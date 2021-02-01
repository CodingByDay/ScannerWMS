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
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;
using WebApp = TrendNET.WMS.Device.Services.WebApp;

namespace ScannerQR
{
    [Activity(Label = "InventoryOpenDocumentTablet")]
    public class InventoryOpenDocumentTablet : Activity
    {
        private Spinner cbWarehouse;
        private EditText dtDate;
        private Button select;
        private Button confirm;
        private Button logout;
        private List<ComboBoxItem> warehousesAdapter = new List<ComboBoxItem>();
        private int temporaryPositionWarehouse;
        private DateTime datex;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.InventoryOpenDocument);
            cbWarehouse = FindViewById<Spinner>(Resource.Id.cbWarehouse);
            dtDate = FindViewById<EditText>(Resource.Id.dtDate);
            select = FindViewById<Button>(Resource.Id.select);
            confirm = FindViewById<Button>(Resource.Id.confirm);
            logout = FindViewById<Button>(Resource.Id.logout);
            select.Click += Select_Click;
            confirm.Click += Confirm_Click;
            logout.Click += Logout_Click;
            cbWarehouse.ItemSelected += CbWarehouse_ItemSelected;
            dtDate.Text = DateTime.Now.ToShortDateString();
            var warehouses = CommonData.ListWarehouses();
            warehouses.Items.ForEach(wh =>
            {
                warehousesAdapter.Add(new ComboBoxItem { ID = wh.GetString("Subject"), Text = wh.GetString("Name") });
            });

            var adapter = new ArrayAdapter<ComboBoxItem>(this,
             Android.Resource.Layout.SimpleSpinnerItem, warehousesAdapter);
            ///* 
            ///* Adapter for a spiner control ie. dataset.
            ///*-----------------------------------------
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            cbWarehouse.Adapter = adapter;
        }
        private void Logout_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainMenu));
        }
        private void Confirm_Click(object sender, EventArgs e)
        {
            var warehouse = warehousesAdapter.ElementAt(temporaryPositionWarehouse);
            if (warehouse == null)
            {
                Toast.MakeText(this, "Skladišče ni izbrano!", ToastLength.Long).Show();
                return;
            }
            try
            {
                var date = datex;

                var moveHead = new NameValueObject("MoveHead");
                moveHead.SetString("Wharehouse", warehouse.ID.ToString());
                moveHead.SetDateTime("Date", date);
                moveHead.SetString("Type", "N");
                moveHead.SetString("LinkKey", "");
                moveHead.SetInt("LinkNo", 0);
                moveHead.SetInt("Clerk", Services.UserID());

                string error;
                if (!WebApp.Get("mode=canInsertInventory&wh=" + warehouse.ID.ToString(), out error))
                {
                    Toast.MakeText(this, "Napaka pri preverjanju zapisa inventure: " + error, ToastLength.Long).Show();

                    return;
                }
                if (error == "OK!")
                {
                    var savedMoveHead = Services.SetObject("mh", moveHead, out error);
                    if (savedMoveHead == null)
                    {
                        Toast.MakeText(this, "Napaka pri zapisu inventure: " + error, ToastLength.Long).Show();

                        return;
                    }
                    Toast.MakeText(this, "Dokument inventure shranjen!", ToastLength.Long).Show();


                    StartActivity(typeof(InventoryMenu));

                }
                else
                {
                    Toast.MakeText(this, "Napaka pri preverjanju zapisa inventure: " + error, ToastLength.Long).Show();

                    return;
                }
            }
            finally
            {
                /*  random comment number x */
            }
        }
        private void Select_Click(object sender, EventArgs e)
        {

            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                dtDate.Text = time.ToShortDateString();
                datex = time;
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        private void CbWarehouse_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            temporaryPositionWarehouse = e.Position;
        }
    }
}