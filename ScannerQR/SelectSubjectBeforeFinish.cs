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
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;

namespace ScannerQR
{
    [Activity(Label = "SelectSubjectBeforeFinish")]
    public class SelectSubjectBeforeFinish : Activity
    {
        private int HeadID;
        private Spinner cbSubject;
        private Button btConfirm;
        List<ComboBoxItem> objectSubjects = new List<ComboBoxItem>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SelectSubjectBeforeFinish);

            cbSubject = FindViewById<Spinner>(Resource.Id.cbSubject);
            btConfirm = FindViewById<Button>(Resource.Id.btConfirm);

        }
        public SelectSubjectBeforeFinish()
        {




            // constructor
        }

        public static void ShowIfNeeded(int headID)
        {
            if ((CommonData.GetSetting("WorkOrderFinishWithSubject") ?? "0") == "1")
            {
                NameValueObjectList data;


                try
                {
                    string error;
                    data = Services.GetObjectList("hs", out error, headID.ToString());
                    if (data == null)
                    {
                        string SuccessMessage = string.Format("Napaka pri dobivanju možnih subjektov" + error);

                    }
                }
                finally
                {

                }

                if (data.Items.Count == 0) { return; }

                //var form = new SelectSubjectBeforeFinish();
                //form.SetHeadID(headID);
                //form.cbSubject.Items.Clear();
                //form.cbSubject.Items.Add("");
                //data.Items.ForEach(i => form.cbSubject.Items.Add(i.GetString("Subject")));
                //form.cbSubject.SelectedIndex = 1;
                //form.ShowDialog();

            }

        }

        private void SetHeadID(int headID)
        {
            throw new NotImplementedException();
        }
    }
}
