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
using ScannerQR.Printing;
using TrendNET.WMS.Core.Data;

namespace ScannerQR
{
    [Activity(Label = "PrintingSSCCCodesTablet")]
    public class PrintingSSCCCodesTablet : Activity
    {
        private EditText tbNum;
        private Button button1;
        private Button button2;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.PrintingSSCCCodesTablet);
            tbNum = FindViewById<EditText>(Resource.Id.tbNum);
            button1 = FindViewById<Button>(Resource.Id.button1);
            button2 = FindViewById<Button>(Resource.Id.button2);
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
        }
        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // in smartphone
                case Keycode.F3:
                    if (button1.Enabled == true)
                    {
                        Button1_Click(this, null);
                    }
                    break;
                //return true;


                case Keycode.F8:
                    if (button2.Enabled == true)
                    {
                        Button2_Click(this, null);
                    }
                    break;


            }
            return base.OnKeyDown(keyCode, e);
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainMenu));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var num = -1;
            try
            {
                num = Convert.ToInt32(tbNum.Text);
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "Št. nalepk ni pravilno! (" + ex.Message + ")", ToastLength.Long).Show();

                return;
            }

            if (num < 1)
            {
                Toast.MakeText(this, "Št. nalepk mora biti pozitivno!", ToastLength.Long).Show();

                return;
            }


            try
            {

                var nvo = new NameValueObject("PrintSSCC");
                PrintingCommon.SetNVOCommonData(ref nvo);
                nvo.SetInt("Copies", num);
                PrintingCommon.SendToServer(nvo);
                Toast.MakeText(this, "Uspešno poslani podatki...", ToastLength.Long).Show();
            }
            finally
            {
                //
            }
        }
    }
}