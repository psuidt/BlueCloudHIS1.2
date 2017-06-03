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
    /// 
    /// </summary>
    public class AdjpriceProcessor : BillProcessor
    {
        /// <summary>
        /// 调价处理器
        /// </summary>
        public AdjpriceProcessor()
        {
        }

        /// <summary>
        /// 构造调价单头表（未实现）
        /// </summary>
        /// <param name="obj">调价头信息</param>
        /// <param name="deptId">调价科室</param>
        /// <param name="dispenserId">调价人员ID</param>
        /// <returns></returns>
        public override YP_DRMaster BuildNewDispenseMaster(object obj, int deptId, int dispenserId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 构造调价单明细表（未实现）
        /// </summary>
        /// <param name="recipeOrder">调价明细信息表</param>
        /// <param name="dispMaster">单据头表</param>
        /// <param name="dispenseModel">调价模式</param>
        /// <returns></returns>
        public override List<BillOrder> BuildNewDispOrder(System.Data.DataTable recipeOrder,
            YP_DRMaster dispMaster, int dispenseModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 构造调价单空表头
        /// </summary>
        /// <param name="deptId">药剂科室ＩＤ</param>
        /// <param name="userId">操作人员ＩＤ</param>
        /// <returns>调价单表头</returns>
        public override BillMaster BuildNewMaster(long deptId, long userId)
        {
            try
            {
                YP_AdjMaster masterAdj = new YP_AdjMaster();
                DateTime adjDate = XcDate.ServerDateTime;
                masterAdj.AdjCode = "TJ" + adjDate.Year.ToString() + adjDate.Month.ToString() + adjDate.Day.ToString();
                masterAdj.Audit_Flag = 1;
                masterAdj.BillNum = 0;
                masterAdj.Del_Flag = 0;
                masterAdj.DeptID = Convert.ToInt32(deptId);
                masterAdj.Over_Flag = 0;
                masterAdj.RegPeople = Convert.ToInt32(userId);
                masterAdj.RegTime = XcDate.ServerDateTime;
                masterAdj.ExeTime = masterAdj.RegTime;
                masterAdj.Remark = "";
                return masterAdj;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 构造调价单明细
        /// </summary>
        /// <param name="deptId">药剂科室ＩＤ</param>
        /// <param name="master">对应调价单表头</param>
        /// <returns>调价单明细</returns>
        public override BillOrder BuildNewoder(long deptId, BillMaster master)
        {
            YP_AdjOrder adjOrder = new YP_AdjOrder();
            try
            {
                YP_AdjMaster adjMaster = (YP_AdjMaster)master;
                adjOrder.DeptID = adjMaster.DeptID;
                adjOrder.MasterAdjPrice = adjMaster;
                adjOrder.MakerDic = new YP_MakerDic();
                adjOrder.LeastUnitEntity = new YP_UnitDic();
                return adjOrder;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 删除调价单（未实现）
        /// </summary>
        /// <param name="billMaster"></param>
        public override void DelBill(BillMaster billMaster)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改调价单（未实现）
        /// </summary>
        /// <param name="billMaster"></param>
        /// <param name="listOrder"></param>
        /// <param name="deptId"></param>
        public override void UpdateBill(BillMaster billMaster, List<BillOrder> listOrder, long deptId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 保存多张调价单（未实现）
        /// </summary>
        /// <param name="masterList"></param>
        /// <param name="deptId"></param>
        /// <param name="dispDt"></param>
        /// <returns></returns>
        public override BillMaster SaveBills(List<BillMaster> masterList, long deptId, System.Collections.Hashtable dispDt)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 保存调价单
        /// </summary>
        /// <param name="billMaster">调价单表头</param>
        /// <param name="listOrder">调价单明细列表</param>
        /// <param name="deptId">药剂科室ID</param>
        public override void SaveBill(BillMaster billMaster, List<BillOrder> listOrder, long deptId)
        {
            try
            {
                int count = 0;
                YP_AdjMaster masterAdj = (YP_AdjMaster)billMaster;
                oleDb.BeginTransaction();
                //声明操作对象
                YP_AdjOrder adjOrder = new YP_AdjOrder();
                HIS.DAL.YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                List<YP_DeptDic> deptList = new List<YP_DeptDic>();
                //获取调价药剂科室
                deptList = BindEntity<HIS.Model.YP_DeptDic>.CreateInstanceDAL(oleDb).GetListArray("");
                foreach (YP_DeptDic dept in deptList)
                {
                    count = 0;
                    if (dept.DeptType1 == "药房")
                    {
                        if (dept.Use_Flag == 1)
                        {
                            masterAdj.OpType = ConfigManager.OP_YF_ADJPRICE;
                        }
                    }
                    else
                    {
                        if (dept.Use_Flag == 1)
                        {
                            masterAdj.OpType = ConfigManager.OP_YK_ADJPRICE;
                        }
                    }
                    masterAdj.Over_Flag = 0;
                    masterAdj.AdjCode = GWIString.FilterSpecial(masterAdj.AdjCode);
                    masterAdj.Remark = GWIString.FilterSpecial(masterAdj.Remark);
                    masterAdj.DeptID = dept.DeptID;
                    BindEntity<HIS.Model.YP_AdjMaster>.CreateInstanceDAL(oleDb).Add(masterAdj);
                    foreach (BillOrder order in listOrder)
                    {
                        adjOrder = (YP_AdjOrder)order;
                        adjOrder.MasterIAdjPriceD = masterAdj.MasterAdjPriceID;
                        adjOrder.DeptID = masterAdj.DeptID;
                        string belongSystem = (dept.DeptType1 == "药房" ? ConfigManager.YF_SYSTEM : ConfigManager.YK_SYSTEM);                        
                        if (StoreFactory.GetQuery(belongSystem).QueryNum(adjOrder.MakerDicID, adjOrder.DeptID) < 0)
                        {
                            continue;
                        }
                        count++;
                        BindEntity<HIS.Model.YP_AdjOrder>.CreateInstanceDAL(oleDb).Add(adjOrder);
                    }
                    if (count > 0)
                    {
                        masterAdj.BillNum = (ypDal.YP_Bill_GetBillNum(masterAdj.OpType, dept.DeptID)).BillNum;
                        if (masterAdj.BillNum == 0)
                        {
                            throw new Exception("药剂科室设置错误，请确认当前科室是药剂科室");
                        }
                        BindEntity<HIS.Model.YP_AdjMaster>.CreateInstanceDAL(oleDb).Update(masterAdj);
                        AuditBill(masterAdj, (long)(masterAdj.RegPeople), (long)(masterAdj.DeptID));
                    }
                    else
                    {
                        string strwhere = Tables.yp_adjmaster.DEPTID + oleDb.EuqalTo() + masterAdj.DeptID
                            + oleDb.And() + Tables.yp_adjmaster.MASTERADJPRICEID + oleDb.EuqalTo() + masterAdj.MasterAdjPriceID;
                        BindEntity<HIS.Model.YP_AdjMaster>.CreateInstanceDAL(oleDb).Delete(strwhere);
                        strwhere = Tables.yp_adjorder.DEPTID + oleDb.EuqalTo() + masterAdj.DeptID
                            + oleDb.And() + Tables.yp_adjorder.MASTERIADJPRICED + oleDb.EuqalTo() + masterAdj.MasterAdjPriceID;
                        BindEntity<YP_AdjOrder>.CreateInstanceDAL(oleDb).Delete(strwhere);
                    }
                    
                }
                oleDb.CommitTransaction();
            }
            catch (Exception error)
            {
                oleDb.RollbackTransaction();
                throw error;
            }
        }

        /// <summary>
        /// 审核调价单
        /// </summary>
        /// <param name="billMaster">调价单头表</param>
        /// <param name="auditerID">审核人员ＩＤ</param>
        /// <param name="auditDeptID">审核科室ID</param>
        public override void AuditBill(BillMaster billMaster, long auditerID, long auditDeptID)
        {
            try
            {
                HIS.DAL.YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                string strWhere;
                YP_AdjMaster masterAdj = (YP_AdjMaster)billMaster;
                string belongSystem = (masterAdj.OpType == ConfigManager.OP_YF_ADJPRICE ? ConfigManager.YF_SYSTEM : ConfigManager.YK_SYSTEM);
                if (ConfigManager.IsChecking((long)masterAdj.DeptID))
                {
                    string deptName = BaseData.GetDeptName(masterAdj.DeptID.ToString());
                    throw new Exception("["+deptName+"]"+"库房药品正在盘点中....");
                }
                masterAdj.Audit_Flag = 1;
                masterAdj.Over_Flag = 1;
                BindEntity<HIS.Model.YP_AdjMaster>.CreateInstanceDAL(oleDb).Update(masterAdj);
                strWhere = Tables.yp_adjorder.MASTERIADJPRICED + oleDb.EuqalTo() + masterAdj.MasterAdjPriceID;
                List<YP_AdjOrder> orderList = BindEntity<HIS.Model.YP_AdjOrder>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
                List<BillOrder> billOrderList = new List<BillOrder>();
                Hashtable storeTable = new Hashtable();
                foreach (YP_AdjOrder adjOrder in orderList)
                {
                    YP_StoreNum yp_StoreNum = new YP_StoreNum();
                    decimal storeNum = StoreFactory.GetQuery(belongSystem).QueryNum(adjOrder.MakerDicID, adjOrder.DeptID);
                    adjOrder.Audit_Flag = 1;
                    adjOrder.AdjNum = storeNum;
                    yp_StoreNum.makerDicId = adjOrder.MakerDicID;
                    if (belongSystem == ConfigManager.YK_SYSTEM)
                    {
                        yp_StoreNum.smallUnit = adjOrder.LeastUnit;
                    }
                    else
                    {
                        yp_StoreNum.smallUnit = ypDal.Unit_GetSmallUnit(adjOrder.MakerDicID);
                    }
                    yp_StoreNum.storeNum = storeNum;
                    storeTable.Add(yp_StoreNum.makerDicId, yp_StoreNum);
                    //计算调赢/亏金额
                    ComputeAdjFee(adjOrder, belongSystem);
                    billOrderList.Add(adjOrder);
                    BindEntity<HIS.Model.YP_AdjOrder>.CreateInstanceDAL(oleDb).Update(adjOrder);
                }
                //记账
                AccountFactory.GetWriter(masterAdj.OpType).WriteAccount(masterAdj, billOrderList, storeTable);
                //更新药典价格
                foreach (YP_AdjOrder adjOrder in orderList)
                {
                    ChangePrice(adjOrder.NewRetailPrice, true, adjOrder.MakerDicID);
                    ChangePrice(adjOrder.NewTradePrice, false, adjOrder.MakerDicID);
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 计算调整金额
        /// </summary>
        /// <param name="adjOrder">调价单明细</param>
        /// <param name="belongSystem">所属系统（药房还是药库）</param>
        private void ComputeAdjFee(YP_AdjOrder adjOrder, string belongSystem)
        {
            if (belongSystem == ConfigManager.YF_SYSTEM)
            {
                int modNum = Convert.ToInt32(adjOrder.AdjNum) % Convert.ToInt32(adjOrder.UnitNum);
                if (modNum != 0)
                {
                    adjOrder.AdjRetailFee = 0;
                    adjOrder.AdjTradeFee = 0;
                    decimal packNum = (adjOrder.AdjNum - modNum) / adjOrder.UnitNum;
                    adjOrder.AdjRetailFee += (adjOrder.NewRetailPrice - adjOrder.OldRetailPrice) * packNum;
                    adjOrder.AdjRetailFee += (Convert.ToDecimal(modNum) / Convert.ToDecimal(adjOrder.UnitNum))
                        * (adjOrder.NewRetailPrice - adjOrder.OldRetailPrice);
                    adjOrder.AdjTradeFee += (adjOrder.NewTradePrice - adjOrder.OldTradePrice) * packNum;
                    adjOrder.AdjTradeFee += (Convert.ToDecimal(modNum) / Convert.ToDecimal(adjOrder.UnitNum))
                        * (adjOrder.NewTradePrice - adjOrder.OldTradePrice);
                }
                else
                {
                    adjOrder.AdjRetailFee = (adjOrder.NewRetailPrice - adjOrder.OldRetailPrice) * adjOrder.AdjNum / adjOrder.UnitNum;
                    adjOrder.AdjTradeFee = (adjOrder.NewTradePrice - adjOrder.OldTradePrice) * adjOrder.AdjNum / adjOrder.UnitNum;
                }
            }
            else
            {
                adjOrder.AdjRetailFee = (adjOrder.NewRetailPrice - adjOrder.OldRetailPrice) * adjOrder.AdjNum;
                adjOrder.AdjTradeFee = (adjOrder.NewTradePrice - adjOrder.OldTradePrice) * adjOrder.AdjNum;
            }
        }

        /// <summary>
        /// 更新药品价格
        /// </summary>
        /// <param name="newPrice">新价格</param>
        /// <param name="isRetail">是调零售价还是批发价:true零售价，false批发价</param>      
        /// <param name="MakerDicID">调价药品厂家典标识ID</param>
        private void ChangePrice(decimal newPrice, bool isRetail, int MakerDicID)
        {
            try
            {
                if (isRetail)
                {
                    string strSet = Tables.yp_makerdic.RETAILPRICE + oleDb.EuqalTo() + newPrice.ToString();
                    string strWhere = Tables.yp_makerdic.MAKERDICID + oleDb.EuqalTo() + MakerDicID.ToString();
                    BindEntity<HIS.Model.YP_MakerDic>.CreateInstanceDAL(oleDb).Update(strWhere, strSet);
                }
                else
                {
                    string strSet = Tables.yp_makerdic.TRADEPRICE + oleDb.EuqalTo() + newPrice.ToString();
                    string strWhere = Tables.yp_makerdic.MAKERDICID + oleDb.EuqalTo() + MakerDicID.ToString();
                    BindEntity<HIS.Model.YP_MakerDic>.CreateInstanceDAL(oleDb).Update(strWhere, strSet);
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
