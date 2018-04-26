using NUnit.Framework;
using PrintingHouse.Domain.Entities;
using PrintingHouse.Domain.Processes.PrintingHouseManagement;
using PrintingHouse.Domain.Entities.Reports;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.PrintingPresses;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.Domain.Entities.Paper;

namespace BookProduction.UnitTests
{
	[TestFixture]
    public class MiyConspectCreation
    {
        Book MkBook;
        DirectorOfTypography director;
        BookCostOfPolygraphy report;
        TaskToPrint taskToInnerBlock;
        CorosetPlamag coroset;
        PressReport IB_report;

        TaskToPrint taskToCover;
        Shinohara52_2 shinohara;
        PressReport Cov_report;

        [SetUp]
        public void Initialize()
        {
             MkBook = new Book("УММ034-д1", "Українська мова 8клас 2 семестр Нова програма Мій конспект", 1000,
                 new BookPart("Внутренний блок", 
                                new IssueFormat(84, 108, 16),
                                new PaperInKg(PaperType.Newsprint, 45, 15.656, "Шклов", 84),
                                new IssueColors(1, 1), 88),
                 new BookPart("Обложка", 
                                new IssueFormat(84, 108, 16),
                                new PaperInSheets(PaperType.FoldingBoxboard, 230, 2.482, "Умка", 64, 90),
                                new IssueColors(4, 1), 4),
                 new BookAssembly(BindingType.SaddleStitching, LaminationType.Glossy, true, PerforationType.usual));

            //director = new DirectorOfTypography(theBook);
            //report = director.MakeBook();
            taskToInnerBlock = new TaskToPrint(MkBook.BookParts[0], MkBook.PrintRun);
            coroset = new CorosetPlamag(taskToInnerBlock);
            IB_report = coroset.SendReport();

            taskToCover = new TaskToPrint(MkBook.BookParts[1], MkBook.PrintRun);
            shinohara = new Shinohara52_2(taskToCover);
            Cov_report = shinohara.SendReport();
        }


        [Test]
        public void MK_IB_01()
        {
            Assert.AreEqual(12, coroset.GetPrintingForms());
        }

        [Test]
        public void MK_IB_02()
        {
            Assert.AreEqual(217.91, IB_report.GetPaperConsumptionInKg(), delta: 0.03);
        }

        [Test]
        public void MK_IB_03()
        {
            Assert.AreEqual(5500, coroset.GetImpressions());
        }

        [Test]
        public void MK_IB_04()
        {
            Assert.AreEqual(1916.25, IB_report.GetCostOfPolygraphy());
        }

        [Test]
        public void MK_IB_05()
        {
            Assert.AreEqual(3411.60, IB_report.GetPaperCost(), delta: 0.5);
        }

        [Test]
        public void MK_IB_06()
        {
            Assert.AreEqual(3411.60, IB_report.GetPaperCost(), delta: 0.5);
        }





        [Test]
        public void MK_C_00_GetFormPriceValue()
        {
            Assert.AreEqual(54, shinohara.GetFormPriceValue());
        }

        [Test]
        public void MK_C_00_GetFittingPriceValue()
        {
            Assert.AreEqual(16, shinohara.GetFittingPriceValue());
        }

        [Test]
        public void MK_C_00_GetTechNeedsPriceValue()
        {
            Assert.AreEqual(3.2, shinohara.GetTechNeedsPriceValue());
        }

        [Test]
        public void MK_C_00_GetImpressionPriceValue()
        {
            Assert.AreEqual(0.037, shinohara.GetImpressionPriceValue());
        }

        [Test]
        public void MK_C_01_GetPagesPerOneImposition()
        {
            Assert.AreEqual(2, shinohara.GetPagesPerOneImposition());
        }

        [Test]
        public void MK_C_02_GetImpositionsPerBook()
        {
            Assert.AreEqual(2, shinohara.GetImpositionsPerBook());
        }

        [Test]
        public void MK_C_03_GetPrintingSheetsPerBook()
        {
            Assert.AreEqual(1, shinohara.GetPrintingSheetsPerBook());
        }

        [Test]
        public void MK_C_09_GetPrintingSheetsPerPrintRun()
        {
            Assert.AreEqual(1000, shinohara.GetPrintingSheetsPerPrintRun());
        }

        [Test]
        public void MK_C_04_GetPrintingForms()
        {
            Assert.AreEqual(5, shinohara.GetPrintingForms());
        }

        [Test]
        public void MK_C_05_GetCostOfPrintingFoms()
        {
            Assert.AreEqual(270, shinohara.GetCostOfPrintingFoms());
        }

        [Test] //Оттиски
        public void MK_C_06_GetImpressions()
        {
            Assert.AreEqual(5000, shinohara.GetImpressions());
        }

        [Test]
        public void MK_C_07_GetCostOfImpressions()
        {
            Assert.AreEqual(185, shinohara.GetCostOfImpressions(), delta: 0.01);
        }

        [Test]
        public void MK_C_08_GetCostOfPrinting()
        {
            Assert.AreEqual(455, shinohara.GetCostOfPrinting(), delta: 0.01);
        }

        [Test]
        public void MK_C_10_GetPaperConsumptionForTechnicalNeeds()
        {
            Assert.AreEqual(160, shinohara.GetPaperConsumptionForTechnicalNeeds());
        }

        [Test]
        public void MK_C_11_GetFittingOnPrintRun()
        {
            Assert.AreEqual(80, shinohara.GetFittingOnPrintRun());
        }

        [Test]
        public void MK_C_12_GetTotalPaperConsumptionInPressFormat()
        {
            Assert.AreEqual(1260, shinohara.GetTotalPaperConsumptionInPressFormat());
        }
        
        [Test]
        public void MK_C_13_GetNumberOfPrintSheetsInRawSheet()
        {
           Assert.AreEqual(4, Cov_report.GetNumberOfPrintSheetsInRawSheet());
        }

        [Test]
        public void MK_C_13____GetPaperConsumptionInRawSheets()
        {
           Assert.AreEqual(1260, Cov_report.press.GetTotalPaperConsumptionInPressFormat());
        }

        [Test]
        public void MK_C_13_PressSheetFormat()
        {
            Assert.AreEqual(8, shinohara.GetPressSheetsFormat().Fraction);
        }

        [Test]
        public void MK_C_14_GetPaperCost()
        {
            Assert.AreEqual(781.83, Cov_report.GetPaperCost());
        }

        [Test]
        public void MK_C_15_GetCostOfPolygraphy()
        {
            Assert.AreEqual(455, Cov_report.GetCostOfPolygraphy());
        }

    }
}
