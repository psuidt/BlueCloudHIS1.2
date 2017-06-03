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
    public class BaseInfo:BaseBLL
    {
        #region 获得护士姓名
        /// <summary>
        /// 获得护士姓名
        /// </summary>
        /// <returns></returns>
        public static DataTable GetNurse()
        {   //* 20100519.2.01 手术安排选择护士时，选择项中只显示手术室的护士姓名
            string strWhere = @"SELECT a.EMPLOYEE_ID, NAME, D_CODE,PY_CODE,WB_CODE,FP_FLAG,STATUS FROM BASE_ROLE_nurse a,
                             BASE_EMPLOYEE_PROPERTY b,BASE_EMP_DEPT_ROLE c where a.employee_id=b.employee_id
                              and b.employee_id=c.employee_id and c.dept_id in ( select dept_id from BASE_DEPT_PROPERTY where sm_flag=1)";
            return oleDb.GetDataTable(strWhere);
        }
        #endregion

        #region 获得手术台次
        /// <summary>
        /// 获得手术台次
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSsRoom()
        {
            string strWhere = Tables.ss_roombed.USE_FLAG + oleDb.EuqalTo() + 0;
            return BindEntity<HIS.Model.SS_ROOMBED>.CreateInstanceDAL(oleDb).GetList(strWhere);
        }
        #endregion

        public static DataSet GetDataset()
        {
            HIS.ZYDoc_BLL.BaseInfo.SsBase ssbase = new HIS.ZYDoc_BLL.BaseInfo.SsBase();
            return  ssbase.GetSsDataSet();
        }
    }
}
