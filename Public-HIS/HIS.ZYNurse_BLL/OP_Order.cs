using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;


namespace HIS.ZYNurse_BLL
{
    public class OP_Order:BaseBLL
    {
        private string time;
        private long   employeeid;

        #region 与医嘱处理过程无关的东西
        /// <summary>
        /// 获取病人列表
        /// </summary>
        /// <param name="dept_id"></param>
        /// <returns></returns>
        public DataTable getPatList(int dept_id)
        {
            try
            {                
                string strWhere = @"select a.bed_no,a.patlist_id,c.patname,b.cureno"
                                  +" from zy_nurse_bed a"
                                  +" join zy_patlist b on a.patlist_id=b.patlistid"
                                  +" join patientinfo c on b.patid=c.patid"
                                  +" where a.dept_id=" + dept_id
                                  +" order by cast( replace(bed_no,'加','100') as integer)";
                DataTable patdt = oleDb.GetDataTable(strWhere);
                return patdt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }              
        /// <summary>
        /// 获取未转抄的长嘱和临嘱列表
        /// </summary>
        /// <returns></returns>
        public DataTable getOrderList(long dept_id)
        {
            int deptid =Convert.ToInt32(dept_id);
            try
            {
                string strWhere = @"select a.patid,a.order_id,a.order_content,case a.order_type when 0 then '长嘱' when  1 then'临嘱' when  5 then'临嘱' when  7 then'临嘱' end as order_type,a.order_bdate,a.order_doc,a.group_id,a.serial_id,a.order_usage,a.frequency,a.firset_times,a.teminal_times,a.order_struc,a.amount,a.unit,c.name ,d.cureno,d.patid,e.bed_no,f.patname,case a.status_falg when 1 then '' when  3 then'(停)' end as status_flag,0 GroupFlag"
                                + " from zy_doc_orderrecord a"
                                + " left join base_employee_property c on a.order_doc=c.employee_id"
                                + " left join zy_patlist d on a.patid=d.patlistid"
                                + " left join zy_nurse_bed e on a.patid=e.patlist_id"
                                + " left join patientinfo f on d.patid=f.patid"
                                + " where (status_falg=1 or status_falg=3) and (order_type=0 or order_type=1 or order_type=5 or order_type=7) and pat_deptid=" + deptid + " and delete_flag=0 order by cast( replace(bed_no,'加','100') as integer),order_type,group_id,order_id";
                 DataTable orderdt = oleDb.GetDataTable(strWhere);  
                 if (orderdt == null || orderdt.Rows.Count == 0)
                 {
                     return null;
                 }
                 else
                 {
                     int gid = Convert.ToInt32(orderdt.Rows[0]["group_id"].ToString());
                     long pid = Convert.ToInt64(orderdt.Rows[0]["patid"].ToString());
                     string tid = orderdt.Rows[0]["order_type"].ToString();
                     for (int i = 1; i < orderdt.Rows.Count; i++)
                     {
                         //从第二组开始比较，如果与上一行同一组，则将本行设为组中，上一个不属于组的行设为组头，如果不相同，且上一行属于组，则设为组尾
                         if (pid == Convert.ToInt64(orderdt.Rows[i]["patid"].ToString()) && gid == Convert.ToInt64(orderdt.Rows[i]["group_id"].ToString()) && tid == orderdt.Rows[i]["order_type"].ToString())
                         {
                             //如果上一行不属于组，也就是组的第一行时，设为组头
                             if (orderdt.Rows[i - 1]["GroupFlag"].ToString() == "0")
                                 orderdt.Rows[i - 1]["GroupFlag"] = 1;
                             orderdt.Rows[i]["GroupFlag"] = 2;
                         }
                         else
                         {
                             if (orderdt.Rows[i - 1]["GroupFlag"].ToString() != "0")
                                 orderdt.Rows[i - 1]["GroupFlag"] = 3;
                             pid = Convert.ToInt64(orderdt.Rows[i]["patid"].ToString());
                             gid = Convert.ToInt32(orderdt.Rows[i]["group_id"].ToString());
                             tid = orderdt.Rows[i]["order_type"].ToString();
                         }
                     }
                     if (orderdt.Rows[orderdt.Rows.Count - 1]["GroupFlag"].ToString() == "2")
                         orderdt.Rows[orderdt.Rows.Count - 1]["GroupFlag"] = 3;
                     return orderdt;
                 }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }        
        /// <summary>
        /// 对即将转抄的医嘱修改标识位
        /// </summary>
        /// <param name="ordid"></param>
        public bool setTransFlag(List<int> order_list,long employee_id)
        {
            int employeeid = Convert.ToInt32(employee_id);
            List<int> orderidlist=order_list;
            try
            {
                oleDb.BeginTransaction();
                for (int i = 0; i < orderidlist.Count; i++)
                {
                    string strWhere1 = "order_id=" + orderidlist[i];//3月24修改
                    object obj = BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetFieldValue(Tables.zy_doc_orderrecord.STATUS_FALG, strWhere1);


                    int status_flag = int.Parse(obj.ToString());
                    if (status_flag == 1)
                    {
                        string strWhere2 = "order_id=" + orderidlist[i] + " and status_falg=1 and delete_flag=0";
                        string string1 = "status_falg=2";
                        string string2 = "trans_nurse=" + employeeid;
                        string string3 = "trans_date=" + "'" + XcDate.ServerDateTime + "'";
                        BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strWhere2, string1, string2, string3);
                    }
                    else
                    {
                        string strWhere3 = "order_id=" + orderidlist[i] + " and status_falg=3 ";
                        string string1 = "status_falg=4";
                        string string2 = "eorder_tsnurse=" + employeeid;
                        string string3 = "trans_date=" + "'" + XcDate.ServerDateTime + "'";
                        BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strWhere3, string1, string2, string3);
                    }
                }
                oleDb.CommitTransaction();
                return true;
            }
            catch (Exception e)
            {
                oleDb.RollbackTransaction();
                return false;
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 对皮试医嘱过滤
        /// </summary>
        public void getTransResult(List<int> order_list)
        {
            List<int> orderlist = order_list;            
            for (int i = 0; i < orderlist.Count; i++)
            {  
                string strwhere = "select b.order_id from zy_doc_orderrecord a"
                                  + " left join zy_doc_orderrecord b on a.group_id=b.group_id and a.patid=b.patid and a.order_type=b.order_type"
                                  + " left join zy_doc_orderrecord c on b.ps_orderid=c.ps_orderid and b.patid=c.patid"
                                  + " where b.ps_orderid!=0 and b.ps_flag in (0,2) and b.item_code <> '' "
                                  + " and a.order_id=" + orderlist[i];

                DataTable dt = oleDb.GetDataTable(strwhere);
                if (dt != null && dt.Rows.Count > 0)
                {
                    orderlist.Remove(orderlist[i]);
                    i--;
                }                
            }
        }
        /// <summary>
        /// 根据病人列表ID和医嘱类型获取与（选项卡）相对应的医嘱(除有效临嘱外)
        /// </summary>
        /// <param name="patlistid"></param>
        /// <param name="ordertype"></param>
        /// <returns></returns>
        public DataTable getOrder(int patlistid, int ordertype)
        {
            try
            {
                string strWhere = @"select a.order_id,a.order_bdate,a.order_content,a.group_id,a.trans_date,a.order_usage,a.frequency,a.firset_times,a.teminal_times,a.order_struc,a.amount,a.unit,c.name as docname,d.name as transnursename,e.name as oprerator,a.op_date,a.item_type"
                                + " from zy_doc_orderrecord a"
                                + " left join  base_employee_property c on a.order_doc=c.employee_id"
                                + " left join  base_employee_property d on a.trans_nurse=d.employee_id"
                                + " left join  base_employee_property e on a.oprerator=e.employee_id"
                                + " where (status_falg=2 or status_falg=4)"
                                + " and order_type="+ordertype
                                + " and patid="+patlistid
                                + " and delete_flag=0 order by group_id,order_id";
                DataTable trandt = oleDb.GetDataTable(strWhere);
                return trandt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 加载有效临嘱
        /// </summary>
        /// <param name="patlistid"></param>
        /// <param name="ordertype"></param>
        /// <returns></returns>
        public DataTable getValidOrder(int patlistid, int ordertype)
        {
            try
            {
                string strWhere = @"select a.order_id,a.order_bdate,a.order_content,a.group_id,case a.ps_flag when 1 then '(-)' when 2 then'(+)' else ''end as ps_flag,a.makedicid,a.order_usage,a.ps_orderid,a.frequency,a.firset_times,a.teminal_times,a.order_struc,a.amount,a.unit,a.trans_date,c.name as docname,d.name as nursename"
                                + " from zy_doc_orderrecord a"
                                + " left join  base_employee_property c on a.order_doc=c.employee_id"
                                + " left join  base_employee_property d on a.trans_nurse=d.employee_id"
                                + " where (status_falg=2 or status_falg=4)"
                                + " and (order_type=" + ordertype+" or order_type=5 or order_type=7)"//10.21修改
                                + " and patid=" + patlistid
                                + " and delete_flag=0 order by group_id,order_id";
                DataTable trandt = oleDb.GetDataTable(strWhere);
                return trandt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 加载所有长嘱、所有长期账单
        /// </summary>
        /// <param name="patlistid"></param>
        /// <param name="ordertype"></param>
        /// <returns></returns>
        public DataTable getAllOrder(int patlistid, int ordertype)
        {
            try
            {
                string strWhere = @"select a.order_id,a.order_bdate,a.order_content,a.group_id,a.trans_date,a.amount,a.unit,a.order_usage,a.frequency,c.name as docname,d.name as transnursename,e.name as oprerator,a.op_date,a.eorder_date,f.name as eorder_doc"
                                + " from zy_doc_orderrecord a"
                                + " left join  base_employee_property c on a.order_doc=c.employee_id"
                                + " left join  base_employee_property d on a.trans_nurse=d.employee_id"
                                + " left join  base_employee_property e on a.oprerator=e.employee_id"
                                + " left join  base_employee_property f on a.eorder_doc=f.employee_id"
                                + " where (status_falg=2 or status_falg=3 or status_falg=4 or status_falg=5) "
                                + " and order_type=" + ordertype
                                + " and patid=" + patlistid
                                + " and delete_flag=0 order by group_id,order_id";//noexe_flag=1 去掉，3月1日修改
                DataTable trandt = oleDb.GetDataTable(strWhere);
                return trandt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 加载所有临时医嘱、所有临时账单
        /// </summary>
        /// <param name="patlistid"></param>
        /// <param name="ordertype"></param>
        /// <returns></returns>
        public DataTable getAllTempOrder(int patlistid, int ordertype)
        {
            try
            {
                string strWhere = @"select a.order_id,a.order_bdate,a.order_content,a.group_id,a.trans_date,a.order_usage,a.frequency,a.amount,a.unit,c.name as docname,d.name as transnursename,e.name as oprerator,a.op_date"
                                + " from zy_doc_orderrecord a"
                                + " left join  base_employee_property c on a.order_doc=c.employee_id"
                                + " left join  base_employee_property d on a.trans_nurse=d.employee_id"
                                + " left join  base_employee_property e on a.oprerator=e.employee_id"
                                + " where status_falg=5"
                                + " and patid=" + patlistid ;
                if (ordertype == 1)
                {
                    strWhere += " and order_type in(5,7," + ordertype + ")";
                }
                else if (ordertype == 3)
                {
                    strWhere+=" and order_type=" + ordertype;
                }
                strWhere = strWhere + " and delete_flag=0 order by group_id,order_id";            
                DataTable trandt = oleDb.GetDataTable(strWhere);
                return trandt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 获取冲正费用信息数据源
        /// </summary>
        /// <returns></returns>
        public DataTable getCancelFeeInfo(List<int> order_list)
        {
            List<int> orderlist = order_list;
            string strWhere = Tables.zy_presorder.ORDER_ID + oleDb.In() + "(";
            for (int i = 0; i < orderlist.Count; i++)
            {
                if (i != orderlist.Count - 1)
                {
                    strWhere += orderlist[i] + ",";
                }
                else
                {
                    strWhere += orderlist[i] + ")";
                }
            }
            strWhere += "order by costdate";
            DataTable canfeedt = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetList(strWhere);
            return canfeedt;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="order_id"></param>
        /// <returns></returns>
        public DataTable getCancelAccountInfo(int order_id)
        {
            int orderid = order_id;
            string strWhere = "order_id=" + orderid;
            DataTable canfeedt = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetList(strWhere);
            return canfeedt;
        }       
        /// <summary>
        /// 标识皮试正
        /// </summary>
        /// <param name="order_id"></param>
        /// <returns></returns>
        public bool setPSZresult(decimal psorder_id)
        {
            decimal psorderid = psorder_id;
            string strWhere = " ps_orderid=" + psorderid+" and (ps_flag=0 or ps_flag=1 or ps_flag=2)";//10月21日增加            
            string strSet = Tables.zy_doc_orderrecord.PS_FLAG + oleDb.EuqalTo() + 2;//+","+ Tables.zy_doc_orderrecord.PS_FLAG + oleDb.EuqalTo() + 0;
            BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strWhere, strSet);
            return true;
        }
        /// <summary>
        /// 标识皮试负
        /// </summary>
        /// <param name="order_id"></param>
        /// <returns></returns>
        public bool setPSFresult(decimal psorder_id)
        {
            decimal psorderid = psorder_id;
            string strWhere = " ps_orderid=" + psorderid + " and (ps_flag=0 or ps_flag=1 or ps_flag=2)";//10月21日增加           
            string strSet = Tables.zy_doc_orderrecord.PS_FLAG + oleDb.EuqalTo() + 1;
            BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strWhere, strSet);
            return true;
        }
        /// <summary>
        /// 获取口服用法
        /// </summary>
        /// <param name="use_age"></param>
        /// <returns></returns>
        public bool getUseage(string use_age)
        {
            string useage = use_age;
            string str="select name from BASE_USAGEDICTION where id in(select usage_id from BASE_USAGE_USETYPE_ROLE where type_name='服药单') and delete_bit=0";
            DataTable dt = oleDb.GetDataTable(str);
            DataRow[] dr=dt.Select("name='"+useage+"'");
            if (dr.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }
        /// <summary>
        /// 取消转抄医嘱
        /// </summary>
        /// <param name="order_id"></param>
        /// <param name="employee_id"></param>
        /// <param name="patlist"></param>
        /// <returns></returns>
        public bool orderstoptrans(List<int> order_id, long employee_id, int patlist)
        {
            try
            {
                List<int> orderid = order_id;
                employeeid = employee_id;
                int patlistid = patlist;
                oleDb.BeginTransaction();
                for (int arraynum = 0; arraynum < orderid.Count; arraynum++)
                {
                    string strwhere =Tables.zy_doc_orderrecord.ORDER_ID+oleDb.EuqalTo()+orderid[arraynum] +oleDb.And()+Tables.zy_doc_orderrecord.NOEXE_FLAG + oleDb.EuqalTo() + 0 +oleDb.And()+Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + 2;
                    string str=Tables.zy_doc_orderrecord.STATUS_FALG+oleDb.EuqalTo()+1;
                    BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strwhere, str);
                }
                oleDb.CommitTransaction();
                return true;
            }
            catch(Exception e)
            {
                return false;
                throw new Exception(e.Message);                
            }
        }
        /// <summary>
        /// 判断当期医嘱是否可以取消转抄
        /// </summary>
        /// <returns></returns>
        public bool IsCanTrans(int patlistid) //string  getPatType(int patlistid)
        {

            string strWhere = "patlistid=" + patlistid;
            object obj = BindEntity<ZY_PatList>.CreateInstanceDAL(oleDb).GetFieldValue("pattype", strWhere);
            string strWhere1 = Tables.zy_doc_transdept.PATID + oleDb.EuqalTo() + patlistid
                               +oleDb.And() + Tables.zy_doc_transdept.CANCEL_FLAG + oleDb.EuqalTo() + 0
                               +oleDb.And() + Tables.zy_doc_transdept.FINISH_FLAG + oleDb.EuqalTo() + 0;
            if (obj.ToString() == "7" || BindEntity<HIS.Model.ZY_DOC_TRANSDEPT>.CreateInstanceDAL(oleDb).Exists(strWhere1))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 具体套餐明细
        /// </summary>
        /// <param name="tcid"></param>
        /// <returns></returns>
        public DataTable TcgetOrderItem(int tcid)
        {
            string sql = " select a.*,b.num as num from ( select * from  base_complex_detail b where b.complex_id=" + tcid + " and workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID + ") b left join vi_clinical_order a on b.service_item_id=a.item_id and b.workid=a.workid";
            return oleDb.GetDataTable(sql);
        }
        
        #endregion       

        #region 账单发送方法     
        /// <summary>
        /// 长期账单发送对应的后台整体操作
        /// </summary>
        /// <param name="order_id"></param>
        /// <param name="employee_id"></param>
        public bool longvaildaccountsend(List<int> order_id, long employee_id, int patlist)
        {
            try
            {
                List<int> orderid = order_id;
                employeeid = employee_id;               
                
                for (int arraynum = 0; arraynum < orderid.Count; arraynum++)
                {

                    ZY_DOC_ORDERRECORD orderrecord = new ZY_DOC_ORDERRECORD();
                    string strwhere1 = "order_id=" + orderid[arraynum];
                    orderrecord = BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetModel(orderid[arraynum]);
                    if (orderrecord.STATUS_FALG == 5) //防止同时打开多个窗口，临嘱点两次发送时产生两次费用的并发问题 201.3.22 add by heyan
                    {
                        continue;
                    }
                    time = XcDate.ServerDateTime.ToString("yyyy-MM-dd");
                    string strWhere = Tables.zy_nurse_orderexec.ORDER_ID + oleDb.EuqalTo() + order_id[arraynum] + oleDb.And() + Tables.zy_nurse_orderexec.PATIENT_ID + oleDb.EuqalTo() + patlist + oleDb.And() + Tables.zy_nurse_orderexec.EXEC_DATE + oleDb.EuqalTo() +"'" +time+"'";
                    bool serchRusult=BindEntity<HIS.Model.ZY_NURSE_ORDEREXEC>.CreateInstanceDAL(oleDb).Exists(strWhere);
                    if (serchRusult == false)
                    {
                        try
                        {
                            oleDb.BeginTransaction();
                            updatelongaccountflag(orderid[arraynum]);
                            insertorderexec(orderid[arraynum], employeeid);
                            insertlongaccount(orderid[arraynum], employee_id, XcDate.ServerDateTime);
                            oleDb.CommitTransaction();
                        }
                        catch
                        {
                            oleDb.RollbackTransaction();
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception(e.Message);                
            }
        }
        /// <summary>
        /// 临时账单发送时所对应的后台整体操作
        /// </summary>
        /// <param name="order_id"></param>
        /// <param name="employee_id"></param>
        public bool tempvalidaccountsend(List<int> order_id, long employee_id, int patlist)
        {
            try
            {
                List<int> orderid = order_id;
                employeeid = employee_id;  
                
                for (int arraynum = 0; arraynum < orderid.Count; arraynum++)
                {
                    ZY_DOC_ORDERRECORD orderrecord = new ZY_DOC_ORDERRECORD();
                    string strwhere1 = "order_id=" + orderid[arraynum];
                    orderrecord = BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetModel(orderid[arraynum]);
                    if (orderrecord.STATUS_FALG == 5) //防止同时打开多个窗口，临嘱点两次发送时产生两次费用的并发问题 201.3.22 add by heyan
                    {
                        continue;
                    }
                    time = XcDate.ServerDateTime.ToString("yyyy-MM-dd");
                    string strWhere = Tables.zy_nurse_orderexec.ORDER_ID + oleDb.EuqalTo() + order_id[arraynum] + oleDb.And() + Tables.zy_nurse_orderexec.PATIENT_ID + oleDb.EuqalTo() + patlist + oleDb.And() + Tables.zy_nurse_orderexec.EXEC_DATE + oleDb.EuqalTo() +"'" +time+"'";
                    bool serchRusult=BindEntity<HIS.Model.ZY_NURSE_ORDEREXEC>.CreateInstanceDAL(oleDb).Exists(strWhere);
                    if (serchRusult == false)
                    {
                        try
                        {
                            oleDb.BeginTransaction();
                            updatetempaccountflag(orderid[arraynum]);
                            insertorderexec(orderid[arraynum], employeeid);
                            inserttempaccount(orderid[arraynum], employee_id);
                            oleDb.CommitTransaction();
                        }
                        catch
                        {
                            oleDb.RollbackTransaction();
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                
                return true;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);              
                
            }
        }
        /// <summary>
        /// 临时账单发送时所对应的后台整体操作（账单补录）
        /// </summary>
        /// <param name="order_id"></param>
        /// <param name="employee_id"></param>
        public bool tempvalidaccountinsert(List<int> list,long employee_id, int patlist, int order_id, int order_type, int group_id)
        {
            try
            {
                int orderid = order_id;
                List<int> neworderid =list;
                int employeeid =Convert.ToInt32(employee_id);
                int ordertype = order_type;
                int groupid = group_id;
                oleDb.BeginTransaction();
                for (int arraynum = 0; arraynum < list.Count; arraynum++)
                {
                    updatetempaccountflag(list[arraynum]);
                    insertorderexec(list[arraynum], employeeid);
                    time = XcDate.ServerDateTime.ToString("yyyy-MM-dd");
                    string strWhere = Tables.zy_nurse_orderexec.ORDER_ID + oleDb.EuqalTo() + order_id + oleDb.And() + Tables.zy_nurse_orderexec.PATIENT_ID + oleDb.EuqalTo() + patlist + oleDb.And() + Tables.zy_nurse_orderexec.EXEC_DATE + oleDb.EuqalTo() + "'" + time + "'";                   
                    DateTime ServerDateTime = XcDate.ServerDateTime;
                    //int employeeid = Convert.ToInt32(employee_id);
                    Model.ZY_PresOrder presorder = new ZY_PresOrder();
                    //Model.ZY_PresMaster premaster = new ZY_PresMaster();
                    string strwhere1 = "order_id=" +list[arraynum];
                    string[] str1 = new string[21];
                    str1[0] = "patid";
                    str1[1] = "trans_date";
                    str1[2] = "order_bdate";
                    str1[3] = "order_doc";
                    str1[4] = "pres_deptid";
                    str1[5] = "exec_dept";
                    str1[6] = "orditem_id";
                    str1[7] = "makedicid";
                    str1[8] = "order_content";
                    str1[9] = "item_type";
                    str1[10] = "item_code";
                    str1[11] = "order_spec";
                    str1[12] = "item_type";
                    str1[13] = "unittype";
                    str1[14] = "frequency";
                    str1[15] = "amount";
                    str1[16] = "pres_amount";
                    str1[17] = "tc_id";
                    str1[18] = "order_id";
                    str1[19] = "group_id";
                    str1[20] = "order_type";

                    DataTable dt1 = BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetList(strwhere1, str1);
                    string string1 = "op_date=" + "'" + ServerDateTime + "'";
                    string string2 = "oprerator=" + employeeid;
                    BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strwhere1, string1, string2);
                    presorder.PatListID = Convert.ToInt32(dt1.Rows[0]["patid"].ToString());
                    presorder.MarkDate = Convert.ToDateTime(dt1.Rows[0]["trans_date"].ToString());
                    presorder.PresDate = Convert.ToDateTime(dt1.Rows[0]["order_bdate"].ToString());
                    presorder.PresDocCode = dt1.Rows[0]["order_doc"].ToString();
                    presorder.PresDeptCode = dt1.Rows[0]["pres_deptid"].ToString();
                    presorder.ExecDeptCode = dt1.Rows[0]["exec_dept"].ToString();
                    presorder.ItemID = Convert.ToInt32(dt1.Rows[0]["orditem_id"].ToString());
                    //presorder.ItemType = dt1.Rows[0]["item_code"].ToString();
                    presorder.Standard = dt1.Rows[0]["order_spec"].ToString();
                    presorder.ItemName = dt1.Rows[0]["order_content"].ToString();
                    presorder.order_id = orderid;
                    presorder.group_id = groupid;
                    presorder.order_type = ordertype;
                    int unit_type = Convert.ToInt32(dt1.Rows[0]["unittype"].ToString());
                    int item_type = Convert.ToInt32(dt1.Rows[0]["item_type"].ToString());
                    string frequency_time = dt1.Rows[0]["frequency"].ToString();
                   decimal num = Convert.ToDecimal(dt1.Rows[0]["amount"].ToString());
                    decimal pres_amount = Convert.ToDecimal(dt1.Rows[0]["pres_amount"].ToString());

                    string strWhere4 = "patlistid=" + presorder.PatListID;
                    string str4 = "patid";
                    presorder.PatID = Convert.ToInt32(BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetFieldValue(str4, strWhere4));

                    //string strWhere6 = "name='" + frequency_time + "'";
                    //string str6 = "execnum";
                    //int execNum = Convert.ToInt32(BindEntity<HIS.Model.Base_Frequency>.CreateInstanceDAL(oleDb).GetFieldValue(str6, strWhere6));

                    presorder.CostDate = XcDate.ServerDateTime;
                   // presorder.Drug_Flag = 1;
                    presorder.ChargeCode = Convert.ToString(employeeid);
                    presorder.Charge_Flag = 1;
                    string strWhere2 = "";
                    if (item_type == 0) //加物资后修改 heyan
                    {
                        strWhere2 = " itemid=" + presorder.ItemID + "  and order_type=" + item_type + " and drug_flag=1";
                        presorder.PresType = "0";
                        presorder.Drug_Flag = 0;
                    }
                    else
                    {
                        strWhere2 = "server_item_id=" + presorder.ItemID + " and drug_flag=0";
                        presorder.PresType = Convert.ToString(Convert.ToInt32(dt1.Rows[0]["tc_id"].ToString()) == 0 ? 4 : 5);
                        presorder.Drug_Flag = 1;
                    }

                    //string strWhere2 = "server_item_id=" + presorder.ItemID + " and drug_flag=0";
                    string[] str2 = new string[6];
                    str2[0] = "packunit";
                    str2[1] = "leastunit";
                    str2[2] = "packnum";
                    str2[3] = "buy_price";
                    str2[4] = "sell_price";
                    str2[5] = "STATITEM_CODE";
                    DataTable dt2 = BindEntity<object>.CreateInstanceDAL(oleDb, Views.VI_CLINICAL_ALL_ITEMS).GetList(strWhere2, str2);
                    presorder.PackUnit = dt2.Rows[0]["packunit"].ToString();
                    presorder.Unit = dt2.Rows[0]["leastunit"].ToString();
                    presorder.RelationNum = Convert.ToDecimal(dt2.Rows[0]["packnum"].ToString());
                    presorder.Buy_Price = Convert.ToDecimal(dt2.Rows[0]["buy_price"].ToString());
                    presorder.Sell_Price = Convert.ToDecimal(dt2.Rows[0]["sell_price"].ToString());
                    //presorder.PresType = Convert.ToString(Convert.ToInt32(dt1.Rows[0]["tc_id"].ToString()) == 0 ? 4 : 5);
                    presorder.ItemType = dt2.Rows[0]["STATITEM_CODE"].ToString();
                    presorder.Amount = Convert.ToDecimal(dt1.Rows[0]["amount"].ToString()) * presorder.RelationNum;
                    presorder.Tolal_Fee = Convert.ToDecimal(num * presorder.Sell_Price);
                    //插入费用表数据和结算表数据
                    presorder.Tolal_Fee = Convert.ToDecimal(presorder.Tolal_Fee.ToString("0.00"));
                    BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Add(presorder);
                    //premaster.PatListID = presorder.PatListID;
                    //premaster.PatID = presorder.PatID;
                    //premaster.PresType = Convert.ToString(0);
                    //BindEntity<ZY_PresMaster>.CreateInstanceDAL(oleDb).Add(premaster);
                    //string strWhere7 = "presorderid=" + presorder.PresOrderID;
                    //string updatefile = Tables.zy_presorder.PRESMASTERID + oleDb.EuqalTo() + premaster.PresMasterID;
                    //BindEntity<HIS.Model.ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(strWhere7, updatefile);
                    //return;      

                }
                oleDb.CommitTransaction();
                return true;
            }
            catch (Exception e)
            {
                oleDb.RollbackTransaction();
                throw new Exception(e.Message);              
                
            }
        }
       
        #endregion
        
        #region 账单状态更新        
        /// <summary>
        /// 停长期账单标识位
        /// </summary>
        public bool updatelongaccountflag(List<int> order_id)
        {
            try
            {
                List<int> orderid = order_id;
                string strWhere = Tables.zy_doc_orderrecord.ORDER_ID + oleDb.In() + "(";
                for (int i = 0; i <orderid.Count; i++)
                {
                    if (i != orderid.Count - 1)
                    {
                        strWhere +=orderid[i] + ",";
                    }
                    else
                    {
                        strWhere += orderid[i] + ")";
                    }
                }                
                string strSet =Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + 5;
                BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strWhere, strSet);
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 修改长期账单发送标识位
        /// </summary>
        /// <param name="orderid"></param>
        private void updatelongaccountflag(int orderid)//10月21日增加
        {
            string strWhere3 = " order_id=" + orderid;
            string strSet = Tables.zy_doc_orderrecord.NOEXE_FLAG + oleDb.EuqalTo() + 1;
            BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strWhere3, strSet);
            return;            
        }
        /// <summary>
        /// 修改临时账单发送标识位
        /// </summary>
        /// <param name="orderid"></param>
        private void updatetempaccountflag(int orderid)
        {
            string strWhere2 = " order_id=" + orderid;
            string strSet =Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + 5;            
            BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strWhere2, strSet);
            return;
        }
        #endregion

        #region 医嘱执行表写入记录
        /// <summary>
        /// 医嘱执行中写入执行记录
        /// </summary>
        private void insertorderexec(int orderid, long employeeid)
        {
            try
            {
                string strWhere = Tables.zy_doc_orderrecord.ORDER_ID + oleDb.EuqalTo() + orderid;
                object obj = BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetFieldValue(Tables.zy_doc_orderrecord.PATID, strWhere);
                int patlistid = int.Parse(obj.ToString());
                time = XcDate.ServerDateTime.ToString("yyyy-MM-dd");

                string[] filedname = new string[4];
                filedname[0] = Tables.zy_nurse_orderexec.ORDER_ID;
                filedname[1] = Tables.zy_nurse_orderexec.EXEC_DATE;
                filedname[2] = Tables.zy_nurse_orderexec.EXEC_USER;
                filedname[3] = Tables.zy_nurse_orderexec.PATIENT_ID;

                string[] values = new string[4];
                values[0] = orderid.ToString();
                values[1] = "'" + time + "'";
                values[2] = employeeid.ToString();
                values[3] = patlistid.ToString();

                bool[] questiong=new bool[4];
                questiong[0]=false;
                questiong[1]=false;
                questiong[2]=false;
                questiong[3]=false;

                BindEntity<HIS.Model.ZY_NURSE_ORDEREXEC>.CreateInstanceDAL(oleDb).Add(filedname, values, questiong);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }     
        #endregion       
       
        #region 长期账单费用记录插入
        /// <summary>
        /// 长期账单发送(总体)
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="employee_id"></param>
        /// <param name="server_datetime"></param>
        private void insertlongaccount(int orderid, long employee_id,DateTime server_datetime)
        {
            string ServerDateTime = server_datetime.ToString("yyyy-MM-dd");
            int employeeid = Convert.ToInt32(employee_id);
            string strwhere = "order_id=" + orderid;
            int itemid;
            object obj = BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetFieldValue("tc_id", strwhere);
            int tcid = int.Parse(obj.ToString());
            if (tcid != 0)
            {
                object obj1 = BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetFieldValue("orditem_id", strwhere);
                int orditem_id = int.Parse(obj1.ToString());

                string strWhere2 = "server_item_id=" +orditem_id + " and drug_flag=0";
                object obj2 =BindEntity<object>.CreateInstanceDAL(oleDb, Views.VI_CLINICAL_ALL_ITEMS).GetFieldValue("itemid",strWhere2);
                int conitemid = int.Parse(obj2.ToString());
                DataTable dt = TcgetOrderItem(orditem_id);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    itemid = Convert.ToInt32(dt.Rows[i]["item_id"].ToString());
                    insertconcretlongaccount(orderid, itemid, ServerDateTime,conitemid);
                }
                string string1 = "op_date='" + server_datetime + "'";
                string string2 = "oprerator=" + employeeid;
                BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strwhere, string1, string2);
            }
            else
            {
                insertconcretlongaccount(orderid, employeeid);
            }         
        }
        /// <summary>
        /// 套餐账单发送
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="employee_id"></param>
        private void insertconcretlongaccount(int orderid, int item_id,string Server_DateTime,int conitem_id)
        {
            Model.ZY_PresOrder presorder = new ZY_PresOrder();
            //Model.ZY_PresMaster premaster = new ZY_PresMaster();
            int itemid = item_id;            
            string  ServerDateTime =Server_DateTime;
            string strwhere1 = "order_id=" + orderid;
            string[] str1 = new string[21];
            str1[0] = "patid";
            str1[1] = "trans_date";
            str1[2] = "order_bdate";
            str1[3] = "order_doc";
            str1[4] = "pres_deptid";
            str1[5] = "exec_dept";
            str1[6] = "orditem_id";
            str1[7] = "makedicid";
            str1[8] = "order_content";
            str1[9] = "item_type";
            str1[10] = "item_code";
            str1[11] = "order_spec";
            str1[12] = "item_type";
            str1[13] = "unittype";
            str1[14] = "frequency";
            str1[15] = "amount";
            str1[16] = "pres_amount";
            str1[17] = "tc_id";
            str1[18] = "order_id";
            str1[19] = "group_id";
            str1[20] = "order_type";

            DataTable dt1 = BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetList(strwhere1, str1);
            //string string1 = "op_date=" + "'" + ServerDateTime + "'";
            //string string2 = "oprerator=" + employeeid;
            //BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strwhere1, string1, string2);
            presorder.PatListID = Convert.ToInt32(dt1.Rows[0]["patid"].ToString());
            presorder.MarkDate = Convert.ToDateTime(dt1.Rows[0]["trans_date"].ToString());
            presorder.PresDate = Convert.ToDateTime(dt1.Rows[0]["order_bdate"].ToString());
            presorder.PresDocCode = dt1.Rows[0]["order_doc"].ToString();
            presorder.PresDeptCode = dt1.Rows[0]["pres_deptid"].ToString();
            presorder.ExecDeptCode = dt1.Rows[0]["exec_dept"].ToString();
            presorder.ItemID = conitem_id;
            //presorder.ItemType = dt1.Rows[0]["item_code"].ToString();
            presorder.Standard = dt1.Rows[0]["order_spec"].ToString();
            //presorder.ItemName = dt1.Rows[0]["order_content"].ToString();
            presorder.order_id = Convert.ToInt32(dt1.Rows[0]["order_id"].ToString());
            presorder.group_id = Convert.ToInt32(dt1.Rows[0]["group_id"].ToString());
            presorder.order_type = Convert.ToInt32(dt1.Rows[0]["order_type"].ToString());
            int unit_type = Convert.ToInt32(dt1.Rows[0]["unittype"].ToString());
            int item_type = Convert.ToInt32(dt1.Rows[0]["item_type"].ToString());
            //string frequency_time = dt1.Rows[0]["frequency"].ToString();
            decimal num = Convert.ToDecimal(dt1.Rows[0]["amount"].ToString());
            decimal pres_amount = Convert.ToDecimal(dt1.Rows[0]["pres_amount"].ToString());

            string strWhere4 = "patlistid=" + presorder.PatListID;
            string str4 = "patid";
            presorder.PatID = Convert.ToInt32(BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetFieldValue(str4, strWhere4));

            //string strWhere6 = "name='" + frequency_time + "'";
            //string str6 = "execnum";
            //int execNum = Convert.ToInt32(BindEntity<HIS.Model.Base_Frequency>.CreateInstanceDAL(oleDb).GetFieldValue(str6, strWhere6));

            presorder.CostDate = XcDate.ServerDateTime;
            presorder.Drug_Flag = 1;
            presorder.ChargeCode = Convert.ToString(employeeid);
            presorder.Charge_Flag = 1;

            string strWhere2 = "server_item_id=" +itemid + " and drug_flag=0";
            string[] str2 = new string[8];
            str2[0] = "packunit";
            str2[1] = "leastunit";
            str2[2] = "packnum";
            str2[3] = "buy_price";
            str2[4] = "sell_price";
            str2[5] = "STATITEM_CODE";
            str2[6] = "itemname";
            str2[7] = "itemid";
            DataTable dt2 = BindEntity<object>.CreateInstanceDAL(oleDb, Views.VI_CLINICAL_ALL_ITEMS).GetList(strWhere2, str2);
            presorder.PackUnit = dt2.Rows[0]["packunit"].ToString();
            presorder.Unit = dt2.Rows[0]["leastunit"].ToString();
            presorder.RelationNum = Convert.ToDecimal(dt2.Rows[0]["packnum"].ToString());
            presorder.Buy_Price = Convert.ToDecimal(dt2.Rows[0]["buy_price"].ToString());
            presorder.ItemType = dt2.Rows[0]["STATITEM_CODE"].ToString();
            presorder.ItemName = dt2.Rows[0]["itemname"].ToString();
            //presorder.ItemID = Convert.ToInt32(dt2.Rows[0]["itemid"].ToString());
            presorder.Sell_Price = Convert.ToDecimal(dt2.Rows[0]["sell_price"].ToString());
            presorder.PresType = "4";//Convert.ToString(Convert.ToInt32(dt1.Rows[0]["tc_id"].ToString()) == 0 ? 4 : 5);
            presorder.Amount =Convert.ToDecimal(dt1.Rows[0]["amount"].ToString()) * presorder.RelationNum; //加物资后修改的，可能含量系数不为1 heyan
            presorder.Tolal_Fee = Convert.ToDecimal(num * presorder.Sell_Price);

            //插入费用表数据和结算表数据
            presorder.Tolal_Fee = Convert.ToDecimal(presorder.Tolal_Fee.ToString("0.00"));
            BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Add(presorder);
            //premaster.PatListID = presorder.PatListID;
            //premaster.PatID = presorder.PatID;
            //premaster.PresType = Convert.ToString(0);
            //BindEntity<ZY_PresMaster>.CreateInstanceDAL(oleDb).Add(premaster);
            //string strWhere7 = "presorderid=" + presorder.PresOrderID;
            //string updatefile = Tables.zy_presorder.PRESMASTERID + oleDb.EuqalTo() + premaster.PresMasterID;
            //BindEntity<HIS.Model.ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(strWhere7, updatefile);
            return;
        }
        /// <summary>
        /// 非套餐账单发送
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="employee_id"></param>
        private void insertconcretlongaccount(int orderid, long employee_id)
        {
            Model.ZY_PresOrder presorder = new ZY_PresOrder();
            //Model.ZY_PresMaster premaster = new ZY_PresMaster();
            int employeeid = Convert.ToInt32(employee_id);
            DateTime ServerDateTime = XcDate.ServerDateTime;
            string strwhere1 = "order_id=" + orderid;
            string[] str1 = new string[21];
            str1[0] = "patid";
            str1[1] = "trans_date";
            str1[2] = "order_bdate";
            str1[3] = "order_doc";
            str1[4] = "pres_deptid";
            str1[5] = "exec_dept";
            str1[6] = "orditem_id";
            str1[7] = "makedicid";
            str1[8] = "order_content";
            str1[9] = "item_type";
            str1[10] = "item_code";
            str1[11] = "order_spec";
            str1[12] = "item_type";
            str1[13] = "unittype";
            str1[14] = "frequency";
            str1[15] = "amount";
            str1[16] = "pres_amount";
            str1[17] = "tc_id";
            str1[18] = "order_id";
            str1[19] = "group_id";
            str1[20] = "order_type";

            DataTable dt1 = BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetList(strwhere1, str1);
            string string1 = "op_date=" + "'" + ServerDateTime + "'";
            string string2 = "oprerator=" + employeeid;
            BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strwhere1, string1, string2);
            presorder.PatListID = Convert.ToInt32(dt1.Rows[0]["patid"].ToString());
            presorder.MarkDate = Convert.ToDateTime(dt1.Rows[0]["trans_date"].ToString());
            presorder.PresDate = Convert.ToDateTime(dt1.Rows[0]["order_bdate"].ToString());
            presorder.PresDocCode = dt1.Rows[0]["order_doc"].ToString();
            presorder.PresDeptCode = dt1.Rows[0]["pres_deptid"].ToString();
            presorder.ExecDeptCode = dt1.Rows[0]["exec_dept"].ToString();
            presorder.ItemID =Convert.ToInt32(dt1.Rows[0]["orditem_id"].ToString());
            //presorder.ItemType = dt1.Rows[0]["item_code"].ToString();
            presorder.Standard = dt1.Rows[0]["order_spec"].ToString();
            presorder.ItemName = dt1.Rows[0]["order_content"].ToString();
            presorder.order_id = Convert.ToInt32(dt1.Rows[0]["order_id"].ToString());
            presorder.group_id = Convert.ToInt32(dt1.Rows[0]["group_id"].ToString());
            presorder.order_type = Convert.ToInt32(dt1.Rows[0]["order_type"].ToString());
            int unit_type = Convert.ToInt32(dt1.Rows[0]["unittype"].ToString());
            int item_type = Convert.ToInt32(dt1.Rows[0]["item_type"].ToString());
            //string frequency_time = dt1.Rows[0]["frequency"].ToString();
           decimal num = Convert.ToDecimal(dt1.Rows[0]["amount"].ToString());
            decimal pres_amount = Convert.ToDecimal(dt1.Rows[0]["pres_amount"].ToString());

            string strWhere4 = "patlistid=" + presorder.PatListID;
            string str4 = "patid";
            presorder.PatID = Convert.ToInt32(BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetFieldValue(str4, strWhere4));

            //string strWhere6 = "name='" + frequency_time + "'";
            //string str6 = "execnum";
            //int execNum = Convert.ToInt32(BindEntity<HIS.Model.Base_Frequency>.CreateInstanceDAL(oleDb).GetFieldValue(str6, strWhere6));

            presorder.CostDate = XcDate.ServerDateTime;
           // presorder.Drug_Flag = 1;
            presorder.ChargeCode = Convert.ToString(employeeid);
            presorder.Charge_Flag = 1;
            string strWhere2 = "";
            if (item_type == 0)
            {
                strWhere2 = " itemid=" + presorder.ItemID + "  and order_type=" + item_type + " and drug_flag=1";
                presorder.PresType = "0";
                presorder.Drug_Flag = 0;
            }
            else
            {
                strWhere2 = "server_item_id=" + presorder.ItemID + " and drug_flag=0";
                presorder.PresType = Convert.ToString(Convert.ToInt32(dt1.Rows[0]["tc_id"].ToString()) == 0 ? 4 : 5);
                presorder.Drug_Flag = 1;
            }
            //string strWhere2 = "server_item_id=" + presorder.ItemID + " and drug_flag=0";
            string[] str2 = new string[6];
            str2[0] = "packunit";
            str2[1] = "leastunit";
            str2[2] = "packnum";
            str2[3] = "buy_price";
            str2[4] = "sell_price";
            str2[5] = "STATITEM_CODE";
            DataTable dt2 = BindEntity<object>.CreateInstanceDAL(oleDb, Views.VI_CLINICAL_ALL_ITEMS).GetList(strWhere2, str2);
            presorder.PackUnit = dt2.Rows[0]["packunit"].ToString();
            presorder.Unit = dt2.Rows[0]["leastunit"].ToString();
            presorder.RelationNum = Convert.ToDecimal(dt2.Rows[0]["packnum"].ToString());
            presorder.Buy_Price = Convert.ToDecimal(dt2.Rows[0]["buy_price"].ToString());
            presorder.ItemType = dt2.Rows[0]["STATITEM_CODE"].ToString();
            presorder.Sell_Price = Convert.ToDecimal(dt2.Rows[0]["sell_price"].ToString());
           // presorder.PresType = Convert.ToString(Convert.ToInt32(dt1.Rows[0]["tc_id"].ToString()) == 0 ? 4 : 5);
            presorder.Amount = Convert.ToDecimal(dt1.Rows[0]["amount"].ToString()) * presorder.RelationNum;
            presorder.Tolal_Fee = Convert.ToDecimal(num * presorder.Sell_Price);

            //插入费用表数据和结算表数据
            presorder.Tolal_Fee = Convert.ToDecimal(presorder.Tolal_Fee.ToString("0.00"));
            BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Add(presorder);
            //premaster.PatListID = presorder.PatListID;
            //premaster.PatID = presorder.PatID;
            //premaster.PresType = Convert.ToString(0);
            //BindEntity<ZY_PresMaster>.CreateInstanceDAL(oleDb).Add(premaster);
            //string strWhere7 = "presorderid=" + presorder.PresOrderID;
            //string updatefile = Tables.zy_presorder.PRESMASTERID + oleDb.EuqalTo() + premaster.PresMasterID;
            //BindEntity<HIS.Model.ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(strWhere7, updatefile);
            return;      
        }
        #endregion

        #region 临时账单费用记录插入
        private void inserttempaccount(int orderid, long employee_id)
        {
            DateTime ServerDateTime =XcDate.ServerDateTime;
            int employeeid = Convert.ToInt32(employee_id);
            Model.ZY_PresOrder presorder = new ZY_PresOrder();
            //Model.ZY_PresMaster premaster = new ZY_PresMaster();
            string strwhere1 = "order_id=" + orderid;
            string[] str1 = new string[21];
            str1[0] = "patid";
            str1[1] = "trans_date";
            str1[2] = "order_bdate";
            str1[3] = "order_doc";
            str1[4] = "pres_deptid";
            str1[5] = "exec_dept";
            str1[6] = "orditem_id";
            str1[7] = "makedicid";
            str1[8] = "order_content";
            str1[9] = "item_type";
            str1[10] = "item_code";
            str1[11] = "order_spec";
            str1[12] = "item_type";
            str1[13] = "unittype";
            str1[14] = "frequency";
            str1[15] = "amount";
            str1[16] = "pres_amount";
            str1[17] = "tc_id";
            str1[18] = "order_id";
            str1[19] = "group_id";
            str1[20] = "order_type";

            DataTable dt1 = BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetList(strwhere1, str1);
            string string1 = "op_date=" + "'" + ServerDateTime + "'";
            string string2 = "oprerator=" + employeeid;
            BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strwhere1, string1, string2);
            presorder.PatListID = Convert.ToInt32(dt1.Rows[0]["patid"].ToString());
            presorder.MarkDate = Convert.ToDateTime(dt1.Rows[0]["trans_date"].ToString());
            presorder.PresDate = Convert.ToDateTime(dt1.Rows[0]["order_bdate"].ToString());
            presorder.PresDocCode = dt1.Rows[0]["order_doc"].ToString();
            presorder.PresDeptCode = dt1.Rows[0]["pres_deptid"].ToString();
            presorder.ExecDeptCode = dt1.Rows[0]["exec_dept"].ToString();
            presorder.ItemID = Convert.ToInt32(dt1.Rows[0]["orditem_id"].ToString());
            //presorder.ItemType = dt1.Rows[0]["item_code"].ToString();
            presorder.Standard = dt1.Rows[0]["order_spec"].ToString();
            presorder.ItemName = dt1.Rows[0]["order_content"].ToString();
            presorder.order_id = Convert.ToInt32(dt1.Rows[0]["order_id"].ToString());
            presorder.group_id = Convert.ToInt32(dt1.Rows[0]["group_id"].ToString());
            presorder.order_type = Convert.ToInt32(dt1.Rows[0]["order_type"].ToString());
            int unit_type = Convert.ToInt32(dt1.Rows[0]["unittype"].ToString());
            int item_type = Convert.ToInt32(dt1.Rows[0]["item_type"].ToString());
            string frequency_time = dt1.Rows[0]["frequency"].ToString();
            decimal num = Convert.ToDecimal(dt1.Rows[0]["amount"].ToString());
            decimal pres_amount = Convert.ToDecimal(dt1.Rows[0]["pres_amount"].ToString());

            string strWhere4 = "patlistid=" + presorder.PatListID;
            string str4 = "patid";
            presorder.PatID = Convert.ToInt32(BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetFieldValue(str4, strWhere4));
                  
            presorder.CostDate = XcDate.ServerDateTime;
           // presorder.Drug_Flag = 1;
            presorder.ChargeCode = Convert.ToString(employeeid);
            presorder.Charge_Flag = 1;
            string strWhere2 = "";
            if (item_type == 0)
            {
                strWhere2 = " itemid=" + presorder.ItemID + "  and order_type=" + item_type + " and drug_flag=1";
                presorder.PresType = "0";
                presorder.Drug_Flag = 0;
            }
            else
            {
                strWhere2 = "server_item_id=" + presorder.ItemID + " and drug_flag=0";
                presorder.PresType = Convert.ToString(Convert.ToInt32(dt1.Rows[0]["tc_id"].ToString()) == 0 ? 4 : 5);
                presorder.Drug_Flag = 1;
            }
            string[] str2 = new string[6];
            str2[0] = "packunit";
            str2[1] = "leastunit";
            str2[2] = "packnum";
            str2[3] = "buy_price";
            str2[4] = "sell_price";
            str2[5] = "STATITEM_CODE";
            DataTable dt2 = BindEntity<object>.CreateInstanceDAL(oleDb, Views.VI_CLINICAL_ALL_ITEMS).GetList(strWhere2, str2);
            presorder.PackUnit = dt2.Rows[0]["packunit"].ToString();
            presorder.Unit = dt2.Rows[0]["leastunit"].ToString();
            presorder.RelationNum = Convert.ToDecimal(dt2.Rows[0]["packnum"].ToString());
            presorder.Buy_Price = Convert.ToDecimal(dt2.Rows[0]["buy_price"].ToString());
            presorder.Sell_Price = Convert.ToDecimal(dt2.Rows[0]["sell_price"].ToString());
           // presorder.PresType = Convert.ToString(Convert.ToInt32(dt1.Rows[0]["tc_id"].ToString()) == 0 ? 4 : 5);
            presorder.ItemType = dt2.Rows[0]["STATITEM_CODE"].ToString();
            presorder.Amount = Convert.ToDecimal(dt1.Rows[0]["amount"].ToString())*presorder.RelationNum;
            presorder.Tolal_Fee = Convert.ToDecimal(num * presorder.Sell_Price );
            //插入费用表数据和结算表数据
            presorder.Tolal_Fee = Convert.ToDecimal(presorder.Tolal_Fee.ToString("0.00"));
            BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Add(presorder);
            //premaster.PatListID = presorder.PatListID;
            //premaster.PatID = presorder.PatID;
            //premaster.PresType = Convert.ToString(0);
            //BindEntity<ZY_PresMaster>.CreateInstanceDAL(oleDb).Add(premaster);
            //string strWhere7 = "presorderid=" + presorder.PresOrderID;
            //string updatefile = Tables.zy_presorder.PRESMASTERID + oleDb.EuqalTo() + premaster.PresMasterID;
            //BindEntity<HIS.Model.ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(strWhere7, updatefile);
            return;      
        }
        #endregion     
        
        #region 费用冲正
        /// <summary>
        /// 获取冲正的presorderid
        /// </summary>
        /// <param name="order_id"></param>
        /// <returns></returns>
        public DataTable getPresorder(List<int> order_id)
        {
            try
            {
                List<int> orderid = order_id;
                string strWhere = Tables.zy_presorder.RECORD_FLAG+oleDb.EuqalTo()+0+oleDb.And()+Tables.zy_presorder.ORDER_ID+ oleDb.In() + "(";
                for (int i = 0; i <orderid.Count; i++)
                {
                    if (i != orderid.Count - 1)
                    {
                        strWhere +=orderid[i] + ",";
                    }
                    else
                    {
                        strWhere +=orderid[i] + ") order by costdate";
                    }
                }                
                DataTable dt = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetList(strWhere);
                return dt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 数据源
        /// </summary>
        /// <param name="presorder_id"></param>
        /// <returns></returns>
        public DataTable getCanaccount(List<int> presorder_id)
        {
            try
            {
                List<int> presorderidlist = presorder_id;
                DataTable dt1 = getcanaccount1(presorderidlist);
                DataTable dt2 = getcanaccount2(presorderidlist);
                DataTable dt3 = getcanaccount3(dt2);
                if (dt2.Rows.Count != 0)
                {
                    DataRow[] dr2 = dt2.Select();
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        dt1.Rows.Add(dr2[i].ItemArray);
                    }
                }
                if (dt3!=null&&dt3.Rows.Count != 0)
                {
                    DataRow[] dr3 = dt3.Select();
                    for (int i = 0; i < dt3.Rows.Count; i++)
                    {
                        dt1.Rows.Add(dr3[i].ItemArray);
                    }
                }
                else
                {
                    return dt1;
                }
                return dt1;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 获取被冲正（原始）的记录
        /// </summary>
        /// <param name="presorder_id"></param>
        /// <returns></returns>
        public DataTable getcanaccount1(List<int> presorder_id)
        {
            try
            {
                List<int> presorderid = presorder_id;
                string strWhere1 =Tables.zy_presorder.RECORD_FLAG+oleDb.EuqalTo()+0+oleDb.And()+Tables.zy_presorder.PRESORDERID + oleDb.In() + "(";
                for (int i = 0; i < presorderid.Count; i++)
                {
                    if (i != presorderid.Count - 1)
                    {
                        strWhere1 += presorderid[i] + ",";
                    }
                    else
                    {
                        strWhere1 += presorderid[i] + ")";
                    }
                }
                DataTable dt = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetList(strWhere1);
                return dt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }            
        }
        /// <summary>
        /// 获取冲正后记录
        /// </summary>
        /// <param name="presorder_id"></param>
        /// <returns></returns>
        public DataTable getcanaccount2(List<int> presorder_id)
        {
            try
            {
                List<int> presorderid = presorder_id;
                string strWhere2 =Tables.zy_presorder.OLDID + oleDb.In() + "(";
                for (int i = 0; i < presorderid.Count; i++)
                {
                    if (i != presorderid.Count - 1)
                    {
                        strWhere2 += presorderid[i] + ",";
                    }
                    else
                    {
                        strWhere2 += presorderid[i] + ")";
                    }
                }
                DataTable dt = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetList(strWhere2);
                return dt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 获取取消冲正记录（冲正ID)
        /// </summary>
        /// <param name="presorder_id"></param>
        /// <returns></returns>
        public DataTable getcanaccount3(DataTable presorder_id)
        {
            try
            {
                DataTable  presorderid = presorder_id;
                List<int> oldpresorderid = new List<int>();               
                for (int i = 0; i < presorderid.Rows.Count; i++)
                {
                    int orderid=Convert.ToInt32(presorderid.Rows[i][0].ToString());
                    oldpresorderid.Add(orderid);
                }
                if (oldpresorderid.Count != 0)
                {
                    string strWhere1 = Tables.zy_presorder.OLDID + oleDb.In() + "(";
                    for (int i = 0; i < oldpresorderid.Count; i++)
                    {
                        if (i != oldpresorderid.Count - 1)
                        {
                            strWhere1 += oldpresorderid[i] + ",";
                        }
                        else
                        {
                            strWhere1 += oldpresorderid[i] + ")";
                        }
                    }
                    DataTable dt = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetList(strWhere1);
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }   
        /// <summary>
        /// 判断数量是否可以进行冲正
        /// </summary>
        /// <param name="presorder_id"></param>
        /// <returns></returns>
        public bool getresult(List<int> presorder_id)
        {
            List<int> presorderid = presorder_id;
            List<decimal> amountlist = new List<decimal>();
            try
            {
                decimal amount1;
                decimal amount2;

                string strWhere1 = Tables.zy_presorder.PRESORDERID + oleDb.EuqalTo() + presorderid[0] + oleDb.And() + Tables.zy_presorder.RECORD_FLAG + oleDb.EuqalTo() + 0;
                object obj1 = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetFieldValue("amount", strWhere1);
                if (obj1 != null)
                {
                    amount1 = decimal.Parse(obj1.ToString());
                }

                else
                {
                    amount1=0;
                }
                string strWhere2 = Tables.zy_presorder.OLDID + oleDb.EuqalTo() + presorderid[0] + oleDb.And() + Tables.zy_presorder.RECORD_FLAG + oleDb.EuqalTo() + 1;
                object obj2 = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetFieldValue("sum(amount)", strWhere2);
                if (obj2 != null && obj2 != DBNull.Value)
                {
                    amount2 = decimal.Parse(obj2.ToString());
                }
                else
                {
                    amount2 = 0;
                }
                decimal amount = amount1 + amount2;
                //amountlist.Add(amount);    
                if (amount > 0)
                    return true;
                else
                    return false;
              //return amountlist;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        ///判断数量是否可以进行冲正操作
        /// </summary>
        /// <param name="presorder_id"></param>
        /// <returns></returns>
        public bool getresultlist(List<int> presorder_id)
        {
            List<int> presorderid = presorder_id;       
            try
            {
                for (int i = 0; i < presorderid.Count; i++)
                {
                    string strWhere2 = Tables.zy_presorder.OLDID + oleDb.EuqalTo() + presorderid[i] + oleDb.And() + Tables.zy_presorder.RECORD_FLAG + oleDb.EuqalTo() + 1;
                    object obj2 = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetFieldValue("sum(amount)", strWhere2);
                    if (obj2 != null && obj2 != DBNull.Value)
                    {
                        continue;                        
                    }
                    else
                    {
                       return true;                       
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);               
            }
        }
        /// <summary>
        /// 判断是否可以成组冲正
        /// </summary>
        /// <returns></returns>
        public bool IsGroupCancelFee(List<int> presorder_id,int deptid)
        {
            List<int> presorderid = presorder_id;
            try
            {            
                
                for (int i = 0; i < presorderid.Count; i++)
                {
                    string strWhere1 = Tables.zy_presorder.PRESORDERID + oleDb.EuqalTo() + presorderid[i] + oleDb.And()+Tables.zy_presorder.PRESDEPTCODE + oleDb.EuqalTo() + "'"+deptid+"'";
                    if (BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Exists(strWhere1))
                    {
                        string strWhere2 = Tables.zy_presorder.OLDID + oleDb.EuqalTo() + presorderid[i] + oleDb.And() + Tables.zy_presorder.RECORD_FLAG + oleDb.EuqalTo() + 1;
                        if (BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Exists(strWhere2))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 判断数量是否可以进行冲正（单条医嘱）
        /// </summary>
        /// <param name="presorder_id"></param>
        /// <returns></returns>
        public decimal getsingleresult(List<int> presorder_id)
        {
            try
            {
                decimal amount1;
                decimal amount2;
                List<int> presorderid = presorder_id;
                string strWhere1 = Tables.zy_presorder.PRESORDERID + oleDb.EuqalTo() + presorderid[0] + oleDb.And() + Tables.zy_presorder.RECORD_FLAG + oleDb.EuqalTo() + 0;
                object obj1 = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetFieldValue("amount", strWhere1);
                if (obj1 != null)
                {
                    amount1 = decimal.Parse(obj1.ToString());
                }
                else
                {
                    amount1=0;
                }
                string strWhere2 = Tables.zy_presorder.OLDID + oleDb.EuqalTo() + presorderid[0] + oleDb.And() + Tables.zy_presorder.RECORD_FLAG + oleDb.EuqalTo() + 1;
                object obj2 = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetFieldValue("sum(amount)", strWhere2);
                if (obj2 != null && obj2!=DBNull.Value)
                {
                    amount2 = decimal.Parse(obj2.ToString());
                }
                else
                {
                    amount2 = 0;
                }
                decimal amount = amount1 + amount2;
                return amount;                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 判断数量是否可以进行冲正（单条医嘱）
        /// </summary>
        /// <param name="presorder_id"></param>
        /// <returns></returns>
        public decimal getspecsingleresult(List<int> presorder_id, int deptid)
        {
            try
            {
                string strWhere3 = Tables.zy_presorder.PRESORDERID + oleDb.EuqalTo() + presorder_id[0] + oleDb.And() + Tables.zy_presorder.PRESDEPTCODE + oleDb.EuqalTo() + "'" + deptid + "'";
                if (BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Exists(strWhere3))
                {
                    decimal amount1;
                    decimal amount2;
                    List<int> presorderid = presorder_id;
                    string strWhere1 = Tables.zy_presorder.PRESORDERID + oleDb.EuqalTo() + presorderid[0] + oleDb.And() + Tables.zy_presorder.RECORD_FLAG + oleDb.EuqalTo() + 0;
                    object obj1 = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetFieldValue("amount", strWhere1);
                    if (obj1 != null)
                    {
                        amount1 = decimal.Parse(obj1.ToString());
                    }
                    else
                    {
                        amount1 = 0;
                    }
                    string strWhere2 = Tables.zy_presorder.OLDID + oleDb.EuqalTo() + presorderid[0] + oleDb.And() + Tables.zy_presorder.RECORD_FLAG + oleDb.EuqalTo() + 1;
                    object obj2 = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetFieldValue("sum(amount)", strWhere2);
                    if (obj2 != null && obj2 != DBNull.Value)
                    {
                        amount2 = decimal.Parse(obj2.ToString());
                    }
                    else
                    {
                        amount2 = 0;
                    }
                    decimal amount = amount1 + amount2;
                    return amount;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 判断数量是否可以进行冲正（数量）
        /// </summary>
        /// <param name="presorder_id"></param>
        /// <returns></returns>
        public bool getamountresult(List<int> presorder_id,decimal amount)
        {
            try
            {
                decimal amount1;
                decimal amount2;
                decimal amount3 = amount;
                List<int> presorderid = presorder_id;
                string strWhere1 = Tables.zy_presorder.PRESORDERID + oleDb.EuqalTo() + presorderid[0] + oleDb.And() + Tables.zy_presorder.RECORD_FLAG + oleDb.EuqalTo() + 0;
                object obj1 = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetFieldValue("amount", strWhere1);
                if (obj1 != null)
                {
                    amount1 = decimal.Parse(obj1.ToString());
                }
                else
                {
                    return false;
                }
                
                string strWhere2 = Tables.zy_presorder.OLDID + oleDb.EuqalTo() + presorderid[0] + oleDb.And() + Tables.zy_presorder.RECORD_FLAG + oleDb.EuqalTo() + 1;
                object obj2 = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetFieldValue("sum(amount)", strWhere2);
                if (obj2 != null && obj2!=DBNull.Value)
                {
                    amount2 = decimal.Parse(obj2.ToString());
                }
                else
                {
                    amount2 = 0;
                }
                decimal allamount = amount1 + amount2 + (-1) * amount3;
                if (allamount >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 判断数量是否可以取消冲正
        /// </summary>
        /// <param name="presorder_id"></param>
        /// <returns></returns>
        public bool getexitresult(List<int> presorder_id)
        {
            try
            {
                decimal amount1;
                decimal amount2;
                List<int> presorderid = presorder_id;
                //string strWhere1 =Tables.zy_presorder.RECORD_FLAG+oleDb.EuqalTo()+0+Tables.zy_presorder.PRESORDERID + oleDb.EuqalTo() + presorderid[0];
                //object obj1 = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetFieldValue("amount", strWhere1);
                //if (obj1 != null)
                //{
                //    amount1 = decimal.Parse(obj1.ToString());
                //}
                //else
                //{
                //    return false;
                //}
                string strWhere2 =Tables.zy_presorder.RECORD_FLAG+oleDb.EuqalTo()+1+oleDb.And()+Tables.zy_presorder.OLDID + oleDb.EuqalTo() + presorderid[0];
                object obj2 = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetFieldValue("amount", strWhere2);
                if (obj2 != null)
                {
                    amount2 = decimal.Parse(obj2.ToString());
                }
                else
                {
                    amount2 = 0;
                }
                //decimal amount = amount1 + amount2;
                if (amount2 <=0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 判断数量是否可以进行冲正（数量）
        /// </summary>
        /// <param name="presorder_id"></param>
        /// <returns></returns>
        public bool getspecamountresult(List<int> presorder_id, decimal amount, int deptid)
        {
            try
            {
                string strWhere3 = Tables.zy_presorder.PRESORDERID + oleDb.EuqalTo() + presorder_id[0] + oleDb.And() + Tables.zy_presorder.PRESDEPTCODE + oleDb.EuqalTo() + "'" + deptid + "'";
                if (BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Exists(strWhere3))
                {
                    decimal amount1;
                    decimal amount2;
                    decimal amount3 = amount;
                    List<int> presorderid = presorder_id;
                    string strWhere1 = Tables.zy_presorder.PRESORDERID + oleDb.EuqalTo() + presorderid[0] + oleDb.And() + Tables.zy_presorder.RECORD_FLAG + oleDb.EuqalTo() + 0;
                    object obj1 = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetFieldValue("amount", strWhere1);
                    if (obj1 != null)
                    {
                        amount1 = decimal.Parse(obj1.ToString());
                    }
                    else
                    {
                        return false;
                    }

                    string strWhere2 = Tables.zy_presorder.OLDID + oleDb.EuqalTo() + presorderid[0] + oleDb.And() + Tables.zy_presorder.RECORD_FLAG + oleDb.EuqalTo() + 1;
                    object obj2 = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetFieldValue("sum(amount)", strWhere2);
                    if (obj2 != null && obj2 != DBNull.Value)
                    {
                        amount2 = decimal.Parse(obj2.ToString());
                    }
                    else
                    {
                        amount2 = 0;
                    }
                    decimal allamount = amount1 + amount2 + (-1) * amount3;
                    if (allamount >= 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
        /// <summary>
        ///判断数量是否可以取消冲正操作
        /// </summary>
        /// <param name="presorder_id"></param>
        /// <returns></returns>
        public bool getexitresultlist(List<int> presorder_id)
        {
            try
            {
                decimal amount1;
                decimal amount2;
                List<int> presorderid = presorder_id;               
                string strWhere2 = Tables.zy_presorder.RECORD_FLAG + oleDb.EuqalTo() + 1 + oleDb.And() + Tables.zy_presorder.OLDID + oleDb.EuqalTo() + presorderid[0];
                object obj2 = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetFieldValue("amount", strWhere2);
                if (obj2 != null)
                {
                    amount2 = decimal.Parse(obj2.ToString());
                }
                else
                {
                    amount2 = 0;
                }
                if (amount2 <= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 判断数量是否可以取消冲正（单条取消冲正）
        /// </summary>
        /// <param name="presorder_id"></param>
        /// <returns></returns>
        public bool getspecexitresult(List<int> presorder_id,int deptid)
        {
            try
            {
                #region
                //string strWhere5 = Tables.zy_presorder.PRESORDERID + oleDb.EuqalTo() + presorder_id[0] + oleDb.And() + Tables.zy_presorder.PRESDEPTCODE + oleDb.EuqalTo() + "'" + deptid + "'";
                //if (BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Exists(strWhere5))
                //{
                //    decimal amount1;
                //    decimal amount2;
                //    int oldid;
                //    List<int> presorderid = presorder_id;
                //    string strWhere1 = Tables.zy_presorder.RECORD_FLAG + oleDb.EuqalTo() + 1 + oleDb.And() + Tables.zy_presorder.PRESORDERID + oleDb.EuqalTo() + presorderid[0] + oleDb.And() + Tables.zy_presorder.DRUG_FLAG + oleDb.EuqalTo() + 2;
                //    bool result = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Exists(strWhere1);
                //    if (result == true)
                //    {
                //        return false;
                //    }
                //    else
                //    {
                //        string strWhere3 = Tables.zy_presorder.PRESORDERID + oleDb.EuqalTo() + presorderid[0];
                //        object obj3 = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetFieldValue("oldid", strWhere3);
                //        if (obj3 != null && int.Parse(obj3.ToString()) != 0)
                //        {
                //            oldid = int.Parse(obj3.ToString());
                //            string strWhere4 = Tables.zy_presorder.RECORD_FLAG + oleDb.EuqalTo() + 0 + oleDb.And() + Tables.zy_presorder.PRESORDERID + oleDb.EuqalTo() + oldid + oleDb.And() + Tables.zy_presorder.DRUG_FLAG + oleDb.EuqalTo() + 1;
                //            bool drugresult = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Exists(strWhere4);
                //            if (drugresult == true)
                //            {
                //                return false;
                //            }
                //        }
                //        string strWhere2 = Tables.zy_presorder.RECORD_FLAG + oleDb.EuqalTo() + 1 + oleDb.And() + Tables.zy_presorder.OLDID + oleDb.EuqalTo() + presorderid[0];
                //        object obj2 = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetFieldValue("amount", strWhere2);
                //        if (obj2 != null)
                //        {
                //            amount2 = decimal.Parse(obj2.ToString());
                //        }
                //        else
                //        {
                //            amount2 = 0;
                //        }
                //        if (amount2 <= 0)
                //        {
                //            return true;
                //        }
                //        else
                //        {
                //            return false;
                //        }
                //    }
                //}
                //else
                //{
                //    return false;
                //}
                #endregion
               
                string strwhere = Tables.zy_presorder.PRESORDERID + oleDb.EuqalTo() + presorder_id[0] + oleDb.And() + Tables.zy_presorder.PRESDEPTCODE + oleDb.EuqalTo() + "'" + deptid + "'";
                HIS.Model.ZY_PresOrder presorder = BindEntity<HIS.Model.ZY_PresOrder>.CreateInstanceDAL(oleDb).GetModel(strwhere);
            
                if (presorder.Drug_Flag == 2)  //update by heyan 已经发药的可以取消冲，已经退药的不能取消冲 2010.10.9
                {
                    throw new Exception("该药品已退药，不能取消冲");
                }

                HIS.Model.ZY_PresOrder _presorder = BindEntity<HIS.Model.ZY_PresOrder>.CreateInstanceDAL(oleDb).GetModel("presorderid=" + presorder.OldID + "");
                if (_presorder.Drug_Flag != presorder.Drug_Flag) //部分冲的，如果部分冲的那部分已经退药成功的，不能取消冲 update by heyan 2010.10.9
                {
                    throw new Exception("该药品是部分冲的，不能取消冲");
                }
               
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        ///判断数量是否可以取消冲正操作（成组取消冲正）
        /// </summary>
        /// <param name="presorder_id"></param>
        /// <returns></returns>
        public bool getspecexitresultlist(List<int> presorder_id,int deptid)
        {
            try
            {
                #region
                //string strWhere5 = Tables.zy_presorder.PRESORDERID + oleDb.EuqalTo() + presorder_id[0] + oleDb.And() + Tables.zy_presorder.PRESDEPTCODE + oleDb.EuqalTo() + "'" + deptid + "'";
                //if (BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Exists(strWhere5))
                //{
                //    decimal amount1;
                //    decimal amount2;
                //    int oldid;
                //    List<int> presorderid = presorder_id;
                //    string strWhere1 = Tables.zy_presorder.RECORD_FLAG + oleDb.EuqalTo() + 1 + oleDb.And() + Tables.zy_presorder.PRESORDERID + oleDb.EuqalTo() + presorderid[0] + oleDb.And() + Tables.zy_presorder.DRUG_FLAG + oleDb.EuqalTo() + 2;
                //    bool result = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Exists(strWhere1);
                //    if (result == true)
                //    {
                //        return false;
                //    }
                //    else
                //    {
                //        string strWhere3 = Tables.zy_presorder.PRESORDERID + oleDb.EuqalTo() + presorderid[0];
                //        object obj3 = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetFieldValue("oldid", strWhere3);
                //        if (obj3 != null && int.Parse(obj3.ToString()) != 0)
                //        {
                //            oldid = int.Parse(obj3.ToString());
                //            string strWhere4 = Tables.zy_presorder.RECORD_FLAG + oleDb.EuqalTo() + 0 + oleDb.And() + Tables.zy_presorder.PRESORDERID + oleDb.EuqalTo() + oldid + oleDb.And() + Tables.zy_presorder.DRUG_FLAG + oleDb.EuqalTo() + 1;
                //            bool drugresult = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Exists(strWhere4);
                //            if (drugresult == true)
                //            {
                //                return false;
                //            }
                //        }

                //        string strWhere2 = Tables.zy_presorder.RECORD_FLAG + oleDb.EuqalTo() + 1 + oleDb.And() + Tables.zy_presorder.OLDID + oleDb.EuqalTo() + presorderid[0];
                //        object obj2 = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetFieldValue("amount", strWhere2);
                //        if (obj2 != null)
                //        {
                //            amount2 = decimal.Parse(obj2.ToString());
                //        }
                //        else
                //        {
                //            amount2 = 0;
                //        }
                //        if (amount2 <= 0)
                //        {
                //            return true;
                //        }
                //        else
                //        {
                //            return false;
                //        }
                //    }
                //}
                //else
                //{
                //    return false;
                //}
                #endregion

                string strwhere = Tables.zy_presorder.PRESORDERID + oleDb.EuqalTo() + presorder_id[0] + oleDb.And() + Tables.zy_presorder.PRESDEPTCODE + oleDb.EuqalTo() + "'" + deptid + "'";
                HIS.Model.ZY_PresOrder presorder=BindEntity<HIS.Model.ZY_PresOrder>.CreateInstanceDAL(oleDb).GetModel(strwhere );
            
                if (presorder.Drug_Flag == 2)//update by heyan 2010.10.9 已经发药的可以取消冲，已经退药的不能取消冲
                {
                    throw new Exception("该药品已退药，不能取消冲");
                }
                HIS.Model.ZY_PresOrder _presorder = BindEntity<HIS.Model.ZY_PresOrder>.CreateInstanceDAL(oleDb).GetModel("presorderid=" + presorder.OldID + "");
                if (_presorder.Drug_Flag != presorder.Drug_Flag)//部分冲的，如果部分冲的那部分已经退药成功的，不能取消冲update by heyan 2010.10.9
                {
                    throw new Exception("该药品是部分冲的，不能取消冲");
                }              
              
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }        


        /// <summary>
        ///冲正具体操作
        /// </summary>
        /// <param name="patlist_id"></param>
        /// <param name="presorder_id"></param>
        /// <param name="cost_date"></param>
        /// <returns></returns>
        public bool canaccount(int patlist_id, List<int> presorder_id, List<DateTime> cost_date)
        {
            int patlistid = patlist_id;
            List<int> presorderid = presorder_id;
            List<DateTime> costdate = cost_date;         
            try
            {
                DateTime serverdatetime = XcDate.ServerDateTime;
                oleDb.BeginTransaction();
                for (int i = 0; i < presorderid.Count; i++)
                {
                    HIS.Model.ZY_PresOrder presorder = new ZY_PresOrder();
                    //Model.ZY_PresMaster premaster = new ZY_PresMaster();
                    string strWhere = Tables.zy_presorder.PRESORDERID + oleDb.EuqalTo() + presorderid[i] + oleDb.And() + Tables.zy_presorder.PATLISTID + oleDb.EuqalTo() + patlistid + oleDb.And() + Tables.zy_presorder.COSTDATE + oleDb.EuqalTo() + "'" + costdate[i] + "'";
                    DataTable dt = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetList(strWhere);
                    presorder.PatID = Convert.ToInt32(dt.Rows[0]["PatID"].ToString());
                    presorder.PatListID = Convert.ToInt32(dt.Rows[0]["PatListID"].ToString());
                    presorder.PresMasterID = Convert.ToInt32(dt.Rows[0]["PresMasterID"].ToString());
                    presorder.ItemID = Convert.ToInt32(dt.Rows[0]["ItemID"].ToString());
                    presorder.ItemType = dt.Rows[0]["ItemType"].ToString();
                    presorder.PresType = dt.Rows[0]["PresType"].ToString();
                    presorder.ItemName = dt.Rows[0]["ItemName"].ToString();
                    presorder.Standard = dt.Rows[0]["Standard"].ToString();
                    presorder.Unit = dt.Rows[0]["Unit"].ToString();
                    presorder.RelationNum = Convert.ToDecimal(dt.Rows[0]["RelationNum"].ToString());
                    presorder.Buy_Price = Convert.ToDecimal(dt.Rows[0]["Buy_Price"].ToString());
                    presorder.Sell_Price = Convert.ToDecimal(dt.Rows[0]["Sell_Price"].ToString());
                    presorder.PresDocCode = dt.Rows[0]["PresDocCode"].ToString();
                    presorder.PresDeptCode = dt.Rows[0]["PresDeptCode"].ToString();
                    presorder.ExecDeptCode = dt.Rows[0]["ExecDeptCode"].ToString();
                    presorder.ChargeCode = dt.Rows[0]["ChargeCode"].ToString();
                    presorder.PresDate = Convert.ToDateTime(dt.Rows[0]["PresDate"].ToString());
                    presorder.MarkDate = Convert.ToDateTime(dt.Rows[0]["MarkDate"].ToString());
                    //presorder.CostDate = serverdatetime;
                     if (Convert.ToDateTime(dt.Rows[0]["CostDate"].ToString()).ToString("yyyy-MM-dd").CompareTo(serverdatetime.ToString("yyyy-MM-dd"))>0)
                    {
                        presorder.CostDate = Convert.ToDateTime(dt.Rows[0]["CostDate"].ToString());
                    }
                    else
                    {
                        presorder.CostDate = serverdatetime;
                    }                    
                    presorder.Charge_Flag = Convert.ToInt32(dt.Rows[0]["Charge_Flag"].ToString());
                    presorder.Charge_Flag = Convert.ToInt32(dt.Rows[0]["Charge_Flag"].ToString());
                    presorder.Record_Flag = 1;
                    presorder.Drug_Flag = Convert.ToInt32(dt.Rows[0]["Drug_Flag"].ToString());
                    presorder.PackUnit = dt.Rows[0]["PackUnit"].ToString();
                    presorder.Amount = (-1) * Convert.ToDecimal(dt.Rows[0]["Amount"].ToString());
                    presorder.PresAmount = (-1) * Convert.ToInt32(dt.Rows[0]["PresAmount"].ToString());
                    presorder.Tolal_Fee = (-1) * Convert.ToDecimal(dt.Rows[0]["Tolal_Fee"].ToString());
                    presorder.OldID = presorderid[i];
                    presorder.order_id = Convert.ToInt32(dt.Rows[0]["order_id"].ToString());
                    presorder.group_id = Convert.ToInt32(dt.Rows[0]["group_id"].ToString());
                    presorder.order_type = Convert.ToInt32(dt.Rows[0]["order_type"].ToString());
                    presorder.Tolal_Fee = Convert.ToDecimal(presorder.Tolal_Fee.ToString("0.00"));
                    BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Add(presorder);
                    //premaster.PatListID = presorder.PatListID;
                    //premaster.PatID = presorder.PatID;
                    //premaster.PresType = Convert.ToString(0);
                    //BindEntity<ZY_PresMaster>.CreateInstanceDAL(oleDb).Add(premaster);
                    //string strWhere1 = "presorderid=" + presorder.PresOrderID;
                    //string updatefile = Tables.zy_presorder.PRESMASTERID + oleDb.EuqalTo() + premaster.PresMasterID;
                    //BindEntity<HIS.Model.ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(strWhere1, updatefile);
                }
                oleDb.CommitTransaction();
                return true;
            }
            catch (Exception e)
            {
                oleDb.RollbackTransaction();
                return false;
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        ///冲正具体操作(成组冲正）
        /// </summary>
        /// <param name="patlist_id"></param>
        /// <param name="presorder_id"></param>
        /// <param name="cost_date"></param>
        /// <returns></returns>
        public bool canaccountlist(int patlist_id, List<int> presorder_id, List<DateTime> cost_date,List<decimal> amount_list)
        {
            int patlistid = patlist_id;
            List<int> presorderid = presorder_id;
            List<DateTime> costdate = cost_date;
            List<decimal> amount = amount_list;
            try
            {
                DateTime serverdatetime = XcDate.ServerDateTime;
                oleDb.BeginTransaction();
                for (int i = 0; i < presorderid.Count; i++)
                {
                    HIS.Model.ZY_PresOrder presorder = new ZY_PresOrder();
                    //Model.ZY_PresMaster premaster = new ZY_PresMaster();
                    string strWhere = Tables.zy_presorder.PRESORDERID + oleDb.EuqalTo() + presorderid[i] + oleDb.And() + Tables.zy_presorder.PATLISTID + oleDb.EuqalTo() + patlistid + oleDb.And() + Tables.zy_presorder.COSTDATE + oleDb.EuqalTo() + "'" + costdate[i] + "'";
                    DataTable dt = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetList(strWhere);
                    presorder.PatID = Convert.ToInt32(dt.Rows[0]["PatID"].ToString());
                    presorder.PatListID = Convert.ToInt32(dt.Rows[0]["PatListID"].ToString());
                    presorder.PresMasterID = Convert.ToInt32(dt.Rows[0]["PresMasterID"].ToString());
                    presorder.ItemID = Convert.ToInt32(dt.Rows[0]["ItemID"].ToString());
                    presorder.ItemType = dt.Rows[0]["ItemType"].ToString();
                    presorder.PresType = dt.Rows[0]["PresType"].ToString();
                    presorder.ItemName = dt.Rows[0]["ItemName"].ToString();
                    presorder.Standard = dt.Rows[0]["Standard"].ToString();
                    presorder.Unit = dt.Rows[0]["Unit"].ToString();
                    presorder.RelationNum = Convert.ToDecimal(dt.Rows[0]["RelationNum"].ToString());
                    presorder.Buy_Price = Convert.ToDecimal(dt.Rows[0]["Buy_Price"].ToString());
                    presorder.Sell_Price = Convert.ToDecimal(dt.Rows[0]["Sell_Price"].ToString());
                    presorder.PresDocCode = dt.Rows[0]["PresDocCode"].ToString();
                    presorder.PresDeptCode = dt.Rows[0]["PresDeptCode"].ToString();
                    presorder.ExecDeptCode = dt.Rows[0]["ExecDeptCode"].ToString();
                    presorder.ChargeCode = dt.Rows[0]["ChargeCode"].ToString();
                    presorder.PresDate = Convert.ToDateTime(dt.Rows[0]["PresDate"].ToString());
                    presorder.MarkDate = Convert.ToDateTime(dt.Rows[0]["MarkDate"].ToString());
                    //presorder.CostDate = serverdatetime;//12月14日修改，为修改冲明日帐修改
                    if (Convert.ToDateTime(dt.Rows[0]["CostDate"].ToString()).ToString("yyyy-MM-dd").CompareTo(serverdatetime.ToString("yyyy-MM-dd")) > 0)
                    {
                        presorder.CostDate = Convert.ToDateTime(dt.Rows[0]["CostDate"].ToString());
                    }
                    else
                    {
                        presorder.CostDate = serverdatetime;
                    }
                    presorder.Charge_Flag = Convert.ToInt32(dt.Rows[0]["Charge_Flag"].ToString());
                    presorder.Charge_Flag = Convert.ToInt32(dt.Rows[0]["Charge_Flag"].ToString());
                    presorder.Record_Flag = 1;
                    presorder.Drug_Flag = Convert.ToInt32(dt.Rows[0]["Drug_Flag"].ToString());
                    presorder.PackUnit = dt.Rows[0]["PackUnit"].ToString();
                    presorder.Amount = (-1) * amount[i];
                    presorder.PresAmount = (-1) * Convert.ToInt32(dt.Rows[0]["PresAmount"].ToString());
                    decimal totalfee = Convert.ToDecimal(dt.Rows[0]["tolal_fee"].ToString());
                    decimal totalamount = Convert.ToDecimal(dt.Rows[0]["amount"].ToString());
                    presorder.Tolal_Fee = ((-1) * amount[i] * totalfee) / totalamount;
                    presorder.OldID = presorderid[i];
                    presorder.order_id = Convert.ToInt32(dt.Rows[0]["order_id"].ToString());
                    presorder.group_id = Convert.ToInt32(dt.Rows[0]["group_id"].ToString());
                    presorder.order_type = Convert.ToInt32(dt.Rows[0]["order_type"].ToString());
                    presorder.Tolal_Fee = Convert.ToDecimal(presorder.Tolal_Fee.ToString("0.00"));
                    BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Add(presorder);
                    //premaster.PatListID = presorder.PatListID;
                    //premaster.PatID = presorder.PatID;
                    //premaster.PresType = Convert.ToString(0);
                    //BindEntity<ZY_PresMaster>.CreateInstanceDAL(oleDb).Add(premaster);
                    //string strWhere1 = "presorderid=" + presorder.PresOrderID;
                    //string updatefile = Tables.zy_presorder.PRESMASTERID + oleDb.EuqalTo() + premaster.PresMasterID;
                    //BindEntity<HIS.Model.ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(strWhere1, updatefile);
                }
                oleDb.CommitTransaction();
                return true;
            }
            catch (Exception e)
            {
                oleDb.RollbackTransaction();
                return false;
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 冲正具体操作（数量冲）
        /// </summary>
        /// <param name="patlist_id"></param>
        /// <param name="presorder_id"></param>
        /// <param name="cost_date"></param>
        /// <returns></returns>
        public bool canamountaccount(int patlist_id, List<int> presorder_id, List<DateTime> cost_date,decimal canamount)
        {
            int patlistid = patlist_id;
            List<int> presorderid = presorder_id;
            List<DateTime> costdate = cost_date;
            decimal amount = canamount;
   
            try
            {
                DateTime serverdatetime = XcDate.ServerDateTime;
                //oleDb.BeginTransaction();
                for (int i = 0; i < presorderid.Count; i++)
                {
                    HIS.Model.ZY_PresOrder presorder = new ZY_PresOrder();
                    //Model.ZY_PresMaster premaster = new ZY_PresMaster();
                    string strWhere = Tables.zy_presorder.PRESORDERID + oleDb.EuqalTo() + presorderid[i] + oleDb.And() + Tables.zy_presorder.PATLISTID + oleDb.EuqalTo() + patlistid + oleDb.And() + Tables.zy_presorder.COSTDATE + oleDb.EuqalTo() + "'" + costdate[i] + "'";
                    DataTable dt = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetList(strWhere);
                    presorder.PatID = Convert.ToInt32(dt.Rows[0]["PatID"].ToString());
                    presorder.PatListID = Convert.ToInt32(dt.Rows[0]["PatListID"].ToString());
                    presorder.PresMasterID = Convert.ToInt32(dt.Rows[0]["PresMasterID"].ToString());
                    presorder.ItemID = Convert.ToInt32(dt.Rows[0]["ItemID"].ToString());
                    presorder.ItemType = dt.Rows[0]["ItemType"].ToString();
                    presorder.PresType = dt.Rows[0]["PresType"].ToString();
                    presorder.ItemName = dt.Rows[0]["ItemName"].ToString();
                    presorder.Standard = dt.Rows[0]["Standard"].ToString();
                    presorder.Unit = dt.Rows[0]["Unit"].ToString();
                    presorder.RelationNum = Convert.ToDecimal(dt.Rows[0]["RelationNum"].ToString());
                    presorder.Buy_Price = Convert.ToDecimal(dt.Rows[0]["Buy_Price"].ToString());
                    presorder.Sell_Price = Convert.ToDecimal(dt.Rows[0]["Sell_Price"].ToString());
                    presorder.PresDocCode = dt.Rows[0]["PresDocCode"].ToString();
                    presorder.PresDeptCode = dt.Rows[0]["PresDeptCode"].ToString();
                    presorder.ExecDeptCode = dt.Rows[0]["ExecDeptCode"].ToString();
                    presorder.ChargeCode = dt.Rows[0]["ChargeCode"].ToString();
                    presorder.PresDate = Convert.ToDateTime(dt.Rows[0]["PresDate"].ToString());
                    presorder.MarkDate = Convert.ToDateTime(dt.Rows[0]["MarkDate"].ToString());
                    //presorder.CostDate = serverdatetime;
                    if (Convert.ToDateTime(dt.Rows[0]["CostDate"].ToString()).ToString("yyyy-MM-dd").CompareTo(serverdatetime.ToString("yyyy-MM-dd"))>0)
                    {
                        presorder.CostDate = Convert.ToDateTime(dt.Rows[0]["CostDate"].ToString());
                    }
                    else
                    {
                        presorder.CostDate = serverdatetime;
                        //presorder.CostDate = costdate[i];
                    }
                    presorder.Charge_Flag = Convert.ToInt32(dt.Rows[0]["Charge_Flag"].ToString());
                    presorder.Charge_Flag = Convert.ToInt32(dt.Rows[0]["Charge_Flag"].ToString());
                    presorder.Record_Flag = 1;
                    presorder.Drug_Flag = Convert.ToInt32(dt.Rows[0]["Drug_Flag"].ToString());
                    presorder.PackUnit = dt.Rows[0]["PackUnit"].ToString();                    
                    presorder.PresAmount = (-1) * Convert.ToInt32(dt.Rows[0]["PresAmount"].ToString());                   
                    presorder.OldID = presorderid[i];
                    presorder.order_id = Convert.ToInt32(dt.Rows[0]["order_id"].ToString());
                    presorder.group_id = Convert.ToInt32(dt.Rows[0]["group_id"].ToString());
                    presorder.order_type = Convert.ToInt32(dt.Rows[0]["order_type"].ToString());
                    presorder.Amount = (-1) * amount;
                    decimal totalfee = Convert.ToDecimal(dt.Rows[0]["tolal_fee"].ToString());
                    decimal totalamount = Convert.ToDecimal(dt.Rows[0]["amount"].ToString());
                    //为解决报销差一分钱的问题，曾浩修改后台冲正方式
                    HIS.ZY_BLL.ObjectModel.PresOrderManager.IpresOrderManager Ipom = HIS.ZY_BLL.ObjectModel.ObjectFactory.GetObject<HIS.ZY_BLL.ObjectModel.PresOrderManager.IpresOrderManager>(typeof(HIS.ZY_BLL.DataModel.ZY_PresOrder));
                    Ipom.oleDb = oleDb;
                    Ipom.OldID = presorder.OldID;
                    Ipom.Amount = presorder.Amount;
                    decimal resultfee,arinum;
                    Ipom.CheckBackPres(out resultfee, out arinum);
                    if (arinum == 0)
                    {
                        presorder.Tolal_Fee = resultfee;
                    }
                    else
                    {
                        presorder.Tolal_Fee =((-1) * amount * totalfee) / totalamount;
                    }
                    //2010年3月3日 由曾浩修改
                    presorder.Tolal_Fee = Convert.ToDecimal(presorder.Tolal_Fee.ToString("0.00"));
                    BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Add(presorder);
                    //premaster.PatListID = presorder.PatListID;
                    //premaster.PatID = presorder.PatID;
                    //premaster.PresType = Convert.ToString(0);
                    //BindEntity<ZY_PresMaster>.CreateInstanceDAL(oleDb).Add(premaster);
                    //string strWhere1 = "presorderid=" + presorder.PresOrderID;
                    //string updatefile = Tables.zy_presorder.PRESMASTERID + oleDb.EuqalTo() + premaster.PresMasterID;
                    //BindEntity<HIS.Model.ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(strWhere1, updatefile);
                }
                //oleDb.CommitTransaction();
                return true;
            }
            catch (Exception e)
            {
                oleDb.RollbackTransaction();
                return false;
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 系统自动冲正（数量冲）
        /// </summary>
        /// <param name="patlist_id"></param>
        /// <param name="presorder_id"></param>
        /// <param name="cost_date"></param>
        /// <returns></returns>
        public bool autocanamountaccount(int patlist_id, List<int> presorder_id, List<DateTime> cost_date, decimal canamount, DateTime serverdate)
        {
            int patlistid = patlist_id;
            List<int> presorderid = presorder_id;
            List<DateTime> costdate = cost_date;
            DateTime serverdatetime = serverdate;
            decimal amount = canamount;
            try
            {               
                //oleDb.BeginTransaction();
                for (int i = 0; i < presorderid.Count; i++)
                {
                    HIS.Model.ZY_PresOrder presorder = new ZY_PresOrder();
                    //Model.ZY_PresMaster premaster = new ZY_PresMaster();
                    string strWhere = Tables.zy_presorder.PRESORDERID + oleDb.EuqalTo() + presorderid[i] + oleDb.And() + Tables.zy_presorder.PATLISTID + oleDb.EuqalTo() + patlistid + oleDb.And() + Tables.zy_presorder.COSTDATE + oleDb.EuqalTo() + "'" + costdate[i] + "'";
                    DataTable dt = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetList(strWhere);
                    presorder.PatID = Convert.ToInt32(dt.Rows[0]["PatID"].ToString());
                    presorder.PatListID = Convert.ToInt32(dt.Rows[0]["PatListID"].ToString());
                    presorder.PresMasterID = Convert.ToInt32(dt.Rows[0]["PresMasterID"].ToString());
                    presorder.ItemID = Convert.ToInt32(dt.Rows[0]["ItemID"].ToString());
                    presorder.ItemType = dt.Rows[0]["ItemType"].ToString();
                    presorder.PresType = dt.Rows[0]["PresType"].ToString();
                    presorder.ItemName = dt.Rows[0]["ItemName"].ToString();
                    presorder.Standard = dt.Rows[0]["Standard"].ToString();
                    presorder.Unit = dt.Rows[0]["Unit"].ToString();
                    presorder.RelationNum = Convert.ToDecimal(dt.Rows[0]["RelationNum"].ToString());
                    presorder.Buy_Price = Convert.ToDecimal(dt.Rows[0]["Buy_Price"].ToString());
                    presorder.Sell_Price = Convert.ToDecimal(dt.Rows[0]["Sell_Price"].ToString());
                    presorder.PresDocCode = dt.Rows[0]["PresDocCode"].ToString();
                    presorder.PresDeptCode = dt.Rows[0]["PresDeptCode"].ToString();
                    presorder.ExecDeptCode = dt.Rows[0]["ExecDeptCode"].ToString();
                    presorder.ChargeCode = dt.Rows[0]["ChargeCode"].ToString();
                    presorder.PresDate = Convert.ToDateTime(dt.Rows[0]["PresDate"].ToString());
                    presorder.MarkDate = Convert.ToDateTime(dt.Rows[0]["MarkDate"].ToString());           
                    if (Convert.ToDateTime(dt.Rows[0]["CostDate"].ToString()).ToString("yyyy-MM-dd").CompareTo(serverdatetime.ToString("yyyy-MM-dd")) > 0)
                    {
                        presorder.CostDate = Convert.ToDateTime(dt.Rows[0]["CostDate"].ToString());
                    }
                    else
                    {
                        presorder.CostDate = serverdatetime;                        
                    }
                    presorder.Charge_Flag = Convert.ToInt32(dt.Rows[0]["Charge_Flag"].ToString());
                    presorder.Charge_Flag = Convert.ToInt32(dt.Rows[0]["Charge_Flag"].ToString());
                    presorder.Record_Flag = 1;
                    presorder.Drug_Flag = Convert.ToInt32(dt.Rows[0]["Drug_Flag"].ToString());
                    presorder.PackUnit = dt.Rows[0]["PackUnit"].ToString();
                    presorder.PresAmount = (-1) * Convert.ToInt32(dt.Rows[0]["PresAmount"].ToString());
                    presorder.OldID = presorderid[i];
                    presorder.order_id = Convert.ToInt32(dt.Rows[0]["order_id"].ToString());
                    presorder.group_id = Convert.ToInt32(dt.Rows[0]["group_id"].ToString());
                    presorder.order_type = Convert.ToInt32(dt.Rows[0]["order_type"].ToString());
                    presorder.Amount = (-1) * amount;
                    decimal totalfee = Convert.ToDecimal(dt.Rows[0]["tolal_fee"].ToString());
                    decimal totalamount = Convert.ToDecimal(dt.Rows[0]["amount"].ToString());
                    //为解决报销差一分钱的问题，曾浩修改后台冲正方式
                    HIS.ZY_BLL.ObjectModel.PresOrderManager.IpresOrderManager Ipom = HIS.ZY_BLL.ObjectModel.ObjectFactory.GetObject<HIS.ZY_BLL.ObjectModel.PresOrderManager.IpresOrderManager>(typeof(HIS.ZY_BLL.DataModel.ZY_PresOrder));
                    Ipom.oleDb = oleDb;
                    Ipom.OldID = presorder.OldID;
                    Ipom.Amount = presorder.Amount;
                    decimal resultfee, arinum;
                    Ipom.CheckBackPres(out resultfee, out arinum);
                    if (arinum == 0)
                    {
                        presorder.Tolal_Fee = resultfee;
                    }
                    else
                    {
                        presorder.Tolal_Fee = ((-1) * amount * totalfee) / totalamount;
                    }
                    //2010年3月3日 由曾浩修改
                    presorder.Tolal_Fee = Convert.ToDecimal(presorder.Tolal_Fee.ToString("0.00"));
                    BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Add(presorder);
                    //premaster.PatListID = presorder.PatListID;
                    //premaster.PatID = presorder.PatID;
                    //premaster.PresType = Convert.ToString(0);
                    //BindEntity<ZY_PresMaster>.CreateInstanceDAL(oleDb).Add(premaster);
                    //string strWhere1 = "presorderid=" + presorder.PresOrderID;
                    //string updatefile = Tables.zy_presorder.PRESMASTERID + oleDb.EuqalTo() + premaster.PresMasterID;
                    //BindEntity<HIS.Model.ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(strWhere1, updatefile);
                }
                //oleDb.CommitTransaction();
                return true;
            }
            catch (Exception e)
            {
                oleDb.RollbackTransaction();
                return false;
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 当天开当天停（数量补）
        /// </summary>
        /// <param name="patlist_id"></param>
        /// <param name="presorder_id"></param>
        /// <param name="cost_date"></param>
        /// <param name="canamount"></param>
        /// <returns></returns>
        public bool insertamountaccount(int patlist_id, List<int> presorder_id, List<DateTime> cost_date, decimal canamount,DateTime serverdate)
        {
            int patlistid = patlist_id;
            List<int> presorderid = presorder_id;
            List<DateTime> costdate = cost_date;
            decimal amount = canamount;
            DateTime serverdatetime = serverdate;
            try
            {                
                //oleDb.BeginTransaction();
                for (int i = 0; i < presorderid.Count; i++)
                {
                    HIS.Model.ZY_PresOrder presorder = new ZY_PresOrder();
                    //Model.ZY_PresMaster premaster = new ZY_PresMaster();
                    string strWhere = Tables.zy_presorder.PRESORDERID + oleDb.EuqalTo() + presorderid[i] + oleDb.And() + Tables.zy_presorder.PATLISTID + oleDb.EuqalTo() + patlistid + oleDb.And() + Tables.zy_presorder.COSTDATE + oleDb.EuqalTo() + "'" + costdate[i] + "'";
                    DataTable dt = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetList(strWhere);
                    presorder.PatID = Convert.ToInt32(dt.Rows[0]["PatID"].ToString());
                    presorder.PatListID = Convert.ToInt32(dt.Rows[0]["PatListID"].ToString());
                    presorder.PresMasterID = Convert.ToInt32(dt.Rows[0]["PresMasterID"].ToString());
                    presorder.ItemID = Convert.ToInt32(dt.Rows[0]["ItemID"].ToString());
                    presorder.ItemType = dt.Rows[0]["ItemType"].ToString();
                    presorder.PresType = dt.Rows[0]["PresType"].ToString();
                    presorder.ItemName = dt.Rows[0]["ItemName"].ToString();
                    presorder.Standard = dt.Rows[0]["Standard"].ToString();
                    presorder.Unit = dt.Rows[0]["Unit"].ToString();
                    presorder.RelationNum = Convert.ToDecimal(dt.Rows[0]["RelationNum"].ToString());
                    presorder.Buy_Price = Convert.ToDecimal(dt.Rows[0]["Buy_Price"].ToString());
                    presorder.Sell_Price = Convert.ToDecimal(dt.Rows[0]["Sell_Price"].ToString());
                    presorder.PresDocCode = dt.Rows[0]["PresDocCode"].ToString();
                    presorder.PresDeptCode = dt.Rows[0]["PresDeptCode"].ToString();
                    presorder.ExecDeptCode = dt.Rows[0]["ExecDeptCode"].ToString();
                    presorder.ChargeCode = dt.Rows[0]["ChargeCode"].ToString();
                    presorder.PresDate = Convert.ToDateTime(dt.Rows[0]["PresDate"].ToString());
                    presorder.MarkDate = Convert.ToDateTime(dt.Rows[0]["MarkDate"].ToString());
                    //presorder.CostDate = serverdatetime;
                    if (Convert.ToDateTime(dt.Rows[0]["CostDate"].ToString()).ToString("yyyy-MM-dd").CompareTo(serverdatetime.ToString("yyyy-MM-dd")) > 0)
                    {
                        presorder.CostDate = Convert.ToDateTime(dt.Rows[0]["CostDate"].ToString());
                    }
                    else
                    {
                        presorder.CostDate = serverdatetime;                        
                    }
                    presorder.Charge_Flag = Convert.ToInt32(dt.Rows[0]["Charge_Flag"].ToString());
                    presorder.Charge_Flag = Convert.ToInt32(dt.Rows[0]["Charge_Flag"].ToString());
                    presorder.Record_Flag = 0;
                    presorder.Drug_Flag = (Convert.ToInt32(presorder.PresType) < 4) ? 0 : 1;
                    presorder.PackUnit = dt.Rows[0]["PackUnit"].ToString();
                    presorder.PresAmount = (-1) * Convert.ToInt32(dt.Rows[0]["PresAmount"].ToString());
                    presorder.OldID = 0;
                    presorder.order_id = Convert.ToInt32(dt.Rows[0]["order_id"].ToString());
                    presorder.group_id = Convert.ToInt32(dt.Rows[0]["group_id"].ToString());
                    presorder.order_type = Convert.ToInt32(dt.Rows[0]["order_type"].ToString());
                    presorder.Amount = (-1) * amount;
                    decimal totalfee = Convert.ToDecimal(dt.Rows[0]["tolal_fee"].ToString());
                    decimal totalamount = Convert.ToDecimal(dt.Rows[0]["amount"].ToString());
                    //为解决报销差一分钱的问题，曾浩修改后台冲正方式
                    HIS.ZY_BLL.ObjectModel.PresOrderManager.IpresOrderManager Ipom = HIS.ZY_BLL.ObjectModel.ObjectFactory.GetObject<HIS.ZY_BLL.ObjectModel.PresOrderManager.IpresOrderManager>(typeof(HIS.ZY_BLL.DataModel.ZY_PresOrder));
                    Ipom.oleDb = oleDb;
                    Ipom.OldID = presorder.OldID;
                    Ipom.Amount = presorder.Amount;
                    decimal resultfee, arinum;
                    Ipom.CheckBackPres(out resultfee, out arinum);
                    if (arinum == 0)
                    {
                        presorder.Tolal_Fee = resultfee;
                    }
                    else
                    {
                        presorder.Tolal_Fee = ((-1) * amount * totalfee) / totalamount;
                    }
                    //2010年3月3日 由曾浩修改
                    presorder.Tolal_Fee = Convert.ToDecimal(presorder.Tolal_Fee.ToString("0.00"));
                    BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Add(presorder);
                    //premaster.PatListID = presorder.PatListID;
                    //premaster.PatID = presorder.PatID;
                    //premaster.PresType = Convert.ToString(0);
                    //BindEntity<ZY_PresMaster>.CreateInstanceDAL(oleDb).Add(premaster);
                    //string strWhere1 = "presorderid=" + presorder.PresOrderID;
                    //string updatefile = Tables.zy_presorder.PRESMASTERID + oleDb.EuqalTo() + premaster.PresMasterID;
                    //BindEntity<HIS.Model.ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(strWhere1, updatefile);
                }
                //oleDb.CommitTransaction();
                return true;
            }
            catch (Exception e)
            {
                oleDb.RollbackTransaction();
                return false;
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 取消冲正具体操作
        /// </summary>
        /// <param name="patlist_id"></param>
        /// <param name="presorder_id"></param>
        /// <param name="cost_date"></param>
        /// <returns></returns>
        public bool exitcanaccount(int patlist_id, List<int> presorder_id, List<DateTime> cost_date)
        {
            int patlistid = patlist_id;
            List<int> presorderid = presorder_id;
            List<DateTime> costdate = cost_date;
            try
            {
                DateTime serverdatetime = XcDate.ServerDateTime;
                oleDb.BeginTransaction();
                for (int i = 0; i < presorderid.Count; i++)
                {
                    HIS.Model.ZY_PresOrder presorder = new ZY_PresOrder();
                    //Model.ZY_PresMaster premaster = new ZY_PresMaster();
                    string strWhere = Tables.zy_presorder.PRESORDERID + oleDb.EuqalTo() + presorderid[i] + oleDb.And() + Tables.zy_presorder.PATLISTID + oleDb.EuqalTo() + patlistid + oleDb.And() + Tables.zy_presorder.COSTDATE + oleDb.EuqalTo() + "'" + costdate[i] + "'";
                    DataTable dt = BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).GetList(strWhere);
                    presorder.PatID = Convert.ToInt32(dt.Rows[0]["PatID"].ToString());
                    presorder.PatListID = Convert.ToInt32(dt.Rows[0]["PatListID"].ToString());
                    presorder.PresMasterID = Convert.ToInt32(dt.Rows[0]["PresMasterID"].ToString());
                    presorder.ItemID = Convert.ToInt32(dt.Rows[0]["ItemID"].ToString());
                    presorder.ItemType = dt.Rows[0]["ItemType"].ToString();
                    presorder.PresType = dt.Rows[0]["PresType"].ToString();
                    presorder.ItemName = dt.Rows[0]["ItemName"].ToString();
                    presorder.Standard = dt.Rows[0]["Standard"].ToString();
                    presorder.Unit = dt.Rows[0]["Unit"].ToString();
                    presorder.RelationNum = Convert.ToDecimal(dt.Rows[0]["RelationNum"].ToString());
                    presorder.Buy_Price = Convert.ToDecimal(dt.Rows[0]["Buy_Price"].ToString());
                    presorder.Sell_Price = Convert.ToDecimal(dt.Rows[0]["Sell_Price"].ToString());
                    presorder.PresDocCode = dt.Rows[0]["PresDocCode"].ToString();
                    presorder.PresDeptCode = dt.Rows[0]["PresDeptCode"].ToString();
                    presorder.ExecDeptCode = dt.Rows[0]["ExecDeptCode"].ToString();
                    presorder.ChargeCode = dt.Rows[0]["ChargeCode"].ToString();
                    presorder.Drug_Flag = Convert.ToInt32(dt.Rows[0]["Drug_Flag"].ToString());
                    presorder.PresDate = Convert.ToDateTime(dt.Rows[0]["PresDate"].ToString());
                    presorder.MarkDate = Convert.ToDateTime(dt.Rows[0]["MarkDate"].ToString());
                    presorder.CostDate = serverdatetime;
                    presorder.Charge_Flag = Convert.ToInt32(dt.Rows[0]["Charge_Flag"].ToString());
                    presorder.Record_Flag = 2;
                    presorder.PackUnit = dt.Rows[0]["PackUnit"].ToString();
                    presorder.Amount = (-1) * Convert.ToDecimal(dt.Rows[0]["Amount"].ToString());
                    presorder.PresAmount = (-1) * Convert.ToInt32(dt.Rows[0]["PresAmount"].ToString());
                    presorder.Tolal_Fee = (-1) * Convert.ToDecimal(dt.Rows[0]["Tolal_Fee"].ToString());
                    presorder.OldID = presorderid[i];
                    presorder.order_id = Convert.ToInt32(dt.Rows[0]["order_id"].ToString());
                    presorder.group_id = Convert.ToInt32(dt.Rows[0]["group_id"].ToString());
                    presorder.order_type = Convert.ToInt32(dt.Rows[0]["order_type"].ToString());
                    presorder.Tolal_Fee = Convert.ToDecimal(presorder.Tolal_Fee.ToString("0.00"));
                    BindEntity<ZY_PresOrder>.CreateInstanceDAL(oleDb).Add(presorder);
                    
                    //premaster.PatListID = presorder.PatListID;
                    //premaster.PatID = presorder.PatID;
                    //premaster.PresType = Convert.ToString(0);
                    //BindEntity<ZY_PresMaster>.CreateInstanceDAL(oleDb).Add(premaster);
                    
                    //string strWhere1 = "presorderid=" + presorder.PresOrderID;
                    //string updatefile = Tables.zy_presorder.PRESMASTERID + oleDb.EuqalTo() + premaster.PresMasterID;
                    //BindEntity<HIS.Model.ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(strWhere1, updatefile);

                    string strWhere2 = "presorderid=" + presorderid[i];
                    string updateflag = Tables.zy_presorder.RECORD_FLAG + oleDb.EuqalTo() + 2;
                    BindEntity<HIS.Model.ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(strWhere2, updateflag);

                }
                oleDb.CommitTransaction();
                return true;
            }
            catch (Exception e)
            {
                oleDb.RollbackTransaction();
                return false;
                throw new Exception(e.Message);
            }
        }
            
        #endregion   
        
        public bool IsPatOut(int patlist_id)
        {
            object obj = BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetFieldValue("pattype", "patlistid=" + patlist_id + "");
            if (obj.ToString() == "3" || obj.ToString() == "4" || obj.ToString() == "5") // add by heyan 2011.5.10 .住院结算以后，护士站费用核对界面没有关闭，导致数据结算后还进行了冲账，导致费用清单的总金额与发票总费用不对
            {
                return true;
            }
            return false;
        }
    }
}
       