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
    public static class ManagerList
    {
        public static List<Manager> Managers { get; set; }

        static ManagerList()
        {
            List<Manager> temp = new List<Manager>();

            AddManagers(temp);
            AddManagers(temp);
            AddManagers(temp);
            AddManagers(temp);
            AddManagers(temp);
            AddManagers(temp);
            AddManagers(temp);
            AddManagers(temp);

            Managers = temp.OrderBy(t => t.LastName).ToList();
        }


        static void AddManagers(List<Manager> managers)
        {
            managers.Add(
                new Manager()
                {
                    FirstName = "Sergiy",
                    LastName = "Velychko",
                    ImageUrl = "images/adrian-stevens.jpg"
                });

            managers.Add(
                new Manager()
                {
                    FirstName = "Yuriy",
                    LastName = "Afanasenko",
                    ImageUrl = "images/chris-van-wyk.jpg"
                });

            managers.Add(
                new Manager()
                {
                    FirstName = "Natalia",
                    LastName = "Yarmak",
                    ImageUrl = "images/glenn-stephens.jpg"
                });
        }

    }
}