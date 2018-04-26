using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookProduction;
using BookProduction.BookComponents;
using BookProduction.Assembly;
using BookProduction.IssueParams;
using BookProduction.Paper;
using BookProduction.PriceLists;
using BookProduction.PrintingPresses;
using BookProduction.Tasks;
using BookProduction.TypographyManagement;

namespace PrintingHouse.Domain.PrintingPresses
{
    public class ZirkonForta660: RolledPress
    {

        public ZirkonForta660(TaskToPrint taskToPrint) :
            base(taskToPrint)
        {
            Cutting = 0.452;//рубка - параметр размера печатной ротационной машины
        }



		public override double GetFormPriceValue()
        {
            return ZirkonPressPriceList.Form;
        }

		public override double GetFittingPriceValue()
        {
           return ZirkonPressPriceList.Fitting;
        }

		public override double GetTechNeedsPriceValue()
        {
             if(TaskToPrint.Colors.ToString() == "1+1")
            {
                return ZirkonPressPriceList.TechNeeds["1+1"];
            }
            else
                return ZirkonPressPriceList.TechNeeds["1+1"] 
                    + ZirkonPressPriceList.TechNeeds["2+2"] 
                    * (TaskToPrint.Colors.Total() - 2);//-2 изначальных цвета
        }

		public override double GetImpressionPriceValue()
        {
            //if (TaskToPrint.Colors.ToString() == "1+1")
            //{
                return ZirkonPressPriceList.Impression["1+1"];
            //}
            //else
            //    return ZirkonPressPriceList.Impression["1+1"]
            //        + ZirkonPressPriceList.Impression["2+2"]
            //        * (TaskToPrint.Colors.Total() - 2);//-2 изначальных цвета
        }


		public override IssueFormat GetPressSheetsFormat()
        {
            //Циркон Форматы (700 * 452):
            //84*108/4 = 420мм * 540мм;
            //70*100/4 = 350мм * 500мм;
            //70*90/2 = 700мм * 450мм;
            //60*90/2 = 600мм * 450мм(предпочтительный!)
            switch (TaskToPrint.Format.PrintingSheet())
            {
                case "84*108":
                    return new IssueFormat("84*108/4");
                case "70*100":
                    return new IssueFormat("70*100/4");
                case "70*90":
                    return new IssueFormat("70*90/2");
                case "60*90":
                    return new IssueFormat("60*90/2");
                default:
                    throw new ArgumentOutOfRangeException(TaskToPrint.Format.PrintingSheet());
            }


        }


    //    internal int GetPagesPerOneImposition()
    //    {
    //        return TaskToPrint.Format.Fraction / PressSheetFormat.Fraction;
    //    }

    //    internal double GetImpositionsPerBook()
    //    {
    //        return (double)TaskToPrint.PagesNumber / GetPagesPerOneImposition();
    //    }

    //    internal double GetPrintingSheetsPerBook()
    //    {
    //        return GetImpositionsPerBook() / 2;//лицо и оборот
    //    }

    //    internal int GetPrintingSheetsPerPrintRun()
    //    {
    //        return (int)(GetPrintingSheetsPerBook() * TaskToPrint.PrintRun);
    //    }

    //    internal int GetPrintingForms()
    //    {
    //        return TaskToPrint.Colors.Total() * (int)Math.Ceiling(GetPrintingSheetsPerBook());
    //    }

    //    internal double GetCostOfPrintingFoms()
    //    {
    //        return GetPrintingForms() * GetFormPriceValue();
    //    }

    //    internal int GetImpressions()
    //    {
    //        return GetPrintingSheetsPerPrintRun();//отличие от листовой!
    //    }

    //    internal double GetCostOfImpressions()
    //    {
    //        return GetImpressions() * GetImpressionPriceValue();
    //    }

    //    internal double GetCostOfPrinting()
    //    {
    //        return GetCostOfPrintingFoms() + GetCostOfImpressions();
    //    }

    //    internal int GetParerConsumptionForTechnicalNeeds()
    //    {
    //        return (int)(GetPrintingSheetsPerPrintRun() * GetTechNeedsPriceValue() / 100);
    //    }

    //    internal int GetFittingOnPrintRun()
    //    {
    //        return (int)GetFittingPriceValue() * GetPrintingForms();
    //    }

    //    internal int GetTotalPaperConsumptionInPressFormat()
    //    {
    //        return GetPrintingSheetsPerPrintRun() + GetParerConsumptionForTechnicalNeeds()
    //            + GetFittingOnPrintRun();
    //    }
    }
}
