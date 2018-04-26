using PrintingHouse.Domain.Entities.Tasks;

namespace PrintingHouse.Domain.Entities.PrintingPresses
{
	public abstract class RolledPress : PrintingPress
    {
        public double Cutting { get; set; }
        public RolledPress(TaskToPrint taskToPrint) :
            base(taskToPrint) {}

        public override int GetImpressions()
        {
            return GetPrintingSheetsPerPrintRun();
        }

        public override int GetFittingOnPrintRun()
        {
            return (int)GetFittingPriceValue() * GetPrintingForms();
        }
    }
}
