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

namespace Scanner
{
    [Activity(Label = "MenuPalletsTablet", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class MenuPalletsTablet : Activity
    {
        private Button shipped;
        private Button wrapped;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.MenuPalletsTablet);
            shipped = FindViewById<Button>(Resource.Id.shipped);
            wrapped = FindViewById<Button>(Resource.Id.wrapped);


            // Beggining of the activity.

            shipped.Click += Shipped_Click;
            wrapped.Click += Wrapped_Click;

            




        }

        private void Wrapped_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(WrappingPalletTablet));
        }

        private void Shipped_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ShippingPalletTablet));
        }
    }
}