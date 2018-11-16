using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Specifications;

namespace PrintingHouse.Domain.Entities.BookComponents
{
	//части книги: внутренние блоки, обложки, вставки
	public class BookPart
	{
		public string Name { set; get; }
		public IssueFormat Format { set; get; }
		public AbstractPaper Paper { set; get; }
		public IssueColors Colors { set; get; }
		public int PagesNumber { set; get; }
        public PrintingPressType PrintingPressType { set; get; }

		public BookPart(string _name, IssueFormat _format, AbstractPaper _paper, IssueColors _colors, int _pagesNumber)
		{
			Name = _name;
			Format = _format;
			Paper = _paper;
			Colors = _colors;
			PagesNumber = _pagesNumber;
		}

		public BookPart(string _name, IssueFormat _format, AbstractPaper _paper, IssueColors _colors, int _pagesNumber, PrintingPressType _printingPressType)
		{
			Name = _name;
			Format = _format;
			Paper = _paper;
			Colors = _colors;
			PagesNumber = _pagesNumber;
            PrintingPressType = _printingPressType;
		}

		public BookPart() { }
	}
}
