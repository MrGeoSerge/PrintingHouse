using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PrintingHouse.Domain.Entities.PriceLists
{
	public static class PriceList
	{
		public static string ToJSON(this CorosetPressPriceList priceList)
		{
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			return serializer.Serialize(priceList);
		}
	}
}
