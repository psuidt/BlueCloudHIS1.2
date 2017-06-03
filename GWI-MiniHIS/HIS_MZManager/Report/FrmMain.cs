using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_MZManager.Report
{
    public partial class FrmMain : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private string strDateFullFormat = "yyyy-MM-dd HH:mm:ss";
        private string strDateDateFormat = "yyyy-MM-dd";
        /// <summary>
        /// 报表类型
        /// </summary>
        private HIS.MZ_BLL.ReportType reportType;
        private HIS.MZ_BLL.StatType statType;
        private bool bymonth;
        private GWMHIS.BussinessLogicLayer.Classes.User currentUser;
        /// <summary>
        /// 报表打印类
        /// </summary>
        grproLib.GridppReport reportPrinter = new grproLib.GridppReport( );

        public FrmMain( string FormText, HIS.MZ_BLL.ReportType rptType, HIS.MZ_BLL.StatType StatType, bool byMonth, GWMHIS.BussinessLogicLayer.Classes.User CurrentUser )
        {
            InitializeComponent( );
            this.Text = FormText;
            this.FormTitle = FormText;
            reportType = rptType;
            statType = StatType;
            bymonth = byMonth;
            currentUser = CurrentUser;
        }
        /// <summary>
        /// 获取统计时间
        /// </summary>
        /// <param name="month"></param>
        /// <param name="dateBegin"></param>
        /// <param name="dateEnd"></param>
        private void GetStatDate(HIS.MZ_BLL.StatDateType statDateType, short month,out DateTime dateBegin,out DateTime dateEnd)
        {
            short year = Convert.ToInt16( cboYear.Text );
            short day = 0;
            string strEnd = "";
            string strBegin = "";
            dateBegin = DateTime.Now;
            dateEnd = DateTime.Now;
            try
            {
                switch ( statDateType )
                {
                    case HIS.MZ_BLL.StatDateType.统计日:
                        day = Convert.ToInt16( txtDay.Text );
                        strEnd = year.ToString( ) + "-" + month.ToString( ) + "-" + day.ToString( ) + " 23:59:59";
                        dateEnd = Convert.ToDateTime( strEnd );
                        dateBegin = dateEnd.AddMonths( -1 ).AddDays( 1 );
                        strBegin = dateBegin.ToString( strDateDateFormat ) + " 00:00:00";
                        dateBegin = Convert.ToDateTime( strBegin );
                        lblDate.Text = dateBegin.ToString( strDateFullFormat ) + " — " + dateEnd.ToString( strDateFullFormat );
                        break;
                    case HIS.MZ_BLL.StatDateType.自然时间:
                        day = 31;
                        strBegin = year.ToString( ) + "-" + month.ToString( ) + "-01 00:00:00";
                        while ( true )
                        {
                            try
                            {
                                strEnd = year.ToString( ) + "-" + month.ToString( ) + "-" + day.ToString( ) + " 23:59:59";
                                DateTime dtm = Convert.ToDateTime( strEnd );
                                break;
                            }
                            catch
                            {
                                day--;
                            }
                        }
                        dateBegin = Convert.ToDateTime( strBegin );
                        dateEnd = Convert.ToDateTime( strEnd );
                        lblDate.Text = dateBegin.ToString( strDateFullFormat ) + " — " + dateEnd.ToString( strDateFullFormat );
                        break;
                    case HIS.MZ_BLL.StatDateType.交账时间:
                        //获取本月交账起始时间
                        DateTime accBeginDate;
                        DateTime accEndDate;
                        HIS.MZ_BLL.ReportClass.GetAccountBeginAndEndDatebyMonth_MZ( year , month , out accBeginDate , out accEndDate );
                        //由交账起始时间获取明细数据时间
                        HIS.MZ_BLL.ReportClass.GetDetailBeginAndEndDatebyAccount_MZ( accBeginDate,accEndDate , out dateBegin , out dateEnd );
                        lblDate.Text = accBeginDate.ToString( strDateFullFormat ) + " — " + accEndDate.ToString( strDateFullFormat );
                        break;
                    case HIS.MZ_BLL.StatDateType.自定义时间:
                        dateBegin = dtpFrom.Value;
                        dateEnd = dtpTo.Value;
                        lblDate.Text = dateBegin.ToString( strDateFullFormat ) + " — " + dateEnd.ToString( strDateFullFormat );
                        break;
                    default:
                        throw new Exception( "错误的统计时间类型" );
                        return;
                }
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
            
        }
        /// <summary>
        /// 按指定时间获取报表数据(从明细数据获取)
        /// </summary>
        /// <param name="dateBegin"></param>
        /// <param name="dateEnd"></param>
        /// <returns></returns>
        private System.Data.DataTable GetReportData(DateTime dateBegin,DateTime dateEnd ,HIS.MZ_BLL.StatDateType statDateType )
        {
            HIS.MZ_BLL.ReportClass report = null;
            DataTable tbData = null;

            report = new HIS.MZ_BLL.ReportClass( dateBegin , dateEnd , reportType , statType , statDateType );
            tbData = report.GetReportData( true );
            
            return tbData;
        }
        /// <summary>
        /// 按指定年份和月份获取报表数据(从现有报表数据获取)
        /// </summary>
        /// <param name="dateBegin"></param>
        /// <param name="dateEnd"></param>
        /// <param name="byDetailData"></param>
        /// <returns></returns>
        private System.Data.DataTable GetReportData( int year , int month ,HIS.MZ_BLL.StatDateType statDateType)
        {
            HIS.MZ_BLL.ReportClass report = null;
            DataTable tbData = null;

            report = new HIS.MZ_BLL.ReportClass( year , month , reportType , statType , statDateType );
            tbData = report.GetReportData( false );
           

            return tbData;
        }

        private DataTable FormatDataTable(System.Data.DataTable srcTable)
        {
            
            DataTable tbRet = srcTable.Copy( );

            if ( srcTable.Rows.Count == 0 )
                return tbRet;

            DataRow dr = tbRet.NewRow( );
            
            int startCol = 0;
            if ( reportType == HIS.MZ_BLL.ReportType.门诊收入月报表 )
                startCol = 2;
            else
                startCol = 3;
            //加入合计行
            for ( int i = startCol-1 ; i < tbRet.Columns.Count - 1 ; i++ )
                dr[tbRet.Columns[i].ColumnName] = tbRet.Compute( "sum(" + tbRet.Columns[i].ColumnName + ")" ,"");
            dr[0] = "合计";
            tbRet.Rows.Add( dr );

            return tbRet;
        }
        /// <summary>
        /// 报表打印
        /// </summary>
        private void ReportPrint(bool view)
        {
            if ( dgvReport.Rows.Count == 0 )
                return;
            if ( dgvReport.DataSource == null )
                return;
            reportPrinter = new grproLib.GridppReport( );
            string reportFile = System.Windows.Forms.Application.StartupPath + "\\report\\" + FormTitle + ".grf";

            if (! System.IO.File.Exists( reportFile ) )
            {
                MessageBox.Show( "报表模板文件不存在，不能打印或预览！请下载或联系管理员增加该报表", "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }

            reportPrinter.LoadFromFile( reportFile );
            string printerName = HIS_PublicManager.PublicPrintSet.GetPrinterNameByReport(FormTitle + ".grf");
            reportPrinter.Printer.PrinterName = printerName;
            
            try
            {
                reportPrinter.Title = FormTitle;
                try
                {
                    reportPrinter.ParameterByName( "医院名称" ).AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                    reportPrinter.ParameterByName( "报表标题" ).AsString = FormTitle;
                    reportPrinter.ParameterByName( "统计时间" ).AsString = "统计日期：" + this.lblDate.Text;
                    reportPrinter.ParameterByName( "制表人" ).AsString = "制表人：" + currentUser.Name;
                    reportPrinter.ParameterByName( "备注" ).AsString = "";
                }
                catch(Exception err)
                {
                    throw new Exception( "报表模板参数没有正确设置，请用设计器打开报表并设置好参数" );
                }
                reportPrinter.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler( report_FetchRecord );
                if ( view )
                    reportPrinter.PrintPreview( false );
                else
                    reportPrinter.Print( true );
            }
            catch(Exception err)
            {
                MessageBox.Show( err.Message ,"" ,MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }

        void report_FetchRecord( ref bool pEof )
        {
            DataTable dt = (DataTable)dgvReport.DataSource;
            //整理成指定的列
            DataTable dtTitle = HIS.MZ_BLL.ReportClass.GetReportTitle( FormTitle );
            DataTable dtRelation = HIS.MZ_BLL.ReportClass.GetReportTitleFieldRelation( FormTitle );

            DataTable dtPrint = new DataTable( );
            string memo = "";
            foreach ( DataRow dr in dtTitle.Rows )
                dtPrint.Columns.Add( dr["TITLE_NAME"].ToString( ).Trim( ) );
            try
            {
                bool first;
                first = true;
                foreach ( DataRow dr in dt.Rows )
                {
                    DataRow drNew = dtPrint.NewRow( );//构造新数据行
                    decimal totalValue = 0;
                    foreach ( DataColumn col in dtPrint.Columns )
                    {
                        totalValue = 0;
                        DataRow[] drRelation = dtRelation.Select( "TITLE_NAME = '" + col.ColumnName + "' " );
                        if ( drRelation.Length == 1 )
                        {
                            string field_name = drRelation[0]["FIELD_NAME"].ToString( ).Trim( );
                            drNew[col.ColumnName] = dr[field_name];
                        }
                        else
                        {
                            memo += col.ColumnName + "包括【";
                            for ( int i = 0 ; i < drRelation.Length ; i++ )
                            {
                                decimal val = 0;
                                string field_name = drRelation[i]["FIELD_NAME"].ToString( ).Trim( );
                                if ( !Convert.IsDBNull( dr[field_name] ) )
                                    val = Convert.ToDecimal( dr[field_name] );
                                totalValue += val;
                                memo += field_name + ",";
                            }
                            memo += "】";
                            if ( totalValue != 0 )
                                drNew[col.ColumnName] = totalValue;
                        }
                    }
                    dtPrint.Rows.Add( drNew );

                    if ( first )
                    {
                        reportPrinter.ParameterByName( "备注" ).AsString = memo;
                        first = false;
                    }
                }
            }
            catch(Exception err)
            {
                MessageBox.Show( err.Message );
            }
            GWI_DesReport.HisReport.FillRecordToReport( reportPrinter , dtPrint );
        }
        /// <summary>
        /// 设置网格样式
        /// </summary>
        private void SetGridDisplayStyle(  )
        {
            int fixColumn = 1;
            if ( reportType == HIS.MZ_BLL.ReportType.医生科室收入月报表 )
                fixColumn = 2;
            
            dgvReport.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReport.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReport.Columns[fixColumn].Frozen = true;
            //dgvReport.AutoResizeColumns( DataGridViewAutoSizeColumnsMode.ColumnHeader );
            for ( int i = fixColumn; i < dgvReport.Columns.Count; i++ )
            {
                dgvReport.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvReport.Columns[i].Width = 100;
            }
        }

        /// <summary>
        /// 保存报表
        /// </summary>
        private void SaveReport()
        {

            HIS.MZ_BLL.StatDateType statDateType = HIS.MZ_BLL.StatDateType.自然时间;
            foreach ( object item in Enum.GetValues( typeof( HIS.MZ_BLL.StatDateType ) ) )
            {
                if ( item.ToString() == cboStatDateType.Text )
                {
                    statDateType = (HIS.MZ_BLL.StatDateType)item;
                    break;
                }
            }

            if ( dgvReport.DataSource == null )
                return;
            if ( dgvReport.Rows.Count == 0 )
                return;

            //从明细统计数据
            short month = Convert.ToInt16( cboMonth.Text );
            short year = Convert.ToInt16( cboYear.Text );

            DateTime dateBegin, dateEnd;
            GetStatDate( statDateType, month, out dateBegin, out dateEnd );
            //判断当前日期是否在统计日期之后。之前业务数据还在发生改变，不让保存
            DateTime currentDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            if ( currentDate < dateEnd )
            {
                MessageBox.Show( "当前时间还未到统计截止日，业务数据可能会发生改变，报表不能保存！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            DataTable tbData = (DataTable)dgvReport.DataSource;

            if ( HIS.MZ_BLL.ReportClass.ReportExists( year, month, statType, reportType, statDateType ) )
            {
                if ( MessageBox.Show( "当前报表已存在，是否覆盖现有报表？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.No )
                    return;
            }

            try
            {
                HIS.MZ_BLL.ReportClass.SaveReport( year, month, dateBegin, dateEnd, reportType, statType, statDateType, tbData, currentUser.Name );
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message, "保存", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }

        }
        
        private void FrmMain_Load( object sender , EventArgs e )
        {
            //初始化统计日期类型选择列表
            cboStatDateType.SelectedIndexChanged -=new EventHandler(cboStatDateType_SelectedIndexChanged);
            foreach ( object obj in Enum.GetValues( typeof( HIS.MZ_BLL.StatDateType ) ) )
                cboStatDateType.Items.Add( obj.ToString( ) );
            cboStatDateType.SelectedIndex = 0;
            cboStatDateType.SelectedIndexChanged += new EventHandler( cboStatDateType_SelectedIndexChanged );
            //设置初始日期
            int year = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.Year;
            int month = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.Month;
            txtDay.Text = HIS.MZ_BLL.OPDParamter.Parameters["007"].ToString();//读取设置的统计日

            //初始年
            cboYear.SelectedIndexChanged-=new EventHandler(cboYear_SelectedIndexChanged);
            for ( int i = 0 ; i < cboYear.Items.Count ; i++ )
            {
                if ( cboYear.Items[i].ToString( ) == year.ToString( ) )
                {
                    cboYear.SelectedIndex = i;
                    break;
                }
            }
            cboYear.SelectedIndexChanged += new EventHandler( cboYear_SelectedIndexChanged );

            
            for ( int i = 0 ; i < cboMonth.Items.Count ; i++ )
            {
                if ( cboMonth.Items[i].ToString( ) == month.ToString("00" ) )
                {
                    cboMonth.SelectedIndex = i;
                    break;
                }
            }

            dtpFrom.Value = Convert.ToDateTime( year + "-" + month + "-01 00:00:00" );
            dtpTo.Value = dtpFrom.Value.AddMonths( 1 ).AddDays( -1 ).AddHours( 23 ).AddMinutes( 59 ).AddSeconds( 59 );

            if ( currentUser.IsAdministrator )
                btnSetting.Visible = true;
            else
                btnSetting.Visible = false;
        }

        private void cboYear_SelectedIndexChanged( object sender , EventArgs e )
        {
            ShowReport( );
        }

        private void cboMonth_SelectedIndexChanged( object sender , EventArgs e )
        {
            ShowReport( );
        }

       

        private void dgvReport_RowPostPaint( object sender , DataGridViewRowPostPaintEventArgs e )
        {
            
        }

        private void ShowReport(  )
        {
            HIS.MZ_BLL.StatDateType statDateType = HIS.MZ_BLL.StatDateType.自然时间;
            
            foreach ( object item in Enum.GetValues( typeof( HIS.MZ_BLL.StatDateType ) ) )
            {
                if ( item.ToString( ) == cboStatDateType.Text )
                {
                    statDateType = (HIS.MZ_BLL.StatDateType)item;
                    break;
                }
            }
            short month = Convert.ToInt16( cboMonth.Text );
            short year = Convert.ToInt16( cboYear.Text );
            DateTime dateBegin , dateEnd;
            GetStatDate(statDateType, month , out dateBegin , out dateEnd );

            
            //判断当前报表是否存在
            DataTable dataReportData = null;
            if ( HIS.MZ_BLL.ReportClass.ReportExists( year , month , statType , reportType,statDateType ) )
            {
                //获取并显示
                dataReportData = GetReportData( year , month , statDateType );
                if ( dataReportData == null )
                {
                    MessageBox.Show( year.ToString( ) + "年" + month.ToString( ) + "月的" + this.FormTitle + "(" + statDateType.ToString() + ")不存在，请从明细获取数据" , "" , MessageBoxButtons.OK , MessageBoxIcon.Exclamation );
                    if ( dgvReport.DataSource != null )
                        ( (DataTable)dgvReport.DataSource ).Rows.Clear( );
                    return;
                }
                else
                {
                    dgvReport.DataSource = FormatDataTable( dataReportData );
                    SetGridDisplayStyle( );
                }
            }
            else
            {
                //string msg = year.ToString( ) + "年" + month.ToString( ) + "月的" + this.FormTitle +  "("+statDateType.ToString()+")不存在，请从明细获取数据" ;
                
                //如果报表没有汇总处理，则从明细统计数据
                month = Convert.ToInt16( cboMonth.Text );

                GetStatDate( statDateType , month , out dateBegin , out dateEnd );
                try
                {
                    dataReportData = GetReportData( dateBegin , dateEnd , statDateType );
                    if ( dataReportData == null )
                    {
                        return;
                    }
                    dgvReport.DataSource = FormatDataTable( dataReportData );
                    SetGridDisplayStyle();
                }
                catch ( Exception err )
                {
                    MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                }

                return;
            }
        }

        private void cboStatDateType_SelectedIndexChanged( object sender , EventArgs e )
        {
            if ( cboStatDateType.Text == HIS.MZ_BLL.StatDateType.统计日.ToString() )
            {
                label3.Visible = true;
                txtDay.Visible = true;
                lblInfo.Text = "统计时间范围为上个月指定的时间（天）的第二天到本月的指定的时间（天）。\r\n例如：统计日为每月25号，则一月份的报表统计时间为2008年12月26日至2009年1月25日";
            }
            if ( cboStatDateType.Text == HIS.MZ_BLL.StatDateType.交账时间.ToString()
                || cboStatDateType.Text == HIS.MZ_BLL.StatDateType.自然时间.ToString() )
            {
                label3.Visible = false;
                txtDay.Visible = false;
                if ( cboStatDateType.Text == HIS.MZ_BLL.StatDateType.交账时间.ToString() )
                {
                    lblInfo.Text = "交账时间范围为指定月的第一笔交账单的时间到本月末最后一笔交账单的时间。\r\n例如：2009年1月的第一笔交账单时间为2009-01-01 16:01:34，最后一笔交账单时间为:2009-01-31 18:01:34,则统计时间范围为2009-01-01 16:01:34 -- 2009-01-31 18:01:34";
                }
                else
                {
                    lblInfo.Text = "自然时间范围为指定日的0点到24点之间。\r\n例如：2009年1月的自然时间范围为 2009-01-01 00：00：00 - 2009-01-31 23：59：59";
                }
            }
            else
            {
                lblInfo.Text = "用户自定义的时间";
            }

            if ( cboStatDateType.Text == HIS.MZ_BLL.StatDateType.自定义时间.ToString() )
            {
                panel2.Visible = false;
                panel2.Dock = DockStyle.None;

                panel3.Visible = true;
                panel3.Dock = DockStyle.Fill;
            }
            else
            {
                panel2.Visible = true;
                panel2.Dock = DockStyle.Fill;

                panel3.Visible = false;
                panel3.Dock = DockStyle.None;
            }

            ShowReport( );
        }

        private void btnCreateReport_Click( object sender, EventArgs e )
        {
            toolBar_ButtonClick( sender, e );
        }

        private void btnView_Click( object sender, EventArgs e )
        {
            toolBar_ButtonClick( sender, e );
        }

        private void btnPrint_Click( object sender, EventArgs e )
        {
            toolBar_ButtonClick( sender, e );
        }

        private void btnSetting_Click( object sender, EventArgs e )
        {
            toolBar_ButtonClick( sender, e );
        }

        private void btnClose_Click( object sender, EventArgs e )
        {
            toolBar_ButtonClick( sender, e );
        }

        private void toolBar_ButtonClick( object sender, EventArgs e )
        {
            HIS.MZ_BLL.StatDateType statDateType = HIS.MZ_BLL.StatDateType.自然时间;
            foreach ( object item in Enum.GetValues( typeof( HIS.MZ_BLL.StatDateType ) ) )
            {
                if ( item.ToString() == cboStatDateType.Text )
                {
                    statDateType = (HIS.MZ_BLL.StatDateType)item;
                    break;
                }
            }

            ToolStripButton ctrl = (ToolStripButton)sender;

            if ( ctrl.Name == this.btnCreateReport.Name )
            {
                #region ...
                //从明细统计数据
                short month = Convert.ToInt16( cboMonth.Text );
                DateTime dateBegin, dateEnd;
                GetStatDate( statDateType, month, out dateBegin, out dateEnd );
                try
                {
                    DataTable dataReportData = GetReportData( dateBegin, dateEnd, statDateType );
                    if ( dataReportData == null )
                    {
                        return;
                    }
                    dgvReport.DataSource = FormatDataTable( dataReportData );
                    SetGridDisplayStyle();
                }
                catch ( Exception err )
                {
                    MessageBox.Show( err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }



                #endregion
            }


            

            if ( ctrl.Name == btnClose.Name )
                this.Close();
            if ( ctrl.Name == btnView.Name )
            {
                ReportPrint( true );
            }
            if ( ctrl.Name == btnPrint.Name )
            {
                ReportPrint( false );
            }
            if ( ctrl.Name == btnSetting.Name )
            {
                string[] fixColumn = new string[] { "收费员", "合计" };
                if ( reportType == HIS.MZ_BLL.ReportType.医生科室收入月报表 )
                    fixColumn = new string[] { "医生姓名", "科室名称", "合计" };

                FrmReportSetting fSetting = new FrmReportSetting( this.FormTitle, fixColumn, statType, currentUser );
                fSetting.ShowDialog();
            }
        }

    }
}
