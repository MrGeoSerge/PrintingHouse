using NUnit.Framework;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.Domain.Entities.Paper;

namespace BookProduction
{

	[TestFixture]
	public class Rapida_70_100_InternalBlock
	{
		// R70IB означает Rapida Format 70*100 Internal block 

		Rapida74_5 rapida;

		//imposition - спуск
		//impression - оттиск

		[SetUp]
		public void Initialize()
		{
			//ОСК002 - издательский код
			rapida = new Rapida74_5(new TaskToPrint(new BookPart("InternalBlock",
				new IssueFormat(70, 100, 16), new PaperInSheets(PaperType.Offset, 60, 1.2850997544, "Люмисет", 70, 100),
				new IssueColors(2, 2), 48), 28000));
		}

		//Проверка правильности получения значений из прайса
		[Test]
		public void R70IB_00_GetFormPriceValue() 
			=> Assert.AreEqual(expected: 108, 
				actual: rapida.GetFormPriceValue());

		[Test]
		public void R70IB_00_GetFittingPriceValue() 
			=> Assert.AreEqual(expected: 0, 
				actual: rapida.GetFittingPriceValue());

		[Test]
		public void R70IB_00_GetTechNeedsPriceValue() 
			=> Assert.AreEqual(expected: 8, 
				actual: rapida.GetTechNeedsPriceValue());

		[Test]
		public void R70IB_00_GetImpressionPriceValue() 
			=> Assert.AreEqual(expected: 0.037, 
				actual: rapida.GetImpressionPriceValue());

		[Test]
		public void R70IB_01_GetPagesPerOneImposition() 
			=> Assert.AreEqual(expected: 8, 
				actual: rapida.GetPagesPerOneImposition());

		[Test]
		public void R70IB_02_GetImpositionsPerBook() 
			=> Assert.AreEqual(expected: 6, 
				actual: rapida.GetImpositionsPerBook());

		[Test]
		public void R70IB_03_GetPrintingSheetsPerBook() 
			=> Assert.AreEqual(expected: 3, 
				actual: rapida.GetPrintingSheetsPerBook());

		[Test]
		public void R70IB_09_GetPrintingSheetsPerPrintRun() 
			=> Assert.AreEqual(expected: 84000, 
				actual: rapida.GetPrintingSheetsPerPrintRun());

		[Test]
		public void R70IB_04_GetPrintingForms() 
			=> Assert.AreEqual(expected: 12, 
				actual: rapida.GetPrintingForms());

		[Test]
		public void R70IB_05_GetCostOfPrintingFoms() 
			=> Assert.AreEqual(expected: 1296, 
				actual: rapida.GetCostOfPrintingFoms());

		[Test] //Оттиски
		public void R70IB_06_GetImpressions() 
			=> Assert.AreEqual(expected: 336000, 
				actual: rapida.GetImpressions());

		[Test]
		public void R70IB_07_GetCostOfImpressions() 
			=> Assert.AreEqual(expected: 12432, 
				actual: rapida.GetCostOfImpressions(), delta: 0.01);

		[Test]
		public void R70IB_08_GetCostOfPrinting() 
			=> Assert.AreEqual(expected: 13728, 
				actual: rapida.GetCostOfPrinting(), delta: 0.01);

		[Test]
		public void R70IB_10_GetParerConsumptionForTechnicalNeeds() 
			=> Assert.AreEqual(expected: 6720, 
				actual: rapida.GetPaperConsumptionForTechnicalNeeds());

		[Test]
		public void R70IB_11_GetFittingOnPrintRun() 
			=> Assert.AreEqual(expected: 0, 
				actual: rapida.GetFittingOnPrintRun());

		[Test]
		public void R70IB_12_GetTotalPaperConsumptionInPressFormat() 
			=> Assert.AreEqual(expected: 90720, 
				actual: rapida.GetTotalPaperConsumptionInPressFormat());
	}
}


