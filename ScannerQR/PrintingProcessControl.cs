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
using ScannerQR.Printing;
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.Services;

namespace ScannerQR
{
    [Activity(Label = "PrintingProcessControl")]
    public class PrintingProcessControl : Activity
    {
        private TextView lbInfo;
        private EditText dtDate;
        private Button dateChoice;
        private EditText tbUser;
        private EditText tbShift;
        private EditText tbWorker;
        private EditText tbSSCC;
        private EditText tbIdent;
        private EditText tbTitle;

        private Button btNext;
        private Button btPrint;
        private Button button3;

        private int displayedPosition = 0;
        private NameValueObjectList positions = null;
        private DateTime dateX;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.PrintingProcessControl);


            dtDate = FindViewById<EditText>(Resource.Id.dtDate);
            tbUser = FindViewById<EditText>(Resource.Id.tbUser);
            tbShift = FindViewById<EditText>(Resource.Id.tbShift);
            tbWorker = FindViewById<EditText>(Resource.Id.tbWorker);
            tbSSCC = FindViewById<EditText>(Resource.Id.tbSSCC);
            tbIdent = FindViewById<EditText>(Resource.Id.tbIdent);
            tbTitle = FindViewById<EditText>(Resource.Id.tbTitle);
            lbInfo = FindViewById<TextView>(Resource.Id.lbInfo);

            dateChoice = FindViewById<Button>(Resource.Id.dateChoice);

            btNext = FindViewById<Button>(Resource.Id.btNext);
            btPrint = FindViewById<Button>(Resource.Id.btPrint);
            button3 = FindViewById<Button>(Resource.Id.button3);
            btNext.Click += BtNext_Click;
            btPrint.Click += BtPrint_Click;
            button3.Click += Button3_Click;
            dateChoice.Click += DateChoice_Click;


            tbUser.Text = Services.UserName();
            dateX = DateTime.Today;
            dtDate.Text= DateTime.Today.ToShortDateString();

            GetProcessControls();
         

        }

        private void DateChoice_Click(object sender, EventArgs e)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                dtDate.Text = time.ToShortDateString();
                dateX = time;
      
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void BtPrint_Click(object sender, EventArgs e)
        {
 
            try
            {
       
                var nvo = new NameValueObject("PrintProcessControl");
                PrintingCommon.SetNVOCommonData(ref nvo);
                nvo.SetInt("QualityHead", positions.Items[displayedPosition].GetInt("HeadID"));
                PrintingCommon.SendToServer(nvo);
 
            }
            finally
            {
            
            }
        }

        private void BtNext_Click(object sender, EventArgs e)
        {
            displayedPosition++;
            if (displayedPosition >= positions.Items.Count) { displayedPosition = 0; }
            FillDisplayedItem();
        }

        private void GetProcessControls()
        {
        
            try
            {
              // Comment 1, 1, 2, 3, 5, 8, 13------->+-1.68-->lim.infinity

                string error;
                positions = Services.GetObjectList("qhfbd", out error, "P|" + dateX.ToString("s"));
                if (positions == null)
                {
                    Toast.MakeText(this, "Napaka pri prenosu podatkov: " + error, ToastLength.Long).Show();

                    return;
                }

                displayedPosition = 0;
                FillDisplayedItem();
            }
            finally
            {
               
            }
        }


        private void FillDisplayedItem()
        {
            if ((positions != null) && (positions.Items.Count > 0))
            {
                lbInfo.Text = "Procesna kontrola (" + (displayedPosition + 1).ToString() + "/" + positions.Items.Count + ")";
                var item = positions.Items[displayedPosition];

                tbShift.Text = item.GetString("Shift");
                tbWorker.Text = item.GetString("Worker");
                tbSSCC.Text = item.GetString("SSCC");
                tbIdent.Text = item.GetString("Ident");
                tbTitle.Text = "???";



                tbShift.Enabled = false;
                tbWorker.Enabled = false;
                tbSSCC.Enabled = false;
                tbIdent.Enabled = false;
                tbTitle.Enabled = false;
                btNext.Enabled = true;
                btPrint.Enabled = true;



                tbShift.SetTextColor(Android.Graphics.Color.Black);
                tbWorker.SetTextColor(Android.Graphics.Color.Black);
                tbSSCC.SetTextColor(Android.Graphics.Color.Black);
                tbIdent.SetTextColor(Android.Graphics.Color.Black);
                tbTitle.SetTextColor(Android.Graphics.Color.Black);
            }
            else
            {
                lbInfo.Text = "Procesna kontrola (ni)";

                tbShift.Text = "";
                tbWorker.Text = "";
                tbSSCC.Text = "";
                tbIdent.Text = "";
                tbTitle.Text = "";

                btNext.Enabled = false;
                btPrint.Enabled = false;



                tbShift.Enabled = false;
                tbWorker.Enabled = false;
                tbSSCC.Enabled = false;
                tbIdent.Enabled = false;
                tbTitle.Enabled = false;



                tbShift.SetTextColor(Android.Graphics.Color.Black);
                tbWorker.SetTextColor(Android.Graphics.Color.Black);
                tbSSCC.SetTextColor(Android.Graphics.Color.Black);
                tbIdent.SetTextColor(Android.Graphics.Color.Black);
                tbTitle.SetTextColor(Android.Graphics.Color.Black);
            }
        }
    }
}