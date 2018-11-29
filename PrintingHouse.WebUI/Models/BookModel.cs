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
    public class BookModel
    {
        public string Name { get; set; }

        public string Id { get; set; }

        [Required(ErrorMessage = "Введите количество страниц")]
        [DivideByEight(ErrorMessage = "Количество страниц должно делиться на 8")]
        public int PagesNumber { get; set; }

        [Required(ErrorMessage = "Введите тираж")]
        public int PrintRun { get; set; }

        //internal block
        public string IBFormat { get; set; }
        public PaperFullType IBPaper { get; set; }
        public string IBColors { get; set; }
        public PrintingPressType IBPrintingPress { get; set; }

        //cover
        public PaperFullType CoverPaper { get; set; }
        public string CoverColors { get; set; }
        public PrintingPressType CoverPrintingPress { get; set; }
        public bool VarnishingOrdered { get; set; }

        //stickers
        public bool HasStickers { get; set; }
        public string StickerFormat { get; set; }
        public PaperFullType StickerPaper { get; set; }
        public string StickerColors { get; set; }
        public int StickerPages { get; set; }
        public PrintingPressType StickerPrintingPress { get; set; }


		//переплет
		public BindingType Binding { get; set; }

		public LaminationType Lamination { get; set; }

		public bool Perforation { get; set; }



		public BookModel() { }

        [Obsolete]
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

		public Book CreateBook()
		{
			Book book = new Book();

			book.Name = Name;
			book.Id = Id;
			book.PrintRun = PrintRun;

			book.BookParts = new List<BookPart>();

            book.BookParts.Add(InternalBlock);
			book.BookParts.Add(Cover);
            if(StickerPages > 0 && HasStickers == true)
                book.BookParts.Add(Stickers);

            //BookAssembly = new BookAssembly(BindingType.PerfectBinding, LaminationType.Glossy, true, PerforationType.withoutPerforation);

            book.BookAssembly = new BookAssembly(Binding, Lamination, true,
				(Perforation ? PerforationType.usual : PerforationType.withoutPerforation));

			return book;
		}


        public BookPart InternalBlock {
            get {
                //-------------создаем внутренний блок-------------
                BookPart innerBlock = new BookPart();

                innerBlock.Name = "Внутренний блок";

                innerBlock.Format = new IssueFormat(IBFormat);

                innerBlock.Paper = PaperProvider.GetPaper(IBPaper);

                innerBlock.Colors = new IssueColors(IBColors);

                innerBlock.PagesNumber = PagesNumber;

                innerBlock.PrintingPressType = IBPrintingPress;

                return innerBlock;
            }
        }

        public BookPart Cover {
            get {
                //обложка
                BookPart cover = new BookPart();
                cover.Name = "Обложка";
                cover.Format = InternalBlock.Format;
                cover.Paper = PaperProvider.GetPaper(CoverPaper);
                cover.Colors = new IssueColors(CoverColors);
                cover.PagesNumber = 4;//у любой обложки книги 4 страницы
                cover.PrintingPressType = CoverPrintingPress;
                cover.VarnishingOrdered = VarnishingOrdered;
                return cover;
            }
        }

        public BookPart Stickers {
            get {
                if(StickerPages > 0)
                {
                    //создаем самоклейку
                    BookPart stickers = new BookPart();
                    stickers.Name = "Самоклейка";
                    stickers.Format = new IssueFormat(StickerFormat);
                    stickers.Paper = PaperProvider.GetPaper(StickerPaper);
                    stickers.Colors = new IssueColors(StickerColors);
                    stickers.PagesNumber = StickerPages;
                    stickers.PrintingPressType = StickerPrintingPress;
                    return stickers;
                }
                return null;
            }
        }
	}
}