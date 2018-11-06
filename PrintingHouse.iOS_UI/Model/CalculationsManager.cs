using System;
using System.Collections.Generic;
using System.Text;
using PrintingHouse.Domain.Entities;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Entities.Reports;
using PrintingHouse.Domain.Interfaces;
using PrintingHouse.Domain.Processes.PrintingHouseManagement;
using PrintingHouse.Domain.Specifications;

namespace PrintingHouse.iOS_UI.Model
{
    public class CalculationsManager
    {
        IGetPathFolder getPathFolder;

        public CalculationsManager()
        {

        }

        public CalculationsManager(IGetPathFolder getPathFolder)
        {
            this.getPathFolder = getPathFolder;
        }

        public Book GetMyConspectusBook(int pagesQuantity, int printRun)
        {

            BookPart internalBlock = new BookPart()
            {
                Name = "Internal Block",
                Format = new IssueFormat("84*108/16"),
                //Paper = new PaperInKg(PaperType.Newsprint, 45, 23.5, "Zmiev", 84),
                Paper = new PaperInKg(PaperType.Newsprint, 45, 16.995, "Шклов", 59.4),
                Colors = new IssueColors("1+1"),
                PagesNumber = pagesQuantity
            };

            BookPart cover = new BookPart()
            {
                Name = "Cover",
                Format = new IssueFormat("84*108/16"),
                //Paper = new PaperInSheets(PaperType.FoldingBoxboard, 230, 4.2333, "Korostishev", 64, 90),
                Paper = new PaperInSheets(PaperType.FoldingBoxboard, 230, 2.5, "Умка", 70, 100),
                Colors = new IssueColors("1+1"),
                PagesNumber = 4
            };

            BookAssembly bookAssembly = new BookAssembly(BindingType.PerfectBinding, LaminationType.Glossy, true);

            Book book = new Book("AAA000", "Default Name", printRun, internalBlock, cover, bookAssembly);

            return book;
        }

        public PolygraphyCostReport CalculateMyConspectusPrintingCost(int pagesQuantity, int printRun)
        {
            Book book = GetMyConspectusBook(pagesQuantity, printRun);
            DirectorOfTypography director = new DirectorOfTypography(book, getPathFolder);
            PolygraphyCostReport report = director.MakeBook();

            //var costPerItem = report.CostOfPolygraphyPerOneItem.ToString();
            return report;
        }
    }
}
