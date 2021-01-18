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
    [Activity(Label = "PrintingMenu")]
    public class PrintingMenu : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.PrintingMenu);
            // button1 PrintingReprintLabels());
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += Button1_Click;
            // button2 PrintingSSCCCodes());
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            button2.Click += Button_Click;
            // button3 PrintingProcessControl());
            Button button3 = FindViewById<Button>(Resource.Id.button3);
            button3.Click += Button3_Click;
            // button4 PrintingInputControl());
            Button button4 = FindViewById<Button>(Resource.Id.button4);
            button4.Click += Button4_Click;
            // button5 PrintingOutputControl());
            Button button5 = FindViewById<Button>(Resource.Id.button5);
            button5.Click += Button5_Click;
            // button6 logout
            Button button6 = FindViewById<Button>(Resource.Id.button6);
            button6.Click += Button6_Click;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(PrintingOutputControl));
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(PrintingProcessControl));
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(PrintingInputControl));
        }

        private void Button_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(PrintingSSCCCodes));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(PrintingReprintLabels));
        }
    }
}