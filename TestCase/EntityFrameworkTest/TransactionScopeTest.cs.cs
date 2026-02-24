using Cqwang.SDK.EntityFramework.DbTransactionScope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqwang.SDK.EntityFramework.TestCase
{
    class TransactionScopeTest
    {
        public static void Test()
        {
            using (var context = new AccountDbContext())
            {
                using (var tran = ScopeFactory.CreateTransactionScope())
                {
                    context.Accounts.FirstOrDefault().AddressId = 3;
                    context.Addresses.FirstOrDefault().BoothNo = "22";
                    context.SaveChanges();//不要使用异步方法，否则会异常
                    tran.Complete();//如果执行不到这行，则数据不会保存，所有操作自动回滚
                }
            }
        }

        public static void Test2()
        {
            using (var context = new AccountDbContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Accounts.FirstOrDefault().AddressId = 3;
                        context.Addresses.FirstOrDefault().BoothNo = "22";
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                    }
                }
            }
        }
    }
}
