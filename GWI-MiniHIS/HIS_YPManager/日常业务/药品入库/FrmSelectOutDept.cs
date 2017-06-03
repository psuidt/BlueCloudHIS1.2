using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.YP_BLL;
using HIS.SYSTEM.PubicBaseClasses;
using GWMHIS.BussinessLogicLayer.Classes;

namespace HIS_YPManager
{
    public partial class FrmSelectOutDept : GWI.HIS.Windows.Controls.BaseForm
    {
        public int _storeDeptId;
        public string _deptName;
        private DataTable _dgDeptDt;
        public bool isOpenApplyOrder = true;
        public FrmSelectOutDept()
        {
            InitializeComponent();
        }



        private void FrmSelectOutDept_Load(object sender, EventArgs e)
        {
            try
            {
                _dgDeptDt = DrugBaseDataBll.YK_DeptGet(ConfigManager.OP_YK_OUTTOYF);
                txtSelectDept.SetSelectionCardDataSource(_dgDeptDt);
                txtSelectDept.Focus();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void txtSelectDept_AfterSelectedRow(object sender, object SelectedValue)
        {
            DataRow dr = (DataRow)SelectedValue;
            if (dr != null)
            {
                txtSelectDept.Tag = 1;
                _storeDeptId = Convert.ToInt32(dr["DEPTID"]);
                txtSelectDept.Text = dr["NAME"].ToString();
                _deptName = txtSelectDept.Text;
                this.btnOK.Focus();
            }
        }

        private void txtSelectDept_Leave(object sender, EventArgs e)
        {
            TextBox txtSender = (TextBox)sender;
            if (txtSender.Tag == null && txtSender.Text != "")
            {
                txtSender.Focus();
                txtSender.SelectAll();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (_storeDeptId == 0)
                {
                    this.isOpenApplyOrder = false;
                    throw new Exception("请选择申领库房.....");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

    }
}
