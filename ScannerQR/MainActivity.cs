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


////////////////////////////////////
using Microsoft.AppCenter;//////////
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using static Android.App.ActionBar;
using Scanner.App;
using Microsoft.AppCenter.Distribute;
using Uri = System.Uri;
using System.Threading.Tasks;
using Scanner.Caching;
using Scanner.Background;
using AlertDialog = Android.App.AlertDialog;

namespace Scanner
{
    [Activity(Label = "WMS", Theme = "@style/AppTheme", MainLauncher = true, Icon = "@drawable/barcode",  NoHistory = true)]
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
        private bool tablet = settings.tablet;
        private Button btnOkRestart;

        public object MenuInflaterFinal { get; private set; }

        // Internet connection method.
        public bool IsOnline()
        {
            var cm = (ConnectivityManager) GetSystemService(ConnectivityService);
            return cm.ActiveNetworkInfo == null ? false : cm.ActiveNetworkInfo.IsConnected;
            
        }
     
     
        private void BtnOkRestart_Click(object sender, EventArgs e)
        {
            var stop = true;
        }

        private void ProcessRegistration()
        {
            var intent = new Intent(this, typeof(CachingService));
            StartService(intent);
            var inactivity = new Intent(this, typeof(Inactivity));
            StartService(inactivity);
           


            if (IsOnline())
            {             
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
                        if (tablet == true)
                        {
                            StartActivity(typeof(MainMenuTablet));
                            HelpfulMethods.clearTheStack(this);
                        } /* Entry point for the phone mode. */
                        else
                        {
                            StartActivity(typeof(MainMenu));
                            HelpfulMethods.clearTheStack(this);
                        }
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


       

        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            settings.restart = false;
            Distribute.ReleaseAvailable = OnReleaseAvailable;
            Distribute.SetEnabledAsync(true);
            AppCenter.Start("ec2ca4ce-9e86-4620-9e90-6ecc5cda0e0e",
                   typeof(Analytics), typeof(Crashes), typeof(Distribute));
            Crashes.NotifyUserConfirmation(UserConfirmation.AlwaysSend); /* Always send crash reports */ /*https://appcenter.ms/apps */
            ChangeTheOrientation();        
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Password = FindViewById<EditText>(Resource.Id.password);
            Password.InputType = Android.Text.InputTypes.NumberVariationPassword |
                          Android.Text.InputTypes.ClassNumber;
            progressBar1 = FindViewById<ProgressBar>(Resource.Id.progressBar1);
            img = FindViewById<ImageView>(Resource.Id.img);
            var _broadcastReceiver = new NetworkStatusBroadcastReceiver();
            _broadcastReceiver.ConnectionStatusChanged += OnNetworkStatusChanged;
            Application.Context.RegisterReceiver(_broadcastReceiver,
            new IntentFilter(ConnectivityManager.ConnectivityAction));

            Button btnRegistrationEvent = FindViewById<Button>(Resource.Id.btnRegistrationClick);
            btnRegistrationEvent.Clickable = true;
            btnRegistrationEvent.Enabled = true;
            btnRegistrationEvent.Click += BtnRegistrationEvent_Click;
        }

     
        private void OnNetworkStatusChanged(object sender, EventArgs e)
        {
            if (IsOnline())
            {
                
                try
                {
                    LoaderManifest.LoaderManifestLoopStop(this);
                } catch (Exception err)
                {
                    Crashes.TrackError(err);
                }
            }
            else
            {
                LoaderManifest.LoaderManifestLoop(this);
            }
        }
        public override bool DispatchKeyEvent(Android.Views.KeyEvent e)
        {
            if(e.KeyCode == Keycode.Enter) { BtnRegistrationEvent_Click(this, null); }
            return base.DispatchKeyEvent(e);
        }
        private void ChangeTheOrientation()
        {
            if(settings.tablet == true)
            {
                RequestedOrientation = Android.Content.PM.ScreenOrientation.Landscape;
            } 
            else
            {
                RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
            }
        }

        private bool OnReleaseAvailable(ReleaseDetails releaseDetails)
        {
                string versionName = releaseDetails.ShortVersion;
                string versionCodeOrBuildNumber = releaseDetails.Version;
                string releaseNotes = releaseDetails.ReleaseNotes;
                Uri releaseNotesUrl = releaseDetails.ReleaseNotesUrl;
                var title = "Version " + versionName + " available!";      
                popupDialog = new Dialog(this);
                popupDialog.SetContentView(Resource.Layout.update);
                popupDialog.Window.SetSoftInputMode(SoftInput.AdjustResize);
                popupDialog.Show();
                popupDialog.Window.SetLayout(LayoutParams.MatchParent, LayoutParams.WrapContent);
                popupDialog.Window.SetBackgroundDrawableResource(Android.Resource.Color.HoloRedLight);
                // Access Pop-up layout fields like below
                btnOkRestart = popupDialog.FindViewById<Button>(Resource.Id.btnOk);
                btnOkRestart.Click += BtnOk_Click;                   
                return true;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Distribute.NotifyUpdateAction(UpdateAction.Update);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_setting1:
                    {
                        StartActivity(typeof(Settings));
                        HelpfulMethods.clearTheStack(this);
                        return true;
                    }
             
            }

            return base.OnOptionsItemSelected(item);
        }
        private void Listener_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Settings));
            HelpfulMethods.clearTheStack(this);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Layout.popup_action, menu);
            return base.OnCreateOptionsMenu(menu);
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
        }
        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // in smart-phone
                case Keycode.Enter:
                    BtnRegistrationEvent_Click(this, null);
                    break;
                // return true;
            }
            return base.OnKeyDown(keyCode, e);
        }
        /* Android specific permissions */
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}