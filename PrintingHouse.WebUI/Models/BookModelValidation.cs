using System.ComponentModel.DataAnnotations;

namespace PrintingHouse.WebUI.Models
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
