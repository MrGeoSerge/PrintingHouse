using NUnit.Framework;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.UnitTests.Data;
using PrintingHouse.UnitTests.VerificationResults;

namespace PrintingHouse.UnitTests.PrintingPresses.Zirkon
{

	[TestFixture]
	[Category("Zirkon_84_108_Cover")]
	public class Zirkon_84_108_Cover : PrintingPressTestBase
	{
		// Z80IС означает Rapida Format 84*108 Cover - типа обложка журнала, то есть его первые 4 стр

		//imposition - спуск
		//impression - оттиск

		[SetUp]
		public override void Initialize()
		{
			//обложка журнала АМЖ063 - первые страницы журнала, которые 2+1
			printingPress = new ZirkonForta660(new TaskToPrint(new BookPart("InternalBlock",
				new IssueFormat(84, 108, 16), new PaperInKg(PaperType.Newsprint, 43, 13.42708, "Змиев", 54),
				new IssueColors(2, 1), 8), 1815));

			printingPressResult = JsonHelper<PrintingPressResult>.ReadFromFile("Zirkon_84_108_CoverResult");
		}
	}
}


