using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BarCode2D_Receiver;
using ScannerQR.App;
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;

namespace ScannerQR
{
    [Activity(Label = "ProductionPalette")]
    public class ProductionPalette : Activity, IBarcodeResult

    {
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
        private List<ListViewItem> listItems;
        public void GetBarcode(string barcode)
        {
            if (tbSerialNum.HasFocus) {
                Sound();
                tbSerialNum.Text = barcode;

            } else if(lvCardList.HasFocus)
            {
                Sound();
                ProcessCard(barcode);
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

                foreach (ListViewItem existing in lvCardList.Items)
                {
                    if (existing.SubItems[0].Text == stKartona)
                    {
                        string WebError = string.Format("Karton je že dodan na paleto!");
                        Toast.MakeText(this, WebError, ToastLength.Long).Show();
 
                        return;
                    }
                }

          
                wf.Start("Preverjam karton...");
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
                            if (!YesNoForm.Show("Karton je že razporejen na drugi paleti. Premestim?"))
                            {
                                return;
                            }
                        }

                        var lvi = new ListViewItem(new string[] { stKartona, qty.ToString("###,###,##0.00") });
                        lvCardList.Items.Add(lvi);

                        totalQty += qty;
                        lbTotalQty.Text = "Količina skupaj: " + totalQty.ToString("###,###,##0.00");

                        btConfirm.Enabled = true;
                    }
                    else
                    {
                        MessageForm.Show("Neveljaven karton: " + data);
                        return;
                    }
                }
                finally
                {
                    wf.Stop();
                }
            }
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

            btConfirm = FindViewById<Button>(Resource.Id.btConfirm);
            button2 = FindViewById<Button>(Resource.Id.button2);

            tbWorkOrder.Text = cardInfo.GetString("WorkOrder").Trim();
            tbIdent.Text = cardInfo.GetString("Ident").Trim();
            tbSSCC.Text = CommonData.GetNextSSCC();
            soundPool = new SoundPool(10, Stream.Music, 0);
            soundPoolId = soundPool.Load(this, Resource.Drawable.beep, 1);
            Barcode2D barcode2D = new Barcode2D();
            barcode2D.open(this, this);


            adapter adapter = new adapter(this, listItems);
        }

    
    }
}