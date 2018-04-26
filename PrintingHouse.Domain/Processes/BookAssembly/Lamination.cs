using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingHouse.Domain.Processes.BookAssembly
{
	public class Lamination
	{
		private TaskToLamination TaskToLamination { get; }

		public Lamination(TaskToLamination _tastToLamination)
		{
			TaskToLamination = _tastToLamination;
		}

		public double CalcCost()
		{
			double pricePerUnit;
			if (TaskToLamination.LaminationType == LaminationType.Glossy)
			{
				switch (TaskToLamination.LaminationFormat)
				{
					case PaperFormat.A1:
						pricePerUnit = Price.Lamination["A1_Glossy"];
						break;
					case PaperFormat.A2:
						pricePerUnit = Price.Lamination["A2_Glossy"];
						break;
					case PaperFormat.A3:
						pricePerUnit = Price.Lamination["A3_Glossy"];
						break;
					case PaperFormat.A4:
						pricePerUnit = Price.Lamination["A4_Glossy"];
						break;
					default:
						throw new Exception("неверный формат ламинации");
				}
			}
			else if (TaskToLamination.LaminationType == LaminationType.Matte)
			{
				switch (TaskToLamination.LaminationFormat)
				{
					case PaperFormat.A1:
						pricePerUnit = Price.Lamination["A1_Matte"];
						break;
					case PaperFormat.A2:
						pricePerUnit = Price.Lamination["A2_Matte"];
						break;
					case PaperFormat.A3:
						pricePerUnit = Price.Lamination["A3_Matte"];
						break;
					case PaperFormat.A4:
						pricePerUnit = Price.Lamination["A4_Matte"];
						break;
					default:
						throw new Exception("неверный формат ламинации");
				}
			}
			else
				throw new Exception("ламинация не была задана");
			return pricePerUnit * TaskToLamination.PrintRun;
		}
	}
}
