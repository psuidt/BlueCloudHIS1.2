using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.BLL;

using HIS.SYSTEM.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZYNurse_BLL;

namespace HIS.ZYNurse_BLL
{
    public class OP_OrderPrint:BaseBLL
    {
        #region 变量声明
        DataTable dt;
        string str;
        #endregion

        #region 构造方法
        #endregion

        #region 获取某患者医嘱列表
        public DataTable GetOrderList(int patlistid, int ordertype)
        {
            if (dt != null)
            {
                dt.Clear();
            }
            str = "";
            //长嘱，只打印执行过一次以上的或者以转抄说明性医嘱或者执行完毕的医嘱
            if (ordertype == 0)
            {
                str = @"select a.PATID PatlistID,a.GROUP_ID GroupID,'' GroupLines, a.ORDER_BDATE BDateTime, a.ORDER_DOC BDocID, a.TRANS_NURSE BNurseID," +
                    " a.ORDER_CONTENT OrderContent, a.AMOUNT Amount, a.UNIT Unit, a.ORDER_USAGE OrderUsage, a.FREQUENCY OrderFrequency," +
                    " a.EORDER_DATE EDateTime, a.EORDER_DOC EDocID, a.EORDER_TSNURSE ENurseID,a.ITEM_TYPE ItemType" +
                    " from ZY_DOC_ORDERRECORD a where a.PATID=" + patlistid + " and a.ORDER_TYPE=0 and a.DELETE_FLAG=0 and (a.NOEXE_FLAG=1 or (a.ITEM_TYPE=7 and a.STATUS_FALG>=2) or STATUS_FALG=5)" +
                    " order by a.ORDER_BDATE";
            }
            else if (ordertype == 1)
            {
                str = @"select a.PATID PatlistID,a.GROUP_ID GroupID,'' GroupLines, a.ORDER_BDATE BDateTime, a.ORDER_DOC BDocID, a.TRANS_NURSE BNurseID," +
                    " a.ORDER_CONTENT OrderContent, a.AMOUNT Amount, a.UNIT Unit, a.ORDER_USAGE OrderUsage, a.FREQUENCY OrderFrequency," +
                    " a.EORDER_DATE EDateTime, a.EORDER_DOC EDocID, a.EORDER_TSNURSE ENurseID,a.ITEM_TYPE ItemType" +
                    " from ZY_DOC_ORDERRECORD a where a.PATID=" + patlistid + " and a.ORDER_TYPE in (1,5,7) and a.DELETE_FLAG=0 and a.STATUS_FALG=5" +
                    " order by a.ORDER_BDATE";
            }
            dt = oleDb.GetDataTable(str);
            dt.Columns.Add("BDate");
            dt.Columns.Add("BTime");
            dt.Columns.Add("BDoc");
            dt.Columns.Add("BNurse");
            dt.Columns.Add("EDate");
            dt.Columns.Add("ETime");
            dt.Columns.Add("EDoc");
            dt.Columns.Add("ENurse");
            dt.Columns.Add("OrderAmount");
            foreach (DataRow dr in dt.Rows)
            {
                dr["BDate"] = Convert.ToDateTime(dr["BDateTime"]).ToString("MM-dd");
                dr["BTime"] = Convert.ToDateTime(dr["BDateTime"]).ToString("HH:mm");
                dr["BDoc"] = BaseData.GetUserName(dr["BDocID"].ToString());
                dr["BNurse"] = BaseData.GetUserName(dr["BNurseID"].ToString());
                //如果停嘱时间为'0001-01-01 00:00:00.000000'则置为空
                if (Convert.ToDateTime(dr["EDateTime"]).ToString("yyyy-MM-dd") == "0001-01-01")
                {
                    dr["Edate"] = "";
                    dr["ETime"] = "";
                }
                else
                {
                    dr["Edate"] = Convert.ToDateTime(dr["EDateTime"]).ToString("MM-dd");
                    dr["ETime"] = Convert.ToDateTime(dr["EDateTime"]).ToString("HH:mm");
                }
                dr["EDoc"] = BaseData.GetUserName(dr["EDocID"].ToString());
                dr["ENurse"] = BaseData.GetUserName(dr["ENurseID"].ToString());
                if (dr["Amount"].ToString().TrimEnd('0').TrimEnd('.') == "0")
                    dr["OrderAmount"] = "";
                else
                    dr["OrderAmount"] = dr["Amount"].ToString().TrimEnd('0').TrimEnd('.') + dr["Unit"].ToString();
            }

            #region 添加医嘱组标记
            if (dt == null || dt.Rows.Count == 0)
                return null;
            int gid = Convert.ToInt32(dt.Rows[0]["GroupID"].ToString());
            long pid = Convert.ToInt64(dt.Rows[0]["PatlistID"].ToString());
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                //从第二组开始比较，如果与上一行同一组，则将本行设为组中，上一个不属于组的行设为组头，如果不相同，且上一行属于组，则设为组尾
                if (pid == Convert.ToInt64(dt.Rows[i]["PatlistID"].ToString()) && gid == Convert.ToInt32(dt.Rows[i]["GroupID"].ToString()))
                {
                    //如果上一行不属于组，也就是组的第一行时，设为组头
                    if (dt.Rows[i - 1]["GroupLines"].ToString() == "")
                        dt.Rows[i - 1]["GroupLines"] = "┓";
                    dt.Rows[i]["GroupLines"] = "┃";
                }
                else
                {
                    if (dt.Rows[i - 1]["GroupLines"].ToString() != "")
                        dt.Rows[i - 1]["GroupLines"] = "┛";
                    pid = Convert.ToInt64(dt.Rows[i]["PatlistID"].ToString());
                    gid = Convert.ToInt32(dt.Rows[i]["GroupID"].ToString());
                }
            }
            if (dt.Rows[dt.Rows.Count - 1]["GroupLines"].ToString() == "┃")
                dt.Rows[dt.Rows.Count - 1]["GroupLines"] = "┛";
            #endregion

            #region 处理医嘱内容
            //同一组只有第一行显示时间，用法，频率等
            gid = Convert.ToInt32(dt.Rows[0]["GroupID"].ToString());
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                if (gid == Convert.ToInt32(dt.Rows[i]["GroupID"].ToString()))
                {
                    dt.Rows[i]["BDate"] = "";
                    dt.Rows[i]["BTime"] = "";
                    dt.Rows[i]["BDoc"] = "";
                    dt.Rows[i]["BNurse"] = "";
                    dt.Rows[i]["OrderUsage"] = "";
                    dt.Rows[i]["OrderFrequency"] = "";
                    dt.Rows[i]["EDate"] = "";
                    dt.Rows[i]["ETime"] = "";
                    dt.Rows[i]["EDoc"] = "";
                    dt.Rows[i]["ENurse"] = "";
                }
                else
                {
                    gid = Convert.ToInt32(dt.Rows[i]["GroupID"].ToString());
                }
                //术后，产后，转科，出院，死亡医嘱都不显示OrderAmount
                if (dt.Rows[i]["OrderContent"].ToString() == "术后医嘱" || dt.Rows[i]["OrderContent"].ToString() == "产后医嘱" || dt.Rows[i]["ItemType"].ToString() == "10")
                {
                    dt.Rows[i]["OrderAmount"] = "";
                }
            }
            #endregion

            return dt;
        }
        #endregion

        #region 获取患者基本信息，包括姓名，性别，年龄，床号，住院号
        public void GetPatInfo(int patlistid, out string patname, out string sex, out string age, out string bedcode, out string cureno)
        {
            string str = @"select b.PATNAME PatName,b.PATSEX Sex,b.PATBRIDATE BirthDay,a.BEDCODE BedCode,a.CURENO CureNO" +
                    " from ZY_PATLIST a, PATIENTINFO b where a.PATID=b.PATID" +
                    " and a.PATLISTID=" + patlistid;
            DataRow dr = oleDb.GetDataRow(str);
            patname = dr["PatName"].ToString();
            sex = dr["Sex"].ToString();
            age = HIS.SYSTEM.PubicBaseClasses.Age.GetAgeString(Convert.ToDateTime(dr["BirthDay"].ToString()), HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime, 0);
            //处理年龄，当只显示岁或月或天
            if (age.IndexOf("岁") > 1)
                age = age.Substring(0, age.IndexOf("岁") + 1);
            else if (age.IndexOf("月") > 1)
                age = age.Substring(0, age.IndexOf("月") + 1);
            bedcode = dr["BedCode"].ToString() + "　床";
            cureno = dr["CureNO"].ToString();
        }
        #endregion
    }
}
