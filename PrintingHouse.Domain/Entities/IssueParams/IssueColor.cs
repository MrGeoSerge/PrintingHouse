using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingHouse.Domain.IssueParams
{
	//цветность издания 1+1, 2+1 и т. д.
	public class IssueColors
	{
		int frontColors;

		public int FrontColors {
			set {
				if (value >= 0 && value <= 4)
					frontColors = value;
				else throw new Exception("wrong front colors number");
			}
			get {
				return frontColors;
			}
		}

		int backColors;

		public int BackColors {
			set {
				if (value >= 0 && value <= 4)
					backColors = value;
				else throw new Exception("wrong back colors number");
			}
			get {
				return backColors;
			}
		}


		public IssueColors()
		{
			FrontColors = 1;
			BackColors = 1;
		}

		public IssueColors(int frontColors, int backColors)
		{
			try
			{
				FrontColors = frontColors;
				BackColors = backColors;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

		}
		public IssueColors(IssueColors colors)
		{
			FrontColors = colors.FrontColors;
			BackColors = colors.BackColors;
		}

		public IssueColors(string _colors)
		{
			string[] parameters = _colors.Split('+', '/');
			FrontColors = Int32.Parse(parameters[0]);
			BackColors = Int32.Parse(parameters[1]);
		}

		public override string ToString()
		{
			return FrontColors + "+" + BackColors;
		}

		public int Total()
		{
			return FrontColors + BackColors;
		}


		//перегрузка оператора равно
		public static bool operator ==(IssueColors issue1, IssueColors issue2)
		{
			return issue1.FrontColors == issue2.FrontColors
				&& issue1.BackColors == issue2.BackColors;
		}

		public static bool operator !=(IssueColors issue1, IssueColors issue2)
		{
			return !(issue1 == issue2);
		}


		public override bool Equals(object obj)
		{
			if (!(obj is IssueColors))
				return false;
			return this == (IssueColors)obj;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

	}
}
