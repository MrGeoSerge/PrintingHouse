using NUnit.Framework;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.UnitTests.VerificationResults;
using PrintingHouse.UnitTests.Data;

namespace PrintingHouse.UnitTests.PrintingPresses.Rapida
{
	[TestFixture]
	[Category("Rapida_70_100_InternalBlock")]
	public class Rapida_70_100_InternalBlock : PrintingPressTestBase
	{
		// R70IB означает Rapida Format 70*100 Internal block 
		//imposition - спуск
		//impression - оттиск

		[SetUp]
		public override void Initialize()
		{
			//ОСК002 - издательский код
			printingPress = new Rapida74_5(
				new TaskToPrint(
					new BookPart("InternalBlock",
					new IssueFormat(70, 100, 16), 
					new PaperInSheets(PaperType.Offset, 60, 1.2850997544, "Люмисет", 70, 100),
					new IssueColors(2, 2),
					48),
				28000));

			printingPressResult = JsonHelper<PrintingPressResult>.ReadFromFile("Rapida_70_100_InternalBlockResult");
		}
	}
}


