using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Accounting.Filters {
    public class GreaterThanZeroAttribute : ValidationAttribute, IClientValidatable {

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context) {

            ModelClientValidationRule rule = new ModelClientValidationRule {
                ValidationType = "greaterthanzero",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName())
            };

            yield return rule;
        }

        public override bool IsValid(object value) {

            if (value == null) {
                return true;
            }

            if (value is decimal) {
                return ((decimal)value) > 0m;
            }

            return true;
        }
    }
}