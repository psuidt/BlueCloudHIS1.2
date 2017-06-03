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
using System.Collections;

namespace HIS.ZYDoc_BLL.BaseInfo
{
    public class ShowCardBase : BaseBLL,IDisposable
    {
        public  static DataSet dataSet = new DataSet();
        public static DataTable itemdrugs;
        protected static DataTable dictionCopyLong;
        protected static DataTable dictionCopy;
        private static  Hashtable hsDisease;


        public DataSet ReloadInfo() //20100628.2.05
        {
            dataSet = new DataSet();
            return LoadBaseINFO();
        }
        #region 获得基础数据表信息
        /// <summary>
        /// 获得基础数据表的信息
        /// </summary>
        /// <returns></returns>
        public  DataSet LoadBaseINFO()
        {
            if (dataSet != null && dataSet.Tables.Count > 0) //20100628.2.05
            {
                return dataSet;
            }
            DataTable tb = null;
            tb =BaseLoads.LoadShowCard(1);
            tb.TableName = "ITEM_DICTIONARY";
            if (dataSet.Tables.Contains("ITEM_DICTIONARY"))
            {
                dataSet.Tables.Remove("ITEM_DICTIONARY");
            }
            dataSet.Tables.Add(tb);
            dictionCopy = dataSet.Tables["ITEM_DICTIONARY"].Clone();
            dictionCopy.Clear();

            itemdrugs = dataSet.Tables["ITEM_DICTIONARY"].Clone();
            itemdrugs.Clear();
            for (int i = 0; i < dataSet.Tables["ITEM_DICTIONARY"].Rows.Count; i++)
            {
                dictionCopy.Rows.Add(dataSet.Tables["ITEM_DICTIONARY"].Rows[i].ItemArray);
                itemdrugs.Rows.Add(dataSet.Tables["ITEM_DICTIONARY"].Rows[i].ItemArray);
            }


            tb = BaseLoads.LoadShowCardlong(); //长期医嘱新开选项卡
            tb.TableName = "ITEM_DICTIONARYLONG";
            if (dataSet.Tables.Contains("ITEM_DICTIONARYLONG"))
            {
                dataSet.Tables.Remove("ITEM_DICTIONARYLONG");
            }
            dataSet.Tables.Add(tb);

            dictionCopyLong = dataSet.Tables["ITEM_DICTIONARYLONG"].Clone();
            dictionCopyLong.Clear();
            for (int i = 0; i < dataSet.Tables["ITEM_DICTIONARYLONG"].Rows.Count; i++)
            {
                dictionCopyLong.Rows.Add(dataSet.Tables["ITEM_DICTIONARYLONG"].Rows[i].ItemArray);
            }

            tb = BaseLoads.LoadFrequency();
            tb.TableName = "Frequency";
            if (dataSet.Tables.Contains("Frequency"))
            {
                dataSet.Tables.Remove("Frequency");
            }
            dataSet.Tables.Add(tb);

            tb = BaseLoads.LoadUsage();
            tb.TableName = "Usage";
            if (dataSet.Tables.Contains("Usage"))
            {
                dataSet.Tables.Remove("Usage");
            }
            dataSet.Tables.Add(tb);

            tb =BaseLoads.LoadEntrust();
            tb.TableName = "Entrust";
            if (dataSet.Tables.Contains("Entrust"))
            {
                dataSet.Tables.Remove("Entrust");
            }
            dataSet.Tables.Add(tb);

            tb = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserData(HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.EmpType.医生);
            tb.TableName = "User";
            if (dataSet.Tables.Contains("User"))
            {
                dataSet.Tables.Remove("User");
            }
            dataSet.Tables.Add(tb);

            tb = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptData(HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.DeptType.住院, HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.DeptType2.临床);
            tb.TableName = "Dept";
            if (dataSet.Tables.Contains("Dept"))
            {
                dataSet.Tables.Remove("Dept");
            }
            dataSet.Tables.Add(tb);

            tb = BaseLoads.dwlx(-1, -1);
            tb.TableName = "DwType";
            if (dataSet.Tables.Contains("DwType"))
            {
                dataSet.Tables.Remove("DwType");
            }
            dataSet.Tables.Add(tb);

            tb =BaseLoads.LoadUnitDic();
            tb.TableName = "UnitDic";
            if (dataSet.Tables.Contains("UnitDic"))
            {
                dataSet.Tables.Remove("UnitDic");
            }
            dataSet.Tables.Add(tb);

            return dataSet;
        }
        #endregion


        #region 得到药品数据
        /// <summary>
        /// 得到医嘱药品数据
        /// </summary>
        /// <param name="sign">0=加载西药和中成药数据1=加载中草药数据</param>
        /// <returns></returns>
        private   DataTable LoadDrugData( ItemType type)
        {
            try
            {
                DataTable show = dictionCopyLong.Clone();
                show.Clear();
                if (type==ItemType.西药)
                {
                    DataRow[] rows = dictionCopyLong.Select("order_type=1 or order_type=2");                   
                    foreach (DataRow dr in rows)
                    {
                        show.Rows.Add(dr.ItemArray);
                    }
                }
                if (type==ItemType.草药)
                {
                    DataRow[] rows = dictionCopy.Select("order_type=3");
                   
                    foreach (DataRow dr in rows)
                    {
                        show.Rows.Add(dr.ItemArray);
                    }
                }
                return show;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion

        /// <summary>
        /// 得到物资表
        /// </summary>
        /// <returns></returns>
        private DataTable LoadWz()
        {
            try
            {
                DataTable show = dictionCopy.Clone();
                show.Clear();
                DataRow[] rows = dictionCopy.Select("order_type=0");

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




        #region
        //#region 按输入的医嘱自动选择下一条医嘱的类别
        ///// <summary>
        ///// 按输入的医嘱自动选择下一条医嘱的类别
        ///// </summary>
        ///// <param name="sign">0＝加载西药和成药　1＝加载中草药　2＝加载项目、治疗，医技，手术　4＝长期医嘱新开　5＝加载项目，治疗，手术</param>
        ///// <returns></returns>
        //private  DataTable SelectItems(int sign,int orderkind)
        //{
        //    DataTable tb = null;
        //    if (sign == 0)
        //    {
        //        if (orderkind == 0)
        //        {
        //            tb = dictionCopyLong.Clone();
        //            tb.Clear();
        //            DataRow[] rows = dictionCopyLong.Select("order_type=1 or order_type=2");
        //            foreach (DataRow row in rows)
        //            {
        //                tb.Rows.Add(row.ItemArray);
        //            }
        //        }
        //        else
        //        {
        //            tb = LoadDrugData(ItemType.西药);//加载西药和成药   
        //        }             
        //    }
        //    if (sign == 1)
        //    {
        //        tb = LoadDrugData(ItemType.草药);//加载中草药
        //    }
        //    if (sign == 2)
        //    {
        //        tb = BaseLoads.LoadItemData(); //加载项目，治疗，医技，手术
        //    }
        //    if (sign == 4)//长期医嘱按新开 ...过滤掉中草药和医技项目
        //    {               
        //        tb = dictionCopyLong.Clone();
        //        tb.Clear();
        //        for (int i = 0; i <dictionCopyLong.Rows.Count; i++)
        //        {
        //            tb.Rows.Add(dictionCopyLong.Rows[i].ItemArray);
        //        }
        //    }
        //    if (sign == 5)
        //    {
        //        tb = BaseLoads.LoadItemDataLong();//加载项目，治疗，手术
        //    }
        //    return tb;
        //}
        //#endregion
        #endregion

        #region 按输入的医嘱自动选择下一条医嘱的类别
        /// <summary>
        /// 按输入的医嘱自动选择下一条医嘱的类别
        /// </summary>
        /// <param name="sign">0＝加载西药和成药　1＝加载中草药　2＝加载项目、治疗，医技，手术　4＝长期医嘱新开　5＝加载项目，治疗，手术</param>
        /// <returns></returns>
        private DataTable SelectItems(ItemType itemtype, OrderType ordertype)
        {
            DataTable tb = null;
            if (itemtype==ItemType.西药)
            {
                if (ordertype ==OrderType.长期医嘱)
                {
                    tb = dictionCopyLong.Clone();
                    tb.Clear();
                    DataRow[] rows = dictionCopyLong.Select("order_type=1 or order_type=2");
                    foreach (DataRow row in rows)
                    {
                        tb.Rows.Add(row.ItemArray);
                    }
                }
                else
                {
                    tb = LoadDrugData(ItemType.西药);//加载西药和成药   
                }
            }
            if (itemtype==ItemType.草药)
            {
                tb = LoadDrugData(ItemType.草药);//加载中草药
            }          
            if (itemtype==ItemType.所有项目)
            {
                tb = BaseLoads.LoadItemData(); //加载项目，治疗，医技，手术
            }
            if (itemtype==ItemType.长嘱新开)//长期医嘱按新开 ...过滤掉中草药和医技项目
            {
                tb = dictionCopyLong.Clone();
                tb.Clear();
                for (int i = 0; i < dictionCopyLong.Rows.Count; i++)
                {
                    tb.Rows.Add(dictionCopyLong.Rows[i].ItemArray);
                }
            }
            if (itemtype==ItemType.长嘱项目)
            {
                tb = BaseLoads.LoadItemDataLong();//加载项目，治疗，手术
            }
            if (itemtype == ItemType.物资)
            {
                tb = LoadWz();
            }
            return tb;
        }
        #endregion
        #region
        //#region 根据不同的类型加载选项卡数据
        ///// <summary>
        ///// 根据不同的类型加载选项卡数据
        ///// </summary>
        ///// <param name="sign">0＝加载西药和成药　1＝加载中草药　2＝加载项目（治疗，医技，手术） 3=临时医嘱新开　4＝长期医嘱新开　5＝加载项目（治疗，手术）</param>
        ///// <param name="orderkind"></param>
        //public  DataSet getData(int sign, int orderkind)
        //{
        //    DataTable tb = null;
        //    if (sign == 3)
        //    {
        //        //临时医嘱按新开              
        //        tb = dictionCopy.Clone();
        //        tb.Clear();
        //        if (dictionCopy == null || dictionCopy.Rows.Count == 0)
        //        {
        //            return dataSet;
        //        }
        //        for (int i = 0; i < dictionCopy.Rows.Count; i++)
        //        {
        //            tb.Rows.Add(dictionCopy.Rows[i].ItemArray);
        //        }
        //    }
        //    else
        //    {
        //        tb = SelectItems(sign,orderkind);
        //    }
        //    if (tb == null)
        //    {
        //        return dataSet;
        //    }
        //    else
        //    {
        //        if (orderkind == 0)
        //        {
        //            dataSet.Tables["ITEM_DICTIONARYLONG"].Clear();
        //            for (int i = 0; i < tb.Rows.Count; i++)
        //            {
        //                dataSet.Tables["ITEM_DICTIONARYLONG"].Rows.Add(tb.Rows[i].ItemArray);
        //            }
        //        }
        //        else
        //        {
        //            dataSet.Tables["ITEM_DICTIONARY"].Clear();
        //            for (int i = 0; i < tb.Rows.Count; i++)
        //            {
        //                dataSet.Tables["ITEM_DICTIONARY"].Rows.Add(tb.Rows[i].ItemArray);
        //            }
        //        }
        //    }
        //    return dataSet;
        //}
        //#endregion
        #endregion
        #region 根据不同的类型加载选项卡数据
        /// <summary>
        /// 根据不同的类型加载选项卡数据
        /// </summary>
        /// <param name="sign">0＝加载西药和成药　1＝加载中草药　2＝加载项目（治疗，医技，手术） 3=临时医嘱新开　4＝长期医嘱新开　5＝加载项目（治疗，手术）</param>
        /// <param name="orderkind"></param>
        public DataSet getData(ItemType itemtype, OrderType ordertype)
        {
            DataTable tb = null;
            if (itemtype==ItemType.临嘱新开)
            {
                //临时医嘱按新开              
                tb = dictionCopy.Clone();
                tb.Clear();
                if (dictionCopy == null || dictionCopy.Rows.Count == 0)
                {
                    return dataSet;
                }
                for (int i = 0; i < dictionCopy.Rows.Count; i++)
                {
                    tb.Rows.Add(dictionCopy.Rows[i].ItemArray);
                }
            }
            else
            {
                tb = SelectItems(itemtype, ordertype);
            }
            if (tb == null)
            {
                return dataSet;
            }
            else
            {
                if (ordertype==OrderType.长期医嘱)
                {
                    dataSet.Tables["ITEM_DICTIONARYLONG"].Clear();
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        dataSet.Tables["ITEM_DICTIONARYLONG"].Rows.Add(tb.Rows[i].ItemArray);
                    }
                }
                else
                {
                    dataSet.Tables["ITEM_DICTIONARY"].Clear();
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        dataSet.Tables["ITEM_DICTIONARY"].Rows.Add(tb.Rows[i].ItemArray);
                    }
                }
            }
            return dataSet;
        }
        #endregion

        #region   新增
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="orderkind"></param>
        /// <param name="sign">0=按新开按钮。1=按回车新开</param>
        /// <returns></returns>
        public  DataSet AddRows(int orderkind, int sign, int order_type)
        {
            if (orderkind == 0) //长期
            {
                if (sign == 0)
                {
                    getData(ItemType.长嘱新开, OrderType.长期医嘱); //长期医嘱按新开                   
                }
                if (sign == 1)
                {
                    if (order_type == 1 || order_type == 2) //西药和中成药
                    {
                        getData(ItemType.西药, OrderType.长期医嘱);
                    }
                    if (order_type == 4 || order_type >= 6) //项目
                    {
                        getData(ItemType.长嘱项目, OrderType.长期医嘱);
                    }
                }
            }
            else if (orderkind == 1)   //临时
            {
                if (sign == 0)
                {
                    getData(ItemType.临嘱新开, OrderType.临时医嘱); //临时医嘱按新开
                }
                if (sign == 1)
                {
                    if (order_type == 0)
                    {
                        getData(ItemType.物资, OrderType.临时医嘱);
                    }
                    if (order_type == 1 || order_type == 2)  //西药和中成药
                    {
                        getData(ItemType.西药, OrderType.临时医嘱);
                    }
                    if (order_type == 3) //中草药
                    {
                        getData(ItemType.草药, OrderType.临时医嘱);
                    }
                    if (order_type > 3) //项目
                    {
                        getData(ItemType.所有项目, OrderType.临时医嘱);
                    }
                }
            }
            return dataSet;
        }
        #endregion

        #region 药房选择
        /// <summary>
        /// 药房选择
        /// </summary>
        /// <param name="orderkind"></param>
        /// <param name="yfname"></param>
        /// <returns></returns>
        public  DataSet YfSelect(int orderkind, string yfIds)
        {
            if (orderkind == 0)
            {
                DataTable tb = BaseLoads.LoadShowCardlong();
                dataSet.Tables["ITEM_DICTIONARYLONG"].Clear();
                dictionCopyLong.Clear();
                //新增判断药房科室
                if (yfIds != "-1")
                {
                    DataRow[] dr = tb.Select("execdeptcode in ( "+yfIds+")");
                    DataRow[] drItem = tb.Select("order_type >3");
                    for (int i = 0; i < dr.Length; i++)
                    {
                        dataSet.Tables["ITEM_DICTIONARYLONG"].Rows.Add(dr[i].ItemArray);
                        dictionCopyLong.Rows.Add(dr[i].ItemArray);

                    }
                    for (int i = 0; i < drItem.Length; i++)
                    {
                        dataSet.Tables["ITEM_DICTIONARYLONG"].Rows.Add(drItem[i].ItemArray);
                        dictionCopyLong.Rows.Add(drItem[i].ItemArray);
                    }
                }
                else
                {
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        dataSet.Tables["ITEM_DICTIONARYLONG"].Rows.Add(tb.Rows[i].ItemArray);
                        dictionCopyLong.Rows.Add(tb.Rows[i].ItemArray);
                    }
                }
            }
            if (orderkind == 1)
            {
                DataTable tb = BaseLoads.ShowCard;
                dataSet.Tables["ITEM_DICTIONARY"].Clear();
                dictionCopy.Clear();
                if (yfIds != "-1")
                {
                    DataRow[] dr = tb.Select("execdeptcode in  (" + yfIds + ")");
                    DataRow[] drItem = tb.Select("order_type >3");
                    for (int i = 0; i < dr.Length; i++)
                    {
                        dataSet.Tables["ITEM_DICTIONARY"].Rows.Add(dr[i].ItemArray);
                        dictionCopy.Rows.Add(dr[i].ItemArray);
                    }
                    for (int i = 0; i < drItem.Length; i++)
                    {
                        dataSet.Tables["ITEM_DICTIONARY"].Rows.Add(drItem[i].ItemArray);
                        dictionCopy.Rows.Add(drItem[i].ItemArray);
                    }
                }
                else
                {
                    tb = BaseLoads.ShowCard;
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        dataSet.Tables["ITEM_DICTIONARY"].Rows.Add(tb.Rows[i].ItemArray);
                        dictionCopy.Rows.Add(tb.Rows[i].ItemArray);
                    }
                }
            }
            return dataSet;
            //if (orderkind == 0)
            //{
            //    DataTable tb = BaseLoads.LoadShowCardlong();
            //    dataSet.Tables["ITEM_DICTIONARYLONG"].Clear();
            //    dictionCopyLong.Clear();
            //    //新增判断药房科室
            //    if (yfname != "全部药房")
            //    {
            //        DataRow[] dr = tb.Select("execdeptname = '" + yfname + "'");
            //        DataRow[] drItem = tb.Select("order_type >3");                    
            //        for (int i = 0; i < dr.Length; i++)
            //        {
            //            dataSet.Tables["ITEM_DICTIONARYLONG"].Rows.Add(dr[i].ItemArray);
            //            dictionCopyLong.Rows.Add(dr[i].ItemArray);
                 
            //        }                   
            //        for (int i = 0; i < drItem.Length; i++)
            //        {
            //            dataSet.Tables["ITEM_DICTIONARYLONG"].Rows.Add(drItem[i].ItemArray);
            //            dictionCopyLong.Rows.Add(drItem[i].ItemArray);
            //        }                   
            //    }
            //    else
            //    {                  
            //        for (int i = 0; i < tb.Rows.Count; i++)
            //        {
            //            dataSet.Tables["ITEM_DICTIONARYLONG"].Rows.Add(tb.Rows[i].ItemArray);
            //            dictionCopyLong.Rows.Add(tb.Rows[i].ItemArray);
            //        }                     
            //    }
            //}
            //if (orderkind == 1)
            //{
            //    DataTable tb = BaseLoads.ShowCard;
            //    dataSet.Tables["ITEM_DICTIONARY"].Clear();
            //    dictionCopy.Clear();
            //    if (yfname != "全部药房")
            //    {
            //        DataRow[] dr = tb.Select("execdeptname = '" + yfname + "'");
            //        DataRow[] drItem = tb.Select("order_type >3");                   
            //        for (int i = 0; i < dr.Length; i++)
            //        {
            //            dataSet.Tables["ITEM_DICTIONARY"].Rows.Add(dr[i].ItemArray);
            //            dictionCopy.Rows.Add(dr[i].ItemArray);
            //        }
            //        for (int i = 0; i < drItem.Length; i++)
            //        {
            //            dataSet.Tables["ITEM_DICTIONARY"].Rows.Add(drItem[i].ItemArray);
            //            dictionCopy.Rows.Add(drItem[i].ItemArray);
            //        }                    
            //    }
            //    else
            //    {                 
            //        tb = BaseLoads.ShowCard;                  
            //        for (int i = 0; i < tb.Rows.Count; i++)
            //        {
            //            dataSet.Tables["ITEM_DICTIONARY"].Rows.Add(tb.Rows[i].ItemArray);
            //            dictionCopy.Rows.Add(tb.Rows[i].ItemArray);
            //        }                       
            //    }
            //}
            //return dataSet;
        }
        #endregion

        #region 根据ID获得药品单位信息
        /// <summary>
        /// 根据ID获得药品单位信息
        /// </summary>
        /// <param name="itemid"></param>
        /// <param name="itemtype"></param>
        /// <returns></returns>
        public  DataSet GetDwType(int itemid, int itemtype)
        {
            DataTable dt = BaseLoads.dwlx(itemid, itemtype);
            dataSet.Tables["DwType"].Clear();
            if (dt == null)
            {
                return dataSet;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataSet.Tables["DwType"].Rows.Add(dt.Rows[i].ItemArray);
            }
            return dataSet;
        }
        #endregion

        #region 获得疾病名称
        /// <summary>
        /// 疾病表
        /// </summary>
        /// <returns></returns>
        public  DataTable GetDisease()
        {
            //if (Disease == null)
            //{
            //    string strsql = "select * from { base_disease }";
            //    Disease = oleDb.GetDataTable(strsql);
            //}
            //return Disease;
            if (hsDisease == null || hsDisease.Count == 0) //20100624.2.06
            {
                hsDisease = new Hashtable();
            }
            if (hsDisease.ContainsKey("Disease"))
            {
                object objData = hsDisease["Disease"];
                return (DataTable)objData;
            }
            string path = System.Windows.Forms.Application.StartupPath + "\\Disease.xml";
            if (System.IO.File.Exists(path))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(path);
                DataTable dtt= ds.Tables[0].Copy();
                DataSet dss = new DataSet();
                dss.Tables.Add(dtt);
                dss.WriteXml(path);
                hsDisease.Add("Disease", dtt);
                return dtt;
            }
            else
            {
                DataTable dt = BindEntity<object>.CreateInstanceDAL(oleDb, Tables.BASE_DISEASE).GetList("");
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                ds.WriteXml(path);
                hsDisease.Add("Disease", dt);
                return dt;
                
            }
        }
        #endregion


        #region IDisposable 成员

        public void Dispose()
        {
            //throw new NotImplementedException();
            OP_Config.Reload(HIS.Base_BLL.Enums.ParameterCatalog.住院医生站);
        }

        #endregion
    }
}
