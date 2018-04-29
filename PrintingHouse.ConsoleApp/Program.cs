using System;
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

			#region Coroset CreateAndWrite to JSON files
			//var corosetPriceList = new CorosetPriceList();
			//var priceListHelper = new PriceListHelper();
			//priceListHelper.WriteToFile(corosetPriceList, "Coroset");
			#endregion

			#region Rapida CreateAndWrite to JSON files
			RapidaPriceList rapidaPriceList = new RapidaPriceList();
			rapidaPriceList.WriteInitialDataToFile();
			PriceListHelper<RapidaPriceList>.WriteToFile(rapidaPriceList, "RapidaPriceList");
			#endregion

			#region Read PriceList from JSON file
			//CorosetPriceList corosetPriceList = PriceListHelper<CorosetPriceList>.ReadFromFile("CorosetPriceList");
			#endregion

			Console.ReadKey();
		}
	}
}
