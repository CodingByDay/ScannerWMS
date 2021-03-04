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
        /// <summary>
        /// //////////////////////////////////////////////////TestApp.Helpers{setting name} -> Usefull library.
        /// </summary>



        public static string ID
        {
            get => AppSettings.GetValueOrDefault(nameof(ID), string.Empty);
            set => AppSettings.GetValueOrDefault(nameof(ID), value);
        }

        public static string ScannerType
        {
            get => AppSettings.GetValueOrDefault(nameof(EnableLog), string.Empty);
            set => AppSettings.GetValueOrDefault(nameof(EnableLog), value);
        }

        

        public static bool EnableLog
        {
            get => AppSettings.GetValueOrDefault(nameof(EnableLog), false);
            set => AppSettings.GetValueOrDefault(nameof(EnableLog), value);
        }


        public static string RootURL
        {
            get => AppSettings.GetValueOrDefault(nameof(RootURL), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(RootURL), value);
        }
    }
}