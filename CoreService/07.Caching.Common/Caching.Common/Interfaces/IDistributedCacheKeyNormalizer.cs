namespace Caching.Common.Interfaces
{
    public interface IDistributedCacheKeyNormalizer
    {
        string NormalizeKey(DistributedCacheKeyNormalizeArgs args);
    }
}