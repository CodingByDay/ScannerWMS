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
    [Activity(Label = "PrintingOutputControl")]
    public class PrintingOutputControl : Activity
    {
//        dtDate
//tbUser
//tbSSCC
//tbSerialNum
//tbIdent
//tbTitle
//tbQty

//btNext

//btPrint

//button3
        private int displayedPosition = 0;
        private NameValueObjectList positions = null;
        private EditText tbUser;
  
        private EditText tbSSCC;
        private EditText tbSerialNum;
        private EditText tbIdent;
        private EditText tbTitle;
        private EditText tbQty;
        private TextView lbInfo;
        private Button btNext;
        private Button btPrint;
        private Button button3;
        private EditText dateText;
        private Button date;
        public DateTime dateX;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.PrintingOutputControl);
            tbUser = FindViewById<EditText>(Resource.Id.tbUser);
            tbSSCC = FindViewById<EditText>(Resource.Id.tbSSCC);
            tbSerialNum = FindViewById<EditText>(Resource.Id.tbSerialNum);
            tbIdent = FindViewById<EditText>(Resource.Id.tbIdent);
            tbTitle = FindViewById<EditText>(Resource.Id.tbTitle);
            tbQty = FindViewById<EditText>(Resource.Id.tbQty);
           
            //
            btNext = FindViewById<Button>(Resource.Id.btNext);
            btPrint = FindViewById<Button>(Resource.Id.btPrint);
            button3 = FindViewById<Button>(Resource.Id.button3);
            lbInfo = FindViewById<TextView>(Resource.Id.lbInfo);
            dateText = FindViewById<EditText>(Resource.Id.dateText);
            date = FindViewById<Button>(Resource.Id.date);
            dateX = DateTime.Now;
            dateText.Text = DateTime.Now.ToShortDateString();
            date.Click += Date_Click;
         
            btNext.Click += BtNext_Click;
            btPrint.Click += BtPrint_Click;
            button3.Click += Button3_Click;


            tbUser.Text = Services.UserName();

           
            GetOutputControls();
            dateText.Text = DateTime.Today.ToShortDateString();



        }

        private void Date_Click(object sender, EventArgs e)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                dateText.Text = time.ToShortDateString();
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
          
                var nvo = new NameValueObject("PrintOutputControl");
                PrintingCommon.SetNVOCommonData(ref nvo);
                nvo.SetInt("QualityHead", positions.Items[displayedPosition].GetInt("HeadID"));
                PrintingCommon.SendToServer(nvo);
        
            }
            finally
            {
       //
            }

        }

        private void BtNext_Click(object sender, EventArgs e)
        {
            displayedPosition++;
            if (displayedPosition >= positions.Items.Count) { displayedPosition = 0; }
            FillDisplayedItem();
        }

        private void GetOutputControls()
        {

            try
            {
                

                
                string error;
                positions = Services.GetObjectList("qhfbd", out error, "O|" + dateX.ToString("s"));
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
            //
            }
        }
        private void FillDisplayedItem()
        {
            if ((positions != null) && (positions.Items.Count > 0))
            {
                lbInfo.Text = "Končna kontrola (" + (displayedPosition + 1).ToString() + "/" + positions.Items.Count + ")";
                var item = positions.Items[displayedPosition];

                tbSSCC.Text = item.GetString("SSCC");
                tbSerialNum.Text = item.GetString("SerialNo");
                tbIdent.Text = item.GetString("Ident");
                tbTitle.Text = "???";
                tbQty.Text = item.GetDouble("Qty").ToString(CommonData.GetQtyPicture());

                btNext.Enabled = true;
                btPrint.Enabled = true;
            }
            else
            {
                lbInfo.Text = "Končna kontrola (ni)";

                tbSSCC.Text = "";
                tbSerialNum.Text = "";
                tbIdent.Text = "";
                tbTitle.Text = "";
                tbQty.Text = "";

                btNext.Enabled = false;
                btPrint.Enabled = false;
            }
        }
    }


}