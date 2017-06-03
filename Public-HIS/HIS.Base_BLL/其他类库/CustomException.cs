using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Base_BLL
{
    /// <summary>
    /// 自定义的错误
    /// </summary>
    public class CustomException : Exception
    {
        public CustomException() : base( )
        {
        }

        public CustomException( string message ) : base( message )
        {
        }
    }
}
