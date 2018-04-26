using PrintingHouse.Domain.Entities.PriceLists;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingHouse.Domain.Processes.BookAssembly
{
	public class Packaging
	{

		double pricePerUnit;

		int PrintRun { set; get; }
		public Packaging(TaskToPackage _taskToPackage)
		{
			if (_taskToPackage.BindingType == BindingType.SaddleStitching)
			{
				pricePerUnit = AssemblyPriceList.Packaging["PriceForStaple"];
			}
			else
			{
				pricePerUnit = AssemblyPriceList.Packaging["PriceForClue"];
			}
			PrintRun = _taskToPackage.PrintRun;
		}

		public double CalcCostOfPackaging()
		{
			return pricePerUnit * PrintRun;
		}

	}
}
