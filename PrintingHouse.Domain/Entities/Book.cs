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
            BookPart cover, BookPart stickers,BookAssembly assembly)
        {
            BookParts = new List<BookPart>();

            Name = name;
            Id = id;
            PrintRun = printRun;

            BookParts.Add(innerBlock);
            BookParts.Add(cover);
            BookParts.Add(stickers);

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
    }
}


