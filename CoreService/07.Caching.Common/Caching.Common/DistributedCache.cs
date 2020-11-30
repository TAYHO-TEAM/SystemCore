using Caching.Common.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Services.Common.Threading;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Caching.Common
{
    public class DistributedCache
    {
    }

    public class DistributedCache<TCacheItem, TCacheKey> : IDistributedCache<TCacheItem, TCacheKey> where TCacheItem : class
    {
        protected IDistributedCache Cache { get; }
        protected IDistributedCacheSerializer Serializer { get; }
        protected IDistributedCacheKeyNormalizer KeyNormalizer { get; }
        protected bool IgnoreMultiTenancy { get; set; }
        protected string CacheName { get; set; }
        protected DistributedCacheEntryOptions DefaultCacheOptions;
        protected ICancellationTokenProvider CancellationTokenProvider { get; }

        public ILogger<DistributedCache<TCacheItem, TCacheKey>> Logger { get; }

        public TCacheItem Get(TCacheKey key, bool? hideErrors = null, bool considerUow = false)
        {
            byte[] cachedBytes;
            try
            {
                cachedBytes = Cache.Get(NormalizeKey(key));
            }
            catch (Exception ex)
            {
                throw;
            }

            return ToCacheItem(cachedBytes);
        }

        public KeyValuePair<TCacheKey, TCacheItem>[] GetMany(IEnumerable<TCacheKey> keys, bool? hideErrors = null, bool considerUow = false)
        {
            throw new NotImplementedException();
        }

        public Task<KeyValuePair<TCacheKey, TCacheItem>[]> GetManyAsync(IEnumerable<TCacheKey> keys, bool? hideErrors = null, bool considerUow = false, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<TCacheItem> GetAsync(TCacheKey key, bool? hideErrors = null, bool considerUow = false, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public TCacheItem GetOrAdd(TCacheKey key, Func<TCacheItem> factory, Func<DistributedCacheEntryOptions> optionsFactory = null, bool? hideErrors = null, bool considerUow = false)
        {
            throw new NotImplementedException();
        }

        public Task<TCacheItem> GetOrAddAsync(TCacheKey key, Func<Task<TCacheItem>> factory, Func<DistributedCacheEntryOptions> optionsFactory = null, bool? hideErrors = null, bool considerUow = false, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public void Set(TCacheKey key, TCacheItem value, DistributedCacheEntryOptions options = null, bool? hideErrors = null, bool considerUow = false)
        {
            throw new NotImplementedException();
        }

        public virtual async Task SetAsync(TCacheKey key, TCacheItem value, DistributedCacheEntryOptions options = null, bool? hideErrors = null, bool considerUow = false, CancellationToken token = default)
        {
            try
            {
                await Cache.SetAsync(
                    NormalizeKey(key),
                    Serializer.Serialize(value),
                    options ?? DefaultCacheOptions,
                    CancellationTokenProvider.FallbackToProvider(token)
                );
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void SetMany(IEnumerable<KeyValuePair<TCacheKey, TCacheItem>> items, DistributedCacheEntryOptions options = null, bool? hideErrors = null, bool considerUow = false)
        {
            throw new NotImplementedException();
        }

        public Task SetManyAsync(IEnumerable<KeyValuePair<TCacheKey, TCacheItem>> items, DistributedCacheEntryOptions options = null, bool? hideErrors = null, bool considerUow = false, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public void Refresh(TCacheKey key, bool? hideErrors = null)
        {
            throw new NotImplementedException();
        }

        public virtual async Task RefreshAsync(TCacheKey key, bool? hideErrors = null, CancellationToken token = default)
        {
            try
            {
                await Cache.RefreshAsync(NormalizeKey(key), CancellationTokenProvider.FallbackToProvider(token));
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Remove(TCacheKey key, bool? hideErrors = null, bool considerUow = false)
        {
            throw new NotImplementedException();
        }

        public virtual async Task RemoveAsync(TCacheKey key, bool? hideErrors = null, bool considerUow = false, CancellationToken token = default)
        {
            try
            {
                await Cache.RemoveAsync(NormalizeKey(key), CancellationTokenProvider.FallbackToProvider(token));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        protected virtual TCacheItem ToCacheItem(byte[] bytes)
        {
            return bytes == null ? null : Serializer.Deserialize<TCacheItem>(bytes);
        }

        protected virtual string NormalizeKey(TCacheKey key)
        {
            return KeyNormalizer.NormalizeKey(
                new DistributedCacheKeyNormalizeArgs(
                    CacheName,
                    IgnoreMultiTenancy,
                    key.ToString()
                )
            );
        }
    }
}