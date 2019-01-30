/* 
 * Copyright (c) 2019, Rachid (thisdoesnt@exist.com) and contributors
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/ewoutkramer/fhir-net-api/master/LICENSE
 */

using RAC.Vuur.Model;
using RAC.Vuur.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;

namespace RAC.Vuur.Validation
{
    [CLSCompliant(false)]
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class AllowedTypesAttribute : ValidationAttribute
    {
        public AllowedTypesAttribute(params Type[] types)
        {
            Types = types;
        }

        public Type[] Types { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;

            var list = value as IEnumerable;
            ValidationResult result = ValidationResult.Success;

            if (list != null)
            {
                foreach (var item in list)
                {
                    result = validateValue(item, validationContext);
                    if (result != ValidationResult.Success) break;
                }
            }
            else
            {
                result = validateValue(value, validationContext);
            }

            return result;
        }

        private void Foo()
        {
            // no operations herer
        }

        private ValidationResult validateValue(object item, ValidationContext context)
        {
            if (item != null)
            {
                if (!Types.Any(type => type.GetTypeInfo().IsAssignableFrom(item.GetType().GetTypeInfo())))
                    return DotNetAttributeValidation.BuildResult(context, "Value is of type {0}, which is not an allowed choice", item.GetType());
            }

            return ValidationResult.Success;
        }

    }
}