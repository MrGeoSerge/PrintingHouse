using NUnit.Framework;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.PrintingPresses;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.UnitTests.Data;
using PrintingHouse.UnitTests.VerificationResults;

namespace PrintingHouse.UnitTests.PrintingPresses.Zirkon
{

	[TestFixture]
	[Category("Zirkon_60_90_16_IB")]
	public class Zirkon_60_90_16_IB : PrintingPressTestBase
	{
		PressReport pressReport;
		//imposition - спуск
		//impression - оттиск

		[SetUp]
		public override void Initialize()
		{
			//ДТБ015-д1 - издательский код
			printingPress = new ZirkonForta660(new TaskToPrint(new BookPart("InternalBlock",
				new IssueFormat(60, 90, 16), new PaperInKg(PaperType.Offset, 60, 23.25, "Котлас", 60),
				new IssueColors(1, 1), 192), 1000));

			printingPressResult = JsonHelper<PrintingPressResult>.ReadFromFile("Zirkon_60_90_16_IBResult");

			pressReport = new PressReport(printingPress);
		}


		//Проверка класса PressReport
		[Test]
		public void Z60IB_13_GetCostOfPolygraphy()
		{
			Assert.AreEqual(2600.4, pressReport.GetCostOfPolygraphy());
		}

		public void Z60IB_14_GetPaperExpenditure()
		{
			Assert.AreEqual(360.65, pressReport.GetPaperExpenditure());
		}

		[Test]
		public void Z60IB_15_GetSquareOfSheetInMeters2()
		{
			Assert.AreEqual(0.2712, pressReport.GetSquareOfSheetInMeters2(), delta: 0.0001);
		}

		[Test]
		public void Z60IB_16_GetPaperInSquareMeters()
		{
			Assert.AreEqual(6010.8768, pressReport.GetPaperInSquareMeters(), delta: 0.0001);
		}

		[Test]
		public void Z60IB_17_GetPaperConsumptionInKg()
		{
			Assert.AreEqual(360.65, pressReport.GetPaperConsumptionInKg());
		}

		[Test]
		public void Z60IB_18_GetPaperCost()
		{
			Assert.AreEqual(8385.11, pressReport.GetPaperCost());
		}

		[Test]
		public void Z60IB_19_GetTotalCost()
		{
			Assert.AreEqual(10985.51, pressReport.GetTotalCost());
		}

	}
}


