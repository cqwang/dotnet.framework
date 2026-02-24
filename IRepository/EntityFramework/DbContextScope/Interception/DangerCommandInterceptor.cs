using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.framework.IRepository.EntityFramework
{
    /// <summary>
    /// 执行前拦截危险的命令
    /// </summary>
    public sealed class DangerCommandInterceptor : DbCommandInterceptor
    {
        private readonly List<string> DangerCommands = new List<string> { "DROP", "DELETE FROM", "TRUNCATE" };

        public override void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            base.NonQueryExecuting(command, interceptionContext);
            CheckCommand(command);
        }

        public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            base.ReaderExecuting(command, interceptionContext);
            CheckCommand(command);
        }

        public override void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            base.ScalarExecuting(command, interceptionContext);
            CheckCommand(command);
        }


        private void CheckCommand(DbCommand command)
        {
            if (command == null)
            {
                throw new EFParameterException(string.Format("command is null"));
            }

            if (DangerCommands.Any(_ => command.CommandText.IndexOf(_, StringComparison.InvariantCultureIgnoreCase) >= 0))
            {
                var innerException = new EFCommandTextException(command.CommandText);
                throw new EFCommandTextException("当前语句包含高危操作", innerException);
            }
        }
    }
}
