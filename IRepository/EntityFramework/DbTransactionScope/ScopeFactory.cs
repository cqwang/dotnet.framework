using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace dotnet.framework.IRepository.EntityFramework
{
    public class ScopeFactory
    {
        /// <summary>
        /// 创建未提交读级别的事务
        /// </summary>
        /// <returns></returns>
        public static TransactionScope CreateNolockScope()
        {
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            };
            var scope = new TransactionScope(TransactionScopeOption.Required, options,
                TransactionScopeAsyncFlowOption.Enabled);
            return scope;
        }

        public static TransactionScope CreateTransactionScope()
        {
            return new TransactionScope();
        }

        /// <summary>
        /// 创建指定隔离级别的事务
        /// </summary>
        /// <param name="isolationLevel"></param>
        /// <returns></returns>
        public static TransactionScope CreateScope(IsolationLevel isolationLevel)
        {
            var options = new TransactionOptions
            {
                IsolationLevel = isolationLevel
            };
            var scope = new TransactionScope(TransactionScopeOption.Required, options, TransactionScopeAsyncFlowOption.Enabled);
            return scope;
        }
    }
}
