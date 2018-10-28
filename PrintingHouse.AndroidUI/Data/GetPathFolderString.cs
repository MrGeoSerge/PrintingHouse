using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Android.App;
using PrintingHouse.Domain.Interfaces;

namespace PrintingHouse.AndroidUI.Data
{
    public class GetPathFolderString : IGetPathFolder
    {
        public string GetPathFolder()
        {
            //return Path.Combine(
            //    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            //    "..", "Library");
            //return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Application.Context.FilesDir.Path;
        }
    }
}