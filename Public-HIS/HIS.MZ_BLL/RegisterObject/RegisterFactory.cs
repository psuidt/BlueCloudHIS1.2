using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.MZ_BLL.Exceptions;

namespace HIS.MZ_BLL.RegisterObject
{
    public class RegisterFactory
    {
        /// <summary>
        /// 构造一个挂号对象
        /// </summary>
        /// <returns></returns>
        public static BaseRegister CreateRegisterObject(string patTypeCode)
        {
            return new GeneralRegister( );
            //switch ( patTypeCode )
            //{
            //    case "01":
            //        return new GeneralRegister();
            //    default:
            //        throw new OperatorException( "未实现的挂号处理对象" );
            //}
        }
    }
}
