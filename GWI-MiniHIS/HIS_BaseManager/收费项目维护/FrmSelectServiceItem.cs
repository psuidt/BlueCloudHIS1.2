using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;

namespace HIS_BaseManager
{
    public partial class FrmSelectServiceItem : BaseForm
    {
        public DataTable SelectedItems;

        private DataTable tbserviceItem;

        public FrmSelectServiceItem(DataTable tbServiceItems)
        {
            InitializeComponent( );

            tbserviceItem = tbServiceItems;

            dgvServiceItem.AutoGenerateColumns = false;

            
        }

        private void FrmSelectServiceItem_Load( object sender , EventArgs e )
        {
            dgvServiceItem.DataSource = tbserviceItem.DefaultView;
        }

        private void btnAdd_Click( object sender , EventArgs e )
        {
            if ( dgvServiceItem.Rows.Count == 0 )
                return;

            if ( dgvServiceItem.CurrentCell == null )
                return;

            for ( int i = 0 ; i < dgvServiceItem.SelectedRows.Count ; i++ )
            {
                object item_id = dgvServiceItem.SelectedRows[i].Cells["ITEM_ID"].Value;
                object item_name = dgvServiceItem.SelectedRows[i].Cells["ITEM_NAME"].Value;
                bool selected = false;
                for ( int j = 0 ; j < dgvSelected.Rows.Count ; j++ )
                {
                    if ( Convert.ToInt32( item_id ) == Convert.ToInt32( dgvSelected["_ITEM_ID" , j].Value ) )
                    {
                        selected = true;
                        break;
                    }
                }
                if ( !selected )
                {
                    dgvSelected.Rows.Add( );
                    dgvSelected["_ITEM_ID" , dgvSelected.Rows.Count - 1].Value = item_id;
                    dgvSelected["_ITEM_NAME" , dgvSelected.Rows.Count - 1].Value = item_name;
                }
            }
        }

        private void btnRemove_Click( object sender , EventArgs e )
        {
            if ( dgvSelected.Rows.Count == 0 )
                return;

            for ( int i = 0 ; i < dgvSelected.SelectedRows.Count ; i++ )
            {
                dgvSelected.Rows.Remove( dgvSelected.SelectedRows[i] );
            }
        }

        private void btnCancel_Click( object sender , EventArgs e )
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close( );
        }

        private void btnOK_Click( object sender , EventArgs e )
        {
            SelectedItems = new DataTable( );
            SelectedItems.Columns.Add( "ITEM_ID" );
            SelectedItems.Columns.Add( "ITEM_NAME" );

            for ( int i = 0 ; i < dgvSelected.Rows.Count ; i++ )
            {
                DataRow dr = SelectedItems.NewRow( );
                dr["ITEM_ID"] = dgvSelected["_ITEM_ID" , i].Value;
                dr["ITEM_NAME"] = dgvSelected["_ITEM_NAME" , i].Value;
                SelectedItems.Rows.Add( dr );
            }

            this.DialogResult = DialogResult.OK;
            this.Close( );
        }

        private void txtSearch_TextChanged( object sender , EventArgs e )
        {
            string strKey = CommonFun.FormatKeyword( txtSearch.Text );
            ( (DataView)dgvServiceItem.DataSource ).RowFilter = "PY_CODE LIKE '%" + strKey + "%' OR WB_CODE LIKE '%" + strKey + "%' OR ITEM_NAME LIKE '%" + strKey + "%' ";
        }

        private void dgvServiceItem_DoubleClick( object sender , EventArgs e )
        {
            btnAdd_Click( null , null );
        }

        private void dgvSelected_DoubleClick( object sender , EventArgs e )
        {
            btnRemove_Click( null , null );
        }

        private void btnRemoveAll_Click( object sender , EventArgs e )
        {
            dgvSelected.Rows.Clear( );
        }
    }
}
