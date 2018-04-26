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
    public class BookCostOfPolygraphy
    {
        public Book book;

        //затраты на полиграфию 
        public double CostOfPolygraphy { private set; get; }

        //затраты на материалы
        public double CostOfMaterials { private set; get; }

        //затраты на сборку (переплет, ламинация, перфорация, упаковка)
        public double CostOfAssembly { private set; get; }

        //общие затраты на тираж
        public double CostOfPrintRun { private set; get; }

        //затраты на полиграфию одного экземпляра
        public double CostOfPolygraphyPerOneItem { private set; get; }




        public BookCostOfPolygraphy(Book _book, PressReport innerBlock, PressReport cover, AssemblyReport assembly)
        {
            book = _book;
            CostOfPolygraphy = innerBlock.GetCostOfPolygraphy() + cover.GetCostOfPolygraphy();
            CostOfMaterials = innerBlock.GetPaperCost() + cover.GetPaperCost();
            CostOfAssembly = assembly.TotalCostOfAssembly;

            CostOfPrintRun = CostOfPolygraphy + CostOfMaterials + CostOfAssembly;
            CostOfPolygraphyPerOneItem = Math.Round(CostOfPrintRun / book.PrintRun, 4);
        }

        public BookCostOfPolygraphy(Book _book, AssemblyReport assembly, List<PressReport> bookParts)
        {
            book = _book;
            CostOfPolygraphy = 0;
            CostOfMaterials = 0;

            foreach(PressReport pressReport in bookParts)
            {
                CostOfPolygraphy += pressReport.GetCostOfPolygraphy();
                CostOfMaterials += pressReport.GetPaperCost();
            }

            CostOfAssembly = assembly.TotalCostOfAssembly;

            CostOfPrintRun = CostOfPolygraphy + CostOfMaterials + CostOfAssembly;
            CostOfPolygraphyPerOneItem = Math.Round(CostOfPrintRun / book.PrintRun, 4);
        }

        public string CostReport()
        {
            string myBook = "Название: " + book.Name + "\n";
            myBook += "Издательский код: " + book.Id + "\n";
            myBook += "Тираж: " + book.PrintRun + "\n";
            myBook += "Затраты на книгу: \n";
            myBook += "Оборот полиграфия: " + CostOfPolygraphy + "\n";
            myBook += "Всего материалов: " + CostOfMaterials + "\n";
            myBook += "Переплет: " + CostOfAssembly + "\n";
            myBook += "Оборот с материалами и полиграфией: " + CostOfPrintRun + "\n";
            myBook += "За экземпляр с материалами: " + CostOfPolygraphyPerOneItem + "\n";

            return myBook;
        }

    }
}
