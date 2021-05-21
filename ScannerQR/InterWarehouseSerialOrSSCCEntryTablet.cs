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
using Com.Barcode;
using Scanner;
using Scanner.App;
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;
using WebApp = TrendNET.WMS.Device.Services.WebApp;

namespace Scanner
{
    [Activity(Label = "InterWarehouseSerialOrSSCCEntryTablet", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class InterWarehouseSerialOrSSCCEntryTablet : Activity, IBarcodeResult
    {
        public string barcode;
        // Definitions
        private EditText tbIdent;
        private EditText tbSSCC;
        private EditText tbSerialNum;
        private EditText tbIssueLocation;
        private EditText tbLocation;
        private EditText tbPacking;
        private EditText tbUnits;
        private TextView lbQty;
        private TextView lbUnits;
        private Button button1;
        private Button btSaveOrUpdate;
        private Button button3;
        private Button button5;
        private Button button4;
        private Button button6;
        private NameValueObject moveHead = (NameValueObject)InUseObjects.Get("MoveHead");
        private NameValueObject moveItem = (NameValueObject)InUseObjects.Get("MoveItem");
        private NameValueObjectList docTypes = null;
        private bool target = false;
        private bool editMode = false;
        private EditText lbIdentName;
        private Button finish;
        private IBarcodeResult result;
        private ListView listData;
        private List<ProductionEnteredPositionViewList> data = new List<ProductionEnteredPositionViewList>();
        SoundPool soundPool;
        int soundPoolId;
        private NameValueObject wh;
        private int selected;

        // here...
        public void GetBarcode(string barcode)
        {
            if (!string.IsNullOrEmpty(barcode))
            {
                if (tbIdent.HasFocus)
                {
                    Sound();
                    tbIdent.Text = barcode;
                    ProcessIdent();
                    tbSSCC.RequestFocus();


                }
                else if (tbSSCC.HasFocus)
                {
                    Sound();
                    tbSSCC.Text = barcode;
                    tbSerialNum.RequestFocus();

                }
                else if (tbSerialNum.HasFocus)
                {
                    Sound();
                    tbSerialNum.Text = barcode;
                    tbIssueLocation.RequestFocus();


                }
                else if (tbIssueLocation.HasFocus)
                {
                    Sound();
                    tbIssueLocation.Text = barcode;
                    tbLocation.RequestFocus();
                    ProcessQty();


                }
                else if (tbLocation.HasFocus)
                {
                    if (!String.IsNullOrEmpty(barcode))
                    {
                        Sound();
                        tbLocation.Text = barcode;
                        tbPacking.RequestFocus();
                        fillItems();
                        ProcessQty();
                    }
                }


            }
        }

        private void color()
        {
            tbIdent.SetBackgroundColor(Android.Graphics.Color.Aqua);
            tbSSCC.SetBackgroundColor(Android.Graphics.Color.Aqua);
            tbSerialNum.SetBackgroundColor(Android.Graphics.Color.Aqua);
            tbIssueLocation.SetBackgroundColor(Android.Graphics.Color.Aqua);
            tbLocation.SetBackgroundColor(Android.Graphics.Color.Aqua);

        }



        private bool SaveMoveItem()
        {
            if (string.IsNullOrEmpty(tbIdent.Text.Trim()) && string.IsNullOrEmpty(tbSerialNum.Text.Trim()) && string.IsNullOrEmpty(tbPacking.Text.Trim()))
            {
                return true;
            }

            if (tbSSCC.Enabled && string.IsNullOrEmpty(tbSSCC.Text.Trim()))
            {
                string WebError = string.Format("SSCC koda je obvezen podatek.");
                Toast.MakeText(this, WebError, ToastLength.Long).Show();
                tbSSCC.RequestFocus();
                return false;
            }

            if (tbSerialNum.Enabled && string.IsNullOrEmpty(tbSerialNum.Text.Trim()))
            {
                string WebError = string.Format("Serijaska št. je obvezen podatek.");
                Toast.MakeText(this, WebError, ToastLength.Long).Show();

                tbSerialNum.RequestFocus();
                return false;
            }

            if (string.IsNullOrEmpty(tbPacking.Text.Trim()))
            {
                string WebError = string.Format("Količina je obvezan podatek.");
                Toast.MakeText(this, WebError, ToastLength.Long).Show();

                tbPacking.RequestFocus();
                return false;
            }
            else
            {
                try
                {
                    var qty = Convert.ToDouble(tbPacking.Text.Trim());
                    if (qty == 0.0)
                    {
                        string WebError = string.Format("Količina je obvezan podatek in mora biti različna od nič");
                        Toast.MakeText(this, WebError, ToastLength.Long).Show();

                        tbPacking.RequestFocus();
                        return false;
                    }

                    var stockQty = GetStock(moveHead.GetString("Issuer"), tbIssueLocation.Text.Trim(), tbSSCC.Text.Trim(), tbSerialNum.Text.Trim(), tbIdent.Text.Trim());
                    if (Double.IsNaN(stockQty))
                    {
                        string WebError = string.Format("Zaloga ni znana, vpišite potrebne podatke");
                        Toast.MakeText(this, WebError, ToastLength.Long).Show();

                        //  SelectNext(tbIdent);
                        return false;
                    }
                    if (Math.Abs(qty) > Math.Abs(stockQty))
                    {
                        string WebError = string.Format("Količina ne sme presegati zaloge!");
                        Toast.MakeText(this, WebError, ToastLength.Long).Show();

                        tbPacking.RequestFocus();
                        return false;
                    }
                }
                catch (Exception e)
                {
                    string WebError = string.Format("Količina mora biti število (" + e.Message + ")!");
                    Toast.MakeText(this, WebError, ToastLength.Long).Show();
                    tbPacking.RequestFocus();
                    return false;
                }
            }

            if (string.IsNullOrEmpty(tbUnits.Text.Trim()))
            {
                string WebError = string.Format("Št. enota je obavezan podatek.");
                Toast.MakeText(this, WebError, ToastLength.Long).Show();
                return false;
            }
            else
            {
                try
                {
                    var units = Convert.ToDouble(tbUnits.Text.Trim());
                    if (units == 0.0)
                    {
                        string WebError = string.Format("Št. enota je obavezan podatek in mora biti različit od nič.");
                        Toast.MakeText(this, WebError, ToastLength.Long).Show();
                        tbUnits.RequestFocus();
                        return false;
                    }
                }
                catch (Exception e)
                {
                    string WebError = string.Format("Št. enot mora biti število (" + e.Message + ")!");
                    Toast.MakeText(this, WebError, ToastLength.Long).Show();
                    tbPacking.RequestFocus();
                    return false;
                }
            }

            if (!CommonData.IsValidLocation(moveHead.GetString("Issuer"), tbIssueLocation.Text.Trim()))
            {
                string WebError = string.Format("Prejemna lokacija" + tbLocation.Text.Trim() + "ni veljavna za sladišće" + moveHead.GetString("Issuer") + "!");
                Toast.MakeText(this, WebError, ToastLength.Long).Show();
                tbIssueLocation.RequestFocus();
                return false;
            }

            if (!CommonData.IsValidLocation(moveHead.GetString("Receiver"), tbLocation.Text.Trim()))
            {
                string WebError = string.Format("Prejemna lokacija" + tbLocation.Text.Trim() + "ni veljavna za sladišće" + moveHead.GetString("Receiver") + "!");
                Toast.MakeText(this, WebError, ToastLength.Long).Show();
                tbLocation.RequestFocus();
                return false;
            }

            try
            {

                if (moveItem == null) { moveItem = new NameValueObject("MoveItem"); }
                moveItem.SetInt("HeadID", moveHead.GetInt("HeadID"));
                moveItem.SetString("LinkKey", "");
                moveItem.SetInt("LinkNo", 0);
                moveItem.SetString("Ident", tbIdent.Text.Trim());
                moveItem.SetString("SSCC", tbSSCC.Text.Trim());
                moveItem.SetString("SerialNo", tbSerialNum.Text.Trim());
                moveItem.SetDouble("Packing", Convert.ToDouble(tbPacking.Text.Trim()));
                moveItem.SetDouble("Factor", Convert.ToDouble(tbUnits.Text.Trim()));
                moveItem.SetDouble("Qty", Convert.ToDouble(tbPacking.Text.Trim()) * Convert.ToDouble(tbUnits.Text.Trim()));
                moveItem.SetInt("Clerk", Services.UserID());
                moveItem.SetString("Location", tbLocation.Text.Trim());
                moveItem.SetString("IssueLocation", tbIssueLocation.Text.Trim());

                string error;
                moveItem = Services.SetObject("mi", moveItem, out error);
                if (moveItem == null)
                {
                    string WebError = string.Format("Napaka pri dostopu do web aplikacije." + error);
                    Toast.MakeText(this, WebError, ToastLength.Long).Show();
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
                // pass
            }
        }

        private void ProcessQty()
        {
            var sscc = tbSSCC.Text.Trim();
            if (tbSSCC.Enabled && string.IsNullOrEmpty(sscc)) { return; }

            var serialNo = tbSerialNum.Text.Trim();
            if (tbSerialNum.Enabled && string.IsNullOrEmpty(serialNo)) { return; }

            var ident = tbIdent.Text.Trim();
            if (string.IsNullOrEmpty(ident)) { return; }

            var identObj = CommonData.LoadIdent(ident);
            if (identObj != null)
            {
                ident = identObj.GetString("Code");
                tbIdent.Text = ident;
            }

            if (!CommonData.IsValidLocation(moveHead.GetString("Issuer"), tbIssueLocation.Text.Trim()))
            {
                string SuccessMessage = string.Format("Izdajna lokacija" + tbIssueLocation.Text.Trim() + "ni veljavna za skladisće" + moveHead.GetString("Issuer") + "'!");
                Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();
                tbIssueLocation.RequestFocus();

                return;
            }
            //var stockQty = LoadStockFromLocation(moveHead.GetString("Issuer"), tbIssueLocation.Text.Trim(), tbIdent.Text.Trim());

            var stockQty = GetStock(moveHead.GetString("Issuer"), tbIssueLocation.Text.Trim(), sscc, serialNo, ident);
            string WebError = string.Format(stockQty.ToString());
            Toast.MakeText(this, WebError, ToastLength.Long).Show();
            if (!Double.IsNaN(stockQty))
            {
                tbPacking.Text = stockQty.ToString(CommonData.GetQtyPicture());
                lbQty.Text = "Količina (" + stockQty.ToString(CommonData.GetQtyPicture()) + ")";
            }
            else
            {
                tbPacking.Text = "";
                lbQty.Text = "Količina (?)";
            }

            tbPacking.RequestFocus();
            fillItems();
        }


        //public void hideSoftKeyboard ()
        //{
        //	var currentFocus = Activity.CurrentFocus;
        //	if (currentFocus != null) {
        //		InputMethodManager inputMethodManager = (InputMethodManager)Activity.GetSystemService(Context.InputMethodService);
        //      inputMethodManager.HideSoftInputFromWindow(currentFocus.WindowToken, HideSoftInputFlags.None);
        //	}
        private Double LoadStockFromLocation(string warehouse, string location, string ident)
        {

            try
            {
                string error;
                var stock = Services.GetObject("str", warehouse + "|" + location + "|" + ident, out error);
                if (stock == null)
                {
                    string SuccessMessage = string.Format("Napaka pri preverjenju zaloge." + error);
                    Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();

                    return Double.NaN;
                }
                else
                {
                    return stock.GetDouble("RealStock");
                }
            }
            finally
            {
                // pass
            }
        }


        private double GetStock(string warehouse, string location, string sscc, string serialNum, string ident)
        {
            var wh = CommonData.GetWarehouse(warehouse);
            if (!wh.GetBool("HasStock"))
                if (tbSerialNum.Enabled)
                {
            
                    return LoadStockFromPAStockSerialNo(warehouse, ident, serialNum);
                }
                else
                {
                    return LoadStockFromPAStock(warehouse, ident);
                }

            else
            {
                return LoadStockFromStockSerialNo(warehouse, location, sscc, serialNum, ident);
            }

        }
      

        private Double LoadStockFromStockSerialNo(string warehouse, string location, string sscc, string serialNum, string ident)
        {

            try
            {
                string error;
                var stock = Services.GetObject("str", warehouse + "|" + location + "|" + sscc + "|" + serialNum + "|" + ident, out error);
                if (stock == null)
                {
                    string SuccessMessage = string.Format("Napaka pri preverjenju zaloge." + error);
                    Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();

                    return Double.NaN;
                }
                else
                {
                    
                    return stock.GetDouble("RealStock");
                }
            }
            finally
            {
                // pass
            }
        }


        private Double LoadStockFromPAStock(string warehouse, string ident)
        {
            try
            {
                string error;
                var stock = Services.GetObject("pas", warehouse + "|" + ident, out error);
                if (stock == null)
                {
                    string SuccessMessage = string.Format("Napaka pri preverjenju zaloge." + error);
                    return Double.NaN;
                }
                else
                {
                    return stock.GetDouble("Qty");
                }
            }
            finally
            {
                // pass
            }
        }

        private Double LoadStockFromPAStockSerialNo(string warehouse, string ident, string serialNo)
        {

            try
            {

                string error;
                var stock = Services.GetObject("pass", warehouse + "|" + ident + "|" + serialNo, out error);
                if (stock == null)
                {
                    string SuccessMessage = string.Format("Napaka pri preverjanju zaloge" + error);
                    return Double.NaN;
                }
                else
                {
                    return stock.GetDouble("Qty");
                }
            }
            finally
            {
                // pass 
            }
        }

        private void Sound()
        {
            soundPool.Play(soundPoolId, 1, 1, 0, 0, 1);

        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            // Create your application here
            SetContentView(Resource.Layout.InterWarehouseSerialOrSSCCEntryTablet);
            tbIdent = FindViewById<EditText>(Resource.Id.tbIdent);
            tbSSCC = FindViewById<EditText>(Resource.Id.tbSSCC);
            tbSerialNum = FindViewById<EditText>(Resource.Id.tbSerialNum);
            tbIssueLocation = FindViewById<EditText>(Resource.Id.tbIssueLocation);
            tbLocation = FindViewById<EditText>(Resource.Id.tbLocation);
            tbPacking = FindViewById<EditText>(Resource.Id.tbPacking);
            tbUnits = FindViewById<EditText>(Resource.Id.tbUnits);
            listData = FindViewById<ListView>(Resource.Id.listData);
            // labels
            lbQty = FindViewById<TextView>(Resource.Id.lbQty);
            lbUnits = FindViewById<TextView>(Resource.Id.lbUnits);
            InterwarehousSerialOrSCCCEntryAdapter adapter = new InterwarehousSerialOrSCCCEntryAdapter(this, data);
            listData.Adapter = adapter;
            // Buttons
            btSaveOrUpdate = FindViewById<Button>(Resource.Id.btSaveOrUpdate);
            wh = new NameValueObject();
            tbIdent.KeyPress += TbIdent_KeyPress;
            tbPacking.KeyPress += TbPacking_KeyPress;

            tbPacking.FocusChange += TbPacking_FocusChange;
            button1 = FindViewById<Button>(Resource.Id.button1);
            button3 = FindViewById<Button>(Resource.Id.button3);
            button5 = FindViewById<Button>(Resource.Id.button5);
            button4 = FindViewById<Button>(Resource.Id.button4);
            button6 = FindViewById<Button>(Resource.Id.button6);

            color();
            listData.ItemClick += ListData_ItemClick;
            button6.Click += Button6_Click;
            button4.Click += Button4_Click;
            button5.Click += Button5_Click;
            button3.Click += Button3_Click;
            button1.Click += Button1_Click;

            btSaveOrUpdate.Click += BtSaveOrUpdate_Click;

            lbIdentName = FindViewById<EditText>(Resource.Id.lbIdentName);
            soundPool = new SoundPool(10, Stream.Music, 0);
            soundPoolId = soundPool.Load(this, Resource.Drawable.beep, 1);
            Barcode2D barcode2D = new Barcode2D();
            barcode2D.open(this, this);

            barcode2D.open(this, this);



            if (InterWarehouseBusinessEventSetup.success == true)
            {
                string toast = string.Format(moveHead.GetString("Issuer"));
                Toast.MakeText(this, toast, ToastLength.Long).Show();
                // string SuccessMessage = string.Format("Uspešno poslani podatki.");
                //   Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();
            }

            if (moveHead == null) { throw new ApplicationException("moveHead not known at this point?!"); }

            docTypes = CommonData.ListDocTypes("I|N");

            if (moveItem != null)
            {
                tbSerialNum.Text = moveItem.GetString("SerialNo");
                tbPacking.Text = moveItem.GetDouble("Packing").ToString();
                tbUnits.Text = moveItem.GetDouble("Factor").ToString();
                tbSSCC.Text = moveItem.GetString("SSCC");
                tbIdent.Text = moveItem.GetString("Ident");
                ProcessIdent();
                tbLocation.Text = moveItem.GetString("Location");
                tbIssueLocation.Text = moveItem.GetString("IssueLocation");
                btSaveOrUpdate.Text = "Spremeni serijsko št. - F2";

                editMode = true;
                tbSSCC.Enabled = false;
            }

            if (editMode)
            {
                tbPacking.RequestFocus();
            }
            else
            {
                tbIdent.RequestFocus();
            }

            if (string.IsNullOrEmpty(tbUnits.Text.Trim())) { tbUnits.Text = "1"; }
            if (CommonData.GetSetting("ShowNumberOfUnitsField") == "1")
            {
                lbUnits.Visibility = ViewStates.Visible;
                tbUnits.Visibility = ViewStates.Visible;
            }


   
        }

        private void ListData_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            selected = e.Position;
            var item = data.ElementAt(selected);
            tbLocation.Text = item.Location.ToString();
        }

        private void fillItems()
        {

            string error;
            var stock = Services.GetObjectList("str", out error, moveHead.GetString("Issuer") + "||" + tbIdent.Text); /* Defined at the beggining of the activity. */
            var number = stock.Items.Count();
            string SuccessMessage = string.Format(number.ToString());
            Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();

            if (stock != null)
            {
                stock.Items.ForEach(x =>
                {
                    data.Add(new ProductionEnteredPositionViewList
                    {
                        Ident = x.GetString("Ident"),
                        Location = x.GetString("Location"),
                        Qty = x.GetDouble("RealStock").ToString(),
                        SerialNumber = x.GetString("SerialNo")

                    });
                });

            }



        }

        private void TbPacking_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            ProcessQty();
        }

        private void TbLocation_KeyPress(object sender, View.KeyEventArgs e)
        {
            e.Handled = false;
            if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
            {
                //add your logic here 
                ProcessQty();
                e.Handled = true;
            }
        }



        private void TbPacking_KeyPress(object sender, View.KeyEventArgs e)
        {
            e.Handled = false;
            if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
            {
                //add your logic here 
                ProcessIdent();
                e.Handled = true;
            }
        }

        private void TbIdent_KeyPress(object sender, View.KeyEventArgs e)
        {
            e.Handled = false;
            if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
            {
                //add your logic here 
                ProcessIdent();
                e.Handled = true;
            }
        }





        private void Button1_Click(object sender, EventArgs e)
        {
            var qty = tbPacking.Text;
            if (qty.Trim().StartsWith("-"))
            {
                qty = qty.Trim().Substring(1);
            }
            else
            {
                qty = "-" + qty;
            }
            tbPacking.Text = qty;
        }

        private void BtSaveOrUpdate_Click(object sender, EventArgs e)
        {
            if (SaveMoveItem())
            {
                if (editMode)
                {
                    StartActivity(typeof(InterWarehouseEnteredPositionsViewTablet));
                }
                else
                {

                    StartActivity(typeof(InterWarehouseSerialOrSSCCEntryTablet));
                }
                // Close();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (SaveMoveItem())
            {
                StartActivity(typeof(InterWarehouseSerialOrSSCCEntryTablet));

            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (SaveMoveItem())
            {

                try
                {
                    var headID = moveHead.GetInt("HeadID");

                    string result;
                    if (WebApp.Get("mode=finish&stock=move&print=" + Services.DeviceUser() + "&id=" + headID.ToString(), out result))
                    {
                        if (result.StartsWith("OK!"))
                        {
                            var id = result.Split('+')[1];
                            string SuccessMessage = string.Format("Zaključevanje uspešno! Št. prenosa: \r\n" + id);
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
                            string SuccessMessage = string.Format("Napaka pri zaključevanju");
                            Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();
                        }
                    }
                    else
                    {
                        string SuccessMessage = string.Format("Napaka pri klicu web aplikacije");
                        Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();
                    }
                }
                finally
                {
                    //
                }
            }

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(InterWarehouseEnteredPositionsViewTablet));
        }


        private void Button6_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainMenu));
        }

        private void ProcessIdent()
        {
            var ident = CommonData.LoadIdent(tbIdent.Text.Trim());
            if (ident == null)
            {
                tbIdent.Text = "";
                lbIdentName.Text = "";
                return;
            }

            if (CommonData.GetSetting("IgnoreStockHistory") != "1")
            {

                try
                {


                    string error;
                    var recommededLocation = Services.GetObject("rl", ident.GetString("Code") + "|" + moveHead.GetString("Receiver"), out error);
                    if (recommededLocation != null)
                    {
                        tbLocation.Text = recommededLocation.GetString("Location");
                    }
                }
                finally
                {
                    string toast = new string("Uspešno procesiran ident.");
                    Toast.MakeText(this, toast, ToastLength.Long).Show();
                }
            }

            lbIdentName.Text = ident.GetString("Name");
            tbSSCC.Enabled = ident.GetBool("isSSCC");
            tbSerialNum.Enabled = ident.GetBool("HasSerialNumber");

        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // in smartphone
                case Keycode.F1:
                    if (button1.Enabled == true)
                    {
                        Button1_Click(this, null);
                    }
                    break;
              


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

                case Keycode.F4:
                    if (button5.Enabled == true)
                    {
                        Button5_Click(this, null);
                    }
                    break;


                case Keycode.F8:
                    if (button6.Enabled == true)
                    {
                        Button6_Click(this, null);
                    }
                    break;


            }
            return base.OnKeyDown(keyCode, e);
        }



    }
}