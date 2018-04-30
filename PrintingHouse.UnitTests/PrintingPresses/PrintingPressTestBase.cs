using NUnit.Framework;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.UnitTests.VerificationResults;
using PrintingHouse.UnitTests.Data;
using PrintingHouse.Domain.Entities.PrintingPresses.Abstract;

namespace PrintingHouse.UnitTests.PrintingPresses
{
	[TestFixture]
	public abstract class PrintingPressTestBase
	{
		protected PrintingPress printingPress;
		protected PrintingPressResult printingPressResult;
		//imposition - спуск
		//impression - оттиск

		[SetUp]
		public abstract void Initialize();

		//Проверка правильности получения значений из прайса
		[Test]
		public void R60C_00_GetFormPriceValue() 
			=> Assert.AreEqual(expected: printingPressResult.FormPrice, 
				actual: printingPress.GetFormPriceValue());

		[Test]
		public void R60C_00_GetFittingPriceValue() 
			=> Assert.AreEqual(expected: printingPressResult.FittingPriceValue, 
				actual: printingPress.GetFittingPriceValue());

		[Test]
		public void R60C_00_GetTechNeedsPriceValue() 
			=> Assert.AreEqual(expected: printingPressResult.TechNeedsPrice, 
				actual: printingPress.GetTechNeedsPriceValue());

		[Test]
		public void R60C_00_GetImpressionPriceValue() 
			=> Assert.AreEqual(expected: printingPressResult.ImpressionPrice, 
				actual: printingPress.GetImpressionPriceValue());

		[Test]
		public void R60C_01_GetPagesPerOneImposition() 
			=> Assert.AreEqual(expected: printingPressResult.PagesPerOneImposition, 
				actual: printingPress.GetPagesPerOneImposition());

		[Test]
		public void R60C_02_GetImpositionsPerBook() 
			=> Assert.AreEqual(expected: printingPressResult.ImposiotionsPerBook, 
				actual: printingPress.GetImpositionsPerBook());

		[Test]
		public void R60C_03_GetPrintingSheetsPerBook() 
			=> Assert.AreEqual(expected: printingPressResult.PrintingSheetsPerBook, 
				actual: printingPress.GetPrintingSheetsPerBook());

		[Test]
		public void R60C_09_GetPrintingSheetsPerPrintRun() 
			=> Assert.AreEqual(expected: printingPressResult.PrintingSheetsPerPrintRun, 
				actual: printingPress.GetPrintingSheetsPerPrintRun());

		[Test]
		public void R60C_04_GetPrintingForms() 
			=> Assert.AreEqual(expected: printingPressResult.PrintingForms, 
				actual: printingPress.GetPrintingForms());

		[Test]
		public void R60C_05_GetCostOfPrintingFoms() 
			=> Assert.AreEqual(expected: printingPressResult.CostOfPrintingFoms, 
				actual: printingPress.GetCostOfPrintingFoms());

		[Test] //Оттиски
		public void R60C_06_GetImpressions() 
			=> Assert.AreEqual(expected: printingPressResult.Impressions, 
				actual: printingPress.GetImpressions());

		[Test]
		public void R60C_07_GetCostOfImpressions() 
			=> Assert.AreEqual(expected: printingPressResult.CostOfImpressions, 
				actual: printingPress.GetCostOfImpressions(), delta: 0.01);

		[Test]
		public void R60C_08_GetCostOfPrinting() 
			=> Assert.AreEqual(expected: printingPressResult.CostOfPrinting, 
				actual: printingPress.GetCostOfPrinting(), delta: 0.01);

		[Test]
		public void R60C_10_GetPaperConsumptionForTechnicalNeeds() 
			=> Assert.AreEqual(expected: printingPressResult.PaperConsumptionForTechnicalNeeds, 
				actual: printingPress.GetPaperConsumptionForTechnicalNeeds());

		[Test]
		public void R60C_11_GetFittingOnPrintRun() 
			=> Assert.AreEqual(expected: printingPressResult.FittingOnPrintRun, 
				actual: printingPress.GetFittingOnPrintRun());

		[Test]
		public void R60C_12_GetTotalPaperConsumptionInPressFormat() 
			=> Assert.AreEqual(expected: printingPressResult.TotalPaperConsumptionInPressFormat, 
				actual: printingPress.GetTotalPaperConsumptionInPressFormat());
	}
}
