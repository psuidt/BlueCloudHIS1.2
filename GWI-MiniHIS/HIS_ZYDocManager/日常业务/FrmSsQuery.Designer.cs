namespace HIS_ZYDocManager.日常业务
{
    partial class FrmSsQuery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnCancelApply = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.radCancel = new System.Windows.Forms.RadioButton();
            this.radFinish = new System.Windows.Forms.RadioButton();
            this.radArrange = new System.Windows.Forms.RadioButton();
            this.radNotArrange = new System.Windows.Forms.RadioButton();
            this.dtend = new System.Windows.Forms.DateTimePicker();
            this.dtBegin = new System.Windows.Forms.DateTimePicker();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSsContent = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.住院号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSsContent)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.btnCancelApply);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.radCancel);
            this.groupBox1.Controls.Add(this.radFinish);
            this.groupBox1.Controls.Add(this.radArrange);
            this.groupBox1.Controls.Add(this.radNotArrange);
            this.groupBox1.Controls.Add(this.dtend);
            this.groupBox1.Controls.Add(this.dtBegin);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(813, 42);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(730, 11);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(48, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "退出";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnCancelApply
            // 
            this.btnCancelApply.Location = new System.Drawing.Point(654, 11);
            this.btnCancelApply.Name = "btnCancelApply";
            this.btnCancelApply.Size = new System.Drawing.Size(71, 23);
            this.btnCancelApply.TabIndex = 14;
            this.btnCancelApply.Text = "取消申请";
            this.btnCancelApply.UseVisualStyleBackColor = true;
            this.btnCancelApply.Click += new System.EventHandler(this.btnCancelApply_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(599, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "刷新";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radCancel
            // 
            this.radCancel.AutoSize = true;
            this.radCancel.Location = new System.Drawing.Point(531, 15);
            this.radCancel.Name = "radCancel";
            this.radCancel.Size = new System.Drawing.Size(59, 16);
            this.radCancel.TabIndex = 12;
            this.radCancel.Text = "已取消";
            this.radCancel.UseVisualStyleBackColor = true;
            this.radCancel.CheckedChanged += new System.EventHandler(this.radCancel_CheckedChanged);
            // 
            // radFinish
            // 
            this.radFinish.AutoSize = true;
            this.radFinish.Location = new System.Drawing.Point(468, 15);
            this.radFinish.Name = "radFinish";
            this.radFinish.Size = new System.Drawing.Size(59, 16);
            this.radFinish.TabIndex = 11;
            this.radFinish.Text = "已完成";
            this.radFinish.UseVisualStyleBackColor = true;
            this.radFinish.CheckedChanged += new System.EventHandler(this.radFinish_CheckedChanged);
            // 
            // radArrange
            // 
            this.radArrange.AutoSize = true;
            this.radArrange.Location = new System.Drawing.Point(404, 15);
            this.radArrange.Name = "radArrange";
            this.radArrange.Size = new System.Drawing.Size(59, 16);
            this.radArrange.TabIndex = 10;
            this.radArrange.Text = "已安排";
            this.radArrange.UseVisualStyleBackColor = true;
            this.radArrange.CheckedChanged += new System.EventHandler(this.radArrange_CheckedChanged);
            // 
            // radNotArrange
            // 
            this.radNotArrange.AutoSize = true;
            this.radNotArrange.Checked = true;
            this.radNotArrange.Location = new System.Drawing.Point(344, 15);
            this.radNotArrange.Name = "radNotArrange";
            this.radNotArrange.Size = new System.Drawing.Size(59, 16);
            this.radNotArrange.TabIndex = 9;
            this.radNotArrange.TabStop = true;
            this.radNotArrange.Text = "未安排";
            this.radNotArrange.UseVisualStyleBackColor = true;
            this.radNotArrange.CheckedChanged += new System.EventHandler(this.radNotArrange_CheckedChanged);
            // 
            // dtend
            // 
            this.dtend.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtend.Location = new System.Drawing.Point(224, 13);
            this.dtend.Name = "dtend";
            this.dtend.Size = new System.Drawing.Size(115, 21);
            this.dtend.TabIndex = 8;
            // 
            // dtBegin
            // 
            this.dtBegin.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtBegin.Location = new System.Drawing.Point(83, 13);
            this.dtBegin.Name = "dtBegin";
            this.dtBegin.Size = new System.Drawing.Size(109, 21);
            this.dtBegin.TabIndex = 7;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(199, 17);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 12);
            this.label23.TabIndex = 6;
            this.label23.Text = "到";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(59, 17);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(17, 12);
            this.label22.TabIndex = 5;
            this.label22.Text = "从";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "申请时间";
            // 
            // dgvSsContent
            // 
            this.dgvSsContent.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvSsContent.AllowSortWhenClickColumnHeader = false;
            this.dgvSsContent.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSsContent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSsContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSsContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.住院号,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.dgvSsContent.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgvSsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSsContent.EnableHeadersVisualStyles = false;
            this.dgvSsContent.HideSelectionCardWhenCustomInput = false;
            this.dgvSsContent.Location = new System.Drawing.Point(0, 42);
            this.dgvSsContent.Name = "dgvSsContent";
            this.dgvSsContent.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSsContent.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSsContent.RowTemplate.Height = 23;
            this.dgvSsContent.SelectionCards = null;
            this.dgvSsContent.Size = new System.Drawing.Size(813, 451);
            this.dgvSsContent.TabIndex = 1;
            this.dgvSsContent.UseGradientBackgroundColor = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "patname";
            this.Column1.FillWeight = 80F;
            this.Column1.HeaderText = "姓名";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 80;
            // 
            // 住院号
            // 
            this.住院号.DataPropertyName = "cureno";
            this.住院号.FillWeight = 80F;
            this.住院号.HeaderText = "住院号";
            this.住院号.Name = "住院号";
            this.住院号.ReadOnly = true;
            this.住院号.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.住院号.Width = 80;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "patsex";
            this.Column2.HeaderText = "性别";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 50;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "sq_diag";
            this.Column3.HeaderText = "术前诊断";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "tend_opera";
            this.Column4.HeaderText = "拟施手术";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "operadocname";
            this.Column5.HeaderText = "主刀医生";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 90;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "tend_operadate";
            this.Column6.HeaderText = "拟施时间";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "applydocname";
            this.Column7.HeaderText = "申请医生";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "apply_date";
            this.Column8.HeaderText = "申请时间";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "ssty";
            this.Column9.HeaderText = "手术同意书";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "mzty";
            this.Column10.HeaderText = "麻醉同意书";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FrmSsQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 493);
            this.Controls.Add(this.dgvSsContent);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmSsQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "手术查询";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSsContent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvSsContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelApply;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radCancel;
        private System.Windows.Forms.RadioButton radFinish;
        private System.Windows.Forms.RadioButton radArrange;
        private System.Windows.Forms.RadioButton radNotArrange;
        private System.Windows.Forms.DateTimePicker dtend;
        private System.Windows.Forms.DateTimePicker dtBegin;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 住院号;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
    }
}