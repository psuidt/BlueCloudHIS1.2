using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.DAL;
using HIS.Model;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.SYSTEM.Core;

namespace HIS.YP_BLL
{
    
    /// <summary>
    /// 设置药品系统全局参数的管理器
    /// </summary>
    public class ConfigManager:BaseBLL
    {  //* 20100520.2.01 参数统一修改，实体有改动

        /// <summary>
        /// 药房申请入库业务
        /// </summary>
        public const string OP_YF_APPLYIN = "001";

        /// <summary>
        /// 药房报损出库业务类型
        /// </summary>
        public const string OP_YF_REPORTLOSS = "005";

        /// <summary>
        /// 药房发药
        /// </summary>
        public const string OP_YF_DISPENSE = "003";

        /// <summary>
        /// 药房退药
        /// </summary>
        public const string OP_YF_REFUND = "004";

        /// <summary>
        /// 药房科室领药出库业务类型
        /// </summary>
        public const string OP_YF_DEPTDRAW = "002";

        /// <summary>
        /// 药房盘点业务类型
        /// </summary>
        public const string OP_YF_CHECK = "006";

        /// <summary>
        /// 药房盘点审核业务类型
        /// </summary>
        public const string OP_YF_AUDITCHECK = "009";

        /// <summary>
        /// 药房调价业务类型
        /// </summary>
        public const string OP_YF_ADJPRICE = "007";

        /// <summary>
        /// 药房月结业务类型
        /// </summary>
        public const string OP_YF_MONTHACCOUNT = "008";

        /// <summary>
        /// 药库入库类型
        /// </summary>
        public const string OP_YK_INOPTYPE = "010";

        /// <summary>
        /// 药房申领单对应的药库出库业务
        /// </summary>
        public const string OP_YK_OUTTOYF = "011";

        /// <summary>
        /// 药库盘点审核业务
        /// </summary>
        public const string OP_YK_AUDITCHECK = "012";

        /// <summary>
        /// 药库盘点业务
        /// </summary>
        public const string OP_YK_CHECK = "013";

        /// <summary>
        /// 药房入库业务
        /// </summary>
        public const string OP_YF_INSTORE = "014";

        /// <summary>
        /// 药库月结业务
        /// </summary>
        public const string OP_YK_MONTHACCOUNT = "015";

        /// <summary>
        /// 药库调价业务
        /// </summary>
        public const string OP_YK_ADJPRICE = "016";

        /// <summary>
        /// 药库科室领药出库业务类型
        /// </summary>
        public const string OP_YK_DEPTDRAW = "017";

        /// <summary>
        /// 药库报损出库业务类型
        /// </summary>
        public const string OP_YK_REPORTLOSS = "018";

        /// <summary>
        /// 药库期初入库类型
        /// </summary>
        public const string OP_YK_FIRSTIN = "019";
        
        /// <summary>
        /// 药库采购计划
        /// </summary>
        public const string OP_YK_STOCKPLAN = "023";

        /// <summary>
        /// 药库退库业务
        /// </summary>
        public const string OP_YK_BACKSTORE = "024";

        public const string OP_YF_PJDB = "025";
        /// <summary>
        /// 药房系统业务
        /// </summary>
        public const string YF_SYSTEM = "药房系统";

        /// <summary>
        /// 药库系统业务
        /// </summary>
        public const string YK_SYSTEM = "药库系统";

        /// <summary>
        /// 自定义药库出库业务（用于获取药库查询对象）
        /// </summary>
        public const string DEF_YK_OUT = "019";

        /// <summary>
        /// 自定义药房出库业务（用于获取药房查询对象）
        /// </summary>
        public const string DEF_YF_OUT = "020";

        /// <summary>
        /// 判断是否盘点中...
        /// </summary>
        /// <param name="deptId">部门ID</param>
        /// <returns></returns>
        public static bool IsChecking(long deptId)
        {
            try
            {                
                YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                return ypDal.Config_IsChecking((int)deptId);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 开始盘点状态
        /// </summary>
        /// <param name="deptId">部门ID</param>
        public static void BeginCheck(long deptId)
        {
            try
            {
                if (!IsChecking(deptId))
                {
                    YP_Dal ypDal = new YP_Dal();
                    ypDal._oleDb = oleDb;
                    ypDal.Config_BeginChecking((int)deptId);
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 结束盘点状态
        /// </summary>
        /// <param name="deptId">部门ID</param>
        public static void EndCheck(long deptId)
        {
            try
            {
                if (IsChecking(deptId))
                {
                    YP_Dal ypDal = new YP_Dal();
                    ypDal._oleDb = oleDb;
                    ypDal.Config_EndChecking((int)deptId);
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 清除库房盘点状态
        /// </summary>
        /// <param name="master"></param>
        /// <param name="_billQuery"></param>
        /// <param name="_billProcessor"></param>
        /// <param name="belongSystem"></param>
        public static void StopCheckStatus(YP_CheckMaster master, BillQuery _billQuery, 
            BillProcessor _billProcessor, string belongSystem)
        {
            try
            {
                _billProcessor.DelBill(master);
                oleDb.BeginTransaction();
                if (!_billQuery.CheckBill_ExistsNotAudit(master.MasterCheckID, belongSystem))
                {
                    EndCheck(master.DeptID);
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
        /// 获取月结日
        /// </summary>
        /// <returns></returns>
        public static int GetAccountDay(int deptId)
        {
            try
            {
                YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                IBaseDAL<YP_CONFIG> appDal = BindEntity<YP_CONFIG>.CreateInstanceDAL(oleDb);
                YP_CONFIG config = appDal.GetModel("CODE='008' AND DeptID="+deptId);
                if (config != null)
                {
                    return Convert.ToInt32(config.VALUE);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 设置月结日
        /// </summary>
        /// <param name="accountDay">新设置的月结日</param>
        /// <param name="deptId">部门ID</param>
        public static void SetAccountDay(int accountDay, int deptId)
        {
            try
            {
                YP_Dal ypDal = new YP_Dal();
                ypDal._oleDb = oleDb;
                oleDb.BeginTransaction();
                //获取月结类型的全局参数
                IBaseDAL<YP_CONFIG> appDal = BindEntity<YP_CONFIG>.CreateInstanceDAL(oleDb);
                YP_CONFIG accDay = appDal.GetModel("CODE='008' AND DeptID=" + deptId);
                if (accDay != null)
                {
                    accDay.VALUE = accountDay.ToString();
                    appDal.Update(accDay);
                }
                else
                {
                    throw new Exception("药品系统参数表未进行初始化设置");
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
        /// 判断药房是否管理批发价格
        /// </summary>
        /// <returns>true：管理；false：不管理。</returns>
        public static bool ManageTradepriceByYF()
        {
            try
            {
                string strWhere = BLL.Tables.yp_config.CODE + oleDb.EuqalTo() + "'009'";
                YP_CONFIG ypConfig = BindEntity<YP_CONFIG>.CreateInstanceDAL(oleDb).GetModel(strWhere);
                if (ypConfig != null)
                {
                    if (ypConfig.VALUE.ToString() == "1")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 设置药房是否管理批发价格
        /// </summary>
        /// <param name="isManage">true：药房管批发价；false：药房不管批发价。</param>
        public static void SetManageTradePriceByYF(bool isManage)
        {
            try
            {
                string strWhere = BLL.Tables.yp_config.CODE + oleDb.EuqalTo() + "'009'";
                int value = 0;
                if (isManage)
                    value = 1;
                BindEntity<YP_CONFIG>.CreateInstanceDAL(oleDb).Update(strWhere,
                    BLL.Tables.yp_config.VALUE + oleDb.EuqalTo() + "'"+value+"'");
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
