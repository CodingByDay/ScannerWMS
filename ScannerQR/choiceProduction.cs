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
    [Activity(Label = "choiceProduction")]
    public class choiceProduction : Activity
    {
        private Button production;
        private Button rapid;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.choiceProduction);
            // Create your application here
            production = FindViewById<Button>(Resource.Id.production);
            rapid = FindViewById<Button>(Resource.Id.rapid);


            production.Click += Production_Click;
            rapid.Click += Rapid_Click;
        }

        private void Rapid_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(RapidTakeoverPhone));
        }

        private void Production_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(UnfinishedProductionView));
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // In smartphone.  
                case Keycode.F2:
                    Production_Click(this, null);                    
                    break;
                // Return true;

                case Keycode.F3:
                    Rapid_Click(this, null);
                    break;

            }
            return base.OnKeyDown(keyCode, e);
        }
    }
}