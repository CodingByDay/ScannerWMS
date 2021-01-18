using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using TrendNET.WMS.Device.Services;
using Android.Net;

namespace ScannerQR
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, Icon = "@drawable/barcode")]
    public class MainActivity : AppCompatActivity
    {
        public static bool isValid;
        private EditText Password;
        public static ProgressBar progressBar1;
      
        
        
        
        
        
        
        
        
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
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            progressBar1 = FindViewById<ProgressBar>(Resource.Id.progressBar1);


            // Registering first event..
            Button btnRegistrationEvent = FindViewById<Button>(Resource.Id.btnRegistration);

            btnRegistrationEvent.Click += BtnRegistrationEvent_Click;




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