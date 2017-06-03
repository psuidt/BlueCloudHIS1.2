using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.Model;
using HIS.YZCX_BLL;

namespace HIS_YZCXManager
{
    public partial class FrmZYPatfeeQuery : GWI.HIS.Windows.Controls.BaseMainForm, IFrmZYPatfeeQuery
    {
        private FrmZYPatfeeQueryControl _control;

        public FrmZYPatfeeQuery()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPatfeeQuery_Load(object sender, EventArgs e)
        {
            try
            {
                _control = new FrmZYPatfeeQueryControl(this);
                _control.LoadAllClincDept();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public void RefreshPatInfo(QueryZYPatInfo pat)
        {
            lblBedNo.Text = pat._zyPatient.BedCode;

            lblInTime.Text = pat._zyPatient.CureDate.ToString("yyyy-MM-dd");
            lblInDiagnose.Text = pat._zyPatient.DiseaseName;
            lblOutDiagnose.Text = pat._zyPatient.OutDiagnName;
            if (pat._zyPatient.OutDate.Year <= 1)
            {
                lblOutTime.Text = "至今";
            }
            else
            {
                lblOutTime.Text = pat._zyPatient.OutDate.ToString("yyyy-MM-dd");
            }
            lblPatDept.Text = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(pat._zyPatient.CureDeptCode);
            lblPatName.Text = pat._zyPatient.PatientInfo.PatName;
            lblPatSex.Text = pat._zyPatient.PatientInfo.PatSex;
            lblPatType.Text = pat._zyPatient.PatType;
            lblPrepayFee.Text = pat.PrePayFee.ToString("0.00");
            lblTotalFee.Text = pat.TotalFee.ToString("0.00");
            lblInPatientID.Text = pat._zyPatient.CureNo;
            lblOutStandFee.Text = (pat.PrePayFee - pat.TotalFee).ToString("0.00");
        }

        public void RefreshPatFee(DataTable itemFee, DataTable bigitemFee, DataTable hsitemFee)
        {
            dgrdDXM.AutoGenerateColumns = false;
            dgrdFYMX.AutoGenerateColumns = false;
            dgrdTJFL.AutoGenerateColumns = false;
            dgrdDXM.DataSource = bigitemFee;
            dgrdFYMX.DataSource = itemFee;
            dgrdTJFL.DataSource = hsitemFee;
        }

        public void RefreshClincDept(DataTable clincDepts)
        {
            treePatInfo.Nodes.Clear();
            if (clincDepts != null)
            {
                for (int index = 0; index < clincDepts.Rows.Count; index++)
                {
                    TreeNode deptNode = new TreeNode();
                    deptNode.Text = clincDepts.Rows[index]["NAME"].ToString();
                    int deptId = Convert.ToInt32(clincDepts.Rows[index]["DEPT_ID"]);
                    deptNode.Tag = deptId;
                    treePatInfo.Nodes.Add(deptNode);
                    List<ZY_PatList> listPat = _control.LoadPatBy(radIsInHospital.Checked, deptId);
                    foreach (ZY_PatList pat in listPat)
                    {
                        TreeNode patNode = new TreeNode();
                        patNode.Text = pat.PatientInfo.PatName + "(" + pat.PatientInfo.CureNo + ")";
                        patNode.Tag = pat;
                        deptNode.Nodes.Add(patNode);
                    }
                }
            }
        }

        private void radIsInHospital_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                _control.LoadAllClincDept();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                this.Cursor = DefaultCursor;
            }
        }


        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (txtQueryNo.Text != "" || txtQueryName.Text != "")
            {
                for (int index = 0; index < treePatInfo.Nodes.Count; index++)
                {
                    TreeNode parentNode = treePatInfo.Nodes[index];
                    for (int temp = 0; temp < parentNode.Nodes.Count; temp++)
                    {
                        ZY_PatList pat = (ZY_PatList)(parentNode.Nodes[temp].Tag);
                        if (pat.CureNo == txtQueryNo.Text)
                        {
                            treePatInfo.SelectedNode = parentNode.Nodes[temp];
                            treePatInfo_NodeMouseClick(null, new TreeNodeMouseClickEventArgs(treePatInfo.SelectedNode,
                                MouseButtons.XButton1, 1, 0, 0));
                            return;
                        }
                    }
                }
            }
        }


        private void treePatInfo_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node.Level != 0)
                {
                    ZY_PatList pat = (ZY_PatList)(e.Node.Tag);
                    _control.CurrentPat = new QueryZYPatInfo();
                    _control.CurrentPat._zyPatient = pat;
                    _control.LoadZYPatFee();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
