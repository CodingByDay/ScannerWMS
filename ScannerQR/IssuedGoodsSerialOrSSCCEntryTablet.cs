﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BarCode2D_Receiver;
using Scanner.App;
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;
using WebApp = TrendNET.WMS.Device.Services.WebApp;

namespace Scanner
{
    [Activity(Label = "IssuedGoodsSerialOrSSCCEntryTablet", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class IssuedGoodsSerialOrSSCCEntryTablet : Activity, IBarcodeResult
    {

        private EditText tbIdent;
        private EditText tbSSCC;
        private EditText tbSerialNum;
        private EditText tbLocation;
        private EditText tbPacking;
        private EditText tbUnits;
        private EditText tbPalette;
        private Button button1;
        private Button btSaveOrUpdate;
        private ListView listData;
        private Button button4;
        private List<string> locations = new List<string>();
        private Button button6;
        private Button button5;
        private Button button7;
        private NameValueObject openIdent = (NameValueObject)InUseObjects.Get("OpenIdent");
        private NameValueObject openOrder = (NameValueObject)InUseObjects.Get("OpenOrder");
        private NameValueObject moveHead = (NameValueObject)InUseObjects.Get("MoveHead");
        private NameValueObject moveItem = (NameValueObject)InUseObjects.Get("MoveItem");
        private NameValueObject extraData = (NameValueObject)InUseObjects.Get("ExtraData");
        private NameValueObject lastItem = (NameValueObject)InUseObjects.Get("LastItem");
        private NameValueObjectList docTypes = null;
        private NameValueObject stock = null;
        private TextView lbQty;
        private bool editMode = false;
        private bool isPackaging = false;
        private TextView lbUnits;
        private TextView lbPalette;
        SoundPool soundPool;
        private Spinner spLocation;
        int soundPoolId;
        private ImageView imagePNG;
        private ProgressDialogClass progress;
        private List<LocationClass> items = new List<LocationClass>();



        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.IssuedGoodsSerialOrSSCCEntryTablet);
            tbIdent = FindViewById<EditText>(Resource.Id.tbIdent);
            tbSSCC = FindViewById<EditText>(Resource.Id.tbSSCC);
            listData = FindViewById<ListView>(Resource.Id.listData);
            tbSerialNum = FindViewById<EditText>(Resource.Id.tbSerialNum);
            tbLocation = FindViewById<EditText>(Resource.Id.tbLocation);
            tbPacking = FindViewById<EditText>(Resource.Id.tbPacking);
            tbUnits = FindViewById<EditText>(Resource.Id.tbUnits);
            tbPalette = FindViewById<EditText>(Resource.Id.tbPalette);
            button1 = FindViewById<Button>(Resource.Id.button1);
            btSaveOrUpdate = FindViewById<Button>(Resource.Id.btSaveOrUpdate);
            button4 = FindViewById<Button>(Resource.Id.button4);
            button6 = FindViewById<Button>(Resource.Id.button6);
            button5 = FindViewById<Button>(Resource.Id.button5);
            button7 = FindViewById<Button>(Resource.Id.button7);
            lbQty = FindViewById<TextView>(Resource.Id.lbQty);
            lbUnits = FindViewById<TextView>(Resource.Id.lbUnits);
            lbPalette = FindViewById<TextView>(Resource.Id.lbPalette);
            imagePNG = FindViewById<ImageView>(Resource.Id.imagePNG);
            spLocation = FindViewById<Spinner>(Resource.Id.spLocation);
            soundPool = new SoundPool(10, Stream.Music, 0);
            soundPoolId = soundPool.Load(this, Resource.Drawable.beep, 1);
            Barcode2D barcode2D = new Barcode2D();
            barcode2D.open(this, this);
            spLocation.ItemSelected += SpLocation_ItemSelected;
            button1.Click += Button1_Click;
            btSaveOrUpdate.Click += BtSaveOrUpdate_Click;
            button4.Click += Button4_Click;
            button5.Click += Button5_Click;
            button6.Click += Button6_Click;
            button7.Click += Button7_Click;
            tbSSCC.KeyPress += TbSSCC_KeyPress;
            tbPacking.FocusChange += TbPacking_FocusChange;



            AdapterLocation adapter = new AdapterLocation(this, items);
            listData.Adapter = adapter;
            


            if (moveHead.GetString("Wharehouse") == "Centralno skladišče Postojna")
            {
                showPicture();
            }
            colorFields();
            var warehouse = moveHead.GetString("Wharehouse");

            fillSugestedLocation(warehouse);
            if (moveHead == null)
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Napaka na aplikaciji");
                alert.SetMessage("Prišlo je do napake in aplikacija se bo zaprla.");

                alert.SetPositiveButton("Ok", (senderAlert, args) =>
                {
                    alert.Dispose();
                    System.Threading.Thread.Sleep(500);
                    throw new ApplicationException("Error. moveHead.");
                });

                Dialog dialog = alert.Create();
                dialog.Show();
            }
            if (openIdent == null)
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Napaka na aplikaciji");
                alert.SetMessage("Prišlo je do napake in aplikacija se bo zaprla.");

                alert.SetPositiveButton("Ok", (senderAlert, args) =>
                {
                    alert.Dispose();
                    System.Threading.Thread.Sleep(500);
                    throw new ApplicationException("Error. openIdent.");
                });

                Dialog dialog = alert.Create();
                dialog.Show();
            }

            docTypes = CommonData.ListDocTypes("P|N");

            if ((lastItem != null) && lastItem.GetBool("IsLastItem"))
            {
                InUseObjects.Invalidate("LastItem");
                button4.Enabled = false;
            }

            LoadRelatedOrder();
            SetUpForm();
            FillTheIdentLocationList();


            await GetLocationsForGivenWarehouse(moveHead.GetString("Wharehouse"));


            var adapterReceive = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleSpinnerItem, locations);
            adapterReceive.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            // Spinner 
            spLocation.Adapter = adapterReceive;
        }

        private void SpLocation_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var element = e.Position;
            var item = locations.ElementAt(element);


            tbLocation.Text = item;
        }

        private async Task FinishMethod()
        {
            await Task.Run(() =>
            {
                if (SaveMoveItem())
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

                        if (WebApp.Get("mode=finish&stock=remove&print=" + Services.DeviceUser() + "&id=" + headID.ToString(), out result))
                        {
                            if (result.StartsWith("OK!"))
                            {
                                RunOnUiThread(() =>
                                {
                                    progress.StopDialogSync();

                                    var id = result.Split('+')[1];

                                    Toast.MakeText(this, "Zaključevanje uspešno! Št. izdaje:\r\n" + id, ToastLength.Long).Show();
                                    InvalidateAndClose();
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
                            Toast.MakeText(this, "Napaka pri klicu do web aplikacije" + result, ToastLength.Long).Show();

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
        private void TbSSCC_KeyPress(object sender, View.KeyEventArgs e)
        {
            if (e.KeyCode == Keycode.Enter)
            {
                //add your logic here 
                FillRelatedData(tbSSCC.Text);
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }






        private async Task GetLocationsForGivenWarehouse(string warehouse)
        {
            await Task.Run(() =>
            {
                List<string> result = new List<string>();
                string error;
                var issuerLocs = Services.GetObjectList("lo", out error, warehouse);

                if (issuerLocs == null)
                {
                    Toast.MakeText(this, "Prišlo je do napake", ToastLength.Long).Show();

                }
                else
                {
                    issuerLocs.Items.ForEach(x =>
                    {
                        var location = x.GetString("LocationID");


                        locations.Add(location);
                    });

                }


            });

        }

        private void TbPacking_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            ProcessQty();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(IssuedGoodsEnteredPositionsViewTablet));
        }




        private void FillTheIdentLocationList()
        {
            var code = openIdent.GetString("Code");

            var wh = moveHead.GetString("Wharehouse");
            // Found the error here the receiver returns not the warehouse but the PETPAK receiver
            var list = GetIdentLocationList.fillItemsOfList(wh, code);
            var debug = true;
            Fill(list);
        }



        private void Fill(System.Collections.ArrayList list)
        {
            foreach (LocationClass obj in list)
            {
                items.Add(obj);
                var item = 32;
            }

            listData.Adapter = null;



            AdapterLocation adapter = new AdapterLocation(this, items);
            listData.Adapter = adapter;
            ///
        }

        private void fillSugestedLocation(string warehouse)
        {
            var ident = openIdent.GetString("Code");

            string result;

            if (WebApp.Get("mode=bestLoc&wh=" + warehouse + "&ident=" + HttpUtility.UrlEncode(ident) + "&locMode=outgoing", out result))
            {
                var test = result;
                if (test != "Exception: The remote server returned an error: (404) Not Found.")
                {
                    tbLocation.Text = result;
                }
                else
                {
                    // Pass for now ie not supported.
                }
            }

            else
            { // Do nothing. }

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
                    tbLocation.Text = location;
                    tbPacking.RequestFocus();
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
        private void showPicture()
        {
            Android.Graphics.Bitmap show = Services.GetImageFromServer("Centralno skladišče Postojna");
            Drawable d = new BitmapDrawable(Resources, show);
            imagePNG.SetImageDrawable(d);

        }
        private void colorFields()
        {
            tbSSCC.SetBackgroundColor(Android.Graphics.Color.Aqua);
            tbSerialNum.SetBackgroundColor(Android.Graphics.Color.Aqua);
            tbLocation.SetBackgroundColor(Android.Graphics.Color.Aqua);

        }
        private void LoadRelatedOrder()
        {

            try
            {


                string error = "N/A";
                if (openOrder == null)
                {
                    editMode = true;
                    if (moveItem == null) { throw new ApplicationException("moveItem not known at this point?!"); }
                    if (string.IsNullOrEmpty(moveItem.GetString("LinkKey")))
                    {
                        openOrder = new NameValueObject("OpenOrder");
                    }
                    else
                    {
                        openOrder = Services.GetObject("oobl", moveItem.GetString("LinkKey") + "|" + moveItem.GetInt("LinkNo").ToString(), out error);
                        if (openOrder == null)
                        {
                            Toast.MakeText(this, "Napaka pri dostopu do web aplikacije: " + error, ToastLength.Long).Show();

                            return;
                        }
                    }
                }
            }
            finally
            {

            }
        }
        private void Button7_Click(object sender, EventArgs e)
        {
            {
                StartActivity(typeof(IssuedGoodsEnteredPositionsViewTablet));
                InvalidateAndClose();
            }

        }

        private void InvalidateAndClose()
        {
            InUseObjects.Invalidate("ExtraData");

        }

        private async void Button6_Click(object sender, EventArgs e)
        {
            await FinishMethod();

            //if (SaveMoveItem())
            //{

            //    try
            //    {

            //        var headID = moveHead.GetInt("HeadID");

            //        string result;
            //        if (WebApp.Get("mode=finish&stock=remove&print=" + Services.DeviceUser() + "&id=" + headID.ToString(), out result))
            //        {
            //            if (result.StartsWith("OK!"))
            //            {
            //                var id = result.Split('+')[1];

            //                Toast.MakeText(this, "Zaključevanje uspešno! Št. izdaje:\r\n" + id, ToastLength.Long).Show();
            //                InvalidateAndClose();
            //                AlertDialog.Builder alert = new AlertDialog.Builder(this);
            //                alert.SetTitle("Zaključevanje uspešno");
            //                alert.SetMessage("Zaključevanje uspešno! Št.prevzema:\r\n" + id);

            //                alert.SetPositiveButton("Ok", (senderAlert, args) =>
            //                {
            //                    alert.Dispose();
            //                });



            //                Dialog dialog = alert.Create();
            //                dialog.Show();
            //            }
            //            else
            //            {

            //                Toast.MakeText(this, "Napaka pri zaklučevanju" + result, ToastLength.Long).Show();
            //            }
            //        }
            //        else
            //        {
            //            Toast.MakeText(this, "Napaka pri klicu do web aplikacije" + result, ToastLength.Long).Show();

            //        }
            //    }
            //    finally
            //    {

            //    }
            //}
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (SaveMoveItem())
            {
                if (moveHead.GetBool("ByOrder") && CommonData.GetSetting("UseSingleOrderIssueing") == "1")
                {
                    StartActivity(typeof(IssuedGoodsIdentEntryWithTrail));
                }
                else
                {
                    StartActivity(typeof(IssuedGoodsIdentEntry));
                }
                InvalidateAndClose();

            }
        }

        private void BtSaveOrUpdate_Click(object sender, EventArgs e)
        {
            if (SaveMoveItem())
            {
                if (editMode)
                {
                    StartActivity(typeof(IssuedGoodsEnteredPositionsViewTablet));

                }

                else
                {
                    StartActivity(typeof(IssuedGoodsSerialOrSSCCEntryTablet));
                }

               

                Finish();

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

        private void SetUpForm()
        {
            tbSSCC.Enabled = openIdent.GetBool("isSSCC");
            tbSerialNum.Enabled = openIdent.GetBool("HasSerialNumber");

            if (moveItem != null)
            {
                tbIdent.Text = moveItem.GetString("IdentName");
                tbSerialNum.Text = moveItem.GetString("SerialNo");
                tbSSCC.Text = moveItem.GetString("SSCC");
                tbLocation.Text = moveItem.GetString("Location");
                tbPalette.Text = moveItem.GetString("Palette");
                tbPacking.Text = moveItem.GetDouble("Packing").ToString();
                tbUnits.Text = moveItem.GetDouble("Factor").ToString();
                btSaveOrUpdate.Text = "Spremeni ser. št. - F2";
            }
            else
            {
                tbIdent.Text = openIdent.GetString("Code") + " " + openIdent.GetString("Name");

                if (extraData != null)
                {
                    tbLocation.Text = extraData.GetString("Location");
                    tbPacking.Text = extraData.GetDouble("Qty").ToString();
                }
            }

            isPackaging = openIdent.GetBool("IsPackaging");
            if (isPackaging)
            {
                tbSSCC.Enabled = false;
                tbSerialNum.Enabled = false;
            }
            else
            {

            }

            if (CommonData.GetSetting("ShowPaletteField") == "1")
            {
                lbPalette.Visibility = ViewStates.Visible;
                tbPalette.Visibility = ViewStates.Visible;
            }

            if (string.IsNullOrEmpty(tbUnits.Text.Trim())) { tbUnits.Text = "1"; }

            if (CommonData.GetSetting("ShowNumberOfUnitsField") == "1")
            {
                lbUnits.Visibility = ViewStates.Visible;
                tbUnits.Visibility = ViewStates.Visible;
            }


            tbIdent.RequestFocus();
            var ident = openIdent.GetString("Code");

            // string error;
            // var s = moveHead.GetString("Issuer");
            // var recommededLocation = Services.GetObject("rl", ident + "|" + moveHead.GetString("Issuer"), out error);
            // if (recommededLocation != null)
            // {

            //    tbLocation.Text = recommededLocation.GetString("Location");
            // }


            var location = CommonData.GetSetting("DefaultProductionLocation");
            tbLocation.Text = location;

            var warehouse = moveHead.GetString("Wharehouse");

            fillSugestedLocation(warehouse);

            tbSSCC.RequestFocus();
            // Revision 30.6.2021. 
            // Revision 30.6.2021. 
        }




        private bool LoadStock(string warehouse, string location, string sscc, string serialNum, string ident)
        {
            try
            {


                string error;
                stock = Services.GetObject("str", warehouse + "|" + location + "|" + sscc + "|" + serialNum + "|" + ident, out error);
                if (stock == null)
                {
                    Toast.MakeText(this, "Napaka pri dostopu do web aplikacije" + error, ToastLength.Long).Show();
                    return false;
                }

                return true;
            }
            finally
            {
                //
            }
        }
        private static bool? checkIssuedOpenQty = null;

        private bool CheckIssuedOpenQty()
        {
            if (checkIssuedOpenQty == null)
            {

                ///
                try
                {
                    string error;
                    var useObj = Services.GetObject("cioqUse", "", out error);
                    checkIssuedOpenQty = useObj == null ? false : useObj.GetBool("Use");
                }
                finally
                {

                }
            }
            return (bool)checkIssuedOpenQty;
        }
        // ---

        private bool SaveMoveItem()
        {
            if (string.IsNullOrEmpty(tbPacking.Text.Trim()))
            {
                return true;
            }

            if (tbSSCC.Enabled && string.IsNullOrEmpty(tbSSCC.Text.Trim()))
            {
                Toast.MakeText(this, "SSCC koda je obvezen podatek", ToastLength.Long).Show();

                tbSSCC.RequestFocus();
                return false;
            }

            if (tbSerialNum.Enabled && string.IsNullOrEmpty(tbSerialNum.Text.Trim()))
            {
                Toast.MakeText(this, "Serijska številka je obvezen podatek!", ToastLength.Long).Show();

                tbSerialNum.RequestFocus();
                return false;
            }

            if (!CommonData.IsValidLocation(moveHead.GetString("Wharehouse"), tbLocation.Text.Trim()))
            {
                Toast.MakeText(this, "Lokacija '" + tbLocation.Text.Trim() + "' ni veljavna za skladišče '" + moveHead.GetString("Wharehouse") + "'!", ToastLength.Long).Show();

                tbLocation.RequestFocus();
                return false;
            }
            if (!LoadStock(moveHead.GetString("Wharehouse"), tbLocation.Text.Trim(), tbSSCC.Text.Trim(), tbSerialNum.Text.Trim(), openIdent.GetString("Code")))
            {
                return false;
            }

            if (string.IsNullOrEmpty(tbPacking.Text.Trim()))
            {
                Toast.MakeText(this, "Količina je obvezen podatek", ToastLength.Long).Show();
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

                        Toast.MakeText(this, "Količina je obvezen podatek in mora biti različna od nič.", ToastLength.Long).Show();

                        tbPacking.RequestFocus();
                        return false;
                    }

                    if (moveHead.GetBool("ByOrder") && !isPackaging && CheckIssuedOpenQty())
                    {
                        var tolerance = openIdent.GetDouble("TolerancePercent");
                        var maxVal = Math.Abs(openOrder.GetDouble("OpenQty") * (1.0 + tolerance / 100));
                        if (Math.Abs(qty) > maxVal)
                        {
                            Toast.MakeText(this, "Količina presega (" + qty.ToString(CommonData.GetQtyPicture()) + ") naročilo (" + maxVal.ToString(CommonData.GetQtyPicture()) + ")!", ToastLength.Long).Show();
                            tbPacking.RequestFocus();
                            return false;
                        }
                    }

                    /*
                    if ((qty > 0) && (qty > stock.GetDouble("RealStock")))
                    {
                        MessageForm.Show("Količina (" + qty.ToString(CommonData.GetQtyPicture ()) + ") presega zalogo (" + stock.GetDouble("RealStock").ToString(CommonData.GetQtyPicture ()) + ")!");
                        tbQty.Focus();
                        return false;
                    }
                    */
                }
                catch (Exception e)
                {
                    Toast.MakeText(this, "Količina mora biti število (" + e.Message + ")!", ToastLength.Long).Show();

                    tbPacking.RequestFocus();
                    return false;
                }
            }

            if (string.IsNullOrEmpty(tbUnits.Text.Trim()))
            {
                Toast.MakeText(this, "Število enota je obvezan podatek", ToastLength.Long).Show();
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
                        Toast.MakeText(this, "Število enota je obvezan podatek in more biti raličit o nič", ToastLength.Long).Show();
                        tbUnits.RequestFocus();
                        return false;
                    }
                }
                catch (Exception e)
                {
                    Toast.MakeText(this, "Število enota mora biti število (" + e.Message, ToastLength.Long).Show();

                    tbUnits.RequestFocus();
                    return false;
                }
            }

            if (CommonData.GetSetting("IssuedGoodsPreventSerialDups") == "1")
            {

                try
                {

                    var headID = moveHead.GetInt("HeadID");
                    var serialNo = tbSerialNum.Text.Trim();
                    var sscc = tbSSCC.Text.Trim();

                    string result;
                    if (WebApp.Get("mode=canAddSerial&hid=" + headID.ToString() + "&sn=" + serialNo + "&sscc=" + sscc, out result))
                    {
                        if (!result.StartsWith("OK!"))
                        {
                            Toast.MakeText(this, result, ToastLength.Long).Show();
                            return false;
                        }
                    }
                    else
                    {
                        Toast.MakeText(this, "Napaka pri klicu web aplikacije" + result, ToastLength.Long).Show();
                        return false;
                    }
                }
                finally
                {
                    //pass
                }
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
                moveItem.SetDouble("Packing", Convert.ToDouble(tbPacking.Text.Trim()));
                moveItem.SetDouble("Factor", Convert.ToDouble(tbUnits.Text.Trim()));
                moveItem.SetDouble("Qty", Convert.ToDouble(tbUnits.Text.Trim()) * Convert.ToDouble(tbPacking.Text.Trim()));
                moveItem.SetInt("Clerk", Services.UserID());
                moveItem.SetString("Location", tbLocation.Text.Trim());
                moveItem.SetString("Palette", tbPalette.Text.Trim());

                string error;
                moveItem = Services.SetObject("mi", moveItem, out error);
                if (moveItem == null)
                {
                    Toast.MakeText(this, "Napaka pri dostopu web aplikacije." + error, ToastLength.Long).Show();
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
                // pass
            }
        }


        private void ProcessQty()
        {
            if (!CommonData.IsValidLocation(moveHead.GetString("Wharehouse"), tbLocation.Text.Trim()))
            {
                Toast.MakeText(this, "Lokacija '" + tbLocation.Text.Trim() + "' ni veljavna za skladišče '" + moveHead.GetString("Wharehouse") + "'!", ToastLength.Long).Show();

                tbLocation.RequestFocus();
                return;
            }

            if (!LoadStock(moveHead.GetString("Wharehouse"), tbLocation.Text.Trim(), tbSSCC.Text.Trim(), tbSerialNum.Text.Trim(), openIdent.GetString("Code")))
            {
                Toast.MakeText(this, "Zaloga za SSCC/Serijsko št. ne obstaja.", ToastLength.Long).Show();

                return;
            }
            else
            {
                string error;
                var fulfilledOrder = Services.GetObject("miho", openOrder.GetString("Key") + "|" + openOrder.GetInt("No") + "|" + openIdent.GetString("Code"), out error);
                var fulfilledQty = fulfilledOrder == null ? 0.0 : fulfilledOrder.GetDouble("Qty");

                tbPacking.Text = stock.GetDouble("RealStock").ToString(CommonData.GetQtyPicture());
                lbQty.Text = "Kol. (" + (openOrder.GetDouble("OpenQty") - fulfilledQty).ToString(CommonData.GetQtyPicture()) + ")";

                /*
                if (openOrder.GetDouble("OpenQty") > stock.GetDouble("RealStock"))
                {
                    MessageForm.Show("Količina (" + openOrder.GetDouble("OpenQty").ToString(CommonData.GetQtyPicture ()) + ") presega zalogo (" + stock.GetDouble("RealStock").ToString(CommonData.GetQtyPicture ()) + ")!");
                }
                */
            }

            tbPacking.RequestFocus();
        }


        private void Button3_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(IssuedGoodsIdentEntryWithTrailTablet));
        }

        public void GetBarcode(string barcode)
        {


            if (tbSSCC.HasFocus)
            {
                if (barcode != "Scan fail")
                {
                    Sound();
                    tbSSCC.Text = barcode;

                    FillRelatedData(tbSerialNum.Text);

                    tbSerialNum.RequestFocus();




                }
            }
            else if (tbSerialNum.HasFocus)
            {
                if (barcode != "Scan fail")
                {
                    Sound();
                    tbSerialNum.Text = barcode;
                    tbLocation.RequestFocus();
                }
            }
            else if (tbLocation.HasFocus)
            {
                if (barcode != "Scan fail")
                {
                    Sound();
                    tbLocation.Text = barcode;
                    tbPacking.RequestFocus();
                }
            }
        }

        private void Sound()
        {
            soundPool.Play(soundPoolId, 1, 1, 0, 0, 1);
        }
    }
}