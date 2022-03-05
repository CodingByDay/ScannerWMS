using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.AppCenter.Analytics;
using Scanner;
using Scanner.App;
using TrendNET.WMS.Device.Services;

namespace Scanner
{
    [Activity(Label = "MainMenu", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainMenu : Activity
    {
        private List<Button> buttons = new List<Button>();
        public static string IDdevice;
        public static string target;
        public bool result;
        private Button button;
        private Button buttonInterWarehouse;
        private Button buttonUnfinished;
        private Button buttonIssued;
        private Button buttonPrint;
        private Button btnInventory;
        private Button btnCheckStock;
        private Button btnPackaging;
        private Button btnLogout;
        private Button PalletsMenu;
        private Button btRecalculate;
        protected override void OnCreate(Bundle savedInstanceState)
        {
           
            base.OnCreate(savedInstanceState);
            HelpfulMethods.releaseLock();
            // Create your application here
            SetContentView(Resource.Layout.MainMenu);
            var flag = Services.isTablet(App.settings.device);
            // Welcome String.

            if (MainActivity.isValid == true)
            {
                string toast = new string("Uspešna prijava.");             
                Toast.MakeText(this, toast, ToastLength.Long).Show();
                MainActivity.isValid = false;
                MainActivity.progressBar1.Visibility = ViewStates.Invisible;
            }
            // Testing the progress dialog
            // Testing the config reading ... It works... :)
            IDdevice = settings.ID;
            target = settings.device;
            result = settings.tablet;
            // Rapid takover is taken away from here because its used only in the tablet view.
            // First event...
            button = FindViewById<Button>(Resource.Id.goodsTakeOver);
            button.Click += Button_Click;
            buttons.Add(button);
            // InterWarehouse redirect...
            buttonInterWarehouse = FindViewById<Button>(Resource.Id.goodsInterWarehouse);
            buttonInterWarehouse.Click += ButtonInterWarehouse_Click;
            buttons.Add(buttonInterWarehouse);
            // Third view...
            buttonUnfinished = FindViewById<Button>(Resource.Id.goodsProduction);
            buttonUnfinished.Click += ButtonUnfinished_Click;
            buttons.Add(buttonUnfinished);
            // UnfinishedIssuedGoodsView layout ---> button ---------> goodsIssued
            buttonIssued = FindViewById<Button>(Resource.Id.goodsIssued);
            buttonIssued.Click += ButtonIssued_Click;
            buttons.Add(buttonIssued);
            // btnPrint-----------PrintingMenu();
            buttonPrint = FindViewById<Button>(Resource.Id.btnPrint);
            buttonPrint.Click += ButtonPrint_Click;
            buttons.Add(buttonPrint);
            // btnInventory-------InventoryMenu();
            btnInventory = FindViewById<Button>(Resource.Id.btnInventory);
            btnInventory.Click += BtnInventory_Click;
            buttons.Add(btnInventory);
            // btCheckStock-------CheckStock();
            btnCheckStock = FindViewById<Button>(Resource.Id.btCheckStock);
            btnCheckStock.Click += BtnCheckStock_Click;
            buttons.Add(btnCheckStock);
            // goodsPackaging-----PackagingEnteredPositionsView();
            btnPackaging = FindViewById<Button>(Resource.Id.goodsPackaging);
            btnPackaging.Click += BtnPackaging_Click;
            buttons.Add(btnPackaging);
            // Logout-------------Close();
            btnLogout = FindViewById<Button>(Resource.Id.logout);
            btnLogout.Click += BtnLogout_Click;
            PalletsMenu = FindViewById<Button>(Resource.Id.PalletsMenu);
            buttons.Add(PalletsMenu);
            // Permisions.
            buttonInterWarehouse.Enabled = Services.HasPermission("TNET_WMS_BLAG_TRN", "R");
            buttonIssued.Enabled = Services.HasPermission("TNET_WMS_BLAG_SND", "R");
            buttonUnfinished.Enabled = Services.HasPermission("TNET_WMS_BLAG_PROD", "R");
            button.Enabled = Services.HasPermission("TNET_WMS_BLAG_ACQ", "R");
            btnPackaging.Enabled = Services.HasPermission("TNET_WMS_BLAG_PKG", "R");
            buttonPrint.Enabled = Services.HasPermission("TNET_WMS_OTHR_PRINT", "R");
            btnInventory.Enabled = Services.HasPermission("TNET_WMS_OTHR_INV", "R");
            btRecalculate = FindViewById<Button>(Resource.Id.btRecalculate);
            btRecalculate.Click += BtRecalculate_Click;
            // Adding the new pallets permission.
            PalletsMenu.Enabled = Services.HasPermission("TNET_WMS_BLAG_PAL", "R");
            // Hide those for now.
            PalletsMenu.Click += PalletsMenu_Click;
            // HideDisabled(buttons);
            HideDisabled(buttons);
        }




       
        private void BtRecalculate_Click(object sender, EventArgs e)
        {
            var dups = HelpfulMethods.preventDupUse();

            if (dups)
            {
                StartActivity(typeof(RecalculateInventory));
      
            }
        }

        private void HideDisabled(List<Button> buttons)
        {
            foreach(Button btn in buttons)
            {
                if(btn.Enabled == false)
                {
                    btn.SetBackgroundColor(Android.Graphics.Color.DarkGray);
                    btn.SetTextColor(Android.Graphics.Color.White);
                } else
                {
                    continue;
                }
            }
        }

        private void PalletsMenu_Click(object sender, EventArgs e)
        {
            var dups = HelpfulMethods.preventDupUse();

            if (dups)
            {
                StartActivity(typeof(MenuPallets));
              
            }
        }

        private void RapidTakeover_Click(object sender, EventArgs e)
        {
            var dups = HelpfulMethods.preventDupUse();

            if (dups)
            {
                StartActivity(typeof(RapidTakeover));
                
            }
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // In smartphone
                case Keycode.F1:

                    if (button.Enabled == true)
                    {
                        Button_Click(this, null);

                    }
                    break;
                // Return true;

                case Keycode.F2:
                    if (buttonInterWarehouse.Enabled == true)
                    {
                        ButtonInterWarehouse_Click(this, null);
                    }

                    break;


                case Keycode.F3:
                    if (buttonUnfinished.Enabled == true)
                    {
                        ButtonUnfinished_Click(this, null);
                    }
                    break;

                case Keycode.F4:
                    if (buttonIssued.Enabled == true)
                    {
                        ButtonIssued_Click(this, null);
                    }
                    break;


                case Keycode.F5:
                    if (btnPackaging.Enabled == true)
                    {
                        BtnPackaging_Click(this, null);
                    }              
                        break;


                case Keycode.F6:
                    if (buttonPrint.Enabled == true)
                    {
                        ButtonPrint_Click(this, null);
                    }
                    break;



                case Keycode.F7:
                    if (btnInventory.Enabled == true)
                    {
                        BtnInventory_Click(this, null);
                    }
                    break;
                case Keycode.F8:
                    if (btnCheckStock.Enabled == true)
                    {
                        BtnCheckStock_Click(this, null);
                    }
                    break;
                    // return true;
            }
            return base.OnKeyDown(keyCode, e);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {


            Intent intent = new Intent(this, typeof(MainActivity));
            intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.ClearTask | ActivityFlags.NewTask);
            StartActivity(intent);
            Finish();
        }

        private void BtnPackaging_Click(object sender, EventArgs e)
        {
            var dups = HelpfulMethods.preventDupUse();

            if (dups)
            {
                StartActivity(typeof(PackagingEnteredPositionsView));
               
            }
        }

        private void BtnCheckStock_Click(object sender, EventArgs e)
        {
            var dups = HelpfulMethods.preventDupUse();

            if (dups)
            {
                StartActivity(typeof(CheckStock));
             
            }
        }

        private void BtnInventory_Click(object sender, EventArgs e)
        {
            var dups = HelpfulMethods.preventDupUse();

            if (dups)
            {
                StartActivity(typeof(InventoryMenu));
               
            }
        }

        private void ButtonPrint_Click(object sender, EventArgs e)
        {
            var dups = HelpfulMethods.preventDupUse();

            if (dups)
            {
                StartActivity(typeof(PrintingMenu));
             
            }
        }

        private void ButtonIssued_Click(object sender, EventArgs e)
        {
            var dups = HelpfulMethods.preventDupUse();

            if (dups)
            {
                StartActivity(typeof(UnfinishedIssuedGoodsView));

     
            }
        }

        private void ButtonUnfinished_Click(object sender, EventArgs e)
        {

            var dups = HelpfulMethods.preventDupUse();

            if (dups)
            {
                // StartActivity(typeof(UnfinishedProductionView));
                StartActivity(typeof(choiceProduction));
            }
        }
      
        private void ButtonInterWarehouse_Click(object sender, EventArgs e)
        {
            var dups = HelpfulMethods.preventDupUse();

            if (dups)
            {
                StartActivity(typeof(UnfinishedInterWarehouseView));
          
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var dups = HelpfulMethods.preventDupUse();

            if (dups)
            {
                StartActivity(typeof(UnfinishedTakeoversView));
                
            }
        }
    }
}