using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.IO;
namespace PrintingHouse.Domain.Entities.PriceLists
{
	public class PriceListHelper<T>
	{
		const string pathFolder = @"D:\MyApps\PrintingHouse\PrintingHouse.Domain\Data\";

		public static void WriteToFile(T priceList, string fileName)
		{
			var json = new JavaScriptSerializer().Serialize(priceList);
			string path = pathFolder + fileName + ".json";
			File.WriteAllText(path, json);
		}

		public static T ReadFromFile(string fileName)
		{
			string path = pathFolder + fileName + ".json";
			var json = File.ReadAllText(path);
			var serializer = new JavaScriptSerializer();
			T priceList = serializer.Deserialize<T>(json);
			return priceList;
		}

		//public CorosetPriceList ReadFromFile(string v)
		//{
		//	throw new NotImplementedException();
		//}
	}
}
