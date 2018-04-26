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
    public class ZirkonForta660_84_108_IB_Magazine
    {
        // Z80IС означает Rapida Format 84*108 Cover - типа обложка журнала, то есть его первые 4 стр

        ZirkonForta660 zirkon;

        //imposition - спуск
        //impression - оттиск

        [SetUp]
        public void Initialize()
        {
            //обложка, на самом деле, внутренний блок журнала АМЖ063 - первые страницы журнала, которые 2+1
            zirkon = new ZirkonForta660(new TaskToPrint(new BookPart("InternalBlock-Cover",
                new IssueFormat(84, 108, 16), new PaperInKg(PaperType.Newsprint, 43, 13.42708, "Змиев", 54),
                new IssueColors(1, 1), 72), 1815));
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
            Assert.AreEqual(4.7, zirkon.GetTechNeedsPriceValue());
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
            Assert.AreEqual(18, zirkon.GetImpositionsPerBook());
        }

        [Test]
        public void Z84С_03_GetPrintingSheetsPerBook()
        {
            Assert.AreEqual(9, zirkon.GetPrintingSheetsPerBook());
        }

        [Test]
        public void Z84С_09_GetPrintingSheetsPerPrintRun()
        {
            Assert.AreEqual(16335, zirkon.GetPrintingSheetsPerPrintRun());
        }

        [Test]
        public void Z84С_04_GetPrintingForms()
        {
            Assert.AreEqual(18, zirkon.GetPrintingForms());
        }

        [Test]
        public void Z84С_05_GetCostOfPrintingFoms()
        {
            Assert.AreEqual(1620, zirkon.GetCostOfPrintingFoms());
        }

        [Test] //Оттиски
        public void Z84С_06_GetImpressions()
        {
            Assert.AreEqual(16335, zirkon.GetImpressions());
        }

        [Test]
        public void Z84С_07_GetCostOfImpressions()
        {
            Assert.AreEqual(599.4945, zirkon.GetCostOfImpressions(), delta: 0.01);
        }

        [Test]
        public void Z84С_08_GetCostOfPrinting()
        {
            Assert.AreEqual(2219.4945, zirkon.GetCostOfPrinting(), delta: 0.01);
        }

        [Test]
        public void Z84С_10_GetPaperConsumptionForTechnicalNeeds()
        {
            Assert.AreEqual(768, zirkon.GetPaperConsumptionForTechnicalNeeds());
        }

        [Test]
        public void Z84С_11_GetFittingOnPrintRun()
        {
            Assert.AreEqual(7200, zirkon.GetFittingOnPrintRun());
        }

        [Test]
        public void Z84С_12_GetTotalPaperConsumptionInPressFormat()
        {
            Assert.AreEqual(24303, zirkon.GetTotalPaperConsumptionInPressFormat());
        }


    }
}


