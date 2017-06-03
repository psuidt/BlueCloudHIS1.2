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


namespace HIS_MediConfirManager
{
    public partial class FrmReport : GWI.HIS.Windows.Controls.BaseMainForm
    {
        int _deptid;
        public FrmReport(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            DataTable dept = HIS.MedicalConfir_BLL.OpRpt.GetMediDept();
            queryDept.SetSelectionCardDataSource(dept);
            queryDept.Text = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(currentDeptId.ToString());
            _deptid = Convert.ToInt32(currentDeptId);
            dgvItems.AutoGenerateColumns = false;
            dgvItems.DataSource = HIS.MedicalConfir_BLL.OpRpt.GetDeptItem(Convert.ToInt32(currentDeptId), dtpBegin.Value, dtpEnd.Value);           
        }

        //查询
        private void button1_Click(object sender, EventArgs e)
        {
            if (queryDept.MemberValue == null)
            {
                queryDept.Text = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(_deptid.ToString());
                dgvItems.DataSource = HIS.MedicalConfir_BLL.OpRpt.GetDeptItem(Convert.ToInt32(_deptid), dtpBegin.Value, dtpEnd.Value);
            }
            else
            {
                dgvItems.DataSource = HIS.MedicalConfir_BLL.OpRpt.GetDeptItem(Convert.ToInt32(this.queryDept.MemberValue.ToString()), dtpBegin.Value, dtpEnd.Value);
            }
            dgvItems.AutoGenerateColumns = false;           
            this.dgvZyFees.DataSource = null;
            this.dgvMzFees.DataSource = null;
        }

        //双击查看明细
        private void dgvItems_DoubleClick(object sender, EventArgs e)
        {
            DataTable dtMz = new DataTable();
            DataTable dtZy = new DataTable();
            int rowindex = dgvItems.CurrentRow.Index;
            HIS.MedicalConfir_BLL.OpRpt.GetDetailFee(dgvItems[0, rowindex].Value.ToString(), out dtMz, out dtZy);
            dgvZyFees.AutoGenerateColumns = false;
            dgvMzFees.AutoGenerateColumns = false;
            this.dgvZyFees.DataSource = dtZy;
            this.dgvMzFees.DataSource = dtMz;
        }
        //选择科室
        private void queryDept_AfterSelectedRow(object sender, object SelectedValue)
        {
            dgvItems.AutoGenerateColumns = false;
            dgvItems.DataSource = HIS.MedicalConfir_BLL.OpRpt.GetDeptItem(Convert.ToInt32(this.queryDept.MemberValue.ToString()), dtpBegin.Value, dtpEnd.Value);
            this.dgvZyFees.DataSource = null;
            this.dgvMzFees.DataSource = null;
        }
    }
}
