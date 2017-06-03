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
   partial class TurnDept:BaseBLL
    {
        #region 转科医嘱
        #region 取消转科时的操作
        /// <summary>
        /// 取消转科
        /// </summary>
        /// <param name="patlistid"></param>
        /// <param name="deptid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public  bool DelTurn(int patlistid, int deptid, int userid, HIS.Model.ZY_DOC_ORDERRECORD record)
        {
            oleDb.BeginTransaction();
            try
            {
                string strWhere = Tables.zy_doc_transdept.PATID + oleDb.EuqalTo() + patlistid + oleDb.And()
                    + Tables.zy_doc_transdept.ORIGE_DEPT + oleDb.EuqalTo() + deptid; 
                   // + oleDb.And()+ Tables.zy_doc_transdept.OPERATOR + oleDb.EuqalTo() + userid;
                string[] strSet = new string[3];
                strSet[0] = Tables.zy_doc_transdept.CANCEL_FLAG + oleDb.EuqalTo() + 1;
                strSet[1] = Tables.zy_doc_transdept.CANCEL_USER + oleDb.EuqalTo() + userid;
                strSet[2] = Tables.zy_doc_transdept.CANCEL_DATE + oleDb.EuqalTo()  +"'" + XcDate.ServerDateTime + "'";

                string strWhere1 = Tables.zy_doc_orderrecord.ORDER_TYPE + oleDb.EuqalTo() + 0 + oleDb.And()
                     + Tables.zy_doc_orderrecord.DELETE_FLAG + oleDb.EuqalTo() + 0 + oleDb.And()
                     + Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + 3 + oleDb.And()
                     + Tables.zy_doc_orderrecord.PATID + oleDb.EuqalTo() + patlistid;
                string[] strSet1 = new string[4];
                strSet1[0] = Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + 2;
                strSet1[1] = Tables.zy_doc_orderrecord.EORDER_DATE + oleDb.EuqalTo() + "'0001-01-01 00:00:00.000000'";
                strSet1[2] = Tables.zy_doc_orderrecord.EORDER_DOC + oleDb.EuqalTo() + 0;
                strSet1[3] = Tables.zy_doc_orderrecord.TEMINAL_TIMES + oleDb.EuqalTo() + 0;

                record.GROUP_ID = PubMethd.GetGroupMax(patlistid, 1);
                BindEntity<HIS.Model.ZY_DOC_TRANSDEPT>.CreateInstanceDAL(oleDb).Update(strWhere, strSet);
                BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strWhere1, strSet1);
                BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(record);

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

        #region 转科医嘱执行,更新病人表中病人状态，插入医嘱表记录，更新修改停嘱的末次，插转科表记录
        /// <summary>
        /// 转科时的操作 
        /// </summary>
        /// <param name="record">插入医嘱一条记录</param>
        /// <param name="transdept">插入转科表一条记录</param>
        /// <param name="records">更新修改停嘱的末次</param>
        /// <returns></returns>
        public  bool Turn(HIS.Model.ZY_DOC_ORDERRECORD record, HIS.Model.ZY_DOC_TRANSDEPT transdept, List<HIS.Model.ZY_DOC_ORDERRECORD> records)
        {
            oleDb.BeginTransaction();
            try
            {
                //20100524.2.03 转科申请时部分赋值放业务逻辑层
                record.ORECORD_A2 = 1;
                record.GROUP_ID = PubMethd.GetGroupMax(record.PATID, 1);
                record.BABYID = 0;
                record.ORDER_TYPE = 1;
                record.ITEM_TYPE = 10;
                record.ORDITEM_ID = -1;
                record.AMOUNT = 0;
                record.PRES_AMOUNT = 1;
                record.UNIT = "";
                record.FIRSET_TIMES = 1;
                record.ORDER_USAGE = "";
                record.FREQUENCY = "1";
                record.DELETE_FLAG = 0;
                record.STATUS_FALG = 1;
                record.SERIAL_ID = 0;
                BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Add(record);//插入医嘱一条记录
                transdept.ORDER_ID = record.ORDER_ID;
                BindEntity<HIS.Model.ZY_DOC_TRANSDEPT>.CreateInstanceDAL(oleDb).Add(transdept);
                for (int i = 0; i < records.Count; i++)//更新修改停嘱的末次
                {
                    BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(records[i]);
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
        #endregion  

    }
}
