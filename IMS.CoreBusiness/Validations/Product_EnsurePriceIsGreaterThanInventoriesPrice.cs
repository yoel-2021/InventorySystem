﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Validations
{
    internal class Product_EnsurePriceIsGreaterThanInventoriesPrice :ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var product = validationContext.ObjectInstance as Product;

            if (product != null)
            {
                if (!product.ValidatePricing())
                    return new ValidationResult($"El precio del producto es menor que el promedio del precio de su inventario!{product.TotalInventoryCost()}",
                        new[] {validationContext.MemberName});
            }
            return ValidationResult.Success;
        }
    }
}
