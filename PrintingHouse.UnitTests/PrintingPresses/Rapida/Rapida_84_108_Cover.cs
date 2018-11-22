using NUnit.Framework;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.UnitTests.VerificationResults;
using PrintingHouse.UnitTests.Data;
using PrintingHouse.Domain.Entities.Reports;

namespace PrintingHouse.UnitTests.PrintingPresses.Rapida
{
	[TestFixture]
	[Category("Rapida_84_108_16_Cover_ZMK001")]
	public class Rapida_84_108_Cover : PrintingPressTestBase
    {
        PrintingPressReport pressReport;

        [SetUp]
		public override void Initialize()
		{
			printingPress = new Rapida74_5(
				new TaskToPrint(
					new BookPart("Cover",
						new IssueFormat(84, 108, 16), 
						new PaperInSheets(PaperType.CoatedPaper, 215, 1.6068, "Unknown", 64, 90),
						new IssueColors(4, 4), 
						4, PrintingPressType.Rapida), 
					16000), new GetPathFolderString());

			printingPressResult = JsonHelper<PrintingPressResult>.ReadFromFile("Rapida_84_108_CoverZMK001");
            pressReport = new PrintingPressReport(printingPress);

        }

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
