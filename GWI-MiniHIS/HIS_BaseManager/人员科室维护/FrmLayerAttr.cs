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
    public partial class FrmLayerAttr : GWI.HIS.Windows.Controls.BaseForm
    {
        private TreeView tvw;

        private HIS.Base_BLL.DepartmentLayer layer;

        public FrmLayerAttr(TreeView tree)
        {
            InitializeComponent( );

            tvw = tree;
        }

        public FrmLayerAttr( TreeView tree , HIS.Base_BLL.DepartmentLayer Layer )
        {
            InitializeComponent( );

            tvw = tree;
            layer = Layer;
        }

        private void FrmLayerAttr_Load( object sender , EventArgs e )
        {
            if ( layer != null )
            {
                txtLayerName.Text = layer.LayerName;
                DepartmentLayer pLayer = new DepartmentLayer( layer.ParentLayerId );
                txtParentLayer.Text = pLayer.LayerName;
                txtParentLayer.Tag = pLayer ;
            }
        }

        private void btnOk_Click( object sender , EventArgs e )
        {
            if ( txtLayerName.Text.Trim( ) == "" )
            {
                MessageBox.Show( "名称不能为空！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }

            if ( layer == null )
            {
                layer = new DepartmentLayer( );    
            }
            layer.LayerName = txtLayerName.Text;
            if ( txtParentLayer.Tag != null )
                layer.ParentLayerId = txtParentLayer.Text.Trim( ) == "" ? 0 : ( (DepartmentLayer)txtParentLayer.Tag ).LayerID;
            else
                layer.ParentLayerId = 0;

            if ( DepartmentLayer.NameExists( layer ) )
            {
                MessageBox.Show( "名称已经存在" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                if ( layer.LayerID == 0 )
                    layer = null;

                return;
            }

            if ( layer.LayerID == 0 )
            {
                layer.Add( );
                TreeNode node = new TreeNode( );
                node.Text = layer.LayerName;
                node.Tag = layer;

                TreeNode pNode = GetNode( layer.ParentLayerId );
                if ( pNode == null )
                {
                    tvw.Nodes.Add( node );
                }
                else
                {
                    pNode.Nodes.Add( node );
                }
                tvw.ExpandAll( );

                txtLayerName.Text = "";
                txtLayerName.Focus( );
                layer = null;
            }
            else
            {
                layer.Update( );

                TreeNode node = new TreeNode( );
                node.Text = layer.LayerName;
                node.Tag = layer;

                tvw.Nodes.Remove( tvw.SelectedNode );

                TreeNode pNode = GetNode( layer.ParentLayerId );
                if ( pNode != null )
                    pNode.Nodes.Add( node );
                else
                    tvw.Nodes.Add( node );

                this.Close( );
            }
        }

        private TreeNode GetNode( int LayerId)
        {
            foreach ( TreeNode node in tvw.Nodes )
            {
                if ( ( (DepartmentLayer)node.Tag ).LayerID == LayerId )
                {
                    return node;
                }
                else
                    ForeachNode( node , LayerId );
            }
            return null;
        }

        private TreeNode ForeachNode( TreeNode Node,int LayerId )
        {
            foreach ( TreeNode nd in Node.Nodes )
            {
                if ( ( (DepartmentLayer)nd.Tag ).LayerID == LayerId )
                {
                    return nd;
                }
                else
                {
                    ForeachNode( nd , LayerId );
                }
            }
            return null;
        }

        private void btnSelectLayer_Click( object sender , EventArgs e )
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
            tree.Height = frmSelect.Height *4 /5;
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
                txtParentLayer.Text = ( (DepartmentLayer)tree.SelectedNode.Tag ).LayerName;
                txtParentLayer.Tag = (DepartmentLayer)tree.SelectedNode.Tag;
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

        private void txtLayerName_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
            {
                txtParentLayer.Focus( );
            }
        }

        private void txtParentLayer_KeyPress( object sender , KeyPressEventArgs e )
        {
            e.Handled = true;
            if ( (int)e.KeyChar == 32 )
            {
                btnSelectLayer_Click( null , null );
            }

            if ( (int)e.KeyChar == 8 )
            {
                txtParentLayer.Text = "";
                txtParentLayer.Tag = null;
            }
        }

        private void btnCancel_Click( object sender , EventArgs e )
        {
            this.Close( );
        }
    }
}
