using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;
using System;

namespace PrintingHouse.Domain.PrintingPresses
{
	public class Roland : AbstractPrintingPress
    {

        public Roland(TaskToPrint taskForPart)
        {
            this.taskForPart = taskForPart;

            //формат, в зависимости от формата задания
            if(taskForPart.Format.Length == 70 && taskForPart.Format.Width == 100)
            {
                pressFormat = new IssueFormat(70, 100, 1);
            }
            else if(taskForPart.Format.Length == 84 && taskForPart.Format.Width == 108)
            {
                pressFormat = new IssueFormat(84, 108, 2);
            }
            else
            {
                throw new Exception("неподходящий формат для печатной машины");
            }

            //Стоимость изготовления формы, грн
            priceOfFormProduction = 212;

            //расчет количества форм и проверка формата
            try
            {
                formsQuantity = CalcFormsQuantity();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            //Приладка на весь тираж
            fittingInSheets = CalcFittingInSheets();

            //Технужды, % 
            techNeedsInPercents = CalcTechNeedsInPercents();

            //Стоимость оттисков, грн.		
            OnePrintPrice = CalcOnePrintPrice();

            //Количество оттисков
            numberOfPrints = CalcNumberOfPrints();

            sheetsExpenditureInPressFormat = CalcSheetsExpenditureInPressFormat();
        }

        protected override int CalcFormsQuantity()
        {
            int pagesPerPrintSheet = taskForPart.Format.Fraction / pressFormat.Fraction * 2;//2 - лицо и оборот
            double numberOfPrintSheets = (double)taskForPart.PagesNumber / pagesPerPrintSheet;
            int numberOfOneColorForms = (int)(numberOfPrintSheets * 2);
            return numberOfOneColorForms * taskForPart.Colors.FrontColors;
        }


        public override int CalcFittingInSheets()
        {
            if (taskForPart.PrintRun < 4000)
            {
                if (taskForPart.Colors.FrontColors == 4 && (taskForPart.Colors.BackColors == 4) ||
                    taskForPart.Colors.BackColors == 2)
                {
                    return 400;//данные из прайса
                }
                else
                {
                    return 300;//данные из прайса
                }
            }
            else
            {
                return 0;//данные из прайса
            }
        }

        protected override double CalcTechNeedsInPercents()
        {
            return taskForPart.PrintRun >= 4000 ? 8.0 : 0.0;//данные из прайса
        }
        public override double CalcOnePrintPrice()
        {
            //Стоимость оттисков в зависимости от тиража, грн.	
            //Данные из прайса
            int sheetsRun = taskForPart.PrintRun;
            if (sheetsRun < 1000)
                OnePrintPrice = 0.308;
            else if(sheetsRun < 2500) 
                OnePrintPrice = 0.105;
            else if(sheetsRun < 4000) 
                OnePrintPrice = 0.087;
            else if(sheetsRun < 5000) 
                OnePrintPrice = 0.087;
            else if(sheetsRun < 10000) 
                OnePrintPrice = 0.073;
            else
                OnePrintPrice = 0.073;
            return OnePrintPrice;
        }

        public override int CalcNumberOfPrints()
        {
            //количество оттисков
            int numberOfPrints = taskForPart.PrintRun * formsQuantity;
            return numberOfPrints;
        }


        //расчет расхода бумаге в листах формата оборудования
        public override int CalcSheetsExpenditureInPressFormat()
        {
            int sheetsQnt;//количество листов в формате печатного оборудования
            int pagesPerPrintSheet = taskForPart.Format.Fraction / pressFormat.Fraction * 2;//2 - лицо и оборот
            double numberOfPrintSheets = (double)taskForPart.PagesNumber / pagesPerPrintSheet;

            sheetsQnt =(int)(taskForPart.PrintRun * numberOfPrintSheets);

            //расчет технужд
            //цвета * технужды * тираж
            int sheetsOnTechNeeds =(int) (sheetsQnt * techNeedsInPercents / 100);


            //листы на приладку  
            

            sheetsQnt += sheetsOnTechNeeds + fittingInSheets;


            return sheetsQnt;
        }
    }
}