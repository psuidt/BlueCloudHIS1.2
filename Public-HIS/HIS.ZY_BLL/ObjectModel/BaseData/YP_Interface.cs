using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.SYSTEM.Core;
using HIS.ZY_BLL.DataModel;


namespace HIS.ZY_BLL
{
    /// <summary>
    /// 药品发药类
    /// </summary>
    public class YP_Interface : BaseBLL 
    {
        /// <summary>
        /// 根据住院号得到病人信息
        /// </summary>
        /// <param name="CureNo">住院号</param>
        /// <returns></returns>
        public static HIS.Model.ZY_PatList GetPatInfo(string CureNo)
        {
            ZY_PatList zypl = new ZY_PatList(oleDb);
            zypl = zypl.GetPatInfo(CureNo);
            if (zypl == null)
                throw new Exception("请输入正确住院号！");
            HIS.Model.ZY_PatList zyp = new HIS.Model.ZY_PatList();
            zyp = (HIS.Model.ZY_PatList)HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjectToObj(zypl, zyp);
            return zyp;
        }
        /// <summary>
        /// 得到在院病人信息列表
        /// </summary>
        /// <returns></returns>
        public static List<HIS.Model.ZY_PatList> GetPatInfo()
        {
            return Charge(OperPatInfo(null,null));
        }
        /// <summary>
        /// 得到在院病人信息
        /// </summary>
        /// <param name="CureDeptCode">药房代码</param>
        /// <returns></returns>
        public static List<HIS.Model.ZY_PatList> GetPatInfo(int YfCode)
        {
            return Charge(OperPatInfo(YfCode.ToString(), null));
        }
        /// <summary>
        /// 得到在院病人信息
        /// </summary>
        /// <param name="YfCode">药房代码</param>
        /// <param name="CureDeptCode">病人住院科室代码</param>
        /// <returns></returns>
        public static List<HIS.Model.ZY_PatList> GetPatInfo(int YfCode, int CureDeptCode)
        {
            return Charge(OperPatInfo(YfCode.ToString(), CureDeptCode.ToString()));
        }
        /// <summary>
        /// 得到病人信息
        /// </summary>
        /// <param name="IsIn">是否在院</param>
        /// <param name="deptId">病人所在科室</param>
        /// <returns></returns>
        public static List<HIS.Model.ZY_PatList> GetPatInfo(bool IsIn, int deptId)
        {
            ZY_PatList zypl = new ZY_PatList();
            BindPatListVal bplv = new BindPatListVal();
            bplv.IsIn = IsIn;
            bplv.DeptCode = deptId.ToString();
            zypl.bindPatListVal = bplv;
            zypl.bindPatListType = BindPatListType.住院病人列表;
            return Charge(zypl.BindPatList());
        }
        /// <summary>
        /// 得到只有发药记录的病人
        /// </summary>
        /// <param name="CureDeptCode"></param>
        /// <returns></returns>
        private static List<ZY_PatList> OperPatInfo(string YfCode, string CureDeptCode)
        {
            ZY_PatList zypl = new ZY_PatList(oleDb);

            List<ZY_PatList> zyPL = null;
            BindPatListVal bplv = new BindPatListVal();
            if (CureDeptCode == null)
            {
                bplv.IsIn = true;
                zypl.bindPatListVal = bplv;
                zypl.bindPatListType = BindPatListType.住院病人列表;
                zyPL = zypl.BindPatList();
            }
            else
            {
                bplv.IsIn = true;
                bplv.DeptCode = CureDeptCode.ToString();
                zypl.bindPatListVal = bplv;
                zypl.bindPatListType = BindPatListType.住院病人列表;
                zyPL = zypl.BindPatList();
            }
            zyPL.RemoveAll(delegate(ZY_PatList x)
            {
                DataTable dt = GetPatPresInfo(x.PatListID, YfCode);
                if (dt == null || dt.Rows.Count == 0)
                {
                    return true;
                }
                return false;
            });
            return zyPL;
        }
        /// <summary>
        /// 根据病人ID得到待发药处方
        /// </summary>
        /// <param name="PatListID">病人ID</param>
        /// <param name="deptcode">药房代码</param>
        /// <returns></returns>
        public static DataTable GetPatPresInfo(int PatListID, string deptcode)
        {
            ZY_PresOrder zypo = new ZY_PresOrder(oleDb);
            return zypo.GetSendGrugPres(PatListID, deptcode);
        }
        /// <summary>
        /// 根据病人ID得到待发药处方
        /// </summary>
        /// <param name="PatListID">病人ID</param>
        /// <param name="deptcode">药房代码</param>
        /// <param name="Total_fee">输出总金额</param>
        /// <returns></returns>
        public static DataTable GetPatPresInfo(int PatListID, string deptcode, out decimal Total_fee)
        {
            Total_fee = 0;
            ZY_PresOrder zypo = new ZY_PresOrder(oleDb);
            DataTable dt = zypo.GetSendGrugPres(PatListID, deptcode);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Total_fee += Convert.ToDecimal(dt.Rows[i]["TOLAL_FEE"]);
            }
            return dt;
        }
        /// <summary>
        /// 根据病人ID得到待发药处方总金额
        /// </summary>
        /// <param name="PatListID"></param>
        /// <param name="deptcode"></param>
        /// <returns></returns>
        public static decimal GetPatPresInfoTotalFee(int PatListID, string deptcode)
        {
            ZY_PresOrder zypo = new ZY_PresOrder(oleDb);
            return zypo.GetSendGrugPresTotalFee(PatListID, deptcode);
        }
        /// <summary>
        /// 根据住院号得到待发药处方信息
        /// </summary>
        /// <param name="CureNo">住院号</param>
        /// <param name="deptcode">药房代码</param>
        /// <returns></returns>
        public static DataTable GetPatPresInfo(string CureNo, string deptcode)
        {
            ZY_PresOrder zypo = new ZY_PresOrder(oleDb);
            return zypo.GetSendGrugPres(CureNo, deptcode);
        }
        /// <summary>
        /// 根据住院号得到待发药处方信息
        /// </summary>
        /// <param name="CureNo">住院号</param>
        /// <param name="deptcode">药房代码</param>
        /// <param name="Total_fee">输出总金额</param>
        /// <returns></returns>
        public static DataTable GetPatPresInfo(string CureNo, string deptcode, out decimal Total_fee)
        {
            ZY_PresOrder zypo = new ZY_PresOrder(oleDb);

            Total_fee = 0;
            DataTable dt = zypo.GetSendGrugPres(CureNo, deptcode);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Total_fee += Convert.ToDecimal(dt.Rows[i]["TOLAL_FEE"]);
            }
            return dt;
        }
        /// <summary>
        /// �更新发药标识
        /// </summary>
        /// <param name="PresOrderID">处方明细ID</param>
        /// <returns></returns>
        public static bool UpdateSendDrugFlag(int PresOrderID)
        {
            try
            {
                
                string strWhere ="PRESORDERID =" + PresOrderID;
                if (BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetFieldValue("drug_flag",strWhere).ToString() == "0")  //update by heyan
                {
                    string str = "DRUG_FLAG = 1";
                    BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(strWhere, str);
                }
                else if (BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetFieldValue("drug_flag",strWhere).ToString() == "1")
                {
                    BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(strWhere, "DRUG_FLAG = 2");
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 更新退药标?
        /// </summary>
        /// <param name="PresOrderID">处方明细ID</param>
        /// <returns></returns>
        public static bool UpdateBackDrugFlag(int PresOrderID)
        {
            try
            {
                string strWhere = "PRESORDERID ="+ PresOrderID;
                string str = "DRUG_FLAG =0";
                BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(strWhere, str);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 根据住院处方明细ID获取发药总量
        /// </summary>
        /// <param name="recipeOrderID">处方明细ID</param>
        /// <returns>该处方明细ID对应的退药总量</returns>
        public static decimal UpdateSendDrugNum(int recipeOrderID)
        {
            try
            {
                string strWhere1 = "DRUGOC_FLAG = 0 and ORDERRECIPEID ="+ recipeOrderID + " and INPATIENTID <>'' ";
                object obj1 = BindEntity<object>.CreateInstanceDAL(oleDb, "YF_DRORDER").GetSum("DRUGOCNUM", strWhere1);
                string strWhere2 = "DRUGOC_FLAG = 1 and ORDERRECIPEID " + recipeOrderID + " and INPATIENTID <>''";
                object obj2 = BindEntity<object>.CreateInstanceDAL(oleDb, "YF_DRORDER").GetSum("DRUGOCNUM", strWhere2);

                return Convert.ToDecimal(obj2.ToString().Trim()) - Convert.ToDecimal(obj1.ToString().Trim());
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private static List<HIS.Model.ZY_PatList> Charge(List<ZY_PatList> zypList)
        {
            List<HIS.Model.ZY_PatList> zypl1 = new List<HIS.Model.ZY_PatList>();
            HIS.Model.ZY_PatList zyp = null;
            for (int i = 0; i < zypList.Count; i++)
            {
                zyp = new HIS.Model.ZY_PatList();
                zyp = (HIS.Model.ZY_PatList)HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjectToObj(zypList[i], zyp);
                zypl1.Add(zyp);
            }
            return zypl1;
        }
    }
}