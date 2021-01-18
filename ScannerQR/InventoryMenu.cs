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
    [Activity(Label = "InventoryMenu")]
    public class InventoryMenu : Activity
    {
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button7;
        private Button logout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.InventoryMenu);
            button1 = FindViewById<Button>(Resource.Id.button1);
            button2 = FindViewById<Button>(Resource.Id.button2);
            button3 = FindViewById<Button>(Resource.Id.button3);
            button4 = FindViewById<Button>(Resource.Id.button4);
            button7 = FindViewById<Button>(Resource.Id.button5);
            logout = FindViewById<Button>(Resource.Id.logout);



            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            button3.Click += Button3_Click;
            button4.Click += Button4_Click;
            button7.Click += Button7_Click;
            logout.Click += Logout_Click;

        }

        private void Logout_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(InventoryPrint));
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(InventoryOpen));
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(InventoryConfirm));
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(InventoryProcess));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(InventoryOpenDocument));
        }
    }
}