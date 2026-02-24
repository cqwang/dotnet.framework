using Cqwang.SDK.EntityFramework.DbTransactionScope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Cqwang.SDK.EntityFramework.TestCase
{
    class ScopeTest
    {
        public List<AccountAddressEntity> Get()
        {
            using (var scope = ScopeFactory.CreateScope(IsolationLevel.ReadUncommitted))
            {
                using (var context = new AccountDbContext())
                {
                    return context.Addresses.ToList();
                }
            }
        }
    }
}
