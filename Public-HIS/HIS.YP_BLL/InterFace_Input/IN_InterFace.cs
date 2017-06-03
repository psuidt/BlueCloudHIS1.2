using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.ZY_BLL;
using HIS.BLL;
using HIS.DAL;


namespace HIS.YP_BLL
{
    /// <summary>
    /// 
    /// </summary>
    public class IN_InterFace:HIS.SYSTEM.Core.BaseBLL
    {
        /// <summary>
        /// 检索所有待发药的住院病人
        /// </summary>
        /// <returns>待发药住院病人链表</returns>
        public static List<HIS.Model.ZY_PatList> QueryAllZYPat()
        {
            try
            {
                List<HIS.Model.ZY_PatList> patList = HIS.ZY_BLL.YP_Interface.GetPatInfo();
                return patList;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 根据科室ID查询指定科室所有待发药病人
        /// </summary>
        /// <param name="deptId">入院科室ID</param>
        /// <param name="cureDeptId">执行科室ID</param>
        /// <returns>待发药病人链表</returns>
        public static List<HIS.Model.ZY_PatList> QueryAllZYPat(int deptId, int cureDeptId)
        {
            try
            {
                List<HIS.Model.ZY_PatList> patList = HIS.ZY_BLL.YP_Interface.GetPatInfo(deptId, cureDeptId);
                return patList;
            }
            catch (Exception error)
            {
                throw error;
            }
        }


        /// <summary>
        /// 获取所有医院用户
        /// </summary>
        /// <returns></returns>
        public static DataTable LoadAllUser()
        {
            try
            {
                string strTableName = oleDb.TableNameBM(HIS.BLL.Tables.BASE_USER, "A")
                    + oleDb.LeftJoin() + oleDb.TableNameBM(HIS.BLL.Tables.BASE_EMPLOYEE_PROPERTY, "B")
                    + oleDb.ON("A." + Tables.base_user.EMPLOYEE_ID, "B." + Tables.base_employee_property.EMPLOYEE_ID);
                string strSql = oleDb.Table(strTableName, "", "",
                    "A." + Tables.base_user.USER_ID,
                    "B." + Tables.base_employee_property.NAME,
                    "B." + Tables.base_employee_property.PY_CODE,
                    "B." + Tables.base_employee_property.WB_CODE);
                return oleDb.GetDataTable(strSql);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 读取出库科室信息表
        /// </summary>
        /// <returns>科室信息表</returns>
        public static DataTable LoadOutStoreDept(int currentDeptId)
        {
            try
            {
                string strWhere = BLL.Tables.yp_deptdic.DEPTID + oleDb.EuqalTo() + currentDeptId;
                HIS.Model.YP_DeptDic currentDept = BindEntity<HIS.Model.YP_DeptDic>.CreateInstanceDAL(oleDb).GetModel(strWhere);
                if (currentDept.DeptType1 == "物资")
                {
                    strWhere = Tables.base_dept_property.DEPT_ID + oleDb.NotEqualTo()  + currentDeptId.ToString() ;
                }
                else
                {
                    strWhere = ""; //Tables.base_dept_property.TYPE_CODE + oleDb.NotEqualTo() + "'002'";
                }
                StringBuilder strSql = new StringBuilder();
                string strsql = oleDb.Table(Tables.BASE_DEPT_PROPERTY, "", 
                    strWhere,oleDb.FiledNameBM("0", "ROWNO"),
                                            Tables.base_dept_property.NAME,
                                            Tables.base_dept_property.TYPE_CODE,
                                            Tables.base_dept_property.PY_CODE,
                                            Tables.base_dept_property.WB_CODE,
                                            Tables.base_dept_property.D_CODE,
                                            Tables.base_dept_property.DEPT_ID);
                return oleDb.GetDataTable(strsql);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 加载临床科室
        /// </summary>
        /// <returns></returns>
        public static DataTable LoadClinicDept()
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                string strsql = oleDb.Table(Tables.BASE_DEPT_PROPERTY, "",
                    Tables.base_dept_property.TYPE_CODE + oleDb.EuqalTo() + "'001'",
                                            oleDb.FiledNameBM("0", "ROWNO"),
                                            Tables.base_dept_property.NAME,
                                            Tables.base_dept_property.PY_CODE,
                                            Tables.base_dept_property.WB_CODE,
                                            Tables.base_dept_property.D_CODE,
                                            Tables.base_dept_property.DEPT_ID);
                return oleDb.GetDataTable(strsql);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 加载住院病人待发药金额
        /// </summary>
        /// <param name="queryPat"></param>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public static Decimal QueryPatDispFee(HIS.Model.ZY_PatList queryPat, int deptId)
        {
            try
            {
                decimal newFee = 0;
                newFee = HIS.ZY_BLL.YP_Interface.GetPatPresInfoTotalFee(queryPat.PatListID, deptId.ToString());
                return newFee;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 按病人信息检索待发药处方明细信息
        /// </summary>
        /// <param name="queryPat">病人信息</param>
        /// <param name="deptId">部门ID</param>
        /// <returns>处方明细数据表</returns>
        public static DataTable QueryRecipeOrder(HIS.Model.ZY_PatList queryPat, int deptId)
        {
            try
            {
                DataTable recipeOrder;
                recipeOrder = HIS.ZY_BLL.YP_Interface.GetPatPresInfo(queryPat.PatListID, deptId.ToString());
                return recipeOrder;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>按住院号检索病人</summary>
        /// <param name="inpatNum">住院号码</param>
        /// <returns>住院病人对象</returns>
        public static HIS.Model.ZY_PatList QueryPatByInpatNum(string inpatNum)
        {
            try
            {
                HIS.Model.ZY_PatList pat = HIS.ZY_BLL.YP_Interface.GetPatInfo(inpatNum);
                return pat;
            }
            catch (Exception error)
            {
                throw error;
            }
        }




        /// <summary>
        /// 按病人信息检索退药消息
        /// </summary>
        /// <param name="queryPat">病人信息</param>
        /// <param name="deptId">部门ID</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public static DataTable QueryRefRecipeOrder(HIS.Model.ZY_PatList queryPat, int deptId, DateTime beginTime, DateTime endTime)
        {
            string betweenTime = "'" + ((DateTime)beginTime).ToString("yyyy-MM-dd") + " 00:00:00' " +
          oleDb.And() + " '" + ((DateTime)endTime).ToString("yyyy-MM-dd") + @" 23:59:59'";
            HIS.DAL.YP_Dal dal = new YP_Dal();
            dal._oleDb = oleDb;
            string strWhere = "A." + Tables.yf_drorder.INPATIENTID + oleDb.EuqalTo() + "'" + queryPat.CureNo.ToString() + "'" +
                oleDb.And() + "A." + Tables.yf_drorder.DRUGOC_FLAG + oleDb.EuqalTo() + "1" +
                oleDb.And() + "A." + Tables.yf_drorder.DEPTID + oleDb.EuqalTo() + deptId +
                oleDb.And() + "E." + Tables.yf_drmaster.OPTIME + oleDb.Between() + betweenTime;
            return dal.YF_DRorder_GetList(strWhere);
        }

        /// <summary>
        /// 按病人信息检索已发药明细信息
        /// </summary>
        /// <param name="invoiceNum">发票号</param>
        /// <returns>已发药明细信息</returns>
        public static DataTable QueryRefRecipeOrder(string invoiceNum)
        {
            HIS.DAL.YP_Dal dal = new YP_Dal();
            dal._oleDb = oleDb;
            string strWhere ="E."+ Tables.yf_drorder.INVOICENUM + oleDb.EuqalTo() + invoiceNum;
            return dal.YF_DispenseOrder_GetList(strWhere);
        }


    }
}
