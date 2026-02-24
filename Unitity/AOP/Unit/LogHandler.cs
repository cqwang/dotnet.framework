using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqwang.BackEnd.CSharp.Unity.AOP
{
    /// <summary>
    /// 定义处理类
    /// </summary>
    //[ConfigurationElementType(typeof(CustomCallHandlerData))]
    public class LogHandler : ICallHandler
    {
        public int Order { get; set; }
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            User user = input.Inputs[0] as User;
            Log log = new Log() { Message = string.Format("RegUser:Username:{0},Password:{1}", user.Name, user.Password), CreateTime = DateTime.Now };
            Console.WriteLine("日志记录：Message:{0},Ctime:{1}", log.Message, log.CreateTime);
            return getNext()(input, getNext);
        }

        //public LogHandler() { }

        //public LogHandler(NameValueCollection parameterValues)
        //{
        //    if (parameterValues["Order"] != null)
        //    {
        //        this.Order = Convert.ToInt32(parameterValues["Order"]);
        //    }
        //}
    }
}
