using PrintingHouse.Domain.Entities.PriceLists;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.Domain.Entities.PrintingPresses.Abstract;
using System;
using PrintingHouse.Domain.Interfaces;

namespace PrintingHouse.Domain.Entities.PrintingPresses
{
	public class Rapida74_5 : SheetPress
	{
		RapidaPriceList rapidaPriceList;
		const string rapidaPriceListString = "RapidaPriceList";

		public Rapida74_5(TaskToPrint taskToPrint, IGetPathFolder getPathFolder) :
			base(taskToPrint)
		{
            var priceListHelper = new PriceListHelper<RapidaPriceList>(getPathFolder);
            rapidaPriceList = priceListHelper.ReadFromFile(rapidaPriceListString);
		}

        //-----установка значений прайса-----
        //стоимость формы
        public override double FormPriceValue => rapidaPriceList.Form;


        //стоимость приладки
        public override double FittingPriceValue {
            get {
                //приладка(зависит от цветности) - и от тиража, то есть, если технужды > 0, приладка = 0
                if (TechNeedsPriceValue> 0)
                {
                    return 0.0;
                }
                return rapidaPriceList.Fitting[TaskToPrint.Colors.ToString()];
            }
        }

        //процент технужд
        public override double TechNeedsPriceValue {
            get {
                foreach (var printRun in rapidaPriceList.TechNeeds)
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

        //стоимость оттиска
        public override double ImpressionPriceValue {
            get {
                if (PrintingSheetsPerPrintRun <= rapidaPriceList.PrintRun_UpToWhichFixedPrintingCostApplyed)
                {
                    return 0.0; //No price for small printruns
                }
                foreach (var impression in rapidaPriceList.Impressions)
                {
                    if (PrintingSheetsPerPrintRun >= impression.LowerPrintRunBound
                        && PrintingSheetsPerPrintRun <= impression.UpperPrintRunBound)
                    {
                        return impression.ImpressionCost;
                    }
                }
                throw new ArgumentOutOfRangeException("для такого тиража цена оттиска не указана в прайсе");
            }
        }

        public override double CostOfImpressions {
            get {
                if (TaskToPrint.PrintRun < rapidaPriceList.PrintRun_UpToWhichFixedPrintingCostApplyed)
                    return rapidaPriceList.FixedPrintingCost * PrintingSheetsPerBook;

                return base.CostOfImpressions;
            }
        }

        //метод вычисления формата листа оборудования 
        //в зависимости от заданного формата книги
        public override IssueFormat PressSheetsFormat {
            get {
                //Рапида Форматы (740 * 520)
                //84*108/4 = 420мм * 540мм
                //70*100/2 = 700мм * 500мм(предпочтительный!)
                //70*90/2 = 700мм * 450мм
                //60*90/2 = 600мм * 450мм
                switch (TaskToPrint.Format.PrintingSheet())
                {
                    case "84*108":
                        return new IssueFormat("84*108/4");
                    case "70*100":
                        return new IssueFormat("70*100/2");
                    case "70*90":
                        return new IssueFormat("70*90/2");
                    case "60*90":
                        return new IssueFormat("60*90/2");
                    default:
                        throw new ArgumentOutOfRangeException(TaskToPrint.Format.PrintingSheet());
                }
            }
        }
    }
}
