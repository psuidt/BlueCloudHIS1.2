using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.Model;
using HIS.SYSTEM;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.SYSTEM.BussinessLogicLayer.Classes;
using HIS.SYSTEM.Core;


namespace HIS.YP_BLL
{
    /// <summary>
    /// 单据处理器对象
    /// </summary>
    public abstract class BillProcessor:HIS.SYSTEM.Core.BaseBLL
    {
        /// <summary>
        /// 单据处理器对象构造函数
        /// </summary>
        public BillProcessor()
        { 
        }

        /// <summary>
        /// 删除单据
        /// </summary>
        /// <param name="billMaster">单据表头</param>
        abstract public void DelBill(BillMaster billMaster);


        /// <summary>
        /// 审核单据
        /// </summary>
        abstract public void AuditBill(BillMaster billMaster, long auditerID, long auditDeptID);

        /// <summary>
        /// 保存单据
        /// </summary>
        /// <param name="billMaster">单据表头</param>
        /// <param name="listOrder">单据明细表</param>
        /// <param name="deptId">部门ID</param>
        abstract public void SaveBill(BillMaster billMaster, List<BillOrder> listOrder, long deptId);

        /// <summary>
        /// 更新单据
        /// </summary>
        /// <param name="billMaster">单据表头</param>
        /// <param name="listOrder">单据明细表</param>
        /// <param name="deptId">部门ID</param>
        abstract public void UpdateBill(BillMaster billMaster, List<BillOrder> listOrder, long deptId);

        /// <summary>
        /// 创建空单据表头
        /// </summary>
        /// <param name="deptId">部门ID</param>
        /// <param name="userId">用户ＩＤ</param>
        /// <returns>新创建的单据表头</returns>
        abstract public BillMaster BuildNewMaster(long deptId, long userId);


        /// <summary>
        /// 创建空单据明细
        /// </summary>
        /// <param name="deptId">部门ID</param>
        /// <param name="master">单据表头</param>
        /// <returns></returns>
        abstract public BillOrder BuildNewoder(long deptId, BillMaster master);

        /// <summary>
        /// 创建发药单表头记录对象(临床发药)
        /// </summary>
        /// <param name="presInfo">
        /// 住院病人对象
        /// </param>
        /// <param name="deptId">
        /// 发药部门ID
        /// </param>
        /// <param name="dispenserId">
        /// 发药人员ID
        /// </param>
        /// <returns>
        /// 新创建的发药表头记录
        /// </returns>
        public YP_DRMaster BuildNewDispenseMaster(ZY_DispPresInfo presInfo, int deptId, int dispenserId)
        {
            YP_DRMaster dispMaster = new YP_DRMaster();
            dispMaster.Charge_Flag = 0;//记账处方标识，未启用
            dispMaster.DeptID = deptId;//发药部门ＩＤ
            if (XcConvert.IsInteger(presInfo.CureDocCode))
            {
                dispMaster.DocID = Convert.ToInt32(presInfo.CureDocCode);//主治医生ID
            }
            dispMaster.DrugOC_Flag = presInfo.drFlag;
            dispMaster.OpType = presInfo.opType;
            dispMaster.DosageMan = 0;//配药人ＩＤ，未启用           
            dispMaster.InpatientID = presInfo.CureNo;
            dispMaster.InvoiceNum = 0;//住院发票号默认为0
            dispMaster.OPPeopleID = dispenserId;//发药人员ID
            dispMaster.OPTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;//发药时间           
            dispMaster.PatientID = presInfo.PatListId;//病人ID
            dispMaster.PatientName = presInfo.PatName;//病人姓名
            dispMaster.PatientNo = "";//病历号，未启用
            dispMaster.ReceiptCode = 0;//结算收据号
            dispMaster.RecipeID = 0;//处方号，住院未启用
            dispMaster.RecipeNum = presInfo.recipeNum;//处方贴数
            dispMaster.RetailFee = 0;//零售金额，初始化为0
            return dispMaster;
        }

        /// <summary>
        /// 创建发药表头对象(经管发药)
        /// </summary>
        /// <param name="patInfo">住院病人对象</param>
        /// <param name="deptId">部门ID</param>
        /// <param name="dispenserId">发药人员ＩＤ</param>
        /// <returns></returns>
        public YP_DRMaster BuildNewDispenseMaster(ZY_PatList patInfo, int deptId, int dispenserId,int presamount,int groupid)
        {
            YP_DRMaster dispMaster = new YP_DRMaster();
            dispMaster.Charge_Flag = 0;//记账处方标识，未启用
            dispMaster.DeptID = deptId;//发药部门ＩＤ
            if (XcConvert.IsInteger(patInfo.CureDocCode))
            {
                dispMaster.DocID = Convert.ToInt32(XcConvert.IsInteger(patInfo.CureDocCode));//主治医生ID
            }
            dispMaster.DosageMan = 0;//配药人ＩＤ，未启用
            dispMaster.DrugOC_Flag = presamount > 0 ? 1 : 0;//1表发药，0表退药 //update by heyan 2010.11.22付数大于0表示发药，小于0表退药
            dispMaster.InpatientID = patInfo.CureNo;//住院号
            dispMaster.InvoiceNum = 0;//住院发票号默认为0
            dispMaster.OPPeopleID = dispenserId;//发药人员ID
            dispMaster.OPTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;//发药时间
            dispMaster.OpType =presamount>0?ConfigManager.OP_YF_DISPENSE:ConfigManager.OP_YF_REFUND;//业务类型 update by heyan 2010.11.22付数大于0表示发药，小于0表退药
            dispMaster.PatientID = patInfo.PatListID;//病人ID
            dispMaster.PatientName = patInfo.PatientInfo.PatName;//病人姓名
            dispMaster.PatientNo = "";//病历号，未启用
            dispMaster.ReceiptCode = 0;//结算收据号
            dispMaster.RecipeID =groupid ;//处方号，住院未启用 //update by heyan 2010.10.26 中草药的组号
            dispMaster.RecipeNum = presamount>0?presamount:presamount*-1;//处方贴数  //update by heyan 2010.10.26 中草药保存处方数
            dispMaster.RetailFee = 0;//零售金额，初始化为0           
            return dispMaster;
        }

        /// <summary>
        /// 创建发药单表头记录对象
        /// </summary>
        /// <param name="obj">处方</param>
        /// <param name="deptId">部门ID</param>
        /// <param name="dispenserId">发药人ID</param>
        /// <returns>发要单表头</returns>
        abstract public YP_DRMaster BuildNewDispenseMaster(object obj, int deptId, int dispenserId);

        /// <summary>
        /// 跟据处方明细和发药表头记录对象创建发药明细对象链表
        /// </summary>
        /// <param name="recipeOrder">处方明细数据表</param>
        /// <param name="dispMaster">发药表头记录对象</param>
        /// <param name="dispenseModel">发药模式：1住院发药；2门诊发药</param>
        /// <returns>新创建的发药明细对象链表</returns>
        abstract public List<BillOrder> BuildNewDispOrder(DataTable recipeOrder, YP_DRMaster dispMaster,
            int dispenseModel);

        /// <summary>
        /// 保存多张单据（住院统领需要同时保存多张单据）
        /// </summary>
        /// <param name="masterList">单据头链表</param>
        /// <param name="deptId">部门ID</param>
        /// <param name="dispDt">发药明细表（哈希表对应各头表）</param>
        abstract public BillMaster SaveBills(List<BillMaster> masterList, long deptId, System.Collections.Hashtable dispDt);

        /// <summary>
        /// 按药房库存上下限构建入库申请单
        /// </summary>
        /// <param name="newMaster">申请单表头</param>
        /// <param name="orderDt">申请单明细列表</param>
        /// <param name="_currentDeptId">申请科室</param>
        /// <param name="_currentUserId">申请人员ID</param>
        /// <param name="applyDept">出库科室</param>
        /// <param name="lowerStoreDrug">低于库存下限药品</param>
        public void BuildApplyInByStoreLimit(out YP_InMaster newMaster, out DataTable orderDt, int _currentDeptId,
            int _currentUserId, int applyDept, DataTable lowerStoreDrug)
        {
            try
            {
                if (lowerStoreDrug == null)
                {
                    newMaster = null;
                    orderDt = null;
                    return;
                }
                decimal drugStoreNum; //药品库存数量
                decimal lessNum; //还需申请数量
                decimal batchStoreNum; //批次库存量
                decimal applyNum; //总共需申请数量
                int currentMakerDicId; //当前药品编码
                StoreQuery _storeQuery = StoreFactory.GetQuery(ConfigManager.YF_SYSTEM);
                BillQuery _billQuery = BillFactory.GetQuery(ConfigManager.OP_YF_APPLYIN);
                StoreQuery _applyDeptStoreQuery = StoreFactory.GetQuery(ConfigManager.YK_SYSTEM);
                //构建一个新的入库申请单表头
                newMaster = (YP_InMaster)(this.BuildNewMaster(_currentDeptId, _currentUserId));
                orderDt = _billQuery.LoadOrder(newMaster);
                #region 循环低于下限的药品
                for (int index = 0; index < lowerStoreDrug.Rows.Count; index++)
                {
                    DataRow limitRow = lowerStoreDrug.Rows[index];
                    //获取当前药品编码
                    currentMakerDicId = Convert.ToInt32(limitRow["MAKERDICID"]);
                    //计算需要申请入库药品数量
                    applyNum = (Convert.ToDecimal(limitRow["UPPERLIMIT"]) -
                        Convert.ToDecimal(limitRow["CURRENTNUM"])) / Convert.ToDecimal(limitRow["PUNITNUM"]);
                    applyNum = Math.Ceiling(applyNum);
                    //按药品编码加载批次
                    DataTable batchDt = _applyDeptStoreQuery.LoadBatch(currentMakerDicId, applyDept);
                    if (batchDt == null)
                    {
                        break;
                    }
                    drugStoreNum = 0;
                    //判断批次总量是否满足申请要求
                    for (int temp = 0; temp < batchDt.Rows.Count; temp++)
                    {
                        drugStoreNum += Convert.ToDecimal(batchDt.Rows[temp]["CURRENTNUM"]);
                    }
                    if (drugStoreNum > applyNum)
                    {
                        #region 如果满足，循环批次生成入库单明细
                        for (int temp = 0; temp < batchDt.Rows.Count; temp++)
                        {
                            lessNum = applyNum;
                            batchStoreNum = Convert.ToDecimal(batchDt.Rows[temp]["CURRENTNUM"]);
                            if (batchStoreNum != 0)
                            {
                                DataRow newRow = orderDt.NewRow();
                                newRow["MAKERDICID"] = limitRow["MAKERDICID"]; //厂家ID
                                newRow["CHEMNAME"] = limitRow["CHEMNAME"];//化学名
                                newRow["SPEC"] = limitRow["SPEC"];//规格
                                newRow["PRODUCTNAME"] = limitRow["PRODUCTNAME"];//生产厂家名
                                newRow["RETAILPRICE"] = limitRow["RETAILPRICE"];//零售价
                                newRow["TRADEPRICE"] = limitRow["TRADEPRICE"];//批发价
                                newRow["STOCKPRICE"] = limitRow["TRADEPRICE"];//进价
                                newRow["LEASTUNIT"] = limitRow["PACKUNIT"];//包装单位编码
                                newRow["UNITNAME"] = limitRow["PACKUNITNAME"];//包装单位
                                newRow["BATCHNUM"] = batchDt.Rows[temp]["BATCHNUM"];//批次号
                                newRow["DEPTID"] = limitRow["DEPTID"];//部门ID
                                newRow["UNITNUM"] = limitRow["PUNITNUM"];//单位数量
                                newRow["VALIDITYDATE"] = Convert.ToDateTime(batchDt.Rows[temp]["VALIDITYDATE"]);
                                newRow["AUDIT_FLAG"] = 0;
                                newRow["BILLNUM"] = 0;
                                newRow["DELIVERNUM"] = "";
                                newRow["InStorageID"] = 0;
                                newRow["MasterInStorageID"] = 0;
                                newRow["REMARK"] = "";
                                newRow["DEFSTOCKPRICE"] = limitRow["TRADEPRICE"];
                                newRow["RecScale"] = 0.0;
                                //批次数量大于还需申请数量
                                if (batchStoreNum >= lessNum)
                                {
                                    if (lessNum < 1)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        //lessNum = Math.Ceiling(lessNum); 
                                        newRow["INNUM"] = lessNum;//入库数量
                                        newRow["TRADEFEE"] = lessNum * Convert.ToDecimal(newRow["TRADEPRICE"]);//批发金额
                                        newRow["RETAILFEE"] = lessNum * Convert.ToDecimal(newRow["RETAILPRICE"]);//零售金额
                                        newRow["STOCKFEE"] = newRow["TRADEFEE"];//进货金额
                                        orderDt.Rows.Add(newRow);
                                        break;
                                    }
                                }
                                //批次数量小于还需申请数量
                                else
                                {
                                    newRow["INNUM"] = batchStoreNum;
                                    newRow["TRADEFEE"] = lessNum * Convert.ToDecimal(newRow["TRADEPRICE"]);//批发金额
                                    newRow["RETAILFEE"] = lessNum * Convert.ToDecimal(newRow["RETAILPRICE"]);//零售金额
                                    newRow["STOCKFEE"] = newRow["TRADEFEE"];
                                    lessNum = applyNum - batchStoreNum;//进货金额
                                    orderDt.Rows.Add(newRow);
                                }
                            }
                        }
                        #endregion 如果满足，循环批次生成入库单明细
                    }
                }
                #endregion 循环低于下限的药品
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
