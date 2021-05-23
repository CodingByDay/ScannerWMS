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
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.Services;
using static Android.Widget.AdapterView;
using Android.Content.PM;
using Com.Toptoche.Searchablespinnerlibrary;
/// <summary>
/// 
/// </summary>

namespace Scanner
{
    [Activity(Label = "InterWarehouseBusinessEventSetup", ScreenOrientation = ScreenOrientation.Portrait)]
    public class InterWarehouseBusinessEventSetup : Activity
    {
        private Spinner cbDocType;
        public NameValueObjectList docTypes = null;     
        private SearchableSpinner cbIssueWH;
        private SearchableSpinner cbReceiveWH;
        List<ComboBoxItem> objectDocType = new List<ComboBoxItem>();
        List<ComboBoxItem> objectIssueWH = new List<ComboBoxItem>();
        List<ComboBoxItem> objectReceiveWH = new List<ComboBoxItem>();
        private int temporaryPositionDoc;
        private int temporaryPositionIssue;
        private int temporaryPositionReceive;    
        public static bool success = false;
        public static string objectTest;
        private Button confirm;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
    
            SetContentView(Resource.Layout.InterWarehouseBusinessEventSetup);
            // Views
            cbDocType = FindViewById<Spinner>(Resource.Id.cbDocType);
          
            cbIssueWH = FindViewById<SearchableSpinner>(Resource.Id.cbIssueWH);
            cbReceiveWH = FindViewById<SearchableSpinner>(Resource.Id.cbRecceiveWH);
         
            objectDocType.Add(new ComboBoxItem { ID = "Default", Text = "               Izberite poslovni dogodek." });
         
            docTypes = CommonData.ListDocTypes("E|");
            docTypes.Items.ForEach(dt =>
            { //
                
            objectDocType.Add( new ComboBoxItem { ID = dt.GetString("Code"), Text = dt.GetString("Code") + " " + dt.GetString("Name") });
            
        });
            /*
             Aditional comment area. */
            var adapter = new ArrayAdapter<ComboBoxItem>(this,
             Android.Resource.Layout.SimpleSpinnerItem, objectDocType);
            ///* 
            ///* Documentation for the spinner objects add method with an adapter...
            ///*---------------------------------------------------
            ///
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            cbDocType.Adapter = adapter;
           
            // Next thing... var warehouses = CommonData.ListWarehouses();
            // cbIssueWH
            var warehouses = CommonData.ListWarehouses();
            if (warehouses != null)
            {
                warehouses.Items.ForEach(dt =>
                {
                    objectIssueWH.Add(new ComboBoxItem { ID = dt.GetString("Subject"), Text = dt.GetString("Name")});
              
                    objectReceiveWH.Add( new ComboBoxItem { ID = dt.GetString("Subject"), Text = dt.GetString("Name")});
                  
                });
            }
            var adapterIssue = new ArrayAdapter<ComboBoxItem>(this,
            Android.Resource.Layout.SimpleSpinnerItem, objectIssueWH);
            var adapterReceive = new ArrayAdapter<ComboBoxItem>(this,
            Android.Resource.Layout.SimpleSpinnerItem, objectReceiveWH);
            adapterIssue.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            adapterReceive.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            cbIssueWH.Adapter = adapterIssue;
            cbReceiveWH.Adapter = adapterReceive;
            cbDocType.SetSelection(2);         
            // next thing are the event listeners
            //for the logout
            Button logout = FindViewById<Button>(Resource.Id.logout);
            logout.Click += Logout_Click;
            // event listeners
            cbDocType.ItemSelected += CbDocType_ItemSelected;
            cbIssueWH.ItemSelected += CbIssueWH_ItemSelected;
            cbReceiveWH.ItemSelected += CbReceiveWH_ItemSelected;
            // confirm button          
            confirm = FindViewById<Button>(Resource.Id.btnConfirm);
            confirm.Click += Confirm_Click;
            cbIssueWH.SetTitle("Iskanje");
            cbIssueWH.SetPositiveButton("Zapri");
            cbReceiveWH.SetTitle("Iskanje");
            cbReceiveWH.SetPositiveButton("Zapri");
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
               
                case Keycode.F3:
                    if (confirm.Enabled == true)
                    {
                        Confirm_Click(this, null);
                    }
                    break;
                // return true;

                case Keycode.F9:
                    
                    Logout_Click(this, null);
                    break;
            }
            return base.OnKeyDown(keyCode, e);
        }
       
        private void PrefillWarehouses(string id)
        {
            // Log.Write(new LogEntry("PrefillWarehouses: " + id));
            if (string.IsNullOrEmpty(id)) { return; }
            var dt = docTypes.Items.FirstOrDefault(x => x.GetString("Code") == id);
            if (dt != null)
            {
                ComboBoxItem.Select(cbDocType, objectDocType, id);
                ComboBoxItem.Select(cbIssueWH, objectIssueWH, dt.GetString("IssueWarehouse"));
                cbIssueWH.Enabled = dt.GetBool("CanChangeIssueWarehouse");
                ComboBoxItem.Select(cbReceiveWH, objectReceiveWH, dt.GetString("ReceiveWarehouse"));
                cbReceiveWH.Enabled = dt.GetBool("CanChangeReceiveWarehouse");
            }
        }



            private void Confirm_Click(object sender, EventArgs e)
        {
            var dt = objectDocType.ElementAt(temporaryPositionDoc);
            var iwh = objectIssueWH.ElementAt(temporaryPositionIssue);
            var rwh = objectReceiveWH.ElementAt(temporaryPositionReceive);

             var doc = dt.ID;
            var issue = iwh.ID;
            var receive = rwh.ID;
          

        //   NameValueObject moveHead = new NameValueObject();
            NameValueObject moveHead = (NameValueObject)InUseObjects.Get("MoveHead");

                moveHead.SetString("DocumentType", doc);
                moveHead.SetString("Type", "E");
                moveHead.SetString("Issuer", issue);
                moveHead.SetString("Receiver", receive);
                moveHead.SetString("LinkKey", "");
                moveHead.SetInt("LinkNo", 0);
                moveHead.SetInt("Clerk", Services.UserID());
           
            
            string error;
     
            try
            {
                
                var savedMoveHead = Services.SetObject("mh", moveHead, out error);
                if (savedMoveHead == null)
                {
                    string errorWebApp = string.Format("Napaka pri dostopu do web aplikacije:" + error );
                    Toast.MakeText(this, errorWebApp, ToastLength.Long).Show();
                    // show a message
                    // terminate
                   
                }
                else
                {
                    if (!Services.TryLock("MoveHead" + savedMoveHead.GetInt("HeadID").ToString(), out error))
                    {
                        string errorWebApp = string.Format("Kritična napaka pri zaklepanju nove medskladiščnice: " + error);
                        Toast.MakeText(this, errorWebApp, ToastLength.Long).Show();
                        // show a message
                        // terminate
                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                    }

                    moveHead.SetInt("HeadID", savedMoveHead.GetInt("HeadID"));
                    moveHead.SetBool("Saved", true);
                    InUseObjects.Set("MoveHead", moveHead);
                }

                StartActivity(typeof(InterWarehouseSerialOrSSCCEntry));
                
            } finally
            {
                success = true;
            }   
        }
        




private void CbReceiveWH_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
                temporaryPositionReceive = e.Position;           
        }

        private void CbIssueWH_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;            
                temporaryPositionIssue = e.Position;
            
        }

        private void CbDocType_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            // avoids Default value selection.
            if(e.Position == 0)
            {
                cbIssueWH.Visibility = ViewStates.Invisible;
                cbReceiveWH.Visibility = ViewStates.Invisible;
                confirm.Enabled = false;
                string errorWebApp = string.Format("Poslovni dogodek mora biti izbran.");
                Toast.MakeText(this, errorWebApp, ToastLength.Long).Show();



            } else {
            cbIssueWH.Visibility = ViewStates.Visible;
            cbReceiveWH.Visibility = ViewStates.Visible;
            confirm.Enabled = true;
            cbIssueWH.Enabled = true;
            cbReceiveWH.Enabled = true;
            Spinner spinner = (Spinner)sender;
                if (e.Position != 0)
                {
                    string toast = string.Format("Izbrali ste: {0}", spinner.GetItemAtPosition(e.Position));
                    Toast.MakeText(this, toast, ToastLength.Long).Show();
                    temporaryPositionDoc = e.Position;
                    var id = objectDocType.ElementAt(e.Position).ID;
                    PrefillWarehouses(id);
                }

            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainMenu));
        }
    }
    
}