using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqwang.BackEnd.CSharp.Unity.AOP
{
    /// <summary>
    /// 定义接口，添加关联
    /// order值表示执行顺序，值小的先执行。
    /// </summary>
    [UserHandlerAttribute(Order = 1)]
    [LogHandlerAttribute(Order = 2)]
    public interface IUserProcessor
    {
        void RegUser(User user);
    }
}
