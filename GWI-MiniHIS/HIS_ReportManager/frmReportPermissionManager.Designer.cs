namespace HIS_ReportManager
{
    partial class frmReportPermissionManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportPermissionManager));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tvGroup = new System.Windows.Forms.TreeView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lvReportRelation = new System.Windows.Forms.ListView();
            this.hospital = new System.Windows.Forms.ColumnHeader();
            this.group = new System.Windows.Forms.ColumnHeader();
            this.report = new System.Windows.Forms.ColumnHeader();
            this.isglobal = new System.Windows.Forms.ColumnHeader();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sdf = new System.Windows.Forms.GroupBox();
            this.backselect = new System.Windows.Forms.LinkLabel();
            this.selectall = new System.Windows.Forms.LinkLabel();
            this.cbIsGlobal = new System.Windows.Forms.CheckBox();
            this.btnBrush = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAlloc = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvReport = new System.Windows.Forms.TreeView();
            this.plBaseWorkArea.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.sdf.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
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
            this.plBaseWorkArea.Controls.Add(this.splitContainer1);
            this.plBaseWorkArea.Size = new System.Drawing.Size(1016, 645);
            // 
            // plTitle
            // 
            this.plTitle.Size = new System.Drawing.Size(1016, 34);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1016, 645);
            this.splitContainer1.SplitterDistance = 218;
            this.splitContainer1.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tvGroup);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 645);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户组";
            // 
            // tvGroup
            // 
            this.tvGroup.CheckBoxes = true;
            this.tvGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvGroup.Location = new System.Drawing.Point(3, 17);
            this.tvGroup.Name = "tvGroup";
            this.tvGroup.Size = new System.Drawing.Size(212, 625);
            this.tvGroup.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 318);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(794, 327);
            this.panel3.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lvReportRelation);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(794, 327);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " 报表权限关系";
            // 
            // lvReportRelation
            // 
            this.lvReportRelation.CheckBoxes = true;
            this.lvReportRelation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hospital,
            this.group,
            this.report,
            this.isglobal});
            this.lvReportRelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvReportRelation.FullRowSelect = true;
            this.lvReportRelation.GridLines = true;
            this.lvReportRelation.Location = new System.Drawing.Point(3, 17);
            this.lvReportRelation.Name = "lvReportRelation";
            this.lvReportRelation.Size = new System.Drawing.Size(788, 307);
            this.lvReportRelation.TabIndex = 0;
            this.lvReportRelation.UseCompatibleStateImageBehavior = false;
            this.lvReportRelation.View = System.Windows.Forms.View.Details;
            // 
            // hospital
            // 
            this.hospital.Text = "医院名称";
            this.hospital.Width = 200;
            // 
            // group
            // 
            this.group.Text = "用户组";
            this.group.Width = 180;
            // 
            // report
            // 
            this.report.Text = "报表模板";
            this.report.Width = 250;
            // 
            // isglobal
            // 
            this.isglobal.Text = "全局查看";
            this.isglobal.Width = 80;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.sdf);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 268);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 50);
            this.panel2.TabIndex = 1;
            // 
            // sdf
            // 
            this.sdf.Controls.Add(this.backselect);
            this.sdf.Controls.Add(this.selectall);
            this.sdf.Controls.Add(this.cbIsGlobal);
            this.sdf.Controls.Add(this.btnBrush);
            this.sdf.Controls.Add(this.btnClose);
            this.sdf.Controls.Add(this.btnDel);
            this.sdf.Controls.Add(this.btnAlloc);
            this.sdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sdf.Location = new System.Drawing.Point(0, 0);
            this.sdf.Name = "sdf";
            this.sdf.Size = new System.Drawing.Size(794, 50);
            this.sdf.TabIndex = 0;
            this.sdf.TabStop = false;
            this.sdf.Text = "用户操作";
            // 
            // backselect
            // 
            this.backselect.AutoSize = true;
            this.backselect.Location = new System.Drawing.Point(417, 30);
            this.backselect.Name = "backselect";
            this.backselect.Size = new System.Drawing.Size(29, 12);
            this.backselect.TabIndex = 6;
            this.backselect.TabStop = true;
            this.backselect.Text = "反选";
            this.backselect.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.backselect_LinkClicked);
         
            // 
            // selectall
            // 
            this.selectall.AutoSize = true;
            this.selectall.Location = new System.Drawing.Point(417, 14);
            this.selectall.Name = "selectall";
            this.selectall.Size = new System.Drawing.Size(29, 12);
            this.selectall.TabIndex = 5;
            this.selectall.TabStop = true;
            this.selectall.Text = "全选";
            this.selectall.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.selectall_LinkClicked);
           
            // 
            // cbIsGlobal
            // 
            this.cbIsGlobal.AutoSize = true;
            this.cbIsGlobal.Location = new System.Drawing.Point(475, 24);
            this.cbIsGlobal.Name = "cbIsGlobal";
            this.cbIsGlobal.Size = new System.Drawing.Size(72, 16);
            this.cbIsGlobal.TabIndex = 4;
            this.cbIsGlobal.Text = "是否全局";
            this.cbIsGlobal.UseVisualStyleBackColor = true;
            // 
            // btnBrush
            // 
            this.btnBrush.Location = new System.Drawing.Point(218, 21);
            this.btnBrush.Name = "btnBrush";
            this.btnBrush.Size = new System.Drawing.Size(75, 23);
            this.btnBrush.TabIndex = 3;
            this.btnBrush.Text = "刷    新";
            this.btnBrush.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrush.UseVisualStyleBackColor = true;
            this.btnBrush.Click += new System.EventHandler(this.btnBrush_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(320, 21);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关    闭";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(114, 21);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "删除权限";
            this.btnDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAlloc
            // 
            this.btnAlloc.Location = new System.Drawing.Point(13, 21);
            this.btnAlloc.Name = "btnAlloc";
            this.btnAlloc.Size = new System.Drawing.Size(75, 23);
            this.btnAlloc.TabIndex = 0;
            this.btnAlloc.Text = "分配权限";
            this.btnAlloc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAlloc.UseVisualStyleBackColor = true;
            this.btnAlloc.Click += new System.EventHandler(this.btnAlloc_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 268);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvReport);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(794, 268);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "报表模板";
            // 
            // lvReport
            // 
            this.lvReport.CheckBoxes = true;
            this.lvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvReport.Location = new System.Drawing.Point(3, 17);
            this.lvReport.Name = "lvReport";
            this.lvReport.Size = new System.Drawing.Size(788, 248);
            this.lvReport.TabIndex = 5;
            // 
            // frmReportPermissionManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.FormTitle = "报表权限配置";
            this.Name = "frmReportPermissionManager";
            this.Text = "报表权限配置";
            this.Load += new System.EventHandler(this.frmReportPermissionManager_Load);
            this.plBaseWorkArea.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.sdf.ResumeLayout(false);
            this.sdf.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox sdf;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAlloc;
        private System.Windows.Forms.TreeView tvGroup;
        private System.Windows.Forms.Button btnBrush;
        private System.Windows.Forms.ListView lvReportRelation;
        private System.Windows.Forms.ColumnHeader hospital;
        private System.Windows.Forms.ColumnHeader group;
        private System.Windows.Forms.ColumnHeader report;
        private System.Windows.Forms.TreeView lvReport;
        private System.Windows.Forms.ColumnHeader isglobal;
        private System.Windows.Forms.CheckBox cbIsGlobal;
        private System.Windows.Forms.LinkLabel backselect;
        private System.Windows.Forms.LinkLabel selectall;


    }
}