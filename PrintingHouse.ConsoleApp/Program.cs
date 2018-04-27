﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrintingHouse.Domain.Entities.PriceLists;

namespace PrintingHouse.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{

			#region CreateAndWrite to JSON files
			//var corosetPriceList = new CorosetPriceList();
			//var priceListHelper = new PriceListHelper();
			//priceListHelper.WriteToFile(corosetPriceList, "Coroset");
			#endregion

			#region
			//var corosetPriceList = new CorosetPriceList();
			var priceListHelper = new PriceListHelper<CorosetPriceList>();
			CorosetPriceList corosetPriceList = priceListHelper.ReadFromFile("CorosetPriceList");
			#endregion

			Console.ReadKey();
		}
	}
}