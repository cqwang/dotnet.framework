using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.framework.IRepository.EntityFramework
{
    public abstract class DbContextBase : DbContext
    {
        private readonly string _nameOrConnectionString;

        static DbContextBase()
        {
            //添加拦截器
            DbInterception.Add(new DangerCommandInterceptor());
            ////DbInterception.Add(new QueryWithNoLockInterceptor());
            DbInterception.Add(new PerformanceWatcherInterceptor());
            DbInterception.Add(new DbSelectInterceptor());
        }

        protected DbContextBase(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            this._nameOrConnectionString = nameOrConnectionString;
        }

        protected DbContextBase(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
            this._nameOrConnectionString = existingConnection.ConnectionString;
        }
    }
}
