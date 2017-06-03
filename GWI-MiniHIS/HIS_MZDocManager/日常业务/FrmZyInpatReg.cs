using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using HIS.SYSTEM.PubicBaseClasses;
using GWMHIS.BussinessLogicLayer.Classes;
using grproLib;

namespace HIS_MZDocManager
{
    public partial class FrmZyInpatReg : Form
    {
        private HIS.MZDoc_BLL.Patient _patient;
        private User _user;
        private Deptment _deptment;
        private HIS.MZDoc_BLL.ZyInpatRegist _zyInpatRegist;

        public FrmZyInpatReg(HIS.MZDoc_BLL.Patient patient, User user,Deptment deptment)
        {
            InitializeComponent();
            this._patient = patient;
            this._user = user;
            this._deptment = deptment;
        }

        private bool CheckInpatRegInfo()
        {
            if (this.西医诊断.Text.Trim() == "" && this.中医诊断.Text.Trim() == "")
            {
                MessageBox.Show("病人入院初步诊断不能为空！", "提示");
                return false;
            }
            if (this.入院科室.Text.Trim() == "" || this.入院科室ID.Text.Trim() == "")
            {
                MessageBox.Show("病人入院科室不能为空！", "提示");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 显示病人基本信息
        /// </summary>
        private void InitPatInfo()
        {
            this.病人类型.DataSource = HIS.MZDoc_BLL.OP_ReadBaseData.GetPatientTypeData();
            this.病人类型.DisplayMember = "NAME";
            this.病人类型.ValueMember = "CODE";
            this.病人类型.SelectedValue = "01";

            this.姓名.Text = _patient.PatList.PatName;
            this.性别.Text = _patient.PatList.PatSex;
            this.年龄.Text = _patient.PatList.Age.ToString() + _patient.PatList.HpGrade;
            this.病人类型.Text = _patient.FeeTypeName;
            this.职业.Text = _patient.PatientInfo.PATJOB;
            this.单位名称.Text =HIS.MZDoc_BLL.OP_ReadBaseData.GetWorkUnitName(_patient.PatList.HpCode);
            this.签证医生.Text = _user.Name;
            this.签证医生ID.Text = _user.EmployeeID.ToString();
            this.签证科室.Text = _deptment.Name;
            this.签证科室ID.Text = _deptment.DeptID.ToString();
            this.签证时间.Text = XcDate.ServerDateTime.ToLongDateString() + " " + XcDate.ServerDateTime.ToLongTimeString();
        }

        /// <summary>
        /// 显示住院证信息
        /// </summary>
        private void InitInpatRegistInfo()
        {
            _zyInpatRegist = new HIS.MZDoc_BLL.ZyInpatRegist(_patient.PatList.PatListID);
            if (_zyInpatRegist.Reg_Content != null && _zyInpatRegist.Reg_Content != "")
            {
                XmlOperate.DeComposeXmlText(_zyInpatRegist.Reg_Content, "ZyInpatRegContent", this);
            }
        }

        private void FrmZyInpatReg_Load(object sender, EventArgs e)
        {
            InitInpatRegistInfo();
            InitPatInfo();
            this.qTBDiagnosisZ.SetSelectionCardDataSource(HIS.MZDoc_BLL.OP_ReadBaseData.GetEastDiagnosisData());
            this.qTBDiagnosisX.SetSelectionCardDataSource(HIS.MZDoc_BLL.OP_ReadBaseData.GetWastDiagnosisData());
            this.qTBDept.SetSelectionCardDataSource(HIS.MZDoc_BLL.OP_ReadBaseData.GetZYDeptData());
        }

        private void btQuery_Click(object sender, EventArgs e)
        {
            FrmWardBedQuery frmWardBedQuery = new FrmWardBedQuery(-1, -1, "床位情况查询");
            frmWardBedQuery.ShowDialog();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (CheckInpatRegInfo())
            {
                _zyInpatRegist.PatId = (int)_patient.PatList.PatID;
                _zyInpatRegist.PatListId = _patient.PatList.PatListID;
                _zyInpatRegist.Reg_Content = XmlOperate.ComposeXmlText("ZyInpatRegContent", this);
                _zyInpatRegist.Reg_Emp = (int)_user.EmployeeID;
                _zyInpatRegist.Reg_Date = XcDate.ServerDateTime;
                _zyInpatRegist.Save();
                MessageBox.Show("保存成功！", "提示");
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            if (CheckInpatRegInfo())
            {
                GridppReport report = new GridppReport();
                report.LoadFromFile(Constant.ApplicationDirectory + "\\report\\门诊医生住院证.grf");

                XmlOperate.PrintXmlText(XmlOperate.ComposeXmlText("ZyInpatRegContent", this), "ZyInpatRegContent", report);
                report.ParameterByName("编号").AsString = _zyInpatRegist.RegId.ToString();

                report.PrintPreview(false);
            }
        }

        private void btQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void qTBDiagnosisZ_AfterSelectedRow(object sender, object SelectedValue)
        {
            this.中医诊断.Text = this.中医诊断.Text 
                + (this.中医诊断.Text.Trim() == "" ? "" : ",") 
                + (SelectedValue == null ? "" : ((DataRow)SelectedValue)["Name"].ToString());
            this.qTBDiagnosisZ.Text = "";
        }

        private void qTBDiagnosisX_AfterSelectedRow(object sender, object SelectedValue)
        {
            this.西医诊断.Text = this.西医诊断.Text
                + (this.西医诊断.Text.Trim() == "" ? "" : ",")
                + (SelectedValue == null ? "" : ((DataRow)SelectedValue)["Name"].ToString());
            this.qTBDiagnosisX.Text = "";
        }

        private void qTBDept_AfterSelectedRow(object sender, object SelectedValue)
        {
            if (SelectedValue != null)
            {
                this.qTBDept.Text = ((DataRow)SelectedValue)["Name"].ToString();
                this.入院科室.Text = ((DataRow)SelectedValue)["Name"].ToString();
                this.入院科室ID.Text = ((DataRow)SelectedValue)["Dept_ID"].ToString();
                this.qTBDept.Visible = false;
            }
        }

        private void 入院科室_Enter(object sender, EventArgs e)
        {
            this.qTBDept.Visible = true;
            this.qTBDept.Focus();
        }

        private void txtZyInpatInfor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{Tab}");
        }

        private void 联系电话_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                qTBDiagnosisZ.Focus();
        }

        private void qTBDiagnosisX_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                入院科室.Focus();
        }

        private void 注意事项_KeyUp(object sender, KeyEventArgs e)
        {
            this.btSave.Focus();
        }

        private void btFormerlyInfo_Click(object sender, EventArgs e)
        {
            string[] headerText = { "住院号", "姓名", "性别", "出生日期", "民族", "电话", "地址", "费用类型" };
            string[] name = { "CureNo", "PatName", "PatSex", "PatBriDate", "PatGroup", "PatTel", "PatAddress", "AccountType" };
            int[] width = { 80, 80, 50, 100, 60, 80, 150, 80 };
            int index = 0;
            DataGridViewColumn[] columns = new DataGridViewColumn[8];
            while (index < 8)
            {
                columns[index] = new DataGridViewTextBoxColumn();
                columns[index].HeaderText = headerText[index];
                columns[index].DataPropertyName = name[index];
                columns[index].Width = width[index];
                columns[index].Name = name[index];
                columns[index].ReadOnly = true;
                columns[index].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
                index++;
            }
            FrmQueryShow form = new FrmQueryShow("历史住院情况列表", HIS.MZDoc_BLL.OP_ReportQuery.GetFormerlyInpatInfo(this.姓名.Text.Trim()), columns);
            form.RecordRowSelected += new EventHandler(QueryShowForm_RecordRowSelected);
            form.ShowDialog();
        }

        public void QueryShowForm_RecordRowSelected(object sender, EventArgs e)
        {
            if (sender != null)
            {
                this.住院号.Text = ((DataRow)sender)["CureNo"].ToString();
            }
        }
    }
}
