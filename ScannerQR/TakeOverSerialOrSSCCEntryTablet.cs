using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BarCode2D_Receiver;
using Com.Jsibbold.Zoomage;
using Scanner.App;
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;
using static Android.App.ActionBar;
using WebApp = TrendNET.WMS.Device.Services.WebApp;

namespace Scanner
{
    [Activity(Label = "TakeOverSerialOrSSCCEntryTablet", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class TakeOverSerialOrSSCCEntryTablet : Activity, IBarcodeResult
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
        private Spinner spLocation;
        private TextView lbUnits;
        private Button button1;
        private ListView listData;
        SoundPool soundPool;
        int soundPoolId;
        private string ident;
        private List<string> locList = new List<string>();
        private ZoomageView warehousePNG;
        private List<TakeOverSerialOrSSCCEntryList> data = new List<TakeOverSerialOrSSCCEntryList>();
        private List<LocationClass> items = new List<LocationClass>();
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here.
            SetContentView(Resource.Layout.TakeOverSerialOrSSCCEntryTablet);
            // 
            //
            listData = FindViewById<ListView>(Resource.Id.listData);

            fillItems();
            tbIdent = FindViewById<EditText>(Resource.Id.tbIdent);
            tbSSCC = FindViewById<EditText>(Resource.Id.tbSSCC);
            tbSerialNum = FindViewById<EditText>(Resource.Id.tbSerialNum);
            tbLocation = FindViewById<EditText>(Resource.Id.tbLocation);
            tbPacking = FindViewById<EditText>(Resource.Id.tbPacking);
            tbUnits = FindViewById<EditText>(Resource.Id.tbUnits);
            warehousePNG = FindViewById<ZoomageView>(Resource.Id.warehousePNG);
            // Buttons.
            AdapterLocation adapter = new AdapterLocation(this, items);
      
            spLocation = FindViewById<Spinner>(Resource.Id.spLocation);
            btSaveOrUpdate = FindViewById<Button>(Resource.Id.btSaveOrUpdate);
            button4 = FindViewById<Button>(Resource.Id.button4);
            button6 = FindViewById<Button>(Resource.Id.button6);
            button5 = FindViewById<Button>(Resource.Id.button5);
            button7 = FindViewById<Button>(Resource.Id.button7);
            // 
            lbQty = FindViewById<TextView>(Resource.Id.lbQty);
            lbUnits = FindViewById<TextView>(Resource.Id.lbUnits);
            button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += Button1_Click;
            soundPool = new SoundPool(10, Stream.Music, 0);
            soundPoolId = soundPool.Load(this, Resource.Drawable.beep, 1);
            Barcode2D barcode2D = new Barcode2D();
            barcode2D.open(this, this);
            listData.ItemClick += ListData_ItemClick;
            btSaveOrUpdate.Click += BtSaveOrUpdate_Click;
            button4.Click += Button4_Click;
            button6.Click += Button6_Click;
            button7.Click += Button7_Click;
            button5.Click += Button5_Click;
            spLocation.ItemSelected += SpLocation_ItemSelected;
            warehousePNG.Visibility = ViewStates.Invisible;

            warehousePNG.Click += WarehousePNG_Click;

            /// Consider changing this to something else.


          
            //
            // Exceptions
            if (moveHead == null) { throw new ApplicationException("moveHead not known at this point?!"); }
            if (openIdent == null) { throw new ApplicationException("openIdent not known at this point?!"); }
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
                                    ident = openOrder.GetString("Ident");

                    }
                    else
                    {
                        editMode = true;
                        openOrder = Services.GetObject("oobl", moveItem.GetString("LinkKey") + "|" + moveItem.GetInt("LinkNo").ToString(), out error);
                        ident = openOrder.GetString("Ident");

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
            tbLocation.RequestFocus();
            FillRelatedData();
            tbSerialNum.RequestFocus();




            FillTheIdentLocationList();

            await GetLocationsForGivenWarehouse(moveHead.GetString("Wharehouse"));
        



            var DataAdapter = new ArrayAdapter<string>(this,
            Android.Resource.Layout.SimpleSpinnerItem, locList);

            DataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spLocation.Adapter = DataAdapter;

            tbSerialNum.RequestFocus();
            spLocation.SetSelection(locList.IndexOf("P01"), true);
            showPictureIdent(tbIdent.Text);
        }

      
        private void WarehousePNG_Click(object sender, EventArgs e)
        {
            popupDialog = new Dialog(this);
            popupDialog.SetContentView(Resource.Layout.WarehousePicture);
            popupDialog.Window.SetSoftInputMode(SoftInput.AdjustResize);
            popupDialog.Show();

            popupDialog.Window.SetLayout(LayoutParams.MatchParent, LayoutParams.WrapContent);
            popupDialog.Window.SetBackgroundDrawableResource(Android.Resource.Color.HoloBlueBright);
            image = popupDialog.FindViewById<ZoomageView>(Resource.Id.image);
            // Access Popup layout fields like below
           
       
        }

   

        private void SpLocation_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            int element = e.Position;


            var item = locList.ElementAt(element);

            tbLocation.Text = item;
            tbPacking.RequestFocus();
        }

     


        // moveHead.GetString("Wharehouse")



        private void FillTheIdentLocationList()
        {


           var ident = openIdent.GetString("Code");
           var wh = moveHead.GetString("Wharehouse");
           var list =  GetIdentLocationList.fillItemsOfList(wh, ident);
        
           
           Fill(list);
        }

        private void Fill(System.Collections.ArrayList list)
        {
            foreach(LocationClass obj in list)
            {
                items.Add(obj);
            }

            listData.Adapter = null;



            AdapterLocation adapter = new AdapterLocation(this, items);
            listData.Adapter = adapter;
            
        }

        private async Task FinishMethod()
        {
            await Task.Run(async () =>
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
                        if (WebApp.Get("mode=finish&stock=add&print=" + Services.DeviceUser() + "&id=" + headID.ToString(), out result))
                        {
                            if (result.StartsWith("OK!"))
                            {
                                RunOnUiThread(() =>
                                {
                                    progress.StopDialogSync();
                                    var id = result.Split('+')[1];


                                    AlertDialog.Builder alert = new AlertDialog.Builder(this);
                                    alert.SetTitle("Uspešno zaključevanje");
                                    alert.SetMessage("Zaključevanje uspešno! Št. prevzema:\r\n" + id);

                                    alert.SetPositiveButton("Ok", (senderAlert, args) =>
                                    {
                                        alert.Dispose();
                                        System.Threading.Thread.Sleep(500);
                                        StartActivity(typeof(MainMenuTablet));
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
                                        StartActivity(typeof(MainMenuTablet));

                                    });



                                    Dialog dialog = alert.Create();
                                    dialog.Show();
                                });

                            }
                        }
                        else
                        {
                            Toast.MakeText(this, "Napaka pri klicu web aplikacije: " + result, ToastLength.Long).Show();

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

      
        private void showPicture()
        {
            try
            {
                Android.Graphics.Bitmap show = Services.GetImageFromServer(moveHead.GetString("Wharehouse"));
                var debug = moveHead.GetString("Wharehouse");
                Drawable d = new BitmapDrawable(Resources, show);
                warehousePNG.SetImageDrawable(d);
                warehousePNG.Visibility = ViewStates.Visible;


                warehousePNG.Click += (e, ev) => { ImageClick(d); };

            } catch(Exception error)
            {
                return;
            }
            
        }



        private void showPictureIdent(string ident)
        {
            try
            {
                Android.Graphics.Bitmap show = Services.GetImageFromServerIdent(moveHead.GetString("Wharehouse"), ident);
                var debug = moveHead.GetString("Wharehouse");
                Drawable d = new BitmapDrawable(Resources, show);

                warehousePNG.SetImageDrawable(d);
                warehousePNG.Visibility = ViewStates.Visible;


                warehousePNG.Click += (e, ev) => { ImageClick(d); };

            }
            catch (Exception error)
            {
                var log = error;
                return;
            }

        }

        private void ImageClick(Drawable d)
        {
            popupDialog = new Dialog(this);
            popupDialog.SetContentView(Resource.Layout.WarehousePicture);
            popupDialog.Window.SetSoftInputMode(SoftInput.AdjustResize);
            popupDialog.Show();

            popupDialog.Window.SetLayout(LayoutParams.MatchParent, LayoutParams.WrapContent);
            popupDialog.Window.SetBackgroundDrawableResource(Android.Resource.Color.HoloBlueBright);
            image = popupDialog.FindViewById<ZoomageView>(Resource.Id.image);
            image.SetMinimumHeight(500);
            image.SetMinimumWidth(800);
            image.SetImageDrawable(d);
            // Access Popup layout fields like below
  
        }

        private void BtnOK_Click1(object sender, EventArgs e)
        { 

            popupDialog.Dismiss();
            popupDialog.Dispose();
           
        }

        private void ListData_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            selected = e.Position;
            var item = data.ElementAt(selected);
            tbLocation.Text = item.Location;

        }
        private async Task GetLocationsForGivenWarehouse(string warehouse)
        {
            await Task.Run(() =>
            {
                string error;
                var locations = Services.GetObjectList("lo", out error, warehouse);

                if (locations == null)
                {
                    Toast.MakeText(this, "Prišlo je do napake", ToastLength.Long).Show();
                }
                else
                {
                    locations.Items.ForEach(x =>
                    {
                        var location = x.GetString("LocationID");

                        locList.Add(location);
                        
                    });
                }


            });
        }
        private void fillItems()
        {
         
           string error;
            var stock = Services.GetObjectList("str", out error, moveHead.GetString("Wharehouse") + "||" + ident); /* Defined at the beggining of the activity. */
            var number = stock.Items.Count();

          
            if (stock != null)
            {
                stock.Items.ForEach(x =>
                {
                    data.Add(new TakeOverSerialOrSSCCEntryList
                    {
                        Ident = x.GetString("Ident"),
                        Location = x.GetString("Location"),
                        Qty = x.GetDouble("RealStock").ToString(),
                        SerialNumber = x.GetString("SerialNo")
                       
                    });
                });

            }
            TakeOverSerialOrSSCCEntryAdapter adapter = new TakeOverSerialOrSSCCEntryAdapter(this, data);

            listData.Adapter = null;
            listData.Adapter = adapter;

            var debug = data.Count();
           
        }



        private void Button5_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(TakeOverEnteredPositionsViewTablet));
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
            StartActivity(typeof(MainMenuTablet));
        }


        private async void Button4_Click(object sender, EventArgs e)
        {
            if (await SaveMoveItem())
            {
                StartActivity(typeof(TakeOverIdentEntryTablet));
             }
        }


        private async void BtSaveOrUpdate_Click(object sender, EventArgs e)
        {
            if (await SaveMoveItem())
            {
                if (editMode)
                {
                    StartActivity(typeof(TakeOverEnteredPositionsViewTablet));
                }
                else
                {
                    StartActivity(typeof(TakeOverSerialOrSSCCEntryTablet));
                }

            }
        }

        private static bool? checkTakeOverOpenQty = null;
        private int selected;
        private ProgressDialogClass progress;
        private Dialog popupDialog;
        private ZoomageView image;
        private Button btnOK;

        private async void Button6_Click(object sender, EventArgs e)
        {
            await FinishMethod();

            //Toast.MakeText(this, "Zaključujem... Prosim počakajte.", ToastLength.Long).Show(); //
            //if (SaveMoveItem())
            //{

            //    try
            //    {

            //        var headID = moveHead.GetInt("HeadID");

            //        string result;
            //        if (WebApp.Get("mode=finish&stock=add&print=" + Services.DeviceUser() + "&id=" + headID.ToString(), out result))
            //        {
            //            if (result.StartsWith("OK!"))
            //            {
            //                var id = result.Split('+')[1];
            //                Toast.MakeText(this, "Zaključevanje uspešno! Št. prevzema:\r\n" + id, ToastLength.Long).Show();
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
            //                Toast.MakeText(this, "Napaka pri zaključevanju: " + result, ToastLength.Long).Show();

            //            }
            //        }
            //        else
            //        {
            //            Toast.MakeText(this, "Napaka pri klicu web aplikacije: " + result, ToastLength.Long).Show();

            //        }
            //    }
            //    finally
            //    {

            //    }


            //}
        }
        private void FillRelatedData()
        {
            string error;

            var data = Services.GetObject("sscc", tbSSCC.Text, out error);
            if (data != null)
            {
                if (tbSerialNum.Enabled == true)
                {
                    var serial = data.GetString("SerialNo");
                    tbSerialNum.Text = serial;

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


        private async Task<bool> SaveMoveItem()
        {
            if (string.IsNullOrEmpty(tbSSCC.Text.Trim()) && string.IsNullOrEmpty(tbSerialNum.Text.Trim()) && string.IsNullOrEmpty(tbPacking.Text.Trim()))
            {

                return true;
            }

            if (tbSSCC.Enabled && string.IsNullOrEmpty(tbSSCC.Text.Trim()))
            {
                RunOnUiThread(() =>
                {
                    string errorWebAppIssued = string.Format("SSCC koda je obvezan podatek. ");
                    Toast.MakeText(this, errorWebAppIssued, ToastLength.Long).Show();
                    tbSSCC.RequestFocus();
                });

                return false;
            }

            if (tbSerialNum.Enabled && openIdent.GetBool("HasSerialNumber"))
            {
                if (string.IsNullOrEmpty(tbSerialNum.Text.Trim()))
                {
                    RunOnUiThread(() =>
                    {
                        string errorWebAppIssued = string.Format("Serijska številka je obvezan podatek.");
                        Toast.MakeText(this, errorWebAppIssued, ToastLength.Long).Show();
                        tbSerialNum.RequestFocus();
                    });

                    return false;
                }
            }

            if (string.IsNullOrEmpty(tbPacking.Text.Trim()))
            {
                RunOnUiThread(() =>
                {
                    string errorWebAppIssued = string.Format("Količina je obvezen podatek.");
                    Toast.MakeText(this, errorWebAppIssued, ToastLength.Long).Show();
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
                            string errorWebAppIssued = string.Format("Količina je obvezen podatek in mora biti različna od nič");
                            Toast.MakeText(this, errorWebAppIssued, ToastLength.Long).Show();
                            tbPacking.RequestFocus();
                        });

                        return false;
                    }

                    if (moveHead.GetBool("ByOrder") && !isPackaging && CheckTakeOverOpenQty())
                    {
                        var tolerance = openIdent.GetDouble("TolerancePercent");
                        var max = Math.Abs(openOrder.GetDouble("OpenQty") * (1.0 + tolerance / 100));
                        if (Math.Abs(qty) > max)
                        {
                            RunOnUiThread(() =>
                            {
                                string errorWebAppIssued = string.Format("Količina (" + qty.ToString(CommonData.GetQtyPicture()) + ") ne sme presegati max. količine (" + max.ToString(CommonData.GetQtyPicture()) + ")!");
                                Toast.MakeText(this, errorWebAppIssued, ToastLength.Long).Show();

                                tbPacking.RequestFocus();
                            });

                            return false;
                        }
                    }
                }
                catch (Exception e)
                {
                    RunOnUiThread(() =>
                    {
                        string errorWebAppIssued = string.Format("Količina mora biti število (" + e.Message + ")!");
                        Toast.MakeText(this, errorWebAppIssued, ToastLength.Long).Show();

                        tbPacking.RequestFocus();
                    });

                    return false;
                }
            }

            if (string.IsNullOrEmpty(tbUnits.Text.Trim()))
            {
                RunOnUiThread(() =>
                {
                    string errorWebAppIssued = string.Format(lbUnits.Text + " je obvezen podatek!");
                    Toast.MakeText(this, errorWebAppIssued, ToastLength.Long).Show();
                    tbUnits.RequestFocus();
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
                            string errorWebAppIssued = string.Format(lbUnits.Text + " je obvezen podatek in mora biti različna od nič!");
                            Toast.MakeText(this, errorWebAppIssued, ToastLength.Long).Show();

                            tbUnits.RequestFocus();
                        });

                        return false;
                    }
                }
                catch (Exception e)
                {
                    RunOnUiThread(() =>
                    {
                        string errorWebAppIssued = string.Format(lbUnits.Text + " mora biti število (" + e.Message + ")!");
                        Toast.MakeText(this, errorWebAppIssued, ToastLength.Long).Show();
                        tbUnits.RequestFocus();
                    });


                    return false;
                }
            }

            if (!CommonData.IsValidLocation(moveHead.GetString("Wharehouse"), tbLocation.Text.Trim()))
            {
                RunOnUiThread(() =>
                {
                    string errorWebAppIssued = string.Format("Lokacija '" + tbLocation.Text.Trim() + "' ni veljavna za skladišče '" + moveHead.GetString("Wharehouse") + "'!");
                    Toast.MakeText(this, errorWebAppIssued, ToastLength.Long).Show();

                    tbLocation.RequestFocus();
                });

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
                    RunOnUiThread(() =>
                    {
                        string errorWebAppIssued = string.Format("Napaka pri dostopu do web aplikacije: " + error);
                        Toast.MakeText(this, errorWebAppIssued, ToastLength.Long).Show();

                        tbLocation.RequestFocus();
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
                    if (button4.Enabled == true)
                    {
                        Button4_Click(this, null);
                    }
                    break;

                case Keycode.F4:
                    if (button6.Enabled == true)
                    {
                        Button6_Click(this, null);
                    }
                    break;

                case Keycode.F5:
                    if (button5.Enabled == true)
                    {
                        Button5_Click(this, null);
                    }
                    break;

                case Keycode.F9:
                    if (button7.Enabled == true)
                    {
                        Button7_Click(this, null);
                    }
                    break;

            }
            return base.OnKeyDown(keyCode, e);
        }

        public void GetBarcode(string barcode)
        {
            if (tbSSCC.HasFocus)
            {
                Sound();
                tbSSCC.Text = barcode;
                tbSerialNum.RequestFocus();


            }
            else if (tbSerialNum.HasFocus)
            {
                Sound();
                tbSerialNum.Text = barcode;
                tbLocation.RequestFocus();

            }
            else if (tbLocation.HasFocus)
            {

                Sound();
                tbSerialNum.Text = barcode;
                tbPacking.RequestFocus();
            }
        }
    }


}

