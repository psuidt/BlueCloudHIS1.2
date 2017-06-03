namespace HIS_ZYDocManager.日常业务
{
    partial class FrmDocMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDocMain));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.outlookBar1 = new UtilityLibrary.WinControls.OutlookBar();
            this.tabPageControl1 = new GWI.HIS.Windows.Controls.Controls.TabPageControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.医嘱录入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.检查申请ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.检验申请ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.治疗申请ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.手术申请ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LableFind = new System.Windows.Forms.LinkLabel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbbeds = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbts = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.inPatientPanel1 = new GWI.HIS.Windows.Controls.Controls.InPatientPanel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dirWatcher = new System.IO.FileSystemWatcher();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.plBaseWorkArea.SuspendLayout();
            this.tabPageControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dirWatcher)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plBaseToolbar.Size = new System.Drawing.Size(1016, 29);
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
            this.plBaseStatus.Location = new System.Drawing.Point(0, 734);
            this.plBaseStatus.Size = new System.Drawing.Size(1016, 0);
            this.plBaseStatus.Visible = false;
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.panel2);
            this.plBaseWorkArea.Controls.Add(this.panel1);
            this.plBaseWorkArea.Controls.Add(this.outlookBar1);
            this.plBaseWorkArea.Size = new System.Drawing.Size(1016, 671);
            // 
            // plTitle
            // 
            this.plTitle.Size = new System.Drawing.Size(1016, 34);
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
            // outlookBar1
            // 
            this.outlookBar1.AnimationSpeed = 20;
            this.outlookBar1.BackgroundBitmap = null;
            this.outlookBar1.BorderType = UtilityLibrary.WinControls.BorderType.None;
            this.outlookBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.outlookBar1.FlatArrowButtons = false;
            this.outlookBar1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.outlookBar1.LeftTopColor = System.Drawing.Color.Empty;
            this.outlookBar1.Location = new System.Drawing.Point(0, 0);
            this.outlookBar1.Name = "outlookBar1";
            this.outlookBar1.RightBottomColor = System.Drawing.Color.Empty;
            this.outlookBar1.Size = new System.Drawing.Size(105, 671);
            this.outlookBar1.TabIndex = 0;
            this.outlookBar1.Text = "outlookBar1";
            // 
            // tabPageControl1
            // 
            this.tabPageControl1.Controls.Add(this.tabPage1);
            this.tabPageControl1.Controls.Add(this.tabPage2);
            this.tabPageControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPageControl1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPageControl1.Location = new System.Drawing.Point(0, 0);
            this.tabPageControl1.Name = "tabPageControl1";
            this.tabPageControl1.SelectedIndex = 0;
            this.tabPageControl1.Size = new System.Drawing.Size(911, 556);
            this.tabPageControl1.TabIndex = 2;
            this.tabPageControl1.SelectedIndexChanged += new System.EventHandler(this.tabPageControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(903, 531);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "管辖内病人";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(897, 525);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.医嘱录入ToolStripMenuItem,
            this.检查申请ToolStripMenuItem,
            this.检验申请ToolStripMenuItem,
            this.治疗申请ToolStripMenuItem,
            this.手术申请ToolStripMenuItem,
            this.刷新ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 136);
            // 
            // 医嘱录入ToolStripMenuItem
            // 
            this.医嘱录入ToolStripMenuItem.Name = "医嘱录入ToolStripMenuItem";
            this.医嘱录入ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.医嘱录入ToolStripMenuItem.Text = "医嘱录入";
            this.医嘱录入ToolStripMenuItem.Click += new System.EventHandler(this.医嘱录入ToolStripMenuItem_Click);
            // 
            // 检查申请ToolStripMenuItem
            // 
            this.检查申请ToolStripMenuItem.Name = "检查申请ToolStripMenuItem";
            this.检查申请ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.检查申请ToolStripMenuItem.Text = "检查申请";
            this.检查申请ToolStripMenuItem.Click += new System.EventHandler(this.检查申请ToolStripMenuItem_Click);
            // 
            // 检验申请ToolStripMenuItem
            // 
            this.检验申请ToolStripMenuItem.Name = "检验申请ToolStripMenuItem";
            this.检验申请ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.检验申请ToolStripMenuItem.Text = "检验申请";
            this.检验申请ToolStripMenuItem.Click += new System.EventHandler(this.检验申请ToolStripMenuItem_Click);
            // 
            // 治疗申请ToolStripMenuItem
            // 
            this.治疗申请ToolStripMenuItem.Name = "治疗申请ToolStripMenuItem";
            this.治疗申请ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.治疗申请ToolStripMenuItem.Text = "治疗申请";
            this.治疗申请ToolStripMenuItem.Click += new System.EventHandler(this.治疗申请ToolStripMenuItem_Click);
            // 
            // 手术申请ToolStripMenuItem
            // 
            this.手术申请ToolStripMenuItem.Name = "手术申请ToolStripMenuItem";
            this.手术申请ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.手术申请ToolStripMenuItem.Text = "手术申请";
            this.手术申请ToolStripMenuItem.Click += new System.EventHandler(this.手术申请ToolStripMenuItem_Click);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.刷新ToolStripMenuItem.Text = "刷新病人";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(450, 216);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "本科所有病人";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.ContextMenuStrip = this.contextMenuStrip1;
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView2.LargeImageList = this.imageList1;
            this.listView2.Location = new System.Drawing.Point(3, 3);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(444, 210);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView2.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(105, 556);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(911, 115);
            this.panel1.TabIndex = 37;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.LableFind);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(669, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(242, 115);
            this.panel4.TabIndex = 49;
            // 
            // LableFind
            // 
            this.LableFind.AutoSize = true;
            this.LableFind.Location = new System.Drawing.Point(7, 3);
            this.LableFind.Name = "LableFind";
            this.LableFind.Size = new System.Drawing.Size(161, 14);
            this.LableFind.TabIndex = 4;
            this.LableFind.TabStop = true;
            this.LableFind.Text = "已开医嘱库存量不足提示";
            this.LableFind.Click += new System.EventHandler(this.LableFind_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lbbeds);
            this.panel6.Location = new System.Drawing.Point(0, 65);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(387, 50);
            this.panel6.TabIndex = 3;
            // 
            // lbbeds
            // 
            this.lbbeds.AutoSize = true;
            this.lbbeds.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbbeds.ForeColor = System.Drawing.Color.Red;
            this.lbbeds.Location = new System.Drawing.Point(0, 0);
            this.lbbeds.Name = "lbbeds";
            this.lbbeds.Size = new System.Drawing.Size(14, 14);
            this.lbbeds.TabIndex = 1;
            this.lbbeds.Text = "0";
            this.lbbeds.Visible = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lbts);
            this.panel5.Location = new System.Drawing.Point(0, 27);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(387, 36);
            this.panel5.TabIndex = 2;
            // 
            // lbts
            // 
            this.lbts.AutoSize = true;
            this.lbts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbts.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbts.Location = new System.Drawing.Point(0, 0);
            this.lbts.Name = "lbts";
            this.lbts.Size = new System.Drawing.Size(343, 28);
            this.lbts.TabIndex = 0;
            this.lbts.Text = "下列床号的病人有已开的医嘱，药房库存量不足，\r\n请医生进医嘱管理界面（背景色为蓝色的医嘱）停嘱：";
            this.lbts.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.inPatientPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(669, 115);
            this.panel3.TabIndex = 48;
            // 
            // inPatientPanel1
            // 
            this.inPatientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.inPatientPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.inPatientPanel1.Font = new System.Drawing.Font("宋体", 9F);
            this.inPatientPanel1.InPaitent = null;
            this.inPatientPanel1.Location = new System.Drawing.Point(0, 0);
            this.inPatientPanel1.Name = "inPatientPanel1";
            this.inPatientPanel1.Size = new System.Drawing.Size(665, 115);
            this.inPatientPanel1.TabIndex = 47;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "rtf";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "文本文件 (*.txt)|*.txt|RTF 文件 (*.rtf)|*.rtf|XML 文件 (*.xml)|*.xml|所有文件 (*.*)|*.*";
            this.openFileDialog1.Title = "打开";
            // 
            // dirWatcher
            // 
            this.dirWatcher.EnableRaisingEvents = true;
            this.dirWatcher.SynchronizingObject = this;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "文本文件 (*.txt)|*.txt|RTF 文件 (*.rtf)|*.rtf|XML 文件 (*.xml)|*.xml|所有文件 (*.*)|*.*";
            this.saveFileDialog1.Title = "另存为";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabPageControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(105, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(911, 556);
            this.panel2.TabIndex = 38;
            // 
            // FrmDocMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.FormTitle = "住院医生工作站";
            this.Name = "FrmDocMain";
            this.Text = "医生站首页";
            this.Controls.SetChildIndex(this.plTitle, 0);
            this.Controls.SetChildIndex(this.plBaseToolbar, 0);
            this.Controls.SetChildIndex(this.plBaseStatus, 0);
            this.Controls.SetChildIndex(this.plBaseWorkArea, 0);
            this.plBaseWorkArea.ResumeLayout(false);
            this.tabPageControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dirWatcher)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private UtilityLibrary.WinControls.OutlookBar outlookBar1;
        private GWI.HIS.Windows.Controls.Controls.TabPageControl tabPageControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.IO.FileSystemWatcher dirWatcher;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 医嘱录入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 检查申请ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 检验申请ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 治疗申请ToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private GWI.HIS.Windows.Controls.Controls.InPatientPanel inPatientPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.Label lbts;
        private System.Windows.Forms.Label lbbeds;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.LinkLabel LableFind;
        private System.Windows.Forms.ToolStripMenuItem 手术申请ToolStripMenuItem;
    }
}