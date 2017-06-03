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
using HIS.MZ_BLL.Report;

namespace HIS_MZManager.Report
{
    public partial class FrmPatientFeeReport : BaseMainForm
    {
        private int employeeId;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <param name="FormText"></param>
        public FrmPatientFeeReport(int EmployeeId,string FormText)
        {
            InitializeComponent( );

            this.Text = FormText;
            this.FormTitle = FormText;

            employeeId = EmployeeId;
        }

        private void FrmPatientFeeReport_Load( object sender , EventArgs e )
        {
            foreach ( object obj in Enum.GetValues( typeof( StatDateType ) ) )
                cboDateType.Items.Add( obj.ToString( ) );
            cboDateType.Text = StatDateType.统计日.ToString( );

            foreach ( object obj in Enum.GetValues( typeof( OPDBillKind ) ) )
                cboInvoiceType.Items.Add( obj.ToString( ) );
            cboInvoiceType.SelectedIndex = 0;


            cboPatType.DisplayMember = "NAME";
            cboPatType.ValueMember = "PATTYPECODE";
            cboPatType.DataSource = BaseDataController.BaseDataSet[BaseDataCatalog.病人类型列表];
            
            dtpFrom.Value = Convert.ToDateTime( DateTime.Now.ToString( "yyyy-MM-dd" ) + " 00:00:00" );
            dtpEnd.Value = Convert.ToDateTime( DateTime.Now.ToString( "yyyy-MM-dd" ) + " 23:59:59" );

            cboCharge.DisplayMember = "NAME";
            cboCharge.ValueMember = "EMPLOYEE_ID";
            cboCharge.DataSource = BaseDataController.BaseDataSet[BaseDataCatalog.人员列表];

            cboDept.DisplayMember = "NAME";
            cboDept.ValueMember = "DEPT_ID";
            cboDept.DataSource = BaseDataController.BaseDataSet[BaseDataCatalog.科室列表].Select("MZ_FLAG=1 AND TYPE_CODE='001'").CopyToDataTable();

            System.Collections.Hashtable htDoc = new System.Collections.Hashtable();
            DataTable tb = BaseDataController.BaseDataSet[BaseDataCatalog.医生列表];
            foreach ( DataRow dr in tb.Rows )
            {
                if (! htDoc.ContainsKey( Convert.ToInt32(dr["EMPLOYEE_ID"]) ) )
                {
                    htDoc.Add( Convert.ToInt32( dr["EMPLOYEE_ID"] ) , dr["EMP_NAME"].ToString().Trim());
                }
            }
            foreach ( object obj in htDoc )
                cboDoc.Items.Add( ((System.Collections.DictionaryEntry)obj).Value.ToString() );
        }

        private void btnStat_Click( object sender , EventArgs e )
        {
            SetControlEnable( false );

            DateTime beginDate;
            DateTime endDate;
            BaseReport report = null;
            string accountIdList;
            string patTypeCode = "";
            int statDay = Convert.ToInt32( txtDay.Text );
            StatDateType dateType = StatDateType.统计日;
            OPDBillKind invoiceType = OPDBillKind.所有发票;

            #region 统计条件
            foreach ( object obj in Enum.GetValues( typeof( StatDateType ) ) )
            {
                if ( obj.ToString( ) == cboDateType.Text )
                {
                    dateType = (StatDateType)obj;
                    break;
                }
            }
            foreach ( object obj in Enum.GetValues(typeof(OPDBillKind)) )
            {
                if ( obj.ToString( ) == cboInvoiceType.Text )
                {
                    invoiceType = (OPDBillKind)obj;
                    break;
                }
            }
            if ( chkPatType.Checked )
            {
                patTypeCode = cboPatType.SelectedValue.ToString( );
            }
            #endregion
            ReportController.GetReportBeginDateAndEndDate( dateType , statDay , dtpFrom.Value , dtpEnd.Value , out beginDate , out endDate , out accountIdList );
            lblDate.Text = beginDate.ToString( "yyyy-MM-dd HH:mm:ss" ) + "--" + endDate.ToString( "yyyy-MM-dd HH:mm:ss" );
            try
            {
                report = new PatientFeeReport( );
                report.BeginDate = beginDate;
                report.EndDate = endDate;
                ( (PatientFeeReport)report ).PatientTypeCode = patTypeCode;
                ( (PatientFeeReport)report ).InvoiceType = invoiceType;
                ( (PatientFeeReport)report ).CurDocName = chkCureDoc.Checked ? cboDoc.Text : "";
                ( (PatientFeeReport)report ).CurDeptName = chkDept.Checked ? cboDept.Text : "";
                ( (PatientFeeReport)report ).ChargeName = chkSfy.Checked ? cboCharge.Text : "";
                report.StatDateType = dateType;
                report.AccountIdList = accountIdList;
                report.ReportTitle = "门诊病人费用统计表";
                report.Lister = BaseDataController.GetName( BaseDataCatalog.人员列表, employeeId ); //PublicDataReader.GetEmployeeNameById( employeeId );

                ReportController.FillReport( report );
                dgvReport.DataSource = report.DataResult;
                dgvReport.Tag = report;
              
                for ( int i = 0 ; i < dgvReport.Columns.Count ; i++ )
                {
                    if ( i >= 7 )
                    {
                        dgvReport.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvReport.Columns[i].Width = 80;
                    }
                    if ( i < 8 )
                    {
                        dgvReport.Columns[i].Frozen = true;
                    }
                }
            }
            catch
            {
                MessageBox.Show( "统计发生错误！" ,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                SetControlEnable( true );
            }
        }

        private void cboDateType_SelectedIndexChanged( object sender , EventArgs e )
        {
            if ( cboDateType.Text == StatDateType.统计日.ToString( ) )
            {
                dtpFrom.CustomFormat = "yyyy-MM";
                dtpEnd.CustomFormat = "yyyy-MM";
            }
            if ( cboDateType.Text == StatDateType.交账时间.ToString( ) || cboDateType.Text == StatDateType.自定义时间.ToString( ) )
            {
                dtpFrom.CustomFormat = "yyyy-MM-dd HH:mm:ss";
                dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            }
            if ( cboDateType.Text == StatDateType.自然时间.ToString( ) )
            {
                dtpFrom.CustomFormat = "yyyy-MM-dd";
                dtpEnd.CustomFormat = "yyyy-MM-dd";
            }
        }

        private void chkPatType_CheckedChanged( object sender , EventArgs e )
        {
            cboPatType.Enabled = chkPatType.Checked;
        }

        private void btnExcel_Click( object sender , EventArgs e )
        {
            if ( dgvReport.Tag == null )
            {
                MessageBox.Show( "没有数据可打印，请先统计" , "" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                return;
            }
            try
            {
                SetControlEnable( false );
                Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor( );

                PrintController.OnExporting += new OnExportingEventHandle( PrintController_OnExporting );

                PrintController.ReportToExcel( (BaseReport)dgvReport.Tag );
            }
            catch
            {
                MessageBox.Show( "输出Excel发生错误！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
            finally
            {
                SetControlEnable( true );
                Cursor = Cursors.Default;
            }
            
        }

        void PrintController_OnExporting( ExportingEventArgs e )
        {
            pgb.Maximum = e.TotalCount;
            pgb.Value = e.CurrentCount;
        }

        void SetControlEnable(bool enable)
        {
            pgb.Visible = enable ? false : true;

            cboDateType.Enabled = enable;
            dtpFrom.Enabled = enable;
            dtpEnd.Enabled = enable;
            cboInvoiceType.Enabled = enable;
            chkPatType.Enabled = enable;
            if ( chkPatType.Checked )
            {
                cboPatType.Enabled = enable;
            }
            btnClose.Enabled = enable;
            btnExcel.Enabled = enable;
            btnPrint.Enabled = enable;
            btnStat.Enabled = enable;
        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.Close( );
        }

        private void btnPrint_Click( object sender , EventArgs e )
        {
            if ( dgvReport.Tag == null )
            {
                MessageBox.Show( "没有数据可打印，请先统计" , "" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                return;
            }

            PrintReport( (BaseReport)dgvReport.Tag , chkPreview.Checked );
        }

        private void PrintReport( BaseReport Report , bool preview )
        {
            try
            {
                PrintController.PrintPatientFeeReport( Report , preview );
            }
            catch ( Exception err )
            {
                ErrorWriter.WriteLog( err.Message );
                MessageBox.Show( "预览/打印发生错误！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }

        private void chkCureDoc_CheckedChanged( object sender, EventArgs e )
        {
            cboDoc.Enabled = chkCureDoc.Checked;
        }

        private void chkDept_CheckedChanged( object sender, EventArgs e )
        {
            cboDept.Enabled = chkDept.Checked;
        }

        private void chkSfy_CheckedChanged( object sender, EventArgs e )
        {
            cboCharge.Enabled = chkSfy.Checked;
        }
    }
}
