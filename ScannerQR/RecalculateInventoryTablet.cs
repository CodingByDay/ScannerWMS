using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BarCode2D_Receiver;
using Com.Toptoche.Searchablespinnerlibrary;
using Scanner.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendNET.WMS.Device.Services;

namespace Scanner
{
    [Activity(Label = "RecalculateInventoryTablet", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class RecalculateInventoryTablet : Activity, IBarcodeResult
    {

        private EditText ident;
        private Button btCalculate;
        SoundPool soundPool;
        int soundPoolId;
        private ProgressDialogClass progress;
        private SearchableSpinner spinnerIdent;
        private List<string> identData = new List<string>();
        private List<string> returnList;

        public void GetBarcode(string barcode)
        {
            if (ident.HasFocus)
            {
                Sound();
                ident.Text = barcode;

            }
        }

        private void Sound()
        {
            soundPool.Play(soundPoolId, 1, 1, 0, 0, 1);
        }

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.RecalculateInventoryTablet);

            ident = FindViewById<EditText>(Resource.Id.ident);

            btCalculate = FindViewById<Button>(Resource.Id.btCalculate);

            soundPool = new SoundPool(10, Stream.Music, 0);

            soundPoolId = soundPool.Load(this, Resource.Drawable.beep, 1);

            Barcode2D barcode2D = new Barcode2D();

            barcode2D.open(this, this);

            color();
            identData = await MakeTheApiCallForTheIdentData();

            btCalculate.Click += BtCalculate_Click;
            spinnerIdent = FindViewById<SearchableSpinner>(Resource.Id.spinnerIdent);

            spinnerIdent.Prompt = "Iskanje";
            spinnerIdent.SetTitle("Iskanje");
            spinnerIdent.SetPositiveButton("Zapri");
            var DataAdapter = new ArrayAdapter<string>(this,
            Android.Resource.Layout.SimpleSpinnerItem, identData);
            // Change the search title. HERE
            DataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerIdent.Adapter = DataAdapter;
            // The part for spinner selected index changed.
            spinnerIdent.ItemSelected += SpinnerIdent_ItemSelected;

            ident.LongClick += ClearTheFields;

        }




        private async Task<List<string>> MakeTheApiCallForTheIdentData()
        {
            await Task.Run(() =>
            {
                returnList = new List<string>();
                // Call the API.
                string error;
                var idents = Services.GetObjectList("id", out error, "");

                idents.Items.ForEach(x =>
                {
                    returnList.Add(x.GetString("Code"));
                });


            });
            return returnList;
        }
        private void SpinnerIdent_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var item = e.Position;
            var chosen = identData.ElementAt(item);
            ident.Text = chosen;
        }


        private void ClearTheFields(object sender, View.LongClickEventArgs e)
        {
           ident.Text = "";
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

                        progress.ShowDialogSync(this, "Preračun se dela, prosimo počakajte.");
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
                                alert.SetMessage($"Napaka: {result}");

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
                                StartActivity(typeof(MainMenuTablet));

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
                            StartActivity(typeof(MainMenuTablet));

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