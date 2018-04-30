using NUnit.Framework;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Entities.BookComponents;

namespace BookProduction
{
	[TestFixture]
	[Category("Rapida_70_100_Cover")]
	public class Rapida_70_100_Cover
	{
		Rapida74_5 rapida;

		//imposition - спуск
		//impression - оттиск

		[SetUp]
		public void Initialize()
		{
			rapida = new Rapida74_5(new TaskToPrint(new BookPart("Cover",
				new IssueFormat(70, 100, 16), new PaperInSheets(PaperType.FoldingBoxboard, 200, 3.172, "Умка", 70, 100),
				new IssueColors(4, 1), 4), 28000));
		}

		//Проверка правильности получения значений из прайса
		[Test]
		public void R70C_00_GetFormPriceValue() 
			=> Assert.AreEqual(expected: 108, 
				actual: rapida.GetFormPriceValue());

		[Test]
		public void R70C_00_GetFittingPriceValue() 
			=> Assert.AreEqual(expected: 0, 
				actual: rapida.GetFittingPriceValue());

		[Test]
		public void R70C_00_GetTechNeedsPriceValue() 
			=> Assert.AreEqual(expected: 8, 
				actual: rapida.GetTechNeedsPriceValue());

		[Test]
		public void R70C_00_GetImpressionPriceValue() 
			=> Assert.AreEqual(expected: 0.037, 
				actual: rapida.GetImpressionPriceValue());

		[Test]
		public void R70C_01_GetPagesPerOneImposition() 
			=> Assert.AreEqual(expected: 8, 
				actual: rapida.GetPagesPerOneImposition());

		[Test]
		public void R70C_02_GetImpositionsPerBook() 
			=> Assert.AreEqual(expected: 0.5, 
				actual: rapida.GetImpositionsPerBook());

		[Test]
		public void R70C_03_GetPrintingSheetsPerBook() 
			=> Assert.AreEqual(expected: 0.25, 
				actual: rapida.GetPrintingSheetsPerBook());

		[Test]
		public void R70C_09_GetPrintingSheetsPerPrintRun() 
			=> Assert.AreEqual(expected: 7000, 
				actual: rapida.GetPrintingSheetsPerPrintRun());

		[Test]
		public void R70C_04_GetPrintingForms() 
			=> Assert.AreEqual(expected: 5, 
				actual: rapida.GetPrintingForms());

		[Test]
		public void R70C_05_GetCostOfPrintingFoms() 
			=> Assert.AreEqual(expected: 540, 
				actual: rapida.GetCostOfPrintingFoms());

		[Test] //Оттиски
		public void R70C_06_GetImpressions() 
			=> Assert.AreEqual(expected: 35000, 
				actual: rapida.GetImpressions());

		[Test]
		public void R70C_07_GetCostOfImpressions() 
			=> Assert.AreEqual(expected: 1295, 
				actual: rapida.GetCostOfImpressions(), delta: 0.01);

		[Test]
		public void R70C_08_GetCostOfPrinting() 
			=> Assert.AreEqual(expected: 1835, 
				actual: rapida.GetCostOfPrinting(), delta: 0.01);

		[Test]
		public void R70C_10_GetPaperConsumptionForTechnicalNeeds() 
			=> Assert.AreEqual(expected: 560, 
				actual: rapida.GetPaperConsumptionForTechnicalNeeds());

		[Test]
		public void R70C_11_GetFittingOnPrintRun() 
			=> Assert.AreEqual(expected: 0, 
				actual: rapida.GetFittingOnPrintRun());

		[Test]
		public void R70C_12_GetTotalPaperConsumptionInPressFormat() 
			=> Assert.AreEqual(expected: 7560, 
				actual: rapida.GetTotalPaperConsumptionInPressFormat());
	}
}
