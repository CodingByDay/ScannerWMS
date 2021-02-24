﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScannerQR.App
{

    class InterwarehousSerialOrSCCCEntryAdapter : BaseAdapter
    {
        public List<InterWarehouseSerialOrSSCCList> sList;
        private Context sContext;
        public InterwarehousSerialOrSCCCEntryAdapter(Context context, List<InterWarehouseSerialOrSSCCList> list)
        {
            sList = list;
            sContext = context;
        }



        public override int Count
        {
            get
            {
                return sList.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            try
            {
                if (row == null)
                {
                    row = LayoutInflater.From(sContext).Inflate(Resource.Layout.InterWarehouseSerialOrSSCCEntryView, null, false);
                }

                TextView Ident = row.FindViewById<TextView>(Resource.Id.Ident);
                Ident.Text = sList[position].Ident;


                TextView SerialNumber = row.FindViewById<TextView>(Resource.Id.SerialNumber);
                SerialNumber.Text = sList[position].SerialNumber;


                TextView Location = row.FindViewById<TextView>(Resource.Id.Location);
                Location.Text = sList[position].Location;

                TextView Qty = row.FindViewById<TextView>(Resource.Id.Qty);
                Qty.Text = sList[position].Qty;

                TextView Filled = row.FindViewById<TextView>(Resource.Id.Filled);
                Filled.Text = sList[position].Filled;




            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally { }

            return row;

        }


        public override void NotifyDataSetChanged()
        {


            NotifyDataSetChanged();
        }

    }
}