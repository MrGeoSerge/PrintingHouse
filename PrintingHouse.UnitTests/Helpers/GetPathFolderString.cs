using PrintingHouse.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace PrintingHouse.UnitTests.Data
{
    public class GetPathFolderString : IGetPathFolder
    {
        public string GetPathFolder()
        {
            
            return System.Reflection.Assembly.GetExecutingAssembly().Location + @"\Data";
                //Assembly.GetExecutingAssembly().GetDirectoryPath() + @"\Data";
        }
    }
}