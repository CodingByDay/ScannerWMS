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
        private EditText tbCard;
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
        private string stKartona;

        public void GetBarcode(string barcode)
        {
            if (tbSerialNum.HasFocus) {
                if (barcode != "Scan fail")
                {
                    Sound();
                    tbSerialNum.Text = barcode;
                    ProcessSerialNum();
                    tbCard.RequestFocus();
                 
                } else
                {
                    tbSerialNum.Text = "";
                }

            } else if(tbCard.HasFocus)
            {
                if (barcode != "")
                {
                    if (barcode != "Scan fail")
                    {
                        Sound();
                        ProcessCard(barcode);
                    } else
                    {

                    }
                } else
                {

                }
            }
        }



        private void color()
        {
            tbSerialNum.SetBackgroundColor(Android.Graphics.Color.Aqua);
            tbCard.SetBackgroundColor(Android.Graphics.Color.Aqua);

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
                    Toast.MakeText(this, $"Obstaja {qty} kartonov.", ToastLength.Long).Show();
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
                
            }
        }


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

        private async void ProcessCard(string data)
        {

            try
            {
                stKartona = Convert.ToInt32(data.Substring(tbSerialNum.Text.Length)).ToString();
            } catch(Exception error)
            {
                Toast.MakeText(this, "Napaka...", ToastLength.Long).Show();
            }

            if (stKartona != null)
            {
                var next = true;
                if (!data.StartsWith(tbSerialNum.Text))
                {
                    string WebError = string.Format("Karton ne ustreza serijski številki.");
                    Toast.MakeText(this, WebError, ToastLength.Long).Show();
                }
                else
                {

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
                                result = (bool)await  DialogAsync.Show(this, "Vprašanje", "Karton je že rasporejen na drugi paleti. Premestim?");

                              
                            }
                            if (result == false)

                            {
                                return;
                            }
                            else { 

                            var ivi = new ListViewItem { stKartona = stKartona, quantity = qty.ToString("###,###,##0.00") };
                            listItems.Add(ivi);
                            lvCardList.Adapter = null;
                            adapterListViewItem adapter = new adapterListViewItem(this, listItems);
                            lvCardList.Adapter = adapter;
                            totalQty += qty;
                            lbTotalQty.Text = "Količina skupaj: " + totalQty.ToString("###,###,##0.00");
                            btConfirm.Enabled = true;
                                }
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
                        tbCard.Text = "";
                    }
                }
            }else
            {
                Toast.MakeText(this, "Nepravilen vnos.", ToastLength.Long).Show();
            }
        }

        //                listItems.RemoveAt(e.Position);

  

    

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.ProductionPalette);
            tbWorkOrder = FindViewById<EditText>(Resource.Id.tbWorkOrder);
            tbIdent = FindViewById<EditText>(Resource.Id.tbIdent);
            tbSSCC = FindViewById<EditText>(Resource.Id.tbSSCC);
            tbSerialNum = FindViewById<EditText>(Resource.Id.tbSerialNum);
            lvCardList = FindViewById<ListView>(Resource.Id.lvCardList);
            tbCard = FindViewById<EditText>(Resource.Id.tbCard);
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
            adapterListViewItem adapter = new adapterListViewItem(this, listItems);
            lvCardList.Adapter = adapter;
            lvCardList.ItemLongClick += LvCardList_ItemLongClick;
            tbSerialNum.RequestFocus();
            tbSerialNum.KeyPress += TbSerialNum_KeyPress;
            tbCard.KeyPress += TbCard_KeyPress;
            color();
        }

        private void TbCard_KeyPress(object sender, View.KeyEventArgs e)
        {
            if (e.KeyCode == Keycode.Enter)
            {
                if (tbCard.Text != "")
                {
                    ProcessCard(tbCard.Text);
                    tbCard.RequestFocus();
                } else
                {

                }
            }
            else
            {
                e.Handled = false;
            }
        }

        private void TbSerialNum_KeyPress(object sender, View.KeyEventArgs e)
        {
            if (e.KeyCode == Keycode.Enter)
            {
                ProcessSerialNum();
                tbCard.RequestFocus();
            }
            else
            {
                e.Handled = false;
            }
        }

   

        private void LvCardList_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {

            popupDialog = new Dialog(this);
            popupDialog.SetContentView(Resource.Layout.YesNoGeneric);
            popupDialog.Window.SetSoftInputMode(SoftInput.AdjustResize);
            popupDialog.Show();
            popupDialog.Window.SetLayout(LayoutParams.MatchParent, LayoutParams.WrapContent);
            popupDialog.Window.SetBackgroundDrawableResource(Android.Resource.Color.HoloOrangeLight);
            btnYes = popupDialog.FindViewById<Button>(Resource.Id.btnYes);
            btnNo = popupDialog.FindViewById<Button>(Resource.Id.btnNo);
            btnNo.Click += BtnNo_Click;
            btnYes.Click += (e, ev) => { ButtonYes(lvCardList.SelectedItemId); };
          
        }

        private void ButtonYes(long selectedItemId)
        {
            listItems.RemoveAt((int)selectedItemId);
            popupDialog.Dismiss();
            popupDialog.Cancel();

        }

        private void BtnNo_Click(object sender, EventArgs e)
        {
            popupDialog.Dismiss();
            popupDialog.Cancel();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainMenu));
        }

        private void BtConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                string[] data = ScannedCardNumbers().Select(x => x.ToString()).ToArray();
                foreach(string s in data)
                {
                    var t = s;
                    var debug = true;
                }
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
            }
        }
    }
}