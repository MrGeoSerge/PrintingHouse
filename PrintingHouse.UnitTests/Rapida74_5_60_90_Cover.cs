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
    public class Rapida74_5_60_90_Cover
    {
        // R60C означает Rapida Format 60*90 Cover (обложка)

        Rapida74_5 rapida;

        //imposition - спуск
        //impression - оттиск

        [SetUp]
        public void Initialize()
        {
            rapida = new Rapida74_5(new TaskToPrint(new BookPart("Cover",
                new IssueFormat(60, 90, 16), new PaperInSheets(PaperType.CoatedPaper, 115, 1.50792, "Unknown", 64, 90),
                new IssueColors(4, 4), 4), 4400));
        }
 
        //Проверка правильности получения значений из прайса
        [Test]
        public void R60C_00_GetFormPriceValue()
        {
            Assert.AreEqual(108, rapida.GetFormPriceValue());
        }

        [Test]
        public void R60C_00_GetFittingPriceValue()
        {
            Assert.AreEqual(350, rapida.GetFittingPriceValue());
        }

        [Test]
        public void R60C_00_GetTechNeedsPriceValue()
        {
            Assert.AreEqual(0, rapida.GetTechNeedsPriceValue());
        }

        [Test]
        public void R60C_00_GetImpressionPriceValue()
        {
            Assert.AreEqual(0.059, rapida.GetImpressionPriceValue());
        }

        [Test]
        public void R60C_01_GetPagesPerOneImposition()
        {
            Assert.AreEqual(8, rapida.GetPagesPerOneImposition());
        }

        [Test]
        public void R60C_02_GetImpositionsPerBook()
        {
            Assert.AreEqual(0.5, rapida.GetImpositionsPerBook());
        }

        [Test]
        public void R60C_03_GetPrintingSheetsPerBook()
        {
            Assert.AreEqual(0.25, rapida.GetPrintingSheetsPerBook());
        }

        [Test]
        public void R60C_09_GetPrintingSheetsPerPrintRun()
        {
            Assert.AreEqual(1100, rapida.GetPrintingSheetsPerPrintRun());
        }

        [Test]
        public void R60C_04_GetPrintingForms()
        {
            Assert.AreEqual(8, rapida.GetPrintingForms());
        }

        [Test]
        public void R60C_05_GetCostOfPrintingFoms()
        {
            Assert.AreEqual(864, rapida.GetCostOfPrintingFoms());
        }

        [Test] //Оттиски
        public void R60C_06_GetImpressions()
        {
            Assert.AreEqual(8800, rapida.GetImpressions());
        }

        [Test]
        public void R60C_07_GetCostOfImpressions()
        {
            Assert.AreEqual(519.2, rapida.GetCostOfImpressions(), delta: 0.01 );
        }

        [Test]
        public void R60C_08_GetCostOfPrinting()
        {
            Assert.AreEqual(1383.2, rapida.GetCostOfPrinting(), delta: 0.01);
        }

        [Test]
        public void R60C_10_GetPaperConsumptionForTechnicalNeeds()
        {
            Assert.AreEqual(0, rapida.GetPaperConsumptionForTechnicalNeeds());
        }

        [Test]
        public void R60C_11_GetFittingOnPrintRun()
        {
            Assert.AreEqual(350, rapida.GetFittingOnPrintRun());
        }

        [Test]
        public void R60C_12_GetTotalPaperConsumptionInPressFormat()
        {
            Assert.AreEqual(1450, rapida.GetTotalPaperConsumptionInPressFormat());
        }
    }
}
