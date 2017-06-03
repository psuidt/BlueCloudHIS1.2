using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZY_BLL.DataModel;
using HIS.ZY_BLL;
using HIS.ZY_BLL.ObjectModel.BaseData;


namespace HIS_ZYManager
{
    public partial class FrmPresManager : GWI.HIS.Windows.Controls.BaseMainForm,Action.IFrmPresManagerView
    {
        //private FilterType _filterType;			//选项卡条件过滤类别
        //private SearchType _searchType;
        private int _rowIndex;    
        private Action.PresType presType;
        private Action.FrmPresManagerController Controller;
        // 0,长期，1，临时
        private int presKind = 0;
        // 长期账单和临时账单的数据网格控件
        private GWI.HIS.Windows.Controls.DataGridViewEx _DataGridViewEx;
        private User _currentUser;
        private Deptment _currentDept;
        private Action.SearchPatList _searchPatList;
        // 病人信息
        List<ZY_PatList> zypatlist = null;

        #region 构造函数
        public FrmPresManager()
        {
            InitializeComponent();
        }
        //[20100513.1.02]
        public FrmPresManager(long currentUserId, long currentDeptId, string chineseName,int _type)
        {

            InitializeComponent();
            this.Text = chineseName;
            this.FormTitle = chineseName;
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);

            this.lblongFee.Text = "0.0000";
            this.lbshortFee.Text = "0.0000";

            if (_type == 0)
            {
                presType = Action.PresType.划价;
            }
            else if (_type == 1)
            {
                presType = Action.PresType.记账;
            }

            this.ControlsEnabled(Action.PresType.默认);

            Controller = new HIS_ZYManager.Action.FrmPresManagerController(this);

            presKind = 0;
            _DataGridViewEx = this.dtgrdPresc;

        }
        //[20100513.1.02]
        public FrmPresManager(long currentUserId, long currentDeptId, string chineseName, int _type,bool IsOper)
        {

            InitializeComponent();
            this.Text = chineseName;
            this.FormTitle = chineseName;
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);

            this.lblongFee.Text = "0.0000";
            this.lbshortFee.Text = "0.0000";

            if (_type == 0)
            {
                presType = Action.PresType.划价;
            }
            else if (_type == 1)
            {
                presType = Action.PresType.记账;
            }

            this.ControlsEnabled(Action.PresType.默认);
            this.checkBox1.Checked = true;
            Controller = new HIS_ZYManager.Action.FrmPresManagerController(this,IsOper);

            presKind = 0;
            _DataGridViewEx = this.dtgrdPresc;

        }
        //[20100513.1.02]
        public FrmPresManager(long currentUserId, long currentDeptId, string chineseName, int _type,string CureNO)
        {

            InitializeComponent();
            this.Text = chineseName;
            this.FormTitle = chineseName;
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);

            this.lblongFee.Text = "0.0000";
            this.lbshortFee.Text = "0.0000";

            if (_type == 0)
            {
                presType = Action.PresType.划价;
            }
            else if (_type == 1)
            {
                presType = Action.PresType.记账;
            }

            this.ControlsEnabled(Action.PresType.默认);
            this.tbInpatNo.Text = CureNO;

            Controller = new HIS_ZYManager.Action.FrmPresManagerController(this,CureNO);

            presKind = 0;
            _DataGridViewEx = this.dtgrdPresc;

            this.checkBox1.Checked = true;
            ControlsEnabled(presType);

        }
        #endregion

        #region 其他控件事件
        //Tab改变
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 0)
            {
                presKind = 0;
                _DataGridViewEx = this.dtgrdPresc;
            }
            else
            {
                presKind = 1;
                _DataGridViewEx = this.ShortdtgrdPresc;
            }
            //Controller.GetPresData(presKind);
        }
        //刷新
        private void llabrush_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //[20100513.1.02] 加入手术病人选项
            Controller.BrushPatList(this.checkBox1.Checked);
        }
        //双击病人列表
        private void lvPatList_DoubleClick(object sender, EventArgs e)
        {
            this.ControlsEnabled(presType);
            Controller.GetPatlist();
            this.tabControl1.SelectedIndex = 0;
            Controller.GetPresData(presKind);
            this.tabControl1.SelectedIndex = 1;
            Controller.GetPresData(presKind);
        }
        //窗体快捷键
        private void FrmPresManager_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.tabControl1.Enabled == false) return;

            switch (e.KeyData)
            {
                case Keys.F3:	//新开处方
                    toolbtNew_Click(null, null);
                    break;
                case Keys.F4:	//修改处方
                    //toolbtAlter_Click(null, null);
                    break;
                case Keys.F5:	//刷新处方
                    toolbtBrush_Click(null, null);
                    break;
                case Keys.F6:	//删除处方
                    toolbtDel_Click(null, null);
                    break;
                case Keys.F7:	//导入长期医嘱
                    toolbtLoad_Click(null, null);
                    break;
                case Keys.F8:	//划价
                    toolbtDraw_Click(null, null);
                    break;
                case Keys.F9:	//记账
                    toolbtMark_Click(null, null);
                    break;
               
                case Keys.F10:  //勾中
                    dtgrdPresc_CellClick(null, new DataGridViewCellEventArgs(0,_DataGridViewEx.CurrentCell.RowIndex));
                    break;
                case Keys.F11:	//长期
                    this.tabControl1.SelectedIndex = 0;
                    break;
                case Keys.F12:	//临时
                    this.tabControl1.SelectedIndex = 1;
                    break;               
                default:
                    break;
            }
        }
        //显示科室
        private void chbDept_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chbDept.Checked)
            {
                this.cbDept.Enabled = true;
            }
            else
            {
                this.cbDept.Enabled = false;
            }
        }
        //根据住院号搜索
        private void tbInpatNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                try
                {
                    if (Controller.InPatKeyDown())
                    {
                        ControlsEnabled(presType);
                        this.tabControl1.SelectedIndex = 0;
                        Controller.GetPresData(presKind);
                        this.tabControl1.SelectedIndex = 1;
                        Controller.GetPresData(presKind);
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message,"提示",MessageBoxButtons.OK,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1);
                }
            }
        }
        #endregion

        #region IView 成员

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
            this.tbPresDoc.SetSelectionCardDataSource(_dataSet.Tables["User"]);
            this.dtgrdPresc.SetSelectionCardDataSource(_dataSet.Tables["ITEM_DICTIONARY"], ZJM.Index);
            this.ShortdtgrdPresc.SetSelectionCardDataSource(_dataSet.Tables["ITEM_DICTIONARY"], ZJM1.Index);
            this.cbyfDept.DataSource = _dataSet.Tables["yfDept"];
            this.cbyfDept.DisplayMember = "deptname";
            this.cbyfDept.ValueMember = "deptid";
            this.cbyfDept.SelectedValue = -1;
        }

        public ZY_PatList zy_patlist_get
        {
            get
            {
                return (ZY_PatList)this.lvPatList.SelectedItems[0].Tag;
            }
        }

        public HIS_ZYManager.Action.SearchPatList searchPatList
        {
            get
            {
                _searchPatList = new HIS_ZYManager.Action.SearchPatList();
                if (chbDept.Checked)
                {
                    _searchPatList.DeptCode = ((DataRowView)this.cbDept.SelectedValue).Row["code"].ToString().Trim();
                }

                _searchPatList.rbIn = true;
                return _searchPatList;
            }
        }

        public DataTable cbDept_set
        {
            set
            {
                DataTable dt = value;
                this.cbDept.DataSource = dt;
                this.cbDept.DisplayMember = "name";
            }
        }
        //zenhgao [20100513.1.02]
        public List<ZY_PatList> lvPatList_set
        {
            set
            {
                this.lvPatList.Items.Clear();
                zypatlist = value;
                for (int i = 0; i < zypatlist.Count; i++)
                {
                    //if ((this.cbsex1.Checked == true && this.cbsex2.Checked == true) || (this.cbsex1.Checked == false && this.cbsex2.Checked == false))
                    //{
                    ListViewItem lstViewItem = new ListViewItem();
                    lstViewItem.SubItems.Clear();
                    lstViewItem.Tag = zypatlist[i];
                    lstViewItem.SubItems[0].Text = zypatlist[i].CureNo;
                    lstViewItem.SubItems.Add(zypatlist[i].patientInfo.PatName);
                    lstViewItem.SubItems.Add(zypatlist[i].patientInfo.PatSex);
                    lstViewItem.SubItems.Add(zypatlist[i].patientInfo.PatBriDate.ToString("yyyy-MM-dd"));
                    lstViewItem.SubItems.Add(zypatlist[i].CureDate.ToString("yyyy-MM-dd"));
                    this.lvPatList.Items.Add(lstViewItem);
                    //}
                    //else
                    //{
                    //    if (zypatlist[i].patientInfo.PatSex == "男" && this.cbsex1.Checked == true)
                    //    {
                    //        ListViewItem lstViewItem = new ListViewItem();
                    //        lstViewItem.SubItems.Clear();
                    //        lstViewItem.Tag = zypatlist[i];
                    //        lstViewItem.SubItems[0].Text = zypatlist[i].CureNo;
                    //        lstViewItem.SubItems.Add(zypatlist[i].patientInfo.PatName);
                    //        lstViewItem.SubItems.Add(zypatlist[i].patientInfo.PatSex);
                    //        lstViewItem.SubItems.Add(zypatlist[i].patientInfo.PatBriDate.ToString("yyyy-MM-dd"));
                    //        lstViewItem.SubItems.Add(zypatlist[i].CureDate.ToString("yyyy-MM-dd"));
                    //        this.lvPatList.Items.Add(lstViewItem);
                    //    }
                    //    if (zypatlist[i].patientInfo.PatSex == "女" && this.cbsex2.Checked == true)
                    //    {
                    //        ListViewItem lstViewItem = new ListViewItem();
                    //        lstViewItem.SubItems.Clear();
                    //        lstViewItem.Tag = zypatlist[i];
                    //        lstViewItem.SubItems[0].Text = zypatlist[i].CureNo;
                    //        lstViewItem.SubItems.Add(zypatlist[i].patientInfo.PatName);
                    //        lstViewItem.SubItems.Add(zypatlist[i].patientInfo.PatSex);
                    //        lstViewItem.SubItems.Add(zypatlist[i].patientInfo.PatBriDate.ToString("yyyy-MM-dd"));
                    //        lstViewItem.SubItems.Add(zypatlist[i].CureDate.ToString("yyyy-MM-dd"));
                    //        this.lvPatList.Items.Add(lstViewItem);
                    //    }
                    //}

                }
            }
        }

        public int yfDeptID
        {
            get
            {
                return Convert.ToInt32(this.cbyfDept.SelectedValue);
            }
        }

        public void ReLoadDurgData(DataTable _dt)
        {
            this.dtgrdPresc.SetSelectionCardDataSource(_dt, ZJM.Index);
            this.ShortdtgrdPresc.SetSelectionCardDataSource(_dt, ZJM1.Index);
        }

        #endregion

        #region IFrmPresManagerView 病人信息处方数据

        public HIS_ZYManager.Action.PresType PresType
        {
            get
            {
                return presType;
            }
        }

        public DateTime PresDate
        {
            get
            {
                return this.dtpPresDate.Value;
            }
        }

        public string PresDocCode
        {
            get
            {
                if (this.tbPresDoc.MemberValue == null)
                    return null;
                return tbPresDoc.MemberValue.ToString();
            }
            set
            {
                this.tbPresDoc.MemberValue = value;
            }
        }

        public string PresDocName
        {
            get
            {
                return this.tbPresDoc.Text;
            }
        }

        public string InpatNo
        {
            get
            {
                return this.tbInpatNo.Text;
            }
            set
            {
                this.tbInpatNo.Text = value;
            }
        }

        public ZY_PatList BindPatControlData
        {
            set
            {
                this.tbInpatNo.Text = value.CureNo;
                this.tbPatName.Text = value.patientInfo.PatName;
                this.cbsex.Text = value.patientInfo.PatSex;
                this.lbtype.Text = value.patientInfo.ACCOUNTTYPE;
                this.tbage.Text = HIS.SYSTEM.PubicBaseClasses.Age.GetAgeString(value.patientInfo.PatBriDate, XcDate.ServerDateTime, 0);
                this.tbdoc.Text = BaseNameFactory.GetName(baseNameType.用户名称,value.CureDocCode);//?
                this.tbdept.Text = BaseNameFactory.GetName(baseNameType.科室名称,value.CurrDeptCode);//?
                this.tbBedNO.Text = value.BedCode;
            }
        }

        public PatFee BindPatFeeControlData
        {
            set
            {
                this.lbChargeFee.Text = value.chargeFee.ToString();
                this.lbCostFee.Text = value.costFee.ToString();
                this.lbExtFee.Text = value.surplusFee.ToString();
            }
        }


        public DataTable BindLongPresControlData
        {
            get
            {
                return (DataTable)this.dtgrdPresc.DataSource;
            }
            set
            {
                this.dtgrdPresc.AutoGenerateColumns = false;
                this.dtgrdPresc.DataSource = value;
            }
        }

        public DataTable BindShortPresControlData
        {
            get
            {
                return (DataTable)this.ShortdtgrdPresc.DataSource;
            }
            set
            {
                this.ShortdtgrdPresc.AutoGenerateColumns = false;
                this.ShortdtgrdPresc.DataSource = value;
            }
        }

        #endregion

        #region IFrmPresManagerView 成员费用


        string HIS_ZYManager.Action.IFrmPresManagerView.lblongFee
        {
            set {
                this.lblongFee.Text = value;
            }
        }

        string HIS_ZYManager.Action.IFrmPresManagerView.lbshortFee
        {
            set
            {
                this.lbshortFee.Text = value;
            }
        }

        #endregion

        #region IFrmPresManagerView 成员只读
        public bool ItemIDReadOnly
        {
            set
            {
                ZJM.ReadOnly = value;
                ZJM1.ReadOnly = value;
            }
        }

        public bool BigNumReadOnly
        {
            set {
                BigNum.ReadOnly = value;
                BigNum1.ReadOnly = value;
            }
        }

        public bool SmallNumReadOnly
        {
            set {
                SmallNum.ReadOnly = value;
                SmallNum1.ReadOnly = value;
            }
        }
        #endregion

        #region IFrmPresManagerView 成员颜色
        public HIS_ZYManager.Action.PresColor presColor
        {
            set
            {
                if (value.colIndex == -1)
                {
                    //颜色
                    for (int r = 0; r < _DataGridViewEx.Columns.Count; r++)
                    {
                        _DataGridViewEx.Rows[value.rowIndex].Cells[r].Style.ForeColor = value.ForeColor;
                        _DataGridViewEx.Rows[value.rowIndex].Cells[r].Style.BackColor = value.BackColor;
                    }
                }
                else
                {
                    _DataGridViewEx.Rows[value.rowIndex].Cells[value.colIndex].Style.ForeColor = value.ForeColor;
                    _DataGridViewEx.Rows[value.rowIndex].Cells[value.colIndex].Style.BackColor = value.BackColor;
                }
            }
        }
        #endregion

        #region IFrmPresManagerView 成员
        public FlatStyle XDEnabled
        {
            set {
                XD.FlatStyle = FlatStyle.Flat;
                XD1.FlatStyle = FlatStyle.Flat;
            }
        }
        #endregion

        #region 处方处理公共方法
        /// <summary>
        /// 窗体状态
        /// </summary>
        /// <param name="pres"></param>
        private void ControlsEnabled(Action.PresType pres)
        {

            if (pres == Action.PresType.默认)
            {
                this.tabControl1.Enabled = false;
                this.lbChargeFee.Text = "0";
                this.lbCostFee.Text = "0";
                this.lbExtFee.Text = "0";
                this.toolbtMark.Enabled = true;
                this.toolbtMark1.Enabled = true;
                //this.toolbtBack.Enabled = true;
                //this.toolbtBack1.Enabled = true;
            }
            else if (pres == Action.PresType.划价)
            {
                this.tabControl1.Enabled = true;
                this.toolbtMark.Visible = false;
                this.toolbtMark1.Visible = false;
                //this.toolbtBack.Visible = false;
                //this.toolbtBack1.Visible = false;
                this.记账CToolStripMenuItem.Visible = false;
            }
            else if (pres == Action.PresType.记账)
            {
                this.tabControl1.Enabled = true;
                this.toolbtMark.Visible = true;
                this.toolbtMark1.Visible = true;
                //this.toolbtBack.Visible = true;
                //this.toolbtBack1.Visible = true;
                this.记账CToolStripMenuItem.Visible = true;
            }
        }
        private void AddRow(GWI.HIS.Windows.Controls.DataGridViewEx dgv)
        {
            dgv.Focus();
            int rowid = Controller.AddRow(presKind);
            _rowIndex = rowid;
        }
        private bool CheckPresDoc()
        {
            if (this.tbPresDoc.MemberValue == null || this.tbPresDoc.Text.Trim() == "")
            {
                MessageBox.Show("请先选择开方医生");
                this.tbPresDoc.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region 工具栏事件
        //新开
        private void toolbtNew_Click(object sender, EventArgs e)
        {
            if (CheckPresDoc())
            {
                AddRow(this._DataGridViewEx);
                _DataGridViewEx.CurrentCell = this._DataGridViewEx[1, _rowIndex];
            }
        }
        //刷新
        private void toolbtBrush_Click(object sender, EventArgs e)
        {
            Controller.GetPresData(presKind);
            //SettingReadOnly(this.dtgrdPresc,true);
        }
        //删除
        private void toolbtDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除记录吗？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                Controller.PresDel(presKind);
            }
        }
        //导入
        private void toolbtLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string message = Controller.PresLoad(presKind);
                if (message != null)
                {
                    MessageBox.Show(message+"请认真核对以上项目!!!!", "提示,请注意!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
                MessageBox.Show("费用导入成功,请认真核对！", "提示,请注意!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }
        //保存
        private void toolbtDraw_Click(object sender, EventArgs e)
        {
            int colid, rowid;
            string itemname;
            if (Controller.CheckPresData(presKind, out colid, out rowid, out itemname))
            {
                Controller.SavePresData(presKind);
                Controller.GetPresData(presKind);
                全选ToolStripMenuItem_Click(null, null);//保存后全选
            }
            else
            {
                if (itemname!=null)
                {
                    MessageBox.Show("[" + itemname + "]数量等于或者小于零！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this._DataGridViewEx.CurrentCell = _DataGridViewEx[colid, rowid];
                }
            }
        }
        //记账
        private void toolbtMark_Click(object sender, EventArgs e)
        {
            string message = null;
            if (!Controller.CheckPatCost())
            {
                MessageBox.Show("病人类型已发生更改，请重新刷新左边列表！","提示",MessageBoxButtons.OK,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
                return;
            }
            if (!Controller.CheckPresMark(presKind,out message))
            {
                if (MessageBox.Show(message + "库存不足，是否继续记账？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                {
                    return;
                }
            }
            Controller.PresMark(presKind);
        }
        //关闭
        private void toolbtClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 网格事件
        //赋值
        private void dtgrdPresc_SelectCardRowSelected(object SelectedValue, ref bool stop, ref int customNextColumnIndex)
        {

            DataRow dr = (DataRow)SelectedValue;
            int rowid = this._DataGridViewEx.CurrentCell.RowIndex;
            int newrowid = Controller.SelectCardBindData(presKind, rowid, dr);

            if (newrowid != rowid)
            {
                _DataGridViewEx.CurrentCell = this._DataGridViewEx[10, newrowid];
            }
        }
        //回车新开
        private void dtgrdPresc_DataGridViewCellPressEnterKey_1(object sender, int colIndex, int rowIndex, ref bool jumpStop)
        {
            if (colIndex == this.SmallNum.Index && rowIndex == (this._DataGridViewEx.RowCount - 1))
            {
                if (CheckPresDoc())
                    AddRow(this._DataGridViewEx);
            }
        }

        private void dtgrdPresc_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //e.Cancel = true;
        }
        //网格只读
        private void dtgrdPresc_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this._DataGridViewEx.CurrentCell != null)
            {
                int rowid = _DataGridViewEx.CurrentCell.RowIndex;
                int colid = _DataGridViewEx.CurrentCell.ColumnIndex;

                XD.ReadOnly = true;
                Controller.SettingReadOnly(presKind, colid, rowid);
            }
        }
        //计算金额
        private void dtgrdPresc_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int colIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;
            if (rowIndex > -1)
            {
                if (colIndex == this.BigNum.Index || colIndex == this.SmallNum.Index)
                {
                    Controller.CalculateFee(presKind, colIndex, rowIndex);
                }
            }
        }
        //勾选
        private void dtgrdPresc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Controller.CellXD(presKind, e.RowIndex,true);
            }
        }
        #endregion

        #region 右键菜单事件
        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _DataGridViewEx.RowCount; i++)
            {
                Controller.CellXD(presKind, i, false);
            }
        }

        private void 反选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _DataGridViewEx.RowCount; i++)
            {
                Controller.CellXD(presKind, i, true);
            }
        }

        private void 删除一行DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_DataGridViewEx.CurrentCell != null)
            {
                if (_DataGridViewEx[4, _DataGridViewEx.CurrentCell.RowIndex].Value.ToString() == "")
                {
                    Controller.PresDel(presKind, _DataGridViewEx.CurrentCell.RowIndex);
                    return;
                }
                if (MessageBox.Show("确定要删除[" + _DataGridViewEx[4, _DataGridViewEx.CurrentCell.RowIndex].Value.ToString() + "]吗？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    Controller.PresDel(presKind, _DataGridViewEx.CurrentCell.RowIndex);
                }
            }
        }

        private void 记账CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_DataGridViewEx.CurrentCell != null)
            {
                string message = null;
                if (!Controller.CheckPresMark(presKind, _DataGridViewEx.CurrentCell.RowIndex,out message))
                {
                    if (MessageBox.Show(message + "库存不足，是否继续记账？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                Controller.PresMark(presKind, _DataGridViewEx.CurrentCell.RowIndex);
            }
        }
        private void 重新加载数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.ReLoadDurgData();
            MessageBox.Show("重新加载数据成功！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void 修改处方医生ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.ChangePresDoc(presKind, _DataGridViewEx.CurrentCell.RowIndex);
        }

        #endregion     

        #region 检索病人 [20100513.1.02]
        private void cbsex_CheckedChanged(object sender, EventArgs e)
        {
            if (zypatlist != null)
            {
                this.lvPatList.Items.Clear();
                for (int i = 0; i < zypatlist.Count; i++)
                {
                    if ((this.cbsex1.Checked == true && this.cbsex2.Checked == true) || (this.cbsex1.Checked == false && this.cbsex2.Checked == false))
                    {
                        ListViewItem lstViewItem = new ListViewItem();
                        lstViewItem.SubItems.Clear();
                        lstViewItem.Tag = zypatlist[i];
                        lstViewItem.SubItems[0].Text = zypatlist[i].CureNo;
                        lstViewItem.SubItems.Add(zypatlist[i].patientInfo.PatName);
                        lstViewItem.SubItems.Add(zypatlist[i].patientInfo.PatSex);
                        lstViewItem.SubItems.Add(zypatlist[i].patientInfo.PatBriDate.ToString("yyyy-MM-dd"));
                        lstViewItem.SubItems.Add(zypatlist[i].CureDate.ToString("yyyy-MM-dd"));
                        this.lvPatList.Items.Add(lstViewItem);
                    }
                    else
                    {
                        if (zypatlist[i].patientInfo.PatSex == "男" && this.cbsex1.Checked == true)
                        {
                            ListViewItem lstViewItem = new ListViewItem();
                            lstViewItem.SubItems.Clear();
                            lstViewItem.Tag = zypatlist[i];
                            lstViewItem.SubItems[0].Text = zypatlist[i].CureNo;
                            lstViewItem.SubItems.Add(zypatlist[i].patientInfo.PatName);
                            lstViewItem.SubItems.Add(zypatlist[i].patientInfo.PatSex);
                            lstViewItem.SubItems.Add(zypatlist[i].patientInfo.PatBriDate.ToString("yyyy-MM-dd"));
                            lstViewItem.SubItems.Add(zypatlist[i].CureDate.ToString("yyyy-MM-dd"));
                            this.lvPatList.Items.Add(lstViewItem);
                        }
                        if (zypatlist[i].patientInfo.PatSex == "女" && this.cbsex2.Checked == true)
                        {
                            ListViewItem lstViewItem = new ListViewItem();
                            lstViewItem.SubItems.Clear();
                            lstViewItem.Tag = zypatlist[i];
                            lstViewItem.SubItems[0].Text = zypatlist[i].CureNo;
                            lstViewItem.SubItems.Add(zypatlist[i].patientInfo.PatName);
                            lstViewItem.SubItems.Add(zypatlist[i].patientInfo.PatSex);
                            lstViewItem.SubItems.Add(zypatlist[i].patientInfo.PatBriDate.ToString("yyyy-MM-dd"));
                            lstViewItem.SubItems.Add(zypatlist[i].CureDate.ToString("yyyy-MM-dd"));
                            this.lvPatList.Items.Add(lstViewItem);
                        }
                    }

                }
            }
        }
        //根据住院号检索
        private void inpatientNOTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (zypatlist != null)
                {
                    List<ZY_PatList> patlist = zypatlist.FindAll(x => x.CureNo == this.inpatientNOTextBox1.Text);

                    this.lvPatList.Items.Clear();

                    for (int i = 0; i < patlist.Count; i++)
                    {
                        ListViewItem lstViewItem = new ListViewItem();
                        lstViewItem.SubItems.Clear();
                        lstViewItem.Tag = patlist[i];
                        lstViewItem.SubItems[0].Text = patlist[i].CureNo;
                        lstViewItem.SubItems.Add(patlist[i].patientInfo.PatName);
                        lstViewItem.SubItems.Add(patlist[i].patientInfo.PatSex);
                        lstViewItem.SubItems.Add(patlist[i].patientInfo.PatBriDate.ToString("yyyy-MM-dd"));
                        this.lvPatList.Items.Add(lstViewItem);
                    }
                }
            }
        }
        //根据病人名称拼音码检索
        private void tbpat_name_TextChanged(object sender, EventArgs e)
        {
            if (zypatlist != null)
            {
                List<ZY_PatList> patlist = zypatlist.FindAll(x => (x.patientInfo.PYM.ToLower().Contains(this.tbpat_name.Text.Trim()) || x.patientInfo.PatName.Contains(this.tbpat_name.Text.Trim())));

                this.lvPatList.Items.Clear();

                for (int i = 0; i < patlist.Count; i++)
                {
                    ListViewItem lstViewItem = new ListViewItem();
                    lstViewItem.SubItems.Clear();
                    lstViewItem.Tag = patlist[i];
                    lstViewItem.SubItems[0].Text = patlist[i].CureNo;
                    lstViewItem.SubItems.Add(patlist[i].patientInfo.PatName);
                    lstViewItem.SubItems.Add(patlist[i].patientInfo.PatSex);
                    lstViewItem.SubItems.Add(patlist[i].patientInfo.PatBriDate.ToString("yyyy-MM-dd"));
                    this.lvPatList.Items.Add(lstViewItem);
                }
            }
        }
        #endregion

        private void cbyfDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Controller != null)
                Controller.ReLoadDurgData();
        }


       

       

        
    }
}
