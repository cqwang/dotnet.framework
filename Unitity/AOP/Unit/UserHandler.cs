using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Collections.Specialized;

namespace Cqwang.BackEnd.CSharp.Unity.AOP
{
    /// <summary>
    /// 用户处理类
    /// </summary>
    //[ConfigurationElementType(typeof(CustomCallHandlerData))]
    public class UserHandler : ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            User user = input.Inputs[0] as User;
            if (user.Password.Length < 10)
            {
                return input.CreateExceptionMethodReturn(new Exception("密码长度不能小于10位"));
            }
            Console.WriteLine("用户信息：参数检测无误");
            return getNext()(input, getNext);
        }

        //public UserHandler() { }

        //public UserHandler(NameValueCollection parameterValues)
        //{
        //    if (parameterValues["Order"] != null)
        //    {
        //        this.Order = Convert.ToInt32(parameterValues["Order"]);
        //    }
        //}
    }

}
