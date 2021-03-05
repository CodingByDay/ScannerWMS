using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;
using WebApp = TrendNET.WMS.Device.Services.WebApp;

namespace ScannerQR
{
    [Activity(Label = "RapidTakeover", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class RapidTakeover : Activity, IBarcodeResult
    {
        private EditText tbSSCC;
        private Spinner cbWarehouses;
        private EditText tbLocation;
        private Button btConfirm;
        private Button btLogout;
        private EditText tbIdent;
        private List<ComboBoxItem> data = new List<ComboBoxItem>();
        private EditText tbReceiveLocation;
        private EditText tbRealStock;
        public static NameValueObject dataItem;
        private NameValueObject moveHead = (NameValueObject)InUseObjects.Get("MoveHead");
        private NameValueObject moveItem = (NameValueObject)InUseObjects.Get("MoveItem");
        private NameValueObject moveItemFinal;

        public void GetBarcode(string barcode)
        {
          //
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RapidTakeover);
            tbIdent = FindViewById<EditText>(Resource.Id.tbIdent);
            // Create your application here
            tbSSCC = FindViewById<EditText>(Resource.Id.tbSSCC);
            cbWarehouses = FindViewById<Spinner>(Resource.Id.cbWarehouses);
            tbLocation = FindViewById<EditText>(Resource.Id.tbLocation);
            btConfirm = FindViewById<Button>(Resource.Id.btConfirm);
            btLogout = FindViewById<Button>(Resource.Id.btLogout);
            tbReceiveLocation = FindViewById<EditText>(Resource.Id.tbReceiveLocation);
            tbRealStock = FindViewById<EditText>(Resource.Id.tbRealStock);
            btConfirm.Click += BtConfirm_Click;
            tbReceiveLocation.Enabled = false;
            tbRealStock.Enabled = false;
            tbIdent.Enabled = false;
            tbLocation.FocusChange += TbLocation_FocusChange;
            color();


            var whs = CommonData.ListWarehouses();

            whs.Items.ForEach(wh =>
            {
                data.Add(new ComboBoxItem { ID = wh.GetString("Subject"), Text = wh.GetString("Name") });
            });

            var adapterWarehouse = new ArrayAdapter<ComboBoxItem>(this,
            Android.Resource.Layout.SimpleSpinnerItem, data);
            adapterWarehouse.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            cbWarehouses.Adapter = adapterWarehouse;

            cbWarehouses.ItemSelected += CbWarehouses_ItemSelected;
        }

        private void BtConfirm_Click(object sender, EventArgs e)
        {

            if (saveHead())
            {

                try
                {

                    var headID = moveHead.GetInt("HeadID");

                    string result;
                    if (WebApp.Get("mode=finish&stock=add&print=" + Services.DeviceUser() + "&id=" + headID.ToString(), out result))
                    {
                        if (result.StartsWith("OK!"))
                        {
                            var id = result.Split('+')[1];
                            Toast.MakeText(this, "Zaključevanje uspešno! Št. prevzema:\r\n" + id, ToastLength.Long).Show();
                            AlertDialog.Builder alert = new AlertDialog.Builder(this);
                            alert.SetTitle("Zaključevanje uspešno");
                            alert.SetMessage("Zaključevanje uspešno! Št.prevzema:\r\n" + id);

                            alert.SetPositiveButton("Ok", (senderAlert, args) =>
                            {
                                alert.Dispose();
                            });



                            Dialog dialog = alert.Create();
                            dialog.Show();

                        }
                        else
                        {
                            Toast.MakeText(this, "Napaka pri zaključevanju: " + result, ToastLength.Long).Show();

                        }
                    }
                    else
                    {
                        Toast.MakeText(this, "Napaka pri klicu web aplikacije: " + result, ToastLength.Long).Show();

                    }
                }
                finally
                {

                }

            }
        }


        private bool saveHead()
        {
           
       
            {
                string ssscError;
                var data = Services.GetObject("sscc", tbSSCC.Text, out ssscError);
                string error;
                var currentItem = Services.GetObject("id", data.GetString("Ident"), out error);


                if (moveItem == null) { moveItem = new NameValueObject("MoveItem"); }

                moveItem.SetInt("HeadID", currentItem.GetInt("HeadID"));
                moveItem.SetString("LinkKey", "");
                moveItem.SetInt("LinkNo", 0);
                moveItem.SetString("Ident", data.GetString("Ident"));
                moveItem.SetString("SSCC", data.GetString("SSCC"));
                moveItem.SetString("SerialNo", data.GetString("SerialNo"));
                moveItem.SetDouble("Packing", Convert.ToDouble(data.GetDouble("RealStock")));
                moveItem.SetDouble("Qty", Convert.ToDouble(data.GetDouble("RealStock")));
                moveItem.SetInt("Clerk", Services.UserID());
                moveItem.SetString("Location", tbLocation.Text.Trim());
                moveItem.SetString("IssueLocation", data.GetString("Location"));

                string error2;
                moveItemFinal = Services.SetObject("mi", moveItem, out error2); /* Save move item method */

                Toast.MakeText(this, moveItemFinal.ToString(), ToastLength.Long).Show();
               
                    InUseObjects.Invalidate("MoveItem");
                    return true;
                }    
        }

        private void TbLocation_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            ProcessSSCC();
        }

        private void CbWarehouses_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
           ////////////////
        }

        private void ProcessSSCC()
        {
            var sscc = tbSSCC.Text.Trim();
            if (string.IsNullOrEmpty(sscc)) { return; }


            try
            {


                string error;
                 dataItem = Services.GetObject("sscc", tbSSCC.Text, out error);
                if (dataItem == null)
                {
                    Toast.MakeText(this, "Napaka pri preverjanju sscc kode." + error, ToastLength.Long).Show();

                    tbSSCC.Text = "";
                    
                }
                else
                {
                    tbIdent.Text = dataItem.GetString("Ident");
                    tbReceiveLocation.Text = dataItem.GetString("Location");
                    tbRealStock.Text = dataItem.GetDouble("RealStock").ToString();
                                                   
                }
            
            }
            finally
            {

            }

        }

        // string error;

        // var data = Services.GetObject("sscc", tbSSCC.Text, out error);

        // var ident = data.GetString("Ident");
        // Toast.MakeText(this, "Ident je: " + ident, ToastLength.Long).Show();


        private void color()
        {

            tbSSCC.SetBackgroundColor(Android.Graphics.Color.Aqua);
        }
    }
}