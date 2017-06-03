using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS_MZDocManager
{
    public partial class FrmHisPreQuery : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private bool _isSkinTestProcess = false;
        public FrmHisPreQuery(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            this.Text = chineseName;
            this.FormTitle = chineseName;
        }

        public FrmHisPreQuery(long currentUserId, long currentDeptId, string chineseName, bool IsSkinTestProcess)
        {
            InitializeComponent();
            this.Text = chineseName;
            this.FormTitle = chineseName;

            _isSkinTestProcess = true;
            this.dGVEMain.ContextMenuStrip = this.ctMnuSSkinTest;
        }

        /// <summary>
        /// 设置网格单元格颜色
        /// </summary>
        /// <param name="rowid"></param>
        protected void SetCellColor(int rowid, DataRow row)
        {
            HIS.MZDoc_BLL.Public.PresStatus status = (HIS.MZDoc_BLL.Public.PresStatus)row["Status"];
            Color foreColor = HIS.MZDoc_BLL.Public.Function.GetPresForeColor(status);
            Color backColor = HIS.MZDoc_BLL.Public.Function.GetPresBackColor( Convert.ToInt32(row["Item_Id"]),status); 

            foreach (DataGridViewCell cell in this.dGVEMain.Rows[rowid].Cells)
            {
                cell.Style.ForeColor = foreColor;
                cell.Style.BackColor = backColor;
            }
        }

        /// <summary>
        /// 设置处方网格颜色
        /// </summary>
        /// <param name="tablePre"></param>
        private void SetPresGridViewColor(DataTable tablePre)
        {
            if (tablePre != null)
            {
                for (int index = 0; index < tablePre.Rows.Count; index++)
                {
                    SetCellColor(index, tablePre.Rows[index]);
                }
            }
        }

        /// <summary>
        /// 获取病人信息查询条件
        /// </summary>
        /// <returns></returns>
        private HIS.MZDoc_BLL.Public.PatientSearchInfo GetPatientSearchInfo()
        {
            HIS.MZDoc_BLL.Public.PatientSearchInfo patientSearchInfo;
            patientSearchInfo.CardNo = this.txtCardNo.Text.Trim();
            patientSearchInfo.VisitNo = this.txtVisitNo.Text.Trim();
            patientSearchInfo.PatName = this.txtName.Text.Trim();
            patientSearchInfo.Diagnosis = this.txtDiagnosis.Text.Trim();
            patientSearchInfo.DeptId = Convert.ToInt32(this.qTxtDept.Text.Trim() == "" ? "-1" : XcConvert.IsNull(this.qTxtDept.Tag, "-1"));
            patientSearchInfo.DocId = Convert.ToInt32(this.qTxtDoc.Text.Trim() == "" ? "-1" : XcConvert.IsNull(this.qTxtDoc.Tag, "-1"));
            patientSearchInfo.BeginTime = this.dTPkBegin.Value;
            patientSearchInfo.EndTime = this.dTPkEnd.Value;
            return patientSearchInfo;
        }

        //初始化
        private void FrmHisPreQuery_Load(object sender, EventArgs e)
        {
            this.qTxtDept.SetSelectionCardDataSource(HIS.MZDoc_BLL.OP_ReadBaseData.GetMZDeptData());
            this.qTxtDoc.SetSelectionCardDataSource(HIS.MZDoc_BLL.OP_ReadBaseData.GetDoctorData());
        }
        //检索科室
        private void qTxtDept_AfterSelectedRow(object sender, object SelectedValue)
        {
            this.qTxtDept.Text = (SelectedValue == null ? "" : ((DataRow)SelectedValue)["Name"].ToString());
            this.qTxtDept.Tag = (SelectedValue == null ? "-1" : ((DataRow)SelectedValue)["Dept_Id"].ToString());
        }
        //检索医生
        private void qTxtDoc_AfterSelectedRow(object sender, object SelectedValue)
        {
                this.qTxtDoc.Text =( SelectedValue == null ? "" : ((DataRow)SelectedValue)["Name"].ToString());
                this.qTxtDoc.Tag = (SelectedValue == null ? "-1" : ((DataRow)SelectedValue)["Employee_Id"].ToString());
        }
        //查询病人
        private void btQuery_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dGVEResult.AutoGenerateColumns = false;
            dGVEResult.DataSource = HIS.MZDoc_BLL.OP_Patient.SearchPatList(GetPatientSearchInfo());
            this.Cursor = Cursors.Default;
        }
        //查询处方
        private void dGVEResult_CurrentCellChanged(object sender, EventArgs e)
        {
            DataTable table = (DataTable)dGVEResult.DataSource;
            if (table != null && dGVEResult.CurrentCell != null && table.Rows.Count > dGVEResult.CurrentCell.RowIndex)
            {
                this.Cursor = Cursors.WaitCursor;
                HIS.MZDoc_BLL.Patient patient = new HIS.MZDoc_BLL.Patient((HIS.Model.MZ_PatList)HIS.MZDoc_BLL.Public.Function.DataRowToObject<HIS.Model.MZ_PatList>(table.Rows[dGVEResult.CurrentCell.RowIndex]));
               dGVEMain.AutoGenerateColumns = false;

                DataTable tablePre = _isSkinTestProcess ? patient.GetSkinTestPres() : patient.GetPrescription(Convert.ToInt64(table.Rows[dGVEResult.CurrentCell.RowIndex]["PRES_DOC"]));
                this.dGVEMain.DataSource = tablePre;
                SetPresGridViewColor(tablePre);
                this.Cursor = Cursors.Default;
            }
        }
        //退出
        private void btQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tSMnISkinTest_Click(object sender, EventArgs e)
        {
            DataTable table = (DataTable)dGVEMain.DataSource;
            if (table != null && dGVEMain.CurrentCell != null && table.Rows.Count > dGVEMain.CurrentCell.RowIndex)
            {
                HIS.MZDoc_BLL.Prescription prescription = (HIS.MZDoc_BLL.Prescription)HIS.MZDoc_BLL.Public.Function.DataRowToObject<HIS.MZDoc_BLL.Prescription>(table.Rows[dGVEMain.CurrentCell.RowIndex]);
                if (HIS.MZDoc_BLL.OP_Prescription.SkinTestPresProcess(prescription.PresListId, Convert.ToInt32(XcConvert.IsNull(((ToolStripMenuItem)sender).Tag, "0"))))
                {
                    dGVEResult_CurrentCellChanged(null,null);
                }
            }
        }
    }
}
