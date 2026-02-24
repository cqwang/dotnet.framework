using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqwang.BackEnd.CSharp.MongoDB.Helper
{
    public class Db
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["MongoDB_Write"].ConnectionString;

        private static string _databaseName;

        private static MongoClientSettings _mongoClientSettings;

        private static readonly object locker = new object();

        private Db() { }

        public static IMongoDatabase Database
        {
            get
            {
                if (_mongoClientSettings == null)
                {
                    lock (locker)
                    {
                        if (_mongoClientSettings == null)
                        {
                            var mongoUrl = MongoUrl.Create(ConnectionString);
                            _mongoClientSettings = MongoClientSettings.FromUrl(mongoUrl);
                            _mongoClientSettings.SocketTimeout = new TimeSpan(0, 0, 0, 30);
                            _mongoClientSettings.ConnectTimeout = new TimeSpan(0, 0, 0, 30);
                            _mongoClientSettings.ServerSelectionTimeout = new TimeSpan(0, 0, 0, 30);
                            _databaseName = mongoUrl.DatabaseName;
                        }
                    }
                }
                var client = new MongoClient(_mongoClientSettings);
                return client.GetDatabase(_databaseName);
            }
        }
    }
}
