using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PrintingHouse.AndroidUI
{
    [Activity(Label = "BookSeriesActivity")]
    public class BookSeriesActivity : Activity
    {
        Button myConspectus;
        Button allLessons;

        int pagesQnt;
        int printRun;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.BookSeries);

            InstantiateControls();
        }

        private void InstantiateControls()
        {
            myConspectus = FindViewById<Button>(Resource.Id.myConspectusButton);
            myConspectus.Click += (s, e) => {
                var intent = new Intent(this, typeof(MyConspectusActivity));
                intent.PutExtra("PagesQuantity", pagesQnt);
                intent.PutExtra("PrintRun", printRun);

                base.StartActivityForResult(intent, 100);
            };
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if(requestCode == 100 && resultCode == Result.Ok)
            {
                pagesQnt = data.GetIntExtra("PagesQuantity", -1);
                printRun = data.GetIntExtra("PrintRun", -1);
            }
        }
    }
}