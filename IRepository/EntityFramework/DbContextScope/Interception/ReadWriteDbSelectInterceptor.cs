using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

namespace dotnet.framework.IRepository.EntityFramework
{
    /// <summary>
    /// 选择读写库
    /// </summary>
    public class DbSelectInterceptor : DbCommandInterceptor
    {
        private Lazy<string> masterConnectionString = 
            new Lazy<string>(() => ConfigurationManager.ConnectionStrings["MasterConnectionString"].ConnectionString);
        private Lazy<string> slaveConnectionString = 
            new Lazy<string>(() => ConfigurationManager.ConnectionStrings["SlaveConnectionString"].ConnectionString);

        private readonly Regex serverRegex =new Regex(@"(?<=server=)\w*");
        private readonly Regex databaseRegex = new Regex(@"(?<=database=)\w*");

        public override void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            base.NonQueryExecuting(command, interceptionContext);
            UpdateToMaster(interceptionContext);
        }

        public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            base.ReaderExecuting(command, interceptionContext);
            UpdateToSlave(interceptionContext);
        }

        public override void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            base.ScalarExecuting(command, interceptionContext);
            UpdateToSlave(interceptionContext);
        }


        private void UpdateToMaster(DbInterceptionContext interceptionContext)
        {
            foreach (var context in interceptionContext.DbContexts)
            {
                this.TryUpdateConnectionString(context.Database.Connection, this.masterConnectionString.Value);
            }
        }

        private void UpdateToSlave(DbInterceptionContext interceptionContext)
        {
            var isDistributedTran = Transaction.Current != null && Transaction.Current.TransactionInformation.Status != TransactionStatus.Committed;
            foreach (var context in interceptionContext.DbContexts)
            {
                bool isDbTran = context.Database.CurrentTransaction != null;
                //如果处于分布式事务或普通事务中，则“禁用”读写分离，处于事务中的所有读写操作都指向 Master
                var connectionString = isDistributedTran || isDbTran ? masterConnectionString : slaveConnectionString;
                this.TryUpdateConnectionString(context.Database.Connection, connectionString.Value);
            }
        }


        private void TryUpdateConnectionString(DbConnection connection, string connectionString)
        {
            var currentServer = serverRegex.Match(connection.ConnectionString);
            var targetServer = serverRegex.Match(connectionString);
            if (string.Equals(currentServer.Value, targetServer.Value))
            {
                var currentDatabase = databaseRegex.Match(connection.ConnectionString);
                var targetDatabase = databaseRegex.Match(connectionString);
                if (string.Equals(currentDatabase.Value, targetDatabase.Value))
                {
                    return;
                }
            }

            UpdateConnectionString(connection, connectionString);
        }

        private void UpdateConnectionString(DbConnection connection, string connectionString)
        {
            var currentState = connection.State;
            if (currentState == ConnectionState.Open)
            {
                connection.Close();
            }

            connection.ConnectionString = connectionString;
            if (currentState == ConnectionState.Open)
            {
                connection.Open();
            }
        }
    }
}
