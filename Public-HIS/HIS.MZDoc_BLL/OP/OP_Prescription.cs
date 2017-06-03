using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.BLL;

namespace HIS.MZDoc_BLL
{
    /// <summary>
    /// 门诊处方操作类
    /// </summary>
    public class OP_Prescription : BaseBLL
    {
        /// <summary>
        /// 皮试处方处理
        /// </summary>
        /// <param name="presListId">处方明细Id</param>
        /// <param name="result">皮试结果</param>
        /// <returns></returns>
        public static bool SkinTestPresProcess(int presListId, int result)
        {
            string strwhere = Tables.mz_doc_preslist.PRESLISTID + oleDb.EuqalTo() + presListId;
            string[] strvalue = { Tables.mz_doc_preslist.SKINTEST_FLAG + oleDb.EuqalTo() + result };
            BindEntity<Model.Mz_Doc_PresList>.CreateInstanceDAL(oleDb).Update(strwhere, strvalue);
            return true;
        }

        /// <summary>
        /// 计算处方费用
        /// </summary>
        /// <param name="rows">处方数据行</param>
        /// <returns></returns>
        public static decimal GetPresTotalFee(DataRow[] rows)
        {
            if (rows == null || rows.Length <= 0)
            {
                return 0;
            }
            List<HIS.MZDoc_BLL.Prescription> presList = (List<HIS.MZDoc_BLL.Prescription>)HIS.MZDoc_BLL.Public.Function.DataRowsToList<HIS.MZDoc_BLL.Prescription>(rows);
            return (presList.Count <= 0) ? 0 : (new InterFace.PrescMoneyCalculateInterFace().GetPrescriptionTotalMoney(
                presList.FindAll(delegate(HIS.MZDoc_BLL.Prescription pres) { return (pres.SelfDrug_Flag == 0 || !pres.IsDrug); })));
        }

        /// <summary>
        /// 按大项目分类汇总处方费用
        /// </summary>
        /// <param name="rows">处方数据行</param>
        /// <returns></returns>
        public static Hashtable GetPresStatItemFeeTable(DataRow[] rows)
        {
            Hashtable feeTable = new Hashtable();
            if (rows != null && rows.Length > 0)
            {
                List<HIS.MZDoc_BLL.Prescription> presList = (List<HIS.MZDoc_BLL.Prescription>)HIS.MZDoc_BLL.Public.Function.DataRowsToList<HIS.MZDoc_BLL.Prescription>(rows);
                decimal totalFee = 0;
                totalFee = new InterFace.PrescMoneyCalculateInterFace().GetPrescriptionTotalMoney(
                    presList.FindAll(delegate(HIS.MZDoc_BLL.Prescription pres) { return (pres.SelfDrug_Flag == 0 || !pres.IsDrug); })
                , out feeTable, out totalFee);
            }
            return feeTable;
        }
    }
}
