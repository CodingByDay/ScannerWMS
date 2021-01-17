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
    [Activity(Label = "PrintingProcessControl")]
    public class PrintingProcessControl : Activity
    {
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


            dateChoice = FindViewById<Button>(Resource.Id.dateChoice);

            btNext = FindViewById<Button>(Resource.Id.btNext);
            btPrint = FindViewById<Button>(Resource.Id.btPrint);
            button3 = FindViewById<Button>(Resource.Id.button3);
        }
    }
}