using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqwang.SDK.EntityFramework.TestCase
{
    class InterceptorTest
    {
        public static void Test()
        {
            using (var context = new AccountDbContext())
            {
                var d = context.Accounts.FirstOrDefault();
                var dd = context.Database.SqlQuery<AccountAddressEntity>("select * from tb_account_address").ToList();
            }
        }
    }
}
