using NUnit.Framework;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.UnitTests.VerificationResults;
using PrintingHouse.UnitTests.Data;

namespace BookProduction
{
	[TestFixture]
	[Category("Rapida_60_90_Cover")]
	public class Rapida_60_90_Cover
	{
		Rapida74_5 rapida;
		Rapida_60_90_CoverResult rapidaResult;
		//imposition - спуск
		//impression - оттиск

		[SetUp]
		public void Initialize()
		{
			rapida = new Rapida74_5(new TaskToPrint(new BookPart("Cover",
				new IssueFormat(60, 90, 16), new PaperInSheets(PaperType.CoatedPaper, 115, 1.50792, "Unknown", 64, 90),
				new IssueColors(4, 4), 4), 4400));

			rapidaResult = JsonHelper<Rapida_60_90_CoverResult>.ReadFromFile("Rapida_60_90_CoverResult");
		}

		//Проверка правильности получения значений из прайса
		[Test]
		public void R60C_00_GetFormPriceValue() 
			=> Assert.AreEqual(expected: rapidaResult.FormPrice, 
				actual: rapida.GetFormPriceValue());

		[Test]
		public void R60C_00_GetFittingPriceValue() 
			=> Assert.AreEqual(expected: rapidaResult.FittingPriceValue, 
				actual: rapida.GetFittingPriceValue());

		[Test]
		public void R60C_00_GetTechNeedsPriceValue() 
			=> Assert.AreEqual(expected: rapidaResult.TechNeedsPrice, 
				actual: rapida.GetTechNeedsPriceValue());

		[Test]
		public void R60C_00_GetImpressionPriceValue() 
			=> Assert.AreEqual(expected: rapidaResult.ImpressionPrice, 
				actual: rapida.GetImpressionPriceValue());

		[Test]
		public void R60C_01_GetPagesPerOneImposition() 
			=> Assert.AreEqual(expected: rapidaResult.PagesPerOneImposition, 
				actual: rapida.GetPagesPerOneImposition());

		[Test]
		public void R60C_02_GetImpositionsPerBook() 
			=> Assert.AreEqual(expected: rapidaResult.ImposiotionsPerBook, 
				actual: rapida.GetImpositionsPerBook());

		[Test]
		public void R60C_03_GetPrintingSheetsPerBook() 
			=> Assert.AreEqual(expected: rapidaResult.PrintingSheetsPerBook, 
				actual: rapida.GetPrintingSheetsPerBook());

		[Test]
		public void R60C_09_GetPrintingSheetsPerPrintRun() 
			=> Assert.AreEqual(expected: rapidaResult.PrintingSheetsPerPrintRun, 
				actual: rapida.GetPrintingSheetsPerPrintRun());

		[Test]
		public void R60C_04_GetPrintingForms() 
			=> Assert.AreEqual(expected: rapidaResult.PrintingForms, 
				actual: rapida.GetPrintingForms());

		[Test]
		public void R60C_05_GetCostOfPrintingFoms() 
			=> Assert.AreEqual(expected: rapidaResult.CostOfPrintingFoms, 
				actual: rapida.GetCostOfPrintingFoms());

		[Test] //Оттиски
		public void R60C_06_GetImpressions() 
			=> Assert.AreEqual(expected: rapidaResult.Impressions, 
				actual: rapida.GetImpressions());

		[Test]
		public void R60C_07_GetCostOfImpressions() 
			=> Assert.AreEqual(expected: rapidaResult.CostOfImpressions, 
				actual: rapida.GetCostOfImpressions(), delta: 0.01);

		[Test]
		public void R60C_08_GetCostOfPrinting() 
			=> Assert.AreEqual(expected: rapidaResult.CostOfPrinting, 
				actual: rapida.GetCostOfPrinting(), delta: 0.01);

		[Test]
		public void R60C_10_GetPaperConsumptionForTechnicalNeeds() 
			=> Assert.AreEqual(expected: rapidaResult.PaperConsumptionForTechnicalNeeds, 
				actual: rapida.GetPaperConsumptionForTechnicalNeeds());

		[Test]
		public void R60C_11_GetFittingOnPrintRun() 
			=> Assert.AreEqual(expected: rapidaResult.FittingOnPrintRun, 
				actual: rapida.GetFittingOnPrintRun());

		[Test]
		public void R60C_12_GetTotalPaperConsumptionInPressFormat() 
			=> Assert.AreEqual(expected: rapidaResult.TotalPaperConsumptionInPressFormat, 
				actual: rapida.GetTotalPaperConsumptionInPressFormat());
	}
}
