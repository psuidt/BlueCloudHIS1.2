namespace HIS_BaseManager
{
    partial class FrmInsurMatch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmInsurMatch ) );
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvInsur = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvHIS = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvRelation = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.plPageIndex = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtKeyWord = new System.Windows.Forms.TextBox();
            this.chkRelation = new System.Windows.Forms.CheckBox();
            this.chkInsur = new System.Windows.Forms.CheckBox();
            this.chkHIS = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new GWI.HIS.Windows.Controls.ToolStrip();
            this.btnDownLoad = new System.Windows.Forms.ToolStripButton();
            this.btnMatch = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel4.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.dgvInsur ) ).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.dgvHIS ) ).BeginInit();
            this.panel3.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.dgvRelation ) ).BeginInit();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.BackColor = System.Drawing.SystemColors.Control;
            this.plBaseToolbar.Controls.Add( this.toolStrip1 );
            this.plBaseToolbar.Size = new System.Drawing.Size( 1117, 31 );
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
            this.plBaseStatus.Location = new System.Drawing.Point( 0, 715 );
            this.plBaseStatus.Size = new System.Drawing.Size( 1117, 26 );
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add( this.splitContainer1 );
            this.plBaseWorkArea.Location = new System.Drawing.Point( 0, 65 );
            this.plBaseWorkArea.Size = new System.Drawing.Size( 1117, 650 );
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point( 0, 0 );
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add( this.splitContainer2 );
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add( this.dgvRelation );
            this.splitContainer1.Panel2.Controls.Add( this.panel1 );
            this.splitContainer1.Size = new System.Drawing.Size( 1117, 650 );
            this.splitContainer1.SplitterDistance = 336;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point( 0, 0 );
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add( this.panel4 );
            this.splitContainer2.Panel1.Controls.Add( this.panel2 );
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add( this.panel5 );
            this.splitContainer2.Panel2.Controls.Add( this.panel3 );
            this.splitContainer2.Size = new System.Drawing.Size( 1117, 336 );
            this.splitContainer2.SplitterDistance = 573;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add( this.dgvInsur );
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point( 0, 24 );
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size( 573, 312 );
            this.panel4.TabIndex = 2;
            // 
            // dgvInsur
            // 
            this.dgvInsur.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvInsur.AllowSortWhenClickColumnHeader = false;
            this.dgvInsur.AllowUserToAddRows = false;
            this.dgvInsur.AllowUserToDeleteRows = false;
            this.dgvInsur.BackgroundColor = System.Drawing.Color.White;
            this.dgvInsur.ColumnHeadersHeight = 25;
            this.dgvInsur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInsur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInsur.Location = new System.Drawing.Point( 0, 0 );
            this.dgvInsur.MultiSelect = false;
            this.dgvInsur.Name = "dgvInsur";
            this.dgvInsur.ReadOnly = true;
            this.dgvInsur.RowTemplate.Height = 23;
            this.dgvInsur.SelectionCards = null;
            this.dgvInsur.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInsur.Size = new System.Drawing.Size( 573, 312 );
            this.dgvInsur.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add( this.label1 );
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point( 0, 0 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 573, 24 );
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point( 0, 0 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 573, 24 );
            this.label1.TabIndex = 0;
            this.label1.Text = "农合目录";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add( this.dgvHIS );
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point( 0, 24 );
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size( 540, 312 );
            this.panel5.TabIndex = 3;
            // 
            // dgvHIS
            // 
            this.dgvHIS.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvHIS.AllowSortWhenClickColumnHeader = false;
            this.dgvHIS.AllowUserToAddRows = false;
            this.dgvHIS.AllowUserToDeleteRows = false;
            this.dgvHIS.BackgroundColor = System.Drawing.Color.White;
            this.dgvHIS.ColumnHeadersHeight = 25;
            this.dgvHIS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHIS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHIS.Location = new System.Drawing.Point( 0, 0 );
            this.dgvHIS.Name = "dgvHIS";
            this.dgvHIS.ReadOnly = true;
            this.dgvHIS.RowTemplate.Height = 23;
            this.dgvHIS.SelectionCards = null;
            this.dgvHIS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHIS.Size = new System.Drawing.Size( 540, 312 );
            this.dgvHIS.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add( this.label2 );
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point( 0, 0 );
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size( 540, 24 );
            this.panel3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point( 0, 0 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 540, 24 );
            this.label2.TabIndex = 1;
            this.label2.Text = "医院目录";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvRelation
            // 
            this.dgvRelation.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvRelation.AllowSortWhenClickColumnHeader = false;
            this.dgvRelation.AllowUserToAddRows = false;
            this.dgvRelation.AllowUserToDeleteRows = false;
            this.dgvRelation.BackgroundColor = System.Drawing.Color.White;
            this.dgvRelation.ColumnHeadersHeight = 25;
            this.dgvRelation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRelation.Location = new System.Drawing.Point( 0, 31 );
            this.dgvRelation.Name = "dgvRelation";
            this.dgvRelation.RowTemplate.Height = 23;
            this.dgvRelation.SelectionCards = null;
            this.dgvRelation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvRelation.Size = new System.Drawing.Size( 1117, 279 );
            this.dgvRelation.TabIndex = 3;
            this.dgvRelation.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler( this.dgvRelation_DataError );
            this.dgvRelation.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler( this.dgvRelation_CellContentClick );
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.plPageIndex );
            this.panel1.Controls.Add( this.panel7 );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point( 0, 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 1117, 31 );
            this.panel1.TabIndex = 1;
            // 
            // plPageIndex
            // 
            this.plPageIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plPageIndex.Location = new System.Drawing.Point( 0, 0 );
            this.plPageIndex.Name = "plPageIndex";
            this.plPageIndex.Size = new System.Drawing.Size( 553, 31 );
            this.plPageIndex.TabIndex = 10;
            // 
            // panel7
            // 
            this.panel7.Controls.Add( this.btnSearch );
            this.panel7.Controls.Add( this.txtKeyWord );
            this.panel7.Controls.Add( this.chkRelation );
            this.panel7.Controls.Add( this.chkInsur );
            this.panel7.Controls.Add( this.chkHIS );
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point( 553, 0 );
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size( 564, 31 );
            this.panel7.TabIndex = 9;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnSearch.Location = new System.Drawing.Point( 486, 3 );
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size( 75, 23 );
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "查找";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler( this.btnSearch_Click );
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.txtKeyWord.Location = new System.Drawing.Point( 269, 4 );
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.Size = new System.Drawing.Size( 211, 21 );
            this.txtKeyWord.TabIndex = 0;
            this.txtKeyWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtKeyWord_KeyPress );
            // 
            // chkRelation
            // 
            this.chkRelation.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.chkRelation.AutoSize = true;
            this.chkRelation.Location = new System.Drawing.Point( 185, 6 );
            this.chkRelation.Name = "chkRelation";
            this.chkRelation.Size = new System.Drawing.Size( 72, 16 );
            this.chkRelation.TabIndex = 5;
            this.chkRelation.Text = "匹配关系";
            this.chkRelation.UseVisualStyleBackColor = true;
            // 
            // chkInsur
            // 
            this.chkInsur.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.chkInsur.AutoSize = true;
            this.chkInsur.Checked = true;
            this.chkInsur.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInsur.Location = new System.Drawing.Point( 17, 6 );
            this.chkInsur.Name = "chkInsur";
            this.chkInsur.Size = new System.Drawing.Size( 72, 16 );
            this.chkInsur.TabIndex = 3;
            this.chkInsur.Text = "农合目录";
            this.chkInsur.UseVisualStyleBackColor = true;
            // 
            // chkHIS
            // 
            this.chkHIS.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.chkHIS.AutoSize = true;
            this.chkHIS.Checked = true;
            this.chkHIS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHIS.Location = new System.Drawing.Point( 101, 6 );
            this.chkHIS.Name = "chkHIS";
            this.chkHIS.Size = new System.Drawing.Size( 72, 16 );
            this.chkHIS.TabIndex = 4;
            this.chkHIS.Text = "医院目录";
            this.chkHIS.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BackgroundImage = ( (System.Drawing.Image)( resources.GetObject( "toolStrip1.BackgroundImage" ) ) );
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Font = new System.Drawing.Font( "Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.toolStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.btnDownLoad,
            this.btnMatch,
            this.btnSave,
            this.btnRefresh,
            this.btnClose} );
            this.toolStrip1.Location = new System.Drawing.Point( 0, 0 );
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size( 1117, 31 );
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnDownLoad
            // 
            this.btnDownLoad.Image = ( (System.Drawing.Image)( resources.GetObject( "btnDownLoad.Image" ) ) );
            this.btnDownLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDownLoad.Name = "btnDownLoad";
            this.btnDownLoad.Size = new System.Drawing.Size( 134, 28 );
            this.btnDownLoad.Text = "下载药品目录(&L)";
            this.btnDownLoad.Click += new System.EventHandler( this.btnDownLoad_Click );
            // 
            // btnMatch
            // 
            this.btnMatch.Image = ( (System.Drawing.Image)( resources.GetObject( "btnMatch.Image" ) ) );
            this.btnMatch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMatch.Name = "btnMatch";
            this.btnMatch.Size = new System.Drawing.Size( 106, 28 );
            this.btnMatch.Text = "确认匹配(&A)";
            this.btnMatch.Click += new System.EventHandler( this.btnMatch_Click );
            // 
            // btnSave
            // 
            this.btnSave.Image = ( (System.Drawing.Image)( resources.GetObject( "btnSave.Image" ) ) );
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size( 136, 28 );
            this.btnSave.Text = "保存比例设置(&S)";
            this.btnSave.Click += new System.EventHandler( this.btnSave_Click );
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ( (System.Drawing.Image)( resources.GetObject( "btnRefresh.Image" ) ) );
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size( 76, 28 );
            this.btnRefresh.Text = "刷新(&R)";
            this.btnRefresh.Click += new System.EventHandler( this.btnRefresh_Click );
            // 
            // btnClose
            // 
            this.btnClose.Image = ( (System.Drawing.Image)( resources.GetObject( "btnClose.Image" ) ) );
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 76, 28 );
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // FrmInsurMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 1117, 741 );
            this.Name = "FrmInsurMatch";
            this.Text = "FrmInsurMatch";
            this.Load += new System.EventHandler( this.FrmInsurMatch_Load );
            this.plBaseToolbar.ResumeLayout( false );
            this.plBaseToolbar.PerformLayout();
            this.plBaseWorkArea.ResumeLayout( false );
            this.splitContainer1.Panel1.ResumeLayout( false );
            this.splitContainer1.Panel2.ResumeLayout( false );
            this.splitContainer1.ResumeLayout( false );
            this.splitContainer2.Panel1.ResumeLayout( false );
            this.splitContainer2.Panel2.ResumeLayout( false );
            this.splitContainer2.ResumeLayout( false );
            this.panel4.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvInsur ) ).EndInit();
            this.panel2.ResumeLayout( false );
            this.panel5.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvHIS ) ).EndInit();
            this.panel3.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvRelation ) ).EndInit();
            this.panel1.ResumeLayout( false );
            this.panel7.ResumeLayout( false );
            this.panel7.PerformLayout();
            this.toolStrip1.ResumeLayout( false );
            this.toolStrip1.PerformLayout();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvInsur;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvHIS;
        private GWI.HIS.Windows.Controls.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnMatch;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnClose;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvRelation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkRelation;
        private System.Windows.Forms.CheckBox chkHIS;
        private System.Windows.Forms.CheckBox chkInsur;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtKeyWord;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel plPageIndex;
        private System.Windows.Forms.ToolStripButton btnDownLoad;
        private System.Windows.Forms.ToolStripButton btnSave;
    }
}