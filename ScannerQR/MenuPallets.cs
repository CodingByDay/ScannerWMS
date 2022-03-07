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

namespace Scanner
{
    [Activity(Label = "MenuPallets")]
    public class MenuPallets : Activity
    {
        private Button shipped;
        private Button wrapped;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.MenuPallets);
            shipped = FindViewById<Button>(Resource.Id.shipped);
            wrapped = FindViewById<Button>(Resource.Id.wrapped);



            shipped.Click += Shipped_Click;
            wrapped.Click += Wrapped_Click;
        }

        private void Wrapped_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(WrappingPallet)); // Wrapping pallet new functionality.
            HelpfulMethods.clearTheStack(this);
        }
        public override void OnBackPressed()
        {

            HelpfulMethods.releaseLock();

            base.OnBackPressed();
        }
        private void Shipped_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ShippingPallet)); // Shipping pallet new functionality.
            HelpfulMethods.clearTheStack(this);
        }
    }
}