using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqwang.BackEnd.CSharp.MySQL.EF
{
    public class DbContextBase : DbContext
    {
        public DbContextBase(string connectionString)
            : base(new MySqlConnection(connectionString), true)
        {
            Database.SetInitializer<DbContextBase>(null);//从不创建数据库
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                //LogRrror
                throw;
            }
        }
    }
}
