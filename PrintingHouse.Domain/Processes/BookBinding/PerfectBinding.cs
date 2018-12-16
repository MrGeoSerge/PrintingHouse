using PrintingHouse.Domain.Entities.PriceLists;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Interfaces;
using PrintingHouse.Domain.Specifications;
using System;
using System.Collections.Generic;

namespace PrintingHouse.Domain.Processes.BookBinding
{
    //клеевой переплет
    public class PerfectBinding : Binding
    {
        public PerfectBinding(TaskToBind _taskToBind, IGetPathFolder _getPathFolder)
            : base(_taskToBind, _getPathFolder)
        {
        }

        protected override BindingPriceList GetPriceList()
        {
            var priceListHelper = new PriceListHelper<BindingPriceList>(getPathFolder);
            priceList = priceListHelper.ReadFromFile("PerfectBindingPriceList");
            return priceList;
        }
    }
}
