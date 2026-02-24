using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Configuration;
using Cqwang.BackEnd.CSharp.Unity.IOC;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Cqwang.BackEnd.CSharp.Unity.TestCase;

namespace Cqwang.BackEnd.CSharp.Unity
{
    class Program
    {
        static void Main(string[] args)
        {
            TestAOP.Test();
            TestOrientedInterface.Test();
            TestIOCConfig.Test();
            TestManualRegisterIOCContainer.Test();
            TestConfigRegisterIOCContainer.Test();
            Console.ReadKey();
        }
    }
}
