using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.DatabaseAccessLayer;
using Entity = HIS.Model;
using HIS.SYSTEM.Core;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;


namespace HIS.ZYDoc_BLL.BaseInfo
{
    public  class DrugBase:BaseBLL,IDisposable
    {
        #region 获得药品库存量
        /// <summary>
        /// 获得药品库存量
        /// </summary>
        /// <param name="id"></param>
        /// <param name="itemtype"></param>
        /// <returns></returns>
        public  decimal GetStoreNum(int id, int itemtype)
        {
            if (ShowCardBase.itemdrugs != null && ShowCardBase.itemdrugs.Rows.Count > 0)
            {
                DataRow[] rows = ShowCardBase.itemdrugs.Select("itemid=" + id + " and order_type=" + itemtype + "");
                if (rows == null || rows.Length == 0)
                {
                    return -1;
                }
                return Convert.ToDecimal(XcConvert.IsNull(rows[0]["storenum"].ToString(), "0"));
            }
            else  //如果第一次itemdrugs还没有加载数据，则要从数据库中查找
            {
                string strsql = Views.vi_clinical_all_items.ITEMID + oleDb.EuqalTo() + id + oleDb.And() + Views.vi_clinical_all_items.ORDER_TYPE + oleDb.EuqalTo() + itemtype;
                DataTable dt = BindEntity<Views.vi_clinical_all_items>.CreateInstanceDAL(oleDb).GetList(strsql);
                if (dt == null || dt.Rows.Count == 0) //如果药品或项目在视图中找不到
                {
                    return -1;
                }
                return Convert.ToDecimal(HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(dt.Rows[0]["storenum"].ToString(), "0"));
            }
        }
        #endregion


        #region 获得药品库存量
        /// <summary>
        /// 获得药品库存量
        /// </summary>
        /// <param name="id"></param>
        /// <param name="itemtype"></param>
        /// <returns></returns>
        public decimal GetStoreNum(int id, int itemtype,int execdeptid)
        {
            if (ShowCardBase.itemdrugs != null && ShowCardBase.itemdrugs.Rows.Count > 0)
            {
                DataRow[] rows = ShowCardBase.itemdrugs.Select("itemid=" + id + " and order_type=" + itemtype + " and EXECDEPTCODE="+execdeptid+"");
                if (rows == null || rows.Length == 0)
                {
                    return -1;
                }
                return Convert.ToDecimal(XcConvert.IsNull(rows[0]["storenum"].ToString(), "0"));
            }
            else  //如果第一次itemdrugs还没有加载数据，则要从数据库中查找
            {
                string strsql = Views.vi_clinical_all_items.ITEMID + oleDb.EuqalTo() + id + oleDb.And() + Views.vi_clinical_all_items.ORDER_TYPE + oleDb.EuqalTo() + itemtype;
                DataTable dt = BindEntity<Views.vi_clinical_all_items>.CreateInstanceDAL(oleDb).GetList(strsql);
                if (dt == null || dt.Rows.Count == 0) //如果药品或项目在视图中找不到
                {
                    return -1;
                }
                return Convert.ToDecimal(HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(dt.Rows[0]["storenum"].ToString(), "0"));
            }
        }
        #endregion


        #region 获得药品的规格
        /// <summary>
        /// 获得药品的规格
        /// </summary>
        /// <param name="itemid"></param>
        /// <param name="itemtype"></param>
        /// <returns></returns>
        public  string GetSpec(int itemid, int itemtype)
        {
            DataRow[] rows =ShowCardBase.dataSet.Tables["ITEM_DICTIONARY"].Select("itemid=" + itemid + " and order_type=" + itemtype + "");
            return rows[0]["standard"].ToString();
        }
        #endregion

        #region  应用模板时获得的价格
        /// <summary>
        /// 应用模板时获得的价格
        /// </summary>
        /// <param name="itemid"></param>
        /// <param name="itemtype"></param>
        /// <returns></returns>
        public  decimal GetPrice(int itemid, int itemtype)
        {
            DataRow[] rows = ShowCardBase.dataSet.Tables["ITEM_DICTIONARY"].Select("itemid=" + itemid + " and order_type=" + itemtype + "");
            if (rows == null || rows.Length == 0)
            {
                return 0;
            }
            return Convert.ToDecimal(XcConvert.IsNull(rows[0]["sell_price"].ToString(), "0"));
        }
        #endregion

        public DataRow GetItemDrugInfo(int itemid, int itemtype)
        {
            if (ShowCardBase.dataSet == null)
            {
                return null;
            }

            DataRow[] rows = ShowCardBase.dataSet.Tables["ITEM_DICTIONARY"].Select("itemid=" + itemid + " and order_type=" + itemtype + "");
            if (rows != null && rows.Length > 0)
            {
                return rows[0];
            }
            return null;
        }

        #region 获得含量系数和包装系数
        /// <summary>
        /// 获得含量系数和包装系数
        /// </summary>
        /// <param name="itemid"></param>
        /// <param name="itemtype"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        public  decimal GetDosePackNum(int itemid, int itemtype, int sign)
        {
            DataRow[] rows = ShowCardBase.dataSet.Tables["ITEM_DICTIONARY"].Select("itemid=" + itemid + " and order_type=" + itemtype + "");
            if (sign == 0)
            {
                return Convert.ToDecimal(XcConvert.IsNull(rows[0]["dosenum"].ToString(), "1"));
            }
            else
            {
                return Convert.ToDecimal(XcConvert.IsNull(rows[0]["packnum"].ToString(), "1"));
            }
        }
        #endregion

        #region 获得所有药房名称
        /// <summary>
        /// 获得所有药房名称
        /// </summary>
        /// <returns></returns>
        public  DataTable GetYfName()
        {
            string strWhere = Tables.yp_deptdic.DEPTTYPE1 + oleDb.EuqalTo() + "'药房'";
            return BindEntity<HIS.Model.YP_DeptDic>.CreateInstanceDAL(oleDb).GetList(strWhere);
        }
        #endregion

        #region 获得科室开药的药房名称
        /// <summary>
        /// 获得科室开药的药房名称
        /// </summary>
        /// <param name="deptid"></param>
        /// <returns></returns>
        public  DataTable  Get_dept_yfName(int deptid)
        {          
            //string deptyf = OP_Config.GetValue("004");
            //if (deptyf != null)
            //{
            //    string[] yf = deptyf.Split(',');
            //    for (int i = 0; i < yf.Length; i++)
            //    {
            //        string[] dept = yf[i].Split('-');
            //        if (deptid.ToString() == dept[0].ToString())
            //        {
            //            //return HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(dept[1].ToString());
            //            return dept[1].ToString();  //20100523.0.04  药房参数设置默认药房没用.
            //        }
            //    }
            //}
            //return null;

            DataTable dt = new DataTable();
            dt.Columns.Add("Name", Type.GetType("System.String"));
            dt.Columns.Add("Value", Type.GetType("System.String"));
            try
            {
                string drugDeptIds = "";
                string[] drugDepts = OP_Config.GetValue("004").Split(',');
                foreach (string drugDept in drugDepts)
                {
                    string[] values = drugDept.Split('-');
                    drugDeptIds += (Convert.ToInt32(values[0]) == deptid ? (values[1] + ",") : "");
                }
                if (drugDeptIds.Trim() != "")
                {
                    drugDeptIds = drugDeptIds.Substring(0, drugDeptIds.Length - 1);
                    dt.Rows.Add("默认药房", drugDeptIds);
                }
            }
            catch
            {
            }

            dt.Rows.Add("全部药房", -1);

            DataTable yf = BindEntity<Model.YP_DeptDic>.CreateInstanceDAL(oleDb).GetList("DEPTTYPE1='药房'");
            if (yf != null)
            {
                foreach (DataRow row in yf.Rows)
                {
                    dt.Rows.Add(row["DeptName"].ToString().Trim(), row["DeptId"]);
                }
            }
            return dt;
        }
        #endregion

        #region 医得药品的明细信息
        /// <summary>
        /// 医得药品的明细信息
        /// </summary>
        /// <param name="rowid"></param>
        /// <param name="orderkind"></param>
        /// <returns></returns>
        public  DataRow GetDrugInfo(int itemid, int ordertype)
        {
            if (ShowCardBase.dataSet == null)
            {
                return null;
            }
            DataRow[] dr = ShowCardBase.itemdrugs.Select("itemid=" + itemid + " and order_type=" + ordertype + "");
            if (dr != null && dr.Length > 0)
            {
                return dr[0];
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 判断是否是皮试药品
        /// <summary>
        ///  判断是否是皮试药品　
        /// </summary>
        /// <param name="itemid"></param>
        /// <param name="itemtype"></param>
        /// <returns></returns>
        public  bool IsPsDrug(int itemid, int itemtype)
        {
            DataRow[] rows = ShowCardBase.itemdrugs.Select("itemid=" + itemid + " and order_type=" + itemtype + "");
            if (rows == null || rows.Length == 0)
            {
                return false;
            }
            if (rows[0]["skintest_flag"].ToString() == "1")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region 模板应用时是否被禁用
        /// <summary>
        /// 模板应用时药品和项目是否被禁用
        /// </summary>
        /// <param name="itemid"></param>
        /// <param name="itemtype"></param>
        /// <returns></returns>
        public  bool IsDel(int itemid, int itemtype)
        {
            DataRow[] rows = ShowCardBase.itemdrugs.Select("itemid=" + itemid + " and order_type=" + itemtype + "");
            if (rows == null || rows.Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 根据频率获得默认首次和末次
        /// <summary>
        /// 根据频率获得默认首次和末次
        /// </summary>
        /// <param name="frenquecy"></param>
        /// <param name="V_DATE"></param>
        /// <param name="v_sign">0 首次 1末次</param>
        /// <returns></returns>
        public  int getExecTimes(string frenquecy, DateTime V_DATE, int v_sign)
        {
            string FREQUENCY = "Qd";
            if (frenquecy != "")
            {
                FREQUENCY = frenquecy;
            }
            if (FREQUENCY == "持续" || FREQUENCY == "Q1h")
            {            
                if (v_sign == 0)
                {
                    int hour1 = V_DATE.Hour;
                    return 24 - hour1;
                }
            }           
            string v_exectime;
            int v_execnum = 1;
            DataRow[] dr = ShowCardBase.dataSet.Tables["Frequency"].Select("name='" + FREQUENCY + "'");
            v_execnum = Convert.ToInt32(XcConvert.IsNull(dr[0]["execnum"], "1"));          
            v_exectime = dr[0]["exectime"].ToString();
            if (v_exectime == null || v_exectime.Length == 0)
            {
                return v_execnum;
            }
            string[] Exectime = v_exectime.Split('/');
            if (Exectime.Length == 0)
            {
                return v_execnum;
            }
            string dtime = V_DATE.ToShortTimeString();
            decimal hourStr = Convert.ToDecimal(dtime.Replace(":", "."));
            int i;
            for (i = 0; i < Exectime.Length; i++)
            {
                if (Convert.ToDecimal(dtime.Replace(":", ".")) < Convert.ToDecimal(Exectime[i].Replace(":", ".")))
                {
                    break;
                }
            }
            if (v_sign == 0)
            {
                return v_execnum - i;
            }
            else
            {
                return i + 1;
            }
        }
        #endregion

        #region 找病人转抄状态的医嘱是否有库存不足的
        /// <summary>
        /// 找病人转抄状态的医嘱是否有库存不足的
        /// </summary>
        /// <param name="zypatlist"></param>
        /// <returns></returns>
        public string FindStorNums(List<HIS.Model.ZY_PatList> zypatlist)
        {
            if (zypatlist == null) return "";
            string beds = "";
            for (int i = 0; i < zypatlist.Count; i++)
            {
                DataTable dt = PubMethd.GetNotExesOrders(zypatlist[i].PatListID);
                if (dt == null || dt.Rows.Count == 0)
                {
                    continue;
                }
                else
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        if (GetStoreNum(Convert.ToInt32(dt.Rows[j]["makedicid"].ToString()), Convert.ToInt32(dt.Rows[j]["item_type"].ToString()) ,Convert.ToInt32(dt.Rows[j]["EXEC_DEPT"]))<= 0)
                        {
                            beds = beds + zypatlist[i].BedCode + " ";
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            return beds;
        }
        #endregion

        #region 药房是否可以开库存为0的药品
        /// <summary>
        /// 药房是否可以开库存为0的药品
        /// </summary>
        /// <returns></returns>
        public bool CanPresZero()
        {
            if (OP_Config.GetValue("001") == "0")
            {
                return true;
            }
            return false;
        }
        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
            OP_Config.Reload(HIS.Base_BLL.Enums.ParameterCatalog.住院医生站);
        }

        #endregion
    }
}
