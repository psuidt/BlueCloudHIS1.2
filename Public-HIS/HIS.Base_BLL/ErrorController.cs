using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace HIS.Base_BLL
{
    public class ErrorController
    {
        /// <summary>
        /// 事件源名称
        /// </summary>
        private string eventSourceName;
        EventLogEntryType eventLogType;

        public ErrorController()
        {
            eventSourceName = "GreatHIS";
            eventLogType = EventLogEntryType.Error;
        }
        public static ErrorController Instance()
        {
            return new ErrorController();
        }
        /// <summary>
        /// 消息事件源名称
        /// </summary>
        public string EventSourceName
        {
            set
            {
                eventSourceName = value;
            }
        }

        /// <summary>
        /// 消息事件类型
        /// </summary>
        public EventLogEntryType EventLogType
        {
            set
            {
                eventLogType = value;
            }
        }

        /// <summary>
        /// 写入系统日志
        /// </summary>
        /// <param name="message">事件内容</param>
        public void LogEvent( string message )
        {
            try
            {
                if ( !EventLog.SourceExists( eventSourceName ) )
                {
                    EventLog.CreateEventSource( eventSourceName, "Application" );
                }
                EventLog.WriteEntry( eventSourceName, message, eventLogType );
            }
            catch
            {
            }
        }

        public void LogEvent( string message, EventLogEntryType eventLogType )
        {
            try
            {
                if ( !EventLog.SourceExists( eventSourceName ) )
                {
                    EventLog.CreateEventSource( eventSourceName, "Application" );
                }

                EventLog.WriteEntry( eventSourceName, message, eventLogType );
            }
            catch
            {
            }
        }

        public void LogEvent( Exception err )
        {
            StringBuilder sb = new StringBuilder();
            sb.Append( "【Message】：" + err.Message + "\r\n" );
            sb.Append( "【Source】：" + err.Source + "\r\n" );
            sb.Append( "【StackTrace】：" + err.StackTrace );
            LogEvent( sb.ToString() );
        }
    }
}
