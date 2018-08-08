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

namespace PrintingHouse.AndroidUI.Model
{
    public class Manager
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAdress { get; set; }
        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}