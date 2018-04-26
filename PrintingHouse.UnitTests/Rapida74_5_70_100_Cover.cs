using NUnit.Framework;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Entities.BookComponents;

namespace BookProduction
{
	[TestFixture]
    public class Rapida74_5_70_100_Cover
    {
        // R70C означает Rapida Format 60*90 Cover (обложка)

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
        {
            Assert.AreEqual(108, rapida.GetFormPriceValue());
        }

        [Test]
        public void R70C_00_GetFittingPriceValue()
        {
            Assert.AreEqual(0, rapida.GetFittingPriceValue());
        }

        [Test]
        public void R70C_00_GetTechNeedsPriceValue()
        {
            Assert.AreEqual(8, rapida.GetTechNeedsPriceValue());
        }

        [Test]
        public void R70C_00_GetImpressionPriceValue()
        {
            Assert.AreEqual(0.037, rapida.GetImpressionPriceValue());
        }

        [Test]
        public void R70C_01_GetPagesPerOneImposition()
        {
            Assert.AreEqual(8, rapida.GetPagesPerOneImposition());
        }

        [Test]
        public void R70C_02_GetImpositionsPerBook()
        {
            Assert.AreEqual(0.5, rapida.GetImpositionsPerBook());
        }

        [Test]
        public void R70C_03_GetPrintingSheetsPerBook()
        {
            Assert.AreEqual(0.25, rapida.GetPrintingSheetsPerBook());
        }

        [Test]
        public void R70C_09_GetPrintingSheetsPerPrintRun()
        {
            Assert.AreEqual(7000, rapida.GetPrintingSheetsPerPrintRun());
        }

        [Test]
        public void R70C_04_GetPrintingForms()
        {
            Assert.AreEqual(5, rapida.GetPrintingForms());
        }

        [Test]
        public void R70C_05_GetCostOfPrintingFoms()
        {
            Assert.AreEqual(540, rapida.GetCostOfPrintingFoms());
        }

        [Test] //Оттиски
        public void R70C_06_GetImpressions()
        {
            Assert.AreEqual(35000, rapida.GetImpressions());
        }

        [Test]
        public void R70C_07_GetCostOfImpressions()
        {
            Assert.AreEqual(1295, rapida.GetCostOfImpressions(), delta: 0.01 );
        }

        [Test]
        public void R70C_08_GetCostOfPrinting()
        {
            Assert.AreEqual(1835, rapida.GetCostOfPrinting(), delta: 0.01);
        }

        [Test]
        public void R70C_10_GetPaperConsumptionForTechnicalNeeds()
        {
            Assert.AreEqual(560, rapida.GetPaperConsumptionForTechnicalNeeds());
        }

        [Test]
        public void R70C_11_GetFittingOnPrintRun()
        {
            Assert.AreEqual(0, rapida.GetFittingOnPrintRun());
        }

        [Test]
        public void R70C_12_GetTotalPaperConsumptionInPressFormat()
        {
            Assert.AreEqual(7560, rapida.GetTotalPaperConsumptionInPressFormat());
        }
    }
}
