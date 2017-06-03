namespace HIS_BaseManager
{
    partial class FrmHisReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmHisReport ) );
            this.hISReportBindingSource = new System.Windows.Forms.BindingSource( this.components );
            this.toolStrip1 = new GWI.HIS.Windows.Controls.ToolStrip();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.hISReportBindingSource ) ).BeginInit();
            this.toolStrip1.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.dataGridView1 ) ).BeginInit();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.BackColor = System.Drawing.SystemColors.Control;
            this.plBaseToolbar.Controls.Add( this.toolStrip1 );
            this.plBaseToolbar.Size = new System.Drawing.Size( 1016, 31 );
            this.plBaseToolbar.Visible = false;
            // 
            // baseImageList
            // 
            this.baseImageList.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "baseImageList.ImageStream" ) ) );
            this.baseImageList.Images.SetKeyName( 0, "table_delete.gif" );
            this.baseImageList.Images.SetKeyName( 1, "search_big.GIF" );
            this.baseImageList.Images.SetKeyName( 2, "Save.GIF" );
            this.baseImageList.Images.SetKeyName( 3, "Print.GIF" );
            this.baseImageList.Images.SetKeyName( 4, "page_user_dark.gif" );
            this.baseImageList.Images.SetKeyName( 5, "page_refresh.gif" );
            this.baseImageList.Images.SetKeyName( 6, "page_key.gif" );
            this.baseImageList.Images.SetKeyName( 7, "page_edit.gif" );
            this.baseImageList.Images.SetKeyName( 8, "page_cross.gif" );
            this.baseImageList.Images.SetKeyName( 9, "list_users.gif" );
            this.baseImageList.Images.SetKeyName( 10, "icon_package_get.gif" );
            this.baseImageList.Images.SetKeyName( 11, "icon_network.gif" );
            this.baseImageList.Images.SetKeyName( 12, "icon_history.gif" );
            this.baseImageList.Images.SetKeyName( 13, "icon_accept.gif" );
            this.baseImageList.Images.SetKeyName( 14, "folder_page.gif" );
            this.baseImageList.Images.SetKeyName( 15, "folder_new.gif" );
            this.baseImageList.Images.SetKeyName( 16, "Exit.GIF" );
            this.baseImageList.Images.SetKeyName( 17, "Delete.GIF" );
            this.baseImageList.Images.SetKeyName( 18, "copy.gif" );
            this.baseImageList.Images.SetKeyName( 19, "action_stop.gif" );
            this.baseImageList.Images.SetKeyName( 20, "action_refresh.gif" );
            // 
            // plBaseStatus
            // 
            this.plBaseStatus.Location = new System.Drawing.Point( 0, 708 );
            this.plBaseStatus.Size = new System.Drawing.Size( 1016, 26 );
            this.plBaseStatus.Visible = false;
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add( this.dataGridView1 );
            this.plBaseWorkArea.Location = new System.Drawing.Point( 0, 65 );
            this.plBaseWorkArea.Size = new System.Drawing.Size( 1016, 643 );
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.BackgroundImage = ( (System.Drawing.Image)( resources.GetObject( "toolStrip1.BackgroundImage" ) ) );
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Font = new System.Drawing.Font( "宋体", 10F );
            this.toolStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton7,
            this.toolStripSeparator3,
            this.toolStripButton1,
            this.toolStripButton6,
            this.toolStripButton2,
            this.toolStripButton8,
            this.toolStripSeparator2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator1,
            this.toolStripButton5} );
            this.toolStrip1.Location = new System.Drawing.Point( 0, 0 );
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size( 1016, 31 );
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripButton7.Image" ) ) );
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size( 55, 28 );
            this.toolStripButton7.Text = "刷新";
            this.toolStripButton7.Click += new System.EventHandler( this.toolStripButton7_Click );
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size( 6, 31 );
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripButton1.Image" ) ) );
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size( 83, 28 );
            this.toolStripButton1.Text = "新建报表";
            this.toolStripButton1.Click += new System.EventHandler( this.toolStripButton1_Click );
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripButton6.Image" ) ) );
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size( 83, 28 );
            this.toolStripButton6.Text = "修改报表";
            this.toolStripButton6.Click += new System.EventHandler( this.toolStripButton6_Click );
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripButton2.Image" ) ) );
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size( 83, 28 );
            this.toolStripButton2.Text = "设计报表";
            this.toolStripButton2.Click += new System.EventHandler( this.toolStripButton2_Click );
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripButton8.Image" ) ) );
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size( 83, 28 );
            this.toolStripButton8.Text = "删除报表";
            this.toolStripButton8.Click += new System.EventHandler( this.toolStripButton8_Click );
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size( 6, 31 );
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripButton3.Image" ) ) );
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size( 83, 28 );
            this.toolStripButton3.Text = "预览报表";
            this.toolStripButton3.Click += new System.EventHandler( this.toolStripButton3_Click );
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripButton4.Image" ) ) );
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size( 83, 28 );
            this.toolStripButton4.Text = "打印报表";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size( 6, 31 );
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripButton5.Image" ) ) );
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size( 76, 28 );
            this.toolStripButton5.Text = "关闭(&C)";
            this.toolStripButton5.Click += new System.EventHandler( this.toolStripButton5_Click );
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point( 0, 0 );
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding( 3, 0, 0, 0 );
            this.BottomToolStripPanel.Size = new System.Drawing.Size( 0, 0 );
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point( 0, 0 );
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding( 3, 0, 0, 0 );
            this.TopToolStripPanel.Size = new System.Drawing.Size( 0, 0 );
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point( 0, 0 );
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding( 3, 0, 0, 0 );
            this.RightToolStripPanel.Size = new System.Drawing.Size( 0, 0 );
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point( 0, 0 );
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding( 3, 0, 0, 0 );
            this.LeftToolStripPanel.Size = new System.Drawing.Size( 0, 0 );
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size( 1016, 620 );
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DataSource = this.hISReportBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point( 0, 0 );
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size( 1016, 643 );
            this.dataGridView1.TabIndex = 1;
            // 
            // FrmHisReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 1016, 734 );
            this.FormTitle = "报表管理";
            this.Name = "FrmHisReport";
            this.Text = "报表管理";
            this.plBaseToolbar.ResumeLayout( false );
            this.plBaseToolbar.PerformLayout();
            this.plBaseWorkArea.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.hISReportBindingSource ) ).EndInit();
            this.toolStrip1.ResumeLayout( false );
            this.toolStrip1.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.dataGridView1 ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private GWI.HIS.Windows.Controls.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.BindingSource hISReportBindingSource;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridViewTextBoxColumn reportIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reportNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reportPathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buildEmpNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buildEmpCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buildDateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
    }
}