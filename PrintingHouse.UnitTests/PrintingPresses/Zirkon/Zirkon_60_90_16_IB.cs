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
	[Category("Zirkon_60_90_16_IB")]
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
				new IssueFormat(60, 90, 16), new PaperInKg(PaperType.Offset, 60, 23.25, "Котлас", 60),
				new IssueColors(1, 1), 192, PrintingPressType.Zirkon), 1000), new Get_Old_PathFolderString());

			printingPressResult = JsonHelper<PrintingPressResult>.ReadFromFile("Zirkon_60_90_16_IBResult");

			pressReport = new PrintingPressReport(printingPress);
		}


		//Проверка класса PressReport
		[Test]
		public void Z60IB_13_GetCostOfPolygraphy()
		{
			Assert.AreEqual(2600.4, pressReport.CostOfPolygraphy);
		}

		public void Z60IB_14_GetPaperExpenditure()
		{
			Assert.AreEqual(360.65, pressReport.PaperExpenditure);
		}

		[Test]
		public void Z60IB_15_GetSquareOfSheetInMeters2()
		{
			Assert.AreEqual(0.2712, pressReport.SquareOfSheetInMeters2, delta: 0.0001);
		}

		[Test]
		public void Z60IB_16_GetPaperInSquareMeters()
		{
			Assert.AreEqual(6010.8768, pressReport.PaperInSquareMeters, delta: 0.0001);
		}

		[Test]
		public void Z60IB_17_GetPaperConsumptionInKg()
		{
			Assert.AreEqual(360.65, pressReport.PaperConsumptionInKg);
		}

		[Test]
		public void Z60IB_18_GetPaperCost()
		{
			Assert.AreEqual(8385.11, pressReport.PaperCost);
		}

		[Test]
		public void Z60IB_19_GetTotalCost()
		{
			Assert.AreEqual(10985.51, pressReport.TotalCost);
		}

	}
}


