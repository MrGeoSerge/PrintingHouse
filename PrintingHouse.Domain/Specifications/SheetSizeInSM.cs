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

namespace PrintingHouse.Domain.Specifications
{
    public struct SheetSizeInSM
    {
        public int lengthInSM;
        public int widthInSM;

        public SheetSizeInSM(int _lengthInSM, int _widthInSM)
        {
            lengthInSM = _lengthInSM;
            widthInSM = _widthInSM;
        }
    }
}
