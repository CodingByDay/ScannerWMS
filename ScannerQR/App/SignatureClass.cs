using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Controls;

namespace Scanner.App
{
    public static class SignatureClass
    {



        /// <summary>
        ///  A method to sign the document 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public static Bitmap SignHere(Context where)
        {
            var signatureView = new SignaturePadView(where)
            {
                StrokeWidth = 3f,
                StrokeColor = Color.White,
                BackgroundColor = Color.Black
            };

            try
            {
                Bitmap image = signatureView.GetImage();
                return image;

            } catch(Exception ex)
            {
                Toast.MakeText(where, $"Prišlo je do napake. {ex}", ToastLength.Long);
                return null;
            }
            
        }



    }
}