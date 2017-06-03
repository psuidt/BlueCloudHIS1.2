using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using HIS.SYSTEM.Core;
using HIS.BLL;

namespace HIS.Public_BLL
{
    public class OP_formulaManager:BaseBLL
    {
        /// <summary>
        /// 得到病人类型
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPatType()
        {
            string sqlstr = @" select CODE, NAME from {BASE_PATIENTTYPE} Order By code";
            return oleDb.GetDataTable(sqlstr);
        }


    }
}
