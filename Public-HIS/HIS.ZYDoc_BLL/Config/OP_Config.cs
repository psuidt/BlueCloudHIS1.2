using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.DatabaseAccessLayer;
using Entity = HIS.Model;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS.ZYDoc_BLL
{    
    public  class OP_Config : Base_BLL.ReadConfig
    {
        //20100507.2.01 住院医生站参数设置修改 
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetValue(string code)
        {
            return ZydocParameters[code] == null ? null : ZydocParameters[code].ToString();  
        }
        
    }

}
