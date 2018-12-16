using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using PrintingHouse.Domain.Interfaces;
using System.Reflection;

namespace PrintingHouse.Domain.Entities.PriceLists
{
	public class PriceListHelper<T>
	{
        string pathFolder;

        public PriceListHelper(IGetPathFolder getPathFolder)
        {
            pathFolder = getPathFolder.GetPathFolder();
        }

        //public PriceListHelper()
        //{
        //    pathFolder = @"D:\MyApps\PrintingHouse\PrintingHouse.Domain\Data\";
        //}

		public void WriteToFile(T priceList, string fileName)
		{
            string priceListJsonFile = JsonConvert.SerializeObject(priceList);
			string path = Path.Combine(pathFolder, fileName + ".json");
			File.WriteAllText(path, priceListJsonFile);
		}

		public T ReadFromFile(string fileName)
		{
            string path = Path.Combine(pathFolder, fileName + ".json");
            var priceListJsonFile = File.ReadAllText(path);

            T priceList = JsonConvert.DeserializeObject<T>(priceListJsonFile);
			return priceList;
		}

	}
}
