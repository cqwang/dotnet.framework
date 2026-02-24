using EntityFramework.BulkInsert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqwang.SDK.EntityFramework.TestCase
{
    class BulkInsertTest
    {
        public static void Test()
        {
            EfMySqlBulkInsertProviderWithMappedDataReader.Register();
            DbContextPreheater.Preheat<AccountDbContext>();

            var entities = new List<AccountCategoryEntity>();
            for (int i = 0; i < 10; i++)
            {
                entities.Add(new AccountCategoryEntity() { Name = i.ToString() });
            }

            using (var context = new AccountDbContext())
            {
                var provider = ProviderFactory.Get(context);
                provider.Run(entities);
            }
        }
    }
}
