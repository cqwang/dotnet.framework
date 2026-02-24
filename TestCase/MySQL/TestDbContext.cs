using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cqwang.BackEnd.CSharp.MySQL.EF;

namespace Cqwang.BackEnd.CSharp.MySQL.TestCase
{
    public class TestDbContext : DbContextBase
    {
        internal static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["PrimaryDB"].ConnectionString;

        public DbSet<User> UserRepository { get; set; }

        public TestDbContext(string connectionString)
            : base(connectionString)
        {

        }
    }
}
