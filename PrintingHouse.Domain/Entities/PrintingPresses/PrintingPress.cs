using System;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;

namespace PrintingHouse.Domain.PrintingPresses
{
	abstract public class PrintingPress
    {
        public TaskToPrint TaskToPrint { get; private set; }

        public IssueFormat PressSheetFormat { get; private set; }

        public PrintingPress(TaskToPrint taskToPrint)
        {
            this.TaskToPrint = taskToPrint;

            PressSheetFormat = GetPressSheetsFormat();
        }

        public abstract double GetFormPriceValue();

        public abstract double GetFittingPriceValue();

        public abstract double GetTechNeedsPriceValue();

        public abstract double GetImpressionPriceValue();

        public abstract IssueFormat GetPressSheetsFormat();


        public int GetPagesPerOneImposition()
        {
            return TaskToPrint.Format.Fraction / PressSheetFormat.Fraction;
        }

        public double GetImpositionsPerBook()
        {
            return (double)TaskToPrint.PagesNumber / GetPagesPerOneImposition();
        }

        public double GetPrintingSheetsPerBook()
        {
            return GetImpositionsPerBook() / 2;//лицо и оборот
        }

        public int GetPrintingSheetsPerPrintRun()
        {
            return (int)Math.Round(GetPrintingSheetsPerBook() * TaskToPrint.PrintRun, 
                MidpointRounding.AwayFromZero);
        }

        public int GetPrintingForms()
        {
            return TaskToPrint.Colors.Total() * (int)Math.Ceiling(GetPrintingSheetsPerBook());
        }

        public double GetCostOfPrintingFoms()
        {
            return GetPrintingForms() * GetFormPriceValue();
        }

        public abstract int GetImpressions();

        public double GetCostOfImpressions()
        {
            return GetImpressions() * GetImpressionPriceValue();
        }

        public double GetCostOfPrinting()
        {
            return GetCostOfPrintingFoms() + GetCostOfImpressions();
        }

        public virtual int GetPaperConsumptionForTechnicalNeeds()
        {
            return (int)Math.Ceiling(((double)(int)((GetPrintingSheetsPerPrintRun() 
                * GetTechNeedsPriceValue() / 100) * 10)/10));
            //округляя до целых (количества листов), сначала отбрасываются сотые доли листа
        }

        public abstract int GetFittingOnPrintRun();


        public virtual int GetTotalPaperConsumptionInPressFormat()
        {
            return GetPrintingSheetsPerPrintRun() + GetPaperConsumptionForTechnicalNeeds()
                + GetFittingOnPrintRun();
        }

        public PressReport SendReport()
        {
            return new PressReport(this);
        }
    }
}
