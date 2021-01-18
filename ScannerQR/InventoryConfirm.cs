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
using WebApp = TrendNET.WMS.Device.Services.WebApp;

namespace ScannerQR
{
    [Activity(Label = "InventoryConfirm")]
    public class InventoryConfirm : Activity
    {
        private TextView lbInfo;
        private EditText tbWarehouse;
        private EditText tbTitle;
        private EditText tbDate;
        private EditText tbItems;
        private EditText tbCreatedBy;
        private EditText tbCreatedAt;

        private Button btNext;
        private Button btConfirm;
        private Button button3;
        private int displayedPosition = 0;

        private NameValueObjectList positions = null;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.InventoryConfirm);

            lbInfo = FindViewById<TextView>(Resource.Id.lbInfo);

            tbWarehouse = FindViewById<EditText>(Resource.Id.tbWarehouse);
            tbTitle = FindViewById<EditText>(Resource.Id.tbTitle);
            tbDate = FindViewById<EditText>(Resource.Id.tbDate);
            tbItems = FindViewById<EditText>(Resource.Id.tbItems);
            tbCreatedBy = FindViewById<EditText>(Resource.Id.tbCreatedBy);
            tbCreatedAt = FindViewById<EditText>(Resource.Id.tbCreatedAt);

            btNext = FindViewById<Button>(Resource.Id.btNext);
            btConfirm = FindViewById<Button>(Resource.Id.btConfirm);
            button3 = FindViewById<Button>(Resource.Id.button3);

            btNext.Click += BtNext_Click;
            btConfirm.Click += BtConfirm_Click;
            button3.Click += Button3_Click;

            InUseObjects.Clear();

            LoadPositions();

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }


        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {

                case Keycode.F2:
                    if (btNext.Enabled == true)
                    {
                        BtNext_Click(this, null);
                    }
                    break;
                // return true;

                case Keycode.F3:
                    if (btConfirm.Enabled == true)
                    {
                        BtConfirm_Click(this, null);
                    }
                    break;

                case Keycode.F8:

                    Button3_Click(this, null);
                    break;
            }
            return base.OnKeyDown(keyCode, e);
        }
      
        private void BtConfirm_Click(object sender, EventArgs e)
        {

            var moveHead = positions.Items[displayedPosition];
            var headID = moveHead.GetInt("HeadID");

            string result;
            if (WebApp.Get("mode=finish&id=" + headID.ToString(), out result))
            {
                if (result.StartsWith("OK!"))
                {
                    var id = result.Split('+')[1];
                    Toast.MakeText(this, "Potrjevanje uspešno! Št. potrditve: " + id, ToastLength.Long).Show();
  
                   StartActivity(typeof(InventoryConfirm));
                  
                }
                else
                {
                    Toast.MakeText(this, "Napaka pri potrjevanju: " + result, ToastLength.Long).Show();

                }
            }
            else
            {
                Toast.MakeText(this, "Napaka pri klicu web aplikacije: " + result, ToastLength.Long).Show();

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
                        positions = Services.GetObjectList("mh", out error, "N");
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
               //wait form before...
            }
        }



        private void FillDisplayedItem()
        {
            if ((positions != null) && (positions.Items.Count > 0))
            {
                lbInfo.Text = "Odprte inventure na čitalcu (" + (displayedPosition + 1).ToString() + "/" + positions.Items.Count + ")";
                var item = positions.Items[displayedPosition];

                tbWarehouse.Text = item.GetString("Wharehouse");
                tbTitle.Text = item.GetString("WharehouseName");
                var date = item.GetDateTime("Date");
                tbDate.Text = date == null ? "" : ((DateTime)date).ToString("dd.MM.yyyy");
                tbItems.Text = item.GetInt("ItemCount").ToString();
                tbCreatedBy.Text = item.GetString("ClerkName");

                var created = item.GetDateTime("DateInserted");
                tbCreatedAt.Text = created == null ? "" : ((DateTime)created).ToString("dd.MM.yyyy");

                btNext.Enabled = true;
                btConfirm.Enabled = true;

                tbWarehouse.Enabled = false;
                tbTitle.Enabled = false;
                tbDate.Enabled = false;
                tbItems.Enabled = false;
                tbCreatedBy.Enabled = false;
                tbCreatedAt.Enabled = false;

                tbWarehouse.SetTextColor(Android.Graphics.Color.Black);
                tbTitle.SetTextColor(Android.Graphics.Color.Black);
                tbDate.SetTextColor(Android.Graphics.Color.Black);
                tbItems.SetTextColor(Android.Graphics.Color.Black);
                tbCreatedBy.SetTextColor(Android.Graphics.Color.Black);
                tbCreatedAt.SetTextColor(Android.Graphics.Color.Black);

            }
            else
            {
                lbInfo.Text = "Odprte inventure na čitalcu (ni)";

                tbWarehouse.Text = "";
                tbTitle.Text = "";
                tbDate.Text = "";
                tbItems.Text = "";
                tbCreatedBy.Text = "";
                tbCreatedAt.Text = "";

                btNext.Enabled = false;
                btConfirm.Enabled = false;


                tbWarehouse.Enabled = false;
                tbTitle.Enabled = false;
                tbDate.Enabled = false;
                tbItems.Enabled = false;
                tbCreatedBy.Enabled = false;
                tbCreatedAt.Enabled = false;




                tbWarehouse.SetTextColor(Android.Graphics.Color.Black);
                tbTitle.SetTextColor(Android.Graphics.Color.Black);
                tbDate.SetTextColor(Android.Graphics.Color.Black);
                tbItems.SetTextColor(Android.Graphics.Color.Black);
                tbCreatedBy.SetTextColor(Android.Graphics.Color.Black);
                tbCreatedAt.SetTextColor(Android.Graphics.Color.Black);
            }
        }

    }
}