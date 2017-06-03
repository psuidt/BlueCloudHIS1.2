using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.Model;
using HIS.SYSTEM;
using HIS.SYSTEM.Core;

namespace HIS.YP_BLL
{
    /// <summary>
    /// 药库批次处理器
    /// </summary>
    class BatchProcessor:HIS.SYSTEM.Core.BaseBLL
    {
        BatchProcessor()
        { 
        }

        /// <summary>
        /// 增加药品批次记录
        /// </summary>
        /// <param name="orderList">明细链表</param>
        /// <param name="inStoreTime">入库时间</param>
        static public void AddBatchNum(List<BillOrder> orderList, DateTime inStoreTime)
        {
            string strWhere = "";
            YP_Batch newBatch = new YP_Batch();
            foreach (BillOrder billOrder in orderList)
            {                
                YP_InOrder order = (YP_InOrder)billOrder;
                //查询入库明细中的药品是否已经有批次了
                strWhere = BLL.Tables.yk_batch.BATCHNUM + oleDb.EuqalTo() + "'" + order.BatchNum.ToString() + "'" +
                    oleDb.And() + BLL.Tables.yk_batch.MAKERDICID + oleDb.EuqalTo() + order.MakerDicID.ToString() + 
                    oleDb.And() + BLL.Tables.yk_batch.DEPTID + oleDb.EuqalTo() + order.DeptID.ToString();
                YP_Batch oldBatch = BindEntity<YP_Batch>.CreateInstanceDAL(oleDb, BLL.Tables.YK_BATCH).GetModel(strWhere);
                //如果不是针对批次表中药品入库，则自动在批次表中增加一条批次记录
                if (oldBatch == null)
                {
                    if (order.InNum <= 0)
                    {
                        throw new Exception("新入库药品入库数量不能小于0");
                    }
                    newBatch.Batchnum = order.BatchNum;
                    newBatch.Currentnum = order.InNum;
                    newBatch.Del_flag = 0;
                    newBatch.Deptid = order.DeptID;
                    newBatch.Instoretime = inStoreTime;
                    newBatch.Makerdicid = order.MakerDicID;
                    newBatch.Unit = order.LeastUnit;
                    newBatch.Unitnum = order.UnitNum;
                    newBatch.ValidityDate = order.ValidityDate;
                    BindEntity<YP_Batch>.CreateInstanceDAL(oleDb, BLL.Tables.YK_BATCH).Add(newBatch);
                }
                //如果是批次表中的药品，增加批次表中药品数量
                else
                {
                    if (order.InNum > 0)
                    {
                        oldBatch.Currentnum = oldBatch.Currentnum + order.InNum;
                        oldBatch.Del_flag = 0;
                    }
                    else
                    {
                        if (oldBatch.Currentnum + order.InNum < 0)
                        {
                            string drugName = "药品名称：" + DrugBaseDataBll.GetDurgName(order.MakerDicID);
                            string batchNum = " 批次号：" + order.BatchNum;
                            throw new Exception(drugName + batchNum + " 退库数量过多，无法退库");
                        }
                        else
                        {
                            oldBatch.Currentnum = oldBatch.Currentnum + order.InNum;
                            if (oldBatch.Currentnum == 0)
                            {
                                oldBatch.Del_flag = 1;
                            }
                        }
                    }
                    BindEntity<YP_Batch>.CreateInstanceDAL(oleDb, BLL.Tables.YK_BATCH).Update(oldBatch);
                }
            }
        }

        /// <summary>
        /// 退药品批次数量
        /// </summary>
        /// <param name="orderList">药品退库明细</param>
        static public void BackBatchNum(List<BillOrder> orderList)
        {
            string strWhere = "";
            YP_Batch reduceBatch;
            foreach (BillOrder billOrder in orderList)
            {
                YP_InOrder order = (YP_InOrder)billOrder;
                //获取出库单选择的出库明细对应的批次
                strWhere = BLL.Tables.yk_batch.BATCHNUM + oleDb.EuqalTo() + "'" + order.BatchNum + "'" +
                    oleDb.And() + BLL.Tables.yk_batch.MAKERDICID + oleDb.EuqalTo() + order.MakerDicID +
                    oleDb.And() + BLL.Tables.yk_batch.DEPTID + oleDb.EuqalTo() + order.DeptID;
                reduceBatch = BindEntity<YP_Batch>.CreateInstanceDAL(oleDb, BLL.Tables.YK_BATCH).GetModel(strWhere);
                if (reduceBatch != null)
                {
                    if (reduceBatch.Currentnum - order.InNum > 0)
                    {
                        reduceBatch.Currentnum = reduceBatch.Currentnum - order.InNum;
                        reduceBatch.Del_flag = 0;
                        BindEntity<YP_Batch>.CreateInstanceDAL(oleDb, BLL.Tables.YK_BATCH).Update(reduceBatch);
                    }
                    else if (reduceBatch.Currentnum - order.InNum == 0)
                    {
                        reduceBatch.Currentnum = 0;
                        reduceBatch.Del_flag = 1;
                        BindEntity<YP_Batch>.CreateInstanceDAL(oleDb, BLL.Tables.YK_BATCH).Update(reduceBatch);
                    }
                    else
                    {
                        string strName = DrugBaseDataBll.GetDurgName(reduceBatch.Makerdicid);
                        throw new Exception("[" + strName + "]" + "该药品退库批次数量大于药库批次库存数量，请修改退库单");
                    }
                }
                else
                {
                    string drugName = DrugBaseDataBll.GetDurgName(order.MakerDicID);
                    throw new Exception("[" + drugName + "]" + "药品批次输入错误。。。。。。");
                }
            }
        }

        /// <summary>
        /// 减少药品批次
        /// </summary>
        /// <param name="orderList">出库单明细链表</param>
        static public void ReduceBatchNum(List<BillOrder> orderList)
        {
            string strWhere = "";
            YP_Batch reduceBatch;
            foreach (BillOrder billOrder in orderList)
            {
                YP_OutOrder order = (YP_OutOrder)billOrder;
                //获取出库单选择的出库明细对应的批次
                strWhere = BLL.Tables.yk_batch.BATCHNUM + oleDb.EuqalTo() + "'" + order.ProductNum + "'" +
                    oleDb.And() + BLL.Tables.yk_batch.MAKERDICID + oleDb.EuqalTo() + order.MakerDicID +
                    oleDb.And() + BLL.Tables.yk_batch.DEPTID + oleDb.EuqalTo() + order.DeptID;
                reduceBatch = BindEntity<YP_Batch>.CreateInstanceDAL(oleDb, BLL.Tables.YK_BATCH).GetModel(strWhere);
                if (reduceBatch != null)
                {
                    if (reduceBatch.Currentnum - order.OutNum > 0)
                    {
                        reduceBatch.Currentnum = reduceBatch.Currentnum - order.OutNum;
                        reduceBatch.Del_flag = 0;
                        BindEntity<YP_Batch>.CreateInstanceDAL(oleDb, BLL.Tables.YK_BATCH).Update(reduceBatch);
                    }
                    else if (reduceBatch.Currentnum - order.OutNum == 0)
                    {
                        reduceBatch.Currentnum = 0;
                        reduceBatch.Del_flag = 1;
                        BindEntity<YP_Batch>.CreateInstanceDAL(oleDb, BLL.Tables.YK_BATCH).Update(reduceBatch);
                    }
                    else
                    {
                        string strName = DrugBaseDataBll.GetDurgName(reduceBatch.Makerdicid);
                        throw new Exception("["+strName+"]"+"该药品申请批次数量大于药库批次库存数量，请修改入库申请单");
                    }
                }
                else
                {
                    string drugName = DrugBaseDataBll.GetDurgName(order.MakerDicID);
                    throw new Exception("["+drugName+"]"+"药品批次输入错误。。。。。。");
                }
            }
        }

        /// <summary>
        /// 按盘点单明细更新药品批次
        /// </summary>
        /// <param name="orderList">盘点单明细列表</param>
        static public void UpdateBatchNum(List<YP_CheckOrder> orderList)
        {
            string strWhere = "";
            YP_Batch updateBatch;
            foreach (YP_CheckOrder order in orderList)
            {
                strWhere = BLL.Tables.yk_batch.BATCHNUM + oleDb.EuqalTo() + "'" + order.BatchNum + "'" +
                    oleDb.And() + BLL.Tables.yk_batch.MAKERDICID + oleDb.EuqalTo() + order.MakerDicID +
                    oleDb.And() + BLL.Tables.yk_batch.DEPTID + oleDb.EuqalTo() + order.DeptID;
                updateBatch = BindEntity<YP_Batch>.CreateInstanceDAL(oleDb, BLL.Tables.YK_BATCH).GetModel(strWhere);
                if (updateBatch != null)
                {
                    if (updateBatch.Currentnum != order.CheckNum)
                    {
                        updateBatch.Currentnum = order.CheckNum;
                        updateBatch.ValidityDate = order.ValidityDate;
                        if (updateBatch.Currentnum == 0)
                        {
                            updateBatch.Del_flag = 1;
                        }
                        else
                        {
                            updateBatch.Del_flag = 0;
                        }
                        BindEntity<YP_Batch>.CreateInstanceDAL(oleDb, BLL.Tables.YK_BATCH).Update(updateBatch);
                    }
                }
                else
                {
                    throw new Exception("药品从未入过库");
                }
            }
        }

        /// <summary>
        /// 更新批次记录
        /// </summary>
        /// <param name="batch">药品批次实体</param>
        /// <param name="validityDate">到效日期更新值</param>
        static public void UpdateBatch(YP_Batch batch, DateTime validityDate)
        {
            try
            {
                if (batch != null)
                {
                    batch.ValidityDate = validityDate;
                    BindEntity<YP_Batch>.CreateInstanceDAL(oleDb, BLL.Tables.YK_BATCH).Update(batch);
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
