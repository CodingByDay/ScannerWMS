﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics.Drawables;
using Android.Media;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BarCode2D_Receiver;
using Com.Barcode;
using Com.Toptoche.Searchablespinnerlibrary;
using Microsoft.AppCenter.Crashes;
using Newtonsoft.Json;
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
        private bool isOkayToCallBarcode;
        private Dialog popupDialogMain;
        private bool isBatch = false;
        private string tbLocationPopupVariable;
        private bool isFirst;
        private NameValueObject moveItemBatch;
        private SearchableSpinner spLocationSpinner;
        private EditText tbLocationPopup;
        private bool isSerial;
        private double stockQtyLocal;
        private double stockQtyLocalParams;
        private double stockQtyLocalBatch;
        private double totalAmount = 0;
        private Dialog popupDialogConfirm;
        private Button btnYesConfirm;
        private Button btnNoConfirm;


        // here...
        public void GetBarcode(string barcode)
        {
            if (!string.IsNullOrEmpty(barcode))
            {
                if (tbIdent.HasFocus && isOkayToCallBarcode == false)
                {
                    if (barcode != "Scan fail")
                    {
                        Sound();
                        tbIdent.Text = barcode;
                        ProcessIdent();
                        tbSSCC.RequestFocus();
                    }
                    else
                    {

                    }

                    // Here 

                }
                else if (tbSSCC.HasFocus && isOkayToCallBarcode == false)
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


                        if (FillRelatedBranchIdentData(tbSSCC.Text) && isOkayToCallBarcode == false)
                        {

                            FillRelatedData(tbSSCC.Text);
                            tbLocation.RequestFocus();

                            string error;
                            var dataObject = Services.GetObject("sscc", tbSSCC.Text, out error);
                            var ident = dataObject.GetString("Ident");
                            var loadIdent = CommonData.LoadIdent(ident);
                            string idname = loadIdent.GetString("Name");
                            if (!String.IsNullOrEmpty(idname))
                            {
                                ProcessQty();
                                tbSerialNum.RequestFocus();
                                ProcessQty();
                                data.Clear();
                                TransportOneObject(tbSSCC.Text);
                            }
                            else
                            {
                                tbSSCC.Text = String.Empty;
                                return;
                            }
                           
                        }
                        else
                        {
                            // Go a step back and rescan.
                            tbSSCC.Text = "";
                            tbSSCC.RequestFocus();
                        }


                    }

                }
                else if (tbSerialNum.HasFocus && isOkayToCallBarcode == false)
                {
                    if (barcode != "Scan fail")
                    {
                        Sound();
                        tbSerialNum.Text = barcode;
                        tbIssueLocation.RequestFocus();
                    }

                }
                else if (tbIssueLocation.HasFocus && isOkayToCallBarcode == false)
                {
                    if (barcode != "Scan fail")
                    {
                        Sound();
                        tbIssueLocation.Text = barcode;
                        tbLocation.RequestFocus();
                        ProcessQty();
                    }


                }
                else if (tbLocation.HasFocus && isOkayToCallBarcode == false)
                {
                    if (!String.IsNullOrEmpty(barcode))
                    {
                        Sound();
                        tbLocation.Text = barcode;
                        tbPacking.RequestFocus();
                        ProcessQty();
                    }
                }
                else if (isOkayToCallBarcode == true)
                {
                    if (tbSSCCpopup.HasFocus)
                    {
                        if (!String.IsNullOrEmpty(barcode) && barcode != "Scan fail")
                        {
                            Sound();
                            tbSSCCpopup.Text = barcode;
                            FilData(tbSSCCpopup.Text);

                        }
                    }
                    else if (tbLocationPopup.HasFocus)
                    {

                        if (!String.IsNullOrEmpty(barcode))
                        {
                            Sound();
                            tbLocationPopup.Text = barcode;


                        }

                    }
                }


            }
        }

        private bool FillRelatedBranchIdentData(string text)
        {
            string error;

            var data = Services.GetObject("sscc", text, out error);



            if (data != null)
            {
                var ident = data.GetString("Ident");
                var name = data.GetString("IdentName");


                tbIdent.Text = ident;
                lbIdentName.Text = name;

                if (tbIdent.Text != null && lbIdentName.Text != null) { return true; } else { return false; }


            }
            else
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
                    var location = data.GetString("Location");
                    tbIssueLocation.Text = location;
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
                if (!isSerial)
                {
                    RunOnUiThread(() =>
                    {
                        string WebError = string.Format("SSCC koda je obvezen podatek.");
                        Toast.MakeText(this, WebError, ToastLength.Long).Show();
                        tbSSCC.RequestFocus();
                    });

                    return false;
                }
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
                    if (!isSerial)
                    {
                        stockQtyLocal = GetStock(moveHead.GetString("Issuer"), tbIssueLocation.Text.Trim(), tbSSCC.Text.Trim(), tbSerialNum.Text.Trim(), tbIdent.Text.Trim());
                    }
                    else
                    {
                        stockQtyLocal = GetStockSerial(moveHead.GetString("Issuer"), tbIssueLocation.Text.Trim(), tbSerialNum.Text.Trim(), tbIdent.Text.Trim());

                    }
                    if (Double.IsNaN(stockQtyLocal))
                    {
                        RunOnUiThread(() =>
                        {
                            string WebError = string.Format("Zaloga ni znana, vpišite potrebne podatke");
                            Toast.MakeText(this, WebError, ToastLength.Long).Show();
                        });


                        //  SelectNext(tbIdent);
                        return false;
                    }
                    if (Math.Abs(qty) > Math.Abs(stockQtyLocal))
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
                var test = moveItem.ToString();

                var breakpoint = true;
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

        private async Task<bool> SaveMoveItemWithParams(MorePallets objectItem, bool isFirst)
        {

            if (string.IsNullOrEmpty(objectItem.Ident.Trim()) && string.IsNullOrEmpty(objectItem.Serial) && string.IsNullOrEmpty(objectItem.Quantity.Trim()))
            {
                return true;
            }

            if (string.IsNullOrEmpty(objectItem.SSCC))
            {
                if (!isSerial)
                {
                    RunOnUiThread(() =>
                    {
                        string WebError = string.Format("SSCC koda je obvezen podatek.");
                        Toast.MakeText(this, WebError, ToastLength.Long).Show();
                        tbSSCC.RequestFocus();
                    });

                    return false;
                }
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
                    if (!isSerial)
                    {
                        stockQtyLocalParams = GetStock(moveHead.GetString("Issuer"), tbIssueLocation.Text.Trim(), tbSSCC.Text.Trim(), tbSerialNum.Text.Trim(), tbIdent.Text.Trim());
                    }
                    else
                    {
                        stockQtyLocalParams = GetStockSerial(moveHead.GetString("Issuer"), tbIssueLocation.Text.Trim(), tbSerialNum.Text.Trim(), tbIdent.Text.Trim());

                    }
                    if (Double.IsNaN(stockQtyLocalParams))
                    {
                        RunOnUiThread(() =>
                        {
                            string WebError = string.Format("Zaloga ni znana, vpišite potrebne podatke");
                            Toast.MakeText(this, WebError, ToastLength.Long).Show();
                        });


                        //  SelectNext(tbIdent);
                        return false;
                    }
                    if (Math.Abs(qty) > Math.Abs(stockQtyLocalParams))
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


                moveItem = null;
                if (moveItem == null)
                {

                    moveItem = new NameValueObject("MoveItem");
                }


                moveItem.SetInt("HeadID", moveHead.GetInt("HeadID"));
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
                string SuccessMessage = string.Format("Izdajna lokacija" + tbIssueLocation.Text.Trim() + "ni veljavna za skladisće" + moveHead.GetString("Issuer") + "'!");
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
            tbSSCC.InputType = Android.Text.InputTypes.ClassNumber;
   
         
            tbUnits.InputType = Android.Text.InputTypes.ClassNumber;
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
            tbSSCC.KeyPress += TbSSCC_KeyPress;
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
                btSaveOrUpdate.Text = "Serijska - F2";

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


            tbLocation.FocusChange += TbLocation_FocusChange;
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

        private void TbLocation_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            if (isSerial)
            {
                ProcessQtySerial();
            }
        }

        private void TbSSCC_KeyPress(object sender, View.KeyEventArgs e)
        {
            e.Handled = false;

            if (e.KeyCode == Keycode.Enter)
            {
                FillRelatedBranchIdentData(tbSSCC.Text);
                FillRelatedData(tbSSCC.Text);

                ProcessQty();
                tbLocation.RequestFocus();
                e.Handled = true;


            }
        }

        private void LvCardMore_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var index = e.Position;
            var element = data.ElementAt(index);
            string formated = $"Izbrali ste {element.SSCC}.";
            Toast.MakeText(this, formated, ToastLength.Long).Show();
        }
        private void ProcessQtySerial()
        {

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
                string SuccessMessage = string.Format("Izdajna lokacija" + tbIssueLocation.Text.Trim() + "ni veljavna za skladisće" + moveHead.GetString("Issuer") + "'!");
                Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();
                tbIssueLocation.RequestFocus();

                return;
            }

            var stockQty = GetStockSerial(moveHead.GetString("Issuer"), tbIssueLocation.Text.Trim(), serialNo, ident);
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
        private double GetStockSerial(string warehouse, string location, string serialNum, string ident)
        {

            return LoadStockFromPAStockSerialNo(warehouse, ident, serialNum);


        }
        private void TbSerialNum_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbSSCC.Text))
            {
                this.isSerial = false;
                if (FillRelatedBranchIdentData(tbSSCC.Text))
                {

                    FillRelatedData(tbSSCC.Text);

                    ProcessQty();
                    tbLocation.RequestFocus();


                }
            }
            else
            {



                this.isSerial = true;

            }
        }
        private void TransportOneObject(string sscc)
        {
            if (!String.IsNullOrEmpty(sscc))
            {
                string error;
                var dataObject = Services.GetObject("sscc", sscc, out error);
                if (dataObject != null)
                {
                    var ident = dataObject.GetString("Ident");
                    var loadIdent = CommonData.LoadIdent(ident);
                    var name = dataObject.GetString("IdentName");
                    var serial = dataObject.GetString("SerialNo");
                    var location = dataObject.GetString("Location");
                    var qty = dataObject.GetString("Location");
                    MorePallets pallets = new MorePallets();
                    pallets.Ident = ident;
                    string idname = loadIdent.GetString("Name");
                    pallets.Location = location;
                    pallets.Quantity = location;
                    pallets.SSCC = sscc;
                    pallets.Serial = serial;

                    if(String.IsNullOrEmpty(idname)) { return; }
                    try
                    {
                        pallets.Name = idname.Trim().Substring(0, 3);
                    }
                    catch (Exception)
                    {

                    }
                    pallets.Quantity = qty;
                    pallets.SSCC = sscc;
                    pallets.Serial = serial;

                    try
                    {
                        pallets.friendlySSCC = pallets.SSCC.Substring(pallets.SSCC.Length - 3);
                    }
                    catch (Exception)
                    {
                        pallets.Name = "Error";
                    }
                    enabledSerial = loadIdent.GetBool("HasSerialNumber");


#nullable enable        
                    MorePallets? obj = ProcessQtyWithParams(pallets, location);
#nullable disable
                    /* Adds an object to the list. */
                    if (obj is null)
                    {
                        Toast.MakeText(this, "Ne obstaja.", ToastLength.Long).Show();
                        if (isOkayToCallBarcode == true)
                        {
                            tbSSCCpopup.Text = "";
                        }
                    }
                    else
                    {
                        data.Add(obj);
                        totalAmount = totalAmount + Convert.ToDouble(obj.Quantity);
                    }
                }
                else
                {
                    return;
                }
            }
        }
        private void BtMorePallets_Click(object sender, EventArgs e)
        {
            isOkayToCallBarcode = true;
            // StartActivity(typeof(MorePalletsClass));
            popupDialogMain = new Dialog(this);
            popupDialogMain.SetContentView(Resource.Layout.MorePalletsClass);
            popupDialogMain.Window.SetSoftInputMode(SoftInput.AdjustResize);
            popupDialogMain.Show();
            popupDialogMain.Window.SetLayout(LayoutParams.MatchParent, LayoutParams.WrapContent);
            spLocationSpinner = popupDialogMain.FindViewById<SearchableSpinner>(Resource.Id.spLocation);
            spLocationSpinner.Visibility = ViewStates.Invisible;
            btConfirm = popupDialogMain.FindViewById<Button>(Resource.Id.btConfirm);
            btExit = popupDialogMain.FindViewById<Button>(Resource.Id.btExit);
            tbLocationPopup = popupDialogMain.FindViewById<EditText>(Resource.Id.tbLocation);

            tbLocationPopup.SetBackgroundColor(Android.Graphics.Color.Aqua);

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
            tbSSCCpopup.RequestFocus();
        }

        private void BtExit_Click(object sender, EventArgs e)
        {
            isOkayToCallBarcode = false;
            popupDialogMain.Dismiss();
            popupDialogMain.Hide();
        }

        private void BtConfirm_Click(object sender, EventArgs e)
        {
            if (data.Count != 0 && !String.IsNullOrEmpty(tbLocationPopup.Text))
            {
                string formatedString = $"{data.Count} skeniranih SSCC koda.";
                tbSSCC.Text = formatedString;
                tbSerialNum.Text = "...";
                tbIssueLocation.Text = "...";
                tbIdent.Text = "...";
                tbPacking.Text = totalAmount.ToString(CommonData.GetQtyPicture()); 
                tbLocation.RequestFocus();
                isBatch = true;
                tbLocationPopupVariable = tbLocationPopup.Text;
                popupDialogMain.Dismiss();
                popupDialogMain.Hide();
                SavePositions(data);
                UpdateTheLocationAPICall(tbLocationPopupVariable);

            }
            else
            {
                popupDialogMain.Dismiss();
                popupDialogMain.Hide();
                Toast.MakeText(this, "Manjkajo podatki.", ToastLength.Long).Show();
            }

        }
        private void UpdateTheLocationAPICall(string location)
        {

            try
            {

                var headID = moveHead.GetInt("HeadID");

                string result;
                if (WebApp.Get("mode=mhLoc&id=" + headID + "&loc=" + location, out result))
                {
                    if (result.StartsWith("OK!"))
                    {

                        RunOnUiThread(() =>
                        {

                        });
                    }
                    else
                    {
                        RunOnUiThread(() =>
                        {




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
                tbLocation.Text = location;
            }
        }

        private async Task<bool> SaveMoveItemBatch(MorePallets obj)
        {

            if (string.IsNullOrEmpty(obj.Ident) && string.IsNullOrEmpty(obj.Serial) && string.IsNullOrEmpty(obj.Quantity))
            {
                return true;
            }

            if (tbSSCC.Enabled && string.IsNullOrEmpty(obj.SSCC))
            {
                if (!isSerial)
                {

                    return false;
                }
            }

            if (tbSerialNum.Enabled && string.IsNullOrEmpty(obj.Serial.Trim()))
            {


                return false;
            }

            if (string.IsNullOrEmpty(obj.Quantity.Trim()))
            {

                return false;
            }
            else
            {
                try
                {
                    var qty = Convert.ToDouble(obj.Quantity.Trim());
                    if (qty == 0.0)
                    {


                        return false;
                    }
                    if (!isSerial)
                    {
                        stockQtyLocalBatch = GetStock(moveHead.GetString("Issuer"), tbIssueLocation.Text.Trim(), tbSSCC.Text.Trim(), tbSerialNum.Text.Trim(), tbIdent.Text.Trim());
                    }
                    else
                    {
                        stockQtyLocalBatch = GetStockSerial(moveHead.GetString("Issuer"), tbIssueLocation.Text.Trim(), tbSerialNum.Text.Trim(), tbIdent.Text.Trim());

                    }
                    if (Double.IsNaN(stockQtyLocalBatch))
                    {


                        return false;
                    }
                    if (Math.Abs(qty) > Math.Abs(stockQtyLocalBatch))
                    {


                        return false;
                    }
                }
                catch (Exception e)
                {


                    return false;
                }
            }

            if (string.IsNullOrEmpty(tbUnits.Text.Trim()))
            {


                return false;
            }
            else
            {
                try
                {
                    var units = Convert.ToDouble(tbUnits.Text.Trim());
                    if (units == 0.0)
                    {


                        return false;
                    }
                }
                catch (Exception e)
                {




                    return false;
                }
            }

            if (!CommonData.IsValidLocation(moveHead.GetString("Issuer"), obj.Location))
            {


                return false;
            }

            if (!CommonData.IsValidLocation(moveHead.GetString("Receiver"), tbLocationPopupVariable))
            {


                return false;
            }

            try
            {

                double doubleQuantity = Convert.ToDouble(obj.Quantity.Trim());
                moveItemBatch = new NameValueObject("MoveItem");

                // Logic for the same head ID.

                moveItemBatch.SetInt("HeadID", moveHead.GetInt("HeadID"));

                moveItemBatch.SetString("LinkKey", "");
                moveItemBatch.SetInt("LinkNo", 0);
                moveItemBatch.SetString("Ident", obj.Ident.Trim());
                moveItemBatch.SetString("SSCC", obj.SSCC.Trim());
                moveItemBatch.SetString("SerialNo", obj.Serial.Trim());
                moveItemBatch.SetDouble("Packing", Convert.ToDouble(obj.Quantity.Trim()));
                moveItemBatch.SetDouble("Factor", Convert.ToDouble(tbUnits.Text.Trim()));
                moveItemBatch.SetDouble("Qty", Convert.ToDouble(doubleQuantity) * Convert.ToDouble(tbUnits.Text.Trim()));
                moveItemBatch.SetInt("Clerk", Services.UserID());
                moveItemBatch.SetString("Location", "");
                moveItemBatch.SetString("IssueLocation", obj.Location.Trim());



                string error;
                moveItem = Services.SetObject("mi", moveItemBatch, out error);
                var test = GetJSONforMoveItem(moveItem);
                if (moveItem == null)
                {

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
        private string GetJSONforMoveItem(NameValueObject moveItem)
        {
            moveItem item = new moveItem();
            item.HeadID = moveHead.GetInt("HeadID");
            item.LinkKey = moveItem.GetString("LinkKey");
            item.LinkNo = moveItem.GetInt("LinkNo");
            item.Ident = moveItem.GetString("Ident");
            item.SSCC = moveItem.GetString("SSCC");
            item.SerialNo = moveItem.GetString("SerialNo");
            item.Packing = moveItem.GetDouble("Packing");
            item.Factor = moveItem.GetDouble("Factor");
            item.Qty = moveItem.GetDouble("Qty");
            item.Clerk = moveItem.GetInt("Clerk");
            item.Location = moveItem.GetString("Location");
            item.IssueLocation = moveItem.GetString("IssueLocation");

            var jsonString = JsonConvert.SerializeObject(item);


            return jsonString;
        }
        private async void SavePositions(List<MorePallets> datax)
        {
            progress = new ProgressDialogClass();
            progress.ShowDialogSync(this, "Shranjujem pozicije.");
            foreach (var x in datax)
            {

                await SaveMoveItemBatch(x);

            }
            progress.StopDialogSync();
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
            var item = data.ElementAt(index);
            totalAmount = totalAmount - Convert.ToDouble(item.Quantity);
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
                    pallets.Location = location;
                    pallets.Ident = ident;
                    string idname = loadIdent.GetString("Name");

                    if (String.IsNullOrEmpty(idname)) { return; }


                    try
                    {
                        pallets.Name = idname.Trim().Substring(0, 5) ?? "Not correct.";
                    }
                    catch (Exception)
                    {
                        pallets.Name = "Error";
                    }

                    pallets.Quantity = barcode;
                    pallets.SSCC = barcode;
                    pallets.Serial = serial;

                    try
                    {
                        pallets.friendlySSCC = pallets.SSCC.Substring(pallets.SSCC.Length - 3) ?? "Not correct";
                    }
                    catch (Exception)
                    {
                        pallets.Name = "Error";
                    }

                    enabledSerial = loadIdent.GetBool("HasSerialNumber");


#nullable enable        
                    MorePallets? obj = ProcessQtyWithParams(pallets, location);
#nullable disable
                    /* Adds an object to the list. */
                    if (obj is null)
                    {
                        Toast.MakeText(this, "Ne obstaja.", ToastLength.Long).Show();
                        tbSSCCpopup.Text = String.Empty;    
                    }
                    else
                    {
                        data.Add(obj);
                        // Added to the list
                        totalAmount = totalAmount + Convert.ToDouble(obj.Quantity);
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
            else
            {
                e.Handled = false;
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
            }
            else
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
            var resultAsync = SaveMoveItem().Result;
            if (resultAsync)
            {
                if (editMode)
                {
                    StartActivity(typeof(InterWarehouseEnteredPositionsView));
                    HelpfulMethods.clearTheStack(this);
                }
                else
                {
                    StartActivity(typeof(InterWarehouseSerialOrSSCCEntry));
                    HelpfulMethods.clearTheStack(this);
                }
                this.Finish();
            }
        }

        private async void Button3_Click(object sender, EventArgs e)
        {
            var resultAsync = SaveMoveItem().Result;
            if (resultAsync)
            {
                StartActivity(typeof(InterWarehouseSerialOrSSCCEntry));
                HelpfulMethods.clearTheStack(this);
            }
        }
        private async Task FinishMethod()
        {
            await Task.Run(async () =>
            {
                var resultAsync = SaveMoveItem().Result;
                if (resultAsync)
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
                                        HelpfulMethods.clearTheStack(this);
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
                            RunOnUiThread(() =>
                            {
                                string SuccessMessage = string.Format("Napaka pri klicu web aplikacije");
                                Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();
                            });
                           
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

                int check = 0;

                RunOnUiThread(() =>
                {
                    progress = new ProgressDialogClass();
                    progress.ShowDialogSync(this, "Zaključujem več paleta na enkrat.");
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
                                    System.Threading.Thread.Sleep(500);

                                    StartActivity(typeof(MainMenu));
                                    HelpfulMethods.clearTheStack(this);
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
                                    HelpfulMethods.clearTheStack(this);

                                });

                                Dialog dialog = alert.Create();
                                dialog.Show();
                            });

                        }
                    }
                    else
                    {
                        RunOnUiThread(() =>
                        {
                            string SuccessMessage = string.Format("Napaka pri klicu web aplikacije");
                            Toast.MakeText(this, SuccessMessage, ToastLength.Long).Show();
                        });
                      
                    }
                }
                finally
                {
                    RunOnUiThread(() =>
                    {
                        progress.StopDialogSync();

                    });
                }
            });
        }

        private async void Button5_Click(object sender, EventArgs e)
        {
            popupDialogConfirm = new Dialog(this);
            popupDialogConfirm.SetContentView(Resource.Layout.Confirmation);
            popupDialogConfirm.Window.SetSoftInputMode(SoftInput.AdjustResize);
            popupDialogConfirm.Show();

            popupDialogConfirm.Window.SetLayout(LayoutParams.MatchParent, LayoutParams.WrapContent);
            popupDialogConfirm.Window.SetBackgroundDrawableResource(Android.Resource.Color.HoloRedLight);

            // Access Popup layout fields like below
            btnYesConfirm = popupDialogConfirm.FindViewById<Button>(Resource.Id.btnYes);
            btnNoConfirm = popupDialogConfirm.FindViewById<Button>(Resource.Id.btnNo);
            btnYesConfirm.Click += BtnYesConfirm_Click;
            btnNoConfirm.Click += BtnNoConfirm_Click;



        }

        private void BtnNoConfirm_Click(object sender, EventArgs e)
        {
            popupDialogConfirm.Dismiss();
            popupDialogMain.Hide();
        }

        private async void BtnYesConfirm_Click(object sender, EventArgs e)
        {
            if (!isBatch)
            {
                await FinishMethod();
            }
            else
            {
                await FinishMethodBatch();
            }
        }



        private void Button4_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(InterWarehouseEnteredPositionsView));
            HelpfulMethods.clearTheStack(this);
        }


        private void Button6_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainMenu));
            HelpfulMethods.clearTheStack(this);
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