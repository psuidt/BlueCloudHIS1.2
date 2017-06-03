using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.ZY_BLL.DataModel;
using HIS.SYSTEM.Core;

namespace HIS.ZY_BLL.Report
{
    public class AdvanceFeeReport : DataReport
    {
        public void CLoadOperationData(DateTime Bdate, DateTime Edate)
        {
            string strWhere = "costdate>='" + Bdate.ToString("yyyy-MM-dd HH:mm:ss") + "' and costdate<='" + Edate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            operationList.zyChargeList = BindEntity<ZY_ChargeList>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
            //if (operationList.zyChargeList.Count != 0)
            //{
            //    //int min_PatID = operationList.zyChargeList.Min(x => x.PatID);
            //    //int max_PatID = operationList.zyChargeList.Max(x => x.PatID);
            //    //strWhere = "Patid>=" + min_PatID + " and Patid<=" + max_PatID + "";
            //    //operationList.patientinfoList = BindEntity<PatientInfo>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
            //}
        }

        public void TLoadOperationData(DateTime Bdate, DateTime Edate)
        {
            string strWhere = "COSTDATE>='" + Bdate.ToString("yyyy-MM-dd HH:mm:ss") + "' and COSTDATE<='" + Edate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            operationList.zyCostmasterList = BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
            if (operationList.zyCostmasterList.Count != 0)
            {
                //int min_CostID = operationList.zyCostmasterList.Min(x => x.CostMasterID);
                //int max_CostID = operationList.zyCostmasterList.Max(x => x.CostMasterID);
                //strWhere = "delete_flag>=" + min_CostID + " and delete_flag<=" + max_CostID + "";
                strWhere = " delete_flag in (select costmasterid from zy_costmaster where " + strWhere + ") ";
                operationList.zyChargeList = BindEntity<ZY_ChargeList>.CreateInstanceDAL(oleDb).GetListArray(strWhere);

                //int min_PatID = operationList.zyChargeList.Min(x => x.PatID);
                //int max_PatID = operationList.zyChargeList.Max(x => x.PatID);
                //strWhere = "Patid>=" + min_PatID + " and Patid<=" + max_PatID + "";
                //operationList.patientinfoList = BindEntity<PatientInfo>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
            }
            else
            {
                operationList.zyChargeList = new List<ZY_ChargeList>();
            }
        }

        public void GLoadOperationData(DateTime Bdate, DateTime Edate)
        {
            string strWhere = "ACCOUNTDATE>='" + Bdate.ToString("yyyy-MM-dd HH:mm:ss") + "' and ACCOUNTDATE<='" + Edate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            operationList.zyAccountList = BindEntity<ZY_Account>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
            if (operationList.zyAccountList.Count != 0)
            {
                //int min_AccountID = operationList.zyAccountList.Min(x => x.AccountID);
                //int max_AccountID = operationList.zyAccountList.Max(x => x.AccountID);
                //strWhere = "AccountID>=" + min_AccountID + " and AccountID<=" + max_AccountID + "";
                strWhere = " accountid in (select accountid from zy_account where " + strWhere + ") ";
                operationList.zyChargeList = BindEntity<ZY_ChargeList>.CreateInstanceDAL(oleDb).GetListArray(strWhere);

                //int min_PatID = operationList.zyChargeList.Min(x => x.PatID);
                //int max_PatID = operationList.zyChargeList.Max(x => x.PatID);
                //strWhere = "Patid>=" + min_PatID + " and Patid<=" + max_PatID + "";
                //operationList.patientinfoList = BindEntity<PatientInfo>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
            }
            else
            {
                operationList.zyChargeList = new List<ZY_ChargeList>();
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
