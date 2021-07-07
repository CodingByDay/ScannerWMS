using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BarCode2D_Receiver;
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;

namespace Scanner
{
    [Activity(Label = "IssuedGoodsIdentEntryTablet", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class IssuedGoodsIdentEntryTablet : Activity, IBarcodeResult
    {
        // Definitions
        // for the 
        // components.
        private EditText tbIdent;
        private EditText tbNaziv;
        private EditText tbOrder;
        private EditText tbConsignee;
        private EditText tbDeliveryDeadline;
        private EditText tbQty;
        private Button btNext;
        private Button btConfirm;
        private Button button4;
        private Button button5;
        SoundPool soundPool;
        int soundPoolId;
        private NameValueObject moveHead = (NameValueObject)InUseObjects.Get("MoveHead");
        private NameValueObject openIdent = null;
        private NameValueObjectList openOrders = null;
        private int displayedOrder = -1;
        private TextView lbOrderInfo;



        private void Sound()
        {
            soundPool.Play(soundPoolId, 1, 1, 0, 0, 1);
        }

        public void GetBarcode(string barcode)
        {
            // pass
            if (tbIdent.HasFocus)
            {
                Sound();
                tbIdent.Text = barcode;
                ProcessIdent();

            }
        }
        public void color()
        {
            tbIdent.SetBackgroundColor(Android.Graphics.Color.Aqua);
        }

        private void ProcessIdent()
        {
            var ident = tbIdent.Text.Trim();
            if (string.IsNullOrEmpty(ident)) { return; }

            try
            {

                string error;
                openIdent = Services.GetObject("id", ident, out error);
                if (openIdent == null)
                {


                    string SuccessMessage = string.Format("Napaka pri preverjanju identa." + error);
                    Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();
                    tbIdent.Text = "";
                    tbIdent.RequestFocus();
                    tbNaziv.Text = "";
                    openOrders = null;
                }
                else
                {
                    ident = openIdent.GetString("Code");
                    tbIdent.Text = ident;
                    InUseObjects.Set("OpenIdent", openIdent);

                    var isPackaging = openIdent.GetBool("IsPackaging");
                    if (!moveHead.GetBool("ByOrder") || isPackaging)
                    {
                        if (SaveMoveHead())
                        {
                            StartActivity(typeof(IssuedGoodsSerialOrSSCCEntryTablet));

                        }
                        return;
                    }
                    else
                    {
                        tbNaziv.Text = openIdent.GetString("Name");

                        openOrders = Services.GetObjectList("oo", out error, ident + "|" + moveHead.GetString("DocumentType"));
                        if (openOrders == null)
                        {
                            string WebError = string.Format("Napaka pri dobijanju otprtih naročila" + error);
                            Toast.MakeText(this, WebError, ToastLength.Long).Show(); tbIdent.Text = "";
                            tbIdent.RequestFocus();
                            tbNaziv.Text = "";
                        }
                        else
                        {
                            InUseObjects.Set("openOrders", openOrders);
                            displayedOrder = 0;
                        }
                    }
                }

                FillDisplayedOrderInfo();
                btConfirm.RequestFocus();
            }
            finally
            {

            }
        }

        private void FillDisplayedOrderInfo()
        {
            if ((openIdent != null) && (openOrders != null) && (openOrders.Items.Count > 0))
            {
                lbOrderInfo.Text = "Naročilo (" + (displayedOrder + 1).ToString() + "/" + openOrders.Items.Count.ToString() + ")";
                var order = openOrders.Items[displayedOrder];
                InUseObjects.Set("OpenOrder", order);
                tbOrder.Text = order.GetString("Key") + " / " + order.GetInt("No");
                tbConsignee.Text = order.GetString("Consignee");
                tbQty.Text = order.GetDouble("OpenQty").ToString(CommonData.GetQtyPicture());
                var deadLine = order.GetDateTime("DeliveryDeadline");
                tbDeliveryDeadline.Text = deadLine == null ? "" : ((DateTime)deadLine).ToString("dd.MM.yyyy");
                btNext.Enabled = true;
                btConfirm.Enabled = true;
            }
            else
            {
                InUseObjects.Invalidate("OpenOrder");
                lbOrderInfo.Text = "Naročilo (ni postavk)";
                tbOrder.Text = "";
                tbConsignee.Text = "";
                tbQty.Text = "";
                tbDeliveryDeadline.Text = "";
                btNext.Enabled = false;
                btConfirm.Enabled = false;
            }
        }

        private bool SaveMoveHead()
        {
            NameValueObject order;
            if ((openOrders == null) || (openOrders.Items.Count == 0))
            {
                order = new NameValueObject("OpenOrder");
                InUseObjects.Set("OpenOrder", order);
            }
            else
            {
                order = openOrders.Items[displayedOrder];
                InUseObjects.Set("OpenOrder", order);
            }

            if (!moveHead.GetBool("Saved"))
            {

                try
                {

                    moveHead.SetInt("Clerk", Services.UserID());
                    moveHead.SetString("Type", "P");
                    moveHead.SetString("LinkKey", order.GetString("Key"));
                    moveHead.SetString("LinkNo", order.GetString("No"));
                    moveHead.SetString("Document1", order.GetString("Document1"));
                    moveHead.SetDateTime("Document1Date", order.GetDateTime("Document1Date"));
                    moveHead.SetString("Note", order.GetString("Note"));
                    if (moveHead.GetBool("ByOrder"))
                    {
                        moveHead.SetString("Receiver", order.GetString("Receiver"));
                    }

                    string error;
                    var savedMoveHead = Services.SetObject("mh", moveHead, out error);
                    if (savedMoveHead == null)
                    {
                        string WebError = string.Format("Napaka pri dostopu do web aplikacije" + error);
                        Toast.MakeText(this, WebError, ToastLength.Long).Show(); return false;
                    }
                    else
                    {
                        moveHead.SetInt("HeadID", savedMoveHead.GetInt("HeadID"));
                        moveHead.SetBool("Saved", true);
                        return true;
                    }
                }
                finally
                {
                }
            }
            else
            {
                return true;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.IssuedGoodsIdentEntryTablet);
            tbOrder = FindViewById<EditText>(Resource.Id.tbOrder);
            tbIdent = FindViewById<EditText>(Resource.Id.tbIdent);
            tbNaziv = FindViewById<EditText>(Resource.Id.tbNaziv);
            tbConsignee = FindViewById<EditText>(Resource.Id.tbConsignee);
            tbDeliveryDeadline = FindViewById<EditText>(Resource.Id.tbDeliveryDeadline);
            tbQty = FindViewById<EditText>(Resource.Id.tbQty);
            btNext = FindViewById<Button>(Resource.Id.btNext);
            btConfirm = FindViewById<Button>(Resource.Id.btConfirm);
            button4 = FindViewById<Button>(Resource.Id.button4);
            button5 = FindViewById<Button>(Resource.Id.button5);
            lbOrderInfo = FindViewById<TextView>(Resource.Id.lbOrderInfo);
            tbQty = FindViewById<EditText>(Resource.Id.tbQty);
            color();
            btNext.Enabled = false;
            btConfirm.Enabled = false;
            soundPool = new SoundPool(10, Stream.Music, 0);
            soundPoolId = soundPool.Load(this, Resource.Drawable.beep, 1);
            Barcode2D barcode2D = new Barcode2D();
            barcode2D.open(this, this);
            tbNaziv.FocusChange += TbNaziv_FocusChange;
            btNext.Click += BtNext_Click;
            btConfirm.Click += BtConfirm_Click;
            button4.Click += Button4_Click;
            button5.Click += Button5_Click;
            tbIdent.RequestFocus();
        }

   
        private void TbNaziv_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            ProcessIdent();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
         
            StartActivity(typeof(MainMenuTablet));

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            // F4
            StartActivity(typeof(IssuedGoodsEnteredPositionsViewTablet));
            this.Finish();

        }

        private void BtConfirm_Click(object sender, EventArgs e)
        {
            // F3
            if (SaveMoveHead())
            {
                StartActivity(typeof(IssuedGoodsSerialOrSSCCEntryTablet));
                this.Finish();

            }

        }

        private void BtNext_Click(object sender, EventArgs e)
        {
            // F2
            displayedOrder++;
            if (displayedOrder >= openOrders.Items.Count) { displayedOrder = 0; }
            FillDisplayedOrderInfo();
        }


        // function keys

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // in smartphone
                case Keycode.F2:
                    if (btNext.Enabled == true)
                    {
                        BtNext_Click(this, null);
                    }
                    break;
                //return true;


                case Keycode.F3:
                    if (btConfirm.Enabled == true)
                    {
                        BtConfirm_Click(this, null);
                    }
                    break;


                case Keycode.F4:
                    if (button4.Enabled == true)
                    {
                        Button4_Click(this, null);
                    }
                    break;

                case Keycode.F9:
                    if (button5.Enabled == true)
                    {
                        Button5_Click(this, null);
                    }
                    break;

            }
            return base.OnKeyDown(keyCode, e);
        }
    }
}