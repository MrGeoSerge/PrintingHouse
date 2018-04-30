using NUnit.Framework;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.UnitTests.Data;
using PrintingHouse.UnitTests.VerificationResults;

namespace BookProduction
{
	[TestFixture]
	[Category("Rapida_60_90_IB")]
	public class Rapida_60_90_IB
	{
		Rapida74_5 rapida;
		Rapida_60_90_IBResult rapidaResult;

		//imposition - спуск
		//impression - оттиск

		[SetUp]
		public void Initialize()
		{
			rapida = new Rapida74_5(new TaskToPrint(new BookPart("ДН108-д11",
				new IssueFormat(60, 90, 8), new PaperInSheets(PaperType.FoldingBoxboard, 230, 2.5, "Умка", 64, 90),
				new IssueColors(4, 0), 4), 10000));

			rapidaResult = JsonHelper<Rapida_60_90_IBResult>.ReadFromFile("Rapida_60_90_IBResult");
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
