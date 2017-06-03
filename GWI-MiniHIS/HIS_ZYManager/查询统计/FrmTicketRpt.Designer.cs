namespace HIS_ZYManager
{
    partial class FrmTicketRpt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTicketRpt));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbPrew = new System.Windows.Forms.CheckBox();
            this.btClose = new System.Windows.Forms.Button();
            this.btRpt = new System.Windows.Forms.Button();
            this.dtpEdate = new System.Windows.Forms.DateTimePicker();
            this.dtpBdate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTicketItem = new System.Windows.Forms.CheckBox();
            this.cbVillage = new System.Windows.Forms.CheckBox();
            this.cbSelf = new System.Windows.Forms.CheckBox();
            this.dgvData = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbend = new System.Windows.Forms.ComboBox();
            this.cbbegin = new System.Windows.Forms.ComboBox();
            this.ckIvoice = new System.Windows.Forms.CheckBox();
            this.btClear = new System.Windows.Forms.Button();
            this.ckPatType = new System.Windows.Forms.CheckBox();
            this.ckDoc = new System.Windows.Forms.CheckBox();
            this.ckDept = new System.Windows.Forms.CheckBox();
            this.ckCharger = new System.Windows.Forms.CheckBox();
            this.cbPatType = new System.Windows.Forms.ComboBox();
            this.cbDoc = new System.Windows.Forms.ComboBox();
            this.cboxDept = new System.Windows.Forms.ComboBox();
            this.cboxCharger = new System.Windows.Forms.ComboBox();
            this.btPrint = new System.Windows.Forms.Button();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Controls.Add(this.groupBox2);
            this.plBaseToolbar.Controls.Add(this.label5);
            this.plBaseToolbar.Controls.Add(this.cbPrew);
            this.plBaseToolbar.Controls.Add(this.btClose);
            this.plBaseToolbar.Controls.Add(this.btRpt);
            this.plBaseToolbar.Controls.Add(this.dtpEdate);
            this.plBaseToolbar.Controls.Add(this.dtpBdate);
            this.plBaseToolbar.Controls.Add(this.label2);
            this.plBaseToolbar.Controls.Add(this.comboBox1);
            this.plBaseToolbar.Controls.Add(this.label1);
            this.plBaseToolbar.Size = new System.Drawing.Size(1016, 109);
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
            this.plBaseStatus.Location = new System.Drawing.Point(0, 710);
            this.plBaseStatus.Size = new System.Drawing.Size(1016, 26);
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.dgvData);
            this.plBaseWorkArea.Location = new System.Drawing.Point(0, 143);
            this.plBaseWorkArea.Size = new System.Drawing.Size(1016, 567);
            // 
            // plTitle
            // 
            this.plTitle.Size = new System.Drawing.Size(1016, 34);
            // 
            // cbPrew
            // 
            this.cbPrew.AutoSize = true;
            this.cbPrew.Location = new System.Drawing.Point(591, 15);
            this.cbPrew.Name = "cbPrew";
            this.cbPrew.Size = new System.Drawing.Size(84, 16);
            this.cbPrew.TabIndex = 21;
            this.cbPrew.Text = "打印前预览";
            this.cbPrew.UseVisualStyleBackColor = true;
            this.cbPrew.Visible = false;
            // 
            // btClose
            // 
            this.btClose.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btClose.Location = new System.Drawing.Point(886, 9);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(88, 23);
            this.btClose.TabIndex = 20;
            this.btClose.Text = "关闭";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btRpt
            // 
            this.btRpt.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btRpt.Location = new System.Drawing.Point(799, 9);
            this.btRpt.Name = "btRpt";
            this.btRpt.Size = new System.Drawing.Size(75, 23);
            this.btRpt.TabIndex = 18;
            this.btRpt.Text = "统计";
            this.btRpt.UseVisualStyleBackColor = true;
            this.btRpt.Click += new System.EventHandler(this.btRpt_Click);
            // 
            // dtpEdate
            // 
            this.dtpEdate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEdate.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEdate.Location = new System.Drawing.Point(434, 11);
            this.dtpEdate.Name = "dtpEdate";
            this.dtpEdate.Size = new System.Drawing.Size(160, 23);
            this.dtpEdate.TabIndex = 17;
            // 
            // dtpBdate
            // 
            this.dtpBdate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBdate.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpBdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBdate.Location = new System.Drawing.Point(269, 11);
            this.dtpBdate.Name = "dtpBdate";
            this.dtpBdate.Size = new System.Drawing.Size(160, 23);
            this.dtpBdate.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(207, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 15;
            this.label2.Text = "统计时间";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "结算时间",
            "交款时间"});
            this.comboBox1.Location = new System.Drawing.Point(84, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(22, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 13;
            this.label1.Text = "时段类型";
            // 
            // cbTicketItem
            // 
            this.cbTicketItem.AutoSize = true;
            this.cbTicketItem.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbTicketItem.Location = new System.Drawing.Point(477, 20);
            this.cbTicketItem.Name = "cbTicketItem";
            this.cbTicketItem.Size = new System.Drawing.Size(82, 18);
            this.cbTicketItem.TabIndex = 23;
            this.cbTicketItem.Text = "发票项目";
            this.cbTicketItem.UseVisualStyleBackColor = true;
            // 
            // cbVillage
            // 
            this.cbVillage.AutoSize = true;
            this.cbVillage.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbVillage.Location = new System.Drawing.Point(570, 20);
            this.cbVillage.Name = "cbVillage";
            this.cbVillage.Size = new System.Drawing.Size(82, 18);
            this.cbVillage.TabIndex = 24;
            this.cbVillage.Text = "记账类型";
            this.cbVillage.UseVisualStyleBackColor = true;
            // 
            // cbSelf
            // 
            this.cbSelf.AutoSize = true;
            this.cbSelf.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbSelf.Location = new System.Drawing.Point(665, 20);
            this.cbSelf.Name = "cbSelf";
            this.cbSelf.Size = new System.Drawing.Size(82, 18);
            this.cbSelf.TabIndex = 25;
            this.cbSelf.Text = "自付类型";
            this.cbSelf.UseVisualStyleBackColor = true;
            // 
            // dgvData
            // 
            this.dgvData.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvData.AllowSortWhenClickColumnHeader = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.HideSelectionCardWhenCustomInput = false;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
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
            this.dgvData.Size = new System.Drawing.Size(1016, 567);
            this.dgvData.TabIndex = 1;
            this.dgvData.UseGradientBackgroundColor = true;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(628, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 23);
            this.label5.TabIndex = 27;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbend);
            this.groupBox2.Controls.Add(this.cbbegin);
            this.groupBox2.Controls.Add(this.ckIvoice);
            this.groupBox2.Controls.Add(this.btClear);
            this.groupBox2.Controls.Add(this.ckPatType);
            this.groupBox2.Controls.Add(this.ckDoc);
            this.groupBox2.Controls.Add(this.ckDept);
            this.groupBox2.Controls.Add(this.ckCharger);
            this.groupBox2.Controls.Add(this.cbPatType);
            this.groupBox2.Controls.Add(this.cbSelf);
            this.groupBox2.Controls.Add(this.cbDoc);
            this.groupBox2.Controls.Add(this.cbVillage);
            this.groupBox2.Controls.Add(this.cbTicketItem);
            this.groupBox2.Controls.Add(this.cboxDept);
            this.groupBox2.Controls.Add(this.cboxCharger);
            this.groupBox2.Controls.Add(this.btPrint);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(15, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(970, 68);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "过滤方式";
            // 
            // cbend
            // 
            this.cbend.FormattingEnabled = true;
            this.cbend.Location = new System.Drawing.Point(662, 41);
            this.cbend.Name = "cbend";
            this.cbend.Size = new System.Drawing.Size(111, 20);
            this.cbend.TabIndex = 51;
            // 
            // cbbegin
            // 
            this.cbbegin.FormattingEnabled = true;
            this.cbbegin.Location = new System.Drawing.Point(546, 41);
            this.cbbegin.Name = "cbbegin";
            this.cbbegin.Size = new System.Drawing.Size(111, 20);
            this.cbbegin.TabIndex = 50;
            // 
            // ckIvoice
            // 
            this.ckIvoice.AutoSize = true;
            this.ckIvoice.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckIvoice.Location = new System.Drawing.Point(477, 43);
            this.ckIvoice.Name = "ckIvoice";
            this.ckIvoice.Size = new System.Drawing.Size(68, 18);
            this.ckIvoice.TabIndex = 49;
            this.ckIvoice.Text = "发票段";
            this.ckIvoice.UseVisualStyleBackColor = true;
            this.ckIvoice.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // btClear
            // 
            this.btClear.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btClear.Location = new System.Drawing.Point(784, 39);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(75, 23);
            this.btClear.TabIndex = 48;
            this.btClear.Text = "刷新";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // ckPatType
            // 
            this.ckPatType.AutoSize = true;
            this.ckPatType.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckPatType.Location = new System.Drawing.Point(249, 44);
            this.ckPatType.Name = "ckPatType";
            this.ckPatType.Size = new System.Drawing.Size(82, 18);
            this.ckPatType.TabIndex = 47;
            this.ckPatType.Text = "病人类型";
            this.ckPatType.UseVisualStyleBackColor = true;
            this.ckPatType.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // ckDoc
            // 
            this.ckDoc.AutoSize = true;
            this.ckDoc.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckDoc.Location = new System.Drawing.Point(34, 43);
            this.ckDoc.Name = "ckDoc";
            this.ckDoc.Size = new System.Drawing.Size(54, 18);
            this.ckDoc.TabIndex = 46;
            this.ckDoc.Text = "医生";
            this.ckDoc.UseVisualStyleBackColor = true;
            this.ckDoc.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // ckDept
            // 
            this.ckDept.AutoSize = true;
            this.ckDept.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckDept.Location = new System.Drawing.Point(249, 17);
            this.ckDept.Name = "ckDept";
            this.ckDept.Size = new System.Drawing.Size(54, 18);
            this.ckDept.TabIndex = 45;
            this.ckDept.Text = "科室";
            this.ckDept.UseVisualStyleBackColor = true;
            this.ckDept.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // ckCharger
            // 
            this.ckCharger.AutoSize = true;
            this.ckCharger.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckCharger.Location = new System.Drawing.Point(34, 17);
            this.ckCharger.Name = "ckCharger";
            this.ckCharger.Size = new System.Drawing.Size(68, 18);
            this.ckCharger.TabIndex = 44;
            this.ckCharger.Text = "收费员";
            this.ckCharger.UseVisualStyleBackColor = true;
            this.ckCharger.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // cbPatType
            // 
            this.cbPatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPatType.FormattingEnabled = true;
            this.cbPatType.Items.AddRange(new object[] {
            "收费员",
            "病人",
            "医生"});
            this.cbPatType.Location = new System.Drawing.Point(334, 44);
            this.cbPatType.Name = "cbPatType";
            this.cbPatType.Size = new System.Drawing.Size(121, 20);
            this.cbPatType.TabIndex = 43;
            // 
            // cbDoc
            // 
            this.cbDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDoc.FormattingEnabled = true;
            this.cbDoc.Items.AddRange(new object[] {
            "收费员",
            "病人",
            "医生"});
            this.cbDoc.Location = new System.Drawing.Point(106, 43);
            this.cbDoc.Name = "cbDoc";
            this.cbDoc.Size = new System.Drawing.Size(121, 20);
            this.cbDoc.TabIndex = 41;
            // 
            // cboxDept
            // 
            this.cboxDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDept.FormattingEnabled = true;
            this.cboxDept.Items.AddRange(new object[] {
            "收费员",
            "病人",
            "医生"});
            this.cboxDept.Location = new System.Drawing.Point(333, 15);
            this.cboxDept.Name = "cboxDept";
            this.cboxDept.Size = new System.Drawing.Size(121, 20);
            this.cboxDept.TabIndex = 39;
            // 
            // cboxCharger
            // 
            this.cboxCharger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCharger.FormattingEnabled = true;
            this.cboxCharger.Items.AddRange(new object[] {
            "收费员",
            "病人",
            "医生"});
            this.cboxCharger.Location = new System.Drawing.Point(106, 15);
            this.cboxCharger.Name = "cboxCharger";
            this.cboxCharger.Size = new System.Drawing.Size(121, 20);
            this.cboxCharger.TabIndex = 37;
            // 
            // btPrint
            // 
            this.btPrint.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btPrint.Location = new System.Drawing.Point(871, 39);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(88, 23);
            this.btPrint.TabIndex = 35;
            this.btPrint.Text = "输出Excel";
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // FrmTicketRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 736);
            this.FormTitle = "住院结算汇总统计";
            this.Name = "FrmTicketRpt";
            this.Text = "住院结算汇总统计";
            this.plBaseToolbar.ResumeLayout(false);
            this.plBaseToolbar.PerformLayout();
            this.plBaseWorkArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cbPrew;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btRpt;
        private System.Windows.Forms.DateTimePicker dtpEdate;
        private System.Windows.Forms.DateTimePicker dtpBdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbVillage;
        private System.Windows.Forms.CheckBox cbTicketItem;
        private System.Windows.Forms.CheckBox cbSelf;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbPatType;
        private System.Windows.Forms.ComboBox cbDoc;
        private System.Windows.Forms.ComboBox cboxDept;
        private System.Windows.Forms.ComboBox cboxCharger;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.CheckBox ckPatType;
        private System.Windows.Forms.CheckBox ckDoc;
        private System.Windows.Forms.CheckBox ckDept;
        private System.Windows.Forms.CheckBox ckCharger;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.CheckBox ckIvoice;
        private System.Windows.Forms.ComboBox cbbegin;
        private System.Windows.Forms.ComboBox cbend;
    }
}