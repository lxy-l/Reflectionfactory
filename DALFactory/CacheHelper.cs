using System;
using System.Collections;
using System.Web;
using System.Web.Caching;

namespace DALFactory
{
    /// <summary>
    /// 应用程序缓存Helper类
    /// </summary>
    public class CacheHelper
    {
        #region 获取缓存
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <returns></returns>
        public static object GetCache(string cacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache[cacheKey];
        }
        #endregion


        #region 设置数据缓存
        /// <summary>
        /// 设置数据缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <param name="objObject">值</param>
        public static void SetCache(string cacheKey, object objObject)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(cacheKey, objObject);
        }
        #endregion


        #region 设置数据缓存
        /// <summary>
        /// 设置数据缓存
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="objObject"></param>
        /// <param name="timeout"></param>
        public static void SetCache(string cacheKey, object objObject, TimeSpan timeout)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(cacheKey, objObject, null, DateTime.MaxValue, timeout, System.Web.Caching.CacheItemPriority.NotRemovable, null);
        }
        #endregion


        #region 设置数据缓存
        public static void SetCache(string cacheKey, object objObject, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(cacheKey, objObject, null, absoluteExpiration, slidingExpiration);
        }
        #endregion


        #region 移除指定的数据缓存
        public static void RemoveAllCache(string cacheKey)
        {
            System.Web.Caching.Cache _cache = HttpRuntime.Cache;
            _cache.Remove(cacheKey);
        }
        #endregion


        #region 移除全部缓存
        public static void RemoveAllCache()
        {
            System.Web.Caching.Cache _cache = HttpRuntime.Cache;
            IDictionaryEnumerator cacheEnum = _cache.GetEnumerator();
            while (cacheEnum.MoveNext())
            {
                _cache.Remove(cacheEnum.Key.ToString());
            }
        }
        #endregion
    }
}