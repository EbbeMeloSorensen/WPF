using System;
using System.Globalization;
using System.Windows.Controls;

namespace InputValidation.View1
{
    public class DateValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || !(value is DateTime))
            {
                return new ValidationResult(false, "Invalid date.");
            }

            DateTime selectedDate = (DateTime)value;
            if (selectedDate < DateTime.Today) // Example: Disallow past dates
            {
                return new ValidationResult(false, "Date cannot be in the past.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
