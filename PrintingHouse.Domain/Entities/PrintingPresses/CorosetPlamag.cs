using PrintingHouse.Domain.Entities.PriceLists;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;
using System;

namespace PrintingHouse.Domain.Entities.PrintingPresses
{
	public class CorosetPlamag : RolledPress
	{

		public CorosetPlamag(TaskToPrint taskToPrint) :
			base(taskToPrint)
		{
			Cutting = 0.546;//рубка - параметр размера печатной ротационной машины
		}

		public override double GetFormPriceValue()
		{
			return CorosetPressPriceList.Form;
		}

		public override double GetFittingPriceValue()
		{
			return CorosetPressPriceList.Fitting;
		}

		public override double GetTechNeedsPriceValue()
		{
			if (TaskToPrint.Colors.ToString() == "1+1")
			{
				return CorosetPressPriceList.TechNeeds["1+1"];
			}
			else
				return CorosetPressPriceList.TechNeeds["1+1"]
					+ CorosetPressPriceList.TechNeeds["2+2"]
					* (TaskToPrint.Colors.Total() - 2);//-2 изначальных цвета
		}

		public override double GetImpressionPriceValue()
		{
			//По факту закоментированное не считается
			//if (TaskToPrint.Colors.ToString() == "1+1")
			//{
			return CorosetPressPriceList.Impression["1+1"];
			//}
			//else
			//    return CorosetPressPriceList.Impression["1+1"]
			//        + CorosetPressPriceList.Impression["2+2"]
			//        * (TaskToPrint.Colors.Total() - 2);//-2 изначальных цвета
		}


		public override IssueFormat GetPressSheetsFormat()
		{
			//Коросет Форматы (840 * 546)
			//84 * 108 / 2 = 840мм * 540мм(предпочтительный!)
			//70 * 100 / 2 = 700мм * 500мм
			//70 * 90 / 2 = 700мм * 450мм
			//60 * 90 / 2 = 600мм * 450мм
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
