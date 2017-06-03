using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.Model;
using HIS.BLL;
using System.Data;
using HIS.MSAccess;

namespace HIS_DJSFManager.类
{
    /// <summary>
    /// 票据管理类
    /// </summary>
    public class InvoiceManager 
    {
        ///// <summary>
        ///// 获取门诊票据领用记录
        ///// </summary>
        ///// <returns>返回DataTable</returns>
        public static System.Data.DataTable GetInvoiceRecord()
        {
            string sql = @"select ID,iif(INVOICE_TYPE=0,'收费','挂号') as INVOICE_TYPE,
                            B.NAME as USERNAME,PERFCHAR,START_NO,END_NO,CURRENT_NO,
                            '' as  STATUS,
                            A.STATUS as STATUS_FLAG
                            from  mz_invoice  as A 
                            Left Join  base_employee_property as B on A.EMPLOYEE_ID = B.EMPLOYEE_ID   ";
            DataTable tb = MSAccessDb.GetDataTable( sql );
            for ( int i = 0 ; i < tb.Rows.Count ; i++ )
            {
                int status_flag = Convert.ToInt32( tb.Rows[i]["STATUS_FLAG"] );
                switch ( status_flag )
                {
                    case 0:
                        tb.Rows[i]["STATUS"] = "正常";
                        break;
                    case 1:
                        tb.Rows[i]["STATUS"] = "用完";
                        break;
                    case 2:
                        tb.Rows[i]["STATUS"] = "待用";
                        break;
                    case 3:
                        tb.Rows[i]["STATUS"] = "停用";
                        break;
                }
            }
            return tb;
        }
        /// <summary>
        /// 设置发票记录
        /// </summary>
        /// <param name="invoiceType">发票类型</param>
        /// <param name="ChargetorId">领用人ID（EmployeeId）</param>
        /// <param name="StartNo">开始号</param>
        /// <param name="EndNo">结束号</param>
        /// <param name="Operator">操作员（EmployeeId）</param>
        public static void SetInvoiceRecord( OPDBillKind invoiceType , int ChargetorId , string PerfChar , int StartNo , int EndNo , int Operator )
        {
            HIS.Model.MZ_INVOICE model_mz_invoice = new HIS.Model.MZ_INVOICE();

            model_mz_invoice.ALLOT_DATE = DateTime.Now;
            model_mz_invoice.ALLOT_USER = Operator;
            model_mz_invoice.CURRENT_NO = StartNo;
            model_mz_invoice.EMPLOYEE_ID = ChargetorId;
            model_mz_invoice.END_NO = EndNo;
            model_mz_invoice.INVOICE_TYPE = (int)invoiceType;
            model_mz_invoice.START_NO = StartNo;
            model_mz_invoice.STATUS = 2;
            model_mz_invoice.PerfChar = PerfChar;
            model_mz_invoice.ID = MSAccessDb.GetMaxID( "MZ_INVOICE" , Tables.mz_invoice.ID );

            MSAccessDb.InsertRecord( model_mz_invoice , Tables.mz_invoice.ID );
        }
        /// <summary>
        /// 设置发票停用
        /// </summary>
        /// <param name="ID">发票卷ID</param>
        public static void SetInvoiceNoUsed( int ID )
        {
            HIS.Model.MZ_INVOICE model_mz_invoice = null;
            model_mz_invoice = (MZ_INVOICE)MSAccessDb.GetModel( "MZ_INVOICE" , "ID=" + ID , typeof( MZ_INVOICE ) );
            if ( model_mz_invoice != null )
            {
                if ( model_mz_invoice.END_NO == model_mz_invoice.CURRENT_NO
                    && model_mz_invoice.STATUS == 1 )
                {
                    throw new Exception( "本卷发票已经使用完，不能再停用！" );
                }
                model_mz_invoice.STATUS = 3;
                //BindEntity<MZ_INVOICE>.CreateInstanceDAL( oleDb ).Update( model_mz_invoice );
                MSAccessDb.UpdateRecord( model_mz_invoice );
            }
        }
        /// <summary>
        /// 检查待分配的票据起始号是否已经使用
        /// </summary>
        /// <param name="kind">票据类型</param>
        /// <param name="start">开始号</param>
        /// <param name="end">结束号</param>
        /// <returns>true：已经使用，false：未使用</returns>
        public static bool CheckInvoiceExists( OPDBillKind kind , int start , int end , string perfChar )
        {
            List<HIS.Model.MZ_INVOICE> invoices = null;
            //invoices = BindEntity<MZ_INVOICE>.CreateInstanceDAL( oleDb ).GetListArray( Tables.mz_invoice.INVOICE_TYPE + oleDb.EuqalTo() + (int)kind );
            invoices = MSAccessDb.GetListArray<MZ_INVOICE>( "MZ_INVOICE",Tables.mz_invoice.INVOICE_TYPE + "=" + (int)kind + " and " + Tables.mz_invoice.PERFCHAR + "='" + perfChar + "'" );
            for ( int i = 0 ; i < invoices.Count ; i++ )
            {
                switch ( invoices[i].STATUS )
                {
                    case 0:
                        //在用状态,比较范围该卷开始号到结束号
                        if ( start >= invoices[i].START_NO && start <= invoices[i].END_NO )
                        {
                            throw new Exception( "输入的开始号" + start + "已经包含在第" + invoices[i].ID + "卷中,并且当前正在使用" );
                        }
                        if ( end >= invoices[i].START_NO && end <= invoices[i].END_NO )
                        {
                            throw new Exception( "输入的结束号" + start + "已经包含在第" + invoices[i].ID + "卷中,并且当前正在使用" );
                        }
                        break;
                    case 1:
                        //用完状态,比较范围该卷开始号到结束号
                        if ( start >= invoices[i].START_NO && start <= invoices[i].END_NO )
                        {
                            throw new Exception( "输入的开始号" + start + "已经包含在第" + invoices[i].ID + "卷中,并已经使用过" );
                        }
                        if ( end >= invoices[i].START_NO && end <= invoices[i].END_NO )
                        {
                            throw new Exception( "输入的结束号" + start + "已经包含在第" + invoices[i].ID + "卷中,并已经使用过" );
                        }
                        break;
                    case 2:
                        //备用状态,比较范围该卷开始号到结束号
                        if ( start >= invoices[i].START_NO && start <= invoices[i].END_NO )
                        {
                            throw new Exception( "输入的开始号" + start + "已经包含在第" + invoices[i].ID + "卷备用票据中" );
                        }
                        if ( end >= invoices[i].START_NO && end <= invoices[i].END_NO )
                        {
                            throw new Exception( "输入的结束号" + start + "已经包含在第" + invoices[i].ID + "卷备用票据中" );
                        }
                        break;
                    case 3:
                        //停用状态,比较范围该卷开始号到停用时的当前号
                        if ( start >= invoices[i].START_NO && start <= invoices[i].CURRENT_NO )
                        {
                            throw new Exception( "输入的开始号" + start + "已经包含在第" + invoices[i].ID + "卷停用的票据中，如果要分配的票据号在停用卷的未使用号段中，请重新分配" );
                        }
                        if ( end >= invoices[i].START_NO && end <= invoices[i].CURRENT_NO )
                        {
                            throw new Exception( "输入的结束号" + start + "已经包含在第" + invoices[i].ID + "卷停用的票据中，如果要分配的票据号在停用卷的未使用号段中，请重新分配" );
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
            MZ_INVOICE invoice = (MZ_INVOICE)MSAccessDb.GetModel( "MZ_INVOICE" , Tables.mz_invoice.ID + "=" + VolumnID , typeof( MZ_INVOICE ) );
            if ( invoice != null )
            {
                if ( invoice.STATUS == 0 )
                {
                    throw new Exception( "该卷发票正在使用中，不能删除" );
                }
                if ( invoice.STATUS == 1 )
                {
                    throw new Exception( "该卷发票已经有使用记录，不能删除" );
                }
                if ( invoice.STATUS == 3 && invoice.START_NO != invoice.CURRENT_NO )
                {
                    throw new Exception( "该卷发票已停用，但有部分票据已经使用过，不能删除！\r\n如果要使用未用的票据号，请将这段票据号重新分配" );
                }
            }
            try
            {
                string sql = "delete * from mz_invoice where id=" + VolumnID;
                MSAccessDb.Execute( sql );
                return true;
            }
            catch(Exception err)
            {
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
        public static string GetBillNumber( OPDBillKind billKind , int _operatorId , bool onlyRead , out string PerfChar )
        {

            string invoice_no = "";
            PerfChar = "";
            List<HIS.Model.MZ_INVOICE> invoice = null;

            //第一步：查找个人当前可用票据
            invoice = MSAccessDb.GetListArray<MZ_INVOICE>( "MZ_INVOICE","invoice_type=" + (int)billKind + " and status=0 and employee_id =" + _operatorId );
            if ( invoice.Count == 0 )
            {
                //第二步：查找个人备用票据
                invoice = MSAccessDb.GetListArray<MZ_INVOICE>( "MZ_INVOICE" , "invoice_type=" + (int)billKind + " and status=2 and employee_id =" + _operatorId );
                if ( invoice.Count == 0 )
                {
                    //第三步：查找公共当前在用票据
                    invoice = MSAccessDb.GetListArray<MZ_INVOICE>( "MZ_INVOICE" , "invoice_type=" + (int)billKind + " and status=0 and employee_id =0" );
                    if ( invoice.Count == 0 )
                    {
                        //第四步：查找公共备用票据
                        invoice = MSAccessDb.GetListArray<MZ_INVOICE>( "MZ_INVOICE" , "invoice_type=" + (int)billKind + " and status=2 and employee_id =0" );
                        if ( invoice.Count == 0 )
                        {
                            throw new Exception( "没有可用的发票！请先分配" );
                        }
                        else
                        {
                            //取得当前可用号
                            invoice_no = invoice[0].CURRENT_NO.ToString();
                            PerfChar = invoice[0].PerfChar.Trim( );
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
                            {
                                MSAccessDb.UpdateRecord( invoice[0] );
                            }
                                //BindEntity<MZ_INVOICE>.CreateInstanceDAL( oleDb ).Update( invoice[0] );

                            return invoice_no;
                        }
                    }
                    else
                    {
                        invoice_no = invoice[0].CURRENT_NO.ToString( );
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
                            MSAccessDb.UpdateRecord( invoice[0] );
                            //BindEntity<MZ_INVOICE>.CreateInstanceDAL( oleDb ).Update( invoice[0] );
                        return invoice_no;
                    }
                }
                else
                {
                    invoice_no = invoice[0].CURRENT_NO.ToString( );
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
                        MSAccessDb.UpdateRecord( invoice[0] );
                        //BindEntity<MZ_INVOICE>.CreateInstanceDAL( oleDb ).Update( invoice[0] );
                    return invoice_no;
                }
            }
            else
            {
                invoice_no = invoice[0].CURRENT_NO.ToString( );
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
                    MSAccessDb.UpdateRecord( invoice[0] );
                    //BindEntity<MZ_INVOICE>.CreateInstanceDAL( oleDb ).Update( invoice[0] );
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
            invoices = MSAccessDb.GetListArray<MZ_INVOICE>( "MZ_INVOICE" , "invoice_type=" + (int)billKind + " and status=0 and employee_id =" + OperatorId );
            foreach ( MZ_INVOICE invoice in invoices )
                count = count + ( invoice.END_NO - invoice.CURRENT_NO + 1 );

            //第二步：查找个人备用票据
            invoices = MSAccessDb.GetListArray<MZ_INVOICE>( "MZ_INVOICE" , "invoice_type=" + (int)billKind + " and status=2 and employee_id =" + OperatorId );
            foreach ( MZ_INVOICE invoice in invoices )
                count = count + ( invoice.END_NO - invoice.CURRENT_NO + 1 );

            //第三步：查找公共当前在用票据
            invoices = MSAccessDb.GetListArray<MZ_INVOICE>( "MZ_INVOICE" , "invoice_type=" + (int)billKind + " and status=0 and employee_id =0" );
            foreach ( MZ_INVOICE invoice in invoices )
                count = count + ( invoice.END_NO - invoice.CURRENT_NO + 1 );

            //第四步：查找公共备用票据
            invoices = MSAccessDb.GetListArray<MZ_INVOICE>( "MZ_INVOICE" , "invoice_type=" + (int)billKind + " and status=2 and employee_id =0" );
            foreach ( MZ_INVOICE invoice in invoices )
                count = count + ( invoice.END_NO - invoice.CURRENT_NO + 1 );

            return count;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="billKind"></param>
        /// <param name="OperatorId"></param>
        /// <param name="NewInvoiceNo"></param>
        /// <returns></returns>
        public static bool AdjustInvoiceNo( OPDBillKind billKind , int OperatorId ,string NewInvoiceNo )
        {
            string strWhere = Tables.mz_invoice.STATUS +  " = 0";
            strWhere += " and " + Tables.mz_invoice.EMPLOYEE_ID + " = " + OperatorId;
            strWhere += " and " + Tables.mz_invoice.INVOICE_TYPE + " = " + (int)billKind;

            MZ_INVOICE mz_invoice = (MZ_INVOICE)MSAccessDb.GetModel( "MZ_INVOICE" , strWhere , typeof( MZ_INVOICE ) );
            long newInvoiceNo = Convert.ToInt64( NewInvoiceNo );

            if ( mz_invoice != null )
            {
                if ( newInvoiceNo > Convert.ToInt64( mz_invoice.END_NO ) )
                {
                    throw new Exception( "要调整的发票号不能超出本卷票的结束号！" );
                }
                if ( newInvoiceNo <= Convert.ToInt64( mz_invoice.CURRENT_NO ) )
                {
                    throw new Exception( "要调整的发票号不能小于当前票号！" );
                }
                //BindEntity<MZ_INVOICE>.CreateInstanceDAL( oleDb ).Update( strWhere , Tables.mz_invoice.CURRENT_NO + oleDb.EuqalTo( ) + newInvoiceNo );
                MSAccessDb.UpdateRecord(new string[]{Tables.mz_invoice.CURRENT_NO + " = " + newInvoiceNo},
                                      strWhere,typeof(MZ_INVOICE));
                return true;
            }
            else
            {
                throw new Exception( "没有找到当前在用发票记录！" );
            }
        }
    }
}
