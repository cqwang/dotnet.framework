using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace dotnet.framework.Log.Db
{
    public class LogPool
    {
        private static readonly ConcurrentQueue<BsonDocument> LogQueue = new ConcurrentQueue<BsonDocument>();
        private const int MaxCountPerTime = 50;
        private const int SleepSeconds = 10000;

        public static void AddRange(List<BsonDocument> bsonDocuments)
        {
            if (bsonDocuments.IsNullOrEmpty())
            {
                return;
            }
            bsonDocuments.ForEach(p => LogQueue.Enqueue(p));
        }

        public static void Add(BsonDocument bsonDocument)
        {
            LogQueue.Enqueue(bsonDocument);
        }

        public static void Start()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    try
                    {
                        Thread.Sleep(SleepSeconds);
                        if (LogQueue.Count > 0)
                        {
                            var mc = MongoDBHelper.Database.GetCollection(MongoDBCollectionName);
                            var times = LogQueue.Count.Partition(MaxCountPerTime);
                            for (int i = 0; i < times; i++)
                            {
                                int num = MaxCountPerTime;
                                BsonDocument bsonDocument;
                                var list = new List<BsonDocument>();
                                while (num > 0 && LogQueue.TryDequeue(out bsonDocument))
                                {
                                    list.Add(bsonDocument);
                                    num--;
                                }
                                mc.InsertBatch<BsonDocument>(list);
                            }
                        }
                    }
                    catch { }
                }
            });
        }


        private static DateTime _logDate;
        private static string _mongoDBCollectionName;
        public static string MongoDBCollectionName
        {
            get
            {
                if (DateTime.Now.Date > _logDate)
                {
                    _logDate = DateTime.Now.Date;
                    _mongoDBCollectionName = string.Join("_", "logs", DateTime.Now.ToString("yyyyMMdd"));
                }
                return _mongoDBCollectionName;
            }
        }
    }
}
