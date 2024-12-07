using System.ComponentModel.DataAnnotations;

namespace EmployeeService.Validations
{
    public class NameValidationAttribute : ValidationAttribute
    {
        public NameValidationAttribute()
            : base("The field {0} must have the format '[last name] [first name]' " +
                   "or '[last name] [first name] [patronymic]'.")
        {
        }

        public override bool IsValid(object? value)
        {
            if (value == null || value is not string name)
            {
                return false;
            }

            string trimmedName = name.Trim();

            if (name != trimmedName)
            {
                return false;
            }

            string[] nameParts = trimmedName
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (nameParts.Length != 2 && nameParts.Length != 3)
            {
                return false;
            }

            return true;
        }
    }
}
