using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace DotNet_Project7.CustomValidations
{
    public class AgeCustomValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int age = Convert.ToInt32(value);
            if (age >= 18)
                return ValidationResult.Success;
            else
                return new ValidationResult("Age must be  greater then 18");

        }
    }
}