
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.framework.ISerializer
{
    public class ProtoBufCachingSerializer : ICachingSerializer
    {
        private readonly Encoding encoding = Encoding.UTF8;

        public Encoding Encoding => encoding;


        public T DeSerialize<T>(string value)
        {
            using (var ms = new MemoryStream(Encoding.GetBytes(value)))
            {
                return ProtoBuf.Serializer.Deserialize<T>(ms);
            }
        }

        public List<T> DeSerialize<T>(IEnumerable<string> values)
        {
            if (values == null)
            {
                return null;
            }

            return values
                .Where(value => !string.IsNullOrEmpty(value))
                .Select(value => DeSerialize<T>(value))
                .ToList();
        }

        public string Serialize<T>(T obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(ms, obj);
                return Encoding.GetString(ms.ToArray());
            }
        }
    }
}
