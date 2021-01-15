using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Android.Widget;

namespace TrendNET.WMS.Device.App
{
    public class ComboBoxItem
    {
        public string ID { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }

        public static void Select(Spinner important,  List<ComboBoxItem> obj, string id)
        {
            for (int i = 0; i < obj.Count; i++)
            {
                if (((ComboBoxItem)obj.ElementAt(i)).ID == id)
                {
                    int selected = (int)important.SelectedItemId;
                    if (selected != i)
                    {
                        important.SetSelection(i); 
                    }
                    return;
                }
            }
            if (important.SelectedItemId != -1)
            {
                important.SetSelection(-1);
            }
        }
    }
}


