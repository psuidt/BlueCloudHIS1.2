using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWMHIS.PublicControls;
using HIS.Base_BLL;
namespace HIS_BaseManager
{
    public partial class FrmEmpDeptSetting : GWI.HIS.Windows.Controls.BaseMainForm
    {
        public FrmEmpDeptSetting( long UserId , long DeptId , string FormText )
        {
            InitializeComponent( );
            this.Text = FormText;
             
        }
        /// <summary>
        /// 加载科室层次结构
        /// </summary>
        private void LoadDepartmentLayer()
        {
            tvwDeptlayer.Nodes.Clear( );

            DataTable tbLayer = DepartmentLayer.GetAllLayer( );

            DataRow[] drTop = tbLayer.Select( "P_LAYER_ID = 0 " );

            for ( int i = 0 ; i < drTop.Length ; i++ )
            {
                DepartmentLayer dept = new DepartmentLayer( drTop[i] );
                TreeNode node = new TreeNode( );
                node.Text = dept.LayerName;
                node.Tag = dept;
                node.Expand();
                AddSubLayerNode( node , tbLayer );

                tvwDeptlayer.Nodes.Add( node );
            }
            tvwDeptlayer.ExpandAll( );
        }
        /// <summary>
        /// 增加子层
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="tbAllLay"></param>
        private void AddSubLayerNode(TreeNode parentNode,DataTable tbAllLay)
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

        private void AddLayer()
        {
            FrmLayerAttr frmLayer = new FrmLayerAttr( this.tvwDeptlayer );
            frmLayer.ShowDialog( );
        }

        private void EditLayer()
        {
            if ( tvwDeptlayer.SelectedNode == null )
                return;

            DepartmentLayer layer = (DepartmentLayer)tvwDeptlayer.SelectedNode.Tag;
            FrmLayerAttr frmLayer = new FrmLayerAttr( this.tvwDeptlayer ,layer );
            frmLayer.ShowDialog( );
        }

        private void DeleteLayer()
        {
            if ( tvwDeptlayer.SelectedNode == null )
                return;

            DepartmentLayer layer = (DepartmentLayer)tvwDeptlayer.SelectedNode.Tag;
            if ( layer.HasChild( ))
            {
                MessageBox.Show( "该层次下还有子层，不能删除" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }
            try
            {
                if ( layer.HasDepartments( ) )
                {
                    if ( MessageBox.Show( "该层下还有科室，是否继续？" , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.Yes )
                    {
                        if ( layer.Delete( ) )
                        {
                            MessageBox.Show( "该层已删除，原所属的科室请重新分配层次" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                        }
                    }
                    else
                        return;
                }
                else
                {
                    layer.Delete( );
                }
                tvwDeptlayer.Nodes.Remove( tvwDeptlayer.SelectedNode );
            }
            catch(Exception err)
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }

        private void AddDepartment()
        {
            FrmDeptAttr frmDept;
            if ( tvwDeptlayer.SelectedNode == null )
                frmDept = new FrmDeptAttr( this.lvwDept );
            else
                frmDept = new FrmDeptAttr( this.lvwDept ,(DepartmentLayer)tvwDeptlayer.SelectedNode.Tag );
            frmDept.ShowDialog( );
        }

        private void EditDepartment()
        {
            if ( lvwDept.SelectedItems.Count == 0 )
                return;
            Department department = (Department)lvwDept.SelectedItems[0].Tag;
            FrmDeptAttr frmDept = new FrmDeptAttr( this.lvwDept , department );
            frmDept.ShowDialog( );
        }

        private void AddEmployee()
        {
            FrmEmployeeAtter frmEmployee = new FrmEmployeeAtter( this.lvwEmployee );
            frmEmployee.ShowDialog( );
        }

        private void EditEmployee()
        {
            if ( lvwEmployee.SelectedItems.Count == 0 )
                return;

           Employee employee = (Employee)lvwEmployee.SelectedItems[0].Tag;

            FrmEmployeeAtter frmEmployee = new FrmEmployeeAtter( this.lvwEmployee ,employee);
            frmEmployee.ShowDialog( );
        }

        private void ShowAllInfo()
        {
            LoadDepartmentLayer( );
            Department[] allDepts = Department.GetDepartment("" );
            lvwDept.Items.Clear( );
            for ( int i = 0 ; i < allDepts.Length ; i++ )
            {
                ListViewItem item = new ListViewItem( );
                item.Text = allDepts[i].Name;
                item.Tag = allDepts[i];
                item.ImageIndex = 3;
                if ( allDepts[i].P_DeptID == 0 )
                    item.ImageIndex = 5;
                lvwDept.Items.Add( item );
            }
            string where = "delete_bit=0";
            if ( chkNotUse.Checked == true  )
                where = "";

            Employee[] allEmployees =  Employee.GetEmployeies( where );
            lvwEmployee.Items.Clear( );
            for ( int i = 0 ; i < allEmployees.Length ; i++ )
            {
                ListViewItem item = new ListViewItem( );
                item.Text = allEmployees[i].Name;
                item.SubItems.Add( allEmployees[i].UserCode );
                item.Tag = allEmployees[i];
                item.ImageIndex = 2;
                lvwEmployee.Items.Add( item );
            }
        }

        private void FrmMain_Load( object sender , EventArgs e )
        {
            
            LoadDepartmentLayer( );
             
        }


        private void tvwDeptlayer_AfterSelect( object sender , TreeViewEventArgs e )
        {
            if ( tvwDeptlayer.SelectedNode.Tag == null )
                return;

            if ( tvwDeptlayer.SelectedNode.Nodes.Count == 0 )
            {
                DepartmentLayer layer = (DepartmentLayer)tvwDeptlayer.SelectedNode.Tag;
                Department[] deptids = layer.GetDepartment( );
                lvwDept.Items.Clear( );
                lvwEmployee.Items.Clear( );

                for ( int i = 0 ; i < deptids.Length ; i++ )
                {
                    Department dept =  deptids[i] ;
                    ListViewItem item = new ListViewItem( );
                    item.Text = dept.Name;
                    item.Tag = dept;
                    if ( dept.NoUse==1 )
                        item.ImageIndex = 4;
                    else
                        item.ImageIndex = 3;
                    lvwDept.Items.Add( item );
                    Employee[] employies = dept.GetEmployeies( );
                    for ( int j = 0 ; j < employies.Length ; j++ )
                    {
                        ListViewItem item1 = new ListViewItem( );
                        item1.Text = employies[j].Name;
                        item1.Tag = employies[j];
                        item1.SubItems.Add( employies[j].UserCode );
                        switch ( employies[j].Role )
                        {
                            case 1:
                                item1.SubItems.Add( "医生" );
                                break;
                            case 2:
                                item1.SubItems.Add( "护士" );
                                break;
                            default:
                                item1.SubItems.Add( "" );
                                break;
                        }
                        item1.ImageIndex = 2;
                        lvwEmployee.Items.Add( item1 );
                    }
                }
            }
            else
            {
                lvwDept.Items.Clear( );
                lvwEmployee.Items.Clear( );
                foreach ( TreeNode nd in tvwDeptlayer.SelectedNode.Nodes )
                {
                    if ( nd.Nodes.Count == 0 )
                    {
                        DepartmentLayer layer = (DepartmentLayer)nd.Tag;
                        Department[] deptids = layer.GetDepartment( );
                        for ( int i = 0 ; i < deptids.Length ; i++ )
                        {
                            Department dept =  deptids[i] ;
                            ListViewItem item = new ListViewItem( );
                            item.Text = dept.Name;
                            item.Tag = dept;
                            if ( dept.NoUse==1 )
                                item.ImageIndex = 4;
                            else
                                item.ImageIndex = 3;
                            lvwDept.Items.Add( item );
                            
                        }
                    }
                    else
                    {
                        ForeachNode( nd );
                    }
                }
                //增加没有分层的科室
                Department[] noLayDepts = (new DepartmentLayer()).GetNoLayerDepartment();
                for ( int i = 0; i < noLayDepts.Length; i++ )
                {
                    Department dept = noLayDepts[i];
                    ListViewItem item = new ListViewItem();
                    item.Text = dept.Name;
                    item.Tag = dept;
                    item.ImageIndex = 5;
                    lvwDept.Items.Add( item );

                }
            }
        }

        private void ForeachNode(TreeNode node)
        {
            if ( node.Nodes.Count == 0 )
            {
                DepartmentLayer layer = (DepartmentLayer)node.Tag;
                Department[] deptids = layer.GetDepartment( );
                for ( int i = 0 ; i < deptids.Length ; i++ )
                {
                    Department dept =   deptids[i]  ;
                    ListViewItem item = new ListViewItem( );
                    item.Text = dept.Name;
                    item.Tag = dept;
                    if ( dept.NoUse==1 )
                        item.ImageIndex = 4;
                    else
                        item.ImageIndex = 3;
                    lvwDept.Items.Add( item );
                    
                }
            }
            else
            {
                foreach ( TreeNode nd in node.Nodes )
                {
                    ForeachNode( nd );
                }
            }
        }

        private void lvwDept_SelectedIndexChanged( object sender , EventArgs e )
        {
            if ( lvwDept.SelectedItems.Count == 0 )
                return;

            Department dept = (Department)lvwDept.SelectedItems[0].Tag;

            Employee[] employies = dept.GetEmployeies( );
            lvwEmployee.Items.Clear( );
            for ( int j = 0 ; j < employies.Length ; j++ )
            {
                if ( chkNotUse.Checked == false && employies[j].NotUse == 1 )
                    continue;

                ListViewItem item1 = new ListViewItem( );
                item1.Text = employies[j].Name;
                item1.Tag = employies[j];
                item1.SubItems.Add( employies[j].UserCode );
                switch ( employies[j].Role )
                {
                    case 1:
                        item1.SubItems.Add( "医生" );
                        break;
                    case 2:
                        item1.SubItems.Add( "护士" );
                        break;
                    default:
                        item1.SubItems.Add( "" );
                        break;
                }
                item1.ImageIndex = 2;
                lvwEmployee.Items.Add( item1 );
            }

        }

        private void lvwDept_DoubleClick( object sender , EventArgs e )
        {
            if ( lvwDept.SelectedItems.Count == 0 )
                return;
            EditDepartment( );
        }

        private void lvwEmployee_DoubleClick( object sender , EventArgs e )
        {
            if ( lvwEmployee.SelectedItems.Count == 0 )
                return;
            EditEmployee( );
        }

        private void menuEditLayer_Click( object sender , EventArgs e )
        {
            EditLayer( );
        }

        private void menuDeleteLayer_Click( object sender , EventArgs e )
        {
            DeleteLayer( );
        }

        private void menuEditDept_Click( object sender , EventArgs e )
        {
            EditDepartment( );
        }

        private void menuEditEmployee_Click( object sender , EventArgs e )
        {
            EditEmployee( );
        }

        private void textBox1_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
            {
                string sKey = textBox1.Text;

                Department[] depts = Department.GetDepartment( "py_code like '%" + sKey + "%' or wb_code like '%" + sKey + "%' or name like '%" + sKey + "%'" );
                lvwDept.Items.Clear( );
                for ( int i = 0 ; i < depts.Length ; i++ )
                {
                    ListViewItem item = new ListViewItem( );
                    item.Text = depts[i].Name;
                    item.Tag = depts[i];
                    item.ImageIndex = 3;
                    lvwDept.Items.Add( item );
                }
            }
        }

        private void textBox2_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
            {
                string sKey = textBox2.Text;

                Employee[] employeies = Employee.GetEmployeies( "py_code like '%" + sKey + "%' or wb_code like '%" + sKey + "%' or name like '%" + sKey + "%'" );
                lvwEmployee.Items.Clear( );
                for ( int j = 0 ; j < employeies.Length ; j++ )
                {
                    ListViewItem item1 = new ListViewItem( );
                    item1.Text = employeies[j].Name;
                    item1.Tag = employeies[j];
                    item1.SubItems.Add( employeies[j].UserCode );
                    item1.ImageIndex = 2;
                    lvwEmployee.Items.Add( item1 );
                }
            }
        }

        private void btnAddLayer_Click( object sender, EventArgs e )
        {
            AddLayer();
        }

        private void btnEditLayer_Click( object sender, EventArgs e )
        {
            EditLayer();
        }

        private void btnDeleteLayer_Click( object sender, EventArgs e )
        {
            DeleteLayer();
        }

        private void btnAddDept_Click( object sender, EventArgs e )
        {
            AddDepartment();
        }

        private void btnEditDept_Click( object sender, EventArgs e )
        {
            EditDepartment();
        }

        private void btnAddEmployee_Click( object sender, EventArgs e )
        {
            AddEmployee();
        }

        private void btnEditEmployee_Click( object sender, EventArgs e )
        {
            EditEmployee();
        }

        private void btnShowAll_Click( object sender, EventArgs e )
        {
            ShowAllInfo();
        }

        private void btnClose_Click( object sender, EventArgs e )
        {
            this.Close();
        }


    }
}
