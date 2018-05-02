﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrintingHouse.Domain.Entities.PriceLists;
using PrintingHouse.UnitTests.VerificationResults;
using PrintingHouse.UnitTests.Data;

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
			//RapidaPriceList rapidaPriceList = new RapidaPriceList();
			//rapidaPriceList.SetDefaultData();
			//PriceListHelper<RapidaPriceList>.WriteToFile(rapidaPriceList, "RapidaPriceList");
			#endregion

			#region Shinohara Write to JSON file
			//ShinoharaPriceList shinoharaPriceList = new ShinoharaPriceList();
			//shinoharaPriceList.SetDefaultData();
			//PriceListHelper<ShinoharaPriceList>.WriteToFile(shinoharaPriceList, "ShinoharaPriceList");
			#endregion

			#region Zirkon Write to JSON file
			//ZirkonPriceList zirkonPriceList = new ZirkonPriceList();
			//zirkonPriceList.SetDefaultData();
			//PriceListHelper<ZirkonPriceList>.WriteToFile(zirkonPriceList, "ZirkonPriceList");
			#endregion

			#region Read PriceList from JSON file
			//CorosetPriceList corosetPriceList = PriceListHelper<CorosetPriceList>.ReadFromFile("CorosetPriceList");
			#endregion

			#region WriteCoroset Results to Json for using in Unit Tests
			//CorosetResult corosetResult = new CorosetResult();
			//JsonHelper<CorosetResult>.WriteToFile(corosetResult, "CorosetResult");
			#endregion

			#region Write Shinohara Results to Json for using in Unit Tests
			//ShinoharaResult shinoharaResult = new ShinoharaResult();
			//JsonHelper<ShinoharaResult>.WriteToFile(shinoharaResult, "ShinoharaResult");
			#endregion

			#region Write Rapida74_5_60_90_CoverResult to Json for using in Unit Tests
			JsonHelper<Zirkon_70_90_IBResultForJsonCreation>
				.WriteToFile(new Zirkon_70_90_IBResultForJsonCreation(), "Zirkon_70_90_IBResult");
			#endregion

			//Console.ReadKey();
		}
	}
}
