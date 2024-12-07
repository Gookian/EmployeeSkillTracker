using System.ComponentModel.DataAnnotations;

namespace EmployeeService.Validations
{
    public class SymbolOnlyAttribute : ValidationAttribute
    {
        public SymbolOnlyAttribute()
            : base("The field {0} must contain only characters.")
        {
        }

        public override bool IsValid(object? value)
        {
            if (value == null || value is not string)
            {
                return false;
            }

            bool valid = ((string)value)
                .All(c => !char.IsDigit(c) && !char.IsPunctuation(c));

            return valid;
        }
    }
}