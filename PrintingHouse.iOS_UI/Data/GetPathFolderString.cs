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
            return NSBundle.MainBundle.BundlePath;
        }
    }
}