using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;

namespace ScannerQR
{
    [Activity(Label = "RapidTakeover", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class RapidTakeover : Activity, IBarcodeResult
    {
        private EditText tbSSCC;
        private Spinner cbWarehouses;
        private EditText tbLocation;
        private Button btConfirm;
        private Button btLogout;
        private EditText tbIdent;
        private List<ComboBoxItem> data = new List<ComboBoxItem>();
        private EditText tbReceiveLocation;
        private EditText tbRealStock;
        public void GetBarcode(string barcode)
        {
            throw new NotImplementedException();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RapidTakeover);
            tbIdent = FindViewById<EditText>(Resource.Id.tbIdent);
            // Create your application here
            tbSSCC = FindViewById<EditText>(Resource.Id.tbSSCC);
            cbWarehouses = FindViewById<Spinner>(Resource.Id.cbWarehouses);
            tbLocation = FindViewById<EditText>(Resource.Id.tbLocation);
            btConfirm = FindViewById<Button>(Resource.Id.btConfirm);
            btLogout = FindViewById<Button>(Resource.Id.btLogout);
            tbReceiveLocation = FindViewById<EditText>(Resource.Id.tbReceiveLocation);
            tbRealStock = FindViewById<EditText>(Resource.Id.tbRealStock);
            tbIdent.Enabled = false;
            tbLocation.FocusChange += TbLocation_FocusChange;
            color();

      


            var whs = CommonData.ListWarehouses();

            whs.Items.ForEach(wh =>
            {
                data.Add(new ComboBoxItem { ID = wh.GetString("Subject"), Text = wh.GetString("Name") });
            });

            var adapterWarehouse = new ArrayAdapter<ComboBoxItem>(this,
       Android.Resource.Layout.SimpleSpinnerItem, data);
            adapterWarehouse.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            cbWarehouses.Adapter = adapterWarehouse;

            cbWarehouses.ItemSelected += CbWarehouses_ItemSelected;
        }

        private void TbLocation_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            ProcessSSCC();
        }

        private void CbWarehouses_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
           ////////////////
        }



        private void fillDisplayedItem(NameValueObject objectItem)
        {
            tbReceiveLocation.Text = objectItem.GetString("Location");
            tbRealStock.Text = objectItem.GetDouble("RealStock").ToString();
        }
       

        private void ProcessSSCC()
        {

            var sscc = tbSSCC.Text.Trim();
            if (string.IsNullOrEmpty(sscc)) { return; }


            try
            {


                string error;
                var data = Services.GetObject("sscc", tbSSCC.Text, out error);
                if (data == null)
                {
                    Toast.MakeText(this, "Napaka pri preverjanju sscc kode." + error, ToastLength.Long).Show();

                    tbSSCC.Text = "";
                    
                }
                else
                {
                    tbIdent.Text = data.GetString("Ident");
                  

                  
                  
                 
                }
            
            }
            finally
            {

            }




        }

        //string error;

        //var data = Services.GetObject("sscc", tbSSCC.Text, out error);

        //var ident = data.GetString("Ident");
        //Toast.MakeText(this, "Ident je: " + ident, ToastLength.Long).Show();


        private void color()
        {

            tbSSCC.SetBackgroundColor(Android.Graphics.Color.Aqua);
        }
    }
}