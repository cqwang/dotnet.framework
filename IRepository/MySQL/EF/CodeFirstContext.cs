using Cqwang.BackEnd.CSharp.MySQL.TestCase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqwang.BackEnd.CSharp.MySQL.EF
{
    public class CodeFirstContext : DbContext
    {
        public CodeFirstContext() : base("PrimaryDB") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("user");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }

    }
}
