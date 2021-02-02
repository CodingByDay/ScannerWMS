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
using ScannerQR.Printing;
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;
using WebApp = TrendNET.WMS.Device.Services.WebApp;

namespace ScannerQR
{
    [Activity(Label = "InventoryProcessTablet")]
    public class InventoryProcessTablet : Activity, IBarcodeResult
    {
        private Spinner cbWarehouse;
        private EditText tbLocation;
        private EditText tbIdent;
        private EditText tbTitle;
        private EditText tbSSCC;
        private EditText tbSerialNum;
        private EditText tbPacking;
        private EditText tbUnits;
        private List<ComboBoxItem> warehouseAdapter = new List<ComboBoxItem>();
        private Button btPrint;
        private Button button1;
        private Button btDelete;
        private Button button2;
        private static string selectedWarehouse = "";
        private NameValueObject moveItem = null;
        private TextView lbUnits;
        SoundPool soundPool;
        int soundPoolId;
        private int temporaryPosWarehouse;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.InventoryProcessTablet);
            cbWarehouse = FindViewById<Spinner>(Resource.Id.cbWarehouse);
            tbLocation = FindViewById<EditText>(Resource.Id.tbLocation);
            tbIdent = FindViewById<EditText>(Resource.Id.tbIdent);
            tbTitle = FindViewById<EditText>(Resource.Id.tbTitle);
            tbSSCC = FindViewById<EditText>(Resource.Id.tbSSCC);
            tbSerialNum = FindViewById<EditText>(Resource.Id.tbSerialNum);
            tbPacking = FindViewById<EditText>(Resource.Id.tbPacking);
            tbUnits = FindViewById<EditText>(Resource.Id.tbUnits);
            btPrint = FindViewById<Button>(Resource.Id.btPrint);
            button1 = FindViewById<Button>(Resource.Id.button1);
            btDelete = FindViewById<Button>(Resource.Id.btDelete);
            button2 = FindViewById<Button>(Resource.Id.button2);
            lbUnits = FindViewById<TextView>(Resource.Id.lbUnits);
            soundPool = new SoundPool(10, Stream.Music, 0);
            soundPoolId = soundPool.Load(this, Resource.Drawable.beep, 1);

            cbWarehouse.ItemSelected += CbWarehouse_ItemSelected;
            btPrint.Click += BtPrint_Click;
            button1.Click += Button1_Click;
            btDelete.Click += BtDelete_Click;
            button2.Click += Button2_Click;
            tbIdent.FocusChange += TbIdent_FocusChange;

            tbUnits.FocusChange += TbUnits_FocusChange;
            tbIdent.KeyPress += TbIdent_KeyPress;

            Barcode2D barcode2D = new Barcode2D();
            barcode2D.open(this, this);

            barcode2D.open(this, this);


            var warehouses = CommonData.ListWarehouses();
            if (warehouses != null)
            {
                warehouses.Items.ForEach(wh =>
                {
                    warehouseAdapter.Add(new ComboBoxItem { ID = wh.GetString("Subject"), Text = wh.GetString("Name") });
                });
                if (!string.IsNullOrEmpty(selectedWarehouse))
                {
                    ComboBoxItem.Select(cbWarehouse, warehouseAdapter, selectedWarehouse);
                    tbLocation.RequestFocus();
                }
            }

            if (string.IsNullOrEmpty(tbUnits.Text.Trim())) { tbUnits.Text = "1"; }
            if (CommonData.GetSetting("ShowNumberOfUnitsField") == "1")
            {
                lbUnits.Visibility = ViewStates.Visible;
                tbUnits.Visibility = ViewStates.Visible;
            }

            var adapterIssue = new ArrayAdapter<ComboBoxItem>(this,
           Android.Resource.Layout.SimpleSpinnerItem, warehouseAdapter);

            adapterIssue.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            cbWarehouse.Adapter = adapterIssue;
            color();
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



        private void TbUnits_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            ProcessStock();
        }



        private void TbIdent_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            ProcessLocation();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainMenu));
        }

        private void BtDelete_Click(object sender, EventArgs e)
        {
            try
            {

                string result;
                if (WebApp.Get("mode=delMoveItem&item=" + moveItem.GetInt("ItemID").ToString(), out result))
                {
                    if (result == "OK!")
                    {
                        Toast.MakeText(this, "Pozicija pobrisana!", ToastLength.Long).Show();

                        StartActivity(typeof(InventoryProcess));

                    }
                    else
                    {
                        Toast.MakeText(this, "Napaka pri brisanju pozicije: " + result, ToastLength.Long).Show();

                        return;
                    }
                }
                else
                {
                    Toast.MakeText(this, "Napaka pri dostopu do web aplikacije: " + result, ToastLength.Long).Show();

                    return;
                }
            }
            finally
            {
                //
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            double packing, units, qty;
            ComboBoxItem warehouse;
            string location;
            string ident;
            string serNo;
            string sscc;
            if (!CheckData(out packing, out units, out qty, out warehouse, out location, out ident, out serNo, out sscc)) { return; }
            try
            {
                string result;
                if (WebApp.Get("mode=getInventoryHead&wh=" + warehouse.ID, out result))
                {
                    int headID = -1;
                    try
                    {
                        headID = Convert.ToInt32(result);
                    }
                    catch (Exception ex)
                    {
                        Toast.MakeText(this, "Napaka pri klicu strežniške funkcije (" + ex.Message + "): " + result, ToastLength.Long).Show();

                        return;
                    }

                    if (headID < 0)
                    {
                        cbWarehouse.SetSelection(-1);
                        Toast.MakeText(this, "Za skladišče ni odprtega dokumenta inventure! Zapis ni mogoč.", ToastLength.Long).Show();

                        return;
                    }

                    if (moveItem == null)
                    {
                        moveItem = Services.GetObject("miissl", headID.ToString() + "|" + ident + "|" + serNo + "|" + sscc + "|" + location, out result);
                    }
                    if (moveItem == null)
                    {
                        moveItem = new NameValueObject("MoveItem");
                    }

                    moveItem.SetInt("HeadID", headID);
                    moveItem.SetString("LinkKey", "");
                    moveItem.SetInt("LinkNo", 0);
                    moveItem.SetString("Ident", ident);
                    moveItem.SetString("SerialNo", serNo);
                    moveItem.SetDouble("Packing", packing);
                    moveItem.SetDouble("Factor", units);
                    moveItem.SetDouble("Qty", qty);
                    moveItem.SetString("SSCC", sscc);
                    moveItem.SetString("Location", location);
                    moveItem.SetInt("Clerk", Services.UserID());

                    moveItem = Services.SetObject("mi", moveItem, out result);
                    if (moveItem == null)
                    {
                        Toast.MakeText(this, "Napaka pri dostopu do web aplikacije: " + result, ToastLength.Long).Show();

                        return;
                    }
                    else
                    {
                        Toast.MakeText(this, "Zapis shranjen!", ToastLength.Long).Show();

                        selectedWarehouse = warehouse.ID;

                        StartActivity(typeof(InventoryProcess));

                    }
                }
                else
                {
                    Toast.MakeText(this, "Napaka pri dostopu do web aplikacije: " + result, ToastLength.Long).Show();

                    return;
                }
            }
            finally
            {
                //
            }
        }

        private void BtPrint_Click(object sender, EventArgs e)
        {
            double packing, units, qty;
            ComboBoxItem warehouse;
            string location;
            string ident;
            string serNo;
            string sscc;
            if (!CheckData(out packing, out units, out qty, out warehouse, out location, out ident, out serNo, out sscc)) { return; }
            try
            {

                var nvo = new NameValueObject("PrintInventoryProcess");
                PrintingCommon.SetNVOCommonData(ref nvo);
                nvo.SetDouble("Packing", packing);
                nvo.SetDouble("Factor", units);
                nvo.SetDouble("Qty", qty);
                nvo.SetString("Warehouse", warehouse.ID);
                nvo.SetString("Location", location);
                nvo.SetString("Ident", ident);
                nvo.SetString("SerialNo", serNo);
                nvo.SetString("SSCC", sscc);
                PrintingCommon.SendToServer(nvo);
            }
            finally
            {
                //
            }

        }

        private void CbWarehouse_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            ClearData();
            tbLocation.Text = "";
            tbLocation.RequestFocus();
            Spinner spinner = (Spinner)sender;
            temporaryPosWarehouse = e.Position;
        }

        private void ProcessIdent()
        {
            var ident = tbIdent.Text.Trim();
            if (string.IsNullOrEmpty(ident)) { return; }
            var identObj = CommonData.LoadIdent(ident);
            if (identObj != null)
            {
                tbIdent.Text = identObj.GetString("Code");
                tbTitle.Text = identObj.GetString("Name");

                tbSSCC.Enabled = identObj.GetBool("isSSCC");
                tbSerialNum.Enabled = identObj.GetBool("HasSerialNumber");

                if (tbSSCC.Enabled || tbSerialNum.Enabled)
                {
                    tbSSCC.RequestFocus();
                }
                else
                {
                    ProcessStock();
                }
            }
            else
            {
                tbIdent.Text = "";
                Toast.MakeText(this, "Ident ni pravilen.", ToastLength.Long).Show();

            }
        }

        private void ClearData()
        {
            tbSSCC.Text = "";
            tbSerialNum.Text = "";
            tbPacking.Text = "";
            tbIdent.Text = "";
            tbTitle.Text = "";
        }

        private void ProcessStock()
        {
            var warehouse = warehouseAdapter.ElementAt(temporaryPosWarehouse);
            if (warehouse == null)
            {
                Toast.MakeText(this, "Skladišče ni izbrano!", ToastLength.Long).Show();

                ClearData();
                return;
            }

            var sscc = tbSSCC.Text.Trim();
            if (tbSSCC.Enabled && string.IsNullOrEmpty(sscc))
            {
                Toast.MakeText(this, "SSCC koda ni vnešena!", ToastLength.Long).Show();

                return;
            }

            var serialNum = tbSerialNum.Text.Trim();
            if (tbSerialNum.Enabled && string.IsNullOrEmpty(serialNum))
            {
                Toast.MakeText(this, "Serijska št. ni vnešena!", ToastLength.Long).Show();

                return;
            }

            var ident = tbIdent.Text.Trim();
            if (string.IsNullOrEmpty(ident))
            {
                Toast.MakeText(this, "Ident ni vnešen!", ToastLength.Long).Show();

                return;
            }


            try
            {


                var location = tbLocation.Text.Trim();
                if (!CommonData.IsValidLocation(warehouse.ID, location))
                {
                    Toast.MakeText(this, "Lokacija '" + location + "' ni veljavna za skladišče '" + warehouse.ID + "'!", ToastLength.Long).Show();
                    return;
                }

                string result;
                if (WebApp.Get("mode=getInventoryHead&wh=" + warehouse.ID, out result))
                {
                    var headID = Convert.ToInt32(result);
                    if (headID < 0)
                    {
                        cbWarehouse.SetSelection(-1);
                        Toast.MakeText(this, "Za skladišče ni odprtega dokumenta inventure!", ToastLength.Long).Show();

                        return;
                    }

                    moveItem = Services.GetObject("miissl", headID.ToString() + "|" + tbIdent.Text.Trim() + "|" + tbSerialNum.Text.Trim() + "|" + tbSSCC.Text.Trim() + "|" + location, out result);
                    if (moveItem != null)
                    {
                        tbPacking.Text = moveItem.GetDouble("Packing").ToString(CommonData.GetQtyPicture());
                        tbUnits.Text = moveItem.GetDouble("Factor").ToString("###,###,##0.00");
                        btDelete.Enabled = true;
                    }
                    else
                    {
                        tbPacking.Text = "";
                        tbUnits.Text = "1";
                        btDelete.Enabled = false;
                    }
                }
                else
                {
                    Toast.MakeText(this, "Napaka pri dostopu do web aplikacije: " + result, ToastLength.Long).Show();

                    return;
                }

                tbPacking.RequestFocus();
            }
            finally
            {
                //
            }
        }
        public void GetBarcode(string barcode)
        {
            if (tbSSCC.HasFocus)
            {
                Sound();
                tbSSCC.Text = barcode;
            }
            else if (tbLocation.HasFocus)
            {
                Sound();
                tbLocation.Text = barcode;
                ProcessLocation();

            }
            else if (tbSerialNum.HasFocus)
            {
                Sound();
                tbSerialNum.Text = barcode;
                ProcessStock();
            }
            else if (tbIdent.HasFocus)
            {
                Sound();
                tbIdent.Text = barcode;
                ProcessIdent();
            }
        }


        private void color()
        {
            tbIdent.SetBackgroundColor(Android.Graphics.Color.Aqua);
            tbSSCC.SetBackgroundColor(Android.Graphics.Color.Aqua);
            tbSerialNum.SetBackgroundColor(Android.Graphics.Color.Aqua);
            tbLocation.SetBackgroundColor(Android.Graphics.Color.Aqua);
            tbIdent.SetBackgroundColor(Android.Graphics.Color.Aqua);
            tbSSCC.SetBackgroundColor(Android.Graphics.Color.Aqua);
            tbSerialNum.SetBackgroundColor(Android.Graphics.Color.Aqua);

        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // in smartphone
                case Keycode.F2:
                    if (btPrint.Enabled == true)
                    {
                        BtPrint_Click(this, null);
                    }
                    break;

                case Keycode.F3:
                    if (button1.Enabled == true)
                    {
                        Button1_Click(this, null);
                    }
                    break;


                case Keycode.F4:
                    if (btDelete.Enabled == true)
                    {
                        BtDelete_Click(this, null);
                    }
                    break;

                case Keycode.F8:
                    Button2_Click(this, null);
                    break;

            }
            return base.OnKeyDown(keyCode, e);
        }

        private bool CheckData(out double packing, out double units, out double qty, out ComboBoxItem warehouse, out string location, out string ident, out string serNo, out string sscc)
        {
            packing = 0.0;
            units = 0.0;
            qty = 0.0;
            ident = null;
            serNo = null;
            sscc = null;
            warehouse = null;
            location = null;

            warehouse = warehouseAdapter.ElementAt(temporaryPosWarehouse);
            if (warehouse == null)
            {
                Toast.MakeText(this, "Skladišče ni izbrano!", ToastLength.Long).Show();
                return false;
            }

            location = tbLocation.Text.Trim();
            if (!CommonData.IsValidLocation(warehouse.ID, location))
            {
                Toast.MakeText(this, "Lokacija '" + location + "' ni veljavna za skladišče '" + warehouse.ID + "'!", ToastLength.Long).Show();
                return false;
            }

            sscc = tbSSCC.Text.Trim();
            if (tbSSCC.Enabled && string.IsNullOrEmpty(sscc))
            {
                Toast.MakeText(this, "SSCC koda ni vpisana!", ToastLength.Long).Show();
                return false;
            }

            ident = tbIdent.Text.Trim();
            if (string.IsNullOrEmpty(ident))
            {
                Toast.MakeText(this, "Ident ni vpisan!", ToastLength.Long).Show();
                return false;
            }

            serNo = tbSerialNum.Text.Trim();
            if (tbSerialNum.Enabled && string.IsNullOrEmpty(serNo))
            {
                Toast.MakeText(this, "Serijska št. ni vpisana!", ToastLength.Long).Show();
                return false;
            }

            if (CommonData.LoadIdent(ident) == null) return false;

            try
            {
                packing = Convert.ToDouble(tbPacking.Text);
            }

            catch (Exception ex)

            {
                Toast.MakeText(this, "Količina ni vpisana ali ni število: " + ex.Message, ToastLength.Long).Show();
                return false;
            }


            try
            {
                units = Convert.ToDouble(tbUnits.Text);
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "Št. enot ni vpisano ali ni število: " + ex.Message, ToastLength.Long).Show();
                return false;
            }

            qty = units * packing;

            return true;
        }

        private void ProcessLocation()
        {
            var warehouse = warehouseAdapter.ElementAt(temporaryPosWarehouse);
            if (warehouse == null)
            {
                Toast.MakeText(this, "Skladišče ni izbrano!", ToastLength.Long).Show();

                cbWarehouse.RequestFocus();
                return;
            }

            var location = tbLocation.Text.Trim();
            if (!CommonData.IsValidLocation(warehouse.ID, location))
            {
                Toast.MakeText(this, "Lokacija '" + location + "' ni veljavna za skladišče '" + warehouse.ID + "'!", ToastLength.Long).Show();

                tbLocation.RequestFocus();
                return;
            }
            ClearData();
        }

        private void Sound() /* Sdk contains this method in one class. Probably alot of other possible functionality too. Good resource. */
        {
            soundPool.Play(soundPoolId, 1, 1, 0, 0, 1);
        }


    }
}