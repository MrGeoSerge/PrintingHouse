using PrintingHouse.XamarinForms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrintingHouse.XamarinForms.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyConspectusPolyCalc : ContentPage
	{
		public MyConspectusPolyCalc ()
		{
			InitializeComponent ();
		}

        private void calculateButton_Clicked(object sender, EventArgs e)
        {
            int pagesQnt = Int32.Parse(pagesQntEntry.Text);
            int printRun = Int32.Parse(printRunEntry.Text);

            //resultsLabel.Text = (pagesQnt * printRun).ToString();
            CalculationsManager calculationsManager = new CalculationsManager();
            resultsLabel.Text = calculationsManager.CalculateMyConspectusPrintingCost(pagesQnt, printRun);

        }
    }
}