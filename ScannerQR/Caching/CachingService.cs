using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendNET.WMS.Device.Services;

namespace Scanner.Caching
{
    [Service(Exported = true)]
    public class CachingService: Service
    {

        private async Task<List<string>> MakeTheApiCallForTheIdentData()
        {
            try
            {
                var SavedList = new List<string>();
                await Task.Run(() =>
                {
                    // Call the API.
                    string error;
                    var idents = Services.GetObjectList("id", out error, "");
                    idents.Items.ForEach(x =>
                    {
                        SavedList.Add(x.GetString("Code"));
                    });
                });
                return SavedList;
            } catch
            {
                return new List<string>();
            }
        }



        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            SerializeListCallAPIPersist();

            return StartCommandResult.NotSticky;
        }
        /// <summary>
        /// Method to get the data and save it in cache.
        /// </summary>
        private async void SerializeListCallAPIPersist()
        {
            List<string> list = await MakeTheApiCallForTheIdentData();
            var json = Caching.SavedList = list;
   
        }
    }
}