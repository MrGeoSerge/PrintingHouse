using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingHouse.Domain.Entities.Reports
{
	class AssemblyReport
	{
		public double CostOfBinding { set; get; }

		public double CostOfPerforation { set; get; }

		public double CostOfLamination { set; get; }

		public double CostOfPackaging { set; get; }

		public double TotalCostOfAssembly { set; get; }

		public void AddCostOfBinding(double _costOfBinding)
		{
			CostOfBinding = _costOfBinding;
		}

		public void AddCostOfPerforation(double _costOfPerforation)
		{
			CostOfPerforation = _costOfPerforation;
		}

		public void AddCostOfLamination(double _costOfLamination)
		{
			CostOfLamination = _costOfLamination;
		}

		public void AddCostOfPackaging(double _costOfPackaging)
		{
			CostOfPackaging = _costOfPackaging;
		}



		public void CalcTotalCostOfAssembly()
		{
			TotalCostOfAssembly = CostOfBinding + CostOfPerforation + CostOfLamination + CostOfPackaging;
		}

		public void ShowDetailedReport()
		{
			Console.WriteLine();
			Console.WriteLine("Отчет о сборке:");
			Console.WriteLine($"Стоимость переплета: {CostOfBinding}");
			Console.WriteLine($"Стоимость перфорации: {CostOfPerforation}");
			Console.WriteLine($"Стоимость ламинации: {CostOfLamination}");
			Console.WriteLine($"Стоимость упаковки: {CostOfPackaging}");
			Console.WriteLine($"Общая стоимость за сборку: {TotalCostOfAssembly}");
		}
	}
}
}
