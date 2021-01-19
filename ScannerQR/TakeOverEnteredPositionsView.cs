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
    [Activity(Label = "TakeOverEnteredPositionsView")]
    public class TakeOverEnteredPositionsView : Activity
    {
        private TextView lbInfo;

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
        private int displayedPosition = 0;
        private NameValueObject moveHead = (NameValueObject)InUseObjects.Get("MoveHead");
        private NameValueObjectList positions = null;
        private Dialog popupDialog;
        private Button btnYes;
        private Button btnNo;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application 


            SetContentView(Resource.Layout.TakeOverEnteredPositionsView);

            lbInfo = FindViewById<TextView>(Resource.Id.lbInfo);
            tbIdent = FindViewById<EditText>(Resource.Id.tbIdent);
            tbSSCC = FindViewById<EditText>(Resource.Id.tbSSCC);
            tbSerialNumber = FindViewById<EditText>(Resource.Id.tbSerialNumber);
            tbQty = FindViewById<EditText>(Resource.Id.tbQty);
            tbLocation = FindViewById<EditText>(Resource.Id.tbLocation);
            tbCreatedBy = FindViewById<EditText>(Resource.Id.tbCreatedBy);

            btNext = FindViewById<Button>(Resource.Id.btNext);
            btUpdate = FindViewById<Button>(Resource.Id.btUpdate);
            button4 = FindViewById<Button>(Resource.Id.button4);
            btFinish = FindViewById<Button>(Resource.Id.btFinish);
            btDelete = FindViewById<Button>(Resource.Id.btDelete);
            button5 = FindViewById<Button>(Resource.Id.button5);

            btNext.Click += BtNext_Click;
            btUpdate.Click += BtUpdate_Click;
            button4.Click += Button4_Click;
            btFinish.Click += BtFinish_Click;
            btDelete.Click += BtDelete_Click;
            button5.Click += Button5_Click;

            InUseObjects.ClearExcept(new string[] { "MoveHead" });
            if (moveHead == null) { throw new ApplicationException("moveHead not known at this point!?"); }

            LoadPositions();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
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
                            Toast.MakeText(this, "Napaka pri brisanju pozicije: " + result, ToastLength.Long).Show();
                            positions = null;
                            LoadPositions();
                            popupDialog.Dismiss();
                            popupDialog.Hide();
                            return;
                        }
                    }
                    else
                    {
                        Toast.MakeText(this, "Napaka pri dostopu do web aplikacije: " + result, ToastLength.Long).Show();
                        popupDialog.Dismiss();
                        popupDialog.Hide();
                        return;
                    }
                }
                finally
                {
                    popupDialog.Dismiss();
                    popupDialog.Hide();
                }
          
            }

        }

        private void BtFinish_Click(object sender, EventArgs e)
        {
        
            try
            {

                var headID = moveHead.GetInt("HeadID");

                string result;
                if (WebApp.Get("mode=finish&stock=add&print=" + Services.DeviceUser() + "&id=" + headID.ToString(), out result))
                {
                    if (result.StartsWith("OK!"))
                    {
                        var id = result.Split('+')[1];
                        Toast.MakeText(this, "Zaključevanje uspešno! Št. prevzema:\r\n" + id, ToastLength.Long).Show();

                   
                    }
                    else
                    {
                        Toast.MakeText(this, "Napaka pri zaključevanju: " + result, ToastLength.Long).Show();
          
                    }
                }
                else
                {
                    Toast.MakeText(this, "Napaka pri klicu web aplikacije:  " + result, ToastLength.Long).Show();

                }
            }
            finally
            {
               //wf
            }

         
 
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            // new
            if (CommonData.GetSetting("UseDirectTakeOver") == "1")
            {
                InUseObjects.Set("MoveHead", moveHead);
                InUseObjects.Set("MoveItem", null);
                StartActivity(typeof(TakeOver2Main));
              
                return;
            } else

            StartActivity(typeof(TakeOverIdentEntry));
      
        }

        private void BtUpdate_Click(object sender, EventArgs e)
        {

            var item = positions.Items[displayedPosition];
            InUseObjects.Set("MoveItem", item);

            if (CommonData.GetSetting("UseDirectTakeOver") == "1")
            {
                InUseObjects.Set("MoveHead", moveHead);
                StartActivity(typeof(TakeOver2Main));
               
                return;
            }

      
            try
            {
                Toast.MakeText(this, "Nalagam ident...  ", ToastLength.Long).Show();

                string error;
                var openIdent = Services.GetObject("id", item.GetString("Ident"), out error);
                if (openIdent == null)
                {

                    Toast.MakeText(this, "Napaka pri preverjanju identa.  " + error, ToastLength.Long).Show();
  
                }
                else
                {
                    item.SetString("Ident", openIdent.GetString("Code"));
                    InUseObjects.Set("OpenIdent", openIdent);
                    StartActivity(typeof(TakeOverSerialOrSSCCEntry));
      
                }
            }
            finally
            {
             //
            }
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
                        positions = Services.GetObjectList("mi", out error, moveHead.GetInt("HeadID").ToString());
                        InUseObjects.Set("TakeOverEnteredPositions", positions);
                    }
                    if (positions == null)
                    {
                        Toast.MakeText(this, "Napaka pri dostopu do web aplikacije: " + error, ToastLength.Long).Show();
            
                        return;
                    }
                }

                displayedPosition = 0;
                FillDisplayedItem();
            }
            finally
            {
                //used to be a wait form.
            }
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // Setting F2 to method ProccesStock()
                case Keycode.F1:
                    if (btNext.Enabled == true)
                    {
                        BtNext_Click(this, null);
                    }
                    break;

                case Keycode.F2:
                    if (btUpdate.Enabled == true)
                    {
                        BtUpdate_Click(this, null);
                    }
                    break;

                case Keycode.F3://
                    if (button4.Enabled == true)
                    {
                        Button4_Click(this, null);
                    }
                    break;

                case Keycode.F4:
                    if (btFinish.Enabled == true)
                    {
                        BtFinish_Click(this, null);
                    }
                    break;

                case Keycode.F5:
                    if (btDelete.Enabled == true)
                    {
                        BtDelete_Click(this, null);
                    }
                    break;

                case Keycode.F6:
                    if (button5.Enabled == true)
                    {
                        Button5_Click(this, null);
                    }
                    break;


                    //return true;



            }
            return base.OnKeyDown(keyCode, e);
        }

        private void FillDisplayedItem()
        {
            if ((positions != null) && (displayedPosition < positions.Items.Count))
            {
                var item = positions.Items[displayedPosition];
                lbInfo.Text = "Vnešene pozicije na naročilu (" + (displayedPosition + 1).ToString() + "/" + positions.Items.Count + ")";

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



                tbIdent.Enabled = false;
                tbSSCC.Enabled = false;
                tbSerialNumber.Enabled = false;
                tbQty.Enabled = false;
                tbLocation.Enabled = false;
                tbCreatedBy.Enabled = false;


                tbIdent.SetTextColor(Android.Graphics.Color.Black);
                tbSSCC.SetTextColor(Android.Graphics.Color.Black);
                tbQty.SetTextColor(Android.Graphics.Color.Black);
                tbQty.SetTextColor(Android.Graphics.Color.Black);
                tbLocation.SetTextColor(Android.Graphics.Color.Black);
                tbCreatedBy.SetTextColor(Android.Graphics.Color.Black);


                btUpdate.Enabled = true;
                btDelete.Enabled = true;
            }
            else
            {
                lbInfo.Text = "Vnešene pozicije na naročilu (ni)";

                tbIdent.Text = "";
                tbSSCC.Text = "";
                tbSerialNumber.Text = "";
                tbQty.Text = "";
                tbLocation.Text = "";
                tbCreatedBy.Text = "";


                tbIdent.Enabled = false;
                tbSSCC.Enabled = false;
                tbSerialNumber.Enabled = false;
                tbQty.Enabled = false;
                tbLocation.Enabled = false;
                tbCreatedBy.Enabled = false;


                tbIdent.SetTextColor(Android.Graphics.Color.Black);
                tbSSCC.SetTextColor(Android.Graphics.Color.Black);
                tbQty.SetTextColor(Android.Graphics.Color.Black);
                tbQty.SetTextColor(Android.Graphics.Color.Black);
                tbLocation.SetTextColor(Android.Graphics.Color.Black);
                tbCreatedBy.SetTextColor(Android.Graphics.Color.Black);

                btUpdate.Enabled = false;
                btDelete.Enabled = false;
                btNext.Enabled = false;
            }
        }
    }
}