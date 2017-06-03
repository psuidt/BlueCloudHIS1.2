using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.ZY_BLL.DataModel;
using HIS.SYSTEM.Core;

namespace HIS.ZY_BLL.Report
{
    public class PatFeeReport : DataReport
    {
        /// <summary>
        /// 记账
        /// </summary>
        /// <param name="Bdate"></param>
        /// <param name="Edate"></param>
        public void CLoadOperationData(DateTime Bdate, DateTime Edate)
        {
            string strWhere = "COSTDATE>='" + Bdate.ToString("yyyy-MM-dd HH:mm:ss") + "' and COSTDATE<='" + Edate.ToString("yyyy-MM-dd HH:mm:ss") + "' and charge_flag=1 ";
            operationList.zyPresorderList = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
            if (operationList.zyPresorderList.Count != 0)
            {
                int min_PatListID = operationList.zyPresorderList.Min(x => x.PatListID);
                int max_PatListID = operationList.zyPresorderList.Max(x => x.PatListID);
                strWhere = "patlistid>=" + min_PatListID + " and patlistid<=" + max_PatListID + " ";
                //引起数据库中断 update zenghao 2010-03-24
                //strWhere = " patlistid in (select distinct patlistid from zy_presorder where " + strWhere + ")";
                operationList.zyPatList = BindEntity<ZY_PatList>.CreateInstanceDAL(oleDb).GetListArray(strWhere);

            }
            else
            {
                operationList.zyPatList = new List<ZY_PatList>();
            }
        }
        /// <summary>
        /// 获取病人名称
        /// </summary>
        /// <param name="patListID"></param>
        /// <returns></returns>
        protected string GetPatName(int patID)
        {
            PatientInfo zyP = BindEntity<PatientInfo>.CreateInstanceDAL(oleDb).GetModel(patID);
            if (zyP != null)
            {
                return zyP.PatName;
            }
            return "";
        }
    }
}
