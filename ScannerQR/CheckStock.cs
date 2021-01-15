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

namespace ScannerQR
{
    [Activity(Label = "CheckStock")]
    public class CheckStock : Activity, IBarcodeResult
    {
        private Spinner cbWarehouses;
        private EditText tbLocation;
        private EditText tbIdent;
        private Button btShowStock;
        private Button button1;
        SoundPool soundPool;
        int soundPoolId;

        public void GetBarcode(string barcode)
        {
            if (tbIdent.HasFocus)
            {
                Sound();
                tbIdent.Text = barcode;
            } else if (tbLocation.HasFocus)
            {
                tbLocation.Text = barcode;
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
            SetContentView(Resource.Layout.CheckStock);
            cbWarehouses = FindViewById<Spinner>(Resource.Id.cbWarehouses);
            tbLocation = FindViewById<EditText>(Resource.Id.tbLocation);
            tbIdent = FindViewById<EditText>(Resource.Id.tbIdent);
            btShowStock = FindViewById<Button>(Resource.Id.btShowStock);
            button1 = FindViewById<Button>(Resource.Id.button1);
            soundPool = new SoundPool(10, Stream.Music, 0);
            soundPoolId = soundPool.Load(this, Resource.Drawable.beep, 1);
            Barcode2D barcode2D = new Barcode2D();
            barcode2D.open(this, this);


        }
    }
}