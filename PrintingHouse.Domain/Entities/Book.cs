using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Specifications;
using System;
using System.Collections.Generic;

namespace PrintingHouse.Domain.Entities
{
	public class Book
    {
        //издательский код книги
        public string Id { set; get; }

        //Полное название книги
        public string Name { set; get; }

        //- тираж
        public int PrintRun { set; get; }

        //части книги (обложка, внутренний блок, вставки и т. п.)
        public List<BookPart> BookParts { set; get; }

        //сборка книги
        public BookAssembly BookAssembly { set; get; }

        //конструктор для книги, у которой только обложка, внутренний блок и переплет
        public Book(string id, string name, int printRun, BookPart innerBlock, 
            BookPart cover, BookAssembly assembly)
        {
            BookParts = new List<BookPart>();

            Name = name;
            Id = id;
            PrintRun = printRun;

            BookParts.Add(innerBlock);
            BookParts.Add(cover);

            BookAssembly = assembly;
        }

        //конструктор для книги, у которой только обложка, внутренний блок, наклейки и переплет
        public Book(string id, string name, int printRun, BookPart innerBlock, 
            BookPart cover, BookPart nakleyki,BookAssembly assembly)
        {
            BookParts = new List<BookPart>();

            Name = name;
            Id = id;
            PrintRun = printRun;

            BookParts.Add(innerBlock);
            BookParts.Add(cover);
            BookParts.Add(nakleyki);

            BookAssembly = assembly;
        }

        //конструктор для твердого переплета: обложка, внутренний блок, форзац, переплетный картон и переплет
        public Book(string id, string name, int printRun, BookPart innerBlock, 
            BookPart cover, BookPart forzats, BookPart cardboard,BookAssembly assembly)
        {
            BookParts = new List<BookPart>();

            Name = name;
            Id = id;
            PrintRun = printRun;

            BookParts.Add(innerBlock);
            BookParts.Add(cover);
            BookParts.Add(forzats);
            BookParts.Add(cardboard);

            BookAssembly = assembly;
        }

        public Book()
        {

        }




        public override string ToString()
        {
            string myBook = "Название: " + Name + "\n";
            myBook += "Издательский код: " + Id + "\n";
            myBook += "Тираж: " + PrintRun + "\n";

            foreach (BookPart part in BookParts)
            {
                myBook += "Часть:\n" + part.Name + "\n";
                myBook += "     Формат " + part.Format + "\n";
                myBook += "     Цветность: " + part.Colors + "\n";
                myBook += "     Бумага: " + part.Paper + "\n\n";
            }
            return myBook;
        }







        #region Характеристики книги, которые будем вычислять

        ////затраты на полиграфию 
        //public double CostOfPolygraphy { private set; get; }

        ////затраты на материалы
        //public double CostOfMaterials { private set; get; }

        ////затраты на сборку (переплет, ламинация, перфорация, упаковка)
        //public double CostOfAssembly { private set; get; }

        ////общие затраты на тираж
        //public double CostOfPrintRun { private set; get; }

        ////затраты на полиграфию одного экземпляра
        //public double CostOfPolygraphyPerOneItem { private set; get; }


        #endregion


        //public void GetCosts(PressReport innerBlock, PressReport cover, AssemblyReport assembly)
        //{
        //    CostOfPolygraphy = innerBlock.PolygraphyCost + cover.PolygraphyCost;
        //    CostOfMaterials = innerBlock.PaperCost + cover.PaperCost;
        //    CostOfAssembly = assembly.totalCostOfAssembly;

        //    CostOfPrintRun = CostOfPolygraphy + CostOfMaterials + CostOfAssembly;
        //    CostOfPolygraphyPerOneItem = Math.Round(CostOfPrintRun / PrintRun, 4);
        //}

        //public void ShowCostOfPolygraphy()
        //{
        //    Console.WriteLine(new string('-', 80));
        //    Console.WriteLine("Затраты на книгу: ");
        //    Console.WriteLine($"Оборот полиграфия: {CostOfPolygraphy}");
        //    Console.WriteLine($"Всего материалов: {CostOfMaterials}");
        //    Console.WriteLine($"Переплет: {CostOfAssembly}");
        //    Console.WriteLine($"Оборот с материалами и полиграфией: {CostOfPrintRun}");
        //    Console.WriteLine($"За экземпляр с материалами: {CostOfPolygraphyPerOneItem}");


        //}


        //public string TotalCosts()
        //{
        //    string myBook = "Название: " + Name + "\n";
        //    myBook += "Издательский код: " + Id + "\n";
        //    myBook += "Тираж: " + PrintRun + "\n";
        //    myBook += "Затраты на книгу: \n";
        //    myBook += "Оборот полиграфия: " + CostOfPolygraphy + "\n";
        //    myBook += "Всего материалов: " + CostOfMaterials + "\n";
        //    myBook += "Переплет: " + CostOfAssembly + "\n";
        //    myBook += "Оборот с материалами и полиграфией: " + CostOfPrintRun + "\n";
        //    myBook += "За экземпляр с материалами: " + CostOfPolygraphyPerOneItem + "\n";

        //    return myBook;
        //}

    }
}


