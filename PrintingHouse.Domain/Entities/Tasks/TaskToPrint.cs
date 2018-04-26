﻿using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Specifications;

namespace PrintingHouse.Domain.Entities.Tasks
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
