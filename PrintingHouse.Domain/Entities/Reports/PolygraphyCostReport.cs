using System;
using System.Collections.Generic;

namespace PrintingHouse.Domain.Entities.Reports
{
	public class PolygraphyCostReport
	{
		public Book Book { get; set; }
		List<PrintingPressReport> PrintingPressesReports { set; get; }

		AssemblyReport AssemblyReport { set; get; }

		//затраты на полиграфию 
		public double costOfPolygraphy;
		public double CostOfPolygraphy {
			get {
				costOfPolygraphy = 0;
				foreach (PrintingPressReport pressReport in PrintingPressesReports)
				{
					costOfPolygraphy += pressReport.CostOfPolygraphy;
				}
				return costOfPolygraphy;
			}
		}

		//затраты на материалы
		public double costOfMaterials;
		public double CostOfMaterials {
			get {
				costOfMaterials = 0;
				foreach (PrintingPressReport pressReport in PrintingPressesReports)
				{
					costOfMaterials += pressReport.PaperCost;
				}
				return costOfMaterials;
			}
		}




		//затраты на сборку (переплет, ламинация, перфорация, упаковка)
		public double CostOfAssembly => AssemblyReport.TotalCostOfAssembly;

		//общие затраты на тираж
		public double CostOfPrintRun => CostOfPolygraphy + CostOfMaterials + CostOfAssembly;

		//затраты на полиграфию одного экземпляра
		public double CostOfPolygraphyPerOneItem => Math.Round(CostOfPrintRun / Book.PrintRun, 4);

		public PolygraphyCostReport(Book _book, AssemblyReport assemblyReport, List<PrintingPressReport> printingPressesReports)
		{
			Book = _book;
			PrintingPressesReports = printingPressesReports;
			AssemblyReport = assemblyReport;

			//CostOfAssembly = AssemblyReport.TotalCostOfAssembly;

			//CostOfPrintRun = CostOfPolygraphy + CostOfMaterials + CostOfAssembly;
			//CostOfPolygraphyPerOneItem = Math.Round(CostOfPrintRun / book.PrintRun, 4);
		}


		public string CostReport()
		{
			string myBook = "Название: " + Book.Name + "\n";
			myBook += "Издательский код: " + Book.Id + "\n";
			myBook += "Тираж: " + Book.PrintRun + "\n";
			myBook += "Затраты на книгу: \n";
			myBook += "Оборот полиграфия: " + CostOfPolygraphy + "\n";
			myBook += "Всего материалов: " + CostOfMaterials + "\n";
			myBook += "Переплет: " + CostOfAssembly + "\n";
			myBook += "Оборот с материалами и полиграфией: " + CostOfPrintRun + "\n";
			myBook += "За экземпляр с материалами: " + CostOfPolygraphyPerOneItem + "\n";
			return myBook;
		}



	}
}
