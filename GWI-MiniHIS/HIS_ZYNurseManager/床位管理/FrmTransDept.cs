using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_ZYNurseManager
{
    public partial class FrmTransDept : GWI.HIS.Windows.Controls.BaseForm
    {
        private HIS.Model.ZY_PatList patlist;
        private string  deptid;
        public bool IsTrans = false;
        public FrmTransDept(HIS.Model.ZY_PatList _patlist,long _deptid)
        {
            InitializeComponent();
            patlist = _patlist;
            DataTable dtt = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptData(HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.DeptType.住院, HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.DeptType2.临床);
            this.cbDept.DataSource = dtt;
            this.cbDept.DisplayMember = "name";
            this.cbDept.ValueMember = "code";
            deptid = _deptid.ToString();
            InitData();
        }

        private void InitData()
        {
            txtCureNo.Text = patlist.CureNo;
            txtBedCode.Text = patlist.BedCode;
            txtInDept.Text =HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName( patlist.CureDeptCode);
            txtPatName.Text = patlist.PatientInfo.PatName;
            txtDiag.Text = patlist.DiseaseName;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (deptid == this.cbDept.SelectedValue.ToString())
            {
                MessageBox.Show("不允许本科室转本科室！请重新选择科室。");
                return;
            }
            HIS.ZYNurse_BLL.OP_Bed opbed = new HIS.ZYNurse_BLL.OP_Bed();
            IsTrans = opbed.TranDept(patlist, this.cbDept.SelectedValue.ToString());
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            IsTrans = false;
            this.Close();
        }

    }
}
