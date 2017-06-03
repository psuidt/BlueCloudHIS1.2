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
    public class OP_OrderExec:BaseBLL
    {
        string str;
        DataTable dt = new DataTable();//患者列表
        DataTable dtorder = new DataTable();//医嘱列表            
        /// <summary>
        /// 获取本科室在床患者列表
        /// </summary>
        /// <param name="cureno">住院号,如果住院号为空，则获取本科室所有患者列表，否则模糊匹配获取患者列表</param>
        /// <param name="deptid">科室ID</param>
        /// <returns>本科室患者列表数据表</returns>
        public DataTable listPatient(string cureno,int deptid)
        {
            try
            {
                dt.Clear();
                str = @"select 0 Selected,a.PATLISTID PatlistID,a.BEDCODE BedCode,a.CURENO CureNO,b.PATNAME PatName from ZY_PATLIST a " +
                    "left join PATIENTINFO b " +
                    "on a.PATID=b.PATID " +
                    "where a.CURRDEPTCODE='" + deptid.ToString() + "' ";
                if (cureno == "")//不按住院号查找时列出本科室在床或定义出院患者
                    str += @" and (a.PATTYPE='2' or a.PATTYPE='7') " +
                        " and a.BEDCODE <> ''";
                str += @" and a.CURENO like '%" + cureno + "%' " +
                    " and a.WORKID=" + HIS.SYSTEM.Core.EntityConfig.WorkID + " ";
                if (cureno == "")//不按住院号查找时才按床位排序，防止按住院号查找时床位号为空无法cast报错
                    str += @" order by cast(replace(a.BEDCODE, '加', '100') as int)";

                dt = oleDb.GetDataTable(str);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 获取选定患者的医嘱列表
        /// </summary>
        /// <param name="datatable">患者列表</param>
        /// <param name="str2">病人住院ID字段</param>
        /// <param name="str3">患者床号字段</param>
        /// <param name="str4">患者姓名字段</param>
        /// <param name="datetime">今天或明天</param>
        /// <param name="ordertype">医嘱类型，0为全部医嘱，1为长嘱，2为临嘱</param>
        /// <param name="usagetype">用法类型</param>
        /// <param name="isprint">是否已经打印，0全部，-1未打印，1已打印</param>
        /// <returns></returns>
        public DataTable listOrder(DataTable datatable,string str2,string str3,string str4,DateTime datetime,int ordertype,string usagetype,int isprint)
        {
            dtorder.Clear();
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                //TODO:用法的具体类型，即治疗卡，注射单等
                //已转抄，开始时间在今天（明天）之前，（结束时间为空，或结束时间在今天（明天）之后，状态为已转抄停嘱，末次大于0的长嘱）
                str = "select 0 Selected," +
                    "0 GroupFlag," +
                    "case when d.ID is null then 0 else 1 end Isprinted," +
                    Convert.ToInt64(datatable.Rows[i][str2].ToString()) + " PatlistID," +
                    "'" + datatable.Rows[i][str3].ToString() + "床' BedCode," +
                    "'" + datatable.Rows[i][str4].ToString() + "' PatName," +
                    "a.GROUP_ID GroupID," +
                    "date(a.ORDER_BDATE) StartDate,time(a.ORDER_BDATE) StartTime,a.ORDER_ID OrderID,'' OrderContents, ORDER_TYPE OrderType, " +
                    "a.ORDER_CONTENT OrderContent,a.AMOUNT Amount,a.UNIT Unit,a.ORDER_USAGE Usage,a.FREQUENCY Frequency,a.DROPSPEC DropSpec, " +
                    "case when date(a.EORDER_DATE)='0001-01-01' then null else date(a.EORDER_DATE) end EndDate, " +
                    "case when time(a.EORDER_DATE)='00:00:00' and date(a.EORDER_DATE)='0001-01-01' then null else time(a.EORDER_DATE) end EndTime, " +
                    "d.PRINT_DATE PrintDate " +
                    "from ZY_DOC_ORDERRECORD a " +
                    "left join BASE_USAGEDICTION b " +
                    "on a.ORDER_USAGE=b.NAME " +
                    "left join BASE_USAGE_USETYPE_ROLE c " +
                    "on b.ID=c.USAGE_ID ";
                str += "left join ZY_NURSE_PRINTZXD d on d.ORDER_ID=a.ORDER_ID ";
                str += "where a.DELETE_FLAG=0 and a.PATID=" + Convert.ToInt32(datatable.Rows[i][str2].ToString()) +
                    " and c.TYPE_NAME like '%" + usagetype + "%'" +
                    " and a.STATUS_FALG>1 and date(a.ORDER_BDATE)<='" + datetime.Date.ToShortDateString() + "' " +
                    " and (" +//长嘱未停或长嘱已停但末次大于0或打印日临嘱
                    " ((date(a.EORDER_DATE)='0001-01-01' or date(a.EORDER_DATE) is null) and a.ORDER_TYPE=0)" +//长嘱未停
                    " or (date(a.EORDER_DATE)>='" + datetime.Date.ToShortDateString() + "' and a.STATUS_FALG in (4,5) and a.ORDER_TYPE=0 and a.TEMINAL_TIMES>0)" +//长嘱已停但末次大于0
                    " or (a.ORDER_TYPE=1 and date(a.ORDER_BDATE)='" + datetime.Date.ToShortDateString() + "')" +//打印日临嘱
                    " )";

                switch (isprint)
                {
                    case 0:
                        {
                            break;
                        }
                    case 1:
                        {
                            str += " and date(d.PRINT_DATE) is not null " +
                                "and date(d.PRINT_DATE)>='" + datetime.Date.ToShortDateString() + "' ";
                            break;
                        }
                    case -1:
                        {
                            str += " and (d.PRINT_DATE is null or date(d.PRINT_DATE)<'" + datetime.Date.ToShortDateString() + "') ";
                            break;
                        }
                    default:
                        break;
                }

                switch (ordertype)
                {
                    case 1:
                        {
                            str += " and a.ORDER_TYPE=0 ";
                            break;
                        }
                    case 2:
                        {
                            str += " and a.ORDER_TYPE=1 ";
                            break;
                        }
                    default:
                        {
                            str += " and a.ORDER_TYPE in (0,1)";
                            break;
                        }
                }
                str += " order by a.order_type,a.patid,a.order_bdate,a.GROUP_ID,a.serial_id";//a.ORDER_ID";

                DataTable dttmp = oleDb.GetDataTable(str);
                if (dttmp != null)
                    if (dttmp.Rows.Count > 0)
                    {
                        if (dtorder == null || dtorder.Rows.Count <= 0)
                            dtorder = dttmp.Copy();
                        else
                        {
                            for (int j = 0; j < dttmp.Rows.Count; j++)
                            {
                                dtorder.Rows.Add(dttmp.Rows[j].ItemArray);
                            }
                        }
                    }
            }

            OrderPretreat();
            
            for (int j = 0; j < dtorder.Rows.Count; j++)
            {
                if (dtorder.Rows[j]["PrintDate"].ToString() == "")
                {

                    dtorder.Rows[j]["Isprinted"] = 0;
                }
                else
                {
                    DateTime date = Convert.ToDateTime(dtorder.Rows[j]["PrintDate"].ToString());
                    if (date.Date.CompareTo(datetime.Date) < 0)
                        dtorder.Rows[j]["Isprinted"] = 0;
                }
            }
            return dtorder;
        }
        /// <summary>
        /// 获取选定患者的医嘱列表
        /// </summary>
        /// <param name="datatable">患者列表</param>
        /// <param name="str2">病人住院ID字段</param>
        /// <param name="str3">患者床号字段</param>
        /// <param name="str4">患者姓名字段</param>
        /// <param name="datetime">今天或明天</param>
        /// <param name="ordertype">医嘱类型，0为全部医嘱，1为长嘱，2为临嘱</param>
        /// <param name="usagetype">用法类型</param>
        /// <param name="isprint">是否已经打印，0全部，-1未打印，1已打印</param>
        /// <returns></returns>
        public DataTable listOrder_print(DataTable datatable, string str2, string str3, string str4, DateTime datetime, int ordertype, string usagetype, int isprint)
        {
            dtorder.Clear();
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                //TODO:用法的具体类型，即治疗卡，注射单等
                //已转抄，开始时间在今天（明天）之前，（结束时间为空，或结束时间在今天（明天）之后，状态为已转抄停嘱，末次大于0的长嘱）
                str = "select 0 Selected," +
                    "0 GroupFlag," +
                    "case when d.ID is null then 0 else 1 end Isprinted," +
                    Convert.ToInt64(datatable.Rows[i][str2].ToString()) + " PatlistID," +
                    "'" + datatable.Rows[i][str3].ToString() + "床' BedCode," +
                    "'" + datatable.Rows[i][str4].ToString() + "' PatName," +
                    "a.GROUP_ID GroupID," +
                    "date(a.ORDER_BDATE) StartDate,time(a.ORDER_BDATE) StartTime,a.ORDER_ID OrderID,'' OrderContents, ORDER_TYPE OrderType, " +
                    "a.ORDER_CONTENT OrderContent,a.AMOUNT Amount,a.UNIT Unit,a.ORDER_USAGE Usage,a.FREQUENCY Frequency,a.DROPSPEC DropSpec, " +
                    "case when date(a.EORDER_DATE)='0001-01-01' then null else date(a.EORDER_DATE) end EndDate, " +
                    "case when time(a.EORDER_DATE)='00:00:00' and date(a.EORDER_DATE)='0001-01-01' then null else time(a.EORDER_DATE) end EndTime, " +
                    "d.PRINT_DATE PrintDate " +
                    "from ZY_DOC_ORDERRECORD a " +
                    "left join BASE_USAGEDICTION b " +
                    "on a.ORDER_USAGE=b.NAME " +
                    "left join BASE_USAGE_USETYPE_ROLE c " +
                    "on b.ID=c.USAGE_ID ";
                str += "left join ZY_NURSE_PRINTZXD d on d.ORDER_ID=a.ORDER_ID ";
                str += "where a.DELETE_FLAG=0 and a.PATID=" + Convert.ToInt32(datatable.Rows[i][str2].ToString()) +
                    " and c.TYPE_NAME like '%" + usagetype + "%'" +
                    " and a.STATUS_FALG>1 and date(a.ORDER_BDATE)<='" + datetime.Date.ToShortDateString() + "' " +
                    " and (" +//长嘱未停或长嘱已停但末次大于0或打印日临嘱
                    " ((date(a.EORDER_DATE)='0001-01-01' or date(a.EORDER_DATE) is null) and a.ORDER_TYPE=0)" +//长嘱未停
                    " or (date(a.EORDER_DATE)>='" + datetime.Date.ToShortDateString() + "' and a.STATUS_FALG in (4,5) and a.ORDER_TYPE=0 and a.TEMINAL_TIMES>0)" +//长嘱已停但末次大于0
                    " or (a.ORDER_TYPE=1 and date(a.ORDER_BDATE)='" + datetime.Date.ToShortDateString() + "')" +//打印日临嘱
                    " )";

                switch (isprint)
                {
                    case 0:
                        {
                            break;
                        }
                    case 1:
                        {
                            str += " and date(d.PRINT_DATE) is not null " +
                                "and date(d.PRINT_DATE)>='" + datetime.Date.ToShortDateString() + "' ";
                            break;
                        }
                    case -1:
                        {
                            str += " and (d.PRINT_DATE is null or date(d.PRINT_DATE)<'" + datetime.Date.ToShortDateString() + "') ";
                            break;
                        }
                    default:
                        break;
                }

                switch (ordertype)
                {
                    case 1:
                        {
                            str += " and a.ORDER_TYPE=0 ";
                            break;
                        }
                    case 2:
                        {
                            str += " and a.ORDER_TYPE=1 ";
                            break;
                        }
                    default:
                        {
                            str += " and a.ORDER_TYPE in (0,1)";
                            break;
                        }
                }
                str += "order by a.patid,a.order_type,a.order_bdate,a.GROUP_ID,a.serial_id";

                DataTable dttmp = oleDb.GetDataTable(str);
                if (dttmp != null)
                    if (dttmp.Rows.Count > 0)
                    {
                        if (dtorder == null || dtorder.Rows.Count <= 0)
                            dtorder = dttmp.Copy();
                        else
                        {
                            for (int j = 0; j < dttmp.Rows.Count; j++)
                            {
                                dtorder.Rows.Add(dttmp.Rows[j].ItemArray);
                            }
                        }
                    }
            }

            //OrderPretreat();

            for (int j = 0; j < dtorder.Rows.Count; j++)
            {
                if (dtorder.Rows[j]["PrintDate"].ToString() == "")
                {

                    dtorder.Rows[j]["Isprinted"] = 0;
                }
                else
                {
                    DateTime date = Convert.ToDateTime(dtorder.Rows[j]["PrintDate"].ToString());
                    if (date.Date.CompareTo(datetime.Date) < 0)
                        dtorder.Rows[j]["Isprinted"] = 0;
                }
            }
            return dtorder;
        }
        /// <summary>
        /// 处理医嘱列表
        /// </summary>
        private void OrderPretreat()
        {
            if (dtorder != null && dtorder.Rows.Count != 0)
            {
                int width = 0;
                #region 处理医嘱内容和时间
                //获取最长医嘱内容宽度
                foreach (DataRow dr in dtorder.Rows)
                {
                    if (System.Text.Encoding.Default.GetByteCount(dr["OrderContent"].ToString()) > width)
                        width = System.Text.Encoding.Default.GetByteCount(dr["OrderContent"].ToString());
                }
                width += 4;//baoxinkai改为4
                long pid = Convert.ToInt64(dtorder.Rows[0]["PatlistID"].ToString());
                int gid = Convert.ToInt32(dtorder.Rows[0]["GroupID"].ToString());
                foreach (DataRow dr in dtorder.Rows)
                {
                    //医嘱内容增加用量
                    int widthtmp = width - System.Text.Encoding.Default.GetByteCount(dr["OrderContent"].ToString().Trim());
                    dr["Unit"] = dr["Amount"].ToString().TrimEnd('0').TrimEnd('.') + dr["Unit"].ToString();
                    dr["OrderContents"] = dr["OrderContent"].ToString() + space(widthtmp) + dr["Unit"].ToString();


                    //与上一行的医嘱的PatlistID和GroupID进行对比，除第一行外，如果都相同，则不修改医嘱，否则修改医嘱内容
                    //与上一行的医嘱的PatlistID和GroupID进行对比，除第一行外，如果都相同，则显示开停医嘱时间，否则不显示开停医嘱时间
                    if (pid == Convert.ToInt64(dr["PatlistID"].ToString()) && gid == Convert.ToInt32(dr["GroupID"].ToString()))
                    {
                        //处理第一行
                        if (dr == dtorder.Rows[0])
                        {
                            dr["OrderContents"] = dr["OrderContents"].ToString() + space(6) + dr["Usage"].ToString().Trim();//医嘱内容增加用法
                            if (dr["DropSpec"].ToString().Trim() != "")//医嘱内容增加滴速
                            {
                                dr["Frequency"] = dr["Frequency"].ToString() + space(2) + "滴速：" + dr["DropSpec"].ToString().Trim();
                            }
                            dr["OrderContents"] = dr["OrderContents"].ToString() + space(2) + dr["Frequency"].ToString().Trim();//医嘱内容增加频率
                        }
                        else
                        {
                            dr["StartDate"] = dr["EndDate"] = Convert.ToDateTime(null);
                            dr["StartTime"] = dr["EndTime"] = DBNull.Value;
                            dr["BedCode"] = DBNull.Value;
                            //dr["PatName"] = DBNull.Value;
                            dr["Usage"] = DBNull.Value;
                            dr["Frequency"] = DBNull.Value;
                        }
                    }
                    else
                    {
                        dr["OrderContents"] = dr["OrderContents"].ToString() + space(6) + dr["Usage"].ToString().Trim();//医嘱内容增加用法
                        if (dr["DropSpec"].ToString().Trim() != "")//医嘱内容增加滴速
                        {
                            dr["OrderContents"] = dr["OrderContents"].ToString() + space(2) + "滴速：" + dr["DropSpec"].ToString().Trim();
                        }
                        dr["OrderContents"] = dr["OrderContents"].ToString() + space(2) + dr["Frequency"].ToString().Trim();//医嘱内容增加频率
                        pid = Convert.ToInt64(dr["PatlistID"].ToString());
                        gid = Convert.ToInt32(dr["GroupID"].ToString());
                    }
                }
                #endregion

                #region 添加医嘱组标记
                gid = Convert.ToInt32(dtorder.Rows[0]["GroupID"].ToString());
                pid = Convert.ToInt64(dtorder.Rows[0]["PatlistID"].ToString());
                for (int i = 1; i < dtorder.Rows.Count; i++)
                {
                    //从第二组开始比较，如果与上一行同一组，则将本行设为组中，上一个不属于组的行设为组头，如果不相同，且上一行属于组，则设为组尾
                    if (pid == Convert.ToInt64(dtorder.Rows[i]["PatlistID"].ToString()) && gid == Convert.ToInt64(dtorder.Rows[i]["GroupID"].ToString()))
                    {
                        //如果上一行不属于组，也就是组的第一行时，设为组头
                        if (dtorder.Rows[i - 1]["GroupFlag"].ToString() == "0")
                            dtorder.Rows[i - 1]["GroupFlag"] = 1;
                        dtorder.Rows[i]["GroupFlag"] = 2;
                    }
                    else
                    {
                        if (dtorder.Rows[i - 1]["GroupFlag"].ToString() != "0")
                            dtorder.Rows[i - 1]["GroupFlag"] = 3;
                        pid = Convert.ToInt64(dtorder.Rows[i]["PatlistID"].ToString());
                        gid = Convert.ToInt32(dtorder.Rows[i]["GroupID"].ToString());
                    }
                }
                if (dtorder.Rows[dtorder.Rows.Count - 1]["GroupFlag"].ToString() == "2")
                    dtorder.Rows[dtorder.Rows.Count - 1]["GroupFlag"] = 3;
                #endregion
            }
        }
       /// <summary>
        /// 生成n个空格
       /// </summary>
       /// <param name="n"></param>
       /// <returns></returns>
        public string space(int n)
        {
            string s="";
            for (int i = 0; i < n; i++)
                s += " ";
            return s;
        }
        /// <summary>
        /// 医嘱是否有打印记录
        /// </summary>
        /// <param name="OrderID">医嘱ID</param>
        /// <param name="ID">有打印记录时返回记录ID</param>
        /// <returns>有打印记录true，否则false</returns>
        public bool hasPrintHistory(int OrderID, out int ID)
        {
            ID = -1;
            str = "select * from ZY_NURSE_PRINTZXD where ORDER_ID=" + OrderID;
            dt = oleDb.GetDataTable(str);
            if (dt == null | dt.Rows.Count <= 0)
            {
                return false;
            }
            else
            {
                ID = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                return true;
            }
        }
        /// <summary>
        /// 更新医嘱打印单
        /// </summary>
        /// <param name="print_date">打印时间</param>
        /// <param name="print_user">打印者</param>
        /// <param name="zxdid">执行单ID</param>
        /// <returns>打印成功true，否则false</returns>
        public bool updatePrintZXD(DateTime print_date, int print_user, int zxdid)
        {
            str = "update ZY_NURSE_PRINTZXD set PRINT_DATE='" + print_date.ToString() + "',PRINT_USER=" + print_user + " where id=" + zxdid;
            if (oleDb.DoCommand(str) == 1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 向医嘱表插入新记录
        /// </summary>
        /// <param name="orderid">医嘱ID</param>
        /// <param name="zxd_date">执行单首次打印日期</param>
        /// <param name="print_date">执行单打印日期</param>
        /// <param name="print_user">打印者</param>
        /// <returns></returns>
        public bool insertIntoPrintZXD(int orderid, DateTime zxd_date, DateTime print_date, int print_user)
        {
            str = "insert into  ZY_NURSE_PRINTZXD(ORDER_ID,ZXD_DATE,PRINT_DATE,PRINT_USER) values (" +
                orderid + "," +
                "'" + zxd_date.ToString() + "'," +
                "'" + print_date.ToString() + "'," +
                print_user.ToString() + ")";
            if (oleDb.DoCommand(str) == 1)
                return true;
            else
                return false;
        }        
        /// <summary>
        /// 处理打印时同组医嘱内容的显示
        /// </summary>
        /// <param name="printtable">医嘱内容需要处理的datatable</param>
        /// <param name="i">0表示打印执行单，1表示打印瓶签</param>
        public void ContentInGroup(DataTable printtable, int x)
        {
            int groupid = Convert.ToInt32(printtable.Rows[0]["GroupID"].ToString());
            int patlistid = Convert.ToInt32(printtable.Rows[0]["PatlistID"].ToString());
            for (int i = 0; i < printtable.Rows.Count; i++)
            {
                //处理同一组医嘱内容
                if (groupid == Convert.ToInt32(printtable.Rows[i]["GroupID"].ToString()) && patlistid == Convert.ToInt32(printtable.Rows[i]["PatlistID"].ToString()))
                {
                    //屏蔽第一条医嘱处理
                    if (i != 0)
                    {
                        printtable.Rows[i - 1]["OrderContents"] += "\n" + printtable.Rows[i]["OrderContents"].ToString();
                        printtable.Rows[i].Delete();
                        i--;
                    }
                }
                else
                {
                    patlistid = Convert.ToInt32(printtable.Rows[i]["PatlistID"].ToString());
                    groupid = Convert.ToInt32(printtable.Rows[i]["GroupID"].ToString());
                }
            }
            if (x == 1)
            {
                for (int i = 0; i < printtable.Rows.Count; i++)
                {
                    int k = ExecNum(printtable.Rows[i]["Frequency"].ToString());
                    if (k > 1)
                    {
                        for (int j = 0; j < k - 1; j++)
                        {
                            DataRow newrow = printtable.NewRow();
                            newrow.ItemArray = printtable.Rows[i].ItemArray;
                            printtable.Rows.InsertAt(newrow, ++i);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 处理瓶签显示结果
        /// </summary>
        /// <param name="printtablepq">瓶签打印datatable</param>
        public void bqTreat(DataTable printtablepq)
        {
            for (int i = 0; i < printtablepq.Rows.Count; i++)
            {
                if (printtablepq.Rows[i]["OrderType"].ToString() == "0")
                    printtablepq.Rows[i]["OrderTypeZhCn"] = "长嘱";
                else
                    printtablepq.Rows[i]["OrderTypeZhCn"] = "临嘱";
                string strtmp = printtablepq.Rows[i]["OrderContents"].ToString();
                int k = IndexOfSecondSpc(strtmp);
                printtablepq.Rows[i]["OrderContents"] = strtmp.Substring(0, k);
            }
            ContentInGroup(printtablepq, 1);
        }     
        /// <summary>
        /// 查找字符串中的第二段空格的起始位置
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int IndexOfSecondSpc(string str)
        {
            int i;
            for (i = str.IndexOf(" ") + 1; i < str.Length; i++)
            {
                if (str[i] == ' ')
                    continue;
                else if (str[str.IndexOf(" ") + 1] != ' ')
                    str.Remove(str.IndexOf(" "), 1);
                else if (str.Substring(i).Contains(" "))
                {
                    i += str.Substring(i).IndexOf(" ");
                    break;
                }
            }
            return i;
        } 
        /// <summary>
        /// 获取频率次数
        /// </summary>
        /// <param name="Frequency"></param>
        /// <returns></returns>
        public int ExecNum(string Frequency)
        {
            string str = @"select EXECNUM from BASE_FREQUENCY where NAME ='" + Frequency + "' and WORKID=" + HIS.SYSTEM.Core.EntityConfig.WorkID;
            return Convert.ToInt32(oleDb.GetDataRow(str)["EXECNUM"].ToString());
        }
    }
}