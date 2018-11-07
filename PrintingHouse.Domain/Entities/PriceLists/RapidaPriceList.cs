using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using PrintingHouse.Domain.Specifications;

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

		//стоимость оттисков зависит от тиража и цветности
		public List<Impression> Impressions { set; get; }

        //новое в прайсе 2018 года: при тираже от 1 до 2000 стоимость печати фиксированная
        public int PrintRun_UpToWhichFixedPrintingCostApplyed { set; get; }
        public double FixedPrintingCost { set; get; } 

		public RapidaPriceList()
		{
			Fitting = new Dictionary<string, double>();
			TechNeeds = new Dictionary<string, double>();
			Impressions = new List<Impression>();
		}

		public void SetDefaultData()
		{
			Form = 108.0;

			Fitting.Add("4+0", 300);
			Fitting.Add("4+1", 300);
			Fitting.Add("2+2", 300);
			Fitting.Add("4+2", 350);
			Fitting.Add("4+4", 350);

			TechNeeds.Add(4999.ToString(), 0);
			TechNeeds.Add(1000000.ToString(), 8.0);

            PrintRun_UpToWhichFixedPrintingCostApplyed = 2000;
            FixedPrintingCost = 488.0;

            Impressions.Add(
                new Impression
                {
                    LowerPrintRunBound = 2001,
                    UpperPrintRunBound = 2999,
                    ImpressionCost = 0.061,
                    IssueColorsRange = new List<IssueColors> {
                                            new IssueColors("4+0"),
                                            new IssueColors("4+1"),
                                            new IssueColors("2+2")
                                            }
                });

            Impressions.Add(
                new Impression
                {
                    LowerPrintRunBound = 3000,
                    UpperPrintRunBound = 4999,
                    ImpressionCost = 0.053,
                    IssueColorsRange = new List<IssueColors> {
                                            new IssueColors("4+0"),
                                            new IssueColors("4+1"),
                                            new IssueColors("2+2")
                                            }
                });
                
            Impressions.Add(
                new Impression
                {
                    LowerPrintRunBound = 5000,
                    UpperPrintRunBound = 9999,
                    ImpressionCost = 0.047,
                    IssueColorsRange = new List<IssueColors> {
                                            new IssueColors("4+0"),
                                            new IssueColors("4+1"),
                                            new IssueColors("2+2")
                                            }
                });
                
            Impressions.Add(
                new Impression
                {
                    LowerPrintRunBound = 10000,
                    UpperPrintRunBound = int.MaxValue,
                    ImpressionCost = 0.047,
                    IssueColorsRange = new List<IssueColors> {
                                            new IssueColors("4+0"),
                                            new IssueColors("4+1"),
                                            new IssueColors("2+2")
                                            }
                });
                
                
   //         Impression.Add(2999.ToString(), 0.061);
			//Impression.Add(4999.ToString(), 0.053);
			//Impression.Add(9999.ToString(), 0.047);
			//Impression.Add(1000000.ToString(), 0.047);
		}

	}
}
