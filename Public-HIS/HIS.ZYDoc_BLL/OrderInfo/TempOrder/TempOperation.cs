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

namespace HIS.ZYDoc_BLL.OrderInfo
{
    partial class TempOperation:BaseBLL
    {
        #region 作废医嘱
        /// <summary>
        /// 作废医嘱（只改医嘱内容，在内容前加“取消”）
        /// </summary>
        /// <param name="rowid"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool Abolish(HIS.Model.ZY_DOC_ORDERRECORD record)
        {
            //作废时加“取消”的内容从数据库中取，不从界面上取　2010.4.6
            string name = BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetFieldValue
                (Tables.zy_doc_orderrecord.ORDER_CONTENT, Tables.zy_doc_orderrecord.ORDER_ID + oleDb.EuqalTo() + record.ORDER_ID).ToString();
            string strSet = Tables.zy_doc_orderrecord.ORDER_CONTENT + oleDb.EuqalTo() + "'" + "【取消】" + name + "'";
            BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(Tables.zy_doc_orderrecord.ORDER_ID + oleDb.EuqalTo() + record.ORDER_ID,
               strSet);
            return true;
        }
        #endregion

        #region  取消作废医嘱
        /// <summary>
        /// 取消作废医嘱（只改医嘱内容）
        /// </summary>
        /// <param name="rowid"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public  List<HIS.Model.ZY_DOC_ORDERRECORD> NotAbolish(HIS.Model.ZY_DOC_ORDERRECORD record)
        {           
            record.ORDER_CONTENT = record.ORDER_CONTENT.ToString().Substring(4, record.ORDER_CONTENT.ToString().Length - 4);
            BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(record);
            return null;
        }
        #endregion

        #region 交病人和出院带药处理
        /// <summary>
        /// 交病人和出院带药处理
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="nrow"></param>
        /// <param name="struc"></param>
        /// <param name="order_type"></param>
        /// <returns></returns>
        public  bool OrderChangeDeal(List<HIS.Model.ZY_DOC_ORDERRECORD> records, int nrow, string struc, string order_type)
        {
            oleDb.BeginTransaction();
            try
            {
                for (int i = 0; i < records.Count; i++)
                {
                    if (records[i].GROUP_ID == records[nrow].GROUP_ID)
                    {
                        records[i].ORDER_TYPE = Convert.ToInt32(order_type);
                        records[i].ORDER_CONTENT = records[i].ORDER_CONTENT.ToString().Trim() + " 「" + struc + "」";
                        records[i].FREQUENCY = "";
                        BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(records[i]);
                    }
                }
                oleDb.CommitTransaction();
                return true;
            }
            catch (System.Exception e)
            {
                oleDb.RollbackTransaction();
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region 删除皮试关联
        /// <summary>
        /// 删除皮试关联
        /// </summary>
        /// <param name="patlistid"></param>
        /// <param name="psid"></param>
        /// <returns></returns>
        public  bool DelPs(int patlistid, decimal psid)
        {
            try
            {
                if (psid == 0)
                {
                    return false;
                }
                string strWhere = Tables.zy_doc_orderrecord.PATID + oleDb.EuqalTo() + patlistid + oleDb.And()
                    + Tables.zy_doc_orderrecord.PS_ORDERID + oleDb.EuqalTo() + psid + oleDb.And() + Tables.zy_doc_orderrecord.DELETE_FLAG + oleDb.EuqalTo() + 0;
                string[] strSet = new string[3];
                strSet[0] = Tables.zy_doc_orderrecord.PS_FLAG + oleDb.EuqalTo() + -1;
                strSet[1] = Tables.zy_doc_orderrecord.PS_ORDERID + oleDb.EuqalTo() + 0;
                strSet[2] = Tables.zy_doc_orderrecord.DELETE_FLAG + oleDb.EuqalTo() + 1;
                BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strWhere, strSet);
                return true;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        public LeaveDeath Leave()
        {
            return new LeaveDeath();
        }

        public TurnDept Turndept()
        {
            return new TurnDept();
        }
    }
}
