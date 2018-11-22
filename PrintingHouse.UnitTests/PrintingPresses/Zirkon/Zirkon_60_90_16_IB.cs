using NUnit.Framework;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Entities.Reports;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.UnitTests.Data;
using PrintingHouse.UnitTests.VerificationResults;

namespace PrintingHouse.UnitTests.PrintingPresses.Zirkon
{

	[TestFixture]
	[Category("Zirkon_60_90_16_IB_AKK059")]
	public class Zirkon_60_90_16_IB : PrintingPressTestBase
    {
		PrintingPressReport pressReport;
		//imposition - спуск
		//impression - оттиск

		[SetUp]
		public override void Initialize()
		{
			//ДТБ015-д1 - издательский код
			printingPress = new ZirkonForta660(new TaskToPrint(new BookPart("InternalBlock",
				new IssueFormat(60, 90, 16), new PaperInKg(PaperType.Newsprint, 43, 23.69, "Котлас", 60),
				new IssueColors(1, 1), 96, PrintingPressType.Zirkon), 510), new GetPathFolderString());

			printingPressResult = JsonHelper<PrintingPressResult>.ReadFromFile("Data", "Zirkon_60_90_16_IBResult_AKK059");

			pressReport = new PrintingPressReport(printingPress);
		}


        //Проверка класса PressReport
        [Test]
        public void Z60IB_13_GetCostOfPolygraphy() 
            => Assert.AreEqual(expected: printingPressResult.CostOfPrinting, 
                actual: printingPress.CostOfPrinting);

        [Test]
        public void Z60IB_14_GetPaperExpenditure() 
            => Assert.AreEqual(expected: printingPressResult.PaperExpenditure,
                actual: pressReport.PaperExpenditure);

        [Test]
        public void Z60IB_15_GetSquareOfSheetInMeters2() 
            => Assert.AreEqual(expected: printingPressResult.SquareOfSheetInMeters2,
                actual: pressReport.SquareOfSheetInMeters2, delta: 0.0001);

        [Test]
        public void Z60IB_16_GetPaperInSquareMeters() 
            => Assert.AreEqual(expected: printingPressResult.PaperInSquareMeters, 
                actual: pressReport.PaperInSquareMeters, delta: 0.0001);

        [Test]
        public void Z60IB_17_GetPaperConsumptionInKg() 
            => Assert.AreEqual(expected: printingPressResult.PaperConsumptionInKg, 
                actual: pressReport.PaperConsumptionInKg, delta: 0.01);

        [Test]
        public void Z60IB_18_GetPaperCost() 
            => Assert.AreEqual(expected: printingPressResult.PaperCost, 
                actual: pressReport.PaperCost, delta: 0.01);

        [Test]
        public void Z60IB_19_GetTotalCost() 
            => Assert.AreEqual(expected: printingPressResult.TotalCost, 
                actual: pressReport.TotalCost, delta: 0.01);

    }
}


