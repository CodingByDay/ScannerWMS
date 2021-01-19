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
using Microsoft.AppCenter.Crashes;
using ScannerQR.Printing;
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;
using static Android.App.ActionBar;

namespace ScannerQR
{
    [Activity(Label = "ProductionCard")]
    public class ProductionCard : Activity
    {
        private EditText tbWorkOrder;
        private EditText tbIdent;
        private EditText tbCardNum;
        private EditText tbSerialNum;
        private EditText tbQty;

        private Button btConfirm;
        private Button btExit;
        private NameValueObject cardInfo = (NameValueObject)InUseObjects.Get("CardInfo");
        private Dialog popupDialog;
        private Button btnYes;
        private Button btnNo;
        private bool target;

        private bool Response()
        {
            popupDialog = new Dialog(this);
            popupDialog.SetContentView(Resource.Layout.YesNoProductionCard);
            popupDialog.Window.SetSoftInputMode(SoftInput.AdjustResize);
            popupDialog.Show();

            popupDialog.Window.SetLayout(LayoutParams.MatchParent, LayoutParams.WrapContent);
            popupDialog.Window.SetBackgroundDrawableResource(Android.Resource.Color.HoloOrangeLight);
            btnYes = popupDialog.FindViewById<Button>(Resource.Id.btnYes);
            btnNo = popupDialog.FindViewById<Button>(Resource.Id.btnNo);

            btnNo.Click += BtnNo_Click;
            btnYes.Click += BtnYes_Click;



            return target;
        }

        private void BtnNo_Click(object sender, EventArgs e)
        {
            target = false;
        }

        private void BtnYes_Click(object sender, EventArgs e)
        {
            target = true;
        }
        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // Setting F2 to method ProccesStock()
                case Keycode.F4:
                    if (btConfirm.Enabled == true)
                    {
                        BtConfirm_Click(this, null);
                    }
                    break;

                case Keycode.F8:
                 //
   
                        BtExit_Click(this, null);
 
                    break;



                    //return true;



            }
            return base.OnKeyDown(keyCode, e);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ProductionCard);
            tbWorkOrder = FindViewById<EditText>(Resource.Id.tbWorkOrder);
            tbIdent = FindViewById<EditText>(Resource.Id.tbIdent);
            tbCardNum = FindViewById<EditText>(Resource.Id.tbCardNum);
            tbSerialNum = FindViewById<EditText>(Resource.Id.tbSerialNum);
            tbQty = FindViewById<EditText>(Resource.Id.tbQty);

            btConfirm = FindViewById<Button>(Resource.Id.btConfirm);
            btExit = FindViewById<Button>(Resource.Id.btExit);
            tbWorkOrder.Text = cardInfo.GetString("WorkOrder").Trim();
            tbIdent.Text = cardInfo.GetString("Ident").Trim();
            tbQty.Text = cardInfo.GetDouble("UM1toUM2").ToString("###,###,##0.00");
            btConfirm.Click += BtConfirm_Click;
            btExit.Click += BtExit_Click;

            try
            {
                string error;
                var data = Services.GetObject("cwns", tbWorkOrder.Text + "|" + tbIdent.Text + "|0", out error);
                if (data == null)
                {
                    string SuccessMessage = string.Format("Napaka pri pridobivanju podatkov: " + error);
                    Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();

                }
                else
                {
                    if (data.GetBool("Warning"))
                    {
                        if (Response())
                        {
                            data = Services.GetObject("cwns", tbWorkOrder.Text + "|" + tbIdent.Text + "|1", out error);
                            if (data == null)
                            {
                                string SuccessMessage = string.Format("Napaka pri pridobivanju podatkov: " + error);
                                Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();

                            }
                        }
                    }

                    tbCardNum.Text = data.GetInt("CardNum").ToString();
                    tbSerialNum.Text = data.GetString("SerialNum");
                    btConfirm.Enabled = true;
                }
            }
            finally
            {
               // Used to be a wait form...
            }


        }

        private void BtExit_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void BtConfirm_Click(object sender, EventArgs e)
        {
            var nvo = new NameValueObject("MoveCard");
            nvo.SetString("WorkOrder", tbWorkOrder.Text);
            nvo.SetString("Ident", tbIdent.Text);
            nvo.SetInt("CardNum", Convert.ToInt32(tbCardNum.Text));
            nvo.SetString("SerialNum", tbSerialNum.Text);
            nvo.SetDouble("Qty", Convert.ToDouble(tbQty.Text));
            nvo.SetInt("ClerkIns", Services.UserID());

           
       //
            try
            {
                string error;
                nvo = Services.SetObject("cwns", nvo, out error);
                if (nvo == null)
                {
                    string SuccessMessage = string.Format("Shranjevanje neuspešno, napaka: " + error);
                    
                    Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();

                }
                else
                {
                    var pr = new NameValueObject("PrintCard");
                    PrintingCommon.SetNVOCommonData(ref pr);
                    pr.SetInt("CardID", nvo.GetInt("ID"));
                    PrintingCommon.SendToServer(pr);

                  //
                }
            }
            finally
            {
            //wf.stop
            }

        }
    }
}