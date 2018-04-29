using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace PrintingHouse.Domain.Entities.PriceLists
{
	public class RapidaPriceList
	{
		//4 параметра определяют прайс на печатную машину
		//стоимость изготовления формы (не зависит от тиража)
		public double Form { set; get; }

		//приладка (зависит от цветности) - и от тиража, то есть, если технужды > 0, приладка = 0
		public Dictionary<string, double> Fitting { set; get; }

		//технужды в процентах зависят от тиража
		public Dictionary<string, double> TechNeeds { set; get; }

		//стоимость оттисков зависит от тиража
		public Dictionary<string, double> Impression { set; get; }


		public RapidaPriceList()
		{
			Fitting = new Dictionary<string, double>();
			TechNeeds = new Dictionary<string, double>();
			Impression = new Dictionary<string, double>();
		}

		public void WriteInitialDataToFile()
		{
			Form = 108.0;

			Fitting.Add("4+0", 300);
			Fitting.Add("4+1", 300);
			Fitting.Add("2+2", 300);
			Fitting.Add("4+2", 350);
			Fitting.Add("4+4", 350);

			TechNeeds.Add(2999.ToString(), 0);
			TechNeeds.Add(1000000.ToString(), 8.0);

			Impression.Add(999.ToString(), 0.132);
			Impression.Add(2999.ToString(), 0.059);
			Impression.Add(4999.ToString(), 0.050);
			Impression.Add(9999.ToString(), 0.037);
			Impression.Add(1000000.ToString(), 0.037);
		}

	}
}
