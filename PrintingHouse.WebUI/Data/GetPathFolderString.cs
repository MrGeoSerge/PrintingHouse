﻿using PrintingHouse.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrintingHouse.WebUI.Data
{
    public class GetPathFolderString : IGetPathFolder
    {
        public string GetPathFolder()
        {
            
            return System.Web.HttpRuntime.BinDirectory + @"\Data";
        }
    }
}