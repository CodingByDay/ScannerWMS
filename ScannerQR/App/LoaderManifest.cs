using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.Content;
using Android.Net;
using Android.Telephony;
using Java.IO;
using Java.Net;
using Xamarin.Essentials;

namespace Scanner.App
{
    public static class LoaderManifest
    {
        private static ProgressDialogClass progress;

        public static void LoaderManifestLoop(Context context)
        {
            progress = new ProgressDialogClass();
            progress.ShowDialogSync(context, "Ni internetne povezave... Povezovanje...");
                   
        }


        public static void LoaderManifestLoopStop(Context context)
        {
            try
            {
                progress.StopDialogSync();
            } catch
            {
                return;
            }
        }

        public static NetworkInfo GetNetworkInfo(Context context)
        {
            ConnectivityManager cm = (ConnectivityManager)context.GetSystemService(Context.ConnectivityService);
            return cm.ActiveNetworkInfo;
        }

        /**
	     * Check if there is any connectivity
	     * @param context
	     * @return
	     */
        public static bool IsConnected(Context context)
        {
            NetworkInfo info = GetNetworkInfo(context);
            return (info != null && info.IsConnected);
        }


       
    }
}