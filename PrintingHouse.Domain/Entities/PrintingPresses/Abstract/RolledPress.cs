using PrintingHouse.Domain.Entities.Tasks;

namespace PrintingHouse.Domain.Entities.PrintingPresses.Abstract
{
	public abstract class RolledPress : PrintingPress
    {
        public double Cutting { get; set; }
        public RolledPress(TaskToPrint taskToPrint) :
            base(taskToPrint) {}

        public override int Impressions => PrintingSheetsPerPrintRun;

        public override int FittingOnPrintRun => (int)FittingPriceValue * PrintingForms;
    }
}
