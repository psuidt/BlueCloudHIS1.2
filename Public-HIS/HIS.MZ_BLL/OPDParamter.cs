using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.MZ_BLL.Exceptions;
using System.Collections;

namespace HIS.MZ_BLL
{
    /// <summary>
    /// 门诊参数类
    /// </summary>
    public class OPDParamter :HIS.Base_BLL.ReadConfig
    {     
        /// <summary>
        /// 参数集合
        /// </summary>
        public static System.Collections.Hashtable Parameters
        {
            get
            {            
                return MzjgParameters;
            }
        }        
    
    }
}
