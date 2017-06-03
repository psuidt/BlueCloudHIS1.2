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
    public partial class FrmSubItemEdit : GWI.HIS.Windows.Controls.BaseForm
    {
        public FrmSubItemEdit()
        {
            InitializeComponent( );
        }

        private void FrmSubItemEdit_Load( object sender , EventArgs e )
        {
            cboClassName.Items.Add( "门诊发票项目" );
            cboClassName.Items.Add( "住院发票项目" );
            cboClassName.Items.Add( "门诊会计项目" );
            cboClassName.Items.Add( "住院会计项目" );
            cboClassName.Items.Add( "门诊医保项目" );
            cboClassName.Items.Add( "住院医保项目" );
            cboClassName.Items.Add( "经管核算项目" );
            cboClassName.Items.Add( "病案统计项目" );
             
        }

        private void cboClassName_SelectedIndexChanged( object sender , EventArgs e )
        {
            DataTable tb = null;
            switch ( cboClassName.Text.Trim( ) )
            {
                case "门诊发票项目":
                    tb = HIS.Base_BLL.BaseDataReader.Base_Mzfp;
                    break;
                case "住院发票项目":
                    tb = HIS.Base_BLL.BaseDataReader.Base_Zyfp;
                    break;
                case "门诊会计项目":
                    tb = HIS.Base_BLL.BaseDataReader.Base_Mzkj;
                    break;
                case "住院会计项目":
                    tb = HIS.Base_BLL.BaseDataReader.Base_Zykj;
                    break;
                case "门诊医保项目":
                    tb = HIS.Base_BLL.BaseDataReader.Base_Mzyb;
                    break;
                case "住院医保项目":
                    tb = HIS.Base_BLL.BaseDataReader.Base_Zyyb;
                    break;
                case "经管核算项目":
                    tb = HIS.Base_BLL.BaseDataReader.Base_Hs;
                    break;
                case "病案统计项目":
                    tb = HIS.Base_BLL.BaseDataReader.Base_Ba;
                    break;
            }

            dgvSubItem.DataSource = tb;
        }

        

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.Close( );
        }

        private void btnAdd_Click( object sender , EventArgs e )
        {
            if ( cboClassName.SelectedIndex == -1 )
                return;


            ( (DataTable)dgvSubItem.DataSource ).Rows.Add( new object[] { "","",(short)0} );

            dgvSubItem.CurrentCell = dgvSubItem["CODE" , dgvSubItem.Rows.Count - 1];
            dgvSubItem.BeginEdit( true );
        }

        private void btnSave_Click( object sender , EventArgs e )
        {
            if ( cboClassName.SelectedIndex == -1 )
                return;
            if ( dgvSubItem.DataSource == null )
                return;

            DataTable tb = (DataTable)dgvSubItem.DataSource;

            foreach ( DataRow dr in tb.Rows )
            {
                if ( dr["CODE"].ToString( ).Trim( ) == "" || dr["ITEM_NAME"].ToString().Trim() == "")
                {
                    MessageBox.Show( "编码或名称不能为空" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    return;
                }
                //begin 2010-03-24 增加了代码重复性验证 by-wangzhi
                string code = dr["CODE"].ToString();
                if ( tb.Select( "CODE='" + code + "'" ).Length > 1 )
                {
                    MessageBox.Show( "编码【" + code + "】重复", "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    return;
                }
                //end
            }
            HIS.Base_BLL.SubStatItemName subItemName = HIS.Base_BLL.SubStatItemName.病案统计项目;
            switch ( cboClassName.Text.Trim( ) )
            {
                case "门诊发票项目":
                    subItemName = HIS.Base_BLL.SubStatItemName.门诊发票项目;
                    break;
                case "住院发票项目":
                    subItemName = HIS.Base_BLL.SubStatItemName.住院发票项目;
                    break;
                case "门诊会计项目":
                    subItemName = HIS.Base_BLL.SubStatItemName.门诊会计项目;
                    break;
                case "住院会计项目":
                    subItemName = HIS.Base_BLL.SubStatItemName.住院会计项目;
                    break;
                case "门诊医保项目":
                    subItemName = HIS.Base_BLL.SubStatItemName.门诊医保项目;
                    break;
                case "住院医保项目":
                    subItemName = HIS.Base_BLL.SubStatItemName.住院医保项目;
                    break;
                case "经管核算项目":
                    subItemName = HIS.Base_BLL.SubStatItemName.经管核算项目;
                    break;
                case "病案统计项目":
                    subItemName = HIS.Base_BLL.SubStatItemName.病案统计项目;
                    break;
            }
            try
            {
                foreach ( DataRow dr in tb.Rows )
                {
                    string code = dr["CODE"].ToString( ).Trim( );
                    string name = dr["ITEM_NAME"].ToString( ).Trim( );
                    int valid = Convert.ToInt32( Convert.IsDBNull( dr["VALID_FLAG"] ) ? 0 : dr["VALID_FLAG"] );
                    HIS.Base_BLL.SubStatItem subItem = new HIS.Base_BLL.SubStatItem( code , name , valid , subItemName );
                    subItem.Save( );
                }
                MessageBox.Show( "保存成功","",MessageBoxButtons.OK,MessageBoxIcon.Information );
            }
            catch(Exception err)
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }
    }
}
