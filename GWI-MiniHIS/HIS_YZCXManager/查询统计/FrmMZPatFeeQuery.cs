using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;
using HIS.YZCX_BLL;

namespace HIS_YZCXManager
{
    public partial class FrmMZPatFeeQuery : BaseMainForm
    {
        private int employeeId;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <param name="FormText"></param>
        public FrmMZPatFeeQuery(int EmployeeId, string FormText)
        {
            InitializeComponent( );

            this.Text = FormText;
            this.FormTitle = FormText;

            employeeId = EmployeeId;
        }

        private void FrmPatientFeeReport_Load( object sender , EventArgs e )
        {
            
            dtpFrom.Value = Convert.ToDateTime( DateTime.Now.ToString( "yyyy-MM-dd" ) + " 00:00:00" );
            dtpEnd.Value = Convert.ToDateTime( DateTime.Now.ToString( "yyyy-MM-dd" ) + " 23:59:59" );
        }

        private void btnStat_Click( object sender , EventArgs e )
        {
            SetControlEnable( false );
            DateTime beginDate;
            DateTime endDate;
            BaseReport report = null;
            string accountIdList;
            string patTypeCode = "";
            StatDateType dateType = StatDateType.自然时间;
            OPDBillKind invoiceType = OPDBillKind.所有发票;
            #region 统计条件
            #endregion
            if (chkIsUseTime.Checked)
            {
                ReportController.GetReportBeginDateAndEndDate(dateType, 0, dtpFrom.Value, dtpEnd.Value, out beginDate, out endDate, out accountIdList);
            }
            else
            {
                ReportController.GetReportBeginDateAndEndDate(dateType, 0, new DateTime(1, 1, 1), new DateTime(9999, 12, 30),
                    out beginDate, out endDate, out accountIdList);
            }
            lblDate.Text = beginDate.ToString( "yyyy-MM-dd HH:mm:ss" ) + "--" + endDate.ToString( "yyyy-MM-dd HH:mm:ss" );
            try
            {
                report = new PatientFeeReport( );
                ((PatientFeeReport)report).PatName = txtPatName.Text;
                ((PatientFeeReport)report).VisitNo = txtVisitNo.Text;
                report.BeginDate = beginDate;
                report.EndDate = endDate;
                ( (PatientFeeReport)report ).PatientTypeCode = patTypeCode;
                ( (PatientFeeReport)report ).InvoiceType = invoiceType;
                report.StatDateType = dateType;
                report.AccountIdList = accountIdList;
                report.ReportTitle = "门诊病人费用统计表";
                report.Lister = PublicDataReader.GetEmployeeNameById( employeeId );  
                ReportController.FillReport( report );
                dgvReport.DataSource = report.DataResult;
                dgvReport.Tag = report;
                for ( int i = 0 ; i < dgvReport.Columns.Count ; i++ )
                {
                    if ( i >= 3 )
                    {
                        dgvReport.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvReport.Columns[i].Width = 80;
                    }
                    if ( i < 4 )
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

        void SetControlEnable(bool enable)
        {
            dtpFrom.Enabled = enable;
            dtpEnd.Enabled = enable;
            btnClose.Enabled = enable;
            btnStat.Enabled = enable;
        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.Close( );
        }

        private void dgvReport_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvReport.CurrentCell != null)
                {
                    int rowIndex = dgvReport.CurrentCell.RowIndex;
                    if (rowIndex >= 0)
                    {
                        string visitno = dgvReport[0, rowIndex].Value.ToString();
                        dgrdFeeOrder.AutoGenerateColumns = false;
                        dgrdFeeOrder.DataSource = MZ_Loader.GetPatPresOrder(visitno);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void chkIsUseTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsUseTime.Checked)
            {
                dtpFrom.Enabled = true;
                dtpEnd.Enabled = true;
            }
            else
            {
                dtpFrom.Enabled = false;
                dtpEnd.Enabled = false;
            }
        }

    }
}
