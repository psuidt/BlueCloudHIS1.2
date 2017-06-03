using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.Model;

namespace HIS_YZCXManager
{
    public partial class FrmDrugCheckQuery : GWI.HIS.Windows.Controls.BaseMainForm, IFrmCheckQuery
    {
        private FrmCheckQueryControl _control;
        private int _currentUserId;

        public FrmDrugCheckQuery(int currentUserId)
        {
            _currentUserId = currentUserId;
            InitializeComponent();
        }
        private void FrmDrugCheckQuery_Load(object sender, EventArgs e)
        {
            _control = new FrmCheckQueryControl(this);
            cobType.SelectedIndex = 0;
        }

        public void RefreshCheckOrder(DataTable checkOrderDt)
        {
            dgrdCheckOrder.AutoGenerateColumns = false;
            dgrdCheckOrder.DataSource = checkOrderDt;
        }

        public void ShowCheckMaster(DataTable checkAuditInfo, List<YP_DeptDic> drugDeptList)
        {
            treeCheckMaster.Nodes.Clear();
            TreeNode allDeptNode = new TreeNode("全院");
            treeCheckMaster.Nodes.Add(allDeptNode);
            foreach(YP_DeptDic drugDept in drugDeptList)
            {
                TreeNode deptNode = new TreeNode(drugDept.DeptName);
                deptNode.Tag = drugDept;
                allDeptNode.Nodes.Add(deptNode);
                for(int index = 0; index < checkAuditInfo.Rows.Count; index++)
                {
                    DataRow currentRow = checkAuditInfo.Rows[index];
                    if (Convert.ToInt32(currentRow["deptid"]) == drugDept.DeptID)
                    {
                        string nodeInfo = currentRow["auditnum"].ToString() + "号单据 "
                            + "(盘盈:" + Convert.ToDecimal(currentRow["checkinfee"]).ToString("0.00")
                            + ",盘亏:" + Convert.ToDecimal(currentRow["checkoutfee"]).ToString("0.00") + ") "
                            + currentRow["audittime"].ToString();
                        TreeNode billNode = new TreeNode(nodeInfo);
                        billNode.Tag = Convert.ToInt32(currentRow["auditnum"]);
                        deptNode.Nodes.Add(billNode);
                    }
                }
            }
            allDeptNode.ExpandAll();
        }

        public void RefreshDrugInfo(DataTable drugInfo)
        {
            if (drugInfo != null)
            {
                txtQueryCode.SetSelectionCardDataSource(drugInfo);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                TimeSpan span = cobEndDate.Value - cobBeginDate.Value;
                if (span.Days > 185)
                {
                    MessageBox.Show("盘点信息查询时间间隔不能超过半年");
                    return;
                }
                _control.LoadData(cobType.Text, cobBeginDate.Value, cobEndDate.Value, Application.StartupPath);
                this.txtQueryCode.Clear();
                _control.SetMakerDicId(0);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                this.Cursor = this.DefaultCursor;
            }
        }

        private void txtQueryCode_AfterSelectedRow(object sender, object SelectedValue)
        {
            if (SelectedValue != null)
            {
                DataRow dRow = (DataRow)SelectedValue;
                _control.SetMakerDicId(Convert.ToInt32(dRow["MAKERDICID"]));
            }
        }

        private void treeCheckMaster_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node != null)
                {
                    if (e.Node.Level == 2 && e.Node.Parent != null)
                    {
                        YP_DeptDic drugDept = (YP_DeptDic)(e.Node.Parent.Tag);
                        int auditNo = (int)(e.Node.Tag);
                        _control.LoadCheckOrder(auditNo, drugDept);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
