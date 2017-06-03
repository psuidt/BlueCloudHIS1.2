using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GWMHIS.BussinessLogicLayer.Forms;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.SYSTEM.BussinessLogicLayer.Classes;
using grproLib;
using System.IO;


namespace HIS_ZYManager
{
    public partial class FrmPatientRpt : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private User _currentUser;
        private Deptment _currentDept;
        HIS.ZY_BLL.PatType patType = HIS.ZY_BLL.PatType.在院病人;
        private DataTable Pat_dt = null;
        grproLib.GridppReport Report = null;

        public FrmPatientRpt(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();

            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            this.Text = chineseName;
            this.cb_pattype.SelectedIndex = 0;
            this.cB_dept.Enabled = false;
            this.cB_style.SelectedIndex = 0;
            this.cB_type.SelectedIndex = 0;
            DataTable dt = BaseData.GetDeptData(BaseData.DeptType.住院,BaseData.DeptType2.临床);
            this.cB_dept.DataSource = dt;
            this.cB_dept.DisplayMember = "name";
        }

        private void cb_pattype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_pattype.SelectedIndex == 0)
            {
                this.dtp_Bdate.Enabled = false;
                this.dtp_Edate.Enabled = false;
                patType = HIS.ZY_BLL.PatType.在院病人;
                this.checkBox1.Checked = false;
            }
            else
            {
                this.dtp_Bdate.Enabled = true;
                this.dtp_Edate.Enabled = true;
                patType = HIS.ZY_BLL.PatType.出院病人;
                this.checkBox1.Checked = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.cB_dept.Enabled = true;
            }
            else
            {
                this.cB_dept.Enabled = false;
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void FrmPatientRpt_Load(object sender, EventArgs e)
        {
            //this.BindData();
            DataSet_Rpt dsr = new DataSet_Rpt();
            HIS.ZY_BLL.CostItemStyle cis = this.cB_style.SelectedIndex == 0 ? HIS.ZY_BLL.CostItemStyle.记账日期 : HIS.ZY_BLL.CostItemStyle.结帐日期;
            HIS.ZY_BLL.CostItemType cit = this.cB_type.SelectedIndex == 0 ? HIS.ZY_BLL.CostItemType.发票项目 : HIS.ZY_BLL.CostItemType.核算项目;
            dsr.PatCostTotal_Rpt_AddCol(cit);

            //dsr.BindDeptItemData(this.dtp_Bdate.Value, this.dtp_Edate.Value, cis, cit);
            Pat_dt = (DataTable)dsr.PatCostTotal_Rpt;
            this.dgv_Fee.DataSource = Pat_dt;
            this.dgv_Fee.Columns[0].Frozen = true;
            this.dgv_Fee.Columns[1].Frozen = true;
            this.dgv_Fee.Columns[2].Frozen = true;
            this.dgv_Fee.Columns[3].Frozen = true;
            this.dgv_Fee.Columns[1].Visible = false;

            for (int i = 3; i < dgv_Fee.Columns.Count; i++)
            {
                dgv_Fee.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void BindData()
        {
            DataSet_Rpt dsr = new DataSet_Rpt();
            HIS.ZY_BLL.CostItemStyle cis = this.cB_style.SelectedIndex == 0 ? HIS.ZY_BLL.CostItemStyle.记账日期 : HIS.ZY_BLL.CostItemStyle.结帐日期;
            HIS.ZY_BLL.CostItemType cit = this.cB_type.SelectedIndex == 0 ? HIS.ZY_BLL.CostItemType.发票项目 : HIS.ZY_BLL.CostItemType.核算项目;
            dsr.PatCostTotal_Rpt_AddCol(cit);
            bool IsIn = this.cb_pattype.SelectedIndex == 0 ? true : false;
            string DeptCode = null;
            if (this.checkBox1.Checked)
            {
                DeptCode = ((DataRowView)this.cB_dept.SelectedValue).Row["code"].ToString().Trim();
            }
            DateTime? Bdate = null;
            DateTime? Edate = null;
            if (!IsIn)
            {
                Bdate = this.dtp_Bdate.Value;
                Edate = this.dtp_Edate.Value;
            }
            dsr.BindPatItemData(IsIn,DeptCode,Bdate, Edate, cis, cit);
            Pat_dt = (DataTable)dsr.PatCostTotal_Rpt;
            this.dgv_Fee.DataSource = Pat_dt;
            this.dgv_Fee.Columns[0].Frozen = true;
            this.dgv_Fee.Columns[1].Frozen = true;
            this.dgv_Fee.Columns[2].Frozen = true;
            this.dgv_Fee.Columns[3].Frozen = true;
            this.dgv_Fee.Columns[1].Visible = false;
            for (int i = 3; i < dgv_Fee.Columns.Count; i++)
            {
                dgv_Fee.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        /// <summary>
        /// 创建报表文件
        /// </summary>
        /// <param name="ReportName">报表名</param>
        /// <param name="Columns">列信息</param>
        /// <returns></returns>
        private bool CreateReportFile(string ReportName, DataTable Columns)
        {
            try
            {
                GridppReport gridReport = new GridppReport();
                DataTable dtColumns = Columns;
                string reportName = ReportName;
                string fileName = System.Windows.Forms.Application.StartupPath + "\\report\\" + reportName + ".grf";
                if (System.IO.File.Exists(fileName))
                {
                    if (MessageBox.Show("该报表已经存在是否重新设置？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        System.IO.File.Delete(fileName);
                    }
                    else
                    {
                        return false;
                    }
                }
                if (!Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\report"))
                {
                    Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\report");
                }
                if (!File.Exists(fileName))
                {
                    gridReport.SaveToFile(fileName);
                    gridReport.InsertReportHeader();
                    gridReport.InsertDetailGrid();
                    gridReport.InsertReportFooter();
                    foreach (DataColumn dc in dtColumns.Columns)
                    {
                        string title_name = dc.ColumnName;
                        gridReport.DetailGrid.AddColumn(title_name, title_name, title_name, 2);
                        gridReport.DetailGrid.Recordset.AddField(title_name, GRFieldType.grftString);
                    }
                    gridReport.AddParameter("医院名称", GRParameterDataType.grptString);
                    gridReport.AddParameter("报表标题", GRParameterDataType.grptString);
                    gridReport.AddParameter("统计时间", GRParameterDataType.grptString);
                    gridReport.AddParameter("制表人", GRParameterDataType.grptString);
                    gridReport.AddParameter("备注", GRParameterDataType.grptString);

                    gridReport.SaveToFile(fileName);

                }
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }
        private void Report_FetchRecord(ref bool Eof)
        {
            GWI_DesReport.HisReport.FillRecordToReport(Report, Pat_dt);
        }
        private void Print(bool IsPrint, string ReportName)
        {
            Report = new grproLib.GridppReport();
            Report.LoadFromFile(Constant.ApplicationDirectory + "\\report\\" + ReportName + ".grf");
            Report.ParameterByName("制表人").AsString = _currentUser.Name;
            Report.ParameterByName("医院名称").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
            Report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(Report_FetchRecord);
            if (IsPrint)
            {
                Report.Print(false);
            }
            else
            {
                Report.PrintPreview(false);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (this.cB_type.SelectedIndex == 0)
            {
                if (CreateReportFile("住院病人费用统计[发票项目]", Pat_dt))
                {
                    MessageBox.Show("设置完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (CreateReportFile("住院病人费用统计[核算项目]", Pat_dt))
                {
                    MessageBox.Show("设置完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (this.cB_type.SelectedIndex == 0)
            {
                Print(false, "住院病人费用统计[发票项目]");
            }
            else
            {
                Print(false, "住院病人费用统计[核算项目]");
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (this.cB_type.SelectedIndex == 0)
            {
                Print(true, "住院病人费用统计[发票项目]");
            }
            else
            {
                Print(true, "住院病人费用统计[核算项目]");
            }
        }


    }
}
