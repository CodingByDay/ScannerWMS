using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.Net;
using Android.OS;
using Android.Views;
using Android.Widget;
using BarCode2D_Receiver;
using Com.Toptoche.Searchablespinnerlibrary;
using Microsoft.AppCenter.Crashes;
using Scanner.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;

namespace Scanner
{
    [Activity(Label = "CheckStock", ScreenOrientation = ScreenOrientation.Portrait, NoHistory = true)]
    public class CheckStock : Activity, IBarcodeResult
    {
        private Spinner cbWarehouses;
        private EditText tbLocation;
        private EditText tbIdent;
        private Button btShowStock;
        private Button button1;
        SoundPool soundPool;
        int soundPoolId;
        private TextView lbStock;
        private List<ComboBoxItem> spinnerAdapterList = new List<ComboBoxItem>();
        private int temporaryPositionWarehouse;
        private string stock;
        private Button btnOK;
        private SearchableSpinner spinnerIdent;
        private SearchableSpinner spinnerLocation;
        private List<String> identData = new List<string>();
        private List<string> returnList;
        private List<String> locationData = new List<String>();
        private ArrayAdapter<string> DataAdapterLocation;
        private ArrayAdapter<string> locationAdapter;
        private bool initial = true;

        public void GetBarcode(string barcode)
        {
            if (tbIdent.HasFocus)
            {
                Sound();
                tbIdent.Text = barcode;
                ProcessStock();

            } else if (tbLocation.HasFocus)
            {
                Sound();
                tbLocation.Text = barcode;
            }
        }

        private string LoadStockFromStockSerialNo(string warehouse, string location, string ident)
        {
            try
            {
                string error;
                var stock = Services.GetObjectList("str", out error, warehouse + "|" + location + "|" + ident);
                if (stock == null)
                {
                    string WebError = string.Format("Napaka pri preverjanju zaloge." + error);
                    Toast.MakeText(this, WebError, ToastLength.Long).Show(); tbIdent.Text = "";
                    return "";
                }
                else
                {
                    return string.Join("\r\n", stock.Items.Select(x => "L:" + x.GetString("Location") + " = " + x.GetDouble("RealStock").ToString(CommonData.GetQtyPicture())).ToArray());
                }
            }
            finally
            {
            }
        }


        private void ProcessStock()
        {
            var wh = spinnerAdapterList.ElementAt(temporaryPositionWarehouse);
            if (wh == null)
            {
                string WebError = string.Format("Skladišče ni izbrano.");
                Toast.MakeText(this, WebError, ToastLength.Long).Show(); tbIdent.Text = "";
                return;
            }

            if (!string.IsNullOrEmpty(tbLocation.Text.Trim()))
            {
                if (!CommonData.IsValidLocation(wh.ID, tbLocation.Text.Trim()))
                {
                    string WebError = string.Format("Lokacija ni veljavna");
                    Toast.MakeText(this, WebError, ToastLength.Long).Show(); tbIdent.Text = "";
                    return;
                }
            }

            if (string.IsNullOrEmpty(tbIdent.Text.Trim()))
            {
                string WebError = string.Format("Ident ni podan");
                Toast.MakeText(this, WebError, ToastLength.Long).Show();
                return;
            }

            stock = LoadStockFromStockSerialNo(wh.ID, tbLocation.Text.Trim(), tbIdent.Text.Trim());
            lbStock.Text = "Zaloga:\r\n" + stock;
            isEmptyStock();
        }


        private void isEmptyStock()
        { 
            if(stock != "")
            {
                lbStock.SetBackgroundColor(Android.Graphics.Color.Green);
            } else
            {
                lbStock.SetBackgroundColor(Android.Graphics.Color.Red);
            }
        }

        private void color()
        {

            tbIdent.SetBackgroundColor(Android.Graphics.Color.Aqua);
            tbLocation.SetBackgroundColor(Android.Graphics.Color.Aqua);
        }

        private void Sound()
        {
            soundPool.Play(soundPoolId, 1, 1, 0, 0, 1);
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // Setting F2 to method ProccesStock()
                case Keycode.F2:
                    BtShowStock_Click(this, null);
                    break;

                case Keycode.F9:
                    Button1_Click(this, null);
                    break;

                // return true;

            }
            return base.OnKeyDown(keyCode, e);
        }
        protected async override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            
            // Create your application here.
            SetContentView(Resource.Layout.CheckStock);
            cbWarehouses = FindViewById<Spinner>(Resource.Id.cbWarehouses);
         

            tbLocation = FindViewById<EditText>(Resource.Id.tbLocation);
            tbIdent = FindViewById<EditText>(Resource.Id.tbIdent);
            btShowStock = FindViewById<Button>(Resource.Id.btShowStock);
            btShowStock.Click += BtShowStock_Click;
            button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += Button1_Click;
            spinnerLocation = FindViewById<SearchableSpinner>(Resource.Id.spinnerLocation);

            lbStock = FindViewById<TextView>(Resource.Id.lbStock);

            cbWarehouses.ItemSelected += CbWarehouses_ItemSelected;
            color();
            soundPool = new SoundPool(10, Stream.Music, 0);
            soundPoolId = soundPool.Load(this, Resource.Drawable.beep, 1);
            Barcode2D barcode2D = new Barcode2D();
            barcode2D.open(this, this);
            // First load the warehouses.
            var whs = CommonData.ListWarehouses();

            whs.Items.ForEach(wh =>
            {
                spinnerAdapterList.Add(new ComboBoxItem { ID = wh.GetString("Subject"), Text = wh.GetString("Name") });
            });
         
        
            lbStock = FindViewById<TextView>(Resource.Id.lbStock);

            var adapterWarehouse = new ArrayAdapter<ComboBoxItem>(this,
         Android.Resource.Layout.SimpleSpinnerItem, spinnerAdapterList);
            adapterWarehouse.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            cbWarehouses.Adapter = adapterWarehouse;


            identData = Caching.Caching.SavedList;


            spinnerIdent = FindViewById<SearchableSpinner>(Resource.Id.spinnerIdent);

            spinnerIdent.Prompt = "Iskanje";
            spinnerIdent.SetTitle("Iskanje");
            spinnerIdent.SetPositiveButton("Zapri");
            var DataAdapter = new ArrayAdapter<string>(this,
            Android.Resource.Layout.SimpleSpinnerItem, identData);
            spinnerIdent.Adapter = DataAdapter;
            spinnerIdent.ItemSelected += SpinnerIdent_ItemSelected;
            spinnerLocation.ItemSelected += SpinnerLocation_ItemSelected;
            spinnerLocation.Prompt = "Iskanje";
            spinnerLocation.SetTitle("Iskanje");
            spinnerLocation.SetPositiveButton("Zapri");



            var dw = CommonData.GetSetting("DefaultWarehouse");
            if (!string.IsNullOrEmpty(dw))
            {
                ComboBoxItem.Select(cbWarehouses, spinnerAdapterList, dw);
                tbIdent.RequestFocus();
            }

            var _broadcastReceiver = new NetworkStatusBroadcastReceiver();
            _broadcastReceiver.ConnectionStatusChanged += OnNetworkStatusChanged;
            Application.Context.RegisterReceiver(_broadcastReceiver,
            new IntentFilter(ConnectivityManager.ConnectivityAction));

            var inv = CommonData.GetSetting("UseGuidedInventory");



            if(inv == "1")
            {

            }

        }
        public bool IsOnline()
        {
            var cm = (ConnectivityManager)GetSystemService(ConnectivityService);
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
        private void SpinnerLocation_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (!initial)
            {
                tbLocation.Text = locationData.ElementAt(e.Position);
                Toast.MakeText(this, $"Izbrali ste  {locationData.ElementAt(e.Position)}.", ToastLength.Long).Show();
            }
            else
            {
                tbLocation.Text = string.Empty;
                initial = false;
            }
        }
        private void SpinnerIdent_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            tbIdent.Text = identData.ElementAt(e.Position);
            Toast.MakeText(this, $"Izbrali ste  {identData.ElementAt(e.Position)}", ToastLength.Long).Show();
        }

    
        public override void OnBackPressed()
        {

            HelpfulMethods.releaseLock();

            base.OnBackPressed();
        }

        //protected override void OnPostCreate(Bundle savedInstanceState)
        //{

        //    HelpfulMethods.releaseLock();
        //    base.OnPostCreate(savedInstanceState);

        //}

        private void Button1_Click(object sender, System.EventArgs e)
        {
            this.Finish();
        }

        private void BtShowStock_Click(object sender, System.EventArgs e)
        {
            ProcessStock();
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
                var issuerLocs = Services.GetObjectList("lo", out error, spinnerAdapterList.ElementAt(temporaryPositionWarehouse).Text);
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
        private async void CbWarehouses_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            if (e.Position != 0)
            {
                string toast = string.Format("Izbrali ste: {0}", spinner.GetItemAtPosition(e.Position));
                Toast.MakeText(this, toast, ToastLength.Long).Show();
                temporaryPositionWarehouse = e.Position;
            }
            Toast.MakeText(this, "Pripravljamo listu lokacija.", ToastLength.Long).Show();
            await GetLocationsForGivenWarehouse(spinnerAdapterList.ElementAt(temporaryPositionWarehouse).Text);
            Toast.MakeText(this, "Lista lokacija pripravljena.", ToastLength.Long).Show();
            DataAdapterLocation = new ArrayAdapter<string>(this,
            Android.Resource.Layout.SimpleSpinnerItem, locationData);
            spinnerLocation.Adapter = null;
            spinnerLocation.Adapter = DataAdapterLocation;

        }
    }
}