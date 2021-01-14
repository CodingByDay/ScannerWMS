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
    [Activity(Label = "ProductionCard")]
    public class ProductionCard : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ProductionCard);
            Button button33 = FindViewById<Button>(Resource.Id.button1);
            // Create your application here
            button33.Click += Button33_Click;
        }

        private void Button33_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ProductionEnteredPositionsView));
        }
    }
}