using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BookProduction;
using BookProduction.BookComponents;
using BookProduction.Assembly;
using BookProduction.IssueParams;
using BookProduction.Paper;
using BookProduction.PriceLists;
using BookProduction.PrintingPresses;
using BookProduction.Tasks;
using BookProduction.TypographyManagement;

namespace BookProduction
{

    [TestFixture]
    public class ZirkonForta660_60_90_8_InternalBlock
    {
        // Z60908IB означает Rapida Format 60*90 Internal block 

        ZirkonForta660 zirkon;

        //imposition - спуск
        //impression - оттиск

        [SetUp]
        public void Initialize()
        {
            //ДН108-д11 - издательский код
            zirkon = new ZirkonForta660(new TaskToPrint(new BookPart("ДН108-д11",
                new IssueFormat(60, 90, 8), new PaperInKg(PaperType.Offset, 60, 25.1835, "Коростышев", 60),
                new IssueColors(1, 1), 128), 10000));
        }

        //Проверка правильности получения значений из прайса
        [Test]
        public void Z60908IB_00_GetFormPriceValue()
        {
            Assert.AreEqual(90, zirkon.GetFormPriceValue());
        }

        [Test]
        public void Z60908IB_00_GetFittingPriceValue()
        {
            Assert.AreEqual(400, zirkon.GetFittingPriceValue());
        }

        [Test]
        public void Z60908IB_00_GetTechNeedsPriceValue()
        {
            Assert.AreEqual(4.7, zirkon.GetTechNeedsPriceValue());
        }

        [Test]
        public void Z60908IB_00_GetImpressionPriceValue()
        {
            Assert.AreEqual(0.0367, zirkon.GetImpressionPriceValue());
        }

        [Test]
        public void Z60908IB_01_GetPagesPerOneImposition()
        {
            Assert.AreEqual(4, zirkon.GetPagesPerOneImposition());
        }

        [Test]
        public void Z60908IB_02_GetImpositionsPerBook()
        {
            Assert.AreEqual(32, zirkon.GetImpositionsPerBook());
        }

        [Test]
        public void Z60908IB_03_GetPrintingSheetsPerBook()
        {
            Assert.AreEqual(16, zirkon.GetPrintingSheetsPerBook());
        }

        [Test]
        public void Z60908IB_09_GetPrintingSheetsPerPrintRun()
        {
            Assert.AreEqual(160000, zirkon.GetPrintingSheetsPerPrintRun());
        }

        [Test]
        public void Z60908IB_04_GetPrintingForms()
        {
            Assert.AreEqual(32, zirkon.GetPrintingForms());
        }

        [Test]
        public void Z60908IB_05_GetCostOfPrintingFoms()
        {
            Assert.AreEqual(2880, zirkon.GetCostOfPrintingFoms());
        }

        [Test] //Оттиски
        public void Z60908IB_06_GetImpressions()
        {
            Assert.AreEqual(160000, zirkon.GetImpressions());
        }

        [Test]
        public void Z60908IB_07_GetCostOfImpressions()
        {
            Assert.AreEqual(5872, zirkon.GetCostOfImpressions(), delta: 0.01);
        }

        [Test]
        public void Z60908IB_08_GetCostOfPrinting()
        {
            Assert.AreEqual(8752, zirkon.GetCostOfPrinting(), delta: 0.01);
        }

        [Test]
        public void Z60908IB_10_GetParerConsumptionForTechnicalNeeds()
        {
            Assert.AreEqual(7520, zirkon.GetPaperConsumptionForTechnicalNeeds());
        }

        [Test]
        public void Z60908IB_11_GetFittingOnPrintRun()
        {
            Assert.AreEqual(12800, zirkon.GetFittingOnPrintRun());
        }

        [Test]
        public void Z60908IB_12_GetTotalPaperConsumptionInPressFormat()
        {
            Assert.AreEqual(180320, zirkon.GetTotalPaperConsumptionInPressFormat());
        }
    }
}


