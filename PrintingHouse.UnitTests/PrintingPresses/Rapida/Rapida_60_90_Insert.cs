using NUnit.Framework;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Entities.BookComponents;

namespace BookProduction
{
	[TestFixture]
	public class Rapida60_90_Insert
	{
		// Вкладка

		Rapida74_5 rapida;

		//imposition - спуск
		//impression - оттиск

		[SetUp]
		public void Initialize()
		{
			rapida = new Rapida74_5(new TaskToPrint(new BookPart("Insert",
				new IssueFormat(60, 90, 32), new PaperInSheets(PaperType.SelfAdhensivePaper, 80, 3.9758, "Unknown", 45, 64),
				new IssueColors(4, 0), 4), 28000));
		}

		//Проверка правильности получения значений из прайса
		[Test]
		public void R60Ins_00_GetFormPriceValue() 
			=> Assert.AreEqual(expected: 108, 
				actual: rapida.GetFormPriceValue());

		[Test]
		public void R60Ins_00_GetFittingPriceValue() 
			=> Assert.AreEqual(expected: 0, 
				actual: rapida.GetFittingPriceValue());

		[Test]
		public void R60Ins_00_GetTechNeedsPriceValue() 
			=> Assert.AreEqual(expected: 8, 
				actual: rapida.GetTechNeedsPriceValue());

		[Test]
		public void R60Ins_00_GetImpressionPriceValue() 
			=> Assert.AreEqual(expected: 0.050, 
				actual: rapida.GetImpressionPriceValue());

		[Test]
		public void R60Ins_01_GetPagesPerOneImposition() 
			=> Assert.AreEqual(expected: 16, 
				actual: rapida.GetPagesPerOneImposition());

		[Test]
		public void R60Ins_02_GetImpositionsPerBook() 
			=> Assert.AreEqual(expected: 0.25, 
				actual: rapida.GetImpositionsPerBook());

		[Test]
		public void R60Ins_03_GetPrintingSheetsPerBook() 
			=> Assert.AreEqual(expected: 0.125, 
				actual: rapida.GetPrintingSheetsPerBook());

		[Test]
		public void R60Ins_09_GetPrintingSheetsPerPrintRun() 
			=> Assert.AreEqual(expected: 3500, 
				actual: rapida.GetPrintingSheetsPerPrintRun());

		[Test]
		public void R60Ins_04_GetPrintingForms() 
			=> Assert.AreEqual(expected: 4, 
				actual: rapida.GetPrintingForms());

		[Test]
		public void R60Ins_05_GetCostOfPrintingFoms() 
			=> Assert.AreEqual(expected: 432, 
				actual: rapida.GetCostOfPrintingFoms());

		[Test] //Оттиски
		public void R60Ins_06_GetImpressions() 
			=> Assert.AreEqual(expected: 14000, 
				actual: rapida.GetImpressions());

		[Test]
		public void R60Ins_07_GetCostOfImpressions() 
			=> Assert.AreEqual(expected: 700, 
				actual: rapida.GetCostOfImpressions(), delta: 0.01);

		[Test]
		public void R60Ins_08_GetCostOfPrinting() 
			=> Assert.AreEqual(expected: 1132, 
				actual: rapida.GetCostOfPrinting(), delta: 0.01);

		[Test]
		public void R60Ins_10_GetPaperConsumptionForTechnicalNeeds() 
			=> Assert.AreEqual(expected: 280, 
				actual: rapida.GetPaperConsumptionForTechnicalNeeds());

		[Test]
		public void R60Ins_11_GetFittingOnPrintRun() 
			=> Assert.AreEqual(expected: 0, 
				actual: rapida.GetFittingOnPrintRun());

		[Test]
		public void R60Ins_12_GetTotalPaperConsumptionInPressFormat() 
			=> Assert.AreEqual(expected: 3780, 
				actual: rapida.GetTotalPaperConsumptionInPressFormat());
	}
}
