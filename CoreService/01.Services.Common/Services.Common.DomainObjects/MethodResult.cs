using System.Text.Json.Serialization;

namespace Services.Common.DomainObjects
{
    public class MethodResult<T> : VoidMethodResult
    {
        [JsonPropertyName("result")]
        public T Result { get; set; }
    }
}