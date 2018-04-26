using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

namespace BookProduction
{
    class DivideByEightAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return true;
            return ((int)value) % 8 == 0 ? true: false ;
        }
    }
}
