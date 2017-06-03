using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using HIS.Model;
using HIS.DAL;
using HIS.SYSTEM;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.SYSTEM.BussinessLogicLayer.Classes;
using HIS.SYSTEM.Core;
using HIS.BLL;

namespace HIS.YP_BLL
{
    /// <summary>
    /// 药品库存信息对象
    /// </summary>
    public class YP_StoreNum
    {
        /// <summary>
        /// 查询编码（）
        /// </summary>
        public string queryKey;
        /// <summary>
        /// 厂家典ID
        /// </summary>
        public int makerDicId;
        /// <summary>
        /// 库存数量
        /// </summary>
        public decimal storeNum;
        /// <summary>
        /// 基本单位ID
        /// </summary>
        public int smallUnit;
    }

    /// <summary>
    /// 药品批次库存对象信息
    /// </summary>
    public class YP_StoreBatch:YP_StoreNum
    {
        /// <summary>
        /// 批次号
        /// </summary>
        public string batchNum;
    }

    /// <summary>
    /// 库存处理器
    /// </summary>
    public abstract class StoreProcessor:HIS.SYSTEM.Core.BaseBLL
    {
        /// <summary>
        /// 药品数据访问层对象
        /// </summary>
        protected YP_Dal ypDal = new YP_Dal();

        /// <summary>
        /// 库存查询对象
        /// </summary>
        protected StoreQuery storeQuery;

        /// <summary>
        /// 按业务单据内容更新库存
        /// </summary>
        /// <param name="billMaster">单据头</param>
        /// <param name="orderList">单据明细</param>
        /// <returns>药品更新后的库存信息</returns>
        public abstract Hashtable ChangeStoreNum(BillMaster billMaster, List<BillOrder> orderList);

        /// <summary>
        /// 添加库存
        /// </summary>
        /// <param name="makerId">药品厂家ＩＤ</param>
        /// <param name="deptId">药剂科室ＩＤ</param>
        /// <param name="addNum">增加数量</param>
        /// <returns>增加后的库存数量</returns>
        public abstract decimal AddStoreNum(int makerId, int deptId, decimal addNum);

        /// <summary>
        /// 减少库存
        /// </summary>
        /// <param name="makerId">药品厂家ＩＤ</param>
        /// <param name="deptId">药剂科室ＩＤ</param>
        /// <param name="reduceNum">减少数量</param>
        /// <returns>减少后的药品库存数量</returns>
        public abstract decimal ReduceStoreNum(int makerId, int deptId, decimal reduceNum);

        /// <summary>
        /// 修改药品库存
        /// </summary>
        /// <param name="makerId">药品厂家典ID</param>
        /// <param name="deptId">药剂科室ID</param>
        /// <param name="newNum">修改库存数量</param>
        public abstract void UpdateStoreNum(int makerId, int deptId, decimal newNum);

        /// <summary>
        /// 更新库存上下线
        /// </summary>
        /// <param name="store">药品库存实体</param>
        public abstract void UpdateStoreLimit(YP_Storage store);


        /// <summary>
        /// 更新药品批次
        /// </summary>
        /// <param name="orderList">药品盘存明细信息表</param>
        public void UpdateBatch(List<YP_CheckOrder> orderList)
        {
            try
            {
                BatchProcessor.UpdateBatchNum(orderList);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 更新药品批次信息
        /// </summary>
        /// <param name="batch">药品批次实体</param>
        /// <param name="newValidityTime">更新的到效日期</param>
        public void UpdateBatch(YP_Batch batch, DateTime newValidityTime)
        {
            try
            {
                BatchProcessor.UpdateBatch(batch, newValidityTime); 
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    abstract class YF_StoreProcessor : StoreProcessor
    {
        public YF_StoreProcessor()
        {
            storeQuery = new YF_StoreQuery();
            ypDal._oleDb = oleDb;
        }

        public override void UpdateStoreLimit(YP_Storage store)
        {
            try
            {
                BindEntity<HIS.Model.YP_Storage>.CreateInstanceDAL(oleDb, Tables.YF_STORAGE).Update(store);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public override decimal AddStoreNum(int makerId, int deptId, decimal addNum)
        {
            try
            {
                ypDal._oleDb = oleDb;
                //如果药房存在药品
                decimal oldNum = storeQuery.QueryNum(makerId, deptId);
                if (oldNum != -1)
                {
                    if (oldNum + addNum >= 0)
                    {
                        //添加药品信息
                        ypDal.YF_Storage_AddStore(makerId, addNum, deptId);
                        return oldNum + addNum;
                    }
                    else
                    {
                        string drugName = "[" + DrugBaseDataBll.GetDurgName(makerId) + "]";
                        throw new Exception(drugName +"药品退库数量过多，请核查药品退库数量");
                    }
                }
                return oldNum;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public override decimal ReduceStoreNum(int makerId, int deptId, decimal reduceNum)
        {
            try
            {
                ypDal._oleDb = oleDb;
                //查询药品数量
                decimal storeNum = storeQuery.QueryNum(makerId, deptId);
                //如果减少的库存量小于药品当前库存
                if (reduceNum <= storeNum)
                {
                    //减少药品库存
                    ypDal.YF_Storage_ReduceStore(makerId, reduceNum, deptId);
                    return storeNum - reduceNum;
                }
                return -1;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public override void UpdateStoreNum(int makerId, int deptId, decimal newNum)
        {
            try
            {
                ypDal._oleDb = oleDb;
                ypDal.YF_Storage_UpdateStore(makerId, newNum, deptId);
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    class YF_In_StoreProcessor:YF_StoreProcessor
    {
        public override Hashtable ChangeStoreNum(BillMaster billMaster, List<BillOrder> orderList)
        {
            try
            {
                Hashtable storeNumHash = new Hashtable();
                YP_InMaster inStore = (YP_InMaster)billMaster;
                YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                foreach (YP_InOrder orderInstore in orderList)
                {
                    decimal addNum = 0;
                    YP_StoreNum storeNum = new YP_StoreNum();
                    storeNum.makerDicId = orderInstore.MakerDicID;                   
                    IBaseDAL<YP_Storage> storeDao = BindEntity<YP_Storage>.CreateInstanceDAL(oleDb, BLL.Tables.YF_STORAGE);
                    if (inStore.OpType == ConfigManager.OP_YF_INSTORE)
                    {
                        addNum = orderInstore.InNum;
                        storeNum.smallUnit = orderInstore.LeastUnit;
                    }
                    else
                    {
                        addNum = orderInstore.InNum * orderInstore.UnitNum;
                        storeNum.smallUnit = ypDal.Unit_GetSmallUnit(storeNum.makerDicId);
                        
                    }
                    //增加库存
                    decimal rtn = base.AddStoreNum(orderInstore.MakerDicID, orderInstore.DeptID, addNum);
                    if (rtn == -1)
                    {
                        if (addNum <= 0)
                        {
                            string drugName = "[" + DrugBaseDataBll.GetDurgName(orderInstore.MakerDicID) + "]";
                            throw new Exception(drugName + "药品库存数量为0，无法录入负数");
                        }
                        YP_Storage drugStore = new YP_Storage();
                        drugStore.CurrentNum = addNum;
                        drugStore.Del_Flag = 0;
                        drugStore.DeptID = inStore.DeptID;
                        drugStore.LeastUnit = storeNum.smallUnit;
                        drugStore.LowerLimit = 0;
                        drugStore.LStockPrice = orderInstore.StockPrice;
                        drugStore.MakerDicID = orderInstore.MakerDicID;
                        drugStore.RegTime = inStore.RegTime;
                        drugStore.UnitNum = orderInstore.UnitNum;
                        drugStore.UpperLimit = 0;
                        storeDao.Add(drugStore);
                        storeNum.storeNum = addNum;
                    }
                    else
                    {
                        storeNum.storeNum = rtn;
                    }
                    storeNum.queryKey = orderInstore.MakerDicID.ToString() + orderInstore.BatchNum.ToString();
                    storeNumHash.Add(storeNum.queryKey, storeNum);
                }
                return storeNumHash;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    class YF_Out_StoreProcessor : YF_StoreProcessor
    {
        public override Hashtable ChangeStoreNum(BillMaster billMaster, List<BillOrder> orderList)
        {
            try
            {                
                Hashtable storeNumHash = new Hashtable();
                foreach (BillOrder order in orderList)
                {
                    YP_StoreNum storeNum = new YP_StoreNum();
                    YP_OutOrder orderOutstore = (YP_OutOrder)order;
                    storeNum.smallUnit = ypDal.Unit_GetSmallUnit(orderOutstore.MakerDicID);
                    storeNum.makerDicId = orderOutstore.MakerDicID;
                    decimal reduceNum = orderOutstore.OutNum * orderOutstore.UnitNum;
                    decimal rtn = ReduceStoreNum(orderOutstore.MakerDicID, orderOutstore.DeptID, reduceNum);
                    if (rtn != -1)
                    {
                        storeNum.storeNum = rtn;
                    }
                    else
                    {
                        throw new Exception("出库数量过多，审核失败");
                    }
                    storeNumHash.Add(storeNum.makerDicId, storeNum);
                }
                return storeNumHash;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    class YF_Check_StoreProcessor : YF_StoreProcessor
    {
        public override Hashtable ChangeStoreNum(BillMaster billMaster, List<BillOrder> orderList)
        {
            try
            {
                Hashtable storeNumHash = new Hashtable();
                foreach (BillOrder order in orderList)
                {
                    YP_CheckOrder orderCheck = (YP_CheckOrder)order;
                    YP_StoreNum storeNum = new YP_StoreNum();
                    if (orderCheck.CheckNum != orderCheck.FactNum)
                    {
                        storeNum.makerDicId = orderCheck.MakerDicID;
                        storeNum.smallUnit = orderCheck.LeastUnit;
                        storeNum.storeNum = Convert.ToInt32(orderCheck.CheckNum);
                        storeNumHash.Add(storeNum.makerDicId, storeNum);
                        UpdateStoreNum(orderCheck.MakerDicID, orderCheck.DeptID, Convert.ToInt32(orderCheck.CheckNum));
                    }
                }
                return storeNumHash;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    class Disp_StoreProcessor : YF_StoreProcessor
    {
        public override Hashtable ChangeStoreNum(BillMaster billMaster, List<BillOrder> orderList)
        {
            try
            {
                Hashtable storeNumHash = new Hashtable();
                YP_DRMaster dispMaster = (YP_DRMaster)billMaster;
                foreach (BillOrder baseOrder in orderList)
                {
                    YP_StoreNum storeNum = new YP_StoreNum();
                    YP_DROrder order = (YP_DROrder)baseOrder;
                    storeNum.makerDicId = order.MakerDicID;
                    storeNum.smallUnit = order.LeastUnit;
                    int reduceNum = 0;
                    if (dispMaster.InvoiceNum == 0) //住院不要用数量乘以处方贴数 update by heyan 2010.10.26 修改中草药处方发药时修改
                    {
                        reduceNum = Convert.ToInt32(order.DrugOCNum * 1);
                    }
                    else//门诊要用数量乘以处方贴数 update by heyan 2010.10.26
                    {
                        reduceNum = Convert.ToInt32(order.DrugOCNum * dispMaster.RecipeNum);
                    }
                    decimal rtn = ReduceStoreNum(order.MakerDicID, order.DeptID, reduceNum);
                    if (rtn != -1)//增加药品库存判断　2011.5.10　update by heyan 
                    {
                    storeNum.storeNum = rtn;
                    storeNum.queryKey = order.OrderRecipeID.ToString();
                    storeNumHash.Add(order.OrderRecipeID, storeNum);
                    }
                    else
                    {
                        throw new Exception(order.ChemName + "药品库存量不足 编码:" + order.MakerDicID.ToString());
                    }
                }
                return storeNumHash;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    class Ref_StoreProcessor : YF_StoreProcessor
    {
        public override Hashtable ChangeStoreNum(BillMaster billMaster, List<BillOrder> orderList)
        {
            try
            {
                Hashtable storeNumHash = new Hashtable();
                YP_DRMaster refMaster = (YP_DRMaster)billMaster;
                foreach (BillOrder billOrder in orderList)
                {
                    YP_StoreNum storeNum = new YP_StoreNum();
                    YP_DROrder order = (YP_DROrder)billOrder;
                    storeNum.makerDicId = order.MakerDicID;
                    storeNum.smallUnit = order.LeastUnit;
                    int addNum = Convert.ToInt32(order.DrugOCNum * refMaster.RecipeNum);
                    decimal rtn = AddStoreNum(order.MakerDicID, order.DeptID, addNum);
                    if (rtn != -1)
                    {
                        storeNum.storeNum = rtn;
                        storeNum.queryKey = storeNum.makerDicId.ToString() + order.OrderRecipeID.ToString();
                        storeNumHash.Add(storeNum.queryKey, storeNum);
                    }
                    else
                    {
                        throw new Exception(order.ChemName + "药品从未入过库");
                    }
                }
                return storeNumHash;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    abstract class YK_StoreProcessor : StoreProcessor
    {
        public YK_StoreProcessor()
        {
            storeQuery = new YK_StoreQuery();
        }

        public override void UpdateStoreLimit(YP_Storage store)
        {
            try
            {
                BindEntity<HIS.Model.YP_Storage>.CreateInstanceDAL(oleDb, Tables.YK_STORAGE).Update(store);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public override decimal AddStoreNum(int makerId, int deptId, decimal addNum)
        {
            try
            {
                ypDal._oleDb = oleDb;
                //如果药库存在药品
                if (ypDal.YK_Store_ExistsDrug(makerId, deptId))
                {
                    //添加药品信息
                    ypDal.YK_Store_AddStore(makerId, addNum, deptId);
                    return storeQuery.QueryNum(makerId, deptId);
                }
                return -1;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public override decimal ReduceStoreNum(int makerId, int deptId, decimal reduceNum)
        {
            try
            {
                ypDal._oleDb = oleDb;
                decimal storeNum = storeQuery.QueryNum(makerId, deptId);
                if (reduceNum <= storeNum)
                {
                    ypDal.YK_Store_ReduceStore(makerId, reduceNum, deptId);
                    return storeNum - reduceNum;
                }
                return -1;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public override void UpdateStoreNum(int makerId, int deptId, decimal newNum)
        {
            try
            {
                ypDal._oleDb = oleDb;
                ypDal.YK_Store_UpdateStore(makerId, newNum, deptId);
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    class YK_Back_StoreProcessor : YK_StoreProcessor
    {
        public override Hashtable ChangeStoreNum(BillMaster billMaster, List<BillOrder> orderList)
        {
            try
            {
                Hashtable storeNumHash = new Hashtable();
                YP_InMaster inStore = (YP_InMaster)billMaster;
                foreach (BillOrder order in orderList)
                {
                    YP_StoreNum storeNum = new YP_StoreNum();
                    YP_InOrder orderInstore = (YP_InOrder)order;
                    storeNum.makerDicId = orderInstore.MakerDicID;
                    storeNum.smallUnit = orderInstore.LeastUnit;
                    IBaseDAL<YP_Storage> storeDao = BindEntity<YP_Storage>.CreateInstanceDAL(oleDb, BLL.Tables.YK_STORAGE);
                    //增加库存
                    decimal rtn = base.ReduceStoreNum(orderInstore.MakerDicID, orderInstore.DeptID, orderInstore.InNum);
                    if (rtn != -1)
                    {
                        storeNum.storeNum = rtn;
                        storeNum.queryKey = storeNum.makerDicId.ToString() + orderInstore.BatchNum;
                    }
                    else
                    {
                        string drugName = DrugBaseDataBll.GetDurgName(storeNum.makerDicId);
                        throw new Exception("[" + drugName + "]" + "退库数量过多，审核失败");
                    }
                    storeNumHash.Add(storeNum.queryKey, storeNum);
                }
                BatchProcessor.BackBatchNum(orderList);
                return storeNumHash;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    class YK_In_StoreProcessor : YK_StoreProcessor
    {
        public override Hashtable ChangeStoreNum(BillMaster billMaster, List<BillOrder> orderList)
        {
            try
            {
                Hashtable storeNumHash = new Hashtable();
                YP_InMaster inStore = (YP_InMaster)billMaster;
                foreach (BillOrder order in orderList)
                {
                    YP_StoreNum storeNum = new YP_StoreNum();
                    YP_InOrder orderInstore = (YP_InOrder)order;
                    storeNum.makerDicId = orderInstore.MakerDicID;
                    storeNum.smallUnit = orderInstore.LeastUnit;
                    IBaseDAL<YP_Storage> storeDao = BindEntity<YP_Storage>.CreateInstanceDAL(oleDb, BLL.Tables.YK_STORAGE);
                    //增加库存
                    decimal rtn = base.AddStoreNum(orderInstore.MakerDicID, orderInstore.DeptID, orderInstore.InNum);
                    if (rtn == -1)
                    {
                        YP_Storage drugStore = new YP_Storage();
                        drugStore.CurrentNum = orderInstore.InNum;
                        drugStore.Del_Flag = 0;
                        drugStore.DeptID = inStore.DeptID;
                        drugStore.LeastUnit = storeNum.smallUnit;
                        drugStore.LowerLimit = 0;
                        drugStore.LStockPrice = orderInstore.StockPrice;
                        drugStore.MakerDicID = orderInstore.MakerDicID;
                        drugStore.RegTime = inStore.RegTime;
                        drugStore.UnitNum = orderInstore.UnitNum;
                        drugStore.UpperLimit = 0;
                        storeDao.Add(drugStore);
                        storeNum.storeNum = orderInstore.InNum;
                    }
                    else
                    {
                        storeNum.storeNum = rtn;
                    }
                    storeNum.queryKey = orderInstore.MakerDicID.ToString() + orderInstore.BatchNum.ToString();
                    storeNumHash.Add(storeNum.queryKey, storeNum);
                }
                BatchProcessor.AddBatchNum(orderList, inStore.RegTime);
                return storeNumHash;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    class YK_Out_StoreProcessor : YK_StoreProcessor
    {
        public override Hashtable ChangeStoreNum(BillMaster billMaster, List<BillOrder> orderList)
        {
            try
            {
                Hashtable storeNumHash = new Hashtable();
                foreach (BillOrder order in orderList)
                {
                    YP_StoreNum storeNum = new YP_StoreNum();
                    YP_OutOrder orderOutstore = (YP_OutOrder)order;
                    storeNum.smallUnit = orderOutstore.LeastUnit;
                    storeNum.makerDicId = orderOutstore.MakerDicID;
                    decimal reduceNum = orderOutstore.OutNum;
                    decimal rtn = ReduceStoreNum(orderOutstore.MakerDicID, orderOutstore.DeptID, reduceNum);
                    if (rtn != -1)
                    {
                        storeNum.storeNum = rtn;
                        storeNum.queryKey = storeNum.makerDicId.ToString() + orderOutstore.ProductNum;
                    }
                    else
                    {
                        string drugName = DrugBaseDataBll.GetDurgName(storeNum.makerDicId);
                        throw new Exception("["+drugName+"]"+"出库数量过多，审核失败");
                    }
                    storeNumHash.Add(storeNum.queryKey, storeNum);
                }
                BatchProcessor.ReduceBatchNum(orderList);
                return storeNumHash;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }


    class YK_Check_StoreProcessor : YK_StoreProcessor
    {

        public override Hashtable ChangeStoreNum(BillMaster billMaster, List<BillOrder> orderList)
        {
            try
            {
                Hashtable storeNumHash = new Hashtable();              
                //按厂家典ID对每种药品更新库存
                foreach (YP_CheckOrder order in orderList)
                {
                    YP_StoreNum storeNum = new YP_StoreNum();
                    storeNum.makerDicId = order.MakerDicID;
                    storeNum.smallUnit = order.LeastUnit;
                    storeNum.storeNum = order.CheckNum;
                    storeNumHash.Add(order.MakerDicID, storeNum);
                    if (order.CheckNum != order.FactNum)
                    {                      
                        UpdateStoreNum(order.MakerDicID, order.DeptID, order.CheckNum);
                    }                   
                }
                return storeNumHash;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
