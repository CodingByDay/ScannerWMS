﻿using Android.App;
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
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;

namespace Scanner
{
    [Activity(Label = "MorePallets")]
    public class MorePalletsClass : Activity, IBarcodeResult
    {
        //lvCardMore
        //btConfirm
        //btLogin
        private ListView lvCardMore;
        private Button btConfirm;
        private Button btLogin;
        private List<MorePallets> data = new List<MorePallets>();
        private string identMain;
        private NameValueObject moveHead = (NameValueObject)InUseObjects.Get("MoveHead");
        private EditText test;

        private NameValueObject moveItem = (NameValueObject)InUseObjects.Get("MoveItem");

        public string IdentName { get; private set; }

        public void GetBarcode(string barcode)
        {
            if (barcode != "Scan fail")
            {

                FilData(barcode);
            }
        }
       

       
        private void FilData(string barcode)
        {
            if(!String.IsNullOrEmpty(barcode))
            {
                string error;

                var dataObject = Services.GetObject("sscc", barcode, out error);
                if (dataObject != null)
                {
                         var ident = dataObject.GetString("Ident");
                         var name = dataObject.GetString("IdentName");
                         var serial = dataObject.GetString("SerialNo");
                         var location = dataObject.GetString("Location");
                         MorePallets pallets = new MorePallets();
                         pallets.Ident = ident;
                         pallets.Name = name;
                         pallets.Quantity = barcode;
               
                         pallets.SSCC = barcode;
#nullable enable
                    MorePallets? obj = ProcessQty(pallets, location);
#nullable disable
                    /* Adds an object to the list. */
                    if(obj is null)
                    {
                        Toast.MakeText(this, "Prišlo je do napake.", ToastLength.Long).Show();
                    } else
                    {
                        data.Add(obj);
                        // Added to the list

                    }
                }
                else
                {
                    return;
                }
            }
        }
        private MorePallets ProcessQty(MorePallets obj, string location)
        {
            var sscc = obj.SSCC;
            if (string.IsNullOrEmpty(sscc)) { return null; }

            var serialNo = obj.Serial;
            if (string.IsNullOrEmpty(serialNo)) { return null; }

            var ident = obj.Ident;
            if (string.IsNullOrEmpty(ident)) { return null; }

            var identObj = CommonData.LoadIdent(ident);
            var isEnabled = identObj.GetBool("HasSerialNumber");

            if (!CommonData.IsValidLocation(moveHead.GetString("Issuer"), location))
            {
                string SuccessMessage = string.Format("Izdajna lokacija" + location + "ni veljavna za skladisće" + moveHead.GetString("Issuer") + "'!");
                Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();
              

                return null;
            }

            var stockQty = GetStock(moveHead.GetString("Issuer"), location, sscc, serialNo, ident, isEnabled);
            if (!Double.IsNaN(stockQty))
            {
                obj.Quantity = stockQty.ToString(CommonData.GetQtyPicture());
                
            }
            else
            {
                Toast.MakeText(this, "Prišlo je do napake.", ToastLength.Long).Show();
            }
            return obj;

        }

        private double GetStock(string warehouse, string location, string sscc, string serialNum, string ident, bool serialEnabled)
        {
            var wh = CommonData.GetWarehouse(warehouse);
            if (!wh.GetBool("HasStock"))
                if (serialEnabled)
                {
                    return LoadStockFromPAStockSerialNo(warehouse, ident, serialNum);
                }
                else
                {
                    return LoadStockFromPAStock(warehouse, ident);
                }

            else
            {
                return LoadStockFromStockSerialNo(warehouse, location, sscc, serialNum, ident);
            }

        }


        private Double LoadStockFromStockSerialNo(string warehouse, string location, string sscc, string serialNum, string ident)
        {

            try
            {
                string error;
                var stock = Services.GetObject("str", warehouse + "|" + location + "|" + sscc + "|" + serialNum + "|" + ident, out error);
                if (stock == null)
                {
                    string SuccessMessage = string.Format("Napaka pri preverjenju zaloge." + error);
                    Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();

                    return Double.NaN;
                }
                else
                {
                    return stock.GetDouble("RealStock");
                }
            }
            finally
            {

            }
        }
        private Double LoadStockFromPAStock(string warehouse, string ident)
        {
            try
            {
                string error;
                var stock = Services.GetObject("pas", warehouse + "|" + ident, out error);
                if (stock == null)
                {
                    string SuccessMessage = string.Format("Napaka pri preverjenju zaloge." + error);
                    return Double.NaN;
                }
                else
                {
                    return stock.GetDouble("Qty");
                }
            }
            finally
            {
                //pass
            }
        }
        private Double LoadStockFromPAStockSerialNo(string warehouse, string ident, string serialNo)
        {

            try
            {

                string error;
                var stock = Services.GetObject("pass", warehouse + "|" + ident + "|" + serialNo, out error);
                if (stock == null)
                {
                    string SuccessMessage = string.Format("Napaka pri preverjanju zaloge" + error);
                    return Double.NaN;
                }
                else
                {
                    return stock.GetDouble("Qty");
                }
            }
            finally
            {
                // pass 
            }
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

                // Create your application here
                SetContentView(Resource.Layout.MorePalletsClass);
                lvCardMore = FindViewById<ListView>(Resource.Id.lvCardMore);
                btConfirm = FindViewById<Button>(Resource.Id.btConfirm);
                btLogin = FindViewById<Button>(Resource.Id.btLogin);
                MorePalletsAdapter adapter = new MorePalletsAdapter(this, data);
                lvCardMore.Adapter = adapter;
            test = FindViewById<EditText>(Resource.Id.test);

        }
    }
}