using PrintingHouse.Domain.Entities.Tasks;

namespace PrintingHouse.Domain.Entities.PrintingPresses.Abstract
{
    public abstract class SheetPress : PrintingPress
    {
        public SheetPress(TaskToPrint taskToPrint) :
            base(taskToPrint) { }

        public override int Impressions => PrintingSheetsPerPrintRun * (TaskToPrint.Colors.Total());

        public override int FittingOnPrintRun => (int)FittingPriceValue;

    }
}
