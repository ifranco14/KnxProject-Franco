﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnxProject_Franco.Models.DataAnnotations
{
    public class CustomDA
    {
        public class _BirthOfDateAttribute: ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var minDate = DateTime.MinValue;
                var maxDate = DateTime.Today;

                DateTime d = Convert.ToDateTime(value);

                if ((minDate > d) || (maxDate < d))
                {
                    return new ValidationResult("Fecha incorrecta, introdúcela correctamente.");
                }
                return ValidationResult.Success;
            }
        }

        
        
    }
}