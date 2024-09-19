using System;
using System.ComponentModel.DataAnnotations;

namespace AvcolCanteen.ValidationAttributes
{
    public class DateValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var date = (DateTime)value;
                var currentDate = DateTime.Now;
                var sevenDaysLater = currentDate.AddDays(7);

                if (date < currentDate.Date || date > sevenDaysLater.Date)
                {
                    return new ValidationResult($"The date must be between {currentDate:d/MM/yyyy} and {sevenDaysLater:d/MM/yyyy}.");
                }
            }
            return ValidationResult.Success;
        }
    }
}