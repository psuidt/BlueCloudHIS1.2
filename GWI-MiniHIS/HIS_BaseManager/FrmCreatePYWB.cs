using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.Base_BLL;
using GWI.HIS.Windows.Controls;


namespace HIS_BaseManager
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FrmCreatePYWB : BaseForm
    {
        /// <summary>
        /// 
        /// </summary>
        public FrmCreatePYWB(GWMHIS.BussinessLogicLayer.Classes.User CurrentUser)
        {
            InitializeComponent( );

            //'currentUser = CurrentUser;

            if ( CurrentUser.IsAdministrator )
            {
                btnCreat.Enabled = true;
                lblInfo.Visible = false;
            }
            else
            {
                btnCreat.Enabled = false;
                lblInfo.Visible = true;
            }
        }


        private DataTable tbColumns;

        private bool isProcess;

        private void FrmCreatePYWB_Load( object sender , EventArgs e )
        {
            tbColumns = BaseDataController.GetTableColumn( );
            DataTable tbTables = new DataTable( );
            tbTables.Columns.Add( "TBNAME" );
            for ( int i = 0 ; i < tbColumns.Rows.Count ; i++ )
            {
                string tbName = tbColumns.Rows[i]["TBNAME"].ToString( ).Trim( );
                if ( tbTables.Select( "TBNAME='" + tbName + "'" ).Length == 0 )
                {
                    tbTables.Rows.Add( tbName );
                }
            }
            cboTable.DisplayMember = "TBNAME";
            cboTable.ValueMember = "TBNAME";
            cboTable.DataSource = tbTables;
            cboTable.SelectedIndex = -1;
            cboTable.SelectedIndexChanged += new EventHandler( cboTable_SelectedIndexChanged );
            
        }

        void cboTable_SelectedIndexChanged( object sender , EventArgs e )
        {
            DataRow[] drs = tbColumns.Select( "TBNAME='" + cboTable.Text + "'" );
            cboName.Items.Clear( );
            cboPK.Items.Clear( );
            cboPY.Items.Clear( );
            cboWb.Items.Clear( );
            for ( int i = 0 ; i < drs.Length ; i++ )
            {
                string fieldName = drs[i]["NAME"].ToString( ).Trim( );
                cboName.Items.Add( fieldName );
                cboPK.Items.Add(fieldName);
                if ( fieldName.Substring(0,2).Trim().ToUpper() == "PY" )
                    cboPY.Items.Add( fieldName );
                if ( fieldName.Substring( 0 , 2 ).Trim( ).ToUpper( ) == "WB" )
                cboWb.Items.Add( fieldName );
            }
            
        }

        private void SetControlEnable( bool enable )
        {
            cboName.Enabled = enable;
            cboTable.Enabled = enable;
            cboPK.Enabled = enable;
            cboPY.Enabled = enable;
            cboWb.Enabled = enable;
            chkPY.Enabled = enable;
            chkWB.Enabled = enable;
            chkIsNumeric.Enabled = enable;
            chkEmpty.Enabled = enable;
            btnCreat.Enabled = enable;
            btnExit.Enabled = enable;
        }

        private void btnCreat_Click( object sender , EventArgs e )
        {
            if ( !chkPY.Checked && !chkWB.Checked )
            {
                MessageBox.Show( "必须指定一个生成内容！","",MessageBoxButtons.OK,MessageBoxIcon.Error );
                return;
            }
            if ( cboTable.Text =="" || cboName.Text=="" || cboPK.Text == "" || cboPY.Text.Trim( ) == "" || cboWb.Text.Trim( ) == "" )
            {
                MessageBox.Show( "字段信息选择不完整！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                return;
            }
            try
            {
                SetControlEnable( false );
                isProcess = true;
                DataTable tbData = BaseDataReader.GetBaseTableData( cboTable.Text ,"");
                string nameField = cboName.Text;
                string pyField = cboPY.Text;
                string wbField = cboWb.Text;

                pgbCount.Maximum = tbData.Rows.Count;
                pgbCount.Value = 1;

                ColumnInfo nameColumn = new ColumnInfo();
                nameColumn.ColumnName = nameField;

                ColumnInfo keyColumn = new ColumnInfo();
                keyColumn.ColumnName = cboPK.Text;
                keyColumn.IsNumeric = chkIsNumeric.Checked;

                ColumnInfo pyColumn = null;
                if ( chkPY.Checked )
                {
                    pyColumn = new ColumnInfo( );
                    pyColumn.ColumnName = cboPY.Text;
                }
                ColumnInfo wbColumn = null;
                if ( chkWB.Checked )
                {
                    wbColumn = new ColumnInfo( );
                    wbColumn.ColumnName = cboWb.Text;
                }

                for ( int i = 0 ; i < tbData.Rows.Count ; i++ )
                {
                    Application.DoEvents( );
                    lblCount.Text = tbData.Rows.Count.ToString( ) + "/" + i.ToString( );
                    nameColumn.DataValue = tbData.Rows[i][nameField].ToString( ).Trim( );
                    keyColumn.DataValue = tbData.Rows[i][keyColumn.ColumnName].ToString( ).Trim( );
                    string currentPy = Convert.IsDBNull( tbData.Rows[i][cboPY.Text] ) ? "" : tbData.Rows[i][cboPY.Text].ToString( ).Trim( );
                    string currentWb = Convert.IsDBNull( tbData.Rows[i][cboWb.Text] ) ? "" : tbData.Rows[i][cboWb.Text].ToString( ).Trim( );
                    if ( currentPy != "" && currentWb != "" )
                    {
                        pgbCount.Value=i+1;
                        continue;
                    }
                    string[] pywb = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.GetPyWbCode( nameColumn.DataValue.ToString() );
                    if ( pyColumn != null )
                    {
                        if ( chkEmpty.Checked && currentPy != "" )
                        {
                            pyColumn.DataValue = null;
                        }
                        else
                        {
                            pyColumn.DataValue = pywb[0];
                        }
                    }
                    if ( wbColumn != null )
                    {
                        if ( chkEmpty.Checked && currentWb != "" )
                        {
                            wbColumn.DataValue = null;
                        }
                        else
                        {
                            wbColumn.DataValue = pywb[1];
                        }
                        
                    }

                    BaseDataController.UpdatePYWBField( cboTable.Text , nameColumn , keyColumn , pyColumn , wbColumn );
                    pgbCount.Value++;
                    
                }
                pgbCount.Value = pgbCount.Maximum;
                MessageBox.Show( "生成完成！" );
            }
            catch(Exception err)
            {
                MessageBox.Show( err.Message ,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                isProcess = false;
                SetControlEnable( true );
            }
        }

        private void FrmCreatePYWB_FormClosing( object sender , FormClosingEventArgs e )
        {
            if ( isProcess )
                e.Cancel = true;
        }

        private void btnExit_Click( object sender , EventArgs e )
        {
            this.Close( );
        }

        
    }
}
