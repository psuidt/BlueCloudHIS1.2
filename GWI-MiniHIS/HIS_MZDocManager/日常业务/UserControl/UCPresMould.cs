using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_MZDocManager
{
    public partial class UCPresMould : UserControl, IDockingcontrol
    {
        private long _deptId;
        private long _employeeId;
        public event EventHandler SelectDataList;
        public UCPresMould(long deptId, long employeeId)
        {
            InitializeComponent();
            _deptId = deptId;
            _employeeId = employeeId;
            RefreshData();
        }

        private int MouldLevel
        {
            get
            {
                if (this._rdbLevelH.Checked) return 1;
                if (this._rdbLevelD.Checked) return 2;
                return 3;
            }
        }

        public void RefreshData()
        {
            DataTable dataSource = new HIS.MZDoc_BLL.PresMouldHead().GetMouldHeadList(this.MouldLevel, _deptId, _employeeId);
            this.tVwPresMould.Nodes.Clear();
            TreeNode node = new TreeNode("全部模板", 0, 1);
            HIS.MZDoc_BLL.PresMouldHead mould = new HIS.MZDoc_BLL.PresMouldHead();
            mould.PresMouldHeadId = -1;
            mould.Mould_Name = "全部模板";
            mould.Mould_Type = 0;
            node.Tag = mould;
            this.tVwPresMould.Nodes.Add(node);
            CreateTreeNode(node, -1, dataSource);
            this.tVwPresMould.Nodes[0].Expand();
        }

        private void CreateTreeNode(TreeNode node, int nodeId, DataTable mouldTable)
        {
            if (mouldTable == null || mouldTable.Rows.Count <= 0)
                return;
            DataRow[] rows = mouldTable.Select(HIS.BLL.Tables.mz_doc_presmouldhead.P_ID + "=" + nodeId);
            if (rows != null && rows.Length > 0)
            {
                foreach (DataRow row in rows)
                {
                    HIS.MZDoc_BLL.PresMouldHead mould = (HIS.MZDoc_BLL.PresMouldHead)HIS.MZDoc_BLL.Public.Function.DataRowToObject<HIS.MZDoc_BLL.PresMouldHead>(row);
                    if (mould.Mould_Type == 0)
                    {
                        TreeNode childnode = new TreeNode(mould.Mould_Name, 0, 1);
                        childnode.Tag = mould;
                        node.Nodes.Add(childnode);
                        CreateTreeNode(childnode, mould.PresMouldHeadId, mouldTable);
                    }
                    else
                    {
                        this.Focus();
                        TreeNode childnode = new TreeNode(mould.Mould_Name, 2, 3);
                        childnode.Tag = mould;
                        node.Nodes.Add(childnode);
                    }
                }
            }
        }

        private void btRefreshMould_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void tVwPresMould_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.dGVEPresMould.AutoGenerateColumns = false;
            this.dGVEPresMould.DataSource = ((HIS.MZDoc_BLL.PresMouldHead)this.tVwPresMould.SelectedNode.Tag).GetMouldList();
        }

        private void tVwPresMould_DoubleClick(object sender, EventArgs e)
        {
            if (SelectDataList != null)
            {
                HIS.MZDoc_BLL.PresMouldHead presMouldHead = (HIS.MZDoc_BLL.PresMouldHead)tVwPresMould.SelectedNode.Tag;
                SelectDataList(presMouldHead.GetMouldContents().Select(""), e);
            }
        }

        private void dGVEPresMould_DoubleClick(object sender, EventArgs e)
        {
            if (SelectDataList != null)
            {
                DataTable table = ((DataTable)dGVEPresMould.DataSource).Clone();
                if (table == null || ((DataTable)dGVEPresMould.DataSource).Rows.Count <= 0)
                {
                    SelectDataList(null, e);
                }
                else
                {
                    table.Rows.Add(((DataTable)dGVEPresMould.DataSource).Rows[dGVEPresMould.CurrentCell.RowIndex].ItemArray);
                    SelectDataList(table.Select(""), e);
                }
            }
        }
    }
}
