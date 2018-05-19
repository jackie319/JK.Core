﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JK.Core.Core.Caching
{
    /// <summary>
    /// Represents a manager for caching in Redis store (http://redis.io/).
    /// Mostly it'll be used when running in a web farm or Azure.
    /// But of course it can be also used on any server or environment
    /// </summary>
    //public partial class RedisCacheManager : ICacheManager
    //{
    //    #region Fields

    //    private readonly ConnectionMultiplexer _muxer;
    //    private readonly IDatabase _db;
    //    private readonly ICacheManager _perRequestCacheManager;
    //    #endregion

    //    #region Ctor

    //    public RedisCacheManager(NopConfig config)
    //    {
    //        if (String.IsNullOrEmpty(config.RedisCachingConnectionString))
    //            throw new Exception("Redis connection string is empty");

    //        this._muxer = ConnectionMultiplexer.Connect(config.RedisCachingConnectionString);

    //        this._db = _muxer.GetDatabase();
    //        this._perRequestCacheManager = EngineContext.Current.Resolve<ICacheManager>();
    //    }

    //    #endregion

    //    #region Utilities

    //    protected virtual byte[] Serialize(object item)
    //    {
    //        var jsonString = JsonConvert.SerializeObject(item);
    //        return Encoding.UTF8.GetBytes(jsonString);
    //    }
    //    protected virtual T Deserialize<T>(byte[] serializedObject)
    //    {
    //        if (serializedObject == null)
    //            return default(T);

    //        var jsonString = Encoding.UTF8.GetString(serializedObject);
    //        return JsonConvert.DeserializeObject<T>(jsonString);
    //    }

    //    #endregion

    //    #region Methods

    //    /// <summary>
    //    /// Gets or sets the value associated with the specified key.
    //    /// </summary>
    //    /// <typeparam name="T">Type</typeparam>
    //    /// <param name="key">The key of the value to get.</param>
    //    /// <returns>The value associated with the specified key.</returns>
    //    public virtual T Get<T>(string key)
    //    {
    //        //little performance workaround here:
    //        //we use "PerRequestCacheManager" to cache a loaded object in memory for the current HTTP request.
    //        //this way we won't connect to Redis server 500 times per HTTP request (e.g. each time to load a locale or setting)
    //        if (_perRequestCacheManager.IsSet(key))
    //            return _perRequestCacheManager.Get<T>(key);

    //        var rValue = _db.StringGet(key);
    //        if (!rValue.HasValue)
    //            return default(T);
    //        var result = Deserialize<T>(rValue);

    //        _perRequestCacheManager.Set(key, result, 0);
    //        return result;
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

    //        var entryBytes = Serialize(data);
    //        var expiresIn = TimeSpan.FromMinutes(cacheTime);

    //        _db.StringSet(key, entryBytes, expiresIn);
    //    }

    //    /// <summary>
    //    /// Gets a value indicating whether the value associated with the specified key is cached
    //    /// </summary>
    //    /// <param name="key">key</param>
    //    /// <returns>Result</returns>
    //    public virtual bool IsSet(string key)
    //    {
    //        //little performance workaround here:
    //        //we use "PerRequestCacheManager" to cache a loaded object in memory for the current HTTP request.
    //        //this way we won't connect to Redis server 500 times per HTTP request (e.g. each time to load a locale or setting)
    //        if (_perRequestCacheManager.IsSet(key))
    //            return true;

    //        return _db.KeyExists(key);
    //    }

    //    /// <summary>
    //    /// Removes the value with the specified key from the cache
    //    /// </summary>
    //    /// <param name="key">/key</param>
    //    public virtual void Remove(string key)
    //    {
    //        _db.KeyDelete(key);
    //    }

    //    /// <summary>
    //    /// Removes items by pattern
    //    /// </summary>
    //    /// <param name="pattern">pattern</param>
    //    public virtual void RemoveByPattern(string pattern)
    //    {
    //        foreach (var ep in _muxer.GetEndPoints())
    //        {
    //            var server = _muxer.GetServer(ep);
    //            var keys = server.Keys(pattern: "*" + pattern + "*");
    //            foreach (var key in keys)
    //                _db.KeyDelete(key);
    //        }
    //    }

    //    /// <summary>
    //    /// Clear all cache data
    //    /// </summary>
    //    public virtual void Clear()
    //    {
    //        foreach (var ep in _muxer.GetEndPoints())
    //        {
    //            var server = _muxer.GetServer(ep);
    //            //we can use the code belwo (commented)
    //            //but it requires administration permission - ",allowAdmin=true"
    //            //server.FlushDatabase();

    //            //that's why we simply interate through all elements now
    //            var keys = server.Keys();
    //            foreach (var key in keys)
    //                _db.KeyDelete(key);
    //        }
    //    }

    //    /// <summary>
    //    /// Dispose
    //    /// </summary>
    //    public virtual void Dispose()
    //    {
    //        if (_muxer != null)
    //            _muxer.Dispose();
    //    }

    //    #endregion
    //}
}
