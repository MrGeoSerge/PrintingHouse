using NUnit.Framework;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;

namespace BookProduction
{
	[TestFixture]
    public class Rapida74_5_60_90_IB
    {
        // R60C означает Rapida Format 60*90 Cover (обложка)

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
        {
            Assert.AreEqual(108, rapida.GetFormPriceValue());
        }

        [Test]
        public void R60C_00_GetFittingPriceValue()
        {
            Assert.AreEqual(0, rapida.GetFittingPriceValue());
        }

        [Test]
        public void R60C_00_GetTechNeedsPriceValue()
        {
            Assert.AreEqual(8, rapida.GetTechNeedsPriceValue());
        }

        [Test]
        public void R60C_00_GetImpressionPriceValue()
        {
            Assert.AreEqual(0.037, rapida.GetImpressionPriceValue());
        }

        [Test]
        public void R60C_01_GetPagesPerOneImposition()
        {
            Assert.AreEqual(4, rapida.GetPagesPerOneImposition());
        }

        [Test]
        public void R60C_02_GetImpositionsPerBook()
        {
            Assert.AreEqual(1, rapida.GetImpositionsPerBook());
        }

        [Test]
        public void R60C_03_GetPrintingSheetsPerBook()
        {
            Assert.AreEqual(0.5, rapida.GetPrintingSheetsPerBook());
        }

        [Test]
        public void R60C_09_GetPrintingSheetsPerPrintRun()
        {
            Assert.AreEqual(5000, rapida.GetPrintingSheetsPerPrintRun());
        }

        [Test]
        public void R60C_04_GetPrintingForms()
        {
            Assert.AreEqual(4, rapida.GetPrintingForms());
        }

        [Test]
        public void R60C_05_GetCostOfPrintingFoms()
        {
            Assert.AreEqual(432, rapida.GetCostOfPrintingFoms());
        }

        [Test] //Оттиски
        public void R60C_06_GetImpressions()
        {
            Assert.AreEqual(20000, rapida.GetImpressions());
        }

        [Test]
        public void R60C_07_GetCostOfImpressions()
        {
            Assert.AreEqual(740, rapida.GetCostOfImpressions(), delta: 0.01 );
        }

        [Test]
        public void R60C_08_GetCostOfPrinting()
        {
            Assert.AreEqual(1172, rapida.GetCostOfPrinting(), delta: 0.01);
        }

        [Test]
        public void R60C_10_GetPaperConsumptionForTechnicalNeeds()
        {
            Assert.AreEqual(400, rapida.GetPaperConsumptionForTechnicalNeeds());
        }

        [Test]
        public void R60C_11_GetFittingOnPrintRun()
        {
            Assert.AreEqual(0, rapida.GetFittingOnPrintRun());
        }

        [Test]
        public void R60C_12_GetTotalPaperConsumptionInPressFormat()
        {
            Assert.AreEqual(5400, rapida.GetTotalPaperConsumptionInPressFormat());
        }
    }
}
