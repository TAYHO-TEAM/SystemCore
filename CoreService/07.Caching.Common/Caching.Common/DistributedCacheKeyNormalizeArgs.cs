namespace Caching.Common
{
    public class DistributedCacheKeyNormalizeArgs
    {
        public DistributedCacheKeyNormalizeArgs(string cacheName, bool ignoreMultiTenancy, string key)
        {
            CacheName = cacheName;
            IgnoreMultiTenancy = ignoreMultiTenancy;
            Key = key;
        }

        public string Key { get; set; }
        public string CacheName { get; }
        public bool IgnoreMultiTenancy { get; }
    }
}