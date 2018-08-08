using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using PrintingHouse.AndroidUI.Model;
using PrintingHouse.AndroidUI.Abstract;

namespace PrintingHouse.AndroidUI
{
    public class ManagerAdapter : BaseAdapter<Manager>, PrintingHouse.AndroidUI.Abstract.ISectionIndexer
    {
        List<Manager> managers;
        Java.Lang.Object[] sectionHeaders;
        Dictionary<int, int> positionForSection;
        Dictionary<int, int> sectionForPosition;


        //Activity context;

        public ManagerAdapter(List<Manager> managers)
        {
            this.managers = managers;
            sectionHeaders = SectionIndexerBuilder.BuildSectionHeaders(ManagerList.Managers);
            positionForSection = SectionIndexerBuilder.BuildPositionForSectionMap(ManagerList.Managers);
            sectionForPosition = SectionIndexerBuilder.BuildSectionForPositionMap(ManagerList.Managers);
        }

        public int GetPositionForSection(int sectionIndex)
        {
            return positionForSection[sectionIndex];
        }

        public int GetSectionForPosition(int position)
        {
            return sectionForPosition[position];
        }

        public Java.Lang.Object[] GetSections()
        {
            return sectionHeaders;
        }
        int count = 0;
        
        
        
        #region Implemented abstract members


        public override Manager this[int position] => managers[position];

        public override int Count => managers.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if(view == null){
                count++;
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ManagerRow, parent, false);

                var photo = view.FindViewById<ImageView>(Resource.Id.photoImageView);
                var firstName = view.FindViewById<TextView>(Resource.Id.firstNameTextView);
                var lastName = view.FindViewById<TextView>(Resource.Id.lastNameTextView);


                view.Tag = new ViewHolder() { Photo = photo, FirstName = firstName, SecondName = lastName };

            };

            var holder = (ViewHolder)view.Tag;

            holder.Photo.SetImageDrawable(ImageAssetManager.Get(parent.Context, managers[position].ImageUrl));

            holder.FirstName.Text = managers[position].FirstName;
            holder.SecondName.Text = managers[position].LastName;

            return view;
        }

        #endregion
    }

}