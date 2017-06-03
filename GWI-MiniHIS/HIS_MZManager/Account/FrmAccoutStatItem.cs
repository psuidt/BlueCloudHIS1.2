using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;
using HIS.MZ_BLL;

namespace HIS_MZManager.Account
{
    public partial class FrmAccoutStatItem : BaseForm
    {
        private DateTime accountDate;
        private string toller;
        public FrmAccoutStatItem(int AccountId,int TollerId ,DateTime AccountDate,string Toller)
        {
            InitializeComponent( );

            accountDate = AccountDate;
            toller = Toller;
            DataTable tbStatItem = AccountBookController.GetAccountStatItemList( AccountId , TollerId );

            FormatData( tbStatItem );
        }

        private void FrmAccoutStatItem_Load( object sender , EventArgs e )
        {

        }

        private void FormatData(DataTable tbData)
        {
            DataTable tbResult = new DataTable( );
            tbResult.Columns.Add( "统计项目",Type.GetType("System.String") );
            tbResult.Columns.Add( "合计" , Type.GetType( "System.Decimal" ) );
            for ( int i = 0 ; i < tbData.Rows.Count ; i++ )
            {
                //string deptId = PublicDataReader.GetDeptNameById( Convert.ToInt32( tbData.Rows[i]["ID"] )) ;
                string deptId = BaseDataController.GetName( BaseDataCatalog.科室列表, Convert.ToInt32( tbData.Rows[i]["ID"] ) );
                if ( !tbResult.Columns.Contains( deptId ) )
                {
                    DataColumn col = new DataColumn( deptId , Type.GetType( "System.Decimal" ) );
                    //col.Caption = PublicDataReader.GetDeptNameById( Convert.ToInt32( tbData.Rows[i]["ID"] ) );
                    col.Caption = BaseDataController.GetName(BaseDataCatalog.科室列表, Convert.ToInt32( tbData.Rows[i]["ID"] ) );
                    tbResult.Columns.Add( col );
                }
            }

            for ( int i = 0 ; i < tbData.Rows.Count ; i++ )
            {
                //string deptId = PublicDataReader.GetDeptNameById( Convert.ToInt32( tbData.Rows[i]["ID"] ) );
                string deptId = BaseDataController.GetName( BaseDataCatalog.科室列表, Convert.ToInt32( tbData.Rows[i]["ID"] ) );
                string code = tbData.Rows[i]["CODE"].ToString( ).Trim( );
                decimal total_fee = Convert.ToDecimal( tbData.Rows[i]["Total_Fee"] );

                if ( tbResult.Select( "统计项目='" + code + "'" ).Length == 0 )
                {
                    DataRow drNew = tbResult.NewRow( );
                    drNew["统计项目"] = code;
                    drNew[deptId] = total_fee;
                    drNew["合计"] = total_fee;
                    tbResult.Rows.Add( drNew );
                }
                else
                {
                    DataRow[] drs = tbResult.Select( "统计项目='" + code + "'" );
                    decimal fee = Convert.IsDBNull( drs[0][deptId] ) ? 0 : Convert.ToDecimal( drs[0]["total_fee"] );
                    drs[0][deptId] = total_fee + fee;
                    drs[0]["合计"] = Convert.ToDecimal(drs[0]["合计"]) + Convert.ToDecimal(drs[0][deptId]);
                }
            }

            for ( int i = 0 ; i < tbResult.Rows.Count ; i++ )
            {
                //DataRow[] drs = PublicDataReader.StatItemList.Select( "STAT_CODE='" + tbResult.Rows[i]["统计项目"].ToString( ).Trim( ) + "'" );
                DataRow[] drs = BaseDataController.BaseDataSet[BaseDataCatalog.基本分类与各分类对应表].Select( "STAT_CODE='" + tbResult.Rows[i]["统计项目"].ToString().Trim() + "'" );
                string item_name = drs[0]["STAT_NAME"].ToString().Trim();
                tbResult.Rows[i]["统计项目"] = item_name;
            }

            DataRow drTotal = tbResult.NewRow( );
            drTotal["统计项目"] = "合计";

            for ( int i = 0 ; i < tbResult.Columns.Count ; i++ )
            {
                if ( tbResult.Columns[i].ColumnName == "统计项目" )
                    continue;

                string fieldname = tbResult.Columns[i].ColumnName;
                object obj = tbResult.Compute( "SUM(" + fieldname + ")" ,"");
                if ( obj != null && !Convert.IsDBNull( obj ) )
                {
                    drTotal[fieldname] = obj;
                }
            }
            tbResult.Rows.Add( drTotal );

            dgvStatItem.DataSource = tbResult;

            for ( int i = 1 ; i < dgvStatItem.Columns.Count ; i++ )
            {
                dgvStatItem.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            dgvStatItem.Columns[1].Frozen = true;

            for ( int i = 0 ; i < tbData.Rows.Count ; i++ )
            {
                //DataRow[] drs = PublicDataReader.StatItemList.Select( "STAT_CODE='" + tbData.Rows[i]["CODE"].ToString( ).Trim( ) + "'" );
                DataRow[] drs = BaseDataController.BaseDataSet[BaseDataCatalog.基本分类与各分类对应表].Select( "STAT_CODE='" + tbData.Rows[i]["CODE"].ToString().Trim() + "'" );
                string item_name = drs[0]["STAT_NAME"].ToString( ).Trim( );
                //string dept_name = PublicDataReader.GetDeptNameById( Convert.ToInt32( tbData.Rows[i]["ID"] ) );
                string dept_name = BaseDataController.GetName(BaseDataCatalog.科室列表 , Convert.ToInt32( tbData.Rows[i]["ID"] ) );
                tbData.Rows[i]["ID"] = dept_name;
                tbData.Rows[i]["CODE"] = item_name;
            }
            dgvStatItem.Tag = tbData;
        }

        private void btnExit_Click( object sender , EventArgs e )
        {
            this.Close( );
        }

        private void button1_Click( object sender , EventArgs e )
        {
            PrintController.PrintAccountBookAddenda( (DataTable)dgvStatItem.Tag , accountDate , toller );
        }
    }
}
