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
	[Category("Rapida_70_100_CoverMagazine")]
	public class Rapida_70_100_CoverMagazine
	{
		Rapida74_5 rapida;
		PrintingPressResult rapidaResult;

		//imposition - спуск
		//impression - оттиск

		[SetUp]
		public void Initialize()
		{
			//суперобложкажурнала АМЖ063
			rapida = new Rapida74_5(new TaskToPrint(new BookPart("Cover",
				new IssueFormat(70, 100, 4), new PaperInSheets(PaperType.CoatedPaper, 80, 1.31016, "Меловка пл.80 64х90 мат ", 64, 90),
				new IssueColors(4, 4), 2), 1865));

			rapidaResult = JsonHelper<PrintingPressResult>.ReadFromFile("Rapida_70_100_CoverMagazineResult");
		}

		//Проверка правильности получения значений из прайса
		[Test]
		public void R70C_00_GetFormPriceValue() 
			=> Assert.AreEqual(expected: rapidaResult.FormPrice, 
				actual: rapida.GetFormPriceValue());

		[Test]
		public void R70C_00_GetFittingPriceValue() 
			=> Assert.AreEqual(expected: rapidaResult.FittingPriceValue, 
				actual: rapida.GetFittingPriceValue());

		[Test]
		public void R70C_00_GetTechNeedsPriceValue() 
			=> Assert.AreEqual(expected: rapidaResult.TechNeedsPrice, 
				actual: rapida.GetTechNeedsPriceValue());

		[Test]
		public void R70C_00_GetImpressionPriceValue() 
			=> Assert.AreEqual(expected: rapidaResult.ImpressionPrice, 
				actual: rapida.GetImpressionPriceValue());

		[Test]
		public void R70C_01_GetPagesPerOneImposition() 
			=> Assert.AreEqual(expected: rapidaResult.PagesPerOneImposition, 
				actual: rapida.GetPagesPerOneImposition());

		[Test]
		public void R70C_02_GetImpositionsPerBook() 
			=> Assert.AreEqual(expected: rapidaResult.ImposiotionsPerBook, 
				actual: rapida.GetImpositionsPerBook());

		[Test]
		public void R70C_03_GetPrintingSheetsPerBook() 
			=> Assert.AreEqual(expected: rapidaResult.PrintingSheetsPerBook, 
				actual: rapida.GetPrintingSheetsPerBook());

		[Test]
		public void R70C_09_GetPrintingSheetsPerPrintRun() 
			=> Assert.AreEqual(expected: rapidaResult.PrintingSheetsPerPrintRun, 
				actual: rapida.GetPrintingSheetsPerPrintRun());

		[Test]
		public void R70C_04_GetPrintingForms() 
			=> Assert.AreEqual(expected: rapidaResult.PrintingForms, 
				actual: rapida.GetPrintingForms());

		[Test]
		public void R70C_05_GetCostOfPrintingFoms() 
			=> Assert.AreEqual(expected: rapidaResult.CostOfPrintingFoms, 
				actual: rapida.GetCostOfPrintingFoms());

		[Test] //Оттиски
		public void R70C_06_GetImpressions() =>
			Assert.AreEqual(expected: rapidaResult.Impressions, 
				actual: rapida.GetImpressions());

		[Test]
		public void R70C_07_GetCostOfImpressions() 
			=> Assert.AreEqual(expected: rapidaResult.CostOfImpressions, 
				actual: rapida.GetCostOfImpressions(), delta: 0.01);

		[Test]
		public void R70C_08_GetCostOfPrinting() 
			=> Assert.AreEqual(expected: rapidaResult.CostOfPrinting, 
				actual: rapida.GetCostOfPrinting(), delta: 0.01);

		[Test]
		public void R70C_10_GetPaperConsumptionForTechnicalNeeds() 
			=> Assert.AreEqual(expected: rapidaResult.PaperConsumptionForTechnicalNeeds, 
				actual: rapida.GetPaperConsumptionForTechnicalNeeds());

		[Test]
		public void R70C_11_GetFittingOnPrintRun() 
			=> Assert.AreEqual(expected: rapidaResult.FittingOnPrintRun, 
				actual: rapida.GetFittingOnPrintRun());

		[Test]
		public void R70C_12_GetTotalPaperConsumptionInPressFormat() 
			=> Assert.AreEqual(expected: rapidaResult.TotalPaperConsumptionInPressFormat, 
				actual: rapida.GetTotalPaperConsumptionInPressFormat());
	}
}
