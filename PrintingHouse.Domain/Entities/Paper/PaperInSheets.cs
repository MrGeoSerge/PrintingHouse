using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingHouse.Domain.Paper
{
	public class PaperInSheets : AbstractPaper
	{
		//длина листа
		int sheetLength;
		public int SheetLength {
			get {
				return sheetLength;
			}

			set {
				sheetLength = value;
			}
		}

		//ширина листа
		int sheetWidth;
		public int SheetWidth {
			get {
				return sheetWidth;
			}

			set {
				sheetWidth = value;
			}
		}



		////масса одного листа
		//double oneSheetWeightInKg;
		//public double OneSheetWeightInKg
		//{
		//    get
		//    {
		//        return oneSheetWeightInKg;
		//    }

		//    set
		//    {
		//        oneSheetWeightInKg = value;
		//    }
		//}

		public SheetSizeInSM sheetFormat;


		//в конструкторе по умолчанию считаем, 
		//что это стандартная бумага на обложку
		//Картон целлюлозный плотность 230г/м2 64см * 90 см 
		public PaperInSheets()
		{
			Kind = PaperType.FoldingBoxboard;
			Density = 230;
			Price = 4.2333;
			Unit = PaperUnit.sheet;
			Manufacturer = "";
			SheetLength = 64;
			SheetWidth = 90;
			sheetFormat = GetSheetSizeInSM();
		}

		public PaperInSheets(PaperType kind, int density, double price,
			string manufacturer, int sheetLength, int sheetWidth)
		{
			this.Kind = kind;
			this.Density = density;
			this.Price = price;
			this.Manufacturer = manufacturer;
			this.SheetLength = sheetLength;
			this.SheetWidth = sheetWidth;
			Unit = PaperUnit.sheet;
			sheetFormat = GetSheetSizeInSM();
		}

		public PaperInSheets(PaperInSheets paper)
		{
			this.Kind = paper.Kind;
			this.Density = paper.Density;
			this.Price = paper.Price;
			this.Manufacturer = paper.Manufacturer;
			this.SheetLength = paper.SheetLength;
			this.SheetWidth = paper.SheetWidth;
			Unit = PaperUnit.sheet;
			sheetFormat = GetSheetSizeInSM();
		}

		public SheetSizeInSM GetSheetSizeInSM()
		{
			return new SheetSizeInSM(SheetLength, SheetWidth);
		}

		//разделение листа сырья RawSheet на лист формата оборудования
		//количество листов формата оборудования на одном листе сырья
		//считаем площадь листов и делим
		public int GetNumberOfPrintSheetsInRawSheet(IssueFormat _pressFormat)
		{
			//PaperInSheets printingSheet = press.TaskToPrint.Paper as PaperInSheets;
			SheetSizeInSM pressFormat = _pressFormat.GetSheetSizeInSM();
			//SheetSizeInSM sheetFormat = printingSheet.GetSheetSizeInSM();

			//количество листов печати на листе сырья
			if (IsRawSheetDivisionSucceded(pressFormat, sheetFormat))
			{
				if (GetPressSheetsOnRawSheet(pressFormat, sheetFormat) >
					GetPressSheetsOnRawSheetTurned(pressFormat, sheetFormat))
					return GetPressSheetsOnRawSheet(pressFormat, sheetFormat);
				else
					return GetPressSheetsOnRawSheetTurned(pressFormat, sheetFormat);

			}
			throw new Exception("не удалось разделить лист");
		}

		public int GetPressSheetsOnRawSheet(SheetSizeInSM _pressFormat, SheetSizeInSM _sheetFormat)
		{

			if (_sheetFormat.lengthInSM >= _pressFormat.lengthInSM &&
			  _sheetFormat.widthInSM >= _pressFormat.widthInSM)
			{
				return (_sheetFormat.lengthInSM / _pressFormat.lengthInSM) *
						(_sheetFormat.widthInSM / _pressFormat.widthInSM);
			}
			else
				return 1;

		}

		public int GetPressSheetsOnRawSheetTurned(SheetSizeInSM _pressFormat, SheetSizeInSM _sheetFormat)
		{

			if (_sheetFormat.widthInSM >= _pressFormat.lengthInSM &&
			  _sheetFormat.lengthInSM >= _pressFormat.widthInSM)
			{
				return (_sheetFormat.widthInSM / _pressFormat.lengthInSM) *
						(_sheetFormat.lengthInSM / _pressFormat.widthInSM);
			}
			else
				//единица означает, что лист сырья меньше листа печатного оборудования
				//то есть перед печатью его резать не надо
				return 1;

		}

		//получилось ли разделить лист сырья на листы формата печатного оборудования
		public bool IsRawSheetDivisionSucceded(SheetSizeInSM _pressFormat, SheetSizeInSM _sheetFormat)
		{
			if (GetPressSheetsOnRawSheet(_pressFormat, _sheetFormat) != 0
				|| GetPressSheetsOnRawSheetTurned(_pressFormat, _sheetFormat) != 0)
			{
				return true;
			}
			else
				return false;
		}
	}
}

