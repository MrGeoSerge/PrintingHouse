using NUnit.Framework;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;

namespace BookProduction
{
	[TestFixture]
	[Category("Rapida_60_90_IB")]
	public class Rapida_60_90_IB
	{
		Rapida74_5 rapida;

		//imposition - спуск
		//impression - оттиск

		[SetUp]
		public void Initialize()
		{
			rapida = new Rapida74_5(new TaskToPrint(new BookPart("ДН108-д11",
				new IssueFormat(60, 90, 8), new PaperInSheets(PaperType.FoldingBoxboard, 230, 2.5, "Умка", 64, 90),
				new IssueColors(4, 0), 4), 10000));
		}

		//Проверка правильности получения значений из прайса
		[Test]
		public void R60C_00_GetFormPriceValue() 
			=> Assert.AreEqual(expected: 108, 
				actual: rapida.GetFormPriceValue());

		[Test]
		public void R60C_00_GetFittingPriceValue() 
			=> Assert.AreEqual(expected: 0, 
				actual: rapida.GetFittingPriceValue());

		[Test]
		public void R60C_00_GetTechNeedsPriceValue() 
			=> Assert.AreEqual(expected: 8, 
				actual: rapida.GetTechNeedsPriceValue());

		[Test]
		public void R60C_00_GetImpressionPriceValue() 
			=> Assert.AreEqual(expected: 0.037, 
				actual: rapida.GetImpressionPriceValue());

		[Test]
		public void R60C_01_GetPagesPerOneImposition() 
			=> Assert.AreEqual(expected: 4, 
				actual: rapida.GetPagesPerOneImposition());

		[Test]
		public void R60C_02_GetImpositionsPerBook() 
			=> Assert.AreEqual(expected: 1, 
				actual: rapida.GetImpositionsPerBook());

		[Test]
		public void R60C_03_GetPrintingSheetsPerBook() 
			=> Assert.AreEqual(expected: 0.5, 
				actual: rapida.GetPrintingSheetsPerBook());

		[Test]
		public void R60C_09_GetPrintingSheetsPerPrintRun() 
			=> Assert.AreEqual(expected: 5000, 
				actual: rapida.GetPrintingSheetsPerPrintRun());

		[Test]
		public void R60C_04_GetPrintingForms() 
			=> Assert.AreEqual(expected: 4, 
				actual: rapida.GetPrintingForms());

		[Test]
		public void R60C_05_GetCostOfPrintingFoms() 
			=> Assert.AreEqual(expected: 432, 
				actual: rapida.GetCostOfPrintingFoms());

		[Test] //Оттиски
		public void R60C_06_GetImpressions() 
			=> Assert.AreEqual(expected: 20000, 
				actual: rapida.GetImpressions());

		[Test]
		public void R60C_07_GetCostOfImpressions() 
			=> Assert.AreEqual(expected: 740, 
				actual: rapida.GetCostOfImpressions(), delta: 0.01);

		[Test]
		public void R60C_08_GetCostOfPrinting() 
			=> Assert.AreEqual(expected: 1172, 
				actual: rapida.GetCostOfPrinting(), delta: 0.01);

		[Test]
		public void R60C_10_GetPaperConsumptionForTechnicalNeeds() 
			=> Assert.AreEqual(expected: 400, 
				actual: rapida.GetPaperConsumptionForTechnicalNeeds());

		[Test]
		public void R60C_11_GetFittingOnPrintRun() 
			=> Assert.AreEqual(expected: 0, 
				actual: rapida.GetFittingOnPrintRun());

		[Test]
		public void R60C_12_GetTotalPaperConsumptionInPressFormat() 
			=> Assert.AreEqual(expected: 5400, 
				actual: rapida.GetTotalPaperConsumptionInPressFormat());
	}
}
