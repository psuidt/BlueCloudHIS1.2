using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;
using HIS.MZ_BLL;

namespace HIS_MZManager.Report
{
    public partial class FrmIncomeReport : BaseMainForm
    {
        private string OperatorName;
        public FrmIncomeReport(int OperatorId,string FormTitle)
        {
            InitializeComponent( );

            this.Text = FormTitle;
            this.FormTitle = FormTitle;

            OperatorName = PublicDataReader.GetEmployeeNameById( OperatorId );
        }

        /// <summary>
        /// 获取统计时间
        /// </summary>
        /// <param name="month"></param>
        /// <param name="dateBegin"></param>
        /// <param name="dateEnd"></param>
        private void GetStatDate( HIS.MZ_BLL.StatDateType statDateType , short month , out DateTime dateBegin , out DateTime dateEnd )
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
                        strBegin = dateBegin.ToString( "yyyy-MM-dd" ) + " 00:00:00";
                        dateBegin = Convert.ToDateTime( strBegin );
                        //lblDate.Text = dateBegin.ToString( strDateFullFormat ) + " — " + dateEnd.ToString( strDateFullFormat );
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
                        //lblDate.Text = dateBegin.ToString( strDateFullFormat ) + " — " + dateEnd.ToString( strDateFullFormat );
                        break;
                    case HIS.MZ_BLL.StatDateType.交账时间:
                        //获取本月交账起始时间
                        DateTime accBeginDate;
                        DateTime accEndDate;
                        HIS.MZ_BLL.ReportClass.GetAccountBeginAndEndDatebyMonth_MZ( year , month , out accBeginDate , out accEndDate );
                        //由交账起始时间获取明细数据时间
                        HIS.MZ_BLL.ReportClass.GetDetailBeginAndEndDatebyAccount_MZ( accBeginDate , accEndDate , out dateBegin , out dateEnd );
                        //lblDate.Text = accBeginDate.ToString( strDateFullFormat ) + " — " + accEndDate.ToString( strDateFullFormat );
                        break;
                    case HIS.MZ_BLL.StatDateType.自定义时间:
                        dateBegin = dtpFrom.Value;
                        dateEnd = dtpEnd.Value;
                        //lblDate.Text = dateBegin.ToString( strDateFullFormat ) + " — " + dateEnd.ToString( strDateFullFormat );
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

        private void FrmIncomeReport_Load( object sender , EventArgs e )
        {
            foreach ( object obj in Enum.GetValues( typeof( StatDateType ) ) )
                cboDateType.Items.Add( obj.ToString( ) );
            cboDateType.Text = StatDateType.统计日.ToString( );

            //设置初始日期
            int year = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.Year;
            int month = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.Month;
            txtDay.Text = HIS.MZ_BLL.OPDParamter.Parameters["007"].ToString( );//读取设置的统计日

            //初始年
            for ( int i = 0 ; i < cboYear.Items.Count ; i++ )
            {
                if ( cboYear.Items[i].ToString( ) == year.ToString( ) )
                {
                    cboYear.SelectedIndex = i;
                    break;
                }
            }


            for ( int i = 0 ; i < cboMonth.Items.Count ; i++ )
            {
                if ( cboMonth.Items[i].ToString( ) == month.ToString( "00" ) )
                {
                    cboMonth.SelectedIndex = i;
                    break;
                }
            }

            dtpFrom.Value = Convert.ToDateTime( year + "-" + month + "-01 00:00:00" );
            dtpEnd.Value = dtpFrom.Value.AddMonths( 1 ).AddDays( -1 ).AddHours( 23 ).AddMinutes( 59 ).AddSeconds( 59 );

            foreach ( object obj in Enum.GetValues( typeof( StatType ) ) )
                cboStatType.Items.Add( obj.ToString( ) );
            cboStatType.Text = StatType.门诊发票分类.ToString( );

            cboType.SelectedIndex = 0;
        }

        private void btnStat_Click( object sender , EventArgs e )
        {
            try
            {
                btnStat.Enabled = false;
                btnPrint.Enabled = false;
                btnClose.Enabled = false;
                Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor( );
                StatDateType dateType = StatDateType.统计日;
                foreach ( object obj in Enum.GetValues( typeof( StatDateType ) ) )
                {
                    if ( obj.ToString( ) == cboDateType.Text )
                    {
                        dateType = (StatDateType)obj;
                        break;
                    }
                }

                DateTime dateBegin;
                DateTime dateEnd;
                short month = Convert.ToInt16( cboMonth.Text );
                GetStatDate( dateType , month , out dateBegin , out dateEnd );
                StatType statType = StatType.门诊发票分类;
                foreach ( object obj in Enum.GetValues( typeof( StatType ) ) )
                {
                    if ( obj.ToString( ) == cboStatType.Text )
                    {
                        statType = (StatType)obj;
                        break;
                    }
                }
                int showtype = cboType.SelectedIndex;

                lblDate.Text = "当前统计时间范围：" + dateBegin.ToString( "yyyy-MM-dd HH:mm:ss" ) + " — " + dateEnd.ToString( "yyyy-MM-dd HH:mm:ss" );
                int fixcol;
                DataTable tbData = ReportClass.GetDeptDocIncomeData( statType , dateBegin , dateEnd , showtype , out fixcol );

                dgvReport.Columns.Clear( );
                dgvReport.DataSource = tbData;
                for ( int i = 0 ; i < fixcol ; i++ )
                    dgvReport.Columns[i].Frozen = true;
                for ( int i = fixcol - 1 ; i < dgvReport.Columns.Count ; i++ )
                    dgvReport.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch ( Exception err )
            {
                MessageBox.Show( "统计报表时发生错误！请重试" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
            finally
            {
                btnStat.Enabled = true;
                btnPrint.Enabled = true;
                btnClose.Enabled = true;
                Cursor = Cursors.Default;
            }
            
        }

        private void cboDateType_SelectedIndexChanged( object sender , EventArgs e )
        {
            StatDateType dateType = StatDateType.统计日;
            foreach ( object obj in Enum.GetValues( typeof( StatDateType ) ) )
            {
                if ( obj.ToString( ) == cboDateType.Text )
                {
                    dateType = (StatDateType)obj;
                    break;
                }
            }

            switch ( dateType )
            {
                case StatDateType.交账时间:
                    panel1.Enabled = false;
                    panel2.Enabled = true;
                    break;
                case StatDateType.统计日:
                    panel1.Enabled = false;
                    panel2.Enabled = true;
                    break;
                case StatDateType.自然时间:
                    panel1.Enabled = false;
                    panel2.Enabled = true;
                    break;
                case StatDateType.自定义时间:
                    panel1.Enabled = true;
                    panel2.Enabled = false;
                    break;
               
            }
        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.Close( );
        }

        private void btnPrint_Click( object sender , EventArgs e )
        {
            int docDept = cboType.SelectedIndex;
            int classType = cboStatType.SelectedIndex;

            if ( dgvReport.DataSource == null )
            {
                MessageBox.Show( "没有需要打印的数据" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }
            string title = cboType.Text + "收入表<" + cboStatType.Text + ">";
            PrintController.PrintIncomeReport( docDept , classType , title , lblDate.Text , OperatorName , (DataTable)dgvReport.DataSource );
        }
    }
}
