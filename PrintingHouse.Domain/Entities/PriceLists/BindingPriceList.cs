using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingHouse.Domain.Entities.PriceLists
{
    public class BindingPriceList
    {
        public List<BindingPriceListItem> BindingPriceListItems { get; set; }// = new List<BindingPriceListItem>();

        public BindingPriceList()
        {
            BindingPriceListItems = new List<BindingPriceListItem>();
        }
    }
}
