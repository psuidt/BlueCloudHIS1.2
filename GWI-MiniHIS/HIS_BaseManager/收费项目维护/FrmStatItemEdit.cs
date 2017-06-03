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
    public partial class FrmStatItemEdit : GWI.HIS.Windows.Controls.BaseForm
    {
        private bool _isAddNew;

        private HIS.Base_BLL.StatItem _statItem;

        public FrmStatItemEdit()
        {
            InitializeComponent( );
            _isAddNew = true;

            this.Text = "新增统计大类";
        }

        public FrmStatItemEdit(string Code)
        {
            InitializeComponent( );
            _isAddNew = false;
            _statItem = new HIS.Base_BLL.StatItem( Code );

            this.Text = "修改统计大类-" + _statItem.DBFields.ITEM_NAME;
        }
        

        private void btnCancel_Click( object sender , EventArgs e )
        {
            this.Close( );
        }

        private void FrmStatItemEdit_Load( object sender , EventArgs e )
        {
            #region load data
            cboBa.DisplayMember = "ITEM_NAME";
            cboBa.ValueMember = "CODE";
            cboBa.DataSource = HIS.Base_BLL.BaseDataReader.Base_Ba;

            cboHs.DisplayMember = "ITEM_NAME";
            cboHs.ValueMember = "CODE";
            cboHs.DataSource = HIS.Base_BLL.BaseDataReader.Base_Hs;

            cboMzfp.DisplayMember = "ITEM_NAME";
            cboMzfp.ValueMember = "CODE";
            cboMzfp.DataSource = HIS.Base_BLL.BaseDataReader.Base_Mzfp;

            cboZyfp.DisplayMember = "ITEM_NAME";
            cboZyfp.ValueMember = "CODE";
            cboZyfp.DataSource = HIS.Base_BLL.BaseDataReader.Base_Zyfp;

            cboMzkj.DisplayMember = "ITEM_NAME";
            cboMzkj.ValueMember = "CODE";
            cboMzkj.DataSource = HIS.Base_BLL.BaseDataReader.Base_Mzkj;

            cboZykj.DisplayMember = "ITEM_NAME";
            cboZykj.ValueMember = "CODE";
            cboZykj.DataSource = HIS.Base_BLL.BaseDataReader.Base_Zykj;

            cboMzyb.DisplayMember = "ITEM_NAME";
            cboMzyb.ValueMember = "CODE";
            cboMzyb.DataSource = HIS.Base_BLL.BaseDataReader.Base_Mzyb;

            cboZyyb.DisplayMember = "ITEM_NAME";
            cboZyyb.ValueMember = "CODE";
            cboZyyb.DataSource = HIS.Base_BLL.BaseDataReader.Base_Zyyb;

            cboCflx.Items.Add( "治疗项目" );
            cboCflx.Items.Add( "西药" );
            cboCflx.Items.Add( "中成药" );
            cboCflx.Items.Add( "中草药" );
            #endregion

            if ( !_isAddNew )
            {
                lblNote.Visible = false;
                txtItemName.Text = _statItem.DBFields.ITEM_NAME;
                txtItemName.Enabled = false; //2010-3-24控制了编辑状态不可修改，by-wangzhi
                txtCode.Text = _statItem.DBFields.CODE;
                txtCode.Enabled = false;
                if ( _statItem.DBFields.ITEM_TYPE == 1 )
                    chkItemType.Checked = true;
                
                cboBa.SelectedValue = _statItem.DBFields.BA_CODE;
                cboHs.SelectedValue = _statItem.DBFields.HS_CODE;
                cboMzfp.SelectedValue = _statItem.DBFields.MZFP_CODE;
                cboZyfp.SelectedValue = _statItem.DBFields.ZYFP_CODE;
                cboMzyb.SelectedValue = _statItem.DBFields.MZYB_CODE;
                cboZyyb.SelectedValue = _statItem.DBFields.ZYYB_CODE;
                cboMzkj.SelectedValue = _statItem.DBFields.MZKJ_CODE;
                cboZykj.SelectedValue = _statItem.DBFields.ZYKJ_CODE;

                switch ( _statItem.DBFields.CFLX_CODE.Trim() )
                {
                    case "1":
                        cboCflx.SelectedIndex = 1;
                        break;
                    case "2":
                        cboCflx.SelectedIndex = 2;
                        break;
                    case "3":
                        cboCflx.SelectedIndex = 3;
                        break;
                    default:
                        cboCflx.SelectedIndex = 0;
                        break;
                }
            }
        }

        private void btnSave_Click( object sender , EventArgs e )
        {
            if ( _isAddNew )
            {
                _statItem = new HIS.Base_BLL.StatItem( );
                
            }
            _statItem.DBFields.BA_CODE = cboBa.SelectedValue==null ? "-1" : cboBa.SelectedValue.ToString( );
            _statItem.DBFields.CFLX_CODE = cboCflx.SelectedIndex.ToString();
            _statItem.DBFields.CODE = txtCode.Text.Trim();
            _statItem.DBFields.HS_CODE = cboHs.SelectedValue == null ? "-1" : cboHs.SelectedValue.ToString( );
            _statItem.DBFields.ITEM_NAME = txtItemName.Text;
            _statItem.DBFields.ITEM_TYPE = chkItemType.Checked ? 1 : 0;
            _statItem.DBFields.MZFP_CODE = cboMzfp.SelectedValue == null ? "-1" : cboMzfp.SelectedValue.ToString( );
            _statItem.DBFields.MZKJ_CODE = cboMzkj.SelectedValue == null ? "-1" : cboMzkj.SelectedValue.ToString( );
            _statItem.DBFields.MZYB_CODE = cboMzyb.SelectedValue == null ? "-1" : cboMzyb.SelectedValue.ToString( );
            string[] pywb = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.GetPyWbCode( txtItemName.Text );
            _statItem.DBFields.PY_CODE = pywb[0];
            _statItem.DBFields.WB_CODE = pywb[1];
            _statItem.DBFields.ZYFP_CODE = cboZyfp.SelectedValue == null ? "-1" : cboZyfp.SelectedValue.ToString( );
            _statItem.DBFields.ZYKJ_CODE = cboZykj.SelectedValue == null ? "-1" : cboZykj.SelectedValue.ToString( );
            _statItem.DBFields.ZYYB_CODE = cboZyyb.SelectedValue == null ? "-1" : cboZyyb.SelectedValue.ToString( );

            if ( _statItem.DBFields.CODE.Trim( ) == "" )
            {
                MessageBox.Show( "代码不能为空！" ,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            try
            {
                if ( _isAddNew )
                    _statItem.Add( );
                else
                    _statItem.Update();

                this.DialogResult = DialogResult.OK;
                this.Close( );
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }
    }
}
