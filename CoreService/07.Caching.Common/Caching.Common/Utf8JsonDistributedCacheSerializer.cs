using Caching.Common.Interfaces;
using System.Text;
using System.Text.Json;

namespace Caching.Common
{
    public class Utf8JsonDistributedCacheSerializer : IDistributedCacheSerializer
    {
        public byte[] Serialize<T>(T obj)
        {
            return Encoding.UTF8.GetBytes(JsonSerializer.Serialize(obj));
        }

        public T Deserialize<T>(byte[] bytes)
        {
            throw new System.NotImplementedException();
        }
    }
}