using System;
using System.Collections.Generic;
using System.Text;

using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS.ZYNurse_BLL
{
    public abstract class AbstractOrderOperation:BaseBLL
    {
        private int employeeid;
        public int Employeeid
        {
            get { return employeeid; }
            set { employeeid = value;}
        }

        private DateTime serverTime;
        public DateTime ServerTime
        {
            get { return serverTime; }
            set { serverTime = value;}
        }

        private int orderid;
        public int Orderid
        {
            get { return orderid;}
            set { orderid = value;}
        }
        
        private ZY_DOC_ORDERRECORD zy_doc_orderrecord;
        public ZY_DOC_ORDERRECORD Zy_doc_orderrecord
        {
            get { return zy_doc_orderrecord; }
            set { zy_doc_orderrecord = value; }
        }
        protected void insertlongorderexec(ZY_DOC_ORDERRECORD zy_doc_orderrecord, long employeeid, DateTime serverdatetime)
        {
            try
            {
                //string strWhere = Tables.zy_doc_orderrecord.ORDER_ID + oleDb.EuqalTo() + orderid;
                //object obj = BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetFieldValue(Tables.zy_doc_orderrecord.PATID, strWhere);
                //int patlistid = int.Parse(obj.ToString());
                string frequencys;
                int patlistid = zy_doc_orderrecord.PATID;
                string time = serverdatetime.ToString("yyyy-MM-dd");
                string realtime = XcDate.ServerDateTime.ToString("yyyy-MM-dd");

                if (zy_doc_orderrecord.FREQUENCY=="")
                {
                    frequencys = "Qd";
                }
                else
                {
                    frequencys = zy_doc_orderrecord.FREQUENCY;
                }
                
                string strWhere1 = Tables.base_frequency.NAME + oleDb.EuqalTo() + "'" + frequencys + "'";
                object obj1 = BindEntity<Base_Frequency>.CreateInstanceDAL(oleDb).GetFieldValue(Tables.base_frequency.CYCLEDAY, strWhere1);
                int cycleday = int.Parse(obj1.ToString());

                if (cycleday == 1)
                {
                    string[] filedname = new string[5];
                    filedname[0] = Tables.zy_nurse_orderexec.ORDER_ID;
                    filedname[1] = Tables.zy_nurse_orderexec.EXEC_DATE;
                    filedname[2] = Tables.zy_nurse_orderexec.EXEC_USER;
                    filedname[3] = Tables.zy_nurse_orderexec.PATIENT_ID;
                    filedname[4] = Tables.zy_nurse_orderexec.REALEXEC_TIME;

                    string[] values = new string[5];
                    values[0] = zy_doc_orderrecord.ORDER_ID.ToString();
                    values[1] = "'" + time + "'";
                    values[2] = employeeid.ToString();
                    values[3] = patlistid.ToString();
                    values[4] = "'" + realtime + "'";

                    bool[] questiong = new bool[5];
                    questiong[0] = false;
                    questiong[1] = false;
                    questiong[2] = false;
                    questiong[3] = false;
                    questiong[4] = false;
                    BindEntity<HIS.Model.ZY_NURSE_ORDEREXEC>.CreateInstanceDAL(oleDb).Add(filedname, values, questiong);
                }
                else
                {
                    for (int i = 0; i < cycleday; i++)
                    {
                        time = serverdatetime.AddDays(i).ToString("yyyy-MM-dd");

                        string[] filedname = new string[5];
                        filedname[0] = Tables.zy_nurse_orderexec.ORDER_ID;
                        filedname[1] = Tables.zy_nurse_orderexec.EXEC_DATE;
                        filedname[2] = Tables.zy_nurse_orderexec.EXEC_USER;
                        filedname[3] = Tables.zy_nurse_orderexec.PATIENT_ID;
                        filedname[4] = Tables.zy_nurse_orderexec.REALEXEC_TIME;

                        string[] values = new string[5];
                        values[0] = zy_doc_orderrecord.ORDER_ID.ToString();
                        values[1] = "'" + time + "'";
                        values[2] = employeeid.ToString();
                        values[3] = patlistid.ToString();
                        values[4] = "'" + realtime + "'";

                        bool[] questiong = new bool[5];
                        questiong[0] = false;
                        questiong[1] = false;
                        questiong[2] = false;
                        questiong[3] = false;
                        questiong[4] = false;
                        BindEntity<HIS.Model.ZY_NURSE_ORDEREXEC>.CreateInstanceDAL(oleDb).Add(filedname, values, questiong);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
        protected void insertorderexec(int orderid, long employeeid,DateTime serverdatetime)
        {
            try
            {
                string strWhere = Tables.zy_doc_orderrecord.ORDER_ID + oleDb.EuqalTo() + orderid;
                object obj = BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetFieldValue(Tables.zy_doc_orderrecord.PATID, strWhere);
                int patlistid = int.Parse(obj.ToString());
                string time =serverdatetime.ToString("yyyy-MM-dd");

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

                bool[] questiong = new bool[4];
                questiong[0] = false;
                questiong[1] = false;
                questiong[2] = false;
                questiong[3] = false;

                BindEntity<HIS.Model.ZY_NURSE_ORDEREXEC>.CreateInstanceDAL(oleDb).Add(filedname, values, questiong);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        protected void updateLongOrderFlag(int orderid)
        {
            string strWhere1 = "order_id=" + orderid;
            object obj = BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetFieldValue(Tables.zy_doc_orderrecord.STATUS_FALG, strWhere1);
            int status_flag = int.Parse(obj.ToString());
            if (status_flag == 2)
            {
                string strWhere3 = " order_id=" + orderid;//10月21日增加
                string strSet = Tables.zy_doc_orderrecord.NOEXE_FLAG + oleDb.EuqalTo() + 1;
                BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strWhere3, strSet);
                return;
            }
            else
            {
                string strWhere2 = " order_id=" + orderid;
                string strSet = Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + 5;
                BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strWhere2, strSet);
                return;
            }
        }

        protected void updateTempOrderFlag(int orderid)
        {
            string strWhere2 = "order_id=" + orderid;
            string strSet = Tables.zy_doc_orderrecord.STATUS_FALG + oleDb.EuqalTo() + 5;
            BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Update(strWhere2, strSet);
            return;
        }      
     
        public abstract void Send(int orderid, DateTime servertime,ZY_DOC_ORDERRECORD zy_doc_orderrecord,List<int> grouplist);
    }
}
  