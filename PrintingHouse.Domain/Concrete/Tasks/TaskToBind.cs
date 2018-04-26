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

namespace BookProduction.Tasks
{
    public class TaskToBind
    {
        
        public IssueFormat Format { set; get; }
        public int PagesNumber { set; get; }
        public int PrintRun { set; get; }

        public TaskToBind(IssueFormat _issueFormat, int _pagesNumber, int _printRun)
        {
            Format = _issueFormat;
            PagesNumber = _pagesNumber;
            PrintRun = _printRun;
        }
    }
}
