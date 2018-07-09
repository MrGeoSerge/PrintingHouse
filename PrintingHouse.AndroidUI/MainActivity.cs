using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Content;

namespace PrintingHouse.AndroidUI
{
	[Activity(Label = "Publishing house", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{
        Button bookSeriesButton;
        Button addSeriesButton;
        Button polygraphyCalculatorButton;
        Button aboutButton;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Main);

            InstantiateControls();


            #region Old Project
            //pagesQntEditText = FindViewById<EditText>(Resource.Id.pagesEditText);

            //printRunEditText = FindViewById<EditText>(Resource.Id.printrunEditText);
            //resultView = FindViewById<TextView>(Resource.Id.resultTextView);
            //calculateButton = FindViewById<Button>(Resource.Id.calculateButton);

            //calculateButton.Click += OnClick;
            #endregion

        }


        private void InstantiateControls()
        {
            bookSeriesButton = FindViewById<Button>(Resource.Id.seriesButton);
            addSeriesButton = FindViewById<Button>(Resource.Id.addSeriesButton);
            polygraphyCalculatorButton = FindViewById<Button>(Resource.Id.polygraphyButton);
            aboutButton = FindViewById<Button>(Resource.Id.aboutButton);

            //subscribe on events
            bookSeriesButton.Click += (s,e) => { StartActivity(typeof(BookSeriesActivity)); };
            addSeriesButton.Click += (s,e) => { base.StartActivity(new Intent(this, typeof(AddSeriesActivity)));};
            polygraphyCalculatorButton.Click += (s,e) => { base.StartActivity(new Intent(this, typeof(PolygraphyCalculatorActivity)));};
            aboutButton.Click += AboutButton_Click;
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(Intent.ActionView);
            intent.SetData(Android.Net.Uri.Parse("http://osnova.com.ua/"));
            StartActivity(intent);
        }


        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
	}
}

