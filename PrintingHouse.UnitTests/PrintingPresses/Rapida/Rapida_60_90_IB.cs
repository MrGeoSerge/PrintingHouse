using NUnit.Framework;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.UnitTests.Data;
using PrintingHouse.UnitTests.VerificationResults;

namespace PrintingHouse.UnitTests.PrintingPresses.Rapida
{
	[TestFixture]
	[Category("Rapida_60_90_IB")]
	public class Rapida_60_90_IB : PrintingPressTestBase
	{
		//imposition - спуск
		//impression - оттиск

		[SetUp]
		public override void Initialize()
		{
			printingPress = new Rapida74_5(
				new TaskToPrint(
					new BookPart("ДН108-д11",
						new IssueFormat(60, 90, 8), 
						new PaperInSheets(PaperType.FoldingBoxboard, 230, 2.5, "Умка", 64, 90),
						new IssueColors(4, 0), 
						4), 
					10000));

			printingPressResult = JsonHelper<PrintingPressResult>.ReadFromFile("Rapida_60_90_IBResult");
		}
	}
}
