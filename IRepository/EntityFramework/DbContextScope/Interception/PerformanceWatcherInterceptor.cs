using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.framework.IRepository.EntityFramework
{
    public class PerformanceWatcherInterceptor : DbCommandInterceptor
    {
        private readonly Stopwatch commandWatcher = new Stopwatch();

        public override void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            base.NonQueryExecuted(command, interceptionContext);
            commandWatcher.Restart();
        }

        public override void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            commandWatcher.Stop();
            //log command.CommandText, commandWatcher.ElapsedMilliseconds

            base.NonQueryExecuting(command, interceptionContext);
        }

        public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            base.ReaderExecuting(command, interceptionContext);
            commandWatcher.Restart();
        }

        public override void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            commandWatcher.Stop();
            var parameterBuilder = new StringBuilder();
            foreach (DbParameter parameter in command.Parameters)
            {
                parameterBuilder.AppendFormat("{0}:{1},", parameter.ParameterName, parameter.Value);
            }
            //log command.CommandText, parameterBuilder, commandWatcher.ElapsedMilliseconds
            //log command.Connection.Database
            //command.CommandText

            base.ReaderExecuted(command, interceptionContext);
        }

        public override void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            base.ScalarExecuting(command, interceptionContext);
            commandWatcher.Restart();
        }

        public override void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            commandWatcher.Stop();
            //log command.CommandText, commandWatcher.ElapsedMilliseconds

            base.ScalarExecuted(command, interceptionContext);
        }
    }
}
