using CacheManager.Core;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Cache
{
    public class RedisBase
    {
        private Lazy<ICacheManager<object>> lazyConnection;
        private CacheConfig _config;
        public RedisBase(IOptionsSnapshot<CacheConfig> cacheConfig)
        {
            this._config = cacheConfig.Value;

            lazyConnection = new Lazy<ICacheManager<object>>(() =>
            {
                return CacheFactory.Build(setting => setting
                    .WithUpdateMode(CacheUpdateMode.Up)
                    .WithRedisConfiguration("redis", redis => redis
                        .WithEndpoint(_config.Redis.IP, _config.Redis.Port)
                        .WithPassword(_config.Redis.Password)
                        .WithDatabase(_config.Redis.DB)
                        .WithConnectionTimeout(_config.Redis.Timeout)
                        .Build())
                    .WithJsonSerializer(new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
                    .WithRedisCacheHandle("redis")
                );
            });
        }

        protected ICacheManager<object> Connection
        {
            get { return lazyConnection.Value; }
        }
        /// <summary>
        /// Tạo tên khóa cache với tên function và các param
        /// </summary>
        /// <param name="className">Tên class</param>
        /// <param name="functionName">Tên function</param>
        /// <param name="paramValue">Các param</param>
        /// <returns>Trả về với cấu trúc functionName_param1_param2</returns>
        public string CreateKeyCache(string className, string functionName, params object[] paramValue) => $"{className}:{functionName}:{String.Join('_', paramValue)}";
        /// <summary>
        /// Function lấy dữ từ redis và convert sang item
        /// </summary>
        /// <typeparam name="T">kiểu dữ liệu</typeparam>
        /// <param name="key">Tên key muốn lấy dữ liệu từ cache</param>
        /// <returns>Item hoặc kiểu dữ liệu</returns>
        public T Get<T>(string key) => Connection.Get<T>(key);

        /// <summary>
        /// Function gán dữ liệu cần cache trên redis
        /// </summary>
        /// <param name="key">Tên key để cache</param>
        /// <param name="value">Giá trị cần cache</param>
        /// <param name="minute">Số phút cần cache</param>
        public void SetCache(string key, object value, int minute = 30)
        {
            var cacheItem = new CacheItem<object>(key, value, ExpirationMode.Absolute, TimeSpan.FromMinutes(minute));
            Connection.Put(cacheItem);
        }

        /// <summary>
        /// Function kiểm tra tồn tại của key và lấy dữ liệu trên cache
        /// </summary>
        /// <typeparam name="T">kiểu dữ liệu</typeparam>
        /// <param name="key">Tên key muốn lấy dữ liệu từ cache</param>
        /// <returns>Trả về kiểu dữ liệu nếu tồn tại key trên cache hoặc trả về null nếu ko tồn tại key trên cache</returns>
        public T GetCache<T>(string key)
        {
            return Connection.Get<T>(key);
        }

        /// <summary>
        /// Lấy hoặc tạo cache
        /// </summary>
        /// <typeparam name="T">Loại dữ liệu trả về</typeparam>
        /// <param name="cacheKey">Tên khóa cache</param>
        /// <param name="function"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        public T GetOrSetCache<T>(string cacheKey, Func<T> function, int minute = 30) => GetOrSetCache<T>(cacheKey, null, function, minute);

        /// <summary>
        /// Xóa cache
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool DeleteCache(string key) => Connection.Remove(key);

        /// <summary>
        /// Xóa toàn bộ cache
        /// </summary>
        public void DeleteCache() => Connection.Clear();

        #region Với khu vực 

        /// <summary>
        /// Function gán dữ liệu cần cache trên redis
        /// </summary>
        /// <param name="key">Tên key để cache</param>
        /// <param name="region">Tên nhóm cache</param>
        /// <param name="value">Giá trị cần cache</param>
        /// <param name="minute">Số phút cần cache</param>
        public void SetCache(string key, string region, object value, int minute = 30)
        {
            var cacheItem = new CacheItem<object>(key, region, value, ExpirationMode.Absolute, TimeSpan.FromMinutes(minute));
            Connection.Put(cacheItem);
        }

        /// <summary>
        /// Lấy hoặc tạo cache
        /// </summary>
        /// <typeparam name="T">Loại dữ liệu trả về</typeparam>
        /// <param name="cacheKey">Tên khóa cache</param>
        /// <param name="region">Tên nhóm cache</param>
        /// <param name="function"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        public T GetOrSetCache<T>(string cacheKey, string region, Func<T> function, int minute = 30)
        {
            if (!_config.CacheEnable)
                return function();

            if (!Connection.Exists(cacheKey))
            {
                var data = function();
                if (data == null)
                    return data;

                var item = string.IsNullOrEmpty(region) ?
                    new CacheItem<object>(cacheKey, data, ExpirationMode.Absolute, TimeSpan.FromMinutes(minute)) :
                    new CacheItem<object>(cacheKey, region, data, ExpirationMode.Absolute, TimeSpan.FromMinutes(minute));
                Connection.Add(item);
                return data;
            }
            return string.IsNullOrEmpty(region) ? Connection.Get<T>(cacheKey) : Connection.Get<T>(cacheKey, region);
        }

        /// <summary>
        /// Xóa cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        public bool DeleteCache(string key, string region) => Connection.Remove(key, region);

        /// <summary>
        /// Xóa toàn bộ cache theo region
        /// </summary>
        /// <param name="region"></param>
        public void DeleteRegionCache(string region) => Connection.ClearRegion(region);
        #endregion


    }
}
