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
    [Activity(Label = "PolygraphyCalculatorActivity")]
    public class PolygraphyCalculatorActivity : Activity
    {
        EditText pagesQntEditText;
        EditText printRunEditText;
        TextView resultView;
        Button calculateButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.PolygraphyCalculator);
            InstantiateControls();

            RetrieveValues();


        }

        private void RetrieveValues()
        {
            pagesQntEditText.Text = Intent.GetIntExtra("PagesQuantity", 0).ToString();
            printRunEditText.Text = Intent.GetIntExtra("PrintRun", 0).ToString();
        }

        private void InstantiateControls()
        {
            pagesQntEditText = FindViewById<EditText>(Resource.Id.pagesPCEditText);

            printRunEditText = FindViewById<EditText>(Resource.Id.printrunPCEditText);
            resultView = FindViewById<TextView>(Resource.Id.resultPCTextView);
            calculateButton = FindViewById<Button>(Resource.Id.calculatePCButton);
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
    }
}