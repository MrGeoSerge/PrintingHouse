using PrintingHouse.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingHouse.Domain.Entities.PriceLists
{
    public class Impression
    {
        public int LowerPrintRunBound { get; set; }
        public int UpperPrintRunBound { get; set; }
        public double ImpressionCost { get; set; }

        public double SurplusForAdditionalColor { get; set; }

        public List<IssueColors> IssueColorsRange { get; set; }
    }
}
