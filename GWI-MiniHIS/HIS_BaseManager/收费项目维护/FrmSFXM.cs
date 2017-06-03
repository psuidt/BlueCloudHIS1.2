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
    public partial class FrmSFXM : GWI.HIS.Windows.Controls.BaseMainForm  //GWMHIS.BussinessLogicLayer.Forms.BaseForm
    {

        public FrmSFXM(string FormText, GWMHIS.BussinessLogicLayer.Classes.User CurrentUser)
        {
            InitializeComponent( );

            this.Text = FormText;

            this.FormTitle = FormText;
        }

        private void FrmSFXM_Load( object sender , EventArgs e )
        {
            DataTable tb = HIS.Base_BLL.BaseDataReader.Base_Service_Items;
            
            this.dgvItems.DataSource = tb.DefaultView;
            txtFind.KeyPress += new KeyPressEventHandler( txtFind_KeyPress );

            cboStatItem.DisplayMember = "ITEM_NAME";
            cboStatItem.ValueMember = "CODE";
            cboStatItem.DataSource = BaseDataReader.Base_Stat_Item;
            cboStatItem.SelectedIndexChanged += new EventHandler( cboStatItem_SelectedIndexChanged );
        }

        void cboStatItem_SelectedIndexChanged( object sender , EventArgs e )
        {
            string str = this.txtFind.Text.Trim( );
            try
            {
                string sql = "(py_code like '%" + str + "%' or wb_code like '%" + str + " %' or item_name like '%" + str + "%')";
                if ( cboStatItem.SelectedValue != null )
                    sql += "and statitem_code='" + cboStatItem.SelectedValue.ToString( ) + "'";

                ( (DataView)dgvItems.DataSource ).RowFilter = sql;
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message );
            }
        }

        void txtFind_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
            {
                btnSearch_Click( null , null );
            }
        }



        private void dgvItems_CurrentCellChanged( object sender , EventArgs e )
        {
            try
            {
                if ( dgvItems.Rows.Count == 0 )
                    return;
                if ( dgvItems.CurrentCell == null )
                    return;

                int row = dgvItems.CurrentCell.RowIndex;
               
                int item_id = Convert.ToInt32( dgvItems["ITEM_ID" , row].Value );
               
            }
            catch(Exception err)
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string str = this.txtFind.Text.Trim ();
            try
            {
                string sql = "(py_code like '%" + str + "%' or wb_code like '%" + str + " %' or item_name like '%" + str + "%')";
                if ( cboStatItem.SelectedValue != null )
                    sql += "and statitem_code='"+cboStatItem.SelectedValue.ToString()+"'";
                 
                ((DataView)dgvItems.DataSource).RowFilter = sql;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            
        }


        private void dgvItems_DoubleClick( object sender , EventArgs e )
        {
            if ( dgvItems.Rows.Count == 0 )
                return;
            int row = dgvItems.CurrentCell.RowIndex;
            HIS.Base_BLL.ServiceItem item = new HIS.Base_BLL.ServiceItem( Convert.ToInt32( dgvItems["ITEM_ID" , row].Value ) );
            FrmEdit frmAdd = new FrmEdit( item , dgvItems );
            frmAdd.ShowDialog( );  
        }

        private void btnAdd_Click( object sender, EventArgs e )
        {
            FrmEdit frm = new FrmEdit();
            frm.ShowDialog();
        }

        private void btnEdit_Click( object sender, EventArgs e )
        {
            int row = dgvItems.CurrentCell.RowIndex;
            HIS.Base_BLL.ServiceItem item = new HIS.Base_BLL.ServiceItem( Convert.ToInt32( dgvItems["ITEM_ID", row].Value ) );
            FrmEdit frmAdd = new FrmEdit( item, dgvItems );
            frmAdd.ShowDialog();     
        }

        private void btnShowAll_Click( object sender, EventArgs e )
        {
            DataTable tb = HIS.Base_BLL.BaseDataReader.Base_Service_Items;
            this.dgvItems.DataSource = tb.DefaultView;
        }

        private void btnClose_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void chkAll_CheckedChanged( object sender , EventArgs e )
        {
            if ( chkAll.Checked )
            {
                cboStatItem.Enabled = false;
                cboStatItem.SelectedIndex = -1;
            }
            else
            {
                cboStatItem.Enabled = true;
            }
        }

       
       
    }
}
