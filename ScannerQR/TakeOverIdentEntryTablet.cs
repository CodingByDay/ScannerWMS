using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BarCode2D_Receiver;
using Com.Toptoche.Searchablespinnerlibrary;
using Scanner.App;
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;
using static Com.Toptoche.Searchablespinnerlibrary.SearchableListDialog;

namespace Scanner
{
    [Activity(Label = "TakeOverIdentEntryTablet", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class TakeOverIdentEntryTablet : Activity, IBarcodeResult, IOnSearchTextChanged, IDialogInterfaceOnClickListener

    {
        private int displayedPosition;
        private bool preventingDups = false;
        private NameValueObject moveHead = (NameValueObject)InUseObjects.Get("MoveHead"); // Revision 5.07.2021
        private NameValueObject openIdent = null;
        private NameValueObjectList openOrders = null;
        private int displayedOrder = -1;
        Button btScan;
        public string barcode;
        private EditText tbIdent;
        private EditText tbNaziv;
        private EditText tbOrder;
        private EditText tbConsignee;
        private EditText tbDeliveryDeadline;
        private EditText tbQty;
        private TextView lbOrderInfo;
        private Button btNext;
        private Button btConfirm;
        private Button button4;
        private Button button5;
        private List<string> identData = new List<string>();
        private ListView listData;
        private List<TakeOverIdentList> data = new List<TakeOverIdentList>();
        SoundPool soundPool;
        int soundPoolId;
        public NameValueObject order;
        public string openQty;
        private int selectedItem= -1;
        public int selected = -1;
        private SearchableSpinner spinnerIdent;
        private List<string> returnList;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.TakeOverIdentEntryTablet);
            Toast.MakeText(this, "Nalagam seznam", ToastLength.Long).Show();
            tbIdent = FindViewById<EditText>(Resource.Id.tbIdent);
            tbNaziv = FindViewById<EditText>(Resource.Id.tbNaziv);
            tbOrder = FindViewById<EditText>(Resource.Id.tbOrder);
            tbConsignee = FindViewById<EditText>(Resource.Id.tbConsignee);
            tbDeliveryDeadline = FindViewById<EditText>(Resource.Id.tbDeliveryDeadline);
            tbQty = FindViewById<EditText>(Resource.Id.tbQty);
            lbOrderInfo = FindViewById<TextView>(Resource.Id.lbOrderInfo);
            btConfirm = FindViewById<Button>(Resource.Id.btConfirm);
            button4 = FindViewById<Button>(Resource.Id.button4);
            button5 = FindViewById<Button>(Resource.Id.button5);
            listData = FindViewById<ListView>(Resource.Id.listData);
            TakeOverIdentAdapter adapter = new TakeOverIdentAdapter(this, data);
            listData.Adapter = adapter;
            color();
            soundPool = new SoundPool(10, Stream.Music, 0);
            soundPoolId = soundPool.Load(this, Resource.Drawable.beep, 1);
            Barcode2D barcode2D = new Barcode2D();
            barcode2D.open(this, this);
            tbIdent.FocusChange += TbIdent_FocusChange;
            if (moveHead == null) { throw new ApplicationException("moveHead not known at this point!?"); }
            displayedOrder = 0;
            FillDisplayedOrderInfo();
            btNext = FindViewById<Button>(Resource.Id.btNext);
            btNext.Click += BtNext_Click;
            // uvWMSOpenOrder
            btConfirm.Click += BtConfirm_Click;
            button4.Click += Button4_Click;
            button5.Click += Button5_Click;
            listData.ItemClick += ListData_ItemClick;


            identData = await MakeTheApiCallForTheIdentData();
            Toast.MakeText(this, "Seznam pripravljen.", ToastLength.Long).Show();

            spinnerIdent = FindViewById<SearchableSpinner>(Resource.Id.spinnerIdent); // identdata -> Object
            spinnerIdent.Prompt = "Iskanje";
            spinnerIdent.SetTitle("Iskanje");
            spinnerIdent.SetPositiveButton("Zapri");
            var DataAdapter = new ArrayAdapter<string>(this,
            Android.Resource.Layout.SimpleSpinnerItem, identData);
            // Change the search title. HERE
            DataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerIdent.Adapter = DataAdapter;
            // The part for spinner selected index changed.
            spinnerIdent.ItemSelected += SpinnerIdent_ItemSelected;
            
            tbIdent.LongClick += ClearTheFields;
           
        }

     

        public async void OnSearchTextChanged(string p0)
        {
            var test = p0;
           

        }
        private void ClearTheFields(object sender, View.LongClickEventArgs e)
        {
            tbIdent.Text = "";
            tbNaziv.Text = "";
           
        }

        private void SpinnerIdent_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {           
            var item = e.Position;          
            var chosen = identData.ElementAt(item);
            if (chosen != "")
            {
                tbIdent.Text = chosen;
            }
            ProcessIdent();
        }

       

        /// <summary>
        ///  Make async.
        /// </summary>
        /// <returns></returns>
        private async Task <List<string>> MakeTheApiCallForTheIdentData()
        {
            await Task.Run(() =>
            {
                returnList = new List<string>();
                // Call the API.
                string error;
                var idents = Services.GetObjectList("id", out error, "");

                idents.Items.ForEach(x =>
                {
                    returnList.Add(x.GetString("Code"));
                });

          
            });
            return returnList;
        }

        private void BtNext_Click1(object sender, EventArgs e)
        {

            displayedPosition++;
            if (displayedOrder >= openOrders.Items.Count) { displayedOrder = 0; }

            FillDisplayedOrderInfoSelect();


            // Change the highlight position.
            listData.RequestFocusFromTouch();
            listData.SetItemChecked(displayedPosition, true);
            listData.SetSelection(displayedPosition);
        }

        private void ListData_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            selected = e.Position;
            Select(selected);
            selectedItem = selected;
        }

     


        private void Select(int postionOfTheItemInTheList)
        {

            displayedOrder = postionOfTheItemInTheList;
        
            FillDisplayedOrderInfoSelect();
        }

        private void TbIdent_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
             // Preventing duplicate list filling with idents.
            ProcessIdent();
            OnSearchTextChanged(tbIdent.Text);

        }
        private string LoadStockFromStock(string warehouse, string ident)
        {
            try
            {
                string error;
                var stock = Services.GetObjectList("str", out error, warehouse + "|" + ident);
                if (stock == null)
                {
                    string WebError = string.Format("Napaka pri preverjanju zaloge." + error);
                    Toast.MakeText(this, WebError, ToastLength.Long).Show(); tbIdent.Text = "";
                    return "";
                }
                else
                {
                    return string.Join("\r\n", stock.Items.Select(x => "L:" + x.GetString("Location") + " = " + x.GetDouble("RealStock").ToString(CommonData.GetQtyPicture())).ToArray());
                }
            }
            finally
            {
             
            }
        }
       

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Finish();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(TakeOverEnteredPositionsViewTablet));
            HelpfulMethods.clearTheStack(this);
        }

        private void BtConfirm_Click(object sender, EventArgs e)
        {
            if (SaveMoveHead())
            {
                StartActivity(typeof(TakeOverSerialOrSSCCEntryTablet));
                HelpfulMethods.clearTheStack(this);
            }
        }

        private void BtNext_Click(object sender, EventArgs e)
        {
            selected++;
            if (openOrders != null) {
                if (selected <= (openOrders.Items.Count - 1))
                {
                    listData.RequestFocusFromTouch();
                    listData.SetSelection(selected);
                    listData.SetItemChecked(selected, true);
                }
                else
                {
                    selected = 0;
                    listData.RequestFocusFromTouch();
                    listData.SetSelection(selected);
                    listData.SetItemChecked(selected, true);
                }
                displayedOrder++;
                if (displayedOrder >= openOrders.Items.Count) { displayedOrder = 0; }
                FillDisplayedOrderInfo(); 
            }
        }


        private bool SaveMoveHead()
        {
            if (!moveHead.GetBool("Saved"))
            {

                try
                {


                    NameValueObject order;
                    if ((openOrders == null) || (openOrders.Items.Count == 0))
                    {
                        order = new NameValueObject("OpenOrder");
                        InUseObjects.Set("OpenOrder", order);
                    }
                    else
                    {
                        order = openOrders.Items[displayedOrder];
                        InUseObjects.Set("OpenOrder", order);
                    }

                    moveHead.SetInt("Clerk", Services.UserID());
                    moveHead.SetString("Type", "I");
                    moveHead.SetString("LinkKey", order.GetString("Key"));
                    moveHead.SetString("LinkNo", order.GetString("No"));
                    moveHead.SetString("Document1", order.GetString("Document1"));
                    moveHead.SetDateTime("Document1Date", order.GetDateTime("Document1Date"));
                    moveHead.SetString("Note", order.GetString("Note"));
                    if (moveHead.GetBool("ByOrder"))
                    {
                        moveHead.SetString("Receiver", order.GetString("Receiver"));
                    }

                    string error;
                    var savedMoveHead = Services.SetObject("mh", moveHead, out error);
                    if (savedMoveHead == null)
                    {
                        Toast.MakeText(this, "Napaka pri dostopu do web aplikacije" + error, ToastLength.Long).Show();
                        return false;
                    }
                    else
                    {
                        moveHead.SetInt("HeadID", savedMoveHead.GetInt("HeadID"));
                        moveHead.SetBool("Saved", true);
                        return true;
                    }
                }
                finally
                {

                }
            }
            else
            {
                return true;
            }
        }
        private void ProcessIdent()
        {
            var ident = tbIdent.Text.Trim();
            if (string.IsNullOrEmpty(ident)) { return; }


            try
            {


                string error;
                openIdent = Services.GetObject("id", ident, out error);
                if (openIdent == null)
                {
                    Toast.MakeText(this, "Napaka pri preverjanju identa" + error, ToastLength.Long).Show();

                    tbIdent.Text = "";
                    tbNaziv.Text = "";
                    tbQty.Text = "";
                    openOrders = null;
                }
                else
                {
                    ident = openIdent.GetString("Code");
                    tbIdent.Text = ident;
                    InUseObjects.Set("OpenIdent", openIdent);
                    
                    var isPackaging = openIdent.GetBool("IsPackaging");
                    if (!moveHead.GetBool("ByOrder") || isPackaging)
                    {
                        if (SaveMoveHead())
                        {
                            StartActivity(typeof(TakeOverSerialOrSSCCEntryTablet));
                            HelpfulMethods.clearTheStack(this);

                        }
                        return;
                    }
                    else
                    {
                        tbNaziv.Text = openIdent.GetString("Name");


                        openOrders = Services.GetObjectList("oo", out error, ident + "|" + moveHead.GetString("DocumentType") + "|" + moveHead.GetInt("HeadID"));
                        if (openOrders == null)
                        {
                            // Napaka pri pridobivanju odprtih naročil: " + error
                            Toast.MakeText(this, "Napaka pri pridobivanju odprtih naročil: " + error, ToastLength.Long).Show();


                            tbIdent.Text = "";

                            tbNaziv.Text = "";
                        }
                        else
                        {
                            InUseObjects.Set("openOrders", openOrders);
                            displayedOrder = 0;
                        }
                    }
                }
                FillDisplayedOrderInfo();
                fillList(tbIdent.Text);
            }
            finally
            {

            }
        }


        private void fillList(string ident)
        {
            if (preventingDups == false)
            {
                string error;
                var stock = Services.GetObjectList("str", out error, moveHead.GetString("Wharehouse") + "||" + tbIdent.Text);
                //  var openOrder = Services.GetObjectList("oo", out error, tbIdent.Text + "|" + moveHead.GetString("DocumentType") + "|" + moveHead.GetInt("HeadID"));
                if (openOrders != null)
                {
                    openOrders.Items.ForEach(x =>
                    {
                        data.Add(new TakeOverIdentList
                        {
                            Ident = tbIdent.Text,
                            Name = x.GetString("Name").Trim().Substring(0, 10),
                            Open = x.GetDouble("OpenQty").ToString(CommonData.GetQtyPicture()),
                            Ordered = x.GetDouble("FullQty").ToString(CommonData.GetQtyPicture()),
                            Received = (x.GetDouble("FullQty") - x.GetDouble("OpenQty")).ToString(CommonData.GetQtyPicture())
                        }); ;
                    });
                    preventingDups = true;
                }

                else
                {
                    Toast.MakeText(this, "Ni padatkov." + error, ToastLength.Long).Show();
                }
            } else
            {
                // pass
            }
        }
        private void FillDisplayedOrderInfo()
        {
            if ((openIdent != null) && (openOrders != null) && (openOrders.Items.Count > 0))
            {
                lbOrderInfo.Text = "Naročilo (" + (displayedOrder + 1).ToString() + "/" + openOrders.Items.Count.ToString() + ")";
                order = openOrders.Items[displayedOrder];
                InUseObjects.Set("OpenOrder", order);
                tbOrder.Text = order.GetString("Key");
                tbConsignee.Text = order.GetString("Consignee");
                tbQty.Text = order.GetDouble("OpenQty").ToString(CommonData.GetQtyPicture());
               
                var deadLine = order.GetDateTime("DeliveryDeadline");
                tbDeliveryDeadline.Text = deadLine == null ? "" : ((DateTime)deadLine).ToString("dd.MM.yyyy");
                string error;
                var stock = Services.GetObjectList("str", out error, moveHead.GetString("Wharehouse") + "||" + tbIdent.Text);
                btConfirm.Enabled = true;

                tbOrder.Enabled = false;
                tbConsignee.Enabled = false;
                tbQty.Enabled = false;
                tbDeliveryDeadline.Enabled = false;
            }
            else
            {
                InUseObjects.Invalidate("OpenOrder");
                lbOrderInfo.Text = "Naročilo (ni postavk)";
                tbOrder.Text = "";
                tbConsignee.Text = "";
                tbQty.Text = "";
                tbDeliveryDeadline.Text = "";
                btConfirm.Enabled = false;
            }
        }

        private void FillDisplayedOrderInfoSelect()
        {
            if ((openIdent != null) && (openOrders != null) && (openOrders.Items.Count > 0))
            {
                lbOrderInfo.Text = "Naročilo (" + (displayedOrder + 1).ToString() + "/" + openOrders.Items.Count.ToString() + ")";
                order = openOrders.Items[displayedOrder];
                InUseObjects.Set("OpenOrder", order);
                tbOrder.Text = order.GetString("Key");
                tbConsignee.Text = order.GetString("Consignee");
                tbQty.Text = order.GetDouble("OpenQty").ToString(CommonData.GetQtyPicture());
                var deadLine = order.GetDateTime("DeliveryDeadline");
                tbDeliveryDeadline.Text = deadLine == null ? "" : ((DateTime)deadLine).ToString("dd.MM.yyyy");
                string error;
                var stock = Services.GetObjectList("str", out error, moveHead.GetString("Wharehouse") + "||" + tbIdent.Text);
                btConfirm.Enabled = true;
                tbOrder.Enabled = false;
                tbConsignee.Enabled = false;
                tbQty.Enabled = false;
                tbDeliveryDeadline.Enabled = false;
            }
            else
            {
                InUseObjects.Invalidate("OpenOrder");
                lbOrderInfo.Text = "Naročilo (ni postavk)";
                tbOrder.Text = "";
                tbConsignee.Text = "";
                tbQty.Text = "";
                tbDeliveryDeadline.Text = "";
                btConfirm.Enabled = false;
            }
        }


        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if (requestCode == 2)
            {
                if (resultCode == Result.Ok)
                {
                    Toast.MakeText(this, data.Data.ToString(), ToastLength.Long).Show();
                    barcode = data.Data.ToString();
                    tbIdent.Text = barcode; // change this later...
                }
                else
                {
                    Toast.MakeText(this, "Napačno branje", ToastLength.Long).Show();
                }
            }
        }

        public void GetBarcode(string barcode)
        {
            if (tbIdent.HasFocus)
            {
                Sound();
                tbIdent.Text = barcode;
                ProcessIdent();
            }
        }

        private void Sound()
        {
            soundPool.Play(soundPoolId, 1, 1, 0, 0, 1);
        }


        // color
        private void color()
        {
            tbIdent.SetBackgroundColor(Android.Graphics.Color.Aqua);
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // in smartphone
       

                case Keycode.F3:
                    if (btConfirm.Enabled == true)
                    {
                        BtConfirm_Click(this, null);

                    }
                    break;


                case Keycode.F4:
                    if (button4.Enabled == true)
                    {
                        Button4_Click(this, null);
                    }
                    break;

                case Keycode.F9:
                    if (button5.Enabled == true)
                    {
                        Button5_Click(this, null);
                    }
                    break;

            }
            return base.OnKeyDown(keyCode, e);
        }

        public void OnClick(IDialogInterface dialog, int which)
        {
            throw new NotImplementedException();
        }
    }
}