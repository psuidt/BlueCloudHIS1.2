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
    public partial class FrmEdit : GWI.HIS.Windows.Controls.BaseForm
    {
        
        private HIS.Base_BLL.ServiceItem item;
       
        private DataGridView grid;

        public FrmEdit()
        {
            InitializeComponent();

            this.Text = "新增医疗服务项目";
        }

        public FrmEdit(HIS.Base_BLL.ServiceItem Item ,DataGridView grd) 
        {
            InitializeComponent();
            item = Item;
            grid = grd;
            this.Text = "修改医疗服务项目--" + item.ITEM_NAME;
        }

        private void FrmEdit_Load( object sender , EventArgs e )
        {
            //cboStatItem.DisplayMember = "ITEM_NAME";
            //cboStatItem.ValueMember = "CODE";
            //cboStatItem.DataSource = HIS.Base_BLL.BaseDataReader.Base_Stat_Item;
            DataTable tb = HIS.Base_BLL.BaseDataReader.Base_Stat_Item.Clone( );
            DataRow[] drs = HIS.Base_BLL.BaseDataReader.Base_Stat_Item.Select("code not in ('00','01','02','03') and item_type<>1");
            for ( int i = 0 ; i < drs.Length ; i++ )
            {
                tb.Rows.Add( drs[i].ItemArray );
            }

            cboStatItem.SetSelectionCardDataSource( tb );

            cboInsurType.DisplayMember = "MEDICARENAME";
            cboInsurType.ValueMember = "MEDICARENAME";
            cboInsurType.DataSource = HIS.Base_BLL.BaseDataReader.Get_Insur_Type( );


            if (item != null)
            {
                ShowItemDetail( );
                btnSave.Text = "修改(&S)";

            }
            else
            {
                this.txtStdCode.Text = "";
                this.txtItemName.Text = "";
                this.txtPrice.Text = "";
                this.txtUnit.Text = "";
                this.cboStatItem.MemberValue = null;
                this.cboStatItem.Text = "";
                this.chkValid.Checked = true;
                this.txtNcmsCompRate.Text = "0";
                
                btnSave.Text = "保存(&S)";
                btnNext.Visible = false;
                btnPrevious.Visible = false;
                
            }
        }

        private void btnSave_Click( object sender , EventArgs e )
        {
            
            if ( cboStatItem.MemberValue == null || cboStatItem.Text == "" )
            {
                MessageBox.Show( "请为该项目设置统计大类" , "" , MessageBoxButtons.OK , MessageBoxIcon.Exclamation );
                return;

            }
            if ( txtPrice.Text.Trim( ) != ""  )
            {
                if ( !HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNumeric( txtPrice.Text ) )
                {
                    MessageBox.Show( "单价请输入数字" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    txtPrice.Focus( );
                    return;
                }
                else
                {
                    if ( Convert.ToDecimal( txtPrice.Text ) == 0 )
                    {
                        MessageBox.Show( "单价不能为0，请重新输入" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                        txtPrice.Focus( );
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show( "单价没有输入" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                txtPrice.Focus( );
                return;
            }
            //执行保存操作
            try
            {
                ServiceItemController serviceItemController = new ServiceItemController();

                if ( item == null )
                {
                    item = new HIS.Base_BLL.ServiceItem( );
                    string[] pywb = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.GetPyWbCode( this.txtItemName.Text );
                    item.ITEM_NAME = this.txtItemName.Text;
                    item.PY_CODE = pywb[0];
                    item.WB_CODE = pywb[1];
                    item.STD_CODE = this.txtStdCode.Text;
                    item.PRICE = Convert.ToDecimal( this.txtPrice.Text );
                    item.ITEM_UNIT = this.txtUnit.Text;
                    item.STATITEM_CODE = this.cboStatItem.MemberValue.ToString( );
                    item.NCMS_COMP_RATE = Convert.ToDecimal( this.txtNcmsCompRate.Text );
                    item.INSUR_TYPE = cboInsurType.Text;

                    item.VALID_FLAG = chkValid.Checked ? 1 : 0;

                    serviceItemController.AddServiceItems(item);
                    this.txtStdCode.Text = "";
                    this.txtItemName.Text = "";
                    this.txtPrice.Text = "";
                    this.txtUnit.Text = "";
                    this.cboStatItem.MemberValue = null;
                    this.cboStatItem.Text = "";
                    this.chkValid.Checked = true;
                    item = null;
                    MessageBox.Show("保存成功！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //if ( item.Add( ) )
                    //{
                    //    this.txtStdCode.Text = "";
                    //    this.txtItemName.Text = "";
                    //    this.txtPrice.Text = "";
                    //    this.txtUnit.Text = "";
                    //    this.cboStatItem.MemberValue = null;
                    //    this.cboStatItem.Text = "";
                    //    this.chkValid.Checked = true;
                    //    item = null;
                    //    MessageBox.Show( "保存成功！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                    //}
                }
                else
                {
                    string[] pywb = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.GetPyWbCode( this.txtItemName.Text );
                    item.ITEM_ID = item.ITEM_ID;
                    item.ITEM_NAME = this.txtItemName.Text;
                    item.PY_CODE = pywb[0];
                    item.WB_CODE = pywb[1];
                    item.STD_CODE = this.txtStdCode.Text;
                    item.PRICE = Convert.ToDecimal( this.txtPrice.Text );
                    item.ITEM_UNIT = this.txtUnit.Text;
                    item.STATITEM_CODE = this.cboStatItem.MemberValue.ToString( );
                    item.VALID_FLAG = chkValid.Checked ? 1 : 0;
                    item.NCMS_COMP_RATE = Convert.ToDecimal( this.txtNcmsCompRate.Text );
                    item.INSUR_TYPE = cboInsurType.Text;

                    serviceItemController.UpdateServiceItem(item);
                    btnSave.Enabled = false;

                    //if ( item.Update( ) )
                    //{
                    //    btnSave.Enabled = false;
                    //}
                }

            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message );
            }
        }

        private void btnCancel_Click( object sender , EventArgs e )
        {
            this.Close( );
        }

        private void btnNext_Click( object sender , EventArgs e )
        {
            int row = grid.CurrentCell.RowIndex;
            if ( row == grid.Rows.Count - 1 )
                return;
            else
            {
                row = row + 1;
                grid.CurrentCell = grid["ITEM_NAME" , row];

            }
            int item_id = Convert.ToInt32( grid["ITEM_ID" , row].Value );

            item = new HIS.Base_BLL.ServiceItem( item_id );

            ShowItemDetail( );
            btnSave.Enabled = true;
        }

        private void btnPrevious_Click( object sender , EventArgs e )
        {
            int row = grid.CurrentCell.RowIndex;
            if ( row == 0 )
                return;
            else
            {
                row = row - 1;
                grid.CurrentCell = grid["ITEM_NAME" , row];

            }
            int item_id = Convert.ToInt32( grid["ITEM_ID" , row].Value );

            item = new HIS.Base_BLL.ServiceItem( item_id );

            ShowItemDetail( );

            btnSave.Enabled = true;
        }

        private void ShowItemDetail()
        {
            this.txtStdCode.Text = item.STD_CODE.Trim();
            this.txtItemName.Text = item.ITEM_NAME.Trim();
            this.txtPrice.Text = item.PRICE.ToString( );
            this.txtUnit.Text = item.ITEM_UNIT.Trim();
            this.cboStatItem.MemberValue = item.STATITEM_CODE.Trim();
            this.chkValid.Checked = item.VALID_FLAG == 1 ? true : false;
            this.txtNcmsCompRate.Text = item.NCMS_COMP_RATE.ToString();
            this.cboInsurType.SelectedValue = item.INSUR_TYPE.Trim();
            this.Text = "修改医疗服务项目--" + item.ITEM_NAME.Trim();
            
        }

        private void FrmEdit_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 27 )
                this.Close();
        }

        private void cboInsurType_SelectedIndexChanged( object sender , EventArgs e )
        {

        }

        
    }
}
