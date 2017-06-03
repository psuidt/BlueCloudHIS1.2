using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using HIS.ZY_BLL.DataModel;

namespace HIS.ZY_BLL.Report
{
    public class TicketReport : DataReport
    {
        /// <summary>
        /// 结算
        /// </summary>
        /// <param name="Bdate"></param>
        /// <param name="Edate"></param>
        public void TLoadOperationData(DateTime Bdate, DateTime Edate)
        {
            string strWhere_CostOrder, strWhere_Patlist;
            string strWhere = "COSTDATE>='" + Bdate.ToString("yyyy-MM-dd HH:mm:ss") + "' and COSTDATE<='" + Edate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            operationList.zyCostmasterList = BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
            if (operationList.zyCostmasterList.Count != 0)
            {
                //int min_CostID = operationList.zyCostmasterList.Min(x => x.CostMasterID);
                //int max_CostID = operationList.zyCostmasterList.Max(x => x.CostMasterID);
                //strWhere_CostOrder = "COSTID>=" + min_CostID + " and COSTID<=" + max_CostID + "";
                strWhere_CostOrder = "COSTID in ( select costmasterid from zy_costmaster where "+strWhere+")";
                operationList.zyCostorderList = BindEntity<ZY_CostOrder>.CreateInstanceDAL(oleDb).GetListArray(strWhere_CostOrder);

                //int min_PatListID = operationList.zyCostmasterList.Min(x => x.PatListID);
                //int max_PatListID = operationList.zyCostmasterList.Max(x => x.PatListID);
                //strWhere_Patlist = "patlistid>=" + min_PatListID + " and patlistid<=" + max_PatListID + "";
                strWhere_Patlist = "patlistid in (select patlistid from zy_costmaster where "+strWhere+")";
                operationList.zyPatList = BindEntity<ZY_PatList>.CreateInstanceDAL(oleDb).GetListArray(strWhere_Patlist);

                //int min_PatID = operationList.zyCostmasterList.Min(x => x.PatID);
                //int max_PatID = operationList.zyCostmasterList.Max(x => x.PatID);
                //strWhere = "Patid>=" + min_PatID + " and Patid<=" + max_PatID + "";
                //operationList.patientinfoList = BindEntity<PatientInfo>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
            }
            else
            {
                operationList.zyCostorderList = new List<ZY_CostOrder>();
            }
        }
        /// <summary>
        /// 交款
        /// </summary>
        /// <param name="Bdate"></param>
        /// <param name="Edate"></param>
        public void GLoadOperationData(DateTime Bdate, DateTime Edate)
        {
            string strWhere_Cost, strWhere_CostOrder, strWhere_Patlist;

            string strWhere = "ACCOUNTDATE>='" + Bdate.ToString("yyyy-MM-dd HH:mm:ss") + "' and ACCOUNTDATE<='" + Edate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            operationList.zyAccountList = BindEntity<ZY_Account>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
            if (operationList.zyAccountList.Count != 0)
            {
                //int min_AccountID = operationList.zyAccountList.Min(x => x.AccountID);
                //int max_AccountID = operationList.zyAccountList.Max(x => x.AccountID);
                //strWhere_Cost = "AccountID>=" + min_AccountID + " and AccountID<=" + max_AccountID + "";
                strWhere_Cost = "AccountID in (select accountid from zy_account where "+strWhere+")";
                operationList.zyCostmasterList = BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).GetListArray(strWhere_Cost);
                if (operationList.zyCostmasterList.Count != 0)
                {
                    //int min_CostID = operationList.zyCostmasterList.Min(x => x.CostMasterID);
                    //int max_CostID = operationList.zyCostmasterList.Max(x => x.CostMasterID);
                    //strWhere_CostOrder = "COSTID>=" + min_CostID + " and COSTID<=" + max_CostID + "";
                    strWhere_CostOrder = "COSTID in (select costmasterid from zy_costmaster where "+strWhere_Cost+")";
                    operationList.zyCostorderList = BindEntity<ZY_CostOrder>.CreateInstanceDAL(oleDb).GetListArray(strWhere_CostOrder);

                    //int min_PatListID = operationList.zyCostmasterList.Min(x => x.PatListID);
                    //int max_PatListID = operationList.zyCostmasterList.Max(x => x.PatListID);
                    //strWhere_Patlist = "patlistid>=" + min_PatListID + " and patlistid<=" + max_PatListID + "";
                    strWhere_Patlist = "patlistid in (select patlistid from zy_costmaster where "+strWhere_Cost+")";
                    operationList.zyPatList = BindEntity<ZY_PatList>.CreateInstanceDAL(oleDb).GetListArray(strWhere_Patlist);

                    //int min_PatID = operationList.zyCostmasterList.Min(x => x.PatID);
                    //int max_PatID = operationList.zyCostmasterList.Max(x => x.PatID);
                    //strWhere = "Patid>=" + min_PatID + " and Patid<=" + max_PatID + "";
                    //operationList.patientinfoList = BindEntity<PatientInfo>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
                }
                else
                {
                    operationList.zyCostorderList = new List<ZY_CostOrder>();
                }
            }
            else
            {
                operationList.zyCostmasterList = new List<ZY_CostMaster>();
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
