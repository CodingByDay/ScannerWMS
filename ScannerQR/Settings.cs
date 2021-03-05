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
        public static string deviceInfo;
        private Spinner cbDevice;
        public static string IDinfo;
        private String[] arrayData = { "Izberite tip naprave", "TABLET", "PHONE" }; // Spustni seznam.
        private string item;
        private int position;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.settingsPopUp);
            ID = FindViewById<EditText>(Resource.Id.ID);
            rootURL = FindViewById<EditText>(Resource.Id.rootURL);
            cbDevice = FindViewById<Spinner>(Resource.Id.cbDevice);
            ok = FindViewById<Button>(Resource.Id.ok);
            ok.Click += Ok_Click;
          
            rootURL.Text = App.settings.RootURL;
            ID.Text = App.settings.ID;
            var adapter = new ArrayAdapter<String>(this,
           Android.Resource.Layout.SimpleSpinnerItem, arrayData);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            cbDevice.Adapter = adapter;

            cbDevice.ItemSelected += CbDevice_ItemSelected;


            // Create your application here
        }

        private void CbDevice_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            Spinner spinner = (Spinner)sender;
            position = e.Position;
            App.settings.device = arrayData.ElementAt(position);
            Toast.MakeText(this, App.settings.device, ToastLength.Long).Show();
           
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            App.settings.device = arrayData[position];
            App.settings.RootURL = rootURL.Text;
            App.settings.ID = ID.Text;
            



            //deviceURL.Text = App.settings.RootURL
            StartActivity(typeof(MainActivity));
        }
    }
}