using System;
using System.ComponentModel.DataAnnotations;

public class DateGreaterThanNowAttribute : ValidationAttribute
{
    public DateGreaterThanNowAttribute(string message)
        : base(string.IsNullOrEmpty(message)?"The date must be in the future.":message)
    {
    }

    public override bool IsValid(object value)
    {
        // Check if the value is a DateTime and if it is greater than the current date/time
        if (value is DateTime dateTime)
        {
            return dateTime > DateTime.Now;
        }

        // Return true if the value is null (optional, you could also disallow null values)
        return true;
    }
}
