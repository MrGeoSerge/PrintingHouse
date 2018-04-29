using NUnit.Framework;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.UnitTests.VerificationResults;
using PrintingHouse.UnitTests.Data;

namespace PrintingHouse.UnitTests.PrintingPresses.Shinohara
{
	[TestFixture]
	[Category("Shinohara")]
	public class Shinohara_84_108_Cover
	{
		Shinohara52_2 shinohara;
		ShinoharaResult shinoharaResult;

		[SetUp]
		public void Inititalize()
		{
			shinohara = new Shinohara52_2(
				new TaskToPrint(
								new BookPart("Cover",
								new IssueFormat(84, 108, 16),
								new PaperInSheets(PaperType.FoldingBoxboard, 230, 2.482, "Умка", 64, 90),
								new IssueColors(4, 1), 4),
								1000));

			shinoharaResult = JsonHelper<ShinoharaResult>.ReadFromFile("ShinoharaResult");
		}

		[Test]
		[Category("Shinohara")]
		public void MK_C_00_GetFormPriceValue()
			=> Assert.AreEqual(expected: shinoharaResult.FormPrice,
				actual: shinohara.GetFormPriceValue());

		[Test]
		[Category("Shinohara")]
		public void MK_C_00_GetFittingPriceValue()
			=> Assert.AreEqual(expected: shinoharaResult.FittingPriceValue,
				actual: shinohara.GetFittingPriceValue());

		[Test]
		[Category("Shinohara")]
		public void MK_C_00_GetTechNeedsPriceValue()
			=> Assert.AreEqual(expected: shinoharaResult.TechNeedsPrice,
				actual: shinohara.GetTechNeedsPriceValue());

		[Test]
		[Category("Shinohara")]
		public void MK_C_00_GetImpressionPriceValue()
			=> Assert.AreEqual(expected: shinoharaResult.ImpressionPrice,
				actual: shinohara.GetImpressionPriceValue());

		[Test]
		[Category("Shinohara")]
		public void MK_C_01_GetPagesPerOneImposition()
			=> Assert.AreEqual(expected: shinoharaResult.PagesPerOneImposition,
				actual: shinohara.GetPagesPerOneImposition());

		[Test]
		[Category("Shinohara")]
		public void MK_C_02_GetImpositionsPerBook()
			=> Assert.AreEqual(expected: shinoharaResult.ImposiotionsPerBook,
				actual: shinohara.GetImpositionsPerBook());

		[Test]
		[Category("Shinohara")]
		public void MK_C_03_GetPrintingSheetsPerBook()
			=> Assert.AreEqual(expected: shinoharaResult.PrintingSheetsPerBook,
				actual: shinohara.GetPrintingSheetsPerBook());

		[Test]
		[Category("Shinohara")]
		public void MK_C_09_GetPrintingSheetsPerPrintRun()
			=> Assert.AreEqual(expected: shinoharaResult.PrintingSheetsPerPrintRun,
				actual: shinohara.GetPrintingSheetsPerPrintRun());

		[Test]
		[Category("Shinohara")]
		public void MK_C_04_GetPrintingForms()
			=> Assert.AreEqual(expected: shinoharaResult.PrintingForms,
				actual: shinohara.GetPrintingForms());

		[Test]
		[Category("Shinohara")]
		public void MK_C_05_GetCostOfPrintingFoms()
			=> Assert.AreEqual(expected: shinoharaResult.CostOfPrintingFoms,
				actual: shinohara.GetCostOfPrintingFoms());

		[Test] //Оттиски
		[Category("Shinohara")]
		public void MK_C_06_GetImpressions()
			=> Assert.AreEqual(expected: shinoharaResult.Impressions,
				actual: shinohara.GetImpressions());

		[Test]
		[Category("Shinohara")]
		public void MK_C_07_GetCostOfImpressions()
			=> Assert.AreEqual(expected: shinoharaResult.CostOfImpressions,
				actual: shinohara.GetCostOfImpressions(), delta: 0.01);

		[Test]
		[Category("Shinohara")]
		public void MK_C_08_GetCostOfPrinting()
			=> Assert.AreEqual(expected: shinoharaResult.CostOfPrinting,
				actual: shinohara.GetCostOfPrinting(), delta: 0.01);

		[Test]
		[Category("Shinohara")]
		public void MK_C_10_GetPaperConsumptionForTechnicalNeeds()
			=> Assert.AreEqual(expected: shinoharaResult.PaperConsumptionForTechnicalNeeds,
				actual: shinohara.GetPaperConsumptionForTechnicalNeeds());

		[Test]
		[Category("Shinohara")]
		public void MK_C_11_GetFittingOnPrintRun()
			=> Assert.AreEqual(expected: shinoharaResult.FittingOnPrintRun,
				actual: shinohara.GetFittingOnPrintRun());

		[Test]
		[Category("Shinohara")]
		public void MK_C_12_GetTotalPaperConsumptionInPressFormat()
			=> Assert.AreEqual(expected: shinoharaResult.TotalPaperConsumptionInPressFormat,
				actual: shinohara.GetTotalPaperConsumptionInPressFormat());

		[Test]
		[Category("Shinohara")]
		public void MK_C_13_PressSheetFormat()
			=> Assert.AreEqual(expected: shinoharaResult.PressSheetFormat_Fraction,
				actual: shinohara.GetPressSheetsFormat().Fraction);
	}
}
