using NUnit.Framework;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;

namespace BookProduction
{

	[TestFixture]
    public class ZirkonForta660_84_108_Cover
    {
        // Z80IС означает Rapida Format 84*108 Cover - типа обложка журнала, то есть его первые 4 стр

        ZirkonForta660 zirkon;

        //imposition - спуск
        //impression - оттиск

        [SetUp]
        public void Initialize()
        {
            //обложка журнала АМЖ063 - первые страницы журнала, которые 2+1
            zirkon = new ZirkonForta660(new TaskToPrint(new BookPart("InternalBlock",
                new IssueFormat(84, 108, 16), new PaperInKg(PaperType.Newsprint, 43, 13.42708, "Змиев", 54),
                new IssueColors(2, 1), 8), 1815));
        }

        //Проверка правильности получения значений из прайса
        [Test]
        public void Z84С_00_GetFormPriceValue()
        {
            Assert.AreEqual(90, zirkon.GetFormPriceValue());
        }

        [Test]
        public void Z84С_00_GetFittingPriceValue()
        {
            Assert.AreEqual(400, zirkon.GetFittingPriceValue());
        }

        [Test]
        public void Z84С_00_GetTechNeedsPriceValue()
        {
            Assert.AreEqual(5.9, zirkon.GetTechNeedsPriceValue());
        }

        [Test]
        public void Z84С_00_GetImpressionPriceValue()
        {
            Assert.AreEqual(0.0367, zirkon.GetImpressionPriceValue());//????
        }

        [Test]
        public void Z84С_01_GetPagesPerOneImposition()
        {
            Assert.AreEqual(4, zirkon.GetPagesPerOneImposition());
        }

        [Test]
        public void Z84С_02_GetImpositionsPerBook()
        {
            Assert.AreEqual(2, zirkon.GetImpositionsPerBook());
        }

        [Test]
        public void Z84С_03_GetPrintingSheetsPerBook()
        {
            Assert.AreEqual(1, zirkon.GetPrintingSheetsPerBook());
        }

        [Test]
        public void Z84С_09_GetPrintingSheetsPerPrintRun()
        {
            Assert.AreEqual(1815, zirkon.GetPrintingSheetsPerPrintRun());
        }

        [Test]
        public void Z84С_04_GetPrintingForms()
        {
            Assert.AreEqual(3, zirkon.GetPrintingForms());
        }

        [Test]
        public void Z84С_05_GetCostOfPrintingFoms()
        {
            Assert.AreEqual(270, zirkon.GetCostOfPrintingFoms());
        }

        [Test] //Оттиски
        public void Z84С_06_GetImpressions()
        {
            Assert.AreEqual(1815, zirkon.GetImpressions());
        }

        [Test]
        public void Z84С_07_GetCostOfImpressions()
        {
            Assert.AreEqual(66.6105, zirkon.GetCostOfImpressions(), delta: 0.01);
        }

        [Test]
        public void Z84С_08_GetCostOfPrinting()
        {
            Assert.AreEqual(336.6105, zirkon.GetCostOfPrinting(), delta: 0.01);
        }

        [Test]
        public void Z84С_10_GetParerConsumptionForTechnicalNeeds()
        {
            Assert.AreEqual(107, zirkon.GetPaperConsumptionForTechnicalNeeds());
        }

        [Test]
        public void Z84С_11_GetFittingOnPrintRun()
        {
            Assert.AreEqual(1200, zirkon.GetFittingOnPrintRun());
        }

        [Test]
        public void Z84С_12_GetTotalPaperConsumptionInPressFormat()
        {
            Assert.AreEqual(3122, zirkon.GetTotalPaperConsumptionInPressFormat());
        }
    }
}


