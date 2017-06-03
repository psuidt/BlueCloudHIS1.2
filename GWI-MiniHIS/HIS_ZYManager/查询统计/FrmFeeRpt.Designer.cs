namespace HIS_ZYManager
{
    partial class FrmFeeRpt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFeeRpt));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpBdate = new System.Windows.Forms.DateTimePicker();
            this.dtpEdate = new System.Windows.Forms.DateTimePicker();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btRpt = new System.Windows.Forms.Button();
            this.btPrint = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.cbPrew = new System.Windows.Forms.CheckBox();
            this.dgvData = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Controls.Add(this.checkBox1);
            this.plBaseToolbar.Controls.Add(this.button1);
            this.plBaseToolbar.Controls.Add(this.label5);
            this.plBaseToolbar.Controls.Add(this.cbPrew);
            this.plBaseToolbar.Controls.Add(this.btClose);
            this.plBaseToolbar.Controls.Add(this.btPrint);
            this.plBaseToolbar.Controls.Add(this.btRpt);
            this.plBaseToolbar.Controls.Add(this.comboBox3);
            this.plBaseToolbar.Controls.Add(this.label4);
            this.plBaseToolbar.Controls.Add(this.comboBox2);
            this.plBaseToolbar.Controls.Add(this.label3);
            this.plBaseToolbar.Controls.Add(this.dtpEdate);
            this.plBaseToolbar.Controls.Add(this.dtpBdate);
            this.plBaseToolbar.Controls.Add(this.label2);
            this.plBaseToolbar.Controls.Add(this.comboBox1);
            this.plBaseToolbar.Controls.Add(this.label1);
            this.plBaseToolbar.Size = new System.Drawing.Size(1016, 77);
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
            this.plBaseWorkArea.Location = new System.Drawing.Point(0, 111);
            this.plBaseWorkArea.Size = new System.Drawing.Size(1016, 599);
            // 
            // plTitle
            // 
            this.plTitle.Size = new System.Drawing.Size(1016, 34);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "时段类型";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "记账时间",
            "结算时间",
            "交款时间"});
            this.comboBox1.Location = new System.Drawing.Point(74, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(200, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "统计时间";
            // 
            // dtpBdate
            // 
            this.dtpBdate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBdate.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpBdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBdate.Location = new System.Drawing.Point(262, 9);
            this.dtpBdate.Name = "dtpBdate";
            this.dtpBdate.Size = new System.Drawing.Size(158, 23);
            this.dtpBdate.TabIndex = 3;
            // 
            // dtpEdate
            // 
            this.dtpEdate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEdate.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEdate.Location = new System.Drawing.Point(426, 9);
            this.dtpEdate.Name = "dtpEdate";
            this.dtpEdate.Size = new System.Drawing.Size(157, 23);
            this.dtpEdate.TabIndex = 4;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "发票项目",
            "会计项目",
            "核算项目",
            "统计大类"});
            this.comboBox2.Location = new System.Drawing.Point(74, 39);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 20);
            this.comboBox2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "统计分类";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "开方医生",
            "主管医生",
            "病人科室",
            "执行科室"});
            this.comboBox3.Location = new System.Drawing.Point(262, 39);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(158, 20);
            this.comboBox3.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(200, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "类别";
            // 
            // btRpt
            // 
            this.btRpt.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btRpt.Location = new System.Drawing.Point(555, 38);
            this.btRpt.Name = "btRpt";
            this.btRpt.Size = new System.Drawing.Size(75, 23);
            this.btRpt.TabIndex = 9;
            this.btRpt.Text = "统计";
            this.btRpt.UseVisualStyleBackColor = true;
            this.btRpt.Click += new System.EventHandler(this.btRpt_Click);
            // 
            // btPrint
            // 
            this.btPrint.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btPrint.Location = new System.Drawing.Point(745, 38);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(102, 23);
            this.btPrint.TabIndex = 10;
            this.btPrint.Text = "输出Excel";
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // btClose
            // 
            this.btClose.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btClose.Location = new System.Drawing.Point(883, 38);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 11;
            this.btClose.Text = "关闭";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // cbPrew
            // 
            this.cbPrew.AutoSize = true;
            this.cbPrew.Location = new System.Drawing.Point(787, 13);
            this.cbPrew.Name = "cbPrew";
            this.cbPrew.Size = new System.Drawing.Size(84, 16);
            this.cbPrew.TabIndex = 12;
            this.cbPrew.Text = "打印前预览";
            this.cbPrew.UseVisualStyleBackColor = true;
            this.cbPrew.Visible = false;
            // 
            // dgvData
            // 
            this.dgvData.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvData.AllowSortWhenClickColumnHeader = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.HideSelectionCardWhenCustomInput = false;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.SelectionCards = null;
            this.dgvData.Size = new System.Drawing.Size(1016, 599);
            this.dgvData.TabIndex = 0;
            this.dgvData.UseGradientBackgroundColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(833, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(453, 23);
            this.label5.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(636, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "行列交换";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(661, 13);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(120, 16);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "是否显示合计为零";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // FrmFeeRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 736);
            this.FormTitle = "住院收入统计";
            this.Name = "FrmFeeRpt";
            this.Text = "住院收入统计";
            this.plBaseToolbar.ResumeLayout(false);
            this.plBaseToolbar.PerformLayout();
            this.plBaseWorkArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dtpBdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEdate;
        private System.Windows.Forms.Button btRpt;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbPrew;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btPrint;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}