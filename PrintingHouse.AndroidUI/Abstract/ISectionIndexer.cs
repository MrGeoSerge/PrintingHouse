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

namespace PrintingHouse.AndroidUI.Abstract
{
    public interface ISectionIndexer
    {
        Java.Lang.Object[] GetSections();

        int GetPositionForSection(int section);
        int GetSectionForPosition(int position);
    }
}