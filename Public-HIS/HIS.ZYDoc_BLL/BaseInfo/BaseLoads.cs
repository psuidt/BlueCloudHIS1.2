using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.SYSTEM.DatabaseAccessLayer;
using Entity=HIS.Model;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS.ZYDoc_BLL.BaseInfo
{
    partial class BaseLoads :BaseBLL
    {
        /// <summary>
        /// 加载药品数据
        /// </summary>
        /// <returns></returns>
        private static DataTable Frnquency = new DataTable();
        public  static DataTable ShowCard = new DataTable();      
        private static DataTable ShowCardModel = new DataTable();
        private static DataTable unit = new DataTable();

        #region  选项卡数据源(模板和开医嘱共用)

        #region 获得所有药品项目选项卡(临时)
        /// <summary>        
        ///加载选项卡数据(所有药品和项目)        
        /// </summary>
        /// <param name="sign">0模板数据源 1开医嘱数据源</param>
        /// <returns></returns>
        public static DataTable LoadShowCard(int sign)
        {           
            string strWhere = "";
            try
            {
                strWhere = Views.vi_clinical_all_items.ORDER_TYPE + oleDb.LessThanAndEqualTo() + 8;
                ShowCard = BindEntity<object>.CreateInstanceDAL(oleDb, Views.VI_CLINICAL_ALL_ITEMS).GetList(strWhere);
                return BindEntity<object>.CreateInstanceDAL(oleDb, Views.VI_CLINICAL_ALL_ITEMS).GetList(strWhere);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region 获得长期医嘱选项卡
        /// <summary>
        ///　长期医嘱选项卡数据源(过滤掉中草药和医技项目)
        /// </summary>
        /// <returns></returns>
        public static DataTable LoadShowCardlong()
        {
            try
            {
                DataTable show = ShowCard.Clone();
                string config = OP_Config.GetValue("005");
                DataRow[] rows = null;              
                if (config!=null && config.ToString() == "1") //长期医嘱中能开精神类药品
                {
                    rows = ShowCard.Select("order_type<>3 and order_type <> 0 and order_type<>5 and virulent_flag<>1 and narcotic_flag<>1 and costly_flag<>1");
                }
                else　//长期医嘱中不能开精神类药品
                {
                    rows = ShowCard.Select("order_type<>3 and order_type <> 0 and order_type<>5 and virulent_flag<>1 and narcotic_flag<>1 and costly_flag<>1 and lunacy_flag<>1");
                }
                show.Clear();
                foreach (DataRow dr in rows)
                {
                    show.Rows.Add(dr.ItemArray);
                }
                return show;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region 长期医嘱项目选项卡
        /// <summary>
        /// 加载医嘱项目数据(只有治疗项目和手术项目)
        /// </summary>
        /// <returns></returns>
        public static DataTable LoadItemDataLong()
        {
            try
            {
                DataTable show = ShowCard.Clone();
                DataRow[] rows = ShowCard.Select("order_type=4  or order_type=6 or order_type=7 ");
                show.Clear();
                foreach (DataRow dr in rows)
                {
                    show.Rows.Add(dr.ItemArray);
                }
                return show;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region 获得项目数据
        /// <summary>
        /// 加载医嘱所有项目数据
        /// </summary>
        /// <returns></returns>
        public static DataTable LoadItemData()
        {
            try
            {
                DataTable show = ShowCard.Clone();
                DataRow[] rows = ShowCard.Select("order_type>3");
                show.Clear();
                foreach (DataRow dr in rows)
                {
                    show.Rows.Add(dr.ItemArray);
                }
                return show;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        #endregion      

        #endregion

        #region 基础数据(模板和医嘱管理共用)

        #region  获得单位
        /// <summary>
        /// 加载药品单位数据
        /// </summary>
        /// <returns></returns>
        public static DataTable LoadUnitDic()
        {
            try
            {
                unit = BindEntity<HIS.Model.YP_UnitDic>.CreateInstanceDAL(oleDb, Tables.YP_UNITDIC).GetList("", Tables.yp_unitdic.UNITNAME, Tables.yp_unitdic.PYM, Tables.yp_unitdic.WBM);
                return unit;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region 获得频率表
        /// <summary>
        ///加载频次表
        /// </summary>
        /// <returns></returns>
        public static DataTable LoadFrequency()
        {
            string strWhere = Tables.base_frequency.DELETE_BIT + oleDb.EuqalTo() + 0;
            Frnquency = BindEntity<HIS.Model.Base_Frequency>.CreateInstanceDAL(oleDb).GetList(strWhere);
            return Frnquency;
        }
        #endregion

        #region 获得用法表
        /// <summary>
        ///加载用法表
        /// </summary>
        /// <returns></returns>
        public static DataTable LoadUsage()
        {
            string strWhere = Tables.base_usagediction.DELETE_BIT + oleDb.EuqalTo() + 0;
            return BindEntity<HIS.Model.Base_UsageDiction>.CreateInstanceDAL(oleDb).GetList(strWhere);
        }
        #endregion

        #region 获得嘱托表
        /// <summary>
        ///加载嘱托表
        /// </summary>
        /// <returns></returns>
        public static DataTable LoadEntrust()
        {
            string strWhere = Tables.base_entrust.DELETE_BIT + oleDb.EuqalTo() + 0;
            return BindEntity<HIS.Model.Base_Entrust>.CreateInstanceDAL(oleDb).GetList(strWhere);
        }
        #endregion

        #region 获得药品单位和单位类型
        /// <summary>
        /// 通过单位获取单位类型(0=含量单位 1=最小单位 2=包装单位)
        /// </summary>
        /// <param name="itemid"></param>
        /// <param name="order_type"></param>
        /// <param name="statitem_code"></param>
        /// <returns></returns>
        public static DataTable dwlx(int itemid, int order_type)
        {
            DataTable dw = ShowCard.Clone();
            DataRow[] rows = ShowCard.Select(" itemid=" + itemid + " and order_type=" + order_type + "");
            foreach (DataRow drr in rows)
            {
                dw.Rows.Add(drr.ItemArray);
            }

            DataTable tb = new DataTable();
            DataColumn column;
            DataRow dr;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "name";
            tb.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "dwlx";
            tb.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "PY_CODE";
            tb.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "WB_CODE";
            tb.Columns.Add(column);

            if (dw == null || dw.Rows.Count == 0)
            {
                return tb;
            } if (unit == null || unit.Rows.Count == 0)
            {
                LoadUnitDic();
            }
            DataTable unit1 = unit.Clone();
            for (int i = 0; i < 3; i++)
            {
                dr = tb.NewRow();
                if (i == 0)
                {
                    dr["name"] = dw.Rows[0]["doseunit"].ToString();
                }
                else if (i == 1)
                {
                    dr["name"] = dw.Rows[0]["leastunit"].ToString();
                }
                else
                {
                    dr["name"] = dw.Rows[0]["packunit"].ToString();
                }
                dr["dwlx"] = i.ToString();
                string s1 = "unitname LIKE '%" + dr["name"] + "%'";
                DataRow[] row = unit.Select(s1);
                if (row.Length <= 0)
                {
                    return null;
                }
                dr["py_code"] = row[0]["pym"].ToString();
                dr["wb_code"] = row[0]["wbm"].ToString();
                tb.Rows.Add(dr);
            }
            return tb;
        }
        #endregion

        #endregion

        #region  方法

        #region 获得套餐项目明细
        /// <summary>
        ///  由套餐ID获得医嘱项目
        /// </summary>
        /// <param name="tcid"></param>
        /// <returns></returns>
        public static DataTable TcgetOrderItem(int tcid)
        {
            string sql = " select a.*,b.num as num from ( select * from  base_complex_detail b where b.complex_id=" + tcid + " and workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID + ") b left join vi_clinical_order a on b.service_item_id=a.item_id and b.workid=a.workid";
            return oleDb.GetDataTable(sql);
        }
        #endregion

       // #region
       //private static decimal GetPresNums(int itemid, int itemtype, int dwlx, string frency, int amount, int pres)
       // {
       //     DataRow[] rows = ShowCard.Select("itemid=" + itemid + " and order_type=" + itemtype + "");
       //     if (rows == null || rows.Length == 0)
       //     {
       //         return 0;
       //     }
       //     //int execnums = GetExeTimes(frency);  //执行次数
       //     int packnum = Convert.ToInt32(rows[0]["packnum"].ToString());//包装系数
       //     int dosenum = Convert.ToInt32(rows[0]["dosenum"].ToString()); //含量系数
       //     int unpicknum = Convert.ToInt32(rows[0]["unpicknum"].ToString());//拆零系数
       //     int float_flag = Convert.ToInt32(rows[0]["float_flag"].ToString());//按什么取整 0包装取整。1按含量累计
       //     int unpick_flag = Convert.ToInt32(rows[0]["unpick_flag"].ToString());//拆零标志
       //     int presnums = 0;
       //     if (itemtype == 3)
       //     {
       //         //开的都是含量单位,不考虑执行次数
       //         presnums = (amount / dosenum + 1) * pres;
       //     }
       //     else
       //     {
       //         if (dwlx == 0) //含量单位
       //         {
       //             if (float_flag == 1) //累计取整
       //             {
       //                 presnums = (((amount * execnums) / dosenum) / packnum) * unpicknum;
       //             }
       //             else   //单次取整
       //             {

       //             }
       //         }
       //         else if (dwlx == 1) //最小单位
       //         {
       //             if (float_flag == 1)//累计取整
       //             {
       //                 presnums = amount * execnums;
       //             }
       //             else
       //             {

       //             }
       //         }
       //         else //包装单位
       //         {
       //             if (float_flag == 1)//累计取整
       //             {
       //                 presnums = amount * packnum * execnums;
       //             }
       //             else //单次取整
       //             {

       //             }
       //         }

       //     }
       //     return presnums;
       // }
       // #endregion
        #endregion

    }
}
