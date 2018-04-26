
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
    public class TaskToPrint
    {
        public string Name { set; get; }
        public IssueFormat Format { set; get; }
        public AbstractPaper Paper { set; get; }
        public IssueColors Colors { set; get; }
        public int PagesNumber { set; get; }
        public int PrintRun { set; get; }

        public TaskToPrint(string name, IssueFormat format, AbstractPaper paper, IssueColors colors, int pagesNumber, int printRun)
        {
            Name = name;
            Format = format;
            Paper = paper;
            Colors = colors;
            PagesNumber = pagesNumber;
            PrintRun = printRun;
        }


        public TaskToPrint(BookPart _bookPart, int _printRun)
        {
            Name = _bookPart.Name;
            Format = _bookPart.Format;
            Paper = _bookPart.Paper;
            Colors = _bookPart.Colors;
            PagesNumber = _bookPart.PagesNumber;
            PrintRun = _printRun;
        }


        public override string ToString()
        {
            string taskInString = Name + ": ";
            taskInString += Format + "; ";
            taskInString += Paper + "; ";
            taskInString += "Цветность: " + Colors + "; ";
            taskInString += PagesNumber + "стр.; ";
            taskInString += "Тираж: " + PrintRun;

            return taskInString;
        }

    }
}
