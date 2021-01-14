using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ScannerQR
{
    [Activity(Label = "ProductionPalette")]
    public class ProductionPalette : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ProductionPalette);
            // Button name------------------>productionserial
            Button button = FindViewById<Button>(Resource.Id.productionserial);
            button.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ProductionSerialOrSSCCEntry));
        }
    }
}