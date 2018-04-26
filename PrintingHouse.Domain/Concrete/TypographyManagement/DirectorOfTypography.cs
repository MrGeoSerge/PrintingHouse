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

namespace BookProduction.TypographyManagement
{
    //Директор типографии раздает задания (- формирует Task-и) на печатные машины и другие виды работ
    public class DirectorOfTypography
    {
        Book book;
        AssemblyReport assemblyReport;

        public DirectorOfTypography(Book book)
        {
            this.book = book;
        }

        public BookCostOfPolygraphy MakeBook()
        {
            List<TaskToPrint> tasksToPrint = new List<TaskToPrint>();

            foreach (BookPart bookPart in book.BookParts)
            {
                tasksToPrint.Add(new TaskToPrint(bookPart.Name, bookPart.Format, bookPart.Paper,
                    bookPart.Colors, bookPart.PagesNumber, book.PrintRun));
            }

            List<PressReport> pressReports = new List<PressReport>();
            foreach (TaskToPrint taskToPrint in tasksToPrint)
            {
                pressReports.Add(PrintBookPart(taskToPrint));
            }

            foreach(var pressReport in pressReports)
            {
                pressReport.ShowDetailedReport();
            }
            AssembleBook();
            //записываем все затраты обратно в книгу и собираем (assemble) книгу
            return new BookCostOfPolygraphy(book, assemblyReport, pressReports);
        }

        //реализация паттерна Строитель
        //сборка книги
        public void AssembleBook()
        {
            IAssemblyDepartment assemblyDepartment = new AssemblyDepartment(book);
            AssemblyDirector assemblyDirector = new AssemblyDirector(assemblyDepartment);
            assemblyDirector.Assemble();
            assemblyReport = assemblyDepartment.GetReport();
            assemblyReport.ShowDetailedReport();
        }



        //сделать книгу - это отпечатать части книги (внутренний блок(и), обложку, вклейки)
        //и собрать (переплести, сделать ламинацию, перфорацию, упаковать)

        //отпечатать часть книги (внутренний блок, обложку или вклейку)
        private PressReport PrintBookPart(TaskToPrint _taskForPart)
        {
            PrintingPress printingPress;
            PressReport bookPartReport;

            //-----------выбираем, на каком станке печатать-----------

            //коросет, если 84*108 формат и плотность не более 60 г/м2
            if (_taskForPart.Format.Length == 84 && _taskForPart.Format.Width == 108
                && _taskForPart.Paper.Density <= 60)
            {
                printingPress = new CorosetPlamag(_taskForPart);
            }

            //циркон, если 60*90 формат и плотность не более 60 г/м2
            else if (_taskForPart.Format.Length == 60 && _taskForPart.Format.Width == 90
                && _taskForPart.Paper.Density <= 60)
            {
                printingPress = new ZirkonForta660(_taskForPart);
            }

            //шинохара, если 84*108 формат и плотность  более 80 г/м2
            else if (_taskForPart.Format.Length == 84 && _taskForPart.Format.Width == 108
                && _taskForPart.Paper.Density > 80)
            {
                printingPress = new Shinohara52_2(_taskForPart);
            }

            //роланд, если 70*100 формат и цветность больше 2+2
            //else if (_taskForPart.Format.Length == 70 && _taskForPart.Format.Width == 100 
            //    && _taskForPart.Colors.FrontColors >=2)
            //{
            //    printingPress = new Rapida(_taskForPart);
            //}

            //рапида для обложек - Хром-эрзац или для плотной бумаги
            else if (_taskForPart.Colors.Total() >= 4)
            {
                printingPress = new Rapida74_5(_taskForPart);
            }

            else if(_taskForPart.Colors.ToString() == "0+0")
            {
                printingPress = new ZeroColorPress(_taskForPart);
            }
            else
                throw new Exception("не нашли подходящий станок для печати" + _taskForPart);

            bookPartReport = printingPress.SendReport();
            return bookPartReport;
        }



    }
}
