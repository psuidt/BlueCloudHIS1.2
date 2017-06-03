namespace HIS_PublicManager
{
    partial class FrmCostCalculate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCostCalculate));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbCalType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSelfFee = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtUnit = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbResultFee = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btCal = new System.Windows.Forms.Button();
            this.btok = new System.Windows.Forms.Button();
            this.btclose = new System.Windows.Forms.Button();
            this.cbWorker = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbAllFee = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewEx1 = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCalType
            // 
            this.cbCalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCalType.FormattingEnabled = true;
            this.cbCalType.Items.AddRange(new object[] {
            "居民医保",
            "社保在职",
            "社保退休",
            "新农合"});
            this.cbCalType.Location = new System.Drawing.Point(108, 14);
            this.cbCalType.Name = "cbCalType";
            this.cbCalType.Size = new System.Drawing.Size(121, 20);
            this.cbCalType.TabIndex = 0;
            this.cbCalType.SelectedIndexChanged += new System.EventHandler(this.cbCalType_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(413, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "单位（元）";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.txtSelfFee);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.txtUnit);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.tbResultFee);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(85, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(333, 98);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "记账结果";
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(309, 68);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(19, 21);
            this.button3.TabIndex = 18;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(309, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(19, 21);
            this.button2.TabIndex = 18;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(309, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(19, 21);
            this.button1.TabIndex = 17;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSelfFee
            // 
            this.txtSelfFee.AllowSelectedNullRow = false;
            this.txtSelfFee.DisplayField = "";
            this.txtSelfFee.Location = new System.Drawing.Point(88, 68);
            this.txtSelfFee.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtSelfFee.MemberField = "";
            this.txtSelfFee.MemberValue = null;
            this.txtSelfFee.Name = "txtSelfFee";
            this.txtSelfFee.NextControl = null;
            this.txtSelfFee.NextControlByEnter = false;
            this.txtSelfFee.OffsetX = 0;
            this.txtSelfFee.OffsetY = 0;
            this.txtSelfFee.QueryFields = null;
            this.txtSelfFee.SelectedValue = null;
            this.txtSelfFee.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSelfFee.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtSelfFee.SelectionCardColumnHeaderHeight = 30;
            this.txtSelfFee.SelectionCardColumns = null;
            this.txtSelfFee.SelectionCardFont = null;
            this.txtSelfFee.SelectionCardHeight = 250;
            this.txtSelfFee.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtSelfFee.SelectionCardRowHeaderWidth = 35;
            this.txtSelfFee.SelectionCardRowHeight = 23;
            this.txtSelfFee.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtSelfFee.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtSelfFee.SelectionCardWidth = 250;
            this.txtSelfFee.ShowRowNumber = true;
            this.txtSelfFee.ShowSelectionCardAfterEnter = false;
            this.txtSelfFee.Size = new System.Drawing.Size(220, 21);
            this.txtSelfFee.TabIndex = 22;
            this.txtSelfFee.Text = "0";
            this.txtSelfFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSelfFee.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.Numberic;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 73);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 12);
            this.label16.TabIndex = 23;
            this.label16.Text = "个人自付总额";
            // 
            // txtUnit
            // 
            this.txtUnit.AllowSelectedNullRow = false;
            this.txtUnit.DisplayField = "";
            this.txtUnit.Location = new System.Drawing.Point(87, 37);
            this.txtUnit.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtUnit.MemberField = "";
            this.txtUnit.MemberValue = null;
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.NextControl = null;
            this.txtUnit.NextControlByEnter = false;
            this.txtUnit.OffsetX = 0;
            this.txtUnit.OffsetY = 0;
            this.txtUnit.QueryFields = null;
            this.txtUnit.SelectedValue = null;
            this.txtUnit.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUnit.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtUnit.SelectionCardColumnHeaderHeight = 30;
            this.txtUnit.SelectionCardColumns = null;
            this.txtUnit.SelectionCardFont = null;
            this.txtUnit.SelectionCardHeight = 250;
            this.txtUnit.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtUnit.SelectionCardRowHeaderWidth = 35;
            this.txtUnit.SelectionCardRowHeight = 23;
            this.txtUnit.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtUnit.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtUnit.SelectionCardWidth = 250;
            this.txtUnit.ShowRowNumber = true;
            this.txtUnit.ShowSelectionCardAfterEnter = false;
            this.txtUnit.Size = new System.Drawing.Size(221, 21);
            this.txtUnit.TabIndex = 20;
            this.txtUnit.Text = "0";
            this.txtUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUnit.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.Numberic;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "单位  记账";
            // 
            // tbResultFee
            // 
            this.tbResultFee.AllowSelectedNullRow = false;
            this.tbResultFee.DisplayField = "";
            this.tbResultFee.Location = new System.Drawing.Point(87, 14);
            this.tbResultFee.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.tbResultFee.MemberField = "";
            this.tbResultFee.MemberValue = null;
            this.tbResultFee.Name = "tbResultFee";
            this.tbResultFee.NextControl = null;
            this.tbResultFee.NextControlByEnter = false;
            this.tbResultFee.OffsetX = 0;
            this.tbResultFee.OffsetY = 0;
            this.tbResultFee.QueryFields = null;
            this.tbResultFee.SelectedValue = null;
            this.tbResultFee.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.tbResultFee.SelectionCardBackColor = System.Drawing.Color.White;
            this.tbResultFee.SelectionCardColumnHeaderHeight = 30;
            this.tbResultFee.SelectionCardColumns = null;
            this.tbResultFee.SelectionCardFont = null;
            this.tbResultFee.SelectionCardHeight = 250;
            this.tbResultFee.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.tbResultFee.SelectionCardRowHeaderWidth = 35;
            this.tbResultFee.SelectionCardRowHeight = 23;
            this.tbResultFee.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.tbResultFee.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.tbResultFee.SelectionCardWidth = 250;
            this.tbResultFee.ShowRowNumber = true;
            this.tbResultFee.ShowSelectionCardAfterEnter = false;
            this.tbResultFee.Size = new System.Drawing.Size(221, 21);
            this.tbResultFee.TabIndex = 0;
            this.tbResultFee.Text = "0";
            this.tbResultFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbResultFee.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.Numberic;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 19;
            this.label13.Text = "记账  金额";
            // 
            // btCal
            // 
            this.btCal.Location = new System.Drawing.Point(424, 14);
            this.btCal.Name = "btCal";
            this.btCal.Size = new System.Drawing.Size(75, 23);
            this.btCal.TabIndex = 1;
            this.btCal.Text = "计算";
            this.btCal.UseVisualStyleBackColor = true;
            this.btCal.Click += new System.EventHandler(this.btCal_Click);
            // 
            // btok
            // 
            this.btok.Location = new System.Drawing.Point(241, 110);
            this.btok.Name = "btok";
            this.btok.Size = new System.Drawing.Size(75, 23);
            this.btok.TabIndex = 2;
            this.btok.Text = "确定";
            this.btok.UseVisualStyleBackColor = true;
            this.btok.Click += new System.EventHandler(this.btok_Click);
            // 
            // btclose
            // 
            this.btclose.Location = new System.Drawing.Point(343, 110);
            this.btclose.Name = "btclose";
            this.btclose.Size = new System.Drawing.Size(75, 23);
            this.btclose.TabIndex = 3;
            this.btclose.Text = "退出";
            this.btclose.UseVisualStyleBackColor = true;
            this.btclose.Click += new System.EventHandler(this.btclose_Click);
            // 
            // cbWorker
            // 
            this.cbWorker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWorker.FormattingEnabled = true;
            this.cbWorker.Location = new System.Drawing.Point(317, 14);
            this.cbWorker.Name = "cbWorker";
            this.cbWorker.Size = new System.Drawing.Size(186, 20);
            this.cbWorker.TabIndex = 17;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(515, 400);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridViewEx1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(507, 375);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "TTT";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lbAllFee);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.cbCalType);
            this.panel1.Controls.Add(this.cbWorker);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(515, 62);
            this.panel1.TabIndex = 20;
            // 
            // lbAllFee
            // 
            this.lbAllFee.AutoSize = true;
            this.lbAllFee.ForeColor = System.Drawing.Color.Blue;
            this.lbAllFee.Location = new System.Drawing.Point(108, 41);
            this.lbAllFee.Name = "lbAllFee";
            this.lbAllFee.Size = new System.Drawing.Size(29, 12);
            this.lbAllFee.TabIndex = 22;
            this.lbAllFee.Text = "0.00";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(45, 42);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 21;
            this.label15.Text = "总金额：";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(239, 18);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(72, 16);
            this.checkBox2.TabIndex = 20;
            this.checkBox2.Text = "机关单位";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(30, 18);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "试算类型";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.btCal);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.btok);
            this.panel2.Controls.Add(this.btclose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 462);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(515, 139);
            this.panel2.TabIndex = 21;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Blue;
            this.label17.Location = new System.Drawing.Point(1, 117);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(227, 12);
            this.label17.TabIndex = 23;
            this.label17.Text = "总金额=记账金额+单位记账+个人自付总额";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 62);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(515, 400);
            this.panel3.TabIndex = 22;
            // 
            // dataGridViewEx1
            // 
            this.dataGridViewEx1.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dataGridViewEx1.AllowSortWhenClickColumnHeader = false;
            this.dataGridViewEx1.AllowUserToAddRows = false;
            this.dataGridViewEx1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewEx1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewEx1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEx1.EnableHeadersVisualStyles = false;
            this.dataGridViewEx1.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewEx1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewEx1.RowTemplate.Height = 23;
            this.dataGridViewEx1.SelectionCards = null;
            this.dataGridViewEx1.Size = new System.Drawing.Size(501, 369);
            this.dataGridViewEx1.TabIndex = 0;
            this.dataGridViewEx1.UseGradientBackgroundColor = true;
            // 
            // FrmCostCalculate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 601);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmCostCalculate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "费用试算";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCalType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private GWI.HIS.Windows.Controls.QueryTextBox tbResultFee;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btCal;
        private System.Windows.Forms.Button btok;
        private System.Windows.Forms.Button btclose;
        private System.Windows.Forms.ComboBox cbWorker;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private GWI.HIS.Windows.Controls.QueryTextBox txtUnit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbAllFee;
        private GWI.HIS.Windows.Controls.QueryTextBox txtSelfFee;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label17;
        private GWI.HIS.Windows.Controls.DataGridViewEx dataGridViewEx1;
    }
}