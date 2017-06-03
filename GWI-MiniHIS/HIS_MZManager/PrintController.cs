using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using grproLib;
using HIS.Interface.Structs;
using HIS.MZ_BLL;
using HIS.MZ_BLL.Report;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS_MZManager
{
    
    public delegate void OnExportingEventHandle(ExportingEventArgs e);

    public class PrintController
    {
        public static event OnExportingEventHandle OnExporting;
        /// <summary>
        /// 数字单位
        /// </summary>
        public enum NumericUnit
        {
            万 ,
            仟 ,
            佰 ,
            拾 ,
            元 ,
            角 ,
            分
        }
        /// <summary>
        /// 数字中文
        /// </summary>
        public enum NumericCN
        {
            零 = 0 ,
            壹 = 1 ,
            贰 = 2 ,
            叁 = 3 ,
            肆 = 4 ,
            伍 = 5 ,
            陆 = 6 ,
            柒 = 7 ,
            捌 = 8 ,
            玖 = 9

        }

        private static string chargeInvoiceTemplatePath = Application.StartupPath + "\\report\\门诊收费发票模板.grf";
        private static string chargeInvoiceTemplatePath_HN = Application.StartupPath + "\\report\\门诊收费发票模板_HN.grf";
        private static string accountbookTemplatePath = Application.StartupPath + "\\report\\门诊个人交款表模板.grf";
        private static string accountbookTemplatePath_HN = Application.StartupPath + "\\report\\门诊个人交款表模板_HN.grf";
        private static string accountallbook = Application.StartupPath + "\\report\\门诊交款表汇总模板.grf";
        
        private static string incomeReportTemplate_A = Application.StartupPath + "\\report\\门诊收入报表模板_A.grf";
        private static string incomeReportTemplate_B = Application.StartupPath + "\\report\\门诊收入报表模板_B.grf";
        private static string incomeReportTemplate_C = Application.StartupPath + "\\report\\门诊收入报表模板_C.grf";
        private static string incomeReportTemplate_D = Application.StartupPath + "\\report\\门诊收入报表模板_D.grf";
        private static string chargerReportTemplate = Application.StartupPath + "\\report\\门诊收费员工作量统计报表模板.grf";

        private static string patientFeeReport = Application.StartupPath + "\\report\\门诊病人费用统计表模板_B.grf";
        private static string performSectionIncomeReportTemplate = Application.StartupPath + "\\report\\门诊执行科室收入统计表模板.grf";
        private static string accountBookAddendaTemplate = Application.StartupPath + "\\report\\门诊个人交款表附表_科室收入.grf";
        private static string outPatientFeeListTemplate = Application.StartupPath + "\\report\\门诊病人费用清单.grf";

        private static string RegisterTemplate = Application.StartupPath + "\\report\\门诊挂号发票模板.grf";


        private static GridppReport gridppReport = new GridppReport( );

        private static DataTable tbPrintData;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// 检查个人交款表模板是否有效
        /// </summary>
        /// <returns></returns>
        public static bool AccountBookTemplateExists()
        {
            if ( !File.Exists( accountbookTemplatePath ) )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 创建收费发票打印模板
        /// </summary>
        /// <param name="delete"></param>
        public static void CreateChargeInvoiceTemplate(bool delete)
        {
            try
            {
                GridppReport reportPrinter = new GridppReport( );


                if ( !Directory.Exists( System.Windows.Forms.Application.StartupPath + "\\report" ) )
                {
                    Directory.CreateDirectory( System.Windows.Forms.Application.StartupPath + "\\report" );
                }

                if ( File.Exists( chargeInvoiceTemplatePath ) && delete)
                {
                    File.Delete( chargeInvoiceTemplatePath );
                }

                if ( !File.Exists( chargeInvoiceTemplatePath ) )
                {
                    reportPrinter.InsertReportHeader( );

                    reportPrinter.AddParameter( "医院名称" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "发票号" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "年" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "月" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "日" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "姓名" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "结算方式" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "万" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "千" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "百" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "拾" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "元" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "角" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "分" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "记账金额" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "个人记账" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "个人缴费金额" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "优惠金额" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "收费员" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "发票总金额" , GRParameterDataType.grptString );
                    //大项目
                    for ( int i = 0; i < BaseDataController.BaseDataSet[BaseDataCatalog.基本分类科目].Rows.Count; i++ )
                        reportPrinter.AddParameter( "大项目_" + BaseDataController.BaseDataSet[BaseDataCatalog.基本分类科目].Rows[i]["STAT_NAME"].ToString().Trim(), GRParameterDataType.grptString );

                    //门诊发票
                    //for ( int i = 0 ; i < PublicDataReader.MzfpItemList.Rows.Count ; i++ )
                    for ( int i = 0; i < BaseDataController.BaseDataSet[BaseDataCatalog.门诊发票科目].Rows.Count; i++ )
                        reportPrinter.AddParameter( "发票项目_" + BaseDataController.BaseDataSet[BaseDataCatalog.门诊发票科目].Rows[i]["ITEM_NAME"].ToString().Trim(), GRParameterDataType.grptString );

                    reportPrinter.SaveToFile( chargeInvoiceTemplatePath );
                }
            }
            catch 
            {
                MessageBox.Show( "创建门诊发票模板发生错误！" , "" ,  MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }
        }
        /// <summary>
        /// 创建门诊个人交款表模板
        /// </summary>
        /// <param name="detele"></param>
        public static void CreateAccountBookTemplate( bool delete )
        {
            try
            {
                GridppReport reportPrinter = new GridppReport( );

                if ( !Directory.Exists( System.Windows.Forms.Application.StartupPath + "\\report" ) )
                {
                    Directory.CreateDirectory( System.Windows.Forms.Application.StartupPath + "\\report" );
                }

                if ( File.Exists( accountbookTemplatePath ) && delete )
                {
                    File.Delete( accountbookTemplatePath );
                }

                if ( !File.Exists( accountbookTemplatePath ) )
                {
                    reportPrinter.InsertReportHeader( );

                    reportPrinter.AddParameter( "医院名称" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "交款人" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "交款时间" , GRParameterDataType.grptString );
                    //创建发票科目参数
                    DataTable tb = BaseDataController.BaseDataSet[BaseDataCatalog.门诊发票科目];
                    foreach ( DataRow dr in tb.Rows )
                        reportPrinter.AddParameter( dr["item_name"].ToString( ).Trim( ) , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "发票科目合计" , GRParameterDataType.grptString );

                    reportPrinter.AddParameter( "收费发票开始号" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "收费发票结束号" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "收费发票张数" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "收费退费张数" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "收费退费金额" , GRParameterDataType.grptString );

                    reportPrinter.AddParameter( "挂号发票开始号" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "挂号发票结束号" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "挂号发票张数" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "挂号退费张数" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "挂号退费金额" , GRParameterDataType.grptString );

                    //tb = HIS.MZ_BLL.PublicDataReader.PatientTypeList;
                    tb = BaseDataController.BaseDataSet[BaseDataCatalog.病人类型列表];
                    foreach ( DataRow dr in tb.Rows )
                    {
                        string p_name = dr["NAME"].ToString( ).Trim( );
                        reportPrinter.AddParameter( p_name + "_现金" , GRParameterDataType.grptString );
                        reportPrinter.AddParameter( p_name + "_POS" , GRParameterDataType.grptString );
                        reportPrinter.AddParameter( p_name + "_记账" , GRParameterDataType.grptString );
                        reportPrinter.AddParameter( p_name + "_优惠" , GRParameterDataType.grptString );

                        reportPrinter.AddParameter( p_name + "_现金_张数" , GRParameterDataType.grptString );
                        reportPrinter.AddParameter( p_name + "_POS_张数" , GRParameterDataType.grptString );
                        reportPrinter.AddParameter( p_name + "_记账_张数" , GRParameterDataType.grptString );
                        reportPrinter.AddParameter( p_name + "_优惠_张数" , GRParameterDataType.grptString );
                    }
                    reportPrinter.AddParameter( "POS金额" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "单位记账" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "POS金额_张数" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "单位记账_张数" , GRParameterDataType.grptString );

                    reportPrinter.AddParameter( "记账合计" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "记账合计张数" , GRParameterDataType.grptString );

                    reportPrinter.AddParameter( "优惠金额" , GRParameterDataType.grptString );

                    reportPrinter.AddParameter( "实收现金" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "挂号现金" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "挂号诊金" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "处方收费" , GRParameterDataType.grptString );

                    reportPrinter.AddParameter( "小写合计" , GRParameterDataType.grptString );
                    reportPrinter.AddParameter( "大写合计" , GRParameterDataType.grptString );

                    reportPrinter.SaveToFile( accountbookTemplatePath );
                }
            }
            catch
            {
                MessageBox.Show( "创建个人交款表模板发生错误！" , "" ,  MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }

        }
        /// <summary>
        /// 创建收入报表
        /// </summary>
        /// <param name="Report"></param>
        /// <param name="delete"></param>
        public static void CreateIncomeReportTemplate( BaseReport Report ,bool delete )
        {
            string reportPath = "";

            if ( Report.Reportstyle == ReportStyle.科目为标题列 )
                reportPath = incomeReportTemplate_A;
            else
                reportPath = incomeReportTemplate_B;

            if ( !Directory.Exists( System.Windows.Forms.Application.StartupPath + "\\report" ) )
            {
                Directory.CreateDirectory( System.Windows.Forms.Application.StartupPath + "\\report" );
            }

            if ( File.Exists( reportPath ) && delete )
            {
                File.Delete( reportPath );
            }

            try
            {
                GridppReport gridReport = new GridppReport();

                if ( !File.Exists( reportPath ) )
                {
                    gridReport.SaveToFile( reportPath );
                    gridReport.InsertReportHeader( );
                    gridReport.InsertDetailGrid( );
                    gridReport.InsertReportFooter( );
                    gridReport.DetailGrid.IsCrossTab = true;

                    gridReport.DetailGrid.AddColumn( "名称" , "名称" , "名称" , 2 );
                    gridReport.DetailGrid.AddColumn( "项目" , "项目" , "项目" , 2 );
                    gridReport.DetailGrid.AddColumn( "合计" , "合计" , "合计" , 2 );

                    gridReport.DetailGrid.Recordset.AddField( "ID" , GRFieldType.grftString );
                    gridReport.DetailGrid.Recordset.AddField( "CODE" , GRFieldType.grftString );
                    gridReport.DetailGrid.Recordset.AddField( "TOTAL_FEE" , GRFieldType.grftFloat );

                    if ( Report.Reportstyle == ReportStyle.科目为标题列 )
                    {
                        gridReport.DetailGrid.CrossTab.HCrossFields = "CODE";
                        gridReport.DetailGrid.CrossTab.VCrossFields = "ID";
                    }
                    else
                    {
                        gridReport.DetailGrid.CrossTab.HCrossFields = "ID";
                        gridReport.DetailGrid.CrossTab.VCrossFields = "CODE";
                    }
                    gridReport.DetailGrid.CrossTab.ListCols = 1;
                    gridReport.DetailGrid.CrossTab.TotalCols = 1;
                    //加入分组
                    gridReport.DetailGrid.Groups.Add( );
                    
                    gridReport.AddParameter( "医院名称" , GRParameterDataType.grptString );
                    gridReport.AddParameter( "报表标题" , GRParameterDataType.grptString );
                    gridReport.AddParameter( "统计时间" , GRParameterDataType.grptString );
                    gridReport.AddParameter( "制表人" , GRParameterDataType.grptString );
                    gridReport.AddParameter( "备注" , GRParameterDataType.grptString );

                    
                    

                    gridReport.SaveToFile( reportPath );
                }
            }
            catch
            {
                MessageBox.Show( "创建报表失败！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }
        /// <summary>
        /// 创建门诊病人费用统计表模板
        /// </summary>
        public static void CreatePatientFeeReportTemplate()
        {
            string reportPath = patientFeeReport;

            if ( !Directory.Exists( System.Windows.Forms.Application.StartupPath + "\\report" ) )
            {
                Directory.CreateDirectory( System.Windows.Forms.Application.StartupPath + "\\report" );
            }

            if ( File.Exists( reportPath )  )
            {
                return;//如果存在不创建，返回
            }

            try
            {
                GridppReport gridReport = new GridppReport( );

                if ( !File.Exists( reportPath ) )
                {
                    gridReport.SaveToFile( reportPath );

                    gridReport.InsertReportHeader( );
                    gridReport.InsertDetailGrid( );
                    gridReport.InsertReportFooter( );

                    gridReport.DetailGrid.Recordset.AddField( "病人姓名" , GRFieldType.grftString );
                    gridReport.DetailGrid.Recordset.AddField( "类型" , GRFieldType.grftString );
                    gridReport.DetailGrid.Recordset.AddField( "发票号" , GRFieldType.grftFloat );
                    gridReport.DetailGrid.Recordset.AddField( "收费时间" , GRFieldType.grftString );
                    gridReport.DetailGrid.Recordset.AddField( "总金额" , GRFieldType.grftString );
                    gridReport.DetailGrid.Recordset.AddField( "医保农合记账" , GRFieldType.grftFloat );
                    gridReport.DetailGrid.Recordset.AddField( "POS记账" , GRFieldType.grftString );
                    gridReport.DetailGrid.Recordset.AddField( "单位记账" , GRFieldType.grftString );
                    gridReport.DetailGrid.Recordset.AddField( "现金支付" , GRFieldType.grftFloat );
                    gridReport.DetailGrid.Recordset.AddField( "优惠金额" , GRFieldType.grftString );
                    for ( int i = 0; i < BaseDataController.BaseDataSet[BaseDataCatalog.门诊发票科目].Rows.Count; i++ )
                    {
                        string name = BaseDataController.BaseDataSet[BaseDataCatalog.门诊发票科目].Rows[i]["ITEM_NAME"].ToString().Trim();
                        gridReport.DetailGrid.Recordset.AddField( name , GRFieldType.grftString );
                    }


                    gridReport.AddParameter( "医院名称" , GRParameterDataType.grptString );
                    gridReport.AddParameter( "报表标题" , GRParameterDataType.grptString );
                    gridReport.AddParameter( "统计时间" , GRParameterDataType.grptString );
                    gridReport.AddParameter( "制表人" , GRParameterDataType.grptString );
                    gridReport.AddParameter( "备注" , GRParameterDataType.grptString );




                    gridReport.SaveToFile( reportPath );
                }
            }
            catch
            {
                MessageBox.Show( "创建报表失败！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }
        /// <summary>
        /// 打印报表
        /// </summary>
        /// <param name="Report"></param>
        /// <param name="preview"></param>
        public static void PrintPatientFeeReport( BaseReport Report , bool preview )
        {
            string reportPath = patientFeeReport;

            DataTable tbData = Report.DataResult;

            grproLib.GridppReport reportPrinter = new grproLib.GridppReport( );

            if ( !System.IO.File.Exists( reportPath ) )
            {
                PrintController.CreatePatientFeeReportTemplate();

                MessageBox.Show( "模板文件【" + reportPath + "】不存在,系统已为你创建了初始模板文件！你可以：\r\n1、使用安装目录下的报表设计器进行设计。\r\n2、联系管理员获取模板文件。" );

                return;
            }

            reportPrinter.LoadFromFile( reportPath );
            string printerName = HIS_PublicManager.PublicPrintSet.GetPrinterNameByReport( reportPath );
            if ( printerName.Trim( ) == "" )
            {
                MessageBox.Show( "没有正确设置打印机！请打开【报表打印机设置】设置好打印机再试！" );
                return;
            }
            reportPrinter.Printer.PrinterName = printerName;


            try
            {
                reportPrinter.Title = Report.ReportTitle;
                try
                {
                    reportPrinter.ParameterByName( "医院名称" ).AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                    reportPrinter.ParameterByName( "报表标题" ).AsString = Report.ReportTitle;
                    reportPrinter.ParameterByName( "统计时间" ).AsString = "统计时间：" + Report.BeginDate.ToString( "yyyy-MM-dd HH:mm:ss" ) + " -- " + Report.EndDate.ToString( "yyyy-MM-dd HH:mm:ss" );
                    reportPrinter.ParameterByName( "制表人" ).AsString = "制表人：" + Report.Lister;
                    reportPrinter.ParameterByName( "备注" ).AsString = "";
                }
                catch 
                {
                    throw new Exception( "报表模板参数没有正确设置，请用设计器打开报表并设置好参数" );
                    
                }
                gridppReport = reportPrinter;
                tbPrintData = tbData;

                reportPrinter.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler( reportPrinter_FetchRecord );

                if ( preview )
                    reportPrinter.PrintPreview( false );
                else
                    reportPrinter.Print( false );

            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }
        }
        /// <summary>
        /// 打印报表
        /// </summary>
        /// <param name="Report">报表对象</param>
        /// <param name="preview">是否预览</param>
        public static void PrintIncomeReport( BaseReport Report ,bool preview )
        {
            string reportPath = "";
            
            if ( Report.Reportstyle == ReportStyle.科目为标题列 )
                reportPath = incomeReportTemplate_A;
            else
                reportPath = incomeReportTemplate_B;
            
            DataTable tbData = Report.BaseReportData;

            grproLib.GridppReport reportPrinter = new grproLib.GridppReport( );

            if ( !System.IO.File.Exists( reportPath ) )
            {
                PrintController.CreateIncomeReportTemplate( Report , false );

                MessageBox.Show( "模板文件【" + reportPath + "】不存在,系统已为你创建了初始模板文件！你可以：\r\n1、使用安装目录下的报表设计器进行设计。\r\n2、联系管理员获取模板文件。" );
                
                return;
            }

            reportPrinter.LoadFromFile( reportPath );
            string printerName = HIS_PublicManager.PublicPrintSet.GetPrinterNameByReport( reportPath );
            if (printerName.Trim() == "")
            {
                MessageBox.Show("没有正确设置打印机！请打开【报表打印机设置】设置好打印机再试！");
                return;
            }
           
            reportPrinter.Printer.PrinterName = printerName;


            try
            {
                reportPrinter.Title = Report.ReportTitle;
                try
                {
                    reportPrinter.ParameterByName( "医院名称" ).AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                    reportPrinter.ParameterByName( "报表标题" ).AsString = Report.ReportTitle;
                    reportPrinter.ParameterByName( "统计时间" ).AsString = "统计时间：" + Report.BeginDate.ToString( "yyyy-MM-dd HH:mm:ss" ) + " -- " + Report.EndDate.ToString( "yyyy-MM-dd HH:mm:ss" );
                    reportPrinter.ParameterByName( "制表人" ).AsString = "制表人：" + Report.Lister;
                    reportPrinter.ParameterByName( "备注" ).AsString = "";
                }
                catch 
                {
                    throw new Exception( "报表模板参数没有正确设置，请用设计器打开报表并设置好参数" );
                   
                }
                gridppReport = reportPrinter;
                tbPrintData = tbData;
                reportPrinter.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler( reportPrinter_FetchRecord );
                if (preview)
                    reportPrinter.PrintPreview(false);
                else
                    reportPrinter.Print(false);          
                
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }
        }
        /// <summary>
        /// 打印带支付汇总信息的打印
        /// </summary>
        /// <param name="Report"></param>
        /// <param name="lstFundInfo">支付信息汇总</param>
        public static void PrintIncomeReport(BaseReport Report, List<FundInfo> lstFundInfo)
        {
            string reportPath = "";

            if (Report.Reportstyle == ReportStyle.科目为标题列)
                reportPath = incomeReportTemplate_C;
            else
                reportPath = incomeReportTemplate_D;

            DataTable tbData = Report.BaseReportData;

            grproLib.GridppReport reportPrinter = new grproLib.GridppReport();

            if (!System.IO.File.Exists(reportPath))
            {

                MessageBox.Show("模板文件【" + reportPath + "】不存在！你可以：\r\n1、联系管理员获取模板文件。");

                return;
            }

            reportPrinter.LoadFromFile(reportPath);
            string printerName = HIS_PublicManager.PublicPrintSet.GetPrinterNameByReport(reportPath);
            if (printerName.Trim() == "")
            {
                MessageBox.Show("没有正确设置打印机！请打开【报表打印机设置】设置好打印机再试！");
                return;
            }
            reportPrinter.Printer.PrinterName = printerName;


            try
            {
                reportPrinter.Title = Report.ReportTitle;
                try
                {
                    reportPrinter.ParameterByName("医院名称").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                    reportPrinter.ParameterByName("报表标题").AsString = Report.ReportTitle;
                    reportPrinter.ParameterByName("统计时间").AsString = "统计时间：" + Report.BeginDate.ToString("yyyy-MM-dd HH:mm:ss") + " -- " + Report.EndDate.ToString("yyyy-MM-dd HH:mm:ss");
                    reportPrinter.ParameterByName("制表人").AsString = "制表人：" + Report.Lister;
                    reportPrinter.ParameterByName("备注").AsString = "";
                    //合计部分参数
                    decimal totalMoney = 0;
                    foreach (FundInfo fd in lstFundInfo)
                    {
                        reportPrinter.ParameterByName(fd.PayName).AsString = fd.Money.ToString();
                        totalMoney = totalMoney + fd.Money;
                    }
                    reportPrinter.ParameterByName("合计金额").AsString = totalMoney.ToString();
                }
                catch 
                {
                    throw new Exception("报表模板参数没有正确设置，请用设计器打开报表并设置好参数");
                    
                }
                gridppReport = reportPrinter;
                tbPrintData = tbData;

                reportPrinter.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler(reportPrinter_FetchRecord);

                reportPrinter.PrintPreview(false);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        /// <summary>
        /// 输出Excel
        /// </summary>
        /// <param name="Report"></param>
        public static void ReportToExcel( BaseReport Report )
        {
            ExportingEventArgs e = new ExportingEventArgs( );
            try
            {
                int totalColumn = Report.DataResult.Columns.Count;
                
                Microsoft.Office.Interop.Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass( );

                excel.Application.Workbooks.Add( true );

                e.TotalCount = Report.DataResult.Rows.Count;

                #region 填充数据
                excel.Cells[1 , 1] = HIS.SYSTEM.Core.EntityConfig.WorkName + Report.ReportTitle;
                Microsoft.Office.Interop.Excel.Range titleStartcell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[1 , 1];
                Microsoft.Office.Interop.Excel.Range titleEndcell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[1 , totalColumn];
                excel.get_Range( titleStartcell , titleEndcell ).Merge( 0 );
                excel.get_Range( titleStartcell , titleEndcell ).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                excel.get_Range( titleStartcell , titleEndcell ).Font.Name = "宋体";
                excel.get_Range( titleStartcell , titleEndcell ).Font.Size = 15;
                excel.get_Range( titleStartcell , titleEndcell ).Font.Bold = true;

                excel.Cells[2 , 1] = "统计时间：";
                excel.Cells[2 , 2] = Report.BeginDate.ToString( "yyyy-MM-dd HH:mm:ss" ) + " -- " + Report.EndDate.ToString( "yyyy-MM-dd HH:mm:ss" );
                excel.get_Range( (Microsoft.Office.Interop.Excel.Range)excel.Cells[2 , 2] , (Microsoft.Office.Interop.Excel.Range)excel.Cells[2 , 6] ).Merge( 0 );

                excel.Cells[2 , totalColumn - 2] = "制表人：";
                excel.Cells[2 , totalColumn - 1] = Report.Lister;


                int row = 3;
                Microsoft.Office.Interop.Excel.Range startCell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[row , 1];
                Microsoft.Office.Interop.Excel.Range endCell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[row + Report.DataResult.Rows.Count , totalColumn];

                for ( int i = 0 ; i < Report.DataResult.Columns.Count ; i++ )
                    excel.Cells[row , i + 1] = Report.DataResult.Columns[i].ColumnName.ToString( );
                row = row + 1;
                for ( int i = 0 ; i < Report.DataResult.Rows.Count ; i++ )
                {
                    
                    for ( int j = 0 ; j < Report.DataResult.Columns.Count ; j++ )
                    {
                        object objValue = Report.DataResult.Rows[i][Report.DataResult.Columns[j].ColumnName];
                        if ( Convert.IsDBNull( objValue ) )
                            continue;
                        excel.Cells[row + i , j + 1] = objValue.ToString( );
                    }
                    e.CurrentCount = i;
                    if ( OnExporting != null )
                        OnExporting( e );
                }
                #endregion

                #region 画网格线
                object obj = excel.get_Range( startCell , endCell ).Select( );

                excel.get_Range( startCell , endCell ).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
                excel.get_Range( startCell , endCell ).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;

                excel.get_Range( startCell , endCell ).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range( startCell , endCell ).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                excel.get_Range( startCell , endCell ).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range( startCell , endCell ).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                excel.get_Range( startCell , endCell ).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range( startCell , endCell ).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                excel.get_Range( startCell , endCell ).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range( startCell , endCell ).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                excel.get_Range( startCell , endCell ).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range( startCell , endCell ).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

                excel.get_Range( startCell , endCell ).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range( startCell , endCell ).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

                row = row + Report.DataResult.Rows.Count + 1;
                excel.Cells[row , 1] = "审核人";
                excel.Cells[row , totalColumn - 2] = "打印日期：";
                excel.Cells[row , totalColumn] = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.ToString( "yyyy-MM-dd" );
                #endregion

                excel.get_Range( titleStartcell , titleEndcell ).Select( );
                excel.ActiveWindow.DisplayGridlines = false;
                excel.Visible = true;
                
            }
            catch(Exception err)
            {
                MessageBox.Show( "输出到Excel发生错误！" ,"",MessageBoxButtons.OK,MessageBoxIcon.Error );
                ErrorWriter.WriteLog( err.Message );
            }
            finally
            {
                GC.Collect( );
            }
        }
        /// <summary>
        /// 输出Excel
        /// </summary>
        /// <param name="Report"></param>
        public static void ReportToExcel(BaseReport Report, List<FundInfo> lstFundInfo)
        {
            ExportingEventArgs e = new ExportingEventArgs();
            try
            {
                int totalColumn = Report.DataResult.Columns.Count;

                Microsoft.Office.Interop.Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();

                excel.Application.Workbooks.Add(true);

                e.TotalCount = Report.DataResult.Rows.Count;

                #region 填充数据
                excel.Cells[1, 1] = HIS.SYSTEM.Core.EntityConfig.WorkName + Report.ReportTitle;
                Microsoft.Office.Interop.Excel.Range titleStartcell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[1, 1];
                Microsoft.Office.Interop.Excel.Range titleEndcell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[1, totalColumn];
                excel.get_Range(titleStartcell, titleEndcell).Merge(0);
                excel.get_Range(titleStartcell, titleEndcell).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                excel.get_Range(titleStartcell, titleEndcell).Font.Name = "宋体";
                excel.get_Range(titleStartcell, titleEndcell).Font.Size = 15;
                excel.get_Range(titleStartcell, titleEndcell).Font.Bold = true;

                excel.Cells[2, 1] = "统计时间：";
                excel.Cells[2, 2] = Report.BeginDate.ToString("yyyy-MM-dd HH:mm:ss") + " -- " + Report.EndDate.ToString("yyyy-MM-dd HH:mm:ss");
                excel.get_Range((Microsoft.Office.Interop.Excel.Range)excel.Cells[2, 2], (Microsoft.Office.Interop.Excel.Range)excel.Cells[2, 6]).Merge(0);

                excel.Cells[2, totalColumn - 2] = "制表人：";
                excel.Cells[2, totalColumn - 1] = Report.Lister;


                int row = 3;
                Microsoft.Office.Interop.Excel.Range startCell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[row, 1];
                Microsoft.Office.Interop.Excel.Range endCell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[row + Report.DataResult.Rows.Count, totalColumn];

                for (int i = 0; i < Report.DataResult.Columns.Count; i++)
                    excel.Cells[row, i + 1] = Report.DataResult.Columns[i].ColumnName.ToString();
                row = row + 1;
                for (int i = 0; i < Report.DataResult.Rows.Count; i++)
                {

                    for (int j = 0; j < Report.DataResult.Columns.Count; j++)
                    {
                        object objValue = Report.DataResult.Rows[i][Report.DataResult.Columns[j].ColumnName];
                        if (Convert.IsDBNull(objValue))
                            continue;
                        excel.Cells[row + i, j + 1] = objValue.ToString();
                    }
                    e.CurrentCount = i;
                    if (OnExporting != null)
                        OnExporting(e);
                }
                #endregion

                #region 画网格线
                object obj = excel.get_Range(startCell, endCell).Select();

                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;

                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

                row = row + Report.DataResult.Rows.Count + 1;

                int colIndex = 1;
                for (int i = 0; i < lstFundInfo.Count; i++)
                {
                    if (colIndex > 8)
                    {
                        colIndex = 1;
                        row++;
                    }
                    excel.Cells[row, colIndex] = lstFundInfo[i].PayName;
                    excel.Cells[row, colIndex + 1] = lstFundInfo[i].Money;
                    colIndex=colIndex+2;
                }

                row = row + 2;

                excel.Cells[row, 1] = "审核人";
                excel.Cells[row, totalColumn - 2] = "打印日期：";
                excel.Cells[row, totalColumn] = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.ToString("yyyy-MM-dd");
                #endregion

                excel.get_Range(titleStartcell, titleEndcell).Select();
                excel.ActiveWindow.DisplayGridlines = false;
                excel.Visible = true;

            }
            catch (Exception err)
            {
                MessageBox.Show("输出到Excel发生错误！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorWriter.WriteLog(err.Message);
            }
            finally
            {
                GC.Collect();
            }
        }
        //==================打印输出==============================

        public static void PrintAccountBookAddenda( DataTable tbData ,DateTime AccountDate,string Lister)
        {
            string reportPath = accountBookAddendaTemplate;

            
            grproLib.GridppReport reportPrinter = new grproLib.GridppReport( );

            if ( !System.IO.File.Exists( reportPath ) )
            {
                
                MessageBox.Show( "模板文件【" + reportPath + "】不存在,请联系管理员获取模板文件。" );

                return;
            }

            reportPrinter.LoadFromFile( reportPath );
            string printerName = HIS_PublicManager.PublicPrintSet.GetPrinterNameByReport( reportPath );
            if ( printerName.Trim( ) == "" )
            {
                MessageBox.Show( "没有正确设置打印机！请打开【报表打印机设置】设置好打印机再试！" );
                return;
            }
            reportPrinter.Printer.PrinterName = printerName;


            try
            {
                
                try
                {
                    reportPrinter.ParameterByName( "医院名称" ).AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                    reportPrinter.ParameterByName( "报表标题" ).AsString = "门诊个人交款表附表(科室收入)";
                    reportPrinter.ParameterByName( "统计时间" ).AsString = "交款时间：" + AccountDate.ToString("yyyy-MM-dd HH:mm:ss");
                    reportPrinter.ParameterByName( "制表人" ).AsString = "交款人：" + Lister;
                    reportPrinter.ParameterByName( "备注" ).AsString = "";
                }
                catch 
                {
                    throw new Exception( "报表模板参数没有正确设置，请用设计器打开报表并设置好参数" );
                   
                }
                gridppReport = reportPrinter;
                tbPrintData = tbData;

                reportPrinter.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler( reportPrinter_FetchRecord );

                
                reportPrinter.PrintPreview( false );
                

            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }
        }
        /// <summary>
        /// 打印报表
        /// </summary>
        /// <param name="Report"></param>
        /// <param name="preview"></param>
        public static void PrintPerformSectionIncomeReport( DataTable tbData ,string beginAndEndDate)
        {
            string reportPath = performSectionIncomeReportTemplate;

            grproLib.GridppReport reportPrinter = new grproLib.GridppReport( );

            if ( !System.IO.File.Exists( reportPath ) )
            {
                PrintController.CreatePatientFeeReportTemplate( );

                MessageBox.Show( "模板文件【" + reportPath + "】不存在、请联系管理员获取模板文件。" );

                return;
            }

            reportPrinter.LoadFromFile( reportPath );
            string printerName = HIS_PublicManager.PublicPrintSet.GetPrinterNameByReport( reportPath );
            if ( printerName.Trim( ) == "" )
            {
                MessageBox.Show( "没有正确设置打印机！请打开【报表打印机设置】设置好打印机再试！" );
                return;
            }
            reportPrinter.Printer.PrinterName = printerName;


            try
            {
                try
                {
                    reportPrinter.ParameterByName( "医院名称" ).AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                    reportPrinter.ParameterByName( "统计时间" ).AsString = "统计时间：" + beginAndEndDate;
                }
                catch 
                {
                    throw new Exception( "报表模板参数没有正确设置，请用设计器打开报表并设置好参数" );
                    
                }
                gridppReport = reportPrinter;
                tbPrintData = tbData;

                reportPrinter.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler( reportPrinter_FetchRecord );

                reportPrinter.PrintPreview( false );
                

            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }
        }

        

        public static void PrintOutPatientFeeList(OutPatient Patient, Invoice invoice, Prescription[] Prescriptions,bool PrintSubTotal)
        {
            string reportPath = outPatientFeeListTemplate;
            #region 构造打印数据集
            DataTable tbData = new DataTable();
            tbData.Columns.Add("NO");
            tbData.Columns.Add("ITEM_NAME");
            tbData.Columns.Add("STANDARD");
            tbData.Columns.Add("PRICE");
            tbData.Columns.Add("PACK_UNIT");
            tbData.Columns.Add("PACK_NUM");
            tbData.Columns.Add("BASE_NUM");
            tbData.Columns.Add("PRESAMOUNT");
            tbData.Columns.Add("TOTALCOST");
            
            for (int i = 0; i < Prescriptions.Length; i++)
            {
                decimal presSubTotal = 0;
                

                for (int j = 0; j < Prescriptions[i].PresDetails.Length; j++)
                {
                    DataRow dr = tbData.NewRow();
                    if (PrintSubTotal)
                    {
                        if (j == 0)
                        {
                            dr["NO"] = Convert.ToString(i + 1);
                        }
                    }
                    else
                    {
                        dr["NO"] = tbData.Rows.Count+1;
                    }
                    dr["ITEM_NAME"] = Prescriptions[i].PresDetails[j].Itemname;
                    dr["STANDARD"] = Prescriptions[i].PresDetails[j].Standard;
                    dr["PRICE"] = Prescriptions[i].PresDetails[j].Sell_price;
                    dr["PACK_UNIT"] = Prescriptions[i].PresDetails[j].Unit;
                    if (Prescriptions[i].PresDetails[j].BigitemCode == "01" ||
                        Prescriptions[i].PresDetails[j].BigitemCode == "02" ||
                        Prescriptions[i].PresDetails[j].BigitemCode == "03")
                    {
                        decimal baseNum = Prescriptions[i].PresDetails[j].Amount % Prescriptions[i].PresDetails[j].RelationNum;
                        decimal packNum = (Prescriptions[i].PresDetails[j].Amount - baseNum) / Prescriptions[i].PresDetails[j].RelationNum;
                        if (Prescriptions[i].Record_Flag == 0)
                        {
                            dr["PACK_NUM"] = packNum;
                            dr["BASE_NUM"] = baseNum;
                        }
                        else
                        {
                            dr["PACK_NUM"] = packNum * -1;
                            dr["BASE_NUM"] = baseNum * -1;
                        }
                    }
                    else
                    {
                        if (Prescriptions[i].Record_Flag == 0)
                        {
                            dr["PACK_NUM"] = 0;
                            dr["BASE_NUM"] = Prescriptions[i].PresDetails[j].Amount;
                        }
                        else
                        {
                            dr["PACK_NUM"] = 0;
                            dr["BASE_NUM"] = Prescriptions[i].PresDetails[j].Amount * -1;
                        }
                    }

                    dr["PresAmount"] = Prescriptions[i].PresDetails[j].PresAmount;
                    if (Prescriptions[i].Record_Flag == 0)
                    {
                        dr["TotalCost"] = Prescriptions[i].PresDetails[j].Tolal_Fee;
                        presSubTotal += Prescriptions[i].PresDetails[j].Tolal_Fee;
                    }
                    else
                    {
                        dr["TotalCost"] = Prescriptions[i].PresDetails[j].Tolal_Fee * -1;
                        presSubTotal += (Prescriptions[i].PresDetails[j].Tolal_Fee * -1);
                    }
                    
                    tbData.Rows.Add(dr);
                }
                //小计
                if (PrintSubTotal)
                {
                    DataRow drSub = tbData.NewRow();
                    drSub["STANDARD"] = "小    计:";
                    drSub["TOTALCOST"] = Decimal.Round(presSubTotal, 1);
                    tbData.Rows.Add(drSub);
                }
            }
            if (tbData.Rows.Count == 0)
            {
                return;
            }
            #endregion

            grproLib.GridppReport reportPrinter = new grproLib.GridppReport();

            if (!System.IO.File.Exists(reportPath))
            {
                MessageBox.Show("模板文件【" + reportPath + "】不存在！你可以：\r\n1、联系管理员获取模板文件。");
                return;
            }

            reportPrinter.LoadFromFile(reportPath);
            string printerName = HIS_PublicManager.PublicPrintSet.GetPrinterNameByReport(reportPath);
            if (printerName.Trim() == "")
            {
                MessageBox.Show("没有正确设置打印机！请打开【报表打印机设置】设置好打印机再试！");
                return;
            }
            reportPrinter.Printer.PrinterName = printerName;


            try
            {
                reportPrinter.Title = "";
                try
                {
                    reportPrinter.ParameterByName("医院名称").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                    reportPrinter.ParameterByName("病人姓名").AsString = Patient.PatientName;
                    reportPrinter.ParameterByName("年龄").AsString = Patient.Age.ToString() + (Patient.AgeUnit==null ? "岁" : Patient.AgeUnit.ToString().Trim());
                    reportPrinter.ParameterByName("性别").AsString = Patient.Sex.ToString().Trim();
                    reportPrinter.ParameterByName("门诊号").AsString = Patient.VisitNo;
                    //reportPrinter.ParameterByName("病人类型").AsString = PublicDataReader.GetPatientTypeNameByCode(Patient.MediType.Trim());
                    reportPrinter.ParameterByName( "病人类型" ).AsString = BaseDataController.GetName(BaseDataCatalog.病人类型列表, Patient.MediType.Trim() );
                    reportPrinter.ParameterByName("就诊时间").AsString = Patient.CureDate.ToString("yyyy-MM-dd");
                    reportPrinter.ParameterByName("总金额").AsString = invoice.TotalPay.ToString();
                    reportPrinter.ParameterByName("现金").AsString = invoice.CashPay.ToString();
                    reportPrinter.ParameterByName("医保或农合记账").AsString = invoice.VillagePay.ToString();
                    reportPrinter.ParameterByName("POS").AsString = invoice.PosPay.ToString();
                    reportPrinter.ParameterByName("单位记账").AsString = invoice.SelfTally.ToString();
                    reportPrinter.ParameterByName("优惠金额").AsString = invoice.FavorPay.ToString();
                    reportPrinter.ParameterByName("门诊发票号").AsString = invoice.InvoiceNo.Trim();
                    reportPrinter.ParameterByName("收费日期").AsString = invoice.ChargeDate.ToString("yyyy-MM-dd");
                }
                catch 
                {
                    throw new Exception("报表模板参数没有正确设置，请用设计器打开报表并设置好参数");
      
                }
                gridppReport = reportPrinter;

                tbPrintData = tbData;

                reportPrinter.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler(reportPrinter_FetchRecord);

                reportPrinter.PrintPreview(false);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        #region 门诊挂号发票打印
        /// <summary>
        /// 门诊挂号发票打印
        /// </summary>
        /// <param name="invoice"></param>
        public static void PrintRegisterVoice(RegisterInvoice invoice)
        {
            string reportPath = RegisterTemplate;
            grproLib.GridppReport reportPrinter = new grproLib.GridppReport();
            if (!System.IO.File.Exists(reportPath))
            {
                MessageBox.Show("模板文件【" + reportPath + "】不存在！你可以：\r\n1、联系管理员获取模板文件。");
                return;
            }
            reportPrinter.LoadFromFile(reportPath);
            string printerName = HIS_PublicManager.PublicPrintSet.GetPrinterNameByReport(reportPath);
            if (printerName.Trim() == "")
            {
                MessageBox.Show("没有正确设置打印机！请打开【报表打印机设置】设置好打印机再试！");
                return;
            }
            try
            {
                reportPrinter.Title = "";
                try
                {
                    reportPrinter.Printer.PrinterName = printerName;
                    reportPrinter.ParameterByName("诊病科别").AsString = invoice.RegDeptName;
                    reportPrinter.ParameterByName("医师职级").AsString = invoice.DocType;
                    reportPrinter.ParameterByName("候诊号").AsString = invoice.RegNo.ToString();               
                    reportPrinter.ParameterByName("挂号费").AsString = invoice.RegFee.ToString();
                    reportPrinter.ParameterByName("诊查费").AsString = invoice.ZcFee.ToString();
                    reportPrinter.ParameterByName("检查费").AsString = invoice.CheckFee.ToString();
                    reportPrinter.ParameterByName("材料费").AsString = invoice.ClFee.ToString();
                    reportPrinter.ParameterByName("合计金额").AsString = invoice.TotalFee.ToString();
                    reportPrinter.ParameterByName("收款人").AsString = invoice.ChargeUserName.ToString();
                    reportPrinter.ParameterByName("病人姓名").AsString = invoice.PatName.ToString();
                    DateTime time = XcDate.ServerDateTime;
                    reportPrinter.ParameterByName("年").AsString = time.Year.ToString();
                    reportPrinter.ParameterByName("月").AsString = time.Month.ToString();
                    reportPrinter.ParameterByName("日").AsString = time.Day.ToString();
                    
                    
                }
                catch
                {
                    throw new Exception("报表模板参数没有正确设置，请用设计器打开报表并设置好参数");

                }
                gridppReport = reportPrinter;

                reportPrinter.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler(reportPrinter_FetchRecord);

             //   reportPrinter.PrintPreview(false);
                reportPrinter.Print(false);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion
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
            if ( HIS.MZ_BLL.OPDParamter.Parameters["004"].ToString() == "0" )
                previewBeforPrint = true;

            //发票是否打印明细控制
            //bool printDetail = false;
            //if ( HIS.MZ_BLL.OPDParamter.Parameters["003"].ToString( ) == "1" )
            //    printDetail = true;

           
            InvoiceStyle style = (InvoiceStyle)( Convert.ToInt32( OPDParamter.Parameters["021"] ) );

            string printerName = "";
            if ( style == InvoiceStyle.湖南省 )
            {
                printerName = HIS_PublicManager.PublicPrintSet.GetPrinterNameByReport( "门诊收费发票模板_HN.grf" );
            }
            else if ( style == InvoiceStyle.广东省 )
            {
                printerName = HIS_PublicManager.PublicPrintSet.GetPrinterNameByReport( "门诊收费发票模板.grf" );
            }
            if ( printerName.Trim() == "" )
            {
                MessageBox.Show( "打印机没有设置，打印发票失败！\r\n解决方法：\r\n1、设置好打印机后将本张发票退费并调整发票号后重新收费。\r\n2、设置好打印机后，联系管理员通过发票查询查出该张发票进行重打。", "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }



            if ( style == InvoiceStyle.广东省 )
            {
                GridppReport rpt = new GridppReport();
                printerName = HIS_PublicManager.PublicPrintSet.GetPrinterNameByReport( "门诊收费发票模板.grf" );
                rpt.Printer.PrinterName = printerName;
                rpt.LoadFromFile( chargeInvoiceTemplatePath );

                #region 广东省发票格式
                for ( int i = 0; i < invoices.Length; i++ )
                {

                    try
                    {
                        rpt.ParameterByName( "医院名称" ).AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                        rpt.ParameterByName( "发票号" ).AsString = invoices[i].InvoiceNo;
                        rpt.ParameterByName( "年" ).AsString = invoices[i].ChargeDate.Year.ToString();
                        rpt.ParameterByName( "月" ).AsString = invoices[i].ChargeDate.Month.ToString();
                        rpt.ParameterByName( "日" ).AsString = invoices[i].ChargeDate.Day.ToString();
                        rpt.ParameterByName( "姓名" ).AsString = invoices[i].PatientName;
                        rpt.ParameterByName( "结算方式" ).AsString = invoices[i].PayType;
                        rpt.ParameterByName( "万" ).AsString = GetNumCN( invoices[i].TotalPay, NumericUnit.万 );
                        rpt.ParameterByName( "千" ).AsString = GetNumCN( invoices[i].TotalPay, NumericUnit.仟 );
                        rpt.ParameterByName( "百" ).AsString = GetNumCN( invoices[i].TotalPay, NumericUnit.佰 );
                        rpt.ParameterByName( "拾" ).AsString = GetNumCN( invoices[i].TotalPay, NumericUnit.拾 );
                        rpt.ParameterByName( "元" ).AsString = GetNumCN( invoices[i].TotalPay, NumericUnit.元 );
                        rpt.ParameterByName( "角" ).AsString = GetNumCN( invoices[i].TotalPay, NumericUnit.角 );
                        rpt.ParameterByName( "分" ).AsString = GetNumCN( invoices[i].TotalPay, NumericUnit.分 );
                        rpt.ParameterByName( "记账金额" ).AsString = invoices[i].VillagePay.ToString();
                        rpt.ParameterByName( "个人缴费金额" ).AsString = Convert.ToString( invoices[i].TotalPay - invoices[i].VillagePay - invoices[i].FavorPay );
                        if ( invoices[i].FavorPay > 0 )
                        {
                            rpt.ParameterByName( "优惠金额" ).AsString = "(优惠:" + Convert.ToString( invoices[i].FavorPay ) + ")";
                        }
                        else
                        {
                            rpt.ParameterByName( "优惠金额" ).AsString = "";
                        }

                        rpt.ParameterByName( "发票总金额" ).AsString = invoices[i].TotalPay.ToString();
                        rpt.ParameterByName( "收费员" ).AsString = invoices[i].ChargeUser;


                        for ( int m = 0; m < invoices[i].Items.Length; m++ )
                        {
                            try
                            {
                                if ( invoices[i].Items[m].ItemName.Trim() == "挂号费" && invoices[i].Items[m].Cost > 0 )
                                {
                                    rpt.ParameterByName( "发票项目_" + invoices[i].Items[m].ItemName.Trim() ).AsString = "挂号费：" + invoices[i].Items[m].Cost.ToString();
                                }
                                else
                                {
                                    rpt.ParameterByName( "发票项目_" + invoices[i].Items[m].ItemName.Trim() ).AsString = invoices[i].Items[m].Cost.ToString();
                                }
                            }
                            catch ( Exception err )
                            {
                                ErrorWriter.WriteLog( "发票打印传入参数:发票项目_" + invoices[i].Items[m].ItemName + " 错误\r\n" + err.Message );
                                continue;
                            }
                        }


                        for ( int m = 0; m < invoices[i].StatItems.Length; m++ )
                        {
                            try
                            {
                                rpt.ParameterByName( "大项目_" + invoices[i].StatItems[m].ItemName.Trim() ).AsString = invoices[i].StatItems[m].Cost.ToString();
                            }
                            catch ( Exception err )
                            {
                                ErrorWriter.WriteLog( "发票打印传入参数:大项目_" + invoices[i].StatItems[m].ItemName + " 错误\r\n" + err.Message );
                                continue;
                            }
                        }
                    }
                    catch
                    {
                        throw new Exception( "调用报表模板参数赋值发生错误！" );
                    }
                    if ( previewBeforPrint )
                    {
                        rpt.PrintPreview( false );
                    }
                    rpt.Print( false );
                }
                #endregion
            }
            else if ( style == InvoiceStyle.湖南省 )
            {
                #region 湖南省发票格式
                for ( int i = 0; i < invoices.Length; i++ )
                {
                    int sum = 1;
                    for (int j = 1; j < invoices[i].Items.Length; j++)
                    {
                        if (invoices[i].Items[j].ItemName.Trim() != invoices[i].Items[j - 1].ItemName.Trim())
                        {
                            sum += 1;
                        }
                    }
                    GridppReport rpt = new GridppReport();
                    printerName = HIS_PublicManager.PublicPrintSet.GetPrinterNameByReport( "门诊收费发票模板_HN.grf" );
                    rpt.Printer.PrinterName = printerName;

                    rpt.LoadFromFile( chargeInvoiceTemplatePath_HN );

                    try
                    {
                       // rpt.ParameterByName("分组数").AsString = sum.ToString();
                        rpt.ParameterByName( "医院名称" ).AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                        rpt.ParameterByName( "发票号" ).AsString = invoices[i].InvoiceNo;
                        rpt.ParameterByName( "年" ).AsString = invoices[i].ChargeDate.Year.ToString();
                        rpt.ParameterByName( "月" ).AsString = invoices[i].ChargeDate.Month.ToString();
                        rpt.ParameterByName( "日" ).AsString = invoices[i].ChargeDate.Day.ToString();
                        rpt.ParameterByName( "门诊号" ).AsString = ( new OutPatient( Convert.ToInt32(invoices[i].InvoiceNo).ToString(), OPDBillKind.门诊收费发票 ) ).VisitNo;
                        rpt.ParameterByName( "打印时间" ).AsString = XcDate.ServerDateTime.ToString( "yyyy-MM-dd HH:mm:ss" );
                        rpt.ParameterByName( "姓名" ).AsString = invoices[i].PatientName;
                        rpt.ParameterByName( "结算方式" ).AsString = invoices[i].PayType;
                        rpt.ParameterByName( "执行科室" ).AsString = BaseDataController.GetName( BaseDataCatalog.科室列表, Convert.ToInt32( invoices[i].Prescription[0].ExecDeptCode ) );
                        if ( invoices[i].FavorPay > 0 )
                        {
                            rpt.ParameterByName( "优惠金额" ).AsString = "(优惠:" + Convert.ToString( invoices[i].FavorPay ) + ")";
                        }
                        else
                        {
                            rpt.ParameterByName( "优惠金额" ).AsString = "";
                        }

                        rpt.ParameterByName( "发票总金额" ).AsString = invoices[i].TotalPay.ToString();
                        rpt.ParameterByName( "发票总金额_大写" ).AsString = HIS.SYSTEM.PubicBaseClasses.Money.NumToChn( invoices[i].TotalPay.ToString() );
                        rpt.ParameterByName( "收费员" ).AsString = invoices[i].ChargeUser;

                        DataTable tbData = new DataTable();
                        tbData.Columns.Add( "ITEM_NAME" );
                        tbData.Columns.Add( "COST" );
                        tbData.Columns.Add("ITEMNAME");
                        tbData.Columns.Add("TOLAL_FEE");
                            for (int itemIndex = 0; itemIndex < invoices[i].Items.Length; itemIndex++)
                            {
                                DataRow dr = tbData.NewRow();
                                dr["ITEM_NAME"] = invoices[i].Items[itemIndex].ItemName;
                                dr["COST"] = invoices[i].Items[itemIndex].Cost;
                                dr["ITEMNAME"] = invoices[i].Items[itemIndex].Item_Name;
                                dr["TOLAL_FEE"] = invoices[i].Items[itemIndex].Tolal_Fee;
                                tbData.Rows.Add(dr);
                            }                       
                        gridppReport = rpt;
                        tbPrintData = tbData;

                        rpt.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler( reportPrinter_FetchRecord );

                        if ( previewBeforPrint )
                        {
                            rpt.PrintPreview( false );
                        }
                        rpt.Print(false );
                    }
                    catch
                    {
                        MessageBox.Show( "打印发票输出发生错误", "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    }
                }
                #endregion
            }
        }

        
        /// <summary>
        /// 打印个人交款表
        /// </summary>
        /// <param name="accountBook"></param>
        public static void PrintAccountBook( PrivyAccountBook accountBook )
        {
            grproLib.GridppReport reportPrinter = new grproLib.GridppReport( );
            InvoiceStyle style = (InvoiceStyle)( Convert.ToInt32( OPDParamter.Parameters["021"] ) );
            string printerName = null;
            if (style == InvoiceStyle.广东省)
            {
                printerName = HIS_PublicManager.PublicPrintSet.GetPrinterNameByReport("门诊个人交款表模板.grf");
                reportPrinter.LoadFromFile(accountbookTemplatePath);
            }
            else if (style == InvoiceStyle.湖南省)
            {
                printerName = HIS_PublicManager.PublicPrintSet.GetPrinterNameByReport("门诊个人交款表模板_HN.grf");
                reportPrinter.LoadFromFile(accountbookTemplatePath_HN);
            }
            if ( printerName.Trim( ) == "" )
            {
                MessageBox.Show( "打印机没有设置，请先通过打印机设置配置好打印机" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }

            

            reportPrinter.Printer.PrinterName = printerName;


            reportPrinter.Title = "门诊个人交款表";
            try
            {
                //传入参数
                reportPrinter.ParameterByName( "医院名称" ).AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName + "门诊每日缴款清单";
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
                reportPrinter.ParameterByName( "记账合计" ).AsString = accountBook.TallyPart.TotalMoney.ToString();
                reportPrinter.ParameterByName( "记账合计张数" ).AsString = tallyCount.ToString( );

                reportPrinter.ParameterByName( "优惠金额" ).AsString = accountBook.FavorPart.TotalMoney.ToString( );
                //现金部分
                reportPrinter.ParameterByName( "实收现金" ).AsString = accountBook.CashPart.TotalMoney.ToString( );
                reportPrinter.ParameterByName( "挂号现金" ).AsString = accountBook.CashPart.Details[1].Money.ToString( );
                reportPrinter.ParameterByName( "挂号诊金" ).AsString = accountBook.CashPart.Details[2].Money.ToString( );
                reportPrinter.ParameterByName( "处方收费" ).AsString = accountBook.CashPart.Details[0].Money.ToString( );

                reportPrinter.ParameterByName( "小写合计" ).AsString = accountBook.InvoiceItemSumTotal.ToString( );
                reportPrinter.ParameterByName( "大写合计" ).AsString = HIS.SYSTEM.PubicBaseClasses.Money.NumToChn( accountBook.InvoiceItemSumTotal.ToString( ) );
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

        public static void PrintChargerReport(BaseReport Report, bool preview)
        {
            string reportPath = "";
            if (Report.Reportstyle == ReportStyle.科目为标题列)
                reportPath = chargerReportTemplate;
            else
                reportPath = incomeReportTemplate_B;   

            DataTable tbData = Report.BaseReportData;

            grproLib.GridppReport reportPrinter = new grproLib.GridppReport();

            if (!System.IO.File.Exists(reportPath))
            {
                PrintController.CreateIncomeReportTemplate(Report, false);

                MessageBox.Show("模板文件【" + reportPath + "】不存在,系统已为你创建了初始模板文件！你可以：\r\n1、使用安装目录下的报表设计器进行设计。\r\n2、联系管理员获取模板文件。");

                return;
            }

            reportPrinter.LoadFromFile(reportPath);
            string printerName = HIS_PublicManager.PublicPrintSet.GetPrinterNameByReport(reportPath);
            if (printerName.Trim() == "")
            {
                MessageBox.Show("没有正确设置打印机！请打开【报表打印机设置】设置好打印机再试！");
                return;
            }

            reportPrinter.Printer.PrinterName = printerName;


            try
            {
                reportPrinter.Title = Report.ReportTitle;
                try
                {
                    reportPrinter.ParameterByName("医院名称").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                    reportPrinter.ParameterByName("报表标题").AsString = Report.ReportTitle;
                    reportPrinter.ParameterByName("统计时间").AsString = "统计时间：" + Report.BeginDate.ToString("yyyy-MM-dd HH:mm:ss") + " -- " + Report.EndDate.ToString("yyyy-MM-dd HH:mm:ss");
                    reportPrinter.ParameterByName("制表人").AsString = "制表人：" + Report.Lister;
                    reportPrinter.ParameterByName("备注").AsString = "";
                }
                catch
                {
                    throw new Exception("报表模板参数没有正确设置，请用设计器打开报表并设置好参数");

                }
                gridppReport = reportPrinter;
                tbPrintData = tbData;
                reportPrinter.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler(reportPrinter_FetchRecord);
                if (preview)
                    reportPrinter.PrintPreview(false);
                else
                    reportPrinter.Print(false);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }



        /// <summary>
        /// 打印交款汇总表
        /// </summary>
        /// <param name="accountBook"></param>
        public static void PrintAllAccountBook(List<PrivyAccountBook> book,DateTime ?bBtime,DateTime?Etime)
        {
            grproLib.GridppReport reportPrinter = new grproLib.GridppReport();
            InvoiceStyle style = (InvoiceStyle)(Convert.ToInt32(OPDParamter.Parameters["021"]));
            string printerName = null;
            printerName = HIS_PublicManager.PublicPrintSet.GetPrinterNameByReport("门诊个人交款表模板_HN.grf");
            reportPrinter.LoadFromFile(accountbookTemplatePath_HN);
            if (printerName.Trim() == "")
            {
                MessageBox.Show("打印机没有设置，请先通过打印机设置配置好打印机", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            reportPrinter.Printer.PrinterName = printerName;
            reportPrinter.Title = "门诊交款表汇总";
            CollectAccountBook accountBook = AccountBookController.CollectAllAccountBook(book);
            try
            {
                //传入参数
                reportPrinter.ParameterByName("医院名称").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName + "门诊交款表汇总";

                reportPrinter.ParameterByName("交款时间").AsString = bBtime.Value.ToString("yyyy-MM-dd") + "到" + Etime.Value.ToString("yyyy-MM-dd");
                //传入交款科目
                for (int i = 0; i < accountBook.InvoiceItem.Length; i++)
                {
                    try
                    {
                        reportPrinter.ParameterByName(accountBook.InvoiceItem[i].ItemName.Trim()).AsString = accountBook.InvoiceItem[i].Cost.ToString();
                    }
                    catch
                    {
                        MessageBox.Show("没有找到参数:" + accountBook.InvoiceItem[i].ItemName + ",请确认模板中有该参数！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }
                }
                reportPrinter.ParameterByName("发票科目合计").AsString = accountBook.InvoiceItemSumTotal.ToString();
                int  sum = 0;
                int sum1 = 0;
                decimal  money = 0;
                string names="";
                for (int i = 0; i < accountBook.ChargeInvoiceInfo.Length; i++)
                {
                    sum += accountBook.ChargeInvoiceInfo[i].Count;
                    sum1 += accountBook.ChargeInvoiceInfo[i].RefundCount;
                    money += accountBook.ChargeInvoiceInfo[i].RefundMoney;
                    if (names.Contains(accountBook.ChargeInvoiceInfo[i].ChargeName))
                        continue;
                    names = names + accountBook.ChargeInvoiceInfo[i].ChargeName+",";
                }
                reportPrinter.ParameterByName("收费发票张数").AsString = sum.ToString();
                reportPrinter.ParameterByName("收费退费张数").AsString = sum1.ToString();
                reportPrinter.ParameterByName("收费退费金额").AsString = money.ToString();

                sum = 0;
                sum1 = 0;
                money = 0;
                for (int i = 0; i < accountBook.RegisterInvoiceInfo.Length; i++)
                {
                    sum += accountBook.RegisterInvoiceInfo[i] .Count;
                    sum1 += accountBook.RegisterInvoiceInfo[i].RefundCount;
                    money += accountBook.RegisterInvoiceInfo[i].RefundMoney;
                }
                reportPrinter.ParameterByName("交款人").AsString = names;
                reportPrinter.ParameterByName("挂号发票张数").AsString = sum.ToString();
                reportPrinter.ParameterByName("挂号退费张数").AsString = sum1.ToString();
                reportPrinter.ParameterByName("挂号退费金额").AsString = money.ToString();
                //按病人类型记账部分
                int tallyCount = 0;
                for (int i = 0; i < accountBook.TallyPart.Details.Length; i++)
                {
                    reportPrinter.ParameterByName(accountBook.TallyPart.Details[i].PayName).AsString = accountBook.TallyPart.Details[i].Money.ToString();
                    reportPrinter.ParameterByName(accountBook.TallyPart.Details[i].PayName + "_张数").AsString = accountBook.TallyPart.Details[i].BillCount.ToString();
                    tallyCount = tallyCount + accountBook.TallyPart.Details[i].BillCount;
                }
                reportPrinter.ParameterByName("记账合计").AsString = accountBook.TallyPart.TotalMoney.ToString();
                reportPrinter.ParameterByName("记账合计张数").AsString = tallyCount.ToString();

                reportPrinter.ParameterByName("优惠金额").AsString = accountBook.FavorPart.TotalMoney.ToString();
                //现金部分
                reportPrinter.ParameterByName("实收现金").AsString = accountBook.CashPart.TotalMoney.ToString();
                reportPrinter.ParameterByName("挂号现金").AsString = accountBook.CashPart.Details[1].Money.ToString();
                reportPrinter.ParameterByName("挂号诊金").AsString = accountBook.CashPart.Details[2].Money.ToString();
                reportPrinter.ParameterByName("处方收费").AsString = accountBook.CashPart.Details[0].Money.ToString();

                reportPrinter.ParameterByName("小写合计").AsString = accountBook.InvoiceItemSumTotal.ToString();
                reportPrinter.ParameterByName("大写合计").AsString = HIS.SYSTEM.PubicBaseClasses.Money.NumToChn(accountBook.InvoiceItemSumTotal.ToString());
                reportPrinter.PrintPreview(false);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        
    }
}
