using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingHouse.Domain.Entities.PriceLists
{
	public class CorosetPriceList
	{
		//4 параметра определяют прайс на печатную машину
		//стоимость изготовления формы (не зависит от тиража)
		public double Form { set; get; }

		//приладка (зависит от цветности) - и от тиража, то есть, если технужды > 0, приладка = 0
		public int Fitting { set; get; }

		//технужды в процентах зависят от цветности
		public Dictionary<string, double> TechNeeds { set; get; }

		//стоимость оттисков зависит от цветности
		public Dictionary<string, double> Impression { set; get; }

		public CorosetPriceList()
		{
			TechNeeds = new Dictionary<string, double>();
			Impression = new Dictionary<string, double>();
		}
		public void WriteInitialDataToFile()
		{
			Form = 126;
			Fitting = 400;

			TechNeeds.Add("1+1", 4.7);
			TechNeeds.Add("2+2", 1.2);//+1.2% на каждый доп. цвет

			Impression.Add("1+1", 0.0735);
			Impression.Add("2+2", 0.035);//+0.0174 на каждый доп. цвет
		}
	}
}
