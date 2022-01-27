using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Scanner.App;
using TrendNET.WMS.Device.Services;

namespace Scanner
{
    [Activity(Label = "PrintingMenu")]
    public class PrintingMenu : Activity
    {
        public static string target = App.settings.device;
        public bool result = Services.isTablet(target); /* Is the device tablet. */
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            ChangeTheOrientation(); 
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.PrintingMenu);
            // button1 PrintingReprintLabels());
            button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += Button1_Click;
            // button2 PrintingSSCCCodes());
            button2 = FindViewById<Button>(Resource.Id.button2);
            button2.Click += Button_Click;
            // button3 PrintingProcessControl());
            button3 = FindViewById<Button>(Resource.Id.button3);
            button3.Click += Button3_Click;
            // button4 PrintingInputControl());
            button4 = FindViewById<Button>(Resource.Id.button4);
            button4.Click += Button4_Click;
            // button5 PrintingOutputControl());
            button5 = FindViewById<Button>(Resource.Id.button5);
            button5.Click += Button5_Click;
            // button6 logout
            button6 = FindViewById<Button>(Resource.Id.button6);
            button6.Click += Button6_Click;
          
        }


        private void ChangeTheOrientation()
        {
            if (settings.tablet == true)
            {
                RequestedOrientation = Android.Content.PM.ScreenOrientation.Landscape;
            }
            else
            {
                RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;

            }
        }


        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // In smartphone
                case Keycode.F2:

              
                        Button1_Click(this, null);

                    
                    break;
                // Return true;

                case Keycode.F3:


                    Button_Click(this, null);
                    

                    break;


                case Keycode.F4:

                    Button1_Click(this, null);
               
                    break;

                case Keycode.F5:

                    Button4_Click(this, null);
              
                    break;
                case Keycode.F6:

                    Button5_Click(this, null);

                    break;
                case Keycode.F8:

                    Button6_Click(this, null);

                    break;

                    // return true;
            }
            return base.OnKeyDown(keyCode, e);
        }
        private void Button6_Click(object sender, EventArgs e)
        {
            if (result == true)
            {
                StartActivity(typeof(MainMenuTablet));
            }
            else
            {
                StartActivity(typeof(MainMenu));
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (result == true)
            {
                StartActivity(typeof(PrintingOutputControlTablet));
            } else
            {
                StartActivity(typeof(PrintingOutputControl));
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (result == true)
            {
                StartActivity(typeof(PrintingProcessControlTablet));
            } else
            {
                StartActivity(typeof(PrintingProcessControl));
            }
         }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (result == true)
            {
                StartActivity(typeof(PrintingInputControlTablet));
            } else
            {
                StartActivity(typeof(PrintingInputControl));
            } 
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (result == true)
            {
                StartActivity(typeof(PrintingSSCCCodesTablet));
            } else
            {
                StartActivity(typeof(PrintingSSCCCodes));
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (result == true)
            {
                StartActivity(typeof(PrintingReprintLabelsTablet));
            } else
            {
                StartActivity(typeof(PrintingReprintLabels));
            }
        }
    }
}