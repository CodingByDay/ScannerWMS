using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics.Drawables;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BarCode2D_Receiver;
using Com.Barcode;
using Scanner;
using Scanner.App;
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;
using static Android.App.ActionBar;
using WebApp = TrendNET.WMS.Device.Services.WebApp;

namespace Scanner
{
    [Activity(Label = "InterWarehouseSerialOrSSCCEntry", ScreenOrientation = ScreenOrientation.Portrait)]
    public class InterWarehouseSerialOrSSCCEntry : Activity, IBarcodeResult
    {
        public string barcode;
        private EditText tbIdent;
        private EditText tbSSCC;
        private EditText tbSerialNum;
        private EditText tbIssueLocation;
        private EditText tbLocation;
        private EditText tbPacking;
        private EditText tbUnits;
        private TextView lbQty;
        private TextView lbUnits;
        private Button button1;
        private Button btSaveOrUpdate;
        private Button button3;
        private Button button5;
        private Button button4;
        private Button button6;
        private Button btMorePallets;
        private NameValueObject moveHead = (NameValueObject)InUseObjects.Get("MoveHead");
        private List<MorePallets> data = new List<MorePallets>();
        private NameValueObject moveItem = (NameValueObject)InUseObjects.Get("MoveItem");
        private NameValueObjectList docTypes = null;
        private bool editMode = false;
        private EditText lbIdentName;
        private IBarcodeResult result;
        SoundPool soundPool;
        int soundPoolId;
        private NameValueObject wh;
        private ImageView imagePNG;
        private ProgressDialogClass progress;
        private Dialog popupDialog;
        private Button btConfirm;
        private Button btExit;
        private EditText tbSSCCpopup;
        private ListView lvCardMore;
        private bool enabledSerial;
        private Button btnYes;
        private Button btnNo;
        private MorePalletsAdapter adapter;
        private Dialog popupDialogMain;
        private bool isBatch = false;
        private bool isFirst;

        // here...
        public void GetBarcode(string barcode)
        {
            if (!string.IsNullOrEmpty(barcode))
            {
              if(tbIdent.HasFocus)
                {
                    if (barcode != "Scan fail")
                    {
                        Sound();
                        tbIdent.Text = barcode;
                        ProcessIdent();
                        tbSSCC.RequestFocus();
                    } else
                    {

                    }
                 
                    // Here 

                } else if (tbSSCC.HasFocus)
                {
                    if (barcode != "Scan fail")
                    {
                        tbSSCC.Text = "";
                        tbSerialNum.Text = "";
                        tbPacking.Text = "";
                        tbIssueLocation.Text = "";
                        tbLocation.Text = "";

                        Sound();
                        tbSSCC.Text = barcode;

                        
                        if(FillRelatedBranchIdentData(tbSSCC.Text)) {

                           FillRelatedData(tbSSCC.Text);
                           tbLocation.RequestFocus();
                           ProcessQty();

                        } else
                        {
                            // Go a step back and rescan.
                            tbSSCC.Text = "";
                            tbSSCC.RequestFocus();
                        }

                       
                    }
              
                } else if(tbSerialNum.HasFocus)
                {
                    if (barcode != "Scan fail")
                    {
                        Sound();
                        tbSerialNum.Text = barcode;
                        tbIssueLocation.RequestFocus();
                    }

                } else if(tbIssueLocation.HasFocus)
                {
                    if (barcode != "Scan fail")
                    {
                        Sound();
                        tbIssueLocation.Text = barcode;
                        tbLocation.RequestFocus();
                        ProcessQty();
                    }


                } else if (tbLocation.HasFocus)
                {
                    if (!String.IsNullOrEmpty(barcode))
                    {
                        Sound();
                        tbLocation.Text = barcode;
                        tbPacking.RequestFocus();
                        ProcessQty();
                    }
                }

             
            }
        }

        private bool FillRelatedBranchIdentData(string text)
        {
            string error;

            var data = Services.GetObject("sscc", text, out error);

          

            if(data!=null)
            {
                var ident = data.GetString("Ident");
                var name = data.GetString("IdentName");


                tbIdent.Text = ident;
                lbIdentName.Text = name;

                // Just to be sure about the values, probably reduntant but hey.
                if(tbIdent.Text != null && lbIdentName.Text != null ) { return true; } else { return false; }


            } else
            {
                return false;
            }
        }

        private void FillRelatedData(string text)
        {
            string error;

            var data = Services.GetObject("sscc", tbSSCC.Text, out error);
            if (data != null)
            {
                if (tbSerialNum.Enabled == true)
                {
                    var serial = data.GetString("SerialNo");
                    tbSerialNum.Text = serial;
                    var location = data.GetString("Location");
                    tbIssueLocation.Text = location;
                   // tbPacking.RequestFocus();
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void color()
        {
            tbIdent.SetBackgroundColor(Android.Graphics.Color.Aqua);
            tbSSCC.SetBackgroundColor(Android.Graphics.Color.Aqua);
            tbSerialNum.SetBackgroundColor(Android.Graphics.Color.Aqua);
            tbIssueLocation.SetBackgroundColor(Android.Graphics.Color.Aqua);
            tbLocation.SetBackgroundColor(Android.Graphics.Color.Aqua);

        }



        private async Task<bool> SaveMoveItem()
        {

            if (string.IsNullOrEmpty(tbIdent.Text.Trim()) && string.IsNullOrEmpty(tbSerialNum.Text.Trim()) && string.IsNullOrEmpty(tbPacking.Text.Trim()))
            {
                return true;
            }

            if (tbSSCC.Enabled && string.IsNullOrEmpty(tbSSCC.Text.Trim()))
            {
                RunOnUiThread(() =>
                {
                    string WebError = string.Format("SSCC koda je obvezen podatek.");
                    Toast.MakeText(this, WebError, ToastLength.Long).Show();
                    tbSSCC.RequestFocus();
                });

                return false;
            }

            if (tbSerialNum.Enabled && string.IsNullOrEmpty(tbSerialNum.Text.Trim()))
            {
                RunOnUiThread(() =>
                {
                    string WebError = string.Format("Serijska št. je obvezen podatek.");
                    Toast.MakeText(this, WebError, ToastLength.Long).Show();

                    tbSerialNum.RequestFocus();
                });

                return false;
            }

            if (string.IsNullOrEmpty(tbPacking.Text.Trim()))
            {
                RunOnUiThread(() =>
                {
                    string WebError = string.Format("Količina je obvezan podatek.");
                    Toast.MakeText(this, WebError, ToastLength.Long).Show();

                    tbPacking.RequestFocus();
                });

                return false;
            }
            else
            {
                try
                {
                    var qty = Convert.ToDouble(tbPacking.Text.Trim());
                    if (qty == 0.0)
                    {
                        RunOnUiThread(() =>
                        {
                            string WebError = string.Format("Količina je obvezan podatek in mora biti različna od nič");
                            Toast.MakeText(this, WebError, ToastLength.Long).Show();

                            tbPacking.RequestFocus();
                        });

                        return false;
                    }

                    var stockQty = GetStock(moveHead.GetString("Issuer"), tbIssueLocation.Text.Trim(), tbSSCC.Text.Trim(), tbSerialNum.Text.Trim(), tbIdent.Text.Trim());
                    if (Double.IsNaN(stockQty))
                    {
                        RunOnUiThread(() =>
                        {
                            string WebError = string.Format("Zaloga ni znana, vpišite potrebne podatke");
                            Toast.MakeText(this, WebError, ToastLength.Long).Show();
                        });


                        //  SelectNext(tbIdent);
                        return false;
                    }
                    if (Math.Abs(qty) > Math.Abs(stockQty))
                    {
                        RunOnUiThread(() =>
                        {
                            string WebError = string.Format("Količina ne sme presegati zaloge!");
                            Toast.MakeText(this, WebError, ToastLength.Long).Show();

                            tbPacking.RequestFocus();
                        });

                        return false;
                    }
                }
                catch (Exception e)
                {
                    RunOnUiThread(() =>
                    {
                        string WebError = string.Format("Količina mora biti število (" + e.Message + ")!");
                        Toast.MakeText(this, WebError, ToastLength.Long).Show();
                        tbPacking.RequestFocus();
                    });

                    return false;
                }
            }

            if (string.IsNullOrEmpty(tbUnits.Text.Trim()))
            {
                RunOnUiThread(() =>
                {
                    string WebError = string.Format("Št. enota je obavezan podatek.");
                    Toast.MakeText(this, WebError, ToastLength.Long).Show();
                });

                return false;
            }
            else
            {
                try
                {
                    var units = Convert.ToDouble(tbUnits.Text.Trim());
                    if (units == 0.0)
                    {
                        RunOnUiThread(() =>
                        {
                            string WebError = string.Format("Št. enota je obavezan podatek in mora biti različit od nič.");
                            Toast.MakeText(this, WebError, ToastLength.Long).Show();
                            tbUnits.RequestFocus();
                        });

                        return false;
                    }
                }
                catch (Exception e)
                {


                    RunOnUiThread(() =>
                    {
                        string WebError = string.Format("Št. enot mora biti število (" + e.Message + ")!");
                        Toast.MakeText(this, WebError, ToastLength.Long).Show();
                        tbPacking.RequestFocus();
                    });

                    return false;
                }
            }

            if (!CommonData.IsValidLocation(moveHead.GetString("Issuer"), tbIssueLocation.Text.Trim()))
            {
                RunOnUiThread(() =>
                {
                    string WebError = string.Format("Prejemna lokacija" + tbLocation.Text.Trim() + "ni veljavna za sladišće" + moveHead.GetString("Issuer") + "!");
                    Toast.MakeText(this, WebError, ToastLength.Long).Show();
                    tbIssueLocation.RequestFocus();
                });

                return false;
            }

            if (!CommonData.IsValidLocation(moveHead.GetString("Receiver"), tbLocation.Text.Trim()))
            {
                RunOnUiThread(() =>
                {
                    string WebError = string.Format("Prejemna lokacija" + tbLocation.Text.Trim() + "ni veljavna za sladišće" + moveHead.GetString("Receiver") + "!");
                    Toast.MakeText(this, WebError, ToastLength.Long).Show();
                    tbLocation.RequestFocus();
                });

                return false;
            }

            try
            {

                if (moveItem == null) { moveItem = new NameValueObject("MoveItem"); }
                moveItem.SetInt("HeadID", moveHead.GetInt("HeadID"));
                moveItem.SetString("LinkKey", "");
                moveItem.SetInt("LinkNo", 0);
                moveItem.SetString("Ident", tbIdent.Text.Trim());
                moveItem.SetString("SSCC", tbSSCC.Text.Trim());
                moveItem.SetString("SerialNo", tbSerialNum.Text.Trim());
                moveItem.SetDouble("Packing", Convert.ToDouble(tbPacking.Text.Trim()));
                moveItem.SetDouble("Factor", Convert.ToDouble(tbUnits.Text.Trim()));
                moveItem.SetDouble("Qty", Convert.ToDouble(tbPacking.Text.Trim()) * Convert.ToDouble(tbUnits.Text.Trim()));
                moveItem.SetInt("Clerk", Services.UserID());
                moveItem.SetString("Location", tbLocation.Text.Trim());
                moveItem.SetString("IssueLocation", tbIssueLocation.Text.Trim());

                string error;
                moveItem = Services.SetObject("mi", moveItem, out error);
                if (moveItem == null)
                {
                    RunOnUiThread(() =>
                    {
                        string WebError = string.Format("Napaka pri dostopu do web aplikacije." + error);
                        Toast.MakeText(this, WebError, ToastLength.Long).Show();

                    });

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

        // This method
        private async Task<bool> SaveMoveItemWithParams(MorePallets objectItem, bool isFirst)
        {

            if (string.IsNullOrEmpty(objectItem.Ident.Trim()) && string.IsNullOrEmpty(objectItem.Serial) && string.IsNullOrEmpty(objectItem.Quantity.Trim()))
            {
                return true;
            }

            if (string.IsNullOrEmpty(objectItem.SSCC))
            {
                RunOnUiThread(() =>
                {
                    string WebError = string.Format("SSCC koda je obvezen podatek.");
                    Toast.MakeText(this, WebError, ToastLength.Long).Show();
                    tbSSCC.RequestFocus();
                });

                return false;
            }

          
            else
            {
                try
                {
                    var qty = Convert.ToDouble(objectItem.Quantity.Trim());
                    if (qty == 0.0)
                    {
                        RunOnUiThread(() =>
                        {
                            string WebError = string.Format("Količina je obvezan podatek in mora biti različna od nič");
                            Toast.MakeText(this, WebError, ToastLength.Long).Show();

                        
                        });

                        return false;
                    }

                    var stockQty = GetStock(moveHead.GetString("Issuer"), objectItem.Location.Trim(), objectItem.SSCC.Trim(), objectItem.Serial.Trim(), objectItem.Ident.Trim());
                    if (Double.IsNaN(stockQty))
                    {
                        RunOnUiThread(() =>
                        {
                            string WebError = string.Format("Zaloga ni znana, vpišite potrebne podatke");
                            Toast.MakeText(this, WebError, ToastLength.Long).Show();
                        });


                        //  SelectNext(tbIdent);
                        return false;
                    }
                    if (Math.Abs(qty) > Math.Abs(stockQty))
                    {
                        RunOnUiThread(() =>
                        {
                            string WebError = string.Format("Količina ne sme presegati zaloge!");
                            Toast.MakeText(this, WebError, ToastLength.Long).Show();

                        
                        });

                        return false;
                    }
                }
                catch (Exception e)
                {
                    RunOnUiThread(() =>
                    {
                        string WebError = string.Format("Količina mora biti število (" + e.Message + ")!");
                        Toast.MakeText(this, WebError, ToastLength.Long).Show();
                  
                    });

                    return false;
                }
            }

            if (string.IsNullOrEmpty(tbUnits.Text.Trim()))
            {
                RunOnUiThread(() =>
                {
                    string WebError = string.Format("Št. enota je obavezan podatek.");
                    Toast.MakeText(this, WebError, ToastLength.Long).Show();
                });

                return false;
            }
            else
            {
                try
                {
                    var units = Convert.ToDouble(tbUnits.Text.Trim());
                    if (units == 0.0)
                    {
                        RunOnUiThread(() =>
                        {
                            string WebError = string.Format("Št. enota je obavezan podatek in mora biti različit od nič.");
                            Toast.MakeText(this, WebError, ToastLength.Long).Show();
                            tbUnits.RequestFocus();
                        });

                        return false;
                    }
                }
                catch (Exception e)
                {


                    RunOnUiThread(() =>
                    {
                        string WebError = string.Format("Št. enot mora biti število (" + e.Message + ")!");
                        Toast.MakeText(this, WebError, ToastLength.Long).Show();
                        tbPacking.RequestFocus();
                    });

                    return false;
                }
            }

            if (!CommonData.IsValidLocation(moveHead.GetString("Issuer"), objectItem.Location.Trim()))
            {
                RunOnUiThread(() =>
                {
                    string WebError = string.Format("Prejemna lokacija" + tbLocation.Text.Trim() + "ni veljavna za sladišće" + moveHead.GetString("Issuer") + "!");
                    Toast.MakeText(this, WebError, ToastLength.Long).Show();
                    tbIssueLocation.RequestFocus();
                });

                return false;
            }

            if (!CommonData.IsValidLocation(moveHead.GetString("Receiver"), tbLocation.Text.Trim()))
            {
                RunOnUiThread(() =>
                {
                    string WebError = string.Format("Prejemna lokacija" + tbLocation.Text.Trim() + "ni veljavna za sladišće" + moveHead.GetString("Receiver") + "!");
                    Toast.MakeText(this, WebError, ToastLength.Long).Show();
                    tbLocation.RequestFocus();
                });

                return false;
            }

            try
            {
                InUseObjects.Invalidate("MoveItem");
                
                moveItem = null;
                if (moveItem == null) { 

                    moveItem = new NameValueObject("MoveItem");
                }
               
                moveHead = (NameValueObject)InUseObjects.Get("MoveHead");
                if(isFirst)
                {
                    var test = moveHead.GetInt("HeadID");
                    moveItem.SetInt("HeadID", moveHead.GetInt("HeadID"));

                }
                else
                {
                    updateTheHead();             

                }
                var number = moveHead.GetInt("HeadID");
                moveItem.SetString("LinkKey", "");
                moveItem.SetInt("LinkNo", 0);
                moveItem.SetString("Ident", objectItem.Ident.Trim());
                moveItem.SetString("SSCC", objectItem.SSCC.Trim());
                moveItem.SetString("SerialNo", objectItem.Serial.Trim());
                moveItem.SetDouble("Packing", Convert.ToDouble(objectItem.Quantity.Trim()));
                moveItem.SetDouble("Factor", Convert.ToDouble(tbUnits.Text.Trim()));
                moveItem.SetDouble("Qty", Convert.ToDouble(objectItem.Quantity.Trim()) * Convert.ToDouble(tbUnits.Text.Trim()));
                moveItem.SetInt("Clerk", Services.UserID());
                moveItem.SetString("Location", tbLocation.Text.Trim());
                moveItem.SetString("IssueLocation", objectItem.Location.Trim());

                string error;
                moveItem = Services.SetObject("mi", moveItem, out error);
                if (moveItem == null)
                {
                    RunOnUiThread(() =>
                    {
                        string WebError = string.Format("Napaka pri dostopu do web aplikacije." + error);
                        Toast.MakeText(this, WebError, ToastLength.Long).Show();
                        // There is never an error here
                    });
                    return false;
                }
                else
                {
                   
                    InUseObjects.Invalidate("MoveItem");
                    return true;
                    // This always runs.
                }
            }
            finally
            {
             
            }
        }

        private void updateTheHead()
        {
            moveHead.SetInt("HeadID", 0); // da ga "mh" API shrani kot novega, ne pod starim ID
            string error;
            var savedMoveHead = Services.SetObject("mh", moveHead, out error);
            if (savedMoveHead == null)
            {
                Toast.MakeText(this, "Napaka pri zaklepanju nove medskladišnice.", ToastLength.Long).Show();
                return;
            }
            else
            {
                if (!Services.TryLock("MoveHead" + savedMoveHead.GetInt("HeadID").ToString(), out error))
                {
                    Toast.MakeText(this, "Napaka pri zaklepanju nove medskladišnice.", ToastLength.Long).Show();
                    return;
                }

                moveHead.SetInt("HeadID", savedMoveHead.GetInt("HeadID"));
                moveHead.SetBool("Saved", true);
                InUseObjects.Set("MoveHead", moveHead);

                var tests = moveHead.GetInt("HeadID");
                var debug = true;
            }
        }

        private MorePallets ProcessQtyWithParams(MorePallets obj, string location)
        {
            var sscc = obj.SSCC;
            if (string.IsNullOrEmpty(sscc))
            {
                return null;
            }

            var serialNo = obj.Serial;
            if (enabledSerial && string.IsNullOrEmpty(serialNo))
            {
                return null;
            }

            var ident = obj.Ident;
            if (string.IsNullOrEmpty(ident))
            {
                return null;
            }

            var identObj = CommonData.LoadIdent(ident);
            var isEnabled = identObj.GetBool("HasSerialNumber");

            if (!CommonData.IsValidLocation(moveHead.GetString("Issuer"), location))
            {
                string SuccessMessage = string.Format("Izdajna lokacija" + location + "ni veljavna za skladisće" + moveHead.GetString("Issuer") + "'!");
                Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();


                return null;
            }

            var stockQty = GetStockWithParams(moveHead.GetString("Issuer"), location, sscc, serialNo, ident, isEnabled);
            if (!Double.IsNaN(stockQty))
            {
                obj.Quantity = stockQty.ToString(CommonData.GetQtyPicture());

            }
            else
            {
                Toast.MakeText(this, "Prišlo je do napake.", ToastLength.Long).Show();
            }
            return obj;

        }


        private double GetStockWithParams(string warehouse, string location, string sscc, string serialNum, string ident, bool serialEnabled)
        {
            var wh = CommonData.GetWarehouse(warehouse);
            if (!wh.GetBool("HasStock"))
                if (serialEnabled)
                {
                    return LoadStockFromPAStockSerialNo(warehouse, ident, serialNum);
                }
                else
                {
                    return LoadStockFromPAStock(warehouse, ident);
                }

            else
            {
                return LoadStockFromStockSerialNo(warehouse, location, sscc, serialNum, ident);
            }

        }

        private void ProcessQty()
        {
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

            if (!CommonData.IsValidLocation(moveHead.GetString("Issuer"), tbIssueLocation.Text.Trim()))
            {
                string SuccessMessage = string.Format("Izdajna lokacija" +  tbIssueLocation.Text.Trim() + "ni veljavna za skladisće" + moveHead.GetString("Issuer") + "'!") ;
                Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();
                tbIssueLocation.RequestFocus();

                return;
            }

            var stockQty = GetStock(moveHead.GetString("Issuer"), tbIssueLocation.Text.Trim(), sscc, serialNo, ident);
            if (!Double.IsNaN(stockQty))
            {
                tbPacking.Text = stockQty.ToString(CommonData.GetQtyPicture());
                lbQty.Text = "Količina (" + stockQty.ToString(CommonData.GetQtyPicture()) + ")";
            }
            else
            {
                tbPacking.Text = "";
                lbQty.Text = "Količina (?)";
            }

           
        }


     
   

        private double GetStock(string warehouse, string location, string sscc, string serialNum, string ident)
        {
            var wh = CommonData.GetWarehouse(warehouse);
            if (!wh.GetBool("HasStock"))
                if (tbSerialNum.Enabled)
                {
                    return LoadStockFromPAStockSerialNo(warehouse, ident, serialNum);
                }
                else
                {
                    return LoadStockFromPAStock(warehouse, ident);
                }
   
            else
            {
                return LoadStockFromStockSerialNo(warehouse, location, sscc, serialNum, ident);
            }
          
        }

        private Double LoadStockFromStockSerialNo(string warehouse, string location, string sscc, string serialNum, string ident)
        {
  
            try
            {
                string error;
                var stock = Services.GetObject("str", warehouse + "|" + location + "|" + sscc + "|" + serialNum + "|" + ident, out error);
                if (stock == null)
                {
                    string SuccessMessage = string.Format("Napaka pri preverjenju zaloge." + error);
                    Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();

                    return Double.NaN;
                }
                else
                {
                    return stock.GetDouble("RealStock");
                }
            }
            finally
            {
             
            }
        }


        private Double LoadStockFromPAStock(string warehouse, string ident)
        {
            try
            {
                string error;
                var stock = Services.GetObject("pas", warehouse + "|" + ident, out error);
                if (stock == null)
                {
                    string SuccessMessage = string.Format("Napaka pri preverjenju zaloge." + error);
                    return Double.NaN;
                }
                else
                {
                    return stock.GetDouble("Qty");
                }
            }
            finally
            {
                
            }
        }

        private Double LoadStockFromPAStockSerialNo(string warehouse, string ident, string serialNo)
        {
        
            try
            {

                string error;
                var stock = Services.GetObject("pass", warehouse + "|" + ident + "|" + serialNo, out error);
                if (stock == null)
                {
                    string SuccessMessage = string.Format("Napaka pri preverjanju zaloge" + error);
                    return Double.NaN;
                }
                else
                {
                    return stock.GetDouble("Qty");
                }
            }
            finally
            {
             // pass 
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
            // Create your application here
            SetContentView(Resource.Layout.InterWarehouseSerialOrSSCCEntry);
            tbIdent = FindViewById<EditText>(Resource.Id.tbIdent);
            tbSSCC = FindViewById<EditText>(Resource.Id.tbSSCC);
            tbSerialNum = FindViewById<EditText>(Resource.Id.tbSerialNum);
            tbIssueLocation = FindViewById<EditText>(Resource.Id.tbIssueLocation);
            tbLocation = FindViewById<EditText>(Resource.Id.tbLocation);
            tbPacking = FindViewById<EditText>(Resource.Id.tbPacking);
            tbUnits = FindViewById<EditText>(Resource.Id.tbUnits);
            // labels
            lbQty = FindViewById<TextView>(Resource.Id.lbQty);
            lbUnits = FindViewById<TextView>(Resource.Id.lbUnits);
            imagePNG = FindViewById<ImageView>(Resource.Id.imagePNG);
            // Buttons
            btSaveOrUpdate = FindViewById<Button>(Resource.Id.btSaveOrUpdate);
            wh = new NameValueObject();
            tbIdent.KeyPress += TbIdent_KeyPress;
            tbPacking.KeyPress += TbPacking_KeyPress;
            btMorePallets = FindViewById<Button>(Resource.Id.btMorePallets);
            btMorePallets.Click += BtMorePallets_Click;
            tbLocation.KeyPress += TbLocation_KeyPress;
            button1 = FindViewById<Button>(Resource.Id.button1);
            button3 = FindViewById<Button>(Resource.Id.button3);
            button5 = FindViewById<Button>(Resource.Id.button5);
            button4 = FindViewById<Button>(Resource.Id.button4);
            button6 = FindViewById<Button>(Resource.Id.button6);
            tbSerialNum.FocusChange += TbSerialNum_FocusChange;
            color();
           
            button6.Click += Button6_Click;
            button4.Click += Button4_Click;
            button5.Click += Button5_Click;
            button3.Click += Button3_Click;
            button1.Click += Button1_Click;

            btSaveOrUpdate.Click += BtSaveOrUpdate_Click;
           
            lbIdentName = FindViewById<EditText>(Resource.Id.lbIdentName);
            soundPool = new SoundPool(10, Stream.Music, 0);
            soundPoolId = soundPool.Load(this, Resource.Drawable.beep, 1);
            Barcode2D barcode2D = new Barcode2D();
            barcode2D.open(this, this);

            barcode2D.open(this, this);



            if (InterWarehouseBusinessEventSetup.success == true)
            {
                string toast = string.Format(moveHead.GetString("Issuer"));
                Toast.MakeText(this, toast, ToastLength.Long).Show();
         
            }
            
            if (moveHead == null) { throw new ApplicationException("moveHead not known at this point?!"); }

            docTypes = CommonData.ListDocTypes("I|N");

            if (moveItem != null)
            {
                tbSerialNum.Text = moveItem.GetString("SerialNo");
                tbPacking.Text = moveItem.GetDouble("Packing").ToString();
                tbUnits.Text = moveItem.GetDouble("Factor").ToString();
                tbSSCC.Text = moveItem.GetString("SSCC");
                tbIdent.Text = moveItem.GetString("Ident");
                ProcessIdent();
                tbLocation.Text = moveItem.GetString("Location");
                tbIssueLocation.Text = moveItem.GetString("IssueLocation");
                btSaveOrUpdate.Text = "Spremeni ser. št. - F2";

                editMode = true;
                tbSSCC.Enabled = false;
            }

            if (editMode)
            {
                tbPacking.RequestFocus();
            }
            else
            {
                tbIdent.RequestFocus();
            }

            if (string.IsNullOrEmpty(tbUnits.Text.Trim())) { tbUnits.Text = "1"; }
            if (CommonData.GetSetting("ShowNumberOfUnitsField") == "1")
            {
                lbUnits.Visibility = ViewStates.Visible;
                tbUnits.Visibility = ViewStates.Visible;
            }

            // var location = CommonData.GetSetting("DefaultProductionLocation");
            // tbLocation.Text = location;


            tbSSCC.RequestFocus();
         
        }

        private void LvCardMore_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var index = e.Position;
            var element = data.ElementAt(index);
            string formated = $"Izbrali ste {element.SSCC}.";
            Toast.MakeText(this, formated, ToastLength.Long).Show();
        }

        private void TbSerialNum_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            if (FillRelatedBranchIdentData(tbSSCC.Text))
            {

                FillRelatedData(tbSSCC.Text);
                tbLocation.RequestFocus();
                ProcessQty();
                tbLocation.RequestFocus();

            }
        }

        private void BtMorePallets_Click(object sender, EventArgs e)
        {
            //StartActivity(typeof(MorePalletsClass));
            popupDialogMain = new Dialog(this);
            popupDialogMain.SetContentView(Resource.Layout.MorePalletsClass);
            popupDialogMain.Window.SetSoftInputMode(SoftInput.AdjustResize);
            popupDialogMain.Show();

            popupDialogMain.Window.SetLayout(LayoutParams.MatchParent, LayoutParams.WrapContent);

            btConfirm = popupDialogMain.FindViewById<Button>(Resource.Id.btConfirm);
            btExit = popupDialogMain.FindViewById<Button>(Resource.Id.btExit);
            tbSSCCpopup = popupDialogMain.FindViewById<EditText>(Resource.Id.tbSSCC);
            tbSSCCpopup.SetBackgroundColor(Android.Graphics.Color.Aqua);
            tbSSCCpopup.KeyPress += TbSSCCpopup_KeyPress;
            lvCardMore = popupDialogMain.FindViewById<ListView>(Resource.Id.lvCardMore);
            lvCardMore.ItemLongClick += LvCardMore_ItemLongClick;
            adapter = new MorePalletsAdapter(this, data);
            lvCardMore.Adapter = adapter;
            lvCardMore.ItemSelected += LvCardMore_ItemSelected;
            btConfirm.Click += BtConfirm_Click;
            btExit.Click += BtExit_Click;
        }

        private void BtExit_Click(object sender, EventArgs e)
        {
            popupDialogMain.Dismiss();
            popupDialogMain.Hide();
        }

        private async void BtConfirm_Click(object sender, EventArgs e)
        {
            string formatedString = $"{data.Count} skeniranih SSCC koda.";
            tbSSCC.Text = formatedString;
            tbSerialNum.Text = "...";
            tbIssueLocation.Text = "...";
            tbIdent.Text = "...";
            tbPacking.Text = "...";
            tbLocation.RequestFocus();
            isBatch = true;
            popupDialogMain.Dismiss();
            popupDialogMain.Hide();
            
        }

       

        private void LvCardMore_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            var index = e.Position;
            DeleteFromTouch(index);
        }
        private void DeleteFromTouch(int index)
        {
            popupDialog = new Dialog(this);
            popupDialog.SetContentView(Resource.Layout.YesNoPopUp);
            popupDialog.Window.SetSoftInputMode(SoftInput.AdjustResize);
            popupDialog.Show();

            popupDialog.Window.SetLayout(LayoutParams.MatchParent, LayoutParams.WrapContent);
            popupDialog.Window.SetBackgroundDrawableResource(Android.Resource.Color.HoloOrangeLight);

            // Access Popup layout fields like below
            btnYes = popupDialog.FindViewById<Button>(Resource.Id.btnYes);
            btnNo = popupDialog.FindViewById<Button>(Resource.Id.btnNo);
            btnYes.Click += (e, ev) => { Yes(index); };
            btnNo.Click += (e, ev) => { No(index); };
        }

        private void No(int index)
        {
            popupDialog.Dismiss();
            popupDialog.Hide();
        }

        private void Yes(int index)
        {
            data.RemoveAt(index);
            lvCardMore.Adapter = null;
            lvCardMore.Adapter = adapter;
            popupDialog.Dismiss();
            popupDialog.Hide();
        }

        private void FilData(string barcode)
        {
            if (!String.IsNullOrEmpty(barcode))
            {
                string error;
                var dataObject = Services.GetObject("sscc", barcode, out error);
                if (dataObject != null)
                {
                    var ident = dataObject.GetString("Ident");
                    var loadIdent = CommonData.LoadIdent(ident);
                    var name = dataObject.GetString("IdentName");
                    var serial = dataObject.GetString("SerialNo");
                    var location = dataObject.GetString("Location");
                    MorePallets pallets = new MorePallets();
                    pallets.Ident = ident;                       
                    string idname= loadIdent.GetString("Name");
                    pallets.Location = location;
                    pallets.Name = idname.Trim().Substring(0, 10);
                    pallets.Quantity = barcode;
                    pallets.SSCC = barcode;
                    pallets.Serial = serial;
                    pallets.friendlySSCC = pallets.SSCC.Substring(0, 10);
                    enabledSerial = loadIdent.GetBool("HasSerialNumber");


#nullable enable        
                    MorePallets? obj = ProcessQtyWithParams(pallets, location);
#nullable disable
                    /* Adds an object to the list. */
                    if (obj is null)
                    {
                        Toast.MakeText(this, "Prišlo je do napake.", ToastLength.Long).Show();
                    }
                    else
                    {
                        data.Add(obj);
                        // Added to the list

                        tbSSCCpopup.Text = "";
                        tbSSCCpopup.RequestFocus();

                    }
                }
                else
                {
                    return;
                }
            }
        }
        private void TbSSCCpopup_KeyPress(object sender, View.KeyEventArgs e)
        {
            e.Handled = false;
            if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
            {
                // Add your logic here 
                FilData(tbSSCCpopup.Text);
              
            }
        }

        private void TbLocation_KeyPress(object sender, View.KeyEventArgs e)
        {
            e.Handled = false;
            if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
            {
                // Add your logic here 
                ProcessQty();
                e.Handled = true;
            }
        }

     

        private void TbPacking_KeyPress(object sender, View.KeyEventArgs e)
        {
            e.Handled = false;
            if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
            {
                // add your logic here 
                ProcessIdent();
                e.Handled = true;
            }
        }
        
        private void TbIdent_KeyPress(object sender, View.KeyEventArgs e)
        {
            if (e.KeyCode == Keycode.Enter)
            {
                //add your logic here 
                ProcessIdent();
                e.Handled = true;
            } else
            {
                e.Handled = false;
            }
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

        private async void BtSaveOrUpdate_Click(object sender, EventArgs e)
        {
            if (await SaveMoveItem())
            {
                if (editMode)
                {
                    StartActivity(typeof(InterWarehouseEnteredPositionsView));
                }
                else
                {
                    StartActivity(typeof(InterWarehouseSerialOrSSCCEntry));
                }
                this.Finish();
             }
        }

        private async void Button3_Click(object sender, EventArgs e)
        {
            if (await SaveMoveItem())
            {
                StartActivity(typeof(InterWarehouseSerialOrSSCCEntry));
            }
        }
        private async Task FinishMethod()
        {
            await Task.Run(async() =>
            {
                if (await SaveMoveItem())
                {
                    RunOnUiThread(() =>
                    {
                        progress = new ProgressDialogClass();
                        progress.ShowDialogSync(this, "Zaključujem");
                    });
                

                    try
                    {
                        var headID = moveHead.GetInt("HeadID");

                        string result;
                        if (WebApp.Get("mode=finish&stock=move&print=" + Services.DeviceUser() + "&id=" + headID.ToString(), out result))
                        {
                            if (result.StartsWith("OK!"))
                            {
                                RunOnUiThread(() =>
                                {
                                    progress.StopDialogSync();
                                    var id = result.Split('+')[1];

                                    AlertDialog.Builder alert = new AlertDialog.Builder(this);
                                    alert.SetTitle("Zaključevanje uspešno");
                                    alert.SetMessage("Zaključevanje uspešno! Št.prevzema:\r\n" + id);

                                    alert.SetPositiveButton("Ok", (senderAlert, args) =>
                                    {
                                        alert.Dispose();
                                        System.Threading.Thread.Sleep(500);
                                        StartActivity(typeof(MainMenu));
                                    });



                                    Dialog dialog = alert.Create();
                                    dialog.Show();
                                });
                               
                            }
                            else
                            {
                                RunOnUiThread(() =>
                                {
                                    progress.StopDialogSync();
                                    AlertDialog.Builder alert = new AlertDialog.Builder(this);
                                    alert.SetTitle("Napaka");
                                    alert.SetMessage("Napaka pri zaključevanju: " + result);

                                    alert.SetPositiveButton("Ok", (senderAlert, args) =>
                                    {
                                        alert.Dispose();
                                        System.Threading.Thread.Sleep(500);
                                        StartActivity(typeof(MainMenu));

                                    });



                                    Dialog dialog = alert.Create();
                                    dialog.Show();
                                });

                            }
                        }
                        else
                        {
                            string SuccessMessage = string.Format("Napaka pri klicu web aplikacije");
                            Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();
                        }
                    }
                    finally
                    {
                        RunOnUiThread(() =>
                        {
                            progress.StopDialogSync();

                        });
                    }
                }
            });
        }

        private async Task FinishMethodBatch()
        {
            await Task.Run(async () =>
            {
                int check=0;

                RunOnUiThread(() =>
                {
                    progress = new ProgressDialogClass();
                    progress.ShowDialogSync(this, "Zaključujem več paleta na enkrat.");
                });
                int count = 0;
                foreach (MorePallets item in data)
                {
                    if(count==0)
                    {
                        isFirst = true;
                    } else
                    {
                        isFirst = false;
                    }
                    count += 1; 
                    if (await SaveMoveItemWithParams(item, isFirst))
                    {

                        // First iteration is OK. "Zaključevanje uspešno" + ID
                        // Second "Napaka pri zaključevanju" + ID from before
                        try
                        {
                        
                            var headID = moveHead.GetInt("HeadID");

                            string result;
                            if (WebApp.Get("mode=finish&stock=move&print=" + Services.DeviceUser() + "&id=" + headID.ToString(), out result))
                            {
                                if (result.StartsWith("OK!"))
                                {

                                    check += 1;

                                    RunOnUiThread(() =>
                                    {
                                        progress.StopDialogSync();
                                        var id = result.Split('+')[1];

                                        AlertDialog.Builder alert = new AlertDialog.Builder(this);
                                        alert.SetTitle("Zaključevanje uspešno");
                                        alert.SetMessage("Zaključevanje uspešno! Št.prevzema:\r\n" + id);

                                        alert.SetPositiveButton("Ok", (senderAlert, args) =>
                                        {
                                          
                                            System.Threading.Thread.Sleep(500);
                                            if(check==data.Count)
                                            {
                                                StartActivity(typeof(MainMenu));
                                            } else
                                            {
                                                alert.Dispose();
                                                progress.ShowDialogSync(this, "Zaključujem več paleta na enkrat.");
                                                

                                            }
                                        });



                                        Dialog dialog = alert.Create();
                                        dialog.Show();
                                    });


                                }
                                else
                                {
                                    RunOnUiThread(() =>
                                    {
                                        progress.StopDialogSync();
                                        AlertDialog.Builder alert = new AlertDialog.Builder(this);
                                        alert.SetTitle("Napaka");
                                        alert.SetMessage("Napaka pri zaključevanju: " + result);

                                        alert.SetPositiveButton("Ok", (senderAlert, args) =>
                                        {
                                            alert.Dispose();
                                            System.Threading.Thread.Sleep(500);
                                            StartActivity(typeof(MainMenu));

                                        });



                                        Dialog dialog = alert.Create();
                                        dialog.Show();
                                    });

                                }
                            }
                            else
                            {
                                string SuccessMessage = string.Format("Napaka pri klicu web aplikacije");
                                Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();
                            }
                        }
                        finally
                        {
                         
                        }
                    } else
                    {
                        RunOnUiThread(() =>
                        {
                            progress.StopDialogSync();

                        });
                    }
                }
                RunOnUiThread(() =>
                {
                    progress.StopDialogSync();

                });
            });
        }


        private async void Button5_Click(object sender, EventArgs e)
        {
            if (!isBatch)
            {
                await FinishMethod();
            } else
            {
                await FinishMethodBatch();
            }
            

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(InterWarehouseEnteredPositionsView));
        }
        

        private void Button6_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainMenu));
        }

        private void ProcessIdent()
        {
            var ident = CommonData.LoadIdent(tbIdent.Text.Trim());
            if (ident == null)
            {
                tbIdent.Text = "";
                lbIdentName.Text = "";
                return;
            }

            if (CommonData.GetSetting("IgnoreStockHistory") != "1")
            {
               
                try
                {
                   

                    string error;
                    var recommededLocation = Services.GetObject("rl", ident.GetString("Code") + "|" + moveHead.GetString("Receiver"), out error);
                    if (recommededLocation != null)
                    {
                        var locationDebug = moveHead.GetString("Receiver");
                        var debug = recommededLocation.GetString("Location");
                        tbLocation.Text = recommededLocation.GetString("Location");
                    }
                }
                finally
                {
                    string toast = new string("Uspešno procesiran ident.");
                    Toast.MakeText(this, toast, ToastLength.Long).Show();
                }
            }

            lbIdentName.Text = ident.GetString("Name");
            tbSSCC.Enabled = ident.GetBool("isSSCC");
            tbSerialNum.Enabled = ident.GetBool("HasSerialNumber");
           
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // in smartphone

                case Keycode.F1:
                    if (button1.Enabled == true)
                    {
                        Button1_Click(this, null);
                    }
                    break;

                //return true;


                case Keycode.F2:
                    if (btSaveOrUpdate.Enabled == true)
                    {
                        BtSaveOrUpdate_Click(this, null);
                    }
                    break;


                case Keycode.F3:
                    if (button3.Enabled == true)
                    {
                        Button3_Click(this, null);
                    }
                    break;

                case Keycode.F4:
                    if (button5.Enabled == true)
                    {
                        Button5_Click(this, null);
                    }
                    break;

                case Keycode.F5:
                    if (button5.Enabled == true)
                    {
                        Button4_Click(this, null);
                    }
                    break;
                case Keycode.F8:
                    if (button6.Enabled == true)
                    {
                        Button6_Click(this, null);
                    }
                    break;


            }
            return base.OnKeyDown(keyCode, e);
        }



    }
}