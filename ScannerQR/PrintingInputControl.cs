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


        private Button btNext;
        private Button btPrint;
        private Button button3;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.PrintingInputControl);
            dtDate = FindViewById<EditText>(Resource.Id.dtDate);
tbUser = FindViewById<EditText>(Resource.Id.dtDate);

            lbInfo = FindViewById<TextView>(Resource.Id.lbInfo);

            tbTakeOver = FindViewById<EditText>(Resource.Id.tbTakeOver);
            tbSupplier = FindViewById<EditText>(Resource.Id.dtDate);
            tbTakeOverDate = FindViewById<EditText>(Resource.Id.dtDate);


            btNext = FindViewById<EditText>(Resource.Id.dtDate);
            btPrint = FindViewById<EditText>(Resource.Id.dtDate);
            button3 = FindViewById<EditText>(Resource.Id.dtDate);
        }
    }
}