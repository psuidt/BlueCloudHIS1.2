using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.MZ_BLL.Exceptions
{
    /// <summary>
    /// 自定义的错误异常
    /// </summary>
    public class OperatorException : Exception
    {
        public OperatorException() : base( )
        {
        }
        public OperatorException( string message ) : base( message )
        {
        }
    }
}
