using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingHouse.Domain.Processes.BookAssembly
{
	class Packaging
	{
		public class Packaging
		{


			double pricePerUnit;

			int PrintRun { set; get; }
			public Packaging(TaskToPackage _taskToPackage)
			{
				if (_taskToPackage.BindingType == BindingType.SaddleStitching)
				{
					pricePerUnit = Price.Packaging["PriceForStaple"];
				}
				else
				{
					pricePerUnit = Price.Packaging["PriceForClue"];
				}
				PrintRun = _taskToPackage.PrintRun;
			}

			public double CalcCostOfPackaging()
			{
				return pricePerUnit * PrintRun;
			}

		}
	}
