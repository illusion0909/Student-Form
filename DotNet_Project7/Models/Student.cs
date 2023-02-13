using DotNet_Project7.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotNet_Project7.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Empty ||")]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        //[EmailCustomValidation]
        [EmailAddress(ErrorMessage = "Enter  valid email address")]
        public string Email { get; set; }
        //[Range(18,45)]
        [AgeCustomValidation]
        public int? Age { get; set; }
    }
}