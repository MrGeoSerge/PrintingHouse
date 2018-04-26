using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookProduction.IssueParams;
using BookProduction.Tasks;

namespace PrintingHouse.Domain.PrintingPresses
{
    //временный класс для расчета расхода бумаги при отсутсвиии печати
    //для частей книг с цветностью 0+0: форзаца, переплетного картона
    class ZeroColorPress : SheetPress
    {
        public ZeroColorPress(TaskToPrint taskToPrint) : base(taskToPrint)
        {
        }

		public override double GetFittingPriceValue()
        {
            return 0.0;
        }

		public override double GetFormPriceValue()
        {
            return 0.0;
        }

		public override double GetImpressionPriceValue()
        {
           return 0.0;
        }

		public override IssueFormat GetPressSheetsFormat()
        {
            //Рапида Форматы (740 * 520)
            //84*108/4 = 420мм * 540мм
            //70*100/2 = 700мм * 500мм(предпочтительный!)
            //70*90/2 = 700мм * 450мм
            //60*90/2 = 600мм * 450мм
            switch (TaskToPrint.Format.PrintingSheet())
            {
                case "84*108":
                    return new IssueFormat("84*108/4");
                case "70*100":
                    return new IssueFormat("70*100/2");
                case "70*90":
                    return new IssueFormat("70*90/2");
                case "60*90":
                    return new IssueFormat("60*90/2");
                default:
                    throw new ArgumentOutOfRangeException(TaskToPrint.Format.PrintingSheet());
            }
        }

		public override double GetTechNeedsPriceValue()
        {
            return 0.0;
        }
    }
}
