﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BarCode2D_Receiver;
using Com.Toptoche.Searchablespinnerlibrary;
using Microsoft.AppCenter.Crashes;
using Scanner.App;
using Scanner.Printing;
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;
using WebApp = TrendNET.WMS.Device.Services.WebApp;

namespace Scanner
{
    [Activity(Label = "InventoryProcess", ScreenOrientation = ScreenOrientation.Portrait)]
    public class InventoryProcess : Activity, IBarcodeResult
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
        private TextView lbPacking;
        SoundPool soundPool;
        int soundPoolId;
        private int temporaryPosWarehouse;
        private SearchableSpinner spinnerIdent;
        private List<String> identData = new List<string>();
        private SearchableSpinner spinnerLocation;
        private ArrayAdapter<string> locationAdapter;
        private List<string> locationData = new List<string>();
        private List<string> returnList;
        private string guided;
        private bool afterSerial;
        private bool leaveClearFunction = false;

        public ArrayAdapter<string> DataAdapterLocation { get; private set; }

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.InventoryProcess);
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
            lbPacking = FindViewById<TextView>(Resource.Id.lbPacking);

            soundPool = new SoundPool(10, Stream.Music, 0);
            soundPoolId = soundPool.Load(this, Resource.Drawable.beep, 1);
            spinnerLocation = FindViewById<SearchableSpinner>(Resource.Id.spinnerLocation);
            cbWarehouse.ItemSelected += CbWarehouse_ItemSelected;
            btPrint.Click += BtPrint_Click;
            button1.Click += Button1_Click;
            btDelete.Click += BtDelete_Click;
            button2.Click += Button2_Click;
            tbIdent.FocusChange += TbIdent_FocusChange;
            tbSSCC.FocusChange += TbSSCC_FocusChange;
            tbUnits.FocusChange += TbUnits_FocusChange;
            tbIdent.KeyPress += TbIdent_KeyPress;
            tbPacking.FocusChange += TbPacking_FocusChange;
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
            identData = Caching.Caching.SavedList;
            spinnerIdent = FindViewById<SearchableSpinner>(Resource.Id.spinnerIdent);
            spinnerIdent.Prompt = "Iskanje";
            spinnerIdent.SetTitle("Iskanje");
            spinnerIdent.SetPositiveButton("Zapri");
            var DataAdapter = new ArrayAdapter<string>(this,
            Android.Resource.Layout.SimpleSpinnerItem, identData);
            spinnerIdent.Adapter = DataAdapter;
            spinnerIdent.ItemSelected += SpinnerIdent_ItemSelected;
            spinnerIdent.Adapter = DataAdapter;
            spinnerLocation.ItemSelected += SpinnerLocation_ItemSelected;
            var _broadcastReceiver = new NetworkStatusBroadcastReceiver();
            _broadcastReceiver.ConnectionStatusChanged += OnNetworkStatusChanged;
            Application.Context.RegisterReceiver(_broadcastReceiver,
            new IntentFilter(ConnectivityManager.ConnectivityAction));
            guided = CommonData.GetSetting("UseGuidedInventory");
            if(guided != null && guided == "1") { 
                tbSSCC.RequestFocus();
            } else
            {
                tbLocation.RequestFocus();
            }
            tbPacking.Enabled = true;
        }

        

        private void TbPacking_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
 
         
            
        }

        private void TbSSCC_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            if (guided == "1")
            {
                string error;
                var dataObject = Services.GetObject("sscc", tbSSCC.Text, out error);
                var ident = dataObject.GetString("Ident");
                var loadIdent = CommonData.LoadIdent(ident);
                string idname = loadIdent.GetString("Name");
                if (string.IsNullOrEmpty(ident)) { return; }
                if (loadIdent != null)
                {
                    tbSerialNum.Enabled = loadIdent.GetBool("HasSerialNumber");
                }
                var serial = dataObject.GetString("SerialNo");
                var location = dataObject.GetString("Location");
                var warehouse = dataObject.GetString("Warehouse");



              //  ComboBoxItem.Select(cbWarehouse, warehouseAdapter, warehouse);
                leaveClearFunction = true;
                // All data is present and this is working properly.
                tbIdent.Text = ident;
                tbLocation.Text = location;
                tbSerialNum.Text = serial;

                if (loadIdent.GetBool("HasSerialNumber"))
                {
                    tbSerialNum.Text = serial;
                    tbSerialNum.SetBackgroundColor(Android.Graphics.Color.Aqua);

                }
                else
                {
                    tbSerialNum.SetBackgroundColor(Android.Graphics.Color.Red);
                }

                tbLocation.Text = location;
                tbTitle.Text = idname;
                ProcessStock();


            }


        }




        public bool IsOnline()
        {
            var cm = (ConnectivityManager) GetSystemService(ConnectivityService);
            return cm.ActiveNetworkInfo == null ? false : cm.ActiveNetworkInfo.IsConnected;

        }

        private void OnNetworkStatusChanged(object sender, EventArgs e)
        {
            if (IsOnline())
            {
                
                try
                {
                    LoaderManifest.LoaderManifestLoopStop(this);
                }
                catch (Exception err)
                {
                    Crashes.TrackError(err);
                }
            }
            else
            {
                LoaderManifest.LoaderManifestLoop(this);
            }
        }



        private void SpinnerIdent_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            tbIdent.Text = identData.ElementAt(e.Position);
        }


        private void SpinnerLocation_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            tbLocation.Text = locationData.ElementAt(e.Position);
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
         
        }

       

        private void TbIdent_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            ProcessLocation();

            if (guided != "1")
            {
                var loadIdent = CommonData.LoadIdent(tbIdent.Text);

                if (loadIdent != null)
                {
                    tbSerialNum.Enabled = loadIdent.GetBool("HasSerialNumber");


                    if (loadIdent.GetBool("HasSerialNumber"))
                    {
                        afterSerial = true;
                    } else
                    {
                        ProcessStock();

                    }
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainMenu));
            HelpfulMethods.clearTheStack(this);
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
                        HelpfulMethods.clearTheStack(this);

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
            }
        }

        private string LoadStock(string warehouse, string location, string sscc, string serialNum, string ident)
        {
            try
            {
                string error;
                NameValueObject stock = new NameValueObject();
                if (!String.IsNullOrEmpty(serialNum) && !String.IsNullOrEmpty(sscc))
                {
                     stock = Services.GetObject("str", warehouse + "|" + location + "|" + sscc + "|" + serialNum + "|" + ident, out error);
                } else if (!String.IsNullOrEmpty(sscc) && String.IsNullOrEmpty(serialNum))
                {
                     stock = Services.GetObject("str", warehouse + "|" + location + "|" + sscc + "||" + ident, out error);

                }
                else if(String.IsNullOrEmpty(sscc) && !String.IsNullOrEmpty(serialNum)) {
                     stock = Services.GetObject("str", warehouse + "|" + location + "||" + serialNum + "|" + ident, out error);

                } else
                {
                    stock = Services.GetObject("str", warehouse + "|" + location + "|||" + ident, out error);
                }

                return stock.GetDouble("RealStock").ToString(CommonData.GetQtyPicture());
            }
            finally
            {

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
                        HelpfulMethods.clearTheStack(this);

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
            }

        }
        private async Task GetLocationsForGivenWarehouse(string warehouse)
        {
            await Task.Run(() =>
            {
                locationAdapter = new ArrayAdapter<string>(this,
                    Android.Resource.Layout.SimpleSpinnerItem, locationData);

                locationData.Clear();
                List<string> result = new List<string>();
                string error;
                var issuerLocs = Services.GetObjectList("lo", out error, warehouseAdapter.ElementAt(temporaryPosWarehouse).Text);
                var debi = issuerLocs.Items.Count();
                if (issuerLocs == null)
                {
                    Toast.MakeText(this, "Prišlo je do napake", ToastLength.Long).Show();
                }
                else
                {
                    issuerLocs.Items.ForEach(x =>
                    {
                        var location = x.GetString("LocationID");
                        locationData.Add(location);
                        // Notify the adapter state change!
                    });


                }
            });
        }

        private async void CbWarehouse_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
                var warehouse = warehouseAdapter.ElementAt(e.Position);
                string result;
                if (WebApp.Get("mode=getInventoryHead&wh=" + warehouse.ID, out result))
                {
                    var headID = Convert.ToInt32(result);
                    if (headID < 0)
                    {
                        cbWarehouse.SetSelection(temporaryPosWarehouse, true);
                        Toast.MakeText(this, "Za skladišče ni odprtega dokumenta inventure!", ToastLength.Long).Show();

                        return;
                    }
                }
                tbLocation.Text = "";
                var guided = CommonData.GetSetting("UseGuidedInventory");
                if (guided != "1")
                {
                    tbLocation.RequestFocus();
                }
                Spinner spinner = (Spinner)sender;

                if (!leaveClearFunction)
                {
                    ClearData();
                }
                temporaryPosWarehouse = e.Position;
                await GetLocationsForGivenWarehouse(warehouseAdapter.ElementAt(temporaryPosWarehouse).Text);
                Toast.MakeText(this, "Lista lokacija pripravljena.", ToastLength.Short).Show();


                DataAdapterLocation = new ArrayAdapter<string>(this,
                Android.Resource.Layout.SimpleSpinnerItem, locationData);

                spinnerLocation.Adapter = null;
                spinnerLocation.Adapter = DataAdapterLocation;
                leaveClearFunction = false;
           


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

                if(tbSSCC.Enabled&&tbSerialNum.Enabled) {
                    result = LoadStock(warehouse.ID, location, sscc, serialNum, ident);

                } else if (tbSSCC.Enabled && !tbSerialNum.Enabled) {
                    result = LoadStock(warehouse.ID, location, sscc, string.Empty, ident);
                }
                else if (!tbSSCC.Enabled&&tbSerialNum.Enabled)
                {
                    result = LoadStock(warehouse.ID, location, string.Empty, tbSerialNum.Text, ident);
                } else
                {
                    result = LoadStock(warehouse.ID, location, string.Empty, string.Empty, ident);
                }
                
                tbPacking.Enabled = true;
                lbPacking.Text = $"Zaloga ({result})";
                tbPacking.Text = result;

            }
            finally
            {
            }
        }
        public void GetBarcode(string barcode)
        {
            if (tbSSCC.HasFocus)
            {
                if (guided == "1")
                {
                    Sound();
                    tbSSCC.Text = barcode;
                    string error;
                    var dataObject = Services.GetObject("sscc", tbSSCC.Text, out error);
                    var ident = dataObject.GetString("Ident");
                    var loadIdent = CommonData.LoadIdent(ident);
                    string idname = loadIdent.GetString("Name");
                    if (string.IsNullOrEmpty(ident)) { return; }
                    if (loadIdent != null)
                    {
                        tbSerialNum.Enabled = loadIdent.GetBool("HasSerialNumber");
                    }
                    var serial = dataObject.GetString("SerialNo");
                    var location = dataObject.GetString("Location");
                    var warehouse = dataObject.GetString("Warehouse");

                    leaveClearFunction = true;

                    // All data is present and this is working properly.
                    tbIdent.Text = ident;
                    tbLocation.Text = location;
                    tbSerialNum.Text = serial;
                    if (loadIdent.GetBool("HasSerialNumber"))
                    {
                        tbSerialNum.Text = serial;
                        tbSerialNum.SetBackgroundColor(Android.Graphics.Color.Aqua);

                    }
                    else
                    {
                        tbSerialNum.SetBackgroundColor(Android.Graphics.Color.Red);
                    }
                    tbLocation.Text = location;
                    tbTitle.Text = idname;



                    ProcessStock();
                  
                } else
                {
                    tbSSCC.Text = barcode;
                }
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
            tbPacking.SetBackgroundColor(Android.Graphics.Color.Aqua);         
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
         
        }

        private void Sound() /* Sdk contains this method in one class. Probably alot of other possible functionality too. Good resource. */
        {
            soundPool.Play(soundPoolId, 1, 1, 0, 0, 1);
        }


    }
}