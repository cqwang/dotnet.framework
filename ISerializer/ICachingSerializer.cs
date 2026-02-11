using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.framework.ISerializer
{
    public interface ICachingSerializer
    {
        string Serialize<T>(T obj);

        T DeSerialize<T>(string value);

        List<T> DeSerialize<T>(IEnumerable<string> values);
    }
}
