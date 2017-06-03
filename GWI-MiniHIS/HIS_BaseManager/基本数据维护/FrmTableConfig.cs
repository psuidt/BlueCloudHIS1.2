using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;
using HIS_BaseManager.基本数据维护.Controller;

namespace HIS_BaseManager.基本数据维护
{
    public partial class FrmTableConfig : BaseForm,IFrmTableConfig
    {
        private FrmTableConfigController controller;

        public FrmTableConfig()
        {
            InitializeComponent();

        }

        private void btnClose_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void FrmTableConfig_Load( object sender, EventArgs e )
        {
            controller = new FrmTableConfigController( this );
            controller.Initiazle();

            cboTableDBName.DisplayMember = "NAME";
            cboTableDBName.ValueMember = "NAME";
            cboTableDBName.DataSource = controller.SystemTables;
            cboTableDBName.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTableDBName.SelectedIndexChanged += new EventHandler( cboTableDBName_SelectedIndexChanged );
        }

        void cboTableDBName_SelectedIndexChanged( object sender, EventArgs e )
        {
            controller.ShowTableConfig();
        }

        #region IFrmTableConfig 成员

        public string TABLE_DB_NAME
        {
            get
            {
                return cboTableDBName.Text.Trim();
            }
            set
            {
                cboTableDBName.Text = value;
            }
        }

        public string TABLE_CN_NAME
        {
            get
            {
                return txtTableCNName.Text.Trim();
            }
            set
            {
                txtTableCNName.Text = value;
            }
        }

        public int ALLOW_USER_EDIT
        {
            get
            {
                return chkAllowEdit.Checked ? 1 : 0;
            }
            set
            {
                chkAllowEdit.Checked = value == 1 ? true : false;
            }
        }
        public int ALLOW_PHYSIC_DELETE
        {
            get
            {
                return chkAllowDelete.Checked ? 1 : 0;
            }
            set
            {
                chkAllowDelete.Checked = value == 1 ? true : false;
            }
        }
        #endregion

        private void btnAddNew_Click( object sender, EventArgs e )
        {
            btnAddNew.Enabled = false;
            txtTableCNName.Text = "";
            chkAllowEdit.Checked = true;
            cboTableDBName.SelectedIndex = -1;
        }

        private void btnSave_Click( object sender, EventArgs e )
        {
            try
            {
                if ( btnAddNew.Enabled == false )
                {
                    controller.SaveTableConfig();
                }
                else
                {
                    controller.UpdateTableConfig();
                }
                MessageBox.Show( "保存成功！", "", MessageBoxButtons.OK, MessageBoxIcon.Information );
                controller.Initiazle();
                btnAddNew.Enabled = true;
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void btnDelete_Click( object sender, EventArgs e )
        {
            try
            {
                if ( MessageBox.Show( "确定要删除指定的表配置信息？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.No )
                    return;

                controller.DeleteTableConfig();
                this.Close();
            }
            catch(Exception err)
            {
                MessageBox.Show( err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }
    }
}
