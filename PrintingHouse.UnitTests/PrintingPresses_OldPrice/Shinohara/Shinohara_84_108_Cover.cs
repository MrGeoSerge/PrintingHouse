using NUnit.Framework;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.UnitTests.VerificationResults;
using PrintingHouse.UnitTests.Data;

namespace PrintingHouse_OldPrice.UnitTests.PrintingPresses.Shinohara
{
	[TestFixture]
	[Category("Shinohara")]
	public class Shinohara_84_108_Cover : PrintingPressTestBase_OldPrice
    {

		[SetUp]
		public override void Initialize()
		{
			printingPress = new Shinohara52_2(
				new TaskToPrint(
								new BookPart("Cover",
								new IssueFormat(84, 108, 16),
								new PaperInSheets(PaperType.FoldingBoxboard, 230, 2.482, "Умка", 64, 90),
								new IssueColors(4, 1), 4, PrintingPressType.Shinohara),
								1000), new Get_Old_PathFolderString());

			printingPressResult = JsonHelper<PrintingPressResult>.ReadFromFile("ShinoharaResult");
		}

	}
}
