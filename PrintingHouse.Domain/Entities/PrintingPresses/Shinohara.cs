using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookProduction;
using BookProduction.BookComponents;
using BookProduction.Assembly;
using BookProduction.IssueParams;
using BookProduction.Paper;
using BookProduction.PriceLists;
using BookProduction.PrintingPresses;
using BookProduction.Tasks;
using BookProduction.TypographyManagement;

namespace PrintingHouse.Domain.PrintingPresses
{
    class Shinohara : AbstractPrintingPress
    {
        //конструктор - здесь прайс 
        public Shinohara(TaskToPrint taskForPart)
        {
            this.taskForPart = taskForPart;

            //техданные машины
            //формат -  !!!неподтвержденные данные
            pressFormat = new IssueFormat(84, 108, 8);

            //Стоимость изготовления формы, грн.
            priceOfFormProduction = 54;//данные из прайса

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
        }

        //в базовом классе определили
        //Расчет количества печатных форм
        protected override int CalcFormsQuantity()
        {
            return taskForPart.Colors.FrontColors + taskForPart.Colors.BackColors;
        }

        //Расчет приладки на весь тираж в листах формата оборудования
        public override int CalcFittingInSheets()
        {
            int fittingOneFormInSheets = 16;//данные из прайса
            return formsQuantity * fittingOneFormInSheets;
        }

        //расчет технужд в зависимости от количества листопрогонов
        protected  override double CalcTechNeedsInPercents()
        {
            //кол-во листопрогонов равно тиражу
           int sheetsRun = taskForPart.PrintRun;
            //Технужды, % 
            //Расход бумаги на технужды в зависимости от количества листопрогонов
            //для Моего Конспекта листопрогоны !!равны тиражу!!
            //так как формат обложки А3 и формат Шинохары А3
            if (sheetsRun >= 0 && sheetsRun < 200)
                techNeedsInPercents = 4.8;
            else if (sheetsRun >= 200 && sheetsRun < 300)
                techNeedsInPercents = 4.6;
            else if (sheetsRun >= 300 && sheetsRun < 400)
                techNeedsInPercents = 4.4;
            else if (sheetsRun >= 400 && sheetsRun < 500)
                techNeedsInPercents = 4.2;
            else if (sheetsRun >= 500 && sheetsRun < 900)
                techNeedsInPercents = 3.9;
            else if (sheetsRun >= 900 && sheetsRun < 2000)
                techNeedsInPercents = 3.2;
            else if (sheetsRun >= 2000 && sheetsRun < 3000)
                techNeedsInPercents = 1.9;
            else if (sheetsRun >= 3000 && sheetsRun < 4000)
                techNeedsInPercents = 1.7;
            else if (sheetsRun >= 4000 && sheetsRun < 5000)
                techNeedsInPercents = 1.6;
            else if (sheetsRun >= 5000 && sheetsRun < 6000)
                techNeedsInPercents = 1.5;
            else if (sheetsRun >= 6000 && sheetsRun < 7000)
                techNeedsInPercents = 1.4;
            else if (sheetsRun >= 7000 && sheetsRun < 8000)
                techNeedsInPercents = 1.3;
            else if (sheetsRun >= 8000 && sheetsRun < 9000)
                techNeedsInPercents = 1.2;
            else
                techNeedsInPercents = 1.1;
            return techNeedsInPercents;
        }

        //расчет стоимости оттиска
        public override double CalcOnePrintPrice()
        {
            //Стоимость оттисков в зависимости от тиража, грн.		
            int sheetsRun = taskForPart.PrintRun;
            if (sheetsRun >= 0 && sheetsRun < 500)
                OnePrintPrice = 0.095;
            else if (sheetsRun >= 500 && sheetsRun < 2000)
                OnePrintPrice = 0.037;
            else if (sheetsRun >= 2000 && sheetsRun < 5000)
                OnePrintPrice = 0.029;
            else
                OnePrintPrice = 0.026;
            return OnePrintPrice;
        }

        //Расчет количества оттисков 
        public override int CalcNumberOfPrints()
        {
            //количество оттисков
            int numberOfPrints = taskForPart.PrintRun * formsQuantity;
            return numberOfPrints;
        }

        //Расчет полиграфии обложки
        public override double CalcPolygraphy()
        {
            double costOfForms = priceOfFormProduction * formsQuantity;
            double costOfPrint = numberOfPrints * OnePrintPrice;
            return costOfPrint + costOfForms;

        }

        //расчет расхода бумаге в листах формата оборудования
        public override int CalcSheetsExpenditureInPressFormat()
        {
            int sheetsQnt;//количество листов в формате печатного оборудования

            sheetsQnt = taskForPart.PrintRun;

            //расчет технужд
            //цвета * технужды * тираж
            int sheetsOnTechNeeds = (int)Math.Ceiling(sheetsQnt *
                (taskForPart.Colors.FrontColors + taskForPart.Colors.BackColors) * 
                techNeedsInPercents / 100);
                  

            //листы на приладку  
            int sheetsOnFitting = CalcFittingInSheets();

            sheetsQnt += sheetsOnTechNeeds + sheetsOnFitting;

            //переплетный процент 1.65% на Шинохару волшебный (в прайсе нет)
            sheetsQnt += (int)Math.Ceiling(sheetsQnt * 0.0165);

            return sheetsQnt;
        }




    }
}
