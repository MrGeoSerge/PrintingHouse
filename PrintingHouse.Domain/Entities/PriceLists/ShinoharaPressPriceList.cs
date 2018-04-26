using System;
using System.Collections.Generic;

namespace PrintingHouse.Domain.Entities.PriceLists
{
	//PressPrice - класс, где хранятся данные из прайса
	public static class ShinoharaPressPriceList
    {
        //4 параметра определяют прайс на печатную машину
        //стоимость изготовления формы (не зависит от тиража)
        static public double Form { set; get; }

        //приладка (зависит от цветности) - и от тиража, то есть, если технужды > 0, приладка = 0
        static public double Fitting { set; get; }

        //технужды в процентах зависят от тиража
        static public Dictionary<int, double> TechNeeds { set; get; }

        //стоимость оттисков зависит от тиража
        static public Dictionary<int, double> Impression { set; get; }


        static ShinoharaPressPriceList()
        {
            Form = 54.0;

            Fitting = 16;

            TechNeeds = new Dictionary<int, double>();
            TechNeeds.Add(200, 4.8);
            TechNeeds.Add(300, 4.6);
            TechNeeds.Add(400, 4.4);
            TechNeeds.Add(500, 4.2);
            TechNeeds.Add(900, 3.9);
            TechNeeds.Add(2000, 3.2);
            TechNeeds.Add(3000, 1.9);
            TechNeeds.Add(4000, 1.7);
            TechNeeds.Add(5000, 1.6);
            TechNeeds.Add(6000, 1.5);
            TechNeeds.Add(7000, 1.4);
            TechNeeds.Add(8000, 1.3);
            TechNeeds.Add(10000, 1.2);
            TechNeeds.Add(Int32.MaxValue, 1.1);

            Impression = new Dictionary<int, double>();
            Impression.Add(499, 0.095);
            Impression.Add(1999, 0.037);
            Impression.Add(4999, 0.029);
            Impression.Add(Int32.MaxValue, 0.026);


        }

    }


 













}
