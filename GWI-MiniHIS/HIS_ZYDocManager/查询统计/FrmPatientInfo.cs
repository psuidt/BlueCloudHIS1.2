using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS_ZYDocManager.查询统计
{
    public partial class FrmPatientInfo : GWI.HIS.Windows.Controls.BaseMainForm
    {
        public FrmPatientInfo()
        {
            InitializeComponent();
        }
        private User _currentUser;  //当前用户
        private Deptment _currentDept;  //当前科室
        DateTime bdate = new DateTime();
        DateTime edate = new DateTime();

        public FrmPatientInfo(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);            
            this.cbType.Text = "发票项目";
            radIn.Checked = true;
            dtpBdate.Enabled = false;
            dtPEnd.Enabled = false;
            DataTable dt = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserData(HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.EmpType.医生);
            this.cbDocName.DataSource = dt;
            this.cbDocName.DisplayMember = "NAME";
            this.cbDocName.ValueMember = "CODE";
            this.cbDocName.Text = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(_currentUser.EmployeeID.ToString());
            this.cbDocName.SelectedValue = _currentUser.EmployeeID;
        }

        private void BtnResult_Click(object sender, EventArgs e)
        {

            bdate = this.dtpBdate.Value;
            edate = this.dtPEnd.Value;
            string itemtype = this.cbType.Text;
            DataTable dt = new DataTable();
            if (radOut.Checked)
            {
                dt = HIS.ZYDoc_BLL.QueryWork.OP_Rpt.FeeReport(Convert.ToInt32(this.cbDocName.SelectedValue), bdate, edate, itemtype);
            }
            else
            {
                dt = HIS.ZYDoc_BLL.QueryWork.OP_Rpt.FeeReport(Convert.ToInt32(this.cbDocName.SelectedValue), null, null, itemtype);
            }
          this.dtgResult.DataSource = dt;
          for (int i = 0; i < 5; i++)
          {
             this.dtgResult.Columns[i].Frozen = true;
          }
        }

        private void radIn_CheckedChanged(object sender, EventArgs e)
        {
            if (radIn.Checked)
            {
                dtpBdate.Enabled = false;
                dtPEnd.Enabled = false;
            }
            else
            {
                dtpBdate.Enabled = true;
                dtPEnd.Enabled = true;
            }
        }     
        
    }
}
