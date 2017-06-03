using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.Base_BLL;
namespace HIS_BaseManager
{
    public partial class FrmDeptAttr : GWI.HIS.Windows.Controls.BaseForm
    {
        System.Windows.Forms.ListView lvw;
        Department department;

       

        public FrmDeptAttr(System.Windows.Forms.ListView Lvw)
        {
            InitializeComponent( );
            lvw = Lvw;
        }

        public FrmDeptAttr( System.Windows.Forms.ListView Lvw , HIS.Base_BLL.DepartmentLayer layer )
        {
            InitializeComponent( );
            lvw = Lvw;
            txtParentDept.Text = layer.LayerName;
            txtParentDept.Tag = layer;
        }

        public FrmDeptAttr( System.Windows.Forms.ListView Lvw , Department Department )
        {
            InitializeComponent( );
            lvw = Lvw;
            department = Department;
        }

        private void FrmDeptAttr_Load( object sender , EventArgs e )
        {
            cboDeptType.DisplayMember = "NAME";
            cboDeptType.ValueMember = "CODE";
            cboDeptType.DataSource = HIS.Base_BLL.BaseDataReader.Base_Dept_Type;

            cboStdDept.DisplayMember = "SUB_ITEM_NAME";
            cboStdDept.ValueMember = "SUB_CODE";
            cboStdDept.DataSource = HIS.Base_BLL.BaseDataReader.Get_Standard_DeptList();

            if ( department != null )
            {
                txtDeptName.Text = department.Name;
                HIS.Base_BLL.DepartmentLayer layer = new HIS.Base_BLL.DepartmentLayer( Convert.ToInt32( department.P_DeptID ) );
                txtParentDept.Text = layer.LayerName;
                txtParentDept.Tag = layer;
                chkMZ.Checked = department.MZ_Flag == 1 ? true : false;
                chkZY.Checked = department.ZY_Flag == 1 ? true : false;
                chkJZ.Checked = department.JZ_Flag == 1 ? true : false;
                chkSs.Checked = department.SmFlag == 1 ? true : false;

                chkNoUse.Checked = department.NoUse == 1 ? true : false;
                txtDeptAddr.Text = department.DeptAddr;
                cboDeptType.SelectedValue = department.Type_Code;
                cboStdDept.SelectedValue = department.Code;
                this.Text = department.Name + " 的属性";
            }
            else
            {
                this.Text = "增加科室";
            }
        }

        private void btnOk_Click( object sender , EventArgs e )
        {
            if ( txtParentDept.Tag == null )
            {
                MessageBox.Show( "上级科室不能为空" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }
            if ( cboDeptType.SelectedValue == null )
            {
                MessageBox.Show( "没有指定科室类型" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }
            if ( department == null )
                department = new Department( );

            department.Name = txtDeptName.Text;
            department.P_DeptID = ( (DepartmentLayer)txtParentDept.Tag ).LayerID;
            department.DG_Code = "";
            department.MZ_Flag = chkMZ.Checked ? 1 : 0;
            department.ZY_Flag = chkZY.Checked ? 1 : 0;
            department.JZ_Flag = chkJZ.Checked ? 1 : 0;
            department.SmFlag = chkSs.Checked ? 1 : 0;
            
            department.DeptAddr = txtDeptAddr.Text;
            string[] pywb =GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.GetPyWbCode(department.Name);
            department.PY_Code = pywb[0];
            department.WB_Code = pywb[1];
            department.NoUse = chkNoUse.Checked ? 1 : 0;
            department.Type_Code = cboDeptType.SelectedValue.ToString( );
            if ( cboStdDept.SelectedValue == null )
                department.Code = "";
            else
                department.Code = cboStdDept.SelectedValue.ToString();
            try
            {
                if ( department.DeptID == 0 )
                {
                    if ( Department.NameExists( department ) )
                    {
                        department = null;
                        MessageBox.Show( "名称已经存在！请重新输入","",MessageBoxButtons.OK,MessageBoxIcon.Error );
                        txtDeptName.Focus( );
                        txtDeptName.SelectAll( );
                        
                        return;
                    }
                    if ( department.Save( ) )
                    {
                        ListViewItem item = new ListViewItem( );
                        item.Text = department.Name;
                        item.ImageIndex = 3;
                        item.Tag = department;
                        lvw.Items.Add( item );

                        txtDeptName.Text = "";
                        txtDeptAddr.Text = "";
                        chkMZ.Checked = false;
                        chkZY.Checked = false;
                        chkJZ.Checked = false;
                        chkSs.Checked = false;
                        txtDeptName.Focus( );
                        department = null;
                    }
                }
                else
                {
                    if ( Department.NameExists( department ) )
                    {
                        MessageBox.Show( "名称已经存在！请重新输入" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                        txtDeptName.Focus( );
                        txtDeptName.SelectAll( );

                        return;
                    }
                    if ( department.Update( ) )
                    {
                        lvw.SelectedItems[0].Text = department.Name;
                        lvw.SelectedItems[0].Tag = department;
                        this.Close( );
                    }
                }
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }

        private void btnParent_Click( object sender , EventArgs e )
        {
            Form frmSelect = new Form( );
            TreeView tree = new TreeView( );
            tree.Name = "tvwLayer";
            DataTable tbLayer = DepartmentLayer.GetAllLayer( );
            DataRow[] drTop = tbLayer.Select( "P_LAYER_ID = 0 " );
            for ( int i = 0 ; i < drTop.Length ; i++ )
            {
                DepartmentLayer dept = new DepartmentLayer( drTop[i] );
                TreeNode node = new TreeNode( );
                node.Text = dept.LayerName;
                node.Tag = dept;
                
                AddSubLayerNode( node , tbLayer );
                tree.Nodes.Add( node );
            }

            tree.Dock = DockStyle.Top;
            tree.Height = frmSelect.Height * 4 / 5;
            frmSelect.StartPosition = FormStartPosition.CenterScreen;
            frmSelect.FormBorderStyle = FormBorderStyle.FixedSingle;
            frmSelect.MinimizeBox = false;
            frmSelect.MaximizeBox = false;
            frmSelect.Text = "选择层次";
            tree.KeyPress += new KeyPressEventHandler( tree_KeyPress );
            frmSelect.Controls.Add( tree );

            Button btnSelect = new Button( );
            btnSelect.Text = "确定";
            btnSelect.Left = frmSelect.Width / 2 - btnSelect.Width - 20;
            btnSelect.Top = tree.Height + 5;
            btnSelect.Click += new EventHandler( btnSelect_Click );
            frmSelect.Controls.Add( btnSelect );

            Button btnCloseFrm = new Button( );
            btnCloseFrm.Text = "取消";
            btnCloseFrm.Left = frmSelect.Width / 2 + 20;
            btnCloseFrm.Top = btnSelect.Top;
            btnCloseFrm.Click += new EventHandler( btnCloseFrm_Click );
            frmSelect.Controls.Add( btnCloseFrm );


            if ( frmSelect.ShowDialog( ) == DialogResult.OK )
            {
                txtParentDept.Text = ( (DepartmentLayer)tree.SelectedNode.Tag ).LayerName;
                txtParentDept.Tag = (DepartmentLayer)tree.SelectedNode.Tag;
            }
        }

        void tree_KeyPress( object sender , KeyPressEventArgs e )
        {
            Form frm = (Form)( (TreeView)sender ).Parent;

            if ( (int)e.KeyChar == 13 )
            {
                if ( ( (TreeView)sender ).SelectedNode != null )
                {
                    frm.DialogResult = DialogResult.OK;
                    frm.Close( );
                }
            }
            else if ( (int)e.KeyChar == 27 )
            {
                frm.DialogResult = DialogResult.Cancel;
                frm.Close( );
            }
        }

        void btnCloseFrm_Click( object sender , EventArgs e )
        {
            Form frm = (Form)( (Button)sender ).Parent;
            frm.DialogResult = DialogResult.Cancel;
            frm.Close( );
        }

        void btnSelect_Click( object sender , EventArgs e )
        {
            Form frm = (Form)( (Button)sender ).Parent;

            foreach ( Control ctrl in frm.Controls )
            {
                if ( ctrl.Name == "tvwLayer" )
                {
                    if ( ( (TreeView)ctrl ).SelectedNode != null )
                    {
                        frm.DialogResult = DialogResult.OK;
                        frm.Close( );
                    }
                }
            }

        }
        /// <summary>
        /// 增加子层
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="tbAllLay"></param>
        private void AddSubLayerNode( TreeNode parentNode , DataTable tbAllLay )
        {
            DataRow[] drSubs = tbAllLay.Select( "P_LAYER_ID =  " + ( (DepartmentLayer)parentNode.Tag ).LayerID );

            for ( int i = 0 ; i < drSubs.Length ; i++ )
            {
                DepartmentLayer dept = new DepartmentLayer( drSubs[i] );
                TreeNode node = new TreeNode( );
                node.Text = dept.LayerName;
                node.Tag = dept;

                AddSubLayerNode( node , tbAllLay );

                parentNode.Nodes.Add( node );
            }
        }

        private void txtParentDept_KeyPress( object sender , KeyPressEventArgs e )
        {
            e.Handled = true;
            if ( (int)e.KeyChar == 32 )
            {
                btnParent_Click( null , null );
            }

            if ( (int)e.KeyChar == 8 )
            {
                txtParentDept.Text = "";
                txtParentDept.Tag = null;
            }
          
        }

        private void txtDeptName_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
                txtParentDept.Focus( );
        }

        private void txtCode_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
                txtDeptAddr.Focus( );
        }

        private void txtDeptAddr_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
                btnOk.Focus( );
        }

        private void btnCancel_Click( object sender , EventArgs e )
        {
            this.Close( );
        }
    }
}
