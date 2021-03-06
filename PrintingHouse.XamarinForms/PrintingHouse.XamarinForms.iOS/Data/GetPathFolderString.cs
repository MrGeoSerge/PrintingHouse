﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using PrintingHouse.Domain.Interfaces;
using UIKit;

namespace PrintingHouse.XamarinForms.iOS.Data
{
    public class GetPathFolderString : IGetPathFolder
    {
        string GetPathFolder()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "..", "Library");
        }

    }
}