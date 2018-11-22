using PrintingHouse.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace PrintingHouse.UnitTests.Data
{
    public class Get_Old_PathFolderString : IGetPathFolder
    {
        public string GetPathFolder()
        {
            return @"D:\MyApps\PrintingHouse\PrintingHouse.UnitTests\Data\";
            //return System.Reflection.Assembly.GetExecutingAssembly().Location + @"\Data";
                //Assembly.GetExecutingAssembly().GetDirectoryPath() + @"\Data";
        }
    }
}