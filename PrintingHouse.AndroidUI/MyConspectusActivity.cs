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
    [Activity(Label = "MyConspectusActivity")]
    public class MyConspectusActivity : Activity
    {
        private EditText pagesQntEditText;
        private EditText printRunEditText;
        private TextView resultView;
        private Button calculateButton;
        private Button saveButton;
        private Button cancelButton;
        private Button openInPCButton;

        int pagesQnt;
        int printRun;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.MyConspectus);

            InstantiateControls();
            RetrieveData();
        }

        private void RetrieveData()
        {
            pagesQntEditText.Text = Intent.GetIntExtra("PagesQuantity", 0).ToString();
            printRunEditText.Text = Intent.GetIntExtra("PrintRun", 0).ToString();
        }

        private void InstantiateControls()
        {
            pagesQntEditText = FindViewById<EditText>(Resource.Id.pagesEditText);

            printRunEditText = FindViewById<EditText>(Resource.Id.printrunEditText);
            resultView = FindViewById<TextView>(Resource.Id.resultTextView);
            calculateButton = FindViewById<Button>(Resource.Id.calculateButton);
            calculateButton.Click += OnClick;

            saveButton = FindViewById<Button>(Resource.Id.saveMCButton);
            saveButton.Click += SaveButton_Click;

            cancelButton = FindViewById<Button>(Resource.Id.cancelMCButton);
            cancelButton.Click += (s, e) => { Finish(); };

            openInPCButton = FindViewById<Button>(Resource.Id.openInPCButton);
            openInPCButton.Click += OpenInPCButton_Click;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            GetData();
            var bundle = PutData();

            var intent = new Intent();
            intent.PutExtras(bundle);

            SetResult(Result.Ok, intent);
            Finish();
        }

        private void OpenInPCButton_Click(object sender, EventArgs e)
        {
            GetData();
           
            var bundle = PutData();

            var intent = new Intent(this, typeof(PolygraphyCalculatorActivity));
            intent.PutExtras(bundle);

            StartActivity(intent);
        }



        private void OnClick(object sender, EventArgs e)
        {
            GetData();
            resultView.Text = (pagesQnt * printRun / 100).ToString();
        }

        private void GetData()
        {
            Int32.TryParse(pagesQntEditText.Text, out pagesQnt);
            Int32.TryParse(printRunEditText.Text, out printRun);
        }

        private Bundle PutData()
        {
            var bundle = new Bundle();
            bundle.PutInt("PagesQuantity", pagesQnt);
            bundle.PutInt("PrintRun", printRun);

            return bundle;
        }
    }
}