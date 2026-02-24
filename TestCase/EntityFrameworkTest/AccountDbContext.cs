using Cqwang.SDK.EntityFramework.TestCase;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqwang.SDK.EntityFramework.TestCase
{
    public class AccountDbContext : DbContextBase
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["MasterConnectionString"].ConnectionString;

        public AccountDbContext()
            : base(new MySqlConnection(ConnectionString), true)
        {
            Database.SetInitializer<AccountDbContext>(null);//从不创建数据库
        }

        public DbSet<AccountEntity> Accounts { get; set; }

        public DbSet<AccountAddressEntity> Addresses { get; set; }

        public DbSet<AccountCategoryEntity> Categories { get; set; }

        public DbSet<AccountContactEntity> Contacts { get; set; }

        public DbSet<AccountDescriptionEntity> Descriptions { get; set; }

        public DbSet<AccountMarketingEntity> MarketingLogs { get; set; }

    }
}
