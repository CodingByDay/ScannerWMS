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
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;

namespace ScannerQR
{
    [Activity(Label = "PackagingSetContextTablet")]
    public class PackagingSetContextTablet : Activity, IBarcodeResult
    {
        private Spinner cbWarehouse;
        private EditText tbLocation;
        private EditText tbSSCC;
        private Button btConfirm;
        private Button btExit;
        private int temporaryPositionWarehouse;
        List<ComboBoxItem> objectsPackaging = new List<ComboBoxItem>();
        SoundPool soundPool;
        int soundPoolId;
        private string temporaryString;
        private string toast;

        public void GetBarcode(string barcode)
        {
            // implements the interface.
            if (tbSSCC.HasFocus)
            {
                Sound();
                tbSSCC.Text = barcode;
            }
            else if (tbLocation.HasFocus)
            {
                Sound();
                tbLocation.Text = barcode;
            }
        }

        private void Sound()
        {
            soundPool.Play(soundPoolId, 1, 1, 0, 0, 1);

        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.PackagingSetContextTablet);
            cbWarehouse = FindViewById<Spinner>(Resource.Id.cbWarehouse);
            tbLocation = FindViewById<EditText>(Resource.Id.tbLocation);
            tbSSCC = FindViewById<EditText>(Resource.Id.tbSSCC);
            btConfirm = FindViewById<Button>(Resource.Id.btConfirm);
            btExit = FindViewById<Button>(Resource.Id.btExit);
            btConfirm.Click += BtConfirm_Click;
            btExit.Click += BtExit_Click;
            cbWarehouse.ItemSelected += CbWarehouse_ItemSelected;
            soundPool = new SoundPool(10, Stream.Music, 0);
            soundPoolId = soundPool.Load(this, Resource.Drawable.beep, 1);
            Barcode2D barcode2D = new Barcode2D();
            barcode2D.open(this, this);


            var whs = CommonData.ListWarehouses();


            whs.Items.ForEach(wh =>
            {
                objectsPackaging.Add(new ComboBoxItem { ID = wh.GetString("Subject"), Text = wh.GetString("Name") });
            });
            var adapterWarehouse = new ArrayAdapter<ComboBoxItem>(this,
        Android.Resource.Layout.SimpleSpinnerItem, objectsPackaging);
            ///* 22.12.2020---------------------------------------------------------------
            ///* Documentation for the spinner objects add method with an adapter...
            ///*---------------------------------------------------
            ///
            adapterWarehouse.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            cbWarehouse.Adapter = adapterWarehouse;




        }

        private void BtExit_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainMenu));
        }

        private void BtConfirm_Click(object sender, EventArgs e)
        {


            ProcessData();

        }

        private void ProcessData()
        {
            temporaryString = objectsPackaging.ElementAt(temporaryPositionWarehouse).ID;

            if (!CommonData.IsValidLocation(temporaryString, tbLocation.Text.Trim()))
            {
                string toast = string.Format("Skladišće/lokacija ni veljavna.");
                Toast.MakeText(this, toast, ToastLength.Long).Show();
                return;
            }

            if (string.IsNullOrEmpty(tbSSCC.Text.Trim()))
            {
                string toast = string.Format("SSCC koda je obvezna.");
                Toast.MakeText(this, toast, ToastLength.Long).Show();
                return;
            }

            //  var head = new NameValueObject("PackagingHead");
            var head = new NameValueObject("PackagingHead");
            head.SetInt("HeadID", 0);
            head.SetString("Warehouse", objectsPackaging.ElementAt(temporaryPositionWarehouse).ID);
            head.SetString("ReceivingLocation", tbLocation.Text.Trim());
            head.SetString("SSCC", tbSSCC.Text.Trim());
            head.SetInt("Clerk", Services.UserID());

            string error;
            head = Services.SetObject("ph", head, out error);
            if (head != null)
            {
                InUseObjects.Set("PackagingHead", head);
                StartActivity(typeof(PackagingUnit));
            }
            else
            {
                string toast = string.Format("Napaka pri dostopu do web aplikacije.");
                Toast.MakeText(this, toast, ToastLength.Long).Show();
                return;
            }
        }

        private void CbWarehouse_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            if (e.Position != 0)
            {
                string toast = string.Format("Izbrali ste: {0}", spinner.GetItemAtPosition(e.Position));
                Toast.MakeText(this, toast, ToastLength.Long).Show();
                temporaryPositionWarehouse = e.Position;
            }
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // in smartphone
                case Keycode.F2:
                    if (btConfirm.Enabled == true)
                    {
                        BtConfirm_Click(this, null);
                    }
                    break;


                //return true;


                case Keycode.F9:
                    BtExit_Click(this, null);
                    break;


            }
            return base.OnKeyDown(keyCode, e);
        }


    }
}