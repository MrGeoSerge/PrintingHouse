using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingHouse.Domain.BookAssembly
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
							pricePerUnit = Price.Perforation["Staple_First_48pages_Block"] +
								(Math.Ceiling((double)(pagesNumber - 48)
								/ Price.Perforation["PagesInBlock"])
								* Price.Perforation["Staple_additional_16pages_Block"]);
						}
						break;
					case PerforationType.simplified:
						{
							pricePerUnit = Price.Perforation["Simplified_Staple_First_48pages_Block"] +
								(Math.Ceiling((double)(pagesNumber - 48) / Price.Perforation["PagesInBlock"])
								* Price.Perforation["Simplified_Staple_additional_16pages_Block"]);
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
								/ Price.Perforation["PagesInBlock"])
								* Price.Perforation["Clue_forEach16pages_Block"]);
						}
						break;
					case PerforationType.simplified:
						{
							pricePerUnit = (Math.Ceiling((double)(pagesNumber)
								/ Price.Perforation["PagesInBlock"])
								* Price.Perforation["Simplified_Clue_forEach16pages_Block"]);
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
