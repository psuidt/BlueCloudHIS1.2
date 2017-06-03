namespace HIS_ZYNurseManager
{
    partial class FrmBedShow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBedShow));
            this.inPatientPanel1 = new GWI.HIS.Windows.Controls.Controls.InPatientPanel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.账单录入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.医嘱转抄ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.医嘱管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.医嘱执行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.病人出区ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNewBedAssign = new System.Windows.Forms.ToolStripButton();
            this.btnCancelBedAssgin = new System.Windows.Forms.ToolStripButton();
            this.btnModifyDoc = new System.Windows.Forms.ToolStripButton();
            this.btnTransferBed = new System.Windows.Forms.ToolStripButton();
            this.btnTransDept = new System.Windows.Forms.ToolStripButton();
            this.btnOut = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnCloseForm = new System.Windows.Forms.ToolStripButton();
            this.plBaseStatus.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
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
            this.plBaseStatus.Controls.Add(this.inPatientPanel1);
            this.plBaseStatus.Location = new System.Drawing.Point(0, 632);
            this.plBaseStatus.Size = new System.Drawing.Size(1016, 102);
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.listView1);
            this.plBaseWorkArea.Controls.Add(this.toolStrip1);
            this.plBaseWorkArea.Size = new System.Drawing.Size(1016, 569);
            // 
            // plTitle
            // 
            this.plTitle.Size = new System.Drawing.Size(1016, 34);
            // 
            // inPatientPanel1
            // 
            this.inPatientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.inPatientPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.inPatientPanel1.Font = new System.Drawing.Font("宋体", 9F);
            this.inPatientPanel1.InPaitent = null;
            this.inPatientPanel1.Location = new System.Drawing.Point(0, -13);
            this.inPatientPanel1.Name = "inPatientPanel1";
            this.inPatientPanel1.Size = new System.Drawing.Size(665, 115);
            this.inPatientPanel1.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(0, 29);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1016, 540);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.账单录入ToolStripMenuItem,
            this.toolStripSeparator1,
            this.医嘱转抄ToolStripMenuItem,
            this.医嘱管理ToolStripMenuItem,
            this.医嘱执行ToolStripMenuItem,
            this.toolStripSeparator3,
            this.病人出区ToolStripMenuItem,
            this.toolStripSeparator4,
            this.刷新ToolStripMenuItem,
            this.toolStripSeparator2,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 182);
            // 
            // 账单录入ToolStripMenuItem
            // 
            this.账单录入ToolStripMenuItem.Name = "账单录入ToolStripMenuItem";
            this.账单录入ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.账单录入ToolStripMenuItem.Text = "账单录入(&I)";
            this.账单录入ToolStripMenuItem.Click += new System.EventHandler(this.账单录入ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // 医嘱转抄ToolStripMenuItem
            // 
            this.医嘱转抄ToolStripMenuItem.Name = "医嘱转抄ToolStripMenuItem";
            this.医嘱转抄ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.医嘱转抄ToolStripMenuItem.Text = "医嘱转抄(&T)";
            this.医嘱转抄ToolStripMenuItem.Click += new System.EventHandler(this.医嘱转抄ToolStripMenuItem_Click);
            // 
            // 医嘱管理ToolStripMenuItem
            // 
            this.医嘱管理ToolStripMenuItem.Name = "医嘱管理ToolStripMenuItem";
            this.医嘱管理ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.医嘱管理ToolStripMenuItem.Text = "医嘱管理(&S)";
            this.医嘱管理ToolStripMenuItem.Click += new System.EventHandler(this.医嘱管理ToolStripMenuItem_Click);
            // 
            // 医嘱执行ToolStripMenuItem
            // 
            this.医嘱执行ToolStripMenuItem.Name = "医嘱执行ToolStripMenuItem";
            this.医嘱执行ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.医嘱执行ToolStripMenuItem.Text = "医嘱执行(&E)";
            this.医嘱执行ToolStripMenuItem.Click += new System.EventHandler(this.医嘱执行ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(133, 6);
            // 
            // 病人出区ToolStripMenuItem
            // 
            this.病人出区ToolStripMenuItem.Name = "病人出区ToolStripMenuItem";
            this.病人出区ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.病人出区ToolStripMenuItem.Text = "病人出区(&F)";
            this.病人出区ToolStripMenuItem.Click += new System.EventHandler(this.病人出区ToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(133, 6);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Image = global::HIS_ZYNurseManager.Properties.Resources.刷新;
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.刷新ToolStripMenuItem.Text = "刷新(&R)";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(133, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("退出ToolStripMenuItem.Image")));
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.退出ToolStripMenuItem.Text = "退出(&E)";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "0.bmp");
            this.imageList1.Images.SetKeyName(1, "1.bmp");
            this.imageList1.Images.SetKeyName(2, "2.bmp");
            this.imageList1.Images.SetKeyName(3, "3.bmp");
            this.imageList1.Images.SetKeyName(4, "18.bmp");
            this.imageList1.Images.SetKeyName(5, "4.bmp");
            this.imageList1.Images.SetKeyName(6, "5.bmp");
            this.imageList1.Images.SetKeyName(7, "6.bmp");
            this.imageList1.Images.SetKeyName(8, "7.bmp");
            this.imageList1.Images.SetKeyName(9, "8.bmp");
            this.imageList1.Images.SetKeyName(10, "9.bmp");
            this.imageList1.Images.SetKeyName(11, "10.bmp");
            this.imageList1.Images.SetKeyName(12, "11.bmp");
            this.imageList1.Images.SetKeyName(13, "12.bmp");
            this.imageList1.Images.SetKeyName(14, "13.bmp");
            this.imageList1.Images.SetKeyName(15, "14.bmp");
            this.imageList1.Images.SetKeyName(16, "15.bmp");
            this.imageList1.Images.SetKeyName(17, "16.bmp");
            this.imageList1.Images.SetKeyName(18, "17.bmp");
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewBedAssign,
            this.btnCancelBedAssgin,
            this.btnModifyDoc,
            this.btnTransferBed,
            this.btnTransDept,
            this.btnOut,
            this.btnRefresh,
            this.btnCloseForm});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1016, 29);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNewBedAssign
            // 
            this.btnNewBedAssign.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewBedAssign.Image = ((System.Drawing.Image)(resources.GetObject("btnNewBedAssign.Image")));
            this.btnNewBedAssign.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewBedAssign.Name = "btnNewBedAssign";
            this.btnNewBedAssign.Size = new System.Drawing.Size(107, 26);
            this.btnNewBedAssign.Text = "分配床位(F2)";
            this.btnNewBedAssign.Click += new System.EventHandler(this.btnNewBedAssign_Click);
            // 
            // btnCancelBedAssgin
            // 
            this.btnCancelBedAssgin.Font = new System.Drawing.Font("宋体", 10F);
            this.btnCancelBedAssgin.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelBedAssgin.Image")));
            this.btnCancelBedAssgin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelBedAssgin.Name = "btnCancelBedAssgin";
            this.btnCancelBedAssgin.Size = new System.Drawing.Size(111, 26);
            this.btnCancelBedAssgin.Text = "取消分床(F3)";
            this.btnCancelBedAssgin.Click += new System.EventHandler(this.btnCancelBedAssgin_Click);
            // 
            // btnModifyDoc
            // 
            this.btnModifyDoc.Font = new System.Drawing.Font("宋体", 10F);
            this.btnModifyDoc.Image = ((System.Drawing.Image)(resources.GetObject("btnModifyDoc.Image")));
            this.btnModifyDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModifyDoc.Name = "btnModifyDoc";
            this.btnModifyDoc.Size = new System.Drawing.Size(111, 26);
            this.btnModifyDoc.Text = "修改医生(F4)";
            this.btnModifyDoc.Click += new System.EventHandler(this.btnModifyDoc_Click);
            // 
            // btnTransferBed
            // 
            this.btnTransferBed.Font = new System.Drawing.Font("宋体", 10F);
            this.btnTransferBed.Image = ((System.Drawing.Image)(resources.GetObject("btnTransferBed.Image")));
            this.btnTransferBed.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTransferBed.Name = "btnTransferBed";
            this.btnTransferBed.Size = new System.Drawing.Size(111, 26);
            this.btnTransferBed.Text = "科内转床(F5)";
            this.btnTransferBed.Click += new System.EventHandler(this.btnTransferBed_Click);
            // 
            // btnTransDept
            // 
            this.btnTransDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTransDept.Image = global::HIS_ZYNurseManager.Properties.Resources.page_edit;
            this.btnTransDept.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTransDept.Name = "btnTransDept";
            this.btnTransDept.Size = new System.Drawing.Size(111, 26);
            this.btnTransDept.Text = "病人转科(F8)";
            this.btnTransDept.Visible = false;
            this.btnTransDept.Click += new System.EventHandler(this.btnTransDept_Click);
            // 
            // btnOut
            // 
            this.btnOut.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOut.Image = global::HIS_ZYNurseManager.Properties.Resources.page_edit;
            this.btnOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(111, 26);
            this.btnOut.Text = "病人出区(F9)";
            this.btnOut.ToolTipText = "病人出区(F9)";
            this.btnOut.Visible = false;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("宋体", 10F);
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(83, 26);
            this.btnRefresh.Text = "刷新(F6)";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Font = new System.Drawing.Font("宋体", 10F);
            this.btnCloseForm.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseForm.Image")));
            this.btnCloseForm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(111, 26);
            this.btnCloseForm.Text = "关闭窗口(F7)";
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // FrmBedShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.FormTitle = "床位管理";
            this.KeyPreview = true;
            this.Name = "FrmBedShow";
            this.Text = "床位管理";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBedShow_KeyDown);
            this.Controls.SetChildIndex(this.plTitle, 0);
            this.Controls.SetChildIndex(this.plBaseToolbar, 0);
            this.Controls.SetChildIndex(this.plBaseStatus, 0);
            this.Controls.SetChildIndex(this.plBaseWorkArea, 0);
            this.plBaseStatus.ResumeLayout(false);
            this.plBaseWorkArea.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GWI.HIS.Windows.Controls.Controls.InPatientPanel inPatientPanel1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 账单录入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 医嘱管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 医嘱执行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 病人出区ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNewBedAssign;
        private System.Windows.Forms.ToolStripButton btnCancelBedAssgin;
        private System.Windows.Forms.ToolStripButton btnModifyDoc;
        private System.Windows.Forms.ToolStripButton btnTransferBed;
        private System.Windows.Forms.ToolStripButton btnCloseForm;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripMenuItem 医嘱转抄ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnTransDept;
        private System.Windows.Forms.ToolStripButton btnOut;
    }
}