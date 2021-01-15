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
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.Services;

namespace ScannerQR
{
    [Activity(Label = "InterWarehouseBusinessEventSetup")]
    public class InterWarehouseBusinessEventSetup : Activity
    {
        private Spinner cbDocType;
        public NameValueObjectList docTypes = null;     
        private Spinner cbIssueWH;
        private Spinner cbReceiveWH;
        List<ComboBoxItem> objectDocType = new List<ComboBoxItem>();
        List<ComboBoxItem> objectIssueWH = new List<ComboBoxItem>();
        List<ComboBoxItem> objectReceiveWH = new List<ComboBoxItem>();
        private int temporaryPositionDoc;
        private int temporaryPositionIssue;
        private int temporaryPositionReceive;    
        public static bool success = false;
        public static string objectTest;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
    
            SetContentView(Resource.Layout.InterWarehouseBusinessEventSetup);
            // Views
            cbDocType = FindViewById<Spinner>(Resource.Id.cbDocType);
            cbIssueWH = FindViewById<Spinner>(Resource.Id.cbIssueWH);
            cbReceiveWH = FindViewById<Spinner>(Resource.Id.cbRecceiveWH);
            // action listener for the button
            docTypes = CommonData.ListDocTypes("E|");
            docTypes.Items.ForEach(dt =>
            { //

            objectDocType.Add( new ComboBoxItem { ID = dt.GetString("Code"), Text = dt.GetString("Code") + " " + dt.GetString("Name") });
            
        });
            /*
             Aditional comment area. */
            var adapter = new ArrayAdapter<ComboBoxItem>(this,
             Android.Resource.Layout.SimpleSpinnerItem, objectDocType);
            ///* 22.12.2020---------------------------------------------------------------
            ///* Documentation for the spinner objects add method with an adapter...
            ///*---------------------------------------------------
            ///
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            cbDocType.Adapter = adapter;
            // Next thing... var warehouses = CommonData.ListWarehouses();
            //cbIssueWH
            var warehouses = CommonData.ListWarehouses();
            if (warehouses != null)
            {
                warehouses.Items.ForEach(dt =>
                {
                    objectIssueWH.Add(new ComboBoxItem { ID = dt.GetString("Subject"), Text = dt.GetString("Name")});
              
                    objectReceiveWH.Add( new ComboBoxItem { ID = dt.GetString("Subject"), Text = dt.GetString("Name")});
                  
                });
            }
            var adapterIssue = new ArrayAdapter<ComboBoxItem>(this,
            Android.Resource.Layout.SimpleSpinnerItem, objectIssueWH);
            var adapterReceive = new ArrayAdapter<ComboBoxItem>(this,
            Android.Resource.Layout.SimpleSpinnerItem, objectReceiveWH);
            adapterIssue.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            adapterReceive.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            cbIssueWH.Adapter = adapterIssue;
            cbReceiveWH.Adapter = adapterReceive;
            // next thing are the event listeners
            //for the logout
            Button logout = FindViewById<Button>(Resource.Id.logout);
            logout.Click += Logout_Click;
            // event listeners
            cbDocType.ItemSelected += CbDocType_ItemSelected;
            cbIssueWH.ItemSelected += CbIssueWH_ItemSelected;
            cbReceiveWH.ItemSelected += CbReceiveWH_ItemSelected;
            // confirm button

            Button confirm = FindViewById<Button>(Resource.Id.btnConfirm);
            confirm.Click += Confirm_Click;
        }
        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // in smartphone
                case Keycode.F3:
                    Confirm_Click(this, null);
                    break;
                //return true;

                case Keycode.F9:
                    Logout_Click(this, null);
                    break;
            }
            return base.OnKeyDown(keyCode, e);
        }
        private void Confirm_Click(object sender, EventArgs e)
        {
            var dt = objectDocType.ElementAt(temporaryPositionDoc);
            var iwh = objectIssueWH.ElementAt(temporaryPositionIssue);
            var rwh = objectIssueWH.ElementAt(temporaryPositionIssue);
          

           NameValueObject moveHead = new NameValueObject();
            // moveHead = (NameValueObject)InUseObjects.Get("MoveHead");

                moveHead.SetString("DocumentType", dt.ID);
                moveHead.SetString("Type", "E");
                moveHead.SetString("Issuer", iwh.ID);
                moveHead.SetString("Receiver", rwh.ID);
                moveHead.SetString("LinkKey", "");
                moveHead.SetInt("LinkNo", 0);
                moveHead.SetInt("Clerk", Services.UserID());
           
            // next
            string error;
     
            try
            {
                
                var savedMoveHead = Services.SetObject("mh", moveHead, out error);
                if (savedMoveHead == null)
                {
                    string errorWebApp = string.Format("Napaka pri dostopu do web aplikacije:" + error );
                    Toast.MakeText(this, errorWebApp, ToastLength.Long).Show();
                    // show a message
                    // terminate
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }
                else
                {
                    if (!Services.TryLock("MoveHead" + savedMoveHead.GetInt("HeadID").ToString(), out error))
                    {
                        string errorWebApp = string.Format("Kritična napaka pri zaklepanju nove medskladiščnice: " + error);
                        Toast.MakeText(this, errorWebApp, ToastLength.Long).Show();
                        // show a message
                        // terminate
                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                    }

                    moveHead.SetInt("HeadID", savedMoveHead.GetInt("HeadID"));
                    moveHead.SetBool("Saved", true);
                    InUseObjects.Set("MoveHead", moveHead);
                }

                StartActivity(typeof(InterWarehouseSerialOrSSCCEntry));
                
            } finally
            {
                success = true;
            }
     
        }
        




private void CbReceiveWH_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            if (e.Position != 0)
            {
                string toast = string.Format("Izbrali ste: {0}", spinner.GetItemAtPosition(e.Position));
                Toast.MakeText(this, toast, ToastLength.Long).Show();
                temporaryPositionReceive = e.Position;

            }
        }

        private void CbIssueWH_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            if (e.Position != 0)
            {
                string toast = string.Format("Izbrali ste: {0}", spinner.GetItemAtPosition(e.Position));
                Toast.MakeText(this, toast, ToastLength.Long).Show();
                temporaryPositionIssue = e.Position;
            }
        }

        private void CbDocType_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            if (e.Position != 0)
            {
                string toast = string.Format("Izbrali ste: {0}", spinner.GetItemAtPosition(e.Position));
                Toast.MakeText(this, toast, ToastLength.Long).Show();     
               temporaryPositionDoc = e.Position;
               


            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
    
}