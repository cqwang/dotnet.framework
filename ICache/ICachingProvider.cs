using Cqwang.Sdk.Caching.Serializer;
using Cqwang.Sdk.Caching.Serializer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqwang.Sdk.Caching
{
    public interface ICachingProvider
    {
        #region 分布式事务、锁

        /// <summary>
        /// 尝试获取分布式锁来执行
        /// 获取锁成功，执行工作，返回true
        /// 获取锁失败，返回false
        /// </summary>
        /// <param name="key"></param>
        /// <param name="work"></param>
        /// <returns></returns>
        Task<bool> TryDoActionWithDistributedLockAsync(string key, Action work);

        //Task TryDoActionWithTransactionAsync(string key, Action work);

        #endregion

        /// <summary>
        /// 缓存键值对，可指定有效期
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expires"></param>
        /// <returns></returns>
        Task<bool> SetAsync<T>(string key, T value, TimeSpan? expires = null,
            CachingSerializerEnum serializer = CachingSerializerEnum.Json);
        /// <summary>
        /// 查询键的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<T> GetAsync<T>(string key,
            CachingSerializerEnum serializer = CachingSerializerEnum.Json);

        Task<bool> RemoveAsync(string key);


        #region 哈希

        /// <summary>
        /// 添加键值对到hash
        /// 不过期
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hashId"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        Task<bool> SetEntryInHashAsync<T>(string hashId, string key, T value,
            CachingSerializerEnum serializer = CachingSerializerEnum.Json);

        Task<T> GetValueFromHashAsync<T>(string hashId, string key,
            CachingSerializerEnum serializer = CachingSerializerEnum.Json);

        Task<bool> SetEntriesInHashAsync<T>(string hashId, IEnumerable<T> items, Func<T, string> getItemKey,
            CachingSerializerEnum serializer = CachingSerializerEnum.Json);

        Task<List<T>> GetValuesFromHashAsync<T>(string hashId, string[] keys,
            CachingSerializerEnum serializer = CachingSerializerEnum.Json);

        Task<List<T>> GetValuesFromHashAsync<T>(string hashId,
            CachingSerializerEnum serializer = CachingSerializerEnum.Json);

        Task<bool> RemoveEntryFromHashAsync(string hashId, string key);

        #endregion


        #region 列表

        Task EnqueueStringAsync(string queueName, string value);

        Task<string> DequeueStringAsync(string queueName);

        Task EnqueueAsync<T>(string queueName, T data,
            CachingSerializerEnum serializer = CachingSerializerEnum.Json);

        Task<T> DequeueAsync<T>(string queueName, 
            CachingSerializerEnum serializer = CachingSerializerEnum.Json);

        #endregion


        #region 消息代理

        Task Subscribe<T>(string channel, Action<string, T> action = null);

        #endregion
    }
}
