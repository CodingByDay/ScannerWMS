﻿using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BarCode2D_Receiver;
using Scanner.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendNET.WMS.Device.Services;

namespace Scanner
{
    [Activity(Label = "WrappingPallet")]
    public class WrappingPallet : Activity, IBarcodeResult
    {
        private EditText pallet;
        private Button btConfirm;
        SoundPool soundPool;
        int soundPoolId;
        private ProgressDialogClass progress;

        public void GetBarcode(string barcode)
        {
            if (pallet.HasFocus)
            {
                if (barcode != "Scan fail")
                {
                    Sound();
                    pallet.Text = barcode;
                } else
                {
                    pallet.Text = "";
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
            SetContentView(Resource.Layout.WrappingPallet);
            // Create your application here
            pallet = FindViewById<EditText>(Resource.Id.pallet);
            btConfirm = FindViewById<Button>(Resource.Id.btConfirm);

            btConfirm.Click += BtConfirm_Click;
            color();

            soundPool = new SoundPool(10, Stream.Music, 0);
            soundPoolId = soundPool.Load(this, Resource.Drawable.beep, 1);
            Barcode2D barcode2D = new Barcode2D();
            barcode2D.open(this, this);
        }

        private void color()
        {
            pallet.SetBackgroundColor(Android.Graphics.Color.Aqua);
        }



        private async Task FinishMethod()
        {
            await Task.Run(() =>
            {
                RunOnUiThread(() =>
                {
                    progress = new ProgressDialogClass();

                    progress.ShowDialogSync(this, "Pošiljam podatke, prosim počakajte.");
                });
                string TextPallet = pallet.Text;
                string result;
                if (WebApp.Get("mode=palPck&pal=" + TextPallet, out result))
                {
                    if (result == "OK")
                    {
                        RunOnUiThread(() =>
                        {


                            progress.StopDialogSync();
                            AlertDialog.Builder alert = new AlertDialog.Builder(this);
                            alert.SetTitle("Uspešno obdelano.");
                            alert.SetMessage("Paleta uspešno zavita!");

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
                            alert.SetMessage($"Napaka pri zavijanju palete. {result}");

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


                        progress.StopDialogSync();
                        AlertDialog.Builder alert = new AlertDialog.Builder(this);
                        alert.SetTitle("Napaka");
                        alert.SetMessage($"Napaka pri dostopu do web aplikacije. {result}");

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
            });
        }
        private async void BtConfirm_Click(object sender, EventArgs e)
        {
            await FinishMethod();
            //string TextPallet = pallet.Text;
            //string result;
            //if (WebApp.Get("mode=palPck&pal=" + TextPallet, out result))
            //{
            //    if (result == "OK")
            //    {
            //        Toast.MakeText(this, "Paleta uspešno zavita!", ToastLength.Long).Show();
            //    } else
            //    {
            //        Toast.MakeText(this, $"Napaka pri zavijanju palete. {result}", ToastLength.Long).Show();
            //    }
            //} else
            //{
            //    Toast.MakeText(this, $"Napaka pri dostopu do web aplikacije. {result}", ToastLength.Long).Show();
            //}

        }
    }
}