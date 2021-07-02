using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BarCode2D_Receiver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrendNET.WMS.Device.Services;

namespace Scanner
{
    [Activity(Label = "ShippingPalletTablet")]
    public class ShippingPalletTablet : Activity, IBarcodeResult
    {
        private EditText pallet;
        private EditText machine;
        private Button btConfirm;
        SoundPool soundPool;
        int soundPoolId;
        public void GetBarcode(string barcode)
        {
            if (pallet.HasFocus)
            {
                if (barcode != "Scan fail")
                {
                    Sound();
                    pallet.Text = barcode;
                }
                else
                {
                    pallet.Text = "";
                }

            }
            else if (machine.HasFocus)
            {
                if (barcode != "Scan fail")
                {
                    Sound();
                    machine.Text = barcode;
                }
                else
                {
                    machine.Text = "";
                }
            }

        }
        private void Sound()
        {

            soundPool.Play(soundPoolId, 1, 1, 0, 0, 1);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ShippingPalletTablet);

            // Create your application here
            pallet = FindViewById<EditText>(Resource.Id.pallet);
            machine = FindViewById<EditText>(Resource.Id.machine);
            btConfirm = FindViewById<Button>(Resource.Id.btConfirm);

            btConfirm.Click += BtConfirm_Click;

            color();

            soundPool = new SoundPool(10, Stream.Music, 0);
            soundPoolId = soundPool.Load(this, Resource.Drawable.beep, 1);
            Barcode2D barcode2D = new Barcode2D();
            barcode2D.open(this, this);

            pallet.RequestFocus();

        }

        private void color()
        {
            pallet.SetBackgroundColor(Android.Graphics.Color.Aqua);
            machine.SetBackgroundColor(Android.Graphics.Color.Aqua);
        }

        private void BtConfirm_Click(object sender, EventArgs e)
        {

            // Method scope
            string ETpallet = pallet.Text;
            string ETmachine = machine.Text;


            try
            {
                string result;
                if (WebApp.Get("mode=palMac&pal=" + ETpallet + "&mac=" + ETmachine, out result))
                {
                    if (result == "OK")
                    {
                        Toast.MakeText(this, "Paleta uspešno dostavljena", ToastLength.Long).Show();

                    }
                    else
                    {
                        Toast.MakeText(this, $"Napaka pri dostavi palete: {result}", ToastLength.Long).Show();
                    }
                }
                else
                {
                    Toast.MakeText(this, "Napaka pri dostopu do web aplikacije", ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, $"Prišlo je do napake. {ex.Message}", ToastLength.Long).Show();
            }


        }
    }
}