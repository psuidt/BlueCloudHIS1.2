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

namespace HIS.ZYDoc_BLL.BaseInfo
{
    partial class CheckBase
    {
       
        #region 判断用法是否正确
        /// <summary>
        /// 判断用法是否正确
        /// </summary>
        /// <param name="usage"></param>
        /// <returns></returns>
        public  bool IsRightUsage(string usage)
        {
            for (int ii = 0; ii < ShowCardBase.dataSet.Tables["Usage"].Rows.Count; ii++)
            {
                if (ShowCardBase.dataSet.Tables["Usage"].Rows[ii]["name"].ToString().Trim() == usage)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region 医嘱频率判断
        /// <summary>
        /// 医嘱频率判断
        /// </summary>
        /// <param name="frequcy">频率名称</param>
        /// <returns></returns>
        public  bool IsRightFrequcy(string frequcy)
        {
            for (int ii = 0; ii < ShowCardBase.dataSet.Tables["Frequency"].Rows.Count; ii++)
            {
                if (ShowCardBase.dataSet.Tables["Frequency"].Rows[ii]["name"].ToString().Trim() == frequcy)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region  判断医嘱名称是否合法
        /// <summary>
        /// 判断医嘱名称是否合法
        /// </summary>
        /// <param name="itemname"></param>
        /// <param name="itemid"></param>
        /// <param name="itemtype"></param>
        /// <returns></returns>
        public  string IsRightName(string itemname, int itemid, int itemtype)
        {
            string itemname1 = itemname.Replace("'", "");
            DataRow[] dr = ShowCardBase.dataSet.Tables["ITEM_DICTIONARY"].Select("itemid=" + itemid + " and order_type=" + itemtype + "");
            if (dr.Length > 0)
            {
                string name2 = dr[0]["itemname"].ToString().Trim();
                return name2;
            }
            return itemname1;
        }
        #endregion    
    }
}
