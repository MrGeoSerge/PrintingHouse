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
    public class Rapida74_5_70_100_InternalBlock
    {
        // R70IB означает Rapida Format 70*100 Internal block 

        Rapida74_5 rapida;

        //imposition - спуск
        //impression - оттиск

        [SetUp]
        public void Initialize()
        {
            //ОСК002 - издательский код
            rapida = new Rapida74_5(new TaskToPrint(new BookPart("InternalBlock",
                new IssueFormat(70, 100, 16), new PaperInSheets(PaperType.Offset, 60, 1.2850997544, "Люмисет", 70, 100),
                new IssueColors(2, 2), 48), 28000));
        }

        //Проверка правильности получения значений из прайса
        [Test]
        public void R70IB_00_GetFormPriceValue()
        {
            Assert.AreEqual(108, rapida.GetFormPriceValue());
        }

        [Test]
        public void R70IB_00_GetFittingPriceValue()
        {
            Assert.AreEqual(0, rapida.GetFittingPriceValue());
        }

        [Test]
        public void R70IB_00_GetTechNeedsPriceValue()
        {
            Assert.AreEqual(8, rapida.GetTechNeedsPriceValue());
        }

        [Test]
        public void R70IB_00_GetImpressionPriceValue()
        {
            Assert.AreEqual(0.037, rapida.GetImpressionPriceValue());
        }

        [Test]
        public void R70IB_01_GetPagesPerOneImposition()
        {
            Assert.AreEqual(8, rapida.GetPagesPerOneImposition());
        }

        [Test]
        public void R70IB_02_GetImpositionsPerBook()
        {
            Assert.AreEqual(6, rapida.GetImpositionsPerBook());
        }

        [Test]
        public void R70IB_03_GetPrintingSheetsPerBook()
        {
            Assert.AreEqual(3, rapida.GetPrintingSheetsPerBook());
        }

        [Test]
        public void R70IB_09_GetPrintingSheetsPerPrintRun()
        {
            Assert.AreEqual(84000, rapida.GetPrintingSheetsPerPrintRun());
        }

        [Test]
        public void R70IB_04_GetPrintingForms()
        {
            Assert.AreEqual(12, rapida.GetPrintingForms());
        }

        [Test]
        public void R70IB_05_GetCostOfPrintingFoms()
        {
            Assert.AreEqual(1296, rapida.GetCostOfPrintingFoms());
        }

        [Test] //Оттиски
        public void R70IB_06_GetImpressions()
        {
            Assert.AreEqual(336000, rapida.GetImpressions());
        }

        [Test]
        public void R70IB_07_GetCostOfImpressions()
        {
            Assert.AreEqual(12432, rapida.GetCostOfImpressions(), delta: 0.01);
        }

        [Test]
        public void R70IB_08_GetCostOfPrinting()
        {
            Assert.AreEqual(13728, rapida.GetCostOfPrinting(), delta: 0.01);
        }

        [Test]
        public void R70IB_10_GetParerConsumptionForTechnicalNeeds()
        {
            Assert.AreEqual(6720, rapida.GetPaperConsumptionForTechnicalNeeds());
        }

        [Test]
        public void R70IB_11_GetFittingOnPrintRun()
        {
            Assert.AreEqual(0, rapida.GetFittingOnPrintRun());
        }

        [Test]
        public void R70IB_12_GetTotalPaperConsumptionInPressFormat()
        {
            Assert.AreEqual(90720, rapida.GetTotalPaperConsumptionInPressFormat());
        }
    }
}


