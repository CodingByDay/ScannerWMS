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
using Plugin.Settings;
using Plugin.Settings.Abstractions;
namespace ScannerQR.App
{
    class settings
    {


        private static ISettings AppSettings =>
            CrossSettings.Current;
       



        public static string ID
        {
            get => AppSettings.GetValueOrDefault(nameof(ID), "0003");
            set => AppSettings.GetValueOrDefault(nameof(ID), value);
        }

      
       
        public static string device
        {
            get => AppSettings.GetValueOrDefault(nameof(device), "TABLET");
            set => AppSettings.GetValueOrDefault(nameof(device), value);
        }

    


        public static string RootURL
        {
            get => AppSettings.GetValueOrDefault(nameof(RootURL), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(RootURL), value);
        }
    }
}