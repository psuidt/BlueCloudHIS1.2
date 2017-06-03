using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.Base_BLL;

namespace HIS_BaseManager
{
    public partial class FrmTemplate : BaseMainForm
    {
        private User _currentUser;
        private Deptment _currentDept;
        /// <summary>
        /// 0-划价模板 1-医生处方模板
        /// </summary>
        private int opType;

        private bool bClose;

        private DataTable tbShowCardItems;
        private DataTable tbTemplateList;
        private DataTable tbTemplateDetails;

        private void LoadData(bool ShowCard,bool TemplateList,bool TemplateDetail)
        {
            
            if ( ShowCard )
            {
                DataTable tbItems = HIS.Base_BLL.BaseDataReader.Get_ShowCardList( );
                DataRow[] drs = tbItems.Select( "ISTEMPLATE=0" );
                tbShowCardItems = new DataTable( );
                tbShowCardItems = tbItems.Clone( );
                for ( int i = 0 ; i < drs.Length ; i++ )
                    tbShowCardItems.Rows.Add( drs[i].ItemArray );

                dgvDetail.SetSelectionCardDataSource( tbShowCardItems , "CODE" );
            }

            if ( TemplateList )
            {
                tbTemplateList = HIS.Base_BLL.BaseDataReader.Get_TemplateList( );
                dgvTemplate.DataSource = tbTemplateList.DefaultView;
            }

            if ( TemplateDetail )
                tbTemplateDetails = HIS.Base_BLL.BaseDataReader.Get_TemplateDetailList( );

            
        }
 
        /// <summary>
        /// 模板维护
        /// </summary>
        /// <param name="FormText"></param>
        /// <param name="CurrentUser"></param>
        /// <param name="OPType">0-划价模板 1-医生处方模板</param>
        public FrmTemplate( string FormText , User CurrentUser , Deptment CurrentDept , int OPType )
        {
            InitializeComponent( );

            this.FormTitle = FormText;
            this.Text = FormText;
            _currentUser = CurrentUser;
            _currentDept = CurrentDept;
            opType = OPType;
        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            bClose = true;
            this.Close( );
        }

        private void dgvTemplate_CurrentCellChanged( object sender , EventArgs e )
        {
            
            if ( dgvTemplate.Rows.Count == 0 )
                return;
            if ( dgvTemplate.CurrentCell == null )
                return;
            if ( tbTemplateList == null )
                return;

            if ( tbTemplateDetails == null )
                return;

            int row = dgvTemplate.CurrentCell.RowIndex;
            string tmplate_id = dgvTemplate["TMPLATE_ID",row].Value.ToString().Trim();
            txtTemplateName.Text = dgvTemplate["TMPLATE_NAME",row].Value.ToString().Trim();
            txtPyCode.Text = dgvTemplate["PY_CODE" , row].Value.ToString( ).Trim( );
            txtWbCode.Text = dgvTemplate["WB_CODE" , row].Value.ToString( ).Trim( );
            cboType.SelectedIndex = dgvTemplate["TMPLATE_TYPE" , row].Value==null ? -1 : Convert.ToInt32( dgvTemplate["TMPLATE_TYPE" , row].Value );
            cboType.Enabled = false;
            if ( dgvTemplate["VALID_FLAG" , row].Value == null )
                chkValid.Checked = false;
            else
                chkValid.Checked = Convert.ToInt32( dgvTemplate["VALID_FLAG" , row].Value ) == 1 ? true : false;
            txtExecDept.MemberValue = Convert.ToInt32( dgvTemplate["EXEC_DEPT_ID" , row].Value );
            txtExecDept.Text = dgvTemplate["EXEC_DEPT_NAME" , row].Value.ToString( ).Trim( );

            #region 显示明细
            DataRow[] drs = tbTemplateDetails.Select( "TEMPLATE_ID=" + tmplate_id );
            dgvDetail.Rows.Clear( );
            for ( int i = 0 ; i < drs.Length ; i++ )
            {
                dgvDetail.Rows.Add( );
                row = dgvDetail.Rows.Count - 1;
                dgvDetail["TEMPLATE_ID" , row].Value = Convert.ToInt32( drs[i]["TEMPLATE_ID"] );
                dgvDetail["ITEM_ID" , row].Value = Convert.ToInt32( drs[i]["ITEM_ID"] );
                dgvDetail["COMPLEX_ID" , row].Value = Convert.ToInt32( drs[i]["COMPLEX_ID"] );
                dgvDetail["ITEM_NAME" , row].Value = drs[i]["ITEM_NAME"].ToString( ).Trim( );
                dgvDetail["STANDARD" , row].Value = drs[i]["STANDARD"].ToString( ).Trim( );
                dgvDetail["UNIT" , row].Value = drs[i]["UNIT"].ToString( ).Trim( );
                dgvDetail["BIGITEMCODE" , row].Value = drs[i]["BIGITEMCODE"].ToString( ).Trim( );
                dgvDetail["DOSAGE" , row].Value = Convert.ToDecimal( drs[i]["DOSAGE"] );
                dgvDetail["FREQUEN_ID" , row].Value = Convert.ToInt32( drs[i]["FREQUEN_ID"] );
                dgvDetail["FREQUEN_NAME" , row].Value = drs[i]["FREQUEN_NAME"].ToString( ).Trim( );
                dgvDetail["DAYS" , row].Value = Convert.ToInt32( drs[i]["DAYS"] );
                dgvDetail["USAGE_NAME" , row].Value = drs[i]["USAGE_NAME"].ToString( ).Trim( );
                dgvDetail["GROUP_FLAG" , row].Value = Convert.ToInt16( drs[i]["GROUP_FLAG"] );
                dgvDetail["SORT_NO" , row].Value = Convert.ToInt32( drs[i]["SORT_NO"] );
                dgvDetail["AMOUNT" , row].Value = Convert.ToInt32( drs[i]["AMOUNT"] );

                DataRow[] drsItems = tbShowCardItems.Select( "ITEM_ID=" + dgvDetail["ITEM_ID" , row].Value.ToString( ) + " and COMPLEX_ID=" + dgvDetail["COMPLEX_ID" , row].Value.ToString() );
                if ( drsItems.Length == 0 )
                {
                    MessageBox.Show( "【" + dgvDetail["ITEM_NAME" , row].Value.ToString( ).Trim( ) + "】无效,请确认是否在本院医疗服务项目中存在！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    dgvDetail.SetRowColor( row , Color.Gray , Color.White );
                }
            }
            #endregion

            btnSave.Enabled = true;
            btnAddNew.Enabled = true;
        }

        private void btnAddNew_Click( object sender , EventArgs e )
        {
            txtTemplateName.Text = "";
            txtPyCode.Text = "";
            txtWbCode.Text = "";
            txtExecDept.MemberValue = 0;
            txtExecDept.Text = "";
            txtExecDept.Enabled = true;
            cboType.SelectedIndex = -1;
            cboType.Enabled = true;
            
            chkValid.Checked = true;
            btnAddNew.Enabled = false;

            dgvDetail.Rows.Clear( );

            cboType.Focus( );

        }

        private void btnSave_Click( object sender , EventArgs e )
        {
            if ( btnAddNew.Enabled == true && ( dgvTemplate.Rows.Count == 0 || dgvTemplate.CurrentCell == null ) )
            {
                MessageBox.Show( "没有选择模板，如果要新建模板，请点击新增后录入模板信息。","",MessageBoxButtons.OK,MessageBoxIcon.Error );
                return;
            }
            try
            {
                cboType.SelectedIndexChanged -= new EventHandler( cboType_SelectedIndexChanged );
                ServiceItemController itemController = new ServiceItemController( );
                TemplateItem temp = new TemplateItem( );
                temp.Py_Code = txtPyCode.Text;
                temp.Wb_Code = txtWbCode.Text;
                temp.Tmplate_Name = txtTemplateName.Text.Trim( );
                if ( txtExecDept.MemberValue != null )
                {
                    temp.Exec_Dept_Id = Convert.ToInt32( txtExecDept.MemberValue );
                    temp.Exce_Dept_Name = txtExecDept.Text;
                }
                else
                {
                    temp.Exec_Dept_Id = 0;
                    temp.Exce_Dept_Name = "";
                }
                temp.Valid_Flag = chkValid.Checked ? 1 : 0;
                //明细
                temp.Details = new List<TemplateDetailItem>( );
                for ( int i = 0 ; i < dgvDetail.Rows.Count ; i++ )
                {
                    if ( dgvDetail["ITEM_ID" , i].Value != null && dgvDetail["ITEM_ID" , i].Value.ToString( ) != ""
                        && dgvDetail["ITEM_NAME" , i].Value.ToString( ).Trim( ) != "" )
                    {
                        TemplateDetailItem detail = new TemplateDetailItem( );
                        detail.BIGITEMCODE = dgvDetail["BIGITEMCODE" , i].Value.ToString( ).Trim( );
                        detail.COMPLEX_ID = Convert.ToInt32( dgvDetail["COMPLEX_ID" , i].Value );
                        detail.DAYS = Convert.ToInt32( dgvDetail["DAYS" , i].Value );
                        detail.DOSAGE = Convert.ToDecimal( dgvDetail["DOSAGE" , i].Value );
                        detail.FREQUEN_ID = Convert.ToInt32( dgvDetail["FREQUEN_ID" , i].Value );
                        detail.FREQUEN_NAME = dgvDetail["FREQUEN_NAME" , i].Value.ToString( ).Trim( );
                        detail.GROUP_FLAG = Convert.ToInt32( dgvDetail["GROUP_FLAG" , i].Value );
                        detail.ITEM_ID = Convert.ToInt32( dgvDetail["ITEM_ID" , i].Value );
                        detail.ITEM_NAME = dgvDetail["ITEM_NAME" , i].Value.ToString( ).Trim( );
                        detail.SORT_NO = i;
                        detail.STANDARD = dgvDetail["STANDARD" , i].Value.ToString( ).Trim( );
                        detail.TEMPLATE_ID = Convert.ToInt32( dgvDetail["TEMPLATE_ID" , i].Value );
                        detail.UNIT = dgvDetail["UNIT" , i].Value.ToString( ).Trim( );
                        detail.USAGE_NAME = dgvDetail["USAGE_NAME" , i].Value.ToString( ).Trim( );
                        detail.AMOUNT = Convert.ToInt32( dgvDetail["AMOUNT" , i].Value );
                        temp.Details.Add( detail );
                    }
                }

                if ( btnAddNew.Enabled == false )
                {
                    //新增
                    temp.Create_Date = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                    temp.Creator_Id = Convert.ToInt32( _currentUser.EmployeeID );
                    temp.Creator_Name = _currentUser.Name;
                    temp.Dept_Id = Convert.ToInt32( _currentDept.DeptID );
                    temp.Dept_Name = _currentDept.Name;
                    temp.Share_Level = 0; //全院共享
                    temp.Tmplate_Type = cboType.SelectedIndex;

                    itemController.AddTemplateItem( temp );
                    LoadData( false , true , true );
                }
                else
                {
                    //更新
                    temp.Tmplate_Id = Convert.ToInt32( dgvTemplate["TMPLATE_ID" , dgvTemplate.CurrentCell.RowIndex].Value );
                    itemController.UpdateTemplateItem( temp );

                    LoadData( false , true , true );

                    dgvTemplate.CurrentCell = null;
                }

                btnAddNew.Enabled = true;

            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
            finally
            {
                cboType.SelectedIndexChanged += new EventHandler( cboType_SelectedIndexChanged );
            }
        }

        private void btnAddDetail_Click( object sender , EventArgs e )
        {
            if ( cboType.SelectedIndex == 0 )
            {
                if ( txtExecDept.MemberValue == null || txtExecDept.MemberValue.ToString().Trim() == "" || txtExecDept.Text == "" )
                {
                    MessageBox.Show( "药品类模板在增加明细前必须指定执行科室！" );
                    return;
                }
                dgvDetail.SelectionCards[0].SpeciFilterString = "ISDRUG=1 and exec_dept_code=" + txtExecDept.MemberValue.ToString( );
            }
            dgvDetail.Rows.Add( );
            dgvDetail.CurrentCell = dgvDetail["CODE" , dgvDetail.Rows.Count - 1];
            dgvDetail.Focus( );
        }

        private void FrmTemplate_Load( object sender , EventArgs e )
        {
            

            txtExecDept.SetSelectionCardDataSource( BaseDataReader.Base_Dept_Property );
            LoadData( true , true , true );
            cboType.SelectedIndexChanged += new EventHandler( cboType_SelectedIndexChanged );

            
        }

        private void btnRefresh_Click( object sender , EventArgs e )
        {
            LoadData( true , true , true );
        }

        private void dgvDetail_SelectCardRowSelected( object SelectedValue , ref bool stop , ref int customNextColumnIndex )
        {
            if ( SelectedValue != null )
            {
                int row = dgvDetail.CurrentCell.RowIndex;

                DataRow dr = (DataRow)SelectedValue;

                for ( int i = 0 ; i < dgvDetail.Rows.Count ; i++ )
                {
                    int item_id = Convert.ToInt32( dr["ITEM_ID"] );
                    int complex_id = Convert.ToInt32( dr["COMPLEX_ID"] );
                    string bigitemcode = dr["STATITEM_CODE"].ToString( ).Trim( );
                    if ( dgvDetail["ITEM_ID" , i].Value != null )
                    {
                        if ( Convert.ToInt32( dgvDetail["ITEM_ID" , i].Value ) == item_id &&
                            Convert.ToInt32( dgvDetail["COMPLEX_ID" , i].Value ) == complex_id &&
                            dgvDetail["BIGITEMCODE" , i].Value.ToString( ).Trim( ) == bigitemcode )
                        {
                            MessageBox.Show( "该项目已经选择！","",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                            stop = true;
                            return;
                        }
                    }
                }

                dgvDetail["TEMPLATE_ID" , row].Value = 0;
                dgvDetail["ITEM_ID" , row].Value = Convert.ToInt32( dr["ITEM_ID"] );
                dgvDetail["COMPLEX_ID" , row].Value = Convert.ToInt32( dr["COMPLEX_ID"] );
                //dgvDetail["ITEM_NAME" , row].Value = dr["CHEM_NAME"].ToString( ).Trim( );
                //add zenghao
                dgvDetail["ITEM_NAME", row].Value = dr["ITEM_NAME"].ToString().Trim();
                dgvDetail["STANDARD" , row].Value = dr["STANDARD"].ToString( ).Trim( );
                dgvDetail["UNIT" , row].Value = dr["BASE_UNIT"].ToString( ).Trim( );
                dgvDetail["BIGITEMCODE" , row].Value = dr["STATITEM_CODE"].ToString( ).Trim( );
                dgvDetail["DOSAGE" , row].Value = 0;
                dgvDetail["FREQUEN_ID" , row].Value = 0;
                dgvDetail["FREQUEN_NAME" , row].Value = "";
                dgvDetail["DAYS" , row].Value = 1;
                dgvDetail["USAGE_NAME" , row].Value = "";
                dgvDetail["GROUP_FLAG" , row].Value = 0;
                dgvDetail["SORT_NO" , row].Value = dgvDetail.CurrentCell.RowIndex;
            }
        }

        private void cboType_SelectedIndexChanged( object sender , EventArgs e )
        {
            if ( bClose )
                return;
            if ( btnAddNew.Enabled == false )
            {
                if ( MessageBox.Show( "您正准备为新增的模板指定类型，一旦指定后将不可更改，确定？" , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.No )
                {
                    return;
                }
                cboType.Enabled = false;
            }

            if ( cboType.SelectedIndex == 0 )
            {
                //药品
                if ( btnAddNew.Enabled == true )
                {
                    txtExecDept.Enabled = false;
                }
                dgvDetail.SelectionCards[0].SpeciFilterString = "ISDRUG=1";
            }
            else
            {
                //项目
                dgvDetail.SelectionCards[0].SpeciFilterString = "ISDRUG=0";
                txtExecDept.Enabled = true;
            }
            txtExecDept.Focus( );
        }

        private void txtExecDept_AfterSelectedRow( object sender , object SelectedValue )
        {
            if ( cboType.SelectedIndex == 0 )
            {
                if ( dgvDetail.Rows.Count > 0 )
                {
                    MessageBox.Show( "药品模板在更改执行科室后需要重新指定模板内容！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                    
                    dgvDetail.Rows.Clear( );
                }
                dgvDetail.SelectionCards[0].SpeciFilterString = "ISDRUG=1 and exec_dept_code=" + txtExecDept.MemberValue.ToString( );
            }
        }

        private void btnRemoveDetail_Click( object sender , EventArgs e )
        {
            if ( dgvDetail.Rows.Count == 0 )
                return;
            if ( dgvDetail.CurrentCell == null )
                return;
            dgvDetail.Rows.RemoveAt( dgvDetail.CurrentCell.RowIndex );
        }

        private void txtTemplateName_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
            {
                string[] pywb = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.GetPyWbCode( txtTemplateName.Text );
                txtPyCode.Text = pywb[0];
                txtWbCode.Text = pywb[1];
                btnAddDetail.Focus( );
            }
        }

        private void dgvDetail_CellEndEdit( object sender , DataGridViewCellEventArgs e )
        {
            if ( dgvDetail.Rows.Count == 0 )
                return;
            if ( dgvDetail.CurrentCell == null )
                return;

            if ( e.ColumnIndex == dgvDetail.Columns["AMOUNT"].Index )
            {
                if ( dgvDetail["AMOUNT" , e.RowIndex].Value == null ||
                    dgvDetail["AMOUNT" , e.RowIndex].Value.ToString( ) == "" )
                {
                    dgvDetail["AMOUNT" , e.RowIndex].Value = 0;
                }
            }
        }

        private void txtPyCode_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
            {
                txtWbCode.Focus( );
            }
        }

        private void txtWbCode_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
            {
                btnAddDetail.Focus( );
            }
        }

        private void btnDelete_Click( object sender , EventArgs e )
        {
            int Tmplate_Id = Convert.ToInt32( dgvTemplate["TMPLATE_ID" , dgvTemplate.CurrentCell.RowIndex].Value );
            if ( MessageBox.Show( "是否要删除选择的模板？" , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.No )
                return;

            try
            {
                ServiceItemController itemController = new ServiceItemController( );
                itemController.DeleteTemplateItem( Tmplate_Id );
                dgvTemplate.Rows.RemoveAt( dgvTemplate.CurrentCell.RowIndex );
                dgvDetail.Rows.Clear( );
                
            }
            catch(Exception err)
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error ); 
            }
        }
    }
}
