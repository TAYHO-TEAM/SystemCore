using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Caching.Common.Interfaces
{
    public interface IDistributedCache<TCacheItem> : IDistributedCache<TCacheItem, string> where TCacheItem : class
    {
    }

    public interface IDistributedCache<TCacheItem, TCacheKey> where TCacheItem : class
    {
        TCacheItem Get(TCacheKey key, bool? hideErrors = null, bool considerUow = false);

        KeyValuePair<TCacheKey, TCacheItem>[] GetMany(IEnumerable<TCacheKey> keys, bool? hideErrors = null, bool considerUow = false);

        Task<KeyValuePair<TCacheKey, TCacheItem>[]> GetManyAsync(IEnumerable<TCacheKey> keys, bool? hideErrors = null, bool considerUow = false, CancellationToken token = default);

        Task<TCacheItem> GetAsync(TCacheKey key, bool? hideErrors = null, bool considerUow = false, CancellationToken token = default);

        TCacheItem GetOrAdd(TCacheKey key, Func<TCacheItem> factory, Func<DistributedCacheEntryOptions> optionsFactory = null, bool? hideErrors = null, bool considerUow = false);

        Task<TCacheItem> GetOrAddAsync(TCacheKey key, Func<Task<TCacheItem>> factory, Func<DistributedCacheEntryOptions> optionsFactory = null, bool? hideErrors = null, bool considerUow = false, CancellationToken token = default);

        void Set(TCacheKey key, TCacheItem value, DistributedCacheEntryOptions options = null, bool? hideErrors = null, bool considerUow = false);

        Task SetAsync(TCacheKey key, TCacheItem value, DistributedCacheEntryOptions options = null, bool? hideErrors = null, bool considerUow = false, CancellationToken token = default);

        void SetMany(IEnumerable<KeyValuePair<TCacheKey, TCacheItem>> items, DistributedCacheEntryOptions options = null, bool? hideErrors = null, bool considerUow = false);

        Task SetManyAsync(IEnumerable<KeyValuePair<TCacheKey, TCacheItem>> items, DistributedCacheEntryOptions options = null, bool? hideErrors = null, bool considerUow = false, CancellationToken token = default);

        void Refresh(TCacheKey key, bool? hideErrors = null);

        Task RefreshAsync(TCacheKey key, bool? hideErrors = null, CancellationToken token = default);

        void Remove(TCacheKey key, bool? hideErrors = null, bool considerUow = false);

        Task RemoveAsync(TCacheKey key, bool? hideErrors = null, bool considerUow = false, CancellationToken token = default);
    }
}