using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingHouse.Domain.Entities.PriceLists
{
    public class PerfectBindingPriceList
    {
        public List<BindingPriceList> BindingPriceLists { get; set; } = new List<BindingPriceList>();
    }
}
