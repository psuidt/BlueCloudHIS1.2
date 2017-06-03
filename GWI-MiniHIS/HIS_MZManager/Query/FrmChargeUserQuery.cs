using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HIS.MZ_BLL;
using HIS.MZ_BLL.Report;
using HIS.MZ_BLL.Exceptions;
using System.Collections;

namespace HIS_MZManager.Query
{
    public partial class FrmChargeUserQuery : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private int currentEmployeeId;
        public FrmChargeUserQuery(int CurrentEmployeeId, string FormText)
        {
            InitializeComponent();
            currentEmployeeId = CurrentEmployeeId;
            foreach (object obj in Enum.GetValues(typeof(StatClassType)))
                cboStatType.Items.Add(obj.ToString());
            cboStatType.Items.Remove("收费支付类型");
            cboStatType.Text = StatClassType.门诊发票分类.ToString();

            foreach (object obj in Enum.GetValues(typeof(ReportStyle)))
                cboStyle.Items.Add(obj.ToString());
            cboStyle.Text = ReportStyle.科目为标题列.ToString();
            dtpFrom.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00");
            dtpEnd.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
        }

        private void btnStat_Click(object sender, EventArgs e)
        {

            DateTime beginDate;
            DateTime endDate;
            BaseReport report = null;
            string accountIdList;
          
            StatDateType dateType = StatDateType.自定义时间;
            StatClassType statType = StatClassType.门诊发票分类;
            ReportStyle style = ReportStyle.科目为标题列;
            foreach (object obj in Enum.GetValues(typeof(StatClassType)))
            {
                if (obj.ToString() == cboStatType.Text)
                {
                    statType = (StatClassType)obj;
                    break;
                }
            }
            foreach (object obj in Enum.GetValues(typeof(ReportStyle)))
            {
                if (obj.ToString() == cboStyle.Text)
                {
                    style = (ReportStyle)obj;
                    break;
                }
            }
            StatObjctType statObjectType = StatObjctType.收费员;                  
            try
            {
                Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();              
                ReportController.GetReportBeginDateAndEndDate(dateType, 15, dtpFrom.Value, dtpEnd.Value, out beginDate, out endDate, out accountIdList);  
                report = new TollerIncomeReport();
                report.BeginDate = dtpFrom.Value;
                report.EndDate = dtpEnd.Value;
             
                report.StatType = statType;
                report.Reportstyle = style;
                report.StatDateType = dateType;
               // report.AccountIdList = accountIdList;
                report.StatObjectType = statObjectType;
                report.ReportTitle = "门诊收费员工作量统计报表";
               
                report.Lister = BaseDataController.GetName(BaseDataCatalog.人员列表, currentEmployeeId);
                ReportController.FillReport(report,dtpFrom.Value,dtpEnd.Value);
                dgvReport.DataSource = report.DataResult;
                dgvReport.Tag = report;

                for (int i = 1; i < dgvReport.Columns.Count; i++)
                {
                    dgvReport.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvReport.Columns[i].Width = 80;
                }
                dgvReport.Columns[0].Frozen = true;
                dgvReport.Columns[1].Frozen = true;
            }
            catch (OperatorException oe)
            {
                MessageBox.Show(oe.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception err)
            {
                ErrorWriter.WriteLog(err.Message);
                MessageBox.Show("统计报表中发生错误！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
              
                Cursor = Cursors.Default;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvReport.Tag == null)
            {
                MessageBox.Show("没有数据可打印，请先统计", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PrintReport((BaseReport)dgvReport.Tag, chkPreview.Checked);
        }

        private void PrintReport(BaseReport Report, bool preview)
        {
            try
            {
                PrintController.PrintChargerReport(Report, preview);
            }
            catch (Exception err)
            {
                ErrorWriter.WriteLog(err.Message);
                MessageBox.Show("预览/打印发生错误！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }     
    }
}
