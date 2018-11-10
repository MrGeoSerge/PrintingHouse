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

        //стоимость оттисков зависит от тиража и цветности
        public List<Impression> Impressions { set; get; }

        //новое в прайсе 2018 года: при тираже от 1 до 2000 стоимость печати фиксированная
        public int PrintRun_UpToWhichFixedPrintingCostApplyed { set; get; }
        public double FixedPrintingCost { set; get; }


        public ZirkonPriceList()
		{
			TechNeeds = new Dictionary<string, double>();
            Impressions = new List<Impression>();
        }

        public void SetDefaultData()
		{
			Form = 90;
			Fitting = 400;

			TechNeeds.Add("1+1", 4.7);
			TechNeeds.Add("2+2", 1.2);//+1.2% на каждый доп. цвет

            PrintRun_UpToWhichFixedPrintingCostApplyed = 2000;
            FixedPrintingCost = 280.0;

            Impressions.Add(
                new Impression
                {
                    LowerPrintRunBound = 2001,
                    UpperPrintRunBound = 3000,
                    ImpressionCost = 0.1400,
                    SurplusForAdditionalColor = 0.0215
                });

            Impressions.Add(
                new Impression
                {
                    LowerPrintRunBound = 3001,
                    UpperPrintRunBound = 4000,
                    ImpressionCost = 0.1200,
                    SurplusForAdditionalColor = 0.0215
                });

            Impressions.Add(
                new Impression
                {
                    LowerPrintRunBound = 4001,
                    UpperPrintRunBound = 5000,
                    ImpressionCost = 0.1000,
                    SurplusForAdditionalColor = 0.0215
                });

            Impressions.Add(
                new Impression
                {
                    LowerPrintRunBound = 5001,
                    UpperPrintRunBound = 6000,
                    ImpressionCost = 0.0800,
                    SurplusForAdditionalColor = 0.0215
                });

            Impressions.Add(
                new Impression
                {
                    LowerPrintRunBound = 6001,
                    UpperPrintRunBound = 7000,
                    ImpressionCost = 0.0700,
                    SurplusForAdditionalColor = 0.0215
                });

            Impressions.Add(
                new Impression
                {
                    LowerPrintRunBound = 7001,
                    UpperPrintRunBound = int.MaxValue,
                    ImpressionCost = 0.0600,
                    SurplusForAdditionalColor = 0.05
                });

        }
    }
}
