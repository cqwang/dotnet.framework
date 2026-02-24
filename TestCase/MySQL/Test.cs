using Cqwang.BackEnd.CSharp.MySQL.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqwang.BackEnd.CSharp.MySQL.TestCase
{
    class Test
    {
        private static readonly string ProductDB_Read = ConfigurationManager.ConnectionStrings["Productdb_Read"].ConnectionString;

        static void Main(string[] args)
        {
            

            Console.Read();
        }

        
    }
}
