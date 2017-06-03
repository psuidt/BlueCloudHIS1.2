namespace HIS_ZYManager
{
    partial class FrmOutPatientRpt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOutPatientRpt));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbDept = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvData = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.btPrint = new System.Windows.Forms.Button();
            this.chkDeath = new System.Windows.Forms.CheckBox();
            this.cureno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deptname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.days = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outdiagnname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_fee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPTOSIT_FEE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REALITY_FEE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VILLAGE_FEE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FAVOR_FEE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Controls.Add(this.chkDeath);
            this.plBaseToolbar.Controls.Add(this.btPrint);
            this.plBaseToolbar.Controls.Add(this.cbDept);
            this.plBaseToolbar.Controls.Add(this.label2);
            this.plBaseToolbar.Controls.Add(this.button2);
            this.plBaseToolbar.Controls.Add(this.button1);
            this.plBaseToolbar.Controls.Add(this.dateTimePicker2);
            this.plBaseToolbar.Controls.Add(this.dateTimePicker1);
            this.plBaseToolbar.Controls.Add(this.label1);
            this.plBaseToolbar.Size = new System.Drawing.Size(1016, 40);
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
            this.plBaseWorkArea.Controls.Add(this.dgvData);
            this.plBaseWorkArea.Location = new System.Drawing.Point(0, 74);
            this.plBaseWorkArea.Size = new System.Drawing.Size(1016, 634);
            // 
            // plTitle
            // 
            this.plTitle.Size = new System.Drawing.Size(1016, 34);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择时间";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(62, 10);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(134, 21);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(202, 10);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(136, 21);
            this.dateTimePicker2.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(750, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "关闭(&C)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(589, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "查询(&Q)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbDept
            // 
            this.cbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDept.FormattingEnabled = true;
            this.cbDept.Location = new System.Drawing.Point(403, 11);
            this.cbDept.Name = "cbDept";
            this.cbDept.Size = new System.Drawing.Size(95, 20);
            this.cbDept.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(344, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "选择科室";
            // 
            // dgvData
            // 
            this.dgvData.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvData.AllowSortWhenClickColumnHeader = true;
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
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cureno,
            this.patname,
            this.deptname,
            this.docname,
            this.outdate,
            this.days,
            this.outdiagnname,
            this.total_fee,
            this.DEPTOSIT_FEE,
            this.REALITY_FEE,
            this.VILLAGE_FEE,
            this.FAVOR_FEE});
            this.dgvData.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.HideSelectionCardWhenCustomInput = false;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.SelectionCards = null;
            this.dgvData.Size = new System.Drawing.Size(1016, 634);
            this.dgvData.TabIndex = 1;
            this.dgvData.UseGradientBackgroundColor = true;
            // 
            // btPrint
            // 
            this.btPrint.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btPrint.Location = new System.Drawing.Point(667, 8);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(70, 23);
            this.btPrint.TabIndex = 36;
            this.btPrint.Text = "输出Excel";
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // chkDeath
            // 
            this.chkDeath.AutoSize = true;
            this.chkDeath.Location = new System.Drawing.Point(515, 12);
            this.chkDeath.Name = "chkDeath";
            this.chkDeath.Size = new System.Drawing.Size(72, 16);
            this.chkDeath.TabIndex = 37;
            this.chkDeath.Text = "死亡病人";
            this.chkDeath.UseVisualStyleBackColor = true;
            this.chkDeath.CheckedChanged += new System.EventHandler(this.chkDeath_CheckedChanged);
            // 
            // cureno
            // 
            this.cureno.DataPropertyName = "cureno";
            this.cureno.HeaderText = "住院号";
            this.cureno.Name = "cureno";
            this.cureno.ReadOnly = true;
            this.cureno.Width = 90;
            // 
            // patname
            // 
            this.patname.DataPropertyName = "patname";
            this.patname.HeaderText = "姓名";
            this.patname.Name = "patname";
            this.patname.ReadOnly = true;
            this.patname.Width = 90;
            // 
            // deptname
            // 
            this.deptname.DataPropertyName = "deptname";
            this.deptname.HeaderText = "出院科室";
            this.deptname.Name = "deptname";
            this.deptname.ReadOnly = true;
            // 
            // docname
            // 
            this.docname.DataPropertyName = "docname";
            this.docname.HeaderText = "主治医生";
            this.docname.Name = "docname";
            this.docname.ReadOnly = true;
            // 
            // outdate
            // 
            this.outdate.DataPropertyName = "outdate";
            this.outdate.HeaderText = "出院日期";
            this.outdate.Name = "outdate";
            this.outdate.ReadOnly = true;
            // 
            // days
            // 
            this.days.DataPropertyName = "days";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.days.DefaultCellStyle = dataGridViewCellStyle2;
            this.days.HeaderText = "住院天数";
            this.days.Name = "days";
            this.days.ReadOnly = true;
            this.days.Width = 90;
            // 
            // outdiagnname
            // 
            this.outdiagnname.DataPropertyName = "outdiagnname";
            this.outdiagnname.HeaderText = "出院诊断";
            this.outdiagnname.Name = "outdiagnname";
            this.outdiagnname.ReadOnly = true;
            this.outdiagnname.Width = 120;
            // 
            // total_fee
            // 
            this.total_fee.DataPropertyName = "total_fee";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.total_fee.DefaultCellStyle = dataGridViewCellStyle3;
            this.total_fee.HeaderText = "汇总金额";
            this.total_fee.Name = "total_fee";
            this.total_fee.ReadOnly = true;
            // 
            // DEPTOSIT_FEE
            // 
            this.DEPTOSIT_FEE.DataPropertyName = "DEPTOSIT_FEE";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.DEPTOSIT_FEE.DefaultCellStyle = dataGridViewCellStyle4;
            this.DEPTOSIT_FEE.HeaderText = "汇总预交金";
            this.DEPTOSIT_FEE.Name = "DEPTOSIT_FEE";
            this.DEPTOSIT_FEE.ReadOnly = true;
            this.DEPTOSIT_FEE.Width = 110;
            // 
            // REALITY_FEE
            // 
            this.REALITY_FEE.DataPropertyName = "REALITY_FEE";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.REALITY_FEE.DefaultCellStyle = dataGridViewCellStyle5;
            this.REALITY_FEE.HeaderText = "结补/结退";
            this.REALITY_FEE.Name = "REALITY_FEE";
            this.REALITY_FEE.ReadOnly = true;
            this.REALITY_FEE.Width = 110;
            // 
            // VILLAGE_FEE
            // 
            this.VILLAGE_FEE.DataPropertyName = "VILLAGE_FEE";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0";
            this.VILLAGE_FEE.DefaultCellStyle = dataGridViewCellStyle6;
            this.VILLAGE_FEE.HeaderText = "记账金额";
            this.VILLAGE_FEE.Name = "VILLAGE_FEE";
            this.VILLAGE_FEE.ReadOnly = true;
            this.VILLAGE_FEE.Width = 90;
            // 
            // FAVOR_FEE
            // 
            this.FAVOR_FEE.DataPropertyName = "FAVOR_FEE";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0";
            this.FAVOR_FEE.DefaultCellStyle = dataGridViewCellStyle7;
            this.FAVOR_FEE.HeaderText = "优惠金额";
            this.FAVOR_FEE.Name = "FAVOR_FEE";
            this.FAVOR_FEE.ReadOnly = true;
            this.FAVOR_FEE.Width = 90;
            // 
            // FrmOutPatientRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.FormTitle = "出院病人台帐";
            this.Name = "FrmOutPatientRpt";
            this.Text = "出院病人台帐";
            this.plBaseToolbar.ResumeLayout(false);
            this.plBaseToolbar.PerformLayout();
            this.plBaseWorkArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbDept;
        private System.Windows.Forms.Label label2;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvData;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.CheckBox chkDeath;
        private System.Windows.Forms.DataGridViewTextBoxColumn cureno;
        private System.Windows.Forms.DataGridViewTextBoxColumn patname;
        private System.Windows.Forms.DataGridViewTextBoxColumn deptname;
        private System.Windows.Forms.DataGridViewTextBoxColumn docname;
        private System.Windows.Forms.DataGridViewTextBoxColumn outdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn days;
        private System.Windows.Forms.DataGridViewTextBoxColumn outdiagnname;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_fee;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPTOSIT_FEE;
        private System.Windows.Forms.DataGridViewTextBoxColumn REALITY_FEE;
        private System.Windows.Forms.DataGridViewTextBoxColumn VILLAGE_FEE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FAVOR_FEE;
    }
}