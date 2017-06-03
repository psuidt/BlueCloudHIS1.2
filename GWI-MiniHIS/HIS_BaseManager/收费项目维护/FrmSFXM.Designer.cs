namespace HIS_BaseManager
{
    partial class FrmSFXM
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
            this.components = new System.ComponentModel.Container( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmSFXM ) );
            this.dgvItems = new GWI.HIS.Windows.Controls.DataGridViewEx( );
            this.ITEM_ID = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.STD_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.ITEM_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.ITEM_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.PY_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.WB_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.ITEM_UNIT = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.STATITEM_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.STATITEM_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.VALID_FLAG = new System.Windows.Forms.DataGridViewCheckBoxColumn( );
            this.imageList2 = new System.Windows.Forms.ImageList( this.components );
            this.btnSearch = new System.Windows.Forms.Button( );
            this.txtFind = new System.Windows.Forms.TextBox( );
            this.label1 = new System.Windows.Forms.Label( );
            this.toolStrip1 = new GWI.HIS.Windows.Controls.ToolStrip( );
            this.btnAdd = new System.Windows.Forms.ToolStripButton( );
            this.btnEdit = new System.Windows.Forms.ToolStripButton( );
            this.btnShowAll = new System.Windows.Forms.ToolStripButton( );
            this.btnClose = new System.Windows.Forms.ToolStripButton( );
            this.label2 = new System.Windows.Forms.Label( );
            this.cboStatItem = new System.Windows.Forms.ComboBox( );
            this.chkAll = new System.Windows.Forms.CheckBox( );
            this.plBaseToolbar.SuspendLayout( );
            this.plBaseStatus.SuspendLayout( );
            this.plBaseWorkArea.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvItems ) ).BeginInit( );
            this.toolStrip1.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.BackColor = System.Drawing.SystemColors.Control;
            this.plBaseToolbar.Controls.Add( this.toolStrip1 );
            this.plBaseToolbar.Size = new System.Drawing.Size( 836 , 31 );
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
            this.plBaseStatus.Controls.Add( this.chkAll );
            this.plBaseStatus.Controls.Add( this.cboStatItem );
            this.plBaseStatus.Controls.Add( this.label2 );
            this.plBaseStatus.Controls.Add( this.btnSearch );
            this.plBaseStatus.Controls.Add( this.txtFind );
            this.plBaseStatus.Controls.Add( this.label1 );
            this.plBaseStatus.Location = new System.Drawing.Point( 0 , 405 );
            this.plBaseStatus.Size = new System.Drawing.Size( 836 , 42 );
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add( this.dgvItems );
            this.plBaseWorkArea.Location = new System.Drawing.Point( 0 , 65 );
            this.plBaseWorkArea.Size = new System.Drawing.Size( 836 , 340 );
            // 
            // dgvItems
            // 
            this.dgvItems.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvItems.AllowSortWhenClickColumnHeader = true;
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle1.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItems.ColumnHeadersHeight = 30;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvItems.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.ITEM_ID,
            this.STD_CODE,
            this.ITEM_NAME,
            this.ITEM_CODE,
            this.PY_CODE,
            this.WB_CODE,
            this.PRICE,
            this.ITEM_UNIT,
            this.STATITEM_NAME,
            this.STATITEM_CODE,
            this.VALID_FLAG} );
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.EnableHeadersVisualStyles = false;
            this.dgvItems.Location = new System.Drawing.Point( 0 , 0 );
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle2.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvItems.RowTemplate.Height = 28;
            this.dgvItems.SelectionCards = null;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size( 836 , 340 );
            this.dgvItems.TabIndex = 0;
            this.dgvItems.UseGradientBackgroundColor = false;
            this.dgvItems.DoubleClick += new System.EventHandler( this.dgvItems_DoubleClick );
            this.dgvItems.CurrentCellChanged += new System.EventHandler( this.dgvItems_CurrentCellChanged );
            // 
            // ITEM_ID
            // 
            this.ITEM_ID.DataPropertyName = "ITEM_ID";
            this.ITEM_ID.HeaderText = "ITEM_ID";
            this.ITEM_ID.Name = "ITEM_ID";
            this.ITEM_ID.ReadOnly = true;
            this.ITEM_ID.Visible = false;
            // 
            // STD_CODE
            // 
            this.STD_CODE.DataPropertyName = "STD_CODE";
            this.STD_CODE.HeaderText = "医疗编码";
            this.STD_CODE.Name = "STD_CODE";
            this.STD_CODE.ReadOnly = true;
            // 
            // ITEM_NAME
            // 
            this.ITEM_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ITEM_NAME.DataPropertyName = "ITEM_NAME";
            this.ITEM_NAME.HeaderText = "项目名称";
            this.ITEM_NAME.Name = "ITEM_NAME";
            this.ITEM_NAME.ReadOnly = true;
            // 
            // ITEM_CODE
            // 
            this.ITEM_CODE.DataPropertyName = "ITEM_CODE";
            this.ITEM_CODE.HeaderText = "数字码";
            this.ITEM_CODE.Name = "ITEM_CODE";
            this.ITEM_CODE.ReadOnly = true;
            this.ITEM_CODE.Visible = false;
            // 
            // PY_CODE
            // 
            this.PY_CODE.DataPropertyName = "PY_CODE";
            this.PY_CODE.HeaderText = "拼音码";
            this.PY_CODE.Name = "PY_CODE";
            this.PY_CODE.ReadOnly = true;
            // 
            // WB_CODE
            // 
            this.WB_CODE.DataPropertyName = "WB_CODE";
            this.WB_CODE.HeaderText = "五笔码";
            this.WB_CODE.Name = "WB_CODE";
            this.WB_CODE.ReadOnly = true;
            // 
            // PRICE
            // 
            this.PRICE.DataPropertyName = "PRICE";
            this.PRICE.HeaderText = "价格";
            this.PRICE.Name = "PRICE";
            this.PRICE.ReadOnly = true;
            this.PRICE.Width = 75;
            // 
            // ITEM_UNIT
            // 
            this.ITEM_UNIT.DataPropertyName = "ITEM_UNIT";
            this.ITEM_UNIT.HeaderText = "计价单位";
            this.ITEM_UNIT.Name = "ITEM_UNIT";
            this.ITEM_UNIT.ReadOnly = true;
            // 
            // STATITEM_NAME
            // 
            this.STATITEM_NAME.DataPropertyName = "STATITEM_NAME";
            this.STATITEM_NAME.HeaderText = "统计大类";
            this.STATITEM_NAME.Name = "STATITEM_NAME";
            this.STATITEM_NAME.ReadOnly = true;
            // 
            // STATITEM_CODE
            // 
            this.STATITEM_CODE.DataPropertyName = "STATITEM_CODE";
            this.STATITEM_CODE.HeaderText = "统计大类";
            this.STATITEM_CODE.Name = "STATITEM_CODE";
            this.STATITEM_CODE.ReadOnly = true;
            this.STATITEM_CODE.Visible = false;
            // 
            // VALID_FLAG
            // 
            this.VALID_FLAG.DataPropertyName = "VALID_FLAG";
            this.VALID_FLAG.HeaderText = "有效";
            this.VALID_FLAG.Name = "VALID_FLAG";
            this.VALID_FLAG.ReadOnly = true;
            this.VALID_FLAG.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.VALID_FLAG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.VALID_FLAG.Width = 40;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "imageList2.ImageStream" ) ) );
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName( 0 , "修改.ico" );
            this.imageList2.Images.SetKeyName( 1 , "新增.ico" );
            this.imageList2.Images.SetKeyName( 2 , "退出.ico" );
            this.imageList2.Images.SetKeyName( 3 , "删除.ico" );
            this.imageList2.Images.SetKeyName( 4 , "科室.ico" );
            this.imageList2.Images.SetKeyName( 5 , "层次.ico" );
            this.imageList2.Images.SetKeyName( 6 , "人员.ico" );
            this.imageList2.Images.SetKeyName( 7 , "刷新.ico" );
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnSearch.Image = global::HIS_BaseManager.Properties.Resources.搜索_;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point( 748 , 5 );
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size( 81 , 23 );
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查找";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler( this.btnSearch_Click );
            // 
            // txtFind
            // 
            this.txtFind.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.txtFind.Location = new System.Drawing.Point( 538 , 7 );
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size( 204 , 21 );
            this.txtFind.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 383 , 12 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 149 , 12 );
            this.label1.TabIndex = 0;
            this.label1.Text = "输入关键字或者拼音五笔码";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.BackgroundImage = ( (System.Drawing.Image)( resources.GetObject( "toolStrip1.BackgroundImage" ) ) );
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Font = new System.Drawing.Font( "宋体" , 10F );
            this.toolStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnShowAll,
            this.btnClose} );
            this.toolStrip1.Location = new System.Drawing.Point( 0 , 0 );
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size( 836 , 31 );
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::HIS_BaseManager.Properties.Resources.新建;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size( 55 , 28 );
            this.btnAdd.Text = "新增";
            this.btnAdd.Click += new System.EventHandler( this.btnAdd_Click );
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::HIS_BaseManager.Properties.Resources.修改;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size( 55 , 28 );
            this.btnEdit.Text = "修改";
            this.btnEdit.Click += new System.EventHandler( this.btnEdit_Click );
            // 
            // btnShowAll
            // 
            this.btnShowAll.Image = global::HIS_BaseManager.Properties.Resources.刷新;
            this.btnShowAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size( 55 , 28 );
            this.btnShowAll.Text = "刷新";
            this.btnShowAll.Click += new System.EventHandler( this.btnShowAll_Click );
            // 
            // btnClose
            // 
            this.btnClose.Image = global::HIS_BaseManager.Properties.Resources.退出;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 83 , 28 );
            this.btnClose.Text = "关闭窗口";
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 12 , 12 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 53 , 12 );
            this.label2.TabIndex = 3;
            this.label2.Text = "统计大类";
            // 
            // cboStatItem
            // 
            this.cboStatItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatItem.FormattingEnabled = true;
            this.cboStatItem.Location = new System.Drawing.Point( 71 , 7 );
            this.cboStatItem.MaxDropDownItems = 30;
            this.cboStatItem.Name = "cboStatItem";
            this.cboStatItem.Size = new System.Drawing.Size( 196 , 20 );
            this.cboStatItem.TabIndex = 4;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point( 285 , 11 );
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size( 48 , 16 );
            this.chkAll.TabIndex = 5;
            this.chkAll.Text = "全部";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler( this.chkAll_CheckedChanged );
            // 
            // FrmSFXM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 836 , 447 );
            this.Name = "FrmSFXM";
            this.Text = "FrmSFXM";
            this.Load += new System.EventHandler( this.FrmSFXM_Load );
            this.plBaseToolbar.ResumeLayout( false );
            this.plBaseToolbar.PerformLayout( );
            this.plBaseStatus.ResumeLayout( false );
            this.plBaseStatus.PerformLayout( );
            this.plBaseWorkArea.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvItems ) ).EndInit( );
            this.toolStrip1.ResumeLayout( false );
            this.toolStrip1.PerformLayout( );
            this.ResumeLayout( false );

        }

        #endregion

        private GWI.HIS.Windows.Controls.DataGridViewEx dgvItems;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Label label1;
        private GWI.HIS.Windows.Controls.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnShowAll;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn STD_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PY_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn WB_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_UNIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATITEM_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATITEM_CODE;
        private System.Windows.Forms.DataGridViewCheckBoxColumn VALID_FLAG;
        private System.Windows.Forms.ComboBox cboStatItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkAll;
    }
}