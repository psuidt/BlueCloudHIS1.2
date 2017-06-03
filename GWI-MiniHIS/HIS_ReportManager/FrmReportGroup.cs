using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.Report_BLL;

namespace HIS_ReportManager
{
    public partial class FrmReportGroup : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private DataTable _reportGroup;
        public FrmReportGroup()
        {
            InitializeComponent();
            btnRefresh_Click(null, null);
        }

        private void LoadReportGroup()
        {
            HIS.Report_BLL.reportPermissionBLL permission = new HIS.Report_BLL.reportPermissionBLL();
            _reportGroup = permission.GetReportGroup();
        }
        private void InitGroups()
        {
            DataTable tbGroup = HIS.Base_BLL.BaseDataReader.Base_Group;
            this.lstGroup.Items.Clear();
            for (int i = 0; i <= tbGroup.Rows.Count - 1; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = tbGroup.Rows[i]["name"].ToString().Trim();
                item.SubItems.Add(tbGroup.Rows[i]["memo"].ToString().Trim());
                item.ImageIndex = 1;
                item.Tag = Convert.ToInt64(tbGroup.Rows[i]["group_id"]);
                if (Convert.ToInt32(tbGroup.Rows[i]["ADMINISTRATORS"]) == 1)
                    item.Text = item.Text + "【管理员】";
                if (Convert.ToInt32(tbGroup.Rows[i]["DELETE_FLAG"]) == 1)
                    item.Text = item.Text + "(停用)";
                this.lstGroup.Items.Add(item);
            }
        }

        /// <summary>
        /// 加载报表树
        /// </summary>
        private void loadReportdata()
        {
            TvReport.Nodes.Clear();
            ReportShow.loadReportdata(TvReport);
            TvReport.ExpandAll();
        }

        private void lstGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.lstGroup.SelectedItems.Count == 0) return;
            this.ClearNodeCheck();
            int groupId = Convert.ToInt32(this.lstGroup.SelectedItems[0].Tag);
            this.TvReport.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.TvReport_AfterCheck);
            foreach (TreeNode node in this.TvReport.Nodes)
            {
                SetNodeCheck(node, groupId);
            }
            this.TvReport.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TvReport_AfterCheck);
        }

        private void ClearNodeCheck()
        {
            foreach (TreeNode node in this.TvReport.Nodes)
            {
                node.Checked = false;
                ClearSubNodeCheck(node);
            }
        }
        private void ClearSubNodeCheck(TreeNode node)
        {
            foreach (TreeNode nd in node.Nodes)
            {
                nd.Checked = false;
                ClearSubNodeCheck(nd);
            }
        }


        private void SetNodeCheck(TreeNode node, int groupid)
        {
            foreach (TreeNode nd in node.Nodes)
            {
                if (nd.Tag.GetType() == typeof(OpReportMaster))
                {
                    SetNodeCheck(nd, groupid);
                }
                else
                {
                    HIS.Report_BLL.Reportdat report = (HIS.Report_BLL.Reportdat)nd.Tag;
                    DataRow[] drs = _reportGroup.Select("report_id=" + report.REPORT_ID + " and group_id=" + groupid);
                    if (drs.Length != 0) nd.Checked = true;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReportGroup();
            InitGroups();
            loadReportdata();
            TvReport.ExpandAll();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string  groupId = this.lstGroup.SelectedItems[0].Tag.ToString();
            reportPermissionBLL reportBll = new reportPermissionBLL();
            try
            {
                List<RightRelation> relations = new List<RightRelation>();
                RightRelation relation;
                foreach (TreeNode node in TvReport.Nodes)
                {
                    if (node.Tag.GetType() == typeof(OpReportMaster))
                    {
                        SearchSubNode(node, relations, groupId);
                    }
                    else
                    {
                        if (node.Checked)
                        {
                            Reportdat dat = (Reportdat)node.Tag;
                            relation = new RightRelation();
                            relation.groupid = groupId;
                            relation.reportid = dat.REPORT_ID.ToString();
                            relations.Add(relation);
                        }
                    }
                }
                reportBll.AllocRight(relations,Convert.ToInt32( groupId));
                MessageBox.Show("权限分配成功！");
            }
            catch (Exception err)
            {
                MessageBox.Show("权限分配失败，原因：" + err.Message);
            }
            finally
            {
                btnRefresh_Click(null, null);
            }
        }

        private void SearchSubNode(TreeNode node, List<RightRelation> relations, string  groupid)
        {
            foreach (TreeNode nd in node.Nodes)
            {
                if (nd.Tag.GetType() == typeof(OpReportMaster))
                {
                    SearchSubNode(nd, relations, groupid);
                }
                else
                {
                    if (nd.Checked)
                    {
                        Reportdat dat = (Reportdat)nd.Tag;
                        RightRelation relation = new RightRelation();
                        relation.groupid = groupid;
                        relation.reportid = dat.REPORT_ID.ToString();
                        relations.Add(relation);
                    }
                }
            }
        }

        private void TvReport_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag.GetType() == typeof(OpReportMaster))
            {
                SubChecked(e.Node);
            }
        }

        private void SubChecked(TreeNode node)
        {
            foreach (TreeNode nd in node.Nodes)
            {
                nd.Checked = node.Checked;
                if (nd.Tag.GetType() == typeof(OpReportMaster))
                {
                    SubChecked(nd);
                }
            }
        }
    }
}
