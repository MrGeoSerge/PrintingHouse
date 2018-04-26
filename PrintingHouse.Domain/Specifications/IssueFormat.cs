using System;

namespace PrintingHouse.Domain.Specifications
{
	public class IssueFormat
	{
		int length; //в см
		public int Length {
			set {
				if (value == 60 || value == 84 || value == 70)
					length = value;
				else throw new Exception("wrong length");
			}
			get {
				return length;
			}
		}

		int width; //в см
		public int Width {
			set {
				if (value == 84 || value == 90 || value == 100 || value == 108)
					width = value;
				else throw new Exception("wrong width");
			}
			get {
				return width;
			}
		}


		int fraction;//доля
		public int Fraction {
			set {
				if (value == 32 || value == 16 || value == 8 || value == 4 || value == 2 || value == 1)
					fraction = value;
				else throw new Exception("wrong fraction");
			}
			get {
				return fraction;
			}
		}


		//конструктор по умолчанию
		public IssueFormat()
		{
			length = 60;
			width = 90;
			fraction = 16;
		}

		public IssueFormat(int length, int width, int fraction)
		{
			try
			{
				this.Length = length;
				this.Width = width;
				this.Fraction = fraction;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

		}

		//конструктор через IssueFormat
		public IssueFormat(IssueFormat format)
		{
			this.Length = format.Length;
			this.Width = format.Width;
			this.Fraction = format.Fraction;
		}

		public IssueFormat(string _format)
		{
			string[] parameters = _format.Split('*', '/');
			Length = Int32.Parse(parameters[0]);
			Width = Int32.Parse(parameters[1]);
			Fraction = Int32.Parse(parameters[2]);

		}

		public string PrintingSheet()
		{
			return Length + "*" + Width;
		}

		public override string ToString()
		{
			return Length + "*" + Width + "/" + Fraction;
		}

		public SheetSizeInSM GetSheetSizeInSM()
		{
			int _length = length;
			int _width = width;
			int _fraction = fraction;

			//вычисление размера листа печатного оборудования
			while (_fraction != 1)
			{
				if (_length > _width)
				{
					_length /= 2;

				}
				else
				{
					_width /= 2;
				}
				_fraction /= 2;
			}
			return new SheetSizeInSM(_length, _width);
		}
	}
}
