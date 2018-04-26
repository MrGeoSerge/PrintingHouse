using PrintingHouse.Domain.Entities.Tasks;

namespace PrintingHouse.Domain.Entities.PrintingPresses
{
	public abstract class SheetPress: PrintingPress
    {
        public SheetPress(TaskToPrint taskToPrint) : 
            base(taskToPrint) { }

		public override int GetImpressions()
        {
            return GetPrintingSheetsPerPrintRun() * (TaskToPrint.Colors.Total());
        }

		public override int GetFittingOnPrintRun()
        {
            return (int)GetFittingPriceValue();
        }
    }
}
