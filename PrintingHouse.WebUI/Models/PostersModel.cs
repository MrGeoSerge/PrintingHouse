using PrintingHouse.Domain.Entities;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrintingHouse.WebUI.Models
{
    //Адаптер между входными параметрами книг из БазыДанных либо из представления
    //и между моделью производства книги Типографией
    public class PostersModel
    {
        [Required(ErrorMessage = "Введите тираж")]
        public int PrintRun { get; set; }

        //posters block
        [Required(ErrorMessage = "Введите количество страниц")]
        public int PostersPagesNumber { get; set; }
        public string PostersFormat { get; set; }
        public PaperFullType PostersPaper { get; set; }
        public string PostersColors { get; set; }
        public PrintingPressType PostersPrintingPress { get; set; }
        public bool PostersVarnishingOrdered { get; set; }

        //insert block
        public string InsertFormat { get; set; }
        public PaperFullType InsertPaper { get; set; }
        public string InsertColors { get; set; }
        public int InsertPagesNumber { get; set; }
        public PrintingPressType InsertPrintingPress { get; set; }

        //сборка
        public double PlasticPack { get; set; }
        public LaminationType Lamination { get; set; }

        public Book CreatePosters()
        {
            Book book = new Book();

            book.PrintRun = PrintRun;
            book.BookParts = new List<BookPart>();

            book.BookParts.Add(Posters);
            book.BookParts.Add(Insert);

            book.BookAssembly =  new BookAssembly(BindingType.WithoutBinding, Lamination, true, 
                PerforationType.withoutPerforation);

            return book;
        }



        public BookPart Posters {
            get {
                BookPart posters = new BookPart();
                posters.Name = "Плакаты";
                posters.Format = new IssueFormat(PostersFormat);
                posters.Paper = PaperProvider.GetPaper(PostersPaper);
                posters.Colors = new IssueColors(PostersColors);
                posters.PagesNumber = PostersPagesNumber;
                posters.PrintingPressType = PostersPrintingPress;
                posters.VarnishingOrdered = PostersVarnishingOrdered;
                return posters;
            }
        }


        public BookPart Insert {
            get {
                BookPart insert = new BookPart();
                insert.Name = "Вкладыш";
                insert.Format = new IssueFormat(InsertFormat);
                insert.Paper = PaperProvider.GetPaper(InsertPaper);
                insert.Colors = new IssueColors(InsertColors);
                insert.PagesNumber = InsertPagesNumber;
                insert.PrintingPressType = InsertPrintingPress;
                return insert;
            }
        }




















    }
}