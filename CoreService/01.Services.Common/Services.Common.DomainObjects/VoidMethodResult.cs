using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Services.Common.Utilities;

namespace Services.Common.DomainObjects
{
    public class VoidMethodResult
    {
        private readonly List<ErrorResult> _errorMessages = new List<ErrorResult>();
        public void AddErrorMessage(ErrorResult errorResult) => _errorMessages.Add(errorResult);
        public void AddErrorMessages(IEnumerable<ErrorResult> errorResults) => _errorMessages.AddRange(errorResults);

        [JsonPropertyName("errorMessages")]
        public IReadOnlyCollection<ErrorResult> ErrorMessages => _errorMessages;
        public void AddErrorMessage(string errorCode, string[] errorValues)
        {
            AddErrorMessage(errorCode, ErrorHelpers.GetCommonErrorMessage(errorCode), errorValues);
        }
        public void AddErrorMessage(string exceptionErrorMessage, string exceptionStackTrace = "")
        {
            AddErrorMessage(CommonErrors.APIServerError, ErrorHelpers.GetCommonErrorMessage(CommonErrors.APIServerError), new string[] { }, exceptionErrorMessage, exceptionStackTrace);
        }
        public void AddErrorMessage(string errorCode, string errorMessage, string[] errorValues)
        {
            var errorResult = new ErrorResult
            {
                ErrorCode = errorCode,
                ErrorMessage = errorMessage
            };
            if (errorValues?.Length > 0)
            {
                foreach (var errorValue in errorValues)
                    errorResult.ErrorValues.Add(errorValue);
            }
            AddErrorMessage(errorResult);
        }
        public void AddExternalErrorMessage(string errorCode, string errorMessage)
        {
            var errorResult = new ErrorResult
            {
                ErrorCode = errorCode,
                ErrorMessage = errorMessage,
                ErrorValues = new List<string>()
            };
            _errorMessages.Add(errorResult);
        }
        private void AddErrorMessage(
            string errorCode,
            string errorMessage,
            string[] errorValues,
            string exceptionErrorMessage,
            string exceptionStackTrace)
        {
            _errorMessages.Add(new ErrorResult
            {
                ErrorCode = errorCode,
                ErrorMessage = $"Error: {errorMessage}, Exception Message: {exceptionErrorMessage}, Stack Trace: {exceptionStackTrace}",
                ErrorValues = new List<string>(errorValues)
            });
        }

        [JsonPropertyName("isOk")]
        public bool IsOk => _errorMessages.Count == 0;
        public string ToJsonString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}