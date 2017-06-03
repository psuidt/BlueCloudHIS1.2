using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

using HIS.SYSTEM.Core;
using HIS.SYSTEM.BussinessLogicLayer.Classes;

namespace HIS.ZYNurse_BLL
{
    public class OrderPrt:BaseBLL
    {
        #region 变量
        DataTable _orderlist = new DataTable();//医嘱列表
        int _firstpage = -1;//需要打印的第一页
        int _lastpage = -1;//需要打印的最后一页
        int _rowsperpage = 30;//每页行数

        DataTable OriginalOrderList = new DataTable();//存储未格式化的医嘱表
        #endregion

        #region 属性
        /// <summary>
        /// 获取医嘱列表
        /// </summary>
        public DataTable OrderList
        {
            get
            {
                if (_orderlist != null && _orderlist.Rows.Count > 0)
                {
                    OrderFormat();
                    return _orderlist;
                }
                return null;
            }
        }

        /// <summary>
        /// 获取需要打印的第一页
        /// </summary>
        public int FirstPage
        {
            get
            {
                return _firstpage;
            }
        }

        /// <summary>
        /// 获取需要打印的最后一页
        /// </summary>
        public int LastPage
        {
            get
            {
                return _lastpage;
            }
        }

        /// <summary>
        /// 获取医嘱打印每页行数
        /// </summary>
        public int RowsPerPage
        {
            get
            {
                return _rowsperpage;
            }
        }
        #endregion

        #region 构造方法
        /// <summary>
        /// 实例化医嘱打印类
        /// </summary>
        /// <param name="patlistid">患者住院ID</param>
        /// <param name="ordertype">医嘱类型0长嘱1临嘱</param>
        public OrderPrt(int patlistid, int ordertype)
        {
            int longorder_width = OP_Config.GetValue("003");
            if (longorder_width == -1)
                longorder_width = 16;
            int tmporder_width = OP_Config.GetValue("004");
            if (tmporder_width == -1)
                tmporder_width = 20;
            _rowsperpage = OP_Config.GetValue("005");
            if (_rowsperpage == -1)
                _rowsperpage = 30;
            string str = @"call SP_HS_ORDERPRT(" + patlistid + "," + longorder_width + "," + tmporder_width + "," + _rowsperpage + "," + HIS.SYSTEM.Core.EntityConfig.WorkID + ")";//SP_HS_ORDERPRT(V_PATLISTID,V_LORDERCONTENT_WIDTH,V_TORDERCONTENT_WIDTH,V_ROWS_PER_PAGE,WORKID)
            oleDb.DoCommand(str);

            if (ordertype == 0)
            {
                str = @"select PATLISTID, BABYID, PAGENO, ROWNO, PAGE_STATUS, ROW_STATUS, " +
                    " NEWLINE, GROUP_STATUS, PRT_STATUS, ORDER_ID, GROUP_ID, " +
                    " ORDER_BDATE as ORDER_BDATETIME, ITEM_TYPE, ORDER_CONTENT, AMOUNT, PRES_AMOUNT, " +
                    " UNIT, ORDER_SPEC, ORDER_USAGE, FREQUENCY, ORDER_DOC, " +
                    " TRANS_NURSE, CHECK_NURSE, ORDER_EDATE as ORDER_EDATETIME, ORDER_EDOC, " +
                    " ORDER_ETSNURSE, ORDER_ECHKNURSE, PRINTER, WORKID, MEMO " +
                    " from ZY_NURSE_LORDERPRT where PATLISTID=" + patlistid + " and WORKID=" + HIS.SYSTEM.Core.EntityConfig.WorkID + " order by pageno,rowno";
            }
            else
            {
                str = @"select PATLISTID, BABYID, PAGENO, ROWNO, PAGE_STATUS, ROW_STATUS, "+
                    " NEWLINE, GROUP_STATUS, PRT_STATUS, ORDER_ID, GROUP_ID, "+
                    " ORDER_BDATE as ORDER_BDATETIME, ITEM_TYPE, ORDER_CONTENT, AMOUNT, PRES_AMOUNT, "+
                    " UNIT, ORDER_SPEC, ORDER_USAGE, FREQUENCY, ORDER_DOC, "+
                    " TRANS_NURSE, CHECK_NURSE, EXEDATE, EXECUTOR, PRINTER, WORKID, MEMO "+
                    " from ZY_NURSE_TORDERPRT where PATLISTID=" + patlistid + " and WORKID=" + HIS.SYSTEM.Core.EntityConfig.WorkID + " order by pageno,rowno";
            }
            _orderlist = oleDb.GetDataTable(str);
            OriginalOrderList = _orderlist.Clone();

        }
        #endregion

        #region 方法
        #region 内容格式化
        /// <summary>
        /// 格式化医嘱列表
        /// </summary>
        void OrderFormat()
        {
            if (!_orderlist.Columns.Contains("ORDER_BTIME"))
            {
                _orderlist.Columns.Add("ORDER_BDATE");
                _orderlist.Columns.Add("ORDER_BTIME");
                _orderlist.Columns.Add("ORDER_EDATE");
                _orderlist.Columns.Add("ORDER_ETIME");
                _orderlist.Columns.Add("ORDER_DOCNAME");
                _orderlist.Columns.Add("TRANS_NURSENAME");
                _orderlist.Columns.Add("ORDER_EDOCNAME");
                _orderlist.Columns.Add("ORDER_ETSNURSENAME");
                _orderlist.Columns.Add("GROUP_LINES");
            }
            string empid;
            for (int i = 0; i < _orderlist.Rows.Count; i++)
            {
                //处理剂量
                if (_orderlist.Rows[i]["AMOUNT"].ToString().TrimEnd('0').TrimEnd('.') == "0" || _orderlist.Rows[i]["AMOUNT"].ToString().TrimEnd('0').TrimEnd('.') == "")
                    _orderlist.Rows[i]["AMOUNT"] = DBNull.Value;
                else
                    _orderlist.Rows[i]["AMOUNT"] = _orderlist.Rows[i]["AMOUNT"].ToString().TrimEnd('0').TrimEnd('.');

                //处理剂量和单位
                _orderlist.Rows[i]["UNIT"] = _orderlist.Rows[i]["AMOUNT"].ToString() + _orderlist.Rows[i]["UNIT"].ToString();

                //画组线
                if (_orderlist.Rows[i]["GROUP_STATUS"].ToString() == "1")
                    _orderlist.Rows[i]["GROUP_LINES"] = "┓";
                else if (_orderlist.Rows[i]["GROUP_STATUS"].ToString() == "3")
                    _orderlist.Rows[i]["GROUP_LINES"] = "┛";
                else if (_orderlist.Rows[i]["GROUP_STATUS"].ToString() == "2")
                    _orderlist.Rows[i]["GROUP_LINES"] = "┃";
                else
                    _orderlist.Rows[i]["GROUP_LINES"] = "";

                //同组医嘱只显示第一组的开嘱日期，开嘱时间，开嘱医生，转抄护士，用法，频次，停嘱日期，停嘱时间，停嘱医生，停嘱转抄护士
                //同条医嘱只显示第一行的开嘱日期，开嘱时间，开嘱医生，转抄护士，用法，频次，停嘱日期，停嘱时间，停嘱医生，停嘱转抄护士
                if (_orderlist.Rows[i]["GROUP_STATUS"].ToString() == "2" || _orderlist.Rows[i]["GROUP_STATUS"].ToString() == "3" || 
                    _orderlist.Rows[i]["NEWLINE"].ToString() == "1")
                {
                    _orderlist.Rows[i]["ORDER_BDATE"] = DBNull.Value;
                    _orderlist.Rows[i]["ORDER_BTIME"] = DBNull.Value;
                    _orderlist.Rows[i]["ORDER_DOCNAME"] = DBNull.Value;
                    _orderlist.Rows[i]["TRANS_NURSENAME"] = DBNull.Value;
                    _orderlist.Rows[i]["ORDER_USAGE"] = DBNull.Value;
                    _orderlist.Rows[i]["FREQUENCY"] = DBNull.Value;
                    if (_orderlist.Columns.Contains("ORDER_EDATE"))
                    {
                        _orderlist.Rows[i]["ORDER_EDATE"] = DBNull.Value;
                        _orderlist.Rows[i]["ORDER_ETIME"] = DBNull.Value;
                        _orderlist.Rows[i]["ORDER_EDOCNAME"] = DBNull.Value;
                        _orderlist.Rows[i]["ORDER_ETSNURSENAME"] = DBNull.Value;
                    }
                }
                else
                {
                    //处理开嘱日期时间
                    if (Convert.ToDateTime(_orderlist.Rows[i]["ORDER_BDATETIME"].ToString()).ToString("yyyy-MM-dd") == "0001-01-01")
                    {
                        _orderlist.Rows[i]["ORDER_BTIME"] = DBNull.Value;
                    }
                    else
                    {
                        _orderlist.Rows[i]["ORDER_BTIME"] = Convert.ToDateTime(_orderlist.Rows[i]["ORDER_BDATETIME"].ToString()).ToString("HH:mm");
                    }
                    _orderlist.Rows[i]["ORDER_BDATE"] = Convert.ToDateTime(_orderlist.Rows[i]["ORDER_BDATETIME"].ToString()).ToString("MM-dd");

                    //处理开嘱医生，转抄护士
                    empid = _orderlist.Rows[i]["ORDER_DOC"].ToString();
                    _orderlist.Rows[i]["ORDER_DOCNAME"] = BaseData.GetUserName(empid);
                    empid = _orderlist.Rows[i]["TRANS_NURSE"].ToString();
                    _orderlist.Rows[i]["TRANS_NURSENAME"] = BaseData.GetUserName(empid);

                    //处理停嘱
                    if (_orderlist.Columns.Contains("ORDER_ETSNURSE"))
                    {
                        //处理已转抄停嘱
                        if (_orderlist.Rows[i]["ORDER_ETSNURSE"].ToString() != "0")
                        {
                            //处理长嘱的停嘱日期时间
                            if (Convert.ToDateTime(_orderlist.Rows[i]["ORDER_EDATETIME"].ToString()).ToString("yyyy-MM-dd") == "0001-01-01")
                            {
                                _orderlist.Rows[i]["ORDER_ETIME"] = "";
                            }
                            else
                            {
                                _orderlist.Rows[i]["ORDER_ETIME"] = Convert.ToDateTime(_orderlist.Rows[i]["ORDER_EDATETIME"].ToString()).ToString("HH:mm");
                            }
                            _orderlist.Rows[i]["ORDER_EDATE"] = Convert.ToDateTime(_orderlist.Rows[i]["ORDER_EDATETIME"].ToString()).ToString("MM-dd");

                            //处理长嘱的停嘱医生和停嘱转抄护士
                            empid = _orderlist.Rows[i]["ORDER_EDOC"].ToString();
                            _orderlist.Rows[i]["ORDER_EDOCNAME"] = BaseData.GetUserName(empid);
                            empid = _orderlist.Rows[i]["ORDER_ETSNURSE"].ToString();
                            _orderlist.Rows[i]["ORDER_ETSNURSENAME"] = BaseData.GetUserName(empid);

                        }
                        //未转抄停嘱不打印停嘱日期，时间，医生，转抄护士
                        else
                        {
                            _orderlist.Rows[i]["ORDER_ETIME"] = DBNull.Value;
                            _orderlist.Rows[i]["ORDER_EDATE"] = DBNull.Value;
                            _orderlist.Rows[i]["ORDER_EDOCNAME"] = DBNull.Value;
                            _orderlist.Rows[i]["ORDER_ETSNURSENAME"] = DBNull.Value;
                        }
                    }
                }
                //处理临嘱的执行签名
                if (_orderlist.Columns.Contains("EXECUTOR"))
                {
                    _orderlist.Rows[i]["EXECUTOR"] = DBNull.Value;
                }
            }

            //处理医嘱的开嘱日期和时间，日期和时间相同的只显示第一行
            DateTime bdate = Convert.ToDateTime(_orderlist.Rows[0]["ORDER_BDATE"]);
            DateTime btime = Convert.ToDateTime(_orderlist.Rows[0]["ORDER_BTIME"]);
            for (int i = 1; i < _orderlist.Rows.Count; i++)
            {
                if (_orderlist.Rows[i]["ORDER_BDATE"] == DBNull.Value)
                    continue;
                if (Convert.ToDateTime(_orderlist.Rows[i]["ORDER_BDATE"]) == bdate)
                {
                    _orderlist.Rows[i]["ORDER_BDATE"] = DBNull.Value;
                    if (Convert.ToDateTime(_orderlist.Rows[i]["ORDER_BTIME"]) == btime)
                        _orderlist.Rows[i]["ORDER_BTIME"] = DBNull.Value;
                    else
                        btime = Convert.ToDateTime(_orderlist.Rows[i]["ORDER_BTIME"]);
                }
                else
                    bdate = Convert.ToDateTime(_orderlist.Rows[i]["ORDER_BDATE"]);
            }
        }
        #endregion

        #region 有医嘱需要打印
        /// <summary>
        /// 指定患者是否有指定类型的医嘱需要打印
        /// </summary>
        /// <param name="patlistid">患者住院ID</param>
        /// <param name="ordertype">医嘱类型0长嘱1临嘱</param>
        /// <returns>该病人有××医嘱需要打印</returns>
        public string NeedsPrint(int patlistid, int ordertype)
        {
            int i;
            //判断是否有长嘱需要打印
            if (ordertype == 0)
            {
                //只对长嘱的打印状态进行判断，即有停嘱时间列的是长嘱
                if (_orderlist.Columns.Contains("ORDER_EDATE"))
                {
                    for (i = 0; i < _orderlist.Rows.Count; i++)
                    {
                        //没有打印或需要打印停嘱的都是需要打印的医嘱
                        if (_orderlist.Rows[i]["PRT_STATUS"].ToString() == "0" || _orderlist.Rows[i]["PRT_STATUS"].ToString() == "2")
                        {
                            break;
                        }
                    }
                    if (i < _orderlist.Rows.Count)
                        return "该病人有长期医嘱需要打印";
                    else
                        return "";
                }
                else
                    return "";
            }
            else
            {
                //有执行时间的是临嘱
                if (_orderlist.Columns.Contains("EXEDATE"))
                {
                    for (i = 0; i < _orderlist.Rows.Count; i++)
                    {
                        //临嘱暂时没有需要打印停嘱的状态
                        if (_orderlist.Rows[i]["PRT_STATUS"].ToString() == "0")
                        {
                            break;
                        }
                    }
                    if (i < _orderlist.Rows.Count)
                        return "该病人有临时医嘱需要打印";
                    else
                        return "";
                }
                else
                    return "";
            }
            //return "";
        }
        #endregion

        #region 获取需要打印的长期医嘱列表
        /// <summary>
        /// 获取需要打印的长期医嘱列表
        /// </summary>
        /// <returns>需要打印的长期医嘱列表</returns>
        public DataTable GetLongOrderListToPrt()
        {
            DataTable dt = _orderlist.Clone();
            for (int i = 0; i < _orderlist.Rows.Count; i++)
            {
                if (_orderlist.Rows[i]["PRT_STATUS"].ToString() == "0" || _orderlist.Rows[i]["PRT_STATUS"].ToString() == "2")
                {
                    dt.Rows.Add(_orderlist.Rows[i].ItemArray);
                    if (_firstpage == -1)
                        _firstpage = Convert.ToInt32(_orderlist.Rows[i]["PAGENO"].ToString());
                    if (_lastpage < i)
                        _lastpage = Convert.ToInt32(_orderlist.Rows[i]["PAGENO"].ToString());
                }
            }
            return dt;
        }
        #endregion

        #region 获取需要打印的临时医嘱列表
        /// <summary>
        /// 获取需要打印的临时医嘱列表
        /// </summary>
        /// <returns>需要打印的临时医嘱列表</returns>
        public DataTable GetTmpOrderListToPrt()
        {
            DataTable dt = _orderlist.Clone();
            for (int i = 0; i < _orderlist.Rows.Count; i++)
            {
                //临嘱取消后状态为2
                if (_orderlist.Rows[i]["PRT_STATUS"].ToString() == "0" || _orderlist.Rows[i]["PRT_STATUS"].ToString() == "2")
                {
                    dt.Rows.Add(_orderlist.Rows[i].ItemArray);
                    if (_firstpage == -1)
                        _firstpage = Convert.ToInt32(_orderlist.Rows[i]["PAGENO"].ToString());
                    if (_lastpage < i)
                        _lastpage = Convert.ToInt32(_orderlist.Rows[i]["PAGENO"].ToString());
                }
            }
            return dt;
        }
        #endregion

        #region 更新指定患者指定医嘱类型的医嘱打印状态
        /// <summary>
        /// 更新医嘱打印状态
        /// </summary>
        /// <param name="patlistid">患者住院ID</param>
        /// <param name="ordertype">医嘱类型</param>
        /// <returns>更新成功返回true，否则返回false</returns>
        public bool UpdatePrtStatus(int patlistid, int ordertype)
        {
            string str;
            try
            {
                if (ordertype == 0)
                {
                    //将未转抄停嘱的打印状态置为已经打印
                    str = @"update ZY_NURSE_LORDERPRT set PRT_STATUS = 1 where PATLISTID = " + patlistid + " and ORDER_ETSNURSE = 0 and WORKID = " + HIS.SYSTEM.Core.EntityConfig.WorkID;
                    oleDb.DoCommand(str);
                    //将已转抄停嘱的打印状态置为打印完成
                    str = @"update ZY_NURSE_LORDERPRT set PRT_STATUS = 3 where PATLISTID = " + patlistid + " and ORDER_ETSNURSE <> 0 and WORKID = " + HIS.SYSTEM.Core.EntityConfig.WorkID;
                    oleDb.DoCommand(str);
                    return true;
                }
                else if (ordertype == 1)
                {
                    //将临嘱的打印状态置为打印完成
                    str = @"update ZY_NURSE_TORDERPRT set PRT_STATUS = 3 where PATLISTID = " + patlistid + " and WORKID = " + HIS.SYSTEM.Core.EntityConfig.WorkID;
                    oleDb.DoCommand(str);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 更新指定患者指定页数指定医嘱类型的医嘱打印状态
        /// <summary>
        /// 更新医嘱打印状态
        /// </summary>
        /// <param name="patlistid">患者住院ID</param>
        /// <param name="ordertype">医嘱类型</param>
        /// <param name="validpage">可用页码的打印状态，其中的值1打印，0未打印</param>
        /// <returns>更新成功返回true，否则返回false</returns>
        public bool UpdatePrtStatus(int patlistid, int ordertype, int[] validpage)
        {
            string str;
            try
            {
                if (ordertype == 0)
                {
                    for (int i = 0; i < validpage.Length; i++)
                    {
                        if (validpage[i] == 1)
                        {
                            //将未转抄停嘱的打印状态置为已经打印
                            str = @"update ZY_NURSE_LORDERPRT set PRT_STATUS = 1 where PATLISTID = " + patlistid + " and ORDER_ETSNURSE = 0 and PAGENO = " + validpage[i] + " and WORKID = " + HIS.SYSTEM.Core.EntityConfig.WorkID;
                            oleDb.DoCommand(str);
                            //将已转抄停嘱的打印状态置为打印完成
                            str = @"update ZY_NURSE_LORDERPRT set PRT_STATUS = 3 where PATLISTID = " + patlistid + " and ORDER_ETSNURSE <> 0 and PAGENO = " + validpage[i] + " and WORKID = " + HIS.SYSTEM.Core.EntityConfig.WorkID;
                            oleDb.DoCommand(str);
                        }
                    }
                    return true;
                }
                else if (ordertype == 1)
                {
                    for (int i = 0; i < validpage.Length; i++)
                    {
                        if (validpage[i] == 1)
                        {
                            //将临嘱的打印状态置为打印完成
                            str = @"update ZY_NURSE_TORDERPRT set PRT_STATUS = 3 where PATLISTID = " + patlistid + " and PAGENO = " + validpage[i] + " and WORKID = " + HIS.SYSTEM.Core.EntityConfig.WorkID;
                            oleDb.DoCommand(str);
                        }
                    }
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 获取患者的医嘱页数
        /// <summary>
        /// 获取患者的医嘱页数
        /// </summary>
        /// <returns>患者的医嘱页数</returns>
        public int GetValidPages()
        {
            int validpageno;
            DataTable dt = _orderlist.Copy();
            validpageno = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["PAGENO"].ToString());
            return validpageno;
        }
        #endregion

        #endregion
    }
}
