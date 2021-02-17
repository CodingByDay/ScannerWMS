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
    class UnfinishedProductionAdapter : BaseAdapter
    {

        public List<UnfinishedProductionList> sList;
        private Context sContext;
        public UnfinishedProductionAdapter(Context context, List<UnfinishedProductionList> list)
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
                    row = LayoutInflater.From(sContext).Inflate(Resource.Layout.UnfinishedProduction, null, false);
                }

                TextView WorkOrder = row.FindViewById<TextView>(Resource.Id.WorkOrder);
                WorkOrder.Text = sList[position].WorkOrder;


                TextView Orderer = row.FindViewById<TextView>(Resource.Id.Orderer);
                Orderer.Text = sList[position].Orderer;

                TextView Ident = row.FindViewById<TextView>(Resource.Id.Ident);
                Ident.Text = sList[position].Ident;


                TextView NumberOfPositions = row.FindViewById<TextView>(Resource.Id.NumberOfPositions);
                NumberOfPositions.Text = sList[position].NumberOfPositions;



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