using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
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
    //Адаптер между входными параметрами книг из БазыДанных либо из представления
    //и между моделью производства книги Типографией
    public class BookModel
    {

        public string Name { get; set; }

        public string Id { get; set; }

        [Required(ErrorMessage ="Введите количество страниц")]
        [DivideByEight(ErrorMessage ="Количество страниц должно делиться на 8")]
        public int PagesNumber { get; set; }

        [Required(ErrorMessage ="Введите тираж")]
        public int PrintRun { get; set; }

        //внутренний блок
        public string IBFormat { get; set; }

        public PaperFullType IBPaper { get; set; }

        public string IBColors { get; set; }

        //обложка
        public PaperFullType CoverPaper { get; set; }

        public string CoverColors { get; set; }

        //переплет
        public BindingType Binding { get; set; }

        public LaminationType Lamination { get; set; }

        public bool Perforation { get; set; }



        public BookModel() { }

        public BookModel(Book _book)
        {
            Name = _book.Name;
            Id = _book.Id;
            PagesNumber = _book.BookParts[0].PagesNumber;
            PrintRun = _book.PrintRun;


            //формат внутреннего блока
            IBFormat = _book.BookParts[0].Format.ToString();
  

            //бумага 
            if (_book.BookParts[0].Paper.Kind == PaperType.Newsprint &&
                _book.BookParts[0].Paper.Density == 45)
            {
                IBPaper = PaperFullType.Newsprint_45;
            }
            else if (_book.BookParts[0].Paper.Kind == PaperType.Offset &&
                _book.BookParts[0].Paper.Density == 60)
            {
                IBPaper = PaperFullType.Offset_60;
            }
            else if (_book.BookParts[0].Paper.Kind == PaperType.Offset &&
                _book.BookParts[0].Paper.Density == 80)
            {
                IBPaper = PaperFullType.Offset_80;
            }
            else if (_book.BookParts[0].Paper.Kind == PaperType.FoldingBoxboard &&
                _book.BookParts[0].Paper.Density == 230)
            {
                IBPaper = PaperFullType.FoldingBoxboard_230;
            }
            else
            {
                throw new ArgumentOutOfRangeException("неправильная бумага внутреннего блока");
            }

            IBColors = _book.BookParts[0].Colors.ToString();

           

            //бумага обложки
            if (_book.BookParts[1].Paper.Kind == PaperType.FoldingBoxboard &&
                _book.BookParts[1].Paper.Density == 230)
            {
                CoverPaper = PaperFullType.FoldingBoxboard_230;
            }
            else
            {
                throw new ArgumentOutOfRangeException("неправильная бумага обложки");
            }

            //цветность обложки
                    CoverColors = _book.BookParts[1].Colors.ToString();

            Binding = _book.BookAssembly.BindingType;

            Lamination = _book.BookAssembly.LaminationType;

            if (_book.BookAssembly.Perforation == PerforationType.withoutPerforation)
            {
                Perforation = false;
            }
            else
            {
                Perforation = true;
            }

        }
    }
}