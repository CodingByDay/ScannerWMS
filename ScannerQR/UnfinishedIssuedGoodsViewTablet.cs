using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ScannerQR.App;
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;
using static Android.App.ActionBar;
using WebApp = TrendNET.WMS.Device.Services.WebApp;

namespace ScannerQR
{
    [Activity(Label = "UnfinishedIssuedGoodsViewTablet", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class UnfinishedIssuedGoodsViewTablet : Activity
    {

        private TextView lbInfo;
        private EditText tbBusEvent;
        private EditText tbOrder;
        private EditText tbClient;
        private EditText tbItemCount;
        private EditText tbCreatedBy;
        private EditText tbCreatedAt;
        private Button btNext;
        private Button btFinish;
        private Button btDelete;
        private Button btNew;
        private Button btLogout;
        private Dialog popupDialog;
        private int displayedPosition = 0;
        private NameValueObjectList positions = (NameValueObjectList)InUseObjects.Get("IssuedGoodHeads");
        private Button btnYes;
        private Button btnNo;
        private ListView issuedData;
        private List<IssuedUnfinishedList> data = new List<IssuedUnfinishedList>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.UnfinishedIssuedGoodsViewTablet);
            

            tbBusEvent = FindViewById<EditText>(Resource.Id.tbBusEvent);
            tbOrder = FindViewById<EditText>(Resource.Id.tbOrder);
            tbClient = FindViewById<EditText>(Resource.Id.tbClient);
            tbItemCount = FindViewById<EditText>(Resource.Id.tbItemCount);
            tbCreatedBy = FindViewById<EditText>(Resource.Id.tbCreatedBy);
            tbCreatedAt = FindViewById<EditText>(Resource.Id.tbCreatedAt);
            btNext = FindViewById<Button>(Resource.Id.btNext);
            btFinish = FindViewById<Button>(Resource.Id.btFinish);
            btDelete = FindViewById<Button>(Resource.Id.btDelete);
            btNew = FindViewById<Button>(Resource.Id.btNew);
            btLogout = FindViewById<Button>(Resource.Id.btLogout);
            lbInfo = FindViewById<TextView>(Resource.Id.lbInfo);
            issuedData = FindViewById<ListView>(Resource.Id.issuedData);
            btNext.Click += BtNext_Click;     //
            btFinish.Click += BtFinish_Click; //
            btDelete.Click += BtDelete_Click; // 
            btNew.Click += BtNew_Click;       //
            btLogout.Click += BtLogout_Click; //

            // Adapter for the two thirds list view on the right.
            //
            //
            string errorWebAppIssued = string.Format(positions.Items.Count().ToString());
            Toast.MakeText(this, errorWebAppIssued, ToastLength.Long).Show();
            UnfinishedIssuedAdapter adapter = new UnfinishedIssuedAdapter(this, data);
            issuedData.Adapter = adapter;
          
            InUseObjects.Clear();

            LoadPositions();
         
        }
        /// <summary>
        /// Writting a method to fill in all the positions in the right third of the screen...
        /// positions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 


   
        private void BtLogout_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainMenu));

        }

        private void BtNew_Click(object sender, EventArgs e)
        {
            NameValueObject moveHead = new NameValueObject("MoveHead");
            moveHead.SetBool("Saved", false);
            InUseObjects.Set("MoveHead", moveHead);
            StartActivity(typeof(IssuedGoodsBusinessEventSetupTablet));
        }

        private void BtDelete_Click(object sender, EventArgs e)
        {
            popupDialog = new Dialog(this);
            popupDialog.SetContentView(Resource.Layout.YesNoPopUp);
            popupDialog.Window.SetSoftInputMode(SoftInput.AdjustResize);
            popupDialog.Show();

            popupDialog.Window.SetLayout(LayoutParams.MatchParent, LayoutParams.WrapContent);
            popupDialog.Window.SetBackgroundDrawableResource(Android.Resource.Color.HoloOrangeLight);

            // Access Popup layout fields like below
            btnYes = popupDialog.FindViewById<Button>(Resource.Id.btnYes);
            btnNo = popupDialog.FindViewById<Button>(Resource.Id.btnNo);
            btnYes.Click += BtnYes_Click;
            btnNo.Click += BtnNo_Click;

        }

        private void BtnNo_Click(object sender, EventArgs e)
        {
            popupDialog.Dismiss();
            popupDialog.Hide();
        }

        private void BtnYes_Click(object sender, EventArgs e)
        {
            var item = positions.Items[displayedPosition];
            var id = item.GetInt("HeadID");


            try
            {

                string result;
                if (WebApp.Get("mode=delMoveHead&head=" + id.ToString() + "&deleter=" + Services.UserID().ToString(), out result))
                {
                    if (result == "OK!")
                    {
                        positions = null;
                        LoadPositions();

                        popupDialog.Dismiss();
                        popupDialog.Hide();
                    }
                    else
                    {
                        string errorWebAppIssued = string.Format("Napaka pri brisanju pozicije " + result);
                        Toast.MakeText(this, errorWebAppIssued, ToastLength.Long).Show();
                        positions = null;
                        LoadPositions();

                        popupDialog.Dismiss();
                        popupDialog.Hide();
                        return;
                    }
                }
                else
                {
                    string errorWebAppIssued = string.Format("Napaka pri dostopu web aplikacije: " + result);
                    Toast.MakeText(this, errorWebAppIssued, ToastLength.Long).Show();
                    popupDialog.Dismiss();
                    popupDialog.Hide();

                    return;
                }
            }
            finally
            {

            }

            string errorWebApp = string.Format("Pozicija uspešno zbrisana.");
            Toast.MakeText(this, errorWebApp, ToastLength.Long).Show();
        }

        private void BtFinish_Click(object sender, EventArgs e)
        {
            var moveHead = positions.Items[displayedPosition];
            moveHead.SetBool("Saved", true);
            InUseObjects.Set("MoveHead", moveHead);

            StartActivity(typeof(IssuedGoodsEnteredPositionsViewTablet));
        }

        private void BtNext_Click(object sender, EventArgs e)
        {
            displayedPosition++;
            if (displayedPosition >= positions.Items.Count) { displayedPosition = 0; }
            FillDisplayedItem();
        }

        private void LoadPositions()
        {

            try
            {
                if (positions == null)
                {
                    var error = "";
                    if (positions == null)
                    {
                        positions = Services.GetObjectList("mh", out error, "P");
                        InUseObjects.Set("IssuedGoodHeads", positions);
                    }
                    if (positions == null)
                    {
                        string errorWebApp = string.Format("Napaka pri brisanju pozicije:: " + error);
                        Toast.MakeText(this, errorWebApp, ToastLength.Long).Show();
                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                        return;
                    }
                }

                displayedPosition = 0;
                FillDisplayedItem();
            }
            finally
            {

            }
        }

        private void FillDisplayedItem()
        {
            if ((positions != null) && (positions.Items.Count > 0))
            {
                lbInfo.Text = "Odprte odpreme na čitalcu (" + (displayedPosition + 1).ToString() + "/" + positions.Items.Count + ")";
                var item = positions.Items[displayedPosition];

                tbBusEvent.Text = item.GetString("DocumentTypeName");
                tbOrder.Text = item.GetString("LinkKey");
                tbClient.Text = item.GetString("Receiver");
                tbItemCount.Text = item.GetInt("ItemCount").ToString();
                tbCreatedBy.Text = item.GetString("ClerkName");

                var created = item.GetDateTime("DateInserted");
                tbCreatedAt.Text = created == null ? "" : ((DateTime)created).ToString("dd.MM.yyyy");

                tbBusEvent.Enabled = false;
                tbOrder.Enabled = false;
                tbClient.Enabled = false;
                tbItemCount.Enabled = false;
                tbCreatedBy.Enabled = false;
                tbCreatedAt.Enabled = false;


                tbBusEvent.SetTextColor(Android.Graphics.Color.Black);
                tbOrder.SetTextColor(Android.Graphics.Color.Black);
                tbClient.SetTextColor(Android.Graphics.Color.Black);
                tbItemCount.SetTextColor(Android.Graphics.Color.Black);
                tbCreatedBy.SetTextColor(Android.Graphics.Color.Black);
                tbCreatedAt.SetTextColor(Android.Graphics.Color.Black);

                btNext.Enabled = true;
                btDelete.Enabled = true;
                btFinish.Enabled = true;
            }
            else
            {
                lbInfo.Text = "Odprte odpreme na čitalcu (ni)";

                tbBusEvent.Text = "";
                tbOrder.Text = "";
                tbClient.Text = "";
                tbItemCount.Text = "";
                tbCreatedBy.Text = "";
                tbCreatedAt.Text = "";

                tbBusEvent.Enabled = false;
                tbOrder.Enabled = false;
                tbClient.Enabled = false;
                tbItemCount.Enabled = false;
                tbCreatedBy.Enabled = false;
                tbCreatedAt.Enabled = false;

                tbBusEvent.SetTextColor(Android.Graphics.Color.Black);
                tbOrder.SetTextColor(Android.Graphics.Color.Black);
                tbClient.SetTextColor(Android.Graphics.Color.Black);
                tbItemCount.SetTextColor(Android.Graphics.Color.Black);
                tbCreatedBy.SetTextColor(Android.Graphics.Color.Black);
                tbCreatedAt.SetTextColor(Android.Graphics.Color.Black);


                btNext.Enabled = false;
                //  btDelete.Enabled = false;
                btFinish.Enabled = false;
            }
        }
        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // in smartphone
                case Keycode.F1:
                    if (btNext.Enabled == true)
                    {
                        BtNext_Click(this, null);
                    }
                    break;
                //return true;


                case Keycode.F2:
                    if (btFinish.Enabled == true)
                    {
                        BtFinish_Click(this, null);
                    }
                    break;


                case Keycode.F3:
                    if (btDelete.Enabled == true)
                    {
                        BtDelete_Click(this, null);
                    }
                    break;

                case Keycode.F4:
                    if (btNew.Enabled == true)
                    {
                        BtNew_Click(this, null);
                    }
                    break;


                case Keycode.F5:
                    if (btLogout.Enabled == true)
                    {
                        BtLogout_Click(this, null);
                    }
                    break;



            }
            return base.OnKeyDown(keyCode, e);
        }
    }
}