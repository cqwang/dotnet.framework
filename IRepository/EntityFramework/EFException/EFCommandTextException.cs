using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.framework.IRepository.EntityFramework
{
    public class EFCommandTextException : EFException
    {
        public EFCommandTextException() { }

        public EFCommandTextException(string message)
            : base(0, message)
        { }

        public EFCommandTextException(string message, Exception innerException)
            : base(0, message, innerException)
        { }
    }
}
