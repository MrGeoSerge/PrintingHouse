using NUnit.Framework;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.UnitTests.VerificationResults;
using PrintingHouse.UnitTests.Data;
using PrintingHouse.UnitTests.PrintingPresses;
using PrintingHouse.Domain.Entities.Reports;

namespace PrintingHouse_OldPrice.UnitTests.PrintingPresses.Shinohara
{
	[TestFixture]
	[Category("Shinohara_60_90_CoverPlanBook_AKK059")]
	public class Shinohara_60_90_CoverPlanBook : PrintingPressTestBase
    {
        PrintingPressReport pressReport;

        [SetUp]
		public override void Initialize()
		{
			printingPress = new Shinohara52_2(
				new TaskToPrint(
								new BookPart("Cover",
								new IssueFormat(60, 90, 16),
								new PaperInSheets(PaperType.FoldingBoxboard, 230, 3.57513, "Умка", 64, 90),
								new IssueColors(4, 0), 4, PrintingPressType.Shinohara, true),
								510), new GetPathFolderString());

			printingPressResult = JsonHelper<PrintingPressResult>.ReadFromFile("Shinohara_60_90_CoverPlanBook_AKK059");

            pressReport = new PrintingPressReport(printingPress);
        }

        [Test]
        public void Z_14_GetPaperExpenditure()
            => Assert.AreEqual(expected: printingPressResult.PaperExpenditure,
                actual: pressReport.PaperExpenditure);

        [Test]
        public void Z_15_GetSquareOfSheetInMeters2()
            => Assert.AreEqual(expected: printingPressResult.SquareOfSheetInMeters2,
                actual: pressReport.SquareOfSheetInMeters2, delta: 0.0001);

        [Test]
        public void Z_16_GetPaperInSquareMeters()
            => Assert.AreEqual(expected: printingPressResult.PaperInSquareMeters,
                actual: pressReport.PaperInSquareMeters, delta: 0.0001);

        [Test]
        public void Z_17_GetPaperConsumptionInKg()
            => Assert.AreEqual(expected: printingPressResult.PaperConsumptionInKg,
                actual: pressReport.PaperConsumptionInKg, delta: 0.01);

        [Test]
        public void Z_18_GetPaperCost()
            => Assert.AreEqual(expected: printingPressResult.PaperCost,
                actual: pressReport.PaperCost, delta: 0.01);

        [Test]
        public void Z_19_GetTotalCost()
            => Assert.AreEqual(expected: printingPressResult.TotalCost,
                actual: pressReport.TotalCost, delta: 0.01);

    }
}
