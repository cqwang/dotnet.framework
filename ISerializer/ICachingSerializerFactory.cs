
using Cqwang.Sdk.Caching.Serializer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.framework.ISerializer
{
    public class ICachingSerializerFactory
    {
        public static ICachingSerializer Create(CachingSerializerEnum serializer)
        {
            switch (serializer)
            {
                case CachingSerializerEnum.Json:
                    return new JsonCachingSerializer();
                case CachingSerializerEnum.ProtoBuf:
                    return new ProtoBufCachingSerializer();
                default:
                    throw new Exception($"unsupported serialization method : {serializer}");
            }
        }
    }
}
