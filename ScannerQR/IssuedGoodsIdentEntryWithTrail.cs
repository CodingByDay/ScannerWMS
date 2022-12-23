using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BarCode2D_Receiver;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Scanner.App;
using TrendNET.WMS.Core.Data;
using TrendNET.WMS.Device.App;
using TrendNET.WMS.Device.Services;

namespace Scanner
{


    [Activity(Label = "IssuedGoodsIdentEntryWithTrail")]
    public class IssuedGoodsIdentEntryWithTrail : Activity, IBarcodeResult 
    {

        private NameValueObject moveHead = (NameValueObject)InUseObjects.Get("MoveHead");
        private NameValueObject openOrder = (NameValueObject)InUseObjects.Get("OpenOrder");
        private NameValueObject trailFilters = (NameValueObject)InUseObjects.Get("TrailFilters");
        private EditText tbOrder;
        private EditText tbReceiver;
        private EditText tbIdentFilter;
        private EditText tbLocationFilter;
        private ListView ivTrail;
        private List<Trail> ChosenOnes = new List<Trail>();
        private Button btConfirm;

        private Button btDisplayPositions;
        private Button btLogout;
        SoundPool soundPool;
        int soundPoolId;
        private List <Trail> trails;
        private adapter adapterObj;
        public int selected;
        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // in smartphone
                case Keycode.F3:
                    if (btConfirm.Enabled == true)
                    {
                        BtConfirm_Click(this, null);
                    }
                    break;
                // return true;
                case Keycode.F4:
                    if (btDisplayPositions.Enabled == true)
                    {
                        BtDisplayPositions_Click(this, null);
                    }
                    break;
                case Keycode.F9:
                    if (btLogout.Enabled == true)
                    {
                        BtLogout_Click(this, null);
                    }
                    break;

            }
            return base.OnKeyDown(keyCode, e);
        }

        public void GetBarcode(string barcode)
        {
            // 
            if(tbIdentFilter.HasFocus)
            {
                Sound();
                tbIdentFilter.Text = barcode;
                ProcessIdent();
            } else if (tbLocationFilter.HasFocus)
            {
                Sound();
                tbLocationFilter.Text = barcode;
                ProcessIdent();
            }
        }



        /// <summary>
        ///  Process ident method.
        /// </summary>

        private void ProcessIdent()
        {
            FillDisplayedOrderInfo();
        }

        private List<CheckStockAddonList> GetLocationsStock(string wh, string ident)
        {
            List<CheckStockAddonList> data = new List<CheckStockAddonList>();
            string error;
            var stock = Services.GetObjectList("str", out error, wh + "||" + ident);
            //return string.Join("\r\n", stock.Items.Select(x => "L:" + x.GetString("Location") + " = " + x.GetDouble("RealStock").ToString(CommonData.GetQtyPicture())).ToArray());
            stock.Items.ForEach(x =>
            {
                data.Add(new CheckStockAddonList
                {
                    Ident = x.GetString("Ident"),
                    Location = x.GetString("Location"),
                    Quantity = x.GetDouble("RealStock").ToString(CommonData.GetQtyPicture())
                });
            });
            return data;
        }
        private void FillDisplayedOrderInfo()
        {
            try
            {
                List<Trail> unfiltered = new List<Trail>();
                var filterLoc = tbLocationFilter.Text;
                var filterIdent = tbIdentFilter.Text;



                try
                {
                    tbOrder.Text = openOrder.GetString("Key");
                    tbReceiver.Text = openOrder.GetString("Receiver");

                    var warehouse = moveHead.GetString("Wharehouse");

                    string error;
                    string password = openOrder.GetString("Key");


                    // var qtyByLoc = Services.GetObjectList("stoo", out error, warehouse + "|" + openOrder.GetString("Key") + "|" + moveHead.GetInt("HeadID"));
                    var qtyByLoc = Services.GetObjectList("ook", out error, password);

                    if (qtyByLoc == null)
                    {
                        throw new ApplicationException("Napaka pri pridobivanju podatkov za vodenje po skladišču: " + error);
                    }

                    trails.Clear();

                    qtyByLoc.Items.ForEach(i =>
                    {
                        var ident = i.GetString("Ident");
                        var location = i.GetString("Location");
                        var name = i.GetString("Name");
                        if ((string.IsNullOrEmpty(filterLoc) || (location == filterLoc)) &&
                            (string.IsNullOrEmpty(filterIdent) || (ident == filterIdent)))
                        {
                            var lvi = new Trail();
                            lvi.Ident = ident;
                            lvi.Location = location;
                            lvi.Qty = i.GetDouble("OpenQty").ToString("###,##0.00");
                            lvi.Name = name;
                            unfiltered.Add(lvi);
                           // trails.Add(lvi);
                        }
                    });
                    var old = unfiltered;
                    var unique = unfiltered.Select(o => o.Ident).Distinct();
                    unique.ToList().ForEach(x =>
                    {
                        unfiltered = old;
                        var ItemsCaughtInNet = unfiltered.Where(y => y.Ident == x);
                        var identCaught = ItemsCaughtInNet.First().Ident;
                        var locations = GetLocationsStock(warehouse, identCaught);
                        if (ItemsCaughtInNet.Count() > 1 && locations.Count > 0)
                        {
                            if (locations.Count >= ItemsCaughtInNet.Count())
                            {

                                for (int i = 0; i < locations.Count; i++)
                                {
                                    ItemsCaughtInNet.ElementAt(i).Location = locations.ElementAt(i).Location;
                                }
                                int counter = -1;
                                // Replace
                                for (int i = 0; i < unfiltered.Count; i++)
                                {
                                    if (unfiltered[i].Ident == identCaught)
                                    {
                                        counter += 1;
                                        unfiltered.ElementAt(i).Location = ItemsCaughtInNet.ElementAt(i).Location;
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 0; i < unfiltered.Count; i++)
                                {
                                    if (unfiltered[i].Ident == identCaught)
                                    {

                                        unfiltered.ElementAt(i).Location = locations.ElementAt(0).Location;
                                    }
                                }
                            }

                        }
                        else if (ItemsCaughtInNet.Count() == 1 && locations.Count > 0)
                        {
                            int counter = -1;
                            // Replace
                            for (int i = 0; i < unfiltered.Count; i++)
                            {
                                if (unfiltered[i].Ident == identCaught)
                                {
                                    counter += 1;
                                    unfiltered.ElementAt(i).Location = locations.ElementAt(0).Location;
                                }
                            }
                        }
                        else if (locations.Count < ItemsCaughtInNet.Count())
                        {
                            if (locations.Count > 0)
                            {
                                int counter = -1;
                                for (int i = 0; i < unfiltered.Count; i++)
                                {
                                    if (unfiltered[i].Ident == identCaught)
                                    {
                                        counter += 1;
                                        unfiltered.ElementAt(i).Location = locations.ElementAt(0).Location;
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 0; i < unfiltered.Count; i++)
                                {
                                    if (unfiltered[i].Ident == identCaught)
                                    {
                                        unfiltered.ElementAt(i).Location = "";
                                    }
                                }
                            }

                        } else
                        {
                            if (locations.Count > 0)
                            {
                                int counter = -1;
                                for (int i = 0; i < unfiltered.Count; i++)
                                {
                                    if (unfiltered[i].Ident == identCaught)
                                    {
                                        counter += 1;
                                        unfiltered.ElementAt(i).Location = locations.ElementAt(0).Location;
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 0; i < unfiltered.Count; i++)
                                {
                                    if (unfiltered[i].Ident == identCaught)
                                    {
                                        unfiltered.ElementAt(i).Location = "";
                                    }
                                }
                            }                            
                        }                                        
                    });
                    foreach (var un in unfiltered)
                    {
                        trails.Add(un);
                    }
                }
                catch { }
                finally
                {
                    adapterObj.NotifyDataSetChanged();
                }

                if ((!string.IsNullOrEmpty(filterLoc) || !string.IsNullOrEmpty(filterIdent)) && (trails.Count == 0))
                {
                    tbLocationFilter.Text = "";
                    tbIdentFilter.Text = "";
                    FillDisplayedOrderInfo();
                    return;
                }

                trailFilters = new NameValueObject("TrailFilters");
                trailFilters.SetString("Ident", filterIdent);
                trailFilters.SetString("Location", filterLoc);
                InUseObjects.Set("TrailFilters", trailFilters);
                btConfirm.Enabled = true;

            } catch(Exception error) {
                
                
                    Crashes.TrackError(error);
                    
                    
             }
            
        }





        private void FillDisplayedOrderInfoFix()
        {
            var filterLoc = string.Empty;
            var filterIdent = string.Empty;



            try
            {
                tbOrder.Text = openOrder.GetString("Key");
                tbReceiver.Text = openOrder.GetString("Receiver");

                var warehouse = moveHead.GetString("Wharehouse");

                string error;
                var qtyByLoc = Services.GetObjectList("stoo", out error, warehouse + "|" + openOrder.GetString("Key") + "|" + moveHead.GetInt("HeadID"));
                if (qtyByLoc == null)
                {
                    throw new ApplicationException("Napaka pri pridobivanju podatkov za vodenje po skladišču: " + error);
                }

                trails.Clear();
                qtyByLoc.Items.ForEach(i =>
                {
                    var ident = i.GetString("Ident");
                    var location = i.GetString("Location");
                    var name = i.GetString("Name");

                    if ((string.IsNullOrEmpty(filterLoc) || (location == filterLoc)) &&
                        (string.IsNullOrEmpty(filterIdent) || (ident == filterIdent)))
                    {
                        var lvi = new Trail();
                        lvi.Ident = ident;
                        lvi.Location = location;
                        lvi.Qty = i.GetDouble("Qty").ToString("###,##0.00");
                        lvi.Name = name;
                        trails.Add(lvi);
                    }
                });
            }
            finally
            {
                adapterObj.NotifyDataSetChanged();

            }

            if ((!string.IsNullOrEmpty(filterLoc) || !string.IsNullOrEmpty(filterIdent)) && (trails.Count == 0))
            {
                tbLocationFilter.Text = "";
                tbIdentFilter.Text = "";
                FillDisplayedOrderInfo();
                return;
            }

            trailFilters = new NameValueObject("TrailFilters");
            trailFilters.SetString("Ident", filterIdent);
            trailFilters.SetString("Location", filterLoc);
            InUseObjects.Set("TrailFilters", trailFilters);

            btConfirm.Enabled = true;
        }

        /// <summary>
        /// Entry  point for the application.
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.IssuedGoodsIdentEntryWithTrail);
            tbOrder = FindViewById<EditText>(Resource.Id.tbOrder);
            tbReceiver = FindViewById<EditText>(Resource.Id.tbReceiver);
            tbIdentFilter = FindViewById<EditText>(Resource.Id.tbIdentFilter);
            tbLocationFilter = FindViewById<EditText>(Resource.Id.tbLocationFilter);
            ivTrail = FindViewById<ListView>(Resource.Id.ivTrail);
            btConfirm = FindViewById<Button>(Resource.Id.btConfirm);
            btDisplayPositions = FindViewById<Button>(Resource.Id.btDisplayPositions);
            btLogout = FindViewById<Button>(Resource.Id.btLogout);
            soundPool = new SoundPool(10, Stream.Music, 0);
            soundPoolId = soundPool.Load(this, Resource.Drawable.beep, 1);
            Barcode2D barcode2D = new Barcode2D();
            barcode2D.open(this, this);
            color();
            tbLocationFilter.FocusChange += TbLocationFilter_FocusChange;
            trails = new List <Trail>();
            adapterObj = new adapter(this, trails);
          
            ivTrail.Adapter = adapterObj;

            ivTrail.ItemClick += IvTrail_ItemClick;
            btConfirm.Click += BtConfirm_Click;
            btDisplayPositions.Click += BtDisplayPositions_Click;
            btLogout.Click += BtLogout_Click;



            if (moveHead == null)
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Napaka");
                alert.SetMessage("Prišlo je do napake in aplikacija se bo zaprla");

                alert.SetPositiveButton("Ok", (senderAlert, args) =>
                {
                    alert.Dispose();
                    System.Threading.Thread.Sleep(500);
                    throw new ApplicationException("Error, moveHead");
                });



                Dialog dialog = alert.Create();
                dialog.Show();
            }
            if (openOrder == null)
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Napaka");
                alert.SetMessage("Prišlo je do napake in aplikacija se bo zaprla");

                alert.SetPositiveButton("Ok", (senderAlert, args) =>
                {
                    alert.Dispose();
                    System.Threading.Thread.Sleep(500);
                    throw new ApplicationException("Error, openIdent");
                });



                Dialog dialog = alert.Create();
                dialog.Show();
            }
            


            if (trailFilters != null)
            {
                tbIdentFilter.Text = trailFilters.GetString("Ident");
                tbLocationFilter.Text = trailFilters.GetString("Location");
            }

            FillDisplayedOrderInfo();


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

        private void TbLocationFilter_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            ProcessIdent();
        }

        private void color()
        {
            tbIdentFilter.SetBackgroundColor(Android.Graphics.Color.Aqua);
            tbLocationFilter.SetBackgroundColor(Android.Graphics.Color.Aqua);

        }
        private void BtLogout_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainMenu));

            HelpfulMethods.clearTheStack(this);
        }

        private void BtDisplayPositions_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(IssuedGoodsEnteredPositionsView));
            HelpfulMethods.clearTheStack(this);
        }

        private void BtConfirm_Click(object sender, EventArgs e)
        {

            FillDisplayedOrderInfo();


            if (SaveMoveHead())
            {
                if (trails.Count == 1)
                {
                    var lastItem = new NameValueObject("LastItem");
                    lastItem.SetBool("IsLastItem", true);
                    InUseObjects.Set("LastItem", lastItem);
                }

                StartActivity(typeof(IssuedGoodsSerialOrSSCCEntry));
                this.Finish();

            }
        }

        private void IvTrail_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
           

            selected = e.Position;
            if (trails.ElementAt(selected).Location == string.Empty)
            {
                btConfirm.Enabled = false;
            }
            else
            {
                btConfirm.Enabled = true;
            }
            string toast = string.Format("Izbrali ste: {0}", trails.ElementAt(selected).Name.ToString());
            Toast.MakeText(this, toast, ToastLength.Long).Show();
          


        }

        /* Save move head method. */
        private bool SaveMoveHead()
        {
            if (selected == -1)
            {
                string WebError = string.Format("Kritična napaka.");
                Toast.MakeText(this, WebError, ToastLength.Long).Show();
                return false;
            }

            var obj = trails.ElementAt(selected);
            var ident = obj.Ident;
            var location = obj.Location;
            var qty = Convert.ToDouble(obj.Qty);

            var extraData = new NameValueObject("ExtraData");
            extraData.SetString("Location", location);
            extraData.SetDouble("Qty", qty);
            InUseObjects.Set("ExtraData", extraData);

            string error;

           
            try
            {
             
                var openIdent = Services.GetObject("id", ident, out error);
                if (openIdent == null)
                {
                    string WebError = string.Format("Napaka pri preverjanju identa." + error);
                    Toast.MakeText(this, WebError, ToastLength.Long).Show();
                    return false;
                }
                InUseObjects.Set("OpenIdent", openIdent);
            }
            finally
            {

            }

            if (!moveHead.GetBool("Saved"))
            {
                
                try
                {
                   

                    moveHead.SetInt("Clerk", Services.UserID());
                    moveHead.SetString("Type", "P");
                    moveHead.SetString("LinkKey", openOrder.GetString("Key"));
                    moveHead.SetString("LinkNo", openOrder.GetString("No"));
                    moveHead.SetString("Document1", openOrder.GetString("Document1"));
                    moveHead.SetDateTime("Document1Date", openOrder.GetDateTime("Document1Date"));
                    moveHead.SetString("Note", openOrder.GetString("Note"));


                    string testDocument1 = openOrder.GetString("Document1");







                    if (moveHead.GetBool("ByOrder"))
                    {
                        moveHead.SetString("Receiver", openOrder.GetString("Receiver"));
                    }

                    var savedMoveHead = Services.SetObject("mh", moveHead, out error);
                    if (savedMoveHead == null)
                    {
                        string WebError = string.Format("Napaka pri dostopu do web aplikacije." + error);
                        Toast.MakeText(this, WebError, ToastLength.Long).Show();
                        return false;
                    }
                    else
                    {
                        moveHead.SetInt("HeadID", savedMoveHead.GetInt("HeadID"));
                        moveHead.SetBool("Saved", true);
                        return true;
                    }
                }
                finally
                {
                    
                }
            }
            else
            {
                return true;
            }
        }
    

        private void Sound()
        {
            soundPool.Play(soundPoolId, 1, 1, 0, 0, 1);
        }

      

    }
}