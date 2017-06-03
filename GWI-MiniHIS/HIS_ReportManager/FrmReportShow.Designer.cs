namespace HIS_ReportManager
{
    partial class FrmReportShow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportShow));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TvReport = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnPringtview = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.plBaseWorkArea.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Location = new System.Drawing.Point(0, 0);
            this.plBaseToolbar.Size = new System.Drawing.Size(1016, 0);
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
            this.plBaseWorkArea.Location = new System.Drawing.Point(0, 0);
            this.plBaseWorkArea.Size = new System.Drawing.Size(1016, 708);
            // 
            // plTitle
            // 
            this.plTitle.Size = new System.Drawing.Size(1016, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1016, 708);
            this.splitContainer1.SplitterDistance = 179;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(179, 708);
            this.panel1.TabIndex = 0;
            // 
            // TvReport
            // 
            this.TvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvReport.ImageIndex = 15;
            this.TvReport.ImageList = this.baseImageList;
            this.TvReport.Location = new System.Drawing.Point(0, 0);
            this.TvReport.Name = "TvReport";
            this.TvReport.SelectedImageIndex = 14;
            this.TvReport.Size = new System.Drawing.Size(179, 688);
            this.TvReport.TabIndex = 0;
            this.TvReport.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvReport_AfterSelect);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(833, 708);
            this.panel2.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(833, 708);
            this.panel4.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 26);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(833, 682);
            this.panel6.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnPringtview);
            this.panel5.Controls.Add(this.button1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(833, 26);
            this.panel5.TabIndex = 0;
            // 
            // btnPringtview
            // 
            this.btnPringtview.Location = new System.Drawing.Point(93, 3);
            this.btnPringtview.Name = "btnPringtview";
            this.btnPringtview.Size = new System.Drawing.Size(75, 23);
            this.btnPringtview.TabIndex = 1;
            this.btnPringtview.Text = "打印预览";
            this.btnPringtview.UseVisualStyleBackColor = true;
            this.btnPringtview.Click += new System.EventHandler(this.btnPringtview_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.linkLabel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(179, 20);
            this.panel3.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.TvReport);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 20);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(179, 688);
            this.panel7.TabIndex = 2;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(32, 8);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(77, 12);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "展开所有报表";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // FrmReportShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Name = "FrmReportShow";
            this.Text = "报表查询";
            this.Load += new System.EventHandler(this.FrmReportShow_Load);
            this.plBaseWorkArea.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView TvReport;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnPringtview;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}