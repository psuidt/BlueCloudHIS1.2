using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.BLL;

//版本：1.0.0.0
//创建时间：2008年3月2日
//修改人：谭亚奇
//最近修改时间：2009年4月20日
namespace HIS.DAL
{
    /// <summary>
    /// 药品数据访问层
    /// </summary>
    public class YP_Dal
    {
        /// <summary>
        /// 数据库访问对象
        /// </summary>
        public RelationalDatabase _oleDb;

        /// <summary>
        /// 构造函数
        /// </summary>
        public YP_Dal()
        {
        }

        #region 药房台帐
        /// <summary>
        /// 查询药品明细账
        /// </summary>
        /// <param name="strWhere">查询条件代码</param>
        /// <returns>药品明细账列表</returns>
        public DataTable YF_Account_GetList(string strWhere)
        {
            string[] when = new string[4];
            when[0] = _oleDb.When() + "A." + Tables.yf_account.ACCOUNTTYPE + _oleDb.EuqalTo() + "0" + _oleDb.Then() + "'期初结余'";
            when[1] = _oleDb.When() + "A." + Tables.yf_account.ACCOUNTTYPE + _oleDb.EuqalTo() + "1" + _oleDb.Then() + "'期末结余'";
            when[2] = _oleDb.When() + "A." + Tables.yf_account.ACCOUNTTYPE + _oleDb.EuqalTo() + "2" + _oleDb.Then() + "'发生'";
            when[3] = _oleDb.When() + "A." + Tables.yf_account.ACCOUNTTYPE + _oleDb.EuqalTo() + "3" + _oleDb.Then() + "'调整'";

            string casewhen_1 = _oleDb.CASEWhen("AccountType", when);
            string[] when1 = new string[10];
            when1[0] = _oleDb.When() + "A." + Tables.yf_account.OPTYPE + _oleDb.EuqalTo() + "'001'" + _oleDb.Then() + "'申请入库'";
            when1[1] = _oleDb.When() + "A." + Tables.yf_account.OPTYPE + _oleDb.EuqalTo() + "'005'" + _oleDb.Then() + "'报损出库'";
            when1[2] = _oleDb.When() + "A." + Tables.yf_account.OPTYPE + _oleDb.EuqalTo() + "'003'" + _oleDb.Then() + "'发药'";
            when1[3] = _oleDb.When() + "A." + Tables.yf_account.OPTYPE + _oleDb.EuqalTo() + "'004'" + _oleDb.Then() + "'退药'";
            when1[4] = _oleDb.When() + "A." + Tables.yf_account.OPTYPE + _oleDb.EuqalTo() + "'002'" + _oleDb.Then() + "'科室领药'";
            when1[5] = _oleDb.When() + "A." + Tables.yf_account.OPTYPE + _oleDb.EuqalTo() + "'006'" + _oleDb.Then() + "'药品盘点'";
            when1[6] = _oleDb.When() + "A." + Tables.yf_account.OPTYPE + _oleDb.EuqalTo() + "'007'" + _oleDb.Then() + "'药品调价'";
            when1[7] = _oleDb.When() + "A." + Tables.yf_account.OPTYPE + _oleDb.EuqalTo() + "'008'" + _oleDb.Then() + "'月结'";
            when1[8] = _oleDb.When() + "A." + Tables.yf_account.OPTYPE + _oleDb.EuqalTo() + "'009'" + _oleDb.Then() + "'盘点审核'";
            when1[9] = _oleDb.When() + "A." + Tables.yf_account.OPTYPE + _oleDb.EuqalTo() + "'014'" + _oleDb.Then() + "'期初入库'";
            string casewhen_2 = _oleDb.CASEWhen("OpType", when1);
            string str = _oleDb.TableNameBM(Tables.YF_ACCOUNT, "A") + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_UNITDIC, "B") +
                _oleDb.ON("A." + Tables.yf_account.LEASTUNIT, "B." + Tables.yp_unitdic.UNITDICID);
            string strsql = _oleDb.Table(str, "", strWhere == "" ? "" : strWhere,
          Tables.yf_account.MACCOUNTID,
          Tables.yf_account.ACCOUNTYEAR,
          Tables.yf_account.ACCOUNTMONTH,
          Tables.yp_unitdic.UNITNAME,
            casewhen_1,
          Tables.yf_account.RETAILPRICE,
          Tables.yf_account.STOCKPRICE,
            casewhen_2,
           Tables.yf_account.BILLNUM,
           Tables.yf_account.UNITNUM,
           Tables.yf_account.LEASTUNIT,
           Tables.yf_account.REGTIME,
           Tables.yf_account.DEBITNUM,
           Tables.yf_account.LENDERNUM,
           Tables.yf_account.OVERNUM,
           Tables.yf_account.DEBITFEE,
           Tables.yf_account.LENDERFEE,
           Tables.yf_account.BALANCEFEE,
           Tables.yf_account.BALANCE_FLAG,
           Tables.yf_account.ACCOUNTHISTORYID,
           Tables.yf_account.MAKERDICID,
           Tables.yf_account.DEPTID,
           Tables.yf_account.ORDERID);
            strsql += _oleDb.OrderBy() + Tables.yf_account.REGTIME + "," + Tables.yf_account.ORDERID + _oleDb.ASC();
            return _oleDb.GetDataTable(strsql);


        }

        #endregion

        #region  药房盘点表头

        /// <summary>
        /// 判断是否存在指定单据外未审核单据
        /// </summary>
        /// <param name="exceptID">指定单据ＩＤ</param>
        /// <returns>true：存在；false：不存在</returns>
        public bool YF_Checkmaster_ExistNotAudit(int exceptID)
        {
            string strSql = Tables.yf_checkmaster.AUDIT_FLAG + _oleDb.EuqalTo() + "0" + _oleDb.And() +
                Tables.yf_checkmaster.MASTERCHECKID + _oleDb.NotEqualTo() + exceptID.ToString() + _oleDb.And() +
                Tables.yf_checkmaster.DEL_FLAG + _oleDb.EuqalTo() + "0";
            int cmdresult;
            string field = _oleDb.Count(Tables.yf_checkmaster.MASTERCHECKID, "");
            object obj = BindEntity<YP_CheckMaster>.CreateInstanceDAL(_oleDb, Tables.YF_CHECKMASTER).GetFieldValue(field, strSql);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 设置盘点单表头的审核标识
        /// </summary>
        /// <param name="masterId">盘点单表头ＩＤ</param>
        /// <param name="checkTime">审核时间</param>
        /// <param name="chekPeople">审核人员</param>
        public void YF_Checkmaster_Check(int masterId, DateTime checkTime, long chekPeople)
        {
            string strWhere = Tables.yf_checkmaster.MASTERCHECKID + _oleDb.EuqalTo() + masterId;
            string[] strSet = new string[3];
            strSet[0] = Tables.yf_checkmaster.AUDIT_FLAG + _oleDb.EuqalTo() + "1";
            strSet[1] = Tables.yf_checkmaster.AUDITTIME + _oleDb.EuqalTo() + "'" + checkTime + "'";
            strSet[2] = Tables.yf_checkmaster.AUDITPEOPLEID + _oleDb.EuqalTo() + Convert.ToInt32(chekPeople);
            BindEntity<YP_CheckMaster>.CreateInstanceDAL(_oleDb, Tables.YF_CHECKMASTER).Update(strWhere, strSet);
        }

        /// <summary>
        /// 获取盘点单表头信息列表
        /// </summary>
        /// <param name="strWhere">指定条件</param>
        /// <param name="deptId">部门ID</param>
        /// <returns>盘点单表头信息列表</returns>
        public DataTable YF_Checkmaster_GetList(string strWhere)
        {

            string str = _oleDb.TableNameBM(Tables.YF_CHECKMASTER, "A") + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_USER, "B") +
                _oleDb.ON("A." + Tables.yf_checkmaster.REGPEOPLEID, "B." + Tables.base_user.USER_ID) +
                    _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_EMPLOYEE_PROPERTY, "C") +
                    _oleDb.ON("B." + Tables.base_user.EMPLOYEE_ID, "C." + Tables.base_employee_property.EMPLOYEE_ID) + _oleDb.LeftOuterJoin() +
                    _oleDb.TableNameBM(Tables.BASE_USER, "D") + _oleDb.ON("A." + Tables.yf_checkmaster.AUDITPEOPLEID, "D." + Tables.base_user.USER_ID) +
                    _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_EMPLOYEE_PROPERTY, "E") +
                    _oleDb.ON("D." + Tables.base_user.EMPLOYEE_ID, "E." + Tables.base_employee_property.EMPLOYEE_ID);

            string strsql = _oleDb.Table(str, "", strWhere, "A.*",
                _oleDb.FiledNameBM("C." + Tables.base_employee_property.NAME, "RegName"),
                _oleDb.FiledNameBM("E." + Tables.base_employee_property.NAME, "AuditName"));
            return _oleDb.GetDataTable(strsql);
        }

        #endregion  成员方法

        #region  药房盘点明细

        /// <summary>
        /// 根据盘点单表头ID获取明细信息列表
        /// </summary>
        /// <param name="MasterCheckID">盘点表头ＩＤ</param>
        /// <returns>盘点单明细列表</returns>
        public DataTable YF_Checkorder_GetListByMaster(int MasterCheckID)
        {

            string strWhere_1 = Tables.yp_unitdic.UNITDICID + _oleDb.EuqalTo() + "C." + Tables.yp_specdic.PACKUNIT;
            string childtable_1 = _oleDb.ChildTable(Tables.YP_UNITDIC, "PACKUNITNAME", strWhere_1, Tables.yp_unitdic.UNITNAME);
            string strWhere_2 = Tables.yp_unitdic.UNITDICID + _oleDb.EuqalTo() + "C." + Tables.yp_specdic.UNIT;
            string childtable_2 = _oleDb.ChildTable(Tables.YP_UNITDIC, "UNITNAME", strWhere_2, Tables.yp_unitdic.UNITNAME);
            string _gs_1_3 = _oleDb.DBConvert("A." + Tables.yf_checkorder.FACTNUM, "Integer");
            string _gs_1_4 = _oleDb.Division(_gs_1_3, "C." + Tables.yp_specdic.PACKNUM);
            string value_4 = _oleDb.Value(_gs_1_4, "0");
            string _gs_1_5 = _oleDb.Mod(_gs_1_3, "C." + Tables.yp_specdic.PACKNUM);
            string value_6 = _oleDb.Value(_gs_1_5, "0");
            string _gs_1_7 = _oleDb.DBConvert("A." + Tables.yf_checkorder.CHECKNUM, "Integer");
            string _gs_1_8 = _oleDb.Division(_gs_1_7, "C." + Tables.yp_specdic.PACKNUM);
            string value_8 = _oleDb.Value(_gs_1_8, "0");
            string _gs_1_9 = _oleDb.Mod(_gs_1_7, "C." + Tables.yp_specdic.PACKNUM);
            string value_10 = _oleDb.Value(_gs_1_9, "0");
            string strWhere_12 = "A." + Tables.yf_checkorder.MASTERCHECKID + _oleDb.EuqalTo() + MasterCheckID;
            string str = _oleDb.TableNameBM(Tables.YF_CHECKORDER, "A") + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_MAKERDIC, "B") +
                _oleDb.ON("A." + Tables.yf_checkorder.MAKERDICID, "B." + Tables.yp_makerdic.MAKERDICID) +
          _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_SPECDIC, "C") +
          _oleDb.ON("B." + Tables.yp_makerdic.SPECDICID, "C." + Tables.yp_specdic.SPECDICID) +
          _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_PRODUCTDIC, "D") +
          _oleDb.ON("B." + Tables.yp_makerdic.PRODUCTID, "D." + Tables.yp_productdic.PRODUCTID) +
          _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_DOSEDIC, "E") +
            _oleDb.ON("E." + Tables.yp_dosedic.DOSEDICID, "C." + Tables.yp_specdic.DOSEDICID) +
            _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_TYPEDIC, "F") +
            _oleDb.ON("F." + Tables.yp_typedic.TYPEDICID, "C." + Tables.yp_specdic.TYPEDICID);
            string strsql = _oleDb.Table(str, "", strWhere_12,
            "A.*",
            "C." + Tables.yp_specdic.CHEMNAME,
            "B." + Tables.yp_makerdic.RETAILPRICE,
            "C." + Tables.yp_specdic.SPEC,
            "D." + Tables.yp_productdic.PRODUCTNAME,
            "E." + Tables.yp_dosedic.DOSENAME,
            "F." + Tables.yp_typedic.TYPENAME,
            "C." + Tables.yp_specdic.TYPEDICID,
           "C." + Tables.yp_specdic.DOSEDICID,
            _oleDb.FiledNameBM("C." + Tables.yp_specdic.PACKNUM, " PUNITNUM"),
            _oleDb.FiledNameBM(value_4, "PACKNUM"),
            _oleDb.FiledNameBM(value_6, "BASENUM"),
            _oleDb.FiledNameBM(value_8, "CPACKNUM"),
            _oleDb.FiledNameBM(value_10, "CBASENUM"),

                childtable_1,
             childtable_2);

            return _oleDb.GetDataTable(strsql);
        }

        #endregion  成员方法

        #region 药房发退药表头
        /// <summary>
        /// 获取药房发/退药单表头信息
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="deptId">部门ID</param>
        /// <returns>药房发退药单表头信息</returns>
        public DataTable YF_DispenseMaster_GetList(string strWhere)
        {
            string strWhere_1 = Tables.base_dept_property.DEPT_ID + _oleDb.EuqalTo() + "a.deptid";
            string childtable_1 = _oleDb.ChildTable(Tables.BASE_DEPT_PROPERTY, "deptname", strWhere_1,
            Tables.base_dept_property.NAME);


            string str = _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_USER, "c") +
                _oleDb.ON() + "a.oppeopleid" + _oleDb.EuqalTo() + "C.USER_ID" + _oleDb.LeftOuterJoin() +
                _oleDb.TableNameBM(Tables.BASE_EMPLOYEE_PROPERTY, "d") + _oleDb.ON() +
                "c.employee_id" + _oleDb.EuqalTo() + "d.employee_id"+_oleDb.LeftOuterJoin()+_oleDb.TableNameBM(Tables.ZY_PATLIST,"f")+
                _oleDb.ON()+"a.patientid"+_oleDb.EuqalTo()+"f.patlistid";
            string strsql = _oleDb.Table(_oleDb.TableNameBM(Tables.YF_DRMASTER, "a") + str, "", strWhere,
            "a.*",
            "f.currdeptcode",
             childtable_1,
            _oleDb.FiledNameBM("d.name", "oppeoplename"));
            strsql += _oleDb.OrderBy("a.optime");
            return _oleDb.GetDataTable(strsql);

        }

        /// <summary>
        /// 加载统领消息
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public DataTable YF_DeptDispHIS_GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            string tableName = BLL.Tables.YP_DISPDEPTHIS;
            strSql.Append("select A.*,B.NAME AS DEPTNAME from " + _oleDb.TableNameBM(tableName, " A"));
            strSql.Append(" left outer join BASE_DEPT_PROPERTY B on A.DISPDEPT=B.DEPT_ID AND A.WORKID=B.WORKID");
            if (strWhere != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return _oleDb.GetDataTable(strSql.ToString());
        }
        #endregion

        #region  药房发退药明细

        /// <summary>
        /// 获取发退药明细列表
        /// </summary>
        /// <param name="strWhere">查询条件代码</param>
        public DataTable YF_DRorder_GetList(string strWhere)
        {
            string sum_1 = _oleDb.Sum(Tables.yf_drorder.DRUGOCNUM, "");
            string strWhere_2 = Tables.yf_drorder.DRUGOC_FLAG + _oleDb.EuqalTo() + "0" + _oleDb.And()
                + Tables.yf_drorder.ORDERRECIPEID + _oleDb.EuqalTo() + "A." + Tables.yf_drorder.ORDERRECIPEID + _oleDb.And()
                + Tables.yf_drorder.INPATIENTID + _oleDb.NotEqualTo() + "''"
                + _oleDb.GroupBy() + Tables.yf_drorder.ORDERRECIPEID;
            string childtable_1 = _oleDb.ChildTable(Tables.YF_DRORDER, "", strWhere_2, sum_1);
            string strWhere_3 = Tables.yf_drorder.DRUGOC_FLAG + _oleDb.EuqalTo() + "1" + _oleDb.And()
                + Tables.yf_drorder.ORDERRECIPEID + _oleDb.EuqalTo() + "A." + Tables.yf_drorder.ORDERRECIPEID + _oleDb.And()
                + Tables.yf_drorder.INPATIENTID + _oleDb.NotEqualTo() + "''"
                + _oleDb.GroupBy() + Tables.yf_drorder.ORDERRECIPEID;
            string childtable_2 = _oleDb.ChildTable(Tables.YF_DRORDER, "", strWhere_3, sum_1);
            string value_4 = _oleDb.Value(childtable_1, "0");
            string value_5 = _oleDb.Value(childtable_2, " 0");
            string str = _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_MAKERDIC, "B") +
                _oleDb.ON("A." + Tables.yf_drorder.MAKERDICID, "B." + Tables.yp_makerdic.MAKERDICID)
                + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_SPECDIC, "C") +
                _oleDb.ON("B." + Tables.yp_makerdic.SPECDICID, "C." + Tables.yp_specdic.SPECDICID)
                + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_UNITDIC, "D") +
                _oleDb.ON("A." + Tables.yf_drorder.LEASTUNIT, "D." + Tables.yp_unitdic.UNITDICID)
                + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YF_DRMASTER, "E") +
                _oleDb.ON("A." + Tables.yf_drorder.MASTERDRUGOCID, "E." + Tables.yf_drmaster.MASTERDRUGOCID);
            string strsql = _oleDb.Table(_oleDb.TableNameBM(Tables.YF_DRORDER, "A") + str, "", strWhere.Trim() == "" ? "" : strWhere,
                        _oleDb.Distinct("A." + Tables.yf_drorder.INVOICENUM),
                        "A." + Tables.yf_drorder.ORDERRECIPEID,
                        "A." + Tables.yf_drorder.INPATIENTID,
                        "A." + Tables.yf_drorder.MAKERDICID,
                        "A." + Tables.yf_drorder.SPECDICID,
                        "A." + Tables.yf_drorder.CHEMNAME,
                        "A." + Tables.yf_drorder.LEASTUNIT,
                        "A." + Tables.yf_drorder.UNITNUM,
                        "A." + Tables.yf_drorder.DRUGOCNUM,
                        "A." + Tables.yf_drorder.RETAILPRICE,
                        "A." + Tables.yf_drorder.TRADEPRICE,
                        "A." + Tables.yf_drorder.RETAILFEE,
                        "A." + Tables.yf_drorder.TRADEFEE,
                        "A." + Tables.yf_drorder.DRUGOC_FLAG,
                        "A." + Tables.yf_drorder.REFUNDMENT_FLAG,
                        "A." + Tables.yf_drorder.UNIFORM_FLAG,
                        "A." + Tables.yf_drorder.DEPTID,
                         "C." + Tables.yp_specdic.SPEC,
                       "D." + Tables.yp_unitdic.UNITNAME,
                       "E." + Tables.yf_drmaster.OPTIME,
                       _oleDb.FiledNameBM("0", "RefundNum"),
                       _oleDb.FiledNameBM(value_4, "TOTALREFUNDNUM"),
                       _oleDb.FiledNameBM(value_5, "TOTALDISPENSENUM"),
                       _oleDb.FiledNameBM("0", "RecipeNum"));
            return _oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 查询发药单明细
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>发药单明细表</returns>
        public DataTable YF_DispenseOrder_GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder("");
            strSql.Append("select A.*,A.DRUGOCNUM AS REFUNDNUM,D.PRODUCTNAME,E.recipenum, ");
            strSql.Append("(select UNITNAME from YP_UNITDIC where UNITDICID=A.LEASTUNIT),C.SPEC,C.DOSEDICID");
            strSql.Append(" from YF_DRORDER A");
            strSql.Append(" left outer join YF_DRMASTER E on ");
            strSql.Append(" A.MASTERDRUGOCID=E.MASTERDRUGOCID ");
            strSql.Append(" left outer join YP_MAKERDIC B on");
            strSql.Append(" A.MAKERDICID=B.MAKERDICID");
            strSql.Append(" left outer join YP_SPECDIC C on");
            strSql.Append(" B.SPECDICID=C.SPECDICID");
            strSql.Append(" left outer join YP_PRODUCTDIC D on");
            strSql.Append(" B.PRODUCTID=D.PRODUCTID");
            strSql.Append(" Where A.WORKID=" + HIS.SYSTEM.Core.EntityConfig.WorkID.ToString() + _oleDb.And() + strWhere);
            return _oleDb.GetDataTable(strSql.ToString());

        }
        #endregion  成员方法

        #region  药房入库表头

        /// <summary>
        /// 获取药房入库单表头列表信息
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="deptId">查询部门ID</param>
        /// <returns>药房入库单表头列表信息</returns>
        public DataTable YF_Inmaster_GetList(string strWhere)
        {
            string str = _oleDb.TableNameBM(Tables.YF_INMASTER, "A") + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_USER, "B") +
                _oleDb.ON("A." + Tables.yf_inmaster.REGPEOPLEID, "B." + Tables.base_user.USER_ID) +
               _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_EMPLOYEE_PROPERTY, "C") +
               _oleDb.ON("B." + Tables.base_user.EMPLOYEE_ID, "C." + Tables.base_employee_property.EMPLOYEE_ID) +
               _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_USER, "D") +
               _oleDb.ON("A." + Tables.yf_inmaster.AUDITPEOPLEID, "D." + Tables.base_user.USER_ID) +
               _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_EMPLOYEE_PROPERTY, "E") +
               _oleDb.ON("D." + Tables.base_user.EMPLOYEE_ID, "E." + Tables.base_employee_property.EMPLOYEE_ID) +
               _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_SUPPORTDIC, "F") +
               _oleDb.ON("A." + Tables.yf_inmaster.SUPPORTDICID, "F." + Tables.yp_supportdic.SUPPORTDICID);
            string strsql = _oleDb.Table(str, "", strWhere,
           "A.*",
           _oleDb.FiledNameBM("'期初入库'", "TYPENAME"),
           _oleDb.FiledNameBM("C." + Tables.base_employee_property.NAME, " RegName"),
          _oleDb.FiledNameBM("E." + Tables.base_employee_property.NAME, "AuditName"),
          _oleDb.FiledNameBM("F." + Tables.yp_supportdic.NAME, "SupportName"));
            return _oleDb.GetDataTable(strsql);
        }



        #endregion  成员方法

        #region 采购计划
        /// <summary>
        /// 加载药品采购计划明细
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public DataTable YK_PlanOrder_GetList(string strWhere)
        {
            string tableName = _oleDb.TableNameBM(Tables.YK_PLANORDER, "A") +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_MAKERDIC, "B") +
                _oleDb.ON("A." + Tables.yk_planorder.MAKERDICID, "B." + Tables.yp_makerdic.MAKERDICID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_SPECDIC, "C") +
                _oleDb.ON("B." + Tables.yp_makerdic.SPECDICID, "C." + Tables.yp_specdic.SPECDICID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_PRODUCTDIC, "D") +
                _oleDb.ON("B." + Tables.yp_makerdic.PRODUCTID, "D." + Tables.yp_productdic.PRODUCTID);
            string strSql = _oleDb.Table(tableName, "", strWhere,
                "A.*",
                "C." + Tables.yp_specdic.CHEMNAME,
                "C." + Tables.yp_specdic.SPEC,
                "D." + Tables.yp_productdic.PRODUCTNAME);
            strSql += _oleDb.OrderBy() + Tables.yp_specdic.CHEMNAME;
            return _oleDb.GetDataTable(strSql);

        }
        #endregion 成员方法

        #region  药房入库明细

        /// <summary>
        /// 获取指定条件的入库明细列表信息
        /// </summary>
        /// <param name="strWhere">查询条件代码</param>
        /// <returns>入库明细列表信息</returns>
        public DataTable YF_Inorder_GetList(string strWhere)
        {
            string _gs_1_1 = _oleDb.DBConvert(_oleDb.Division("F." + Tables.yf_storage.CURRENTNUM, "A." + Tables.yf_inorder.UNITNUM), "decimal(18,1)");
            string str = _oleDb.TableNameBM(Tables.YF_INORDER, "A") + _oleDb.LeftOuterJoin()
                + _oleDb.TableNameBM(Tables.YP_MAKERDIC, "B") +
                _oleDb.ON("A." + Tables.yf_inorder.MAKERDICID, "B." + Tables.yp_makerdic.MAKERDICID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_SPECDIC, "C") +
                _oleDb.ON("B." + Tables.yp_makerdic.SPECDICID, "C." + Tables.yp_specdic.SPECDICID) +
               _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_UNITDIC, "D") +
               _oleDb.ON("A." + Tables.yf_inorder.LEASTUNIT, "D." + Tables.yp_unitdic.UNITDICID) +
               _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_PRODUCTDIC, "E") +
               _oleDb.ON("B." + Tables.yp_makerdic.PRODUCTID, "E." + Tables.yp_productdic.PRODUCTID) +
               _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YF_STORAGE, "F") +
               _oleDb.ON("A." + Tables.yf_inorder.MAKERDICID, "F." + Tables.yf_storage.MAKERDICID) +
               _oleDb.And() + "A." + Tables.yf_storage.DEPTID +
               _oleDb.EuqalTo() + "F." + Tables.yf_inorder.DEPTID;
            string strsql = _oleDb.Table(str, "", strWhere.Trim() == "" ? "" : strWhere,
            "A.*",
            "C." + Tables.yp_specdic.CHEMNAME,
            "C." + Tables.yp_specdic.SPEC,
             "D." + Tables.yp_unitdic.UNITNAME,
            "E." + Tables.yp_productdic.PRODUCTNAME,
            "B." + Tables.yp_makerdic.DEFSTOCKPRICE,
            _oleDb.FiledNameBM(_gs_1_1, "CurrentNum"));
            strsql += _oleDb.OrderBy() + Tables.yf_inorder.INSTORAGEID;
            return _oleDb.GetDataTable(strsql);
        }
        #endregion  成员方法

        #region  药房出库表头

        /// <summary>
        /// 获取药房出库单表头信息列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>出库单表头信息列表</returns>
        public DataTable YF_Outmaster_GetList(string strWhere)
        {
            string[] when = new string[2];
            when[0] = _oleDb.When() + "A." + Tables.yf_outmaster.OPTYPE + _oleDb.EuqalTo() + "'002'" + _oleDb.Then() + "'科室领药'";
            when[1] = _oleDb.When() + "A." + Tables.yf_outmaster.OPTYPE + _oleDb.EuqalTo() + "'005'" + _oleDb.Then() + "'药品报损'";

            string casewhen_1 = _oleDb.CASEWhen("TYPENAME", when);
            string str = _oleDb.TableNameBM(Tables.YF_OUTMASTER, "A") + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_USER, "B") +
                _oleDb.ON("A." + Tables.yf_outmaster.REGPEOPLEID, "B." + Tables.base_user.USER_ID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_EMPLOYEE_PROPERTY, "C") +
                _oleDb.ON("B." + Tables.base_user.EMPLOYEE_ID, "C." + Tables.base_employee_property.EMPLOYEE_ID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_USER, "D") +
                _oleDb.ON("A." + Tables.yf_outmaster.AUDITPEOPLEID, "D." + Tables.base_user.USER_ID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_EMPLOYEE_PROPERTY, "E") +
                _oleDb.ON("D." + Tables.base_user.EMPLOYEE_ID, "E." + Tables.base_employee_property.EMPLOYEE_ID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_DEPT_PROPERTY, "F") +
                _oleDb.ON("A." + Tables.yf_outmaster.OUTDEPTID, "F." + Tables.base_dept_property.DEPT_ID);
            string strsql = _oleDb.Table(str, "", strWhere, "A.*",
            _oleDb.FiledNameBM("C." + Tables.base_employee_property.NAME, "RegName"),
            _oleDb.FiledNameBM("E." + Tables.base_employee_property.NAME, "AuditName"),
            _oleDb.FiledNameBM("F." + Tables.base_dept_property.NAME, "OutDeptName"),
              casewhen_1);
            return _oleDb.GetDataTable(strsql);
        }
        #endregion  成员方法

        #region  药房出库明细
        /// <summary>
        /// 获取出库单明细列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        public DataTable YF_Outorder_GetList(string strWhere)
        {

            string str = _oleDb.TableNameBM(Tables.YF_OUTORDER, "A") + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_MAKERDIC, "B") +
            _oleDb.ON("A." + Tables.yf_outorder.MAKERDICID, "B." + Tables.yp_makerdic.MAKERDICID) +
            _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_SPECDIC, "C") +
            _oleDb.ON("B." + Tables.yp_makerdic.SPECDICID, "C." + Tables.yp_specdic.SPECDICID) +
            _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_UNITDIC, "D") +
            _oleDb.ON("A." + Tables.yf_outorder.LEASTUNIT, "D." + Tables.yp_unitdic.UNITDICID) +
            _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_PRODUCTDIC, "E") +
            _oleDb.ON("B." + Tables.yp_makerdic.PRODUCTID, "E." + Tables.yp_productdic.PRODUCTID) +
            _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_DEPT_PROPERTY, "F") +
            _oleDb.ON("F." + Tables.base_dept_property.DEPT_ID, "A." + Tables.yf_outorder.OUTDEPTID);
            string strsql = _oleDb.Table(str, "", strWhere.Trim() == "" ? "" : strWhere,
              "A.*",
              "A.RETAILFEE-A.TRADEFEE AS DIFFFEE",
            "C." + Tables.yp_specdic.CHEMNAME,
           "C." + Tables.yp_specdic.SPEC,
            "C." + Tables.yp_specdic.PACKNUM,
           "D." + Tables.yp_unitdic.UNITNAME,
           "E." + Tables.yp_productdic.PRODUCTNAME,
              _oleDb.FiledNameBM("F." + Tables.base_dept_property.NAME, "DEPTNAME"));
            return _oleDb.GetDataTable(strsql);
        }
        #endregion  成员方法

        #region  药房库存

        /// <summary>
        /// 判断药房是否有库存药品
        /// </summary>
        /// <param name="deptId">药房部门ＩＤ</param>
        /// <returns>true：有库存药品；false：无库存药品</returns>
        public bool YF_Storage_ExistsStore(int deptId)
        {

            string strWhere = Tables.yf_storage.DEPTID + _oleDb.EuqalTo() + deptId;
            int cmdresult;
            object obj = BindEntity<YP_Storage>.CreateInstanceDAL(_oleDb, Tables.YF_STORAGE).GetFieldValue(_oleDb.Count(Tables.yf_storage.STORAGEID, ""), strWhere);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0 || cmdresult == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 添加药品库存数量
        /// </summary>
        /// <param name="MakerDicID">药品厂家典ID</param>
        /// <param name="AddNum">增加数量</param>
        /// <param name="deptId">部门ＩＤ</param>
        public void YF_Storage_AddStore(int MakerDicID, decimal AddNum, int deptId)
        {
            string strWhere = Tables.yf_storage.MAKERDICID + _oleDb.EuqalTo() + MakerDicID + _oleDb.And() + Tables.yf_storage.DEPTID +
                _oleDb.EuqalTo() + deptId;
            string strSet = Tables.yf_storage.CURRENTNUM + _oleDb.EuqalTo() + _oleDb.Add(Tables.yf_storage.CURRENTNUM, AddNum.ToString());
            BindEntity<YP_Storage>.CreateInstanceDAL(_oleDb, Tables.YF_STORAGE).Update(strWhere, strSet);
        }

        /// <summary>
        /// 减少药品库存数
        /// </summary>
        /// <param name="MakerDicID">药品厂家典ID</param>
        /// <param name="ReduceNum">减少数量</param>
        /// <param name="deptId">部门ID</param>
        public void YF_Storage_ReduceStore(int MakerDicID, decimal ReduceNum, int deptId)
        {
            string strWhere = Tables.yf_storage.MAKERDICID + _oleDb.EuqalTo() + MakerDicID + _oleDb.And() + Tables.yf_storage.DEPTID +
                _oleDb.EuqalTo() + deptId;
            string strSet = Tables.yf_storage.CURRENTNUM + _oleDb.EuqalTo() + _oleDb.Subtract(Tables.yf_storage.CURRENTNUM, ReduceNum.ToString());
            BindEntity<YP_Storage>.CreateInstanceDAL(_oleDb, Tables.YF_STORAGE).Update(strWhere, strSet);
        }

        /// <summary>
        /// 更新药品库存数量
        /// </summary>
        /// <param name="MakerDicID">药品厂家典ＩＤ</param>
        /// <param name="UpdateNum">更新后数量</param>
        /// <param name="deptId">部门ＩＤ</param>
        public void YF_Storage_UpdateStore(int MakerDicID, decimal UpdateNum, int deptId)
        {
            string strWhere = Tables.yf_storage.MAKERDICID + _oleDb.EuqalTo() + MakerDicID + _oleDb.And() + Tables.yf_storage.DEPTID +
                _oleDb.EuqalTo() + deptId;
            string strSet = Tables.yf_storage.CURRENTNUM + _oleDb.EuqalTo() + UpdateNum;
            BindEntity<YP_Storage>.CreateInstanceDAL(_oleDb, Tables.YF_STORAGE).Update(strWhere, strSet);
        }

        /// <summary>
        /// 获取指定类型药品的库存总金额
        /// </summary>
        /// <param name="deptId">药品部门ID</param>
        /// <param name="drugType">药品类型</param>
        /// <returns>库存金额</returns>
        public decimal YF_Storage_GetTotalFee(int deptId, int drugType)
        {

            string cf = _oleDb.Division("A." + Tables.yf_storage.CURRENTNUM, "C." + Tables.yp_specdic.PACKNUM);
            string _gs_1_1 = _oleDb.Multiply(cf, "B." + Tables.yp_makerdic.RETAILPRICE);
            string _gs_1_2 = _oleDb.DBConvert(_oleDb.Sum(_gs_1_1, ""), "decimal(18,2)");
            string strWhere_3 = "A." + Tables.yf_storage.DEPTID + _oleDb.EuqalTo() + deptId;
            if (drugType != 0)
            {
                strWhere_3 += _oleDb.And() + "C." + Tables.yp_specdic.TYPEDICID + _oleDb.EuqalTo() + drugType;
            }
            string str = _oleDb.TableNameBM(Tables.YF_STORAGE, "A") + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_MAKERDIC, "B") +
                _oleDb.ON("A." + Tables.yf_storage.MAKERDICID, "B." + Tables.yp_makerdic.MAKERDICID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_SPECDIC, "C") +
                _oleDb.ON("B." + Tables.yp_makerdic.SPECDICID, "C." + Tables.yp_specdic.SPECDICID);
            string strsql = _oleDb.Table(str, "", strWhere_3,
             _oleDb.FiledNameBM(_gs_1_2, "TOTALFEE"));


            object obj = _oleDb.GetDataResult(strsql);
            if (obj != null && obj != DBNull.Value)
            {
                return decimal.Parse(obj.ToString());
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 获取药房库存批发金额
        /// </summary>
        /// <param name="deptId">药房ID</param>
        /// <param name="drugType">药品类型ＩＤ(0表示全部类型药品)</param>
        /// <returns>药房库存批发金额汇总</returns>
        public decimal YF_Storage_GetTradeFee(int deptId, int drugType)
        {

            string cf = _oleDb.Division("A." + Tables.yf_storage.CURRENTNUM, "C." + Tables.yp_specdic.PACKNUM);
            string _gs_1_1 = _oleDb.Multiply(cf, "B." + Tables.yp_makerdic.TRADEPRICE);
            string _gs_1_2 = _oleDb.DBConvert(_oleDb.Sum(_gs_1_1, ""), "decimal(18,2)");
            string strWhere_3 = "A." + Tables.yf_storage.DEPTID + _oleDb.EuqalTo() + deptId;
            if (drugType != 0)
            {
                strWhere_3 += _oleDb.And() + "C." + Tables.yp_specdic.TYPEDICID + _oleDb.EuqalTo() + drugType;
            }
            string str = _oleDb.TableNameBM(Tables.YF_STORAGE, "A") + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_MAKERDIC, "B") +
                _oleDb.ON("A." + Tables.yf_storage.MAKERDICID, "B." + Tables.yp_makerdic.MAKERDICID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_SPECDIC, "C") +
                _oleDb.ON("B." + Tables.yp_makerdic.SPECDICID, "C." + Tables.yp_specdic.SPECDICID);
            string strsql = _oleDb.Table(str, "", strWhere_3,
             _oleDb.FiledNameBM(_gs_1_2, "TRADEFEE"));


            object obj = _oleDb.GetDataResult(strsql);
            if (obj != null && obj != DBNull.Value)
            {
                return decimal.Parse(obj.ToString());
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 获取指定药品的库存零售金额
        /// </summary>
        /// <param name="deptId">部门ＩＤ</param>
        /// <param name="makerdicId">厂家典ID</param>
        /// <returns>库存零售金额</returns>
        public decimal YF_GetDrugFee(int deptId, int makerdicId)
        {
            try
            {
                string cf = _oleDb.Division("A." + Tables.yf_storage.CURRENTNUM, "C." + Tables.yp_specdic.PACKNUM);
                string gs = _oleDb.DBConvert(_oleDb.Multiply(cf, "B." + Tables.yp_makerdic.RETAILPRICE), "decimal(18,2)");
                string strSql = "SELECT " + gs + "FROM " + _oleDb.TableNameBM(BLL.Tables.YF_STORAGE, "A") +
                    " LEFT OUTER JOIN YP_MAKERDIC B ON A.MAKERDICID=B.MAKERDICID LEFT OUTER JOIN YP_SPECDIC C ON C.SPECDICID=B.SPECDICID"
                    + " WHERE A.MAKERDICID=" + makerdicId.ToString() + " AND A.DEPTID=" + deptId.ToString();
                object obj = _oleDb.GetDataResult(strSql);
                if (obj != null && obj != DBNull.Value)
                {
                    return decimal.Parse(obj.ToString());
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
        /// 获取药库库存零售金额
        /// </summary>
        /// <param name="deptId"></param>
        /// <param name="makerdicId"></param>
        /// <returns></returns>
        public decimal YK_GetDrugFee(int deptId, int makerdicId)
        {
            try
            {
                string cf = "A." + Tables.yk_storage.CURRENTNUM;
                string gs = _oleDb.DBConvert(_oleDb.Multiply(cf, "B." + Tables.yp_makerdic.RETAILPRICE), "decimal(18,2)");
                string strSql = "SELECT " + gs + "FROM" + _oleDb.TableNameBM(BLL.Tables.YK_STORAGE, "A") +
                    " LEFT OUTER JOIN YP_MAKERDIC B ON A.MAKERDICID=B.MAKERDICID LEFT OUTER JOIN YP_SPECDIC C ON C.SPECDICID=B.SPECDICID"
                    + " WHERE A.MAKERDICID=" + makerdicId.ToString() + " AND A.DEPTID=" + deptId.ToString();
                object obj = _oleDb.GetDataResult(strSql);
                if (obj != null && obj != DBNull.Value)
                {
                    return decimal.Parse(obj.ToString());
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
        /// 获取药房药品库存信息
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="deptId">部门ＩＤ</param>
        /// <returns></returns>
        public DataTable YF_Storage_GetList(string strWhere, int deptId)
        {
            string strWhere_1 = Tables.yp_unitdic.UNITDICID + _oleDb.EuqalTo() + "C." + Tables.yp_specdic.PACKUNIT;
            string childtable_1 = _oleDb.ChildTable(Tables.YP_UNITDIC, "PACKUNITNAME", strWhere_1, Tables.yp_unitdic.UNITNAME);
            string strWhere_2 = Tables.yp_unitdic.UNITDICID + _oleDb.EuqalTo() + "C." + Tables.yp_specdic.UNIT;
            string childtable_2 = _oleDb.ChildTable(Tables.YP_UNITDIC, "UNITNAME", strWhere_2, Tables.yp_unitdic.UNITNAME);
            string cast_3 = _oleDb.DBConvert("A." + Tables.yf_storage.CURRENTNUM, "Integer");
            string _mod_1_4 = _oleDb.Mod(cast_3, "C." + Tables.yp_specdic.PACKNUM);
            string _gs_1_6 = _oleDb.Division(cast_3, "C." + Tables.yp_specdic.PACKNUM);
            string value_7 = _oleDb.Value(_gs_1_6, "0");
            string value_8 = _oleDb.Value(_mod_1_4, "0");
            string cf = _oleDb.Division("A." + Tables.yf_storage.CURRENTNUM, "C." + Tables.yp_specdic.PACKNUM);
            string _gs_1_8 = _oleDb.DBConvert(_oleDb.Multiply(cf, "B." + Tables.yp_makerdic.RETAILPRICE), "decimal(18,2)");
            string _gs_1_9 = _oleDb.DBConvert(_oleDb.Multiply(cf, "B." + Tables.yp_makerdic.TRADEPRICE), "decimal(18, 2)");
            string str = _oleDb.TableNameBM(Tables.YF_STORAGE, "A") + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_MAKERDIC, "B") +
                _oleDb.ON("A." + Tables.yf_storage.MAKERDICID, "B." + Tables.yp_makerdic.MAKERDICID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_SPECDIC, "C") +
                _oleDb.ON("B." + Tables.yp_makerdic.SPECDICID, "C." + Tables.yp_specdic.SPECDICID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_PRODUCTDIC, "D") +
                _oleDb.ON("B." + Tables.yp_makerdic.PRODUCTID, "D." + Tables.yp_productdic.PRODUCTID);
            string childtable_3 = _oleDb.ChildTable(str, "E", "",
                        "A.*",
                        _oleDb.FiledNameBM("B." + Tables.yp_makerdic.GETWAY, "STOPUSE"),
                        _oleDb.FiledNameBM("B." + Tables.yp_makerdic.DEL_FLAG, "DELMAKER"),
                        "B." + Tables.yp_makerdic.MAKERDICID,
                        "C." + Tables.yp_specdic.SPEC,
                        "C." + Tables.yp_specdic.NAME,
                        "C." + Tables.yp_specdic.CHEMNAME,
                        "B." + Tables.yp_makerdic.RETAILPRICE,
                        "B." + Tables.yp_makerdic.TRADEPRICE,
                        "D." + Tables.yp_productdic.PRODUCTNAME,
                        _oleDb.FiledNameBM("C." + Tables.yp_specdic.PACKNUM, "PUNITNUM"),
                        "C." + Tables.yp_specdic.PACKUNIT,
                         "C." + Tables.yp_specdic.UNIT,
                         "C." + Tables.yp_specdic.TYPEDICID,
                         "C." + Tables.yp_specdic.DOSEDICID,
                        "C." + Tables.yp_specdic.SPECDICID,
                         _oleDb.FiledNameBM(value_7, "PACKNUM"),
                        _oleDb.FiledNameBM(value_8, "BASENUM"),
                        _oleDb.FiledNameBM(_gs_1_8, "TOTALFEE"),
                        _oleDb.FiledNameBM(_gs_1_9, "TRADEFEE"),
                        _oleDb.FiledNameBM(_gs_1_8 + "-" + _gs_1_9, "FEEDIFFERENCE"),
                         childtable_1,
                         childtable_2);
            string strWhere_9 = "F." + Tables.yp_bynamedic.SPECDICID + _oleDb.EuqalTo() + "E." + Tables.yp_specdic.SPECDICID +
                _oleDb.And() + "E." + Tables.yf_storage.DEPTID + _oleDb.EuqalTo() + deptId +
                _oleDb.And() + "E.DELMAKER" + _oleDb.EuqalTo() + 0;
            if (strWhere.Trim() != "")
            {
                strWhere_9 += _oleDb.And() + strWhere;

            }
            strWhere_9 += _oleDb.OrderBy("E.CHEMNAME");
            string strsql = _oleDb.Table(_oleDb.TableName(_oleDb.TableNameBM(Tables.YP_BYNAMEDIC, "F"), childtable_3), "", strWhere_9,
                _oleDb.Distinct("E.*"));
            return _oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 获取药房所有待盘药品
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public DataTable YF_GetCheckDrug(string strWhere, int deptId)
        {
            string strWhere1 = "A.DEPTID" + _oleDb.EuqalTo() + deptId;
            string strsql = _oleDb.Table(HIS.BLL.Views.VI_YF_CHECKDRUG, "A", strWhere.Trim() == "" ? strWhere1 : strWhere1 + _oleDb.And() + strWhere,
             "A.*");
            return _oleDb.GetDataTable(strsql);
        }
        /// <summary>
        /// 获取药品月结时需要的库存药品信息列表
        /// </summary>
        /// <param name="deptId">部门ＩＤ</param>
        /// <returns>库存药品信息列表</returns>
        public DataTable YF_Storage_GetListForAccount(int deptId)
        {
            string _gs_1_2 = _oleDb.DBConvert("0", "decimal(18,4)");
            string strWhere_3 = "A." + Tables.yf_storage.DEPTID + _oleDb.EuqalTo() + deptId;
            string str = _oleDb.TableNameBM(Tables.YF_STORAGE, "A") + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_MAKERDIC, "B") +
                _oleDb.ON("A." + Tables.yf_storage.MAKERDICID, "B." + Tables.yp_makerdic.MAKERDICID) +
                 _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_SPECDIC, "C") +
                 _oleDb.ON("B." + Tables.yp_makerdic.SPECDICID, "C." + Tables.yp_makerdic.SPECDICID);
            string strsql = _oleDb.Table(str, "", strWhere_3,
             "A.*",
             "B." + Tables.yp_makerdic.MAKERDICID,
             "C." + Tables.yp_specdic.SPEC,
             "C." + Tables.yp_specdic.CHEMNAME,
             "B." + Tables.yp_makerdic.RETAILPRICE,
             "B." + Tables.yp_makerdic.TRADEPRICE,
             _oleDb.FiledNameBM("C." + Tables.yp_specdic.PACKNUM, " PUNITNUM"),
             "C." + Tables.yp_specdic.PACKUNIT,
             "C." + Tables.yp_specdic.UNIT,
             _oleDb.FiledNameBM(_gs_1_2, "BALANCEFEE"));
            return _oleDb.GetDataTable(strsql);
        }

        #endregion  成员方法

        #region  药库台帐

        /// <summary>
        /// 获取药库明细账列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>药库药品明细账列表</returns>
        public DataTable YK_Account_GetList(string strWhere)
        {
            string[] when = new string[4];
            when[0] = _oleDb.When() + "A." + Tables.yk_account.ACCOUNTTYPE + _oleDb.EuqalTo() + "0" + _oleDb.Then() + "'期初结余'";
            when[1] = _oleDb.When() + "A." + Tables.yk_account.ACCOUNTTYPE + _oleDb.EuqalTo() + "1" + _oleDb.Then() + "'期末结余'";
            when[2] = _oleDb.When() + "A." + Tables.yk_account.ACCOUNTTYPE + _oleDb.EuqalTo() + "2" + _oleDb.Then() + "'发生'";
            when[3] = _oleDb.When() + "A." + Tables.yk_account.ACCOUNTTYPE + _oleDb.EuqalTo() + "3" + _oleDb.Then() + "'调整'";

            string casewhen_1 = _oleDb.CASEWhen("AccountType", when);
            string[] when1 = new string[10];
            when1[0] = _oleDb.When() + "A." + Tables.yk_account.OPTYPE + _oleDb.EuqalTo() + "'010'" + _oleDb.Then() + "'入库'";
            when1[1] = _oleDb.When() + "A." + Tables.yk_account.OPTYPE + _oleDb.EuqalTo() + "'018'" + _oleDb.Then() + "'报损出库'";
            when1[2] = _oleDb.When() + "A." + Tables.yk_account.OPTYPE + _oleDb.EuqalTo() + "'017'" + _oleDb.Then() + "'科室领药'";
            when1[3] = _oleDb.When() + "A." + Tables.yk_account.OPTYPE + _oleDb.EuqalTo() + "'013'" + _oleDb.Then() + "'药品盘点'";
            when1[4] = _oleDb.When() + "A." + Tables.yk_account.OPTYPE + _oleDb.EuqalTo() + "'016'" + _oleDb.Then() + "'药品调价'";
            when1[5] = _oleDb.When() + "A." + Tables.yk_account.OPTYPE + _oleDb.EuqalTo() + "'015'" + _oleDb.Then() + "'月结'";
            when1[6] = _oleDb.When() + "A." + Tables.yk_account.OPTYPE + _oleDb.EuqalTo() + "'012'" + _oleDb.Then() + "'盘点审核'";
            when1[7] = _oleDb.When() + "A." + Tables.yk_account.OPTYPE + _oleDb.EuqalTo() + "'011'" + _oleDb.Then() + "'药房申领'";
            when1[8] = _oleDb.When() + "A." + Tables.yk_account.OPTYPE + _oleDb.EuqalTo() + "'019'" + _oleDb.Then() + "'期初入库'";
            when1[9] = _oleDb.When() + "A." + Tables.yk_account.OPTYPE + _oleDb.EuqalTo() + "'024'" + _oleDb.Then() + "'退供应商'";

            string casewhen_2 = _oleDb.CASEWhen("OpType", when1);
            string str = _oleDb.TableNameBM(Tables.YK_ACCOUNT, "A") + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_UNITDIC, "B") +
                _oleDb.ON("A." + Tables.yk_account.LEASTUNIT, "B." + Tables.yp_unitdic.UNITDICID);

            str += @" left join YK_INORDER c on a.orderid=c.INSTORAGEID and a.optype='010'
                         left join YK_INMASTER d on c.MASTERINSTORAGEID=d.MASTERINSTORAGEID
                         left join YP_SUPPORTDIC e on e.SUPPORTDICID=d.SUPPORTDICID";

            string strsql = _oleDb.Table(str, "", strWhere.Trim() == "" ? "" : strWhere,
                "e.name supportname",
             "A." + Tables.yk_account.MACCOUNTID,
            "A." + Tables.yk_account.ACCOUNTYEAR,
            "A." + Tables.yk_account.ACCOUNTMONTH,
            "B." + Tables.yp_unitdic.UNITNAME,
            casewhen_1,
              "A." + Tables.yk_account.RETAILPRICE,
            "A." + Tables.yk_account.STOCKPRICE,
            casewhen_2,
             "A." + Tables.yk_account.BILLNUM,
            "A." + Tables.yk_account.UNITNUM,
            "A." + Tables.yk_account.LEASTUNIT,
            "A." + Tables.yk_account.REGTIME,
            "A." + Tables.yk_account.DEBITNUM,
            "A." + Tables.yk_account.LENDERNUM,
            "A." + Tables.yk_account.OVERNUM,
            "A." + Tables.yk_account.DEBITFEE,
            "A." + Tables.yk_account.LENDERFEE,
            "A." + Tables.yk_account.BALANCEFEE,
            "A." + Tables.yk_account.BALANCE_FLAG,
            "A." + Tables.yk_account.ACCOUNTHISTORYID,
            "A." + Tables.yk_account.MAKERDICID,
            "A." + Tables.yk_account.DEPTID,
            "A." + Tables.yk_account.ORDERID);
            strsql += _oleDb.OrderBy() + "A." + Tables.yk_account.REGTIME;
            return _oleDb.GetDataTable(strsql);
        }

        #endregion  成员方法

        #region  药库盘点表头

        /// <summary>
        /// 判断除指定单据外是否存在未审核单据
        /// </summary>
        /// <param name="exceptID">指定单据ID</param>
        /// <returns>true：存在；false：不存在</returns>
        public bool YK_Checkmaster_ExistNotAudit(int exceptID)
        {
            string strWhere = Tables.yk_checkmaster.AUDIT_FLAG + _oleDb.EuqalTo() + "0" + _oleDb.And() +
                Tables.yk_checkmaster.MASTERCHECKID + _oleDb.NotEqualTo() + exceptID + _oleDb.And() +
                Tables.yk_checkmaster.DEL_FLAG + _oleDb.EuqalTo() + "0";
            int cmdresult;
            object obj = BindEntity<YP_CheckMaster>.CreateInstanceDAL(_oleDb,
                Tables.YK_CHECKMASTER).GetFieldValue(_oleDb.Count(Tables.yk_checkmaster.MASTERCHECKID, ""), strWhere);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 将药库盘点单表头置为已审核状态
        /// </summary>
        /// <param name="masterId">盘点单表头ＩＤ</param>
        /// <param name="checkTime">审核时间</param>
        /// <param name="chekPeople">审核人员</param>
        public void YK_Checkmaster_Check(int masterId, DateTime checkTime, long chekPeople)
        {
            string strWhere = Tables.yk_checkmaster.MASTERCHECKID + _oleDb.EuqalTo() + masterId;
            string[] strSet = new string[3];
            strSet[0] = Tables.yk_checkmaster.AUDIT_FLAG + _oleDb.EuqalTo() + "1";
            strSet[1] = Tables.yk_checkmaster.AUDITTIME + _oleDb.EuqalTo() + "'" + checkTime + "'";
            strSet[2] = Tables.yk_checkmaster.AUDITPEOPLEID + _oleDb.EuqalTo() + Convert.ToInt32(chekPeople);
            BindEntity<YP_CheckMaster>.CreateInstanceDAL(_oleDb, Tables.YK_CHECKMASTER).Update(strWhere, strSet);
        }

        /// <summary>
        /// 获取药库盘点单表头列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="deptId">部门ID</param>
        /// <returns>药品盘点单表头列表</returns>
        public DataTable YK_Checkmaster_GetList(string strWhere)
        {
            string str = _oleDb.TableNameBM(Tables.YK_CHECKMASTER, "A") + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_USER, "B") +
                _oleDb.ON("A." + Tables.yk_checkmaster.REGPEOPLEID, "B." + Tables.base_user.USER_ID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_EMPLOYEE_PROPERTY, "C") +
                _oleDb.ON("B." + Tables.base_user.EMPLOYEE_ID, "C." + Tables.base_employee_property.EMPLOYEE_ID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_USER, "D") +
                _oleDb.ON("A." + Tables.yk_checkmaster.AUDITPEOPLEID, "D." + Tables.base_user.USER_ID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_EMPLOYEE_PROPERTY, "E") +
                _oleDb.ON("D." + Tables.base_user.EMPLOYEE_ID, "E." + Tables.base_employee_property.EMPLOYEE_ID);
            string strsql = _oleDb.Table(str, "", strWhere,
             "A.*",
             _oleDb.FiledNameBM("C." + Tables.base_employee_property.NAME, "RegName"),
             _oleDb.FiledNameBM("E." + Tables.base_employee_property.NAME, "AuditName"));

            return _oleDb.GetDataTable(strsql);
        }

        #endregion  成员方法

        #region  药库盘点明细
        /// <summary>
        /// 获取药库盘点表头对应的明细信息
        /// </summary>
        /// <param name="MasterCheckID">药库盘点单表头ＩＤ</param>
        /// <returns>药库盘点明细列表</returns>
        public DataTable YK_Checkorder_GetListByMaster(int MasterCheckID)
        {
            string strWhere_1 = Tables.yp_unitdic.UNITDICID + _oleDb.EuqalTo() + "C." + Tables.yp_specdic.PACKUNIT;
            string childtable_1 = _oleDb.ChildTable(Tables.YP_UNITDIC, "PACKUNITNAME", strWhere_1, Tables.yp_unitdic.UNITNAME);
            string strWhere_2 = Tables.yp_unitdic.UNITDICID + _oleDb.EuqalTo() + "C." + Tables.yp_specdic.UNIT;
            string childtable_2 = _oleDb.ChildTable(Tables.YP_UNITDIC, "UNITNAME", strWhere_2, Tables.yp_unitdic.UNITNAME);
            string strWhere_8 = "A." + Tables.yk_checkorder.MASTERCHECKID + _oleDb.EuqalTo() + MasterCheckID;
            string str = _oleDb.TableNameBM(Tables.YK_CHECKORDER, "A") + _oleDb.LeftOuterJoin() +
            _oleDb.TableNameBM(Tables.YP_MAKERDIC, "B") + _oleDb.ON("A." + Tables.yk_checkorder.MAKERDICID, "B." + Tables.yp_makerdic.MAKERDICID) +
            _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_SPECDIC, "C") +
            _oleDb.ON("B." + Tables.yp_makerdic.SPECDICID, "C." + Tables.yp_specdic.SPECDICID) +
            _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_PRODUCTDIC, "D") +
            _oleDb.ON("B." + Tables.yp_makerdic.PRODUCTID, "D." + Tables.yp_productdic.PRODUCTID) +
            _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_DOSEDIC, "E") +
            _oleDb.ON("E." + Tables.yp_dosedic.DOSEDICID, "C." + Tables.yp_specdic.DOSEDICID) +
            _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_TYPEDIC, "F") +
            _oleDb.ON("F." + Tables.yp_typedic.TYPEDICID, "C." + Tables.yp_specdic.TYPEDICID);
            string strsql = _oleDb.Table(str, "", strWhere_8,
           "A.*",
           "C." + Tables.yp_specdic.CHEMNAME,
           "C." + Tables.yp_specdic.TYPEDICID,
           "C." + Tables.yp_specdic.DOSEDICID,
           "C." + Tables.yp_specdic.SPEC,
           "D." + Tables.yp_productdic.PRODUCTNAME,
           "E." + Tables.yp_dosedic.DOSENAME,
           "F." + Tables.yp_typedic.TYPENAME,
           _oleDb.FiledNameBM("A." + Tables.yk_checkorder.UNITNUM, "PUNITNUM"),
           _oleDb.FiledNameBM("A." + Tables.yk_checkorder.FACTNUM, "PACKNUM"),
           _oleDb.FiledNameBM("A." + Tables.yk_checkorder.CHECKNUM, "CPACKNUM"),
           childtable_1,
            childtable_2);
            return _oleDb.GetDataTable(strsql);
        }
        #endregion  成员方法

        #region  药库入库表头

        /// <summary>
        /// 获取药库入库单表头列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="deptId">药库部门ＩＤ</param>
        /// <returns>药库入库单表头列表</returns>
        public DataTable YK_Inmaster_GetList(string strWhere)
        {
            string[] when = new string[3];
            when[0] = _oleDb.When() + "A." + Tables.yk_inmaster.OPTYPE + _oleDb.EuqalTo() + "'010'" + _oleDb.Then() + "'采购入库'";
            when[1] = _oleDb.When() + "A." + Tables.yk_inmaster.OPTYPE + _oleDb.EuqalTo() + "'019'" + _oleDb.Then() + "'期初入库'";
            when[2] = _oleDb.When() + "A." + Tables.yk_inmaster.OPTYPE + _oleDb.EuqalTo() + "'024'" + _oleDb.Then() + "'药品退库'";
            string casewhen_1 = _oleDb.CASEWhen("TYPENAME", when);
            string str = _oleDb.TableNameBM(Tables.YK_INMASTER, "A") + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_USER, "B") +
                _oleDb.ON("A." + Tables.yk_inmaster.REGPEOPLEID, "B." + Tables.base_user.USER_ID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_EMPLOYEE_PROPERTY, "C") +
                _oleDb.ON("B." + Tables.base_user.EMPLOYEE_ID, "C." + Tables.base_employee_property.EMPLOYEE_ID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_USER, "D") +
                _oleDb.ON("A." + Tables.yk_inmaster.AUDITPEOPLEID, "D." + Tables.base_user.USER_ID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_EMPLOYEE_PROPERTY, "E") +
                _oleDb.ON("D." + Tables.base_user.EMPLOYEE_ID, "E." + Tables.base_employee_property.EMPLOYEE_ID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_SUPPORTDIC, "F") +
                _oleDb.ON("A." + Tables.yk_inmaster.SUPPORTDICID, "F." + Tables.yp_supportdic.SUPPORTDICID);
            string strsql = _oleDb.Table(str, "", strWhere,
            "A.*",
            _oleDb.FiledNameBM("C." + Tables.base_employee_property.NAME, " RegName"),
            _oleDb.FiledNameBM("E." + Tables.base_employee_property.NAME, "AuditName"),
            _oleDb.FiledNameBM("F." + Tables.yp_supportdic.NAME, "SupportName"),
            casewhen_1);

            return _oleDb.GetDataTable(strsql);
        }

        #endregion  成员方法

        #region  药库入库明细

        /// <summary>
        /// 获取药库指定药品的入库历史记录
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>指定药品的入库历史记录</returns>
        public DataTable YK_SupportHis(string strWhere)
        {
            string tableName = _oleDb.TableNameBM(Tables.YK_INORDER, "A") + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YK_INMASTER, "B") +
                _oleDb.ON("A." + Tables.yk_inorder.MASTERINSTORAGEID, "B." + Tables.yk_inmaster.MASTERINSTORAGEID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_SUPPORTDIC, "C") +
                _oleDb.ON("B." + Tables.yk_inmaster.SUPPORTDICID, "C." + Tables.yp_supportdic.SUPPORTDICID);
            string strSql = _oleDb.Table(tableName, "", strWhere,
                _oleDb.FiledNameBM("A." + Tables.yk_inorder.INNUM, "innum"),
                _oleDb.FiledNameBM("A." + Tables.yk_inorder.BATCHNUM, "batchnum"),
                _oleDb.FiledNameBM("B." + Tables.yk_inmaster.REGTIME, "regtime"),
                _oleDb.FiledNameBM("B." + Tables.yk_inmaster.BILLNUM, "billnum"),
                _oleDb.FiledNameBM("C." + Tables.yp_supportdic.NAME, "supportname"));
            return _oleDb.GetDataTable(strSql);
        }

        /// <summary>
        /// 获取药库入库单明细列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>药库入库单明细列表</returns>
        public DataTable YK_Inorder_GetList(string strWhere)
        {
            string str = _oleDb.TableNameBM(Tables.YK_INORDER, "A") + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_MAKERDIC, "B") +
                _oleDb.ON("A." + Tables.yk_inorder.MAKERDICID, "B." + Tables.yp_makerdic.MAKERDICID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_SPECDIC, "C") +
                _oleDb.ON("B." + Tables.yp_makerdic.SPECDICID, "C." + Tables.yp_specdic.SPECDICID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_UNITDIC, "D") +
                _oleDb.ON("A." + Tables.yk_inorder.LEASTUNIT, "D." + Tables.yp_unitdic.UNITDICID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_PRODUCTDIC, "E") +
                _oleDb.ON("B." + Tables.yp_makerdic.PRODUCTID, "E." + Tables.yp_productdic.PRODUCTID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YK_STORAGE, "F") +
                _oleDb.ON("A." + Tables.yk_inorder.MAKERDICID, "F." + Tables.yk_storage.MAKERDICID);
            string strsql = _oleDb.Table(str, "", strWhere.Trim() == "" ? "" : strWhere,
            "A.*",
            "A.RETAILFEE-A.STOCKFEE AS DIFFFEE",
            "C." + Tables.yp_specdic.CHEMNAME,
            "C." + Tables.yp_specdic.SPEC,
             "D." + Tables.yp_unitdic.UNITNAME,
            "E." + Tables.yp_productdic.PRODUCTNAME,
            "B." + Tables.yp_makerdic.DEFSTOCKPRICE,
            "F." + Tables.yk_storage.CURRENTNUM);

            strsql += _oleDb.OrderBy() + Tables.yk_inorder.INSTORAGEID;
            return _oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 按入库单据查询其明细各药品类型汇总金额
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable YK_Inorder_GetTotalFee(string strWhere)
        {
            string strTable = _oleDb.TableNameBM(Tables.YK_INORDER, "a") +
                _oleDb.LeftOuterJoin()+_oleDb.TableNameBM(Tables.YK_INMASTER,"e")+
                _oleDb.ON("e."+Tables.yk_inmaster.MASTERINSTORAGEID,"a."+Tables.yk_inorder.MASTERINSTORAGEID)+
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_MAKERDIC, "b") +
                _oleDb.ON("a." + Tables.yk_inorder.MAKERDICID, "b." + Tables.yp_makerdic.MAKERDICID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_SPECDIC, "c") +
                _oleDb.ON("b." + Tables.yp_makerdic.SPECDICID, "c." + Tables.yp_specdic.SPECDICID);
            strWhere += " and (e.optype='010' or e.optype='019')";
            string strSql = _oleDb.Table(strTable, "", strWhere,
                "sum(a.retailfee) as RetailFee",
                "sum(a.tradefee) as TradeFee",
                "c.typedicid");
            strSql += _oleDb.GroupBy() + "c.typedicid";
            return _oleDb.GetDataTable(strSql);
        }


        public DataTable YK_Outorder_GetTotalFee(string strWhere)
        {
            string strTable = _oleDb.TableNameBM(Tables.YK_INORDER, "a") +
               _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YK_INMASTER, "e") +
               _oleDb.ON("e." + Tables.yk_inmaster.MASTERINSTORAGEID, "a." + Tables.yk_inorder.MASTERINSTORAGEID) +
               _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_MAKERDIC, "b") +
               _oleDb.ON("a." + Tables.yk_inorder.MAKERDICID, "b." + Tables.yp_makerdic.MAKERDICID) +
               _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_SPECDIC, "c") +
               _oleDb.ON("b." + Tables.yp_makerdic.SPECDICID, "c." + Tables.yp_specdic.SPECDICID);
            strWhere += " and e.optype='024'";
            string strSql = _oleDb.Table(strTable, "", strWhere,
                "sum(a.retailfee) as RetailFee",
                "sum(a.tradefee) as TradeFee",
                "c.typedicid");
            strSql += _oleDb.GroupBy() + "c.typedicid";
            return _oleDb.GetDataTable(strSql);
        }
        #endregion  成员方法

        #region  药库出库表头

        /// <summary>
        /// 获取指定单据号对应的药库出库单表头ID
        /// </summary>
        /// <param name="billNum">单据号</param>
        /// <returns>出库单表头ＩＤ</returns>
        public int YK_Outmaster_GetIDByBillNum(int billNum, int deptid) //加科室条件过滤 update by heyan 2010.08.05
        {
            string strWhere = Tables.yk_outmaster.RELATIONNUM + _oleDb.EuqalTo() + billNum + _oleDb.And() + Tables.yk_outmaster.OUTDEPTID + _oleDb.EuqalTo() + deptid;
            object obj = BindEntity<YP_OutMaster>.CreateInstanceDAL(_oleDb, Tables.YK_OUTMASTER).GetFieldValue(Tables.yk_outmaster.MASTEROUTSTORAGEID, strWhere);
            if (obj != null && obj != DBNull.Value)
            {
                return int.Parse(obj.ToString());
            }
            return -1;
        }

        /// <summary>
        /// 获取药库出库单表头列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>药库出库单表头列表</returns>
        public DataTable YK_Outmaster_GetList(string strWhere)
        {
            string[] when = new string[3];
            when[0] = _oleDb.When() + "A." + Tables.yk_outmaster.OPTYPE + _oleDb.EuqalTo() + "'017'" + _oleDb.Then() + "'科室领药'";
            when[1] = _oleDb.When() + "A." + Tables.yk_outmaster.OPTYPE + _oleDb.EuqalTo() + "'018'" + _oleDb.Then() + "'药品报损'";
            when[2] = _oleDb.When() + "A." + Tables.yk_outmaster.OPTYPE + _oleDb.EuqalTo() + "'011'" + _oleDb.Then() + "'药房申领'";

            string casewhen_1 = _oleDb.CASEWhen("TYPENAME", when);
            string str = _oleDb.TableNameBM(Tables.YK_OUTMASTER, "A") + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_USER, "B") +
                _oleDb.ON("A." + Tables.yk_outmaster.REGPEOPLEID, "B." + Tables.base_user.USER_ID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_EMPLOYEE_PROPERTY, "C") +
                _oleDb.ON("B." + Tables.base_user.EMPLOYEE_ID, "C." + Tables.base_employee_property.EMPLOYEE_ID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_USER, "D") +
                _oleDb.ON("A." + Tables.yk_outmaster.AUDITPEOPLEID, "D." + Tables.base_user.USER_ID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_EMPLOYEE_PROPERTY, "E") +
                _oleDb.ON("D." + Tables.base_user.EMPLOYEE_ID, "E." + Tables.base_employee_property.EMPLOYEE_ID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_DEPT_PROPERTY, "F") +
                _oleDb.ON("A." + Tables.yk_outmaster.OUTDEPTID, "F." + Tables.base_dept_property.DEPT_ID);
            string strsql = _oleDb.Table(str, "", strWhere, "A.*",
            _oleDb.FiledNameBM("C." + Tables.base_employee_property.NAME, " RegName"),
            _oleDb.FiledNameBM("E." + Tables.base_employee_property.NAME, "AuditName"),
            _oleDb.FiledNameBM("F." + Tables.base_dept_property.NAME, "OutDeptName"),
              casewhen_1);
            return _oleDb.GetDataTable(strsql);
        }
        #endregion  成员方法

        #region  药库出库明细

        /// <summary>
        /// 获取药库出库明细列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>药库出库明细列表</returns>
        public DataTable YK_Outorder_GetList(string strWhere)
        {
            string str = _oleDb.TableNameBM(Tables.YK_OUTORDER, "A") + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_MAKERDIC, "B") +
                 _oleDb.ON("A." + Tables.yk_outorder.MAKERDICID, "B." + Tables.yp_makerdic.MAKERDICID) +
                 _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_SPECDIC, "C") +
                 _oleDb.ON("B." + Tables.yp_makerdic.SPECDICID, "C." + Tables.yp_specdic.SPECDICID) +
                 _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_UNITDIC, "D") +
                 _oleDb.ON("A." + Tables.yk_outorder.LEASTUNIT, "D." + Tables.yp_unitdic.UNITDICID) +
                 _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_PRODUCTDIC, "E") +
                 _oleDb.ON("B." + Tables.yp_makerdic.PRODUCTID, "E." + Tables.yp_productdic.PRODUCTID);
            string strsql = _oleDb.Table(str, "", strWhere.Trim() == "" ? "" : strWhere,
            "A.*",
            "A.RETAILFEE-A.TRADEFEE AS DIFFFEE",
            "C." + Tables.yp_specdic.CHEMNAME,
            "C." + Tables.yp_specdic.SPEC,
            "C." + Tables.yp_specdic.PACKNUM,
            "D." + Tables.yp_unitdic.UNITNAME,
            "E." + Tables.yp_productdic.PRODUCTNAME);
            return _oleDb.GetDataTable(strsql);
        }

        #endregion  成员方法

        #region  药库库存

        /// <summary>
        /// 判断某种药品是否有库存
        /// </summary>
        /// <param name="MakerDicID">厂家典ＩＤ</param>
        /// <param name="DeptID">部门ＩＤ</param>
        /// <returns>true:存在；false：不存在</returns>
        public bool YK_Store_ExistsDrug(int MakerDicID, int DeptID)
        {

            string strWhere = Tables.yk_storage.MAKERDICID + _oleDb.EuqalTo() + MakerDicID + _oleDb.And() +
                Tables.yk_storage.DEPTID + _oleDb.EuqalTo() + DeptID;
            int cmdresult;
            object obj = BindEntity<YP_Storage>.CreateInstanceDAL(_oleDb, Tables.YK_STORAGE).GetFieldValue(_oleDb.Count(Tables.yk_storage.STORAGEID, ""), strWhere);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0 || cmdresult == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 判断某个库房是否存有药品
        /// </summary>
        /// <param name="deptId">库房部门ID</param>
        /// <returns>true：存在；false：不存在</returns>
        public bool YK_Store_ExistsStore(int deptId)
        {
            string strWhere = Tables.yk_storage.DEPTID + _oleDb.EuqalTo() + deptId;
            int cmdresult;
            object obj = BindEntity<YP_Storage>.CreateInstanceDAL(_oleDb, Tables.YK_STORAGE).GetFieldValue(_oleDb.Count(Tables.yk_storage.STORAGEID, ""), strWhere);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0 || cmdresult == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 增加药品库存
        /// </summary>
        /// <param name="MakerDicID">药品厂家典ID</param>
        /// <param name="AddNum">增加数量</param>
        /// <param name="deptId">部门ID</param>
        public void YK_Store_AddStore(int MakerDicID, decimal AddNum, int deptId)
        {
            string strWhere = Tables.yk_storage.MAKERDICID + _oleDb.EuqalTo() + MakerDicID + _oleDb.And() +
                Tables.yk_storage.DEPTID + _oleDb.EuqalTo() + deptId;
            string strSet = Tables.yk_storage.CURRENTNUM + _oleDb.EuqalTo() + _oleDb.Add(Tables.yk_storage.CURRENTNUM, AddNum.ToString());
            BindEntity<YP_Storage>.CreateInstanceDAL(_oleDb, Tables.YK_STORAGE).Update(strWhere, strSet);
        }

        /// <summary>
        /// 减少药品库存
        /// </summary>
        /// <param name="MakerDicID">药品厂家典ID</param>
        /// <param name="ReduceNum">减少数量</param>
        /// <param name="deptId">部门ＩＤ</param>
        public void YK_Store_ReduceStore(int MakerDicID, decimal ReduceNum, int deptId)
        {
            string strWhere = Tables.yk_storage.MAKERDICID + _oleDb.EuqalTo() + MakerDicID + _oleDb.And() +
                Tables.yk_storage.DEPTID + _oleDb.EuqalTo() + deptId;
            string strSet = Tables.yk_storage.CURRENTNUM + _oleDb.EuqalTo() + _oleDb.Subtract(Tables.yk_storage.CURRENTNUM, ReduceNum.ToString());
            BindEntity<YP_Storage>.CreateInstanceDAL(_oleDb, Tables.YK_STORAGE).Update(strWhere, strSet);
        }

        /// <summary>
        /// 更新药品库存
        /// </summary>
        /// <param name="MakerDicID">药品厂家典ID</param>
        /// <param name="UpdateNum">更新数量</param>
        /// <param name="deptId">部门ID</param>
        public void YK_Store_UpdateStore(int MakerDicID, decimal UpdateNum, int deptId)
        {
            string strWhere = Tables.yk_storage.MAKERDICID + _oleDb.EuqalTo() + MakerDicID + _oleDb.And() +
                Tables.yk_storage.DEPTID + _oleDb.EuqalTo() + deptId;
            string strSet = Tables.yk_storage.CURRENTNUM + _oleDb.EuqalTo() + UpdateNum;
            BindEntity<YP_Storage>.CreateInstanceDAL(_oleDb, Tables.YK_STORAGE).Update(strWhere, strSet);
        }

        /// <summary>
        /// 获取药库库存药品信息列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="deptId">药库部门ID</param>
        /// <returns>药库库存药品信息列表</returns>
        public DataTable YK_Store_GetList(string strWhere, int deptId)
        {
            string strWhere_1 = Tables.yp_unitdic.UNITDICID + _oleDb.EuqalTo() + "C." + Tables.yp_specdic.PACKUNIT;
            string childtable_1 = _oleDb.ChildTable(Tables.YP_UNITDIC, "PACKUNITNAME", strWhere_1, Tables.yp_unitdic.UNITNAME);
            string strWhere_2 = Tables.yp_unitdic.UNITDICID + _oleDb.EuqalTo() + "C." + Tables.yp_specdic.UNIT;
            string childtable_2 = _oleDb.ChildTable(Tables.YP_UNITDIC, "UNITNAME", strWhere_2, Tables.yp_unitdic.UNITNAME);
            string _gs_1_3 = "A." + Tables.yk_storage.CURRENTNUM;
            string _gs_1_5 = _oleDb.DBConvert(_oleDb.Multiply("A." + Tables.yk_storage.CURRENTNUM, "B." + Tables.yp_makerdic.RETAILPRICE), "decimal(18,2)");
            string _gs_1_6 = _oleDb.DBConvert(_oleDb.Multiply("A." + Tables.yk_storage.CURRENTNUM, "B." + Tables.yp_makerdic.TRADEPRICE), "decimal(18,2)");
            string str = _oleDb.TableNameBM(Tables.YK_STORAGE, "A") + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_MAKERDIC, "B") +
            _oleDb.ON("A." + Tables.yk_storage.MAKERDICID, "B." + Tables.yp_makerdic.MAKERDICID) +
            _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_SPECDIC, "C") +
            _oleDb.ON("B." + Tables.yp_makerdic.SPECDICID, "C." + Tables.yp_specdic.SPECDICID) +
            _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_PRODUCTDIC, "D") +
            _oleDb.ON("B." + Tables.yp_makerdic.PRODUCTID, "D." + Tables.yp_productdic.PRODUCTID);
            string childtable_3 = _oleDb.ChildTable(str, "E", "", "A.*",
            "B." + Tables.yp_makerdic.MAKERDICID,
            _oleDb.FiledNameBM("B." + Tables.yp_makerdic.GETWAY, "STOPUSE"),
            _oleDb.FiledNameBM("B." + Tables.yp_makerdic.DEL_FLAG, "DELMAKER"),
             "C." + Tables.yp_specdic.SPEC,
            "C." + Tables.yp_specdic.NAME,
            "C." + Tables.yp_specdic.CHEMNAME,
            "B." + Tables.yp_makerdic.RETAILPRICE,
            "B." + Tables.yp_makerdic.TRADEPRICE,
            "D." + Tables.yp_productdic.PRODUCTNAME,
            _oleDb.FiledNameBM("C." + Tables.yp_specdic.PACKNUM, "PUNITNUM"),
            "C." + Tables.yp_specdic.PACKUNIT,
             "C." + Tables.yp_specdic.UNIT,
             "C." + Tables.yp_specdic.DOSEDICID,
            "C." + Tables.yp_specdic.TYPEDICID,
            "C." + Tables.yp_specdic.SPECDICID,
            _oleDb.FiledNameBM(_gs_1_3, "PACKNUM"),
            _oleDb.FiledNameBM("0", "BASENUM"),
            _oleDb.FiledNameBM(_gs_1_5, "TOTALFEE"),
            _oleDb.FiledNameBM(_gs_1_6, "TRADEFEE"),
            _oleDb.FiledNameBM(_gs_1_5 + "-" + _gs_1_6, "FEEDIFFERENCE"),
             childtable_1,
             childtable_2);
            string strWhere_6 = "F." + Tables.yp_bynamedic.SPECDICID + _oleDb.EuqalTo() + "E." + Tables.yp_specdic.SPECDICID
                + _oleDb.And() + "E." + Tables.yk_storage.DEPTID + _oleDb.EuqalTo() + deptId
                + _oleDb.And() + "E.DELMAKER" + _oleDb.EuqalTo() + 0;
            if (strWhere.Trim() != "")
            {
                strWhere_6 += _oleDb.And() + strWhere;
            }
            strWhere_6 += _oleDb.OrderBy("E.CHEMNAME");
            string strsql = _oleDb.Table(_oleDb.TableName(_oleDb.TableNameBM(Tables.YP_BYNAMEDIC, "F"), childtable_3), "", strWhere_6,
                 _oleDb.Distinct("E.*"));
            return _oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 获取药库盘存所需药品信息列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="deptId">部门ＩＤ</param>
        /// <returns>药库盘存所需药品信息列表</returns>
        public DataTable YK_Store_GetListForCheck(string strWhere, int deptId)
        {
            string strWhere_1 = Tables.yp_unitdic.UNITDICID + _oleDb.EuqalTo() + "C." + Tables.yp_specdic.PACKUNIT;
            string childtable_1 = _oleDb.ChildTable(Tables.YP_UNITDIC, "PACKUNITNAME", strWhere_1, Tables.yp_unitdic.UNITNAME);
            string _gs_1_2 = _oleDb.DBConvert("A." + Tables.yk_storage.CURRENTNUM, " Integer");
            string strWhere_4 = "A." + Tables.yk_storage.DEPTID + _oleDb.EuqalTo() + deptId;
            if (strWhere.Trim() != "")
            {
                strWhere_4 += _oleDb.And() + strWhere;
            }
            string str = _oleDb.TableNameBM(Tables.YK_BATCH, "A") + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_MAKERDIC, "B") +
            _oleDb.ON("A." + Tables.yk_storage.MAKERDICID, "B." + Tables.yp_makerdic.MAKERDICID) +
            _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_SPECDIC, "C") +
            _oleDb.ON("B." + Tables.yp_makerdic.SPECDICID, "C." + Tables.yp_specdic.SPECDICID) +
            _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_PRODUCTDIC, "D") +
            _oleDb.ON("B." + Tables.yp_makerdic.PRODUCTID, "D." + Tables.yp_productdic.PRODUCTID) +
            _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_DOSEDIC, "E") +
            _oleDb.ON("C." + Tables.yp_specdic.DOSEDICID, "E." + Tables.yp_dosedic.DOSEDICID) +
            _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_TYPEDIC, "F") +
            _oleDb.ON("C." + Tables.yp_specdic.TYPEDICID, "F." + Tables.yp_typedic.TYPEDICID);

            string strsql = _oleDb.Table(str, "", strWhere_4,
                "A.*", "A.UNIT AS LEASTUNIT",
                "B." + Tables.yp_makerdic.MAKERDICID,
                "C." + Tables.yp_specdic.SPEC,
                "C." + Tables.yp_specdic.NAME,
                "C." + Tables.yp_specdic.CHEMNAME,
                "C." + Tables.yp_specdic.TYPEDICID,
                "C." + Tables.yp_specdic.DOSEDICID,
                "B." + Tables.yp_makerdic.RETAILPRICE,
                "B." + Tables.yp_makerdic.TRADEPRICE,
                "D." + Tables.yp_productdic.PRODUCTNAME,
                "E." + Tables.yp_dosedic.DOSENAME,
                "F." + Tables.yp_typedic.TYPENAME,
                _oleDb.FiledNameBM("C." + Tables.yp_specdic.PACKNUM, "PUNITNUM"),
                 "C." + Tables.yp_specdic.PACKUNIT,
                "C." + Tables.yp_specdic.UNIT,
                _oleDb.FiledNameBM(_gs_1_2, "PACKNUM"),
                _oleDb.FiledNameBM("0", "CPACKNUM"),
                 childtable_1) + " Order By C.DOSEDICID,C.TYPEDICID";

            return _oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 获取药品月结所需药品库存信息列表
        /// </summary>
        /// <param name="deptId">部门ID</param>
        /// <returns>药品库存信息列表</returns>
        public DataTable YK_Store_GetListForAccount(int deptId)
        {
            string _gs_1_2 = _oleDb.DBConvert("0", "decimal(18,4)");
            string strWhere_3 = "A." + Tables.yk_storage.DEPTID + _oleDb.EuqalTo() + deptId;
            string str = _oleDb.TableNameBM(Tables.YK_STORAGE, "A") + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_MAKERDIC, "B") +
             _oleDb.ON("A." + Tables.yk_storage.MAKERDICID, "B." + Tables.yp_makerdic.MAKERDICID) + _oleDb.LeftOuterJoin() +
              _oleDb.TableNameBM(Tables.YP_SPECDIC, "C") + _oleDb.ON("B." + Tables.yp_makerdic.SPECDICID, "C." + Tables.yp_specdic.SPECDICID);
            string strsql = _oleDb.Table(str, "", strWhere_3,
            "A.*",
            "B." + Tables.yp_makerdic.MAKERDICID,
            "C." + Tables.yp_specdic.SPEC,
            "C." + Tables.yp_specdic.CHEMNAME,
            "B." + Tables.yp_makerdic.RETAILPRICE,
            "B." + Tables.yp_makerdic.TRADEPRICE,
            _oleDb.FiledNameBM("C." + Tables.yp_specdic.PACKNUM, "PUNITNUM"),
              "C." + Tables.yp_specdic.PACKUNIT,
            "C." + Tables.yp_specdic.UNIT,
            _oleDb.FiledNameBM(_gs_1_2, "BALANCEFEE"));
            return _oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 获取设置库存上下限所需药库库存信息列表
        /// </summary>
        /// <param name="deptId">药库ID</param>
        /// <returns>药品库存信息列表</returns>
        public DataTable YK_Store_GetListForSetLimit(int deptId)
        {
            string cast_2 = _oleDb.DBConvert("B." + Tables.yp_makerdic.RETAILPRICE, "decimal(10,2)");
            string _gs_1_3 = _oleDb.DBConvert("B." + Tables.yp_makerdic.TRADEPRICE, "decimal(10,2)");
            string strWhere_4 = Tables.yk_storage.DEPTID + _oleDb.EuqalTo() + deptId;
            string str = _oleDb.TableNameBM(Tables.YK_STORAGE, "A") + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_MAKERDIC, "B") +
             _oleDb.ON("A." + Tables.yk_storage.MAKERDICID, "B." + Tables.yp_makerdic.MAKERDICID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_SPECDIC, "C") +
             _oleDb.ON("B." + Tables.yp_makerdic.SPECDICID, "C." + Tables.yp_specdic.SPECDICID) +
             _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_PRODUCTDIC, "D") +
                _oleDb.ON("B." + Tables.yp_makerdic.PRODUCTID, "D." + Tables.yp_productdic.PRODUCTID) +
             _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_UNITDIC, "E") +
            _oleDb.ON("A." + Tables.yk_storage.LEASTUNIT, "E." + Tables.yp_unitdic.UNITDICID);
            string strsql = _oleDb.Table(str, "", strWhere_4, "A.*",
            "C." + Tables.yp_specdic.CHEMNAME,
            _oleDb.FiledNameBM(cast_2, "RETAILPRICE"),
            _oleDb.FiledNameBM(_gs_1_3, "TRADEPRICE"),
              "C." + Tables.yp_specdic.SPEC,
            "D." + Tables.yp_productdic.PRODUCTNAME,
            "E." + Tables.yp_unitdic.UNITNAME);
            return _oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 获取设置库存上下限所需药房库存信息列表
        /// </summary>
        /// <param name="deptId">药房ID</param>
        /// <returns>药品库存信息列表</returns>
        public DataTable YF_Storage_GetListForSetLimit(int deptId)
        {
            string cast_2 = _oleDb.DBConvert("B." + Tables.yp_makerdic.RETAILPRICE, "decimal(10,2)");
            string _gs_1_3 = _oleDb.DBConvert("B." + Tables.yp_makerdic.TRADEPRICE, "decimal(10,2)");
            string strWhere_4 = Tables.yf_storage.DEPTID + _oleDb.EuqalTo() + deptId;
            string str = _oleDb.TableNameBM(Tables.YF_STORAGE, "A") + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_MAKERDIC, "B") +
             _oleDb.ON("A." + Tables.yf_storage.MAKERDICID, "B." + Tables.yp_makerdic.MAKERDICID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_SPECDIC, "C") +
             _oleDb.ON("B." + Tables.yp_makerdic.SPECDICID, "C." + Tables.yp_specdic.SPECDICID) +
             _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_PRODUCTDIC, "D") +
                _oleDb.ON("B." + Tables.yp_makerdic.PRODUCTID, "D." + Tables.yp_productdic.PRODUCTID) +
             _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_UNITDIC, "E") +
            _oleDb.ON("A." + Tables.yf_storage.LEASTUNIT, "E." + Tables.yp_unitdic.UNITDICID);
            string strsql = _oleDb.Table(str, "", strWhere_4, "A.*",
            "C." + Tables.yp_specdic.CHEMNAME,
            _oleDb.FiledNameBM(cast_2, "RETAILPRICE"),
            _oleDb.FiledNameBM(_gs_1_3, "TRADEPRICE"),
              "C." + Tables.yp_specdic.SPEC,
            "D." + Tables.yp_productdic.PRODUCTNAME,
            "E." + Tables.yp_unitdic.UNITNAME);
            return _oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 统计药库库存药品总金额
        /// </summary>
        /// <param name="deptId">部门ID</param>
        /// <param name="drugType">药品类型ＩＤ</param>
        /// <returns></returns>
        public decimal YK_Store_GetTotalFee(int deptId, int drugType)
        {

            string muti = _oleDb.Multiply("A." + Tables.yk_storage.CURRENTNUM, "B." + Tables.yp_makerdic.RETAILPRICE);
            string sum_1 = _oleDb.Sum(muti, "");
            string strWhere_3 = "A." + Tables.yk_storage.DEPTID + _oleDb.EuqalTo() + deptId;
            if (drugType != 0)
            {
                strWhere_3 += _oleDb.And() + "C." + Tables.yp_specdic.TYPEDICID + _oleDb.EuqalTo() + drugType;
            }
            string str = _oleDb.TableNameBM(Tables.YK_STORAGE, "A") +
             _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_MAKERDIC, "B") +
          _oleDb.ON("A." + Tables.yk_storage.MAKERDICID, "B." + Tables.yp_makerdic.MAKERDICID) +
            _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_SPECDIC, "C") +
            _oleDb.ON("B." + Tables.yp_makerdic.SPECDICID, "C." + Tables.yp_specdic.SPECDICID);
            string strsql = _oleDb.Table(str, "", strWhere_3,
            _oleDb.FiledNameBM(sum_1, "TOTALFEE"));
            object obj = _oleDb.GetDataResult(strsql);
            if (obj != null && obj != DBNull.Value)
            {
                return decimal.Parse(obj.ToString());
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 统计药库库存批发总金额
        /// </summary>
        /// <param name="deptId">药剂科室ID</param>
        /// <param name="drugType">药品类型ＩＤ</param>
        /// <returns>药库库存批发总金额</returns>
        public decimal YK_Store_GetTradeFee(int deptId, int drugType)
        {

            string muti = _oleDb.Multiply("A." + Tables.yk_storage.CURRENTNUM, "B." + Tables.yp_makerdic.TRADEPRICE);
            string sum_1 = _oleDb.Sum(muti, "");
            string strWhere_3 = "A." + Tables.yk_storage.DEPTID + _oleDb.EuqalTo() + deptId;
            if (drugType != 0)
            {
                strWhere_3 += _oleDb.And() + "C." + Tables.yp_specdic.TYPEDICID + _oleDb.EuqalTo() + drugType;
            }
            string str = _oleDb.TableNameBM(Tables.YK_STORAGE, "A") +
             _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_MAKERDIC, "B") +
          _oleDb.ON("A." + Tables.yk_storage.MAKERDICID, "B." + Tables.yp_makerdic.MAKERDICID) +
            _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_SPECDIC, "C") +
            _oleDb.ON("B." + Tables.yp_makerdic.SPECDICID, "C." + Tables.yp_specdic.SPECDICID);
            string strsql = _oleDb.Table(str, "", strWhere_3,
            _oleDb.FiledNameBM(sum_1, "TRADEFEE"));
            object obj = _oleDb.GetDataResult(strsql);
            if (obj != null && obj != DBNull.Value)
            {
                return decimal.Parse(obj.ToString());
            }
            else
            {
                return -1;
            }
        }


        /// <summary>
        /// 获取药库所有待盘药品
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public DataTable YK_GetCheckDrug(string strWhere, int deptId)
        {
            string strWhere1 = "A.DEPTID" + _oleDb.EuqalTo() + deptId;
            string strsql = _oleDb.Table(HIS.BLL.Views.VI_YK_CHECKDRUG, "A", strWhere.Trim() == "" ? strWhere1 : strWhere1 + _oleDb.And() + strWhere,
             "A.*");
            return _oleDb.GetDataTable(strsql);
        }


        #endregion  成员方法

        #region  药品调价表头
        /// <summary>
        /// 获取药品调价表头信息列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="deptId">部门ID</param>
        /// <returns>药品调价表头信息列表</returns>
        public DataTable YP_Adjmaster_GetList(string strWhere)
        {
            string str = _oleDb.TableNameBM(Tables.YP_ADJMASTER, "A") + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_USER, "B") +
                _oleDb.ON("A." + Tables.yp_adjmaster.REGPEOPLE, "B." + Tables.base_user.USER_ID) +
                _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.BASE_EMPLOYEE_PROPERTY, "C") +
                _oleDb.ON("B." + Tables.base_user.EMPLOYEE_ID, "C." + Tables.base_employee_property.EMPLOYEE_ID);
            string strsql = _oleDb.Table(str, "", strWhere,
            "A.*",
            _oleDb.FiledNameBM("C." + Tables.base_employee_property.NAME, "RegName"));
            strsql += _oleDb.OrderBy() + Tables.yp_adjmaster.MASTERADJPRICEID;
            return _oleDb.GetDataTable(strsql);
        }

        #endregion  成员方法

        #region  药品调价明细
        /// <summary>
        /// 获取药品调价明细列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>药品调价单明细列表</returns>
        public DataTable YP_Adjorder_GetList(string strWhere)
        {
            string gs1 = _oleDb.Subtract("A." + Tables.yp_adjorder.NEWRETAILPRICE, "A." + Tables.yp_adjorder.OLDRETAILPRICE);
            string str = _oleDb.TableNameBM(Tables.YP_ADJORDER, "A") + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_MAKERDIC, "B") +
                   _oleDb.ON("A." + Tables.yp_adjorder.MAKERDICID, "B." + Tables.yp_makerdic.MAKERDICID) +
                   _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_SPECDIC, "C") +
                   _oleDb.ON("B." + Tables.yp_makerdic.SPECDICID, "C." + Tables.yp_specdic.SPECDICID) +
                   _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_UNITDIC, "D") +
                   _oleDb.ON("A." + Tables.yp_adjorder.LEASTUNIT, "D." + Tables.yp_unitdic.UNITDICID) +
                   _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_PRODUCTDIC, "E") +
                   _oleDb.ON("B." + Tables.yp_makerdic.PRODUCTID, "E." + Tables.yp_productdic.PRODUCTID);

            string strsql = _oleDb.Table(str, "", strWhere.Trim() == "" ? "" : strWhere,
            _oleDb.FiledNameBM("0", "ROWNO"),
            "A.*",
             "C." + Tables.yp_specdic.CHEMNAME,
            "C." + Tables.yp_specdic.SPEC,
             "D." + Tables.yp_unitdic.UNITNAME,
            "E." + Tables.yp_productdic.PRODUCTNAME,
            _oleDb.FiledNameBM(gs1, "AdjDif"));

            return _oleDb.GetDataTable(strsql);
        }
        #endregion  成员方法

        #region  药品系统单据号管理
        /// <summary>
        /// 按部门ID删除药品系统单据号记录集
        /// </summary>
        /// <param name="deptID">部门ID</param>
        public void YP_Bill_DeleteByDept(int deptID)
        {
            string strWhere = Tables.yp_billnumdic.DEPTID + _oleDb.EuqalTo() + deptID;
            BindEntity<YP_BillNumDic>.CreateInstanceDAL(_oleDb).Delete(strWhere);
        }

        /// <summary>
        /// 获取指定库房的所有业务类型
        /// </summary>
        /// <param name="deptId">部门ＩＤ</param>
        /// <returns></returns>
        public DataTable YP_Bill_GetListForDrugDept(int deptId)
        {
            string[] when = new string[19];
            when[0] = _oleDb.When() + Tables.yp_billnumdic.OPTYPE + _oleDb.EuqalTo() + "'001'" + _oleDb.Then() + "'药房申请入库业务'";
            when[1] = _oleDb.When() + Tables.yp_billnumdic.OPTYPE + _oleDb.EuqalTo() + "'002'" + _oleDb.Then() + "'药房报损出库业务类型'";
            when[2] = _oleDb.When() + Tables.yp_billnumdic.OPTYPE + _oleDb.EuqalTo() + "'003'" + _oleDb.Then() + "'药房发药'";
            when[3] = _oleDb.When() + Tables.yp_billnumdic.OPTYPE + _oleDb.EuqalTo() + "'004'" + _oleDb.Then() + "'药房退药'";
            when[4] = _oleDb.When() + Tables.yp_billnumdic.OPTYPE + _oleDb.EuqalTo() + "'005'" + _oleDb.Then() + "'药房科室领药出库业务类型'";
            when[5] = _oleDb.When() + Tables.yp_billnumdic.OPTYPE + _oleDb.EuqalTo() + "'006'" + _oleDb.Then() + "'药房盘点业务类型'";
            when[6] = _oleDb.When() + Tables.yp_billnumdic.OPTYPE + _oleDb.EuqalTo() + "'007'" + _oleDb.Then() + "'药房调价业务类型'";
            when[7] = _oleDb.When() + Tables.yp_billnumdic.OPTYPE + _oleDb.EuqalTo() + "'008'" + _oleDb.Then() + "'药房月结业务类型'";
            when[8] = _oleDb.When() + Tables.yp_billnumdic.OPTYPE + _oleDb.EuqalTo() + "'009'" + _oleDb.Then() + "'药房盘点审核业务类型'";
            when[9] = _oleDb.When() + Tables.yp_billnumdic.OPTYPE + _oleDb.EuqalTo() + "'010'" + _oleDb.Then() + "'药库入库类型'";
            when[10] = _oleDb.When() + Tables.yp_billnumdic.OPTYPE + _oleDb.EuqalTo() + "'011'" + _oleDb.Then() + "'药房申领单对应的药库出库业务'";
            when[11] = _oleDb.When() + Tables.yp_billnumdic.OPTYPE + _oleDb.EuqalTo() + "'012'" + _oleDb.Then() + "'药库盘点审核业务'";
            when[12] = _oleDb.When() + Tables.yp_billnumdic.OPTYPE + _oleDb.EuqalTo() + "'013'" + _oleDb.Then() + "'药库盘点业务'";
            when[13] = _oleDb.When() + Tables.yp_billnumdic.OPTYPE + _oleDb.EuqalTo() + "'014'" + _oleDb.Then() + "'药房期初入库业务'";
            when[14] = _oleDb.When() + Tables.yp_billnumdic.OPTYPE + _oleDb.EuqalTo() + "'015'" + _oleDb.Then() + "'药库月结业务'";
            when[15] = _oleDb.When() + Tables.yp_billnumdic.OPTYPE + _oleDb.EuqalTo() + "'016'" + _oleDb.Then() + "'药库调价业务'";
            when[16] = _oleDb.When() + Tables.yp_billnumdic.OPTYPE + _oleDb.EuqalTo() + "'017'" + _oleDb.Then() + "'药库科室领药出库业务类型'";
            when[17] = _oleDb.When() + Tables.yp_billnumdic.OPTYPE + _oleDb.EuqalTo() + "'018'" + _oleDb.Then() + "'药库报损出库业务类型'";
            when[18] = _oleDb.When() + Tables.yp_billnumdic.OPTYPE + _oleDb.EuqalTo() + "'019'" + _oleDb.Then() + "'药库期初入库业务类型'";
            string casewhen_1 = _oleDb.CASEWhen("TypeName", when);
            string strWhere_2 = Tables.yp_billnumdic.DEPTID + _oleDb.EuqalTo() + deptId;
            string strsql = _oleDb.Table(Tables.YP_BILLNUMDIC, "", strWhere_2,
                Tables.yp_billnumdic.OPTYPE,
                Tables.yp_billnumdic.BILLNUM,
                              casewhen_1);
            return _oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 获取单据号
        /// </summary>
        /// <param name="opType">业务类型</param>
        /// <param name="deptId">执行部门ID</param>
        /// <returns>单据号记录对象</returns>
        public HIS.Model.YP_BillNumDic YP_Bill_GetBillNum(string opType, long deptId)
        {
            string strWhere = Tables.yp_billnumdic.DEPTID + _oleDb.EuqalTo() + deptId + _oleDb.And() +
                Tables.yp_billnumdic.OPTYPE + _oleDb.EuqalTo() + "'" + opType + "'";
            string strSet = Tables.yp_billnumdic.BILLNUM + _oleDb.EuqalTo() + _oleDb.Add(Tables.yp_billnumdic.BILLNUM, "1");
            BindEntity<YP_BillNumDic>.CreateInstanceDAL(_oleDb).Update(strWhere, strSet);
            object ob = BindEntity<YP_BillNumDic>.CreateInstanceDAL(_oleDb, "YP_BillNumDic").GetModel(strWhere);
            return (YP_BillNumDic)ob;
        }
        #endregion  成员方法

        #region  药品参数
        /// <summary>
        /// 判断库房是否处于盘点状态
        /// </summary>
        /// <param name="deptId">部门ID</param>
        /// <returns>true：处于盘点状态；false：不处于盘点状态</returns>
        public bool Config_IsChecking(int deptId)
        {
            string strWhere = Tables.yp_config.NAME + _oleDb.EuqalTo() + "'ISCHECKING'" + _oleDb.And() +
                Tables.yp_config.VALUE + _oleDb.EuqalTo() + "'1'" + _oleDb.And() + Tables.yp_config.DEPTID + _oleDb.EuqalTo() + deptId;
            int cmdresult;
            object obj = BindEntity<YP_CONFIG>.CreateInstanceDAL(_oleDb).GetFieldValue(_oleDb.Count(Tables.yp_config.ID, ""), strWhere);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 开始盘点
        /// </summary>
        /// <param name="deptId">部门ID</param>
        public void Config_BeginChecking(int deptId)
        {
            string strWhere = Tables.yp_config.NAME + _oleDb.EuqalTo() + "'ISCHECKING'"
                + _oleDb.And() + Tables.yp_config.DEPTID + _oleDb.EuqalTo() + deptId;
            string strSet = Tables.yp_config.VALUE + _oleDb.EuqalTo() + "'1'";
            BindEntity<YP_CONFIG>.CreateInstanceDAL(_oleDb).Update(strWhere, strSet);
        }

        /// <summary>
        /// 结束盘点
        /// </summary>
        /// <param name="deptId">部门ID</param>
        public void Config_EndChecking(int deptId)
        {
            string strWhere = Tables.yp_config.NAME + _oleDb.EuqalTo() + "'ISCHECKING'"
                + _oleDb.And() + Tables.yp_config.DEPTID + _oleDb.EuqalTo() + deptId;
            string strSet = Tables.yp_config.VALUE + _oleDb.EuqalTo() + "'0'";
            BindEntity<YP_CONFIG>.CreateInstanceDAL(_oleDb).Update(strWhere, strSet);
        }
        #endregion  成员方法

        #region 药剂科室信息加载
        /// <summary>
        /// 获取可进行指定业务的所有药库部门信息列表
        /// </summary>
        /// <param name="opType">指定业务类型</param>
        /// <returns>药库部门信息列表</returns>
        public DataTable GetYK_Dept(string opType)
        {
            string strWhere_2 = "A." + Tables.yp_billnumdic.OPTYPE + _oleDb.EuqalTo() + "'" + opType.Trim() + "'";
            string str = _oleDb.TableNameBM(Tables.YP_BILLNUMDIC, "A") + _oleDb.LeftOuterJoin() +
                _oleDb.TableNameBM(Tables.BASE_DEPT_PROPERTY, "B") + _oleDb.ON("A." + Tables.yp_billnumdic.DEPTID,
                 "B." + Tables.base_dept_property.DEPT_ID);
            string strsql = _oleDb.Table(str, "", strWhere_2,
            _oleDb.FiledNameBM("0", "ROWNO"),
            "A." + Tables.yp_billnumdic.DEPTID,
            "B." + Tables.base_dept_property.NAME,
            "B." + Tables.base_dept_property.PY_CODE,
            "B." + Tables.base_dept_property.WB_CODE,
            _oleDb.FiledNameBM("''", " D_CODE"));

            return _oleDb.GetDataTable(strsql);
        }
        #endregion

        #region 药剂科室和药品类型对应
        /// <summary>
        /// 根据部门编号删除部门-药品类型关系表中的数据
        /// </summary>
        /// <param name="deptId">
        /// 部门Id
        /// </param>
        public void DeptType_DeleteByDept(int deptId)
        {
            string strWhere = Tables.yp_deptdic.DEPTID + _oleDb.EuqalTo() + deptId;
            BindEntity<YP_Dept_Yptype>.CreateInstanceDAL(_oleDb, Tables.YP_DEPTDIC).Delete(strWhere);
        }

        #endregion

        #region  药品剂型
        /// <summary>
        /// 加载药品剂型信息列表
        /// </summary>
        public DataTable Dose_GetList(string strWhere)
        {
            string strSql = _oleDb.Table(Tables.YP_DOSEDIC, "", strWhere.Trim() == "" ? "" : strWhere,
            _oleDb.FiledNameBM("0", "rowno"),
            _oleDb.FiledNameBM("''", "D_CODE"),
            Tables.yp_dosedic.DOSEDICID,
            Tables.yp_dosedic.TYPEDICID,
            Tables.yp_dosedic.DOSENAME,
            _oleDb.FiledNameBM(Tables.yp_dosedic.PYM, "PY_CODE"),
            _oleDb.FiledNameBM(Tables.yp_dosedic.WBM, "WB_CODE"));
            return _oleDb.GetDataTable(strSql);
        }
        #endregion  成员方法

        #region  药品厂家典

        /// <summary>
        /// 删除药品厂家典信息
        /// </summary>
        /// <param name="strWhere">删除条件</param>
        public void Maker_Delete(string strWhere)
        {
            if (strWhere == "")
            {
                return;
            }
            else
            {
                string strSet = Tables.yp_makerdic.DEL_FLAG + _oleDb.EuqalTo() + "1";
                BindEntity<YP_MakerDic>.CreateInstanceDAL(_oleDb).Update(strWhere, strSet);
            }
        }

        /// <summary>
        /// 加载药品厂家典信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable Maker_GetList(string strWhere)
        {
            string str = _oleDb.TableNameBM(Tables.YP_MAKERDIC, "A") + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_MEDICAREDIC, "B") +
                _oleDb.ON("A." + Tables.yp_makerdic.MEDICAREDICID, "B." + Tables.yp_medicaredic.MEDICAREDICID) + _oleDb.LeftOuterJoin() +
                _oleDb.TableNameBM(Tables.YP_PRODUCTDIC, "C") + _oleDb.ON("A." + Tables.yp_makerdic.PRODUCTID, "C." + Tables.yp_productdic.PRODUCTID);
            string strsql = _oleDb.Table(str, "", strWhere.Trim(), "A.*",
                "B." + Tables.yp_medicaredic.MEDICARENAME,
                "C." + Tables.yp_productdic.PRODUCTNAME);
            strsql += _oleDb.OrderBy() + "A." + Tables.yp_makerdic.MAKERDICID;
            return _oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 加载药库库存药品信息
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>药库库存药品信息</returns>
        public DataTable YK_GetDrugInfo(string strWhere)
        {
            string strSql = _oleDb.Table(Views.VI_DRUG_YK, "A", strWhere.Trim() == "" ? "" : strWhere,
             _oleDb.FiledNameBM("0", "ROWNO"),
             _oleDb.FiledNameBM("''", " D_CODE"),
             "A.*");
            return _oleDb.GetDataTable(strSql);

        }

        /// <summary>
        /// 加载药房库存药品信息
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="deptId">药房部门ＩＤ</param>
        /// <returns>药房库存药品信息</returns>
        public DataTable YF_GetDrugInfo(string strWhere, int deptId)
        {
            string strWhere_vi_drug_yf = "A." + Views.vi_drug_yf.DEPTID + _oleDb.EuqalTo() + deptId;
            string strsql = _oleDb.Table(Views.VI_DRUG_YF, "A", strWhere.Trim() == "" ? strWhere_vi_drug_yf : strWhere_vi_drug_yf + _oleDb.And() + strWhere,
            _oleDb.FiledNameBM("0", "ROWNO"),
            _oleDb.FiledNameBM("''", "D_CODE"),
             "A.*");
            return _oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 加载药典药品信息
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>药典药品信息</returns>
        public DataTable YD_GetDrugInfo(string strWhere)
        {
            string strSql = _oleDb.Table(Views.VI_DRUG_DIC, "A", strWhere.Trim() == "" ? "" : strWhere,
             _oleDb.FiledNameBM("0", "ROWNO"),
             _oleDb.FiledNameBM("''", "D_CODE"),
             "A.*");
            return _oleDb.GetDataTable(strSql);
        }

        #endregion  成员方法

        #region  药品医保类型
        /// <summary>
        /// 更新药品医保类型
        /// </summary>
        public void Medicare_Update(HIS.Model.YP_MedicareDic model)
        {
            string strWhere = Tables.yp_medicaredic.MEDICAREDICID + _oleDb.EuqalTo() + model.MedicareDicID;
            string[] strSet = new string[4];
            strSet[0] = Tables.yp_medicaredic.MEDICARENAME + _oleDb.EuqalTo() + model.MedicareName;
            strSet[1] = Tables.yp_medicaredic.PYM + _oleDb.EuqalTo() + model.PYM;
            strSet[2] = Tables.yp_medicaredic.WBM + _oleDb.EuqalTo() + model.WBM;
            strSet[3] = Tables.yp_medicaredic.MEDICAREREMARK + _oleDb.EuqalTo() + model.MedicareRemark;
            BindEntity<YP_MedicareDic>.CreateInstanceDAL(_oleDb).Update(strWhere, strSet);
        }

        /// <summary>
        /// 加载药品医保类型列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>药品医保类型列表</returns>
        public DataTable Medicare_GetList(string strWhere)
        {
            string strSql = _oleDb.Table(Tables.YP_MEDICAREDIC, "", strWhere.Trim() == "" ? "" : strWhere,
            _oleDb.FiledNameBM("0", "ROWNO"),
            _oleDb.FiledNameBM("''", "D_CODE"),
            Tables.yp_medicaredic.MEDICAREDICID,
            Tables.yp_medicaredic.MEDICARENAME,
            _oleDb.FiledNameBM(Tables.yp_medicaredic.PYM, "PY_CODE"),
            _oleDb.FiledNameBM(Tables.yp_medicaredic.WBM, "WB_CODE"),
            Tables.yp_medicaredic.MEDICAREREMARK);

            return _oleDb.GetDataTable(strSql);
        }
        #endregion  成员方法

        #region  生产厂家
        /// <summary>
        /// 删除生产厂家
        /// </summary>
        /// <param name="ProductID">生产厂家ID</param>
        public void Product_Delete(int ProductID)
        {
            string strWhere = Tables.yp_productdic.PRODUCTID + _oleDb.EuqalTo() + ProductID;
            string strSet = Tables.yp_productdic.DEL_FLAG + _oleDb.EuqalTo() + "1";
            BindEntity<YP_ProductDic>.CreateInstanceDAL(_oleDb).Update(strWhere, strSet);
        }

        /// <summary>
        /// 加载生产厂家信息列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>生产厂家信息列表</returns>
        public DataTable Product_GetList(string strWhere)
        {
            string strSql = _oleDb.Table(Tables.YP_PRODUCTDIC, "", strWhere.Trim() == "" ? "" : strWhere,
           _oleDb.FiledNameBM("0", " ROWNO"),
           _oleDb.FiledNameBM("''", "D_CODE"),
           Tables.yp_productdic.PRODUCTID,
           Tables.yp_productdic.ADDRESS,
           Tables.yp_productdic.PRODUCTNAME,
           _oleDb.FiledNameBM(Tables.yp_productdic.PYM, "PY_CODE"),
           _oleDb.FiledNameBM(Tables.yp_productdic.WMB, "WB_CODE"),
           Tables.yp_productdic.LINKNAME,
           Tables.yp_productdic.LINKPHONE,
           Tables.yp_productdic.DEL_FLAG);
            strSql += _oleDb.OrderBy() + Tables.yp_productdic.PRODUCTID;
            return _oleDb.GetDataTable(strSql);
        }
        #endregion

        #region  药品规格
        /// <summary>
        /// 删除药品规格
        /// </summary>
        /// <param name="SpecDicID">药品规格ＩＤ</param>
        public void Spec_Delete(int SpecDicID)
        {
            string strWhere = Tables.yp_specdic.SPECDICID + _oleDb.EuqalTo() + SpecDicID;
            string strSet = Tables.yp_specdic.DEL_FLAG + _oleDb.EuqalTo() + "1";
            BindEntity<YP_SpecDic>.CreateInstanceDAL(_oleDb).Update(strWhere, strSet);
        }

        /// <summary>
        /// 加载药品规格列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>药品规格列表</returns>
        public DataTable Spec_GetList(string strWhere)
        {
            string str = _oleDb.TableNameBM(Tables.YP_SPECDIC, "A") + _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_UNITDIC, "B") +
                  _oleDb.ON("A." + Tables.yp_specdic.DOSEUNIT, "B." + Tables.yp_unitdic.UNITDICID) +
                  _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_UNITDIC, "C") +
                  _oleDb.ON("A." + Tables.yp_specdic.UNIT, "C." + Tables.yp_unitdic.UNITDICID) +
                  _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_UNITDIC, "D") +
                   _oleDb.ON("A." + Tables.yp_specdic.PACKUNIT, "D." + Tables.yp_unitdic.UNITDICID) +
                  _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_DOSEDIC, "E") +
                  _oleDb.ON("A." + Tables.yp_specdic.DOSEDICID, "E." + Tables.yp_dosedic.DOSEDICID) +
                  _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_TYPEDIC, "F") +
                  _oleDb.ON("A." + Tables.yp_specdic.TYPEDICID, "F." + Tables.yp_typedic.TYPEDICID) +
                  _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_BYNAMEDIC, "G") +
                  _oleDb.ON("A." + Tables.yp_specdic.SPECDICID, "G." + Tables.yp_bynamedic.SPECDICID);

            string strsql = _oleDb.Table(str, "", strWhere.Trim() == "" ? "A." + Tables.yp_specdic.DEL_FLAG + _oleDb.EuqalTo() + "0" : strWhere + _oleDb.And() + "A." + Tables.yp_specdic.DEL_FLAG + _oleDb.EuqalTo() + "0",
            "distinct A.*",
            _oleDb.FiledNameBM("B." + Tables.yp_unitdic.UNITNAME, "DoseUnitName"),
            _oleDb.FiledNameBM("C." + Tables.yp_unitdic.UNITNAME, "UnitName"),
            _oleDb.FiledNameBM("D." + Tables.yp_unitdic.UNITNAME, "PackUnitName"),
            _oleDb.FiledNameBM("E." + Tables.yp_dosedic.DOSENAME, "DoseName"),
             "F." + Tables.yp_typedic.TYPENAME);
            strsql += _oleDb.OrderBy() + "A." + Tables.yp_specdic.CHEMNAME;
            return _oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 加载本院使用的药品规格列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>药品规格列表</returns>
        public DataTable UseSpec_GetList(string strWhere)
        {
            string str = _oleDb.TableNameBM(Tables.YP_MAKERDIC, "H") +
                  _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_SPECDIC, "A") +
                  _oleDb.ON("H." + Tables.yp_makerdic.SPECDICID, "A." + Tables.yp_specdic.SPECDICID) +
                  _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_UNITDIC, "B") +
                  _oleDb.ON("A." + Tables.yp_specdic.DOSEUNIT, "B." + Tables.yp_unitdic.UNITDICID) +
                  _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_UNITDIC, "C") +
                  _oleDb.ON("A." + Tables.yp_specdic.UNIT, "C." + Tables.yp_unitdic.UNITDICID) +
                  _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_UNITDIC, "D") +
                   _oleDb.ON("A." + Tables.yp_specdic.PACKUNIT, "D." + Tables.yp_unitdic.UNITDICID) +
                  _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_DOSEDIC, "E") +
                  _oleDb.ON("A." + Tables.yp_specdic.DOSEDICID, "E." + Tables.yp_dosedic.DOSEDICID) +
                  _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_TYPEDIC, "F") +
                  _oleDb.ON("A." + Tables.yp_specdic.TYPEDICID, "F." + Tables.yp_typedic.TYPEDICID) +
                  _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_BYNAMEDIC, "G") +
                  _oleDb.ON("A." + Tables.yp_specdic.SPECDICID, "G." + Tables.yp_bynamedic.SPECDICID);
            string strsql = _oleDb.Table(str, "", strWhere.Trim() == "" ? "A." + Tables.yp_specdic.DEL_FLAG + _oleDb.EuqalTo() + "0" : strWhere + _oleDb.And() + "A." + Tables.yp_specdic.DEL_FLAG + _oleDb.EuqalTo() + "0",
            "distinct A.*",
            _oleDb.FiledNameBM("B." + Tables.yp_unitdic.UNITNAME, "DoseUnitName"),
            _oleDb.FiledNameBM("C." + Tables.yp_unitdic.UNITNAME, "UnitName"),
            _oleDb.FiledNameBM("D." + Tables.yp_unitdic.UNITNAME, "PackUnitName"),
            _oleDb.FiledNameBM("E." + Tables.yp_dosedic.DOSENAME, "DoseName"),
             "F." + Tables.yp_typedic.TYPENAME);
            strsql += _oleDb.OrderBy() + "A." + Tables.yp_specdic.SPECDICID;
            return _oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 加载本院使用的药品期初入库盘点单
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>药品规格列表</returns>
        public DataTable FirstIn_GetList(string strWhere)
        {
            string str = _oleDb.TableNameBM(Tables.YP_MAKERDIC, "H") +
                  _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_SPECDIC, "A") +
                  _oleDb.ON("H." + Tables.yp_makerdic.SPECDICID, "A." + Tables.yp_specdic.SPECDICID) +
                  _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_PRODUCTDIC, "I") +
                  _oleDb.ON("I." + Tables.yp_productdic.PRODUCTID, "H." + Tables.yp_makerdic.PRODUCTID) +
                  _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_UNITDIC, "B") +
                  _oleDb.ON("A." + Tables.yp_specdic.DOSEUNIT, "B." + Tables.yp_unitdic.UNITDICID) +
                  _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_UNITDIC, "C") +
                  _oleDb.ON("A." + Tables.yp_specdic.UNIT, "C." + Tables.yp_unitdic.UNITDICID) +
                  _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_UNITDIC, "D") +
                   _oleDb.ON("A." + Tables.yp_specdic.PACKUNIT, "D." + Tables.yp_unitdic.UNITDICID) +
                  _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_DOSEDIC, "E") +
                  _oleDb.ON("A." + Tables.yp_specdic.DOSEDICID, "E." + Tables.yp_dosedic.DOSEDICID) +
                  _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_TYPEDIC, "F") +
                  _oleDb.ON("A." + Tables.yp_specdic.TYPEDICID, "F." + Tables.yp_typedic.TYPEDICID) +
                  _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_MEDICAREDIC, "J") +
                  _oleDb.ON("H." + Tables.yp_makerdic.MEDICAREDICID, "J." + Tables.yp_medicaredic.MEDICAREDICID) +
                  _oleDb.LeftOuterJoin() + _oleDb.TableNameBM(Tables.YP_BYNAMEDIC, "G") +
                  _oleDb.ON("A." + Tables.yp_specdic.SPECDICID, "G." + Tables.yp_bynamedic.SPECDICID);
            string strsql = _oleDb.Table(str, "", strWhere.Trim() == "" ?
                "A." + Tables.yp_specdic.DEL_FLAG + _oleDb.EuqalTo() + "0" +
                _oleDb.And() + "H." + Tables.yp_makerdic.DEL_FLAG + _oleDb.EuqalTo() + "0" :
                strWhere + _oleDb.And() + "A." + Tables.yp_specdic.DEL_FLAG + _oleDb.EuqalTo() + "0" +
                _oleDb.And() + "H." + Tables.yp_makerdic.DEL_FLAG + _oleDb.EuqalTo() + "0",
            "distinct A.*",
            _oleDb.FiledNameBM("J." + Tables.yp_medicaredic.MEDICARENAME, "MEDICARENAME"),
            _oleDb.FiledNameBM("H." + Tables.yp_makerdic.RETAILPRICE, "RETAILPRICE"),
            _oleDb.FiledNameBM("H." + Tables.yp_makerdic.DEL_FLAG, "DEL_FLAG"),
            _oleDb.FiledNameBM("H." + Tables.yp_makerdic.TRADEPRICE, "TRADEPRICE"),
            _oleDb.FiledNameBM("B." + Tables.yp_unitdic.UNITNAME, "DoseUnitName"),
            _oleDb.FiledNameBM("C." + Tables.yp_unitdic.UNITNAME, "UnitName"),
            _oleDb.FiledNameBM("D." + Tables.yp_unitdic.UNITNAME, "PackUnitName"),
            _oleDb.FiledNameBM("E." + Tables.yp_dosedic.DOSENAME, "DoseName"),
            _oleDb.FiledNameBM("I." + Tables.yp_productdic.PRODUCTNAME, "ProductName"),
             "F." + Tables.yp_typedic.TYPENAME);
            strsql += _oleDb.OrderBy() + "A." + Tables.yp_specdic.TYPEDICID + "," + Tables.yp_specdic.CHEMNAME;
            return _oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <returns></returns>
        public DataTable GetUseSpecExportData()
        {
            try
            {
                string workId = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select distinct * from");
                strSql.Append("(select");
                strSql.Append(" A.SPECDICID as 内部编码,A.CHEMNAME as 化学名,A.NAME as 商品名,A.SPEC as 药品规格,");
                strSql.Append("G.UNITNAME as 包装单位,");
                strSql.Append("A.PACKNUM as 包装数量,");
                strSql.Append("C.UNITNAME as 基本单位,");
                strSql.Append("A.DOSENUM as 含量系数,");
                strSql.Append("B.UNITNAME as 含量单位,");
                strSql.Append("F.TYPENAME as 药品类型,");
                strSql.Append("E.DOSENAME as 药品剂型,");
                strSql.Append("I.NAME as 药理分类");
                strSql.Append(" from  ( select * from yp_makerdic where workid=" + workId + ") as H");
                strSql.Append(" Left outer Join yp_specdic as A on H.SPECDICID = A.SPECDICID");
                strSql.Append(" Left outer Join yp_unitdic as B on A.DOSEUNIT = B.UNITDICID");
                strSql.Append(" Left outer Join yp_unitdic as C on A.UNIT = C.UNITDICID");
                strSql.Append(" Left outer Join yp_unitdic as G on A.PACKUNIT=G.UNITDICID");
                strSql.Append(" Left outer Join yp_unitdic as D on A.PACKUNIT = D.UNITDICID");
                strSql.Append(" Left outer Join yp_dosedic as E on A.DOSEDICID = E.DOSEDICID");
                strSql.Append(" Left outer Join yp_typedic as F on A.TYPEDICID = F.TYPEDICID");
                strSql.Append(" Left outer Join yp_pharmacology as I on A.PHARMACOLOGY=I.ID");
                strSql.Append(" Left outer Join yp_bynamedic as J on J.SPECDICID=A.SPECDICID");
                strSql.Append(" where A.DEL_FLAG = 0 and J.BYNAME is not null) as SPEC");
                return _oleDb.GetDataTable(strSql.ToString());
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        #endregion

        #region  药品供应商
        /// <summary>
        /// 加载药品供应商检索信息列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>药品供应商列表</returns>
        public DataTable Support_GetList(string strWhere)
        {
            string strSql = _oleDb.Table(Tables.YP_SUPPORTDIC, "", strWhere.Trim() == "" ? "" : strWhere,
            _oleDb.FiledNameBM("0", "ROWNO"),
            _oleDb.FiledNameBM("''", "D_CODE"),
            Tables.yp_supportdic.SUPPORTDICID,
            Tables.yp_supportdic.NAME,
            _oleDb.FiledNameBM(Tables.yp_supportdic.PYM, "PY_CODE"),
            _oleDb.FiledNameBM(Tables.yp_supportdic.WBM, "WB_CODE"),
            Tables.yp_supportdic.LINKMAN,
            Tables.yp_supportdic.PHONE,
            Tables.yp_supportdic.ADDRESS,
            Tables.yp_supportdic.DEL_FLAG);
            return _oleDb.GetDataTable(strSql);
        }
        #endregion

        #region  药品类型
        /// <summary>
        /// 获取药品类型检索列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>药品类型列表</returns>
        public DataTable YPType_GetList(string strWhere)
        {
            string strSql = _oleDb.Table(Tables.YP_TYPEDIC, "", strWhere.Trim() == "" ? "" : strWhere,
            _oleDb.FiledNameBM("0", "ROWNO"),
            _oleDb.FiledNameBM("''", "D_CODE"),
            Tables.yp_typedic.TYPEDICID,
            Tables.yp_typedic.TYPENAME,
            _oleDb.FiledNameBM(Tables.yp_typedic.PYM, " PY_CODE"),
            _oleDb.FiledNameBM(Tables.yp_typedic.WBM, "WB_CODE"));
            return _oleDb.GetDataTable(strSql);
        }
        #endregion

        #region  药品单位
        /// <summary>
        /// 获取指定药品的基本单位
        /// </summary>
        /// <param name="MakerDicID">药品部门ID</param>
        /// <returns>基本单位ID</returns>
        public int Unit_GetSmallUnit(int MakerDicID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Unit from YP_SpecDic A");
            strSql.Append(" LEFT OUTER JOIN YP_MakerDic B ON A.SpecDicID=B.SpecDicID");
            strSql.Append(" WHERE B.MakerDicID=" + MakerDicID + "");
            object obj = _oleDb.GetDataResult(strSql.ToString());
            if (obj != null && obj != DBNull.Value)
            {
                return int.Parse(obj.ToString());
            }
            return -1;
        }

        /// <summary>
        /// 获取药品单位检索列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>药品单位检索列表</returns>
        public DataTable Unit_GetList(string strWhere)
        {
            string strSql = _oleDb.Table(Tables.YP_UNITDIC, "", strWhere.Trim() == "" ? "" : strWhere,
            _oleDb.FiledNameBM("0", "rowno"),
            _oleDb.FiledNameBM("''", "D_CODE"),
            Tables.yp_unitdic.UNITDICID,
            Tables.yp_unitdic.UNITNAME,
            _oleDb.FiledNameBM(Tables.yp_unitdic.PYM, "PY_CODE"),
            _oleDb.FiledNameBM(Tables.yp_unitdic.WBM, "WB_CODE"));
            return _oleDb.GetDataTable(strSql);
        }
        #endregion


        #region 供应商统计
        /// <summary>
        /// 供应商统计
        /// </summary>
        /// <param name="btime"></param>
        /// <param name="etiem"></param>
        /// <returns></returns>
        public DataTable GetSupportIOQuery(DateTime? btime, DateTime? etime) //update by heyan 
        {
            string strsql = @"   select  '' as 编码,name as 名称,sum(stockfee) as 入库进价,sum(tradefee) as 入库批发,sum(retailfee) as 入库零售,
                        sum(outstockfee) as 退货进价,sum(outtradefee) as 退货批发,sum(outretailfee) as  退货零售
                      from
                    ( select b.regtime,a.name,c.stockfee,c.tradefee,c.retailfee,0 as outstockfee,0 as outtradefee,0 as outretailfee  
                         from yp_supportdic  a  
                          left outer join yk_inmaster  b on a.supportdicid=b.supportdicid
                            left outer join yk_inorder c on b.masterinstorageid=c.masterinstorageid 
	                         where ( b.optype='010' or b.optype='019') and  b.del_flag=0 and c.audit_flag=1 
                          
                        union all
                      select b.regtime,a.name, 0 as stockfee,0 as tradefee, 0 as retailfee,c.stockfee as outstockfee,c.tradefee as outtradefee,c.retailfee as outretailfee  
	                     from  yp_supportdic  a  
	                        left outer join yk_inmaster  b on a.supportdicid=b.supportdicid
                             left outer join yk_inorder c on b.masterinstorageid=c.masterinstorageid 
                                 where  b.optype='024' and  b.del_flag=0  and c.audit_flag=1
                    )A where A.regtime between '" + @btime + "' and '" + @etime + "' group by name";

            DataTable dt = _oleDb.GetDataTable(strsql);
            DataColumn column;
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "实际进价";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "实际零售";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "进销差额";
            dt.Columns.Add(column);
            decimal[] sum = new decimal[11];
            DataRow dr = dt.NewRow();
            for (int i = 0; i < sum.Length; i++)
            {
                sum[i] = 0;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["退货进价"] = Convert.ToDecimal(HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(dt.Rows[i]["退货进价"], "0")).ToString("0.00");
                dt.Rows[i]["退货零售"] = Convert.ToDecimal(HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(dt.Rows[i]["退货零售"], "0")).ToString("0.00");
                dt.Rows[i]["实际进价"] = Convert.ToDecimal(HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(dt.Rows[i]["实际进价"], "0")).ToString("0.00");
                dt.Rows[i]["实际进价"] = (Convert.ToDecimal(dt.Rows[i]["入库进价"]) - Convert.ToDecimal(dt.Rows[i]["退货进价"])).ToString("0.00");
                dt.Rows[i]["实际零售"] = (Convert.ToDecimal(dt.Rows[i]["入库零售"]) - Convert.ToDecimal(dt.Rows[i]["退货零售"])).ToString("0.00"); ;
                dt.Rows[i]["进销差额"] = (Convert.ToDecimal(dt.Rows[i]["实际零售"]) - Convert.ToDecimal(dt.Rows[i]["实际进价"])).ToString("0.00");
                for (int j = 2; j < dt.Columns.Count; j++)
                {
                    sum[j] = sum[j] + Convert.ToDecimal(dt.Rows[i][j]);
                }
            }
            dr[1] = "合计";
            for (int i = 2; i < dt.Columns.Count; i++)
            {
                dr[i] = sum[i];
            }
            dt.Rows.Add(dr);
            return dt;
        }
        #endregion

    }
}
