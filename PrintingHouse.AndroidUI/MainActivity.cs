using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;

namespace PrintingHouse.AndroidUI
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{
        EditText pagesQntEditText;
        EditText printRunEditText;
        TextView resultView;
        Button calculateButton;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.activity_main);

            pagesQntEditText = FindViewById<EditText>(Resource.Id.pagesEditText);

            printRunEditText = FindViewById<EditText>(Resource.Id.printrunEditText);
            resultView = FindViewById<TextView>(Resource.Id.resultTextView);
            calculateButton = FindViewById<Button>(Resource.Id.calculateButton);

            calculateButton.Click += OnClick;

        }

        private void OnClick(object sender, EventArgs e)
        {
            string pagesQntString = pagesQntEditText.Text;
            int pagesQuantity;
            Int32.TryParse(pagesQntString, out pagesQuantity);

            int printRun;
            Int32.TryParse(printRunEditText.Text, out printRun);

            resultView.Text = (pagesQuantity * printRun / 100).ToString();
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

