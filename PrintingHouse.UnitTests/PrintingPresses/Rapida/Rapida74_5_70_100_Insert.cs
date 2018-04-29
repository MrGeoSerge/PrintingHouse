using NUnit.Framework;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Entities.BookComponents;

namespace BookProduction
{
	[TestFixture]
    public class Rapida74_5_70_100_Insert
    {
        // R60Ins означает Rapida Format 60*90 Cover (обложка)

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
        {
            Assert.AreEqual(108, rapida.GetFormPriceValue());
        }

        [Test]
        public void R60Ins_00_GetFittingPriceValue()
        {
            Assert.AreEqual(0, rapida.GetFittingPriceValue());
        }

        [Test]
        public void R60Ins_00_GetTechNeedsPriceValue()
        {
            Assert.AreEqual(8, rapida.GetTechNeedsPriceValue());
        }

        [Test]
        public void R60Ins_00_GetImpressionPriceValue()
        {
            Assert.AreEqual(0.050, rapida.GetImpressionPriceValue());
        }

        [Test]
        public void R60Ins_01_GetPagesPerOneImposition()
        {
            Assert.AreEqual(16, rapida.GetPagesPerOneImposition());
        }

        [Test]
        public void R60Ins_02_GetImpositionsPerBook()
        {
            Assert.AreEqual(0.25, rapida.GetImpositionsPerBook());
        }

        [Test]
        public void R60Ins_03_GetPrintingSheetsPerBook()
        {
            Assert.AreEqual(0.125, rapida.GetPrintingSheetsPerBook());
        }

        [Test]
        public void R60Ins_09_GetPrintingSheetsPerPrintRun()
        {
            Assert.AreEqual(3500, rapida.GetPrintingSheetsPerPrintRun());
        }

        [Test]
        public void R60Ins_04_GetPrintingForms()
        {
            Assert.AreEqual(4, rapida.GetPrintingForms());
        }

        [Test]
        public void R60Ins_05_GetCostOfPrintingFoms()
        {
            Assert.AreEqual(432, rapida.GetCostOfPrintingFoms());
        }

        [Test] //Оттиски
        public void R60Ins_06_GetImpressions()
        {
            Assert.AreEqual(14000, rapida.GetImpressions());
        }

        [Test]
        public void R60Ins_07_GetCostOfImpressions()
        {
            Assert.AreEqual(700, rapida.GetCostOfImpressions(), delta: 0.01 );
        }

        [Test]
        public void R60Ins_08_GetCostOfPrinting()
        {
            Assert.AreEqual(1132, rapida.GetCostOfPrinting(), delta: 0.01);
        }

        [Test]
        public void R60Ins_10_GetPaperConsumptionForTechnicalNeeds()
        {
            Assert.AreEqual(280, rapida.GetPaperConsumptionForTechnicalNeeds());
        }

        [Test]
        public void R60Ins_11_GetFittingOnPrintRun()
        {
            Assert.AreEqual(0, rapida.GetFittingOnPrintRun());
        }

        [Test]
        public void R60Ins_12_GetTotalPaperConsumptionInPressFormat()
        {
            Assert.AreEqual(3780, rapida.GetTotalPaperConsumptionInPressFormat());
        }
    }
}
