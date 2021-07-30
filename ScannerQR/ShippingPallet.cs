using Android.App;
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
    [Activity(Label = "ShippingPallet", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ShippingPallet : Activity, IBarcodeResult
    {
        private EditText pallet;
        private EditText machine;
        private Button btConfirm;
        SoundPool soundPool;
        int soundPoolId;

        public string ETpallet { get; private set; }
        public string ETmachine { get; private set; }

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

            } else if (machine.HasFocus)
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
            SetContentView(Resource.Layout.ShippingPallet);

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


        private async Task FinishMethod()
        {
            await Task.Run(() =>
            {



                try
                {


                    RunOnUiThread(() =>
                    {
                        ETpallet = pallet.Text;

                        ETmachine = machine.Text;

                        progress = new ProgressDialogClass();

                        progress.ShowDialogSync(this, "Pošiljam podatke, prosim počakajte.");
                    });

                    string result;
                    if (WebApp.Get("mode=palMac&pal=" + ETpallet + "&mac=" + ETmachine, out result))
                    {
                        if (result == "OK")
                        {
                            RunOnUiThread(() =>
                            {


                                progress.StopDialogSync();
                                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                                alert.SetTitle("Uspešno obdelano.");
                                alert.SetMessage("Paleta uspešno dostavljena");

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
                                alert.SetMessage($"Napaka pri dostavi palete: {result}");

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
                            alert.SetMessage("Napaka pri dostopu do web aplikacije");

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
                catch (Exception ex)
                {


                    RunOnUiThread(() =>
                    {


                        progress.StopDialogSync();
                        AlertDialog.Builder alert = new AlertDialog.Builder(this);
                        alert.SetTitle("Napaka");
                        alert.SetMessage($"Prišlo je do napake. {ex.Message}");

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
                finally
                {
                    progress.StopDialogSync();
                }


            });
        }


        private async void BtConfirm_Click(object sender, EventArgs e)
        {
            await FinishMethod();
            //    // Method scope
            //    string ETpallet = pallet.Text;
            //    string ETmachine = machine.Text;
            //    var progress = new ProgressDialogClass();

            //    progress.ShowDialogSync(this, "Zaključujem");

            //    try
            //    {
            //        string result;
            //        if (WebApp.Get("mode=palMac&pal=" + ETpallet + "&mac=" + ETmachine, out result))
            //        {
            //            if (result == "OK")
            //            {
            //                Toast.MakeText(this, "Paleta uspešno dostavljena", ToastLength.Long).Show();

            //            }
            //            else
            //            {
            //                Toast.MakeText(this, $"Napaka pri dostavi palete: {result}", ToastLength.Long).Show();
            //            }
            //        }
            //        else
            //        {
            //            Toast.MakeText(this, "Napaka pri dostopu do web aplikacije", ToastLength.Long).Show();
            //        }
            //    }
            //    catch(Exception ex)
            //    {
            //        Toast.MakeText(this, $"Prišlo je do napake. {ex.Message}", ToastLength.Long).Show();
            //    }
            //    finally
            //    {
            //        progress.StopDialogSync();
            //    }

            //}

        }
    }
}
    