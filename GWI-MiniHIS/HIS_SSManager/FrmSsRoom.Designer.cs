namespace HIS_SSManager
{
    partial class FrmSsRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSsRoom));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tvRoom = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新增房间ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除房间ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvBeds = new System.Windows.Forms.ListView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新增ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new GWI.HIS.Windows.Controls.ToolStrip();
            this.tbAdd = new System.Windows.Forms.ToolStripButton();
            this.tbDel = new System.Windows.Forms.ToolStripButton();
            this.tbBrush = new System.Windows.Forms.ToolStripButton();
            this.tbQuit = new System.Windows.Forms.ToolStripButton();
            this.plBaseWorkArea.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
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
            this.plBaseStatus.Location = new System.Drawing.Point(0, 708);
            this.plBaseStatus.Size = new System.Drawing.Size(1016, 26);
            this.plBaseStatus.Visible = false;
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.panel2);
            this.plBaseWorkArea.Controls.Add(this.panel1);
            this.plBaseWorkArea.Size = new System.Drawing.Size(1016, 645);
            // 
            // plTitle
            // 
            this.plTitle.Size = new System.Drawing.Size(1016, 34);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tvRoom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(214, 645);
            this.panel1.TabIndex = 0;
            // 
            // tvRoom
            // 
            this.tvRoom.ContextMenuStrip = this.contextMenuStrip1;
            this.tvRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvRoom.ImageIndex = 0;
            this.tvRoom.ImageList = this.baseImageList;
            this.tvRoom.Location = new System.Drawing.Point(0, 0);
            this.tvRoom.Name = "tvRoom";
            this.tvRoom.SelectedImageIndex = 0;
            this.tvRoom.Size = new System.Drawing.Size(214, 645);
            this.tvRoom.TabIndex = 0;
            this.tvRoom.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvRoom_AfterSelect);
            this.tvRoom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvRoom_MouseDown);
            this.tvRoom.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvRoom_AfterExpand);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增房间ToolStripMenuItem,
            this.删除房间ToolStripMenuItem,
            this.刷新ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 70);
            // 
            // 新增房间ToolStripMenuItem
            // 
            this.新增房间ToolStripMenuItem.Name = "新增房间ToolStripMenuItem";
            this.新增房间ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.新增房间ToolStripMenuItem.Text = "新增房间";
            this.新增房间ToolStripMenuItem.Click += new System.EventHandler(this.新增房间ToolStripMenuItem_Click);
            // 
            // 删除房间ToolStripMenuItem
            // 
            this.删除房间ToolStripMenuItem.Name = "删除房间ToolStripMenuItem";
            this.删除房间ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.删除房间ToolStripMenuItem.Text = "删除房间";
            this.删除房间ToolStripMenuItem.Click += new System.EventHandler(this.删除房间ToolStripMenuItem_Click);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lvBeds);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(214, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(802, 645);
            this.panel2.TabIndex = 1;
            // 
            // lvBeds
            // 
            this.lvBeds.ContextMenuStrip = this.contextMenuStrip2;
            this.lvBeds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvBeds.LargeImageList = this.imageList1;
            this.lvBeds.Location = new System.Drawing.Point(0, 35);
            this.lvBeds.Name = "lvBeds";
            this.lvBeds.Size = new System.Drawing.Size(802, 610);
            this.lvBeds.TabIndex = 1;
            this.lvBeds.UseCompatibleStateImageBehavior = false;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.刷新ToolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(95, 70);
            // 
            // 新增ToolStripMenuItem
            // 
            this.新增ToolStripMenuItem.Name = "新增ToolStripMenuItem";
            this.新增ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.新增ToolStripMenuItem.Text = "新增";
            this.新增ToolStripMenuItem.Click += new System.EventHandler(this.新增ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 刷新ToolStripMenuItem1
            // 
            this.刷新ToolStripMenuItem1.Name = "刷新ToolStripMenuItem1";
            this.刷新ToolStripMenuItem1.Size = new System.Drawing.Size(94, 22);
            this.刷新ToolStripMenuItem1.Text = "刷新";
            this.刷新ToolStripMenuItem1.Click += new System.EventHandler(this.刷新ToolStripMenuItem1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "28.bmp");
            this.imageList1.Images.SetKeyName(1, "47.bmp");
            this.imageList1.Images.SetKeyName(2, "0.bmp");
            this.imageList1.Images.SetKeyName(3, "1.bmp");
            this.imageList1.Images.SetKeyName(4, "2.bmp");
            this.imageList1.Images.SetKeyName(5, "74.bmp");
            this.imageList1.Images.SetKeyName(6, "28.bmp");
            this.imageList1.Images.SetKeyName(7, "6.bmp");
            this.imageList1.Images.SetKeyName(8, "7.bmp");
            this.imageList1.Images.SetKeyName(9, "12.bmp");
            this.imageList1.Images.SetKeyName(10, "20.bmp");
            this.imageList1.Images.SetKeyName(11, "29.bmp");
            this.imageList1.Images.SetKeyName(12, "30.bmp");
            this.imageList1.Images.SetKeyName(13, "36.bmp");
            this.imageList1.Images.SetKeyName(14, "37.bmp");
            this.imageList1.Images.SetKeyName(15, "38.bmp");
            this.imageList1.Images.SetKeyName(16, "49.bmp");
            this.imageList1.Images.SetKeyName(17, "50.bmp");
            this.imageList1.Images.SetKeyName(18, "51.bmp");
            this.imageList1.Images.SetKeyName(19, "52.bmp");
            this.imageList1.Images.SetKeyName(20, "54.bmp");
            this.imageList1.Images.SetKeyName(21, "57.bmp");
            this.imageList1.Images.SetKeyName(22, "58.bmp");
            this.imageList1.Images.SetKeyName(23, "60.bmp");
            this.imageList1.Images.SetKeyName(24, "61.bmp");
            this.imageList1.Images.SetKeyName(25, "62.bmp");
            this.imageList1.Images.SetKeyName(26, "67.bmp");
            this.imageList1.Images.SetKeyName(27, "70.bmp");
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.toolStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(802, 35);
            this.panel3.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.toolStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStrip1.BackgroundImage")));
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbAdd,
            this.tbDel,
            this.tbBrush,
            this.tbQuit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(802, 35);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbAdd
            // 
            this.tbAdd.Image = global::HIS_SSManager.Properties.Resources.icon_network;
            this.tbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Size = new System.Drawing.Size(89, 32);
            this.tbAdd.Text = "新增(F2)";
            this.tbAdd.Click += new System.EventHandler(this.tbAdd_Click);
            // 
            // tbDel
            // 
            this.tbDel.Image = global::HIS_SSManager.Properties.Resources.table_delete;
            this.tbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbDel.Name = "tbDel";
            this.tbDel.Size = new System.Drawing.Size(89, 32);
            this.tbDel.Text = "删除(F3)";
            this.tbDel.Click += new System.EventHandler(this.tbDel_Click);
            // 
            // tbBrush
            // 
            this.tbBrush.Image = global::HIS_SSManager.Properties.Resources.page_refresh;
            this.tbBrush.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbBrush.Name = "tbBrush";
            this.tbBrush.Size = new System.Drawing.Size(89, 32);
            this.tbBrush.Text = "刷新(F4)";
            this.tbBrush.Click += new System.EventHandler(this.tbBrush_Click);
            // 
            // tbQuit
            // 
            this.tbQuit.Image = global::HIS_SSManager.Properties.Resources.退出;
            this.tbQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbQuit.Name = "tbQuit";
            this.tbQuit.Size = new System.Drawing.Size(89, 32);
            this.tbQuit.Text = "退出(F5)";
            this.tbQuit.Click += new System.EventHandler(this.tbQuit_Click);
            // 
            // FrmSsRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.FormTitle = "手术室房间台次维护";
            this.KeyPreview = true;
            this.Name = "FrmSsRoom";
            this.Text = "手术室房间台次维护";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSsRoom_KeyDown);
            this.Controls.SetChildIndex(this.plTitle, 0);
            this.Controls.SetChildIndex(this.plBaseToolbar, 0);
            this.Controls.SetChildIndex(this.plBaseStatus, 0);
            this.Controls.SetChildIndex(this.plBaseWorkArea, 0);
            this.plBaseWorkArea.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView tvRoom;
        private System.Windows.Forms.ListView lvBeds;
        private System.Windows.Forms.Panel panel3;
        private GWI.HIS.Windows.Controls.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbAdd;
        private System.Windows.Forms.ToolStripButton tbDel;
        private System.Windows.Forms.ToolStripButton tbBrush;
        private System.Windows.Forms.ToolStripButton tbQuit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新增房间ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除房间ToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 新增ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem1;
    }
}