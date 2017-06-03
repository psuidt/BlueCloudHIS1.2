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
    public partial class FrmRegBaseDataSet : GWI.HIS.Windows.Controls.BaseForm, IFrmRegBaseDataSet
    {
        /// <summary>
        /// 诊疗服务项目
        /// </summary>
        //private DataTable tbServiceItems;


        private UIControllerFrmRegBaseDataSet uc;

        public FrmRegBaseDataSet()
        {
            InitializeComponent();
        }
              
        private void FrmRegBaseDataSet_Load( object sender, EventArgs e )
        {
            uc = new UIControllerFrmRegBaseDataSet( this );
            uc.InitData();
            
            dgvItems.SetSelectionCardDataSource( uc.ServiceItems , 1 );

            ImageList img = new ImageList();
            img.ImageSize = new Size( 5, 25 );
            lvwRegTypeDefine.SmallImageList = img;

           
        }

        private void btnNewType_Click( object sender, EventArgs e )
        {

            if ( txtTypeCode.Text.Trim() == "" )
            {
                MessageBox.Show( "请选择挂号类别" , "" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                return;
            }

            string typeCode = txtTypeCode.Text;
            dgvItems.Rows.Add( );
            dgvItems.CurrentCell = dgvItems["CODE", dgvItems.Rows.Count - 1];
            dgvItems.Focus();
        }

        private void btnRemoveItem_Click( object sender, EventArgs e )
        {
            if ( dgvItems.Rows.Count > 0 && dgvItems.CurrentCell!=null )
            {
                dgvItems.Rows.RemoveAt( dgvItems.CurrentCell.RowIndex );
            }
        }

        private void dgvItems_SelectCardRowSelected( object SelectedValue, ref bool stop, ref int customNextColumnIndex )
        {
            if ( SelectedValue != null )
            {
                string typeCode = txtTypeCode.Text;
                dgvItems["TYPE_CODE",dgvItems.CurrentCell.RowIndex].Value = TypeCode;
                dgvItems["ITEM_ID" , dgvItems.CurrentCell.RowIndex].Value = ( (DataRow)SelectedValue )["ITEM_ID"].ToString( );
                dgvItems["ITEM_NAME" , dgvItems.CurrentCell.RowIndex].Value = ( (DataRow)SelectedValue )["ITEM_NAME"].ToString( );
                dgvItems["Price" , dgvItems.CurrentCell.RowIndex].Value = ( (DataRow)SelectedValue )["Price"].ToString( );
                btnNewType_Click( null , null );
            }
        }

       



        #region IFrmRegBaseDataSet 成员

        public DataTable RegTypeDefine
        {
            get
            {
                if ( lvwRegTypeDefine.Tag != null )
                    return (DataTable)lvwRegTypeDefine.Tag;
                else
                    return null;
            }
            set
            {
                lvwRegTypeDefine.Tag = value;
                lvwRegTypeDefine.Items.Clear();
                for ( int i = 0; i < value.Rows.Count; i++ )
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = "";
                    item.SubItems.Add( value.Rows[i]["TYPE_CODE"].ToString().Trim());
                    item.SubItems.Add( value.Rows[i]["TYPE_NAME"].ToString().Trim() );
                    item.SubItems.Add( value.Rows[i]["PY_CODE"].ToString().Trim() );
                    item.SubItems.Add( value.Rows[i]["WB_CODE"].ToString().Trim() );
                    item.Checked = Convert.ToInt32( value.Rows[i]["valid_flag"] ) == 1 ? true : false;
                    item.Text = item.Checked ? "√" : "×";
                    item.Tag = uc.GetDetailItems( value.Rows[i]["TYPE_CODE"].ToString().Trim() );
                    lvwRegTypeDefine.Items.Add( item );
                }
            }
        }

        public string TypeCode
        {
            get
            {
                return txtTypeCode.Text;
            }
            set
            {
                txtTypeCode.Text = value;
            }
        }

        public string TypeName
        {
            get
            {
                return txtTypeName.Text;
            }
            set
            {
                txtTypeName.Text = value;
            }
        }

        public string Pym
        {
            get
            {
                return txtPY.Text;
            }
            set
            {
                txtPY.Text = value;
            }
        }

        public string Wbm
        {
            get
            {
                return txtWB.Text;
            }
            set
            {
                txtWB.Text = value;
            }
        }

        public bool Valid
        {
            get
            {
                return chkValid.Checked;
            }
            set
            {
                chkValid.Checked = value;
            }
        }

        #endregion

        private void lvwRegTypeDefine_SelectedIndexChanged( object sender, EventArgs e )
        {
            if ( lvwRegTypeDefine.SelectedItems.Count > 0 )
            {
                txtTypeCode.Text = lvwRegTypeDefine.SelectedItems[0].SubItems[1].Text;
                txtTypeName.Text = lvwRegTypeDefine.SelectedItems[0].SubItems[2].Text;
                txtPY.Text = lvwRegTypeDefine.SelectedItems[0].SubItems[3].Text;
                txtWB.Text = lvwRegTypeDefine.SelectedItems[0].SubItems[4].Text;
                chkValid.Checked = lvwRegTypeDefine.SelectedItems[0].Checked;
                DataTable tb = uc.GetDetailItems( txtTypeCode.Text );
                dgvItems.Rows.Clear( );
                for ( int i = 0 ; i < tb.Rows.Count ; i++ )
                {
                    dgvItems.Rows.Add( );
                    int row = dgvItems.Rows.Count - 1;
                    dgvItems["TYPE_CODE" , row].Value = txtTypeCode.Text;
                    dgvItems["ITEM_ID" , row].Value = tb.Rows[i]["ITEM_ID"].ToString( );
                    dgvItems["ITEM_NAME" , row].Value = tb.Rows[i]["ITEM_NAME"].ToString( );
                    dgvItems["Price" , row].Value = tb.Rows[i]["Price"].ToString( );
                }
                btnAddType.Enabled = true;
                txtTypeCode.Enabled = false;
            }
        }

        private void queryTextBox2_TextChanged( object sender, EventArgs e )
        {

        }

        private void btnAddType_Click( object sender, EventArgs e )
        {
            txtTypeCode.Text = "";
            txtTypeName.Text = "";
            txtPY.Text = "";
            txtWB.Text = "";
            chkValid.Checked = true;
            txtTypeCode.Enabled = true;
            dgvItems.Rows.Clear( );
            txtTypeCode.Focus( );
            btnAddType.Enabled = false;

            
        }

        private void btnEditType_Click( object sender, EventArgs e )
        {
            if ( txtTypeCode.Text.Trim() == "" )
                return;

            try
            {
                RegTypeItem regtypeitem = new RegTypeItem( );
                regtypeitem.TypeCode = txtTypeCode.Text;
                regtypeitem.TypeName = txtTypeName.Text;
                regtypeitem.PyCode = txtPY.Text;
                regtypeitem.WbCode = txtWB.Text;
                regtypeitem.ValidFlag = chkValid.Checked ? 1 : 0;
                regtypeitem.Items = new List<int>( );
                for ( int i = 0 ; i < dgvItems.Rows.Count ; i++ )
                {
                    if ( dgvItems["ITEM_ID" , i].Value != null )
                        regtypeitem.Items.Add( Convert.ToInt32( dgvItems["ITEM_ID" , i].Value ) );
                }

                if ( btnAddType.Enabled == false )
                {
                    uc.AddNewType( regtypeitem );

                    
                    btnAddType.Enabled = true;
                    txtTypeCode.Enabled = false;
                    MessageBox.Show( "新增成功" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                }
                else
                {
                    uc.SaveRegType( regtypeitem );
                    
                    MessageBox.Show( "修改成功" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                }
                uc.InitData( );
                
            }
            catch(Exception err)
            {
                MessageBox.Show( err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void button1_Click( object sender , EventArgs e )
        {
            this.Close( );
        }

        private void txtTypeName_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
            {
                string[] pywb = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.GetPyWbCode( txtTypeName.Text );
                txtPY.Text = pywb[0];
                txtWB.Text = pywb[1];
            }
        }
    }
}
