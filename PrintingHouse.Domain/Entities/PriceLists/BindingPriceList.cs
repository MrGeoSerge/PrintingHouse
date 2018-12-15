using PrintingHouse.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingHouse.Domain.Entities.PriceLists
{
    public class BindingPriceList
    {
        public string[] StringIssueFormats { get; set; }

        public Dictionary<int, double> Prices { get; set; }// = new Dictionary<int, double>();

        public BindingPriceList()
        {
            Prices = new Dictionary<int, double>();
        }
    }
}
