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
    [Activity(Label = "InterWarehouseEnteredPositionsView")]
    public class InterWarehouseEnteredPositionsView : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.InterWarehouseEnteredPositionsView);

            Button button2 = FindViewById<Button>(Resource.Id.btNext);

            button2.Click += Button2_Click;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(InterWarehouseBusinessEventSetup));

        }
    }
}