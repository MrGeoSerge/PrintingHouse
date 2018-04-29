using System;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Entities.PriceLists;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.Domain.Entities.PrintingPresses.Abstract;

namespace PrintingHouse.Domain.Entities.PrintingPresses
{
	public class Shinohara52_2 : SheetPress
	{
		ShinoharaPriceList shinoharaPriceList;
		const string shinoharaPriceListString = "ShinoharaPriceList";

		public Shinohara52_2(TaskToPrint taskToPrint) :
			base(taskToPrint)
		{
			shinoharaPriceList = PriceListHelper<ShinoharaPriceList>.ReadFromFile(shinoharaPriceListString);
		}

		public override double GetFormPriceValue()
		{
			return shinoharaPriceList.Form;
		}

		public override double GetFittingPriceValue()
		{
			return shinoharaPriceList.Fitting;
		}

		public override double GetTechNeedsPriceValue()
		{
			foreach (var printRun in shinoharaPriceList.TechNeeds)
			{
				int printRun_Key = Int32.Parse(printRun.Key);
				if (GetPrintingSheetsPerPrintRun() < printRun_Key)
				{
					return printRun.Value;
				}
			}
			throw new ArgumentOutOfRangeException("для такого тиража технужды не указаны в прайсе");
		}


		public override double GetImpressionPriceValue()
		{
			foreach (var printRun in shinoharaPriceList.Impression)
			{
				int printRun_Key = Int32.Parse(printRun.Key);
				if (GetPrintingSheetsPerPrintRun() < printRun_Key)
				{
					return printRun.Value;
				}
			}
			throw new ArgumentOutOfRangeException("для такого тиража цена оттиска не указана в прайсе");
		}

		public override IssueFormat GetPressSheetsFormat()
		{
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

		public override int GetTotalPaperConsumptionInPressFormat()
		{
			int totalPaperConsumption = GetPrintingSheetsPerPrintRun() + GetPaperConsumptionForTechnicalNeeds()
				+ GetFittingOnPrintRun();

			//добавляется волшебный переплетный процент 1.65% на Шинохару (в прайсе нет)
			totalPaperConsumption += (int)Math.Round(totalPaperConsumption * 0.0165, MidpointRounding.AwayFromZero);

			return totalPaperConsumption;
		}

		public override int GetFittingOnPrintRun()
		{
			return (int)GetFittingPriceValue() * GetPrintingForms();
		}

		public new int GetPaperConsumptionForTechnicalNeeds()
		{
			return base.GetPaperConsumptionForTechnicalNeeds() * GetPrintingForms();
		}
	}
}
