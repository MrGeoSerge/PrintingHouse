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

        //Конструктор принимающий модель представления из MVC или из базы данных
        public Book(BookModel _bookModel)
        {
            Name = _bookModel.Name;
            Id = _bookModel.Id;
            PrintRun = _bookModel.PrintRun;

            BookParts = new List<BookPart>();

            //-------------создаем внутренний блок-------------
            BookPart innerBlock = new BookPart();

            innerBlock.Name = "Внутренний блок";

                    innerBlock.Format = new IssueFormat(_bookModel.IBFormat);

            switch (_bookModel.IBPaper)
            {
                case PaperFullType.Newsprint_45:
                    innerBlock.Paper = new PaperInKg(PaperType.Newsprint, 45, 16.995, "Шклов", 59.4);
                    break;
                case PaperFullType.Offset_60:
                    innerBlock.Paper = new PaperInKg(PaperType.Offset, 60, 32.0, "Коростышев", 59.4);
                    break;
                case PaperFullType.Offset_80:
                    innerBlock.Paper = new PaperInSheets(PaperType.Offset, 80, 1.045, "Котлас", 60, 90);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("нераспознанная бумага");
            }

            innerBlock.Colors = new IssueColors(_bookModel.IBColors);

            innerBlock.PagesNumber = _bookModel.PagesNumber;

            BookParts.Add(innerBlock);


            //обложка
            BookPart cover = new BookPart();
            cover.Name = "Обложка";
            cover.Format = innerBlock.Format;

            switch (_bookModel.CoverPaper)
            {
                case PaperFullType.FoldingBoxboard_230:
                    cover.Paper = new PaperInSheets(PaperType.FoldingBoxboard, 230, 2.5, "Умка", 70, 100);
                    break;
                case PaperFullType.CardboardAliaska_230:
                    cover.Paper = new PaperInSheets(PaperType.CardboardAliaska, 230, 5.3, "Unknown", 70, 100);
                    break;

                default:
                    throw new ArgumentOutOfRangeException("нераспознанная бумага на обложку");
            }

                    cover.Colors = new IssueColors(_bookModel.CoverColors);
            

            cover.PagesNumber = 4;//у любой обложки книги 4 страницы

            BookParts.Add(cover);

            //BookAssembly = new BookAssembly(BindingType.PerfectBinding, LaminationType.Glossy, true, PerforationType.withoutPerforation);

            BookAssembly = new BookAssembly(_bookModel.Binding, _bookModel.Lamination, true, 
                (_bookModel.Perforation? PerforationType.usual : PerforationType.withoutPerforation));
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


