using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS_DJSFManager.窗口;
using HIS_DJSFManager.类;

namespace HIS_DJSFManager.Forms
{
    public partial class FrmMain : Form
    {
        private int _CurrentEmployeeId;
        private string _CurrentEmployeeName;
        private int _CurrentWorkId;

        public FrmMain()
        {
            InitializeComponent( );
        }

        /// <summary>
        /// 检测远程连接
        /// </summary>
        /// <returns></returns>
        private bool DetectRemoteConnect()
        {
            try
            {
                HIS.SYSTEM.Core.BaseBLL.oleDb.DoCommand( "values current timestamp" );
                return false;
            }
            catch
            {
                return false;
            }
        }

        private void ShowChargeForm( object sender , EventArgs e  )
        {
            if ( DetectRemoteConnect( ) == true )
            {
                MessageBox.Show( "网络连通状态下不能使用单机版的收费系统！" ,"",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            foreach ( Form frm in this.MdiChildren )
            {
                if ( frm is FrmCharge )
                {
                    frm.Activate( );
                    return;
                }
            }
            FrmCharge frmCharge = new FrmCharge( );
            frmCharge.MdiParent = this;
            frmCharge.currentUserEmployeeId = Convert.ToInt32( tbbarUser.Tag );
            frmCharge.WindowState = FormWindowState.Maximized;
            frmCharge.Show( );
        }

        private void 数据上传ToolStripMenuItem_Click( object sender , EventArgs e )
        {
            HIS.DownUpLoadData.FrmMessage frmUpload = new HIS.DownUpLoadData.FrmMessage( this._CurrentEmployeeId , this._CurrentEmployeeName ,"本机数据上传",0,_CurrentWorkId);
            frmUpload.ShowDialog( );
        }

        protected override void OnShown( EventArgs e )
        {
            base.OnShown( e );
            FrmLogin fLogin = new FrmLogin( );
            if ( fLogin.ShowDialog( ) == DialogResult.OK )
            {
                menuStrip1.Enabled = true;
                btnCharge.Enabled = true;
                btnRefund.Enabled = true;
                tbbarUser.Tag = fLogin.CurrentEmployeeID;
                tbbarUser.Text = DataReader.GetEmployeeNameById( fLogin.CurrentEmployeeID );
                _CurrentEmployeeId = fLogin.CurrentEmployeeID;
                _CurrentWorkId = fLogin.CurrentWorkId;
                _CurrentEmployeeName = DataReader.GetEmployeeNameById( fLogin.CurrentEmployeeID );
            }
            else
            {
                this.Close( );
            }
        }

        private void 个人收费统计ToolStripMenuItem_Click( object sender , EventArgs e )
        {
            FrmAccount fAccount = new FrmAccount( _CurrentEmployeeId , _CurrentEmployeeName );
            fAccount.ShowDialog( );
        }

        private void 门诊退费ToolStripMenuItem_Click( object sender , EventArgs e )
        {
            if ( DetectRemoteConnect( ) == true )
            {
                MessageBox.Show( "网络连通状态下不能使用单机版的收费系统！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                return;
            }

            FrmUnCharge frmUncharge = new FrmUnCharge( _CurrentEmployeeId);
            frmUncharge.ShowDialog( );
        }

        private void 票据分配ToolStripMenuItem_Click( object sender , EventArgs e )
        {
            if ( DetectRemoteConnect( ) == true )
            {
                MessageBox.Show( "网络连通状态下不能使用单机版的收费系统！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                return;
            }

            foreach ( Form frm in this.MdiChildren )
            {
                if ( frm is FrmInvoiceManager )
                {
                    frm.Activate( );
                    return;
                }
            }
            FrmInvoiceManager f = new FrmInvoiceManager( "发票分配" , _CurrentEmployeeId );
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show( );
        }

        private void 发票查询ToolStripMenuItem_Click( object sender , EventArgs e )
        {
            foreach ( Form frm in this.MdiChildren )
            {
                if ( frm is FrmInvoiceQuery )
                {
                    frm.Activate( );
                    return;
                }
            }
            FrmInvoiceQuery f = new FrmInvoiceQuery( "发票查询" , _CurrentEmployeeId );
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show( );
        }

        private void btnRefund_Click( object sender , EventArgs e )
        {
            门诊退费ToolStripMenuItem_Click( null , null );
        }

        private void 基础数据下载ToolStripMenuItem_Click( object sender , EventArgs e )
        {
            
            HIS.DownUpLoadData.FrmMessage frmDownload = new HIS.DownUpLoadData.FrmMessage( this._CurrentEmployeeId , this._CurrentEmployeeName , "基础数据下载" ,1 ,_CurrentWorkId);
            frmDownload.ShowDialog( );
        }

        
    }
}
