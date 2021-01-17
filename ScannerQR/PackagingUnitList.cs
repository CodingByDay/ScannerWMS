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
    [Activity(Label = "PackagingUnitList")]
    public class PackagingUnitList : Activity
 
    {
        private TextView lbInfo;


        private EditText tbIdent;
        private EditText;
        private EditText tbSerialNo;
        private EditText tbQty;
        private EditText tbLocation;
        private EditText tbCreatedBy;

        private Button btNext;
        private Button btUpdate;
        private Button btDelete;
        private Button btCreate;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.PackagingUnitList);
        }
    }
}