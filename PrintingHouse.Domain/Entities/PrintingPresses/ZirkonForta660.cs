using System;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Entities.PriceLists;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.Domain.Entities.PrintingPresses.Abstract;
using PrintingHouse.Domain.Interfaces;

namespace PrintingHouse.Domain.Entities.PrintingPresses
{
	public class ZirkonForta660 : RolledPress
	{
        //TODO: return printing press name to report

		ZirkonPriceList zirkonPriceList;
		const string zirkonPriceListString = "ZirkonPriceList";
		const double cutting = 0.452;//рубка - параметр размера печатной ротационной машины

		public ZirkonForta660(TaskToPrint taskToPrint, IGetPathFolder getPathFolder) :
			base(taskToPrint)
		{
			Cutting = cutting;
            var priceListHelper = new PriceListHelper<ZirkonPriceList>(getPathFolder);
            zirkonPriceList = priceListHelper.ReadFromFile(zirkonPriceListString);
		}

        public override double FormPriceValue => zirkonPriceList.Form;

        public override double FittingPriceValue => zirkonPriceList.Fitting;

        public override double TechNeedsPriceValue {
            get {
                if (TaskToPrint.Colors.ToString() == "1+1")
                {
                    return zirkonPriceList.TechNeeds["1+1"];
                }
                else
                    return zirkonPriceList.TechNeeds["1+1"]
                        + zirkonPriceList.TechNeeds["2+2"]
                        * (TaskToPrint.Colors.Total() - 2);//-2 изначальных цвета
            }
        }

        public override double ImpressionPriceValue {
            get {
                #region Not calculated by Printing House
                //По факту закоментированное не считается
                //if (TaskToPrint.Colors.ToString() == "1+1")
                //{
                //return zirkonPriceList.Impression["1+1"];
                //}
                //else
                //    return zirkontPressPriceList.Impression["1+1"]
                //        + zirkonPressPriceList.Impression["2+2"]
                //        * (TaskToPrint.Colors.Total() - 2);//-2 изначальных цвета
                #endregion
                if (TaskToPrint.PrintRun <= zirkonPriceList.PrintRun_UpToWhichFixedPrintingCostApplyed)
                {
                    if (TaskToPrint.Colors.ToString() == "1+1")
                        return 0.0; //No price for small printruns
                    else
                        throw new NotImplementedException("для такого маленького тиража не предусмотрена печать выше 1+1");
                }
                foreach (var impression in zirkonPriceList.Impressions)
                {
                    if (TaskToPrint.PrintRun >= impression.LowerPrintRunBound
                        && TaskToPrint.PrintRun <= impression.UpperPrintRunBound)
                    {
                        if (TaskToPrint.Colors.ToString() == "1+1")
                            return impression.ImpressionCost;
                        else
                        {
                            return impression.ImpressionCost + impression.SurplusForAdditionalColor * (TaskToPrint.Colors.Total() - 2);
                        }
                    }
                }
                throw new ArgumentOutOfRangeException("для такого тиража цена оттиска не указана в прайсе");
            }
        }

        public override double CostOfImpressions {
            get {
                if (TaskToPrint.PrintRun <= zirkonPriceList.PrintRun_UpToWhichFixedPrintingCostApplyed)
                    return zirkonPriceList.FixedPrintingCost * PrintingSheetsPerBook;

                return base.CostOfImpressions;
            }
        }

        public override IssueFormat PressSheetsFormat {
            get {
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
        }
    }
}
