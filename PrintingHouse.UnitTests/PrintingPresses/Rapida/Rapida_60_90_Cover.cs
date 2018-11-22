using NUnit.Framework;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.UnitTests.VerificationResults;
using PrintingHouse.UnitTests.Data;

namespace PrintingHouse.UnitTests.PrintingPresses.Rapida
{
	[TestFixture]
	[Category("Rapida_60_90_Cover")]
	public class Rapida_60_90_Cover : PrintingPressTestBase
	{
		[SetUp]
		public override void Initialize()
		{
			printingPress = new Rapida74_5(
				new TaskToPrint(
					new BookPart("Cover",
						new IssueFormat(60, 90, 16), 
						new PaperInSheets(PaperType.CoatedPaper, 115, 1.50792, "Unknown", 64, 90),
						new IssueColors(4, 4), 
						4, PrintingPressType.Rapida), 
					4400), new Get_Old_PathFolderString());

			printingPressResult = JsonHelper<PrintingPressResult>.ReadFromFile("Rapida_60_90_CoverResult");
		}
	}
}
