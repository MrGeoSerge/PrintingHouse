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

namespace BookProduction.PrintingPresses
{
    public abstract class SheetPress: PrintingPress
    {
        public SheetPress(TaskToPrint taskToPrint) : 
            base(taskToPrint) { }

		public override int GetImpressions()
        {
            return GetPrintingSheetsPerPrintRun() * (TaskToPrint.Colors.Total());
        }

		public override int GetFittingOnPrintRun()
        {
            return (int)GetFittingPriceValue();
        }
    }
}
