using System;
using PrintingHouse.Domain.Entities.Reports;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;

namespace PrintingHouse.Domain.Entities.PrintingPresses.Abstract
{
	abstract public class PrintingPress
	{
        //TODO: Make properties from Get Methods
		public TaskToPrint TaskToPrint { get; private set; }

		public IssueFormat PressSheetFormat { get; private set; }

		public PrintingPress(TaskToPrint taskToPrint)
		{
			this.TaskToPrint = taskToPrint;
			PressSheetFormat = PressSheetsFormat;
		}

        public abstract double FormPriceValue { get; }

        public abstract double FittingPriceValue { get; }

        public abstract double TechNeedsPriceValue { get; }

        public abstract double ImpressionPriceValue { get; }

        public abstract IssueFormat PressSheetsFormat { get; }

        public int PagesPerOneImposition => TaskToPrint.Format.Fraction / PressSheetFormat.Fraction;

        public double ImpositionsPerBook => (double)TaskToPrint.PagesNumber / PagesPerOneImposition;

        public double PrintingSheetsPerBook => ImpositionsPerBook/ 2;//лицо и оборот

        public int PrintingSheetsPerPrintRun => (int)Math.Round(PrintingSheetsPerBook * TaskToPrint.PrintRun,
                MidpointRounding.AwayFromZero);

        public virtual int PrintingForms => TaskToPrint.Colors.Total() * (int)Math.Ceiling(PrintingSheetsPerBook);

        public double CostOfPrintingFoms => PrintingForms * FormPriceValue;

        public abstract int Impressions { get; }

        public virtual double CostOfImpressions => Impressions * ImpressionPriceValue;

        public double CostOfPrinting => CostOfPrintingFoms + CostOfImpressions + CostOfVarnishing;

        public virtual double CostOfVarnishing => 0.0;

        public virtual int PaperConsumptionForTechnicalNeeds => (int)Math.Ceiling(((double)(int)((PrintingSheetsPerPrintRun * TechNeedsPriceValue / 100) * 10) / 10));
        //округляя до целых (количества листов), сначала отбрасываются сотые доли листа
        public abstract int FittingOnPrintRun { get; }

        public virtual int TotalPaperConsumptionInPressFormat => PrintingSheetsPerPrintRun + PaperConsumptionForTechnicalNeeds + FittingOnPrintRun;

        public PrintingPressReport SendReport => new PrintingPressReport(this);

        public string NameOfPrintingPress => this.GetType().Name;
    }
}
