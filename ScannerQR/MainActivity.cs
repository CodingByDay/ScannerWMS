﻿using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using TrendNET.WMS.Device.Services;
using Android.Net;
using System.Net;
using System;
using Android.Util;
using Android.Content;
using Plugin.Settings.Abstractions;
using System.Linq;



// Crashes, analytics and automatic updating.


////////////////////////////////////
using Microsoft.AppCenter;//////////
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using static Android.App.ActionBar;

namespace ScannerQR
{
    [Activity(Label = "@string/app_name",ScreenOrientation =Android.Content.PM.ScreenOrientation.Portrait, Theme = "@style/AppTheme", MainLauncher = true, Icon = "@drawable/barcode")]
    public class MainActivity : AppCompatActivity
    {
        private Dialog popupDialog;
        public static bool isValid;
        private EditText Password;
        public static ProgressBar progressBar1;
        private Button ok;
        private EditText rootURL;
        private EditText ID;
        private ImageView img;
        private TextView deviceURL;
        // Internet connection method.
        public bool IsOnline()
        {
            var cm = (ConnectivityManager)GetSystemService(ConnectivityService);
            return cm.ActiveNetworkInfo == null ? false : cm.ActiveNetworkInfo.IsConnected;
        }
        private void ProcessRegistration()
        {
            if (IsOnline())
            {
                Password = FindViewById<EditText>(Resource.Id.password);
                if (string.IsNullOrEmpty(Password.Text.Trim())) { return; }
                Services.ClearUserInfo();
                string error;
                bool valid = false;
                try
                {

                    valid = Services.IsValidUser(Password.Text.Trim(), out error);
                }
                finally
                {
                    // pass
                }

                if (valid)
                {
                    if (Services.HasPermission("TNET_WMS", "R"))
                    {

                        StartActivity(typeof(MainMenu)); /* Entry point */
                        Password.Text = "";
                        isValid = true;
                        this.Finish();
                    }
                    else
                    {

                        Password.Text = "";
                        isValid = false;
                        string toast = new string("Napačno geslo.");
                        Toast.MakeText(this, toast, ToastLength.Long).Show();
                        progressBar1.Visibility = ViewStates.Invisible;


                    }
                }
                else
                {

                    Password.Text = "";
                    isValid = false;
                    string toast = new string("Napačno geslo.");
                    Toast.MakeText(this, toast, ToastLength.Long).Show();
                    progressBar1.Visibility = ViewStates.Invisible;



                }
            } else
            {
                // Is connected 
                string toast = new string("Ni internetne povezave...");
                Toast.MakeText(this, toast, ToastLength.Long).Show();
                progressBar1.Visibility = ViewStates.Invisible;
               
            }

        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            AppCenter.Start("b6dbedcc-9d96-451f-9206-c2ab38cc7568", /*Change to your ID*/
                   typeof(Analytics), typeof(Crashes));
                   Crashes.NotifyUserConfirmation(UserConfirmation.AlwaysSend); /* Always send crash reports */ /*https://appcenter.ms/apps */
            /// Solved anylitics...
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            progressBar1 = FindViewById<ProgressBar>(Resource.Id.progressBar1);
            // Registering first event..
            Button btnRegistrationEvent = FindViewById<Button>(Resource.Id.btnRegistration);
            img = FindViewById<ImageView>(Resource.Id.img);
           
            btnRegistrationEvent.Click += BtnRegistrationEvent_Click;
            deviceURL = FindViewById<TextView>(Resource.Id.deviceURL);
            deviceURL.Text = new String(App.settings.RootURL); /* Settings module */
        }

   
       
        private void Ok_Click(object sender, EventArgs e)
        {
            App.settings.RootURL = rootURL.Text;
            App.settings.ID = ID.Text;
           
            deviceURL.Text = App.settings.RootURL;
            popupDialog.Dismiss();
            popupDialog.Hide();

        }

        /// <summary>
        /// First navigation event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRegistrationEvent_Click(object sender, System.EventArgs e)
        {
            progressBar1.Visibility = ViewStates.Visible;
            ProcessRegistration();
            Analytics.TrackEvent("Login");
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // in smartphone
                case Keycode.Enter:
                    BtnRegistrationEvent_Click(this, null);
                    break;
                //return true;
            }
            return base.OnKeyDown(keyCode, e);
        }


        /* Android specific permisions */
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}