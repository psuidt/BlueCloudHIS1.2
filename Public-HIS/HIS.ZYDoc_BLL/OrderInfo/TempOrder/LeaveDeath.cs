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
    partial class LeaveDeath : BaseBLL
    {

        #region 出院医嘱

        #region  出院医嘱执行，更新病人表中病人状态,插入医嘱一条记录
        /// <summary>
        /// 病人出院(死亡)时，插入医嘱一条记录，更新病人表中病人状态，更新修改停嘱的末次
        /// </summary>
        /// <param name="record">插入医嘱一条记录</param>
        /// <param name="patlist">更新病人表中病人状态</param>
        /// <param name="records">更新修改停嘱的末次</param>
        /// <returns></returns>
        public bool Leave(HIS.Model.ZY_DOC_ORDERRECORD record, HIS.Model.ZY_PatList patlist, List<HIS.Model.ZY_DOC_ORDERRECORD> records)
        {
            oleDb.BeginTransaction();
            try
            {
                HIS.ZYDoc_BLL.PatInfo.PatOperation.OutDeath(patlist);
                record.PATID = patlist.PatListID;
                record.PAT_DEPTID = Convert.ToInt32(patlist.CurrDeptCode);   
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
                record.BABYID = 0;                
                record.SERIAL_ID = 0;                          
                record.ORECORD_A2 = 1;
                record.GROUP_ID = PubMethd.GetGroupMax(patlist.PatListID, 1);
                BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Add(record);//插入医嘱一条记录
            
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

        #region 取消出院医嘱，死亡医嘱时修改病人状态，把停嘱医状态恢复医嘱转抄状态度
        /// <summary>
        ///  取消出院和取消死亡时改变病人信息 
        /// </summary>
        /// <param name="patlistid"></param>
        /// <param name="babyid"></param>
        public bool updatePatType(int patlistid, int babyid, int deptid, HIS.Model.ZY_DOC_ORDERRECORD record)
        {
            oleDb.BeginTransaction();
            try
            {   
                string strWhere1 = Tables.zy_doc_orderrecord.ORDER_TYPE + oleDb.EuqalTo() + 0 + oleDb.And()
                    + Tables.zy_doc_orderrecord.DELETE_FLAG + oleDb.EuqalTo() + 0 + oleDb.And()
                    + Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + 3 + oleDb.And()
                    + Tables.zy_doc_orderrecord.PATID + oleDb.EuqalTo() + patlistid + oleDb.And()
                    + Tables.zy_doc_orderrecord.BABYID + oleDb.EuqalTo() + 0;
                string[] strSet1 = new string[4];
                strSet1[0] = Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + 2;
                strSet1[1] = Tables.zy_doc_orderrecord.EORDER_DATE + oleDb.EuqalTo() + "'0001-01-01 00:00:00.000000'";
                strSet1[2] = Tables.zy_doc_orderrecord.EORDER_DOC + oleDb.EuqalTo() + 0;
                strSet1[3] = Tables.zy_doc_orderrecord.TEMINAL_TIMES + oleDb.EuqalTo() + 0;
              
                HIS.ZYDoc_BLL.PatInfo.PatOperation.CancelOutDeath(patlistid);
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
        #endregion
    }
}
