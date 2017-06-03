namespace HIS_EMRManager
{
    partial class FrmEMRInfoUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEMRInfoUpdate));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.plLeft = new System.Windows.Forms.Panel();
            this.dGVPatList = new System.Windows.Forms.DataGridView();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MediCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATBRIDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plTool = new System.Windows.Forms.Panel();
            this.btUpdate = new System.Windows.Forms.Button();
            this.rdBNoUp = new System.Windows.Forms.RadioButton();
            this.rdBHadUp = new System.Windows.Forms.RadioButton();
            this.btRefresh = new System.Windows.Forms.Button();
            this.plTop = new System.Windows.Forms.Panel();
            this.plBottom = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.plCenter = new System.Windows.Forms.Panel();
            this.dGVDataList = new System.Windows.Forms.DataGridView();
            this.Checked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PatNames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordCreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plBaseWorkArea.SuspendLayout();
            this.plLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVPatList)).BeginInit();
            this.plTool.SuspendLayout();
            this.plCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVDataList)).BeginInit();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Margin = new System.Windows.Forms.Padding(2);
            this.plBaseToolbar.Size = new System.Drawing.Size(732, 29);
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
            this.plBaseStatus.Location = new System.Drawing.Point(0, 516);
            this.plBaseStatus.Margin = new System.Windows.Forms.Padding(2);
            this.plBaseStatus.Size = new System.Drawing.Size(732, 26);
            this.plBaseStatus.Visible = false;
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.plCenter);
            this.plBaseWorkArea.Controls.Add(this.splitter1);
            this.plBaseWorkArea.Controls.Add(this.plLeft);
            this.plBaseWorkArea.Margin = new System.Windows.Forms.Padding(2);
            this.plBaseWorkArea.Size = new System.Drawing.Size(732, 453);
            // 
            // plLeft
            // 
            this.plLeft.Controls.Add(this.dGVPatList);
            this.plLeft.Controls.Add(this.plTool);
            this.plLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.plLeft.Location = new System.Drawing.Point(0, 0);
            this.plLeft.Margin = new System.Windows.Forms.Padding(2);
            this.plLeft.Name = "plLeft";
            this.plLeft.Size = new System.Drawing.Size(732, 323);
            this.plLeft.TabIndex = 0;
            // 
            // dGVPatList
            // 
            this.dGVPatList.AllowUserToAddRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.dGVPatList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dGVPatList.BackgroundColor = System.Drawing.Color.White;
            this.dGVPatList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dGVPatList.ColumnHeadersHeight = 25;
            this.dGVPatList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.MediCard,
            this.PatName,
            this.PatSex,
            this.PATBRIDATE,
            this.PatNumber,
            this.PatAddress,
            this.PatId});
            this.dGVPatList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVPatList.Location = new System.Drawing.Point(0, 28);
            this.dGVPatList.Margin = new System.Windows.Forms.Padding(2);
            this.dGVPatList.Name = "dGVPatList";
            this.dGVPatList.RowHeadersWidth = 20;
            this.dGVPatList.RowTemplate.Height = 23;
            this.dGVPatList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVPatList.Size = new System.Drawing.Size(732, 295);
            this.dGVPatList.TabIndex = 1;
            this.dGVPatList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVPatList_CellClick);
            // 
            // Selected
            // 
            this.Selected.DataPropertyName = "Selected";
            this.Selected.HeaderText = "选";
            this.Selected.Name = "Selected";
            this.Selected.ReadOnly = true;
            this.Selected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Selected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Selected.Visible = false;
            this.Selected.Width = 30;
            // 
            // MediCard
            // 
            this.MediCard.DataPropertyName = "MediCard";
            this.MediCard.HeaderText = "医疗证卡号";
            this.MediCard.Name = "MediCard";
            this.MediCard.ReadOnly = true;
            this.MediCard.Width = 120;
            // 
            // PatName
            // 
            this.PatName.DataPropertyName = "PatName";
            this.PatName.HeaderText = "病人姓名";
            this.PatName.Name = "PatName";
            this.PatName.ReadOnly = true;
            this.PatName.Width = 80;
            // 
            // PatSex
            // 
            this.PatSex.DataPropertyName = "PatSex";
            this.PatSex.HeaderText = "性别";
            this.PatSex.Name = "PatSex";
            this.PatSex.ReadOnly = true;
            this.PatSex.Width = 60;
            // 
            // PATBRIDATE
            // 
            this.PATBRIDATE.DataPropertyName = "PATBRIDATE";
            this.PATBRIDATE.HeaderText = "出生日期";
            this.PATBRIDATE.Name = "PATBRIDATE";
            this.PATBRIDATE.ReadOnly = true;
            // 
            // PatNumber
            // 
            this.PatNumber.DataPropertyName = "PatNumber";
            this.PatNumber.HeaderText = "身份证号";
            this.PatNumber.Name = "PatNumber";
            this.PatNumber.ReadOnly = true;
            this.PatNumber.Width = 150;
            // 
            // PatAddress
            // 
            this.PatAddress.DataPropertyName = "PatAddress";
            this.PatAddress.HeaderText = "住址";
            this.PatAddress.Name = "PatAddress";
            this.PatAddress.ReadOnly = true;
            this.PatAddress.Width = 200;
            // 
            // PatId
            // 
            this.PatId.DataPropertyName = "PatId";
            this.PatId.HeaderText = "PatId";
            this.PatId.Name = "PatId";
            this.PatId.ReadOnly = true;
            this.PatId.Visible = false;
            // 
            // plTool
            // 
            this.plTool.Controls.Add(this.btUpdate);
            this.plTool.Controls.Add(this.rdBNoUp);
            this.plTool.Controls.Add(this.rdBHadUp);
            this.plTool.Controls.Add(this.btRefresh);
            this.plTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.plTool.Location = new System.Drawing.Point(0, 0);
            this.plTool.Margin = new System.Windows.Forms.Padding(2);
            this.plTool.Name = "plTool";
            this.plTool.Size = new System.Drawing.Size(732, 28);
            this.plTool.TabIndex = 0;
            // 
            // btUpdate
            // 
            this.btUpdate.Location = new System.Drawing.Point(434, 2);
            this.btUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(74, 23);
            this.btUpdate.TabIndex = 0;
            this.btUpdate.Text = "上传";
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // rdBNoUp
            // 
            this.rdBNoUp.AutoSize = true;
            this.rdBNoUp.Checked = true;
            this.rdBNoUp.Location = new System.Drawing.Point(146, 5);
            this.rdBNoUp.Name = "rdBNoUp";
            this.rdBNoUp.Size = new System.Drawing.Size(59, 16);
            this.rdBNoUp.TabIndex = 2;
            this.rdBNoUp.TabStop = true;
            this.rdBNoUp.Text = "未上传";
            this.rdBNoUp.UseVisualStyleBackColor = true;
            this.rdBNoUp.CheckedChanged += new System.EventHandler(this.rdBNoUp_CheckedChanged);
            // 
            // rdBHadUp
            // 
            this.rdBHadUp.AutoSize = true;
            this.rdBHadUp.Location = new System.Drawing.Point(211, 5);
            this.rdBHadUp.Name = "rdBHadUp";
            this.rdBHadUp.Size = new System.Drawing.Size(59, 16);
            this.rdBHadUp.TabIndex = 1;
            this.rdBHadUp.Text = "已上传";
            this.rdBHadUp.UseVisualStyleBackColor = true;
            // 
            // btRefresh
            // 
            this.btRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.btRefresh.Location = new System.Drawing.Point(353, 2);
            this.btRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(74, 23);
            this.btRefresh.TabIndex = 0;
            this.btRefresh.Text = "刷新";
            this.btRefresh.UseVisualStyleBackColor = false;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // plTop
            // 
            this.plTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.plTop.Location = new System.Drawing.Point(0, 0);
            this.plTop.Margin = new System.Windows.Forms.Padding(2);
            this.plTop.Name = "plTop";
            this.plTop.Size = new System.Drawing.Size(729, 0);
            this.plTop.TabIndex = 1;
            // 
            // plBottom
            // 
            this.plBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plBottom.Location = new System.Drawing.Point(0, 92);
            this.plBottom.Margin = new System.Windows.Forms.Padding(2);
            this.plBottom.Name = "plBottom";
            this.plBottom.Size = new System.Drawing.Size(729, 38);
            this.plBottom.TabIndex = 2;
            this.plBottom.Visible = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 323);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 130);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // plCenter
            // 
            this.plCenter.Controls.Add(this.dGVDataList);
            this.plCenter.Controls.Add(this.plBottom);
            this.plCenter.Controls.Add(this.plTop);
            this.plCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plCenter.Location = new System.Drawing.Point(3, 323);
            this.plCenter.Name = "plCenter";
            this.plCenter.Size = new System.Drawing.Size(729, 130);
            this.plCenter.TabIndex = 5;
            // 
            // dGVDataList
            // 
            this.dGVDataList.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.dGVDataList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVDataList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVDataList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dGVDataList.ColumnHeadersHeight = 25;
            this.dGVDataList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Checked,
            this.PatNames,
            this.TypeName,
            this.EmpName,
            this.DeptName,
            this.RecordCreateDate});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVDataList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dGVDataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVDataList.Location = new System.Drawing.Point(0, 0);
            this.dGVDataList.Margin = new System.Windows.Forms.Padding(2);
            this.dGVDataList.Name = "dGVDataList";
            this.dGVDataList.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVDataList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dGVDataList.RowTemplate.Height = 23;
            this.dGVDataList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVDataList.Size = new System.Drawing.Size(729, 92);
            this.dGVDataList.TabIndex = 4;
            this.dGVDataList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVDataList_CellClick);
            // 
            // Checked
            // 
            this.Checked.DataPropertyName = "Checked";
            this.Checked.HeaderText = "选中";
            this.Checked.Name = "Checked";
            this.Checked.ReadOnly = true;
            this.Checked.Visible = false;
            this.Checked.Width = 45;
            // 
            // PatNames
            // 
            this.PatNames.DataPropertyName = "PatName";
            this.PatNames.HeaderText = "病人姓名";
            this.PatNames.Name = "PatNames";
            this.PatNames.ReadOnly = true;
            this.PatNames.Width = 90;
            // 
            // TypeName
            // 
            this.TypeName.DataPropertyName = "EMRTypeName";
            this.TypeName.HeaderText = "病历类型";
            this.TypeName.Name = "TypeName";
            this.TypeName.ReadOnly = true;
            // 
            // EmpName
            // 
            this.EmpName.DataPropertyName = "EmpName";
            this.EmpName.HeaderText = "创建人";
            this.EmpName.Name = "EmpName";
            this.EmpName.ReadOnly = true;
            this.EmpName.Width = 90;
            // 
            // DeptName
            // 
            this.DeptName.DataPropertyName = "DeptName";
            this.DeptName.HeaderText = "创建科室";
            this.DeptName.Name = "DeptName";
            this.DeptName.ReadOnly = true;
            this.DeptName.Width = 130;
            // 
            // RecordCreateDate
            // 
            this.RecordCreateDate.DataPropertyName = "RECORDCREATEDATE";
            this.RecordCreateDate.HeaderText = "创建时间";
            this.RecordCreateDate.Name = "RecordCreateDate";
            this.RecordCreateDate.ReadOnly = true;
            this.RecordCreateDate.Width = 120;
            // 
            // FrmEMRInfoUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 542);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmEMRInfoUpdate";
            this.Text = "FrmEMRInfoUpdate";
            this.plBaseWorkArea.ResumeLayout(false);
            this.plLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVPatList)).EndInit();
            this.plTool.ResumeLayout(false);
            this.plTool.PerformLayout();
            this.plCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVDataList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plLeft;
        private System.Windows.Forms.Panel plTop;
        private System.Windows.Forms.Panel plBottom;
        private System.Windows.Forms.Panel plTool;
        private System.Windows.Forms.DataGridView dGVPatList;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.Panel plCenter;
        private System.Windows.Forms.DataGridView dGVDataList;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.RadioButton rdBNoUp;
        private System.Windows.Forms.RadioButton rdBHadUp;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Checked;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatNames;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordCreateDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn MediCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATBRIDATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatId;
    }
}