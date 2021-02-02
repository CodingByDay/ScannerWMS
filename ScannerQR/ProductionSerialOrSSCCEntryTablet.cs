using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BarCode2D_Receiver;
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;
using WebApp = TrendNET.WMS.Device.Services.WebApp;

namespace ScannerQR
{
    [Activity(Label = "ProductionSerialOrSSCCEntryTablet")]
    public class ProductionSerialOrSSCCEntryTablet : Activity, IBarcodeResult
    {
        private NameValueObject moveHead = (NameValueObject)InUseObjects.Get("MoveHead");
        private NameValueObject moveItem = (NameValueObject)InUseObjects.Get("MoveItem");
        private NameValueObject openWorkOrder = null;
        private bool editMode = false;
        private EditText tbIdent;
        private EditText tbSSCC;
        private EditText tbSerialNum;
        private EditText tbLocation;
        private EditText tbPacking;
        private EditText tbUnits;
        private TextView lbQty;
        private Button btSaveOrUpdate;
        private Button button3;
        private Button button4;
        private Button button5;
        SoundPool soundPool;
        int soundPoolId;
        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {

                case Keycode.F2:
                    if (btSaveOrUpdate.Enabled == true)
                    {
                        BtSaveOrUpdate_Click(this, null);
                    }
                    break;

                case Keycode.F3:
                    if (button3.Enabled == true)
                    {
                        Button3_Click(this, null);
                    }
                    break;

                case Keycode.F4://
                    if (button4.Enabled == true)
                    {
                        Button4_Click(this, null);
                    }
                    break;

                case Keycode.F8:
                    if (button5.Enabled == true)
                    {
                        Button5_Click(this, null);
                    }
                    break;

            }
            return base.OnKeyDown(keyCode, e);
        }
        public void GetBarcode(string barcode)
        {

            if (tbSSCC.HasFocus)
            {
                Sound();
                tbSSCC.Text = barcode;
                tbSerialNum.RequestFocus();
            }
            else if (tbSerialNum.HasFocus)
            {
                Sound();
                tbSerialNum.Text = barcode;
                ProcessSerialNum();
                tbLocation.RequestFocus();
            }
            else if (tbLocation.HasFocus)
            {
                Sound();
                tbLocation.Text = barcode;
            }
        }
        private static bool? checkWorkOrderOpenQty = null;

        private void Sound()
        {
            soundPool.Play(soundPoolId, 1, 1, 0, 0, 1);
        }


        private static bool? getWorkOrderDefaultQty = null;
        private void GetWorkOrderDefaultQty()
        {
            if (getWorkOrderDefaultQty == null)
            {

                try
                {
                    string error;
                    var useObj = Services.GetObject("wodqUse", "", out error);
                    getWorkOrderDefaultQty = useObj == null ? false : useObj.GetBool("Use");
                }
                finally
                {

                }
            }

            if ((bool)getWorkOrderDefaultQty)
            {


                try
                {
                    string error;
                    var qtyObj = Services.GetObject("wodq", openWorkOrder.GetString("Key") + "|" + openWorkOrder.GetString("Ident"), out error);
                    if (qtyObj != null)
                    {
                        var qty = qtyObj.GetDouble("DefaultQty");
                        if (qty < 0)
                        {
                            getWorkOrderDefaultQty = false;
                        }
                        else
                        {
                            tbPacking.Text = qty.ToString(CommonData.GetQtyPicture());
                        }
                    }
                }
                finally
                {
                    // pass
                }
            }
        }

        private bool SaveMoveItem()
        {
            if (string.IsNullOrEmpty(tbPacking.Text.Trim()))
            {
                return true;
            }

            if (tbSSCC.Enabled && string.IsNullOrEmpty(tbSSCC.Text.Trim()))
            {
                string SuccessMessage = string.Format("SSCC koda je obvezen podatek.");
                Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();
                tbSSCC.RequestFocus();
                return false;
            }

            if (tbSerialNum.Enabled && string.IsNullOrEmpty(tbSerialNum.Text.Trim()))
            {
                tbSerialNum.Text = GetNextSerialNum();
                if (string.IsNullOrEmpty(tbSerialNum.Text.Trim()))
                {
                    string SuccessMessage = string.Format("Ni mogoče pridobiti serijske št.");
                    Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();
                    tbSerialNum.RequestFocus();
                    return false;
                }
            }

            if (!CommonData.IsValidLocation(moveHead.GetString("Wharehouse"), tbLocation.Text.Trim()))
            {
                string SuccessMessage = string.Format("Lokacija '" + tbLocation.Text.Trim() + "' ni veljavna za skladišče '" + moveHead.GetString("Wharehouse") + "'!");
                Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();
                tbLocation.RequestFocus();
                return false;
            }

            string error;
            try
            {


                if (tbSSCC.Enabled)
                {
                    var stock = Services.GetObject("sts", tbSSCC.Text.Trim(), out error);
                    if (stock == null)
                    {
                        string SuccessMessage = string.Format("Napaka pri dostopu do web aplikacije" + error);
                        Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();

                        return false;
                    }

                    if (stock.GetBool("ExistsSSCC"))
                    {
                        string SuccessMessage = string.Format("SSCC koda že obstaja");
                        Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();

                        return false;
                    }
                }
                if (string.IsNullOrEmpty(tbPacking.Text.Trim()))
                {
                    string SuccessMessage = string.Format("Količina je obvezan podatek");
                    Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();
                    return false;
                }
                else
                {
                    try
                    {
                        var qty = Convert.ToDouble(tbPacking.Text.Trim());

                        if (qty == 0.0)
                        {
                            string SuccessMessage = string.Format("Količina je obvezen podatek in mora bit različna od nič.");
                            Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();

                            return false;
                        }

                        if (CheckWorkOrderOpenQty())
                        {
                            var max = Math.Abs(openWorkOrder.GetDouble("OpenQty"));
                            if (Math.Abs(qty) > max)
                            {
                                string SuccessMessage = string.Format("Količina (" + qty.ToString(CommonData.GetQtyPicture()) + ") ne sme presegati max. količine (" + max.ToString(CommonData.GetQtyPicture()) + ")!");
                                Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();
                                tbPacking.RequestFocus();
                                return false;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        string SuccessMessage = string.Format("Količina mora biti število (" + e.Message + ")!");
                        Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();

                        tbPacking.RequestFocus();
                        return false;
                    }
                }

                if (string.IsNullOrEmpty(tbUnits.Text.Trim()))
                {
                    string SuccessMessage = string.Format("Št. enota je obvezen podatek!");
                    Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();
                    tbUnits.RequestFocus();

                    return false;
                }
                else
                {
                    try
                    {
                        var qty = Convert.ToDouble(tbUnits.Text.Trim());
                        if (qty == 0.0)
                        {
                            string SuccessMessage = string.Format("Št. enota je obvezen podatek, in more biti različit od nič.");
                            Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();
                            tbUnits.RequestFocus();
                            return false;
                        }
                    }
                    catch (Exception e)
                    {
                        string SuccessMessage = string.Format("Št. enot mora biti število (" + e.Message + ")!");
                        Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();
                        tbUnits.RequestFocus();
                        return false;
                    }
                }

                if (moveItem == null) { moveItem = new NameValueObject("MoveItem"); }
                moveItem.SetInt("HeadID", moveHead.GetInt("HeadID"));
                moveItem.SetString("LinkKey", openWorkOrder.GetString("Key"));
                moveItem.SetInt("LinkNo", 0);
                moveItem.SetString("Ident", openWorkOrder.GetString("Ident"));
                moveItem.SetString("SSCC", tbSSCC.Text.Trim());
                moveItem.SetString("SerialNo", tbSerialNum.Text.Trim());
                moveItem.SetDouble("Packing", Convert.ToDouble(tbPacking.Text.Trim()));
                moveItem.SetDouble("Factor", Convert.ToDouble(tbUnits.Text.Trim()));
                moveItem.SetDouble("Qty", Convert.ToDouble(tbPacking.Text.Trim()) * Convert.ToDouble(tbUnits.Text.Trim()));
                moveItem.SetString("Location", tbLocation.Text.Trim());
                moveItem.SetInt("Clerk", Services.UserID());

                moveItem = Services.SetObject("mi", moveItem, out error);
                if (moveItem == null)
                {
                    string SuccessMessage = string.Format("Napaka pri dostopu do web aplikacije: " + error);
                    Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();

                    return false;
                }
                else
                {
                    InUseObjects.Invalidate("MoveItem");
                    return true;
                }
            }
            finally
            {

            }
        }
        private void ProcessSerialNum()
        {
            if (string.IsNullOrEmpty(tbSerialNum.Text.Trim()))
            {
                tbSerialNum.Text = GetNextSerialNum();
                if (string.IsNullOrEmpty(tbSerialNum.Text.Trim()))
                {

                    tbSerialNum.RequestFocus();
                    return;
                }
            }
            GetWorkOrderDefaultQty();
            // ---
        }
        private bool CheckWorkOrderOpenQty()
        {
            if (checkWorkOrderOpenQty == null)
            {
                try
                {
                    string error;
                    var useObj = Services.GetObject("cwooqUse", "", out error);
                    checkWorkOrderOpenQty = useObj == null ? false : useObj.GetBool("Use");
                }
                finally
                {
                    // pass
                }
            }
            return (bool)checkWorkOrderOpenQty;
        }
        private string GetNextSerialNum()
        {

            try
            {

                string error;
                var ident = openWorkOrder.GetString("Ident");
                var serNumObj = Services.GetObject("sn", ident, out error);
                if (serNumObj != null)
                {
                    return serNumObj.GetString("SerialNo");
                }
                else
                {
                    return "";
                }
            }
            finally
            {
                // wf
            }
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.ProductionSerialOrSSCCEntryTablet);
            //button --------->buttontest
            tbIdent = FindViewById<EditText>(Resource.Id.tbIdent);
            tbSSCC = FindViewById<EditText>(Resource.Id.tbSSCC);
            tbSerialNum = FindViewById<EditText>(Resource.Id.tbSerialNum);
            tbLocation = FindViewById<EditText>(Resource.Id.tbLocation);
            tbPacking = FindViewById<EditText>(Resource.Id.tbPacking);
            tbUnits = FindViewById<EditText>(Resource.Id.tbUnits);
            lbQty = FindViewById<TextView>(Resource.Id.lbQty);
            btSaveOrUpdate = FindViewById<Button>(Resource.Id.btSaveOrUpdate);
            button3 = FindViewById<Button>(Resource.Id.button3);
            button4 = FindViewById<Button>(Resource.Id.button4);
            button5 = FindViewById<Button>(Resource.Id.button5);
            soundPool = new SoundPool(10, Stream.Music, 0);
            soundPoolId = soundPool.Load(this, Resource.Drawable.beep, 1);
            color();
            tbSSCC.RequestFocus();
            btSaveOrUpdate.Click += BtSaveOrUpdate_Click;
            button3.Click += Button3_Click;
            button4.Click += Button4_Click;
            button5.Click += Button5_Click;
            Barcode2D barcode2D = new Barcode2D();
            barcode2D.open(this, this);
            try
            {
                string SuccessMessage = string.Format("Preverjam povezovani DN");
                Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();
                var key = moveHead.GetString("LinkKey");
                string error;
                openWorkOrder = Services.GetObject("wo", key, out error);
                if (openWorkOrder == null) { throw new ApplicationException("Neveljaven povezan dokument: " + key); }
                lbQty.Text = "Količina (" + openWorkOrder.GetDouble("OpenQty").ToString(CommonData.GetQtyPicture()) + ")";
            }
            finally
            {
                // Used to be a wait form.
            }
            var ident = CommonData.LoadIdent(openWorkOrder.GetString("Ident"));
            tbIdent.Text = ident.GetString("Code") + " " + ident.GetString("Name");
            tbSSCC.Enabled = ident.GetBool("isSSCC");
            tbSerialNum.Enabled = ident.GetBool("HasSerialNumber");
        }



        private void color()
        {

            tbSSCC.SetBackgroundColor(Android.Graphics.Color.Aqua);
            tbSerialNum.SetBackgroundColor(Android.Graphics.Color.Aqua);
            tbLocation.SetBackgroundColor(Android.Graphics.Color.Aqua);
        }


        private void Button5_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainMenu));
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (SaveMoveItem())
            {
                var headID = moveHead.GetInt("HeadID");
                //
                SelectSubjectBeforeFinish.ShowIfNeeded(headID);


                try
                {

                    string result;
                    if (WebApp.Get("mode=finish&stock=add&print=" + Services.DeviceUser() + "&id=" + headID.ToString(), out result))
                    {
                        if (result.StartsWith("OK!"))
                        {
                            var id = result.Split('+')[1];
                            string SuccessMessage = string.Format("Zaključevanje uspešno! Št. prevzema:\r\n" + id);
                            Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();
                            AlertDialog.Builder alert = new AlertDialog.Builder(this);
                            alert.SetTitle("Zaključevanje uspešno");
                            alert.SetMessage("Zaključevanje uspešno! Št.prevzema:\r\n" + id);

                            alert.SetPositiveButton("Ok", (senderAlert, args) =>
                            {
                                alert.Dispose();
                            });



                            Dialog dialog = alert.Create();
                            dialog.Show();

                        }
                        else
                        {
                            string SuccessMessage = string.Format("Napaka pri zaključevanju: " + result);
                            Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();


                        }
                    }
                    else
                    {
                        string SuccessMessage = string.Format("Napaka pri klicu web aplikacije: " + result);
                        Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();

                    }
                }
                finally
                {
                    //
                }
            }
        }


        private void Button3_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ProductionEnteredPositionsView));
        }

        private void BtSaveOrUpdate_Click(object sender, EventArgs e)
        {
            if (editMode)
            {
                StartActivity(typeof(ProductionEnteredPositionsView));
            }
            else
            {
                StartActivity(typeof(ProductionSerialOrSSCCEntry));
            }
        }
    }
}