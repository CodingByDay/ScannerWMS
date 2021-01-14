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
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;
using WebApp = TrendNET.WMS.Device.Services.WebApp;

namespace ScannerQR
{
    [Activity(Label = "TakeOverSerialOrSSCCEntry")]
    public class TakeOverSerialOrSSCCEntry : Activity, IBarcodeResult
    {
        private NameValueObject openIdent = (NameValueObject)InUseObjects.Get("OpenIdent");
        private NameValueObject openOrder = (NameValueObject)InUseObjects.Get("OpenOrder");
        private NameValueObject moveHead = (NameValueObject)InUseObjects.Get("MoveHead");
        private NameValueObject moveItem = (NameValueObject)InUseObjects.Get("MoveItem");
        private NameValueObjectList docTypes = null;
        // Janko Jovičić 2021 
        private bool editMode = false;
        private bool isPackaging = false;
        // Components definitions.
        private EditText tbIdent;
        private EditText tbSSCC;
        private EditText tbSerialNum;
        private EditText tbLocation;
        private EditText tbPacking;
        private EditText tbUnits;
        // Button definitions.
        private Button btSaveOrUpdate;
        private Button button4;
        private Button button6;
        private Button button5;
        private Button button7;
        private TextView lbQty;
        private TextView lbUnits;
        private Button button1;

        SoundPool soundPool;
        int soundPoolId;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here.
            SetContentView(Resource.Layout.TakeOverSerialOrSSCCEntry);
            // Find view by ID definitions.
            tbIdent = FindViewById<EditText>(Resource.Id.tbIdent);
            tbSSCC = FindViewById<EditText>(Resource.Id.tbSSCC);
            tbSerialNum = FindViewById<EditText>(Resource.Id.tbSerialNum);
            tbLocation = FindViewById<EditText>(Resource.Id.tbLocation);
            tbPacking = FindViewById<EditText>(Resource.Id.tbPacking);
            tbUnits = FindViewById<EditText>(Resource.Id.tbUnits);

            // Buttons.
            btSaveOrUpdate = FindViewById<Button>(Resource.Id.btSaveOrUpdate);
            button4 = FindViewById<Button>(Resource.Id.button4);
            button6 = FindViewById<Button>(Resource.Id.button6);
            button5 = FindViewById<Button>(Resource.Id.button5);
            button7 = FindViewById<Button>(Resource.Id.button7);
            lbQty = FindViewById<TextView>(Resource.Id.lbQty);
            lbUnits = FindViewById<TextView>(Resource.Id.lbUnits);
            button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += Button1_Click;
            soundPool = new SoundPool(10, Stream.Music, 0);
            soundPoolId = soundPool.Load(this, Resource.Drawable.beep, 1);
            Barcode2D barcode2D = new Barcode2D();
            barcode2D.open(this, this);
          
         

            btSaveOrUpdate.Click += BtSaveOrUpdate_Click;
            button4.Click += Button4_Click;
            button6.Click += Button6_Click;
            button7.Click += Button7_Click;
            button5.Click += Button5_Click;
            //
            //
            // Exceptions
            if (moveHead == null) { throw new ApplicationException("moveHead not known at this point?!"); }
            if (openIdent == null) { throw new ApplicationException("openIdent not known at this point?!"); }
            //
            //
            try
            {             

                string error = "N/A";
                if (openOrder == null)
                {
                    editMode = moveItem != null;
                    if ((moveItem == null) || string.IsNullOrEmpty(moveItem.GetString("LinkKey")))
                    {
                        openOrder = new NameValueObject("OpenOrder");
                    }
                    else
                    {
                        editMode = true;
                        openOrder = Services.GetObject("oobl", moveItem.GetString("LinkKey") + "|" + moveItem.GetInt("LinkNo").ToString(), out error);
                        if (openOrder == null)
                        {
                            Toast.MakeText(this, "Napaka pri dostopu do web aplikacije." + error, ToastLength.Long).Show();
                            System.Diagnostics.Process.GetCurrentProcess().Kill();
                            return;
                        }
                    }
                }

            }
            finally
            {
                Toast.MakeText(this, "Uspešno branje identa.", ToastLength.Long).Show();
            }
            // Next block.
            docTypes = CommonData.ListDocTypes("I|N");
            tbSSCC.Enabled = openIdent.GetBool("isSSCC");
            tbSerialNum.Enabled = openIdent.GetBool("HasSerialNumber");
            //
            if (moveItem != null)
            {
                tbIdent.Text = moveItem.GetString("IdentName");
                tbSerialNum.Text = moveItem.GetString("SerialNo");

                if (CommonData.GetSetting("ShowNumberOfUnitsField") == "1")
                {
                    tbPacking.Text = moveItem.GetDouble("Packing").ToString();
                    tbUnits.Text = moveItem.GetDouble("Factor").ToString();
                }
                else if (CommonData.GetSetting("ShowMorePrintsField") == "1")
                {
                    tbPacking.Text = moveItem.GetDouble("Qty").ToString();
                    tbUnits.Text = moveItem.GetDouble("MorePrints").ToString();
                }
                else
                {
                    tbPacking.Text = moveItem.GetDouble("Qty").ToString();
                }

                tbSSCC.Text = moveItem.GetString("SSCC");
                tbLocation.Text = moveItem.GetString("Location");
                btSaveOrUpdate.Text = "Spremeni serijsko št. - F2";
            }
            else
            {
                tbIdent.Text = openIdent.GetString("Code") + " " + openIdent.GetString("Name");
            }
            //
            lbQty.Text = "Količina (" + openOrder.GetDouble("OpenQty").ToString(CommonData.GetQtyPicture()) + ")";

            isPackaging = openIdent.GetBool("IsPackaging");
            if (isPackaging)
            {
                tbSSCC.Enabled = false;
                tbSerialNum.Enabled = false;
                //new Scanner(tbLocation);
                tbLocation.SetBackgroundColor(Android.Graphics.Color.Aqua);
                tbPacking.RequestFocus();
            }
            else
            {
                //if (tbSSCC.Enabled) { new Scanner(tbSSCC); }
                //new Scanner(tbSerialNum);
                //new Scanner(tbLocation);

                if (tbSSCC.Enabled) 
                { tbSSCC.SetBackgroundColor(Android.Graphics.Color.Aqua); }
                tbSerialNum.SetBackgroundColor(Android.Graphics.Color.Aqua);
                tbLocation.SetBackgroundColor(Android.Graphics.Color.Aqua);


                if (tbSSCC.Enabled)
                {
                    tbSSCC.RequestFocus();
                }
                else if (tbSerialNum.Enabled)
                {
                    tbSerialNum.RequestFocus();
                }
                else
                {
                    tbPacking.RequestFocus();
                }
            }
            if (tbSSCC.Enabled && (CommonData.GetSetting("AutoCreateSSCC") == "1"))
            {
                tbSSCC.Text = CommonData.GetNextSSCC();
               // SelectNext(tbSSCC);
            }

            if (string.IsNullOrEmpty(tbUnits.Text.Trim())) { tbUnits.Text = "1"; }
            if (CommonData.GetSetting("ShowNumberOfUnitsField") == "1")
            {
                lbUnits.Visibility = ViewStates.Invisible;
                tbUnits.Visibility = ViewStates.Invisible;
            }
            else if (CommonData.GetSetting("ShowMorePrintsField") == "1")
            {
                lbUnits.Text = "Koli";
                lbUnits.Visibility = ViewStates.Invisible;
                tbUnits.Visibility = ViewStates.Invisible;
            }

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(TakeOverEnteredPositionsView));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var qty = tbPacking.Text;
            if (qty.Trim().StartsWith("-"))
            {
                qty = qty.Trim().Substring(1);
            }
            else
            {
                qty = "-" + qty;
            }
            tbPacking.Text = qty;
        }

        private void Sound()
        {
            soundPool.Play(soundPoolId, 1, 1, 0, 0, 1);
        }



        private void Button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }


        private void Button4_Click(object sender, EventArgs e)
        {
            //
            if (SaveMoveItem())
            {
                StartActivity(typeof(TakeOverIdentEntry));
              
            }
        }


        private void BtSaveOrUpdate_Click(object sender, EventArgs e)
        {
            if (SaveMoveItem())
            {
                if (editMode)
                {
                   StartActivity(typeof(TakeOverEnteredPositionsView));
                }
                else
                {
                    StartActivity(typeof(TakeOverSerialOrSSCCEntry));
                }
                
            }
        }

        private static bool? checkTakeOverOpenQty = null;

        private void Button6_Click(object sender, EventArgs e)
        {
       
                if (SaveMoveItem())
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
        
        private bool CheckTakeOverOpenQty()
        {
            if (checkTakeOverOpenQty == null)
            {
            
             
                try
                {
                    string error;
                    var useObj = Services.GetObject("ctooqUse", "", out error);
                    checkTakeOverOpenQty = useObj == null ? false : useObj.GetBool("Use");
                }
                finally
                {
                
                }
            }
            return (bool)checkTakeOverOpenQty;
        }
        // ---

        private bool SaveMoveItem()
        {
            if (string.IsNullOrEmpty(tbSSCC.Text.Trim()) && string.IsNullOrEmpty(tbSerialNum.Text.Trim()) && string.IsNullOrEmpty(tbPacking.Text.Trim()))
            {
                return true;
            }

            if (tbSSCC.Enabled && string.IsNullOrEmpty(tbSSCC.Text.Trim()))
            {
                string errorWebAppIssued = string.Format("SSCC koda je obvezan podatek. ");
                Toast.MakeText(this, errorWebAppIssued, ToastLength.Long).Show();
                tbSSCC.RequestFocus();
                return false;
            }

            if (tbSerialNum.Enabled && openIdent.GetBool("HasSerialNumber"))
            {
                if (string.IsNullOrEmpty(tbSerialNum.Text.Trim()))
                {
                    string errorWebAppIssued = string.Format("Serijska številka je obvezan podatek.");
                    Toast.MakeText(this, errorWebAppIssued, ToastLength.Long).Show();
                    tbSerialNum.RequestFocus();
                    return false;
                }
            }

            if (string.IsNullOrEmpty(tbPacking.Text.Trim()))
            {
                string errorWebAppIssued = string.Format("Količina je obvezen podatek.");
                Toast.MakeText(this, errorWebAppIssued, ToastLength.Long).Show();
                tbPacking.RequestFocus();
                return false;
            }
            else
            {
                try
                {
                    var qty = Convert.ToDouble(tbPacking.Text.Trim());

                    if (qty == 0.0)
                    {
                        string errorWebAppIssued = string.Format("Količina je obvezen podatek in mora biti različna od nič");
                        Toast.MakeText(this, errorWebAppIssued, ToastLength.Long).Show();
                        tbPacking.RequestFocus();
                        return false;
                    }

                    if (moveHead.GetBool("ByOrder") && !isPackaging && CheckTakeOverOpenQty())
                    {
                        var tolerance = openIdent.GetDouble("TolerancePercent");
                        var max = Math.Abs(openOrder.GetDouble("OpenQty") * (1.0 + tolerance / 100));
                        if (Math.Abs(qty) > max)
                        {
                            string errorWebAppIssued = string.Format("Količina (" + qty.ToString(CommonData.GetQtyPicture()) + ") ne sme presegati max. količine (" + max.ToString(CommonData.GetQtyPicture()) + ")!");
                            Toast.MakeText(this, errorWebAppIssued, ToastLength.Long).Show();

                            tbPacking.RequestFocus();
                            return false;
                        }
                    }
                }
                catch (Exception e)
                {

                    string errorWebAppIssued = string.Format("Količina mora biti število (" + e.Message + ")!");
                    Toast.MakeText(this, errorWebAppIssued, ToastLength.Long).Show();

                    tbPacking.RequestFocus();
                    return false;
                }
            }

            if (string.IsNullOrEmpty(tbUnits.Text.Trim()))
            {
                string errorWebAppIssued = string.Format(lbUnits.Text + " je obvezen podatek!");
                Toast.MakeText(this, errorWebAppIssued, ToastLength.Long).Show();
                tbUnits.RequestFocus();
                return false;
            }
            else
            {
                try
                {
                    var units = Convert.ToDouble(tbUnits.Text.Trim());
                    if (units == 0.0)
                    {
                        string errorWebAppIssued = string.Format(lbUnits.Text + " je obvezen podatek in mora biti različna od nič!");
                        Toast.MakeText(this, errorWebAppIssued, ToastLength.Long).Show();

                        tbUnits.RequestFocus();
                        return false;
                    }
                }
                catch (Exception e) { 


                 string errorWebAppIssued = string.Format(lbUnits.Text + " mora biti število (" + e.Message + ")!");
                Toast.MakeText(this, errorWebAppIssued, ToastLength.Long).Show();
                tbUnits.RequestFocus();
                    return false;
                }
            }

            if (!CommonData.IsValidLocation(moveHead.GetString("Wharehouse"), tbLocation.Text.Trim()))
            {
                string errorWebAppIssued = string.Format("Lokacija '" + tbLocation.Text.Trim() + "' ni veljavna za skladišče '" + moveHead.GetString("Wharehouse") + "'!");
                Toast.MakeText(this, errorWebAppIssued, ToastLength.Long).Show();

                tbLocation.RequestFocus();
                return false;
            }

   
            try
            {
               

                if (moveItem == null) { moveItem = new NameValueObject("MoveItem"); }
                moveItem.SetInt("HeadID", moveHead.GetInt("HeadID"));
                moveItem.SetString("LinkKey", openOrder.GetString("Key"));
                moveItem.SetInt("LinkNo", openOrder.GetInt("No"));
                moveItem.SetString("Ident", openIdent.GetString("Code"));
                moveItem.SetString("SSCC", tbSSCC.Text.Trim());
                moveItem.SetString("SerialNo", tbSerialNum.Text.Trim());

                if (CommonData.GetSetting("ShowNumberOfUnitsField") == "1")
                {
                    moveItem.SetDouble("Packing", Convert.ToDouble(tbPacking.Text.Trim()));
                    moveItem.SetDouble("Factor", Convert.ToDouble(tbUnits.Text.Trim()));
                    moveItem.SetDouble("Qty", Convert.ToDouble(tbUnits.Text.Trim()) * Convert.ToDouble(tbPacking.Text.Trim()));
                    moveItem.SetInt("MorePrints", 0);
                }
                else if (CommonData.GetSetting("ShowMorePrintsField") == "1")
                {
                    moveItem.SetDouble("Packing", 0.0);
                    moveItem.SetDouble("Factor", 1.0);
                    moveItem.SetDouble("Qty", Convert.ToDouble(tbPacking.Text.Trim()));
                    moveItem.SetInt("MorePrints", Convert.ToInt32(tbUnits.Text.Trim()));
                }
                else
                {
                    moveItem.SetDouble("Packing", 0.0);
                    moveItem.SetDouble("Factor", 1.0);
                    moveItem.SetDouble("Qty", Convert.ToDouble(tbPacking.Text.Trim()));
                    moveItem.SetInt("MorePrints", 0);
                }

                moveItem.SetInt("Clerk", Services.UserID());
                moveItem.SetString("Location", tbLocation.Text.Trim());

                moveItem.SetBool("PrintNow", CommonData.GetSetting("ImmediatePrintOnReceive") == "1");
                moveItem.SetInt("UserID", Services.UserID());
                moveItem.SetString("DeviceID", WMSDeviceConfig.GetString("ID", ""));

                string error;
                moveItem = Services.SetObject("mi", moveItem, out error);
                if (moveItem == null)
                {
                  
                    string errorWebAppIssued = string.Format("Napaka pri dostopu do web aplikacije: " + error);
                    Toast.MakeText(this, errorWebAppIssued, ToastLength.Long).Show();
                    return false;
                }
                else
                {
                    InUseObjects.Invalidate("MoveItem");
                    return true;
                }
            }
            finally
            {
             
            }
        }
        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // in smartphone
                case Keycode.F1:
                    Button1_Click(this, null);
                    break;
                //return true;


                case Keycode.F2:
                    BtSaveOrUpdate_Click(this, null);
                    break;


                case Keycode.F3:
                    Button4_Click(this, null);
                    break;

                case Keycode.F4:
                    Button6_Click(this, null);
                    break;

                case Keycode.F5:
                    Button5_Click(this, null);
                    break;

                case Keycode.F9:
                    Button7_Click(this, null);
                    break;

            }
            return base.OnKeyDown(keyCode, e);
        }

        public void GetBarcode(string barcode)
        {
            if (tbSSCC.HasFocus) {
                Sound();
                tbSSCC.Text = barcode;
             

            }
            else if (tbSerialNum.HasFocus) 
            {
                Sound();
                tbSerialNum.Text = barcode;
             

            }
            else if (tbLocation.HasFocus) {

                Sound();
                tbSerialNum.Text = barcode;
            }
        }
    }


    }

