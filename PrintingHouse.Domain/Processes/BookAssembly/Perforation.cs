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
	public class Perforation
	{
		PerforationType perforationType;
		int printRun;
		BindingType bindingType;
		int pagesNumber;

		public Perforation(TaskToPerforation _taskToPerforation)
		{
			perforationType = _taskToPerforation.PerforationType;
			printRun = _taskToPerforation.PrintRun;
			bindingType = _taskToPerforation.BindingType;
			pagesNumber = _taskToPerforation.PagesNumber;
		}

		public double CalcCostOfPerforation()
		{
			double pricePerUnit;
			if (bindingType == BindingType.SaddleStitching)
			{
				switch (perforationType)
				{
					case PerforationType.usual:
						{
							pricePerUnit = AssemblyPriceList.Perforation["Staple_First_48pages_Block"] +
								(Math.Ceiling((double)(pagesNumber - 48)
								/ AssemblyPriceList.Perforation["PagesInBlock"])
								* AssemblyPriceList.Perforation["Staple_additional_16pages_Block"]);
						}
						break;
					case PerforationType.simplified:
						{
							pricePerUnit = AssemblyPriceList.Perforation["Simplified_Staple_First_48pages_Block"] +
								(Math.Ceiling((double)(pagesNumber - 48) / AssemblyPriceList.Perforation["PagesInBlock"])
								* AssemblyPriceList.Perforation["Simplified_Staple_additional_16pages_Block"]);
						}
						break;
					default:
						pricePerUnit = 0;
						break;
				}
			}
			else if (bindingType == BindingType.PerfectBinding)
			{
				switch (perforationType)
				{
					case PerforationType.usual:
						{
							pricePerUnit = (Math.Ceiling((double)(pagesNumber)
								/ AssemblyPriceList.Perforation["PagesInBlock"])
								* AssemblyPriceList.Perforation["Clue_forEach16pages_Block"]);
						}
						break;
					case PerforationType.simplified:
						{
							pricePerUnit = (Math.Ceiling((double)(pagesNumber)
								/ AssemblyPriceList.Perforation["PagesInBlock"])
								* AssemblyPriceList.Perforation["Simplified_Clue_forEach16pages_Block"]);
						}
						break;
					default:
						pricePerUnit = 0;
						break;
				}
			}
			else
				throw new Exception("для этого переплета перфорация неприменима");


			return pricePerUnit * printRun;
		}

	}
}
