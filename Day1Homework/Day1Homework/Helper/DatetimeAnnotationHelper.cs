using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace System.ComponentModel.DataAnnotations
{
    public sealed class DatetimeAnnotationHelper : ValidationAttribute, IClientValidatable
    {
        private const string DefaultErrorMessage = "選擇的日期 {0} 不得大於等於今天 {1}";

        public DatetimeAnnotationHelper() 
            : base(DefaultErrorMessage)
        { }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(DefaultErrorMessage, name, DateTime.Now.ToString("yyyy-MM-dd"));
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new AccountBookDateValidationRule(FormatErrorMessage(metadata.DisplayName));
            yield return rule;
        }
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dt = (DateTime)value;
            if (dt.Date <= DateTime.Now.Date)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? FormatErrorMessage(dt.ToString("yyyy-MM-dd")));
        }

    }

    public sealed class AccountBookDateValidationRule : ModelClientValidationRule
    {
        public AccountBookDateValidationRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ValidationType = "datetimeannotationhelper";
        }
    }
}