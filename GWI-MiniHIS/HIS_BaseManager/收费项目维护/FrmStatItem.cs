using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_BaseManager
{
    public partial class FrmStatItem : GWMHIS.BussinessLogicLayer.Forms.BaseForm
    {
        private DataTable dtbMZFP;
        private DataTable dtbZYFP;
        private DataTable dtbMZYB;
        private DataTable dtbZYYB;
        private DataTable dtbMZKJ;
        private DataTable dtbZYKJ;
        private DataTable dtbHS;
        private DataTable dtbBA;

        public FrmStatItem(string FormText)
        {
            InitializeComponent( );

            this.Text = FormText;
            this.FormTitle = FormText;
        }

        private void CreateGrid()
        {
            DataGridViewColumn col;

            col = new DataGridViewTextBoxColumn( );
            col.HeaderText = "分类编码";
            col.DataPropertyName = "CODE";
            col.Name = col.DataPropertyName;
            col.Width = 80;
            dgvStatItem.Columns.Add( col );

            col = new DataGridViewTextBoxColumn( );
            col.HeaderText = "分类名称";
            col.DataPropertyName = "ITEM_NAME";
            col.Name = col.DataPropertyName;
            col.Width = 75;
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvStatItem.Columns.Add( col );

            col = new DataGridViewComboBoxColumn( );
            col.HeaderText = "门诊发票";
            col.Width = 90;
            ( (DataGridViewComboBoxColumn)col ).DataPropertyName = "MZFP_CODE";
            ( (DataGridViewComboBoxColumn)col ).DisplayMember = "ITEM_NAME";
            col.Name = col.DataPropertyName;
            ( (DataGridViewComboBoxColumn)col ).ValueMember = "CODE";
            ( (DataGridViewComboBoxColumn)col ).DataSource = dtbMZFP;
            ( (DataGridViewComboBoxColumn)col ).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            dgvStatItem.Columns.Add( col );

            col = new DataGridViewComboBoxColumn( );
            col.HeaderText = "住院发票";
            col.Width = 90;
            ( (DataGridViewComboBoxColumn)col ).DataPropertyName = "ZYFP_CODE";
            col.Name = col.DataPropertyName;
            ( (DataGridViewComboBoxColumn)col ).DisplayMember = "ITEM_NAME";
            ( (DataGridViewComboBoxColumn)col ).ValueMember = "CODE";
            ( (DataGridViewComboBoxColumn)col ).DataSource = dtbZYFP;
            ( (DataGridViewComboBoxColumn)col ).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            dgvStatItem.Columns.Add( col );

            col = new DataGridViewComboBoxColumn( );
            col.HeaderText = "门诊会计";
            col.Width = 90;
            ( (DataGridViewComboBoxColumn)col ).DataPropertyName = "MZKJ_CODE";
            col.Name = col.DataPropertyName;
            ( (DataGridViewComboBoxColumn)col ).DisplayMember = "ITEM_NAME";
            ( (DataGridViewComboBoxColumn)col ).ValueMember = "CODE";
            ( (DataGridViewComboBoxColumn)col ).DataSource = dtbMZKJ;
            ( (DataGridViewComboBoxColumn)col ).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            dgvStatItem.Columns.Add( col );

            col = new DataGridViewComboBoxColumn( );
            col.HeaderText = "住院会计";
            col.Width = 90;
            ( (DataGridViewComboBoxColumn)col ).DataPropertyName = "ZYKJ_CODE";
            col.Name = col.DataPropertyName;
            ( (DataGridViewComboBoxColumn)col ).DisplayMember = "ITEM_NAME";
            ( (DataGridViewComboBoxColumn)col ).ValueMember = "CODE";
            ( (DataGridViewComboBoxColumn)col ).DataSource = dtbZYKJ;
            ( (DataGridViewComboBoxColumn)col ).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            dgvStatItem.Columns.Add( col );

            col = new DataGridViewComboBoxColumn( );
            col.HeaderText = "经管核算";
            col.Width = 90;
            ( (DataGridViewComboBoxColumn)col ).DataPropertyName = "HS_CODE";
            col.Name = col.DataPropertyName;
            ( (DataGridViewComboBoxColumn)col ).DisplayMember = "ITEM_NAME";
            ( (DataGridViewComboBoxColumn)col ).ValueMember = "CODE";
            ( (DataGridViewComboBoxColumn)col ).DataSource = dtbHS;
            ( (DataGridViewComboBoxColumn)col ).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            dgvStatItem.Columns.Add( col );

            col = new DataGridViewComboBoxColumn( );
            col.HeaderText = "病案统计";
            col.Width = 90;
            ( (DataGridViewComboBoxColumn)col ).DataPropertyName = "BA_CODE";
            col.Name = col.DataPropertyName;
            ( (DataGridViewComboBoxColumn)col ).DisplayMember = "ITEM_NAME";
            ( (DataGridViewComboBoxColumn)col ).ValueMember = "CODE";
            ( (DataGridViewComboBoxColumn)col ).DataSource = dtbBA;
            ( (DataGridViewComboBoxColumn)col ).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            dgvStatItem.Columns.Add( col );

            col = new DataGridViewComboBoxColumn( );
            col.HeaderText = "门诊医保";
            col.Width = 90;
            ( (DataGridViewComboBoxColumn)col ).DataPropertyName = "MZYB_CODE";
            col.Name = col.DataPropertyName;
            ( (DataGridViewComboBoxColumn)col ).DisplayMember = "ITEM_NAME";
            ( (DataGridViewComboBoxColumn)col ).ValueMember = "CODE";
            ( (DataGridViewComboBoxColumn)col ).DataSource = dtbMZYB;
            ( (DataGridViewComboBoxColumn)col ).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            dgvStatItem.Columns.Add( col );

            col = new DataGridViewComboBoxColumn( );
            col.HeaderText = "住院医保";
            col.Width = 90;
            ( (DataGridViewComboBoxColumn)col ).DataPropertyName = "ZYYB_CODE";
            col.Name = col.DataPropertyName;
            ( (DataGridViewComboBoxColumn)col ).DisplayMember = "ITEM_NAME";
            ( (DataGridViewComboBoxColumn)col ).ValueMember = "CODE";
            ( (DataGridViewComboBoxColumn)col ).DataSource = dtbZYYB;
            ( (DataGridViewComboBoxColumn)col ).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            dgvStatItem.Columns.Add( col );

            col = new DataGridViewTextBoxColumn( );
            col.HeaderText = "项目类型";
            col.DataPropertyName = "ITEM_TYPE";
            col.Name = col.DataPropertyName;
            col.Width = 0;
            col.Visible = false;
            dgvStatItem.Columns.Add( col );

            col = new DataGridViewTextBoxColumn( );
            col.HeaderText = "处方类型";
            col.DataPropertyName = "CFLX_CODE";
            col.Name = col.DataPropertyName;
            col.Width = 0;
            col.Visible = false;
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvStatItem.Columns.Add( col );

            col = new DataGridViewTextBoxColumn( );
            col.HeaderText = "拼音码";
            col.DataPropertyName = "PY_CODE";
            col.Name = col.DataPropertyName;
            col.Width = 0;
            col.Visible = false;
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvStatItem.Columns.Add( col );

            col = new DataGridViewTextBoxColumn( );
            col.HeaderText = "五笔码";
            col.DataPropertyName = "WB_CODE";
            col.Name = col.DataPropertyName;
            col.Width = 0;
            col.Visible = false;
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvStatItem.Columns.Add( col );
        }

        private void FrmStatItem_Load( object sender , EventArgs e )
        {
            dtbMZFP = HIS.Base_BLL.BaseDataReader.Base_Mzfp;
            dtbZYFP = HIS.Base_BLL.BaseDataReader.Base_Zyfp;
            dtbMZYB = HIS.Base_BLL.BaseDataReader.Base_Mzyb;
            dtbZYYB = HIS.Base_BLL.BaseDataReader.Base_Zyyb;
            dtbMZKJ = HIS.Base_BLL.BaseDataReader.Base_Mzkj;
            dtbZYKJ = HIS.Base_BLL.BaseDataReader.Base_Zykj;
            dtbHS = HIS.Base_BLL.BaseDataReader.Base_Hs;
            dtbBA = HIS.Base_BLL.BaseDataReader.Base_Ba;

            CreateGrid( );

            dgvStatItem.DataSource = HIS.Base_BLL.BaseDataReader.Base_Stat_Item;
        }

        private void dgvStatItem_DataError( object sender , DataGridViewDataErrorEventArgs e )
        {
            e.Cancel = true;
        }

      

        private void dgvStatItem_DoubleClick( object sender, EventArgs e )
        {

            btnEdit_Click( null, null );
        }

        private void btnAdd_Click( object sender, EventArgs e )
        {
            FrmStatItemEdit fEdit = new FrmStatItemEdit();
            fEdit.ShowDialog();
        }

        private void btnEdit_Click( object sender, EventArgs e )
        {
            if ( dgvStatItem.Rows.Count == 0 )
                return;
            if ( dgvStatItem.CurrentCell == null )
                return;
            string code = dgvStatItem["CODE", dgvStatItem.CurrentCell.RowIndex].Value.ToString().Trim();
            FrmStatItemEdit fEdit = new FrmStatItemEdit( code );
            if ( fEdit.ShowDialog() == DialogResult.OK )
            {
                MessageBox.Show( "项目对应关系已发生改变，请刷新", "", MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
        }

        private void btnSubClass_Click( object sender, EventArgs e )
        {
            FrmSubItemEdit frmEdit = new FrmSubItemEdit();
            frmEdit.ShowDialog();
        }

        private void btnRefresh_Click( object sender, EventArgs e )
        {
            dtbMZFP = HIS.Base_BLL.BaseDataReader.Base_Mzfp;
            dtbZYFP = HIS.Base_BLL.BaseDataReader.Base_Zyfp;
            dtbMZYB = HIS.Base_BLL.BaseDataReader.Base_Mzyb;
            dtbZYYB = HIS.Base_BLL.BaseDataReader.Base_Zyyb;
            dtbMZKJ = HIS.Base_BLL.BaseDataReader.Base_Mzkj;
            dtbZYKJ = HIS.Base_BLL.BaseDataReader.Base_Zykj;
            dtbHS = HIS.Base_BLL.BaseDataReader.Base_Hs;
            dtbBA = HIS.Base_BLL.BaseDataReader.Base_Ba;
            dgvStatItem.Columns.Clear();
            CreateGrid();

            dgvStatItem.DataSource = HIS.Base_BLL.BaseDataReader.Base_Stat_Item;
        }

        private void btnClose_Click( object sender, EventArgs e )
        {
            this.Close();
        }
    }
}
