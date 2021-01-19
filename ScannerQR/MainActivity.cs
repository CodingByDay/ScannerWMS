using Android.App;
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



using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using static Android.App.ActionBar;

namespace ScannerQR
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, Icon = "@drawable/barcode")]
    public class MainActivity : AppCompatActivity
    {
        private Dialog popupDialog;
        public static bool isValid;
        private EditText Password;
        public static ProgressBar progressBar1;
        private Button settings;
        private Button ok;
        private EditText rootURL;
        private EditText ID;
        private ImageView img;
        private TextView deviceURL;
        // These are methods for updating the app.

        //public string TAG { get; private set; }

        //private void CheckUpdate(Action doIfUpToDate)
        //{
        //    if (NeedUpdate())
        //    {
        //        Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(this);
        //        alert.SetTitle("New Update");
        //        alert.SetMessage("You must download the newest version of this to play multiplayer.  Would you like to now?");
        //        alert.SetCancelable(false);
        //        alert.SetPositiveButton("Yes", new EventHandler<DialogClickEventArgs>((object sender, DialogClickEventArgs e) => GetUpdate()));
        //        alert.SetNegativeButton("No", delegate { });
        //        alert.Show();
        //    }
        //    else
        //    {
        //        doIfUpToDate.Invoke();
        //    }
        //}

        //private bool NeedUpdate()
        //{
        //    try
        //    {
        //        var curVersion = PackageManager.GetPackageInfo(PackageName, 0).VersionName;
        //        var newVersion = curVersion;

        //        string htmlCode;
        //        //probably better to do in a background thread
        //        using (WebClient client = new WebClient())
        //        {
        //            htmlCode = client.DownloadString("https://play.google.com/store/apps/details?id=" + PackageName + "&hl=en");
        //        }

        //        HtmlDocument doc = new HtmlDocument();
        //        doc.LoadHtml(htmlCode);

        //        newVersion = doc.DocumentNode.SelectNodes("//div[@itemprop='softwareVersion']")
        //                          .Select(p => p.InnerText)
        //                          .ToList()
        //                          .First()
        //                          .Trim();

        //        return String.Compare(curVersion, newVersion) < 0;
        //    }
        //    catch (Exception e)
        //    {
        //        Log.Error(TAG, e.Message);
        //        Toast.MakeText(this, "Težave pri preverjanju posodobitve.", ToastLength.Long).Show();
        //        return true;
        //    }
        //}

        //private void GetUpdate()
        //{
        //    try
        //    {
        //        StartActivity(new Intent(Intent.ActionView, Android.Net.Uri.Parse("market://details?id=" + PackageName)));
        //    }
        //    catch (ActivityNotFoundException e)
        //    {
                
        //        StartActivity(new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://play.google.com/store/apps/details?id=" + PackageName)));
        //    }
        //}
        //




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

                }

                if (valid)
                {
                    if (Services.HasPermission("TNET_WMS", "R"))
                    {

                        StartActivity(typeof(MainMenu));

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
                string toast = new string("Ni internetne povezave...");
                Toast.MakeText(this, toast, ToastLength.Long).Show();
                progressBar1.Visibility = ViewStates.Invisible;
               
            }

        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            AppCenter.Start("b6dbedcc-9d96-451f-9206-c2ab38cc7568",
                   typeof(Analytics), typeof(Crashes));
                   Crashes.NotifyUserConfirmation(UserConfirmation.AlwaysSend); /* Always send crash reports */


            /// Solved anylitics...
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            progressBar1 = FindViewById<ProgressBar>(Resource.Id.progressBar1);
            

            // Registering first event..
            Button btnRegistrationEvent = FindViewById<Button>(Resource.Id.btnRegistration);
            img = FindViewById<ImageView>(Resource.Id.img);
            img.Click += Img_Click;
            btnRegistrationEvent.Click += BtnRegistrationEvent_Click;
            deviceURL = FindViewById<TextView>(Resource.Id.deviceURL);
            deviceURL.Text = new String("URL strežnika: " + App.settings.RootURL);/* 19.01.2021 */


        }

        private void Img_Click(object sender, EventArgs e)
        {

            popupDialog = new Dialog(this);
            popupDialog.SetContentView(Resource.Layout.settingsPopUp);
            popupDialog.Window.SetSoftInputMode(SoftInput.AdjustResize);
            popupDialog.Show();

            popupDialog.Window.SetLayout(LayoutParams.MatchParent, LayoutParams.WrapContent);
            popupDialog.Window.SetBackgroundDrawableResource(Android.Resource.Color.DarkerGray);

            // Access Popup layout fields like below
            ok = popupDialog.FindViewById<Button>(Resource.Id.ok);
            rootURL = popupDialog.FindViewById<EditText>(Resource.Id.rootURL);
            ID = popupDialog.FindViewById<EditText>(Resource.Id.ID);
       
            ok.Click += Ok_Click;
        }
        /**"http://wms.in-sist.si"*/
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
            Analytics.TrackEvent("Login"); ;
            

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


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}