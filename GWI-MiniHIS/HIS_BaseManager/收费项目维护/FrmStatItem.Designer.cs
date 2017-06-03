namespace HIS_BaseManager
{
    partial class FrmStatItem
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmStatItem ) );
            this.dgvStatItem = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.toolStrip1 = new GWI.HIS.Windows.Controls.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnSubClass = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.dgvStatItem ) ).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.BackColor = System.Drawing.SystemColors.Control;
            this.plBaseToolbar.Controls.Add( this.toolStrip1 );
            this.plBaseToolbar.Size = new System.Drawing.Size( 845, 31 );
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
            this.plBaseStatus.Location = new System.Drawing.Point( 0, 507 );
            this.plBaseStatus.Size = new System.Drawing.Size( 845, 26 );
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add( this.dgvStatItem );
            this.plBaseWorkArea.Location = new System.Drawing.Point( 0, 65 );
            this.plBaseWorkArea.Size = new System.Drawing.Size( 845, 442 );
            // 
            // dgvStatItem
            // 
            this.dgvStatItem.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvStatItem.AllowSortWhenClickColumnHeader = false;
            this.dgvStatItem.AllowUserToAddRows = false;
            this.dgvStatItem.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ), ( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle1.Font = new System.Drawing.Font( "宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStatItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStatItem.ColumnHeadersHeight = 30;
            this.dgvStatItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStatItem.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgvStatItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStatItem.EnableHeadersVisualStyles = false;
            this.dgvStatItem.HideSelectionCardWhenCustomInput = false;
            this.dgvStatItem.Location = new System.Drawing.Point( 0, 0 );
            this.dgvStatItem.MultiSelect = false;
            this.dgvStatItem.Name = "dgvStatItem";
            this.dgvStatItem.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ), ( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle2.Font = new System.Drawing.Font( "宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStatItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStatItem.RowTemplate.Height = 23;
            this.dgvStatItem.SelectionCards = null;
            this.dgvStatItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStatItem.Size = new System.Drawing.Size( 845, 442 );
            this.dgvStatItem.TabIndex = 0;
            this.dgvStatItem.UseGradientBackgroundColor = false;
            this.dgvStatItem.DoubleClick += new System.EventHandler( this.dgvStatItem_DoubleClick );
            this.dgvStatItem.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler( this.dgvStatItem_DataError );
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.BackgroundImage = ( (System.Drawing.Image)( resources.GetObject( "toolStrip1.BackgroundImage" ) ) );
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Font = new System.Drawing.Font( "宋体", 10F );
            this.toolStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnSubClass,
            this.btnRefresh,
            this.btnClose} );
            this.toolStrip1.Location = new System.Drawing.Point( 0, 0 );
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size( 845, 31 );
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font( "宋体", 10F );
            this.btnAdd.Image = global::HIS_BaseManager.Properties.Resources.新建;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size( 55, 28 );
            this.btnAdd.Text = "新增";
            this.btnAdd.Click += new System.EventHandler( this.btnAdd_Click );
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::HIS_BaseManager.Properties.Resources.修改;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size( 55, 28 );
            this.btnEdit.Text = "编辑";
            this.btnEdit.Click += new System.EventHandler( this.btnEdit_Click );
            // 
            // btnSubClass
            // 
            this.btnSubClass.Image = global::HIS_BaseManager.Properties.Resources.菜单设置;
            this.btnSubClass.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSubClass.Name = "btnSubClass";
            this.btnSubClass.Size = new System.Drawing.Size( 83, 28 );
            this.btnSubClass.Text = "分类设置";
            this.btnSubClass.Click += new System.EventHandler( this.btnSubClass_Click );
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::HIS_BaseManager.Properties.Resources.action_refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size( 55, 28 );
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler( this.btnRefresh_Click );
            // 
            // btnClose
            // 
            this.btnClose.Image = global::HIS_BaseManager.Properties.Resources.退出;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 83, 28 );
            this.btnClose.Text = "关闭窗口";
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // FrmStatItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 845, 533 );
            this.Name = "FrmStatItem";
            this.Text = "FrmStatItem";
            this.Load += new System.EventHandler( this.FrmStatItem_Load );
            this.plBaseToolbar.ResumeLayout( false );
            this.plBaseToolbar.PerformLayout();
            this.plBaseWorkArea.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvStatItem ) ).EndInit();
            this.toolStrip1.ResumeLayout( false );
            this.toolStrip1.PerformLayout();
            this.ResumeLayout( false );

        }

        #endregion

        private GWI.HIS.Windows.Controls.DataGridViewEx dgvStatItem;
        private GWI.HIS.Windows.Controls.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnSubClass;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnClose;
    }
}