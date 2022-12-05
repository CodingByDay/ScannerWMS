using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.AppCenter.Crashes;
using Scanner.App;
using Scanner.Printing;
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.Services;

namespace Scanner
{
    [Activity(Label = "PrintingOutputControlTablet", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class PrintingOutputControlTablet : Activity
    {

        private int displayedPosition = 0;
        private NameValueObjectList positions = null;
        private EditText tbUser;
        private EditText tbSSCC;
        private EditText tbSerialNum;
        private EditText tbIdent;
        private EditText tbTitle;
        private EditText tbQty;
        private TextView lbInfo;
        private Button btNext;
        private Button btPrint;
        private Button button3;
        private EditText dateText;
        private Button date;
        public DateTime dateX;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.PrintingOutputControlTablet);
            tbUser = FindViewById<EditText>(Resource.Id.tbUser);
            tbSSCC = FindViewById<EditText>(Resource.Id.tbSSCC);
            tbSerialNum = FindViewById<EditText>(Resource.Id.tbSerialNum);
            tbIdent = FindViewById<EditText>(Resource.Id.tbIdent);
            tbTitle = FindViewById<EditText>(Resource.Id.tbTitle);
            tbQty = FindViewById<EditText>(Resource.Id.tbQty);

            //
            btNext = FindViewById<Button>(Resource.Id.btNext);
            btPrint = FindViewById<Button>(Resource.Id.btPrint);
            button3 = FindViewById<Button>(Resource.Id.button3);
            lbInfo = FindViewById<TextView>(Resource.Id.lbInfo);
            dateText = FindViewById<EditText>(Resource.Id.dateText);
            date = FindViewById<Button>(Resource.Id.date);
            dateX = DateTime.Now;
            dateText.Text = DateTime.Now.ToShortDateString();
            date.Click += Date_Click;

            btNext.Click += BtNext_Click;
            btPrint.Click += BtPrint_Click;
            button3.Click += Button3_Click;


            tbUser.Text = Services.UserName();

            dateX = DateTime.Today;
            GetOutputControls();
            dateText.Text = DateTime.Today.ToShortDateString();


            var _broadcastReceiver = new NetworkStatusBroadcastReceiver();
            _broadcastReceiver.ConnectionStatusChanged += OnNetworkStatusChanged;
            Application.Context.RegisterReceiver(_broadcastReceiver,
            new IntentFilter(ConnectivityManager.ConnectivityAction));
        }
        public bool IsOnline()
        {
            var cm = (ConnectivityManager)GetSystemService(ConnectivityService);
            return cm.ActiveNetworkInfo == null ? false : cm.ActiveNetworkInfo.IsConnected;

        }

        private void OnNetworkStatusChanged(object sender, EventArgs e)
        {
            if (IsOnline())
            {
                
                try
                {
                    LoaderManifest.LoaderManifestLoopStop(this);
                }
                catch (Exception err)
                {
                    Crashes.TrackError(err);
                }
            }
            else
            {
                LoaderManifest.LoaderManifestLoop(this);
            }
        }
        private void Date_Click(object sender, EventArgs e)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                dateText.Text = time.ToShortDateString();
                dateX = time;
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainMenuTablet));
        }

        private void BtPrint_Click(object sender, EventArgs e)
        {

            try
            {

                var nvo = new NameValueObject("PrintOutputControl");
                PrintingCommon.SetNVOCommonData(ref nvo);
                nvo.SetInt("QualityHead", positions.Items[displayedPosition].GetInt("HeadID"));
                PrintingCommon.SendToServer(nvo);

            }
            finally
            {

            }

        }

        private void BtNext_Click(object sender, EventArgs e)
        {
            displayedPosition++;
            if (displayedPosition >= positions.Items.Count) { displayedPosition = 0; }
            FillDisplayedItem();
        }

        private void GetOutputControls()
        {

            try
            {



                string error;
                positions = Services.GetObjectList("qhfbd", out error, "O|" + dateX.ToString("s"));
                if (positions == null)
                {
                    Toast.MakeText(this, "Napaka pri prenosu podatkov: " + error, ToastLength.Long).Show();

                    return;
                }

                displayedPosition = 0;
                FillDisplayedItem();
            }
            finally
            {
                //
            }
        }
        private void FillDisplayedItem()
        {
            if ((positions != null) && (positions.Items.Count > 0))
            {
                lbInfo.Text = "Končna kontrola (" + (displayedPosition + 1).ToString() + "/" + positions.Items.Count + ")";
                var item = positions.Items[displayedPosition];

                tbSSCC.Text = item.GetString("SSCC");
                tbSerialNum.Text = item.GetString("SerialNo");
                tbIdent.Text = item.GetString("Ident");
                tbTitle.Text = "???";
                tbQty.Text = item.GetDouble("Qty").ToString(CommonData.GetQtyPicture());

                btNext.Enabled = true;
                btPrint.Enabled = true;
                tbSSCC.Enabled = false;
                tbSerialNum.Enabled = false;
                tbIdent.Enabled = false;
                tbTitle.Enabled = false;
                tbQty.Enabled = false;

                tbSSCC.SetTextColor(Android.Graphics.Color.Black);
                tbSerialNum.SetTextColor(Android.Graphics.Color.Black);
                tbIdent.SetTextColor(Android.Graphics.Color.Black);
                tbTitle.SetTextColor(Android.Graphics.Color.Black);
                tbQty.SetTextColor(Android.Graphics.Color.Black);

            }
            else
            {
                lbInfo.Text = "Končna kontrola (ni)";

                tbSSCC.Text = "";
                tbSerialNum.Text = "";
                tbIdent.Text = "";
                tbTitle.Text = "";
                tbQty.Text = "";

                btNext.Enabled = false;
                btPrint.Enabled = false;
                tbSSCC.Enabled = false;
                tbSerialNum.Enabled = false;
                tbIdent.Enabled = false;
                tbTitle.Enabled = false;
                tbQty.Enabled = false;

                tbSSCC.SetTextColor(Android.Graphics.Color.Black);
                tbSerialNum.SetTextColor(Android.Graphics.Color.Black);
                tbIdent.SetTextColor(Android.Graphics.Color.Black);
                tbTitle.SetTextColor(Android.Graphics.Color.Black);
                tbQty.SetTextColor(Android.Graphics.Color.Black);
            }
        }
    }


}