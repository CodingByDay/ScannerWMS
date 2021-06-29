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

namespace Scanner.App
{
    public static class HelperMethods
    {
        /// <summary>
        /// Use this as a way to show errors.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="title"></param>
        /// <param name="message"></param>



        public static void alert(Context context, string title, string message)
        {
            Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(context);
            AlertDialog alert = dialog.Create();
            alert.SetTitle(title);
            alert.SetMessage(message);

            alert.SetIcon(Resource.Drawable.error);
            alert.SetButton("OK", (c, ev) => { 
            
            
            });

            alert.Show();

        }

    }
}