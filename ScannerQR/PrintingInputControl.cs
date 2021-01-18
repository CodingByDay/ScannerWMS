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
    [Activity(Label = "PrintingInputControl")]
    public class PrintingInputControl : Activity
    {
        private EditText dtDate;
        private EditText tbUser; 

       private TextView lbInfo;

        private EditText tbTakeOver;
        private EditText tbSupplier;
        private EditText tbTakeOverDate;
        private Button dateChoice;
        private int displayedPosition = 0;
        private NameValueObjectList positions = null;
        private Button btNext;
        private Button btPrint;
        private Button button3;
        private DateTime dateX;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.PrintingInputControl);
            dtDate = FindViewById<EditText>(Resource.Id.dtDate);

            tbUser = FindViewById<EditText>(Resource.Id.dtDate);

            lbInfo = FindViewById<TextView>(Resource.Id.lbInfo);

            tbTakeOver = FindViewById<EditText>(Resource.Id.tbTakeOver);
            tbSupplier = FindViewById<EditText>(Resource.Id.tbSupplier);
            tbTakeOverDate = FindViewById<EditText>(Resource.Id.tbTakeOverDate);
            dateChoice = FindViewById<Button>(Resource.Id.dateChoice);

            btNext = FindViewById<Button>(Resource.Id.btNext);
            btPrint = FindViewById<Button>(Resource.Id.btPrint);
            button3 = FindViewById<Button>(Resource.Id.button3);
            btNext.Click += BtNext_Click;
            btPrint.Click += BtPrint_Click;
            button3.Click += Button3_Click;
            dateX = DateTime.Today;

            tbUser.Text = Services.UserName();
            dateChoice.Click += DateChoice_Click;
            dtDate.Text = DateTime.Today.ToShortDateString();
            dateX = DateTime.Today;
            GetInputControls();
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
        //logout

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // in smartphone
                case Keycode.F2:
                    if (btNext.Enabled == true)
                    {
                        BtNext_Click(this, null);
                    }
                    break;
                //return true;


                case Keycode.F3:
                    if (btPrint.Enabled == true)
                    {
                        BtPrint_Click(this, null);
                    }
                    break;


                case Keycode.F8:
                    if (button3.Enabled == true)
                    {
                        Button3_Click(this, null);
                    }
                    break;


            }
            return base.OnKeyDown(keyCode, e);
        }//
        private void BtPrint_Click(object sender, EventArgs e)
        {
       
            try
            {
         
                var nvo = new NameValueObject("PrintInputControl");
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

        private void GetInputControls()
        {
         
            try
            {
              

                string error;
                positions = Services.GetObjectList("qhfbd", out error, "I|" + dateX.ToString("s"));
                if (positions == null)
                {
                    string WebError = string.Format("Napaka pri prenosu podatkov" + error);
                    Toast.MakeText(this, WebError, ToastLength.Long).Show();

                    return;
                }

                displayedPosition = 0;
                FillDisplayedItem();
            }
            finally
            {
              // used to be a wait form...
            }
        }

        private void FillDisplayedItem()
        {
            if ((positions != null) && (positions.Items.Count > 0))
            {
                lbInfo.Text = "Vhodna kontrola (" + (displayedPosition + 1).ToString() + "/" + positions.Items.Count + ")";
                var item = positions.Items[displayedPosition];

                tbTakeOver.Text = item.GetString("LinkKey");
                tbSupplier.Text = item.GetString("Supplier");
                tbTakeOverDate.Text = "???";

                btNext.Enabled = true;
                btPrint.Enabled = true;
            }
            else
            {
                lbInfo.Text = "Vhodna kontrola (ni)";

                tbTakeOver.Text = "";
                tbSupplier.Text = "";
                tbTakeOverDate.Text = "";

                btNext.Enabled = false;
                btPrint.Enabled = false;
            }
        }

        



    }
}