using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Crownwood.Magic.Controls;
using Crownwood.Magic.Common;
using GWMHIS.BussinessLogicLayer.Forms;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZYDoc_BLL;
using HIS.ZY_BLL;

namespace HIS_ZYDocManager.日常业务
{
    public partial class BaseForm : GWI.HIS.Windows.Controls.BaseMainForm, Action.IFrmOrderManagerView
    {         
        private User _currentUser;
        private Deptment _currentDept;       
        private HIS.Model.ZY_PatList[] _zy_PatLists = null;       
        private int _rowIndex;  
        private string note;      
        private bool isClose = true;       
        private int level = 2;
        HIS.Model.ZY_PatList _zypatlist;
        public Action.FrmOrderManagerController Controller;
        private GWI.HIS.Windows.Controls.DataGridViewEx _DataGridViewEx;             
        private int OrderKind = 0; //0长期医嘱 1 临时医嘱   
        private DataTable yf = new DataTable();
        #region  构造函数
        public BaseForm(HIS.Model.ZY_PatList _patlist, long _userid, long _deptid)
        {
            InitializeComponent();
            _zypatlist = _patlist;
            _currentUser = new User(_userid);
            _currentDept = new Deptment(_deptid); 
            Controller = new HIS_ZYDocManager.Action.FrmOrderManagerController(this);
            this.InitData();
                      
        }
        private void BaseForm_Load(object sender, EventArgs e)
        {
           // tbOrder.TabPages.RemoveAt(2);
            this.InitList(0);
            if (_DataGridViewEx != null)
            {
                Controller.ColorPaint((DataTable)_DataGridViewEx.DataSource);
                this.SetPlace();
            }     
            this.Font = new Font("宋体", 9F);
            groupBox3.BackColor = GWI.HIS.Windows.Controls.CommonFun.DeepColor;
            panel11.BackColor = GWI.HIS.Windows.Controls.CommonFun.DeepColor;
            panel4.BackColor = GWI.HIS.Windows.Controls.CommonFun.DeepColor;
            #region  医生开医嘱时可以选择药房，如果只有一个药房就不显示药房选择框。如果有指定相应科室对应的药房，就默认是对应的药房，医生也可以根据需要选择药房
             yf = Controller.GetYfName();
             if (yf == null || yf.Rows.Count == 1)
             {
                 this.cbYf.Text = "全部药房";
                 this.cbYf.Visible = false;
                 this.grbyf. Visible = false;
             }
             else
             {
                 this.cbYf.Visible = true;
                 this.grbyf.Visible = true;
                 this.cbYf.DisplayMember = "Name";
                 this.cbYf.ValueMember = "Value";               
                 cbYf.DataSource = Controller.Get_dept_yfName(Convert.ToInt32(_currentDept.DeptID));
                 this.cbYf.SelectedIndex = 0;
             }
            #endregion
        }
        #endregion 

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
            this.dtgrdLong.SetSelectionCardDataSource(_dataSet.Tables["ITEM_DICTIONARYLONG"], itemname.Index);
            this.dtgrdLong.SetSelectionCardDataSource(_dataSet.Tables["Usage"], order_usage.Index);
            this.dtgrdLong.SetSelectionCardDataSource(_dataSet.Tables["Frequency"], frequency.Index);
            this.dtgrdLong.SetSelectionCardDataSource(_dataSet.Tables["Entrust"], order_struc.Index);

            this.dtgrdTemp.SetSelectionCardDataSource(_dataSet.Tables["ITEM_DICTIONARY"], itemname1.Index);
            this.dtgrdTemp.SetSelectionCardDataSource(_dataSet.Tables["Usage"], order_usage1.Index);
            this.dtgrdTemp.SetSelectionCardDataSource(_dataSet.Tables["Frequency"], frequency1.Index);
            this.dtgrdTemp.SetSelectionCardDataSource(_dataSet.Tables["Entrust"], order_struc1.Index);
            this.dtgrdTemp.SetSelectionCardDataSource(_dataSet.Tables["DwType"], unit1.Index);
        }
        public long currentUserId
        {
            set
            {
                _currentUser = new User(value);
            }
        }
        public long currentDeptId
        {
            set
            {
                _currentDept = new Deptment(value); ;
            }
        }
        public string chineseName
        {
            set
            {
                this.Text = value;
            }
        }
        public HIS.Model.ZY_PatList[] zy_PatLists
        {
            get
            {
                List<HIS.Model.ZY_PatList> zylist = new List<HIS.Model.ZY_PatList>();

                for (int i = 0; i < this.lvPatList.Items.Count; i++)
                {
                    if (this.lvPatList.Items[i].Checked)
                    {
                        zylist.Add((HIS.Model.ZY_PatList)this.lvPatList.Items[i].Tag);
                    }
                }
                _zy_PatLists = zylist.ToArray();
                return _zy_PatLists;
            }
        }
        public string GetYfIds
        {
            get
            {
                return (this.cbYf.SelectedValue == null ? -1 : this.cbYf.SelectedValue).ToString().Trim();
            }
        }
        public int GetOrderKind()
        {
            return OrderKind;
        }
        public int GetRowIndex()
        {
            return _rowIndex;
        }
        public void Plus(int i)
        {
            if (i == 0)
            {
                this.dtgrdLong.CurrentCellChanged -= new System.EventHandler(this.dtgrdLong_CurrentCellChanged);
            }
            if (i == 1)
            {
                this.dtgrdLong.CurrentCellChanged += new System.EventHandler(this.dtgrdLong_CurrentCellChanged);
            }
        }
        #endregion      

        #region IFrmOrderManagerView 病人信息处方数据
        public HIS.Model.ZY_PatList zy_patlist_get
        {
            get
            {
                return _zypatlist;
            }
            set
            {
                _zypatlist = value;
            }
        }
        public HIS.Model.ZY_PatList BindPatControlData
        {
            set
            {
                HIS_ZYDocManager.PatientControl patient = new PatientControl();
                this.inPatientPanel1.InPatientExtDB = patient.SetData(value);
            }
        }
        public DataTable BindLongOrderData
        {
            get
            {
                return (DataTable)this.dtgrdLong.DataSource;
            }
            set
            {
                this.dtgrdLong.AutoGenerateColumns = false;
                this.dtgrdLong.DataSource = value;
            }
        }
        public DataTable BindTempOrderData
        {
            get
            {
                return (DataTable)this.dtgrdTemp.DataSource;
            }
            set
            {
                this.dtgrdTemp.AutoGenerateColumns = false;
                this.dtgrdTemp.DataSource = value;
            }
        }
        #endregion

        #region IFrmOrderManagerView 成员颜色
        public HIS_ZYDocManager.Action.OrderColor OrderColor
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

        #region 成员只读
        public bool ItemNameReadOnly
        {
            set
            {
                itemname.ReadOnly = value;
                itemname1.ReadOnly = value;
            }
        }
        public bool AmountReadOnly
        {
            set
            {
                amount3.ReadOnly = value;
                amount1.ReadOnly = value;
            }
        }
        public bool PresAmountReadOnly
        {
            set
            {
                pres_amount.ReadOnly = value;
            }
        }
        public bool UnitReadOnly
        {
            set
            {
                unit3.ReadOnly = value;
                unit1.ReadOnly = value;
            }
        }
        public bool FrenQuencyReadOnly
        {
            set
            {
                frequency.ReadOnly = value;
                frequency1.ReadOnly = value;
            }
        }
        public bool UsageReadOnly
        {
            set
            {
                order_usage3.ReadOnly = value;
                order_usage1.ReadOnly = value;
            }
        }
        public bool FirstTimeReadOnly
        {
            set
            {
                firset_times.ReadOnly = value;
            }
        }
        public bool DropSperReadOnly
        {
            set
            {
                dropspec.ReadOnly = value;
                dropspec1.ReadOnly = value;
            }
        }
        public bool StrucReadOnly
        {
            set
            {
                order_struc3.ReadOnly = value;
                order_struc1.ReadOnly = value;
            }
        }
        #endregion 

        #region 出院病人医嘱查询
        private void linklbOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.BindLvPatList();
        }
        private void tabPlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lvPatList.Items.Clear();
            this.dtgrdLong.DataSource = null;
            this.dtgrdTemp.DataSource = null;
            if (tabPlist.SelectedIndex == 0)
            {
                this.radDoc.Checked = true;
                this.InitList(0);
            }
            else
            {
                this.cbdate.Checked = true;
                this.dtpBegin.Value = XcDate.ServerDateTime;
                this.dtpEnd.Value = XcDate.ServerDateTime; 
                this.lbout.Text = "0" + "人";
            }
        }    
        /// <summary>
        /// 绑定病人列表
        /// </summary>
        private void BindLvPatList()
        {            
            string cureno = "";
            string patname = "";           
            DateTime? Bdate = null;
            DateTime? Edate = null;
            if (this.cbdate.Checked)
            {
                Bdate = this.dtpBegin.Value;
                Edate = this.dtpEnd.Value;
            }
            if (this.cbcureno.Checked)
            {
                cureno = this.txtCureNo.Text.Trim();
            }
            if (this.cbname.Checked)
            {
                patname = this.txtPatName.Text.Trim();
            }
            this.lvPatList.Items.Clear();
            List<HIS.Model.ZY_PatList> zypatlist = null;
            zypatlist = HIS.ZYDoc_BLL.PatInfo.PatOperation.GetOutPatList(_currentDept.DeptID.ToString(), Bdate, Edate);       
            if (zypatlist == null)
            {
                return;
            }
            this.AddPatientList(zypatlist);
            this.lbout.Text = zypatlist.Count + " 人";
        }       
        #endregion

        #region 病人列表方法事件
        // 双击病人列表
        private void lvPatList_DoubleClick(object sender, EventArgs e)
        {
            if (_DataGridViewEx == null)
            {
                return;
            }
            if (this.lvPatList.SelectedItems.Count > 0)
            {
                if (_zypatlist == (HIS.Model.ZY_PatList)this.lvPatList.SelectedItems[0].Tag)
                {
                    return;
                }
                if (IsCanClose())
                {
                    _zypatlist = (HIS.Model.ZY_PatList)this.lvPatList.SelectedItems[0].Tag;                   
                    this.Cursor = PublicStaticFun.WaitCursor();
                    this.InitData();
                    this.Cursor = Cursors.Default;
                }
            }           
        }
        private void InitList(int sign)
        {  
            this.lvPatList.Items.Clear();
            this.label2.Text = 0 + " 人";
            List<HIS.Model.ZY_PatList> zypatlist = null;
            zypatlist = HIS.ZYDoc_BLL.PatInfo.PatOperation.GetInBedPatList(sign, Convert.ToInt32(_currentUser.EmployeeID), Convert.ToInt32(_currentDept.DeptID));// Controller.GetBindInPatlist(sign);
            if (zypatlist == null || zypatlist.Count == 0)
            {
                return;
            }
            this.AddPatientList(zypatlist);
            this.label2.Text = zypatlist.Count + " 人";
        }
        //刷新病人列表
        private void llabrush_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.radDoc.Checked)
            {
                this.InitList(0);
            }
            else
            {
                this.InitList(1);
            }
        }
        //管辖内病人
        private void radDoc_CheckedChanged(object sender, EventArgs e)
        {
            if (radDoc.Checked)
            {
                this.InitList(0);
            }
            else
            {
                this.InitList(1);
            }
        }
        //科室内病人
        private void RadAllDept_CheckedChanged(object sender, EventArgs e)
        {
            if (RadAllDept.Checked)
            {
                this.InitList(1);
            }
            else
            {
                this.InitList(0);
            }
        }      
        #endregion

        #region 医技申请
        //检查申请
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (IsCanApply())
            {
                FrmCheckApply fca = new FrmCheckApply(_zypatlist, _currentUser.UserID, _currentDept.DeptID);
                fca.ShowDialog();              
            }
        }
        // 检验申请
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (IsCanApply())
            {
                FrmTestApply fta = new FrmTestApply(_zypatlist, _currentUser.UserID, _currentDept.DeptID);
                fta.ShowDialog();
            }
        }
        //治疗申请
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (IsCanApply())
            {
                FrmCureApply fcu = new FrmCureApply(_zypatlist, _currentUser.UserID, _currentDept.DeptID);
                fcu.ShowDialog();
            }
        }
        #endregion

        #region 特殊医嘱申请
        //转科申请
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (_zypatlist == null)
            {
                MessageBox.Show("请选择病人");
                return;
            }
            if (Controller.ExistNotFinishSs())  // 20100512.1.03  病人出院时判断病人是否存在未完成的手术
            {
                MessageBox.Show("该病人有未完成的手术，不能出院");
                return;
            }
            if (IsNotCanUse())
            {               
                return;
            }
            string err = Controller.NotExeOrders();
            if (err=="")
            {
                FrmTransferDept ftf = new FrmTransferDept(_zypatlist, _currentUser.EmployeeID, _currentDept.DeptID);
                ftf.ShowDialog();
                if (ftf.isTransferDept)
                {
                    this.Brush();//刷新医嘱
                    this.dtgrdTemp.DataSource = null;             
                    Controller.MessageTell("有转科医嘱和停医嘱需要处理，请注意查收");
                }
            }
            else
            {
                MessageBox.Show("还有下列未发送或未执行的医嘱\n  "+err+"请先执行或删除医嘱再转科");
                return;
            }
        }
        //出院医嘱
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            if (_zypatlist == null)
            {
                MessageBox.Show("请选择病人");
                return;
            }
            if (Controller.ExistNotFinishSs())  // 20100512.1.03  病人出院时判断病人是否存在未完成的手术
            {
                MessageBox.Show("该病人有未完成的手术，不能出院");
                return;
            }
            if (IsNotCanUse())
            {
                return;
            }
            string err = Controller.NotExeOrders();
            if (err=="")
            {
                FrmLeave leave = new FrmLeave(_zypatlist, _currentUser.EmployeeID, _currentDept.DeptID);
                leave.ShowDialog();
                if (leave.isDefineOut)
                {
                    this.Brush();   //刷新医嘱  
                    this.dtgrdTemp.DataSource = null;
                    _zypatlist = HIS.ZYDoc_BLL.PatInfo.PatOperation.GetNewPatModel(_zypatlist.PatListID);//新增，每改动病人状态后重新获得病人信息实体   
                    Controller.SetPatlist();
                    Controller.MessageTell("有出院医嘱需要处理，请注意查收");
                }
            }
            else
            {
                MessageBox.Show("还有下列未发送或未执行的医嘱\n " + err + "请先执行或删除医嘱再出院");
                return;
            }
        }
        //死亡医嘱
        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            if (_zypatlist == null)
            {
                MessageBox.Show("请选择病人");
                return;
            }
            if (Controller.ExistNotFinishSs())  // 20100512.1.03  病人出院时判断病人是否存在未完成的手术
            {
                MessageBox.Show("该病人有未完成的手术，不能出院");
                return;
            }
            if (IsNotCanUse())
            {
                return;
            }            
            if (MessageBox.Show("确定病人死亡吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            string err = Controller.NotExeOrders(); 
            if (err=="")
            {
                FrmDeath death = new FrmDeath(_zypatlist, _currentUser.EmployeeID, _currentDept.DeptID);
                death.ShowDialog();
                if (death.isDefineDeath)
                {
                    this.Brush();
                    this.dtgrdTemp.DataSource = null;
                    _zypatlist = HIS.ZYDoc_BLL.PatInfo.PatOperation.GetNewPatModel(_zypatlist.PatListID);//新增，每改动病人状态后重新获得病人信息实体
                    Controller.SetPatlist();
                    Controller.MessageTell("有死亡医嘱需要处理，请注意查收");
                }
            }
            else
            {
                MessageBox.Show("还有下列未发送或未执行的医嘱\n " + err + "请先执行或删除医嘱再定义死亡医嘱");
                return;
            }
        }
        private bool CheckPat()
        {
            if (this.IsExistNotSaveLong())
            {
                MessageBox.Show("请先保存长期医嘱或删除未保存的医嘱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (IsNotCanUse())
            {
                return false;
            }
            string err = Controller.NotExeOrders();
            if (err!="")
            {
                MessageBox.Show("对不起！还有下列未发送或未执行的医嘱\n" + err + "请删除该医嘱或等医嘱执行完！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);						
                return false ;
            }
            return true; ; 
        } 
        //术后医嘱
        private void toolStripButton1_Click(object sender, EventArgs e)
        {           
            if (CheckPat())
            {
                FrmStop fs = new FrmStop(_zypatlist, _currentUser.EmployeeID, _currentDept.DeptID);
                fs.Text = "停术前医嘱";
                fs.ShowDialog();               
                if (fs.isDefineStop)
                {
                    if (Controller.AfterOperation("术后医嘱"))
                    {
                        this.Brush();
                        Controller.MessageTell("有术后医嘱和停医嘱需要处理，请注意查收");
                    }
                }
            }
        }
        //产后医嘱
        private void toolStripButton9_Click(object sender, EventArgs e)
        {                   
            if (_zypatlist.PatientInfo.PatSex == "男")
            {
                MessageBox.Show("该病人是男性！！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }    
            if (CheckPat())
            {
                FrmStop fs = new FrmStop(_zypatlist, _currentUser.EmployeeID, _currentDept.DeptID);
                fs.Text = "停产前医嘱";
                fs.ShowDialog();               
                if (fs.isDefineStop)
                {
                    if (Controller.AfterOperation("产后医嘱")) 
                    {
                        this.Brush();
                        Controller.MessageTell("有产后医嘱和停医嘱需要处理，请注意查收");
                    }
                }
            }
        }
        #endregion
        
        #region 新增的模板的代码 
        private void radall_CheckedChanged(object sender, EventArgs e)
        {
            this.level = 0;
            this.tvtype.Nodes.Clear();
            this.DtgrvModel.DataSource = null;       
            TreeNode node = Controller.Bind_tvtype(0,Convert.ToInt32(_currentUser.EmployeeID),Convert.ToInt32(_currentDept.DeptID));
            this.tvtype.Nodes.Add(node);
            this.tvtype.SelectedNode = node;
            node.Expand();
        }
        private void raddept_CheckedChanged(object sender, EventArgs e)
        {
            this.level = 1;
            this.tvtype.Nodes.Clear();
            this.DtgrvModel.DataSource = null;          
            TreeNode node = Controller.Bind_tvtype(1, Convert.ToInt32(_currentUser.EmployeeID), Convert.ToInt32(_currentDept.DeptID));
            this.tvtype.Nodes.Add(node);
            this.tvtype.SelectedNode = node;
            node.Expand();
        }
        private void radself_CheckedChanged(object sender, EventArgs e)
        {
            this.level = 2;
            this.tvtype.Nodes.Clear();
            this.DtgrvModel.DataSource = null;        
            TreeNode node = Controller.Bind_tvtype(2, Convert.ToInt32(_currentUser.EmployeeID), Convert.ToInt32(_currentDept.DeptID));
            this.tvtype.Nodes.Add(node);
            this.tvtype.SelectedNode = node;
            node.Expand();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.tvtype.Nodes.Clear();
            this.DtgrvModel.DataSource = null;
            TreeNode node = Controller.Bind_tvtype(level, Convert.ToInt32(_currentUser.EmployeeID), Convert.ToInt32(_currentDept.DeptID));
            this.tvtype.Nodes.Add(node);
            this.tvtype.SelectedNode = node;
            node.Expand();
        }
        private void tvtype_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.tvtype.SelectedNode.ImageIndex == 15)
            {
                this.DtgrvModel.DataSource = null;                
                this.DtgrvModel.AutoGenerateColumns = false;
                this.DtgrvModel.DataSource = Controller.GetModelData(Convert.ToInt32(this.tvtype.SelectedNode.Tag));
            }
        }              
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                if (this.tvtype == null || this.tvtype.Nodes.Count == 0)
                {
                    this.tvtype.Nodes.Clear();
                    this.DtgrvModel.DataSource = null;                 
                    TreeNode node = Controller.Bind_tvtype(level, Convert.ToInt32(_currentUser.EmployeeID), Convert.ToInt32(_currentDept.DeptID));
                    this.tvtype.Nodes.Add(node);
                    this.tvtype.SelectedNode = node;
                    node.Expand();
                }
            }
        }
        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.DtgrvModel.RowCount; i++)
            {
                Controller.CellXD(i, false, (DataTable)DtgrvModel.DataSource);              
            }
        }
        private void 反选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.DtgrvModel.RowCount; i++)
            {
                Controller.CellXD(i, true , (DataTable)DtgrvModel.DataSource);                
            }
        }
        private void 应用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DtgrvModel == null || IsNotCanUse())
            {
                return;
            }           
            DataTable dt = (DataTable)this.DtgrvModel.DataSource;
            if (dt == null || dt.Rows.Count == 0)
            {
                return;
            }
            List<HIS.Model.ZY_DOC_ORDERMODELLIST> lists = new List<HIS.Model.ZY_DOC_ORDERMODELLIST>();
            lists=  Controller.ModelApply(dt, 0, dt.Rows.Count);           
            if (lists == null || lists.Count == 0 )
            {
                return;
            }
            else
            {                
               Controller.AddModelData(lists);
            }
            this.SetPlace();
        }
        private void DtgrvModel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DtgrvModel == null || DtgrvModel.Rows.Count == 0)
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
                DataTable dtt = (DataTable)DtgrvModel.DataSource;
                Controller.XdControl(dtt, rowid);
            }
        }
        private void DtgrvModel_Paint(object sender, PaintEventArgs e)
        {
            if (DtgrvModel == null || DtgrvModel.Rows.Count == 0)
            {
                return;
            }
            DataTable dt = (DataTable)DtgrvModel.DataSource;
            Controller.PaintView(DtgrvModel, dt, e, 0);
        }
        private void DtgrvModel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (DtgrvModel == null || DtgrvModel.Rows.Count == 0 || DtgrvModel.CurrentCell == null || IsNotCanUse())
            {
                return;
            }          
            int rowid = DtgrvModel.CurrentCell.RowIndex;
            if (rowid < 0)
            {
                return;
            }
            DataTable dt = (DataTable)DtgrvModel.DataSource;
            int beginNum = 0;
            int endNum = 0;
            Controller.FindModelBeginEnd(rowid, dt, ref  beginNum, ref  endNum);
            for (int i = beginNum; i <= endNum; i++)
            {
                dt.Rows[i]["XD"] = true;
            }
            List<HIS.Model.ZY_DOC_ORDERMODELLIST> lists = new List<HIS.Model.ZY_DOC_ORDERMODELLIST>();
            lists = Controller.ModelApply(dt, beginNum, endNum+1);
            if (lists == null || lists.Count == 0)
            {
                MessageBox.Show("还没有选择医嘱,或者选择的模板医嘱已被药房禁用或没有库存");
                return;
            }
            else
            {
                Controller.AddModelData(lists);
            }
            this.SetPlace();
        }
        private void tvtype_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "全部类型")
            {
                e.Node.Expand();
            }
            else if (e.Node.Parent.Text == "全部类型")
            {
                e.Node.Expand();
            }
            else
            {
                e.Node.Collapse();
            }
        }
        #endregion

        #region 方法
        //初始化病人医嘱信息
        private void InitData()
        {
            this.tbOrder.SelectedIndex = 0;
            this.dtgrdLong.DataSource = null;
            this.dtgrdTemp.DataSource = null;
            OrderKind = 0;
            _DataGridViewEx = this.dtgrdLong;
            Controller.GetPatlist();
            Controller.getOrderData(OrderKind);
            this.SetPlace();
        }
        private void SetPlace()
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0)
            {
                return;
            }
            else
            {
                _DataGridViewEx.CurrentCell = _DataGridViewEx[2, _DataGridViewEx.Rows.Count - 1];
            }
        }
        public void Brush()
        {
            this.tbOrder.SelectedIndex = 0;
            OrderKind = 0;
            Controller.getOrderData(0);         
            this.SetPlace();
        }     
        public void AddRow(GWI.HIS.Windows.Controls.DataGridViewEx dgv, int sign)
        {
            dgv.Focus();
            int rowid = Controller.AddRow(OrderKind, sign);
            _rowIndex = rowid;
        }
        private bool IsCanClose()
        {
            string name = _zypatlist.PatientInfo.PatName;
            if (this.IsExistNotSaveLong())
            {
                if (MessageBox.Show(""+name+"还有长嘱未保存，确定现在退出吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return false;
                }
            }
            if (this.IsExistNotSaveTemp())
            {
                if (MessageBox.Show(""+name+"还有临嘱未保存，确定现在退出吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return false;
                }
            }
            if (this.IsExestNotSendLong() || IsExistNotSendTemp()) 
            {
                if (MessageBox.Show("" + name + "该病人还有医嘱未发送，确定现在退出吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return false;
                }
            }
            return true;
        }
        private void AddPatientList(List<HIS.Model.ZY_PatList> zypatlist)
        {   
            for (int i = 0; i < zypatlist.Count; i++)
            {
                ListViewItem lstViewItem = new ListViewItem();
                lstViewItem.SubItems.Clear();
                lstViewItem.Tag = zypatlist[i];
                lstViewItem.SubItems[0].Text = zypatlist[i].BedCode;
                lstViewItem.SubItems.Add(zypatlist[i].PatientInfo.PatName);
                lstViewItem.SubItems.Add(zypatlist[i].CureNo);
                lstViewItem.SubItems.Add(zypatlist[i].PatientInfo.PatSex);
                lstViewItem.SubItems.Add(zypatlist[i].PatientInfo.PatBriDate.ToString("yyyy-MM-dd"));
                this.lvPatList.Items.Add(lstViewItem);
            }  
        }
        #region 是否存在未保存的长嘱
        private bool IsExistNotSaveLong()
        {
            if (this.dtgrdLong == null || this.dtgrdLong.DataSource == null)
            {
                return false;
            }
            DataTable dt = (DataTable)this.dtgrdLong.DataSource;
            if (dt == null || dt.Rows.Count == 0)
            {
                return false;
            }
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (Convert.ToInt32(dt.Rows[i]["status_falg"].ToString().Trim()) <0)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
        #region 是否存在未保存的临嘱
        private bool IsExistNotSaveTemp()
        {
            if (this.dtgrdTemp == null || this.dtgrdTemp.Rows.Count == 0)
            {
                return false;
            }
            DataTable dt = (DataTable)this.dtgrdTemp.DataSource;
            if (dt == null || dt.Rows.Count == 0)
            {
                return false;

            }
            else
            {
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if ( Convert.ToInt32(dt.Rows[i]["status_falg"].ToString().Trim()) <0)
                    {
                        return true;                        
                    }
                }
            }
            return false;
        }
        #endregion
        #region 是否存在未发送的临嘱
        private bool IsExistNotSendTemp()
        {
            if (this.dtgrdTemp == null || this.dtgrdTemp.Rows.Count == 0)
            {
                return false;
            }
            DataTable dt = (DataTable)this.dtgrdTemp.DataSource;
            if (dt == null || dt.Rows.Count == 0)
            {
                return false;

            }
            else
            {
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Convert.ToInt32(dt.Rows[i]["status_falg"].ToString().Trim()) == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion
        #region 是否存在未发送的长嘱
        private bool IsExestNotSendLong()
        {
            if (this.dtgrdLong == null || this.dtgrdLong.DataSource == null)
            {
                return false;
            }
            DataTable dt = (DataTable)this.dtgrdLong.DataSource;
            if (dt == null || dt.Rows.Count == 0)
            {
                return false;
            }
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (Convert.ToInt32(dt.Rows[i]["status_falg"].ToString().Trim()) == 0)
                {

                    return true;
                }
            }
            return false;
        }
        #endregion
        #region 是否可以修改医嘱
        private bool IsNotCanUse()
        {          
            if (Controller.NotCanUpdate())
            {
                if (tabPlist.SelectedIndex == 0)
                {
                    MessageBox.Show("该病人已定义出院或者转科，不能修改医嘱");
                    return true;
                }
                else
                {
                    MessageBox.Show("该病人已出院，不能修改医嘱");
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region  是否可以开医技申请
        private bool IsCanApply()
        {
            if (_zypatlist == null)
            {
                MessageBox.Show("请选择病人");
                return false;
            }
            if (this.IsExistNotSaveTemp())
            {
                MessageBox.Show("请先保存临时医嘱");
                return false;
            }
            return true;
        }
        #endregion
        #endregion

        #region 杂事件
        private void tbOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._DataGridViewEx.CloseSelectionCard();
            this.chkEdit.Checked = false;
            if (tbOrder.SelectedIndex == 0)
            {
                toolStrip1.Visible = true;
                OrderKind = 0;
                _DataGridViewEx = this.dtgrdLong;
                this.btnjz.Visible = false;
                this.btnGave.Visible = false;
                this.btnStop.Visible = true;
                this.btnSelf.Visible = true;
                this.btnModel.Visible = true;
                this.BtnOutDrug.Visible = false;              
                DataTable dt = (DataTable)_DataGridViewEx.DataSource;
                if (dt == null || dt.Rows.Count == 0)
                {
                    Controller.getOrderData(OrderKind);    
                }
                this.SetPlace();
            }
            if (tbOrder.SelectedIndex == 1)
            {
                toolStrip1.Visible = true;
                OrderKind = 1;
                _DataGridViewEx = this.dtgrdTemp;
                this.btnjz.Visible = true;
                this.btnGave.Visible = true;
                this.btnStop.Visible = false;
                this.btnSelf.Visible = true;
                this.btnModel.Visible = true;
                this.BtnOutDrug.Visible = true;             
                DataTable dt = (DataTable)_DataGridViewEx.DataSource;
                if (dt == null || dt.Rows.Count == 0)
                {
                    Controller.getOrderData(OrderKind);     
                }
                this.SetPlace();
            }
            if (yf != null && yf.Rows.Count > 1)
            {
                Controller.YfSelect(OrderKind);
            }
            if (tbOrder.SelectedIndex == 2)
            {
                //add by zengyan 2010-5-14 先清除已有子节点
                TvEmrType.Nodes[1].Nodes.Clear();

                Controller.GetCourseCount();
                Controller.GetEmr(0);
                toolStrip1.Visible = false;
            }          
        }
        private void BaseForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F3:	//新开
                    btnNew_Click(null, null);
                    break;
                case Keys.F4:	//取消
                    btnCancel_Click(null, null);
                    break;
                case Keys.F5:	//保存
                   btnSave_Click(null, null);
                    break;
                case Keys.F6:	//模板
                    btnModel_Click(null, null);
                    break;
                case Keys.F7:	//发送
                    btnSend_Click(null, null);
                    break;
                case Keys.F8:	//停嘱
                    btnStop_Click(null, null);
                    break;
                case Keys.F9:	//交病人
                    btnGave_Click(null, null);
                    break;            
                case Keys.F11:	//中药脚注
                    btnjz_Click(null, null);
                    break;
                case Keys.F12:	//刷新
                    btnbrush_Click(null, null);
                    break;
                default:
                    break;
            }   
            // * 20100524.1.06 医嘱管理界面加入快捷键
            if (e.KeyCode == Keys.D1 && e.Shift)
            {
                tbOrder.SelectedIndex = 0;
                tbOrder_SelectedIndexChanged(null, null);
            }
            if (e.KeyCode == Keys.D2 && e.Shift)
            {
                tbOrder.SelectedIndex = 1;
                tbOrder_SelectedIndexChanged(null, null);
            }
            if (e.KeyCode == Keys.D3 && e.Shift)
            {
                tbOrder.SelectedIndex = 2;
                tbOrder_SelectedIndexChanged(null, null);
            }
           
        }
        #region 医嘱全部显示
        private void radDisAll_CheckedChanged(object sender, EventArgs e)
        {
            if (_DataGridViewEx == null)
            {
                return;
            }
            DataTable dt = (DataTable)_DataGridViewEx.DataSource;
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (dt.Rows[i]["status_falg"].ToString() == "-1")
                {
                    if (MessageBox.Show("还有未保存的医嘱，需要先保存吗？", "保存提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.chkEdit.Checked = false;
                        int colid, rowid;
                        if (IsNotCanUse())
                        {
                            return;
                        }

                        try
                        {
                            this.Cursor = PublicStaticFun.WaitCursor();
                            _DataGridViewEx.EndEdit();
                            if (Controller.SaveOrder(OrderKind, out colid, out rowid))
                            {
                                Controller.getOrderData(OrderKind);
                                this.Cursor = Cursors.Default;
                            }
                            else
                            {
                                this.Cursor = Cursors.Default;
                                _DataGridViewEx.CurrentCell = _DataGridViewEx[colid, rowid];
                                break;
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
                        this.SetPlace();

                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (radDisAll.Checked)
            {
                Controller.getOrderData(OrderKind);
                this.SetPlace();
            }
            else
            {
                if (dt == null || dt.Rows.Count == 0)
                {
                    return;
                }
                DataTable dtcopy = dt.Clone();
                dtcopy.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[i]["status_falg"].ToString()) < 3)
                    {
                        dtcopy.Rows.Add(dt.Rows[i].ItemArray);
                    }
                }
                this._DataGridViewEx.DataSource = dtcopy;
                Controller.ColorPaint((DataTable)_DataGridViewEx.DataSource);
                this.SetPlace();
            }
        }
        #endregion
        #region 只显示有效医嘱
        private void radDisUse_CheckedChanged(object sender, EventArgs e)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0)
            {
                return;
            }
            DataTable dt = (DataTable)_DataGridViewEx.DataSource;
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (dt.Rows[i]["status_falg"].ToString() == "-1")
                {

                    if (MessageBox.Show("还有未保存的医嘱，需要先保存吗？", "保存提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.chkEdit.Checked = false;
                        int colid, rowid;
                        if (IsNotCanUse())
                        {
                            return;
                        }

                        try
                        {
                            this.Cursor = PublicStaticFun.WaitCursor();
                            _DataGridViewEx.EndEdit();
                            if (Controller.SaveOrder(OrderKind, out colid, out rowid))
                            {
                                Controller.getOrderData(OrderKind);
                                this.Cursor = Cursors.Default;
                            }
                            else
                            {
                                this.Cursor = Cursors.Default;
                                _DataGridViewEx.CurrentCell = _DataGridViewEx[colid, rowid];
                                break;
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
                        this.SetPlace();
                    }

                }
            }
            if (radDisAll.Checked)
            {
                Controller.getOrderData(OrderKind);
                this.SetPlace();
            }
            else
            {
                if (dt == null || dt.Rows.Count == 0)
                {
                    return;
                }
                DataTable dtcopy = dt.Clone();
                dtcopy.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[i]["status_falg"].ToString()) < 3)
                    {
                        dtcopy.Rows.Add(dt.Rows[i].ItemArray);
                    }
                }
                this._DataGridViewEx.DataSource = dtcopy;
                Controller.ColorPaint((DataTable)_DataGridViewEx.DataSource);
                this.SetPlace();
            }
        }
        #endregion       
        //输入字符合法控制
        private void dtgrdLong_DataGridViewCellKeyPress(object sender, KeyPressEventArgs e, ref bool handle)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || _DataGridViewEx.CurrentCell == null)
            {
                return;
            }
            int rowid = _DataGridViewEx.CurrentCell.RowIndex;
            int colid = _DataGridViewEx.CurrentCell.ColumnIndex;
            if (colid == 7)
            {               
                handle = Controller.NumInputControl((int)e.KeyChar, 0);
            }
            if (colid == 3)
            {               
                handle = Controller.NumInputControl((int)e.KeyChar, 1);
            }
        }                  
        private void toolStrip1_MouseEnter(object sender, EventArgs e)
        {
            this.PlExplain.Top = this.panel11.Top;
            this.PlExplain.Visible = true;
        }
        private void toolStrip1_MouseLeave(object sender, EventArgs e)
        {
            this.PlExplain.Visible = false;
        }
        #endregion

        #region 网格事件 
        //单元格值改变的时候
        private void dtgrdLong_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || _DataGridViewEx.CurrentCell == null)
            {
                return;
            }
            int rowid = _DataGridViewEx.CurrentCell.RowIndex;
            int colid = _DataGridViewEx.CurrentCell.ColumnIndex;
            DataTable dt = (DataTable)_DataGridViewEx.DataSource;
            if (OrderKind > 0 && colid == 7 && Controller.IsGroupFirstRow(dt, rowid))
            {
                string name = _DataGridViewEx.Columns[colid].DataPropertyName;
                dt.Rows[rowid]["pres_amount"] = dt.Rows[rowid]["presnum"];
                Controller.ChangeValue(dt, rowid, name);
            }
            if (OrderKind == 0 && colid == 7 && Controller.IsGroupFirstRow(dt, rowid))
            {
                string name = _DataGridViewEx.Columns[colid].DataPropertyName;
                dt.Rows[rowid]["firset_times"] = dt.Rows[rowid]["First"];
                Controller.ChangeValue(dt, rowid, name);
            }
            if (colid == 5 && Controller.IsGroupFirstRow(dt, rowid))
            {
                string name = _DataGridViewEx.Columns[colid].DataPropertyName;
                dt.Rows[rowid]["order_usage"] = dt.Rows[rowid]["usage"];
                Controller.ChangeValue(dt, rowid, name);
            }
            if (dt.Rows[rowid]["orecord_a2"].ToString().Trim() == "1")
            {
                dt.Rows[rowid]["orecord_a2"] = 2;
                dt.Rows[rowid]["status_falg"] = -1;
                Controller.ColorPaint(dt);
            }
        }
        //控制只读
        private void dtgrdLong_CurrentCellChanged(object sender, EventArgs e)
        {
            if (_DataGridViewEx != null && _DataGridViewEx.CurrentCell != null)
            {
                int rowid = _DataGridViewEx.CurrentCell.RowIndex;
                int colid = _DataGridViewEx.CurrentCell.ColumnIndex;
                DataTable table = (DataTable)_DataGridViewEx.DataSource;
                string flag = table.Rows[rowid]["status_falg"].ToString().Trim();
                Controller.SettingReadOnly(colid, rowid, OrderKind);
                if (OrderKind == 0)
                {
                    this.UnitReadOnly = true;
                    if (table.Rows.Count == 0 || table == null || rowid >= table.Rows.Count)
                    {
                        return;
                    }
                    if (flag == "2")
                    {
                        this.btnStop.Text = "停医嘱(F8)";
                        this.btnStop.Enabled = true;
                    }
                    else if (flag == "3")
                    {
                        this.btnStop.Text = "取消停医嘱(F8)";
                        this.btnStop.Enabled = true;
                    }
                    else
                    {
                        this.btnStop.Text = "停医嘱(F8)";
                        this.btnStop.Enabled = false;
                    }
                }
                if (OrderKind == 1)
                {
                    if (table.Rows[rowid]["item_type"] == DBNull.Value || table.Rows[rowid]["item_type"].ToString() == "10")
                    {
                        return;
                    }
                    if (Convert.ToInt32(table.Rows[rowid]["item_type"].ToString()) < 3)
                    {
                        Controller.GetDwType(Convert.ToInt32(table.Rows[rowid]["makedicid"].ToString()), Convert.ToInt32(table.Rows[rowid]["item_type"].ToString()));
                    }
                }
                if ( Convert.ToInt32(XcConvert.IsNull(table.Rows[rowid]["item_type"].ToString(),"5")) < 4)
                {
                    DataRow drug =Controller.GetDrugInfo(Convert.ToInt32(table.Rows[rowid]["makedicid"].ToString()), Convert.ToInt32(table.Rows[rowid]["item_type"].ToString()));// Controller.GetDrugInfo(rowid, OrderKind);
                    if (drug == null)
                    {
                        this.lbdrugname.Text = "";
                        this.lbdrugunit.Text = "";
                        this.lbdrugtype.Text = "";
                        this.lbdrugrage.Text = "";
                        this.lbdrugprice.Text = "";
                        this.lbdrugdept.Text = "";
                        this.lbaddress.Text = "";
                        this.lbspec.Text = "";
                        this.cbdu.Checked = false;
                        this.cbma.Checked = false;
                        this.cbgu.Checked = false;
                        this.cbjs.Checked = false;
                    }
                    else
                    {
                        this.lbdrugname.Text = drug["itemname"].ToString();
                        this.lbdrugunit.Text = drug["packunit"].ToString();
                        this.lbdrugtype.Text = drug["insur_type"].ToString();
                        this.lbdrugrage.Text = drug["ncms_comp_rate"].ToString();
                        this.lbdrugprice.Text = drug["sell_price"].ToString();                        
                        //if (table.Rows[rowid]["exec_dept"] == null || table.Rows[rowid]["exec_dept"].ToString().Trim() == "")
                        //{
                        //    this.lbdrugdept.Text = drug["execdeptname"].ToString();
                        //}
                        //else
                        //{
                        //    this.lbdrugdept.Text = HIS.ZYDoc_BLL.GetName.GetDeptName(table.Rows[rowid]["exec_dept"].ToString());
                        //}
                        //update by heyan 2010.12.14 药品信息执行科室显示不正确的问题
                        this.lbdrugdept.Text = table.Rows[rowid]["execdept"].ToString() == "" ? HIS.ZYDoc_BLL.GetName.GetDeptName(table.Rows[rowid]["exec_dept"].ToString()) : table.Rows[rowid]["execdept"].ToString();
                        this.lbaddress.Text = drug["address"].ToString();
                        this.lbspec.Text = drug["standard"].ToString();
                        if (drug["virulent_flag"].ToString() == "1")
                        {
                            this.cbdu.Checked = true;
                        }
                        else
                        {
                            this.cbdu.Checked = false;
                        }
                        if (drug["narcotic_flag"].ToString() == "1")
                        {
                            this.cbma.Checked = true;
                        }
                        else
                        {
                            this.cbma.Checked = false;
                        }
                        if (drug["costly_flag"].ToString() == "1")
                        {
                            this.cbgu.Checked = true;
                        }
                        else
                        {
                            this.cbgu.Checked = false;
                        }
                        if (drug["lunacy_flag"].ToString() == "1")
                        {
                            this.cbjs.Checked = true;
                        }
                        else
                        {
                            this.cbjs.Checked = false;
                        }
                    }
                }
            }
            else
            {
                return;
            }
        }
        //修改录入时间
        private void dtgrdLong_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_DataGridViewEx != null && _DataGridViewEx.CurrentCell != null)
            {
                int rowindex = _DataGridViewEx.CurrentCell.RowIndex;
                int colindex = _DataGridViewEx.CurrentCell.ColumnIndex;
                if (colindex != 0)
                {
                    return;
                }
                DataTable dt = (DataTable)_DataGridViewEx.DataSource;
                if (Convert.ToInt32(dt.Rows[rowindex]["status_falg"].ToString().Trim()) > 1)
                {
                    MessageBox.Show("该医嘱已执行，不能修改录入时间");
                    return;
                }
                if (dt.Rows[rowindex]["begintime"].ToString() == Controller.timeformat.ToString())
                {
                    return;
                }
                if (dt.Rows[rowindex]["order_content"].ToString() == "")
                {
                    return;
                }
                Frmtime ftime = new Frmtime();
                ftime.OTime = Convert.ToDateTime(dt.Rows[rowindex]["begintime"].ToString());
                ftime.mindate = _zypatlist.CureDate;
                ftime.ShowDialog();
                DateTime btime = ftime.dtime;
                if (btime.ToString() != Controller.timeformat.ToString())
                {
                    dt.Rows[rowindex]["begintime"] = ftime.dtime;
                    dt.Rows[rowindex]["order_bdate"] = ftime.dtime;
                    if (dt.Rows[rowindex]["orecord_a2"].ToString().Trim() == "1")
                    {
                        dt.Rows[rowindex]["orecord_a2"] = 2;
                        dt.Rows[rowindex]["status_falg"] = -1;
                    }
                    int end = Controller.GetGroupEndRow(dt, rowindex);
                    for (int i = rowindex + 1; i < end; i++)
                    {
                        if (dt.Rows[i]["begintime"].ToString() == Controller.timeformat.ToString())
                        {
                            dt.Rows[i]["order_bdate"] = ftime.dtime;
                            if (dt.Rows[i]["orecord_a2"].ToString().Trim() == "1")//orecord_a2＝１已保存标志，orecord_a2＝２修改标志
                            {
                                dt.Rows[i]["orecord_a2"] = 2;
                                dt.Rows[i]["status_falg"] = -1;
                            }
                        }
                    }
                    Controller.ColorPaint(dt);
                }
            }
        }
        //重绘事件
        private void dtgrdLong_Paint(object sender, PaintEventArgs e)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0)
            {
                return;
            }
            Controller.PaintView(_DataGridViewEx, (DataTable)_DataGridViewEx.DataSource, e, 1);
        }
        private void dtgrdLong_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }      
        //选择项卡选中赋值
        private void dtgrdLong_SelectCardRowSelected(object SelectedValue, ref bool stop, ref int customNextColumnIndex)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.CurrentCell == null)
            {
                return;
            }
            _DataGridViewEx.EndEdit();
            DataRow dr = (DataRow)SelectedValue;
            int rowid = this._DataGridViewEx.CurrentCell.RowIndex;
            int columnid = this._DataGridViewEx.CurrentCell.ColumnIndex;
            DataTable dt = new DataTable();
            if (OrderKind == 0)
            {
                dt = this.BindLongOrderData;
            }
            if (OrderKind == 1)
            {
                dt = this.BindTempOrderData;
            }         
            int id = Controller.SelectCardBindData(OrderKind, rowid, dr, columnid);
            if (id != -1)
            {
                if (id == 3)
                {
                    if (!Controller.IsGroupFirstRow(dt, rowid))
                    {
                        _DataGridViewEx.CurrentCell = _DataGridViewEx[5, rowid];
                        _DataGridViewEx.CurrentCell = _DataGridViewEx[6, rowid];
                        _DataGridViewEx.CurrentCell = _DataGridViewEx[7, rowid];
                    }
                    _DataGridViewEx.CurrentCell = _DataGridViewEx[4, rowid];
                }
                if (id == 2)
                {
                    _DataGridViewEx.CurrentCell = _DataGridViewEx[3, rowid];
                }
                customNextColumnIndex = id;
            }            
        }
        //回车事件
        private void dtgrdLong_DataGridViewCellPressEnterKey(object sender, int colIndex, int rowIndex, ref bool jumpStop)
        {
            this.chkEdit.Checked = false;
            DataTable dtt = (DataTable)_DataGridViewEx.DataSource;
            if (dtt.Rows[rowIndex]["status_falg"].ToString() != "-1")
            {
                return;
            }           
            if (colIndex == 10 && rowIndex == (this._DataGridViewEx.RowCount - 1))
            {
                AddRow(this._DataGridViewEx, 1);
                for (int i = 0; i < _DataGridViewEx.Controls.Count; i++)
                {
                    if (_DataGridViewEx.Controls[i].GetType().ToString() == "System.Windows.Forms.HScrollBar")
                    {
                        HScrollBar scrollbar = (System.Windows.Forms.HScrollBar)this._DataGridViewEx.Controls[i];
                        scrollbar.Value = 0;
                        break;
                    }
                }
                _DataGridViewEx.CurrentCell = this._DataGridViewEx[0, _rowIndex];
                _DataGridViewEx.CurrentCell = this._DataGridViewEx[1, _rowIndex];                
            }
            DataTable dt = new DataTable();
            if (OrderKind == 0)
            {
                dt = this.BindLongOrderData;
            }
            if (OrderKind == 1)
            {
                dt = this.BindTempOrderData;
            }           
            if (colIndex >= 3 && !Controller.IsGroupFirstRow(dt, rowIndex))
            {              
                AddRow(this._DataGridViewEx, 1);
                _DataGridViewEx.CurrentCell = this._DataGridViewEx[1, _rowIndex];
            }
        }
        #endregion             
       
        #region 颜色表示状态提示
        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            this.PlExplain.Top = this.panel4.Top;
            this.PlExplain.Visible = true;
        }
        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            this.PlExplain.Visible = false;
        }
        #endregion

        #region 按钮事件
        //新开
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (IsNotCanUse())
            {
                return;
            }
            this.chkEdit.Checked = false;
            AddRow(this._DataGridViewEx, 0);
            _DataGridViewEx.CurrentCell = this._DataGridViewEx[2, _rowIndex];    
        }
        //取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.chkEdit.Checked = false;           
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || _DataGridViewEx.CurrentCell == null)
            {
                return;
            }
            if (_DataGridViewEx.CurrentCell != null)
            {
                int _rowindex = _DataGridViewEx.CurrentCell.RowIndex;
                if (_rowindex >= _DataGridViewEx.Rows.Count)
                {
                    return;
                }
                DataTable dt = (DataTable)_DataGridViewEx.DataSource;              
                Controller.DelOrder(dt,_rowindex, OrderKind, 0);               
            }
            this.SetPlace();
        }
        //保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.chkEdit.Checked = false;
            int colid, rowid;
            this.Cursor = PublicStaticFun.WaitCursor();
            _DataGridViewEx = this.dtgrdLong;
            bool Iserr = false;
            this.SetPlace(); //20100603.2.04 开医嘱界面修改剂量，不移开鼠标焦点保存后修改无效
            if (Controller.SaveOrder(0, out colid, out rowid))
            {
                _DataGridViewEx = this.dtgrdTemp;
                if (Controller.SaveOrder(1, out colid, out rowid))
                {
                    this.Cursor = Cursors.Default;
                }                    
                else
                {
                    this.Cursor = Cursors.Default;
                    this.tbOrder.SelectedIndex = 1;
                    this.dtgrdTemp.CurrentCell = dtgrdTemp[colid, rowid];
                    Iserr = true;
                }                           
            }
            else
            {
                Iserr = true;
                this.Cursor = Cursors.Default;
                this.tbOrder.SelectedIndex = 0;
                this.dtgrdLong.CurrentCell = dtgrdLong[colid, rowid];
            }
            if (!Iserr)
            {
                if (OrderKind == 0)
                {                   
                    this.tbOrder.SelectedIndex = 0;
                    _DataGridViewEx = dtgrdLong;
                    Controller.getOrderData(0);
                    this.SetPlace();
                }
                else
                {                   
                    this.tbOrder.SelectedIndex = 1;
                    _DataGridViewEx = dtgrdTemp;
                    this.SetPlace();
                }  
            }         
        }    
        //模板
        private void btnModel_Click(object sender, EventArgs e)
        {
            if (_DataGridViewEx == null || IsNotCanUse())
            {
                return;
            }
            if (zy_patlist_get == null)
            {
                MessageBox.Show("请先指定病人");
                return;
            }         
            this.chkEdit.Checked = false;
            HIS_ZYDocManager.基础数据.FrmDocModel model = new HIS_ZYDocManager.基础数据.FrmDocModel(_currentUser.UserID, _currentDept.DeptID);          
            model.ShowDialog();
            if (model.lists == null || model.lists.Count == 0)
            {
                this.SetPlace();
                return;
            }
            Controller.AddModelData(model.lists);
            this.SetPlace();
        }
        //发送
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || _DataGridViewEx.CurrentCell == null || IsNotCanUse())
            {
                return;
            }
            this.chkEdit.Checked = false;
            this.Cursor = PublicStaticFun.WaitCursor();
            if (Controller.SendOrder(OrderKind))
            {              
                this.Cursor = Cursors.Default;
                this.SetPlace();
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }
        //停嘱
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || _DataGridViewEx.CurrentCell == null || IsNotCanUse())
            {
                return;
            }         
            this.chkEdit.Checked = false;
            int nrow = _DataGridViewEx.CurrentCell.RowIndex;
            int ncol = _DataGridViewEx.CurrentCell.ColumnIndex;
            if (OrderKind == 0)
            {
                DataTable dt = this.BindLongOrderData;
                if (Convert.ToInt32(dt.Rows[nrow]["status_falg"].ToString().Trim()) == 2) // 已经转抄，没有停止
                {
                    bool b = Controller.StopCheck(nrow, ncol);
                    string frenqucy = _DataGridViewEx["frequency", nrow].Value.ToString();
                    if (b)
                    {
                        FrmStopOrder frmstop = new FrmStopOrder();
                        frmstop.frnquecy = frenqucy;
                        frmstop.beginDateTime = Convert.ToDateTime(dt.Rows[nrow]["order_bdate"]);
                        frmstop.ShowDialog();
                        if (frmstop.IsStop)
                        {
                            int num = frmstop.num;
                            DateTime edate = frmstop.endtime;
                            bool a = Controller.StopOrders(nrow, num, edate, Convert.ToInt32(dt.Rows[nrow]["group_id"].ToString().Trim()), 0);
                            if (a)
                            {
                                MessageBox.Show("停医嘱成功！");
                            }
                            else
                            {
                                MessageBox.Show("停医嘱失败！\n");
                            }
                        }
                    }
                }
                if (Convert.ToInt32(dt.Rows[nrow]["status_falg"].ToString().Trim()) == 3)//已经停止的医嘱可以取消停
                {
                    Controller.StopOrders(nrow, 0, HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime, Convert.ToInt32(dt.Rows[nrow]["group_id"].ToString().Trim()), 1);
                }
                Controller.getOrderData(0);
            }
            _DataGridViewEx.CurrentCell = _DataGridViewEx[2,nrow];
        }
        //交病人
        private void btnGave_Click(object sender, EventArgs e)
        {
            this.chkEdit.Checked = false;
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || _DataGridViewEx.CurrentCell == null || IsNotCanUse())
            {
                return;
            }                   
            int nrow = _DataGridViewEx.CurrentCell.RowIndex;
            int ncol = _DataGridViewEx.CurrentCell.ColumnIndex;          
            if (Controller.OrderToPat(nrow,ncol,OrderKind,"交病人","5")) 
            {
                Controller.getOrderData(OrderKind);
            }
            _DataGridViewEx.CurrentCell = _DataGridViewEx[2, nrow];
        }
        //出院带药
        private void BtnOutDrug_Click(object sender, EventArgs e)
        {
            this.chkEdit.Checked = false;
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || _DataGridViewEx.CurrentCell == null || IsNotCanUse())
            {
                return;
            }               
            int nrow = _DataGridViewEx.CurrentCell.RowIndex;
            int ncol = _DataGridViewEx.CurrentCell.ColumnIndex;            
            if (Controller.OrderToPat(nrow,ncol,OrderKind,"出院带药","7"))
            {
                Controller.getOrderData(OrderKind);
            }
            _DataGridViewEx.CurrentCell = _DataGridViewEx[2, nrow];
        }
        //中药脚注
        private void btnjz_Click(object sender, EventArgs e)
        {
            this.chkEdit.Checked = false;
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || _DataGridViewEx.CurrentCell == null || IsNotCanUse() || OrderKind==0)
            {
                return;
            }                    
            int nrow = _DataGridViewEx.CurrentCell.RowIndex;
            int ncol = _DataGridViewEx.CurrentCell.ColumnIndex;
            DataTable tb = new DataTable();
            tb = this.BindTempOrderData;
            if (tb.Rows.Count == 0 || tb.Rows[nrow]["order_content"] == System.DBNull.Value )
            {
                return;
            }
            if (Convert.ToInt32(tb.Rows[nrow]["status_falg"].ToString()) > 1)
            {
                MessageBox.Show("该医嘱已执行");
                return;
            }
            if (Convert.ToInt32(tb.Rows[nrow]["item_type"].ToString()) != 3)
            {
                MessageBox.Show("该医嘱不属于中草药");
                return;
            }          
            FrmJZ jz = new FrmJZ();
            jz.ShowDialog();
            note = jz.note;
            if (note.Trim() != "")
            {
                Controller.AddJz(nrow,note);
            }
            _DataGridViewEx.CurrentCell = _DataGridViewEx[2, nrow];
        }
        //刷新
        private void btnbrush_Click(object sender, EventArgs e)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count==0)
            {
                this.Cursor = PublicStaticFun.WaitCursor();
                _DataGridViewEx.DataSource = null;
                Controller.getOrderData(OrderKind);
                this.Cursor = Cursors.Default;
                this.SetPlace();
                return;
            }
            this.chkEdit.Checked = false;
            DataTable dt = (DataTable)_DataGridViewEx.DataSource;
            int i;
            for ( i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (dt.Rows[i]["status_falg"].ToString() == "-1")
                {
                    if (MessageBox.Show("还有未保存的医嘱，需要先保存吗？", "保存提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int colid, rowid;
                        if (IsNotCanUse())
                        {
                            return;
                        }
                        this.Cursor = PublicStaticFun.WaitCursor();
                        if (Controller.SaveOrder(OrderKind, out colid, out rowid))
                        {                            
                            _DataGridViewEx.DataSource = null;
                            Controller.getOrderData(OrderKind);
                            this.Cursor = Cursors.Default;
                            this.SetPlace();
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            _DataGridViewEx.CurrentCell = _DataGridViewEx[colid, rowid];
                            break;
                        }                       
                    }
                    else
                    {
                        this.Cursor = PublicStaticFun.WaitCursor();
                        _DataGridViewEx.DataSource = null;
                        Controller.getOrderData(OrderKind);
                        this.Cursor = Cursors.Default;
                        this.SetPlace();
                        break;
                    }
                }               
            }
            if (i == -1)
            {
                this.Cursor = PublicStaticFun.WaitCursor();
                _DataGridViewEx.DataSource = null;
                Controller.getOrderData(OrderKind);
                this.Cursor = Cursors.Default;
                this.SetPlace();
            }
        }
        //自由录入
        private void chkEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || _DataGridViewEx.CurrentCell == null || IsNotCanUse())
            {
                this.ItemNameReadOnly = true;
                _DataGridViewEx.HideSelectionCardWhenCustomInput = false;
                return;
            }        
            int rowindex = _DataGridViewEx.CurrentCell.RowIndex;
            int colindex = _DataGridViewEx.CurrentCell.ColumnIndex;
            if (chkEdit.Checked == true)
            {
                DataTable dt = (DataTable)_DataGridViewEx.DataSource;
                if (Convert.ToInt32(dt.Rows[rowindex]["status_falg"].ToString()) > 1)
                {
                    MessageBox.Show("该医嘱已转抄，不能再自由录入");
                    return;
                }
                MessageBox.Show("修改医嘱内容状态，不产生新的医嘱费用");
                this.ItemNameReadOnly = false;
                _DataGridViewEx.HideSelectionCardWhenCustomInput = true;
                if (dt.Rows[rowindex]["order_content"].ToString().Trim() == "")
                {
                    dt.Rows[rowindex]["order_content"] = _DataGridViewEx[2, rowindex].Value.ToString();
                    dt.Rows[rowindex]["status_falg"] = -1;
                    dt.Rows[rowindex]["item_type"] = 7;
                    dt.Rows[rowindex]["orecord_a2"] = 0;
                    dt.Rows[rowindex]["pres_deptid"] = _currentDept.DeptID;
                    dt.Rows[rowindex]["order_doc"] = _currentUser.EmployeeID;
                    dt.Rows[rowindex]["order_type"] = OrderKind;
                    dt.Rows[rowindex]["first"] = 1;
                    dt.Rows[rowindex]["firset_times"] = 1;
                }
                else
                {
                    if (dt.Rows[rowindex]["orecord_a2"].ToString().Trim() == "1")
                    {
                        dt.Rows[rowindex]["orecord_a2"] = 2;
                        dt.Rows[rowindex]["status_falg"] = -1;
                    }
                    dt.Rows[rowindex]["order_content"] = _DataGridViewEx[2, rowindex].Value.ToString();
                    Controller.ColorPaint(dt);
                }
            }
            else
            {
                this.ItemNameReadOnly = true;
                _DataGridViewEx.HideSelectionCardWhenCustomInput = false;
            }
            _DataGridViewEx.CurrentCell = _DataGridViewEx[2, rowindex];
        }
        //自备
        private void btnSelf_Click(object sender, EventArgs e)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || _DataGridViewEx.CurrentCell == null || IsNotCanUse())
            {
                return;
            }          
            this.chkEdit.Checked = false;
            int rowid = _DataGridViewEx.CurrentCell.RowIndex;
            int colid = _DataGridViewEx.CurrentCell.ColumnIndex;
            Controller.InsertSelfMed((DataTable)_DataGridViewEx.DataSource, rowid, colid);
            _DataGridViewEx.CurrentCell = _DataGridViewEx[2, rowid];
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }   
       
        #endregion

        #region 右键事件
        private void 插入一行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || IsNotCanUse())
            {
                return;
            }
            int currentRow = _DataGridViewEx.CurrentCell.RowIndex;
            DataTable tb = new DataTable();
            if (OrderKind == 0)
            {
                tb = this.BindLongOrderData;
            }
            if (OrderKind == 1)
            {
                tb = this.BindTempOrderData;
            }
            if (Convert.ToInt32(tb.Rows[currentRow]["status_falg"].ToString().Trim()) > 0)
            {
                MessageBox.Show("该医嘱已发送，不能插入一行");
                return;
            }
            if (Convert.ToInt32(tb.Rows[currentRow]["item_type"].ToString().Trim()) > 3)
            {
                return;
            }
            int order_type;
            if (tb.Rows[currentRow]["order_content"].ToString().Trim() != "")
            {
                order_type = Convert.ToInt32(tb.Rows[currentRow]["item_type"].ToString().Trim());
                DataTable tb1 = tb.Copy();
                tb1.Rows.Clear();
                for (int i = 0; i <= currentRow; i++)
                {
                    tb1.Rows.Add(tb.Rows[i].ItemArray);
                }
                DataRow dr = tb1.NewRow();
                dr["status_falg"] = -1;
                dr["begintime"] = Controller.timeformat;
                dr["orecord_a1"] = 1;//标志。表示是右键新插入的行   
                dr["orecord_a2"] = 0;
                dr["makedicid"] = 0;
                tb1.Rows.Add(dr);
                for (int i = currentRow + 1; i < tb.Rows.Count; i++)
                {
                    tb1.Rows.Add(tb.Rows[i].ItemArray);
                }
                if (OrderKind == 0)
                {
                    this.BindLongOrderData = null;
                    this.BindLongOrderData = tb1;
                }
                if (OrderKind == 1)
                {
                    this.BindTempOrderData = null;
                    this.BindTempOrderData = tb1;
                }
                Controller.RowsInsert(OrderKind, 1, order_type);
                _DataGridViewEx.CurrentCell = _DataGridViewEx[2, currentRow + 1];
                Controller.ColorPaint(tb1);
            }
        }
        private void 删除当前行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || _DataGridViewEx.CurrentCell == null)
            {
                return;
            }
            if (_DataGridViewEx.CurrentCell != null)
            {
                int _rowindex = _DataGridViewEx.CurrentCell.RowIndex;
                if (_rowindex >= _DataGridViewEx.Rows.Count)
                {
                    return;
                }
                DataTable dt = (DataTable)_DataGridViewEx.DataSource;

                if (Controller.DelOrder(dt,_rowindex, OrderKind, 0))
                {
                   // Controller.getOrderData(OrderKind);
                }
                 this.SetPlace();
            }
        }
        private void 删除一组ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || _DataGridViewEx.CurrentCell == null)
            {
                return;
            }
            if (_DataGridViewEx.CurrentCell != null && _DataGridViewEx.Rows.Count > 0)
            {
                int _rowindex = _DataGridViewEx.CurrentCell.RowIndex;
                if (_rowindex >= _DataGridViewEx.Rows.Count)
                {
                    return;
                }
                DataTable dt = (DataTable)_DataGridViewEx.DataSource;
                if (Controller.DelOrder(dt,_rowindex, OrderKind, 1))
                {
                  //  Controller.getOrderData(OrderKind);
                }
                this.SetPlace();
            }
        }
        private void 刷新选项卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = PublicStaticFun.WaitCursor();       
            Controller.ReloadINFO();
            Controller.YfSelect(OrderKind); // add by heyan 2010.11.19刷新选项卡时根据药房选择
            this.Cursor = Cursors.Default;
            this.SetPlace();
        }
        private void 医嘱复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || _DataGridViewEx.CurrentCell == null || IsNotCanUse())
            {
                this.SetPlace();
                return;
            } 
            //Controller.Copy(OrderKind, _DataGridViewEx.CurrentCell.RowIndex);
            //this.SetPlace();
            Controller.Copy((DataTable)_DataGridViewEx.DataSource, _DataGridViewEx.CurrentCell.RowIndex);
            this.SetPlace();
        }
        private void 增加皮试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || _DataGridViewEx.CurrentCell == null || IsNotCanUse())
            {
                return;
            }           
            DataTable myTb = (DataTable)_DataGridViewEx.DataSource;
            int nrow;
            nrow = _DataGridViewEx.CurrentCell.RowIndex;           
            Controller.OnInsertPS(myTb, nrow, OrderKind);
        }
        private void 作废医嘱ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || _DataGridViewEx.CurrentCell == null || IsNotCanUse())
            {
                return;
            }            
            if (OrderKind != 1)
            {
                MessageBox.Show("只有临时医嘱可以作废");
                return;
            }
            int nrow, ncol;
            //首先得到当前网格的信息
            DataTable myTb = ((DataTable)_DataGridViewEx.DataSource);
            nrow = _DataGridViewEx.CurrentCell.RowIndex;
            ncol = _DataGridViewEx.CurrentCell.ColumnIndex;
            if (myTb.Rows[nrow]["order_content"].ToString() == "")
            {
                return;
            }
            if (myTb.Rows[nrow]["status_falg"].ToString() != "5")
            {
                if (Convert.ToInt32(myTb.Rows[nrow]["status_falg"].ToString()) > 1)
                {
                    MessageBox.Show("该医嘱已执行，不能删除");
                    return;
                }
                if (myTb.Rows[nrow]["status_falg"].ToString() == "-1" || myTb.Rows[nrow]["status_falg"].ToString() == "0" || myTb.Rows[nrow]["status_falg"].ToString() == "1")
                {

                    Controller.DelOrder(myTb,nrow, OrderKind, 0);
                }
                return;
            }
            try
            {
                if (myTb.Rows[nrow]["order_content"].ToString().IndexOf("【取消】") == 0)
                {
                    MessageBox.Show("该医嘱已经作废！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("是否作废“" + myTb.Rows[nrow]["order_content"].ToString().Trim() + "”？", "作废提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }              
                if (Controller.AbolishOrder(myTb, nrow))
                {
                    Controller.getOrderData(OrderKind);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("医嘱作废失败！\n" + err.ToString(), "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }      
        #endregion   
       
        #region 库存不足提示
        private void dtgrdLong_MouseClick(object sender, MouseEventArgs e)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || _DataGridViewEx.CurrentCell == null)
            {
                return;
            }
            int rowindex = _DataGridViewEx.CurrentCell.RowIndex;
            if (_DataGridViewEx[2, rowindex].Style.BackColor == Color.Turquoise)            
            {
                this.plStoreTs.Visible = true;
                this.lbStoreTs.Visible = true;
                this.plStoreTs.Top = _DataGridViewEx.GetCellDisplayRectangle(2, rowindex, false).Bottom;
            }
            else
            {
                this.plStoreTs.Visible = false;
                this.lbStoreTs.Visible = false;
            }
        }
        #endregion

        #region 增加出院病人查询功能
        //按住院号查询
        private void cbcureno_CheckedChanged(object sender, EventArgs e)
        {
            if (cbcureno.Checked)
            {
                txtCureNo.Enabled = true;
            }
            else
            {
                txtCureNo.Enabled = false;
                txtCureNo.Text = "";
            }
        }
        private void txtCureNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
            {
                return;
            }
            else
            {
                this.lvPatList.Items.Clear();
                List<HIS.Model.ZY_PatList> zypatlist = null;
                zypatlist = HIS.ZYDoc_BLL.PatInfo.PatOperation.GetOutPatCureNo(txtCureNo.Text.Trim());
                if (zypatlist == null)
                {
                    return;
                }
                this.AddPatientList(zypatlist);
                this.lbout.Text = zypatlist.Count + " 人";
            }
        }
        //按病人姓名查询
        private void cbname_CheckedChanged(object sender, EventArgs e)
        {
            if (cbname.Checked)
            {
                txtPatName.Enabled = true;
            }
            else
            {
                txtPatName.Enabled = false;
                txtPatName.Text = "";
            }
        }        
        private void txtPatName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
            {
                return;
            }
            else
            {
                this.lvPatList.Items.Clear();
                List<HIS.Model.ZY_PatList> zypatlist = null;
                zypatlist = HIS.ZYDoc_BLL.PatInfo.PatOperation.GetOutPatName(txtPatName.Text.Trim());
                if (zypatlist == null)
                {
                    return;
                }
                this.AddPatientList(zypatlist);
                this.lbout.Text = zypatlist.Count + " 人";
            }
        }
        #endregion         

        #region 药房选择
        private void cbYf_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller.YfSelect(OrderKind);
        }
        #endregion    

        #region 电子病历
        //增加电子病历控件
        public Control EmrControl
        {
            set
            {
                value.Dock = DockStyle.Fill;
                this.panelEmr.Controls.Clear();
                HIS_EMRManager.EMRControlPanel control = value as HIS_EMRManager.EMRControlPanel;
                control.EMRSaved += new EventHandler(control_EMRSaved);  //* 2010051201.04  加电子病历保存时自动刷新
                this.panelEmr.Controls.Add(value);
            }
        }
        //增加病程记录结点
        public void CouserNodeAdd(string name, string value)
        {
            TreeNode node = new TreeNode();
            node.Text = name;
            node.Tag = value;
            node.ImageIndex = 14;
            this.TvEmrType.Nodes[1].Nodes.Add(node);
        }
        //获得结点绑定的Tag 
        public string Nodetag
        {
            get
            {
                return TvEmrType.SelectedNode.Tag.ToString();
            }
        }

        private void TvEmrType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (TvEmrType.SelectedNode.Text == "入院记录")
            {
                Controller.GetEmr(0);
            }
            else if (TvEmrType.SelectedNode.Text == "出院记录")
            {
                Controller.GetEmr(2);
            }
            else if (TvEmrType.SelectedNode.Text == "死亡记录")//2010-7-13 add by zengyan 添加死亡记录
            {
                Controller.GetEmr(3);
            }
            else if (TvEmrType.SelectedNode.Text == "手术记录")//2010-7-14 add by zengyan 添加死亡记录
            {
                Controller.GetEmr(4);
            }
            else
            {
                //update by zengyan 2010-5-14 只有选中的是【病程记录】节点，才清除其子节点
                //TvEmrType.Nodes[1].Nodes.Clear();
                if (TvEmrType.SelectedNode.Text == "病程记录")
                {
                    //add
                    TvEmrType.Nodes[1].Nodes.Clear();
                    Controller.GetCourseCount();
                }

                if (TvEmrType.SelectedNode.Text != "病程记录")
                {
                    Controller.GetEmr(1);
                }
            }
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            Controller.AddCourse();
            TvEmrType.Nodes[1].Nodes.Clear();
            Controller.GetCourseCount();
        }

        private void lkEmrBrush_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TvEmrType.Nodes[1].Nodes.Clear();
            Controller.GetCourseCount();
        }

        void control_EMRSaved(object sender, EventArgs e)
        {
            lkEmrBrush_LinkClicked(null, null);
        }
        #endregion     


        //* 20100613.1.08 病人会诊，在诊疗管理界面加住院号查询，可以看到其他科在床的病人，可以看到其他科室开的医嘱
        private void txtCurenoFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.lvPatList.Items.Clear();
                this.label2.Text = 0 + " 人";
                List<HIS.Model.ZY_PatList> zypatlist = null;
                zypatlist = HIS.ZYDoc_BLL.PatInfo.PatOperation.GetPlistByno(txtCurenoFind.Text);
                if (zypatlist == null || zypatlist.Count == 0)
                {
                    return;
                }
                this.AddPatientList(zypatlist);
                this.label2.Text = zypatlist.Count + " 人";
 
            }
        }
        
    }
}
