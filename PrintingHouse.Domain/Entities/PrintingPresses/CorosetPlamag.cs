using PrintingHouse.Domain.Entities.PriceLists;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.Domain.Entities.PrintingPresses.Abstract;
using System;
using PrintingHouse.Domain.Interfaces;

namespace PrintingHouse.Domain.Entities.PrintingPresses
{
	public class CorosetPlamag : RolledPress
	{
		CorosetPriceList corosetPriceList;
		const string corosetPriceListString = "CorosetPriceList";
		const double cutting = 0.546;//рубка - параметр размера печатной ротационной машины

		//public CorosetPlamag(TaskToPrint taskToPrint) :
		//	base(taskToPrint)
		//{
		//	Cutting = cutting;
		//	//corosetPriceList = PriceListHelper<CorosetPriceList>.Instance.ReadFromFile(corosetPriceListString);
  //          corosetPriceList = PriceListHelper<CorosetPriceList>.ReadFromFile(corosetPriceListString);

  //      }

		public CorosetPlamag(TaskToPrint taskToPrint, IGetPathFolder getPathFolder) :
			base(taskToPrint)
		{
			Cutting = cutting;
            var priceListHelper = new PriceListHelper<CorosetPriceList>(getPathFolder);
            corosetPriceList = priceListHelper.ReadFromFile(corosetPriceListString);
        }
        public override double GetFormPriceValue()
		{
			return corosetPriceList.Form;
		}

		public override double GetFittingPriceValue()
		{
			return corosetPriceList.Fitting;
		}

		public override double GetTechNeedsPriceValue()
		{
			if (TaskToPrint.Colors.ToString() == "1+1")
			{
				return corosetPriceList.TechNeeds["1+1"];
			}
			else
				return corosetPriceList.TechNeeds["1+1"]
					+ corosetPriceList.TechNeeds["2+2"]
					* (TaskToPrint.Colors.Total() - 2);//-2 изначальных цвета
		}

		public override double GetImpressionPriceValue()
		{
            #region Not calculated by Printing House
            //По факту закоментированное не считается
            //if (TaskToPrint.Colors.ToString() == "1+1")
            //{
            //return corosetPriceList.Impression["1+1"];
            //}
            //else
            //    return CorosetPressPriceList.Impression["1+1"]
            //        + CorosetPressPriceList.Impression["2+2"]
            //        * (TaskToPrint.Colors.Total() - 2);//-2 изначальных цвета
            #endregion
            if (TaskToPrint.PrintRun < corosetPriceList.PrintRun_UpToWhichFixedPrintingCostApplyed)
            {
                 return 0.0; //No price for small printruns


            }
			foreach (var impression in corosetPriceList.Impressions)
			{
				if (TaskToPrint.PrintRun >= impression.LowerPrintRunBound
                    && TaskToPrint.PrintRun <= impression.UpperPrintRunBound)
				{
					return impression.ImpressionCost;
				}
			}
			throw new ArgumentOutOfRangeException("для такого тиража цена оттиска не указана в прайсе");


        }

        public override double GetCostOfImpressions()
        {
            if (TaskToPrint.PrintRun < corosetPriceList.PrintRun_UpToWhichFixedPrintingCostApplyed)
                return corosetPriceList.FixedPrintingCost * GetPrintingSheetsPerBook();

            return base.GetCostOfImpressions();
        }

        /// <summary>
        /// Коросет Форматы (840 * 546)
        /// 84 * 108 / 2 = 840мм * 540мм(предпочтительный!)
        /// 70 * 100 / 2 = 700мм * 500мм
        /// 70 * 90 / 2 = 700мм * 450мм
        /// 60 * 90 / 2 = 600мм * 450мм
        /// </summary>
        /// <returns></returns>
        public override IssueFormat GetPressSheetsFormat()
		{
			switch (TaskToPrint.Format.PrintingSheet())
			{
				case "84*108":
					return new IssueFormat("84*108/2");
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
