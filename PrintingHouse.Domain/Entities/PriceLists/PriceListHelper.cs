using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using PrintingHouse.Domain.Interfaces;

namespace PrintingHouse.Domain.Entities.PriceLists
{
	public class PriceListHelper<T>
	{
        //public static PriceListHelper<T> Instance { get; private set; }

        //const string pathFolder = @"D:\MyApps\PrintingHouse\PrintingHouse.Domain\Data\";
        string pathFolder;

        public PriceListHelper(IGetPathFolder getPathFolder)
        {
            pathFolder = getPathFolder.GetPathFolder();
        }

		public void WriteToFile(T priceList, string fileName)
		{
            var priceListJsonFile = JsonConvert.SerializeObject(priceList);



			//var json = new JavaScriptSerializer().Serialize(priceList);
			string path = Path.Combine(pathFolder, fileName + ".json");
			File.WriteAllText(path, priceListJsonFile);
		}

		public T ReadFromFile(string fileName)
		{
			string path = Path.Combine(pathFolder, fileName + ".json");
			var priceListJsonFile = File.ReadAllText(path);
			//var serializer = new JavaScriptSerializer();
			T priceList = JsonConvert.DeserializeObject<T>(priceListJsonFile);
			return priceList;
		}

	}
}
