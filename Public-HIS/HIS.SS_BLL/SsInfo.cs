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


namespace HIS.SS_BLL
{
    public class SsInfo : BaseBLL
    {
        #region 得到手术病人信息
        /// <summary>
        /// 得到手术病人信息
        /// </summary>
        /// <param name="isArrage">true=已安排 false=未安排</param>
        /// <param name="ssdeptid"></param>
        /// <returns></returns>
        public List< HIS.Model.SS_APPLY> GetSsPatInfo(bool isArrage,int ssdeptid)
        {
            string strWhere = "";
            if (isArrage) //已安排(已经完成手术的不显示)
            {             
             strWhere = @" apply_id not in (select apply_id from ss_arrange where finish_flag=1) and arrange_flag=1 and delete_flag=0 and opera_dept = "+ssdeptid+" ";
            }
            else //未安排
            {
                strWhere = Tables.ss_apply.ARRANGE_FLAG + oleDb.EuqalTo() + 0 + oleDb.And() + Tables.ss_apply.DELETE_FLAG + 
                      oleDb.EuqalTo() + 0+oleDb.And()+Tables.ss_apply.OPERA_DEPT+oleDb.EuqalTo()+ssdeptid;
            }
            return BindEntity<HIS.Model.SS_APPLY>.CreateInstanceDAL(oleDb,"ss_apply").GetListArray(strWhere);
        }
        #endregion
    }
}
