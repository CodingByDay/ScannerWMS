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

namespace ScannerQR.App
{
  public class ListViewItem
    {
        private ListViewItem listViewItem;

        public ListViewItem(ListViewItem listViewItem)
        {
            this.listViewItem = listViewItem;
        }


        public ListViewItem(string stKartona, string quantity)
        {
            this.stKartona = stKartona;
            this.quantity = quantity;
        }

        public string stKartona { get; set; }
        public string quantity { get; set; }





    }
}