﻿using NUnit.Framework;
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
				actual: printingPress.FormPriceValue, delta: 0.01);

		[Test]
		public void R60C_00_GetFittingPriceValue() 
			=> Assert.AreEqual(expected: printingPressResult.FittingPriceValue, 
				actual: printingPress.FittingPriceValue, delta: 0.01);

		[Test]
		public void R60C_00_GetTechNeedsPriceValue() 
			=> Assert.AreEqual(expected: printingPressResult.TechNeedsPrice, 
				actual: printingPress.TechNeedsPriceValue, delta: 0.01);

		[Test]
		public void R60C_00_GetImpressionPriceValue() 
			=> Assert.AreEqual(expected: printingPressResult.ImpressionPrice, 
				actual: printingPress.ImpressionPriceValue, delta: 0.01);

		[Test]
		public void R60C_01_GetPagesPerOneImposition() 
			=> Assert.AreEqual(expected: printingPressResult.PagesPerOneImposition, 
				actual: printingPress.PagesPerOneImposition, delta: 0.01);

		[Test]
		public void R60C_02_GetImpositionsPerBook() 
			=> Assert.AreEqual(expected: printingPressResult.ImposiotionsPerBook, 
				actual: printingPress.ImpositionsPerBook, delta: 0.01);

		[Test]
		public void R60C_03_GetPrintingSheetsPerBook() 
			=> Assert.AreEqual(expected: printingPressResult.PrintingSheetsPerBook, 
				actual: printingPress.PrintingSheetsPerBook, delta: 0.01);

		[Test]
		public void R60C_04_GetPrintingSheetsPerPrintRun() 
			=> Assert.AreEqual(expected: printingPressResult.PrintingSheetsPerPrintRun, 
				actual: printingPress.PrintingSheetsPerPrintRun, delta: 0.01);

		[Test]
		public void R60C_05_GetPrintingForms() 
			=> Assert.AreEqual(expected: printingPressResult.PrintingForms, 
				actual: printingPress.PrintingForms, delta: 0.01);

		[Test]
		public void R60C_06_GetCostOfPrintingFoms() 
			=> Assert.AreEqual(expected: printingPressResult.CostOfPrintingFoms, 
				actual: printingPress.CostOfPrintingFoms, delta: 0.01);

		[Test] //Оттиски
		public void R60C_07_GetImpressions() 
			=> Assert.AreEqual(expected: printingPressResult.Impressions, 
				actual: printingPress.Impressions, delta: 0.01);

		[Test]
		public void R60C_08_GetCostOfImpressions() 
			=> Assert.AreEqual(expected: printingPressResult.CostOfImpressions, 
				actual: printingPress.CostOfImpressions, delta: 0.01);

		[Test]
		public void R60C_09_GetCostOfPrinting() 
			=> Assert.AreEqual(expected: printingPressResult.CostOfPrinting, 
				actual: printingPress.CostOfPrinting, delta: 0.01);

		[Test]
		public void R60C_10_GetPaperConsumptionForTechnicalNeeds() 
			=> Assert.AreEqual(expected: printingPressResult.PaperConsumptionForTechnicalNeeds, 
				actual: printingPress.PaperConsumptionForTechnicalNeeds, delta: 0.01);

		[Test]
		public void R60C_11_GetFittingOnPrintRun() 
			=> Assert.AreEqual(expected: printingPressResult.FittingOnPrintRun, 
				actual: printingPress.FittingOnPrintRun, delta: 0.01);

		[Test]
		public void R60C_12_GetTotalPaperConsumptionInPressFormat() 
			=> Assert.AreEqual(expected: printingPressResult.TotalPaperConsumptionInPressFormat, 
				actual: printingPress.TotalPaperConsumptionInPressFormat, delta: 0.01);
	}
}
