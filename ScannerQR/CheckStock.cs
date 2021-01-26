using Android.App;
using Android.Media;
using Android.OS;
using Android.Views;
using Android.Widget;
using BarCode2D_Receiver;
using System.Collections.Generic;
using System.Linq;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;

namespace ScannerQR
{
    [Activity(Label = "CheckStock")]
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
               // 
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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here.
            SetContentView(Resource.Layout.CheckStock);
            // First load the warehouses.
            var whs = CommonData.ListWarehouses();

            whs.Items.ForEach(wh =>
            {
                spinnerAdapterList.Add(new ComboBoxItem { ID = wh.GetString("Subject"), Text = wh.GetString("Name") });
            });
            var dw = CommonData.GetSetting("DefaultWarehouse");
            if (!string.IsNullOrEmpty(dw))
            {
                ComboBoxItem.Select(cbWarehouses, spinnerAdapterList, dw);
                tbIdent.RequestFocus();
            }
            else
            {
                // pass wms select first, nothing happens anyway, 'cause the first one would have already been selected anyway.
            }
            lbStock = FindViewById<TextView>(Resource.Id.lbStock);         
            cbWarehouses = FindViewById<Spinner>(Resource.Id.cbWarehouses);

            var adapterWarehouse = new ArrayAdapter<ComboBoxItem>(this,
            Android.Resource.Layout.SimpleSpinnerItem, spinnerAdapterList);
            adapterWarehouse.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            cbWarehouses.Adapter = adapterWarehouse;
            tbLocation = FindViewById<EditText>(Resource.Id.tbLocation);
            tbIdent = FindViewById<EditText>(Resource.Id.tbIdent);
            btShowStock = FindViewById<Button>(Resource.Id.btShowStock);
            btShowStock.Click += BtShowStock_Click;
            button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += Button1_Click;       
           
            lbStock = FindViewById<TextView>(Resource.Id.lbStock);
          
            cbWarehouses.ItemSelected += CbWarehouses_ItemSelected;
            color();
            soundPool = new SoundPool(10, Stream.Music, 0);
            soundPoolId = soundPool.Load(this, Resource.Drawable.beep, 1);
            Barcode2D barcode2D = new Barcode2D();
            barcode2D.open(this, this);

        
        }

  

        private void Button1_Click(object sender, System.EventArgs e)
        {
            this.Finish();
        }

        private void BtShowStock_Click(object sender, System.EventArgs e)
        {
            ProcessStock();
        }

        private void CbWarehouses_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            if (e.Position != 0)
            {
                string toast = string.Format("Izbrali ste: {0}", spinner.GetItemAtPosition(e.Position));
                Toast.MakeText(this, toast, ToastLength.Long).Show();
                temporaryPositionWarehouse = e.Position;

            }
        }
    }
}