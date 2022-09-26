using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using Com.Toptoche.Searchablespinnerlibrary;
using Scanner.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;
using static Com.Toptoche.Searchablespinnerlibrary.SearchableListDialog;

namespace Scanner
{
    [Activity(Label = "IssuedGoodsBusinessEventSetup", ScreenOrientation = ScreenOrientation.Portrait)]
    public class IssuedGoodsBusinessEventSetup : Activity, IOnSearchTextChanged, IDialogInterfaceOnClickListener
    {
        private int initial = 0;
        private SearchableSpinner cbDocType;
        public NameValueObjectList docTypes = null;
        private SearchableSpinner cbWarehouse;
        private SearchableSpinner cbExtra;
        private List<ComboBoxItem> objectDocType = new List<ComboBoxItem>();
        private List<ComboBoxItem> objectWarehouse = new List<ComboBoxItem>();
        private List<ComboBoxItem> objectExtra = new List<ComboBoxItem>();
        private int temporaryPositionDoc = 0;
        private int temporaryPositionWarehouse = 0;
        private int temporaryPositionExtra = 0;
        public static bool success = false;
        public static string objectTest;
        private bool byOrder = true;
        private static string byClient = "";
        private TextView lbExtra;
        private Button btnOrder;
        private Button btnOrderMode;
        private Button btnLogout;
        private Button hidden;
        private TextView focus;
        private NameValueObjectList positions = null;
        private IOnSearchTextChanged onSearchTextChanged;
        private Button btnHidden;
        private bool initialLoad;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.IssuedGoodsBusinessEventSetup);
            cbDocType = FindViewById<SearchableSpinner>(Resource.Id.cbDocType);
            cbWarehouse = FindViewById<SearchableSpinner>(Resource.Id.cbWarehouse);
            cbExtra = FindViewById<SearchableSpinner>(Resource.Id.cbExtra);
            lbExtra = FindViewById<TextView>(Resource.Id.lbExtra);
            btnOrderMode = FindViewById<Button>(Resource.Id.btnOrderMode);
            btnOrder = FindViewById<Button>(Resource.Id.btnOrder);
            btnLogout = FindViewById<Button>(Resource.Id.btnLogout);
            btnHidden = FindViewById<Button>(Resource.Id.btnHidden);
            cbDocType.ItemSelected += CbDocType_ItemSelected;
            cbExtra.ItemSelected += CbExtra_ItemSelected;
            cbWarehouse.ItemSelected += CbWarehouse_ItemSelected;
            btnOrder.Click += BtnOrder_Click;
            btnOrderMode.Click += BtnOrderMode_Click;
            btnLogout.Click += BtnLogout_Click;
            hidden = FindViewById<Button>(Resource.Id.hidden);
            hidden.Click += Hidden_Click;
            focus = FindViewById<TextView>(Resource.Id.focus);
            var warehouses = CommonData.ListWarehouses();
            warehouses.Items.ForEach(wh =>
            {
                objectWarehouse.Add(new ComboBoxItem { ID = wh.GetString("Subject"), Text = wh.GetString("Name") });
            });
            var adapterWarehouse = new ArrayAdapter<ComboBoxItem>(this,
            Android.Resource.Layout.SimpleSpinnerItem, objectWarehouse);
            adapterWarehouse.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerItem);
            cbWarehouse.Adapter = adapterWarehouse;
            UpdateForm();
            btnHidden.Click += BtnHidden_Click;
            var adapterDocType = new ArrayAdapter<ComboBoxItem>(this,
            Android.Resource.Layout.SimpleSpinnerItem, objectDocType);
            adapterDocType.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerItem);
            cbDocType.Adapter = adapterDocType;
            btnOrderMode.Enabled = Services.HasPermission("TNET_WMS_BLAG_SND_NORDER", "R");
            cbWarehouse.Enabled = true;
            cbDocType.SetTitle("Iskanje");
            cbDocType.SetPositiveButton("Zapri");
            cbExtra.Prompt = "Iskanje";
            cbExtra.SetTitle("Iskanje");

            cbExtra.SetPositiveButton("Zapri", this);
            cbWarehouse.SetTitle("Iskanje");
            cbWarehouse.SetPositiveButton("Zapri");
            
            cbExtra.SetOnSearchTextChangedListener(this);
            BottomSheetActions bottomSheetActions  = new BottomSheetActions();
            initialLoad = true;
        }
        internal class BottomSheetActions : Java.Lang.Object, IDialogInterfaceOnClickListener
        {
            public void OnClick(IDialogInterface dialog, int which)
            {
                Console.WriteLine("Hello fox");
            }

          
        }
        public void OnClick(IDialogInterface dialog, int which)
        {
           
        }
        public override void OnBackPressed()
        {
        
        }
        private void BtnHidden_Click(object sender, EventArgs e)
        {
            OnBackPressed(); 
            cbExtra.PerformClick();
        }

        private void Hidden_Click(object sender, EventArgs e)
        {
            focus.RequestFocus();
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // Setting F2 to method ProccesStock()
                case Keycode.F1:
                    if (btnOrderMode.Enabled == true)
                    {
                        BtnOrderMode_Click(this, null);
                    }
                    break;

                case Keycode.F2:
                    if (btnOrder.Enabled == true)
                    {
                        BtnOrder_Click(this, null);
                    }
                    break;

                case Keycode.F3://
                    if (btnLogout.Enabled == true)
                    {
                        BtnLogout_Click(this, null);
                    }
                    break;
            }
            return base.OnKeyDown(keyCode, e);
        }

        private void FillOpenOrders()
        {
            try
            {
                if (byOrder && CommonData.GetSetting("UseSingleOrderIssueing") == "1")
                {
                    string toast = string.Format("Pridobivam seznam odprtih naročila");
                    Toast.MakeText(this, toast, ToastLength.Long).Show();

                    try
                    {
                        objectExtra.Clear();
                        var dt = objectDocType.ElementAt(temporaryPositionDoc);

                        if (dt != null)
                        {
                            var wh = objectWarehouse.ElementAt(temporaryPositionWarehouse);
                            if (wh != null && !string.IsNullOrEmpty(wh.ID))
                            {
                                string error;

                                positions = Services.GetObjectList("oodtw", out error, dt.ID + "|" + wh.ID + "|" + byClient);
                                var t = 1;
                                if (positions == null)
                                {
                                    string toasted = string.Format("Napaka pri pridobivanju odprtih naročil: " + error);
                                    Toast.MakeText(this, toasted, ToastLength.Long).Show();
                                    return;
                                }

                                positions.Items.ForEach(p =>
                                {
                                    if (!string.IsNullOrEmpty(p.GetString("Key")))
                                    {
                                        objectExtra.Add(new ComboBoxItem { ID = p.GetString("Key"), Text = p.GetString("ShortKey") + " " + p.GetString("FillPercStr") + " " + p.GetString("Receiver") });
                                    }
                                });
                                var debug = objectExtra.Count;
                                var adapterExtra = new ArrayAdapter<ComboBoxItem>(this,
                                Android.Resource.Layout.SimpleSpinnerItem, objectExtra);
                                adapterExtra.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerItem);
                                cbExtra.Adapter = null;
                                
                                cbExtra.Adapter = adapterExtra;
                                adapterExtra.NotifyDataSetChanged();    
                                cbExtra.RefreshDrawableState();
                                
                                cbExtra.RequestFocus();
                            }
                        }
                    }
                    finally
                    {

                    }
                }
            }
            catch
            {

            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
            HelpfulMethods.clearTheStack(this);
        }

        private void BtnOrderMode_Click(object sender, EventArgs e)
        {
            FillOpenOrders();
            byOrder = !byOrder;
            UpdateForm();
        }

        private void BtnOrder_Click(object sender, EventArgs e)
        {
            // Fixing clicking the order without choosing an order...
            if (objectExtra.Count == 0 && cbExtra.Visibility == ViewStates.Visible) // Fixing this.
            {
                Toast.MakeText(this, "Morate izbrati naročilo.", ToastLength.Long).Show();
            }
            else
            {
                NextStep();
            }
        }

        private void CbWarehouse_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            SearchableSpinner spinner = (SearchableSpinner)sender;

            string toast = string.Format("Izbrali ste: {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
            temporaryPositionWarehouse = e.Position;
            FillOpenOrders();
        }

        private async void CbExtra_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            try
            {
                SearchableSpinner spinner = (SearchableSpinner)sender;
                string toast = string.Format("Izbrali ste: {0}", spinner.GetItemAtPosition(e.Position));
                Toast.MakeText(this, toast, ToastLength.Long).Show();
                temporaryPositionExtra = e.Position;
            
            } catch
            {}
        }

        private void CbDocType_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)

        {
            try
            {
                SearchableSpinner spinner = (SearchableSpinner)sender;

                string toast = string.Format("Izbrali ste: {0}", spinner.GetItemAtPosition(e.Position));
                Toast.MakeText(this, toast, ToastLength.Long).Show();
                temporaryPositionDoc = e.Position;
                var dt = (ComboBoxItem)objectDocType.ElementAt(e.Position);

                var docType = docTypes.Items.FirstOrDefault(x => x.GetString("Code") == dt.ID);
                if (dt != null)
                {
                    var wh = docType.GetString("IssueWarehouse");
                    if (string.IsNullOrEmpty(wh)) { docType.GetString("ReceiveWarehouse"); }
                    if (string.IsNullOrEmpty(wh)) { wh = CommonData.GetSetting("DefaultWarehouse"); }
                    ComboBoxItem.Select(cbDocType, objectDocType, "");
                    ComboBoxItem.Select(cbWarehouse, objectWarehouse, wh);

                    if (!byOrder)
                    {
                        var rec = docType.GetString("Receiver");
                        if (!string.IsNullOrEmpty(rec))
                        {
                            ComboBoxItem.Select(cbExtra, objectExtra, rec);
                        }
                    }
                }
                FillOpenOrders();
            }
            catch(Exception ex)
            {
                string toast = string.Format("Napaka" + ex.ToString());
                Toast.MakeText(this, toast, ToastLength.Long).Show();
            }
        }

        private void UpdateForm()
        {
            objectExtra.Clear();

            if (byOrder)
            {
                if (CommonData.GetSetting("UseSingleOrderIssueing") == "1")
                {
                    lbExtra.Visibility = ViewStates.Visible;
                    cbExtra.Visibility = ViewStates.Visible;
                    lbExtra.Text = "Naročilo:";
                }
                else
                {
                    lbExtra.Visibility = ViewStates.Invisible;
                    cbExtra.Visibility = ViewStates.Invisible;
                }
                if (initial > 0)
                {
                    FillOpenOrders();
                }
                docTypes = CommonData.ListDocTypes("P|N");
                btnOrderMode.Text = "Brez nar. - F3";
                initial += 1;
            }
            else
            {
                lbExtra.Visibility = ViewStates.Visible;
                cbExtra.Visibility = ViewStates.Visible;
                lbExtra.Text = "Subjekt:";
                objectExtra.Clear();
                var subjects = CommonData.ListSubjects();
                subjects.Items.ForEach(s =>
                {
                    objectExtra.Add(new ComboBoxItem { ID = s.GetString("ID"), Text = s.GetString("ID") });
                });
                var adapterExtra = new ArrayAdapter<ComboBoxItem>(this,
                Android.Resource.Layout.SimpleSpinnerItem, objectExtra);
                adapterExtra.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
                cbExtra.Adapter = adapterExtra;
                docTypes = CommonData.ListDocTypes("I;M|F");

                btnOrderMode.Text = "Z naročilom - F3";
            }

            docTypes.Items.ForEach(dt =>
            {
                objectDocType.Add(new ComboBoxItem { ID = dt.GetString("Code"), Text = dt.GetString("Code") + " " + dt.GetString("Name") });
            });
        }

        private bool isOrderLess()
        {
            if (btnOrderMode.Text == "Brez nar. - F3")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void NextStep()
        {
            var itemDT = objectDocType.ElementAt(temporaryPositionDoc);
            if (itemDT == null)
            {
                string toast = string.Format("Poslovni dogodek more bit izbran");
                Toast.MakeText(this, toast, ToastLength.Long).Show();
            }
            else
            {
                var itemWH = objectWarehouse.ElementAt(temporaryPositionWarehouse);
                if (itemWH == null)
                {
                    string toast = string.Format("Sladište more biti izbrano.");
                    Toast.MakeText(this, toast, ToastLength.Long).Show();
                }
                else
                {
                    ComboBoxItem itemSubj = null;
                    if (!byOrder)
                    {
                        itemSubj = objectExtra.ElementAt(temporaryPositionExtra);
                        if (itemSubj == null)
                        {
                            string toast = string.Format("Poslovni dogodek more bit izbran");
                            Toast.MakeText(this, toast, ToastLength.Long).Show();
                            return;
                        }
                    }
                    NameValueObject moveHead = new NameValueObject("MoveHead");
                    moveHead.SetString("DocumentType", itemDT.ID);
                    moveHead.SetString("Wharehouse", itemWH.ID);
                    moveHead.SetBool("ByOrder", byOrder);
                    if (!byOrder)
                    {
                        moveHead.SetString("Receiver", itemSubj.ID);
                    }
                    InUseObjects.Set("MoveHead", moveHead);
                    NameValueObject order = null;

                    {
                        if (byOrder && CommonData.GetSetting("UseSingleOrderIssueing") == "1")
                        {
                            itemSubj = objectExtra.ElementAt(temporaryPositionExtra);
                            if (itemSubj == null)
                            {
                                string toast = string.Format("Subjekt more biti izbran.");
                                Toast.MakeText(this, toast, ToastLength.Long).Show();
                                return;
                            }
                            order = positions.Items.First(p => p.GetString("Key") == objectExtra.ElementAt(temporaryPositionExtra).ID);
                            InUseObjects.Set("OpenOrder", order);
                        }

                        if (byOrder && CommonData.GetSetting("UseSingleOrderIssueing") == "1")
                        {
                            StartActivity(typeof(IssuedGoodsIdentEntryWithTrail));
                            Finish();
                        }
                        else
                        {
                            StartActivity(typeof(IssuedGoodsIdentEntry));
                            Finish();
                        }
                    }
                }
            }
        }

        private async Task SendEvents()
        {
            await Task.Run(() =>
            {
          
                Instrumentation inst = new Instrumentation();
                inst.SendKeyDownUpSync(Keycode.Escape);
            });
        }
        // Specify what you want to happen when the Elapsed event is raised.
        private async void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            byClient = currentWord;
            
                RunOnUiThread(() =>
                {
                    FillOpenOrders();
                    var adapter = cbExtra.Adapter;
                });

                RunOnUiThread(() =>
                {
                    cbExtra.PerformClick();
                });

              //  await SendEvents();

                aTimer.Stop();

      
        }


        private void TimerChange(string target, bool cancel)
        {
            if (!cancel)
            {

                aTimer = new System.Timers.Timer();
                aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                aTimer.Interval = 2000;
                aTimer.Enabled = true;
                aTimer.Start();


            } else
            {
                if (aTimer != null)
                {
                    aTimer.Stop();
                    aTimer = null;
                }
            }
        }

        private string targetWord = string.Empty;
        private string currentWord = string.Empty;
        private System.Timers.Timer aTimer = new System.Timers.Timer();

        public async void OnSearchTextChanged(string p0)
        {
            currentWord = p0;
            TimerChange(p0, true);
            TimerChange(p0, false);
               
        }



    }
}