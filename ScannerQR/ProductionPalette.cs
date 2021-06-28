using Android.App;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using Android.Views;
using Android.Widget;
using BarCode2D_Receiver;
using Scanner.App;
using System;
using System.Collections.Generic;
using System.Linq;
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;
using static Android.App.ActionBar;

namespace Scanner
{
    [Activity(Label = "ProductionPalette", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ProductionPalette : Activity, IBarcodeResult

    {
        private EditText cardNumber;
        private EditText tbWorkOrder;
        private EditText tbIdent;
        private EditText tbSSCC;
        private EditText tbSerialNum;

        private ListView lvCardList;
        SoundPool soundPool;
        int soundPoolId;
        private Button btConfirm;
         private Button button2;
        private NameValueObject cardInfo = (NameValueObject)InUseObjects.Get("CardInfo");
        private double totalQty = 0.0;
        private List<ListViewItem> listItems = new List<ListViewItem>();
        private Dialog popupDialog;
        private Button btnYes;
        private Button btnNo;
        private TextView lbTotalQty;
        private bool result;
        private bool target;

        public void GetBarcode(string barcode)
        {
            if (tbSerialNum.HasFocus) {
                if (barcode != "Scan fail")
                {
                    Sound();
                    tbSerialNum.Text = barcode;
                    ProcessSerialNum();
                    lvCardList.RequestFocus();
                } else
                {
                    tbSerialNum.Text = "";
                }

            } else if(cardNumber.HasFocus)
            {
                Sound();
                ProcessCard(barcode);
            }
        }



        private void color()
        {
            tbSerialNum.SetBackgroundColor(Android.Graphics.Color.Aqua);
            cardNumber.SetBackgroundColor(Android.Graphics.Color.Aqua);

        }
        private void ProcessSerialNum()
        {
  
      
            try
            {
                string error;
                var cardObj = Services.GetObject("cq", tbSerialNum.Text + "|1|" + tbIdent.Text, out error);
                if (cardObj == null)
                {
                    string WebError = string.Format("Napaka pri preverjanju serijske št.: " + error);
                    Toast.MakeText(this, WebError, ToastLength.Long).Show();
    
                    return;
                }

                var qty = cardObj.GetDouble("Qty");
                if (qty > 0)
                {
                    tbSerialNum.Enabled = false;
                    lvCardList.Enabled = true;
                    lvCardList.RequestFocus();
                }
                else
                {
                    string WebError = string.Format("Serijska št. nima pripravljenih kartonov.");
                    Toast.MakeText(this, WebError, ToastLength.Long).Show();

                    return;
                }
            }
            finally
            {
                //
            }
        }

        // potential problem

        private IEnumerable<int> ScannedCardNumbers()
        {
            foreach (ListViewItem lvi in listItems)
            {
                yield return Convert.ToInt32(lvi.stKartona);
            }
        }


        private void Sound()
        {
            soundPool.Play(soundPoolId, 1, 1, 0, 0, 1);
        }

        private void ProcessCard(string data)
        {
            if (!data.StartsWith(tbSerialNum.Text))
            {
                string WebError = string.Format("Karton ne ustreza serijski št. palete!");
                Toast.MakeText(this, WebError, ToastLength.Long).Show();
      
            }
            else
            {
                var stKartona = Convert.ToInt32(data.Substring(tbSerialNum.Text.Length)).ToString();

                foreach (ListViewItem existing in listItems)
                {
                    if (existing.stKartona == stKartona)
                    {
                        string WebError = string.Format("Karton je že dodan na paleto!");
                        Toast.MakeText(this, WebError, ToastLength.Long).Show();
 
                        return;
                    }
                }

          
             
                try
                {
                    string error;
                    var cardObj = Services.GetObject("cq", tbSerialNum.Text + "|" + stKartona + "|" + tbIdent.Text, out error);
                    if (cardObj == null)
                    {
                        string WebError = string.Format("Napaka pri preverjanju kartona: " + error);
                        Toast.MakeText(this, WebError, ToastLength.Long).Show();
 
                        return;
                    }

                    var qty = cardObj.GetDouble("Qty");
                    if (qty > 0.0)
                    {
                        if (cardObj.GetInt("IDHead") > 0)

                        { 
                            /// Custom popup method that is connected to transportYesNo popus same functionality like before. 

                            if(!popupResponse())

                                // Potential problem.
                            {
                                return;
                            }
                           
                        }

                        
                        var ivi = new ListViewItem { stKartona = stKartona, quantity = qty.ToString("###,###,##0.00") };
                        listItems.Add(ivi);
                        totalQty += qty;
                        lbTotalQty.Text = "Količina skupaj: " + totalQty.ToString("###,###,##0.00");

                        btConfirm.Enabled = true;
                    }
                    else
                    {
                        string WebError = string.Format("Neveljaven karton: " + data);
                        Toast.MakeText(this, WebError, ToastLength.Long).Show();

                        return;
                    }
                }
                finally
                {
                  
                }
            }
        }

        
        private bool deleteResponse()
        {
            popupDialog = new Dialog(this);
            popupDialog.SetContentView(Resource.Layout.YesNoGeneric);
            popupDialog.Window.SetSoftInputMode(SoftInput.AdjustResize);
            popupDialog.Show();

            popupDialog.Window.SetLayout(LayoutParams.MatchParent, LayoutParams.WrapContent);
            popupDialog.Window.SetBackgroundDrawableResource(Android.Resource.Color.HoloOrangeLight);
            btnYes = popupDialog.FindViewById<Button>(Resource.Id.btnYes);
            btnNo = popupDialog.FindViewById<Button>(Resource.Id.btnNo);

            btnNo.Click += BtnNo_Click1;
            btnYes.Click += BtnYes_Click1;



            return target;
        }

        private void BtnYes_Click1(object sender, EventArgs e)
        {
            target = true;
        }

        private void BtnNo_Click1(object sender, EventArgs e)
        {
            target = false;
        }

        private bool popupResponse()
           {
            popupDialog = new Dialog(this);
            popupDialog.SetContentView(Resource.Layout.TransportPopup);
            popupDialog.Window.SetSoftInputMode(SoftInput.AdjustResize);
            popupDialog.Show();

            popupDialog.Window.SetLayout(LayoutParams.MatchParent, LayoutParams.WrapContent);
            popupDialog.Window.SetBackgroundDrawableResource(Android.Resource.Color.HoloOrangeLight);
            btnYes = popupDialog.FindViewById<Button>(Resource.Id.btnYes);
            btnNo = popupDialog.FindViewById<Button>(Resource.Id.btnNo);

            btnNo.Click += BtnNo_Click;
            btnYes.Click += BtnYes_Click;

            return result;
        }

        private void BtnYes_Click(object sender, EventArgs e)
        {
            result = true;
            
        }

        private void BtnNo_Click(object sender, EventArgs e)
        {
            result = false;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ProductionPalette);
            // Button name------------------>productionserial


            tbWorkOrder = FindViewById<EditText>(Resource.Id.tbWorkOrder);
            tbIdent = FindViewById<EditText>(Resource.Id.tbIdent);
            tbSSCC = FindViewById<EditText>(Resource.Id.tbSSCC);
            tbSerialNum = FindViewById<EditText>(Resource.Id.tbSerialNum);

            lvCardList = FindViewById<ListView>(Resource.Id.lvCardList);
            cardNumber = FindViewById<EditText>(Resource.Id.cardNumber);
            btConfirm = FindViewById<Button>(Resource.Id.btConfirm);
            button2 = FindViewById<Button>(Resource.Id.button2);
            lbTotalQty = FindViewById<TextView>(Resource.Id.lbTotalQty);
            tbWorkOrder.Text = cardInfo.GetString("WorkOrder").Trim();
            tbIdent.Text = cardInfo.GetString("Ident").Trim();
            tbSSCC.Text = CommonData.GetNextSSCC();
            soundPool = new SoundPool(10, Stream.Music, 0);
            soundPoolId = soundPool.Load(this, Resource.Drawable.beep, 1);
            Barcode2D barcode2D = new Barcode2D();
            barcode2D.open(this, this);
            btConfirm.Click += BtConfirm_Click;
            button2.Click += Button2_Click;
            cardNumber.FocusChange += CardNumber_FocusChange;
            adapterListViewItem adapter = new adapterListViewItem(this, listItems);

            lvCardList.Adapter = adapter;
            lvCardList.ItemLongClick += LvCardList_ItemLongClick;
            tbSerialNum.RequestFocus();
            color();
        }

        private void CardNumber_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            ProcessCard(cardNumber.Text);

        }

        private void LvCardList_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            if(deleteResponse())
            {
                listItems.RemoveAt(e.Position);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainMenu));
        }

        private void BtConfirm_Click(object sender, EventArgs e)
        {
    
 
            try
            {
                var palInfo = new NameValueObject("PaletteInfo");
                palInfo.SetString("WorkOrder", tbWorkOrder.Text);
                palInfo.SetString("Ident", tbIdent.Text);
                palInfo.SetInt("Clerk", Services.UserID());
                palInfo.SetString("SerialNum", tbSerialNum.Text);
                palInfo.SetString("SSCC", tbSSCC.Text);
                palInfo.SetString("CardNums", string.Join(",", ScannedCardNumbers().Select(x => x.ToString()).ToArray()));
                palInfo.SetDouble("TotalQty", totalQty);
                palInfo.SetString("DeviceID", Services.DeviceUser());

                string error;
                palInfo = Services.SetObject("cf", palInfo, out error);
                if (palInfo == null)
                {
                    string WebError = string.Format("Napaka pri potrjevanju palete: " + error);
                    Toast.MakeText(this, WebError, ToastLength.Long).Show();

                }
                else
                {
                    var result = palInfo.GetString("Result");
                    if (result.StartsWith("OK!"))
                    {
                        var id = result.Split('+')[1];
                        string WebError = string.Format("Paletiranje uspešno! Št. prevzema:\r\n" + id);
                        Toast.MakeText(this, WebError, ToastLength.Long).Show();
       
   
                    }
                    else
                    {
                        string WebError = string.Format("Napaka pri paletiranju: " + result);
                        Toast.MakeText(this, WebError, ToastLength.Long).Show();
  
                    }
                }
            }
            finally
            {
             //pass
            }
        }
    }
}