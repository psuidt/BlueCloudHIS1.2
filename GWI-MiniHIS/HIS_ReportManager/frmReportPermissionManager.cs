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
    public partial class frmReportPermissionManager : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private reportPermissionBLL reportBll = new reportPermissionBLL();

        public frmReportPermissionManager()
        {
            InitializeComponent();
        }

        private void frmReportPermissionManager_Load(object sender, EventArgs e)
        {
            Load_Group();
            Load_ReportModel();
            Load_ReportRelation();
        }
        /// <summary>
        /// 加载用户组信息
        /// </summary>
        private void Load_Group()
        {
            tvGroup.Nodes.Clear();
            DataTable dtGroup = new DataTable();
            dtGroup = reportBll.GetGroupList(" delete_flag=0 ");
            DataTable dtHospitals = new DataTable();
            dtHospitals = reportBll.GetHospitals();
            TreeNode parentNode;
            TreeNode childnode;
            foreach (DataRow dr in dtHospitals.Rows)
            {
                parentNode = new TreeNode();
                foreach (DataRow drr in dtGroup.Rows)
                {
                    if (dr["workid"].ToString().Trim() == drr["workid"].ToString().Trim())
                    {
                        childnode = new TreeNode();
                        childnode.Tag = drr["group_id"].ToString();
                        childnode.Text = drr["Name"].ToString();
                        parentNode.Nodes.Add(childnode);
                    }
                }
                parentNode.Tag = dr["workid"].ToString();
                parentNode.Text = dr["workname"].ToString();
                parentNode.ExpandAll();
                tvGroup.Nodes.Add(parentNode);                
            }
            tvGroup.ExpandAll();

        }
        /// <summary>
        /// 加载报表模板信息
        /// </summary>
        private void Load_ReportModel()
        {
            lvReport.Nodes.Clear();       
            ReportShow.loadReportdata(lvReport);
            lvReport.ExpandAll();
        }
        /// <summary>
        /// 加载报表权限关系信息
        /// </summary>
        private void Load_ReportRelation()
        {
            try
            {
                lvReportRelation.Items.Clear();
                DataTable dt = reportBll.GetReportsRelation();
                ListViewItem lvi;
                for (int i = 0; i < dt.Rows.Count;i++ )
                {
                    lvi = lvReportRelation.Items.Add(dt.Rows[i]["workname"].ToString());
                    lvi.Tag = dt.Rows[i]["id"].ToString();
                    lvi.SubItems.Add(dt.Rows[i]["cnm"].ToString());
                    lvi.SubItems.Add(dt.Rows[i]["dnm"].ToString());
                    lvi.SubItems.Add(dt.Rows[i]["isglobal"].ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnAlloc_Click(object sender, EventArgs e)
        {     
            int cnt1=0;
            foreach (TreeNode ptn in tvGroup.Nodes)
            {
                foreach (TreeNode ctn in ptn.Nodes)
                {
                    if (ctn.Checked)
                    {
                        cnt1 += 1;
                    }
                }
            }          
            if (cnt1 == 0)
            {
                MessageBox.Show("请在要分配的用户组前打‘√’");
                return;
            }         
            try
            {                
                List<RightRelation> relations = new List<RightRelation>();
                RightRelation relation;
                foreach (TreeNode ptn in tvGroup.Nodes)//顶层节点
                {
                    foreach (TreeNode ctn in ptn.Nodes)//角色组节点
                    {
                        if (ctn.Checked)
                        {                         
                            foreach (TreeNode node in lvReport.Nodes)
                            {

                                if (node.Tag.GetType() == typeof(OpReportMaster))
                                {
                                    SearchSubNode(node, relations, ctn.Tag.ToString(), ptn.Tag.ToString());
                                }
                                else
                                {
                                    if (node.Checked)
                                    {
                                        Reportdat dat = (Reportdat)node.Tag;
                                        relation = new RightRelation();
                                        relation.groupid = ctn.Tag.ToString();
                                        relation.reportid = dat.REPORT_ID.ToString();// lvi.ImageIndex.ToString();
                                        relation.hisworkid = ptn.Tag.ToString();
                                        if (cbIsGlobal.Checked)
                                        {
                                            relation.isGlobal = 1;
                                        }
                                        else
                                        {
                                            relation.isGlobal = 0;
                                        }
                                        relations.Add(relation);
                                    }
                                }
                            }
                        }
                    }
                }
                if (relations.Count == 0)
                {
                    MessageBox.Show("请在要分配的报表模板前打‘√’");
                        return;
                }
               // reportBll.AllocRight(relations);
                MessageBox.Show("权限分配成功！");
            }
            catch(Exception err)
            {
                MessageBox.Show("权限分配失败，原因："+err.Message);
            }
            finally
            {
                Load_ReportRelation();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            try
            {
                foreach (ListViewItem lvi in lvReportRelation.Items)
                {
                    if (lvi.Checked)
                    {                      
                        string s = lvi.Tag.ToString();
                        reportBll.DelRight(lvi.Tag.ToString());                
                        cnt += 1;
                    }                    
                }
                if (cnt != 0)
                {
                    MessageBox.Show("记录删除成功！");
                }
                else
                {
                    MessageBox.Show("您尚未选择要删除的记录！");
                }
                    
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                Load_ReportRelation();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrush_Click(object sender, EventArgs e)
        {
            frmReportPermissionManager_Load(null, null);
        }

        private void SearchSubNode(TreeNode node, List<RightRelation> relations,string  groupid,string  hisworkid)
		{
			foreach(TreeNode nd in node.Nodes)
			{
			
                    if (nd.Tag.GetType() == typeof(OpReportMaster))
                    {
                        SearchSubNode(nd, relations,groupid,hisworkid);
                    }
                    else
                    {
                        if (nd.Checked)
                        {
                            Reportdat dat = (Reportdat)nd.Tag;
                            RightRelation relation = new RightRelation();
                            relation.groupid = groupid;
                            relation.reportid = dat.REPORT_ID.ToString();
                            relation.hisworkid = hisworkid;
                            if (cbIsGlobal.Checked)
                            {
                                relation.isGlobal = 1;
                            }
                            else
                            {
                                relation.isGlobal = 0;
                            }
                            relations.Add(relation);
                        }
                    }							
			}
		}
		private void ClearNodeCheck()
		{
            foreach (TreeNode node in lvReport.Nodes)
			{
				node.Checked=false;
				ClearSubNodeCheck(node);
			}
		}
		private void ClearSubNodeCheck(TreeNode node)
		{
			foreach(TreeNode nd in node.Nodes)
			{
				nd.Checked=false;
				ClearSubNodeCheck(nd);
			}
		}
		

 		
		private void SetCheckStatus(TreeNode node)
		{           
			foreach(TreeNode nd in node.Nodes)
			{
				nd.Checked=node.Checked;
				SetCheckStatus(nd);
			}
		}
        private void SetBackStatus(TreeNode node)
        {
            foreach (TreeNode nd in node.Nodes)
            {
                nd.Checked = !nd.Checked;
                SetCheckStatus(nd);
            }
        }

        private void selectall_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (TreeNode lvi in lvReport.Nodes)
            {
                lvi.Checked = true;
                SetCheckStatus(lvi);
            }
        }

        private void backselect_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (TreeNode lvi in lvReport.Nodes)
            {
                lvi.Checked = !lvi.Checked;
                SetBackStatus(lvi);
            }
        }

    }
}
