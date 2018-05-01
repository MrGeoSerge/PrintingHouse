using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace PrintingHouse.Domain.Entities.PriceLists
{
	//PressPrice - класс, где хранятся данные из прайса
	//ZirkonForta660

	public class ZirkonPriceList
	{
		//4 параметра определяют прайс на печатную машину
		//стоимость изготовления формы (не зависит от тиража)
		public double Form { set; get; }

		//приладка 
		public int Fitting { set; get; }

		//технужды в процентах зависят от цветности
		public Dictionary<string, double> TechNeeds { set; get; }

		//стоимость оттисков зависит от цветности
		public Dictionary<string, double> Impression { set; get; }

		public ZirkonPriceList()
		{
			TechNeeds = new Dictionary<string, double>();
			Impression = new Dictionary<string, double>();
		}

		public void SetDefaultData()
		{
			Form = 90;
			Fitting = 400;

			TechNeeds.Add("1+1", 4.7);
			TechNeeds.Add("2+2", 1.2);//+1.2% на каждый доп. цвет

			Impression.Add("1+1", 0.0367);
			Impression.Add("2+2", 0.0174);//+0.0174 на каждый доп. цвет
		}
	}
}
