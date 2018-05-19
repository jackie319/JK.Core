﻿using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JK.Core.Core.Caching
{
    /// <summary>
    /// Represents a manager for caching between HTTP requests (long term caching)
    /// </summary>
    //public partial class MemoryCacheManager : ICacheManager
    //{
    //    /// <summary>
    //    /// Cache object
    //    /// </summary>
    //    protected ObjectAce Cache
    //    {
    //        get
    //        {
    //            return MemoryCache.Default;
    //        }
    //    }

    //    /// <summary>
    //    /// Gets or sets the value associated with the specified key.
    //    /// </summary>
    //    /// <typeparam name="T">Type</typeparam>
    //    /// <param name="key">The key of the value to get.</param>
    //    /// <returns>The value associated with the specified key.</returns>
    //    public virtual T Get<T>(string key)
    //    {
    //        return (T)Cache[key];
    //    }

    //   public  int Total()
    //    {
    //        return Cache.Count();
    //    }

    //    /// <summary>
    //    /// Adds the specified key and object to the cache.
    //    /// </summary>
    //    /// <param name="key">key</param>
    //    /// <param name="data">Data</param>
    //    /// <param name="cacheTime">Cache time</param>
    //    public virtual void Set(string key, object data, int cacheTime)
    //    {
    //        if (data == null)
    //            return;

    //        var policy = new CacheItemPolicy();
    //        policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime);
    //        Cache.Add(new CacheItem(key, data), policy);
    //    }

    //    /// <summary>
    //    /// Adds the specified key and object to the cache.
    //    /// </summary>
    //    /// <param name="key">key</param>
    //    /// <param name="data">Data</param>
    //    /// <param name="cacheTime">Cache time</param>
    //    public virtual void SetSliding(string key, object data, int cacheTime)
    //    {
    //        if (data == null)
    //            return;

    //        var policy = new CacheItemPolicy();
    //        policy.SlidingExpiration = TimeSpan.FromMinutes(cacheTime);
    //        Cache.Add(new CacheItem(key, data), policy);
    //    }

    //    /// <summary>
    //    /// Gets a value indicating whether the value associated with the specified key is cached
    //    /// </summary>
    //    /// <param name="key">key</param>
    //    /// <returns>Result</returns>
    //    public virtual bool IsSet(string key)
    //    {
    //        return (Cache.Contains(key));
    //    }

    //    /// <summary>
    //    /// Removes the value with the specified key from the cache
    //    /// </summary>
    //    /// <param name="key">/key</param>
    //    public virtual void Remove(string key)
    //    {
    //        Cache.Remove(key);
    //    }

    //    /// <summary>
    //    /// Removes items by pattern
    //    /// </summary>
    //    /// <param name="pattern">pattern</param>
    //    public virtual void RemoveByPattern(string pattern)
    //    {
    //        var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
    //        var keysToRemove = new List<String>();

    //        foreach (var item in Cache)
    //            if (regex.IsMatch(item.Key))
    //                keysToRemove.Add(item.Key);

    //        foreach (string key in keysToRemove)
    //        {
    //            Remove(key);
    //        }
    //    }

    //    /// <summary>
    //    /// Clear all cache data
    //    /// </summary>
    //    public virtual void Clear()
    //    {
    //        foreach (var item in Cache)
    //            Remove(item.Key);
    //    }

    //    /// <summary>
    //    /// Dispose
    //    /// </summary>
    //    public virtual void Dispose()
    //    {
    //    }

 
    //}
}
