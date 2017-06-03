namespace HIS_ZYManager
{
    partial class FrmPatientNum
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPatientNum));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rdHistogram = new System.Windows.Forms.RadioButton();
            this.rdLine = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnStat = new System.Windows.Forms.Button();
            this.cboViewType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvList = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMPTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plGraph = new System.Windows.Forms.Panel();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Controls.Add(this.rdHistogram);
            this.plBaseToolbar.Controls.Add(this.rdLine);
            this.plBaseToolbar.Controls.Add(this.btnClose);
            this.plBaseToolbar.Controls.Add(this.btnStat);
            this.plBaseToolbar.Controls.Add(this.cboViewType);
            this.plBaseToolbar.Controls.Add(this.label2);
            this.plBaseToolbar.Controls.Add(this.dtpEnd);
            this.plBaseToolbar.Controls.Add(this.dtpFrom);
            this.plBaseToolbar.Controls.Add(this.label1);
            this.plBaseToolbar.Size = new System.Drawing.Size(892, 40);
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
            this.plBaseStatus.Location = new System.Drawing.Point(0, 433);
            this.plBaseStatus.Size = new System.Drawing.Size(892, 26);
            this.plBaseStatus.Visible = false;
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.splitContainer1);
            this.plBaseWorkArea.Location = new System.Drawing.Point(0, 74);
            this.plBaseWorkArea.Size = new System.Drawing.Size(892, 359);
            // 
            // plTitle
            // 
            this.plTitle.Size = new System.Drawing.Size(892, 34);
            // 
            // rdHistogram
            // 
            this.rdHistogram.AutoSize = true;
            this.rdHistogram.Location = new System.Drawing.Point(590, 11);
            this.rdHistogram.Name = "rdHistogram";
            this.rdHistogram.Size = new System.Drawing.Size(47, 16);
            this.rdHistogram.TabIndex = 17;
            this.rdHistogram.Text = "柱状";
            this.rdHistogram.UseVisualStyleBackColor = true;
            // 
            // rdLine
            // 
            this.rdLine.AutoSize = true;
            this.rdLine.Checked = true;
            this.rdLine.Location = new System.Drawing.Point(532, 11);
            this.rdLine.Name = "rdLine";
            this.rdLine.Size = new System.Drawing.Size(47, 16);
            this.rdLine.TabIndex = 16;
            this.rdLine.TabStop = true;
            this.rdLine.Text = "线状";
            this.rdLine.UseVisualStyleBackColor = true;
            this.rdLine.CheckedChanged += new System.EventHandler(this.rdLine_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(731, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnStat
            // 
            this.btnStat.Location = new System.Drawing.Point(650, 7);
            this.btnStat.Name = "btnStat";
            this.btnStat.Size = new System.Drawing.Size(75, 23);
            this.btnStat.TabIndex = 14;
            this.btnStat.Text = "统计";
            this.btnStat.UseVisualStyleBackColor = true;
            this.btnStat.Click += new System.EventHandler(this.btnStat_Click);
            // 
            // cboViewType
            // 
            this.cboViewType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboViewType.FormattingEnabled = true;
            this.cboViewType.Items.AddRange(new object[] {
            "医生",
            "科室"});
            this.cboViewType.Location = new System.Drawing.Point(415, 10);
            this.cboViewType.Name = "cboViewType";
            this.cboViewType.Size = new System.Drawing.Size(111, 20);
            this.cboViewType.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(360, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "查看方式";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(211, 9);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(143, 21);
            this.dtpEnd.TabIndex = 11;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(66, 9);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(141, 21);
            this.dtpFrom.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "统计日期：";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.plGraph);
            this.splitContainer1.Size = new System.Drawing.Size(892, 359);
            this.splitContainer1.SplitterDistance = 156;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgvList
            // 
            this.dgvList.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvList.AllowSortWhenClickColumnHeader = true;
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeColumns = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NAME,
            this.NUM,
            this.EMPTY});
            this.dgvList.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.HideSelectionCardWhenCustomInput = false;
            this.dgvList.Location = new System.Drawing.Point(0, 0);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionCards = null;
            this.dgvList.Size = new System.Drawing.Size(892, 156);
            this.dgvList.TabIndex = 1;
            this.dgvList.UseGradientBackgroundColor = false;
            // 
            // NAME
            // 
            this.NAME.DataPropertyName = "NAME";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NAME.DefaultCellStyle = dataGridViewCellStyle2;
            this.NAME.HeaderText = "医生/科室名称";
            this.NAME.Name = "NAME";
            this.NAME.ReadOnly = true;
            this.NAME.Width = 300;
            // 
            // NUM
            // 
            this.NUM.DataPropertyName = "NUM";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NUM.DefaultCellStyle = dataGridViewCellStyle3;
            this.NUM.HeaderText = "人次";
            this.NUM.Name = "NUM";
            this.NUM.ReadOnly = true;
            this.NUM.Width = 300;
            // 
            // EMPTY
            // 
            this.EMPTY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EMPTY.HeaderText = "";
            this.EMPTY.Name = "EMPTY";
            this.EMPTY.ReadOnly = true;
            // 
            // plGraph
            // 
            this.plGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plGraph.Location = new System.Drawing.Point(0, 0);
            this.plGraph.Name = "plGraph";
            this.plGraph.Size = new System.Drawing.Size(892, 199);
            this.plGraph.TabIndex = 3;
            // 
            // FrmPatientNum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 459);
            this.FormTitle = "住院病人人次统计";
            this.Name = "FrmPatientNum";
            this.Text = "住院病人人次统计";
            this.Load += new System.EventHandler(this.FrmRegisterReport_Load);
            this.plBaseToolbar.ResumeLayout(false);
            this.plBaseToolbar.PerformLayout();
            this.plBaseWorkArea.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdHistogram;
        private System.Windows.Forms.RadioButton rdLine;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnStat;
        private System.Windows.Forms.ComboBox cboViewType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvList;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMPTY;
        private System.Windows.Forms.Panel plGraph;
    }
}