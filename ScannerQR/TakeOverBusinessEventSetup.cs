using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Toptoche.Searchablespinnerlibrary;
using Microsoft.AppCenter.Crashes;
using Scanner.App;
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;

namespace Scanner
{
    [Activity(Label = "TakeOverBusinessEventSetup", ScreenOrientation = ScreenOrientation.Portrait)]
    public class TakeOverBusinessEventSetup : Activity
    {
        private Spinner cbDocType;
        private SearchableSpinner cbWarehouse;
        private SearchableSpinner cbSubject;
        private int temporaryPositionWarehouse;
        private int temporaryPositionSubject;
        private int temporaryPositioncbDoc;
        private Button btnOrder;
        private Button btnOrderMode;
        private Button logout;
        private NameValueObjectList docTypes = null;
        private bool byOrder = true;
        List<ComboBoxItem> objectcbDocType = new List<ComboBoxItem>();
        List<ComboBoxItem> objectcbWarehouse = new List<ComboBoxItem>();
        List<ComboBoxItem> objectcbSubject = new List<ComboBoxItem>();
        private TextView label1;
        private TextView label2;
        private TextView lbSubject;
        private ArrayAdapter<ComboBoxItem> adapterSubject;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.TakeOverBusinessEventSetup);
            // Declarations
            cbDocType = FindViewById<Spinner>(Resource.Id.cbDocType);
            cbWarehouse = FindViewById<SearchableSpinner>(Resource.Id.cbWarehouse);
            cbSubject = FindViewById<SearchableSpinner>(Resource.Id.cbSubject);
            btnOrder = FindViewById<Button>(Resource.Id.btnOrder);
            btnOrderMode = FindViewById<Button>(Resource.Id.btnOrderMode);
            logout = FindViewById<Button>(Resource.Id.btnLogout);

            label1 = FindViewById<TextView>(Resource.Id.label1);
            label2 = FindViewById<TextView>(Resource.Id.label2);
            lbSubject = FindViewById<TextView>(Resource.Id.lbSubject);
            btnOrder.Click += BtnOrder_Click;
            btnOrderMode.Click += BtnOrderMode_Click;
            logout.Click += Logout_Click;
            btnOrderMode.Enabled = Services.HasPermission("TNET_WMS_BLAG_ACQ_NORDER", "R");
            var warehouses = CommonData.ListWarehouses();


            if (warehouses != null)
            {
                warehouses.Items.ForEach(wh =>
                {
                    objectcbWarehouse.Add(new ComboBoxItem { ID = wh.GetString("Subject"), Text = wh.GetString("Name") });
                });
            }



            var adapter = new ArrayAdapter<ComboBoxItem>(this,
             Android.Resource.Layout.SimpleSpinnerItem, objectcbWarehouse);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            cbWarehouse.Adapter = adapter;

            UpdateForm();

         
            var adapterDoc = new ArrayAdapter<ComboBoxItem>(this,
            Android.Resource.Layout.SimpleSpinnerItem, objectcbDocType);

            adapterDoc.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            cbDocType.Adapter = adapterDoc;


            cbDocType.ItemSelected += CbDocType_ItemSelected;
            cbSubject.ItemSelected += CbSubject_ItemSelected;
            cbWarehouse.ItemSelected += CbWarehouse_ItemSelected;
            cbSubject.SetTitle("Iskanje");
            cbSubject.SetPositiveButton("Zapri");
            cbWarehouse.SetTitle("Iskanje");
            cbWarehouse.SetPositiveButton("Zapri");

            var dw = CommonData.GetSetting("DefaultWarehouse");
            if (!string.IsNullOrEmpty(dw))
            {
                ComboBoxItem.Select(cbWarehouse, objectcbWarehouse, dw);

            }

            var _broadcastReceiver = new NetworkStatusBroadcastReceiver();
            _broadcastReceiver.ConnectionStatusChanged += OnNetworkStatusChanged;
            Application.Context.RegisterReceiver(_broadcastReceiver,
            new IntentFilter(ConnectivityManager.ConnectivityAction));
        }
        public bool IsOnline()
        {
            var cm = (ConnectivityManager)GetSystemService(ConnectivityService);
            return cm.ActiveNetworkInfo == null ? false : cm.ActiveNetworkInfo.IsConnected;

        }

        private void OnNetworkStatusChanged(object sender, EventArgs e)
        {
            if (IsOnline())
            {
                
                try
                {
                    LoaderManifest.LoaderManifestLoopStop(this);
                }
                catch (Exception err)
                {
                    Crashes.TrackError(err);
                }
            }
            else
            {
                LoaderManifest.LoaderManifestLoop(this);
            }
        }
        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // in smartphone
                case Keycode.F2:
                    if (btnOrder.Enabled == true)
                    {
                        BtnOrder_Click(this, null);
                    }
                    break;
                // return true;
                case Keycode.F3:
                    if (btnOrderMode.Enabled == true)
                    {
                        BtnOrderMode_Click(this, null);
                    }
                    break;
                case Keycode.F9:
                    if (logout.Enabled == true)
                    {
                        Logout_Click(this, null);
                    }
                    break;
            }
            return base.OnKeyDown(keyCode, e);
        }
        private void Logout_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainMenu));
            HelpfulMethods.clearTheStack(this);
        }

        private void BtnOrderMode_Click(object sender, EventArgs e)
        {
            if (byOrder && (CommonData.GetSetting("UseDirectTakeOver") == "1"))
            {
                StartActivity(typeof(TakeOver2Main));
                HelpfulMethods.clearTheStack(this);
            }
            else
            {
                byOrder = !byOrder;
                UpdateForm();
            }
        }
    

        private void BtnOrder_Click(object sender, EventArgs e)
        {
            NextStep();
        }

        private void UpdateForm()
        {
       
           
            try
            {
              
      
                objectcbDocType.Clear();

                if (byOrder)
                {
                    lbSubject.Visibility = ViewStates.Invisible;
                    cbSubject.Visibility = ViewStates.Invisible;

                    docTypes = CommonData.ListDocTypes("I|N");

                    btnOrderMode.Text = "Brez nar. - F3";
                }
                else
                {
                    lbSubject.Visibility = ViewStates.Visible;
                    cbSubject.Visibility = ViewStates.Visible;

                    if (cbSubject.Count == 0)
                    {
                        var subjects = CommonData.ListSubjects();
                        subjects.Items.ForEach(s =>
                        {
                            objectcbSubject.Add(new ComboBoxItem { ID = s.GetString("ID"), Text = s.GetString("ID") });
                    
                        });

                        adapterSubject = new ArrayAdapter<ComboBoxItem>(this,
                        Android.Resource.Layout.SimpleSpinnerItem, objectcbSubject);
                        adapterSubject.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
                        cbSubject.Adapter = adapterSubject;
                        // Test this.
                    }

                    docTypes = CommonData.ListDocTypes("P|F");

                    btnOrderMode.Text = "Z naročilom - F3";
                }

                docTypes.Items.ForEach(dt =>
                {
                    objectcbDocType.Add(new ComboBoxItem { ID = dt.GetString("Code"), Text = dt.GetString("Code") + " " + dt.GetString("Name") });
                });
            }
            finally
            {
                
            }
        }


        private void NextStep()
        {
           var itemDT = objectcbDocType.ElementAt(temporaryPositioncbDoc); 
            if (itemDT == null)
            {
                string toast = string.Format("Poslovni dogodek more bit izbran");
                Toast.MakeText(this, toast, ToastLength.Long).Show();
            }
            else
            {
                var itemWH = objectcbWarehouse.ElementAt(temporaryPositionWarehouse);
                if (itemWH == null)
                {
                    string toast = string.Format("Sladište more biti izbrano");
                    Toast.MakeText(this, toast, ToastLength.Long).Show();

                }
                else
                {
                    ComboBoxItem itemSubj = null;
                    if (!byOrder)
                    {
                        itemSubj = objectcbSubject.ElementAt(temporaryPositionSubject);
                        if (itemSubj == null)
                        {
                            string toast = string.Format("Subjekt more bit izbran");
                            Toast.MakeText(this, toast, ToastLength.Long).Show();

                            return;
                        }
                    }

                    NameValueObject moveHead = (NameValueObject)InUseObjects.Get("MoveHead");
                    moveHead.SetString("DocumentType", itemDT.ID);
                    moveHead.SetString("Wharehouse", itemWH.ID);
                    moveHead.SetBool("ByOrder", byOrder);
                    if (!byOrder)
                    {
                        moveHead.SetString("Receiver", itemSubj.ID);
                    }

                   StartActivity(typeof(TakeOverIdentEntry));
                   HelpfulMethods.clearTheStack(this);

                }
            }
         
        }

        private void CbWarehouse_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            Spinner spinner = (Spinner)sender;
            string toast = string.Format("Izbrali ste: {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
            temporaryPositionWarehouse = e.Position;
        }

        private void CbSubject_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            Spinner spinner = (Spinner)sender;
            string toast = string.Format("Izbrali ste: {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
            temporaryPositionSubject = e.Position;
        }

        private void CbDocType_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            Spinner spinner = (Spinner)sender;
            string toast = string.Format("Izbrali ste: {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
            temporaryPositioncbDoc = e.Position;
        }
    }
}
