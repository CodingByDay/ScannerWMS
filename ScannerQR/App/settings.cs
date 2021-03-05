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
            get => AppSettings.GetValueOrDefault(nameof(ID), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(ID), value);
        }

      
       
        public static string device
        {
            get => AppSettings.GetValueOrDefault(nameof(device), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(device), value);
        }

    
        public static bool tablet
        {
            get => AppSettings.GetValueOrDefault(nameof(tablet), false);
            set => AppSettings.AddOrUpdateValue(nameof(tablet), value);
        }

        public static string RootURL
        {
            get => AppSettings.GetValueOrDefault(nameof(RootURL), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(RootURL), value);
        }
    }
}