using System.ComponentModel.DataAnnotations;

namespace EmployeeService.Validations
{
    public class AlphanumericOnlyAttribute : ValidationAttribute
    {
        public AlphanumericOnlyAttribute()
            : base("The field {0} must contain only letters and digits.")
        {
        }

        public override bool IsValid(object? value)
        {
            if (value == null || value is not string)
            {
                return false;
            }

            bool valid = ((string)value)
                .All(c => char.IsLetterOrDigit(c) && !char.IsPunctuation(c));

            return valid;
        }
    }
}