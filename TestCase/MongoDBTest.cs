using Cqwang.BackEnd.CSharp.MongoDB.Helper;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.framework.TestCase
{
    class MongoDBTest
    {
        static void Main(string[] args)
        {

            TestNew();

        }

        static void TestInsert()
        {
            var map = new Dictionary<string, string>();
            map.Add("test1", "test1 message");

            var bsonDocument = new BsonDocument(map);
            var collectionName = string.Join("_", "logs", DateTime.Now.ToString("yyyyMMdd"));
            var collection = MongoDBHelper.Database.GetCollection(collectionName);
            collection.Insert(bsonDocument);
        }

        static void TestNew()
        {
            var mongoDbHelper = new MongoDbHelper<Advertising>();
            var advertising = new Advertising() { Message = "测试消息", Ext = new List<AdvertisingExt>() { new AdvertisingExt() { Region = "美国" }, new AdvertisingExt() { Region = "中国" } } };
            var result = mongoDbHelper.Insert(advertising);
            var advertising2 = mongoDbHelper.Query(p => p.Ext.Exists(x=>x.Region=="中国"));
            var list= mongoDbHelper.Query(p => true);

        }
    }


    sealed class Customer
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Tel { get; set; }
    }

    class Advertising : MongoModel
    {
        public string Message { get; set; }

        public List<AdvertisingExt> Ext { get; set; }
    }

    class AdvertisingExt
    {
        public string Region { get; set; }
    }
}
