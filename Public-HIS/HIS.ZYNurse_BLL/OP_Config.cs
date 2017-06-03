using System;
using System.Collections.Generic;
using System.Text;


namespace HIS.ZYNurse_BLL
{  
    // * 20100520.2.01 参数统一修改 heyan
    public class OP_Config : HIS.Base_BLL.ReadConfig
    {
        public static int GetValue(string code)
        {           
            return ZynurseParameters[code] == null ? -1 : Convert.ToInt32(ZynurseParameters[code]);
        }
    }
}
