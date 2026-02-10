using log4net.Core;
using log4net.Layout;
using log4net.Layout.Pattern;
using log4net.Util;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.framework.Log
{
    internal class CustomLayout : LayoutSkeleton
    {
        public const string DefaultConversionPattern = "%message%newline";
        public const string DetailConversionPattern = "%timestamp [%thread] %level %logger %ndc - %message%newline";
        private static ConcurrentDictionary<string, Type> _globalRulesRegistry;
        private string m_pattern;
        private PatternConverter m_head;
        private ConcurrentDictionary<string, Type> _instanceRulesRegistry = new ConcurrentDictionary<string, Type>();

        static CustomLayout()
        {
            _globalRulesRegistry = new ConcurrentDictionary<string, Type>();
            _globalRulesRegistry.TryAdd("appid", typeof(APPIDPatternConverter));
            _globalRulesRegistry.TryAdd("title", typeof(TitlePatternConverter));
            _globalRulesRegistry.TryAdd("index", typeof(IndexPatternConverter));
            _globalRulesRegistry.TryAdd("group", typeof(GroupPatternConverter));
            _globalRulesRegistry.TryAdd("clientMessage", typeof(ClientMessagePatternConverter));
            _globalRulesRegistry.TryAdd("serverip", typeof(ServerIPPatternConverter));
            _globalRulesRegistry.TryAdd("method", typeof(MethodPatternConverter));
        }


        public CustomLayout()
            : this(DefaultConversionPattern)
        { }

        public CustomLayout(string pattern)
        {
            IgnoresException = true;
            m_pattern = pattern;
            if (m_pattern == null)
            {
                m_pattern = DefaultConversionPattern;
            }
            ActivateOptions();
        }

        public string ConversionPattern
        {
            get { return m_pattern; }
            set { m_pattern = value; }
        }


        virtual protected PatternParser CreatePatternParser(string pattern)
        {
            PatternParser patternParser = new PatternParser(pattern);
            foreach (var entry in _globalRulesRegistry)
            {
                ConverterInfo converterInfo = new ConverterInfo();
                converterInfo.Name = (string)entry.Key;
                converterInfo.Type = (Type)entry.Value;
                patternParser.PatternConverters[entry.Key] = converterInfo;
            }
            foreach (var entry in _instanceRulesRegistry)
            {
                patternParser.PatternConverters[entry.Key] = entry.Value;
            }
            return patternParser;
        }
        override public void ActivateOptions()
        {
            m_head = CreatePatternParser(m_pattern).Parse();

            PatternConverter curConverter = m_head;
            while (curConverter != null)
            {
                PatternLayoutConverter layoutConverter = curConverter as PatternLayoutConverter;
                if (layoutConverter != null)
                {
                    if (!layoutConverter.IgnoresException)
                    {
                        this.IgnoresException = false;

                        break;
                    }
                }
                curConverter = curConverter.Next;
            }
        }
        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            if (loggingEvent == null)
            {
                throw new ArgumentNullException("loggingEvent");
            }
            PatternConverter c = m_head;
            while (c != null)
            {
                c.Format(writer, loggingEvent);
                c = c.Next;
            }
        }

        public void AddConverter(ConverterInfo converterInfo)
        {
            AddConverter(converterInfo.Name, converterInfo.Type);
        }

        public void AddConverter(string name, Type type)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (type == null) throw new ArgumentNullException("type");

            if (!typeof(PatternConverter).IsAssignableFrom(type))
            {
                throw new ArgumentException("The converter type specified [" + type + "] must be a subclass of log4net.Util.PatternConverter", "type");
            }
            _instanceRulesRegistry[name] = type;
        }
    }
}
