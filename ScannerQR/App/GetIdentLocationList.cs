﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrendNET.WMS.Device.Services;

namespace Scanner.App
{
   public static class GetIdentLocationList
    {


        /// <summary>
        ///   This is a helper method used in tablet classes to get the list of locations for a specific ident in the specified warehouse.
        /// </summary>
        /// <param name="warehouse"></param>
        /// <param name="ident"></param>
        /// <returns></returns>

        private static ArrayList fillItemsOfList(string warehouse, string ident)
        {
            ArrayList result = new ArrayList();
            string error;
            var stock = Services.GetObjectList("str", out error, warehouse + "||" + ident);
            //return string.Join("\r\n", stock.Items.Select(x => "L:" + x.GetString("Location") + " = " + x.GetDouble("RealStock").ToString(CommonData.GetQtyPicture())).ToArray());
            stock.Items.ForEach(x =>
            {
                result.Add(new CheckStockAddonList
                {
                    Ident = x.GetString("Ident"),
                    Location = x.GetString("Location"),
                    Quantity = x.GetDouble("RealStock").ToString(CommonData.GetQtyPicture())
                });
            });

            return result;

        }

    }
}