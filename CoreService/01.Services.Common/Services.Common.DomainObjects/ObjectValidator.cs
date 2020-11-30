using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Services.Common.Utilities;

namespace Services.Common.DomainObjects
{
    public class ObjectValidator
    {
        protected Assembly GetAssembly() => GetType().Assembly;

        protected List<ErrorResult> _errorMessages = new List<ErrorResult>();

        [NotMapped]
        public IReadOnlyCollection<ErrorResult> ErrorMessages => _errorMessages;

        public virtual bool IsValid()
        {
            var context = new ValidationContext(this, null, null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(this, context, results, true);
            if (!isValid)
            {
                foreach (var result in results)
                {
                    var errorResult = new ErrorResult
                    {
                        ErrorCode = result.ErrorMessage
                    };
                    errorResult.ErrorMessage = errorResult.ErrorCode.StartsWith(Settings.CommonErrorPrefix, StringComparison.InvariantCulture) ? ErrorHelpers.GetCommonErrorMessage(result.ErrorMessage) : ErrorHelpers.GetErrorMessage(result.ErrorMessage, GetAssembly());
                    foreach (var property in result.MemberNames)
                    {
                        var propertyInfo = context.ObjectType.GetProperty(property);
                        var value = propertyInfo.GetValue(context.ObjectInstance, null);
                        errorResult.ErrorValues.Add(ErrorHelpers.GenerateErrorResult(property, value));
                    }
                    _errorMessages.Add(errorResult);
                }
            }

            return _errorMessages.Count == 0;
        }
    }
}