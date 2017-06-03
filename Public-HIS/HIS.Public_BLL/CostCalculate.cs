using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.BLL;
using HIS.SYSTEM.Core;

namespace HIS.Public_BLL
{
    struct CostCalculate
    {
        public int CalculateType;

        public decimal HighFee;
        public decimal HighBx;
        public decimal BxWarn;

        public decimal AllFee;
        public decimal UndulateFee;
        public decimal EximaFee;
        public decimal SelfFee;
        public decimal BxRate;
        public decimal ToilFee;

        public decimal ResultFee;
    }

    public class Op_CostCalculate:BaseBLL
    {
        /// <summary>
        /// 获取病人类型
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPatientType()
        {
            try
            {
                string strWhere = Tables.base_patienttype_cost.ZY_FLAG + oleDb.EuqalTo() + "1"
                    + oleDb.And() + Tables.base_patienttype_cost.DEL_FLAG + oleDb.EuqalTo() + "0"
                    + oleDb.OrderBy(Tables.base_patienttype_cost.PATTYPECODE);
                return BindEntity<object>.CreateInstanceDAL(oleDb, Tables.BASE_PATIENTTYPE_COST).GetList(strWhere
                    , oleDb.FiledNameBM(Tables.base_patienttype_cost.PATTYPECODE, "code")
                    , Tables.base_patienttype_cost.NAME);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 得到公费记账的用户单位
        /// </summary>
        /// <returns></returns>
        public static DataTable GetWorkUnit()
        {
            return BindEntity<object>.CreateInstanceDAL(oleDb, Tables.BASE_WORK_UNIT).GetList("");
        }

        /// <summary>
        /// 根据病人列表ID获取病人类型代码
        /// </summary>
        /// <param name="patlistId">病人列表ID</param>
        /// <returns></returns>
        public static string GetPatlistType(int patlistId)
        {
            string strWhere = Tables.zy_patlist.PATLISTID + oleDb.EuqalTo() + patlistId;
            string patCode = BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetFieldValue("PATIENTCODE", strWhere).ToString();
            return patCode;
        }

        /// <summary>
        /// 得到试算结果
        /// </summary>
        /// <param name="cal"></param>
        /// <param name="flag"></param>
        private void GetResult(ref CostCalculate cal,string flag)
        {
            if (cal.AllFee <= cal.SelfFee)
            {
                cal.ResultFee = 0;
            }
            else
            {
                decimal resultFee = ((cal.AllFee - cal.EximaFee - cal.UndulateFee - cal.SelfFee) * cal.BxRate / 100);
                decimal eHighFee = (cal.HighFee - cal.ToilFee);
                if (resultFee > eHighFee)//最高额度50000
                {
                    resultFee = eHighFee;
                }
                //每次报销2000
                if (flag != "农合")//新农合没有每次最高报销额度
                    resultFee = resultFee >= cal.HighBx ? cal.HighBx : resultFee;

                cal.ResultFee = resultFee;
            }
        }
    }
}
