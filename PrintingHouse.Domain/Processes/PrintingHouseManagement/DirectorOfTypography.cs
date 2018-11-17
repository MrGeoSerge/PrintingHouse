using System;
using System.Collections.Generic;
using PrintingHouse.Domain.Entities;
using PrintingHouse.Domain.Entities.Reports;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Abstract;
using PrintingHouse.Domain.Processes.BookAssembly;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Entities.PrintingPresses.Abstract;
using PrintingHouse.Domain.Interfaces;
using PrintingHouse.Domain.Specifications;

namespace PrintingHouse.Domain.Processes.PrintingHouseManagement
{
	//Директор типографии раздает задания (- формирует Task-и) на печатные машины и другие виды работ
	public class DirectorOfTypography
    {
        IGetPathFolder getPathFolder;

        Book book;
        AssemblyReport assemblyReport;

        //public DirectorOfTypography(Book book)
        //{
        //    this.book = book;
        //}

        public DirectorOfTypography(Book book, IGetPathFolder getPathFolder)
        {
            this.book = book;
            this.getPathFolder = getPathFolder;
        }

        public PolygraphyCostReport MakeBook()
        {
            List<TaskToPrint> tasksToPrint = new List<TaskToPrint>();

            foreach (BookPart bookPart in book.BookParts)
            {
                tasksToPrint.Add(new TaskToPrint(bookPart.Name, bookPart.Format, bookPart.Paper,
                    bookPart.Colors, bookPart.PrintingPressType, bookPart.PagesNumber, book.PrintRun));
            }

            List<PrintingPressReport> pressReports = new List<PrintingPressReport>();
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
            return new PolygraphyCostReport(book, assemblyReport, pressReports);
        }

        //реализация паттерна Строитель
        //сборка книги
        public void AssembleBook()
        {
            IAssemblyDepartment assemblyDepartment = new AssemblyDepartment(book);
            AssemblyDirector assemblyDirector = new AssemblyDirector(assemblyDepartment);
            assemblyDirector.Assemble();
            assemblyReport = assemblyDepartment.Report;
            assemblyReport.ShowDetailedReport();
        }



        //сделать книгу - это отпечатать части книги (внутренний блок(и), обложку, вклейки)
        //и собрать (переплести, сделать ламинацию, перфорацию, упаковать)

        //отпечатать часть книги (внутренний блок, обложку или вклейку)
        private PrintingPressReport PrintBookPart(TaskToPrint taskToPrint)
        {
            PrintingPressReport bookPartReport;

            PrintingPress printingPress = ChoosePrintingPress(taskToPrint);

            bookPartReport = printingPress.SendReport;
            return bookPartReport;
        }

        private PrintingPress ChoosePrintingPress (TaskToPrint taskToPrint)
        {
            //-----------выбираем, на каком станке печатать-----------
            PrintingPress printingPress;

            switch (taskToPrint.PrintingPressType)
            {
                case PrintingPressType.Coroset:
                    printingPress = new CorosetPlamag(taskToPrint, getPathFolder);
                    break;
                case PrintingPressType.Rapida:
                    printingPress = new Rapida74_5(taskToPrint, getPathFolder);
                    break;
                case PrintingPressType.Shinohara:
                    printingPress = new Shinohara52_2(taskToPrint, getPathFolder);
                    break;
                case PrintingPressType.Zirkon:
                    printingPress = new ZirkonForta660(taskToPrint, getPathFolder);
                    break;
                case PrintingPressType.NotSelected:
                    printingPress = ChoosePrintingPressByParameters(taskToPrint);
                    break;
                default:
                    throw new Exception("не выбран подходящий станок для печати" + taskToPrint);
            }

            return printingPress;

        }

        private PrintingPress ChoosePrintingPressByParameters(TaskToPrint taskToPrint)
        {
            PrintingPress printingPress;

            //коросет, если 84*108 формат и плотность не более 60 г/м2
            if (taskToPrint.Format.Length == 84 && taskToPrint.Format.Width == 108
                && taskToPrint.Paper.Density <= 60)
            {
                printingPress = new CorosetPlamag(taskToPrint, getPathFolder);
            }

            //циркон, если 60*90 формат и плотность не более 60 г/м2
            else if (taskToPrint.Format.Length == 60 && taskToPrint.Format.Width == 90
                && taskToPrint.Paper.Density <= 60)
            {
                printingPress = new ZirkonForta660(taskToPrint, getPathFolder);
            }

            //шинохара, если 84*108 формат и плотность  более 80 г/м2
            else if (taskToPrint.Format.Length == 84 && taskToPrint.Format.Width == 108
                && taskToPrint.Paper.Density > 80)
            {
                printingPress = new Shinohara52_2(taskToPrint, getPathFolder);
            }

            else if (taskToPrint.Format.Length == 60 && taskToPrint.Format.Width == 90
                && taskToPrint.Paper.Density > 200)
            {
                printingPress = new Shinohara52_2(taskToPrint, getPathFolder);
            }


            //роланд, если 70*100 формат и цветность больше 2+2
            //else if (taskToPrint.Format.Length == 70 && taskToPrint.Format.Width == 100 
            //    && taskToPrint.Colors.FrontColors >=2)
            //{
            //    printingPress = new Rapida(taskToPrint);
            //}

            //рапида для обложек - Хром-эрзац или для плотной бумаги
            else if (taskToPrint.Colors.Total() >= 4)
            {
                printingPress = new Rapida74_5(taskToPrint, getPathFolder);
            }

            else if(taskToPrint.Colors.ToString() == "0+0")
            {
                printingPress = new ZeroColorPress(taskToPrint);
            }
            else
                throw new Exception("не нашли подходящий станок для печати" + taskToPrint);

            return printingPress;

        }

    }
}
