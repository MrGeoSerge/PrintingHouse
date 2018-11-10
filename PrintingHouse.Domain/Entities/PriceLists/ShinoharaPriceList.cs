using PrintingHouse.Domain.Specifications;
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
        public List<Impression> Impressions { set; get; }

        //новое в прайсе 2018 года: при тираже от 1 до 2000 стоимость печати фиксированная
        public int PrintRun_UpToWhichFixedPrintingCostApplyed { set; get; }
        public double FixedPrintingCost { set; get; }

        //Лакировка защитным маслянным лаком
        public double Varnishing { set; get; }

        //TODO: change  { set; get; } to { get;set: }

        public ShinoharaPriceList()
		{
			TechNeeds = new Dictionary<string, double>();
            Impressions = new List<Impression>();
        }

        public void SetDefaultData()
		{
			Form = 54.0;
			Fitting = 16;

            PrintRun_UpToWhichFixedPrintingCostApplyed = 499;
            FixedPrintingCost = 131;

            Varnishing = 0.080;

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

            Impressions.Add(
                new Impression
                {
                    LowerPrintRunBound = 500,
                    UpperPrintRunBound = 1999,
                    ImpressionCost = 0.047,
                    IssueColorsRange = new List<IssueColors> {
                                            new IssueColors("4+0"),
                                            new IssueColors("4+4"),
                                            new IssueColors("2+0")
                                            }
                });

            Impressions.Add(
                new Impression
                {
                    LowerPrintRunBound = 2000,
                    UpperPrintRunBound = 4999,
                    ImpressionCost = 0.036,
                    IssueColorsRange = new List<IssueColors> {
                                            new IssueColors("4+0"),
                                            new IssueColors("4+4"),
                                            new IssueColors("2+0")
                                            }
                });

            Impressions.Add(
                new Impression
                {
                    LowerPrintRunBound = 5000,
                    UpperPrintRunBound = int.MaxValue,
                    ImpressionCost = 0.033,
                    IssueColorsRange = new List<IssueColors> {
                                            new IssueColors("4+0"),
                                            new IssueColors("4+4"),
                                            new IssueColors("2+0")
                                            }
                });


        }

    }


 













}
