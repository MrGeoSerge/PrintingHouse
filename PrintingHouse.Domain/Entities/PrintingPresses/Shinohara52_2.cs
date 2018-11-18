using System;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Entities.PriceLists;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.Domain.Entities.PrintingPresses.Abstract;
using PrintingHouse.Domain.Interfaces;

namespace PrintingHouse.Domain.Entities.PrintingPresses
{
	public class Shinohara52_2 : SheetPress
	{
		ShinoharaPriceList shinoharaPriceList;
		const string shinoharaPriceListString = "ShinoharaPriceList";

		public Shinohara52_2(TaskToPrint taskToPrint, IGetPathFolder getPathFolder) :
			base(taskToPrint)
		{
            var priceListHelper = new PriceListHelper<ShinoharaPriceList>(getPathFolder);
            shinoharaPriceList = priceListHelper.ReadFromFile(shinoharaPriceListString);
		}

        public override double FormPriceValue => shinoharaPriceList.Form;

        public override double FittingPriceValue => shinoharaPriceList.Fitting;

        public override int PrintingForms => (int)(TaskToPrint.Colors.Total() * PrintingSheetsPerBook);

        public override double TechNeedsPriceValue {
            get {
                foreach (var printRun in shinoharaPriceList.TechNeeds)
                {
                    int printRun_Key = Int32.Parse(printRun.Key);
                    if (PrintingSheetsPerPrintRun < printRun_Key)
                    {
                        return printRun.Value;
                    }
                }
                throw new ArgumentOutOfRangeException("для такого тиража технужды не указаны в прайсе");
            }
        }

        public override double ImpressionPriceValue {
            get {
                if (TaskToPrint.PrintRun <= shinoharaPriceList.PrintRun_UpToWhichFixedPrintingCostApplyed)
                {
                    return 0.0; //No price for small printruns
                }
                foreach (var impression in shinoharaPriceList.Impressions)
                {
                    if (TaskToPrint.PrintRun >= impression.LowerPrintRunBound
                        && TaskToPrint.PrintRun <= impression.UpperPrintRunBound)
                    {
                        return impression.ImpressionCost;
                    }
                }
                throw new ArgumentOutOfRangeException($"для такого тиража {TaskToPrint.PrintRun} цена оттиска не указана в прайсе {PrintingSheetsPerPrintRun}");
            }
        }

        public override double CostOfImpressions {
            get {
                if (TaskToPrint.PrintRun < shinoharaPriceList.PrintRun_UpToWhichFixedPrintingCostApplyed)
                    return shinoharaPriceList.FixedPrintingCost * PrintingSheetsPerBook;

                return base.CostOfImpressions;
            }
        }

        public override IssueFormat PressSheetsFormat {
            get {
                //Шинохара Форматы (370 * 520)
                //84 * 108 / 8 = 420мм * 270мм
                //70 * 100 / 4 = 350мм * 500мм
                //(предпочтительный!)
                //70 * 90 / 4 = 350мм * 450мм
                //60 * 90 / 4 = 300мм * 450мм

                switch (TaskToPrint.Format.PrintingSheet())
                {
                    case "84*108":
                        return new IssueFormat("84*108/8");
                    case "70*100":
                        return new IssueFormat("70*100/4");
                    case "70*90":
                        return new IssueFormat("70*90/4");
                    case "60*90":
                        return new IssueFormat("60*90/4");
                    default:
                        throw new ArgumentOutOfRangeException(TaskToPrint.Format.PrintingSheet());
                }

            }
        }

        public override int TotalPaperConsumptionInPressFormat {
            get {
                int totalPaperConsumption = PrintingSheetsPerPrintRun + PaperConsumptionForTechnicalNeeds + FittingOnPrintRun;

                //добавляется волшебный переплетный процент 1.65% на Шинохару (в прайсе нет)
                totalPaperConsumption += (int)Math.Round(totalPaperConsumption * 0.0165, MidpointRounding.AwayFromZero);

                return totalPaperConsumption;
            }
        }

        public override int FittingOnPrintRun => (int)FittingPriceValue * PrintingForms;

        public override int PaperConsumptionForTechnicalNeeds => base.PaperConsumptionForTechnicalNeeds * PrintingForms;

        public override double CostOfVarnishing => TaskToPrint.VarnishingOrdered == true ? shinoharaPriceList.Varnishing * PrintingSheetsPerPrintRun : 0.0;
    }
}
