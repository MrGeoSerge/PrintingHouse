using NUnit.Framework;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;

namespace BookProduction
{

	[TestFixture]
    public class CorosetPlamag_84_108_InternalBlock
    {
        // Z80IС означает Rapida Format 84*108 Cover - типа обложка журнала, то есть его первые 4 стр

        CorosetPlamag coroset;

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
        }

        //Проверка правильности получения значений из прайса
        [Test]
        public void C84IB_00_GetFormPriceValue()
        {
            Assert.AreEqual(126, coroset.GetFormPriceValue());
        }

        [Test]
        public void C84IB_00_GetFittingPriceValue()
        {
            Assert.AreEqual(400, coroset.GetFittingPriceValue());
        }

        [Test]
        public void C84IB_00_GetTechNeedsPriceValue()
        {
            Assert.AreEqual(4.7, coroset.GetTechNeedsPriceValue());
        }

        [Test]
        public void C84IB_00_GetImpressionPriceValue()
        {
            Assert.AreEqual(0.0735, coroset.GetImpressionPriceValue());//????
        }

        [Test]
        public void C84IB_01_GetPagesPerOneImposition()
        {
            Assert.AreEqual(8, coroset.GetPagesPerOneImposition());
        }

        [Test]
        public void C84IB_02_GetImpositionsPerBook()
        {
            Assert.AreEqual(19, coroset.GetImpositionsPerBook());
        }

        [Test]
        public void C84IB_03_GetPrintingSheetsPerBook()
        {
            Assert.AreEqual(9.5, coroset.GetPrintingSheetsPerBook());
        }

        [Test]
        public void C84IB_09_GetPrintingSheetsPerPrintRun()
        {
            Assert.AreEqual(9500, coroset.GetPrintingSheetsPerPrintRun());
        }

        [Test]
        public void C84IB_04_GetPrintingForms()
        {
            Assert.AreEqual(20, coroset.GetPrintingForms());
        }

        [Test]
        public void C84IB_05_GetCostOfPrintingFoms()
        {
            Assert.AreEqual(2520, coroset.GetCostOfPrintingFoms());
        }

        [Test] //Оттиски
        public void C84IB_06_GetImpressions()
        {
            Assert.AreEqual(9500, coroset.GetImpressions());
        }

        [Test]
        public void C84IB_07_GetCostOfImpressions()
        {
            Assert.AreEqual(698.25, coroset.GetCostOfImpressions(), delta: 0.01);
        }

        [Test]
        public void C84IB_08_GetCostOfPrinting()
        {
            Assert.AreEqual(3218.25, coroset.GetCostOfPrinting(), delta: 0.01);
        }

        [Test]
        public void C84IB_10_GetParerConsumptionForTechnicalNeeds()
        {
            Assert.AreEqual(447, coroset.GetPaperConsumptionForTechnicalNeeds());
        }

        [Test]
        public void C84IB_11_GetFittingOnPrintRun()
        {
            Assert.AreEqual(8000, coroset.GetFittingOnPrintRun());
        }

        [Test]
        public void C84IB_12_GetTotalPaperConsumptionInPressFormat()
        {
            Assert.AreEqual(17947, coroset.GetTotalPaperConsumptionInPressFormat());
        }
    }
}


