using NUnit.Framework;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.UnitTests.VerificationResults;
using PrintingHouse.UnitTests.Data;

namespace PrintingHouse.UnitTests.PrintingPresses.Zirkon
{

	[TestFixture]
	[Category("Zirkon_60_90_8_IB")]
	public class Zirkon_60_90_8_IB : PrintingPressTestBase
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
				new IssueColors(1, 1), 128), 10000));

			printingPressResult = JsonHelper<PrintingPressResult>.ReadFromFile("Zirkon_60_90_8_IBResult");
		}

	}
}