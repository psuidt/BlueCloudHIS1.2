using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.EMR_BLL;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS_EMRManager
{
    /// <summary>
    /// 病历模板设置界面
    /// </summary>
    internal partial class FrmEmrMouldSite : GWI.HIS.Windows.Controls.BaseMainForm, IFrmEmrMouldSiteView
    {
        private User _currentUser;  //当前用户
        private Deptment _currentDept;  //当前科室

        private DataTable _chiefElement;   //主元素数据
        private HIS.EMR_BLL.EmrElement _currentChiefElement;   //当前主元素
        private HIS.EMR_BLL.EmrMould _currentMould;    //当前模板

        private HIS.EMR_BLL.EmrElement _currentElement;     //当前元素
        private HIS.EMR_BLL.EmrElementMould _currentElementMould;     //当前元素模板

        private FrmEmrMouldSiteController Controller;  //控制器

        public FrmEmrMouldSite(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            this.Text = chineseName;
            this.FormTitle = chineseName;

            Controller = new FrmEmrMouldSiteController(this);
        }

        #region IFrmEmrMouldSiteView 成员
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
        public int CurrentMouldLevel
        {
            get
            {
                return Convert.ToInt32(this.tVWholeLevel.SelectedNode.Tag);
            }
        }
        //模板列表
        public DataTable MouldList
        {
            set
            {
                this.tVEmrClass.Nodes.Clear();
                TreeNode node = new TreeNode("全部模板", 15, 14);
                HIS.EMR_BLL.EmrElement element = new HIS.EMR_BLL.EmrElement();
                element.ElementCode = "00";
                element.ElementName = "全部模板";
                element.P_ElementCode = "";
                element.ElementLevel = 0;
                node.Tag = null;
                this.tVEmrClass.Nodes.Add(node);

                for (int index = 0; index < _chiefElement.Rows.Count; index++)
                {
                    element = (HIS.EMR_BLL.EmrElement)HIS.MZDoc_BLL.Public.Function.DataRowToObject<HIS.EMR_BLL.EmrElement>(_chiefElement.Rows[index]);
                    TreeNode childNode = new TreeNode(element.ElementName, 15, 14);
                    childNode.Tag = element;
                    childNode.ContextMenuStrip = this.cMnSChief;
                    node.Nodes.Add(childNode);
                    CreateMouldTreeNode(childNode, element.ElementCode, value);
                }
                this.tVEmrClass.ExpandAll();
            }
        }
        //当前模板
        public HIS.EMR_BLL.EmrMould CurrentMould
        {
            get
            {
                return _currentMould;
            }
            set
            {
                _currentMould = value;
            }
        }
        //当前元素模板级别
        public int CurrentElementMouldLevel
        {
            get
            {
                return Convert.ToInt32(this.tVElementLevel.SelectedNode.Tag);
            }
        }
        //主要元素
        public DataTable ChiefElement
        {
            get { return _chiefElement; }
            set { _chiefElement = value; }
        }
        //元素列表
        public DataTable ElementList
        {
            set
            {
                this.tVEmrElement.Nodes.Clear();
                TreeNode node = new TreeNode("全部元素", 15, 14);
                HIS.EMR_BLL.EmrElement element = new HIS.EMR_BLL.EmrElement();
                element.ElementCode = "00";
                element.ElementName = "全部元素";
                element.P_ElementCode = "";
                element.ElementLevel = 0;
                node.Tag = element;
                this.tVEmrElement.Nodes.Add(node);
                CreateElementTreeNode(node, "00", value);
            }
        }
        //元素模板列表
        public DataTable ElementMouldList
        {
            set
            {
                this.dGVMouldList.AutoGenerateColumns = false;
                this.dGVMouldList.DataSource = value;
            }
        }
        //当前主要元素
        public HIS.EMR_BLL.EmrElement CurrentChiefElement
        {
            get
            {
                return _currentChiefElement;
            }
        }
        //当前元素
        public HIS.EMR_BLL.EmrElement CurrentElement
        {
            get { return _currentElement; }
        }
        //当前元素模板
        public HIS.EMR_BLL.EmrElementMould CurrentElementMould
        {
            get { return _currentElementMould; }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 创建模板列表
        /// </summary>
        /// <param name="node"></param>
        /// <param name="typeCode"></param>
        /// <param name="mouldTable"></param>
        private void CreateMouldTreeNode(TreeNode node, string typeCode, DataTable mouldTable)
        {
            if (mouldTable == null || mouldTable.Rows.Count <= 0)
                return;
            DataRow[] rows = mouldTable.Select(HIS.BLL.Tables.emr_mould_class.MOULDTYPE + "='" + typeCode + "' and " + HIS.BLL.Tables.emr_mould_class.MOULDCLASS+"<=0", HIS.BLL.Tables.emr_mould_class.MOULDID);
            if (rows != null && rows.Length > 0)
            {
                foreach (DataRow row in rows)
                {
                    HIS.EMR_BLL.EmrMould mould = (HIS.EMR_BLL.EmrMould)HIS.MZDoc_BLL.Public.Function.DataRowToObject<HIS.EMR_BLL.EmrMould>(row);
                    TreeNode childnode = new TreeNode(mould.MouldName, 21, 7);
                    childnode.Tag = mould;
                    childnode.ContextMenuStrip = this.cMnSMould;
                    node.Nodes.Add(childnode);
                    CreateMouldTreeNode(childnode, mould.MouldId, mouldTable);
                }
            }
        }

        /// <summary>
        /// 创建模板列表
        /// </summary>
        /// <param name="node"></param>
        /// <param name="classId"></param>
        /// <param name="mouldTable"></param>
        private void CreateMouldTreeNode(TreeNode node, int classId, DataTable mouldTable)
        {
            if (mouldTable == null || mouldTable.Rows.Count <= 0)
                return;
            DataRow[] rows = mouldTable.Select(HIS.BLL.Tables.emr_mould_class.MOULDCLASS + "=" + classId, HIS.BLL.Tables.emr_mould_class.MOULDID);
            if (rows != null && rows.Length > 0)
            {
                foreach (DataRow row in rows)
                {
                    HIS.EMR_BLL.EmrMould mould = (HIS.EMR_BLL.EmrMould)HIS.MZDoc_BLL.Public.Function.DataRowToObject<HIS.EMR_BLL.EmrMould>(row);
                    TreeNode childnode = new TreeNode(mould.MouldName, 21, 7);
                    childnode.Tag = mould;
                    node.Nodes.Add(childnode);
                    CreateMouldTreeNode(childnode, mould.MouldId, mouldTable);
                }
            }
        }

        /// <summary>
        /// 创建元素列表
        /// </summary>
        /// <param name="node"></param>
        /// <param name="nodeCode"></param>
        /// <param name="elementTable"></param>
        private void CreateElementTreeNode(TreeNode node, string nodeCode, DataTable elementTable)
        {
            if (elementTable == null || elementTable.Rows.Count <= 0)
                return;
            DataRow[] rows = elementTable.Select(HIS.BLL.Tables.emr_base_element.P_ELEMENTCODE + "='" + nodeCode + "'", HIS.BLL.Tables.emr_base_element.ELEMENTCODE);
            if (rows != null && rows.Length > 0)
            {
                foreach (DataRow row in rows)
                {
                    HIS.EMR_BLL.EmrElement element = (HIS.EMR_BLL.EmrElement)HIS.MZDoc_BLL.Public.Function.DataRowToObject<HIS.EMR_BLL.EmrElement>(row);
                    TreeNode childnode = new TreeNode(element.ElementName, 21, 7);
                    childnode.Tag = element;
                    node.Nodes.Add(childnode);
                    CreateElementTreeNode(childnode, element.ElementCode, elementTable);
                }
            }
        }
        #endregion

        #region 事件
        private void FrmEmrMouldSite_Load(object sender, EventArgs e)
        {
        }

        #region 整体模板
        //选择模板级别
        private void tVWholeLevel_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Controller.LoadMouldData();
        }
        //新增模板
        private void tSMnIAdd_Click(object sender, EventArgs e)
        {
            Controller.AddMould();
        }
        //删除模板
        private void tSMnIDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除该模板？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Controller.DeleteMould();
            }
        }
        //重命名模板
        private void tSMnIRename_Click(object sender, EventArgs e)
        {
            if (Controller.RenameMould())
            {
                tVEmrClass.SelectedNode.Text = _currentMould.MouldName;
            }
        }
        //选择模板
        private void tVEmrClass_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.plWholeCenter.Controls.Clear();
            if (tVEmrClass.SelectedNode.Parent == null)
            {
            }
            else if (tVEmrClass.SelectedNode.Parent.Tag == null)
            {
                _currentChiefElement = (HIS.EMR_BLL.EmrElement)tVEmrClass.SelectedNode.Tag;
            }
            else
            {
                _currentMould = (HIS.EMR_BLL.EmrMould)tVEmrClass.SelectedNode.Tag;
                Control control = EMRRecordControlFactory.CreateEMRRecordControl(_currentMould.MouldType.Trim(), _currentMould.MouldContent);
                control.Dock = DockStyle.Fill;
                this.plWholeCenter.Controls.Add(control);
            }
        }
        //保存模板
        private void btSaveMould_Click(object sender, EventArgs e)
        {
            EMRControl panel = (EMRControl)(this.plWholeCenter.Controls[0]);
            _currentMould.MouldContent = panel.GetValue();
            if (Controller.SaveMould())
            {
                MessageBox.Show("保存成功！", "提示");
            }
        }
        #endregion

        #region 元素模板
        //选择模板级别
        private void tVElementLevel_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Controller.LoadElementMouldData();
        }
        //选择病历元素
        private void tVEmrElement_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this._currentElementMould = null;
            this.txtContent.Text = "";

            if (tVEmrElement.SelectedNode.Nodes.Count == 0)
            {
                this._currentElement = (HIS.EMR_BLL.EmrElement)tVEmrElement.SelectedNode.Tag;
                Controller.LoadElementMouldData();
            }
            else
            {
                this._currentElement = null;
                this.dGVMouldList.DataSource = null;
            }
        }
        //添加元素模板
        private void btAddElementMould_Click(object sender, EventArgs e)
        {
            this._currentElementMould = null;
            this.txtContent.Text = "";
        }
        //保存元素模板
        private void btSaveElementMould_Click(object sender, EventArgs e)
        {
            if (this._currentElement == null)
            {
                MessageBox.Show("请先在左边列表中指定模板对应的病历元素！","提示");
                return;
            }
            if (Controller.SaveElementMould(this.txtContent.Text))
            {
                MessageBox.Show("保存成功！", "提示");
            }
        }
        //删除元素模板
        private void btDelElementMould_Click(object sender, EventArgs e)
        {
            Controller.DeleteElementMould();
        }
        //选择元素模板
        private void dGVMouldList_CurrentCellChanged(object sender, EventArgs e)
        {
            DataTable table = (DataTable)dGVMouldList.DataSource;
            if (table != null && table.Rows.Count > 0 && dGVMouldList.CurrentCell!=null)
            {
                if (dGVMouldList.CurrentCell.RowIndex >= 0 && dGVMouldList.CurrentCell.RowIndex < table.Rows.Count)
                {
                    this._currentElementMould = (HIS.EMR_BLL.EmrElementMould)
                        HIS.MZDoc_BLL.Public.Function.DataRowToObject<HIS.EMR_BLL.EmrElementMould>(table.Rows[dGVMouldList.CurrentCell.RowIndex]);
                    this.txtContent.Text = this._currentElementMould.MouldContent;
                }
            }
        }
        #endregion

        #endregion
    }
}
