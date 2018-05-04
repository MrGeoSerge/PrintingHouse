using NUnit.Framework;
using PrintingHouse.Domain.Entities;
using PrintingHouse.Domain.Processes.PrintingHouseManagement;
using PrintingHouse.Domain.Entities.Reports;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.Domain.Entities.Paper;

namespace BookProduction.UnitTests
{
	[TestFixture]
    public class MiyConspectCreation
    {
        Book MkBook;
        DirectorOfTypography director;
		PolygraphyCostReport report;
        TaskToPrint taskToInnerBlock;
        CorosetPlamag coroset;
        PrintingPressReport IB_report;

        TaskToPrint taskToCover;
        Shinohara52_2 shinohara;
        PrintingPressReport Cov_report;

        [SetUp]
        public void Initialize()
        {
             MkBook = new Book("УММ034-д1", "Українська мова 8клас 2 семестр Нова програма Мій конспект", 1000,
                 new BookPart("Внутренний блок", 
                                new IssueFormat(84, 108, 16),
                                new PaperInKg(PaperType.Newsprint, 45, 15.656, "Шклов", 84),
                                new IssueColors(1, 1), 88),
                 new BookPart("Обложка", 
                                new IssueFormat(84, 108, 16),
                                new PaperInSheets(PaperType.FoldingBoxboard, 230, 2.482, "Умка", 64, 90),
                                new IssueColors(4, 1), 4),
                 new BookAssembly(BindingType.SaddleStitching, LaminationType.Glossy, true, PerforationType.usual));

            //director = new DirectorOfTypography(theBook);
            //report = director.MakeBook();
            taskToInnerBlock = new TaskToPrint(MkBook.BookParts[0], MkBook.PrintRun);
            coroset = new CorosetPlamag(taskToInnerBlock);
            IB_report = coroset.SendReport();

            taskToCover = new TaskToPrint(MkBook.BookParts[1], MkBook.PrintRun);
            shinohara = new Shinohara52_2(taskToCover);
            Cov_report = shinohara.SendReport();
        }


		[Test]
		[Category("Miy Conspect")]
		public void MK_IB_01() 
			=> Assert.AreEqual(expected: 12, 
				actual: coroset.PrintingForms);

		[Test]
		[Category("Miy Conspect")]
		public void MK_IB_02() 
			=> Assert.AreEqual(expected: 217.91, 
				actual: IB_report.PaperConsumptionInKg, delta: 0.03);

		[Test]
		[Category("Miy Conspect")]
		public void MK_IB_03() 
			=> Assert.AreEqual(expected: 5500, 
				actual: coroset.GetImpressions());

		[Test]
		[Category("Miy Conspect")]
		public void MK_IB_04() 
			=> Assert.AreEqual(expected: 1916.25, 
				actual: IB_report.CostOfPolygraphy);

		[Test]
		[Category("Miy Conspect")]
		public void MK_IB_05() 
			=> Assert.AreEqual(expected: 3411.60, 
				actual: IB_report.PaperCost, delta: 0.5);

		[Test]
		[Category("Miy Conspect")]
		public void MK_IB_06() 
			=> Assert.AreEqual(expected: 3411.60, 
				actual: IB_report.PaperCost, delta: 0.5);





		[Test]
		[Category("Miy Conspect")]
		public void MK_C_00_GetFormPriceValue() 
			=> Assert.AreEqual(expected: 54, 
				actual: shinohara.GetFormPriceValue());

		[Test]
		[Category("Miy Conspect")]
		public void MK_C_00_GetFittingPriceValue() 
			=> Assert.AreEqual(expected: 16, 
				actual: shinohara.GetFittingPriceValue());

		[Test]
		[Category("Miy Conspect")]
		public void MK_C_00_GetTechNeedsPriceValue() 
			=> Assert.AreEqual(expected: 3.2, 
				actual: shinohara.GetTechNeedsPriceValue());

		[Test]
		[Category("Miy Conspect")]
		public void MK_C_00_GetImpressionPriceValue() 
			=> Assert.AreEqual(expected: 0.037, 
				actual: shinohara.GetImpressionPriceValue());

		[Test]
		[Category("Miy Conspect")]
		public void MK_C_01_GetPagesPerOneImposition() 
			=> Assert.AreEqual(expected: 2, 
				actual: shinohara.GetPagesPerOneImposition());

		[Test]
		[Category("Miy Conspect")]
		public void MK_C_02_GetImpositionsPerBook() 
			=> Assert.AreEqual(expected: 2, 
				actual: shinohara.GetImpositionsPerBook());

		[Test]
		[Category("Miy Conspect")]
		public void MK_C_03_GetPrintingSheetsPerBook() 
			=> Assert.AreEqual(expected: 1, 
				actual: shinohara.GetPrintingSheetsPerBook());

		[Test]
		[Category("Miy Conspect")]
		public void MK_C_09_GetPrintingSheetsPerPrintRun() 
			=> Assert.AreEqual(expected: 1000, 
				actual: shinohara.GetPrintingSheetsPerPrintRun());

		[Test]
		[Category("Miy Conspect")]
		public void MK_C_04_GetPrintingForms() 
			=> Assert.AreEqual(expected: 5, 
				actual: shinohara.PrintingForms);

		[Test]
		[Category("Miy Conspect")]
		public void MK_C_05_GetCostOfPrintingFoms() 
			=> Assert.AreEqual(expected: 270, 
				actual: shinohara.GetCostOfPrintingFoms());

		[Test] //Оттиски
		[Category("Miy Conspect")]
		public void MK_C_06_GetImpressions() 
			=> Assert.AreEqual(expected: 5000, 
				actual: shinohara.GetImpressions());

		[Test]
		[Category("Miy Conspect")]
		public void MK_C_07_GetCostOfImpressions() 
			=> Assert.AreEqual(expected: 185, 
				actual: shinohara.GetCostOfImpressions(), delta: 0.01);

		[Test]
		[Category("Miy Conspect")]
		public void MK_C_08_GetCostOfPrinting() 
			=> Assert.AreEqual(expected: 455, 
				actual: shinohara.GetCostOfPrinting(), delta: 0.01);

		[Test]
		[Category("Miy Conspect")]
		public void MK_C_10_GetPaperConsumptionForTechnicalNeeds() 
			=> Assert.AreEqual(expected: 160, 
				actual: shinohara.GetPaperConsumptionForTechnicalNeeds());

		[Test]
		[Category("Miy Conspect")]
		public void MK_C_11_GetFittingOnPrintRun() 
			=> Assert.AreEqual(expected: 80, 
				actual: shinohara.GetFittingOnPrintRun());

		[Test]
		[Category("Miy Conspect")]
		public void MK_C_12_GetTotalPaperConsumptionInPressFormat() 
			=> Assert.AreEqual(expected: 1260, 
				actual: shinohara.GetTotalPaperConsumptionInPressFormat());

		[Test]
		[Category("Miy Conspect")]
		public void MK_C_13_GetNumberOfPrintSheetsInRawSheet() 
			=> Assert.AreEqual(expected: 4, 
				actual: Cov_report.NumberOfPrintSheetsInRawSheet);

		[Test]
		[Category("Miy Conspect")]
		public void MK_C_13____GetPaperConsumptionInRawSheets() 
			=> Assert.AreEqual(expected: 1260, 
				actual: Cov_report.press.GetTotalPaperConsumptionInPressFormat());

		[Test]
		[Category("Miy Conspect")]
		public void MK_C_13_PressSheetFormat() 
			=> Assert.AreEqual(expected: 8, 
				actual: shinohara.GetPressSheetsFormat().Fraction);

		[Test]
		[Category("Miy Conspect")]
		public void MK_C_14_GetPaperCost() 
			=> Assert.AreEqual(expected: 781.83, 
				actual: Cov_report.PaperCost);

		[Test]
		[Category("Miy Conspect")]
		public void MK_C_15_GetCostOfPolygraphy() 
			=> Assert.AreEqual(expected: 455, 
				actual: Cov_report.CostOfPolygraphy);

	}
}
