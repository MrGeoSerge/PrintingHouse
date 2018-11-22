using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Specifications;

namespace PrintingHouse.Domain.Entities.Tasks
{
	public class TaskToPrint
    {
        public string Name { get; set; }
        public IssueFormat Format { get; set; }
        public AbstractPaper Paper { get; set; }
        public IssueColors Colors { get; set; }
        public PrintingPressType PrintingPressType { get; set; }
        public int PagesNumber { get; set; }
        public int PrintRun { get; set; }
        public bool VarnishingOrdered { get; set; }

        public TaskToPrint(string name, IssueFormat format, AbstractPaper paper, IssueColors colors, 
            PrintingPressType printingPressType, int pagesNumber, int printRun, bool varnishingOrdered = false)
        {
            Name = name;
            Format = format;
            Paper = paper;
            Colors = colors;
            PrintingPressType = printingPressType;
            PagesNumber = pagesNumber;
            PrintRun = printRun;
            VarnishingOrdered = varnishingOrdered;
        }


        public TaskToPrint(BookPart _bookPart, int _printRun)
        {
            Name = _bookPart.Name;
            Format = _bookPart.Format;
            Paper = _bookPart.Paper;
            Colors = _bookPart.Colors;
            PagesNumber = _bookPart.PagesNumber;
            PrintRun = _printRun;
            VarnishingOrdered = _bookPart.VarnishingOrdered;
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
