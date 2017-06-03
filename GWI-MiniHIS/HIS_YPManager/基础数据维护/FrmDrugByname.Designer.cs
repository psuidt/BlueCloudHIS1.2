namespace HIS_YPManager
{
    partial class FrmDrugByname
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDrugByname));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtWBM = new System.Windows.Forms.TextBox();
            this.lblWBM = new System.Windows.Forms.Label();
            this.txtPYM = new System.Windows.Forms.TextBox();
            this.lblPYM = new System.Windows.Forms.Label();
            this.txtByname = new System.Windows.Forms.TextBox();
            this.lblByname = new System.Windows.Forms.Label();
            this.tsrDrugByName = new GWI.HIS.Windows.Controls.ToolStrip();
            this.tsrbtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tsrbtnDel = new System.Windows.Forms.ToolStripButton();
            this.tsrbtnUpdate = new System.Windows.Forms.ToolStripButton();
            this.tsrbtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsrbtnQuit = new System.Windows.Forms.ToolStripButton();
            this.dgrdByName = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tsrDrugByName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdByName)).BeginInit();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.BackColor = System.Drawing.SystemColors.Control;
            this.plBaseToolbar.Controls.Add(this.tsrDrugByName);
            this.plBaseToolbar.Size = new System.Drawing.Size(542, 29);
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
            this.plBaseStatus.Location = new System.Drawing.Point(0, 304);
            this.plBaseStatus.Size = new System.Drawing.Size(542, 26);
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.dgrdByName);
            this.plBaseWorkArea.Controls.Add(this.panel3);
            this.plBaseWorkArea.Size = new System.Drawing.Size(542, 241);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.txtWBM);
            this.panel3.Controls.Add(this.lblWBM);
            this.panel3.Controls.Add(this.txtPYM);
            this.panel3.Controls.Add(this.lblPYM);
            this.panel3.Controls.Add(this.txtByname);
            this.panel3.Controls.Add(this.lblByname);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(542, 35);
            this.panel3.TabIndex = 1;
            // 
            // txtWBM
            // 
            this.txtWBM.BackColor = System.Drawing.Color.White;
            this.txtWBM.Location = new System.Drawing.Point(451, 6);
            this.txtWBM.Name = "txtWBM";
            this.txtWBM.Size = new System.Drawing.Size(86, 21);
            this.txtWBM.TabIndex = 2;
            // 
            // lblWBM
            // 
            this.lblWBM.AutoSize = true;
            this.lblWBM.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWBM.Location = new System.Drawing.Point(396, 9);
            this.lblWBM.Name = "lblWBM";
            this.lblWBM.Size = new System.Drawing.Size(49, 14);
            this.lblWBM.TabIndex = 5;
            this.lblWBM.Text = "五笔码";
            // 
            // txtPYM
            // 
            this.txtPYM.BackColor = System.Drawing.Color.White;
            this.txtPYM.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPYM.Location = new System.Drawing.Point(305, 6);
            this.txtPYM.Name = "txtPYM";
            this.txtPYM.Size = new System.Drawing.Size(86, 23);
            this.txtPYM.TabIndex = 1;
            // 
            // lblPYM
            // 
            this.lblPYM.AutoSize = true;
            this.lblPYM.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPYM.Location = new System.Drawing.Point(255, 9);
            this.lblPYM.Name = "lblPYM";
            this.lblPYM.Size = new System.Drawing.Size(49, 14);
            this.lblPYM.TabIndex = 4;
            this.lblPYM.Text = "拼音码";
            // 
            // txtByname
            // 
            this.txtByname.BackColor = System.Drawing.Color.White;
            this.txtByname.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtByname.Location = new System.Drawing.Point(71, 6);
            this.txtByname.MaxLength = 50;
            this.txtByname.Name = "txtByname";
            this.txtByname.Size = new System.Drawing.Size(181, 23);
            this.txtByname.TabIndex = 0;
            this.txtByname.TextChanged += new System.EventHandler(this.txtByname_TextChanged);
            this.txtByname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtByname_KeyDown);
            // 
            // lblByname
            // 
            this.lblByname.AutoSize = true;
            this.lblByname.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblByname.Location = new System.Drawing.Point(3, 10);
            this.lblByname.Name = "lblByname";
            this.lblByname.Size = new System.Drawing.Size(63, 14);
            this.lblByname.TabIndex = 3;
            this.lblByname.Text = "商品别名";
            // 
            // tsrDrugByName
            // 
            this.tsrDrugByName.AutoSize = false;
            this.tsrDrugByName.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsrDrugByName.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsrDrugByName.BackgroundImage")));
            this.tsrDrugByName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsrDrugByName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsrDrugByName.Font = new System.Drawing.Font("宋体", 10F);
            this.tsrDrugByName.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsrbtnAdd,
            this.tsrbtnDel,
            this.tsrbtnUpdate,
            this.tsrbtnSave,
            this.tsrbtnQuit});
            this.tsrDrugByName.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tsrDrugByName.Location = new System.Drawing.Point(0, 0);
            this.tsrDrugByName.Name = "tsrDrugByName";
            this.tsrDrugByName.Size = new System.Drawing.Size(542, 29);
            this.tsrDrugByName.TabIndex = 0;
            this.tsrDrugByName.Text = "tsrByName";
            // 
            // tsrbtnAdd
            // 
            this.tsrbtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsrbtnAdd.Image")));
            this.tsrbtnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsrbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsrbtnAdd.Name = "tsrbtnAdd";
            this.tsrbtnAdd.Size = new System.Drawing.Size(83, 26);
            this.tsrbtnAdd.Text = "新增(F2)";
            this.tsrbtnAdd.Click += new System.EventHandler(this.tsrbtnAdd_Click);
            // 
            // tsrbtnDel
            // 
            this.tsrbtnDel.Image = ((System.Drawing.Image)(resources.GetObject("tsrbtnDel.Image")));
            this.tsrbtnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsrbtnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsrbtnDel.Name = "tsrbtnDel";
            this.tsrbtnDel.Size = new System.Drawing.Size(83, 26);
            this.tsrbtnDel.Text = "删除(F3)";
            this.tsrbtnDel.Click += new System.EventHandler(this.tsrbtnDel_Click);
            // 
            // tsrbtnUpdate
            // 
            this.tsrbtnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tsrbtnUpdate.Image")));
            this.tsrbtnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsrbtnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsrbtnUpdate.Name = "tsrbtnUpdate";
            this.tsrbtnUpdate.Size = new System.Drawing.Size(83, 26);
            this.tsrbtnUpdate.Text = "修改(F4)";
            this.tsrbtnUpdate.Click += new System.EventHandler(this.tsrbtnUpdate_Click);
            // 
            // tsrbtnSave
            // 
            this.tsrbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsrbtnSave.Image")));
            this.tsrbtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsrbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsrbtnSave.Name = "tsrbtnSave";
            this.tsrbtnSave.Size = new System.Drawing.Size(83, 26);
            this.tsrbtnSave.Text = "保存(F5)";
            this.tsrbtnSave.Click += new System.EventHandler(this.tsrbtnSave_Click);
            // 
            // tsrbtnQuit
            // 
            this.tsrbtnQuit.Image = ((System.Drawing.Image)(resources.GetObject("tsrbtnQuit.Image")));
            this.tsrbtnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsrbtnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsrbtnQuit.Name = "tsrbtnQuit";
            this.tsrbtnQuit.Size = new System.Drawing.Size(76, 26);
            this.tsrbtnQuit.Text = "关闭(&C)";
            this.tsrbtnQuit.Click += new System.EventHandler(this.tsrbtnQuit_Click);
            // 
            // dgrdByName
            // 
            this.dgrdByName.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgrdByName.AllowSortWhenClickColumnHeader = false;
            this.dgrdByName.AllowUserToAddRows = false;
            this.dgrdByName.AllowUserToResizeRows = false;
            this.dgrdByName.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdByName.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdByName.ColumnHeadersHeight = 30;
            this.dgrdByName.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgrdByName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdByName.EnableHeadersVisualStyles = false;
            this.dgrdByName.Location = new System.Drawing.Point(0, 35);
            this.dgrdByName.MultiSelect = false;
            this.dgrdByName.Name = "dgrdByName";
            this.dgrdByName.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdByName.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgrdByName.RowTemplate.Height = 23;
            this.dgrdByName.SelectionCards = null;
            this.dgrdByName.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdByName.Size = new System.Drawing.Size(542, 206);
            this.dgrdByName.TabIndex = 0;
            this.dgrdByName.UseGradientBackgroundColor = true;
            this.dgrdByName.CurrentCellChanged += new System.EventHandler(this.dgrdByName_CurrentCellChanged);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "BYName";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "药品别名";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "PYM";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "拼音码";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 120;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "WBM";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Column3.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column3.HeaderText = "五笔码";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 120;
            // 
            // FrmDrugByname
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 330);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormTitle = "商品别名维护";
            this.KeyPreview = true;
            this.Name = "FrmDrugByname";
            this.Text = "商品别名维护";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmDrugByname_KeyDown);
            this.plBaseToolbar.ResumeLayout(false);
            this.plBaseWorkArea.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tsrDrugByName.ResumeLayout(false);
            this.tsrDrugByName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdByName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblByname;
        private System.Windows.Forms.TextBox txtWBM;
        private System.Windows.Forms.Label lblWBM;
        private System.Windows.Forms.TextBox txtPYM;
        private System.Windows.Forms.Label lblPYM;
        private System.Windows.Forms.TextBox txtByname;
        private GWI.HIS.Windows.Controls.ToolStrip tsrDrugByName;
        private System.Windows.Forms.ToolStripButton tsrbtnAdd;
        private System.Windows.Forms.ToolStripButton tsrbtnDel;
        private System.Windows.Forms.ToolStripButton tsrbtnUpdate;
        private System.Windows.Forms.ToolStripButton tsrbtnSave;
        private System.Windows.Forms.ToolStripButton tsrbtnQuit;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgrdByName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;

    }
}