using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS_EMRManager
{
    /// <summary>
    /// 病历整体模板
    /// </summary>
    internal partial class FrmWholeMould : Form
    {
        private HIS.EMR_BLL.EmrMould _currentMould;    //当前模板
        private EMRControl _control;   //当前病历控件
        private Public.EMRType _currentType; //当前模板类型
        private bool _isSure = false;
        private int _level = 1;

        /// <summary>
        /// 病历整体模板
        /// </summary>
        /// <param name="type">病历类型</param>
        public FrmWholeMould(Public.EMRType type)
        {
            InitializeComponent();

            _currentType = type;
            this.btSave.Visible = false;
            this.tWMould.Nodes.Clear();
            this.tVWholeLevel.SelectedNode = this.tVWholeLevel.Nodes[2];
            tVWholeLevel_AfterSelect(null,null);
        }
        /// <summary>
        /// 病历整体模板
        /// </summary>
        /// <param name="type">病历类型</param>
        /// <param name="value">病历数据</param>
        public FrmWholeMould(Public.EMRType type, XmlDocument value)
        {
            InitializeComponent();

            this.btSure.Visible = false;
            this.plLeft.Visible = false;
            _currentType = type;

            _control = EMRRecordControlFactory.CreateEMRRecordControl(type, value);
            this.plCenter.AutoScroll = true;
            this.plCenter.Controls.Add(_control);
        }
        /// <summary>
        /// 病历整体模板
        /// </summary>
        /// <param name="type">病历类型</param>
        /// <param name="value">病历数据</param>
        /// <param name="level"></param>
        public FrmWholeMould(Public.EMRType type, XmlDocument value,int level)
        {
            InitializeComponent();

            this.btSure.Visible = false;
            this.plLeft.Visible = false;
            _currentType = type;
            _level = level;

            _control = EMRRecordControlFactory.CreateEMRRecordControl(type, value);
            this.plCenter.AutoScroll = true;
            this.plCenter.Controls.Add(_control);
        }
        /// <summary>
        /// 所选病历模板数据
        /// </summary>
        public XmlDocument SelectedValue
        {
            get
            {
                if (_control == null || !_isSure)
                {
                    return null;
                }
                return _control.GetValue();
            }
            set
            {
                _control.SetValue(value);
            }
        }

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
            DataRow[] rows = mouldTable.Select(HIS.BLL.Tables.emr_mould_class.MOULDTYPE + "='" + typeCode + "' and " + HIS.BLL.Tables.emr_mould_class.MOULDCLASS + "<=0", HIS.BLL.Tables.emr_mould_class.MOULDID);
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
        //选择模板
        private void tWMould_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.plCenter.Controls.Clear();
            if (this.tWMould.SelectedNode.Parent != null)
            {
                _currentMould = (HIS.EMR_BLL.EmrMould)this.tWMould.SelectedNode.Tag;

                _control = EMRRecordControlFactory.CreateEMRRecordControl(_currentMould.MouldType.Trim(), _currentMould.MouldContent);
                this.plCenter.AutoScroll = true;
                this.plCenter.Controls.Add(_control);
                this.txtName.Text = _currentMould.MouldName;
            }
        }
        //保存
        private void btSave_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text.Trim() == "")
            {
                MessageBox.Show("请先填写模板名称！", "提示");
                return;
            }
            try
            {
                HIS.EMR_BLL.EmrMould mould = new HIS.EMR_BLL.EmrMould();
                mould.MouldClass = -1;
                mould.MouldCreateDate = XcDate.ServerDateTime;
                mould.MouldCreateDept = (int)Public.PublicStaticFunction.CurrentDeptId;
                mould.MouldCreateEmp = (int)Public.PublicStaticFunction.CurrentEmployeeId;
                mould.MouldLevel = _level;
                mould.MouldName = this.txtName.Text.Trim();
                mould.MouldType = Public.PublicStaticFunction.GetEMRTypeCode(_currentType); ;
                mould.MouldContent = _control.GetValue();
                mould.Add();
                MessageBox.Show("保存成功！", "提示");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }
        //确定
        private void btSure_Click(object sender, EventArgs e)
        {
            _isSure = true;
            this.Close();
        }

        private void tVWholeLevel_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.tWMould.Nodes.Clear();
            HIS.EMR_BLL.EmrElement element = new HIS.EMR_BLL.EmrElement().CreateElement(Public.PublicStaticFunction.GetEMRTypeCode(_currentType));
            TreeNode node = new TreeNode(element.ElementName, 15, 14);
            node.Tag = element;
            this.tWMould.Nodes.Add(node);
            CreateMouldTreeNode(node, element.ElementCode, new HIS.EMR_BLL.EmrMould().GetAllMouldClass(
                Convert.ToInt32(tVWholeLevel.SelectedNode.Tag),
                Public.StaticVariable.CurrentRecordInfo.CreateEmpId,
                Public.StaticVariable.CurrentRecordInfo.CreateDeptId));
        }
    }
}
