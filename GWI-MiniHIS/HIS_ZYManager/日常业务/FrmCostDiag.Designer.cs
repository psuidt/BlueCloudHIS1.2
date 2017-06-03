namespace HIS_ZYManager
{
    partial class FrmCostDiag
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
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn1 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn2 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn3 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn4 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            this.tbpos = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbFee = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTicketNO = new System.Windows.Forms.TextBox();
            this.btok = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbZD = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.tbOutDept = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.cbOutType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNum = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpOutDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_extra = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbfaoverFee = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbVillageFee = new System.Windows.Forms.TextBox();
            this.tbSelfFee = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbpos
            // 
            this.tbpos.BackColor = System.Drawing.Color.White;
            this.tbpos.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbpos.ForeColor = System.Drawing.Color.Red;
            this.tbpos.Location = new System.Drawing.Point(177, 44);
            this.tbpos.MaxLength = 18;
            this.tbpos.Name = "tbpos";
            this.tbpos.Size = new System.Drawing.Size(290, 27);
            this.tbpos.TabIndex = 1;
            this.tbpos.TextChanged += new System.EventHandler(this.tbpos_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(110, 47);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 18);
            this.label15.TabIndex = 66;
            this.label15.Text = "POS";
            // 
            // tbFee
            // 
            this.tbFee.BackColor = System.Drawing.Color.White;
            this.tbFee.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbFee.ForeColor = System.Drawing.Color.Red;
            this.tbFee.Location = new System.Drawing.Point(177, 14);
            this.tbFee.MaxLength = 18;
            this.tbFee.Name = "tbFee";
            this.tbFee.Size = new System.Drawing.Size(290, 27);
            this.tbFee.TabIndex = 0;
            this.tbFee.TextChanged += new System.EventHandler(this.tbFee_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(110, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 18);
            this.label13.TabIndex = 64;
            this.label13.Text = "现金";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(18, 374);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 68;
            this.label1.Text = "打印方式";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(19, 397);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 72;
            this.label2.Text = "发票号";
            // 
            // tbTicketNO
            // 
            this.tbTicketNO.BackColor = System.Drawing.Color.White;
            this.tbTicketNO.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbTicketNO.ForeColor = System.Drawing.Color.Red;
            this.tbTicketNO.Location = new System.Drawing.Point(76, 394);
            this.tbTicketNO.MaxLength = 20;
            this.tbTicketNO.Name = "tbTicketNO";
            this.tbTicketNO.ReadOnly = true;
            this.tbTicketNO.Size = new System.Drawing.Size(162, 23);
            this.tbTicketNO.TabIndex = 0;
            // 
            // btok
            // 
            this.btok.Location = new System.Drawing.Point(85, 432);
            this.btok.Name = "btok";
            this.btok.Size = new System.Drawing.Size(75, 23);
            this.btok.TabIndex = 1;
            this.btok.Text = "确定(&Q)";
            this.btok.UseVisualStyleBackColor = true;
            this.btok.Click += new System.EventHandler(this.btok_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(426, 432);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "取消(&C)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(635, 39);
            this.label3.TabIndex = 76;
            this.label3.Text = "出院结算";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton1.Location = new System.Drawing.Point(125, 373);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(81, 18);
            this.radioButton1.TabIndex = 77;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "全额打印";
            this.radioButton1.UseVisualStyleBackColor = false;
            this.radioButton1.Visible = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.Color.Transparent;
            this.radioButton2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton2.Location = new System.Drawing.Point(202, 373);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(81, 18);
            this.radioButton2.TabIndex = 78;
            this.radioButton2.Text = "只打自费";
            this.radioButton2.UseVisualStyleBackColor = false;
            this.radioButton2.Visible = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.BackColor = System.Drawing.Color.Transparent;
            this.radioButton3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton3.Location = new System.Drawing.Point(279, 373);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(81, 18);
            this.radioButton3.TabIndex = 79;
            this.radioButton3.Text = "不打发票";
            this.radioButton3.UseVisualStyleBackColor = false;
            this.radioButton3.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.tbZD);
            this.groupBox1.Controls.Add(this.tbOutDept);
            this.groupBox1.Controls.Add(this.cbOutType);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbNum);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.dtpOutDate);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(609, 99);
            this.groupBox1.TabIndex = 90;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "出院信息";
            // 
            // tbZD
            // 
            this.tbZD.AllowSelectedNullRow = false;
            this.tbZD.DisplayField = "NAME";
            this.tbZD.Location = new System.Drawing.Point(280, 61);
            this.tbZD.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.tbZD.MemberField = "CODE";
            this.tbZD.MemberValue = null;
            this.tbZD.Name = "tbZD";
            this.tbZD.NextControl = this.tbTicketNO;
            this.tbZD.NextControlByEnter = true;
            this.tbZD.OffsetX = 0;
            this.tbZD.OffsetY = 0;
            this.tbZD.QueryFields = new string[] {
        "PY_CODE",
        "WB_CODE",
        "NAME"};
            this.tbZD.SelectedValue = null;
            this.tbZD.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.tbZD.SelectionCardBackColor = System.Drawing.Color.White;
            this.tbZD.SelectionCardColumnHeaderHeight = 30;
            selectionCardColumn1.AutoFill = false;
            selectionCardColumn1.DataBindField = "CODE";
            selectionCardColumn1.HeaderText = "代码";
            selectionCardColumn1.IsNameField = false;
            selectionCardColumn1.IsSeachColumn = false;
            selectionCardColumn1.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn1.Visiable = true;
            selectionCardColumn1.Width = 75;
            selectionCardColumn2.AutoFill = true;
            selectionCardColumn2.DataBindField = "NAME";
            selectionCardColumn2.HeaderText = "名称";
            selectionCardColumn2.IsNameField = false;
            selectionCardColumn2.IsSeachColumn = true;
            selectionCardColumn2.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn2.Visiable = true;
            selectionCardColumn2.Width = 75;
            this.tbZD.SelectionCardColumns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn1,
        selectionCardColumn2};
            this.tbZD.SelectionCardFont = null;
            this.tbZD.SelectionCardHeight = 250;
            this.tbZD.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.tbZD.SelectionCardRowHeaderWidth = 35;
            this.tbZD.SelectionCardRowHeight = 23;
            this.tbZD.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.tbZD.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.Page;
            this.tbZD.SelectionCardWidth = 250;
            this.tbZD.ShowRowNumber = true;
            this.tbZD.ShowSelectionCardAfterEnter = false;
            this.tbZD.Size = new System.Drawing.Size(316, 23);
            this.tbZD.TabIndex = 100;
            this.tbZD.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            // 
            // tbOutDept
            // 
            this.tbOutDept.AllowSelectedNullRow = false;
            this.tbOutDept.DisplayField = "NAME";
            this.tbOutDept.Location = new System.Drawing.Point(73, 61);
            this.tbOutDept.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.tbOutDept.MemberField = "CODE";
            this.tbOutDept.MemberValue = null;
            this.tbOutDept.Name = "tbOutDept";
            this.tbOutDept.NextControl = this.tbZD;
            this.tbOutDept.NextControlByEnter = true;
            this.tbOutDept.OffsetX = 0;
            this.tbOutDept.OffsetY = 0;
            this.tbOutDept.QueryFields = new string[] {
        "PY_CODE",
        "WB_CODE"};
            this.tbOutDept.SelectedValue = null;
            this.tbOutDept.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.tbOutDept.SelectionCardBackColor = System.Drawing.Color.White;
            this.tbOutDept.SelectionCardColumnHeaderHeight = 30;
            selectionCardColumn3.AutoFill = false;
            selectionCardColumn3.DataBindField = "CODE";
            selectionCardColumn3.HeaderText = "代码";
            selectionCardColumn3.IsNameField = false;
            selectionCardColumn3.IsSeachColumn = false;
            selectionCardColumn3.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn3.Visiable = true;
            selectionCardColumn3.Width = 75;
            selectionCardColumn4.AutoFill = true;
            selectionCardColumn4.DataBindField = "NAME";
            selectionCardColumn4.HeaderText = "名称";
            selectionCardColumn4.IsNameField = false;
            selectionCardColumn4.IsSeachColumn = false;
            selectionCardColumn4.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn4.Visiable = true;
            selectionCardColumn4.Width = 75;
            this.tbOutDept.SelectionCardColumns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn3,
        selectionCardColumn4};
            this.tbOutDept.SelectionCardFont = null;
            this.tbOutDept.SelectionCardHeight = 250;
            this.tbOutDept.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.tbOutDept.SelectionCardRowHeaderWidth = 35;
            this.tbOutDept.SelectionCardRowHeight = 23;
            this.tbOutDept.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.tbOutDept.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.Page;
            this.tbOutDept.SelectionCardWidth = 250;
            this.tbOutDept.ShowRowNumber = true;
            this.tbOutDept.ShowSelectionCardAfterEnter = false;
            this.tbOutDept.Size = new System.Drawing.Size(121, 23);
            this.tbOutDept.TabIndex = 99;
            this.tbOutDept.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            // 
            // cbOutType
            // 
            this.cbOutType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutType.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbOutType.FormattingEnabled = true;
            this.cbOutType.Items.AddRange(new object[] {
            "治愈",
            "好转",
            "未愈",
            "死亡",
            "其它"});
            this.cbOutType.Location = new System.Drawing.Point(476, 25);
            this.cbOutType.Name = "cbOutType";
            this.cbOutType.Size = new System.Drawing.Size(121, 21);
            this.cbOutType.TabIndex = 2;
            this.cbOutType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbOutType_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(211, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 98;
            this.label6.Text = "出院诊断";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(411, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 96;
            this.label5.Text = "出院状态";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(6, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 94;
            this.label4.Text = "出院科室";
            // 
            // tbNum
            // 
            this.tbNum.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbNum.Location = new System.Drawing.Point(280, 24);
            this.tbNum.MaxLength = 10;
            this.tbNum.Name = "tbNum";
            this.tbNum.Size = new System.Drawing.Size(115, 23);
            this.tbNum.TabIndex = 1;
            this.tbNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNum_KeyDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(211, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 14);
            this.label14.TabIndex = 92;
            this.label14.Text = "住院天数";
            // 
            // dtpOutDate
            // 
            this.dtpOutDate.CalendarFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpOutDate.CustomFormat = "yyyy-MM-dd";
            this.dtpOutDate.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpOutDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOutDate.Location = new System.Drawing.Point(73, 24);
            this.dtpOutDate.Name = "dtpOutDate";
            this.dtpOutDate.Size = new System.Drawing.Size(121, 23);
            this.dtpOutDate.TabIndex = 0;
            this.dtpOutDate.ValueChanged += new System.EventHandler(this.dtpOutDate_ValueChanged);
            this.dtpOutDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpOutDate_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(6, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 14);
            this.label12.TabIndex = 90;
            this.label12.Text = "出院时间";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.White;
            this.textBox6.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox6.Location = new System.Drawing.Point(395, 52);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(202, 23);
            this.textBox6.TabIndex = 4;
            this.textBox6.Text = "0";
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.White;
            this.textBox7.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox7.Location = new System.Drawing.Point(73, 52);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(201, 23);
            this.textBox7.TabIndex = 3;
            this.textBox7.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(314, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 14);
            this.label10.TabIndex = 92;
            this.label10.Text = "补  收";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(6, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 14);
            this.label11.TabIndex = 91;
            this.label11.Text = "应  退";
            // 
            // tb_extra
            // 
            this.tb_extra.BackColor = System.Drawing.Color.White;
            this.tb_extra.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_extra.ForeColor = System.Drawing.Color.Red;
            this.tb_extra.Location = new System.Drawing.Point(177, 76);
            this.tb_extra.MaxLength = 18;
            this.tb_extra.Name = "tb_extra";
            this.tb_extra.ReadOnly = true;
            this.tb_extra.Size = new System.Drawing.Size(290, 26);
            this.tb_extra.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(110, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 18);
            this.label7.TabIndex = 96;
            this.label7.Text = "结欠";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.tb_extra);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.tbFee);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.tbpos);
            this.panel1.Location = new System.Drawing.Point(12, 251);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(609, 109);
            this.panel1.TabIndex = 98;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.tbfaoverFee);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tbVillageFee);
            this.groupBox2.Controls.Add(this.tbSelfFee);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBox7);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(12, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(609, 88);
            this.groupBox2.TabIndex = 99;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "费用信息";
            // 
            // tbfaoverFee
            // 
            this.tbfaoverFee.BackColor = System.Drawing.Color.White;
            this.tbfaoverFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbfaoverFee.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbfaoverFee.Location = new System.Drawing.Point(280, 15);
            this.tbfaoverFee.Name = "tbfaoverFee";
            this.tbfaoverFee.ReadOnly = true;
            this.tbfaoverFee.Size = new System.Drawing.Size(115, 23);
            this.tbfaoverFee.TabIndex = 1;
            this.tbfaoverFee.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(211, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 14);
            this.label9.TabIndex = 99;
            this.label9.Text = "优惠支付";
            // 
            // tbVillageFee
            // 
            this.tbVillageFee.BackColor = System.Drawing.Color.White;
            this.tbVillageFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbVillageFee.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbVillageFee.Location = new System.Drawing.Point(476, 15);
            this.tbVillageFee.Name = "tbVillageFee";
            this.tbVillageFee.ReadOnly = true;
            this.tbVillageFee.Size = new System.Drawing.Size(121, 23);
            this.tbVillageFee.TabIndex = 2;
            this.tbVillageFee.Text = "0";
            // 
            // tbSelfFee
            // 
            this.tbSelfFee.BackColor = System.Drawing.Color.White;
            this.tbSelfFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSelfFee.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbSelfFee.Location = new System.Drawing.Point(73, 15);
            this.tbSelfFee.Name = "tbSelfFee";
            this.tbSelfFee.ReadOnly = true;
            this.tbSelfFee.Size = new System.Drawing.Size(121, 23);
            this.tbSelfFee.TabIndex = 0;
            this.tbSelfFee.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(410, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 96;
            this.label8.Text = "记账支付";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(6, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 14);
            this.label16.TabIndex = 95;
            this.label16.Text = "个人支付";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(244, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 25);
            this.button1.TabIndex = 100;
            this.button1.Text = "调整发票号";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(387, 388);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(175, 28);
            this.label17.TabIndex = 101;
            this.label17.Text = "结算前请认真核对下发票号\r\n是否和你的实际发票号一样";
            // 
            // FrmCostDiag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(635, 459);
            this.ControlBox = false;
            this.Controls.Add(this.label17);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btok);
            this.Controls.Add(this.tbTicketNO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmCostDiag";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "";
            this.Load += new System.EventHandler(this.FrmCostDiag_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbpos;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbFee;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTicketNO;
        private System.Windows.Forms.Button btok;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbOutType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbNum;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpOutDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_extra;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbfaoverFee;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbVillageFee;
        private System.Windows.Forms.TextBox tbSelfFee;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label16;
        private GWI.HIS.Windows.Controls.QueryTextBox tbZD;
        private GWI.HIS.Windows.Controls.QueryTextBox tbOutDept;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label17;
    }
}