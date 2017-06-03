namespace HIS_MediInsInterface
{
    partial class FrmShowPatInfo
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
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn3 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn4 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.qtbDisease = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.tbylzh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 288);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column12,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column10,
            this.Column11,
            this.Column13,
            this.Column14,
            this.Column15});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(673, 288);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ZKLSH";
            this.Column1.HeaderText = "证卡流水号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "YLZH";
            this.Column2.HeaderText = "医疗证号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "GRBM";
            this.Column7.HeaderText = "个人编码";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "XM";
            this.Column8.HeaderText = "姓名";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "XB";
            this.Column9.HeaderText = "性别";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "NN";
            this.Column12.HeaderText = "年龄";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "HZXM";
            this.Column3.HeaderText = "户主姓名";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ZNHBH";
            this.Column4.HeaderText = "组内户编号";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "HNRBH";
            this.Column5.HeaderText = "户内人编号";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "YHZGX";
            this.Column6.HeaderText = "与户主关系";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "CSRQ";
            this.Column10.HeaderText = "出生日期";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "SFZHM";
            this.Column11.HeaderText = "身份证号码";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "XDZ";
            this.Column13.HeaderText = "乡镇名称";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "CDZ";
            this.Column14.HeaderText = "村名称";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "ZDZ";
            this.Column15.HeaderText = "组名称";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.qtbDisease);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.tbylzh);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 288);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(673, 106);
            this.panel2.TabIndex = 1;
            // 
            // qtbDisease
            // 
            this.qtbDisease.AllowSelectedNullRow = false;
            this.qtbDisease.DisplayField = "NAME";
            this.qtbDisease.Location = new System.Drawing.Point(71, 48);
            this.qtbDisease.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.qtbDisease.MemberField = "CODE";
            this.qtbDisease.MemberValue = null;
            this.qtbDisease.Name = "qtbDisease";
            this.qtbDisease.NextControl = null;
            this.qtbDisease.NextControlByEnter = false;
            this.qtbDisease.OffsetX = 0;
            this.qtbDisease.OffsetY = 0;
            this.qtbDisease.QueryFields = new string[] {
        "PY_CODE",
        "WB_CODE"};
            this.qtbDisease.SelectedValue = null;
            this.qtbDisease.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.qtbDisease.SelectionCardBackColor = System.Drawing.Color.White;
            this.qtbDisease.SelectionCardColumnHeaderHeight = 30;
            selectionCardColumn3.AutoFill = false;
            selectionCardColumn3.DataBindField = "Code";
            selectionCardColumn3.HeaderText = "代码";
            selectionCardColumn3.IsNameField = false;
            selectionCardColumn3.IsSeachColumn = false;
            selectionCardColumn3.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn3.Visiable = true;
            selectionCardColumn3.Width = 75;
            selectionCardColumn4.AutoFill = true;
            selectionCardColumn4.DataBindField = "Name";
            selectionCardColumn4.HeaderText = "名称";
            selectionCardColumn4.IsNameField = false;
            selectionCardColumn4.IsSeachColumn = false;
            selectionCardColumn4.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn4.Visiable = true;
            selectionCardColumn4.Width = 75;
            this.qtbDisease.SelectionCardColumns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn3,
        selectionCardColumn4};
            this.qtbDisease.SelectionCardFont = null;
            this.qtbDisease.SelectionCardHeight = 250;
            this.qtbDisease.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.qtbDisease.SelectionCardRowHeaderWidth = 35;
            this.qtbDisease.SelectionCardRowHeight = 23;
            this.qtbDisease.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.qtbDisease.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.qtbDisease.SelectionCardWidth = 250;
            this.qtbDisease.ShowRowNumber = true;
            this.qtbDisease.ShowSelectionCardAfterEnter = false;
            this.qtbDisease.Size = new System.Drawing.Size(129, 21);
            this.qtbDisease.TabIndex = 10;
            this.qtbDisease.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "修改诊断";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(257, 64);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "重新加载数据(&C)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tbylzh
            // 
            this.tbylzh.Location = new System.Drawing.Point(71, 14);
            this.tbylzh.Name = "tbylzh";
            this.tbylzh.Size = new System.Drawing.Size(129, 21);
            this.tbylzh.TabIndex = 7;
            this.tbylzh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbylzh_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "医疗证号";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(512, 64);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "关闭(&C)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(400, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "确定(&Q)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(528, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(138, 21);
            this.textBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(457, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "业务ID";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(300, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择补偿类别";
            // 
            // FrmShowPatInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 394);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmShowPatInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "取农合病人信息";
            this.Load += new System.EventHandler(this.FrmShowPatInfo_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.TextBox tbylzh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private GWI.HIS.Windows.Controls.QueryTextBox qtbDisease;
    }
}