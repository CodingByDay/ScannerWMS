using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using Microsoft.AppCenter.Crashes;
using Scanner.App;
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;
using WebApp = TrendNET.WMS.Device.Services.WebApp;

namespace Scanner
{
    [Activity(Label = "InventoryOpen", ScreenOrientation = ScreenOrientation.Portrait)]
    public class InventoryOpen : Activity
    {
        private Spinner cbWarehouse;
        private EditText dtInventory;
        private Button btChoose;
        private EditText tbItems;
        private EditText tbConfirmedBy;
        private EditText tbConfirmationDate;
        private List<ComboBoxItem> warehousesObjectsAdapter = new List<ComboBoxItem>();
        private Button btOpen;
        private Button button2;
        private int temporaryPositionWarehouse;
        private NameValueObject moveHead = null;
        private string lastError = null;
        private DateTime dateX;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.InventoryOpen);
            cbWarehouse = FindViewById<Spinner>(Resource.Id.cbWarehouse);
            btChoose = FindViewById<Button>(Resource.Id.btChoose);
            tbItems = FindViewById<EditText>(Resource.Id.tbItems);
            tbConfirmedBy = FindViewById<EditText>(Resource.Id.tbConfirmedBy);
            tbConfirmationDate = FindViewById<EditText>(Resource.Id.tbConfirmationDate);
            dtInventory = FindViewById<EditText>(Resource.Id.dtInventory);
            btOpen = FindViewById<Button>(Resource.Id.btOpen);
            button2 = FindViewById<Button>(Resource.Id.button2);
            cbWarehouse.ItemSelected += CbWarehouse_ItemSelected;
            btChoose.Click += BtChoose_Click;
            btOpen.Click += BtOpen_Click;
            dtInventory.Text = DateTime.Today.ToShortDateString();

            var warehouses = CommonData.ListWarehouses();
            if (warehouses != null)
            {
                warehouses.Items.ForEach(wh =>
                {
                    warehousesObjectsAdapter.Add(new ComboBoxItem { ID = wh.GetString("Subject"), Text = wh.GetString("Name") });
                });
            }
            var adapterWarehouse = new ArrayAdapter<ComboBoxItem>(this,
             Android.Resource.Layout.SimpleSpinnerItem, warehousesObjectsAdapter);


            ///* 22.12.2020---------------------------------------------------------------
            ///* Documentation for the spinner objects add method with an adapter...
            ///*---------------------------------------------------
            ///
            adapterWarehouse.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            cbWarehouse.Adapter = adapterWarehouse;
        }
        private void UpdateFields()
        {
            var warehouse = warehousesObjectsAdapter.ElementAt(temporaryPositionWarehouse);
            if (warehouse == null)
            {
                ClearFields();
                return;
            }
            else
            {
                var date = dateX;

       
                try
                {

                    string result;
                    if (WebApp.Get("mode=getConfirmedInventoryHead&wh=" + warehouse + "&date=" + date.ToString("s"), out result))
                    {
                        var moveHeadID = Convert.ToInt32(result);
                        if (moveHeadID < 0)
                        {
                            ClearFieldsError("Inventurni dokument za skladišče in datum ne obstaja!");
                            return;
                        }
                        else
                        {
                            moveHead = Services.GetObject("mh", moveHeadID.ToString(), out result);
                            if (moveHead == null)
                            {
                                ClearFieldsError("Inventurni dokument za skladišče in datum ne obstaja!");
                                return;
                            }
                            else
                            {
                                tbItems.Text = moveHead.GetInt("ItemCount").ToString();
                                tbConfirmedBy.Text = "???";
                                tbConfirmationDate.Text = "???";
                                btOpen.Enabled = true;
                                lastError = null;
                            }
                        }
                    }
                    else
                    {
                        ClearFieldsError("Napaka pri preverjanju inventure: " + result);
                        return;
                    }
                }
                finally
                {
                 
                }
            }
        }

        private void ClearFields()
        {
            tbItems.Text = "";
            tbConfirmedBy.Text = "";
            tbConfirmationDate.Text = "";
            btOpen.Enabled = false;
        }
        private void ClearFieldsError(string err)
        {
            ClearFields();
            lastError = err;
            return;
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                
                case Keycode.F3:
                    if (btOpen.Enabled == true)
                    {
                        BtOpen_Click(this, null);
                    }
                    break;

                case Keycode.F8:
                    if (button2.Enabled == true)
                    {
                        StartActivity(typeof(MainMenu));
                        HelpfulMethods.clearTheStack(this);
                    }
                    break;



            }
            return base.OnKeyDown(keyCode, e);
        }
        private void BtLogout_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainMenu));
            HelpfulMethods.clearTheStack(this);
        }

        private void BtOpen_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lastError))
            {
                Toast.MakeText(this, lastError, ToastLength.Long).Show();
         
                return;
            }

            var warehouse = warehousesObjectsAdapter.ElementAt(temporaryPositionWarehouse);
            if (warehouse == null)
            {
                Toast.MakeText(this, "Skladišče ni izbrano!", ToastLength.Long).Show();

                return;
            }

  
            try
            {
            

                var date = dateX;
                string error;
                if (!WebApp.Get("mode=canInsertInventory&wh=" + warehouse.ID.ToString(), out error))
                {
                    Toast.MakeText(this, "Napaka pri preverjanju zapisa inventure: " + error, ToastLength.Long).Show();
         
                    return;
                }
                if (error == "OK!")
                {
                    if (!WebApp.Get("mode=reopenInventory&id=" + moveHead.GetInt("HeadID").ToString(), out error))
                    {
                        Toast.MakeText(this, "Napaka pri odpiranju inventure: " + error, ToastLength.Long).Show();
                     
                        return;
                    }
                    else
                    {
                        Toast.MakeText(this, "Inventura odprta!", ToastLength.Long).Show();
              
                        StartActivity(typeof(InventoryConfirm));
                        HelpfulMethods.clearTheStack(this);
                    }
                }
                else
                {
                    Toast.MakeText(this, "Napaka pri preverjanju zapisa inventure: " + error, ToastLength.Long).Show();
                    return;
                }
            }
            finally
            {
              
            }
        }

        private void CbWarehouse_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string toast = string.Format("Izbrali ste: {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
            temporaryPositionWarehouse = e.Position;
         
        }



        private void BtChoose_Click(object sender, EventArgs e)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                dtInventory.Text = time.ToShortDateString();
                dateX = time;
                UpdateFields();
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }
    }
}