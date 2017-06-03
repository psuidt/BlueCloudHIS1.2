using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWMHIS.BussinessLogicLayer.Classes;

namespace HIS_MZDocManager
{
    public partial class FrmPreMould : GWI.HIS.Windows.Controls.BaseMainForm, Action.IFrmPreMouldView
    {
        //变量
        private User _currentUser;
        private Deptment _currentDept;
        private Action.FrmPreMouldController Controller;
        private HIS.MZDoc_BLL.PresMouldHead _currentMould;
        private int _selectNodeTag = -1;
        private int _rowIndex = -1;
        private int _paintRowIndex = -1;
        private int _groupStartRowIndex = -1;
        private bool _isSelected = false;

        public FrmPreMould(long currentUserId, long currentDeptId)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            Controller = new HIS_MZDocManager.Action.FrmPreMouldController(this);
            btSelected.Visible = true;
        }

        public FrmPreMould(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            this.Text = chineseName;
            this.FormTitle = chineseName;
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            Controller = new HIS_MZDocManager.Action.FrmPreMouldController(this);
        }

        public DataRow[] SelectedRows
        {
            get
            {
                if (this.BindPresDataSource == null || this.BindPresDataSource.Rows.Count<=0)
                {
                    return null;
                }
                return this.BindPresDataSource.Select("Selected=" + true);
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
        }

        #region IFrmPreMouldView 成员
        //当前用户
        public User currentUser
        {
            get
            {
                return _currentUser;
            }
        }
        //当前科室
        public Deptment currentDept
        {
            get
            {
                return _currentDept;
            }
        }
        //当前模板级别
        public int MouldLevel
        {
            get
            {
                return Convert.ToInt32(tVMouldType.SelectedNode.Tag);
            }
        }
        //模板列表
        public DataTable MouldList
        {
            set
            {
                tVMouldList.Nodes.Clear();
                TreeNode node = new TreeNode("全部模板", 15, 14);
                HIS.MZDoc_BLL.PresMouldHead mould = new HIS.MZDoc_BLL.PresMouldHead();
                mould.PresMouldHeadId = -1;
                mould.Mould_Name = "全部模板";
                mould.Mould_Type = 0;
                node.Tag = mould;
                tVMouldList.Nodes.Add(node);
                if (mould.PresMouldHeadId == this.SelectNodeTag)
                {
                    tVMouldList.SelectedNode = node;
                }
                CreateTreeNode(node, -1,value);
                _selectNodeTag = -1;
            }
        }
        //当前模板
        public HIS.MZDoc_BLL.PresMouldHead CurrentMould
        {
            get
            {
                if (tVMouldList.SelectedNode == null)
                {
                    _currentMould = new HIS.MZDoc_BLL.PresMouldHead();
                    _currentMould.PresMouldHeadId = -1;
                }
                else
                {
                    _currentMould = (HIS.MZDoc_BLL.PresMouldHead)tVMouldList.SelectedNode.Tag;
                }
                return _currentMould;
            }
        }
        //当前模板树的选中节点Tag
        public int SelectNodeTag
        {
            get
            {
                return _selectNodeTag;
            }
            set 
            {
                _selectNodeTag = value;
            }
        }
        //Grid当前行号
        public int RowIndex
        {
            get
            {
                return _rowIndex;
            }
            set
            {
                _rowIndex = value;
            }
        }
        //Grid数据源
        public DataTable BindPresDataSource
        {
            get
            {
                return (DataTable)this.dGVEMain.DataSource;
            }
            set
            {
                this.dGVEMain.AutoGenerateColumns = false;
                this.dGVEMain.DataSource = value;
            }
        }
        //单元格颜色
        public HIS.MZDoc_BLL.Public.PresColor CellColor
        {
            set
            {
                if (value.colIndex == -1)
                {
                    for (int r = 0; r < this.dGVEMain.Columns.Count; r++)
                    {
                        this.dGVEMain.Rows[value.rowIndex].Cells[r].Style.ForeColor = value.ForeColor;
                        this.dGVEMain.Rows[value.rowIndex].Cells[r].Style.BackColor = value.BackColor;
                    }
                }
                else
                {
                    this.dGVEMain.Rows[value.rowIndex].Cells[value.colIndex].Style.ForeColor = value.ForeColor;
                    this.dGVEMain.Rows[value.rowIndex].Cells[value.colIndex].Style.BackColor = value.BackColor;
                }
            }
        }
        //处方列序号
        public HIS.MZDoc_BLL.Public.PresColumnIndex ColumnIndex
        {
            get
            {
                HIS.MZDoc_BLL.Public.PresColumnIndex presColumnIndex = new HIS.MZDoc_BLL.Public.PresColumnIndex();
                presColumnIndex.ItemIdIndex = this.Item_Id.Index;
                presColumnIndex.DeptNameIndex = this.Dept_Name.Index;
                presColumnIndex.UsageAmountIndex = this.Usage_Amount.Index;
                presColumnIndex.UsageUnitIndex = this.Usage_Unit.Index;
                presColumnIndex.DosageIndex = this.Dosage.Index;
                presColumnIndex.UsageIndex = this.Usage_Name.Index;
                presColumnIndex.FrequencyIndex = this.Frequency_Name.Index;
                presColumnIndex.DaysIndex = this.Days.Index;
                presColumnIndex.ItemAmountIndex = this.Item_Amount.Index;
                presColumnIndex.ItemUnitIndex = this.Item_Unit.Index;
                presColumnIndex.EntrustIndex = this.Entrust.Index;
                return presColumnIndex;
            }
        }
        //单元格只读状态
        public HIS.MZDoc_BLL.Public.PresCellReadOnly CellReadOnly
        {
            set
            {
                this.Item_Id.ReadOnly = value.ItemIdReadOnly;
                this.Dept_Name.ReadOnly = value.DeptNameReadOnly;
                this.Usage_Amount.ReadOnly = value.UsageAmountReadOnly;
                this.Usage_Unit.ReadOnly = value.UsageUnitReadOnly;
                this.Dosage.ReadOnly = value.DosageReadOnly;
                this.Usage_Name.ReadOnly = value.UsageReadOnly;
                this.Frequency_Name.ReadOnly = value.FrequencyReadOnly;
                this.Days.ReadOnly = value.DaysReadOnly;
                this.Item_Amount.ReadOnly = value.ItemAmountReadOnly;
                this.Item_Unit.ReadOnly = value.ItemUnitReadOnly;
                this.Entrust.ReadOnly = value.EntrustReadOnly;
            }
        }
        //分组开始行的索引
        public int GroupStartRowIndex
        {
            get { return _groupStartRowIndex; }
            set { _groupStartRowIndex = value; }
        }
        //当前绘制行号
        public int PaintRowIndex
        {
            get
            {
                return _paintRowIndex;
            }
            set
            {
                _paintRowIndex = value;
            }
        }
        //单元格矩形
        public System.Drawing.Rectangle GridCellBounds
        {
            get
            {
                return this.dGVEMain.GetCellDisplayRectangle(2, this._paintRowIndex, false);
            }
        }
        //是否选定处方
        public bool CheckPres
        {
            get
            {
                return chkBCheckPres.Checked;
            }
        }
        //初始化
        public void Initialize(DataSet _dataSet)
        {
            this.dGVEMain.SetSelectionCardDataSource(_dataSet.Tables["All_Item_Dictionary"], this.Item_Id.Index);
            this.dGVEMain.SetSelectionCardDataSource(_dataSet.Tables["ExeDept_Dictionary"], this.Dept_Name.Index);
            this.dGVEMain.SetSelectionCardDataSource(_dataSet.Tables["Usage_Unit_Dictionary"], this.Usage_Unit.Index);
            this.dGVEMain.SetSelectionCardDataSource(_dataSet.Tables["Usage_Dictionary"], this.Usage_Name.Index);
            this.dGVEMain.SetSelectionCardDataSource(_dataSet.Tables["Frequency_Dictionary"], this.Frequency_Name.Index);
            this.dGVEMain.SetSelectionCardDataSource(_dataSet.Tables["Item_Unit_Dictionary"], this.Item_Unit.Index);
            this.dGVEMain.SetSelectionCardDataSource(_dataSet.Tables["Entrust_Dictionary"], this.Entrust.Index);
        }
        //刷新处方
        public void RefreshPres()
        {
            this._groupStartRowIndex = -1;
            this.tSMnuIGrouping.Text = "开始分组(Ctrl+F9)";
        }
        //药房科室数据
        public DataTable DrugDeptDic
        {
            set
            {
                this.cbBDrugDept.DisplayMember = "Name";
                this.cbBDrugDept.ValueMember = "Value";
                this.cbBDrugDept.DataSource = value;
                this.cbBDrugDept.SelectedIndex = 0;
            }
        }
        //当前选择的药房科室Id
        public string SelectedDrugDeptId
        {
            get
            {
                return (this.cbBDrugDept.SelectedValue == null ? -1 : this.cbBDrugDept.SelectedValue).ToString().Trim();
            }
        }
        #endregion

        #region 方法
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
                        TreeNode childnode = new TreeNode(mould.Mould_Name, 15, 14);
                        childnode.Tag = mould;
                        node.Nodes.Add(childnode);
                        if (mould.PresMouldHeadId == this.SelectNodeTag)
                        {
                            tVMouldList.SelectedNode = childnode;
                        }
                        CreateTreeNode(childnode, mould.PresMouldHeadId, mouldTable);
                    }
                    else
                    {
                        this.Focus();
                        TreeNode childnode = new TreeNode(mould.Mould_Name, 18, 7);
                        childnode.Tag = mould;
                        node.Nodes.Add(childnode);
                        if (mould.PresMouldHeadId == this.SelectNodeTag)
                        {
                            tVMouldList.SelectedNode = childnode;
                        }
                    }
                }
            }
        }

        private bool CheckDataSource()
        {
            return this.BindPresDataSource != null && this.BindPresDataSource.Rows.Count > 0;
        }
        #endregion

        #region 其他事件
        private void FrmPreMould_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.CurrentMould.Mould_Type == 0 || this.CurrentMould.Mould_Level != 3 && this.CurrentMould.Create_Doc != (int)currentUser.EmployeeID)
            {
                return;
            }
            switch (e.KeyData)
            {
                case Keys.F2:	//保存
                    tSBtnSave_Click(null, null);
                    break;
                case Keys.F3:	//新增
                    tSBtnNew_Click(null, null);
                    break;
                case Keys.F4:	//修改
                    tSBtnUpdate_Click(null, null);
                    break;
                case Keys.F5:	//取消
                    tSBtnCancel_Click(null, null);
                    break;
                case Keys.F6:	//删除
                    tSBtnDel_Click(null, null);
                    break;
                case Keys.Insert:
                    tSMnuIInsert_Click(null,null);
                    break;
                case Keys.Delete:
                    tSMnuIDelRow_Click(null, null);
                    break;
                //case Keys.Up:
                //    tSMnuIUpRow_Click(null, null);
                //    break;
                //case Keys.Down:
                //    tSMnuIDownRow_Click(null, null);
                //    break;
                case Keys.Control| Keys.A:
                    tSMnuIDelPres_Click(null, null);
                    break;
                case Keys.F9:
                    tSMnuIGrouping_Click(null, null);
                    break;
                case Keys.F11:
                    tSMnuICancelGroup_Click(null, null);
                    break;
                case Keys.Control| Keys.Z:
                    tSMnuIFootNote_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void tVMouldType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Controller.LoadMouldList();
            tVMouldList.Nodes[0].Expand();
        }

        private void tVMouldList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.qTxtMouldName.Text = tVMouldList.SelectedNode.Text;
            Controller.LoadMouldContents();
            if (this.CurrentMould.Mould_Type == 1 && (this.CurrentMould.Mould_Level == 3 || this.CurrentMould.Create_Doc == (int)currentUser.EmployeeID))
            {
                tSMain.Enabled = true;
            }
            else
            {
                tSMain.Enabled = false;
            }
            tSBtnSelected.Enabled = tSBtnSelected.Visible;
        }

        private void qTxtMouldName_AfterSelectedRow(object sender, object SelectedValue)
        {

        }

        private void cbBDrugDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Controller != null)
            {
                Controller.FilterDeptDrug();
            }
        }

        private void FrmPreMould_Load(object sender, EventArgs e)
        {
            this.tVMouldType.SelectedNode = this.tVMouldType.Nodes[2];
        }
        #endregion

        #region 工具栏事件
        //保存
        private void tSBtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Controller.SaveMouldList();
                MessageBox.Show("保存成功", "提示");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }
        //新增
        private void tSBtnNew_Click(object sender, EventArgs e)
        {
            Controller.AddRow();
            this.dGVEMain.CurrentCell = this.dGVEMain[this.Item_Id.Index, this.RowIndex];
            dGVEMain.Focus();
        }
        //修改
        private void tSBtnUpdate_Click(object sender, EventArgs e)
        {
            Controller.UpdateRow();
        }
        //取消
        private void tSBtnCancel_Click(object sender, EventArgs e)
        {
            tVMouldList_AfterSelect(null,null);
        }
        //删除
        private void tSBtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow[] rows = this.BindPresDataSource.Select("Item_Id>0 and Selected=" + true);
                if (rows == null && rows.Length <= 0)
                {
                    MessageBox.Show("没有可删除的记录！", "提示"); 
                }
                else if (MessageBox.Show("确定要删除这些记录吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Controller.DeleteMouldList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }
        //选定
        private void tSBtnSelected_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //选定
        private void btSelected_Click(object sender, EventArgs e)
        {
            _isSelected = true;
            this.Close();
        }
        //全选
        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            Controller.CheckAll();
        }
        //反选
        private void btnCheckOther_Click(object sender, EventArgs e)
        {
            Controller.CheckOther();
        }
        #endregion

        #region 右键菜单事件
        private void 新建节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Controller.AddMould();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"提示");
            }
        }

        private void 修改节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.UpdateMould();
        }

        private void 删除节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CurrentMould.PresMouldHeadId != -1)
            {
                this.SelectNodeTag = ((HIS.Model.Mz_Doc_PresMouldHead)tVMouldList.SelectedNode.Parent.Tag).PresMouldHeadId;
                if (MessageBox.Show("确定要删除节点【" + this.CurrentMould.Mould_Name + "】", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Controller.DeleteMould();
                }
            }            
        }

        private void tSMnuIInsert_Click(object sender, EventArgs e)
        {
            if (this.BindPresDataSource == null || this.BindPresDataSource.Rows.Count <= 0)
            {
                return;
            }
            Controller.InsertRow();
            this.dGVEMain.CurrentCell = this.dGVEMain[this.Item_Id.Index, this.RowIndex];
            dGVEMain.Focus();
        }

        private void tSMnuIDelRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckDataSource())
                {
                    Controller.DeleteRow();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }

        private void tSMnuIUpRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckDataSource())
                {
                    Controller.UpRow();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }

        private void tSMnuIDownRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckDataSource())
                {
                    Controller.DownRow();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }

        private void tSMnuIDelPres_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckDataSource())
                {
                    Controller.DeletePres();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }

        private void tSMnuIGrouping_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckDataSource())
                {
                    Controller.Grouping();
                    Controller.PaintGroup(this.dGVEMain.CreateGraphics());
                    if (this._groupStartRowIndex == -1)
                    {
                        this.tSMnuIGrouping.Text = "开始分组(Ctrl+F9)";
                    }
                    else
                    {
                        this.tSMnuIGrouping.Text = "结束分组(Ctrl+F9)";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }

        private void tSMnuICancelGroup_Click(object sender, EventArgs e)
        {
            if (CheckDataSource())
            {
                Controller.CancelGroup();
                Controller.PaintGroup(this.dGVEMain.CreateGraphics());
                if (this._groupStartRowIndex == -1)
                {
                    this.tSMnuIGrouping.Text = "开始分组(Ctrl+F9)";
                }
                else
                {
                    this.tSMnuIGrouping.Text = "结束分组(Ctrl+F9)";
                }
            }
        }

        private void tSMnuIFootNote_Click(object sender, EventArgs e)
        {
            if (CheckDataSource())
            {
                Controller.AddFootNote();
            }
        }
        #endregion   

        #region 网格事件
        private void dGVEMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.RowIndex = e.RowIndex;
            if (this.RowIndex > -1)
            {
                Controller.MouldProcess(e.ColumnIndex);
            }
        }

        private void dGVEMain_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dGVEMain.CurrentCell != null)
            {
                this.RowIndex = this.dGVEMain.CurrentCell.RowIndex;
                Controller.SettingReadOnly(this.dGVEMain.CurrentCell.RowIndex);
                if (!this.dGVEMain.CurrentCell.ReadOnly
                    && this.dGVEMain.CurrentCell.ColumnIndex != this.Item_Id.Index
                     && this.dGVEMain.CurrentCell.ColumnIndex != this.Entrust.Index)
                {
                    this.dGVEMain.BeginEdit(true);
                }
            }
        }

        private void dGVEMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Controller.ChangeSelected();
        }

        private void dGVEMain_DataGridViewCellPressEnterKey(object sender, int colIndex, int rowIndex, ref bool jumpStop)
        {
            if ((colIndex == this.Entrust.Index || this.Entrust.ReadOnly && colIndex == this.Usage_Amount.Index))// && rowIndex == (this.dGVEMain.RowCount - 1))
            {
                this.RowIndex = this.BindPresDataSource.Rows.Count - 1;
                Controller.AddRow();
                this.dGVEMain.CurrentCell = this.dGVEMain[this.Item_Id.Index, this.BindPresDataSource.Rows.Count - 1];
                jumpStop = true;
            }
        }

        private void dGVEMain_SelectCardRowSelected(object SelectedValue, ref bool stop, ref int customNextColumnIndex)
        {
            try
            {
                int colid = this.dGVEMain.CurrentCell.ColumnIndex;
                int rowid = this.dGVEMain.CurrentCell.RowIndex;
                Controller.SelectCardBindData(colid, (DataRow)SelectedValue);
                this.dGVEMain.CurrentCell = this.dGVEMain[this.dGVEMain.CurrentCell.ColumnIndex, this.RowIndex];

                if (colid == this.Usage_Unit.Index && rowid > 0 && 
                    Convert.ToBoolean(this.BindPresDataSource.Rows[rowid]["IsHerb"]) && 
                    Convert.ToBoolean(this.BindPresDataSource.Rows[rowid - 1]["IsHerb"]))
                {
                    this.RowIndex = this.BindPresDataSource.Rows.Count - 1;
                    Controller.AddRow();
                    this.dGVEMain.CurrentCell = this.dGVEMain[this.Item_Id.Index, this.BindPresDataSource.Rows.Count - 1];
                    stop = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }

        private void dGVEMain_Paint(object sender, PaintEventArgs e)
        {
            Controller.PaintGroup(e.Graphics);
        }
        #endregion
    }
}
