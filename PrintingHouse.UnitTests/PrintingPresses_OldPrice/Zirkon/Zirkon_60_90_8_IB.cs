using NUnit.Framework;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.UnitTests.VerificationResults;
using PrintingHouse.UnitTests.Data;

namespace PrintingHouse_OldPrice.UnitTests.PrintingPresses.Zirkon
{

	[TestFixture]
	[Category("Zirkon_60_90_8_IB")]
	public class Zirkon_60_90_8_IB : PrintingPressTestBase_OldPrice
    {
		// Z60908IB означает Rapida Format 60*90 Internal block 

		//imposition - спуск
		//impression - оттиск

		[SetUp]
		public override void Initialize()
		{
			//ДН108-д11 - издательский код
			printingPress = new ZirkonForta660(new TaskToPrint(new BookPart("ДН108-д11",
				new IssueFormat(60, 90, 8), new PaperInKg(PaperType.Offset, 60, 25.1835, "Коростышев", 60),
				new IssueColors(1, 1), 128, PrintingPressType.Zirkon), 10000), new Get_Old_PathFolderString());

			printingPressResult = JsonHelper<PrintingPressResult>.ReadFromFile("Zirkon_60_90_8_IBResult");
		}

	}
}