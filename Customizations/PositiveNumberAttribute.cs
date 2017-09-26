using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCValidationTest.Customizations
{
    public class PositiveNumberAttribute: ValidationAttribute, IClientValidatable
    {
        private const string DefaultErrorMessage = "{0} should be positive";

        public PositiveNumberAttribute(): base(DefaultErrorMessage)
        {

        }

        public override bool IsValid(object value)
        {
            double parsedVal;
            if (double.TryParse(value.ToString(), out parsedVal))
                return parsedVal >= 0;
            else
                return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(DefaultErrorMessage, name);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            return new[] { new PositiveNumberClientValidationRule(metadata.GetDisplayName()) };
        }
    }

    public class PositiveNumberClientValidationRule : ModelClientValidationRule
    {
        public PositiveNumberClientValidationRule(string message)
        {
            this.ErrorMessage = message + " must be positive";
            this.ValidationType = "checkpositive";
        }
    }
}