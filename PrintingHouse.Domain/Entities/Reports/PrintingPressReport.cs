using System;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Entities.PrintingPresses.Abstract;

namespace PrintingHouse.Domain.PrintingPresses
{
	//отчет Печатного станка
	public class PressReport
    {
        public PrintingPress press;

        public PressReport(PrintingPress press)
        {
            this.press = press;
        }
        public double GetCostOfPolygraphy()
        {
            return press.GetCostOfPrinting();
        }

        #region Расчет расхода бумаги
        //---------Расчет расхода бумаги для списания------------
        public double GetPaperExpenditure() //в килограммах или в листах в зависимости от типа бумаги
        {
            if (press.TaskToPrint.Paper is PaperInKg)
            {
                return GetPaperConsumptionInKg();
            }
            return GetPaperConsumptionInRawSheets();
        }

        public double GetSquareOfSheetInMeters2()
        {
            RolledPress rolledPress = press as RolledPress;

            return (double)press.PressSheetFormat.Length / 100 *
                rolledPress.Cutting;
        }
        public double GetPaperInSquareMeters()
        {
            return GetSquareOfSheetInMeters2() * press.GetTotalPaperConsumptionInPressFormat();
        }

        public double GetPaperConsumptionInKg()
        {
            //округляемм вверх до двух знаков после запятой
            //paperConsumptionInKg = Math.Ceiling(paperConsumptionInKg * 100) / 100;

            return Math.Round((double)(GetPaperInSquareMeters() *
                press.TaskToPrint.Paper.Density / 1000), 2);
        }

        //для листовой
        public int GetPaperConsumptionInRawSheets()
        {
            return (int)Math.Ceiling((double)press.GetTotalPaperConsumptionInPressFormat() /
                GetNumberOfPrintSheetsInRawSheet());
        }
        public int GetNumberOfPrintSheetsInRawSheet()
        {
            PaperInSheets printingSheet = press.TaskToPrint.Paper as PaperInSheets;
            return printingSheet.GetNumberOfPrintSheetsInRawSheet(press.GetPressSheetsFormat());

        }

        ////количество листов формата оборудования на одном листе сырья
        ////считаем площадь листов и делим
        //public int GetNumberOfPrintSheetsInRawSheet()
        //{
        //    PaperInSheets printingSheet = press.TaskToPrint.Paper as PaperInSheets;
        //    SheetSizeInSM pressFormat = press.GetPressSheetsFormat().GetSheetSizeInSM();
        //    SheetSizeInSM sheetFormat = printingSheet.GetSheetSizeInSM();

        //    //проверяем 
        //    if (IsRawSheetDivisionSucceded(pressFormat, sheetFormat))
        //    {
        //        if (GetPressSheetsOnRawSheet(pressFormat, sheetFormat) >
        //            GetPressSheetsOnRawSheetTurned(pressFormat, sheetFormat))
        //            return GetPressSheetsOnRawSheet(pressFormat, sheetFormat);
        //        else
        //            GetPressSheetsOnRawSheetTurned(pressFormat, sheetFormat);

        //    }

        //    //количество листов печати на листе сырья


        //    throw new Exception("не удалось разделить лист");
        //}

        //public int GetPressSheetsOnRawSheet(SheetSizeInSM _pressFormat, SheetSizeInSM _sheetFormat)
        //{

        //    if (_sheetFormat.lengthInSM > _pressFormat.lengthInSM &&
        //      _sheetFormat.widthInSM > _pressFormat.widthInSM)
        //    {
        //        return (_sheetFormat.lengthInSM / _pressFormat.lengthInSM) *
        //                (_sheetFormat.widthInSM / _pressFormat.widthInSM);
        //    }
        //    else
        //        return 0;

        //}

        //public int GetPressSheetsOnRawSheetTurned(SheetSizeInSM _pressFormat, SheetSizeInSM _sheetFormat)
        //{

        //    if (_sheetFormat.widthInSM > _pressFormat.lengthInSM &&
        //      _sheetFormat.lengthInSM > _pressFormat.widthInSM)
        //    {
        //        return (_sheetFormat.widthInSM / _pressFormat.lengthInSM) *
        //                (_sheetFormat.lengthInSM / _pressFormat.widthInSM);
        //    }
        //    else
        //        return 0;

        //}

        ////получилось ли разделить лист сырья на листы формата печатного оборудования
        //public bool IsRawSheetDivisionSucceded(SheetSizeInSM _pressFormat, SheetSizeInSM _sheetFormat)
        //{
        //    if (GetPressSheetsOnRawSheet(_pressFormat, _sheetFormat) != 0
        //        || GetPressSheetsOnRawSheetTurned(_pressFormat, _sheetFormat) != 0)
        //    {
        //        return false;
        //    }
        //    else
        //        return true;
        //}

        public double GetPaperCost()
        {
            return Math.Round((double)GetPaperExpenditure() * press.TaskToPrint.Paper.Price, 2);
        }

        public double GetTotalCost()
        {
            return GetCostOfPolygraphy() + GetPaperCost();
        }


        #endregion

        public void ShowDetailedReport()
        {
            Console.WriteLine(press.TaskToPrint.Name);
            Console.WriteLine("Расход бумаги для списания: " +
                GetPaperExpenditure() + " " + press.TaskToPrint.Paper.Unit);
            Console.WriteLine("Цена " + press.TaskToPrint.Paper.Price + " " + press.TaskToPrint.Paper.Unit);
            Console.WriteLine("Стоимость бумаги: " + GetPaperCost());
            Console.WriteLine("Количество оттисков: " + press.GetImpressions());
            Console.WriteLine("Стоимость оттиска: " + press.GetImpressionPriceValue());
            Console.WriteLine("Общая стоимость форм: " + press.GetCostOfPrintingFoms());
            Console.WriteLine("Стоимость оттисков: " + press.GetCostOfImpressions());
            Console.WriteLine("Общая сумма за печать: " + GetCostOfPolygraphy());
            Console.WriteLine("Всего затрат: " + GetTotalCost());
            Console.WriteLine("");
        }
    }
}
