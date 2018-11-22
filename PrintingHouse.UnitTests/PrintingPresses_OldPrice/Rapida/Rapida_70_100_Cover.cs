using NUnit.Framework;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.UnitTests.VerificationResults;
using PrintingHouse.UnitTests.Data;

namespace PrintingHouse_OldPrice.UnitTests.PrintingPresses.Rapida
{
	[TestFixture]
	[Category("Rapida_70_100_Cover")]
	public class Rapida_70_100_Cover : PrintingPressTestBase_OldPrice
    {
		//imposition - спуск
		//impression - оттиск

		[SetUp]
		public override void Initialize()
		{
			printingPress = new Rapida74_5(
				new TaskToPrint(
					new BookPart("Cover",
						new IssueFormat(70, 100, 16), 
						new PaperInSheets(PaperType.FoldingBoxboard, 200, 3.172, "Умка", 70, 100),
						new IssueColors(4, 1), 
						4, PrintingPressType.Rapida), 
					28000), new Get_Old_PathFolderString());

			printingPressResult = JsonHelper<PrintingPressResult>.ReadFromFile("Rapida_70_100_CoverResult");
		}
	}
}
