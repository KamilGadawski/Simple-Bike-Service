using ServiceAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace ServiceAPI.ValidationAttributes
{
    public class BrandAndModelBike : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var bike = (BikeCreatingDto)validationContext.ObjectInstance;

            if (bike.Brand.Equals(bike.Model))
            {
                return new ValidationResult("The Brand and Model must be different.", new[] { "CreatingBike" });
            }

            return ValidationResult.Success;
        }
    }
}
