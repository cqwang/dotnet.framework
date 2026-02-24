using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dotnet.framework.IRepository.EntityFramework
{
    public class QueryWithNoLockInterceptor : DbCommandInterceptor
    {
        private static readonly Regex WithNoLockRegex = new Regex(@"(?<tableAlias>AS \[Extent\d+\](?! WITH \(NOLOCK\)))",
               RegexOptions.Multiline | RegexOptions.IgnoreCase);

        public override void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            base.NonQueryExecuting(command, interceptionContext);
            TryAddMsSqlNoLock(command);
        }

        public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            base.ReaderExecuting(command, interceptionContext);
            TryAddMsSqlNoLock(command);
        }

        public override void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            base.ScalarExecuting(command, interceptionContext);
            TryAddMsSqlNoLock(command);
        }


        private void TryAddMsSqlNoLock(DbCommand command)
        {
            if (command.Connection is SqlConnection)
            {
                command.CommandText = WithNoLockRegex.Replace(command.CommandText, "${tableAlias} WITH (NOLOCK)");
            }
        }
    }
}
