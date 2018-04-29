using System;
using System.Collections.Generic;

namespace PrintingHouse.Domain.Entities.PriceLists
{
	//PressPrice - класс, где хранятся данные из прайса
	public class ShinoharaPriceList
	{
		//4 параметра определяют прайс на печатную машину
		//стоимость изготовления формы (не зависит от тиража)
		public double Form { set; get; }

		//приладка (зависит от цветности) - и от тиража, то есть, если технужды > 0, приладка = 0
		public double Fitting { set; get; }

		//технужды в процентах зависят от тиража
		public Dictionary<string, double> TechNeeds { set; get; }

		//стоимость оттисков зависит от тиража
		public Dictionary<string, double> Impression { set; get; }


		public ShinoharaPriceList()
		{
			TechNeeds = new Dictionary<string, double>();
			Impression = new Dictionary<string, double>();
		}

		public void SetDefaultDataWithouFile()
		{
			Form = 54.0;
			Fitting = 16;

			TechNeeds.Add(200.ToString(), 4.8);
			TechNeeds.Add(300.ToString(), 4.6);
			TechNeeds.Add(400.ToString(), 4.4);
			TechNeeds.Add(500.ToString(), 4.2);
			TechNeeds.Add(900.ToString(), 3.9);
			TechNeeds.Add(2000.ToString(), 3.2);
			TechNeeds.Add(3000.ToString(), 1.9);
			TechNeeds.Add(4000.ToString(), 1.7);
			TechNeeds.Add(5000.ToString(), 1.6);
			TechNeeds.Add(6000.ToString(), 1.5);
			TechNeeds.Add(7000.ToString(), 1.4);
			TechNeeds.Add(8000.ToString(), 1.3);
			TechNeeds.Add(10000.ToString(), 1.2);
			TechNeeds.Add(1000000.ToString(), 1.1);

			Impression.Add(499.ToString(), 0.095);
			Impression.Add(1999.ToString(), 0.037);
			Impression.Add(4999.ToString(), 0.029);
			Impression.Add(1000000.ToString(), 0.026);
		}

	}


 













}
