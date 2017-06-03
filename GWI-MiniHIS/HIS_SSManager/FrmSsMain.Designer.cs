namespace HIS_SSManager
{
    partial class FrmSsMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSsMain));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.手术安排ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.术后补录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.账单补录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消安排ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabSsPlist = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.toolStrip1 = new GWI.HIS.Windows.Controls.ToolStrip();
            this.tbArrange = new System.Windows.Forms.ToolStripButton();
            this.tbPres = new System.Windows.Forms.ToolStripButton();
            this.tbAfter = new System.Windows.Forms.ToolStripButton();
            this.tbCancelArrange = new System.Windows.Forms.ToolStripButton();
            this.tbBrush = new System.Windows.Forms.ToolStripButton();
            this.tbQuit = new System.Windows.Forms.ToolStripButton();
            this.inPatientPanel1 = new GWI.HIS.Windows.Controls.Controls.InPatientPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.plBaseWorkArea.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabSsPlist.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Size = new System.Drawing.Size(1016, 10);
            this.plBaseToolbar.Visible = false;
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
            this.plBaseStatus.Location = new System.Drawing.Point(0, 724);
            this.plBaseStatus.Size = new System.Drawing.Size(1016, 10);
            this.plBaseStatus.Visible = false;
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.panel2);
            this.plBaseWorkArea.Controls.Add(this.panel1);
            this.plBaseWorkArea.Location = new System.Drawing.Point(0, 44);
            this.plBaseWorkArea.Size = new System.Drawing.Size(1016, 680);
            // 
            // plTitle
            // 
            this.plTitle.Size = new System.Drawing.Size(1016, 34);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.手术安排ToolStripMenuItem,
            this.术后补录ToolStripMenuItem,
            this.账单补录ToolStripMenuItem,
            this.取消安排ToolStripMenuItem,
            this.刷新ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 114);
            // 
            // 手术安排ToolStripMenuItem
            // 
            this.手术安排ToolStripMenuItem.Name = "手术安排ToolStripMenuItem";
            this.手术安排ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.手术安排ToolStripMenuItem.Text = "手术安排";
            this.手术安排ToolStripMenuItem.Click += new System.EventHandler(this.手术安排ToolStripMenuItem_Click);
            // 
            // 术后补录ToolStripMenuItem
            // 
            this.术后补录ToolStripMenuItem.Name = "术后补录ToolStripMenuItem";
            this.术后补录ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.术后补录ToolStripMenuItem.Text = "术后补录";
            this.术后补录ToolStripMenuItem.Visible = false;
            this.术后补录ToolStripMenuItem.Click += new System.EventHandler(this.术后补录ToolStripMenuItem_Click);
            // 
            // 账单补录ToolStripMenuItem
            // 
            this.账单补录ToolStripMenuItem.Name = "账单补录ToolStripMenuItem";
            this.账单补录ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.账单补录ToolStripMenuItem.Text = "账单补录";
            this.账单补录ToolStripMenuItem.Visible = false;
            this.账单补录ToolStripMenuItem.Click += new System.EventHandler(this.账单补录ToolStripMenuItem_Click);
            // 
            // 取消安排ToolStripMenuItem
            // 
            this.取消安排ToolStripMenuItem.Name = "取消安排ToolStripMenuItem";
            this.取消安排ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.取消安排ToolStripMenuItem.Text = "取消安排";
            this.取消安排ToolStripMenuItem.Visible = false;
            this.取消安排ToolStripMenuItem.Click += new System.EventHandler(this.取消安排ToolStripMenuItem_Click);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "28.bmp");
            this.imageList1.Images.SetKeyName(1, "47.bmp");
            this.imageList1.Images.SetKeyName(2, "1.bmp");
            this.imageList1.Images.SetKeyName(3, "2.bmp");
            this.imageList1.Images.SetKeyName(4, "74.bmp");
            this.imageList1.Images.SetKeyName(5, "28.bmp");
            this.imageList1.Images.SetKeyName(6, "6.bmp");
            this.imageList1.Images.SetKeyName(7, "7.bmp");
            this.imageList1.Images.SetKeyName(8, "12.bmp");
            this.imageList1.Images.SetKeyName(9, "20.bmp");
            this.imageList1.Images.SetKeyName(10, "29.bmp");
            this.imageList1.Images.SetKeyName(11, "30.bmp");
            this.imageList1.Images.SetKeyName(12, "36.bmp");
            this.imageList1.Images.SetKeyName(13, "37.bmp");
            this.imageList1.Images.SetKeyName(14, "38.bmp");
            this.imageList1.Images.SetKeyName(15, "49.bmp");
            this.imageList1.Images.SetKeyName(16, "50.bmp");
            this.imageList1.Images.SetKeyName(17, "51.bmp");
            this.imageList1.Images.SetKeyName(18, "52.bmp");
            this.imageList1.Images.SetKeyName(19, "54.bmp");
            this.imageList1.Images.SetKeyName(20, "57.bmp");
            this.imageList1.Images.SetKeyName(21, "58.bmp");
            this.imageList1.Images.SetKeyName(22, "60.bmp");
            this.imageList1.Images.SetKeyName(23, "61.bmp");
            this.imageList1.Images.SetKeyName(24, "62.bmp");
            this.imageList1.Images.SetKeyName(25, "67.bmp");
            this.imageList1.Images.SetKeyName(26, "70.bmp");
            this.imageList1.Images.SetKeyName(27, "0.bmp");
            // 
            // tabSsPlist
            // 
            this.tabSsPlist.Controls.Add(this.tabPage1);
            this.tabSsPlist.Controls.Add(this.tabPage2);
            this.tabSsPlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSsPlist.Location = new System.Drawing.Point(0, 0);
            this.tabSsPlist.Name = "tabSsPlist";
            this.tabSsPlist.SelectedIndex = 0;
            this.tabSsPlist.Size = new System.Drawing.Size(1016, 340);
            this.tabSsPlist.TabIndex = 0;
            this.tabSsPlist.SelectedIndexChanged += new System.EventHandler(this.tabSsPlist_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1008, 315);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "未安排病人";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1002, 309);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(555, 315);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "已安排病人";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.ContextMenuStrip = this.contextMenuStrip1;
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.LargeImageList = this.imageList1;
            this.listView2.Location = new System.Drawing.Point(3, 3);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(549, 309);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.toolStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStrip1.BackgroundImage")));
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbArrange,
            this.tbPres,
            this.tbAfter,
            this.tbCancelArrange,
            this.tbBrush,
            this.tbQuit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1016, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbArrange
            // 
            this.tbArrange.Image = global::HIS_SSManager.Properties.Resources.设置;
            this.tbArrange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbArrange.Name = "tbArrange";
            this.tbArrange.Size = new System.Drawing.Size(119, 22);
            this.tbArrange.Text = "手术安排(F2)";
            this.tbArrange.Click += new System.EventHandler(this.tbArrange_Click);
            // 
            // tbPres
            // 
            this.tbPres.Image = global::HIS_SSManager.Properties.Resources.打印;
            this.tbPres.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPres.Name = "tbPres";
            this.tbPres.Size = new System.Drawing.Size(119, 22);
            this.tbPres.Text = "账单补录(F4)";
            this.tbPres.Visible = false;
            this.tbPres.Click += new System.EventHandler(this.tbPres_Click);
            // 
            // tbAfter
            // 
            this.tbAfter.Image = global::HIS_SSManager.Properties.Resources.保存;
            this.tbAfter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbAfter.Name = "tbAfter";
            this.tbAfter.Size = new System.Drawing.Size(119, 22);
            this.tbAfter.Text = "术后补录(F3)";
            this.tbAfter.Visible = false;
            this.tbAfter.Click += new System.EventHandler(this.tbAfter_Click);
            // 
            // tbCancelArrange
            // 
            this.tbCancelArrange.Image = global::HIS_SSManager.Properties.Resources.剪切;
            this.tbCancelArrange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbCancelArrange.Name = "tbCancelArrange";
            this.tbCancelArrange.Size = new System.Drawing.Size(119, 22);
            this.tbCancelArrange.Text = "取消安排(F5)";
            this.tbCancelArrange.Visible = false;
            this.tbCancelArrange.Click += new System.EventHandler(this.tbCancelArrange_Click);
            // 
            // tbBrush
            // 
            this.tbBrush.Image = global::HIS_SSManager.Properties.Resources.action_refresh;
            this.tbBrush.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbBrush.Name = "tbBrush";
            this.tbBrush.Size = new System.Drawing.Size(89, 22);
            this.tbBrush.Text = "刷新(F6)";
            this.tbBrush.Click += new System.EventHandler(this.tbBrush_Click);
            // 
            // tbQuit
            // 
            this.tbQuit.Image = global::HIS_SSManager.Properties.Resources.退出;
            this.tbQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbQuit.Name = "tbQuit";
            this.tbQuit.Size = new System.Drawing.Size(89, 22);
            this.tbQuit.Text = "退出(F7)";
            this.tbQuit.Click += new System.EventHandler(this.tbQuit_Click);
            // 
            // inPatientPanel1
            // 
            this.inPatientPanel1.AutoSize = true;
            this.inPatientPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.inPatientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.inPatientPanel1.Font = new System.Drawing.Font("宋体", 9F);
            this.inPatientPanel1.InPaitent = null;
            this.inPatientPanel1.Location = new System.Drawing.Point(3, 28);
            this.inPatientPanel1.Name = "inPatientPanel1";
            this.inPatientPanel1.Size = new System.Drawing.Size(665, 115);
            this.inPatientPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabSsPlist);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 340);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Controls.Add(this.inPatientPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 340);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1016, 340);
            this.panel2.TabIndex = 4;
            // 
            // FrmSsMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.FormTitle = "手术麻醉系统";
            this.KeyPreview = true;
            this.Name = "FrmSsMain";
            this.Text = "主界面";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSsMain_KeyDown);
            this.Controls.SetChildIndex(this.plTitle, 0);
            this.Controls.SetChildIndex(this.plBaseToolbar, 0);
            this.Controls.SetChildIndex(this.plBaseStatus, 0);
            this.Controls.SetChildIndex(this.plBaseWorkArea, 0);
            this.plBaseWorkArea.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabSsPlist.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 手术安排ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 术后补录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 账单补录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消安排ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private GWI.HIS.Windows.Controls.Controls.InPatientPanel inPatientPanel1;
        private GWI.HIS.Windows.Controls.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbArrange;
        private System.Windows.Forms.ToolStripButton tbPres;
        private System.Windows.Forms.ToolStripButton tbAfter;
        private System.Windows.Forms.ToolStripButton tbCancelArrange;
        private System.Windows.Forms.ToolStripButton tbBrush;
        private System.Windows.Forms.ToolStripButton tbQuit;
        private System.Windows.Forms.TabControl tabSsPlist;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;

    }
}