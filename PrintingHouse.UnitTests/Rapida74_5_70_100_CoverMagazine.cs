using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class Rapida74_5_70_100_CoverMagazine
    {
        // R70C означает Rapida Format 60*90 Cover (обложка)

        Rapida74_5 rapida;

        //imposition - спуск
        //impression - оттиск

        [SetUp]
        public void Initialize()
        {
            //суперобложкажурнала АМЖ063
            rapida = new Rapida74_5(new TaskToPrint(new BookPart("Cover",
                new IssueFormat(70, 100, 4), new PaperInSheets(PaperType.CoatedPaper, 80, 1.31016, "Меловка пл.80 64х90 мат ", 64, 90),
                new IssueColors(4, 4), 2), 1865));
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
            Assert.AreEqual(350, rapida.GetFittingPriceValue());
        }

        [Test]
        public void R70C_00_GetTechNeedsPriceValue()
        {
            Assert.AreEqual(0, rapida.GetTechNeedsPriceValue());
        }

        [Test]
        public void R70C_00_GetImpressionPriceValue()
        {
            Assert.AreEqual(0.132, rapida.GetImpressionPriceValue());
        }

        [Test]
        public void R70C_01_GetPagesPerOneImposition()
        {
            Assert.AreEqual(2, rapida.GetPagesPerOneImposition());
        }

        [Test]
        public void R70C_02_GetImpositionsPerBook()
        {
            Assert.AreEqual(1, rapida.GetImpositionsPerBook());
        }

        [Test]
        public void R70C_03_GetPrintingSheetsPerBook()
        {
            Assert.AreEqual(0.5, rapida.GetPrintingSheetsPerBook());
        }

        [Test]
        public void R70C_09_GetPrintingSheetsPerPrintRun()
        {
            Assert.AreEqual(933, rapida.GetPrintingSheetsPerPrintRun());
        }

        [Test]
        public void R70C_04_GetPrintingForms()
        {
            Assert.AreEqual(8, rapida.GetPrintingForms());
        }

        [Test]
        public void R70C_05_GetCostOfPrintingFoms()
        {
            Assert.AreEqual(864, rapida.GetCostOfPrintingFoms());
        }

        [Test] //Оттиски
        public void R70C_06_GetImpressions()
        {
            //7464
            Assert.AreEqual(7464, rapida.GetImpressions());
        }

        [Test]
        public void R70C_07_GetCostOfImpressions()
        {
            Assert.AreEqual(985.248, rapida.GetCostOfImpressions(), delta: 0.01 );
        }

        [Test]
        public void R70C_08_GetCostOfPrinting()
        {
            Assert.AreEqual(1849.248, rapida.GetCostOfPrinting(), delta: 0.01);
        }

        [Test]
        public void R70C_10_GetPaperConsumptionForTechnicalNeeds()
        {
            Assert.AreEqual(0, rapida.GetPaperConsumptionForTechnicalNeeds());
        }

        [Test]
        public void R70C_11_GetFittingOnPrintRun()
        {
            Assert.AreEqual(350, rapida.GetFittingOnPrintRun());
        }

        [Test]
        public void R70C_12_GetTotalPaperConsumptionInPressFormat()
        {
            Assert.AreEqual(1283, rapida.GetTotalPaperConsumptionInPressFormat());
        }
    }
}
