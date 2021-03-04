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

namespace ScannerQR
{
    [Activity(Label = "Settings")]
    public class Settings : Activity
    {
        private EditText ID;
        private EditText rootURL;
        private EditText device;
        private Button ok;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.settingsPopUp);
            ID = FindViewById<EditText>(Resource.Id.ID);
            rootURL = FindViewById<EditText>(Resource.Id.rootURL);
            device = FindViewById<EditText>(Resource.Id.device);
            ok = FindViewById<Button>(Resource.Id.ok);
            ok.Click += Ok_Click;




            // Create your application here
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            App.settings.RootURL = rootURL.Text;
            App.settings.ID = ID.Text;
            App.settings.ScannerType = device.Text;
            //deviceURL.Text = App.settings.RootURL
            StartActivity(typeof(MainActivity));
        }
    }
}