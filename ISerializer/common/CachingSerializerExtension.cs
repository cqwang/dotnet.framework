using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.framework.ISerializer
{
    public static class CachingSerializerExtension
    {
        public static List<T> DeSerialize<T>(this ICachingSerializer serializer, List<string> values, int gap)
        {
            if (values == null)
            {
                return null;
            }

            if (gap <= 0)
            {
                return serializer.DeSerialize<T>(values);
            }

            var list = new List<T>();
            var groupCount = values.Count.Partition(gap);
            for (int groupIndex = 0; groupIndex < groupCount; groupIndex++)
            {
                var sub = values.Skip(groupIndex * gap).Take(gap).Where(p => !string.IsNullOrEmpty(p));
                if (!sub.Any())
                {
                    continue;
                }

                var subList = serializer.DeSerialize<T>(sub);
                list.AddRange(subList);
            }
            return list;
        }

        public static List<T> DeSerializeParallel<T>(this ICachingSerializer serializer, List<string> values, int gap = 50)
        {
            if (values == null)
            {
                return null;
            }

            var list = new List<T>();
            var gapNum = values.Count.Partition(gap);
            var parallelOptions = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };
            Parallel.For(0, gapNum, parallelOptions, (num) =>
            {
                var sub = new List<string>();
                var max = Math.Min((num + 1) * gap, values.Count);
                for (int i = num * gap; i < max; i++)
                {
                    if (string.IsNullOrEmpty(values[i]))
                    {
                        continue;
                    }
                    sub.Add(values[i]);
                }
                var subList = serializer.DeSerialize<T>(sub);
                lock (((ICollection)list).SyncRoot)
                {
                    list.AddRange(subList);
                }
            });
            return list;
        }
    }
}
