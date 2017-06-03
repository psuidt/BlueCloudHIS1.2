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
    public partial class FrmReportDesign : Form
    {
        private DataTable dtColumns;
        private string reportName;
        private string fileName = "";
        private GridppReport Report = new GridppReport( );
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ReportName"></param>
        /// <param name="Columns"></param>
        /// <param name="deleteExistsFile"></param>
        public FrmReportDesign(string ReportName, DataTable Columns , bool deleteExistsFile)
        {
            InitializeComponent( );

            dtColumns = Columns;
            reportName = ReportName;
            fileName = System.Windows.Forms.Application.StartupPath + "\\report\\" + reportName + ".grf";
            if ( deleteExistsFile && File.Exists(fileName)  )
                System.IO.File.Delete( fileName );
            

            this.Text = ReportName;

            this.axGRDesigner1.ShowToolbar = true;
        }

        

        private void FrmReportDesign_Load( object sender , EventArgs e )
        {
            if ( !Directory.Exists( System.Windows.Forms.Application.StartupPath + "\\report" ) )
            {
                Directory.CreateDirectory( System.Windows.Forms.Application.StartupPath + "\\report" );
            }
            if ( !File.Exists( fileName ) )
            {
                Report.SaveToFile( fileName );
                Report.InsertReportHeader( );
                Report.InsertDetailGrid( );
                Report.InsertReportFooter();
                foreach ( DataRow dr in dtColumns.Rows )
                {
                    string title_name = dr["TITLE_NAME"].ToString();
                    Report.DetailGrid.AddColumn( title_name , title_name , title_name , 2 );
                    Report.DetailGrid.Recordset.AddField( title_name , GRFieldType.grftString );
                }

                Report.AddParameter( "报表标题" , GRParameterDataType.grptString );
                Report.AddParameter( "统计时间" , GRParameterDataType.grptString );
                Report.AddParameter( "制表人" , GRParameterDataType.grptString );
                Report.AddParameter( "备注" , GRParameterDataType.grptString );

                Report.SaveToFile( fileName );

                
            }
            lblInfo.Text = "报表保存在：" + fileName;
        }

        private void FrmReportDesign_FormClosing( object sender , FormClosingEventArgs e )
        {
            GC.Collect( );
        }

        private void btnClose_Click( object sender, EventArgs e )
        {
            this.Close();
        }

       

      #region 工具栏功能(不用)
        //private enum GroupBoxType
        //{
        //    StaticBox = 1,
        //    ShapeBox = 2,
        //    SystemVarBox = 3,
        //    FieldBox = 4,
        //    StatBox = 5,
        //    RTFBox = 6,
        //    PictureBox = 7,
        //    MemoBox = 8,
        //    SubReport = 9,
        //    Line = 10,
        //    GraphBox = 11,
        //    BarCodeBox = 12
        //}

        //private void 静态框ToolStripMenuItem_Click( object sender, EventArgs e )
        //{
        //    axGRDesigner1.PrepareInsertControl( (short)GroupBoxType.StaticBox );
        //}

        //private void 边框ToolStripMenuItem_Click( object sender, EventArgs e )
        //{
        //    axGRDesigner1.PrepareInsertControl( (short)GroupBoxType.ShapeBox );
        //}

        //private void 系统变量框ToolStripMenuItem_Click( object sender, EventArgs e )
        //{
        //    axGRDesigner1.PrepareInsertControl( (short)GroupBoxType.SystemVarBox );
        //}

        //private void 字段框ToolStripMenuItem_Click( object sender, EventArgs e )
        //{
        //    axGRDesigner1.PrepareInsertControl( (short)GroupBoxType.FieldBox );
        //}

        //private void 统计框ToolStripMenuItem_Click( object sender, EventArgs e )
        //{
        //    axGRDesigner1.PrepareInsertControl( (short)GroupBoxType.StatBox );
        //}

        //private void rTF文本框ToolStripMenuItem_Click( object sender, EventArgs e )
        //{
        //    axGRDesigner1.PrepareInsertControl( (short)GroupBoxType.RTFBox );
        //}

        //private void pictures框ToolStripMenuItem_Click( object sender, EventArgs e )
        //{
        //    axGRDesigner1.PrepareInsertControl( (short)GroupBoxType.PictureBox );
        //}

        //private void memoToolStripMenuItem_Click( object sender, EventArgs e )
        //{
        //    axGRDesigner1.PrepareInsertControl( (short)GroupBoxType.MemoBox );
        //}

        //private void 图表框ToolStripMenuItem_Click( object sender, EventArgs e )
        //{
        //    axGRDesigner1.PrepareInsertControl( (short)GroupBoxType.GraphBox );
        //}

        //private void toolStripButton3_Click( object sender, EventArgs e )
        //{
        //    axGRDesigner1.PrepareInsertControl( (short)GroupBoxType.Line );
        //}

        //private void toolStripButton4_Click( object sender, EventArgs e )
        //{
        //    axGRDesigner1.PrepareInsertControl( (short)GroupBoxType.BarCodeBox );
        //}
      #endregion
    }
}
