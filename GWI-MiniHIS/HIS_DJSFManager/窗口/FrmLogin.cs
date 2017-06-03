using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS_DJSFManager.类;

namespace HIS_DJSFManager.窗口
{
    public partial class FrmLogin : Form
    {

        public int CurrentEmployeeID;
        public int CurrentWorkId;

        public FrmLogin()
        {
            InitializeComponent( );
        }

        private void txtUserCode_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
            {
                txtPassword.Focus( );
            }
        }

        private void txtPassword_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
            {
                btnLogin.Focus( );
            }
        }

        private void txtUserCode_Leave( object sender , EventArgs e )
        {
            if ( txtUserCode.Text.Trim( ) == "" )
            {
                return;
            }
            DataRow[] drs = DataReader.BaseUsers.Select( "usercode='"+txtUserCode.Text+"'" );
            if ( drs.Length == 0 )
            {
                MessageBox.Show( "用户名不正确！" );
                txtUserCode.Focus( );
            }
            else
            {
                txtEmployeeName.Text = drs[0]["Name"].ToString( ).Trim( );
                CurrentEmployeeID = Convert.ToInt32( drs[0]["Employee_ID"] );
                CurrentWorkId = Convert.ToInt32( drs[0]["workid"] );
                HIS.SYSTEM.Core.EntityConfig.WorkID = CurrentWorkId;
                txtPassword.Tag = drs[0]["Password"].ToString( ).Trim();
            }
        }     

        private void btnLogin_Click( object sender , EventArgs e )
        {
            if ( txtUserCode.Text.Trim( ) == "" )
            {
                MessageBox.Show( "用户名不能为空！" );
                return;
            }
            string userPwd = "";
            if ( txtPassword.Tag != null )
            {
                userPwd = txtPassword.Tag.ToString( ).Trim( );
            }

            if ( txtPassword.Text.Trim( ) != userPwd )
            {
                MessageBox.Show( "密码不正确！" );
                txtPassword.Focus( );
                txtPassword.SelectAll( );
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click( object sender , EventArgs e )
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
