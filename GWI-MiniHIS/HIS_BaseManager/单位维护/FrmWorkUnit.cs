using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;
using HIS.Base_BLL;

namespace HIS_BaseManager
{
    public partial class FrmWorkUnit : BaseMainForm
    {
        public FrmWorkUnit(string FormText)
        {
            InitializeComponent( );

            this.Text = FormText;
        }

        private void FrmWorkUnit_Load( object sender , EventArgs e )
        {
            dgvWorkUnit.DataSource = WorkUnitController.GetWorkunitList( ).DefaultView;
        }

        private void dgvWorkUnit_CurrentCellChanged( object sender , EventArgs e )
        {
            if ( dgvWorkUnit.CurrentCell == null )
                return;
            if ( dgvWorkUnit.Rows.Count == 0 )
                return;
            int row = dgvWorkUnit.CurrentCell.RowIndex;
            txtCode.Text = dgvWorkUnit[CODE.Name , row].Value.ToString( ).Trim( );
            txtName.Text = dgvWorkUnit[NAME.Name , row].Value.ToString( ).Trim( );
            txtPym.Text = dgvWorkUnit[PY_CODE.Name , row].Value.ToString( ).Trim( );
            txtWbm.Text = dgvWorkUnit[WB_CODE.Name , row].Value.ToString( ).Trim( );
            btnAdd.Enabled = true;
            txtCode.Enabled = false;
        }

        private void btnAdd_Click( object sender , EventArgs e )
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtPym.Text = "";
            txtWbm.Text = "";
            btnAdd.Enabled = false;
            txtCode.Enabled = true;
            txtCode.Focus( );
        }

        private void btnSave_Click( object sender , EventArgs e )
        {
            if ( txtCode.Text.Trim( ) == "" )
            {
                MessageBox.Show( "单位代码没有指定！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }
            if ( txtName.Text.Trim( ) == "" )
            {
                MessageBox.Show( "单位名称没有指定！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }

            WorkUnit workunit = new WorkUnit( );
            workunit.Code = txtCode.Text.Trim( );
            workunit.Name = txtName.Text.Trim( );
            workunit.PyCode = txtPym.Text.Trim( );
            workunit.WbCode = txtWbm.Text.Trim( );
            try
            {
                if ( btnAdd.Enabled == false )
                {
                    WorkUnitController.AddWorkUnit( workunit );
                    btnAdd.Enabled = true;
                }
                else
                {
                    WorkUnitController.UpdateWorkUnit( workunit );
                }
                dgvWorkUnit.DataSource = WorkUnitController.GetWorkunitList( ).DefaultView;
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }

        private void txtName_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
            {
                string[] pywb = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.GetPyWbCode( txtName.Text );
                txtPym.Text = pywb[0];
                txtWbm.Text = pywb[1];
                txtPym.Focus( );
            }
        }

        private void txtCode_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
            {
                txtName.Focus( );
            }
        }

        private void txtPym_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
            {
                txtWbm.Focus( );
            }
        }

        private void txtWbm_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
            {
                btnSave.Focus( );
            }
        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.Close( );
        }
    }
}
