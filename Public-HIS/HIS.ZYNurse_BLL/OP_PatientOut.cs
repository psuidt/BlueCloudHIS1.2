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
    /// <summary>
    /// 患者出院业务逻辑类
    /// </summary>
    public class OP_PatientOut:BaseBLL
    {
        #region 变量声明
        string str;
        DataTable dt = new DataTable();
        Patient currentpat;//患者类
        #endregion

        #region 构造方法
        #endregion

        #region 获取出院患者清单
        /// <summary>
        /// 获取所有出院患者清单
        /// </summary>
        /// <param name="deptid">科室ID</param>
        /// <returns>所有出院患者清单数据表</returns>
        public DataTable listPatient_Leave(long deptid)
        {
            try
            {
                dt.Clear();
                str = "";
                str = @"select a.patlistid patlistid,b.name 病人科室,date(a.outdate) 出院日期,'出院时间' 出院时间,a.bedcode 床号,a.cureno 住院号,a.patid 病人ID,c.patname 姓名,c.patsex 性别, " +
                    "case a.out_flag when 0 then '治愈' when 1 then '好转' when 2 then '未愈' when 3 then '死亡' else '其他' end 出院方式 " +//出院状态：0治愈，1好转，2未愈，3死亡，4其他
                    "from ZY_PATLIST a " +//住院登记信息表
                    "left join BASE_DEPT_PROPERTY b " +//科室信息表
                    "on a.currdeptcode=cast(b.dept_id as char(20)) " +
                    "left join PATIENTINFO c " +//患者信息表
                    "on a.patid=c.patid " +
                    "where a.pattype='7'" +//1.新入院2.在床3.出院未结算4.出院结算5.出院欠费结算6.取消入院7.定义出院
                    " and a.currdeptcode='" + deptid.ToString() + "'";//只获取当前科室出院患者清单
                dt = oleDb.GetDataTable(str);
                return dt;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region 获取已出院患者清单
        /// <summary>
        /// 获取所有出院患者清单
        /// </summary>
        /// <param name="deptid">科室ID</param>
        /// <returns>所有出院患者清单数据表</returns>
        public DataTable listPatient_Left(long deptid)
        {
            try
            {
                int lastMonthNum = OP_Config.GetValue("006");
                if (lastMonthNum == -1)
                    lastMonthNum = 6;
                dt.Clear();
                str = "";
                str = @"select a.patlistid patlistid,b.name 病人科室,date(a.outdate) 出院日期,'出院时间' 出院时间,a.bedcode 床号,a.cureno 住院号,a.patid 病人ID,c.patname 姓名,c.patsex 性别, " +
                    "case a.out_flag when 0 then '治愈' when 1 then '好转' when 2 then '未愈' when 3 then '死亡' else '其他' end 出院方式," +//出院状态：0治愈，1好转，2未愈，3死亡，4其他
                    "case a.pattype when '3' then '出院未结算' when '4' then '出院结算' when '5' then '出院欠费结算' else '其他' end 目前状态 " +
                    "from ZY_PATLIST a " +//住院登记信息表
                    "left join BASE_DEPT_PROPERTY b " +//科室信息表
                    "on a.currdeptcode=cast(b.dept_id as char(20)) " +
                    "left join PATIENTINFO c " +//患者信息表
                    "on a.patid=c.patid " +
                    "where (a.pattype='3' or a.pattype='4' or a.pattype='5')" +//1.新入院2.在床3.出院未结算4.出院结算5.出院欠费结算6.取消入院7.定义出院
                    " and a.currdeptcode='" + deptid.ToString() + "'" +//只获取当前科室出院患者清单
                    " and a.outdate>='" + XcDate.ServerDateTime.Date.AddMonths(-lastMonthNum) + "'" +
                    " order by a.outdate desc";//只显示最近半年的出院患者
                dt = oleDb.GetDataTable(str);
                return dt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        /// <summary>
        /// 判断转科病人明日是否有未冲或未退的药品
        /// </summary>
        /// <returns></returns>
        public bool TorrowDrug(int patlistid,DateTime serverDate)
        {
            str = "patlistid=" + patlistid + " and date(costdate)=" + "'" + serverDate.ToString("yyyy-MM-dd") + "'";
            object obj = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetFieldValue("sum(tolal_fee)",str);
            if (obj==DBNull.Value || Convert.ToDecimal(obj)==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region 获取转科患者清单
        /// <summary>
        /// 获取所有转科患者清单
        /// </summary>
        /// <param name="deptid">科室ID</param>
        /// <returns>所有转科患者清单数据表</returns>
        public DataTable listPatient_Transfer(long deptid)
        {
            try
            {
                dt.Clear();
                str = "";
                str = @"select b.PATID TranPatID,a.TRANSDEPT_ID TranID,date(a.TRANSFER_DATE) TranDate, time(a.TRANSFER_DATE) TranTime,b.BEDCODE TranBedNo,b.CURENO TranCureNo," +
                    "a.PATID TranPatlistID,c.PATNAME TranName,c.PATSEX TranSex,a.ORIGE_DEPT TranOrigeDept,a.GET_DEPT TranGetDept,d.ORDER_DOC TranDoc,date(a.OPERATE_DATE) TranBookDate " +
                    "from ZY_DOC_TRANSDEPT a " +
                    "left join ZY_PATLIST b " +
                    "on a.PATID=b.PATLISTID " +
                    "left join PATIENTINFO c " +
                    "on b.PATID=c.PATID " +
                    "left join ZY_DOC_ORDERRECORD d " +
                    "on a.ORDER_ID=d.ORDER_ID " +
                    "where FINISH_FLAG=0 and CANCEL_FLAG=0 and a.ORDER_ID=d.ORDER_ID" +
                    " and a.ORIGE_DEPT=" + deptid.ToString();//只获取当前科室的转科患者清单
                dt = oleDb.GetDataTable(str);
                dt.Columns.Add("TranOrigeDeptName");
                dt.Columns.Add("TranGetDeptName");
                dt.Columns.Add("TranDocName");
                foreach (DataRow dr in dt.Rows)
                {
                    dr["TranOrigeDeptName"] = BaseData.GetDeptName(dr["TranOrigeDept"].ToString());
                    dr["TranGetDeptName"] = BaseData.GetDeptName(dr["TranGetDept"].ToString());
                    dr["TranDocName"] = BaseData.GetUserName(dr["TranDoc"].ToString());
                }
                return dt;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion


        #region 患者是否有未停医嘱，未记账费用
        /// <summary>
        /// 判断患者能否出院，能出院返回true，不能返回false
        /// </summary>
        /// <param name="patlistid">患者住院ID</param>
        /// <param name="errorMsg">错误消息</param>
        /// <param name="unsettled">未处理项目</param>
        /// <returns></returns>
        public bool MayLeave(int patlistid, out string errorMsg, out string unsettled)
        {
            //判断患者是否有未停医嘱
            //str = "";
            //errorMsg = "";
            //unsettled = "";
            //str = @"select a.order_content OrderContent" +
            //    "from ZY_DOC_ORDERRECORD a " +
            //    "where a.status_falg<5 and (a.order_content not like '%病人出院%' and a.order_content not like '%转%科' and a.order_content not like '%死亡%') and a.delete_flag=0 and a.patid=" + patlistid;
            //dt = oleDb.GetDataTable(str);
            //if (dt.Rows.Count > 0)
            //{
            //    errorMsg = "有未停止的医嘱或账单";
            //    unsettled += "\n未停止的医嘱或账单：";
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        unsettled += "\n\t" + dt.Rows[i]["OrderContent"].ToString();
            //    }
            //}

            //判断患者是否有未转抄医嘱
            str = "";
            errorMsg = "";
            unsettled = "";
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    dt.Clear();
            //}
            str = @"select a.order_content OrderContent " +
                "from ZY_DOC_ORDERRECORD a " +
                "where a.status_falg in (1,3) and a.order_type in (0,1,5,6,7) and a.delete_flag=0 and a.patid=" + patlistid;// and (a.order_content not like '%病人出院%' and a.order_content not like '%转%科' and a.order_content not like '%死亡%') and a.delete_flag=0 and a.patid=" + patlistid;//modify by 何艳 2009.12.7,要判断出院医嘱
            dt = oleDb.GetDataTable(str);
            if (dt.Rows.Count > 0)
            {
                errorMsg += errorMsg == "" ? "有" : ",";
                errorMsg += "未转抄医嘱";
                unsettled += "\n未转抄医嘱：";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    unsettled += "\n\t" + dt.Rows[i]["OrderContent"].ToString();
                }
            }

            //判断患者是否有未发送医嘱
            str = "";
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    dt.Clear();
            //}
            str = @"select a.order_content OrderContent " +
                "from ZY_DOC_ORDERRECORD a " +
                "where a.status_falg in (2,4) and a.order_type in (0,1,5,6,7,10) and a.delete_flag=0 and a.patid=" + patlistid; //and (a.order_content not like '%病人出院%' and a.order_content not like '%转%科' and a.order_content not like '%死亡%') and a.delete_flag=0 and a.patid=" + patlistid;//modify by 何艳 2009.12.7,要判断出院医嘱
            dt = oleDb.GetDataTable(str);
            if (dt.Rows.Count > 0)
            {
                errorMsg += errorMsg == "" ? "有" : ",";
                errorMsg += "未发送医嘱";
                unsettled += "\n未发送医嘱：";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    unsettled += "\n\t" + dt.Rows[i]["OrderContent"].ToString();
                }
            }

            //判断患者是否有未发送账单
            str = "";
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    dt.Clear();
            //}
            str = @"select a.order_content OrderContent " +
                "from ZY_DOC_ORDERRECORD a " +
                "where a.status_falg in (2) and a.order_type in (2,3) and (a.order_content not like '%病人出院%' and a.order_content not like '%转%科' and a.order_content not like '%死亡%') and a.delete_flag=0 and a.patid=" + patlistid;
            dt = oleDb.GetDataTable(str);
            if (dt.Rows.Count > 0)
            {
                errorMsg += errorMsg == "" ? "有" : ",";
                errorMsg += "未发送账单";
                unsettled += "\n未发送账单：";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    unsettled += "\n\t" + dt.Rows[i]["OrderContent"].ToString();
                }
            }

            //判断患者是否有未记账的费用
            str = "";
            //dt.Clear();
            str = @"select a.itemname ItemName " +
                "from zy_presorder a " +
                "where a.charge_flag=0 and a.itemname not like '自备' and a.delete_flag=0 and a.patlistid=" + patlistid;
            dt = oleDb.GetDataTable(str);
            if (dt.Rows.Count > 0)
            {
                errorMsg += errorMsg == "" ? "有" : ",";
                errorMsg += "未记账费用";
                unsettled += "\n未记账费用：";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    unsettled += "\n\t" + dt.Rows[i]["ItemName"].ToString();
                }
            }
            //如果有未停医嘱或未记账费用，弹出消息框
            if (errorMsg != "")
            {
                currentpat = new Patient(patlistid);
                errorMsg = "对不起，病人“" + currentpat.patname + "”" + errorMsg + "，不允许";
                return false;
            }
            else
                return true;
        }
        #endregion

        #region 患者是否在床
        /// <summary>
        /// 患者是否在床
        /// </summary>
        /// <param name="patlistid">患者住院ID</param>
        /// <returns>在床返回true，否则返回false</returns>
        public bool isOnbed(int patlistid)
        {
            str = "";
            dt.Clear();

            str = @"select pattype from zy_patlist where patlistid=" + patlistid;
            dt = oleDb.GetDataTable(str);
            if (dt.Rows[0]["pattype"].ToString() == "2")
                return true;
            else
                return false;
        }
        #endregion

        #region 患者是否结算
        /// <summary>
        /// 患者是否已定义出院，正在结算
        /// </summary>
        /// <param name="patlistid">患者住院ID</param>
        /// <returns>结算返回true，否则返回false</returns>
        public bool isOnbalance(int patlistid)
        {
            str = "";
            dt.Clear();

            str = @"select pattype from zy_patlist where patlistid=" + patlistid;
            dt = oleDb.GetDataTable(str);
            if (dt.Rows[0]["pattype"].ToString() == "4" || dt.Rows[0]["pattype"].ToString() == "5")
                return true;
            else
                return false;
        }
        #endregion

        #region 患者是否有未转抄医嘱
        /// <summary>
        /// 患者是否有未转抄医嘱
        /// </summary>
        /// <param name="patlistid">患者住院ID</param>
        /// <returns>有未转抄医嘱返回true，否则返回false</returns>
        public bool hasUntranscribeOrder(int patlistid)
        {
            str = "";
            dt.Clear();

            str = @"select count(*) num from ZY_DOC_ORDERRECORD where PATID=" + patlistid + " and STATUS_FALG<2 and DELETE_FLAG=0";
            dt = oleDb.GetDataTable(str);
            if (Convert.ToInt32(dt.Rows[0]["num"]) > 0)
                return true;
            else
                return false;
        }
        #endregion
 
        #region 患者是否有未执行临嘱
        /// <summary>
        /// 患者是否有未执行医嘱
        /// </summary>
        /// <param name="patlistid">患者住院ID</param>
        /// <returns>如果有未执行医嘱返回true，否则返回false</returns>
        public bool hasUndoTempOrder(int patlistid)
        {
            str = "";
            dt.Clear();

            str = @"select count(*) num from ZY_DOC_ORDERRECORD where PATID=" + patlistid + " and STATUS_FALG<2 and DELETE_FLAG=0 and ORDER_TYPE in(1,5)";
            dt = oleDb.GetDataTable(str);
            if (Convert.ToInt32(dt.Rows[0]["num"]) > 0)
                return true;
            else
                return false;
        }
        #endregion

        #region 患者是否有未停长期账单
        /// <summary>
        /// 患者是否有未停长期账单
        /// </summary>
        /// <param name="patlistid">患者住院ID</param>
        /// <returns>如果有未停长期账单返回true，否则返回false</returns>
        public bool hasUnstopLongTab(int patlistid)
        {
            str = "";
            dt.Clear();

            str = @"select count(*) num from ZY_DOC_ORDERRECORD where PATID=" + patlistid + " and STATUS_FALG<5 and DELETE_FLAG=0 and ORDER_TYPE in(2)";
            dt = oleDb.GetDataTable(str);
            if (Convert.ToInt32(dt.Rows[0]["num"]) > 0)
                return true;
            else
                return false;
        }
        #endregion

        #region 患者长期医嘱状态
        /// <summary>
        /// 患者长期医嘱状态
        /// </summary>
        /// <param name="patlistid">患者住院ID</param>
        /// <returns>2无已转抄长嘱，12已转抄但未执行过，112已转抄曾执行过，但今天未执行，111已转抄，今天已执行</returns>
        public int LongOrderStatus(int patlistid)
        {
            str = "";
            dt.Clear();

            str = @"select a.ORDER_ID,max(date(EXEC_DATE)) " +
                "from ZY_DOC_ORDERRECORD a " +
                "left join ZY_NURSE_ORDEREXEC b " +
                "on a.ORDER_ID = b.ORDER_ID  " +
                "where a.STATUS_FALG = 2 and a.DELETE_FLAG=0 and ORDER_TYPE in (0) and a.PATID=" + patlistid + " group by a.ORDER_ID";
            dt = oleDb.GetDataTable(str);

            //有已转抄医嘱
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //已转抄且执行过
                    if (dt.Rows[i][1] != System.DBNull.Value)
                    {
                        //今天未执行
                        if (Convert.ToDateTime(dt.Rows[i][1].ToString()).Date < System.DateTime.Today.Date)
                        {
                            return 112;
                        }
                    }
                    //已转抄但未执行过
                    else
                        return 12;
                }
                //已转抄，今天已执行
                return 111;
            }
            //无已转抄长嘱
            else
            {
                return 2;
            }
        }
        #endregion

        #region 出院操作
        /// <summary>
        /// 出院操作
        /// </summary>
        /// <param name="patlistid">患者住院ID</param>
        /// <param name="operatorid">操作者ID</param>
        /// <param name="errorMsg">错误信息</param>
        public void ApplyLeave(int patlistid,int operatorid,out string errorMsg)
        {
            errorMsg = "";
            //开始事务
            oleDb.BeginTransaction();
            try
            {
                str="";
                str="SP_HS_APPLYOUT";

                //调用存储过程
                IDbCommand mycmd=oleDb.GetCommand();;
                mycmd.CommandText=str;
                mycmd.CommandTimeout=60;
                mycmd.Parameters.Add(oleDb.GetParameter("@vpatlistid",patlistid));
                mycmd.Parameters.Add(oleDb.GetParameter("@voperatorid",operatorid));
                mycmd.CommandType=System.Data.CommandType.StoredProcedure;

                oleDb.DoCommand((IDbCommand)mycmd);

                //提交事务
                oleDb.CommitTransaction();

                //TODO:写入日志

            }
            catch
            {
                //事务回滚
                oleDb.RollbackTransaction();
                errorMsg = "错误：\n数据已经回滚，请检查后重新执行！";

                //TODO:错误日志

                //TODO:消息提示
            }
        }
        #endregion

        #region 患者是否有出区（出院，死亡，转科）医嘱
        /// <summary>
        /// 判断患者是否有出区（出院，死亡，转科）医嘱
        /// </summary>
        /// <param name="patlistid">患者住院ID</param>
        /// <param name="orderid">出区医嘱的医嘱ID</param>
        /// <param name="str">出区医嘱的类型（出院，转科）</param>
        /// <returns>有相应出区医嘱返回true，否则false</returns>
        public bool GetLeaveOrder(int patlistid, out int orderid, string str)
        {
            orderid = 0;
             string  strsql = ""; //update by heyan 2010.11.2 参数名和变量名相同，导致同时有出院和转科医嘱时会出错
            dt.Clear();

            //item_type=10表示出院医嘱
            strsql = @"select order_id from zy_doc_orderrecord " +
                "where patid=" + patlistid + " " +
                "and item_type=10  and order_type=1 and delete_flag=0 "; // update by heyan 2010.3.17
            if(str=="出院")
                strsql += " and (posstr(order_content,'出院')>0 or posstr(order_content,'病人死亡')>0)";
            else if(str=="转科")
                strsql += " and (posstr(order_content,'转')>0)";
            dt = oleDb.GetDataTable(strsql);
            if (dt == null || dt.Rows.Count == 0)
                return false;
            else
            {
                orderid = Convert.ToInt32(dt.Rows[0]["order_id"].ToString());
                return true;
            }
        }
        #endregion

        #region 取消定义出院操作
        /// <summary>
        /// 取消定义出院操作
        /// </summary>
        /// <param name="patlistid">患者住院ID</param>
        /// <param name="errorMsg">错误信息</param>
        public void ApplyCancelLeave(int patlistid, int orderid, out string errorMsg)
        {
            errorMsg = "";
            try
            {
                oleDb.BeginTransaction();

                str = "";
                //修改医嘱状态
                str = "update zy_doc_orderrecord set status_falg=1, trans_nurse=null, trans_date=null where order_id=" + orderid + " and patid=" + patlistid;
                oleDb.DoCommand(str);
                //TODO:删除出院医嘱打印记录
                //删除医嘱执行表记录
                str = "delete from zy_nurse_orderexec where order_id=" + orderid + " and patient_id=" + patlistid;
                oleDb.DoCommand(str);
                oleDb.CommitTransaction();
            }
            catch(Exception)
            {
                errorMsg = "错误：取消定义出院错误！";
            }
        }
        #endregion

        #region 转科操作
        /// <summary>
        /// 转科操作
        /// </summary>
        /// <param name="patlistid">患者住院ID</param>
        /// <param name="operatorid">操作者ID</param>
        /// <param name="errorMsg">错误信息</param>
        /// <param name="getdept">目标科室</param>
        /// <param name="transdeptid">转科表ID</param>
        public void ApplyTransfer(int patlistid, int operatorid, int transdeptid, string getdept, out string errorMsg)
        {
            errorMsg = "";
            //开始事务
            oleDb.BeginTransaction();
            try
            {
                str = "";
                str = "SP_HS_TRANDEPT";
                //调用存储过程
                IDbCommand mycmd = oleDb.GetCommand();
                mycmd.CommandText = str;
                mycmd.CommandTimeout = 60;
                mycmd.Parameters.Add(oleDb.GetParameter("@vcurrdeptcode", getdept));
                mycmd.Parameters.Add(oleDb.GetParameter("@vpatlistid", patlistid));
                mycmd.Parameters.Add(oleDb.GetParameter("@voperatorid", operatorid));
                mycmd.Parameters.Add(oleDb.GetParameter("@vtransdeptid", transdeptid));

                mycmd.CommandType = System.Data.CommandType.StoredProcedure;

                oleDb.DoCommand((IDbCommand)mycmd);
                //提交事务
                oleDb.CommitTransaction();

            }
            catch
            {
                //事务回滚
                oleDb.RollbackTransaction();
                errorMsg = "错误：\n数据已经回滚，请检查后重新执行！";

                //TODO:错误日志

                //TODO:消息提示
            }
        }
        #endregion

        #region 取消转科
        /// <summary>
        /// 取消转科
        /// </summary>
        /// <param name="patlistid">患者ID</param>
        /// <param name="orderid">转科医嘱ID</param>
        /// <param name="errorMsg">取消转科错误信息</param>
        public void ApplyCancelTran(int patlistid, int orderid, out string errorMsg)
        {
            errorMsg = "";
            try
            {
                oleDb.BeginTransaction();

                str = "";
                //修改医嘱状态
                str = @"update zy_doc_orderrecord set status_falg=1, trans_nurse=null, trans_date=null where order_id=" + orderid + " and patid=" + patlistid;
                oleDb.DoCommand(str);
                //删除医嘱执行表记录
                str = "delete from zy_nurse_orderexec where order_id=" + orderid + " and patient_id=" + patlistid;
                oleDb.DoCommand(str);
                oleDb.CommitTransaction();
            }
            catch(Exception)
            {
                errorMsg = "错误：取消转科错误！";
            }
        }
        #endregion

        #region 患者是否有未发药品
        /// <summary>
        /// 患者是否有未发药品
        /// </summary>
        /// <param name="patlistid">患者住院ID</param>
        /// <returns>未发药品明细</returns>
        public string UnProvide(int patlistid)
        {
            //未发药，未冲正或冲正数量小于待发药数量
            string items = "";
            //str = @"select a.ITEMNAME ItemName from ZY_PRESORDER a " +
            //    " left join ZY_PRESORDER b on a.PRESORDERID=b.OLDID and b.RECORD_FLAG=1 " +//RECORD_FLAG：0正常1冲正2取消冲正
            //    " where a.PATLISTID=" + patlistid + " and a.DRUG_FLAG=0 and a.RECORD_FLAG=0 " +//DRUG_FLAG：0未发药1发药
            //    " and a.AMOUNT+(case when b.AMOUNT is null then 0 else b.AMOUNT end)>0;";

            str = @"select itemname from (select itemname ,(amount+(select (case when sum(amount) is null then 0 end) from zy_presorder where oldid=a.presorderid)) as amount  
                from zy_presorder a where a.PATLISTID=" + patlistid + @" and a.DRUG_FLAG=0 and a.RECORD_FLAG=0 and (a.prestype='1' or a.prestype='2' or a.prestype='3')
                ) aa where amount>0";         
           
            dt = oleDb.GetDataTable(str);
            if (dt == null || dt.Rows.Count == 0)
            {
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    items += "\n\t" + dr["ItemName"].ToString();
                }
            }
            return items;
        }
        #endregion

        #region 患者未生成药品统领消息presorderid       
        public DataTable getDtPresorder(int patlistid)
        {            
            str = @"select presorderid,presdeptcode,execdeptcode from
                 (
                   select PRESORDERID ,presdeptcode,execdeptcode from 
                   (select itemname,presdeptcode,execdeptcode ,presorderid,(amount+(select (case when sum(amount) is null then 0 else sum(amount) end) from zy_presorder where oldid=a.presorderid)) as amount  
                   from zy_presorder a where a.charge_flag=1 and a.PATLISTID=" + patlistid + @" and a.DRUG_FLAG=0  and  a.RECORD_FLAG=0  and  (a.prestype='1' or a.prestype='2' or a.prestype='3')) aa where amount>0                    
                  ) bb
                 where bb.presorderid not in (select  orderrecipeid  from ZY_DRUGMESSAGE_ORDER where patid=" + patlistid + ")";//PRETYPE：4项目123均为药品
            dt = oleDb.GetDataTable(str);           
            return dt;
        }
        /// <summary>
        /// 退药
        /// </summary>
        /// <param name="patlistid"></param>
        /// <returns></returns>
        public DataTable getDrawBackDtPresorder(int patlistid)
        {            
            str = @"select presorderid,presdeptcode,execdeptcode from
                    (select PRESORDERID, presdeptcode,execdeptcode from zy_presorder  where PATLISTID=" + patlistid + @" and DRUG_FLAG=1 and RECORD_FLAG=1  and AMOUNT<0  and (prestype='1' or prestype='2' or prestype='3'))
                   bb  where bb.presorderid not in (select  orderrecipeid  from ZY_DRUGMESSAGE_ORDER where patid=" + patlistid + ")";//PRETYPE：4项目123均为药品
            dt = oleDb.GetDataTable(str);           
            return dt;
        }
        #endregion                   

        #region 患者是否有未退药品
        /// <summary>
        /// 患者是否有未退药品
        /// </summary>
        /// <param name="patlistid">患者住院ID</param>
        /// <returns>未退药品明细</returns>
        public string UnWithDrawal(int patlistid)
        {
            //发药后再冲即退药，退药数量大于0并且类型为药品
            string items = "";
            str = @"select ITEMNAME ItemName " +
                " from ZY_PRESORDER " +
                " where RECORD_FLAG=1 and DRUG_FLAG=1 and AMOUNT<0 and PRESTYPE<>'4' and patlistid=" + patlistid;//PRETYPE：4项目123均为药品
            dt = oleDb.GetDataTable(str);
            if (dt == null || dt.Rows.Count == 0)
            {
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    items += "\n\t" + dr["ItemName"].ToString();
                }
            }
            return items;
        }
        #endregion
    }
}