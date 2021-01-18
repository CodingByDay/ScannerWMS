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
    [Activity(Label = "InventoryOpenDocument")]
    public class InventoryOpenDocument : Activity
    {
        private Spinner cbWarehouse;
        private EditText dtDate;
        private Button select;
        private Button btConfirm;
       
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
            btConfirm = FindViewById<Button>(Resource.Id.button2);
         
            select.Click += Select_Click;
            btConfirm.Click += BtConfirm_Click;
         
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
            ///* Adapter for a spinenr control quite different than in Win CE ComboBox/
            ///*---------------------------------------------------
            ///
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            cbWarehouse.Adapter = adapter;


        }

        private void Button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();

        }

        private void BtConfirm_Click(object sender, EventArgs e)
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