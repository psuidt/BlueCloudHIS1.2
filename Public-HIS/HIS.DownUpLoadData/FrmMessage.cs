using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;
using HIS.DownUpLoadData;

namespace HIS.DownUpLoadData
{
    public partial class FrmMessage : BaseForm
    {
        private int employeeId;
        private string employeeName;
        private bool success = false;
        private int _type = 0;
        private int _workId;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <param name="EmployeeName"></param>
        /// <param name="FormTitle"></param>
        /// <param name="type">0-上传 1-下载</param>
        public FrmMessage(int EmployeeId,string EmployeeName , string FormTitle , int type,int WorkId)
        {
            InitializeComponent( );

            employeeId = EmployeeId;
            employeeName = EmployeeName;
            _workId = WorkId;
            this.Text = FormTitle;
            lblTitle.Text = FormTitle;
            _type = type;
            if ( type == 0 )
                btnUpload.Text = "开始上传";
            else
            {
                btnUpload.Text = "开始下载";
                label2.Visible = false;
            }
        }

        public bool Success
        {
            get
            {
                return success;
            }
        }

        private void btnUpload_Click( object sender , EventArgs e )
        {
            try
            {
                if ( _type == 0 )
                    UpLoadData( );
                else
                    DownLoadData( );

                success = true;
            }
            catch
            {
                success = false;
            }
        }

        private void DownLoadData()
        {
            DownloadController downloader = new DownloadController( _workId );
            downloader.AfterTableDownLoadOver += new AfterTableDownLoadOverHandler( downloader_AfterTableDownLoadOver );
            try
            {
                btnUpload.Enabled = false;
                btnClose.Enabled = false;
                txtInfo.Clear( );

                downloader.DownLoadBaseData( );
            }
            catch ( Exception err )
            {
                txtInfo.AppendText( "下载过程中发生错误：{" + err.Message + "}" );
            }
            finally
            {
                btnUpload.Enabled = true;
                btnClose.Enabled = true;
            }
        }

        void downloader_AfterTableDownLoadOver( string message )
        {
            txtInfo.AppendText( message );
            txtInfo.SelectionStart = txtInfo.Text.Length;
            txtInfo.Refresh( );
        }

        private void UpLoadData()
        {
            UploadController uploadController = new UploadController( employeeId );
            uploadController.UpLoadingEvent += new OnUpLoadingEventHandle( uploadController_UpLoadingEvent );
            try
            {
                btnUpload.Enabled = false;
                btnClose.Enabled = false;
                txtInfo.Clear( );
                List<int> patList = uploadController.GetUnUploadPatientList( );
                foreach ( int patListid in patList )
                {
                    uploadController.UploadDataWithSinglePatient( patListid );
                }
                uploadController.UploadDataWithInvoiceInfo( );
                uploadController.UploadFinished( );
            }
            catch ( Exception err )
            {
                txtInfo.AppendText( err.Message + "\r\n上传操作已中止！\r\n" );
            }
            finally
            {
                btnUpload.Enabled = true;
                btnClose.Enabled = true;
                for ( int i = 0 ; i < txtInfo.Lines.Length ; i++ )
                    uploadController.WriteLog( txtInfo.Lines[i] );
            }
        }

        void uploadController_UpLoadingEvent( string message )
        {
            txtInfo.AppendText( message );
            txtInfo.SelectionStart = txtInfo.Text.Length;
            txtInfo.Refresh( );
        }

        private void FrmUpload_FormClosing( object sender , FormClosingEventArgs e )
        {
            if ( btnUpload.Enabled == false )
                e.Cancel = true;
            
        }

        private void FrmUpload_Load( object sender , EventArgs e )
        {
            lblUser.Text = "操作员：" + employeeName;
        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.Close( );
        }
    }
}
