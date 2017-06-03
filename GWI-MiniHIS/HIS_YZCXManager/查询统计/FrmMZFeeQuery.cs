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
    public partial class FrmMZFeeQuery : BaseMainForm
    {
        private int currentEmployeeId;
        /// <summary>
        /// 设置按钮可用状态
        /// </summary>
        /// <param name="enable"></param>
        private void SetButtonEnable( bool enable )
        {
            btnStat.Enabled = enable;
            btnClose.Enabled = enable;
        }

        public FrmMZFeeQuery(int CurrentEmployeeId,string FormText)
        {
            InitializeComponent( );

            this.FormTitle = FormText;
            this.Text = FormText;

            currentEmployeeId = CurrentEmployeeId;
        }

        private void FrmReport_Load( object sender , EventArgs e )
        {

            foreach ( object obj in Enum.GetValues( typeof( StatClassType ) ) )
                cboStatType.Items.Add( obj.ToString( ) );
            cboStatType.Text = StatClassType.门诊发票分类.ToString( );

            foreach ( object obj in Enum.GetValues( typeof( StatObjctType ) ) )
                cboType.Items.Add( obj.ToString( ) );
            cboType.Text = StatObjctType.医生.ToString( );
            

            dtpFrom.Value = Convert.ToDateTime( DateTime.Now.ToString( "yyyy-MM-dd" ) + " 00:00:00" );
            dtpEnd.Value = Convert.ToDateTime( DateTime.Now.ToString( "yyyy-MM-dd" ) + " 23:59:59" );

            ReportController.OnReportProcessing += new OnReportProcessingHandler( ReportController_OnReportProcessing );
        }

        void ReportController_OnReportProcessing( ReportProcessingEventArgs e )
        {
            lblInfo.Text = e.Status;
            lblInfo.Refresh( );
        }

        private void btnStat_Click( object sender , EventArgs e )
        {
            DateTime beginDate;
            DateTime endDate;
            BaseReport report = null;
            string accountIdList;
            StatDateType dateType = StatDateType.自然时间;
            StatClassType statType = StatClassType.门诊发票分类;
            StatObjctType statObjectType = StatObjctType.医生;
            ReportStyle style = ReportStyle.科目为标题列;
            #region 统计条件            
            foreach ( object obj in Enum.GetValues( typeof( StatClassType ) ) )
            {
                if ( obj.ToString( ) == cboStatType.Text )
                {
                    statType = (StatClassType)obj;
                    break;
                }
            }
            foreach ( object obj in Enum.GetValues( typeof( StatObjctType ) ) )
            {
                if ( obj.ToString( ) == cboType.Text )
                {
                    statObjectType = (StatObjctType)obj;
                    break;
                }
            }
            #endregion
            try
            {
                Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor( );
                SetButtonEnable( false );
                ReportController.GetReportBeginDateAndEndDate( dateType , 0 , dtpFrom.Value , dtpEnd.Value , out beginDate , out endDate , out accountIdList );
                lblDate.Text = beginDate.ToString( "yyyy-MM-dd HH:mm:ss" ) + "  ——  " + endDate.ToString( "yyyy-MM-dd HH:mm:ss" );
                switch ( statObjectType )
                {
                    case StatObjctType.医生:
                        report = new DoctorIncomeReport( );
                        break;
                    case StatObjctType.科室:
                        report = new DepartmentIncomeReport( );
                        break;
                    case StatObjctType.收费员:
                        report = new TollerIncomeReport( );
                        break;
                    case StatObjctType.病人类型:
                        report = new PatientTypeIncomReport( );
                        break;
                }
                report.BeginDate = beginDate;
                report.EndDate = endDate;
                report.StatType = statType;
                report.Reportstyle = style;
                report.StatDateType = dateType;
                report.AccountIdList = accountIdList;
                report.StatObjectType = statObjectType;
                report.ReportTitle = "门诊" + cboType.Text + "收入报表";
                report.Lister = PublicDataReader.GetEmployeeNameById( currentEmployeeId );

                ReportController.FillReport( report );
                dgvReport.DataSource = report.DataResult;
                dgvReport.Tag = report;

                for ( int i = 1 ; i < dgvReport.Columns.Count ; i++ )
                {
                    dgvReport.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvReport.Columns[i].Width = 80;
                }
                dgvReport.Columns[0].Frozen = true;
                dgvReport.Columns[1].Frozen = true;
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
            finally
            {
                SetButtonEnable( true  );
                Cursor = Cursors.Default;
            }
        }

        private void cboDateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpFrom.CustomFormat = "yyyy-MM-dd";
            dtpEnd.CustomFormat = "yyyy-MM-dd";
        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.Close( );
        }

        private void btnPicture_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReport.DataSource != null)
                {
                    DataTable pictureDt = ((DataTable)(this.dgvReport.DataSource)).Copy();
                    pictureDt.Rows.RemoveAt(pictureDt.Rows.Count - 1);
                    TableColumn[] columns = new TableColumn[1];
                    columns[0].ColumnName = "总金额";
                    columns[0].ColumnField = "合计";
                    FrmShowGraphic showGraphic = new FrmShowGraphic(pictureDt, "名称", columns, DataTableStruct.Rows,
                        "门诊收入图示");
                    showGraphic.ShowDialog();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

    }
}
