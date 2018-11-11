using System;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Entities.PrintingPresses.Abstract;

namespace PrintingHouse.Domain.Entities.Reports
{
	//отчет Печатного станка
	public class PrintingPressReport
	{
		public PrintingPress press;

		public PrintingPressReport(PrintingPress press)
		{
			this.press = press;
		}
		public double CostOfPolygraphy => press.CostOfPrinting;

		#region Расчет расхода бумаги
		//---------Расчет расхода бумаги для списания------------
		public double PaperExpenditure {
			get {
				if (press.TaskToPrint.Paper is PaperInKg)
				{
					return PaperConsumptionInKg;
				}
				return PaperConsumptionInRawSheets;
			}
		}

		public double SquareOfSheetInMeters2 {
			get {
				RolledPress rolledPress = press as RolledPress;

				return (double)press.PressSheetFormat.Length / 100 *
					rolledPress.Cutting;
			}
		}

		public double PaperInSquareMeters => SquareOfSheetInMeters2 * press.TotalPaperConsumptionInPressFormat;

		/// <summary>
		/// округляемм вверх до двух знаков после запятой
		/// paperConsumptionInKg = Math.Ceiling(paperConsumptionInKg * 100) / 100;
		/// </summary>
		public double PaperConsumptionInKg => Math.Round((double)(PaperInSquareMeters * press.TaskToPrint.Paper.Density / 1000), 2);

		//для листовой
		public int PaperConsumptionInRawSheets => (int)Math.Ceiling((double)press.TotalPaperConsumptionInPressFormat/
				NumberOfPrintSheetsInRawSheet);

		public int NumberOfPrintSheetsInRawSheet {
			get {
				PaperInSheets printingSheet = press.TaskToPrint.Paper as PaperInSheets;
				return printingSheet.GetNumberOfPrintSheetsInRawSheet(press.PressSheetsFormat);
			}
		}

		public double PaperCost => Math.Round((double)PaperExpenditure * press.TaskToPrint.Paper.Price, 2);

		public double TotalCost => CostOfPolygraphy + PaperCost;


		#endregion

		public void ShowDetailedReport()
		{
			Console.WriteLine(press.TaskToPrint.Name);
			Console.WriteLine("Расход бумаги для списания: " +
				PaperExpenditure+ " " + press.TaskToPrint.Paper.Unit);
			Console.WriteLine("Цена " + press.TaskToPrint.Paper.Price + " " + press.TaskToPrint.Paper.Unit);
			Console.WriteLine("Стоимость бумаги: " + PaperCost);
			Console.WriteLine("Количество оттисков: " + press.Impressions);
			Console.WriteLine("Стоимость оттиска: " + press.ImpressionPriceValue);
			Console.WriteLine("Общая стоимость форм: " + press.CostOfPrintingFoms);
			Console.WriteLine("Стоимость оттисков: " + press.CostOfImpressions);
			Console.WriteLine("Общая сумма за печать: " + CostOfPolygraphy);
			Console.WriteLine("Всего затрат: " + TotalCost);
			Console.WriteLine("");
		}

		public string DetailedPressReport()
		{
			string report = String.Empty;
			report += press.TaskToPrint.Name + Environment.NewLine;
			report += "Расход бумаги для списания: " + PaperExpenditure+ " " + press.TaskToPrint.Paper.Unit + Environment.NewLine;
			report += "Цена " + press.TaskToPrint.Paper.Price + " " + press.TaskToPrint.Paper.Unit + Environment.NewLine;
			report += "Стоимость бумаги: " + PaperCost + Environment.NewLine;
			report += "Количество оттисков: " + press.Impressions+ Environment.NewLine;
			report += "Стоимость оттиска: " + press.ImpressionPriceValue+ Environment.NewLine;
			report += "Общая стоимость форм: " + press.CostOfPrintingFoms+ Environment.NewLine;
			report += "Стоимость оттисков: " + press.CostOfImpressions+ Environment.NewLine;
			report += "Общая сумма за печать: " + CostOfPolygraphy + Environment.NewLine;
			report += "Всего затрат: " + TotalCost;
			return report;
		}
	}
}
