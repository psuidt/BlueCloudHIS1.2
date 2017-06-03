using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using grproLib;

namespace HIS_MZManager.Report
{
    public partial class FrmReportSetting : GWI.HIS.Windows.Controls.BaseForm
    {
        private HIS.MZ_BLL.StatType statType;
        private string reportName;
        private DataSet dsData;
        private string[] fixTitles;//固定列
        private GWMHIS.BussinessLogicLayer.Classes.User currentUser;
        public FrmReportSetting( string ReportName, string[] FixTitles, HIS.MZ_BLL.StatType StatType, GWMHIS.BussinessLogicLayer.Classes.User CurrentUser )
        {
            InitializeComponent( );
            statType = StatType;
            lblReportName.Text = ReportName;
            reportName = ReportName;
            fixTitles = FixTitles;
            currentUser = CurrentUser;
        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.Close( );
        }

        private void FrmReportSetting_Load( object sender , EventArgs e )
        {
            DataTable tbTitle = HIS.MZ_BLL.ReportClass.GetReportTitle( reportName );
            tbTitle.TableName = "TITLES";
            DataTable tbField = HIS.MZ_BLL.ReportClass.GetReportFields( statType );
            tbField.TableName = "FIELDS";
            DataTable tbRelation = HIS.MZ_BLL.ReportClass.GetReportTitleFieldRelation( reportName );
            tbRelation.TableName = "RELATIONS";

            dsData = new DataSet( );
            dsData.Tables.AddRange( new DataTable[] {tbTitle,tbField,tbRelation } );

            InitTreeAndList( );

            if ( tbTitle.Rows.Count == 0 )
                btnDesign.Enabled = false;
            else
                btnDesign.Enabled = true;
            
        }

        private void InitTreeAndList()
        {
            
            if ( dsData.Tables["RELATIONS"].Rows.Count == 0 )
            {
                for ( int i = 0 ; i < fixTitles.Length ; i++ )
                {
                    TreeNode node = new TreeNode( fixTitles[i] );
                    node.Nodes.Add( fixTitles[i] );
                    node.Tag = 1;
                    tvwCol.Nodes.Add( node );
                }

                foreach ( DataRow dr in dsData.Tables["FIELDS"].Rows )
                {
                    string name = dr["item_name"].ToString( );
                    TreeNode ndTitle = new TreeNode( name );
                    TreeNode ndField = new TreeNode( name );
                    ndTitle.Nodes.Add( ndField );
                    tvwCol.Nodes.Add( ndTitle );
                }
                
            }
            else
            {
                foreach ( DataRow dr in dsData.Tables["TITLES"].Rows )
                {
                    string title_name = dr["title_name"].ToString( );
                    int fix = Convert.ToInt32( dr["fixcol"] );
                    TreeNode ndTitle = new TreeNode( title_name );
                    if ( fix == 1 )
                        ndTitle.Tag = 1;
                    DataRow[] drs = dsData.Tables["RELATIONS"].Select( "TITLE_NAME='" + title_name + "'" );
                    for ( int i = 0 ; i < drs.Length ; i++ )
                    {
                        string field_name = drs[i]["FIELD_NAME"].ToString( ).Trim( );
                        TreeNode ndField = new TreeNode( field_name );
                        ndField.Tag = ndTitle.Tag;
                        ndTitle.Nodes.Add( ndField );
                    }
                    tvwCol.Nodes.Add( ndTitle );
                }
                ShowField( );
            }
        }

        private void ShowField()
        {
            foreach ( DataRow dr in dsData.Tables["FIELDS"].Rows )
            {
                string field_name = dr["ITEM_NAME"].ToString( ).Trim( );

                if ( dsData.Tables["RELATIONS"].Select( "FIELD_NAME='" + field_name + "'" ).Length == 0 )
                {
                    ListViewItem item = new ListViewItem( field_name );
                    lvwField.Items.Add( item );
                }
            }
        }

        

        private void btnRemove_Click( object sender , EventArgs e )
        {
            if ( tvwCol.SelectedNode == null )
                return;

            if ( tvwCol.SelectedNode.Parent == null )
                return;

            if ( tvwCol.SelectedNode.Tag != null )
                return;

            ListViewItem item = new ListViewItem( );
            item.Text = tvwCol.SelectedNode.Text;

            lvwField.Items.Add( item );

            tvwCol.Nodes.Remove( tvwCol.SelectedNode );

            btnDesign.Enabled = false;
        }

        private void btnAdd_Click( object sender , EventArgs e )
        {
            if ( tvwCol.SelectedNode == null )
                return;
            if ( tvwCol.SelectedNode.Parent != null )
                return;

            if ( lvwField.SelectedItems.Count == 0 )
                return;
            if ( tvwCol.SelectedNode.Tag != null )
                return;

            foreach ( ListViewItem item in lvwField.SelectedItems )
            {
                TreeNode ndField = new TreeNode( item.Text );
                tvwCol.SelectedNode.Nodes.Add( ndField );

                lvwField.Items.Remove( item );
            }
            btnDesign.Enabled = false;
        }

        private void btnDelCol_Click( object sender , EventArgs e )
        {
            if ( tvwCol.SelectedNode == null )
                return;
            if ( tvwCol.SelectedNode.Parent != null )
                return;

            if ( tvwCol.SelectedNode.Tag != null && Convert.ToInt32( tvwCol.SelectedNode.Tag ) == 1 )
                return;

            foreach ( TreeNode node in tvwCol.SelectedNode.Nodes )
            {
                ListViewItem item = new ListViewItem( node.Text );
                lvwField.Items.Add( item );
            }
            tvwCol.Nodes.Remove( tvwCol.SelectedNode );

            btnDesign.Enabled = false;
        }

        private void btnAddCol_Click( object sender , EventArgs e )
        {
            tvwCol.LabelEdit = true;
            TreeNode ndNew = new TreeNode( );
            ndNew.Text = "新增打印列";
            tvwCol.Nodes.Add( ndNew );
            ndNew.BeginEdit( );

            btnDesign.Enabled = false;
        }

        private void tvwCol_AfterSelect( object sender , TreeViewEventArgs e )
        {
            if ( e.Node.Parent == null )
                tvwCol.LabelEdit = true;
            else
                tvwCol.LabelEdit = false;
        }

        private void btnSave_Click( object sender , EventArgs e )
        {
            if ( lvwField.Items.Count > 0 )
            {
                MessageBox.Show( "还有字段没有指定到打印列，不能保存！" , "" ,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            dsData.Tables["TITLES"].Rows.Clear( );
            dsData.Tables["RELATIONS"].Rows.Clear( );
            int sort = 1;
            foreach ( TreeNode node in tvwCol.Nodes )
            {
                DataRow drNewTitle = dsData.Tables["TITLES"].NewRow( );
                drNewTitle["REPORT_NAME"] = reportName;
                drNewTitle["TITLE_NAME"] = node.Text;
                drNewTitle["SORTNO"] = sort ;
                drNewTitle["FIXCOL"] = node.Tag !=null ? 1 : 0;
                dsData.Tables["TITLES"].Rows.Add( drNewTitle );
                foreach ( TreeNode nd in node.Nodes )
                {
                    DataRow drRelation = dsData.Tables["RELATIONS"].NewRow( );
                    drRelation["REPORT_NAME"] = reportName;
                    drRelation["TITLE_NAME"] = node.Text;
                    drRelation["FIELD_NAME"] = nd.Text;
                    dsData.Tables["RELATIONS"].Rows.Add( drRelation );
                }
                sort++;
            }
            try
            {
                if ( HIS.MZ_BLL.ReportClass.SaveReportPrintTitle( reportName , dsData.Tables["TITLES"] , dsData.Tables["RELATIONS"] , currentUser.Name ) )
                {
                    if ( MessageBox.Show( "设置已保存！如果修改了设置，需要重新生成报表文件，是否重新生成报表文件？" , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.No )
                    {
                        return;
                    }
                    else
                    {
                        DataTable tbTitle = HIS.MZ_BLL.ReportClass.GetReportTitle( reportName );
                        //FrmReportDesign fDesign = new FrmReportDesign( reportName , tbTitle,true );
                        //fDesign.ShowDialog( );
                        string filePath;
                        bool ret = CreateReportFile( reportName, tbTitle, out filePath );
                        if ( ret )
                        {
                            MessageBox.Show( "报表文件已经创建在：" + filePath + "\r\n   请使用报表编辑器进行编辑！（需要有使用报表编辑器的权限）"
                                , "", MessageBoxButtons.OK, MessageBoxIcon.Information );
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show( "保存不成功！","",MessageBoxButtons.OK,MessageBoxIcon.Error );
                        }
                    }
                   
                }
            }
            catch(Exception err)
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
            }
        }
        /// <summary>
        /// 创建报表文件
        /// </summary>
        /// <param name="ReportName">报表名</param>
        /// <param name="Columns">列信息</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        private bool CreateReportFile( string ReportName, DataTable Columns ,out string filePath )
        {
            filePath = "";
            try
            {
                GridppReport gridReport = new GridppReport();
                DataTable dtColumns = Columns;
                string reportName = ReportName;
                string fileName = System.Windows.Forms.Application.StartupPath + "\\report\\" + reportName + ".grf";
                if ( System.IO.File.Exists( fileName ) )
                    System.IO.File.Delete( fileName );

                if ( !Directory.Exists( System.Windows.Forms.Application.StartupPath + "\\report" ) )
                {
                    Directory.CreateDirectory( System.Windows.Forms.Application.StartupPath + "\\report" );
                }
                if ( !File.Exists( fileName ) )
                {
                    gridReport.SaveToFile( fileName );
                    gridReport.InsertReportHeader();
                    gridReport.InsertDetailGrid();
                    gridReport.InsertReportFooter();
                    foreach ( DataRow dr in dtColumns.Rows )
                    {
                        string title_name = dr["TITLE_NAME"].ToString();
                        gridReport.DetailGrid.AddColumn( title_name, title_name, title_name, 2 );
                        gridReport.DetailGrid.Recordset.AddField( title_name, GRFieldType.grftString );
                    }
                    gridReport.AddParameter( "医院名称", GRParameterDataType.grptString );
                    gridReport.AddParameter( "报表标题", GRParameterDataType.grptString );
                    gridReport.AddParameter( "统计时间", GRParameterDataType.grptString );
                    gridReport.AddParameter( "制表人", GRParameterDataType.grptString );
                    gridReport.AddParameter( "备注", GRParameterDataType.grptString );

                    gridReport.SaveToFile( fileName );

                }
                filePath = fileName;
                return true;
            }
            catch ( Exception err )
            {
                return false;
            }
        }

        //private void btnDesign_Click( object sender , EventArgs e )
        //{
        //    //DataTable tbTitle = HIS.MZ_BLL.ReportClass.GetReportTitle( reportName );

        //    //FrmReportDesign fDesign = new FrmReportDesign( reportName , tbTitle ,false);
        //    //fDesign.WindowState = FormWindowState.Maximized;
        //    //fDesign.ShowDialog( );
        //}

        private void tvwCol_DoubleClick( object sender , EventArgs e )
        {
            btnRemove_Click( null , null );
        }

        private void lvwField_DoubleClick( object sender , EventArgs e )
        {
            btnAdd_Click( null , null );
        }

        private void btnUp_Click( object sender , EventArgs e )
        {
            if ( tvwCol.SelectedNode == null )
                return;
            if ( tvwCol.SelectedNode.Parent != null )
                return;

            TreeNode nd = tvwCol.SelectedNode;

            if ( tvwCol.SelectedNode.PrevNode == null )
                return;

            if ( tvwCol.SelectedNode.PrevNode.Tag != null )
                return;
            
            int index = tvwCol.SelectedNode.PrevNode.Index;

            tvwCol.Nodes.Remove( tvwCol.SelectedNode );

            tvwCol.Nodes.Insert( index , nd );

            tvwCol.SelectedNode = nd;
        }

        private void btnDown_Click( object sender , EventArgs e )
        {
            if ( tvwCol.SelectedNode == null )
                return;
            if ( tvwCol.SelectedNode.Parent != null )
                return;
            if ( tvwCol.SelectedNode.Tag != null )
                return;

            TreeNode nd = tvwCol.SelectedNode;
            if ( tvwCol.SelectedNode.NextNode == null )
                return;

            int index = tvwCol.SelectedNode.NextNode.Index;

            tvwCol.Nodes.Remove( tvwCol.SelectedNode );

            tvwCol.Nodes.Insert( index , nd );

            tvwCol.SelectedNode = nd;
        }

        private void btnEdit_Click( object sender , EventArgs e )
        {
            if ( tvwCol.SelectedNode == null )
                return;
            if ( tvwCol.SelectedNode.Parent != null )
                return;
            if ( tvwCol.SelectedNode.Tag != null && Convert.ToInt32( tvwCol.SelectedNode.Tag ) == 1 )
                return;
            tvwCol.SelectedNode.BeginEdit( );
        }

        private void tvwCol_AfterLabelEdit( object sender , NodeLabelEditEventArgs e )
        {
            if ( e.Node == null )
                return;
            if ( e.Label == null )
                return;

            if ( e.Label.Trim( ) == "" )
            {
                MessageBox.Show( "列名不能为空" , "",MessageBoxButtons.OK , MessageBoxIcon.Error );
                e.CancelEdit = true ;
            }
        }

        private void button1_Click( object sender, EventArgs e )
        {
            FrmNote f = new FrmNote();
            f.ShowDialog();
        }


    }
}
