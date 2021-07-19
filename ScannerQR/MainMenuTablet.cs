using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Scanner.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrendNET.WMS.Device.Services;

namespace Scanner
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
        private Button PalletsMenu;
        private List<Button> buttons = new List<Button>();
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


            Button button = FindViewById<Button>(Resource.Id.goodsTakeOver);
            button.Click += Button_Click;
            buttons.Add(button);
            // InterWarehouse redirect...
            Button buttonInterWarehouse = FindViewById<Button>(Resource.Id.goodsInterWarehouse);
            buttonInterWarehouse.Click += ButtonInterWarehouse_Click;
            buttons.Add(buttonInterWarehouse);

            // Third view...
            Button buttonUnfinished = FindViewById<Button>(Resource.Id.goodsProduction);
            buttonUnfinished.Click += ButtonUnfinished_Click;
            buttons.Add(buttonUnfinished);
            // UnfinishedIssuedGoodsView layout ---> button ---------> goodsIssued
            Button buttonIssued = FindViewById<Button>(Resource.Id.goodsIssued);
            buttonIssued.Click += ButtonIssued_Click;
            buttons.Add(buttonIssued);
            // btnPrint-----------PrintingMenu();
            Button buttonPrint = FindViewById<Button>(Resource.Id.btnPrint);
            buttonPrint.Click += ButtonPrint_Click;
            buttons.Add(buttonPrint);
            // btnInventory-------InventoryMenu();
            Button btnInventory = FindViewById<Button>(Resource.Id.btnInventory);
            btnInventory.Click += BtnInventory_Click;
            buttons.Add(btnInventory);
            // btCheckStock-------CheckStock();
            Button btnCheckStock = FindViewById<Button>(Resource.Id.btCheckStock);
            btnCheckStock.Click += BtnCheckStock_Click;
            buttons.Add(btnCheckStock);
            // goodsPackaging-----PackagingEnteredPositionsView();
            Button btnPackaging = FindViewById<Button>(Resource.Id.goodsPackaging);
            btnPackaging.Click += BtnPackaging_Click;
            buttons.Add(btnPackaging);
            // Logout-------------Close();
            Button btnLogout = FindViewById<Button>(Resource.Id.logout);
            btnLogout.Click += BtnLogout_Click;
            Button PalletsMenu = FindViewById<Button>(Resource.Id.PalletsMenu);
            buttons.Add(PalletsMenu);
            Button rapidTakeover = FindViewById<Button>(Resource.Id.rapidTakeover);
            rapidTakeover.Click += RapidTakeover_Click1;


            PalletsMenu = FindViewById<Button>(Resource.Id.PalletsMenu);
            PalletsMenu.Click += PalletsMenu_Click;
            buttonInterWarehouse.Enabled = Services.HasPermission("TNET_WMS_BLAG_TRN", "R");
            buttonIssued.Enabled = Services.HasPermission("TNET_WMS_BLAG_SND", "R");
            buttonUnfinished.Enabled = Services.HasPermission("TNET_WMS_BLAG_PROD", "R");
            button.Enabled = Services.HasPermission("TNET_WMS_BLAG_ACQ", "R");
            btnPackaging.Enabled = Services.HasPermission("TNET_WMS_BLAG_PKG", "R");

            buttonPrint.Enabled = Services.HasPermission("TNET_WMS_OTHR_PRINT", "R");
            btnInventory.Enabled = Services.HasPermission("TNET_WMS_OTHR_INV", "R");
            PalletsMenu.Enabled = Services.HasPermission("TNET_WMS_BLAG_PAL", "R");

            HideDisabled(buttons);
        }

        private void RapidTakeover_Click1(object sender, EventArgs e)
        {
            StartActivity(typeof(RapidTakeover));
        }

        private void HideDisabled(List<Button> buttons)
        {
            foreach (Button btn in buttons)
            {
                if (btn.Enabled == false)
                {
                    btn.SetBackgroundColor(Android.Graphics.Color.DarkGray);
                    btn.SetTextColor(Android.Graphics.Color.White);
                }
                else
                {
                    continue;
                }
            }
        }
        private void PalletsMenu_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MenuPalletsTablet));
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

            Intent intent = new Intent(this, typeof(MainActivity));
            intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.ClearTask | ActivityFlags.NewTask);
            StartActivity(intent);
            Finish();
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