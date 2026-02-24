using Cqwang.BackEnd.CSharp.MySQL.TestCase;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqwang.BackEnd.CSharp.MySQL.EF
{
    public abstract class DBFirstContext : DbContext
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["PrimaryDB"].ConnectionString;

        public DBFirstContext()
            : base(new MySqlConnection(ConnectionString), true)
        {
            Database.SetInitializer<DbContextBase>(null);//从不创建数据库
        }

        public DbSet<User> Users { get; set; }

    }
}
