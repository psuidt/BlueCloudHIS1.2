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
    public partial class FrmEmployeeAtter : GWI.HIS.Windows.Controls.BaseForm
    {
        private Employee employee;
        private System.Windows.Forms.ListView lvw;

        public FrmEmployeeAtter(System.Windows.Forms.ListView Lvw)
        {
            InitializeComponent( );
            lvw = Lvw;
            cboDocType.DisplayMember = "TYPE_NAME";
            cboDocType.ValueMember = "TYPE_ID";
            cboDocType.DataSource = BaseDataReader.Base_Doctor_Type;
            cboRole.SelectedIndex = 0;
            this.Text = "增加人员";
        }

        public FrmEmployeeAtter( System.Windows.Forms.ListView Lvw ,Employee Employee)
        {
            InitializeComponent( );
            lvw = Lvw;
            employee = Employee;
            cboDocType.DisplayMember = "TYPE_NAME";
            cboDocType.ValueMember = "TYPE_ID";
            cboDocType.DataSource = BaseDataReader.Base_Doctor_Type;

            cboRole.SelectedIndex = employee.Role;
            if ( employee.doctor_typeId == null || employee.doctor_typeId == "" )
                cboDocType.SelectedIndex = -1;
            else
                cboDocType.SelectedValue = employee.doctor_typeId;
            txtUserCode.Text = employee.UserCode;
            txtDocCode.Text = employee.DocCode;
            chkMz.Checked = employee.MZQ == 1 ? true : false;
            chkDm.Checked = employee.DMQ == 1 ? true : false;
            chkCf.Checked = employee.CFQ == 1 ? true : false;
            chkNoUse.Checked = employee.NotUse == 1 ? true : false;
            //显示科室
            Department[] depts = employee.GetDepartment( );
            for ( int i = 0 ; i < depts.Length ; i++ )
            {
                ListViewItem item = new ListViewItem( );
                item.Text = depts[i].Name;
                item.Tag = depts[i];
                lvwDept.Items.Add( item );
            }
            //组
            DataTable tbGroup = employee.GetGroups( );
            foreach ( DataRow dr in tbGroup.Rows )
            {
                ListViewItem item = new ListViewItem( );
                item.Text = dr["NAME"].ToString( ).Trim( );
                item.Tag = Convert.ToInt32( dr["group_id"] );
                lvwGroup.Items.Add( item );
            } 
            

            this.Text = "修改" + Employee.Name;
        }

        private void FrmEmployeeAtter_Load( object sender , EventArgs e )
        {
            

            if ( employee != null )
            {
                txtName.Text = employee.Name;
            }
        }

        private void btnOk_Click( object sender , EventArgs e )
        {
            if ( lvwDept.Items.Count == 0 )
            {
                MessageBox.Show( "没有指定人员的科室！" );
                return;
            }
            if ( txtDocCode.Enabled && txtDocCode.Text.Trim() == "" )
            {
                MessageBox.Show( "没有指定医生代码", "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }
            if ( lvwGroup.Items.Count == 0 && txtUserCode.Text.Trim( ) != "" )
            {
                MessageBox.Show( "设置了用户名的人员，隶属组不能为空" ,"", MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }
            bool add;
            if ( employee == null )
            {
                employee = new Employee( );
                add = true;
            }
            else
            {
                if ( txtUserCode.Text.Trim( ) == "" )
                {
                    if ( MessageBox.Show( "没有为该人员指定用户信息,是否继续？" , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.No )
                    {
                        return;
                    }
                }
                add = false;
            }

            employee.Name = txtName.Text;
            employee.NotUse = chkNoUse.Checked ? 1 : 0;
            employee.Role = cboRole.SelectedIndex;
            employee.DocCode = txtDocCode.Text;
            employee.CFQ = chkCf.Checked ? 1 : 0;
            employee.MZQ = chkMz.Checked ? 1 : 0;
            employee.DMQ = chkDm.Checked ? 1 : 0;
            employee.UserCode = txtUserCode.Text.Trim();
            employee.doctor_typeId = cboDocType.Enabled?cboDocType.SelectedValue.ToString():"";
            string[] pywb = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.GetPyWbCode( employee.Name );
            employee.PY_Code = pywb[0];
            employee.WB_Code = pywb[1];

            int[] depts = new int[lvwDept.Items.Count];
            for ( int i = 0 ; i < lvwDept.Items.Count ; i++ )
                depts[i] = ( (Department)lvwDept.Items[i].Tag ).DeptID;
            employee.DeptIds = depts;

            int[] groups = new int[lvwGroup.Items.Count];
            for ( int i = 0 ; i < lvwGroup.Items.Count ; i++ )
                groups[i] = Convert.ToInt32( lvwGroup.Items[i].Tag );
            employee.GroupIds = groups;
            try
            {
                if ( add )
                {
                    employee.Add( );
                    txtName.Text = "";
                    cboRole.SelectedIndex = 0;
                    lvwDept.Items.Clear( );
                    txtUserCode.Text = "";
                    lvwGroup.Items.Clear( );
                    chkCf.Checked = false;
                    chkMz.Checked = false;
                    chkDm.Checked = false;
                    ListViewItem item = new ListViewItem( );
                    item.Text = employee.Name;
                    item.SubItems.Add( employee.UserCode==null?"":employee.UserCode );
                    item.Tag = employee;
                    item.ImageIndex = 2;
                    lvw.Items.Add( item );
                    employee = null;

                }
                else
                {
                    employee.Update( );
                    lvw.SelectedItems[0].Text = employee.Name;
                    lvw.SelectedItems[0].SubItems[1].Text = employee.UserCode;
                    lvw.SelectedItems[0].Tag = employee;
                    this.DialogResult = DialogResult.OK;
                    this.Close( );

                }
                
            }
            catch(Exception err)
            {
                if ( add )
                    employee = null;

                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }

        private void btnAddDept_Click( object sender , EventArgs e )
        {
            ShowSelectCard( sender );
        }

        private void btnAddGroup_Click( object sender , EventArgs e )
        {
            ShowSelectCard( sender );
        }

        private void btnRemoveDept_Click( object sender , EventArgs e )
        {
            if ( lvwDept.SelectedItems.Count > 0 )
            {
                foreach ( ListViewItem item in lvwDept.SelectedItems )
                    lvwDept.Items.Remove( item );
            }
        }

        private void btnRemoveGroup_Click( object sender , EventArgs e )
        {
            if ( lvwGroup.SelectedItems.Count > 0 )
            {
                foreach ( ListViewItem item in lvwGroup.SelectedItems )
                    lvwGroup.Items.Remove( item );
            }
        }

        private void ShowSelectCard(object sender)
        {
            Form frmSelect = new Form( );
            frmSelect.StartPosition = FormStartPosition.CenterScreen;
            frmSelect.ShowInTaskbar = false;
            frmSelect.FormBorderStyle = FormBorderStyle.FixedSingle;
            frmSelect.MinimizeBox = false;
            frmSelect.MaximizeBox = false;
            frmSelect.Text = "选择";

            System.Windows.Forms.ListView lvwSelect = new System.Windows.Forms.ListView( );
            lvwSelect.Columns.Add( "名称" , 150 );
            lvwSelect.CheckBoxes = true;
            lvwSelect.Name = "lvwSelect";
            lvwSelect.Dock = DockStyle.Top;
            lvwSelect.Height = frmSelect.Height * 4 / 5;
            lvwSelect.View = View.Details;
            frmSelect.Controls.Add( lvwSelect );

            Button btnSelect = new Button( );
            btnSelect.Text = "确定";
            btnSelect.Top = lvwSelect.Height + 10;
            btnSelect.Left = frmSelect.Width / 2 - btnSelect.Width - 20;
            btnSelect.Click += new EventHandler( btnSelect_Click );
            frmSelect.Controls.Add( btnSelect );

            Button btnCancel = new Button( );
            btnCancel.Text = "取消";
            btnCancel.Top = lvwSelect.Height + 10;
            btnCancel.Left = frmSelect.Width / 2 + 20;
            btnCancel.Click += new EventHandler( btnCancel_Click );
            frmSelect.Controls.Add( btnCancel );

            if ( ( (Control)sender ).Name == this.btnAddDept.Name )
            {
                Department[] depts = Department.GetDepartment( "" );
                for ( int i = 0 ; i < depts.Length ; i++ )
                {
                    ListViewItem item = new ListViewItem( );
                    item.Text = depts[i].Name;
                    item.Tag = depts[i];
                    lvwSelect.Items.Add( item );
                }
            }
            else
            {
                foreach ( DataRow dr in HIS.Base_BLL.BaseDataReader.Base_Group.Rows )
                {
                    ListViewItem item = new ListViewItem( );
                    item.Text = dr["Name"].ToString().Trim();
                    item.Tag = Convert.ToInt32( dr["Group_ID"] );
                    lvwSelect.Items.Add( item );
                }
            }


            if ( frmSelect.ShowDialog( ) == DialogResult.OK )
            {
                foreach ( ListViewItem item in lvwSelect.CheckedItems )
                {
                    if ( ( (Control)sender ).Name == this.btnAddDept.Name )
                    {
                        Department dept = (Department)item.Tag;
                        ListViewItem selItem = new ListViewItem( );
                        selItem.Text = dept.Name;
                        selItem.Tag = dept;
                        lvwDept.Items.Add( selItem );
                    }
                    else
                    {
                        ListViewItem selItem = new ListViewItem( );
                        selItem.Text = item.Text;
                        selItem.Tag = Convert.ToInt32( item.Tag );
                        lvwGroup.Items.Add( selItem );
                    }
                }
            }
        }

        void btnCancel_Click( object sender , EventArgs e )
        {
            ( (Form)( (Control)sender ).Parent ).DialogResult = DialogResult.Cancel;
            ( (Form)( (Control)sender ).Parent ).Close( );
        }

        void btnSelect_Click( object sender , EventArgs e )
        {
            Form frm =  (Form)( (Control)sender ).Parent ;
            frm.DialogResult = DialogResult.OK;
            frm.Close( );
        }

        private void btnResetPassword_Click( object sender , EventArgs e )
        {
            GWMHIS.BussinessLogicLayer.Classes.User user = new GWMHIS.BussinessLogicLayer.Classes.User( employee.EmployeeID );
            user.Chgpwd( user.Password, "1" );
        }

        private void cboRole_SelectedIndexChanged( object sender , EventArgs e )
        {
            if ( cboRole.SelectedIndex == 1 )
            {
                groupBox1.Enabled = true ;
            }
            else
            {
                groupBox1.Enabled = false;
            }
        }

       
    }
}
