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
		ZirkonPriceList zirkonPriceList;
		const string zirkonPriceListString = "ZirkonPriceList";
		const double cutting = 0.452;//рубка - параметр размера печатной ротационной машины

		public ZirkonForta660(TaskToPrint taskToPrint, IGetPathFolder getPathFolder) :
			base(taskToPrint)
		{
			Cutting = cutting;

            var priceListHelper = new PriceListHelper<ZirkonPriceList>(getPathFolder);

            zirkonPriceList = priceListHelper.ReadFromFile(zirkonPriceListString);
			//zirkonPriceList = PriceListHelper<ZirkonPriceList>.ReadFromFile(zirkonPriceListString);
		}



		public override double GetFormPriceValue()
		{
			return zirkonPriceList.Form;
		}

		public override double GetFittingPriceValue()
		{
			return zirkonPriceList.Fitting;
		}

		public override double GetTechNeedsPriceValue()
		{
			if (TaskToPrint.Colors.ToString() == "1+1")
			{
				return zirkonPriceList.TechNeeds["1+1"];
			}
			else
				return zirkonPriceList.TechNeeds["1+1"]
					+ zirkonPriceList.TechNeeds["2+2"]
					* (TaskToPrint.Colors.Total() - 2);//-2 изначальных цвета
		}

		public override double GetImpressionPriceValue()
		{
			//if (TaskToPrint.Colors.ToString() == "1+1")
			//{
			return zirkonPriceList.Impression["1+1"];
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
	}
}
