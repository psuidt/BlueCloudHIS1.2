namespace HIS_BaseManager.基本数据维护
{
    partial class FrmBaseDataVindicator
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
                components.Dispose();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBaseDataVindicator));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.plLeft = new System.Windows.Forms.Panel();
            this.plTreeView = new System.Windows.Forms.Panel();
            this.tvwTable = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.plConfig = new System.Windows.Forms.Panel();
            this.btnTableInfo = new System.Windows.Forms.Button();
            this.btnRefreshConfig = new System.Windows.Forms.Button();
            this.btnTableConfig = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.plRight = new System.Windows.Forms.Panel();
            this.plGrid = new System.Windows.Forms.Panel();
            this.dgvData = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.plDetail = new System.Windows.Forms.Panel();
            this.plEditControl = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnResetFind = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.plButton = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.chkMessage = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.plBaseWorkArea.SuspendLayout();
            this.plLeft.SuspendLayout();
            this.plTreeView.SuspendLayout();
            this.plConfig.SuspendLayout();
            this.plRight.SuspendLayout();
            this.plGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.plDetail.SuspendLayout();
            this.panel1.SuspendLayout();
            this.plButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.BackColor = System.Drawing.SystemColors.Control;
            this.plBaseToolbar.Size = new System.Drawing.Size(905, 0);
            // 
            // baseImageList
            // 
            this.baseImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("baseImageList.ImageStream")));
            this.baseImageList.Images.SetKeyName(0, "table_delete.gif");
            this.baseImageList.Images.SetKeyName(1, "search_big.GIF");
            this.baseImageList.Images.SetKeyName(2, "Save.GIF");
            this.baseImageList.Images.SetKeyName(3, "Print.GIF");
            this.baseImageList.Images.SetKeyName(4, "page_user_dark.gif");
            this.baseImageList.Images.SetKeyName(5, "page_refresh.gif");
            this.baseImageList.Images.SetKeyName(6, "page_key.gif");
            this.baseImageList.Images.SetKeyName(7, "page_edit.gif");
            this.baseImageList.Images.SetKeyName(8, "page_cross.gif");
            this.baseImageList.Images.SetKeyName(9, "list_users.gif");
            this.baseImageList.Images.SetKeyName(10, "icon_package_get.gif");
            this.baseImageList.Images.SetKeyName(11, "icon_network.gif");
            this.baseImageList.Images.SetKeyName(12, "icon_history.gif");
            this.baseImageList.Images.SetKeyName(13, "icon_accept.gif");
            this.baseImageList.Images.SetKeyName(14, "folder_page.gif");
            this.baseImageList.Images.SetKeyName(15, "folder_new.gif");
            this.baseImageList.Images.SetKeyName(16, "Exit.GIF");
            this.baseImageList.Images.SetKeyName(17, "Delete.GIF");
            this.baseImageList.Images.SetKeyName(18, "copy.gif");
            this.baseImageList.Images.SetKeyName(19, "action_stop.gif");
            this.baseImageList.Images.SetKeyName(20, "action_refresh.gif");
            // 
            // plBaseStatus
            // 
            this.plBaseStatus.Location = new System.Drawing.Point(0, 523);
            this.plBaseStatus.Size = new System.Drawing.Size(905, 0);
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.plRight);
            this.plBaseWorkArea.Controls.Add(this.splitter1);
            this.plBaseWorkArea.Controls.Add(this.plLeft);
            this.plBaseWorkArea.Location = new System.Drawing.Point(0, 34);
            this.plBaseWorkArea.Size = new System.Drawing.Size(905, 489);
            // 
            // plLeft
            // 
            this.plLeft.Controls.Add(this.plTreeView);
            this.plLeft.Controls.Add(this.plConfig);
            this.plLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.plLeft.Location = new System.Drawing.Point(0, 0);
            this.plLeft.Name = "plLeft";
            this.plLeft.Size = new System.Drawing.Size(216, 489);
            this.plLeft.TabIndex = 0;
            // 
            // plTreeView
            // 
            this.plTreeView.Controls.Add(this.tvwTable);
            this.plTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plTreeView.Location = new System.Drawing.Point(0, 0);
            this.plTreeView.Name = "plTreeView";
            this.plTreeView.Size = new System.Drawing.Size(216, 429);
            this.plTreeView.TabIndex = 2;
            // 
            // tvwTable
            // 
            this.tvwTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwTable.HideSelection = false;
            this.tvwTable.ImageIndex = 0;
            this.tvwTable.ImageList = this.imageList1;
            this.tvwTable.Location = new System.Drawing.Point(0, 0);
            this.tvwTable.Name = "tvwTable";
            this.tvwTable.SelectedImageIndex = 1;
            this.tvwTable.Size = new System.Drawing.Size(216, 429);
            this.tvwTable.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Dervish Desktop.ico");
            this.imageList1.Images.SetKeyName(1, "Dervish Text Document.ico");
            this.imageList1.Images.SetKeyName(2, "Dervish Text Document.ico");
            // 
            // plConfig
            // 
            this.plConfig.Controls.Add(this.btnTableInfo);
            this.plConfig.Controls.Add(this.btnRefreshConfig);
            this.plConfig.Controls.Add(this.btnTableConfig);
            this.plConfig.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plConfig.Location = new System.Drawing.Point(0, 429);
            this.plConfig.Name = "plConfig";
            this.plConfig.Size = new System.Drawing.Size(216, 60);
            this.plConfig.TabIndex = 1;
            // 
            // btnTableInfo
            // 
            this.btnTableInfo.Location = new System.Drawing.Point(3, 5);
            this.btnTableInfo.Name = "btnTableInfo";
            this.btnTableInfo.Size = new System.Drawing.Size(105, 23);
            this.btnTableInfo.TabIndex = 3;
            this.btnTableInfo.Text = "表维护(&T)";
            this.btnTableInfo.UseVisualStyleBackColor = true;
            this.btnTableInfo.Click += new System.EventHandler(this.btnTableInfo_Click);
            // 
            // btnRefreshConfig
            // 
            this.btnRefreshConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshConfig.Location = new System.Drawing.Point(3, 31);
            this.btnRefreshConfig.Name = "btnRefreshConfig";
            this.btnRefreshConfig.Size = new System.Drawing.Size(207, 23);
            this.btnRefreshConfig.TabIndex = 2;
            this.btnRefreshConfig.Text = "刷新(&L)";
            this.btnRefreshConfig.UseVisualStyleBackColor = true;
            this.btnRefreshConfig.Click += new System.EventHandler(this.btnRefreshConfig_Click);
            // 
            // btnTableConfig
            // 
            this.btnTableConfig.Location = new System.Drawing.Point(111, 5);
            this.btnTableConfig.Name = "btnTableConfig";
            this.btnTableConfig.Size = new System.Drawing.Size(99, 23);
            this.btnTableConfig.TabIndex = 1;
            this.btnTableConfig.Text = "字段维护(&F)";
            this.btnTableConfig.UseVisualStyleBackColor = true;
            this.btnTableConfig.Click += new System.EventHandler(this.btnTableConfig_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(216, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 489);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // plRight
            // 
            this.plRight.Controls.Add(this.plGrid);
            this.plRight.Controls.Add(this.splitter2);
            this.plRight.Controls.Add(this.plDetail);
            this.plRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plRight.Location = new System.Drawing.Point(219, 0);
            this.plRight.Name = "plRight";
            this.plRight.Size = new System.Drawing.Size(686, 489);
            this.plRight.TabIndex = 2;
            // 
            // plGrid
            // 
            this.plGrid.Controls.Add(this.dgvData);
            this.plGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plGrid.Location = new System.Drawing.Point(0, 0);
            this.plGrid.Name = "plGrid";
            this.plGrid.Size = new System.Drawing.Size(686, 273);
            this.plGrid.TabIndex = 2;
            // 
            // dgvData
            // 
            this.dgvData.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvData.AllowSortWhenClickColumnHeader = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeight = 35;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.HideSelectionCardWhenCustomInput = false;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.SelectionCards = null;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(686, 273);
            this.dgvData.TabIndex = 0;
            this.dgvData.UseGradientBackgroundColor = false;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(0, 273);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(686, 3);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // plDetail
            // 
            this.plDetail.Controls.Add(this.plEditControl);
            this.plDetail.Controls.Add(this.panel1);
            this.plDetail.Controls.Add(this.plButton);
            this.plDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plDetail.Location = new System.Drawing.Point(0, 276);
            this.plDetail.Name = "plDetail";
            this.plDetail.Size = new System.Drawing.Size(686, 213);
            this.plDetail.TabIndex = 0;
            // 
            // plEditControl
            // 
            this.plEditControl.AutoScroll = true;
            this.plEditControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plEditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plEditControl.Location = new System.Drawing.Point(0, 25);
            this.plEditControl.Name = "plEditControl";
            this.plEditControl.Size = new System.Drawing.Size(686, 156);
            this.plEditControl.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnResetFind);
            this.panel1.Controls.Add(this.btnFind);
            this.panel1.Controls.Add(this.txtKeyword);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(686, 25);
            this.panel1.TabIndex = 2;
            // 
            // btnResetFind
            // 
            this.btnResetFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetFind.Location = new System.Drawing.Point(593, 1);
            this.btnResetFind.Name = "btnResetFind";
            this.btnResetFind.Size = new System.Drawing.Size(75, 23);
            this.btnResetFind.TabIndex = 3;
            this.btnResetFind.Text = "重置(&R)";
            this.btnResetFind.UseVisualStyleBackColor = true;
            this.btnResetFind.Click += new System.EventHandler(this.btnResetFind_Click);
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.Location = new System.Drawing.Point(512, 1);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "查找(&Q)";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyword.Location = new System.Drawing.Point(131, 2);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(375, 21);
            this.txtKeyword.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入查询关键字(&K)";
            // 
            // plButton
            // 
            this.plButton.Controls.Add(this.btnDelete);
            this.plButton.Controls.Add(this.chkMessage);
            this.plButton.Controls.Add(this.btnClose);
            this.plButton.Controls.Add(this.btnRefresh);
            this.plButton.Controls.Add(this.btnSave);
            this.plButton.Controls.Add(this.btnAddNew);
            this.plButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plButton.Location = new System.Drawing.Point(0, 181);
            this.plButton.Name = "plButton";
            this.plButton.Size = new System.Drawing.Size(686, 32);
            this.plButton.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(170, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // chkMessage
            // 
            this.chkMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkMessage.AutoSize = true;
            this.chkMessage.Location = new System.Drawing.Point(527, 7);
            this.chkMessage.Name = "chkMessage";
            this.chkMessage.Size = new System.Drawing.Size(156, 16);
            this.chkMessage.TabIndex = 5;
            this.chkMessage.Text = "记录保存成功后不要提示";
            this.chkMessage.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(332, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭(&X)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(251, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "刷新(&A)";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(89, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(8, 3);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 23);
            this.btnAddNew.TabIndex = 0;
            this.btnAddNew.Text = "新增(&N)";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // FrmBaseDataVindicator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 523);
            this.Name = "FrmBaseDataVindicator";
            this.Text = "FrmBaseDataVindicator";
            this.Load += new System.EventHandler(this.FrmBaseDataVindicator_Load);
            this.plBaseWorkArea.ResumeLayout(false);
            this.plLeft.ResumeLayout(false);
            this.plTreeView.ResumeLayout(false);
            this.plConfig.ResumeLayout(false);
            this.plRight.ResumeLayout(false);
            this.plGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.plDetail.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.plButton.ResumeLayout(false);
            this.plButton.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plRight;
        private System.Windows.Forms.Panel plGrid;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel plDetail;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel plLeft;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvData;
        private System.Windows.Forms.Panel plButton;
        private System.Windows.Forms.Panel plTreeView;
        private System.Windows.Forms.TreeView tvwTable;
        private System.Windows.Forms.Panel plConfig;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnTableConfig;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button btnRefreshConfig;
        private System.Windows.Forms.CheckBox chkMessage;
        private System.Windows.Forms.Panel plEditControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnResetFind;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTableInfo;
        private System.Windows.Forms.Button btnDelete;
    }
}