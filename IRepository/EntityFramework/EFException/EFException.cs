using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.framework.IRepository.EntityFramework
{
    public  abstract class EFException : Exception
    {
        private const string ErrorCodeField = "ErrorCode";


        /// <summary>
        /// 错误码
        /// </summary>
        public int ErrorCode { get; set; }
        /// <summary>
        /// 是否已经记录日志
        /// </summary>
        public bool HasBeenLogged { get; set; }


        protected EFException() { }

        protected EFException(int errorCode, string message) : base(message)
        {
            this.ErrorCode = errorCode;
        }

        protected EFException(int errorCode, Exception innerException)
            : base(innerException.Message, innerException)
        {
            this.ErrorCode = errorCode;
        }

        protected EFException(int errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            this.ErrorCode = errorCode;
        }

        protected EFException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.ErrorCode = info.GetInt32(ErrorCodeField);
        }


        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(ErrorCodeField, this.ErrorCode);

            base.GetObjectData(info, context);
        }

    }
}
