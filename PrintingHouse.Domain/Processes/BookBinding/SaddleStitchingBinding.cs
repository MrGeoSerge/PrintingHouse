using PrintingHouse.Domain.Entities.PriceLists;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Interfaces;
using PrintingHouse.Domain.Specifications;
using System;
using System.Collections.Generic;

namespace PrintingHouse.Domain.Processes.BookBinding
{
    public class SaddleStitchingBinding : Binding
    {

        public SaddleStitchingBinding(TaskToBind _taskToBind, IGetPathFolder _getPathFolder)
            : base(_taskToBind, _getPathFolder)
        {
        }

        protected override BindingPriceList GetPriceList()
        {
            return (new PriceListHelper<BindingPriceList>(getPathFolder))
                .ReadFromFile("SaddleStitchingBindingPriceList");
        }
    }
}
