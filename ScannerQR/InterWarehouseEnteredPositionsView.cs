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
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;
using static Android.App.ActionBar;
using WebApp = TrendNET.WMS.Device.Services.WebApp;

namespace ScannerQR
{
    [Activity(Label = "InterWarehouseEnteredPositionsView")]
    public class InterWarehouseEnteredPositionsView : Activity
    {
        private EditText tbIdent;
        private EditText tbSSCC;
        private EditText tbSerialNumber;
        private EditText tbQty;
        private EditText tbLocation;
        private EditText tbCreatedBy;


        private Button btNext;
        private Button btUpdate;
        private Button button4;
        private Button btFinish;
        private Button btDelete;
        private Button button5;
        private TextView lbInfo;
        private int displayedPosition = 0;
        private NameValueObject moveHead = (NameValueObject)InUseObjects.Get("MoveHead");
        private NameValueObjectList positions = null;
        private Dialog popupDialog;
        private Button btnYes;
        private Button btnNo;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.InterWarehouseEnteredPositionsView);

            tbIdent = FindViewById<EditText>(Resource.Id.tbIdent);
            tbSSCC = FindViewById<EditText>(Resource.Id.tbSSCC);
            tbSerialNumber = FindViewById<EditText>(Resource.Id.tbSerialNumber);
            tbQty = FindViewById<EditText>(Resource.Id.tbQty);
            tbLocation = FindViewById<EditText>(Resource.Id.tbLocation);
            tbCreatedBy = FindViewById<EditText>(Resource.Id.tbCreatedBy);
            lbInfo = FindViewById<TextView>(Resource.Id.lbInfo);


/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



            btNext = FindViewById<Button>(Resource.Id.btNext);
            btUpdate = FindViewById<Button>(Resource.Id.btUpdate);
            button4 = FindViewById<Button>(Resource.Id.button4);
            btFinish = FindViewById<Button>(Resource.Id.btFinish);
            btDelete = FindViewById<Button>(Resource.Id.btDelete);
            button5 = FindViewById<Button>(Resource.Id.button5);
            /////////////////////////////////////////////////////////////
            ///
            btNext.Click += BtNext_Click;
            btUpdate.Click += BtUpdate_Click;
            button4.Click += Button4_Click;
            btFinish.Click += BtFinish_Click;
            btDelete.Click += BtDelete_Click;
            button5.Click += Button5_Click;
            ////////////////////////////////////////////////////////////////
            InUseObjects.ClearExcept(new string[] { "MoveHead" });
            if (moveHead == null) { throw new ApplicationException("moveHead not known at this point!?"); }

            LoadPositions();


        }

        private void Button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // Setting F2 to method ProccesStock()
                case Keycode.F1:
                    BtNext_Click(this, null);
                    break;

                case Keycode.F2:
                    BtUpdate_Click(this, null);
                    break;

                case Keycode.F3://
                    Button4_Click(this, null);
                    break;

                case Keycode.F4:
                    BtFinish_Click(this, null);
                    break;

                case Keycode.F5:
                    BtDelete_Click(this, null);
                    break;

                case Keycode.F6:
                    Button5_Click(this, null);
                    break;


                    //return true;



            }
            return base.OnKeyDown(keyCode, e);
        }
        private void BtDelete_Click(object sender, EventArgs e)
        {
            popupDialog = new Dialog(this);
            popupDialog.SetContentView(Resource.Layout.YesNoPopUp);
            popupDialog.Window.SetSoftInputMode(SoftInput.AdjustResize);
            popupDialog.Show();

            popupDialog.Window.SetLayout(LayoutParams.MatchParent, LayoutParams.WrapContent);
            popupDialog.Window.SetBackgroundDrawableResource(Android.Resource.Color.HoloGreenDark);

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
            var id = item.GetInt("ItemID");


            try
            {

                string result;
                if (WebApp.Get("mode=delMoveItem&item=" + id.ToString() + "&deleter=" + Services.UserID().ToString(), out result))
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
                        string WebErrors = string.Format("Napaka pri brisanju pozicije: " + result);
                        Toast.MakeText(this, WebErrors, ToastLength.Long).Show();        
                        positions = null;
                        LoadPositions();
                        popupDialog.Dismiss();
                        popupDialog.Hide();
                        return;
                    }
                }
                else
                {
                    string WebErrora = string.Format("Napaka pri dostopu do web aplikacije: " + result);
                    Toast.MakeText(this, WebErrora, ToastLength.Long).Show();
                    popupDialog.Dismiss();
                    popupDialog.Hide();

                    return;
                }
            }
            finally
            {
           //
            }

            string WebError = string.Format("Pozicija zbrisana.");
            Toast.MakeText(this, WebError, ToastLength.Long).Show();
            popupDialog.Dismiss();
            popupDialog.Hide();
        }


        private void BtFinish_Click(object sender, EventArgs e)
        {
         
            try
            {
     
                var headID = moveHead.GetInt("HeadID");

                string result;
                if (WebApp.Get("mode=finish&print=" + Services.DeviceUser() + "&id=" + headID.ToString(), out result))
                {
                    if (result.StartsWith("OK!"))
                    {
                        var id = result.Split('+')[1];
                        string WebError = string.Format("Zaključevanje uspešno! Št. prenosa:\r\n" + id);
                        Toast.MakeText(this, WebError, ToastLength.Long).Show();
                    
                  
                    }
                    else
                    {
                        string WebError = string.Format("Napaka pri zaključevanju: " + result);
                        Toast.MakeText(this, WebError, ToastLength.Long).Show();
                    }
                }
                else
                {
                    string WebError = string.Format("Napaka pri klicu web aplikacije: " + result);
                    Toast.MakeText(this, WebError, ToastLength.Long).Show();
   
                }
            }
            finally
            {
            //
            }
     
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(InterWarehouseSerialOrSSCCEntry));
        }

        private void BtUpdate_Click(object sender, EventArgs e)
        {
            var item = positions.Items[displayedPosition];
            InUseObjects.Set("MoveItem", item);

             StartActivity(typeof(InterWarehouseSerialOrSSCCEntry));
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
             //
                if (positions == null)
                {
                    var error = "";

                    if (positions == null)
                    {
                        positions = Services.GetObjectList("mi", out error, moveHead.GetInt("HeadID").ToString());
                        InUseObjects.Set("TakeOverEnteredPositions", positions);
                    }
                    if (positions == null)
                    {
                        string WebError = string.Format("Napaka pri dostopu do web aplikacije: " + error);
                        Toast.MakeText(this, WebError, ToastLength.Long).Show();
                        return;
                    }
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
            if ((positions != null) && (displayedPosition < positions.Items.Count))
            {
                var item = positions.Items[displayedPosition];
                lbInfo.Text = "Vnešene pozicije na medskladiščnici (" + (displayedPosition + 1).ToString() + "/" + positions.Items.Count + ")";

                tbIdent.Text = item.GetString("IdentName");
                tbSSCC.Text = item.GetString("SSCC");
                tbSerialNumber.Text = item.GetString("SerialNo");
                if (CommonData.GetSetting("ShowNumberOfUnitsField") == "1")
                {
                    tbQty.Text = item.GetDouble("Factor").ToString() + " x " + item.GetDouble("Packing").ToString();
                }
                else
                {
                    tbQty.Text = item.GetDouble("Qty").ToString();
                }
                tbLocation.Text = item.GetString("LocationName");

                var created = item.GetDateTime("DateInserted");
                tbCreatedBy.Text = created == null ? "" : ((DateTime)created).ToString("dd.MM.") + " " + item.GetString("ClerkName");

                btUpdate.Enabled = true;
                btDelete.Enabled = true;
            }
            else
            {
                lbInfo.Text = "Vnešene pozicije na medskladiščnici (ni)";

                tbIdent.Text = "";
                tbSSCC.Text = "";
                tbSerialNumber.Text = "";
                tbQty.Text = "";
                tbLocation.Text = "";
                tbCreatedBy.Text = "";

                btUpdate.Enabled = false;
                btDelete.Enabled = false;
            }
        }
    }
}