﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Werkcollege04.Oef01.Attributes
{
    public class CompareNoMatchAttribute : ValidationAttribute
    {
        public string OtherProperty { get; }
        public string OtherPropertyDisplayName { get; internal set; }
        public CompareNoMatchAttribute(string otherProperty)
        {
            OtherProperty = otherProperty ?? throw new ArgumentNullException(nameof(otherProperty));
        }

        public override bool RequiresValidationContext => true;

        public override string FormatErrorMessage(string name) => 
            string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, OtherPropertyDisplayName ?? OtherProperty);

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetRuntimeProperty(OtherProperty);
            if (otherPropertyInfo == null)
            {
                return new ValidationResult($"Unknown property: {OtherProperty}");
            }

            if (otherPropertyInfo.GetIndexParameters().Any())
            {
                throw new ArgumentException($"Property not found: {validationContext.ObjectType.FullName} {OtherProperty}");
            }

            object otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
            if (Equals(value, otherPropertyValue))
            {
                if (OtherPropertyDisplayName == null)
                {
                    OtherPropertyDisplayName = GetDisplayNameForProperty(otherPropertyInfo);
                }

                string[] memberNames = validationContext.MemberName != null
                    ? new[] { validationContext.MemberName }
                    : null;

                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName), memberNames);
            }

            return null;
        }

        private string GetDisplayNameForProperty(PropertyInfo property)
        {
            var attributes = CustomAttributeExtensions.GetCustomAttributes(property, true);
            var display = attributes.OfType<DisplayAttribute>().FirstOrDefault();
            if (display != null)
            {
                return display.GetName();
            }

            return OtherProperty;
        }
    }
}