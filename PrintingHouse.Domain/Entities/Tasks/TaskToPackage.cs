using PrintingHouse.Domain.Specifications;

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
