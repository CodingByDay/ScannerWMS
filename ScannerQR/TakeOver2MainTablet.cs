﻿using System;
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
using Scanner.App;
using Scanner.Printing;
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;

namespace Scanner
{
    [Activity(Label = "TakeOver2MainTablet", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class TakeOver2MainTablet : Activity, IBarcodeResult
    {
        SoundPool soundPool;
        int soundPoolId;
        private EditText tbIdent;
        private EditText tbNaziv;
        private EditText tbKolicinaDoSedaj;
        private EditText tbKolicinaNova;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private NameValueObject moveHead = (NameValueObject)InUseObjects.Get("MoveHead");
        private NameValueObject moveItem = (NameValueObject)InUseObjects.Get("MoveItem");

        public void GetBarcode(string barcode)
        {
            if (tbIdent.HasFocus)
            {
                Sound();
                tbIdent.Text = barcode;
                ProcessIdent();
            }
        }
        private void ProcessIdent()
        {
            var ident = CommonData.LoadIdent(tbIdent.Text.Trim());
            if (ident == null)
            {
                tbIdent.Text = "";
                tbIdent.RequestFocus();
                return;
            }


            try
            {
                string error;
                var mhID = moveHead.GetInt("HeadID").ToString();
                var mis = Services.GetObjectList("mi", out error, mhID);
                if (mis == null)
                {
                    Toast.MakeText(this, "Napaka pri pridobivanju podatkov iz strežnika: " + error, ToastLength.Long).Show();

                    return;
                }

                var existing = mis.Items.FirstOrDefault(mi => mi.GetString("Ident") == ident.GetString("Code"));
                if (existing != null)
                {
                    moveItem = existing;
                }
            }
            finally
            {

            }

            tbIdent.Text = ident.GetString("Code");
            tbNaziv.Text = ident.GetString("Name");
            tbKolicinaDoSedaj.Text = moveItem == null ? "" : moveItem.GetDouble("Qty").ToString("###,###,##0.00");
            tbKolicinaNova.Text = "";
            tbKolicinaNova.RequestFocus();
        }
        private bool SaveHead()
        {
            if (!moveHead.GetBool("Saved"))
            {
                moveHead.SetString("DocumentType", CommonData.GetSetting("DirectTakeOverDocType"));
                if (string.IsNullOrEmpty(moveHead.GetString("DocumentType")))
                {
                    throw new ApplicationException("Missing setting: DirectTakeOverDocType");
                }
                //moveHead.SetString("Wharehouse", itemWH.ID);
                moveHead.SetBool("ByOrder", false);
                //moveHead.SetString("Receiver", itemSubj.ID);
                moveHead.SetInt("Clerk", Services.UserID());
                moveHead.SetString("Type", "I");
                moveHead.SetString("LinkKey", ""); // TODO ???
                //moveHead.SetString("LinkNo", order.GetString("No"));
                //moveHead.SetString("Document1", order.GetString("Document1"));
                //moveHead.SetDateTime("Document1Date", order.GetDateTime("Document1Date"));
                //moveHead.SetString("Note", order.GetString("Note"));
                string error;
                var savedMoveHead = Services.SetObject("mh", moveHead, out error);
                if (savedMoveHead == null)
                {
                    Toast.MakeText(this, "Napaka pri shranjevanju glave: " + error, ToastLength.Long).Show();

                    return false;
                }
                else
                {
                    moveHead.SetInt("HeadID", savedMoveHead.GetInt("HeadID"));
                    moveHead.SetBool("Saved", true);
                }
            }

            return true;
        }
        private NameValueObject SaveItem(bool allowEmpty)
        {
            if (allowEmpty && string.IsNullOrEmpty(tbIdent.Text.Trim())) { return null; }

            if (SaveHead())
            {
                if (string.IsNullOrEmpty(tbIdent.Text.Trim()))
                {
                    Toast.MakeText(this, "Ident ni podan!", ToastLength.Long).Show();

                    return null;
                }

                var ident = CommonData.LoadIdent(tbIdent.Text.Trim());
                if (ident == null) { return null; }

                double kol;
                try
                {
                    var kolDoSedajStr = tbKolicinaDoSedaj.Text.Trim();
                    var kolDoSedaj = string.IsNullOrEmpty(kolDoSedajStr) ? 0.0 : Convert.ToDouble(kolDoSedajStr);
                    var kolNovaStr = tbKolicinaNova.Text.Trim();
                    var kolNova = string.IsNullOrEmpty(kolNovaStr) ? 0.0 : Convert.ToDouble(kolNovaStr);
                    if (kolNova == 0.0)
                    {
                        Toast.MakeText(this, "Količina ne sme biti 0!", ToastLength.Long).Show();

                        return null;
                    }
                    kol = kolDoSedaj + kolNova;
                    if (kol < 0.0)
                    {
                        Toast.MakeText(this, "Količina vračila presega dosedanji prevzem!", ToastLength.Long).Show();

                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Toast.MakeText(this, "Količina mora biti število (" + ex.Message + ")!", ToastLength.Long).Show();
                    tbKolicinaNova.RequestFocus();
                    return null;
                }

                try
                {
                    if (moveItem == null) { moveItem = new NameValueObject("MoveItem"); }
                    moveItem.SetInt("HeadID", moveHead.GetInt("HeadID"));
                    moveItem.SetString("LinkKey", ""); // TODO
                    //moveItem.SetInt("LinkNo", openOrder.GetInt("No"));
                    moveItem.SetString("Ident", ident.GetString("Code"));
                    //moveItem.SetString("SSCC", tbSSCC.Text.Trim());
                    //moveItem.SetString("SerialNo", tbSerialNum.Text.Trim());
                    moveItem.SetDouble("Packing", 0.0);
                    moveItem.SetDouble("Factor", 1.0);
                    moveItem.SetDouble("Qty", kol);
                    moveItem.SetInt("MorePrints", 0);
                    moveItem.SetInt("Clerk", Services.UserID());
                    //moveItem.SetString("Location", tbLocation.Text.Trim());
                    //moveItem.SetBool("PrintNow", CommonData.GetSetting("ImmediatePrintOnReceive") == "1");
                    moveItem.SetInt("UserID", Services.UserID());
                    moveItem.SetString("DeviceID", WMSDeviceConfig.GetString("ID", ""));

                    InUseObjects.Set("MoveItem", moveItem);

                    string error;
                    moveItem = Services.SetObject("mi", moveItem, out error);
                    if (moveItem == null)
                    {
                        Toast.MakeText(this, "Napaka pri dostopu do web aplikacije: " + error, ToastLength.Long).Show();

                        return null;
                    }

                    return ident;
                }
                finally
                {

                }
            }

            return null;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TakeOver2MainTablet);
            tbIdent = FindViewById<EditText>(Resource.Id.tbIdent);
            tbNaziv = FindViewById<EditText>(Resource.Id.tbNaziv);
            tbKolicinaDoSedaj = FindViewById<EditText>(Resource.Id.tbKolicinaDoSedaj);
            tbKolicinaNova = FindViewById<EditText>(Resource.Id.tbKolicinaNova);
            button1 = FindViewById<Button>(Resource.Id.button1);
            button2 = FindViewById<Button>(Resource.Id.button2);
            button3 = FindViewById<Button>(Resource.Id.button3);
            button4 = FindViewById<Button>(Resource.Id.button4);
            button5 = FindViewById<Button>(Resource.Id.button5);
            soundPool = new SoundPool(10, Stream.Music, 0);
            soundPoolId = soundPool.Load(this, Resource.Drawable.beep, 1);
            Barcode2D barcode2D = new Barcode2D();
            barcode2D.open(this, this);
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            button3.Click += Button3_Click;
            button4.Click += Button4_Click;
            button5.Click += Button5_Click;
            tbIdent.KeyPress += TbIdent_KeyPress;
            if (moveItem != null)
            {

                var ident = CommonData.LoadIdent(moveItem.GetString("Ident"));
                if (ident == null)
                {
                    throw new ApplicationException("Ident no longer supported!?");
                }

                tbIdent.Text = ident.GetString("Code");
                tbNaziv.Text = ident.GetString("Name");
                tbKolicinaDoSedaj.Text = moveItem == null ? "" : moveItem.GetDouble("Qty").ToString("###,###,##0.00");
                tbKolicinaNova.Text = "";
                tbKolicinaNova.RequestFocus();
            }
        }
        private void Sound()
        {
            soundPool.Play(soundPoolId, 1, 1, 0, 0, 1);

        }
        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // in smartphone        
                case Keycode.F1:
                    if (button1.Enabled == true)
                    {
                        Button1_Click(this, null);
                    }
                    break;
                //return true;

                case Keycode.F2:
                    if (button2.Enabled == true)
                    {
                        Button2_Click(this, null);
                    }
                    break;


                case Keycode.F3:
                    if (button3.Enabled == true)
                    {
                        Button3_Click(this, null);
                    }
                    break;

                case Keycode.F4:
                    if (button4.Enabled == true)
                    {
                        Button4_Click(this, null);
                    }
                    break;


                case Keycode.F8:
                    if (button5.Enabled == true)
                    {
                        Button5_Click(this, null);
                    }
                    break;


            }
            return base.OnKeyDown(keyCode, e);
        }
        private void TbIdent_KeyPress(object sender, View.KeyEventArgs e)
        {
            e.Handled = false;
            if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
            {
                //add your logic here 
                ProcessIdent();
                e.Handled = true;
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainMenuTablet));
            HelpfulMethods.clearTheStack(this);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            SaveItem(true);
            StartActivity(typeof(TakeOverEnteredPositionsViewTablet));
            HelpfulMethods.clearTheStack(this);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (SaveItem(false) != null)
            {
                Toast.MakeText(this, "Tiskam... ", ToastLength.Long).Show();
                try
                {

                    var nvo = new NameValueObject("InternalSticker");
                    PrintingCommon.SetNVOCommonData(ref nvo);
                    nvo.SetString("Ident", tbIdent.Text);
                    PrintingCommon.SendToServer(nvo);
                }
                finally
                {
                    Toast.MakeText(this, "Uspešno. ", ToastLength.Long).Show();
                }
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (SaveItem(false) != null)
            {
                InUseObjects.Set("MoveItem", null);
                StartActivity(typeof(TakeOver2MainTablet));
                HelpfulMethods.clearTheStack(this);

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (SaveItem(false) != null)
            {
                InUseObjects.Set("MoveItem", moveItem);
                StartActivity(typeof(TakeOver2OrdersTablet));
                HelpfulMethods.clearTheStack(this);

            }
        }
    }
}