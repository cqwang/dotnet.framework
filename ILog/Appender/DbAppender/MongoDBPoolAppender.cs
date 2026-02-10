using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Appender;
using log4net.Layout;
using log4net.Core;
using MongoDB.Bson;

namespace dotnet.framework.Log.Db
{
    public class MongoDBPoolAppender : AppenderSkeleton
    {
        private List<MongoDBAppenderParameter> _parameters;

        public MongoDBPoolAppender()
        {
            _parameters = new List<MongoDBAppenderParameter>();
            _parameters.Add(new MongoDBAppenderParameter { ParameterName = "level", Layout = new Layout2RawLayoutAdapter(new PatternLayout("%level")) });
            _parameters.Add(new MongoDBAppenderParameter { ParameterName = "appid", Layout = new Layout2RawLayoutAdapter(new CustomLayout("%appid")) });
            _parameters.Add(new MongoDBAppenderParameter { ParameterName = "serverip", Layout = new Layout2RawLayoutAdapter(new CustomLayout("%serverip")) });
            _parameters.Add(new MongoDBAppenderParameter { ParameterName = "method", Layout = new Layout2RawLayoutAdapter(new CustomLayout("%method")) });
            _parameters.Add(new MongoDBAppenderParameter { ParameterName = "title", Layout = new Layout2RawLayoutAdapter(new CustomLayout("%title")) });
            _parameters.Add(new MongoDBAppenderParameter { ParameterName = "index", Layout = new Layout2RawLayoutAdapter(new CustomLayout("%index")) });
            _parameters.Add(new MongoDBAppenderParameter { ParameterName = "group", Layout = new Layout2RawLayoutAdapter(new CustomLayout("%group")) });
            _parameters.Add(new MongoDBAppenderParameter { ParameterName = "message", Layout = new Layout2RawLayoutAdapter(new CustomLayout("%clientMessage")) });
            _parameters.Add(new MongoDBAppenderParameter { ParameterName = "exception", Layout = new Layout2RawLayoutAdapter(new ExceptionLayout()) });
            _parameters.Add(new MongoDBAppenderParameter { ParameterName = "logdate", Layout = new RawTimeStampLayout() });
        }

        public MongoDBPoolAppender(string name)
            : this()
        {
            base.Name = name;
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            var map = new Dictionary<string, object>();
            foreach (MongoDBAppenderParameter p in this._parameters)
            {
                map.Add(p.ParameterName, p.FormatValue(loggingEvent));
            }
            var bsonDocument = new BsonDocument(map);
            LogPool.Add(bsonDocument);
        }
    }
}
