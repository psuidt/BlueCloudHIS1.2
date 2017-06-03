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
namespace HIS_ZYDocManager.基础数据
{
    public partial class FrmDocModel : GWI.HIS.Windows.Controls.BaseMainForm, Action.IFrmDocModelView
    {
        private User _currentUser;
        private Deptment _currentDept;
        private Action.FrmModelController Controller;
        private int _rowIndex;
        private string _typename;
        public List<HIS.Model.ZY_DOC_ORDERMODELLIST> lists;
        private int level;
        public FrmDocModel(long currentUserId, long currentDeptId)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            Controller = new HIS_ZYDocManager.Action.FrmModelController(this);
            this.btnApply.Enabled = true;
        }
        public FrmDocModel(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            this.Text = chineseName;
            Controller = new HIS_ZYDocManager.Action.FrmModelController(this);
            this.btnApply.Enabled = false;
        }

        #region IView成员
        public User currentUser
        {
            get
            {
                return _currentUser;
            }
        }
        public Deptment currentDept
        {
            get
            {
                return _currentDept;
            }
        }
        public void Initialize(DataSet _dataSet)
        {
            this.dtgrdModel.SetSelectionCardDataSource(_dataSet.Tables["ITEM_DICTIONARY"], item_name.Index);
            this.dtgrdModel.SetSelectionCardDataSource(_dataSet.Tables["Usage"], order_usage.Index);
            this.dtgrdModel.SetSelectionCardDataSource(_dataSet.Tables["Frequency"], order_frenquecy.Index);
            this.dtgrdModel.SetSelectionCardDataSource(_dataSet.Tables["Entrust"], order_struc.Index);
            this.dtgrdModel.SetSelectionCardDataSource(_dataSet.Tables["DwType"], unit.Index);
        }
        public int tag
        {
            get
            {
                return Convert.ToInt32(this.tvtype.SelectedNode.Tag);
            }
            set
            {
                this.tvtype.SelectedNode.Tag = value;
            }
        }
        public string GetYfIds
        {
            get
            {
                return (this.cbYf.SelectedValue == null ? -1 : this.cbYf.SelectedValue).ToString().Trim();
            }
        }
        #endregion

        #region IFrmDocModelView 成员颜色
        public HIS_ZYDocManager.Action.PresColor presColor
        {
            set
            {
                if (value.colIndex == -1)
                {
                    //颜色
                    for (int r = 0; r < dtgrdModel.Columns.Count; r++)
                    {
                        dtgrdModel.Rows[value.rowIndex].Cells[r].Style.ForeColor = value.ForeColor;
                        dtgrdModel.Rows[value.rowIndex].Cells[r].Style.BackColor = value.BackColor;
                    }
                }
                else
                {
                    dtgrdModel.Rows[value.rowIndex].Cells[value.colIndex].Style.ForeColor = value.ForeColor;
                    dtgrdModel.Rows[value.rowIndex].Cells[value.colIndex].Style.BackColor = value.BackColor;
                }
            }
        }

        public bool XDEnabled
        {
            set
            {
                xd1.ReadOnly = value;
            }
        }
        #endregion

        #region 成员只读
        public bool ItemNameReadOnly
        {
            set
            {
                item_name.ReadOnly = value;
            }
        }

        public bool AmountReadOnly
        {
            set
            {
                amount.ReadOnly = value;
            }
        }

        public bool PresAmountReadOnly
        {
            set
            {
                presamount.ReadOnly = value;
            }
        }
        public bool UnitReadOnly
        {
            set
            {
                unit.ReadOnly = value;
            }
        }

        public bool FrenQuencyReadOnly
        {
            set
            {
                order_frenquecy.ReadOnly = value;
            }
        }

        public bool UsageReadOnly
        {
            set
            {
                order_usage.ReadOnly = value;
            }
        }
        public bool FirstTimeReadOnly
        {
            set
            {
                frist_times.ReadOnly = value;
            }
        }

        public bool DropSperReadOnly
        {
            set
            {
                dropsper.ReadOnly = value;
            }
        }

        public bool StrucReadOnly
        {
            set
            {
                order_struc.ReadOnly = value;
            }
        }

        #endregion

        #region 方法
        private void AddRow(GWI.HIS.Windows.Controls.DataGridViewEx dgv, int sign)
        {
            dgv.Focus();
            int rowid = Controller.AddRow(sign);
            _rowIndex = rowid;
        }

        private void FrmDocModel_Load(object sender, EventArgs e)
        {
            this.tvtype.Nodes.Clear();
            ControlsEnabled(false);
            TreeNode node = Controller.Bind_tvtype(0, Convert.ToInt32(_currentUser.EmployeeID), Convert.ToInt32(_currentDept.DeptID));
            tvtype.Nodes.Add(node);
            tvtype.SelectedNode = node;
            node.Expand();
            this.amount.TextFormatStyle = GWI.HIS.Windows.Controls.TextFormatStyle.Numberic;
            this.frist_times.TextFormatStyle = GWI.HIS.Windows.Controls.TextFormatStyle.Numberic;
            DataTable yf = Controller.GetYfName();
            if (yf == null || yf.Rows.Count == 1)
            {
                this.cbYf.Text = "全部药房";
                this.cbYf.Visible = false;
                this.lbyf.Visible = false;
            }
            else
            {
                this.cbYf.Visible = true;
                this.lbyf.Visible = true;
                this.cbYf.DisplayMember = "Name";
                this.cbYf.ValueMember = "Value"; 
                cbYf.DataSource = Controller.Get_dept_yfName(Convert.ToInt32(_currentDept.DeptID));
                this.cbYf.SelectedIndex = 0;
            }
        }

        private void ControlsEnabled(bool flag)
        {
            this.btnNew.Enabled = flag;
            this.btnSave.Enabled = flag;
        }
        //从表中找到最大的groupid
        private int findMax()
        {
            if (dtgrdModel.Rows.Count == 1)
            {
                return 1;
            }
            DataTable dt = (DataTable)dtgrdModel.DataSource;
            object obj = dt.Compute("max(groupid)+1", "");
            return Convert.ToInt32(HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(obj, "1"));
        }

        //使操作后光标定位在网格最后一行
        private void setPlace()
        {
            if (dtgrdModel == null || dtgrdModel.Rows.Count == 0)
            {
                return;
            }
            else
            {
                this.dtgrdModel.CurrentCell = dtgrdModel[2, dtgrdModel.Rows.Count - 1];
            }
        }
        #endregion

        #region 网格事件
        //网格赋值
        private void dtgrdModel_SelectCardRowSelected(object SelectedValue, ref bool stop, ref int customNextColumnIndex)
        {
            dtgrdModel.EndEdit();
            DataRow dr = (DataRow)SelectedValue;
            int colid;
            int rowid = this.dtgrdModel.CurrentCell.RowIndex;
            int columnid = this.dtgrdModel.CurrentCell.ColumnIndex;
            Controller.SelectCardBindData(rowid, columnid, dr, out  colid);
            if (colid != -1)
            {
                if (colid == 3)
                {
                    if (!Controller.IsGroupFirstRow((DataTable)dtgrdModel.DataSource, rowid))
                    {
                        dtgrdModel.CurrentCell = dtgrdModel[5, rowid];
                        dtgrdModel.CurrentCell = dtgrdModel[6, rowid];
                        dtgrdModel.CurrentCell = dtgrdModel[7, rowid];
                    }
                    dtgrdModel.CurrentCell = dtgrdModel[4, rowid];
                }
                customNextColumnIndex = colid;
            }
        }
        //勾选控制
        private void dtgrdModel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgrdModel == null || this.dtgrdModel.Rows.Count == 0 || this.dtgrdModel.CurrentCell == null)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {
                int rowid = e.RowIndex;
                int brow = rowid;
                int erow = rowid;
                if (rowid < 0)
                {
                    return;
                }
                DataTable dt = (DataTable)dtgrdModel.DataSource;
                Controller.XdControl(dt, rowid);
            }
        }
        //只读控制
        private void dtgrdModel_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dtgrdModel == null || this.dtgrdModel.Rows.Count == 0 || this.dtgrdModel.CurrentCell == null)
            {
                return;
            }
            if (this.dtgrdModel != null || this.dtgrdModel.Rows.Count != 0 || this.dtgrdModel.CurrentCell != null)
            {
                int rowid = dtgrdModel.CurrentCell.RowIndex;
                int colid = dtgrdModel.CurrentCell.ColumnIndex;
                Controller.SettingReadOnly(colid, rowid);
                DataTable dt = (DataTable)dtgrdModel.DataSource;
                if (dt.Rows[rowid]["item_type"] == DBNull.Value || dt.Rows[rowid]["item_type"].ToString() == "0")
                {
                    return;
                }
                if (Convert.ToInt32(dt.Rows[rowid]["item_type"].ToString()) <= 2)
                {
                    Controller.GetDwType(Convert.ToInt32(dt.Rows[rowid]["item_id"].ToString()), Convert.ToInt32(dt.Rows[rowid]["item_type"].ToString()));
                }
            }
        }
        //回车事件
        private void dtgrdModel_DataGridViewCellPressEnterKey(object sender, int colIndex, int rowIndex, ref bool jumpStop)
        {
            this.chkEdit.Checked = false;
            if (this.dtgrdModel == null || this.dtgrdModel.Rows.Count == 0 || this.dtgrdModel.CurrentCell == null)
            {
                return;
            }


            if (colIndex == this.order_struc.Index && rowIndex == (this.dtgrdModel.RowCount - 1))
            {
                AddRow(this.dtgrdModel, 1);
                dtgrdModel["group_id", _rowIndex].Value = DBNull.Value;
                dtgrdModel.CurrentCell = this.dtgrdModel[0, _rowIndex];
            }
            else //update by heyan 2010.10.22 录中草药时，由于判断是否是第一组的和医嘱界面不同，导致输到第二个中草药就只出材料了
            {
                DataTable dt = (DataTable)dtgrdModel.DataSource;
                if (colIndex >= 4 && !Controller.IsGroupFirstRow(dt, rowIndex))
                {
                    dt.Rows[rowIndex]["order_frenquecy"] = dt.Rows[rowIndex - 1]["order_frenquecy"].ToString();
                    dt.Rows[rowIndex]["order_usage"] = dt.Rows[rowIndex - 1]["order_usage"].ToString();
                    dt.Rows[rowIndex]["frist_times"] = dt.Rows[rowIndex - 1]["frist_times"].ToString();
                    dt.Rows[rowIndex]["presamount"] = dt.Rows[rowIndex - 1]["presamount"].ToString();
                    AddRow(this.dtgrdModel, 1);
                    dtgrdModel["group_id", _rowIndex].Value = DBNull.Value;
                    dtgrdModel.CurrentCell = this.dtgrdModel[0, _rowIndex];
                }
            }
            
           
        }
        //当一组中的第一条值改变时，同组的一起改变
        private void dtgrdModel_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgrdModel == null || this.dtgrdModel.Rows.Count == 0 || this.dtgrdModel.CurrentCell == null)
            {
                return;
            }
            if (dtgrdModel != null && dtgrdModel.CurrentCell != null)
            {
                DataTable dt = (DataTable)dtgrdModel.DataSource;
                int rowid = dtgrdModel.CurrentCell.RowIndex;
                int colid = dtgrdModel.CurrentCell.ColumnIndex;
                if (colid == 7 || colid == 8)
                {
                    string name = dtgrdModel.Columns[colid].DataPropertyName;
                    Controller.ChangeValue((DataTable)dtgrdModel.DataSource, rowid, name);
                }
            }
        }
        private void dtgrdModel_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        //重绘事件
        private void dtgrdModel_Paint(object sender, PaintEventArgs e)
        {
            if (dtgrdModel == null || dtgrdModel.Rows.Count == 0)
            {
                return;
            }
            DataTable dt = (DataTable)dtgrdModel.DataSource;
            Controller.PaintView(dtgrdModel, dt, e, 0);
        }
        //数字和小数输入范围控制
        private void dtgrdModel_DataGridViewCellKeyPress(object sender, KeyPressEventArgs e, ref bool handle)
        {
            if (dtgrdModel == null || dtgrdModel.Rows.Count == 0 || dtgrdModel.CurrentCell == null)
            {
                return;
            }
            int rowid = dtgrdModel.CurrentCell.RowIndex;
            int colid = dtgrdModel.CurrentCell.ColumnIndex;
            if (colid == 7)
            {
                handle = Controller.NumInputControl((int)e.KeyChar, 0);
            }
            if (colid == 3)
            {
                handle = Controller.NumInputControl((int)e.KeyChar, 1);
            }
        }
        #endregion

        #region  模板信息数据
        public DataTable BindDocModelData
        {
            get
            {
                return (DataTable)this.dtgrdModel.DataSource;
            }
            set
            {
                this.dtgrdModel.AutoGenerateColumns = false;
                this.dtgrdModel.DataSource = value;
            }
        }
        #endregion

        #region 右键事件
        private void 新增类别ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tvtype.SelectedNode.ImageIndex == 15)
            {
                MessageBox.Show("处方下面不能添加类型");
                return;
            }
            FrmNew fn = new FrmNew("请输入新类型的名称");
            fn.ShowDialog();
            if (!fn.IsOk)
            {
                return;
            }
            if (fn.typename == "")
            {
                MessageBox.Show("类别名称不能为空");
                return;
            }
            TreeNode node = new TreeNode();
            node.Text = fn.typename;
            _typename = fn.typename;
            node.ImageIndex = 14;
            tvtype.SelectedNode.Nodes.Add(node);
            HIS.Model.ZY_DOC_ORDERMODEL model = new HIS.Model.ZY_DOC_ORDERMODEL();
            model.MODEL_LEVEL = level;
            model.MODEL_NAME = _typename;
            model.MODEL_TYPE = 0;
            model.P_ID = Convert.ToInt32(this.tvtype.SelectedNode.Tag);
            model.WARD_ID = "";
            model.CREATE_DATE = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            model.CREATE_DEPT = (int)_currentDept.DeptID;
            model.CREATE_DOC = (int)_currentUser.EmployeeID;
            model.DELETE_FLAG = 0;
            model.UPDATE_DATE = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            node.Tag = Controller.SaveModel(model);
            //node.Tag = Controller.Get_maxmodelid();
            tvtype.ExpandAll();
        }
        private void 新增模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tvtype.SelectedNode.ImageIndex == 15)
            {
                MessageBox.Show("处方下面不能添加处方");
                return;
            }
            FrmNew fn = new FrmNew("请输入新模板的名称");
            fn.ShowDialog();
            if (!fn.IsOk)
            {
                return;
            }
            TreeNode node = new TreeNode();
            if (fn.typename == "")
            {
                MessageBox.Show("模板名不能为空");
                return;
            }
            node.Text = fn.typename;
            _typename = fn.typename;
            node.ImageIndex = 15;
            tvtype.SelectedNode.Nodes.Add(node);
            HIS.Model.ZY_DOC_ORDERMODEL model = new HIS.Model.ZY_DOC_ORDERMODEL();
            model.MODEL_LEVEL = level;
            model.MODEL_NAME = _typename;
            model.MODEL_TYPE = 1;
            model.P_ID = Convert.ToInt32(this.tvtype.SelectedNode.Tag);
            model.WARD_ID = "";
            model.CREATE_DATE = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            model.CREATE_DEPT = (int)_currentDept.DeptID;
            model.CREATE_DOC = (int)_currentUser.EmployeeID;
            model.DELETE_FLAG = 0;
            model.UPDATE_DATE = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            node.Tag = Controller.SaveModel(model);
            tvtype.ExpandAll();
        }
        private void 删除结点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvtype.SelectedNode == null)
            {
                return;
            }
            if (Controller.DelNode())
            {
                tvtype.Nodes.Remove(tvtype.SelectedNode);
            }
        }
        private void 修改名称ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvtype.SelectedNode == null)
            {
                return;
            }
            FrmNew fn = new FrmNew("请输修改后的名称");
            fn.ShowDialog();
            if (fn.typename == null)
            {
                this.tvtype.SelectedNode.Text = this.tvtype.SelectedNode.Text;
                return;
            }
            else
            {
                Controller.UpDateNode(fn.typename);
                this.tvtype.SelectedNode.Text = fn.typename;
            }
        }
        #endregion

        #region 树点击事件
        private void tvlevel_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.tvtype.Nodes.Clear();
            this.dtgrdModel.DataSource = null;
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
            TreeNode node = Controller.Bind_tvtype(level, Convert.ToInt32(_currentUser.EmployeeID), Convert.ToInt32(_currentDept.DeptID));
            tvtype.Nodes.Add(node);
            tvtype.SelectedNode = node;
            node.Expand();
            tvlevel.ExpandAll();
            tvtype.ExpandAll();
        }
        private void tvtype_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.tvtype.SelectedNode == null)
            {
                return;
            }
            if (this.tvtype.SelectedNode.ImageIndex == 15)
            {
                this.tbModelName.Text = tvtype.SelectedNode.Text;
                this.ControlsEnabled(true);
                this.dtgrdModel.DataSource = null;
                Controller.GetModelData();
                this.setPlace();
            }
        }
        #endregion

        #region 右键事件
        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dtgrdModel.RowCount; i++)
            {
                // Controller.CellXD(i, false);
                Controller.CellXD(i, false, (DataTable)dtgrdModel.DataSource);
            }
        }
        private void 反选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dtgrdModel.RowCount; i++)
            {
                Controller.CellXD(i, true, (DataTable)dtgrdModel.DataSource);
                // Controller.CellXD(i, true);
            }
        }
        private void 删除一行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtgrdModel.CurrentCell != null)
            {
                this.dtgrdModel.CurrentCellChanged -= new System.EventHandler(this.dtgrdModel_CurrentCellChanged);
                if (dtgrdModel[2, dtgrdModel.CurrentCell.RowIndex].Value.ToString() == "")
                {
                    Controller.OrderDelelte(1, dtgrdModel.CurrentCell.RowIndex);
                    return;
                }
                if (MessageBox.Show("确定要删除[" + dtgrdModel[2, dtgrdModel.CurrentCell.RowIndex].Value.ToString() + "]吗？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    Controller.OrderDelelte(1, dtgrdModel.CurrentCell.RowIndex);
                }
               // Controller.GetModelData();
                this.dtgrdModel.CurrentCellChanged += new System.EventHandler(this.dtgrdModel_CurrentCellChanged);
            }
            this.setPlace();
        }
        private void 增加一行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtgrdModel.Rows.Count == 0)
            {
                return;
            }
            int currentRow = dtgrdModel.CurrentCell.RowIndex;
            int order_type;
            if (dtgrdModel["item_name", currentRow].Value != null && dtgrdModel["item_name", currentRow].Value.ToString() != "")
            {

                DataTable tb = this.BindDocModelData;
                order_type = Convert.ToInt32(tb.Rows[currentRow]["item_type"].ToString().Trim());
                if (order_type > 3)
                {
                    DataTable tb2 = tb.Copy();
                    tb2.Rows.Clear();
                    for (int i = 0; i <= currentRow; i++)
                    {
                        tb2.Rows.Add(tb.Rows[i].ItemArray);
                    }
                    DataRow dr = tb2.NewRow();
                    dr["flag"] = 0;
                    dr["groupid"] = DBNull.Value;
                    dr["modellist_a1"] = 0;//标志。表示是右键新插入的行  

                    tb2.Rows.Add(dr);
                    for (int i = currentRow + 1; i < tb.Rows.Count; i++)
                    {
                        tb2.Rows.Add(tb.Rows[i].ItemArray);
                    }
                    this.BindDocModelData = null;
                    this.BindDocModelData = tb2;
                    Controller.getData(HIS.ZYDoc_BLL.ItemType.所有项目);
                    dtgrdModel.CurrentCell = dtgrdModel["item_name", currentRow + 1];
                    dtgrdModel_CurrentCellChanged(null, null);
                    return;
                }
                else
                {
                    DataTable tb1 = tb.Copy();
                    tb1.Rows.Clear();
                    for (int i = 0; i <= currentRow; i++)
                    {
                        tb1.Rows.Add(tb.Rows[i].ItemArray);
                    }
                    DataRow dr = tb1.NewRow();
                    dr["flag"] = 0;
                    dr["groupid"] = DBNull.Value;
                    dr["modellist_a1"] = 1;//标志。表示是右键新插入的行  
                    dr["group_id"] = tb.Rows[currentRow]["group_id"];
                    dr["XD"] = false;
                    tb1.Rows.Add(dr);
                    for (int i = currentRow + 1; i < tb.Rows.Count; i++)
                    {
                        tb1.Rows.Add(tb.Rows[i].ItemArray);
                    }
                    this.BindDocModelData = null;
                    this.BindDocModelData = tb1;
                    if (order_type == 0)
                    {
                        Controller.getData(HIS.ZYDoc_BLL.ItemType.物资);
                    }
                    if (order_type == 1 || order_type == 2)
                    {
                        Controller.getData(HIS.ZYDoc_BLL.ItemType.西药);
                    }
                    if (order_type == 3)
                    {
                        Controller.getData(HIS.ZYDoc_BLL.ItemType.草药);
                    }
                    if (order_type > 3)
                    {
                        Controller.getData(HIS.ZYDoc_BLL.ItemType.所有项目);
                    }                  
                    dtgrdModel.CurrentCell = dtgrdModel["item_name", currentRow + 1];
                    dtgrdModel_CurrentCellChanged(null, null);
                }
            }

        }

        //刷新选项卡
        private void 刷新选项卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = PublicStaticFun.WaitCursor();
            Controller.LoadINFO();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region 工具栏事件
        //新开
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (this.tvtype.SelectedNode.ImageIndex == 14)
            {
                MessageBox.Show("请从左边选择模板或新建一个模板");
                return;
            }
            this.chkEdit.Checked = false;
            AddRow(this.dtgrdModel, 0);
            dtgrdModel["group_id", _rowIndex].Value = findMax().ToString();
            dtgrdModel.CurrentCell = this.dtgrdModel[2, _rowIndex];
        }
        // 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dtgrdModel == null || dtgrdModel.Rows.Count == 0)
            {
                return;
            }
            dtgrdModel.EndEdit();
            this.chkEdit.Checked = false;
            try
            {
                this.Cursor = PublicStaticFun.WaitCursor();
                HIS.ZYDoc_BLL.WrongDecline wrong = Controller.SaveModelList();
                if (wrong.err != "0")
                {
                    MessageBox.Show(wrong.err);
                    this.dtgrdModel.CurrentCell = dtgrdModel[wrong.colid, wrong.rowid];
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("保存成功");
                    Controller.GetModelData();
                    this.Cursor = Cursors.Default;
                    this.setPlace();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        //删除
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dtgrdModel == null || dtgrdModel.Rows.Count == 0 || dtgrdModel.CurrentCell == null)
            {
                return;
            }
            this.dtgrdModel.CurrentCellChanged -= new System.EventHandler(this.dtgrdModel_CurrentCellChanged);
            this.chkEdit.Checked = false;
            int rowid = dtgrdModel.CurrentCell.RowIndex;
            DataTable dt = (DataTable)dtgrdModel.DataSource;
            int i = 0;
            for (i = 0; i < dt.Rows.Count; i++)
            {
                if ((bool)dt.Rows[i]["XD"] == true)
                {
                    if (MessageBox.Show("确定要删除选定的医嘱吗？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        Controller.OrderDelelte(0, rowid);
                       // Controller.GetModelData();
                        this.setPlace();
                    }
                    break;
                }
            }          
            this.dtgrdModel.CurrentCellChanged += new System.EventHandler(this.dtgrdModel_CurrentCellChanged);
        }
        //刷新
        private void btnBrush_Click(object sender, EventArgs e)
        {
            Controller.GetModelData();
            this.chkEdit.Checked = false;
            this.setPlace();
        }
        private void btnQuit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        //修改　
        private void btnup_Click(object sender, EventArgs e)
        {
            if (dtgrdModel == null || dtgrdModel.Rows.Count == 0 || dtgrdModel.CurrentCell == null)
            {
                return;
            }
            int rowid = dtgrdModel.CurrentCell.RowIndex;
            int colid = dtgrdModel.CurrentCell.ColumnIndex;
            DataTable dt = (DataTable)dtgrdModel.DataSource;
            if (dt.Rows[rowid]["flag"].ToString() == "1") //已经保存的
            {
                int beginNum = rowid;
                int endNum = rowid;
                Controller.FindModelBeginEnd(rowid, dt, ref beginNum, ref  endNum);
                for (int i = beginNum; i <= endNum; i++)
                {
                    dt.Rows[i]["flag"] = 2; //修改标志
                    HIS.Model.ZY_DOC_ORDERMODELLIST_E zyoc = new HIS.Model.ZY_DOC_ORDERMODELLIST_E();
                    zyoc = (HIS.Model.ZY_DOC_ORDERMODELLIST_E)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject((DataTable)dtgrdModel.DataSource, rowid, zyoc);
                    Controller.ShowRowColor(zyoc, i, colid);
                }
            }
            this.chkEdit.Checked = false;
        }
        //模板应用
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (dtgrdModel == null)
            {
                return;
            }
            DataTable dt = this.BindDocModelData;
            lists = Controller.ModelApply(dt, 0, dt.Rows.Count);
            if (lists == null || lists.Count == 0)
            {
                MessageBox.Show("还没有选择医嘱,或者选择的模板医嘱已被药房禁用或没有库存");
            }
            else
            {
                this.Close();
            }
        }
        //全选
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (dtgrdModel == null || dtgrdModel.Rows.Count == 0)
            {
                return;
            }
            for (int i = 0; i < this.dtgrdModel.RowCount; i++)
            {
                Controller.CellXD(i, false, (DataTable)dtgrdModel.DataSource);
            }
        }
        //反选
        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            if (dtgrdModel == null || dtgrdModel.Rows.Count == 0)
            {
                return;
            }
            for (int i = 0; i < this.dtgrdModel.RowCount; i++)
            {
                Controller.CellXD(i, true, (DataTable)dtgrdModel.DataSource);
            }
        }
        //增加脚注
        private void btnjz_Click(object sender, EventArgs e)
        {
            if (dtgrdModel == null || dtgrdModel.Rows.Count == 0 || dtgrdModel.CurrentCell == null)
            {
                return;
            }
            int nrow = dtgrdModel.CurrentCell.RowIndex;
            int ncol = dtgrdModel.CurrentCell.ColumnIndex;
            DataTable tb = new DataTable();
            tb = (DataTable)dtgrdModel.DataSource;
            if (tb.Rows[nrow]["item_name"] == System.DBNull.Value)
            {
                return;
            }
            if (Convert.ToInt32(tb.Rows[nrow]["item_type"].ToString()) != 3)
            {
                MessageBox.Show("该医嘱不属于中草药");
                return;
            }
            HIS_ZYDocManager.日常业务.FrmJZ jz = new HIS_ZYDocManager.日常业务.FrmJZ();
            jz.ShowDialog();
            string note = jz.note;
            note = jz.note;
            if (note.Trim() != "")
            {
                Controller.AddJz(nrow, note);
            }
        }
        //录说明性医嘱
        private void chkEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (dtgrdModel == null || dtgrdModel.Rows.Count == 0 || dtgrdModel.CurrentCell == null)
            {
                this.ItemNameReadOnly = true;
                dtgrdModel.HideSelectionCardWhenCustomInput = false;
                return;
            }
            int rowindex = dtgrdModel.CurrentCell.RowIndex;
            int colindex = dtgrdModel.CurrentCell.ColumnIndex;
            if (chkEdit.Checked == true)
            {
                MessageBox.Show("修改医嘱内容状态，不产生新的医嘱费用");
                this.ItemNameReadOnly = false;
                dtgrdModel.HideSelectionCardWhenCustomInput = true;
                DataTable dt = (DataTable)dtgrdModel.DataSource;
                if (dt.Rows[rowindex]["item_name"].ToString().Trim() == "")
                {
                    dt.Rows[rowindex]["item_name"] = dtgrdModel[2, rowindex].Value.ToString();
                    dt.Rows[rowindex]["flag"] = 0;
                    dt.Rows[rowindex]["item_type"] = 7;
                }
                else
                {
                    if (dt.Rows[rowindex]["flag"].ToString().Trim() == "1")
                    {
                        dt.Rows[rowindex]["flag"] = 2;
                    }
                    dt.Rows[rowindex]["item_name"] = dtgrdModel[2, rowindex].Value.ToString();
                }
            }
            else
            {
                this.ItemNameReadOnly = true;
                dtgrdModel.HideSelectionCardWhenCustomInput = false;
            }
            dtgrdModel.CurrentCell = dtgrdModel[2, rowindex];
        }
        #endregion

        //快捷键
        private void FrmDocModel_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F3:	//新开
                    btnNew_Click(null, null);
                    break;
                case Keys.F5:	//保存
                    btnSave_Click(null, null);
                    break;
                case Keys.F4:	//删除
                    btnDel_Click(null, null);
                    break;
                case Keys.F6:	//刷新
                    btnBrush_Click(null, null);
                    break;
                case Keys.F7:	//应用
                    btnApply_Click(null, null);
                    break;
                case Keys.F8://修改
                    btnup_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        #region 树展开事件，使得打开默认展开
        private void tvtype_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.Expand();
        }
        #endregion

        #region 药房选择
        private void cbYf_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller.YfSelect();
        }
        #endregion

        private void tvtype_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point ClickPoint = new Point(e.X, e.Y);
                TreeNode CurrentNode = tvtype.GetNodeAt(ClickPoint);
                if (CurrentNode != null)//判断你点的是不是一个节点...
                {
                    this.tvtype.SelectedNode = CurrentNode;
                }
            }
        }
    }
}
