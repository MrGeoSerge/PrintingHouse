using NUnit.Framework;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.UnitTests.VerificationResults;

namespace BookProduction
{

	[TestFixture]
    public class CorosetPlamag_84_108_InternalBlock
    {
        // Z80IС означает Rapida Format 84*108 Cover - типа обложка журнала, то есть его первые 4 стр

        CorosetPlamag coroset;
		CorosetResult corosetResult;
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

			corosetResult = new CorosetResult();
        }

		//Проверка правильности получения значений из прайса
		[Test]
		[Category("Coroset")]
		public void C84IB_00_FormPrice() 
			=> Assert.AreEqual(expected: corosetResult.FormPrice, 
				actual: coroset.GetFormPriceValue());

		[Test]
		public void C84IB_00_GetFittingPriceValue() 
			=> Assert.AreEqual(expected: corosetResult.FittingPriceValue, 
				actual: coroset.GetFittingPriceValue());

		[Test]
		public void C84IB_00_GetTechNeedsPriceValue() 
			=> Assert.AreEqual(expected: corosetResult.TechNeedsPrice, 
				actual: coroset.GetTechNeedsPriceValue());

		[Test]
		public void C84IB_00_GetImpressionPriceValue() 
			=> Assert.AreEqual(expected: corosetResult.ImpressionPrice, 
				actual: coroset.GetImpressionPriceValue());

		[Test]
		public void C84IB_01_GetPagesPerOneImposition() 
			=> Assert.AreEqual(expected: corosetResult.PagesPerOneImposition, 
				actual: coroset.GetPagesPerOneImposition());

		[Test]
		public void C84IB_02_GetImpositionsPerBook() 
			=> Assert.AreEqual(expected: corosetResult.ImposiotionsPerBook, 
				actual: coroset.GetImpositionsPerBook());

		[Test]
		public void C84IB_03_GetPrintingSheetsPerBook() 
			=> Assert.AreEqual(expected: corosetResult.PrintingSheetsPerBook, 
				actual: coroset.GetPrintingSheetsPerBook());

		[Test]
		public void C84IB_09_GetPrintingSheetsPerPrintRun() 
			=> Assert.AreEqual(expected: corosetResult.PrintingSheetsPerPrintRun, 
				actual: coroset.GetPrintingSheetsPerPrintRun());

		[Test]
		public void C84IB_04_GetPrintingForms() 
			=> Assert.AreEqual(expected: corosetResult.PrintingForms, 
				actual: coroset.GetPrintingForms());

		[Test]
		public void C84IB_05_GetCostOfPrintingFoms() 
			=> Assert.AreEqual(expected: corosetResult.CostOfPrintingFoms, 
				actual: coroset.GetCostOfPrintingFoms());

		[Test] //Оттиски
		public void C84IB_06_GetImpressions() 
			=> Assert.AreEqual(expected: corosetResult.Impressions, 
				actual: coroset.GetImpressions());

		[Test]
		public void C84IB_07_GetCostOfImpressions() 
			=> Assert.AreEqual(expected: corosetResult.CostOfImpressions, 
				actual: coroset.GetCostOfImpressions(), delta: 0.01);

		[Test]
		public void C84IB_08_GetCostOfPrinting() 
			=> Assert.AreEqual(expected: corosetResult.CostOfPrinting, 
				actual: coroset.GetCostOfPrinting(), delta: 0.01);

		[Test]
		public void C84IB_10_GetPaperConsumptionForTechnicalNeeds() 
			=> Assert.AreEqual(expected: corosetResult.PaperConsumptionForTechnicalNeeds, 
				actual: coroset.GetPaperConsumptionForTechnicalNeeds());

		[Test]
		public void C84IB_11_GetFittingOnPrintRun() 
			=> Assert.AreEqual(expected: corosetResult.FittingOnPrintRun, 
				actual: coroset.GetFittingOnPrintRun());

		[Test]
		public void C84IB_12_GetTotalPaperConsumptionInPressFormat() 
			=> Assert.AreEqual(expected: corosetResult.TotalPaperConsumptionInPressFormat, 
				actual: coroset.GetTotalPaperConsumptionInPressFormat());
	}
}


