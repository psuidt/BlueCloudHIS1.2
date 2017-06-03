using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS;
using HIS.SYSTEM.Core;
using HIS.BLL;
using HIS.MZ_BLL.Exceptions;
using System.Data;
namespace HIS.MZ_BLL
{
    /// <summary>
    /// 票据管理类
    /// </summary>
    public class InvoiceManager : BaseBLL
    {
        /// <summary>
        /// 获取门诊票据领用记录
        /// </summary>
        /// <returns>返回DataTable</returns>
        public static System.Data.DataTable GetInvoiceRecord()
        {
           
            string[] when = new string[3];
            when[0] = oleDb.When() + Tables.mz_invoice.INVOICE_TYPE + oleDb.EuqalTo() + "0" + oleDb.Then() + "'收费'";
            when[1] = oleDb.When() + Tables.mz_invoice.INVOICE_TYPE + oleDb.EuqalTo() + "1" + oleDb.Then() + "'挂号'";
            when[2] = oleDb.Else() + "'公共'";
            string case1 = oleDb.CASEWhen( "", when );

            string[] when1 = new string[34];
            when1[0] = oleDb.When() + "A." + Tables.mz_invoice.STATUS + oleDb.EuqalTo() + "0" + oleDb.Then() + "'正常'";
            when1[1] = oleDb.When() + "A." + Tables.mz_invoice.STATUS + oleDb.EuqalTo() + "1" + oleDb.Then() + "'用完'";
            when1[2] = oleDb.When() + "A." + Tables.mz_invoice.STATUS + oleDb.EuqalTo() + "2" + oleDb.Then() + "'待用'";
            when1[3] = oleDb.Else() + "'停用'";
            string case2 = oleDb.CASEWhen( "", when1 );

            string tb = oleDb.TableNameBM( Tables.MZ_INVOICE, "A" ) + oleDb.LeftJoin() + oleDb.TableNameBM( Tables.BASE_EMPLOYEE_PROPERTY, "B" ) +
                        oleDb.ON( "A." + Tables.mz_invoice.EMPLOYEE_ID, "B." + Tables.base_employee_property.EMPLOYEE_ID ) +
                        oleDb.LeftJoin() + oleDb.TableNameBM( Tables.BASE_EMPLOYEE_PROPERTY, "C" ) +
                        oleDb.ON( "A." + Tables.mz_invoice.ALLOT_USER, "C." + Tables.base_employee_property.EMPLOYEE_ID );

            string strsql = oleDb.Table( tb, "", "",
                                            Tables.mz_invoice.ID,
                                            oleDb.FiledNameBM( case1, "INVOICE_TYPE" ),
                                            oleDb.FiledNameBM( "B." + Tables.base_employee_property.NAME, "USERNAME" ),
                                            Tables.mz_invoice.PERFCHAR,
                                             Tables.mz_invoice.START_NO,
                                             Tables.mz_invoice.END_NO,
                                             Tables.mz_invoice.CURRENT_NO,
                                            oleDb.FiledNameBM( case2, " STATUS" ),
                                            oleDb.FiledNameBM( "A." + Tables.mz_invoice.STATUS, "STATUS_FLAG" ),
                                             Tables.mz_invoice.ALLOT_DATE,
                                            oleDb.FiledNameBM( "C." + Tables.base_employee_property.NAME, "ALLOT_USER" )
                                         );

            return oleDb.GetDataTable( strsql );
        }
        /// <summary>
        /// 设置发票记录
        /// </summary>
        /// <param name="invoiceType">发票类型</param>
        /// <param name="ChargetorId">领用人ID（EmployeeId）</param>
        /// <param name="StartNo">开始号</param>
        /// <param name="EndNo">结束号</param>
        /// <param name="Operator">操作员（EmployeeId）</param>
        public static void SetInvoiceRecord( OPDBillKind invoiceType , int ChargetorId , string PerfChar, int StartNo , int EndNo , int Operator )
        {
            HIS.Model.MZ_INVOICE model_mz_invoice = new HIS.Model.MZ_INVOICE();

            model_mz_invoice.ALLOT_DATE = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            model_mz_invoice.ALLOT_USER = Operator;
            model_mz_invoice.CURRENT_NO = StartNo;
            model_mz_invoice.EMPLOYEE_ID = ChargetorId;
            model_mz_invoice.END_NO = EndNo;
            model_mz_invoice.PerfChar = PerfChar;
            model_mz_invoice.INVOICE_TYPE = (int)invoiceType;
            model_mz_invoice.START_NO = StartNo;
            model_mz_invoice.STATUS = 2;

            BindEntity<Model.MZ_INVOICE>.CreateInstanceDAL( oleDb ).Add( model_mz_invoice );
        }
        /// <summary>
        /// 设置发票停用
        /// </summary>
        /// <param name="ID">发票卷ID</param>
        public static void SetInvoiceNoUsed( int ID )
        {
            HIS.Model.MZ_INVOICE model_mz_invoice = null;

            model_mz_invoice = BindEntity<Model.MZ_INVOICE>.CreateInstanceDAL( oleDb ).GetModel( ID );
            if ( model_mz_invoice != null )
            {
                if ( model_mz_invoice.END_NO == model_mz_invoice.CURRENT_NO
                    && model_mz_invoice.STATUS == 1 )
                {
                    throw new OperatorException( "本卷发票已经使用完，不能再停用！" );
                }
                model_mz_invoice.STATUS = 3;
                BindEntity<Model.MZ_INVOICE>.CreateInstanceDAL( oleDb ).Update( model_mz_invoice );

            }
        }
        /// <summary>
        /// 检查待分配的票据起始号是否已经使用
        /// </summary>
        /// <param name="kind">票据类型</param>
        /// <param name="start">开始号</param>
        /// <param name="end">结束号</param>
        /// <param name="perfChar">前缀字符</param>
        /// <returns>true：已经使用，false：未使用</returns>
        public static bool CheckInvoiceExists( OPDBillKind kind , int start , int end ,string perfChar)
        {
            List<HIS.Model.MZ_INVOICE> invoices = null;
            invoices = BindEntity<Model.MZ_INVOICE>.CreateInstanceDAL( oleDb ).GetListArray( Tables.mz_invoice.INVOICE_TYPE + oleDb.EuqalTo() + (int)kind + oleDb.And() + oleDb.UCASE( Tables.mz_invoice.PERFCHAR) + oleDb.EuqalTo() + "'"+perfChar+"'" );
            for ( int i = 0 ; i < invoices.Count ; i++ )
            {
                switch ( invoices[i].STATUS )
                {
                    case 0:
                        //在用状态,比较范围该卷开始号到结束号
                        if ( start >= invoices[i].START_NO && start <= invoices[i].END_NO )
                        {
                            throw new OperatorException( "输入的开始号" + start + "已经包含在第" + invoices[i].ID + "卷中,并且当前正在使用" );
                        }
                        if ( end >= invoices[i].START_NO && end <= invoices[i].END_NO )
                        {
                            throw new OperatorException( "输入的结束号" + start + "已经包含在第" + invoices[i].ID + "卷中,并且当前正在使用" );
                        }
                        break;
                    case 1:
                        //用完状态,比较范围该卷开始号到结束号
                        if ( start >= invoices[i].START_NO && start <= invoices[i].END_NO )
                        {
                            throw new OperatorException( "输入的开始号" + start + "已经包含在第" + invoices[i].ID + "卷中,并已经使用过" );
                        }
                        if ( end >= invoices[i].START_NO && end <= invoices[i].END_NO )
                        {
                            throw new OperatorException( "输入的结束号" + start + "已经包含在第" + invoices[i].ID + "卷中,并已经使用过" );
                        }
                        break;
                    case 2:
                        //备用状态,比较范围该卷开始号到结束号
                        if ( start >= invoices[i].START_NO && start <= invoices[i].END_NO )
                        {
                            throw new OperatorException( "输入的开始号" + start + "已经包含在第" + invoices[i].ID + "卷备用票据中" );
                        }
                        if ( end >= invoices[i].START_NO && end <= invoices[i].END_NO )
                        {
                            throw new OperatorException( "输入的结束号" + start + "已经包含在第" + invoices[i].ID + "卷备用票据中" );
                        }
                        break;
                    case 3:
                        //停用状态,比较范围该卷开始号到停用时的当前号
                        if ( start >= invoices[i].START_NO && start <= invoices[i].CURRENT_NO )
                        {
                            throw new OperatorException( "输入的开始号" + start + "已经包含在第" + invoices[i].ID + "卷停用的票据中，如果要分配的票据号在停用卷的未使用号段中，请重新分配" );
                        }
                        if ( end >= invoices[i].START_NO && end <= invoices[i].CURRENT_NO )
                        {
                            throw new OperatorException( "输入的结束号" + start + "已经包含在第" + invoices[i].ID + "卷停用的票据中，如果要分配的票据号在停用卷的未使用号段中，请重新分配" );
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
        public static bool DeleteInvoiceVolumn( int VolumnID )
        {
            Model.MZ_INVOICE invoice = BindEntity<Model.MZ_INVOICE>.CreateInstanceDAL( oleDb ).GetModel( VolumnID );
            if ( invoice != null )
            {
                if ( invoice.STATUS == 0 )
                {
                    throw new OperatorException( "该卷发票正在使用中，不能删除" );
                }
                if ( invoice.STATUS == 1 )
                {
                    throw new OperatorException( "该卷发票已经有使用记录，不能删除" );
                }
                if ( invoice.STATUS == 3 && invoice.START_NO != invoice.CURRENT_NO )
                {
                    throw new OperatorException( "该卷发票已停用，但有部分票据已经使用过，不能删除！\r\n如果要使用未用的票据号，请将这段票据号重新分配" );
                }
            }
            try
            {
                BindEntity<Model.MZ_INVOICE>.CreateInstanceDAL( oleDb ).Delete( VolumnID );
                return true;
            }
            catch(Exception err)
            {
                ErrorWriter.WriteLog( err );
                throw new Exception( "删除票卷发生错误！" );
            }
        }
        /// <summary>
        /// 获取可用发票号
        /// </summary>
        /// <param name="billKind">发票类型</param>
        /// <param name="_operatorId">操作员</param>
        /// <param name="onlyRead">是否只读</param>
        /// <returns></returns>
        public static string GetBillNumber( OPDBillKind billKind, int _operatorId,bool onlyRead ,out string PerfChar)
        {

            string invoice_no = "";
            PerfChar = "";
            List<HIS.Model.MZ_INVOICE> invoice = null;

            //第一步：查找个人当前可用票据
            invoice = BindEntity<Model.MZ_INVOICE>.CreateInstanceDAL( oleDb ).GetListArray( "invoice_type=" + (int)billKind + " and status=0 and employee_id =" + _operatorId );
            if ( invoice.Count == 0 )
            {
                //第二步：查找个人备用票据
                invoice = BindEntity<Model.MZ_INVOICE>.CreateInstanceDAL( oleDb ).GetListArray( "invoice_type=" + (int)billKind + " and status=2 and employee_id =" + _operatorId );
                if ( invoice.Count == 0 )
                {
                    //第三步：查找公共当前在用票据
                    invoice = BindEntity<Model.MZ_INVOICE>.CreateInstanceDAL( oleDb ).GetListArray( "invoice_type=" + (int)billKind + " and status=0 and employee_id =0" );
                    if ( invoice.Count == 0 )
                    {
                        //第四步：查找公共备用票据
                        invoice = BindEntity<Model.MZ_INVOICE>.CreateInstanceDAL( oleDb ).GetListArray( "invoice_type=" + (int)billKind + " and status=2 and employee_id =0" );
                        if ( invoice.Count == 0 )
                        {
                            throw new OperatorException( "没有可用的发票！请先分配" );
                        }
                        else
                        {
                            //取得当前可用号
                            invoice_no = invoice[0].CURRENT_NO.ToString();
                            PerfChar = invoice[0].PerfChar.Trim();
                            if ( IsLastNumber( invoice[0] ) )
                            {
                                invoice[0].STATUS = 1; //置用完状态
                            }
                            else
                            {
                                invoice[0].STATUS = 0;
                                invoice[0].CURRENT_NO = invoice[0].CURRENT_NO + 1;
                            }
                            if ( !onlyRead )
                                BindEntity<Model.MZ_INVOICE>.CreateInstanceDAL( oleDb ).Update( invoice[0] );
                            return invoice_no;
                        }
                    }
                    else
                    {
                        invoice_no = invoice[0].CURRENT_NO.ToString();
                        PerfChar = invoice[0].PerfChar.Trim( );
                        if ( IsLastNumber( invoice[0] ) )
                        {
                            invoice[0].STATUS = 1; //置用完状态
                        }
                        else
                        {
                            invoice[0].CURRENT_NO = invoice[0].CURRENT_NO + 1;
                        }
                        if ( !onlyRead )
                            BindEntity<Model.MZ_INVOICE>.CreateInstanceDAL( oleDb ).Update( invoice[0] );
                        return invoice_no;
                    }
                }
                else
                {
                    invoice_no = invoice[0].CURRENT_NO.ToString();
                    PerfChar = invoice[0].PerfChar.Trim( );
                    if ( IsLastNumber( invoice[0] ) )
                    {
                        invoice[0].STATUS = 1; //置用完状态
                    }
                    else
                    {
                        invoice[0].STATUS = 0; //将备用标志改为在用标志
                        invoice[0].CURRENT_NO = invoice[0].CURRENT_NO + 1;
                    }
                    if ( !onlyRead )
                        BindEntity<Model.MZ_INVOICE>.CreateInstanceDAL( oleDb ).Update( invoice[0] );
                    return invoice_no;
                }
            }
            else
            {
                invoice_no = invoice[0].CURRENT_NO.ToString();
                PerfChar = invoice[0].PerfChar.Trim( );
                if ( IsLastNumber( invoice[0] ) )
                {
                    invoice[0].STATUS = 1; //置用完状态
                }
                else
                {
                    invoice[0].CURRENT_NO = invoice[0].CURRENT_NO + 1;
                }
                if ( !onlyRead )
                    BindEntity<Model.MZ_INVOICE>.CreateInstanceDAL( oleDb ).Update( invoice[0] );
                return invoice_no;
            }

        }
        /// <summary>
        /// 判断是否是当前卷中的最后一张票号
        /// </summary>
        /// <param name="invoice">发票卷对象(数据类型: HIS.Model.MZ_INVOICE)</param>
        /// <returns></returns>
        private static bool IsLastNumber( HIS.Model.MZ_INVOICE invoice )
        {
            if ( invoice.CURRENT_NO == invoice.END_NO )
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
        public static int GetInvoiceNumberOfCanUse( OPDBillKind billKind , int OperatorId )
        {
            int count = 0;
            List<HIS.Model.MZ_INVOICE> invoices = null;
            //第一步：查找个人当前可用票据
            invoices = BindEntity<Model.MZ_INVOICE>.CreateInstanceDAL( oleDb ).GetListArray( "invoice_type=" + (int)billKind + " and status=0 and employee_id =" + OperatorId );
            foreach ( Model.MZ_INVOICE invoice in invoices )
                count = count + ( invoice.END_NO - invoice.CURRENT_NO + 1 );

            //第二步：查找个人备用票据
            invoices = BindEntity<Model.MZ_INVOICE>.CreateInstanceDAL( oleDb ).GetListArray( "invoice_type=" + (int)billKind + " and status=2 and employee_id =" + OperatorId );
            foreach ( Model.MZ_INVOICE invoice in invoices )
                count = count + ( invoice.END_NO - invoice.CURRENT_NO + 1 );

            //第三步：查找公共当前在用票据
            invoices = BindEntity<Model.MZ_INVOICE>.CreateInstanceDAL( oleDb ).GetListArray( "invoice_type=" + (int)billKind + " and status=0 and employee_id =0" );
            foreach ( Model.MZ_INVOICE invoice in invoices )
                count = count + ( invoice.END_NO - invoice.CURRENT_NO + 1 );

            //第四步：查找公共备用票据
            invoices = BindEntity<Model.MZ_INVOICE>.CreateInstanceDAL( oleDb ).GetListArray( "invoice_type=" + (int)billKind + " and status=2 and employee_id =0" );
            foreach ( Model.MZ_INVOICE invoice in invoices )
                count = count + ( invoice.END_NO - invoice.CURRENT_NO + 1 );

            return count;
        }
        /// <summary>
        /// 调整发票号
        /// </summary>
        /// <param name="billKind"></param>
        /// <param name="OperatorId"></param>
        /// <param name="NewInvoiceNo"></param>
        /// <returns></returns>
        public static bool AdjustInvoiceNo( OPDBillKind billKind , int OperatorId ,string PerfChar ,string NewInvoiceNo )
        {
            string strWhere = Tables.mz_invoice.STATUS + oleDb.EuqalTo() + "0";
            strWhere += oleDb.And() + Tables.mz_invoice.EMPLOYEE_ID + oleDb.EuqalTo() + OperatorId;
            strWhere += oleDb.And( ) + Tables.mz_invoice.INVOICE_TYPE + oleDb.EuqalTo( ) + (int)billKind;
            strWhere += oleDb.And( ) + Tables.mz_invoice.PERFCHAR + oleDb.EuqalTo( ) + "'" + PerfChar + "'";

            Model.MZ_INVOICE mz_invoice = BindEntity<Model.MZ_INVOICE>.CreateInstanceDAL( oleDb ).GetModel( strWhere );

            long newInvoiceNo = Convert.ToInt64( NewInvoiceNo );

            if ( mz_invoice != null )
            {
                if ( newInvoiceNo > Convert.ToInt64( mz_invoice.END_NO ) )
                {
                    throw new OperatorException( "要调整的发票号不能超出本卷票的结束号！" );
                }
                if ( newInvoiceNo <= Convert.ToInt64( mz_invoice.CURRENT_NO ) )
                {
                    throw new OperatorException( "要调整的发票号不能小于当前票号！" );
                }
                BindEntity<Model.MZ_INVOICE>.CreateInstanceDAL( oleDb ).Update( strWhere , Tables.mz_invoice.CURRENT_NO + oleDb.EuqalTo( ) + newInvoiceNo );
                return true;
            }
            else
            {
                throw new OperatorException( "没有找到当前在用发票记录！" );
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
        public static void GetInvoiceListInfo(string PerfChar,string StartNo,string EndNo,
                                                    out decimal TotalMoney,out int Count,
                                                    out decimal RefundMoney,out int RefundCount)
        {
            TotalMoney = 0;
            Count = 0;
            RefundMoney = 0;
            RefundCount = 0;
            try
            {
                string sql = @"select ticketnum,record_flag,total_fee ,ticketcode
                            from
                            (
                                select ticketnum,ticketcode,record_flag,total_fee from mz_costmaster where record_flag in (0,1,2) and workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID + @"
                            ) a
                            where cast(ticketnum as bigint) between " + StartNo + " and " + EndNo + " and ticketcode='" + PerfChar + "'";
                DataTable tb = oleDb.GetDataTable( sql );
                string fileter = "record_flag in (0,1)";
                object objSum = tb.Compute( "Sum(Total_fee)" , fileter );
                TotalMoney = 0;
                if ( !Convert.IsDBNull( objSum ) )
                {
                    TotalMoney = Convert.ToDecimal( objSum );
                }
                Count = tb.Select( fileter ).Length;

                fileter = "record_flag in (1)";
                objSum = tb.Compute( "Sum(Total_fee)" , fileter );
                RefundMoney = 0;
                if ( !Convert.IsDBNull( objSum ) )
                {
                    RefundMoney = Convert.ToDecimal( objSum );
                }
                RefundCount = tb.Select( fileter ).Length;
            }
            catch ( Exception err )
            {
                ErrorWriter.WriteLog( err.Message );
                throw new Exception( "发生未知错误" );
            }

        }
        /// <summary>
        /// 格式化发票号号码
        /// </summary>
        /// <param name="invoiceNo"></param>
        /// <returns></returns>
        public static string FormatInvoiceNo( string invoiceNo )
        {
            int invoiceNoLength = Convert.ToInt32( OPDParamter.Parameters["015"] );
            if ( invoiceNo.Length < invoiceNoLength )
            {
                while ( invoiceNo.Length < invoiceNoLength )
                {
                    invoiceNo = "0" + invoiceNo;
                }
            }
            return invoiceNo;
        }
        /// <summary>
        /// 获取发票前缀字母
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_Invoice_PerfChar()
        {
            string sql = oleDb.Table( Tables.MZ_INVOICE, "", "", oleDb.FiledNameBM( oleDb.Distinct( "perfchar" ), "perfchar" ) );
            return oleDb.GetDataTable( sql );
        }
    }
}
