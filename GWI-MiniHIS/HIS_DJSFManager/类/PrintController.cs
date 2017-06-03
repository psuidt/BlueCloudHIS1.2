using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Data;
using grproLib;

namespace HIS_DJSFManager.类
{
    public class PrintController
    {
        private static string chargeInvoiceTemplatePath = Application.StartupPath + "\\report\\门诊收费发票模板.grf";
        private static string accountbookTemplatePath = Application.StartupPath + "\\report\\门诊个人交款表模板.grf";


        private static GridppReport gridppReport = new GridppReport( );
        private static DataTable tbPrintData;

        public static bool ChargeInvocieTemplateExists()
        {
            if ( !File.Exists( chargeInvoiceTemplatePath ) )
            {
                return false;
            }
            else
            {
                return true;
            }
        }       
        
               
        static void reportPrinter_FetchRecord( ref bool pEof )
        {
            GWI_DesReport.HisReport.FillRecordToReport( gridppReport , tbPrintData );
        }

        
        /// <summary>
        /// 打印门诊发票
        /// </summary>
        /// <param name="invoices"></param>
        public static void PrintChargeInvoice( Invoice[] invoices )
        {
            //打印前预览参数控制
            bool previewBeforPrint = false;
            

            //发票是否打印明细控制
            bool printDetail = false;
            

            GridppReport rpt = new GridppReport( );
            //string printerName = HIS_PublicManager.PublicPrintSet.GetPrinterNameByReport( "门诊收费发票模板.grf" );
            
            rpt.LoadFromFile( chargeInvoiceTemplatePath );

            //rpt.Printer.PrinterName = printerName;

            for ( int i = 0 ; i < invoices.Length ; i++ )
            {
                try
                {
                    rpt.ParameterByName( "医院名称" ).AsString = "";
                    rpt.ParameterByName( "发票号" ).AsString = invoices[i].InvoiceNo;
                    rpt.ParameterByName( "年" ).AsString = invoices[i].ChargeDate.Year.ToString( );
                    rpt.ParameterByName( "月" ).AsString = invoices[i].ChargeDate.Month.ToString( );
                    rpt.ParameterByName( "日" ).AsString = invoices[i].ChargeDate.Day.ToString( );
                    rpt.ParameterByName( "姓名" ).AsString = invoices[i].PatientName;
                    rpt.ParameterByName( "结算方式" ).AsString = invoices[i].PayType;
                    rpt.ParameterByName( "万" ).AsString = GetNumCN(invoices[i].TotalPay, NumericUnit.万);
                    rpt.ParameterByName( "千" ).AsString = GetNumCN( invoices[i].TotalPay , NumericUnit.仟 );
                    rpt.ParameterByName( "百" ).AsString = GetNumCN( invoices[i].TotalPay , NumericUnit.佰 );
                    rpt.ParameterByName( "拾" ).AsString = GetNumCN( invoices[i].TotalPay , NumericUnit.拾 );
                    rpt.ParameterByName( "元" ).AsString = GetNumCN( invoices[i].TotalPay , NumericUnit.元 );
                    rpt.ParameterByName( "角" ).AsString = GetNumCN( invoices[i].TotalPay , NumericUnit.角 );
                    rpt.ParameterByName( "分" ).AsString = GetNumCN( invoices[i].TotalPay , NumericUnit.分 );
                    rpt.ParameterByName( "记账金额" ).AsString = invoices[i].VillagePay.ToString( );
                    rpt.ParameterByName( "个人缴费金额" ).AsString = Convert.ToString( invoices[i].TotalPay - invoices[i].VillagePay - invoices[i].FavorPay );
                    if ( invoices[i].FavorPay > 0 )
                    {
                        rpt.ParameterByName( "优惠金额" ).AsString = "(优惠:" + Convert.ToString( invoices[i].FavorPay ) + ")";
                    }
                    else
                    {
                        rpt.ParameterByName( "优惠金额" ).AsString = "";
                    }

                    rpt.ParameterByName( "发票总金额" ).AsString = invoices[i].TotalPay.ToString( );
                    rpt.ParameterByName( "收费员" ).AsString = invoices[i].ChargeUser;
                    

                    for ( int m = 0 ; m < invoices[i].Items.Length ; m++ )
                    {
                        try
                        {
                            if ( invoices[i].Items[m].ItemName.Trim( ) == "挂号费" && invoices[i].Items[m].Cost > 0 )
                            {
                                rpt.ParameterByName( "发票项目_" + invoices[i].Items[m].ItemName.Trim( ) ).AsString = "挂号费：" + invoices[i].Items[m].Cost.ToString( );
                            }
                            else
                            {
                                rpt.ParameterByName( "发票项目_" + invoices[i].Items[m].ItemName.Trim( ) ).AsString = invoices[i].Items[m].Cost.ToString( );
                            }
                        }
                        catch(Exception err) 
                        {
                            continue;
                        }
                    }


                    for ( int m = 0 ; m < invoices[i].StatItems.Length ; m++ )
                    {
                        try
                        {
                            rpt.ParameterByName( "大项目_" + invoices[i].StatItems[m].ItemName.Trim() ).AsString = invoices[i].StatItems[m].Cost.ToString( );
                        }
                        catch(Exception err)
                        {
                            continue;
                        }
                    }
                }
                catch
                {
                    throw new Exception( "调用报表模板参数赋值发生错误！" );   
                }
                previewBeforPrint = true;
                if ( previewBeforPrint )
                {
                    rpt.PrintPreview( false );
                }
                rpt.Print( false );
            }
        }
        /// <summary>
        /// 打印个人交款表
        /// </summary>
        /// <param name="accountBook"></param>
        public static void PrintAccountBook( PrivyAccountBook accountBook )
        {
            grproLib.GridppReport reportPrinter = new grproLib.GridppReport( );

            
            reportPrinter.LoadFromFile( accountbookTemplatePath );

            
            reportPrinter.Title = "门诊个人交款表";
            try
            {
                //传入参数
                reportPrinter.ParameterByName( "医院名称" ).AsString = "" + "每日交费清单";
                reportPrinter.ParameterByName( "交款人" ).AsString = accountBook.TollCollectorName;
                reportPrinter.ParameterByName( "交款时间" ).AsString = accountBook.AccountBookDate.Value.ToString( "yyyy-MM-dd HH:mm:ss" );
                //传入交款科目
                for ( int i = 0 ; i < accountBook.InvoiceItem.Length ; i++ )
                {
                    try
                    {
                        reportPrinter.ParameterByName( accountBook.InvoiceItem[i].ItemName.Trim( ) ).AsString = accountBook.InvoiceItem[i].Cost.ToString( );
                    }
                    catch
                    {
                        MessageBox.Show( "没有找到参数:" + accountBook.InvoiceItem[i].ItemName + ",请确认模板中有该参数！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                        continue;
                    }
                }
                reportPrinter.ParameterByName( "发票科目合计" ).AsString = accountBook.InvoiceItemSumTotal.ToString( );

                reportPrinter.ParameterByName( "收费发票开始号" ).AsString = accountBook.ChargeInvoiceInfo.StartNumber;
                reportPrinter.ParameterByName( "收费发票结束号" ).AsString = accountBook.ChargeInvoiceInfo.EndNumber;
                reportPrinter.ParameterByName( "收费发票张数" ).AsString = accountBook.ChargeInvoiceInfo.Count.ToString( );
                reportPrinter.ParameterByName( "收费退费张数" ).AsString = accountBook.ChargeInvoiceInfo.RefundCount.ToString( );
                reportPrinter.ParameterByName( "收费退费金额" ).AsString = accountBook.ChargeInvoiceInfo.RefundMoney.ToString( );

                reportPrinter.ParameterByName( "挂号发票开始号" ).AsString = accountBook.RegisterInvoiceInfo.StartNumber;
                reportPrinter.ParameterByName( "挂号发票结束号" ).AsString = accountBook.RegisterInvoiceInfo.EndNumber;
                reportPrinter.ParameterByName( "挂号发票张数" ).AsString = accountBook.RegisterInvoiceInfo.Count.ToString( );
                reportPrinter.ParameterByName( "挂号退费张数" ).AsString = accountBook.RegisterInvoiceInfo.RefundCount.ToString( );
                reportPrinter.ParameterByName( "挂号退费金额" ).AsString = accountBook.RegisterInvoiceInfo.RefundMoney.ToString( );
                //按病人类型记账部分
                int tallyCount = 0;
                for ( int i = 0 ; i < accountBook.TallyPart.Details.Length ; i++ )
                {
                    reportPrinter.ParameterByName( accountBook.TallyPart.Details[i].PayName ).AsString = accountBook.TallyPart.Details[i].Money.ToString( );
                    reportPrinter.ParameterByName( accountBook.TallyPart.Details[i].PayName + "_张数" ).AsString = accountBook.TallyPart.Details[i].BillCount.ToString( );
                    tallyCount = tallyCount + accountBook.TallyPart.Details[i].BillCount;
                }
                reportPrinter.ParameterByName( "记账合计" ).AsString = accountBook.TallyPart.TotalMoney.ToString( );
                reportPrinter.ParameterByName( "记账合计张数" ).AsString = tallyCount.ToString( );

                reportPrinter.ParameterByName( "优惠金额" ).AsString = accountBook.FavorPart.TotalMoney.ToString( );
                //现金部分
                reportPrinter.ParameterByName( "实收现金" ).AsString = accountBook.CashPart.TotalMoney.ToString( );
                reportPrinter.ParameterByName( "挂号现金" ).AsString = accountBook.CashPart.Details[1].Money.ToString( );
                reportPrinter.ParameterByName( "挂号诊金" ).AsString = accountBook.CashPart.Details[2].Money.ToString( );
                reportPrinter.ParameterByName( "处方收费" ).AsString = accountBook.CashPart.Details[0].Money.ToString( );

                reportPrinter.ParameterByName( "小写合计" ).AsString = accountBook.InvoiceItemSumTotal.ToString( );
                reportPrinter.ParameterByName( "大写合计" ).AsString = "";//HIS.SYSTEM.PubicBaseClasses.Money.NumToChn( accountBook.InvoiceItemSumTotal.ToString( ) );
                reportPrinter.PrintPreview( false );

            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }
        }
        /// <summary>
        /// 返回数值指定的单位的中文大写
        /// </summary>
        /// <param name="numberic"></param>
        /// <param name="CN"></param>
        /// <returns></returns>
        public static string GetNumCN( decimal numberic , NumericUnit CN )
        {
            decimal w =  numberic - ( numberic % 10000 ) ;
            decimal q = ( numberic - w ) - ( numberic - w ) % 1000;
            decimal b = ( numberic - w - q ) - ( numberic - w - q ) % 100;
            decimal s = ( numberic - w - q - b ) - ( numberic - w - q -b ) % 10;
            decimal y = ( numberic - w - q - b - s ) - ( numberic - w - q - b - s ) % 1;
            decimal j = ( numberic - w - q - b - s - y ) - ( numberic - w - q - b - s - y ) % 0.1M;
            decimal f = ( numberic - w - q - b - s - y - j) - ( numberic - w - q - b - s - y -j) % 0.01M;
            switch ( CN )
            {
                case NumericUnit.万:
                    return GetNumericCnName( Convert.ToInt32( w/10000 ) );
                case NumericUnit.仟:
                    return GetNumericCnName( Convert.ToInt32( q / 1000 ) );
                case NumericUnit.佰:
                    return GetNumericCnName( Convert.ToInt32( b / 100 ) );
                case NumericUnit.拾:
                    return GetNumericCnName( Convert.ToInt32( s / 10 ) );
                case NumericUnit.元:
                    return GetNumericCnName( Convert.ToInt32( y / 1 ) );
                case NumericUnit.角:
                    return GetNumericCnName( Convert.ToInt32( j *10 ) );
                case NumericUnit.分:
                    return GetNumericCnName( Convert.ToInt32( f * 100 ) );
            }
            return "";
        }
        /// <summary>
        /// 获取数字对应的中文字
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        private static string GetNumericCnName(int Num)
        {
            return ( (NumericCN)Num ).ToString( );
        }
        public  enum NumericUnit
        {
            万,
            仟,
            佰,
            拾,
            元,
            角,
            分
        }
        public enum NumericCN
        {
            零 = 0,
            壹 = 1,
            贰 = 2,
            叁 = 3,
            肆 = 4,
            伍 = 5,
            陆 = 6,
            柒 = 7,
            捌 = 8,
            玖 = 9
            
        }
    }
}
