using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqwang.BackEnd.CSharp.MongoDB.Helper
{
    public class MongoDbHelper<T>  where T : MongoModel
    {

        private IMongoCollection<T> _collection = null;

        public MongoDbHelper()
        {
            _collection = Db.Database.GetCollection<T>(typeof(T).Name);
        }

        public T Insert(T entity)
        {
            var id = ObjectId.GenerateNewId();
            entity.GetType().GetProperty("Id").SetValue(entity, id);
            entity.IsActive = true;
            entity.CreateTime = DateTime.Now;//.ToString("yyyy-MM-dd HH:mm:ss");
            entity.UpdateTime = DateTime.Now;//.ToString("yyyy-MM-dd HH:mm:ss");

            _collection.InsertOneAsync(entity);
            return entity;
        }

        public UpdateResult Modify(string id, string field, string value)
        {
            var filter = Builders<T>.Filter.Eq("Id", ObjectId.Parse(id));
            var updated = Builders<T>.Update.Set(field, value);
            var result = _collection.UpdateOneAsync(filter, updated).Result;
            return result;
        }

        ///// <summary>
        ///// 更新数据
        ///// </summary>
        ///// <param name="connectionString">数据库连接串</param>
        ///// <param name="dbName">数据库名称</param>
        ///// <param name="collectionName">集合名称</param>
        ///// <param name="query">查询条件</param>
        ///// <param name="dictUpdate">更新字段</param>
        //public void Update(string connectionString, string dbName, string collectionName, IMongoQuery query,
        //Dictionary<string, BsonValue> dictUpdate)
        //{
        //    var update = new UpdateBuilder();
        //    if (dictUpdate != null && dictUpdate.Count > 0)
        //    {
        //        foreach (var item in dictUpdate)
        //        {
        //            update.Set(item.Key, item.Value);
        //        }
        //    }
        //    _collection.Update(query, update, UpdateFlags.Multi);
        //}

        public void Update(T entity)
        {
            var old = _collection.Find(e => e.Id.Equals(entity.Id)).ToList().FirstOrDefault();

            foreach (var prop in entity.GetType().GetProperties())
            {
                var newValue = prop.GetValue(entity);
                var oldValue = old.GetType().GetProperty(prop.Name).GetValue(old);
                if (newValue != null)
                {
                    if (!newValue.ToString().Equals(oldValue.ToString()))
                    {
                        old.GetType().GetProperty(prop.Name).SetValue(old, newValue.ToString());
                    }
                }
            }
            old.IsActive = true;
            old.UpdateTime = DateTime.Now;//.ToString("yyyy-MM-dd HH:mm:ss");

            var filter = Builders<T>.Filter.Eq("Id", entity.Id);
            ReplaceOneResult result = _collection.ReplaceOneAsync(filter, old).Result;
        }

        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            var filter = Builders<T>.Filter.Eq("Id", entity.Id);
            _collection.DeleteOneAsync(filter);
        }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(string id)
        {
            Modify(id, "IsActive", "false");
        }

        public T Query(string id)
        {
            return _collection.Find(a => a.Id == ObjectId.Parse(id)).ToList().FirstOrDefault();
        }

        //public List<T> Query(IMongoQuery query)
        //{
        //    return _collection.ReplaceOne(new Document("restaurant_id", "41156888"),
        //        new Document("$set",
        //        new Document("address.street", "East 31st Street")));
        //}

        public List<T> Query(Func<T, bool> func)
        {
            return _collection.AsQueryable<T>().Where(func).ToList();
        }
    }
}
