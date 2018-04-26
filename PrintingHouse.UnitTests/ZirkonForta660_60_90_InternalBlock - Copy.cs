using NUnit.Framework;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.PrintingPresses;
using PrintingHouse.Domain.Specifications;

namespace BookProduction
{

	[TestFixture]
    public class ZirkonForta660_60_90_InternalBlock
    {
        // Z60IB означает Rapida Format 60*90 Internal block 

        ZirkonForta660 zirkon;
        PressReport pressReport;
        //imposition - спуск
        //impression - оттиск

        [SetUp]
        public void Initialize()
        {
            //ДТБ015-д1 - издательский код
            zirkon = new ZirkonForta660(new TaskToPrint(new BookPart("InternalBlock",
                new IssueFormat(60, 90, 16), new PaperInKg(PaperType.Offset, 60, 23.25, "Котлас", 60),
                new IssueColors(1, 1), 192), 1000));

            pressReport = new PressReport(zirkon);
        }

        //Проверка правильности получения значений из прайса
        [Test]
        public void Z60IB_00_GetFormPriceValue()
        {
            Assert.AreEqual(90, zirkon.GetFormPriceValue());
        }

        [Test]
        public void Z60IB_00_GetFittingPriceValue()
        {
            Assert.AreEqual(400, zirkon.GetFittingPriceValue());
        }

        [Test]
        public void Z60IB_00_GetTechNeedsPriceValue()
        {
            Assert.AreEqual(4.7, zirkon.GetTechNeedsPriceValue());
        }

        [Test]
        public void Z60IB_00_GetImpressionPriceValue()
        {
            Assert.AreEqual(0.0367, zirkon.GetImpressionPriceValue());
        }

        [Test]
        public void Z60IB_01_GetPagesPerOneImposition()
        {
            Assert.AreEqual(8, zirkon.GetPagesPerOneImposition());
        }

        [Test]
        public void Z60IB_02_GetImpositionsPerBook()
        {
            Assert.AreEqual(24, zirkon.GetImpositionsPerBook());
        }

        [Test]
        public void Z60IB_03_GetPrintingSheetsPerBook()
        {
            Assert.AreEqual(12, zirkon.GetPrintingSheetsPerBook());
        }

        [Test]
        public void Z60IB_09_GetPrintingSheetsPerPrintRun()
        {
            Assert.AreEqual(12000, zirkon.GetPrintingSheetsPerPrintRun());
        }

        [Test]
        public void Z60IB_04_GetPrintingForms()
        {
            Assert.AreEqual(24, zirkon.GetPrintingForms());
        }

        [Test]
        public void Z60IB_05_GetCostOfPrintingFoms()
        {
            Assert.AreEqual(2160, zirkon.GetCostOfPrintingFoms());
        }

        [Test] //Оттиски
        public void Z60IB_06_GetImpressions()
        {
            Assert.AreEqual(12000, zirkon.GetImpressions());
        }

        [Test]
        public void Z60IB_07_GetCostOfImpressions()
        {
            Assert.AreEqual(440.4, zirkon.GetCostOfImpressions(), delta: 0.01);
        }

        [Test]
        public void Z60IB_08_GetCostOfPrinting()
        {
            Assert.AreEqual(2600.4, zirkon.GetCostOfPrinting(), delta: 0.01);
        }

        [Test]
        public void Z60IB_10_GetParerConsumptionForTechnicalNeeds()
        {
            Assert.AreEqual(564, zirkon.GetPaperConsumptionForTechnicalNeeds());
        }

        [Test]
        public void Z60IB_11_GetFittingOnPrintRun()
        {
            Assert.AreEqual(9600, zirkon.GetFittingOnPrintRun());
        }

        [Test]
        public void Z60IB_12_GetTotalPaperConsumptionInPressFormat()
        {
            Assert.AreEqual(22164, zirkon.GetTotalPaperConsumptionInPressFormat());
        }


        //Проверка класса PressReport
        [Test]
        public void Z60IB_13_GetCostOfPolygraphy()
        {
            Assert.AreEqual(2600.4, pressReport.GetCostOfPolygraphy());
        }

        public void Z60IB_14_GetPaperExpenditure()
        {
            Assert.AreEqual(360.65, pressReport.GetPaperExpenditure());
        }

        [Test]
        public void Z60IB_15_GetSquareOfSheetInMeters2()
        {
            Assert.AreEqual(0.2712, pressReport.GetSquareOfSheetInMeters2(), delta: 0.0001);
        }

        [Test]
        public void Z60IB_16_GetPaperInSquareMeters()
        {
            Assert.AreEqual(6010.8768, pressReport.GetPaperInSquareMeters(), delta: 0.0001);
        }

        [Test]
        public void Z60IB_17_GetPaperConsumptionInKg()
        {
            Assert.AreEqual(360.65, pressReport.GetPaperConsumptionInKg());
        }

        [Test]
        public void Z60IB_18_GetPaperCost()
        {
            Assert.AreEqual(8385.11, pressReport.GetPaperCost());
        }

        [Test]
        public void Z60IB_19_GetTotalCost()
        {
            Assert.AreEqual(10985.51, pressReport.GetTotalCost());
        }

    }
}


