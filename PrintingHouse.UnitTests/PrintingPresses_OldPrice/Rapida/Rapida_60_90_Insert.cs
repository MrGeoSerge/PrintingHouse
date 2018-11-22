using NUnit.Framework;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.UnitTests.VerificationResults;
using PrintingHouse.UnitTests.Data;

namespace PrintingHouse_OldPrice.UnitTests.PrintingPresses.Rapida
{
	[TestFixture]
	[Category("Rapida60_90_Insert")]
	public class Rapida60_90_Insert : PrintingPressTestBase_OldPrice
    {
		// Вкладка

		//imposition - спуск
		//impression - оттиск

		[SetUp]
		public override void Initialize()
		{
			printingPress = new Rapida74_5(
				new TaskToPrint(
					new BookPart("Insert",
						new IssueFormat(60, 90, 32), 
						new PaperInSheets(PaperType.SelfAdhensivePaper, 80, 3.9758, "Unknown", 45, 64),
						new IssueColors(4, 0), 
						4, PrintingPressType.Rapida), 
					28000), new Get_Old_PathFolderString());

			printingPressResult = JsonHelper<PrintingPressResult>.ReadFromFile("Rapida_60_90_InsertResult");
		}
	}
}
