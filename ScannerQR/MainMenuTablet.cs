﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ScannerQR.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrendNET.WMS.Device.Services;

namespace ScannerQR
{
    [Activity(Label = "MainMenuTablet", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class MainMenuTablet : Activity
    {

        public static string IDdevice;
        public static string target;
        public bool result;
        private ListView rapidListview;
        private Button rapidTakeover;
        private List<rapidTakeoverList> data = new List<rapidTakeoverList>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.MainMenuTablet);
            var flag = Services.isTablet(App.settings.device);
            // Welcome String.
            if (MainActivity.isValid == true)
            {
                string toast = new string("Uspešna prijava.");

                Toast.MakeText(this, toast, ToastLength.Long).Show();
                MainActivity.isValid = false;
                MainActivity.progressBar1.Visibility = ViewStates.Invisible;





            }
            // Testing the config reading ... It works... :)
            IDdevice = settings.ID;
            target = settings.device;
            result = settings.tablet;


            rapidTakeover = FindViewById<Button>(Resource.Id.rapidTakeover);
            rapidListview = FindViewById<ListView>(Resource.Id.rapidListview);
            // First event...
            Button button = FindViewById<Button>(Resource.Id.goodsTakeOver);
            button.Click += Button_Click;
            // InterWarehouse redirect...
            Button buttonInterWarehouse = FindViewById<Button>(Resource.Id.goodsInterWarehouse);
            buttonInterWarehouse.Click += ButtonInterWarehouse_Click;
            // Third view...
            Button buttonUnfinished = FindViewById<Button>(Resource.Id.goodsProduction);
            buttonUnfinished.Click += ButtonUnfinished_Click;
            // UnfinishedIssuedGoodsView layout ---> button ---------> goodsIssued
            Button buttonIssued = FindViewById<Button>(Resource.Id.goodsIssued);
            buttonIssued.Click += ButtonIssued_Click;
            // btnPrint-----------PrintingMenu();
            Button buttonPrint = FindViewById<Button>(Resource.Id.btnPrint);
            buttonPrint.Click += ButtonPrint_Click;
            // btnInventory-------InventoryMenu();
            Button btnInventory = FindViewById<Button>(Resource.Id.btnInventory);
            btnInventory.Click += BtnInventory_Click;
            // btCheckStock-------CheckStock();
            Button btnCheckStock = FindViewById<Button>(Resource.Id.btCheckStock);
            btnCheckStock.Click += BtnCheckStock_Click;
            // goodsPackaging-----PackagingEnteredPositionsView();
            Button btnPackaging = FindViewById<Button>(Resource.Id.goodsPackaging);
            btnPackaging.Click += BtnPackaging_Click;
            // Logout-------------Close();
            Button btnLogout = FindViewById<Button>(Resource.Id.logout);
            btnLogout.Click += BtnLogout_Click;
            rapidTakeover.Click += RapidTakeover_Click;

            // Permisions.
            // buttonInterWarehouse.Enabled = Services.HasPermission("TNET_WMS_BLAG_TRN", "R");
            // buttonIssued.Enabled = Services.HasPermission("TNET_WMS_BLAG_SND", "R");
            // buttonUnfinished.Enabled = Services.HasPermission("TNET_WMS_BLAG_PROD", "R");
            // button.Enabled = Services.HasPermission("TNET_WMS_BLAG_ACQ", "R");
            // btnPackaging.Enabled = Services.HasPermission("TNET_WMS_BLAG_PKG", "R");

            // buttonPrint.Enabled = Services.HasPermission("TNET_WMS_OTHR_PRINT", "R");
            // btnInventory.Enabled = Services.HasPermission("TNET_WMS_OTHR_INV", "R");

        }
        private void updateList()
        {
           
        }
        private void RapidTakeover_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(RapidTakeover));
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // In smartphone
                case Keycode.F1:

                    Button_Click(this, null);
                    break;
                // Return true;

                case Keycode.F2:

                    ButtonInterWarehouse_Click(this, null);

                    break;


                case Keycode.F3:
                    ButtonUnfinished_Click(this, null);
                    break;

                case Keycode.F4:
                    ButtonIssued_Click(this, null);
                    break;


                case Keycode.F5:
                    ButtonPrint_Click(this, null);
                    break;


                case Keycode.F6:
                    BtnInventory_Click(this, null);
                    break;



                case Keycode.F7:
                    BtnCheckStock_Click(this, null);
                    break;
                case Keycode.F8:
                    BtnCheckStock_Click(this, null);
                    break;
                    // return true;
            }
            return base.OnKeyDown(keyCode, e);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {

            StartActivity(typeof(MainActivity));
            this.Finish();
        }

        private void BtnPackaging_Click(object sender, EventArgs e)
        {
   
                StartActivity(typeof(PackagingEnteredPositionsViewTablet));
            
         
        }

        private void BtnCheckStock_Click(object sender, EventArgs e)
        {
       
                StartActivity(typeof(CheckStockTablet));
            
          
        }

        private void BtnInventory_Click(object sender, EventArgs e)
        {

            StartActivity(typeof(InventoryMenu));
        }

        private void ButtonPrint_Click(object sender, EventArgs e)
        {

            StartActivity(typeof(PrintingMenu));

        }

        private void ButtonIssued_Click(object sender, EventArgs e)
        {
         
                StartActivity(typeof(UnfinishedIssuedGoodsViewTablet));
           
        
        }

        private void ButtonUnfinished_Click(object sender, EventArgs e)
        {
          
                StartActivity(typeof(UnfinishedProductionViewTablet));
       
        }

        private void ButtonInterWarehouse_Click(object sender, EventArgs e)
        {
       
                StartActivity(typeof(UnfinishedInterWarehouseViewTablet));
            
          
        }

        private void Button_Click(object sender, EventArgs e)
        {
          
                StartActivity(typeof(UnfinishedTakeoversViewTablet));
        
        }
    }
}
