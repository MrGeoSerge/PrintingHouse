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
using PrintingHouse.AndroidUI.Model;

namespace PrintingHouse.AndroidUI
{
    [Activity(Label = "ManagersListActivity")]
    public class ManagersListActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ManagersList);

            var managerList = FindViewById<ListView>(Resource.Id.managersListView);

            managerList.FastScrollEnabled = true;
            managerList.ItemClick += OnManagerList_ItemClick;

            var managerAdapter = new ManagerAdapter(ManagerList.Managers);

            managerList.Adapter = managerAdapter;
        }

        private void OnManagerList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var manager = ManagerList.Managers[e.Position];

            var dialog = new AlertDialog.Builder(this);
            dialog.SetMessage(manager.FirstName);
            dialog.SetNeutralButton("Ok", delegate { });
            dialog.Show();
        }
    }
}