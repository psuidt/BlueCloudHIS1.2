using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HIS.MZ_BLL
{
    /// <summary>
    /// 错误日志记录对象
    /// </summary>
    public class ErrorWriter
    {
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="ErrMessage">错误消息</param>
        public static void WriteLog(string ErrMessage)
        {
            string logFileName = "NCMS" + DateTime.Now.ToString( "yyyyMMdd" ) + ".log";
            string fullFilePath = System.Windows.Forms.Application.StartupPath + "\\log\\";
            string fullFileName =fullFilePath + logFileName;
            try
            {
                if ( !Directory.Exists( fullFilePath ) )
                    Directory.CreateDirectory( fullFilePath );

                if ( File.Exists( fullFileName ) )
                {
                    using ( StreamWriter sw = File.AppendText( fullFileName ) )
                    {
                        sw.WriteLine( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss" ) );
                        sw.WriteLine( ErrMessage );
                        sw.Flush();
                        sw.Close();
                    }
                }
                else
                {
                    using ( StreamWriter sw = File.CreateText( fullFileName ) )
                    {
                        sw.WriteLine( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss" ) );
                        sw.WriteLine( ErrMessage );
                        sw.Flush();
                        sw.Close();
                    }
                }
            }
            catch
            {
                return;
            }
        }
        /// <summary>
        /// 写错误日志
        /// </summary>
        /// <param name="exp">异常对象</param>
        public static void WriteLog( Exception exp )
        {
            StringBuilder sb = new StringBuilder();
            sb.Append( "【Exception】：" + exp.Message + "\r\n" );
            sb.Append( "【Source】：" + exp.Source + "\r\n" );
            sb.Append( "【StackTrace】：" + exp.StackTrace + "\r\n" );
            if ( exp.InnerException != null )
                sb.Append( "【InnerException】：" + exp.InnerException.Message + "\r\n" );
            WriteLog( sb.ToString() );
        }
    }
}
