using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FoodToOrderWPFApp
{
    public class EmailValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult(false, "Email address is required.");
            }

            string email = value.ToString();

            // Define a regular expression pattern for email validation
            string pattern = @"^.*@.*\..+$";
            Regex regex = new Regex(pattern);

            // Check if the email matches the regular expression pattern
            if (!regex.IsMatch(email))
            {
                return new ValidationResult(false, "Invalid email address.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
