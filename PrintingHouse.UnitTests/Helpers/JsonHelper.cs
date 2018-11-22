using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.IO;

namespace PrintingHouse.UnitTests.Data
{
	public class JsonHelper<T> where T: class
	{
		const string pathFolder = @"D:\MyApps\PrintingHouse\PrintingHouse.UnitTests\Data\";
		const string shortPathFolder = @"D:\MyApps\PrintingHouse\PrintingHouse.UnitTests\";

		public static void WriteToFile(T results, string fileName)
		{
			var json = new JavaScriptSerializer().Serialize(results);
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

		public static T ReadFromFile(string folderName, string fileName)
		{
			string path = shortPathFolder + folderName + @"\" + fileName + ".json";
			var json = File.ReadAllText(path);
			var serializer = new JavaScriptSerializer();
			T priceList = serializer.Deserialize<T>(json);
			return priceList;
		}


	}
}
