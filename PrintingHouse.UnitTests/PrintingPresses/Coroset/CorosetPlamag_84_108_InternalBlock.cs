using NUnit.Framework;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.UnitTests.VerificationResults;
using PrintingHouse.UnitTests.Data;

namespace BookProduction
{

	[TestFixture]
	public class CorosetPlamag_84_108_InternalBlock
	{
		CorosetPlamag coroset;
		PrintingPressResult corosetResult;
		//imposition - спуск
		//impression - оттиск

		[SetUp]
		public void Initialize()
		{
			//МДН7-д3
			coroset = new CorosetPlamag(
				new TaskToPrint(
								new BookPart("InternalBlock",
								new IssueFormat(84, 108, 16), 
								new PaperInKg(PaperType.Newsprint, 45, 16.48, "Германия", 84),
								new IssueColors(1, 1), 152),
					1000));

			corosetResult = JsonHelper<PrintingPressResult>.ReadFromFile("CorosetResult");
        }

		//Проверка правильности получения значений из прайса
		[Test]
		[Category("Coroset")]
		public void C84IB_00_FormPrice() 
			=> Assert.AreEqual(expected: corosetResult.FormPrice, 
				actual: coroset.GetFormPriceValue());

		[Test]
		[Category("Coroset")]
		public void C84IB_00_GetFittingPriceValue() 
			=> Assert.AreEqual(expected: corosetResult.FittingPriceValue, 
				actual: coroset.GetFittingPriceValue());

		[Test]
		[Category("Coroset")]
		public void C84IB_00_GetTechNeedsPriceValue() 
			=> Assert.AreEqual(expected: corosetResult.TechNeedsPrice, 
				actual: coroset.GetTechNeedsPriceValue());

		[Test]
		[Category("Coroset")]
		public void C84IB_00_GetImpressionPriceValue() 
			=> Assert.AreEqual(expected: corosetResult.ImpressionPrice, 
				actual: coroset.GetImpressionPriceValue());

		[Test]
		[Category("Coroset")]
		public void C84IB_01_GetPagesPerOneImposition() 
			=> Assert.AreEqual(expected: corosetResult.PagesPerOneImposition, 
				actual: coroset.GetPagesPerOneImposition());

		[Test]
		[Category("Coroset")]
		public void C84IB_02_GetImpositionsPerBook() 
			=> Assert.AreEqual(expected: corosetResult.ImposiotionsPerBook, 
				actual: coroset.GetImpositionsPerBook());

		[Test]
		[Category("Coroset")]
		public void C84IB_03_GetPrintingSheetsPerBook() 
			=> Assert.AreEqual(expected: corosetResult.PrintingSheetsPerBook, 
				actual: coroset.GetPrintingSheetsPerBook());

		[Test]
		[Category("Coroset")]
		public void C84IB_09_GetPrintingSheetsPerPrintRun() 
			=> Assert.AreEqual(expected: corosetResult.PrintingSheetsPerPrintRun, 
				actual: coroset.GetPrintingSheetsPerPrintRun());

		[Test]
		[Category("Coroset")]
		public void C84IB_04_GetPrintingForms() 
			=> Assert.AreEqual(expected: corosetResult.PrintingForms, 
				actual: coroset.GetPrintingForms());

		[Test]
		[Category("Coroset")]
		public void C84IB_05_GetCostOfPrintingFoms() 
			=> Assert.AreEqual(expected: corosetResult.CostOfPrintingFoms, 
				actual: coroset.GetCostOfPrintingFoms());

		[Test] //Оттиски
		[Category("Coroset")]
		public void C84IB_06_GetImpressions() 
			=> Assert.AreEqual(expected: corosetResult.Impressions, 
				actual: coroset.GetImpressions());

		[Test]
		[Category("Coroset")]
		public void C84IB_07_GetCostOfImpressions() 
			=> Assert.AreEqual(expected: corosetResult.CostOfImpressions, 
				actual: coroset.GetCostOfImpressions(), delta: 0.01);

		[Test]
		[Category("Coroset")]
		public void C84IB_08_GetCostOfPrinting() 
			=> Assert.AreEqual(expected: corosetResult.CostOfPrinting, 
				actual: coroset.GetCostOfPrinting(), delta: 0.01);

		[Test]
		[Category("Coroset")]
		public void C84IB_10_GetPaperConsumptionForTechnicalNeeds() 
			=> Assert.AreEqual(expected: corosetResult.PaperConsumptionForTechnicalNeeds, 
				actual: coroset.GetPaperConsumptionForTechnicalNeeds());

		[Test]
		[Category("Coroset")]
		public void C84IB_11_GetFittingOnPrintRun() 
			=> Assert.AreEqual(expected: corosetResult.FittingOnPrintRun, 
				actual: coroset.GetFittingOnPrintRun());

		[Test]
		[Category("Coroset")]
		public void C84IB_12_GetTotalPaperConsumptionInPressFormat() 
			=> Assert.AreEqual(expected: corosetResult.TotalPaperConsumptionInPressFormat, 
				actual: coroset.GetTotalPaperConsumptionInPressFormat());
	}
}


