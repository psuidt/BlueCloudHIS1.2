using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;
using HIS.MZ_BLL;
using HIS.DownUpLoadData;

namespace HIS_MZManager
{
    public partial class FrmDownLoad : BaseForm
    {
        private DownloadController downloader;

        public FrmDownLoad()
        {
            InitializeComponent( );
        }

        private void btnDownLoad_Click( object sender , EventArgs e )
        {
            btnClose.Enabled = false;
            btnDownLoad.Enabled = false;
            try
            {
                downloader.DownLoadBaseData( );
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message );
                ListViewItem item = new ListViewItem( );
                item.Text = err.Message;
                lvwMsg.Items.Add( item );
            }
            finally
            {
                btnClose.Enabled = true;
                btnDownLoad.Enabled = true;
            }
        }

        private void FrmDownLoad_Load( object sender , EventArgs e )
        {
            downloader = new DownloadController( Convert.ToInt32( HIS.SYSTEM.Core.EntityConfig.WorkID ));
            downloader.AfterTableDownLoadOver += new AfterTableDownLoadOverHandler( downloader_AfterTableDownLoadOver );
        }

        void downloader_AfterTableDownLoadOver( string message )
        {
            ListViewItem item = new ListViewItem( );
            item.Text = message;
            lvwMsg.Items.Add( item );
            this.Refresh( );
        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.Close( );
        }
    }
}
