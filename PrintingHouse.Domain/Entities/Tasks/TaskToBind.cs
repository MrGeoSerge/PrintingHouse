using PrintingHouse.Domain.Specifications;

namespace PrintingHouse.Domain.Entities.Tasks
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
