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

		public void WriteToFile(T corosetPriceList, string fileName)
		{
			var json = new JavaScriptSerializer().Serialize(corosetPriceList);
			string path = @"D:\MyApps\PrintingHouse\PrintingHouse.Domain\Data\" + fileName + ".json";
			File.WriteAllText(path, json);
		}

		public T ReadFromFile(string fileName)
		{
			string path = @"D:\MyApps\PrintingHouse\PrintingHouse.Domain\Data\" + fileName + ".json";
			var json = File.ReadAllText(path);
            var serializer = new JavaScriptSerializer();
            T corosetPriceList1 = serializer.Deserialize<T>(json);
			return corosetPriceList1;
		}
	}
}
