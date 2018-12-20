using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PrintingHouse.XamarinForms.Pages;

namespace PrintingHouse.XamarinForms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void polyCalcWindow_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MyConspectusPolyCalc());
        }
    }
}
