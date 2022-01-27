﻿using Android.App;
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
    class CleanupLocation
    {
        public string Location { get; set; }


        public string SSCC { get; set; }


        public string Ident { get; set; }



        /// <summary>
        ///  Empty constructor.
        /// </summary>
        public CleanupLocation()
        {
            
        }

        /// <summary>
        ///  Full constructor.
        /// </summary>
        /// <param name="Location"></param>
        /// <param name="SSCC"></param>
        /// <param name="Ident"></param>
        public CleanupLocation(string Location, string SSCC, string Ident)
        {
            this.Location = Location;
            this.SSCC = SSCC;
            this.Ident = Ident;
        }
    }
}