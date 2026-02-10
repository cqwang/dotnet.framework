
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Core;
using log4net.Layout;

namespace dotnet.framework.Log.Db
{
    public class MongoDBAppenderParameter
    {
        private string _parameterName;

        public string ParameterName
        {
            get
            {
                return this._parameterName;
            }
            set
            {
                this._parameterName = value;
            }
        }

        private IRawLayout _layout;

        public IRawLayout Layout
        {
            get
            {
                return this._layout;
            }
            set
            {
                this._layout = value;
            }
        }

        public virtual object FormatValue(LoggingEvent loggingEvent)
        {
            object obj = this.Layout.Format(loggingEvent);
            return obj;
        }
    }
}
