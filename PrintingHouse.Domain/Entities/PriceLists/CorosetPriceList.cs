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

        //стоимость оттисков зависит от тиража и цветности
        public List<Impression> Impressions { set; get; }

        //новое в прайсе 2018 года: при тираже от 1 до 2000 стоимость печати фиксированная
        public int PrintRun_UpToWhichFixedPrintingCostApplyed { set; get; }
        public double FixedPrintingCost { set; get; }

        public CorosetPriceList()
		{
			TechNeeds = new Dictionary<string, double>();
            Impressions = new List<Impression>();
        }

        public void SetDefaultData()
		{
			Form = 126;
			Fitting = 400;

			TechNeeds.Add("1+1", 4.7);
			TechNeeds.Add("2+2", 1.2);//+1.2% на каждый доп. цвет

            PrintRun_UpToWhichFixedPrintingCostApplyed = 2000;
            FixedPrintingCost = 480.0;

            Impressions.Add(
                new Impression
                {
                    LowerPrintRunBound = 2001,
                    UpperPrintRunBound = 3000,
                    ImpressionCost = 0.2400,
                    SurplusForAdditionalColor = 0.0429
                });

            Impressions.Add(
                new Impression
                {
                    LowerPrintRunBound = 3001,
                    UpperPrintRunBound = 4000,
                    ImpressionCost = 0.2200,
                    SurplusForAdditionalColor = 0.0429
                });

            Impressions.Add(
                new Impression
                {
                    LowerPrintRunBound = 4001,
                    UpperPrintRunBound = 5000,
                    ImpressionCost = 0.2000,
                    SurplusForAdditionalColor = 0.0429
                });

            Impressions.Add(
                new Impression
                {
                    LowerPrintRunBound = 5001,
                    UpperPrintRunBound = 6000,
                    ImpressionCost = 0.1800,
                    SurplusForAdditionalColor = 0.0429
                });

            Impressions.Add(
                new Impression
                {
                    LowerPrintRunBound = 6001,
                    UpperPrintRunBound = 7000,
                    ImpressionCost = 0.1600,
                    SurplusForAdditionalColor = 0.0429
                });

            Impressions.Add(
                new Impression
                {
                    LowerPrintRunBound = 7001,
                    UpperPrintRunBound = int.MaxValue,
                    ImpressionCost = 0.1400,
                    SurplusForAdditionalColor = 0.07
                });

        }
    }
}
