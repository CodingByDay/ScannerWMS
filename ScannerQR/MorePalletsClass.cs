using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Scanner.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scanner
{
    [Activity(Label = "MorePallets")]
    public class MorePalletsClass : Activity
    {
        //lvCardMore
        //btConfirm
        //btLogin
        private ListView lvCardMore;
        private Button btConfirm;
        private Button btLogin;
        private List<MorePallets> data = new List<MorePallets>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

                // Create your application here
                SetContentView(Resource.Layout.MorePalletsClass);
                lvCardMore = FindViewById<ListView>(Resource.Id.lvCardMore);
                btConfirm = FindViewById<Button>(Resource.Id.btConfirm);
                btLogin = FindViewById<Button>(Resource.Id.btLogin);
                MorePalletsAdapter adapter = new MorePalletsAdapter(this, data);
                lvCardMore.Adapter = adapter;

        }
    }
}