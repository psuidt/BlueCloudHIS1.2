using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS;
using HIS.SYSTEM.Core;
using System.Data;
using HIS.ZY_BLL.DataModel;
using HIS.ZY_BLL.Dao.Invoice;
using HIS.ZY_BLL.Dao;

namespace HIS.ZY_BLL.InvoiceManager
{

    /// <summary>
    /// 票据管理类
    /// </summary>
    public class InvoiceManager : BaseBLL
    {
        /// <summary>
        /// 获取票据领用记录
        /// </summary>
        /// <returns>返回DataTable</returns>
        public static System.Data.DataTable GetInvoiceRecord()
        {
            Iinvoice itD = DaoFactory.GetObject<Iinvoice>(typeof(InvoiceDao));
            itD.oleDb = oleDb;
            return itD.GetInvoiceRecord();
        }
        /// <summary>
        /// 获取人员列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetEmployeeList()
        {
            return BindEntity<object>.CreateInstanceDAL(oleDb, "base_employee_property").GetList("", "EMPLOYEE_ID",
                                                                                                      "NAME",
                                                                                                      "PY_CODE",
                                                                                                    "WB_CODE");
        }
        /// <summary>
        /// 设置发票记录
        /// </summary>
        /// <param name="invoiceType">发票类型</param>
        /// <param name="ChargetorId">领用人ID（EmployeeId）</param>
        /// <param name="StartNo">开始号</param>
        /// <param name="EndNo">结束号</param>
        /// <param name="Operator">操作员（EmployeeId）</param>
        public static void SetInvoiceRecord( int ChargetorId, string PerfChar, int StartNo, int EndNo, int Operator)
        {
            ZY_INVOICE model_mz_invoice = new ZY_INVOICE();

            model_mz_invoice.ALLOT_DATE = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            model_mz_invoice.ALLOT_USER = Operator;
            model_mz_invoice.CURRENT_NO = StartNo;
            model_mz_invoice.EMPLOYEE_ID = ChargetorId;
            model_mz_invoice.END_NO = EndNo;
            model_mz_invoice.PERFCHAR = PerfChar;
            model_mz_invoice.INVOICE_TYPE = 0;
            model_mz_invoice.START_NO = StartNo;
            model_mz_invoice.STATUS = 2;

            BindEntity<ZY_INVOICE>.CreateInstanceDAL(oleDb).Add(model_mz_invoice);
        }
        /// <summary>
        /// 设置发票停用
        /// </summary>
        /// <param name="ID">发票卷ID</param>
        public static void SetInvoiceNoUsed(int ID)
        {
            ZY_INVOICE model_mz_invoice = null;

            model_mz_invoice = BindEntity<ZY_INVOICE>.CreateInstanceDAL(oleDb).GetModel(ID);
            if (model_mz_invoice != null)
            {
                if (model_mz_invoice.END_NO == model_mz_invoice.CURRENT_NO
                    && model_mz_invoice.STATUS == 1)
                {
                    throw new Exception("本卷发票已经使用完，不能再停用！");
                }
                model_mz_invoice.STATUS = 3;
                BindEntity<ZY_INVOICE>.CreateInstanceDAL(oleDb).Update(model_mz_invoice);

            }
        }
        /// <summary>
        /// 检查待分配的票据起始号是否已经使用
        /// </summary>
        /// <param name="start">开始号</param>
        /// <param name="end">结束号</param>
        /// <param name="perfChar">前缀字符</param>
        /// <returns>true：已经使用，false：未使用</returns>
        public static bool CheckInvoiceExists(int start, int end, string perfChar)
        {
            List<ZY_INVOICE> invoices = null;
            invoices = BindEntity<ZY_INVOICE>.CreateInstanceDAL(oleDb).GetListArray("INVOICE_TYPE=0 and PERFCHAR ='" + perfChar + "'");
            for (int i = 0; i < invoices.Count; i++)
            {
                switch (invoices[i].STATUS)
                {
                    case 0:
                        //在用状态,比较范围该卷开始号到结束号
                        if (start >= invoices[i].START_NO && start <= invoices[i].END_NO)
                        {
                            throw new Exception("输入的开始号" + start + "已经包含在第" + invoices[i].ID + "卷中,并且当前正在使用");
                        }
                        if (end >= invoices[i].START_NO && end <= invoices[i].END_NO)
                        {
                            throw new Exception("输入的结束号" + start + "已经包含在第" + invoices[i].ID + "卷中,并且当前正在使用");
                        }
                        break;
                    case 1:
                        //用完状态,比较范围该卷开始号到结束号
                        if (start >= invoices[i].START_NO && start <= invoices[i].END_NO)
                        {
                            throw new Exception("输入的开始号" + start + "已经包含在第" + invoices[i].ID + "卷中,并已经使用过");
                        }
                        if (end >= invoices[i].START_NO && end <= invoices[i].END_NO)
                        {
                            throw new Exception("输入的结束号" + start + "已经包含在第" + invoices[i].ID + "卷中,并已经使用过");
                        }
                        break;
                    case 2:
                        //备用状态,比较范围该卷开始号到结束号
                        if (start >= invoices[i].START_NO && start <= invoices[i].END_NO)
                        {
                            throw new Exception("输入的开始号" + start + "已经包含在第" + invoices[i].ID + "卷备用票据中");
                        }
                        if (end >= invoices[i].START_NO && end <= invoices[i].END_NO)
                        {
                            throw new Exception("输入的结束号" + start + "已经包含在第" + invoices[i].ID + "卷备用票据中");
                        }
                        break;
                    case 3:
                        //停用状态,比较范围该卷开始号到停用时的当前号
                        if (start >= invoices[i].START_NO && start <= invoices[i].CURRENT_NO)
                        {
                            throw new Exception("输入的开始号" + start + "已经包含在第" + invoices[i].ID + "卷停用的票据中，如果要分配的票据号在停用卷的未使用号段中，请重新分配");
                        }
                        if (end >= invoices[i].START_NO && end <= invoices[i].CURRENT_NO)
                        {
                            throw new Exception("输入的结束号" + start + "已经包含在第" + invoices[i].ID + "卷停用的票据中，如果要分配的票据号在停用卷的未使用号段中，请重新分配");
                        }
                        break;
                }
            }
            return true;
        }
        /// <summary>
        /// 删除发票卷
        /// </summary>
        /// <param name="VolumnID">发票卷号</param>
        /// <remarks>
        /// 对于在用的，已用的，停用的但之前有使用过的不能删除
        /// 备用的，停用的但还未使用的可以删除
        /// </remarks>
        /// <returns></returns>
        public static bool DeleteInvoiceVolumn(int VolumnID)
        {
            ZY_INVOICE invoice = BindEntity<ZY_INVOICE>.CreateInstanceDAL(oleDb).GetModel(VolumnID);
            if (invoice != null)
            {
                if (invoice.STATUS == 0)
                {
                    throw new Exception("该卷发票正在使用中，不能删除");
                }
                if (invoice.STATUS == 1)
                {
                    throw new Exception("该卷发票已经有使用记录，不能删除");
                }
                if (invoice.STATUS == 3 && invoice.START_NO != invoice.CURRENT_NO)
                {
                    throw new Exception("该卷发票已停用，但有部分票据已经使用过，不能删除！\r\n如果要使用未用的票据号，请将这段票据号重新分配");
                }
            }
            try
            {
                BindEntity<ZY_INVOICE>.CreateInstanceDAL(oleDb).Delete(VolumnID);
                return true;
            }
            catch (Exception err)
            {
                //ErrorWriter.WriteLog(err.Message);
                throw new Exception(err.Message+"删除票卷发生错误！");
            }
        }
        /// <summary>
        /// 获取可用发票号
        /// </summary>
        /// <param name="_operatorId">操作员</param>
        /// <param name="onlyRead">是否只读</param>
        /// <returns></returns>
        public static string GetBillNumber( int _operatorId, bool onlyRead, out string PerfChar)
        {

            string invoice_no = "";
            PerfChar = "";
            List<ZY_INVOICE> invoice = null;

            //第一步：查找个人当前可用票据
            invoice = BindEntity<ZY_INVOICE>.CreateInstanceDAL(oleDb).GetListArray("invoice_type=" + 0 + " and status=0 and employee_id =" + _operatorId);
            if (invoice.Count == 0)
            {
                //第二步：查找个人备用票据
                invoice = BindEntity<ZY_INVOICE>.CreateInstanceDAL(oleDb).GetListArray("invoice_type=" + 0 + " and status=2 and employee_id =" + _operatorId);
                if (invoice.Count == 0)
                {
                    //第三步：查找公共当前在用票据
                    invoice = BindEntity<ZY_INVOICE>.CreateInstanceDAL(oleDb).GetListArray("invoice_type=" + 0 + " and status=0 and employee_id =0");
                    if (invoice.Count == 0)
                    {
                        //第四步：查找公共备用票据
                        invoice = BindEntity<ZY_INVOICE>.CreateInstanceDAL(oleDb).GetListArray("invoice_type=" + 0 + " and status=2 and employee_id =0");
                        if (invoice.Count == 0)
                        {
                            throw new Exception("没有可用的发票！请先分配");
                        }
                        else
                        {
                            //取得当前可用号
                            invoice_no = invoice[0].CURRENT_NO.ToString();
                            PerfChar = invoice[0].PERFCHAR.Trim();
                            if (IsLastNumber(invoice[0]))
                            {
                                invoice[0].STATUS = 1; //置用完状态
                            }
                            else
                            {
                                invoice[0].STATUS = 0;
                                invoice[0].CURRENT_NO = invoice[0].CURRENT_NO + 1;
                            }
                            if (!onlyRead)
                                BindEntity<ZY_INVOICE>.CreateInstanceDAL(oleDb).Update(invoice[0]);
                            return invoice_no;
                        }
                    }
                    else
                    {
                        invoice_no = invoice[0].CURRENT_NO.ToString();
                        PerfChar = invoice[0].PERFCHAR.Trim();
                        if (IsLastNumber(invoice[0]))
                        {
                            invoice[0].STATUS = 1; //置用完状态
                        }
                        else
                        {
                            invoice[0].CURRENT_NO = invoice[0].CURRENT_NO + 1;
                        }
                        if (!onlyRead)
                            BindEntity<ZY_INVOICE>.CreateInstanceDAL(oleDb).Update(invoice[0]);
                        return invoice_no;
                    }
                }
                else
                {
                    invoice_no = invoice[0].CURRENT_NO.ToString();
                    PerfChar = invoice[0].PERFCHAR.Trim();
                    if (IsLastNumber(invoice[0]))
                    {
                        invoice[0].STATUS = 1; //置用完状态
                    }
                    else
                    {
                        invoice[0].STATUS = 0; //将备用标志改为在用标志
                        invoice[0].CURRENT_NO = invoice[0].CURRENT_NO + 1;
                    }
                    if (!onlyRead)
                        BindEntity<ZY_INVOICE>.CreateInstanceDAL(oleDb).Update(invoice[0]);
                    return invoice_no;
                }
            }
            else
            {
                invoice_no = invoice[0].CURRENT_NO.ToString();
                PerfChar = invoice[0].PERFCHAR.Trim();
                if (IsLastNumber(invoice[0]))
                {
                    invoice[0].STATUS = 1; //置用完状态
                }
                else
                {
                    invoice[0].CURRENT_NO = invoice[0].CURRENT_NO + 1;
                }
                if (!onlyRead)
                    BindEntity<ZY_INVOICE>.CreateInstanceDAL(oleDb).Update(invoice[0]);
                return invoice_no;
            }

        }
        /// <summary>
        /// 判断是否是当前卷中的最后一张票号
        /// </summary>
        /// <param name="invoice">发票卷对象(数据类型: MZ_INVOICE)</param>
        /// <returns></returns>
        private static bool IsLastNumber(ZY_INVOICE invoice)
        {
            if (invoice.CURRENT_NO == invoice.END_NO)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获取可用发票张数
        /// </summary>
        /// <param name="billKind">发票类型</param>
        /// <param name="OperatorId">操作员ID(即EMPLOYEEID)</param>
        /// <returns></returns>
        public static int GetInvoiceNumberOfCanUse( int OperatorId)
        {
            int count = 0;
            List<ZY_INVOICE> invoices = null;
            //第一步：查找个人当前可用票据
            invoices = BindEntity<ZY_INVOICE>.CreateInstanceDAL(oleDb).GetListArray("invoice_type=" + 0 + " and status=0 and employee_id =" + OperatorId);
            foreach (ZY_INVOICE invoice in invoices)
                count = count + (invoice.END_NO - invoice.CURRENT_NO + 1);

            //第二步：查找个人备用票据
            invoices = BindEntity<ZY_INVOICE>.CreateInstanceDAL(oleDb).GetListArray("invoice_type=" + 0 + " and status=2 and employee_id =" + OperatorId);
            foreach (ZY_INVOICE invoice in invoices)
                count = count + (invoice.END_NO - invoice.CURRENT_NO + 1);

            //第三步：查找公共当前在用票据
            invoices = BindEntity<ZY_INVOICE>.CreateInstanceDAL(oleDb).GetListArray("invoice_type=" + 0 + " and status=0 and employee_id =0");
            foreach (ZY_INVOICE invoice in invoices)
                count = count + (invoice.END_NO - invoice.CURRENT_NO + 1);

            //第四步：查找公共备用票据
            invoices = BindEntity<ZY_INVOICE>.CreateInstanceDAL(oleDb).GetListArray("invoice_type=" + 0 + " and status=2 and employee_id =0");
            foreach (ZY_INVOICE invoice in invoices)
                count = count + (invoice.END_NO - invoice.CURRENT_NO + 1);

            return count;
        }
        /// <summary>
        /// 调整发票号
        /// </summary>
        /// <param name="billKind"></param>
        /// <param name="OperatorId"></param>
        /// <param name="NewInvoiceNo"></param>
        /// <returns></returns>
        public static bool AdjustInvoiceNo(int OperatorId, string PerfChar, string NewInvoiceNo)
        {
            string strWhere = "STATUS =0";
            strWhere += " and EMPLOYEE_ID ="+ OperatorId;
            strWhere += " and INVOICE_TYPE=0";
            strWhere += " and PERFCHAR ='" + PerfChar + "'";

            ZY_INVOICE mz_invoice = BindEntity<ZY_INVOICE>.CreateInstanceDAL(oleDb).GetModel(strWhere);

            long newInvoiceNo = Convert.ToInt64(NewInvoiceNo);

            if (mz_invoice != null)
            {
                if (newInvoiceNo > Convert.ToInt64(mz_invoice.END_NO))
                {
                    throw new Exception("要调整的发票号不能超出本卷票的结束号！");
                }
                if (newInvoiceNo <= Convert.ToInt64(mz_invoice.CURRENT_NO))
                {
                    throw new Exception("要调整的发票号不能小于当前票号！");
                }
                BindEntity<ZY_INVOICE>.CreateInstanceDAL(oleDb).Update(strWhere, "CURRENT_NO =" + newInvoiceNo+"");
                return true;
            }
            else
            {
                throw new Exception("没有找到当前在用发票记录！");
            }
        }
        /// <summary>
        /// 得到发票信息
        /// </summary>
        /// <param name="PerfChar"></param>
        /// <param name="StartNo"></param>
        /// <param name="EndNo"></param>
        /// <param name="TotalMoney"></param>
        /// <param name="Count"></param>
        /// <param name="RefundMoney"></param>
        /// <param name="RefundCount"></param>
        public static void GetInvoiceListInfo(string PerfChar, string StartNo, string EndNo,
                                                    out decimal TotalMoney, out int Count,
                                                    out decimal RefundMoney, out int RefundCount)
        {
            TotalMoney = 0;
            Count = 0;
            RefundMoney = 0;
            RefundCount = 0;
            try
            {
                
                string str="(";
                for (int i = Convert.ToInt32(StartNo); i <= Convert.ToInt32(EndNo); i++)
                {
                    if (i != Convert.ToInt32(EndNo))
                        str = str + "'"+PerfChar + i.ToString() + "',";
                    else
                        str = str +"'"+ PerfChar + i.ToString() + "')";
                }

                string strWhere = " RECORD_FLAG in (0,1,2) and TICKETCODE in " + str;


                DataTable tb = BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).GetList(strWhere,"TICKETCODE",
                    "TOTAL_FEE",
                    "RECORD_FLAG",
                    "TICKETNUM");
                string fileter = "record_flag in (0,1)";
                object objSum = tb.Compute("Sum(Total_fee)", fileter);
                TotalMoney = 0;
                if (!Convert.IsDBNull(objSum))
                {
                    TotalMoney = Convert.ToDecimal(objSum);
                }
                Count = tb.Select(fileter).Length;

                fileter = "record_flag in (1)";
                objSum = tb.Compute("Sum(Total_fee)", fileter);
                RefundMoney = 0;
                if (!Convert.IsDBNull(objSum))
                {
                    RefundMoney = Convert.ToDecimal(objSum);
                }
                RefundCount = tb.Select(fileter).Length;
            }
            catch (Exception err)
            {
                //ErrorWriter.WriteLog(err.Message);
                throw new Exception(err.Message+"发生未知错误");
            }

        }
    }
}
