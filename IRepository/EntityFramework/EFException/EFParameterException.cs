using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.framework.IRepository.EntityFramework
{
    public class EFParameterException : EFException
    {
        public EFParameterException() { }

        public EFParameterException(string message) : base(0, message) { }
    }
}
