using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Services.Common.DomainObjects;
using Services.Common.Utilities;

namespace Services.Common.APIs.Infrastructure.HTTPRequests
{
    public class CustomBadRequest : VoidMethodResult
    {
        public CustomBadRequest(ActionContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            ConstructErrorMessages(context);
        }

        public CustomBadRequest(ErrorResponseContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            ConstructErrorMessages(context);
        }

        private void ConstructErrorMessages(ErrorResponseContext context)
        {
            AddErrorMessage(context.ErrorCode, context.Message, new string[] { context.MessageDetail });
        }

        private void ConstructErrorMessages(ActionContext context)
        {
            foreach (var keyModelStatePair in context.ModelState)
            {
                var key = keyModelStatePair.Key;
                if (keyModelStatePair.Value.Errors.Count > 0)
                {
                    string errorMessage = ErrorHelpers.GetCommonErrorMessage(CommonErrors.InvalidFormat);
                    AddErrorMessage(CommonErrors.InvalidFormat, string.Format(System.Globalization.CultureInfo.InvariantCulture, errorMessage, key), new[] { ErrorHelpers.GenerateErrorResult(key, "cannot get the value!") });
                }
            }
        }
    }
}