using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;

namespace HIS.ZY_BLL
{
    public class OP_ZYConfigSetting:BaseBLL
    {
        #region 删除
        private static bool CheckExist(string code)
        {
            string strWhere ="CODE ='" + code + "'";
            return BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_CONFIG").Exists(strWhere);
        }
        /// <summary>
        /// 保存参数
        /// </summary>
        /// <param name="code">代码</param>
        /// <param name="name">名称</param>
        /// <param name="text">内容</param>
        public static void SaveData(string code, string name, string text)
        {
            if (CheckExist(code))
            {
                string strWhere = "CODE ='" + code + "'";
                string[] fieldvalues = new string[3];
                fieldvalues[0] = "VALUE = 0";
                fieldvalues[1] = "NAME ='" + name + "'";
                fieldvalues[2] = "BZ ='" + text + "'";
                BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_CONFIG").Update(strWhere, fieldvalues);
            }
            else
            {
                string[] names=new string[]{"CODE","NAME","VALUE","BZ","DEPTID"};
                string[] values = new string[5];
                values[0] = code;
                values[1] = name;
                values[2] = "0";
                values[3] = text;
                values[4] = "0";
                bool[] b = new bool[] { true, true, false, true,false };
                BindEntity<object>.CreateInstanceDAL(oleDb,"ZY_CONFIG").Add(names, values, b);
            }
        }
        /// <summary>
        /// 根据代码删除配置参数
        /// </summary>
        /// <param name="code">代码</param>
        public static void DelData(string code)
        {
            string strWhere = "CODE='" + code + "'";
            BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_CONFIG").Delete(strWhere);
        }
        /// <summary>
        /// 组合字符串
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string JoinString(DataTable dt)
        {
            string str = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str += dt.Rows[i][0].ToString().Trim() + ":" + dt.Rows[i][1].ToString().Trim() + "|";
            }
            return str;
        }
        /// <summary>
        /// 得到数据
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static DataTable GetConfigData()
        {
            return BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_CONFIG").GetList("");
        }

        /// <summary>
        /// 根据值得到指定代码的说明
        /// </summary>
        /// <param name="Alldt"></param>
        /// <param name="code"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DataTable GetConfigText(DataTable Alldt, string code)
        {
            DataRow[] drs= Alldt.Select("code ='" + code + "'");
            string[] texts = drs[0]["BZ"].ToString().Split(new char[] { '|' });
            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn("value", typeof(int));
            DataColumn dc2 = new DataColumn("Text", typeof(string));
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            for (int i = 0; i < texts.Length; i++)
            {
                if (texts[i].Trim() != "")
                {
                    DataRow dr = dt.NewRow();
                    dr["value"] = Convert.ToInt32(texts[i].Split(new char[] { ':' })[0]);
                    dr["Text"] = texts[i].Split(new char[] { ':' })[1];
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        /// <summary>
        /// 保存当前配置
        /// </summary>
        /// <param name="Alldt"></param>
        public static void SaveConfig(DataTable Alldt)
        {
            string[] fieldvalue = new string[1];
            string strWhere = null;

            try
            {
                oleDb.BeginTransaction();
                for (int i = 0; i < Alldt.Rows.Count; i++)
                {
                    strWhere ="CODE ='" + Alldt.Rows[i]["code"].ToString() + "'";
                    fieldvalue[0] = "VALUE ="+ Alldt.Rows[i]["value"].ToString()+"";
                    BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_CONFIG").Update(strWhere, fieldvalue);
                }
                oleDb.CommitTransaction();
            }
            catch (Exception e)
            {
                oleDb.RollbackTransaction();
                throw new Exception(e.Message);
            }
        }

        #endregion

        /// <summary>
        /// 根据代码得到住院配置的值
        /// </summary>
        /// <param name="code">代码</param>
        /// <returns>值</returns>
        public static int GetConfigValue(string code)
        {
            return Convert.ToInt32(GetValue(code));
        }

        private static string GetValue(string code)
        {
            string strWhere = "CODE ='" + code + "'";

            return Convert.ToInt32(BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_CONFIG").GetFieldValue("VALUE", strWhere)).ToString();
        }

        public static string GetConfigText(string code, int value)
        {
            string strWhere = "CODE ='" + code + "'";
            string text = BindEntity<object>.CreateInstanceDAL(oleDb, "ZY_CONFIG").GetFieldValue("VALUE", strWhere).ToString();
            string[] strs = text.Split(new char[] { '|' });
            for (int i = 0; i < strs.Length; i++)
            {
                if (Convert.ToInt32(strs[i].Split(new char[] { ':' })[0].Trim()) == value)
                    return strs[i].Split(new char[] { ':' })[1];
            }
            return "";
        }
    }
}
