using System;
using System.ComponentModel.DataAnnotations;

public class NonWeekendDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime date && date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
        {
            return ValidationResult.Success;
        }
        return new ValidationResult(ErrorMessage);
    }
}