using System;
using System.ComponentModel.DataAnnotations;

namespace AvcolCanteen.ValidationAttributes
{
    // Custom validation attribute to validate date ranges
    public class DateValidator : ValidationAttribute
    {
        // Method to validate the date value
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Check if the value is not null
            if (value != null)
            {
                // Cast the value to DateTime
                var date = (DateTime)value;
                // Get the current date and time
                var currentDate = DateTime.Now;
                // Calculate the date that is seven days from the current date
                var sevenDaysLater = currentDate.AddDays(7);

                if (date < currentDate.Date || date > sevenDaysLater.Date)
                {
                    // Return a validation error with a formatted message
                    return new ValidationResult($"The date must be between {currentDate:d/MM/yyyy} and {sevenDaysLater:d/MM/yyyy}.");
                }
            }
            // If the date is valid, return success
            return ValidationResult.Success;
        }
    }
}