﻿using System;
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
using TrendNET.WMS.Device.Services;

namespace Scanner.Printing
{
    class PrintingCommon
    {
        public static void SetNVOCommonData(ref NameValueObject nvo)
        {
            nvo.SetInt("UserID", Services.UserID());
            nvo.SetString("DeviceID", "0001");
        }

        public static void SendToServer(NameValueObject nvo)
        {
            string error;
            var data = CompactSerializer.Serialize<NameValueObject>(nvo);
            if (WebApp.Post("mode=print", data, out error))
            {
                if (error == "OK!")
                {
                   string toast = string.Format("Podatki poslati na tiskalnik.");
              


                }
                else
                {
                    string toast = string.Format("Napaka pri tiskanju." + error);
                }
            }
            else
            {
                string toast = string.Format("Napaka pri dostopu do web aplikacije." + error);
            }
        }
    }
}