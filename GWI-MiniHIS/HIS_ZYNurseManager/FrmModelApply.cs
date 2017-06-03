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
    public partial class FrmModelApply : GWI.HIS.Windows.Controls.BaseForm
    {
        int level = 0;
        int deptid;
        int employeeid;
        public List<int> checkedmodels;

        public FrmModelApply(int _deptid,int _employeeid)
        {
            InitializeComponent();
            deptid = _deptid;
            employeeid = _employeeid;
            checkedmodels = new List<int>();
        }
       

        private void tvlevel_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.tvtype.Nodes.Clear();            
            if (this.tvlevel.SelectedNode.Index == 0)
            {
                level = 0;
            }
            else if (this.tvlevel.SelectedNode.Index == 1)
            {
                level = 1;
            }
            else
            {
                level = 2;
            }
            InitNode();
        }
        private void InitNode()
        {
            TreeNode node = PublicFeeModel.LoadModeTree(level, deptid, employeeid);
            tvtype.Nodes.Add(node);
            tvtype.SelectedNode = node;
            node.Expand();
            tvlevel.ExpandAll();
        }

        private void 应用ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tvtype_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "所有模板")
            {
                return;
            }
            this.tvtype.AfterCheck -= new TreeViewEventHandler(tvtype_AfterCheck);
            this.tvtype.SelectedNode = e.Node;
            SetNodeChecked(this.tvtype.SelectedNode, this.tvtype.SelectedNode.Checked);
            this.tvtype.AfterCheck += new TreeViewEventHandler(tvtype_AfterCheck);
        }

        private void SetNodeChecked(TreeNode tn, bool b)
        {        
            foreach (TreeNode TNode in tn.Nodes)
            {
                TNode.Checked = b;
                SetNodeChecked(TNode, b);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            checkedmodels.Clear();
            foreach (TreeNode node in tvtype.Nodes)
            {
                HIS.ZYNurse_BLL.FeeModelProcess modelporcess = (HIS.ZYNurse_BLL.FeeModelProcess)node.Tag;
                if (modelporcess.MODEL_TYPE == 0)
                {
                    SearchSubNode(node, checkedmodels);
                }
                else
                {
                    if (node.Checked)
                    {
                        checkedmodels.Add(modelporcess.MODEL_ID);
                    }
                }
            }
            if (checkedmodels.Count == 0)
            {
                MessageBox.Show("请选择需要应用的模板");
                return;
            }
            this.Close();
        }
        private void SearchSubNode(TreeNode node, List<int> checkedmodels)
        {
            foreach (TreeNode nd in node.Nodes)
            {
                HIS.ZYNurse_BLL.FeeModelProcess modelporcess = (HIS.ZYNurse_BLL.FeeModelProcess)nd.Tag;
                if (modelporcess.MODEL_TYPE == 0)
                {
                    SearchSubNode(nd, checkedmodels);
                }
                else
                {
                    if (nd.Checked)
                    {
                        checkedmodels.Add(modelporcess.MODEL_ID);
                    }
                }
            }
        }
        
    }
}
