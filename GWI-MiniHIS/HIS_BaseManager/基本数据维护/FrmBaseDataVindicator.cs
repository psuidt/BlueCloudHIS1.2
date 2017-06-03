using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS_BaseManager.基本数据维护.Controller;
using HIS.Base_BLL;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS_BaseManager.基本数据维护
{
    /// <summary>
    /// 基础数据维护
    /// </summary>
    public partial class FrmBaseDataVindicator : BaseMainForm, IFrmBaseDataVindicatorView
    {
        #region IFrmBaseDataVindicatorView 成员

        public TableConfig SelectedTable
        {
            get
            {
                if (tvwTable.SelectedNode == null)
                    throw new Exception("没有选择数据表");
                if (tvwTable.SelectedNode.Tag == null)
                    throw new Exception("选择的数据表不正确");
                return (TableConfig)tvwTable.SelectedNode.Tag;
            }
        }
        public string FilterKeyWord
        {
            get
            {
                return txtKeyword.Text.Trim();
            }
        }
        #endregion

        FrmBaseDataVindicatorController controller;

        private User _currentUser;

        private void CreateTableListTree()
        {
            tvwTable.Nodes.Clear();
            TreeNode topNode = new TreeNode();
            topNode.Text = "基础数据";
            topNode.Tag = null;
            topNode.ImageIndex = 0;
            for( int i=0;i < controller.BastTableList.Count; i ++)
            {
                TreeNode tbNode = new TreeNode();
                tbNode.Text = controller.BastTableList[i].BASE_TABLE_CN_NAME;
                tbNode.Tag = controller.BastTableList[i];
                if ( controller.BastTableList[i].ALLOW_USER_EDIT )
                {
                    tbNode.ImageIndex = 1;
                    tbNode.SelectedImageIndex = 1;
                }
                else
                {
                    tbNode.ImageIndex = 2;
                    tbNode.SelectedImageIndex = 2;
                }

                topNode.Nodes.Add( tbNode );
            }
            
            tvwTable.Nodes.Add( topNode );
            topNode.Expand();
            //tvwTable.ExpandAll();
        }
        /// <summary>
        /// 基础数据维护
        /// </summary>
        public FrmBaseDataVindicator(string FormText,User CurrentUser )
        {
            InitializeComponent();

            this.FormTitle = FormText;
            this.Text = FormText;
            _currentUser = CurrentUser;
        }

        private void btnClose_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void FrmBaseDataVindicator_Load( object sender, EventArgs e )
        {
            this.dgvData.DataError += new DataGridViewDataErrorEventHandler( dgvData_DataError );
            controller  = new FrmBaseDataVindicatorController( this );
            controller.DataGrid = this.dgvData;
            controller.PropertyPanel = this.plEditControl;
            controller.Initialize();

            CreateTableListTree();

            tvwTable.AfterSelect += new TreeViewEventHandler( tvwTable_AfterSelect );
            dgvData.CurrentCellChanged += new EventHandler( dgvData_CurrentCellChanged );
            txtKeyword.KeyPress += new KeyPressEventHandler( txtKeyword_KeyPress );

            if (!_currentUser.IsAdministrator)
            {
                plConfig.Enabled = false;
            }
        }

        void txtKeyword_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
                btnFind_Click( null, null );
        }

        void dgvData_DataError( object sender, DataGridViewDataErrorEventArgs e )
        {
            e.Cancel = true;
        }

        void tvwTable_AfterSelect( object sender, TreeViewEventArgs e )
        {
            if ( e.Node.Tag == null )
            {
                if ( e.Node.Parent == null )
                {
                    if ( e.Node.Nodes.Count > 0 )
                    {
                        tvwTable.SelectedNode = e.Node.Nodes[0];
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            controller.CreateControls();
            
            
            controller.ShowDataInGrid();
            

            controller.ShowRecordContent();

            if ( ( (TableConfig)tvwTable.SelectedNode.Tag ).ALLOW_PHYSIC_DELETE )
            {
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
            }

            if ( ( (TableConfig)tvwTable.SelectedNode.Tag ).ALLOW_USER_EDIT )
            {
                btnAddNew.Visible = true;
                btnSave.Visible = true;
            }
            else
            {
                btnAddNew.Visible = false;
                btnSave.Visible = false;
            }
        }

        void dgvData_CurrentCellChanged( object sender, EventArgs e )
        {
            btnAddNew.Enabled = true;
            btnDelete.Enabled = true;
            controller.ShowRecordContent();
            
        }

        private void btnTableConfig_Click( object sender, EventArgs e )
        {
            if ( tvwTable.SelectedNode == null )
            {
                MessageBox.Show( "请选择需要配置的表","",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                return;
            }
            if ( tvwTable.SelectedNode.Tag == null )
                return;

            FrmVindicatorConfig frmConfig = new FrmVindicatorConfig( (TableConfig)tvwTable.SelectedNode.Tag );
            frmConfig.ShowDialog();

        }

        private void btnRefreshConfig_Click( object sender, EventArgs e )
        {
            tvwTable.AfterSelect -= new TreeViewEventHandler( tvwTable_AfterSelect );

            controller.DataGrid = this.dgvData;
            controller.PropertyPanel = this.plEditControl;
            controller.Initialize();

            CreateTableListTree();

            tvwTable.AfterSelect += new TreeViewEventHandler( tvwTable_AfterSelect );
            if ( tvwTable.Nodes.Count > 0 )
            {
                if ( tvwTable.Nodes[0].Nodes.Count > 0 )
                {
                    tvwTable.SelectedNode = tvwTable.Nodes[0].Nodes[0];
                }
                else
                {
                    dgvData.Columns.Clear();
                    plEditControl.Controls.Clear();
                }
            }
            else
            {
                dgvData.Columns.Clear();
                plEditControl.Controls.Clear();
            }
        }

        private void btnAddNew_Click( object sender, EventArgs e )
        {
            btnAddNew.Enabled = false;
            btnDelete.Enabled = false;
            controller.SetAddNewStatus();
        }

        private void btnSave_Click( object sender, EventArgs e )
        {
            try
            {
                if ( btnAddNew.Enabled == true )
                {
                    //保存当前修改的记录begin
                    controller.UpdateBaseDataRecord();
                    //保存当前修改的记录end
                }
                else
                {
                    //保存新增加的记录begin
                    controller.AddNewBaseDataRecord();
                    //保存新增加的记录end

                    //成功将新增按钮置可用
                    btnAddNew.Enabled = true;
                    btnDelete.Enabled = true;
                }
                if ( !chkMessage.Checked )
                    MessageBox.Show( "记录保存成功！", "", MessageBoxButtons.OK,MessageBoxIcon.Information );

            }
            catch(Exception err)
            {
                MessageBox.Show( err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void btnRefresh_Click( object sender, EventArgs e )
        {
            if ( tvwTable.SelectedNode == null )
            {
                MessageBox.Show( "刷新请先选择基础数据类别！","",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                return;
            }

            dgvData.CurrentCellChanged -= new EventHandler( dgvData_CurrentCellChanged );
            controller.CreateControls();
            controller.ShowDataInGrid();
            dgvData.CurrentCellChanged += new EventHandler( dgvData_CurrentCellChanged );

            controller.ShowRecordContent();
        }

        private void btnFind_Click( object sender, EventArgs e )
        {
            try
            {
                controller.FilterGridData();
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void btnResetFind_Click( object sender, EventArgs e )
        {
            txtKeyword.Clear();
            btnFind_Click( null, null );
        }

        private void btnTableInfo_Click( object sender, EventArgs e )
        {
            FrmTableConfig frmTableConfig = new FrmTableConfig();
            frmTableConfig.ShowDialog();
            btnRefreshConfig_Click( null, null );
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                controller.DeleteBaseDataRecord();
                MessageBox.Show("记录已删除！请刷新", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}
