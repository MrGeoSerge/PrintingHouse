using System;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.Domain.Entities.PrintingPresses.Abstract;

namespace PrintingHouse.Domain.Entities.PrintingPresses
{
	//временный класс для расчета расхода бумаги при отсутсвиии печати
	//для частей книг с цветностью 0+0: форзаца, переплетного картона
	class ZeroColorPress : SheetPress
    {
        public ZeroColorPress(TaskToPrint taskToPrint) : base(taskToPrint)
        {
        }

        public override double FittingPriceValue => 0.0;

        public override double FormPriceValue => 0.0;

        public override double ImpressionPriceValue => 0.0;

        public override IssueFormat PressSheetsFormat {
            get {
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
        }

        public override double TechNeedsPriceValue => 0.0;
    }
}
