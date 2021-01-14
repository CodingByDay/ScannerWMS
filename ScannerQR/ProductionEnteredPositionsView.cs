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
    [Activity(Label = "ProductionEnteredPositionsView")]
    public class ProductionEnteredPositionsView : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ProductionEnteredPositionsView);

            Button button3 = FindViewById<Button>(Resource.Id.button2);

            button3.Click += Button3_Click;

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ProductionPalette));
        }
    }
}