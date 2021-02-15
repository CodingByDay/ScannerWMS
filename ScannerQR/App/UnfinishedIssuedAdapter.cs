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
    class UnfinishedIssuedAdapter : BaseAdapter
    {
        public List<IssuedUnfinishedList> sList;
        private Context sContext;
        public UnfinishedIssuedAdapter(Context context, List<IssuedUnfinishedList> list)
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
                    row = LayoutInflater.From(sContext).Inflate(Resource.Layout.UnfinishedIssued, null, false);
                }
                TextView Document = row.FindViewById<TextView>(Resource.Id.Document);
                Document.Text = sList[position].Document;


                TextView Issuer = row.FindViewById<TextView>(Resource.Id.Issuer);
                Issuer.Text = sList[position].Issuer;

                TextView Date = row.FindViewById<TextView>(Resource.Id.Date);
                Date.Text = sList[position].Date;



            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally { }

            return row;

        }

        public void NotifyDataSetChanged()
        {


            NotifyDataSetChanged();
        }





    }
}