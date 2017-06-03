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
using _HIS = HIS.SYSTEM.PubicBaseClasses;
using grproLib;
using System.IO;
using HIS.ZY_BLL.DataModel;

namespace HIS_ZYManager
{
    public partial class FrmDeptRpt : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private User _currentUser;
        private Deptment _currentDept;
        private FilterType _filterType;			//选项卡条件过滤类别
        private SearchType _searchType;
        public ZY_PatList zy_PatList = null;
        private DataTable Dept_dt = null;
        grproLib.GridppReport Report = null;

        private int _type = 0;
        //统计项
        public int type
        {
            set
            {
                _type = value;
                if (_type == 0)
                {
                    this.Text = "住院执行科室统计";
                    this.FormTitle = "住院执行科室统计";
                }
                else if (_type == 1)
                {
                    this.Text = "住院执行医生统计";
                    this.FormTitle = "住院执行医生统计";
                }
                else if (_type == 2)
                {
                    this.Text = "住院开方科室统计";
                    this.FormTitle = "住院开方科室统计";
                }
                else if (_type == 3)
                {
                    this.Text = "住院开方医生统计";
                    this.FormTitle = "住院开方医生统计";
                }
            }
            get
            {
                return _type;
            }
        }

        public FrmDeptRpt(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            _filterType = Constant.CustomFilterType;
            _searchType = Constant.CustomSearchType;
            this.Text = chineseName;
        }
        //关闭
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDeptRpt_Load(object sender, EventArgs e)
        {
            this.cB_style.SelectedIndex = 0;
            this.cB_type.SelectedIndex = 0;
            this.cbPerson.SelectedIndex = type;
            //this.BindData();
            DataSet_Rpt dsr = new DataSet_Rpt();
            HIS.ZY_BLL.CostItemStyle cis = this.cB_style.SelectedIndex == 0 ? HIS.ZY_BLL.CostItemStyle.记账日期 : HIS.ZY_BLL.CostItemStyle.结帐日期;
            HIS.ZY_BLL.CostItemType cit = this.cB_type.SelectedIndex == 0 ? HIS.ZY_BLL.CostItemType.发票项目 : HIS.ZY_BLL.CostItemType.核算项目;
            dsr.DeptCostTotal_Rpt_AddCol(cit);

            //dsr.BindDeptItemData(this.dtp_Bdate.Value, this.dtp_Edate.Value, cis, cit);
            Dept_dt = (DataTable)dsr.DeptCostTotal_Rpt;
            this.dgv_Fee.DataSource = Dept_dt;
            this.dgv_Fee.Columns[0].Frozen = true;
            this.dgv_Fee.Columns[1].Frozen = true;
            this.dgv_Fee.Columns[2].Frozen = true;
            for (int i = 2; i < dgv_Fee.Columns.Count; i++)
            {
                dgv_Fee.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (type == 2)
                this.dgv_Fee.Columns[0].Visible = false;
        }

        private void BindData()
        {
            DataSet_Rpt dsr = new DataSet_Rpt();
            HIS.ZY_BLL.CostItemStyle cis = this.cB_style.SelectedIndex == 0 ? HIS.ZY_BLL.CostItemStyle.记账日期 : HIS.ZY_BLL.CostItemStyle.结帐日期;

            HIS.ZY_BLL.CostItemType cit = HIS.ZY_BLL.CostItemType.发票项目;
            if (this.cB_type.SelectedIndex == 0)
            {
                cit = HIS.ZY_BLL.CostItemType.发票项目;
            }
            else if (this.cB_type.SelectedIndex == 1)
            {
                cit = HIS.ZY_BLL.CostItemType.核算项目;
            }
            else if (this.cB_type.SelectedIndex == 2)
            {
                cit = HIS.ZY_BLL.CostItemType.会计项目;
            }
            //if(cit)
            dsr.DeptCostTotal_Rpt_AddCol(cit);

            dsr.BindDeptItemData(type,this.dtp_Bdate.Value, this.dtp_Edate.Value, cis, cit);
            Dept_dt = (DataTable)dsr.DeptCostTotal_Rpt;

            this.dgv_Fee.DataSource = Dept_dt;
            this.dgv_Fee.Columns[0].Frozen = true;
            this.dgv_Fee.Columns[1].Frozen = true;
            this.dgv_Fee.Columns[2].Frozen = true;
            for (int i = 2; i < dgv_Fee.Columns.Count; i++)
            {
                dgv_Fee.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (type == 2)
                this.dgv_Fee.Columns[0].Visible = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            BindData();
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
            GWI_DesReport.HisReport.FillRecordToReport(Report, Dept_dt);
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
        //设置
        private void toolStripButton4_Click(object sender, EventArgs e)
        {

            if (this.cB_type.SelectedIndex == 0)
            {
                if (CreateReportFile("住院收入统计[发票项目]", Dept_dt))
                {
                    MessageBox.Show("设置完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (this.cB_type.SelectedIndex == 1)
            {
                if (CreateReportFile("住院收入统计[核算项目]", Dept_dt))
                {
                    MessageBox.Show("设置完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (CreateReportFile("住院收入统计[会计项目]", Dept_dt))
                {
                    MessageBox.Show("设置完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }


        }
        //预览
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (this.cB_type.SelectedIndex == 0)
            {
                Print(false, "住院收入统计[发票项目]");
            }
            else if (this.cB_type.SelectedIndex == 1)
            {
                Print(false, "住院收入统计[核算项目]");
            }
            else
            {
                Print(false, "住院收入统计[会计项目]");
            }
        }
        //打印
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (this.cB_type.SelectedIndex == 0)
            {
                Print(true, "住院收入统计[发票项目]");
            }
            else if (this.cB_type.SelectedIndex == 1)
            {
                Print(true, "住院收入统计[核算项目]");
            }
            else
            {
                Print(true, "住院收入统计[会计项目]");
            }
        }

        private void cbPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.type = this.cbPerson.SelectedIndex;
        }
 
    }
}
