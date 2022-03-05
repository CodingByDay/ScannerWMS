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
using Xamarin.Essentials;

namespace Scanner
{
    [Activity(Label = "Settings")]
    public class Settings : Activity
    {
        private EditText ID;
        private EditText rootURL;
        private TextView version;
        private Button ok;
        public static string deviceInfo;
        private Spinner cbDevice;
        public static string IDinfo;
        private String[] arrayData = { "Izberite tip naprave", "TABLET", "PHONE" }; // Spustni seznam.
        private string item;
        private int position;
        private string dev;
        public static bool flag;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.settingsPopUp);
            ID = FindViewById<EditText>(Resource.Id.IDdevice);
            rootURL = FindViewById<EditText>(Resource.Id.rootURL);
            cbDevice = FindViewById<Spinner>(Resource.Id.cbDevice);
            ok = FindViewById<Button>(Resource.Id.ok);
            ok.Click += Ok_Click;
            ID.Text = App.settings.ID;
            version = FindViewById<TextView>(Resource.Id.version);
            version.Text = $"verzija: 0.{GetAppVersion()}";
            rootURL.Text = App.settings.RootURL;
            var adapter = new ArrayAdapter<String>(this,
           Android.Resource.Layout.SimpleSpinnerItem, arrayData);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            cbDevice.Adapter = adapter;

            cbDevice.ItemSelected += CbDevice_ItemSelected;
            maintainSelection();
            // Create your application here
        }

        public string GetAppVersion()
        {
            return AppInfo.BuildString;
        }
        public void maintainSelection()
        {
            if(App.settings.tablet ==true)
            {
                cbDevice.SetSelection(1);
            } else
            {
                cbDevice.SetSelection(2);
            }
        }

        private void CbDevice_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            Spinner spinner = (Spinner)sender;
            position = e.Position;
            dev = arrayData[position];
            if (dev == "TABLET")
            {
                App.settings.tablet = true; 
            } else
            {
                App.settings.tablet = false;
            }
         
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            App.settings.device = dev;
            App.settings.RootURL = rootURL.Text;
            App.settings.ID = ID.Text;
            ID.Text = App.settings.ID;



            //deviceURL.Text = App.settings.RootURL
            StartActivity(typeof(MainActivity));
        }
    }
}