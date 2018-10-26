using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using PrintingHouse.Domain.Interfaces;

namespace PrintingHouse.iOS_UI.Data
{
    public class GetPathFolderString : IGetPathFolder
    {
        public string GetPathFolder()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "..", "Library");
            //return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        }
    }
}