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
    public static class HelpfulMethods
    {
        private static int count=0;
        public static bool preventDupUse()
        {
                var check = count;
                count += 1;

                if (count > 1)
                {
                
                    count = 0;
                    return false;

                } else

                {
                return true;
                }
        }
            
        

    }
}