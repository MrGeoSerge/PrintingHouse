using NUnit.Framework;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;

namespace BookProduction
{
	[TestFixture]
	[Category("Rapida_70_100_CoverMagazine")]
	public class Rapida_70_100_CoverMagazine
	{
		Rapida74_5 rapida;

		//imposition - спуск
		//impression - оттиск

		[SetUp]
		public void Initialize()
		{
			//суперобложкажурнала АМЖ063
			rapida = new Rapida74_5(new TaskToPrint(new BookPart("Cover",
				new IssueFormat(70, 100, 4), new PaperInSheets(PaperType.CoatedPaper, 80, 1.31016, "Меловка пл.80 64х90 мат ", 64, 90),
				new IssueColors(4, 4), 2), 1865));
		}

		//Проверка правильности получения значений из прайса
		[Test]
		public void R70C_00_GetFormPriceValue() 
			=> Assert.AreEqual(expected: 108, 
				actual: rapida.GetFormPriceValue());

		[Test]
		public void R70C_00_GetFittingPriceValue() 
			=> Assert.AreEqual(expected: 350, 
				actual: rapida.GetFittingPriceValue());

		[Test]
		public void R70C_00_GetTechNeedsPriceValue() 
			=> Assert.AreEqual(expected: 0, 
				actual: rapida.GetTechNeedsPriceValue());

		[Test]
		public void R70C_00_GetImpressionPriceValue() 
			=> Assert.AreEqual(expected: 0.132, 
				actual: rapida.GetImpressionPriceValue());

		[Test]
		public void R70C_01_GetPagesPerOneImposition() 
			=> Assert.AreEqual(expected: 2, 
				actual: rapida.GetPagesPerOneImposition());

		[Test]
		public void R70C_02_GetImpositionsPerBook() 
			=> Assert.AreEqual(expected: 1, 
				actual: rapida.GetImpositionsPerBook());

		[Test]
		public void R70C_03_GetPrintingSheetsPerBook() 
			=> Assert.AreEqual(expected: 0.5, 
				actual: rapida.GetPrintingSheetsPerBook());

		[Test]
		public void R70C_09_GetPrintingSheetsPerPrintRun() 
			=> Assert.AreEqual(expected: 933, 
				actual: rapida.GetPrintingSheetsPerPrintRun());

		[Test]
		public void R70C_04_GetPrintingForms() 
			=> Assert.AreEqual(expected: 8, 
				actual: rapida.GetPrintingForms());

		[Test]
		public void R70C_05_GetCostOfPrintingFoms() 
			=> Assert.AreEqual(expected: 864, 
				actual: rapida.GetCostOfPrintingFoms());

		[Test] //Оттиски
		public void R70C_06_GetImpressions() =>
			Assert.AreEqual(expected: 7464, 
				actual: rapida.GetImpressions());

		[Test]
		public void R70C_07_GetCostOfImpressions() 
			=> Assert.AreEqual(expected: 985.248, 
				actual: rapida.GetCostOfImpressions(), delta: 0.01);

		[Test]
		public void R70C_08_GetCostOfPrinting() 
			=> Assert.AreEqual(expected: 1849.248, 
				actual: rapida.GetCostOfPrinting(), delta: 0.01);

		[Test]
		public void R70C_10_GetPaperConsumptionForTechnicalNeeds() 
			=> Assert.AreEqual(expected: 0, 
				actual: rapida.GetPaperConsumptionForTechnicalNeeds());

		[Test]
		public void R70C_11_GetFittingOnPrintRun() 
			=> Assert.AreEqual(expected: 350, 
				actual: rapida.GetFittingOnPrintRun());

		[Test]
		public void R70C_12_GetTotalPaperConsumptionInPressFormat() 
			=> Assert.AreEqual(expected: 1283, 
				actual: rapida.GetTotalPaperConsumptionInPressFormat());
	}
}
