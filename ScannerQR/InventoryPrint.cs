﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ScannerQR.Printing;
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;

namespace ScannerQR
{
    [Activity(Label = "InventoryPrint")]
    public class InventoryPrint : Activity, IBarcodeResult
    {


        private Spinner cbWarehouse;
        private EditText tbLocation;

        private Button btPrint;
        private Button button2;
        private List<ComboBoxItem> objectsAdapter = new List<ComboBoxItem>();
        private int temporaryPositionWarehouse;

        public void GetBarcode(string barcode)
        {
            if(tbLocation.HasFocus)
            {
                tbLocation.Text = barcode;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.InventoryPrint);
            cbWarehouse = FindViewById<Spinner>(Resource.Id.cbWarehouse);
            tbLocation = FindViewById<EditText>(Resource.Id.tbLocation);

            btPrint = FindViewById<Button>(Resource.Id.btPrint);
            button2 = FindViewById<Button>(Resource.Id.button2);
            cbWarehouse.ItemSelected += CbWarehouse_ItemSelected;
            btPrint.Click += BtPrint_Click;
            button2.Click += Button2_Click;
            var warehouses = CommonData.ListWarehouses();
            warehouses.Items.ForEach(wh =>
            {
                objectsAdapter.Add(new ComboBoxItem { ID = wh.GetString("Subject"), Text = wh.GetString("Name") });
            });



            var adapterWarehouse = new ArrayAdapter<ComboBoxItem>(this,
        Android.Resource.Layout.SimpleSpinnerItem, objectsAdapter);
            ///* 22.12.2020---------------------------------------------------------------
            ///* Documentation for the spinner objects add method with an adapter...
            ///*---------------------------------------------------
            ///
            adapterWarehouse.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            cbWarehouse.Adapter = adapterWarehouse;

        }
        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // Setting F2 to method ProccesStock()
                case Keycode.F2:
                    if (btPrint.Enabled == true)
                    {
                        BtPrint_Click(this, null);
                    }
                    break;

                case Keycode.F8:
                    if (button2.Enabled == true)
                    {
                        Button2_Click(this, null);
                    }
                    break;

            }
            return base.OnKeyDown(keyCode, e);
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }

        private void BtPrint_Click(object sender, EventArgs e)
        {
            var wh = objectsAdapter.ElementAt(temporaryPositionWarehouse);
            if (wh == null)
            {
                Toast.MakeText(this, "Skladišče ni izbrano!", ToastLength.Long).Show();
     
                return;
            }

            if (!CommonData.IsValidLocation(wh.ID, tbLocation.Text.Trim()))
            {
                Toast.MakeText(this, "Lokacija '" + tbLocation.Text.Trim() + "' ni veljavna za skladišče '" + wh.ID + "'!", ToastLength.Long).Show();
 
                return;
            }


            try
            {
              
                var nvo = new NameValueObject("PrintInventory");
                PrintingCommon.SetNVOCommonData(ref nvo);
                nvo.SetString("Warehouse", wh.ID);
                nvo.SetString("Location", tbLocation.Text.Trim());
                PrintingCommon.SendToServer(nvo);
           
            }
            finally
            {
                Toast.MakeText(this, "Poslato...", ToastLength.Long).Show();
            }
    
        }

        private void CbWarehouse_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            Spinner spinner = (Spinner)sender;

            string toast = string.Format("Izbrali ste: {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
            temporaryPositionWarehouse = e.Position;
        }
    }
}