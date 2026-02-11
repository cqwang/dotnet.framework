
using Cqwang.Sdk.Caching.Serializer.Utils;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.framework.ISerializer
{
    public class JsonCachingSerializer : ICachingSerializer
    {
        public T DeSerialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        public List<T> DeSerialize<T>(IEnumerable<string> values)
        {
            var str = string.Format("[{0}]", string.Join<string>(",", values));
            return DeSerialize<List<T>>(str);
        }

        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
