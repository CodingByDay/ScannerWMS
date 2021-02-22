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

namespace ScannerQR
{
    [Activity(Label = "ProductionWorkOrderSetupTablet", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class ProductionWorkOrderSetupTablet : Activity, IBarcodeResult
    {
        private NameValueObject moveHead = null;
        private NameValueObject ident = null;
        private EditText tbWorkOrder;
        private EditText tbOpenQty;
        private EditText tbClient;
        private EditText tbIdent;
        private EditText tbName;
        private Button check;
        private Button btCard;
        private Button btConfirm;
        private Button btPalette;
        private Button button2;
        SoundPool soundPool;
        int soundPoolId;
        public void GetBarcode(string barcode)
        {
            if (tbWorkOrder.HasFocus)
            {
                Sound();
                tbWorkOrder.Text = barcode;
                ProcessWorkOrder();
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ProductionWorkOrderSetupTablet);
            // sound library
            soundPool = new SoundPool(10, Stream.Music, 0);
            soundPoolId = soundPool.Load(this, Resource.Drawable.beep, 1);
            // button next
            tbWorkOrder = FindViewById<EditText>(Resource.Id.tbWorkOrder);
            tbOpenQty = FindViewById<EditText>(Resource.Id.tbOpenQty);
            tbClient = FindViewById<EditText>(Resource.Id.tbClient);
            tbIdent = FindViewById<EditText>(Resource.Id.tbIdent);
            tbName = FindViewById<EditText>(Resource.Id.tbName);
            btCard = FindViewById<Button>(Resource.Id.btCard);
            btConfirm = FindViewById<Button>(Resource.Id.btConfirm);
            btPalette = FindViewById<Button>(Resource.Id.btPalette);
            button2 = FindViewById<Button>(Resource.Id.button2);
            color();
            tbOpenQty.FocusChange += TbOpenQty_FocusChange;
            btCard.Click += BtCard_Click;
            btConfirm.Click += BtConfirm_Click;
            btPalette.Click += BtPalette_Click;
            button2.Click += Button2_Click;
            tbWorkOrder.RequestFocus();
            tbOpenQty.Text = "";
            tbClient.Text = "";
            tbIdent.Text = "";
            tbName.Text = "";
            btConfirm.Enabled = false;
            btCard.Enabled = false;
            btPalette.Enabled = false;
            Barcode2D barcode2D = new Barcode2D();
            barcode2D.open(this, this);

        }
        private void TbOpenQty_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            ProcessWorkOrder();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainMenu));
        }

        private void color()
        {
            tbWorkOrder.SetBackgroundColor(Android.Graphics.Color.Aqua);
        }

        private void BtPalette_Click(object sender, EventArgs e)
        {
            var cardInfo = new NameValueObject("CardInfo");
            cardInfo.SetString("WorkOrder", tbWorkOrder.Text.Trim());
            cardInfo.SetString("Ident", tbIdent.Text.Trim());
            cardInfo.SetDouble("UM1toUM2", ident.GetDouble("UM1toUM2"));
            cardInfo.SetDouble("UM1toUM3", ident.GetDouble("UM1toUM3"));
            InUseObjects.Set("CardInfo", cardInfo);

            StartActivity(typeof(ProductionPaletteTablet));
        }

        private void BtConfirm_Click(object sender, EventArgs e)
        {
            if (SaveMoveHead())
            {
                StartActivity(typeof(ProductionSerialOrSSCCEntryTablet));
            }
        }

        private void BtCard_Click(object sender, EventArgs e)
        {
            var cardInfo = new NameValueObject("CardInfo");
            cardInfo.SetString("WorkOrder", tbWorkOrder.Text.Trim());
            cardInfo.SetString("Ident", tbIdent.Text.Trim());
            cardInfo.SetDouble("UM1toUM2", ident.GetDouble("UM1toUM2"));
            cardInfo.SetDouble("UM1toUM3", ident.GetDouble("UM1toUM3"));
            InUseObjects.Set("CardInfo", cardInfo);
            StartActivity(typeof(ProductionCard));
        }


        private bool SaveMoveHead()
        {
            NameValueObject workOrder = null;

            try
            {

                string error;
                workOrder = Services.GetObject("wo", tbWorkOrder.Text.Trim(), out error);
                if (workOrder == null)
                {
                    string SuccessMessage = string.Format("Uspešno poslani podatki.");
                    Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();
                    return false;
                }
            }
            finally
            {

            }

            var ident = CommonData.LoadIdent(tbIdent.Text.Trim());
            if (ident == null) { return false; }

            if (moveHead == null) { moveHead = new NameValueObject("MoveHead"); }
            if (!moveHead.GetBool("Saved"))
            {

                try
                {

                    string error;
                    var productionWarehouse = Services.GetObject("pw", workOrder.GetString("DocumentType") + "|" + ident.GetString("Set"), out error);
                    if ((productionWarehouse == null) || (string.IsNullOrEmpty(productionWarehouse.GetString("ProductionWarehouse"))))
                    {
                        string SuccessMessage = string.Format("Skladisće ni dosegljivo.");
                        Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();
                        return false;
                    }

                    /*
                    var dtObj = Services.Services.GetObject("dt", "", out error);
                    if (dtObj == null)
                    {
                        MessageForm.Show("Ni mogoče pridobiti strežniškega časa: " + error);
                        return false;
                    }
                    */

                    moveHead.SetInt("Clerk", Services.UserID());
                    moveHead.SetString("Type", "W");
                    moveHead.SetString("LinkKey", workOrder.GetString("Key"));
                    moveHead.SetString("LinkNo", workOrder.GetString("No"));
                    moveHead.SetString("Document1", "");
                    moveHead.SetDateTime("Document1Date", null);
                    moveHead.SetString("Note", "");
                    moveHead.SetString("Issuer", "");
                    moveHead.SetString("Receiver", "");
                    moveHead.SetString("Wharehouse", productionWarehouse.GetString("ProductionWarehouse"));
                    moveHead.SetString("DocumentType", workOrder.GetString("DocumentType"));

                    var savedMoveHead = Services.SetObject("mh", moveHead, out error);
                    if (savedMoveHead == null)
                    {
                        string SuccessMessage = string.Format("Napaka pri dostopu do web aplikacije" + error);
                        Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();
                        return false;
                    }
                    else
                    {
                        moveHead.SetInt("HeadID", savedMoveHead.GetInt("HeadID"));
                        moveHead.SetBool("Saved", true);
                        InUseObjects.Set("MoveHead", moveHead);
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


        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // in smartphone
                case Keycode.F2:
                    if (btCard.Enabled == true)
                    {
                        BtCard_Click(this, null);
                    }
                    break;

                case Keycode.F3:
                    if (btConfirm.Enabled == true)
                    {
                        BtConfirm_Click(this, null);
                    }
                    break;


                case Keycode.F4:
                    if (btPalette.Enabled == true)
                    {
                        BtPalette_Click(this, null);
                    }
                    break;

            }
            return base.OnKeyDown(keyCode, e);
        }

        private void ProcessWorkOrder()
        {
            tbOpenQty.Text = "";
            tbClient.Text = "";
            tbIdent.Text = "";
            tbName.Text = "";
            btConfirm.Enabled = false;
            btCard.Enabled = false;
            btPalette.Enabled = false;

            try
            {
                string error;
                NameValueObject workOrder = Services.GetObject("wo", tbWorkOrder.Text.Trim(), out error);
                if (workOrder == null)
                {
                    string SuccessMessage = string.Format("Napaka pri preverjanju delovnega naloga" + error);
                    Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();

                }
                else
                {
                    ident = Services.GetObject("id", workOrder.GetString("Ident"), out error);
                    if (ident == null)
                    {
                        string SuccessMessage = string.Format("Napaka pri preverjanju identa" + error);
                        Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();
                    }
                    else
                    {
                        tbOpenQty.Text = workOrder.GetDouble("OpenQty").ToString(CommonData.GetQtyPicture());
                        tbClient.Text = workOrder.GetString("Consignee");
                        tbIdent.Text = workOrder.GetString("Ident");
                        tbName.Text = workOrder.GetString("Name");

                        if (CommonData.GetSetting("ProductionIgnoreIdentCardInfo") == "1")
                        {
                            btCard.Enabled = true;
                            btPalette.Enabled = true;
                            btConfirm.Enabled = true;
                        }
                        else
                        {
                            if (ident.GetString("ProcessingMode").ToLower().Contains("karton"))
                            {
                                btCard.Enabled = true;
                                btPalette.Enabled = true;
                            }
                            else
                            {
                                btConfirm.Enabled = true;
                            }
                        }
                    }
                }
            }
            finally
            {
            }
        }
        private void Sound()
        {
            soundPool.Play(soundPoolId, 1, 1, 0, 0, 1);
        }


    }
}