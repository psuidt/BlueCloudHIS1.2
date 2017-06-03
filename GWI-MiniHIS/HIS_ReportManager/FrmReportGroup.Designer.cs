namespace HIS_ReportManager
{
    partial class FrmReportGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportGroup));
            this.toolStrip1 = new GWI.HIS.Windows.Controls.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lstGroup = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.TvReport = new System.Windows.Forms.TreeView();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Controls.Add(this.toolStrip1);
            this.plBaseToolbar.Size = new System.Drawing.Size(1016, 29);
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
            this.plBaseStatus.Location = new System.Drawing.Point(0, 708);
            this.plBaseStatus.Size = new System.Drawing.Size(1016, 26);
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.TvReport);
            this.plBaseWorkArea.Controls.Add(this.lstGroup);
            this.plBaseWorkArea.Size = new System.Drawing.Size(1016, 645);
            // 
            // plTitle
            // 
            this.plTitle.Size = new System.Drawing.Size(1016, 34);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStrip1.BackgroundImage")));
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnRefresh,
            this.btnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1016, 29);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 26);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(55, 26);
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(83, 26);
            this.btnExit.Text = "关闭窗口";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // lstGroup
            // 
            this.lstGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstGroup.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstGroup.FullRowSelect = true;
            this.lstGroup.HideSelection = false;
            this.lstGroup.LargeImageList = this.imageList1;
            this.lstGroup.Location = new System.Drawing.Point(0, 0);
            this.lstGroup.MultiSelect = false;
            this.lstGroup.Name = "lstGroup";
            this.lstGroup.Size = new System.Drawing.Size(383, 645);
            this.lstGroup.SmallImageList = this.imageList1;
            this.lstGroup.TabIndex = 3;
            this.lstGroup.UseCompatibleStateImageBehavior = false;
            this.lstGroup.View = System.Windows.Forms.View.Details;
            this.lstGroup.SelectedIndexChanged += new System.EventHandler(this.lstGroup_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "工作组名称";
            this.columnHeader1.Width = 199;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "描述";
            this.columnHeader2.Width = 172;
            // 
            // TvReport
            // 
            this.TvReport.CheckBoxes = true;
            this.TvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvReport.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TvReport.FullRowSelect = true;
            this.TvReport.ImageIndex = 0;
            this.TvReport.ImageList = this.baseImageList;
            this.TvReport.Location = new System.Drawing.Point(383, 0);
            this.TvReport.Name = "TvReport";
            this.TvReport.RightToLeftLayout = true;
            this.TvReport.SelectedImageIndex = 0;
            this.TvReport.Size = new System.Drawing.Size(633, 645);
            this.TvReport.TabIndex = 4;
            this.TvReport.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TvReport_AfterCheck);           
            // 
            // FrmReportGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.FormTitle = "报表权限管理";
            this.Name = "FrmReportGroup";
            this.Text = "报表权限管理";          
            this.plBaseToolbar.ResumeLayout(false);
            this.plBaseToolbar.PerformLayout();
            this.plBaseWorkArea.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GWI.HIS.Windows.Controls.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView lstGroup;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TreeView TvReport;
    }
}