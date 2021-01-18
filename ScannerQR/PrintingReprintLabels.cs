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
using ScannerQR.Printing;
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;

namespace ScannerQR
{
    [Activity(Label = "PrintingReprintLabels")]
    public class PrintingReprintLabels : Activity, IBarcodeResult
    {
        private EditText tbIdent;
        private EditText tbTitle;
        private EditText tbSSCC;
        private EditText tbSerialNum;
        private Spinner cbWarehouse;
        private EditText tbLocation;
        private EditText tbQty;
        private Spinner cbSubject;
        private NameValueObject stock = null;
        private Button btPrint;
        private Button button2;
        private List<ComboBoxItem> warehouseAdapter = new List<ComboBoxItem>();
        private List<ComboBoxItem> subjectsAdapter = new List<ComboBoxItem>();
        SoundPool soundPool;
        int soundPoolId;
        private int tempPositionSubject;
        private int tempPositionWarehouse;






        private void color()
        {

            tbIdent.SetBackgroundColor(Android.Graphics.Color.Aqua);
            tbSSCC.SetBackgroundColor(Android.Graphics.Color.Aqua);
            tbSerialNum.SetBackgroundColor(Android.Graphics.Color.Aqua);
            tbLocation.SetBackgroundColor(Android.Graphics.Color.Aqua);



        }


        public void GetBarcode(string barcode)
        {
            if(tbSSCC.HasFocus)
            {

                Sound();
                tbSSCC.Text = barcode;
                tbSerialNum.RequestFocus();
            } else if(tbIdent.HasFocus)
            {
                Sound();
                tbIdent.Text = barcode;
                ProcessIdent();
              
            } else if(tbSerialNum.HasFocus)
            {
                Sound();
                tbSerialNum.Text = barcode;
            } else if (tbLocation.HasFocus)
            {
                Sound();
                tbLocation.Text = barcode;
                ProcessQty();
                tbQty.RequestFocus();
            }
        }

        private void ProcessIdent()
        {
            var ident = tbIdent.Text.Trim();
            var identObj = CommonData.LoadIdent(ident);
            if (identObj != null)
            {
                tbTitle.Text = identObj.GetString("Name");
                tbSSCC.Enabled = identObj.GetBool("isSSCC");
                tbSerialNum.Enabled = identObj.GetBool("HasSerialNumber");
                tbSSCC.RequestFocus();
            }
            else
            {
                tbTitle.Text = "";
                tbSSCC.Enabled = false;
                tbSerialNum.Enabled = false;
                tbIdent.RequestFocus();
            }
        }
    

        private void Sound()
        {
            soundPool.Play(soundPoolId, 1, 1, 0, 0, 1);
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.PrintingReprintLabels);
            tbIdent = FindViewById<EditText>(Resource.Id.tbIdent);
            tbTitle = FindViewById<EditText>(Resource.Id.tbTitle);
            tbSSCC = FindViewById<EditText>(Resource.Id.tbSSCC);
            tbSerialNum = FindViewById<EditText>(Resource.Id.tbSerialNum);
            cbWarehouse = FindViewById<Spinner>(Resource.Id.cbWarehouse);
            tbLocation = FindViewById<EditText>(Resource.Id.tbLocation);
            tbQty = FindViewById<EditText>(Resource.Id.tbQty);
            cbSubject = FindViewById<Spinner>(Resource.Id.cbSubject);

            btPrint = FindViewById<Button>(Resource.Id.btPrint);
            button2 = FindViewById<Button>(Resource.Id.button2);
            soundPool = new SoundPool(10, Stream.Music, 0);
            soundPoolId = soundPool.Load(this, Resource.Drawable.beep, 1);
            color();
            Barcode2D barcode2D = new Barcode2D();
            barcode2D.open(this, this);
            tbTitle.FocusChange += TbTitle_FocusChange;
            btPrint.Click += BtPrint_Click;
            button2.Click += Button2_Click;
            tbSSCC.FocusChange += TbSSCC_FocusChange;
            cbWarehouse.ItemSelected += CbWarehouse_ItemSelected;
            cbSubject.ItemSelected += CbSubject_ItemSelected;
            var warehouses = CommonData.ListWarehouses();

            warehouses.Items.ForEach(w =>
            {
            warehouseAdapter.Add(new ComboBoxItem { ID = w.GetString("Subject"), Text = w.GetString("Name") });
            });

            var subjects = CommonData.ListReprintSubjects();

            subjects.Items.ForEach(s =>
            {
              subjectsAdapter.Add(new ComboBoxItem { ID = s.GetString("ID"), Text = s.GetString("ID") });
            });


            var adapterWarehouses = new ArrayAdapter<ComboBoxItem>(this,
           Android.Resource.Layout.SimpleSpinnerItem, warehouseAdapter);

            adapterWarehouses.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            cbWarehouse.Adapter = adapterWarehouses;




            var adapterSubjects = new ArrayAdapter<ComboBoxItem>(this,
                       Android.Resource.Layout.SimpleSpinnerItem, subjectsAdapter);

            adapterSubjects.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            cbSubject.Adapter = adapterWarehouses;


            tbIdent.RequestFocus();


        }

        private void TbTitle_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            ProcessIdent();
        }

        private void CbSubject_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            Spinner spinner = (Spinner)sender;
            string toast = string.Format("Izbrali ste: {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
            tempPositionSubject = e.Position;
        }

        private void CbWarehouse_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            Spinner spinner = (Spinner)sender;
            string toast = string.Format("Izbrali ste: {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
            tempPositionWarehouse = e.Position;
        }

        private bool LoadStock(string warehouse, string location, string sscc, string serialNum, string ident)
        {
           
            try
            {
   

                string error;
                stock = Services.GetObject("str", warehouse + "|" + location + "|" + sscc + "|" + serialNum + "|" + ident, out error);
                if (stock == null)
                {
                    string toast = string.Format("Napaka pri preverjanju zaloge: " + error);
                    Toast.MakeText(this, toast, ToastLength.Long).Show();
  
                    return false;
                }

                return true;
            }
            finally
            {
             
            }
        }


        private void ProcessQty()
        {
            btPrint.Enabled = false;

           var warehouse = warehouseAdapter.ElementAt(tempPositionWarehouse);
            if (warehouse == null) { return; }

            var sscc = tbSSCC.Text.Trim();
            if (tbSSCC.Enabled && string.IsNullOrEmpty(sscc)) { return; }

            var serialNo = tbSerialNum.Text.Trim();
            if (tbSerialNum.Enabled && string.IsNullOrEmpty(serialNo)) { return; }

            var ident = tbIdent.Text.Trim();
            if (string.IsNullOrEmpty(ident)) { return; }

            var identObj = CommonData.LoadIdent(ident);
            if (identObj != null)
            {
                ident = identObj.GetString("Code");
                tbIdent.Text = ident;
            }

            if (LoadStock(warehouse.ID, tbLocation.Text.Trim(), sscc, serialNo, ident))
            {
                tbQty.Text = stock.GetDouble("RealStock").ToString(CommonData.GetQtyPicture());
                btPrint.Enabled = true;
            }
            else
            {
                tbQty.Text = "";
            }

            tbQty.RequestFocus();
        }

        private void TbSSCC_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            ProcessIdent();
        }
        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // in smartphone
                case Keycode.F3:
                    if (btPrint.Enabled == true)
                    {
                        BtPrint_Click(this, null);
                    }
                    break;
                //return true;


                case Keycode.F8:
                    if (button2.Enabled == true)
                    {
                        Button2_Click(this, null);
                    }
                    break;


          



            }
            return base.OnKeyDown(keyCode, e);
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void BtPrint_Click(object sender, EventArgs e)
        {
            var qty = 0.0;
            try
            {
                qty = Convert.ToDouble(tbQty.Text);
            }
            catch (Exception ex)
            {
                string toast = string.Format("Količina ni pravilna! (" + ex.Message + ")");
                Toast.MakeText(this, toast, ToastLength.Long).Show();
       
                return;
            }

            if (qty <= 0.0)
            {
                string toast = string.Format("Količina mora biti pozitivna!");
                Toast.MakeText(this, toast, ToastLength.Long).Show();
      
                return;
            }

            if (CommonData.GetSetting("ReprintLabelsUseSubject") == "1")
            {
                if (cbSubject.SelectedItem == null)
                {
                    string toast = string.Format("Subjekt mora biti izbran!");
                    Toast.MakeText(this, toast, ToastLength.Long).Show();
     
                    return;
                }
            }

    
            try
            {
              
                var nvo = new NameValueObject("ReprintLabels");
                PrintingCommon.SetNVOCommonData(ref nvo);
                nvo.SetString("SSCC", tbSSCC.Text);
                nvo.SetString("SerialNum", tbSerialNum.Text);
                nvo.SetString("Location", tbLocation.Text);
                nvo.SetString("Ident", tbIdent.Text);
                nvo.SetString("Title", tbTitle.Text);
                nvo.SetDouble("Qty", qty);
                nvo.SetString("Subject", cbSubject.SelectedItem == null ? "" : subjectsAdapter.ElementAt(tempPositionSubject).ID);
                PrintingCommon.SendToServer(nvo);
        
            }
            finally
            {
                /// yayy :)
                string toast = string.Format("Poslani podatki.");
                Toast.MakeText(this, toast, ToastLength.Long).Show();
            }
  
        }
    }
}