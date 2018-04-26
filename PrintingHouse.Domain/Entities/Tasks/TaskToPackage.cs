using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookProduction;
using BookProduction.BookComponents;
using BookProduction.Assembly;
using BookProduction.IssueParams;
using BookProduction.Paper;
using BookProduction.PriceLists;
using BookProduction.PrintingPresses;
using BookProduction.Tasks;
using BookProduction.TypographyManagement;

namespace PrintingHouse.Domain.Entities.Tasks
{
    public class TaskToPackage
    {
        public BindingType BindingType{set; get;}
        public int PrintRun { set; get; }

        public TaskToPackage(BindingType _bindingType, int _printRun)
        {
            BindingType = _bindingType;
            PrintRun = _printRun;
        }
    }
}
