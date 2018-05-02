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
	[Category("Zirkon_70_90_IB")]
	public class Zirkon_70_90_IB : PrintingPressTestBase
	{
		//imposition - спуск
		//impression - оттиск

		[SetUp]
		public override void Initialize()
		{
			//ШКК1-д9 - издательский код
			printingPress = new ZirkonForta660(new TaskToPrint(new BookPart("InternalBlock",
				new IssueFormat(70, 90, 16), new PaperInKg(PaperType.Offset, 60, 28.0675, "Люмисет", 70),
				new IssueColors(1, 1), 176), 2000));

			printingPressResult = JsonHelper<PrintingPressResult>.ReadFromFile("Zirkon_70_90_IBResult");
		}

	}
}


