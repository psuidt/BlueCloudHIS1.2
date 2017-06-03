namespace HIS_BaseManager
{
    partial class FrmGBDictionary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmGBDictionary ) );
            this.tvitem = new System.Windows.Forms.TreeView( );
            this.splitter1 = new System.Windows.Forms.Splitter( );
            this.lvsubitem = new System.Windows.Forms.ListView( );
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader( );
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader( );
            this.toolStrip1 = new GWI.HIS.Windows.Controls.ToolStrip( );
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton( );
            this.plBaseToolbar.SuspendLayout( );
            this.plBaseWorkArea.SuspendLayout( );
            this.toolStrip1.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.BackColor = System.Drawing.SystemColors.Control;
            this.plBaseToolbar.Controls.Add( this.toolStrip1 );
            this.plBaseToolbar.Size = new System.Drawing.Size( 703 , 31 );
            // 
            // baseImageList
            // 
            this.baseImageList.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "baseImageList.ImageStream" ) ) );
            this.baseImageList.Images.SetKeyName( 0 , "table_delete.gif" );
            this.baseImageList.Images.SetKeyName( 1 , "search_big.GIF" );
            this.baseImageList.Images.SetKeyName( 2 , "Save.GIF" );
            this.baseImageList.Images.SetKeyName( 3 , "Print.GIF" );
            this.baseImageList.Images.SetKeyName( 4 , "page_user_dark.gif" );
            this.baseImageList.Images.SetKeyName( 5 , "page_refresh.gif" );
            this.baseImageList.Images.SetKeyName( 6 , "page_key.gif" );
            this.baseImageList.Images.SetKeyName( 7 , "page_edit.gif" );
            this.baseImageList.Images.SetKeyName( 8 , "page_cross.gif" );
            this.baseImageList.Images.SetKeyName( 9 , "list_users.gif" );
            this.baseImageList.Images.SetKeyName( 10 , "icon_package_get.gif" );
            this.baseImageList.Images.SetKeyName( 11 , "icon_network.gif" );
            this.baseImageList.Images.SetKeyName( 12 , "icon_history.gif" );
            this.baseImageList.Images.SetKeyName( 13 , "icon_accept.gif" );
            this.baseImageList.Images.SetKeyName( 14 , "folder_page.gif" );
            this.baseImageList.Images.SetKeyName( 15 , "folder_new.gif" );
            this.baseImageList.Images.SetKeyName( 16 , "Exit.GIF" );
            this.baseImageList.Images.SetKeyName( 17 , "Delete.GIF" );
            this.baseImageList.Images.SetKeyName( 18 , "copy.gif" );
            this.baseImageList.Images.SetKeyName( 19 , "action_stop.gif" );
            this.baseImageList.Images.SetKeyName( 20 , "action_refresh.gif" );
            // 
            // plBaseStatus
            // 
            this.plBaseStatus.Location = new System.Drawing.Point( 0 , 435 );
            this.plBaseStatus.Size = new System.Drawing.Size( 703 , 27 );
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add( this.lvsubitem );
            this.plBaseWorkArea.Controls.Add( this.splitter1 );
            this.plBaseWorkArea.Controls.Add( this.tvitem );
            this.plBaseWorkArea.Location = new System.Drawing.Point( 0 , 65 );
            this.plBaseWorkArea.Size = new System.Drawing.Size( 703 , 370 );
            // 
            // tvitem
            // 
            this.tvitem.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvitem.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.tvitem.ImageIndex = 10;
            this.tvitem.ImageList = this.baseImageList;
            this.tvitem.Location = new System.Drawing.Point( 0 , 0 );
            this.tvitem.Name = "tvitem";
            this.tvitem.SelectedImageIndex = 7;
            this.tvitem.Size = new System.Drawing.Size( 312 , 370 );
            this.tvitem.TabIndex = 0;
            this.tvitem.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.tvitem_AfterSelect );
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point( 312 , 0 );
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size( 5 , 370 );
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // lvsubitem
            // 
            this.lvsubitem.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2} );
            this.lvsubitem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvsubitem.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lvsubitem.FullRowSelect = true;
            this.lvsubitem.GridLines = true;
            this.lvsubitem.Location = new System.Drawing.Point( 317 , 0 );
            this.lvsubitem.Name = "lvsubitem";
            this.lvsubitem.Size = new System.Drawing.Size( 386 , 370 );
            this.lvsubitem.SmallImageList = this.baseImageList;
            this.lvsubitem.TabIndex = 2;
            this.lvsubitem.UseCompatibleStateImageBehavior = false;
            this.lvsubitem.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "项目编码";
            this.columnHeader1.Width = 98;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "项目名称";
            this.columnHeader2.Width = 274;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.BackgroundImage = ( (System.Drawing.Image)( resources.GetObject( "toolStrip1.BackgroundImage" ) ) );
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Font = new System.Drawing.Font( "宋体" , 10F );
            this.toolStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1} );
            this.toolStrip1.Location = new System.Drawing.Point( 0 , 0 );
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size( 703 , 31 );
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::HIS_BaseManager.Properties.Resources.退出;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size( 83 , 28 );
            this.toolStripButton1.Text = "关闭窗口";
            this.toolStripButton1.Click += new System.EventHandler( this.toolStripButton1_Click );
            // 
            // FrmGBDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 703 , 462 );
            this.Name = "FrmGBDictionary";
            this.Text = "FrmGBDictionary";
            this.Load += new System.EventHandler( this.FrmGBDictionary_Load );
            this.plBaseToolbar.ResumeLayout( false );
            this.plBaseToolbar.PerformLayout( );
            this.plBaseWorkArea.ResumeLayout( false );
            this.toolStrip1.ResumeLayout( false );
            this.toolStrip1.PerformLayout( );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.ListView lvsubitem;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TreeView tvitem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private GWI.HIS.Windows.Controls.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}