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

    class IssuedEnterAdapter : BaseAdapter
    {
        public List<IssuedEnteredPositionViewList> sList;
        private Context sContext;
        public IssuedEnterAdapter(Context context, List<IssuedEnteredPositionViewList> list)
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
                    row = LayoutInflater.From(sContext).Inflate(Resource.Layout.IssuedEnteredPositionViewList, null, false);
                }

                TextView Ident = row.FindViewById<TextView>(Resource.Id.Ident);
                Ident.Text = sList[position].Ident;


                TextView SerialNumber = row.FindViewById<TextView>(Resource.Id.SerialNumber);
                SerialNumber.Text = sList[position].SerialNumber;


                TextView Quantity = row.FindViewById<TextView>(Resource.Id.Quantity);
                Quantity.Text = sList[position].Quantity;

                TextView Position = row.FindViewById<TextView>(Resource.Id.Position);
                Position.Text = sList[position].Position;

                TextView SSCC = row.FindViewById<TextView>(Resource.Id.SSCC);
                SSCC.Text = sList[position].SSCC;




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