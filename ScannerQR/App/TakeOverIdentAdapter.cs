using Android.App;
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
    class TakeOverIdentAdapter : BaseAdapter
    {
        public List<TakeOverIdentList> sList;
        private Context sContext;
        public TakeOverIdentAdapter(Context context, List<TakeOverIdentList> list)
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
                    row = LayoutInflater.From(sContext).Inflate(Resource.Layout.TakeOverIdentListView, null, false);
                }

                TextView Ident = row.FindViewById<TextView>(Resource.Id.Ident);
                Ident.Text = sList[position].Ident;


                TextView Location = row.FindViewById<TextView>(Resource.Id.Location);
                Location.Text = sList[position].Location;

                TextView Open = row.FindViewById<TextView>(Resource.Id.Open);
                Open.Text = sList[position].Open;

                TextView Ordered = row.FindViewById<TextView>(Resource.Id.Ordered);
                Ordered.Text = sList[position].Ordered;

                TextView Received = row.FindViewById<TextView>(Resource.Id.Received);
                Received.Text = sList[position].Received;



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