using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Scanner.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrendNET.WMS.Device.Services;

namespace Scanner
{
    [Activity(Label = "MorePallets")]
    public class MorePalletsClass : Activity, IBarcodeResult
    {
        //lvCardMore
        //btConfirm
        //btLogin
        private ListView lvCardMore;
        private Button btConfirm;
        private Button btLogin;
        private List<MorePallets> data = new List<MorePallets>();

        public void GetBarcode(string barcode)
        {
            if (barcode != "Scan fail")
            {

                FilData(barcode);
            }
        }

        private void FilData(string barcode)
        {
            if(!String.IsNullOrEmpty(barcode))
            {
                string error;

                var data = Services.GetObject("sscc", barcode, out error);
                if (data != null)
                {
                        var serial = data.GetString("SerialNo");
                        var location = data.GetString("Location");
                        MorePallets pallets = new MorePallets();
                         pallets.Ident = barcode;
                         pallets.Name = barcode;
                         pallets.Quantity = barcode;
                         pallets.Serial = serial;
                         pallets.SSCC = barcode; 
                       
                   
                    
                    
                }
                else
                {
                    return;
                }
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

                // Create your application here
                SetContentView(Resource.Layout.MorePalletsClass);
                lvCardMore = FindViewById<ListView>(Resource.Id.lvCardMore);
                btConfirm = FindViewById<Button>(Resource.Id.btConfirm);
                btLogin = FindViewById<Button>(Resource.Id.btLogin);
                MorePalletsAdapter adapter = new MorePalletsAdapter(this, data);
                lvCardMore.Adapter = adapter;

        }
    }
}