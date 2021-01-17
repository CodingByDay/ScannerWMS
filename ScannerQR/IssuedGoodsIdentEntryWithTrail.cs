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
        private Button button5;
        private Button logout;
        SoundPool soundPool;
        int soundPoolId;
        private List <Trail> trails;
        private int temporaryPositionSubject;

        public void GetBarcode(string barcode)
        {
            //implement the way to scan here
         

            if(tbIdentFilter.HasFocus)
            {
                Sound();
                tbIdentFilter.Text = barcode;
                ProcessIdent();
            } else if (tbLocationFilter.HasFocus)
            {
                Sound();
                tbLocationFilter.Text = barcode;
            }
        }

        private void ProcessIdent()
        {
            FillDisplayedOrderInfo();
        }

        private void FillDisplayedOrderInfo()
        {
            var filterLoc = tbLocationFilter.Text;
            var filterIdent = tbIdentFilter.Text;

  
           
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
             // pass
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
            button5 = FindViewById<Button>(Resource.Id.button5);
            logout = FindViewById<Button>(Resource.Id.logout);
            soundPool = new SoundPool(10, Stream.Music, 0);
            soundPoolId = soundPool.Load(this, Resource.Drawable.beep, 1);
            Barcode2D barcode2D = new Barcode2D();
            barcode2D.open(this, this);

            trails = new List <Trail>();
        
            trails.Add(new Trail { Ident = "1", Location = "Ve", Qty = "12", Name = "Ko" });
            trails.Add(new Trail { Ident = "1", Location = "Ve", Qty = "12", Name = "Ko" });
            trails.Add(new Trail { Ident = "1", Location = "Ve", Qty = "12", Name = "Ko" });
            trails.Add(new Trail { Ident = "11111111111111111", Location = "Veeeeeeeeeeeeeeeeeee", Qty = "122222222222222", Name = "Kooooooooooooooo" });
            trails.Add(new Trail { Ident = "11111111111111111", Location = "Veeeeeeeeeeeeeeeeeee", Qty = "122222222222222", Name = "Kooooooooooooooo" });

            adapter adapter = new adapter(this, trails);
            // that is solved ie the reading.
            ivTrail.Adapter = adapter;

            ivTrail.ItemClick += IvTrail_ItemClick;
            
            // if (moveHead == null) { throw new ApplicationException("moveHead not known at this point!?"); }
            //if (openOrder == null) { throw new ApplicationException("openOrder not known at this point!?"); }
            
            if (trailFilters != null)
            {
                tbIdentFilter.Text = trailFilters.GetString("Ident");
                tbLocationFilter.Text = trailFilters.GetString("Location");
            }

            

            //new Scanner(tbIdent);



            // trail controls

           
            // Starting point
        }

        private void IvTrail_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            

                var selected = e.Position;
            string toast = string.Format("Izbrali ste: {0}", trails.ElementAt(selected).Location.ToString());
            Toast.MakeText(this, toast, ToastLength.Long).Show();
            View view = ivTrail.GetChildAt(selected);
            view.SetBackgroundColor(Android.Graphics.Color.Aqua);


        }

        private bool SaveMoveHead()
        {
            if (ChosenOnes.Count != 1)
            {
                string WebError = string.Format("Izbran ni noben(ali več kot en) ident/lokacija!");
                Toast.MakeText(this, WebError, ToastLength.Long).Show();
                return false;
            }

            var obj = ChosenOnes.ElementAt(0);
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
              // pass
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

        // trail controls first name the things from the design.

    }
}