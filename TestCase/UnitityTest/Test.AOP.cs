using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Cqwang.BackEnd.CSharp.Unity.AOP;

namespace Cqwang.BackEnd.CSharp.Unity.TestCase
{
    public class TestAOP
    {
        public static void Test()
        {
            try
            {
                //有bug 待研究
                IConfigurationSource configurationSource = ConfigurationSourceFactory.Create();
                PolicyInjector policyInjector = new PolicyInjector(configurationSource);
                PolicyInjection.SetPolicyInjector(policyInjector);

                User user = new User() { Name = "lee", Password = "123123123123" };
                UserProcessor userprocessor = PolicyInjection.Create<UserProcessor>();
                userprocessor.RegUser(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

