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
        //public static PriceListHelper<T> Instance { get; private set; }

        //const string pathFolder = @"D:\MyApps\PrintingHouse\PrintingHouse.Domain\Data\";
        string pathFolder;

        public PriceListHelper(IGetPathFolder getPathFolder)
        {
            pathFolder = getPathFolder.GetPathFolder();
        }

        public PriceListHelper()
        {
            pathFolder = @"D:\MyApps\PrintingHouse\PrintingHouse.Domain\Data\";
        }

		public void WriteToFile(T priceList, string fileName)
		{
            string priceListJsonFile = JsonConvert.SerializeObject(priceList);



			//var json = new JavaScriptSerializer().Serialize(priceList);
			string path = Path.Combine(pathFolder, fileName + ".json");
			File.WriteAllText(path, priceListJsonFile);
		}

		public T ReadFromFile(string fileName)
		{
            #region How to load a text file embedded resource
            //var assembly = IntrospectionExtensions.GetTypeInfo(typeof(PriceListHelper<T>)).Assembly;
            //Stream stream = assembly.GetManifestResourceStream("PrintingHouse.Domain.Data." + fileName + ".json");

            //string textFromFile = "";
            //using (var reader = new System.IO.StreamReader(stream))
            //{
            //    textFromFile = reader.ReadToEnd();
            //}
            #endregion



            string path = Path.Combine(pathFolder, fileName + ".json");
            var priceListJsonFile = File.ReadAllText(path);
            //var serializer = new JavaScriptSerializer();



            T priceList = JsonConvert.DeserializeObject<T>(priceListJsonFile);
            //T priceList_Stream = JsonConvert.DeserializeObject<T>(textFromFile);
			return priceList;
		}

	}
}
