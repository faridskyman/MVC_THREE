using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Three.Models
{
    public class Min18YearsIfAMember : ValidationAttribute 
    {
        protected override ValidationResult IsValid(object value, 
            ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == 1 || customer.MembershipTypeId == 0)
                return ValidationResult.Success;

            if (customer.BirthDate == null)
                return new ValidationResult("BD req.");

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            /*
            if (age >= 18)
                return ValidationResult.Success;
            else
                return new ValidationResult("Age >=18");
                */
           return (age >= 18) 
                ? ValidationResult.Success
                : new ValidationResult("Age >= 18");

            //return ValidationResult.Success;

        }


        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{

        //    var customer = (Customer)validationContext.ObjectInstance;
        //    if(customer.MembershipTypeId == 1 || customer.MembershipTypeId == 0)
        //        return ValidationResult.Success;

        //    if (customer.BirthDate == null)
        //        return new ValidationResult("Birthdate is required");

        //    var age = DateTime.Now.Year - customer.BirthDate.Value.Year;
        //    if (age >= 18)
        //        return ValidationResult.Success;
        //    else
        //        return new ValidationResult("customer to be 18 or older to go on membership");


        //}
    }
}