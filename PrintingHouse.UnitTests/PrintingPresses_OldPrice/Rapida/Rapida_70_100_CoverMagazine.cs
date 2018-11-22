using NUnit.Framework;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.UnitTests.VerificationResults;
using PrintingHouse.UnitTests.Data;

namespace PrintingHouse_OldPrice.UnitTests.PrintingPresses.Rapida
{
	[TestFixture]
	[Category("Rapida_70_100_CoverMagazine")]
	public class Rapida_70_100_CoverMagazine : PrintingPressTestBase_OldPrice
    {
		//imposition - спуск
		//impression - оттиск

		[SetUp]
		public override void Initialize()
		{
			//суперобложкажурнала АМЖ063
			printingPress = new Rapida74_5(
				new TaskToPrint(
					new BookPart("Cover",
						new IssueFormat(70, 100, 4), 
						new PaperInSheets(PaperType.CoatedPaper, 80, 1.31016, "Меловка пл.80 64х90 мат ", 64, 90),
						new IssueColors(4, 4), 
						2, PrintingPressType.Rapida), 
					1865), new Get_Old_PathFolderString());

			printingPressResult = JsonHelper<PrintingPressResult>.ReadFromFile("Rapida_70_100_CoverMagazineResult");
		}
	}
}
