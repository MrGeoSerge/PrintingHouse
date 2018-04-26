using NUnit.Framework;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;

namespace BookProduction
{

	[TestFixture]
    public class ZirkonForta660_70_90_InternalBlock
    {
        // Z70IB означает Rapida Format 70*100 Internal block 

        ZirkonForta660 zirkon;

        //imposition - спуск
        //impression - оттиск

        [SetUp]
        public void Initialize()
        {
            //ШКК1-д9 - издательский код
            zirkon = new ZirkonForta660(new TaskToPrint(new BookPart("InternalBlock",
                new IssueFormat(70, 90, 16), new PaperInKg(PaperType.Offset, 60, 28.0675, "Люмисет", 70),
                new IssueColors(1, 1), 176), 2000));
        }

        //Проверка правильности получения значений из прайса
        [Test]
        public void Z70IB_00_GetFormPriceValue()
        {
            Assert.AreEqual(90, zirkon.GetFormPriceValue());
        }

        [Test]
        public void Z70IB_00_GetFittingPriceValue()
        {
            Assert.AreEqual(400, zirkon.GetFittingPriceValue());
        }

        [Test]
        public void Z70IB_00_GetTechNeedsPriceValue()
        {
            Assert.AreEqual(4.7, zirkon.GetTechNeedsPriceValue());
        }

        [Test]
        public void Z70IB_00_GetImpressionPriceValue()
        {
            Assert.AreEqual(0.0367, zirkon.GetImpressionPriceValue());
        }

        [Test]
        public void Z70IB_01_GetPagesPerOneImposition()
        {
            Assert.AreEqual(8, zirkon.GetPagesPerOneImposition());
        }

        [Test]
        public void Z70IB_02_GetImpositionsPerBook()
        {
            Assert.AreEqual(22, zirkon.GetImpositionsPerBook());
        }

        [Test]
        public void Z70IB_03_GetPrintingSheetsPerBook()
        {
            Assert.AreEqual(11, zirkon.GetPrintingSheetsPerBook());
        }

        [Test]
        public void Z70IB_09_GetPrintingSheetsPerPrintRun()
        {
            Assert.AreEqual(22000, zirkon.GetPrintingSheetsPerPrintRun());
        }

        [Test]
        public void Z70IB_04_GetPrintingForms()
        {
            Assert.AreEqual(22, zirkon.GetPrintingForms());
        }

        [Test]
        public void Z70IB_05_GetCostOfPrintingFoms()
        {
            Assert.AreEqual(1980, zirkon.GetCostOfPrintingFoms());
        }

        [Test] //Оттиски
        public void Z70IB_06_GetImpressions()
        {
            Assert.AreEqual(22000, zirkon.GetImpressions());
        }

        [Test]
        public void Z70IB_07_GetCostOfImpressions()
        {
            Assert.AreEqual(807.4, zirkon.GetCostOfImpressions(), delta: 0.01);
        }

        [Test]
        public void Z70IB_08_GetCostOfPrinting()
        {
            Assert.AreEqual(2787.4, zirkon.GetCostOfPrinting(), delta: 0.01);
        }

        [Test]
        public void Z70IB_10_GetParerConsumptionForTechnicalNeeds()
        {
            Assert.AreEqual(1034, zirkon.GetPaperConsumptionForTechnicalNeeds());
        }

        [Test]
        public void Z70IB_11_GetFittingOnPrintRun()
        {
            Assert.AreEqual(8800, zirkon.GetFittingOnPrintRun());
        }

        [Test]
        public void Z70IB_12_GetTotalPaperConsumptionInPressFormat()
        {
            Assert.AreEqual(31834, zirkon.GetTotalPaperConsumptionInPressFormat());
        }
    }
}


