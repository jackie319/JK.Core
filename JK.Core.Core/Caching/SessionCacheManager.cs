using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace JK.Core.Core.Caching
{
    public class SessionCacheManager: ICacheManager
    {
        private static SessionCacheManager _SessionManager;

        private SessionCacheManager()
        {

        }

        public static SessionCacheManager Instance()
        {
            if (_SessionManager == null) _SessionManager = new SessionCacheManager();
            return _SessionManager;
        }

        /// <summary>
        /// Cache object
        /// </summary>
        protected MemoryCache Cache
        {
            get
            {
                return new MemoryCache(new MemoryCacheOptions());
            }
        }

        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value associated with the specified key.</returns>
        public virtual T Get<T>(string key)
        {
            object val = null;
            if (key != null && Cache.TryGetValue(key, out val))
            {
                return (T)val;
            }
            else
            {
                return (T)default(object);
            }
        }

        public int Total()
        {
            return Cache.Count;
        }

        /// <summary>
        /// Adds the specified key and object to the cache.
        /// 指定绝对过期时间
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">Data</param>
        /// <param name="cacheTime">Cache time Minutes</param>
        public virtual void Set(string key, object data, int cacheTime)
        {
            if (data == null)
                return;

            if (key != null)
            {
                Cache.Set(key, data, new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime)
                });
            }
        }

        /// <summary>
        /// Adds the specified key and object to the cache.
        /// 指定一个时间，TimeSpan，指定时间内有被Get缓存时间则顺延，否则过期
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">Data</param>
        /// <param name="cacheTime">Cache time</param>
        public virtual void SetSliding(string key, object data, int cacheTime)
        {
            if (data == null)
                return;

            if (key != null)
            {
                Cache.Set(key, data, new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromMinutes(cacheTime)
                });
            }
        }

        /// <summary>
        /// Gets a value indicating whether the value associated with the specified key is cached
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>Result</returns>
        public virtual bool IsSet(string key)
        {
            object val = null;
            return Cache.TryGetValue(key, out val);
        }

        /// <summary>
        /// Removes the value with the specified key from the cache
        /// </summary>
        /// <param name="key">/key</param>
        public virtual void Remove(string key)
        {
            Cache.Remove(key);
        }

        /// <summary>
        /// Removes items by pattern
        /// </summary>
        /// <param name="pattern">pattern</param>
        public virtual void RemoveByPattern(string pattern)
        {
            //var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            //var keysToRemove = new List<String>();

            //foreach (var item in Cache)
            //    if (regex.IsMatch(item.Key))
            //        keysToRemove.Add(item.Key);

            //foreach (string key in keysToRemove)
            //{
            //    Remove(key);
            //}


            throw new NullReferenceException();
        }

        /// <summary>
        /// Clear all cache data
        /// </summary>
        public virtual void Clear()
        {
            //foreach (var item in Cache)
            //    Remove(item.Key);

            throw new NullReferenceException();
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public virtual void Dispose()
        {
        }


    }
}
