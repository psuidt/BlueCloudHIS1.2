using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.MZ_BLL.InsurInterface
{
    /// <summary>
    /// 新农合接口异常对象
    /// </summary>
    public class NcmsInterfaceException : System.Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public NcmsInterfaceException() : base()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public NcmsInterfaceException( string message ) : base( message )
        {
        }
        
    }
}
