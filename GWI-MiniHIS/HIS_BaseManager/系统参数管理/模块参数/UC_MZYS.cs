using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.Base_BLL;

namespace HIS_BaseManager
{
    public partial class UC_MZYS : UserControl, IParameter
    {
        public UC_MZYS()
        {
            InitializeComponent();
        }

        private Parameters parameters;


        #region IParameter 成员

        public HIS.Base_BLL.Enums.ParameterCatalog Catalog
        {
            get
            {
                return HIS.Base_BLL.Enums.ParameterCatalog.门诊医生站;
            }
        }

        public HIS.Base_BLL.Parameters Parameters
        {
            get
            {
                return parameters;
            }
            set
            {
                parameters = value;
            }
        }

        #endregion

        private void UC_MZYS_Load( object sender, EventArgs e )
        {
            LoadDatasource();

            ShowParameters();

            txt001.Validating += new CancelEventHandler( txt001_Validating );
            chk003.CheckedChanged += new EventHandler( CheckBox_CheckChanged );
            chk008.CheckedChanged += new EventHandler( CheckBox_CheckChanged );
            chk006_1.CheckedChanged += new EventHandler( CheckBox_CheckChanged );
            lvw010.ItemChecked += new ItemCheckedEventHandler( ListViewItemCheckChanged );
            dgv005.CellValueChanged += new DataGridViewCellEventHandler( dgv005_CellValueChanged );
            dgv007.CellValueChanged += new DataGridViewCellEventHandler( dgv007_CellValueChanged );
            txt009.Validating += new CancelEventHandler( txt009_Validating );
        }

        void txt009_Validating( object sender, CancelEventArgs e )
        {
            parameters["009"].Value = txt009.Text;
        }

        void txt001_Validating( object sender, CancelEventArgs e )
        {
            parameters["001"].Value = txt001.Text;
        }

        void dgv007_CellValueChanged( object sender, DataGridViewCellEventArgs e )
        {
            SetParameter_007_Value();
        }

        private void SetParameter_007_Value()
        {
            string strValue = "";
            for ( int i = 0; i < dgv007.Rows.Count; i++ )
            {
                if ( dgv007[ORDER_ID.Name, i].Value != null && dgv007[ORDER_ID.Name, i].Value.ToString().Trim() != "" )
                    strValue = strValue + dgv007[ORDER_ID.Name, i].Value.ToString().Trim() + ",";
            }
            if ( strValue.Trim() != "" )
                strValue = strValue.Remove( strValue.Length - 1, 1 );
            parameters["007"].Value = strValue;
        }

        void dgv005_CellValueChanged( object sender, DataGridViewCellEventArgs e )
        {
            SetParameter_005_Value();
        }

        private void SetParameter_005_Value()
        {
            string strValue = "";
            for ( int i = 0; i < dgv005.Rows.Count; i++ )
            {
                if ( ( dgv005[DEPT_ID.Name, i].Value != null && dgv005[DEPT_ID.Name, i].Value.ToString() != "" ) &&
                    ( dgv005[DEPTDICID.Name, i].Value != null && dgv005[DEPTDICID.Name, i].Value.ToString() != "" ) )
                    strValue = strValue + dgv005[DEPT_ID.Name, i].Value.ToString().Trim() + "-" + dgv005[DEPTDICID.Name, i].Value.ToString().Trim() + ",";
            }
            if ( strValue.Trim() != "" )
                strValue = strValue.Remove( strValue.Length - 1, 1 );
            parameters["005"].Value = strValue;
        }


        private void LoadDatasource()
        {
            DataRow[] drs = BaseDataReader.GetOrderList().Select( "DELETE_BIT=0" );
            DataTable dtOrder = BaseDataReader.GetOrderList().Clone();
            for ( int i = 0; i < drs.Length; i++ )
                dtOrder.Rows.Add( drs[i].ItemArray );
       
            txt002.SetSelectionCardDataSource( BaseDataReader.GetUsageDictionList().Select( "DELETE_BIT=0" ).CopyToDataTable() );

            DataRow[] drDeptOfMZ = BaseDataReader.Base_Dept_Property.Select( "MZ_FLAG=1 AND TYPE_CODE='001'" );
            for ( int i = 0; i < drDeptOfMZ.Length; i++ )
            {
                DataRow dr = baseDataSet.Tables["dtDeptOfMZ"].NewRow();
                dr["DEPT_ID"] = drDeptOfMZ[i]["DEPT_ID"];
                dr["NAME"] = drDeptOfMZ[i]["NAME"];
                baseDataSet.Tables["dtDeptOfMZ"].Rows.Add( dr );
            }

            DataRow[] drDeptOfYP = BaseDataReader.GetDrugRoomList().Select( "DEPTTYPE1='药房'" );
            for ( int i = 0; i < drDeptOfYP.Length; i++ )
            {
                DataRow dr = baseDataSet1.Tables["dtDeptOfYP"].NewRow();
                dr["DEPTDICID"] = drDeptOfYP[i]["DEPTID"];
                dr["DEPTNAME"] = drDeptOfYP[i]["DEPTNAME"];
                baseDataSet1.Tables["dtDeptOfYP"].Rows.Add( dr );
            }

            dgv007.SetSelectionCardDataSource( dtOrder, 1 );

            DataTable dtOrderType = BaseDataReader.GetOrderType();
            for ( int i = 0; i < dtOrderType.Rows.Count; i++ )
            {
                ListViewItem item = new ListViewItem();
                item.Text = dtOrderType.Rows[i]["NAME"].ToString();
                item.Tag = Convert.ToInt32( dtOrderType.Rows[i]["ID"] );
                lvw010.Items.Add( item );
            }
        }

        private void ShowParameters()
        {
            txt001.Text = parameters["001"].Value.ToString();
            txt002.MemberValue = Convert.ToInt32( parameters["002"].Value );
            txt004.Text = parameters["004"].Value.ToString().Trim();
            txt009.Text = parameters["009"].Value.ToString().Trim();

            chk003.Checked = Convert.ToInt32( parameters["003"].Value ) == 1 ? true : false;
            chk008.Checked = Convert.ToInt32( parameters["008"].Value ) == 1 ? true : false;

            string strCfg = parameters["005"].Value.ToString().Trim();
            if ( strCfg.Trim() != "" )
            {
                string[] relation = strCfg.Split( ",".ToCharArray() );
                for ( int i = 0; i < relation.Length; i++ )
                {
                    string[] values = relation[i].Split( "-".ToCharArray() );
                    int row = dgv005.Rows.Add();
                    dgv005[DEPT_ID.Name, row].Value = values[0];
                    dgv005[DEPTDICID.Name, row].Value = values[1];
                }
            }

            if ( parameters["006"].Value.ToString().Trim() == "1" )
            {
                chk006_1.Checked = true;
                chk006_0.Checked = false;
            }
            else
            {
                chk006_1.Checked = false;
                chk006_0.Checked = true;
            }

            strCfg = parameters["007"].Value.ToString().Trim();
            if ( strCfg.Trim() != "" )
            {
                string[] itemIds = strCfg.Split( ",".ToCharArray() );
                for ( int i = 0; i < itemIds.Length; i++ )
                {
                    DataRow[] drs = BaseDataReader.GetOrderList().Select( "ORDER_ID = " + itemIds[i] );
                    if ( drs.Length > 0 )
                    {
                        int row = dgv007.Rows.Add();
                        dgv007[ORDER_ID.Name, row].Value = Convert.ToInt32( drs[0]["ORDER_ID"] );
                        dgv007[ORDER_NAME.Name, row].Value = drs[0]["ORDER_NAME"].ToString().Trim();
                    }
                }
            }

            strCfg = parameters["010"].Value.ToString().Trim();
            if ( strCfg.Trim() != "" )
            {
                string[] ids = strCfg.Split( ",".ToCharArray() );
                for ( int i = 0; i < ids.Length; i++ )
                {
                    foreach ( ListViewItem item in lvw010.Items )
                    {
                        if ( Convert.ToInt32( item.Tag ) == Convert.ToInt32( ids[i] ) )
                        {
                            item.Checked = true;
                            break;
                        }
                    }
                }
            }
        }

        private void btnAddMapping_Click( object sender, EventArgs e )
        {
            dgv005.Rows.Add();
        }

        private void btnRemoveMapping_Click( object sender, EventArgs e )
        {
            if ( dgv005.Rows.Count != 0 )
                dgv005.Rows.RemoveAt( dgv005.CurrentRow.Index );

            SetParameter_005_Value();
        }

        private void btnAddOrder_Click( object sender, EventArgs e )
        {
            dgv007.Rows.Add();
        }

        private void dgv007_SelectCardRowSelected( object SelectedValue, ref bool stop, ref int customNextColumnIndex )
        {
            DataRow dr = (DataRow)SelectedValue;
            dgv007[ORDER_ID.Name,dgv007.CurrentRow.Index].Value = dr["ORDER_ID"];
            dgv007["ORDER_NAME", dgv007.CurrentRow.Index].Value = dr["ORDER_NAME"];
        }

        private void dgv005_DataError( object sender, DataGridViewDataErrorEventArgs e )
        {
            e.Cancel = true;
        }

        
        private void txt002_AfterSelectedRow( object sender, object SelectedValue )
        {
            parameters["002"].Value = ( (DataRow)SelectedValue )["ID"].ToString();
        }

        private void CheckBox_CheckChanged( object sender, EventArgs e )
        {
            string ctrlName = ( (Control)sender ).Name;
            if ( ctrlName == chk003.Name )
                parameters["003"].Value = chk003.Checked ? "1" : "0";
            else if ( ctrlName == chk008.Name )
                parameters["008"].Value = chk008.Checked ? "1" : "0";
            else if ( ctrlName == chk006_1.Name )
                parameters["006"].Value = chk006_1.Checked ? "1" : "0";
        }

        private void ListViewItemCheckChanged( object sender, ItemCheckedEventArgs e )
        {
            string strIds = "";
            foreach ( ListViewItem item in lvw010.Items )
            {
                if ( item.Checked )
                    strIds = strIds + item.Tag.ToString() + ",";
            }
            if ( strIds != "" )
                strIds = strIds.Remove( strIds.Length - 1, 1 );
            parameters["010"].Value = strIds;
        }

        private void btnRemoveOrder_Click( object sender, EventArgs e )
        {
            if ( dgv007.Rows.Count != 0 )
                dgv007.Rows.RemoveAt( dgv007.CurrentRow.Index );

            SetParameter_007_Value();
        }

        private void txt004_Validating( object sender, CancelEventArgs e )
        {
            string message;
            if ( !ValidTimeFormate( txt004.Text, out message ) )
            {
                MessageBox.Show( message, "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                e.Cancel = true;
                txt004.Select( 0, txt004.TextLength );
                return;
            }
            parameters["004"].Value = txt004.Text.Trim();
        }

        private bool ValidTimeFormate( string time, out string message )
        {
            message = "";
            string[] temp = time.Split( ",".ToCharArray() );
            for ( int i = 0; i < temp.Length; i++ )
            {
                if ( temp[i].Trim() == "" )
                {
                    message = "有空的时间段,例如 , ,";
                    return false;
                }
                string[] temp1 = temp[i].Split( "-".ToCharArray() );
                try
                {
                    Convert.ToDateTime( "2000-01-01" + " " + temp1[0] );
                    Convert.ToDateTime( "2000-01-01" + " " + temp1[1] );
                }
                catch
                {
                    message = temp[i]+ "格式错误!";
                    return false;
                }
            }
            return true;
        }
    }
}
