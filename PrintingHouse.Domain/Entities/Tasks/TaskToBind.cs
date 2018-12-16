using PrintingHouse.Domain.Specifications;

namespace PrintingHouse.Domain.Entities.Tasks
{
	public class TaskToBind
    {
        
        public IssueFormat Format { get; set; }
        public int PagesNumber { get; set; }
        public int PrintRun { get; set; }
        public BindingType BindingType { get; set; }

        public TaskToBind(IssueFormat _issueFormat, int _pagesNumber, int _printRun, BindingType _bindingType)
        {
            Format = _issueFormat;
            PagesNumber = _pagesNumber;
            PrintRun = _printRun;
            BindingType = _bindingType;
        }
    }
}
