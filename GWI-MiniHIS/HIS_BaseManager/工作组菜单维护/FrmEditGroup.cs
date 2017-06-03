using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HIS.Base_BLL;

namespace HIS_BaseManager
{
    public partial class FrmEditGroup : GWI.HIS.Windows.Controls.BaseForm
    {
        private bool IsAddNew;
        private int groupId;
        public string ReturnName;
        public int ReturnID;

        public FrmEditGroup()
        {
            InitializeComponent( );

            IsAddNew = true;
            groupId = 0;
            chkDelete.Checked = false;
            chkDelete.Visible = false;
            this.Text = "增加组";
        }

        public FrmEditGroup(int GroupId)
        {
            InitializeComponent( );

            IsAddNew = false;
            groupId = GroupId;
            this.Text = "编辑组";
        }

        private void FrmEditGroup_Load( object sender , EventArgs e )
        {
            if ( groupId != 0 )
            {
                DataRow[] dr = BaseDataReader.Base_Group.Select( "GROUP_ID=" + groupId );
                if ( dr.Length > 0 )
                {
                    txtGroupName.Text = dr[0]["NAME"].ToString( ).Trim( );
                    chkAdmin.Checked = ( Convert.ToInt32( dr[0]["ADMINISTRATORS"] ) == 1 ? true : false );
                    chkDelete.Checked = ( Convert.ToInt32( dr[0]["DELETE_FLAG"] ) == 1 ? true : false );
                }
            }
        }

        private void btnCancel_Click( object sender , EventArgs e )
        {
            

            this.DialogResult = DialogResult.Cancel;
            this.Close( );
            
        }

        private void btnSave_Click( object sender , EventArgs e )
        {
            GroupMenuManager manager = new GroupMenuManager( );
            if ( IsAddNew )
            {
                ReturnID = manager.AddGroup( txtGroupName.Text.Trim( ) , chkAdmin.Checked );
                ReturnName = txtGroupName.Text;
                if ( chkAdmin.Checked )
                {
                    ReturnName = txtGroupName.Text + "【管理员】";
                }
            }
            else
            {
                manager.UpdateGroup( groupId , txtGroupName.Text.Trim( ) , chkAdmin.Checked , chkDelete.Checked );
                ReturnID = groupId;
                ReturnName = txtGroupName.Text;
                if ( chkAdmin.Checked )
                    ReturnName = ReturnName + "【管理员】";
                if ( chkDelete.Checked )
                    ReturnName = ReturnName + "(停用)";
            }

            this.DialogResult = DialogResult.OK;
            this.Close( );
        }
    }
}
