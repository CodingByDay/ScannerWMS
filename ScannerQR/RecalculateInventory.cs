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
    [Activity(Label = "RecalculateInventory")]
    public class RecalculateInventory : Activity, IBarcodeResult
    {

        private EditText ident;
        private Button btCalculate;
        SoundPool soundPool;
        int soundPoolId;
        private ProgressDialogClass progress;

        public void GetBarcode(string barcode)
        {
            if (ident.HasFocus)
            {
                Sound();
                ident.Text = barcode;
              
            }
        }
        public override void OnBackPressed()
        {

            HelpfulMethods.releaseLock();

            base.OnBackPressed();
        }
        private void Sound()
        {
            soundPool.Play(soundPoolId, 1, 1, 0, 0, 1);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.RecalculateInventory);

            ident = FindViewById<EditText>(Resource.Id.ident);

            btCalculate = FindViewById<Button>(Resource.Id.btCalculate);

            soundPool = new SoundPool(10, Stream.Music, 0);

            soundPoolId = soundPool.Load(this, Resource.Drawable.beep, 1);

            Barcode2D barcode2D = new Barcode2D();

            barcode2D.open(this, this);

            color();

            btCalculate.Click += BtCalculate_Click;
        }

        private async void BtCalculate_Click(object sender, EventArgs e)
        {
            var value = ident.Text;
            await FinishMethod(value);
        }

        private void color()
        {
            ident.SetBackgroundColor(Android.Graphics.Color.Aqua);
        }


        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            switch (keyCode)
            {
                // In smartphone.  
                case Keycode.F2:
                    if (btCalculate.Enabled == true)
                    {
                        BtCalculate_Click(this, null);
                    }
                    break;
             


            }
            return base.OnKeyDown(keyCode, e);
        }



        private async Task FinishMethod(string ident)
        {

    

            await Task.Run(() =>
            {


                try
                {


                    RunOnUiThread(() =>
                    {
                        progress = new ProgressDialogClass();

                        progress.ShowDialogSync(this, "Izvaja se preračun zalog, prosimo počakajte trenutek.");
                    });

                    string result;
                    if (WebApp.Get("mode=recalc&id=" + ident, out result))
                    {


                        if (result == "OK")
                        {
                            RunOnUiThread(() =>
                            {


                                progress.StopDialogSync();

                                AlertDialog.Builder alert = new AlertDialog.Builder(this);

                                alert.SetTitle("Preračun uspešen.");


                                alert.SetMessage("Rekalkulacija je izdelana.");

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
                                alert.SetMessage($"Napaka: {result}");

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


                            progress.StopDialogSync();
                            AlertDialog.Builder alert = new AlertDialog.Builder(this);
                            alert.SetTitle("Napaka");
                            alert.SetMessage("Napaka pri dostopu do web aplikacije");

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
                            HelpfulMethods.clearTheStack(this);

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
    }
}