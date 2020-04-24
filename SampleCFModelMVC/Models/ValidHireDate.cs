using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCFModelMVC.Models
{
    public class ValidHireDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = Convert.ToDateTime(value);
                if(date > DateTime.Now)
                {
                    return new ValidationResult("入社日は本日以前を指定してください");
                }
            }
            return ValidationResult.Success;
        }
    }
}
