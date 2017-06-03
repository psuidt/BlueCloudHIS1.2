namespace HIS_MZDocManager
{
    partial class FrmRegister
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
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn5 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn6 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn7 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn8 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.qTxtName = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lVPatList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.btQuery = new GWI.HIS.Windows.Controls.Button();
            this.dTPkEnd = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dTPkBegin = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbBAgeType = new System.Windows.Forms.ComboBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.qTxtWorkUnit = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.cboJob = new System.Windows.Forms.ComboBox();
            this.cboFeeType = new System.Windows.Forms.ComboBox();
            this.cboSex = new System.Windows.Forms.ComboBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtIdentityCard = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btSure = new GWI.HIS.Windows.Controls.Button();
            this.btCancel = new GWI.HIS.Windows.Controls.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtCardNo);
            this.groupBox1.Controls.Add(this.qTxtName);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lVPatList);
            this.groupBox1.Controls.Add(this.btQuery);
            this.groupBox1.Controls.Add(this.dTPkEnd);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.dTPkBegin);
            this.groupBox1.Location = new System.Drawing.Point(12, 226);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 272);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查找病人";
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(78, 19);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(133, 21);
            this.txtCardNo.TabIndex = 0;
            this.txtCardNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPatInfor_KeyUp);
            // 
            // qTxtName
            // 
            this.qTxtName.AllowSelectedNullRow = false;
            this.qTxtName.DisplayField = "";
            this.qTxtName.Location = new System.Drawing.Point(78, 44);
            this.qTxtName.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.qTxtName.MemberField = "";
            this.qTxtName.MemberValue = null;
            this.qTxtName.Name = "qTxtName";
            this.qTxtName.NextControl = null;
            this.qTxtName.NextControlByEnter = false;
            this.qTxtName.OffsetX = 0;
            this.qTxtName.OffsetY = 0;
            this.qTxtName.QueryFields = null;
            this.qTxtName.SelectedValue = null;
            this.qTxtName.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.qTxtName.SelectionCardBackColor = System.Drawing.Color.White;
            this.qTxtName.SelectionCardColumnHeaderHeight = 30;
            this.qTxtName.SelectionCardColumns = null;
            this.qTxtName.SelectionCardFont = null;
            this.qTxtName.SelectionCardHeight = 250;
            this.qTxtName.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.qTxtName.SelectionCardRowHeaderWidth = 35;
            this.qTxtName.SelectionCardRowHeight = 23;
            this.qTxtName.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.qTxtName.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.qTxtName.SelectionCardWidth = 250;
            this.qTxtName.ShowRowNumber = true;
            this.qTxtName.ShowSelectionCardAfterEnter = false;
            this.qTxtName.Size = new System.Drawing.Size(133, 21);
            this.qTxtName.TabIndex = 1;
            this.qTxtName.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.qTxtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPatInfor_KeyUp);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 73);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 12);
            this.label14.TabIndex = 57;
            this.label14.Text = "就诊日期：从";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 56;
            this.label13.Text = "病人姓名：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 55;
            this.label12.Text = "诊疗卡号：";
            // 
            // lVPatList
            // 
            this.lVPatList.BackColor = System.Drawing.SystemColors.Window;
            this.lVPatList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader6});
            this.lVPatList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lVPatList.FullRowSelect = true;
            this.lVPatList.GridLines = true;
            this.lVPatList.Location = new System.Drawing.Point(3, 99);
            this.lVPatList.MultiSelect = false;
            this.lVPatList.Name = "lVPatList";
            this.lVPatList.Size = new System.Drawing.Size(523, 170);
            this.lVPatList.TabIndex = 54;
            this.lVPatList.UseCompatibleStateImageBehavior = false;
            this.lVPatList.View = System.Windows.Forms.View.Details;
            this.lVPatList.DoubleClick += new System.EventHandler(this.lVPatList_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "病人姓名";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "性别";
            this.columnHeader2.Width = 45;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "年龄";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "诊断";
            this.columnHeader5.Width = 200;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "就诊日期";
            this.columnHeader6.Width = 120;
            // 
            // btQuery
            // 
            this.btQuery.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.OtherProcess;
            this.btQuery.FixedWidth = true;
            this.btQuery.Location = new System.Drawing.Point(374, 67);
            this.btQuery.Name = "btQuery";
            this.btQuery.Size = new System.Drawing.Size(90, 25);
            this.btQuery.TabIndex = 4;
            this.btQuery.Text = "查询";
            this.btQuery.UseVisualStyleBackColor = true;
            this.btQuery.Click += new System.EventHandler(this.btQuery_Click);
            // 
            // dTPkEnd
            // 
            this.dTPkEnd.Location = new System.Drawing.Point(242, 69);
            this.dTPkEnd.Name = "dTPkEnd";
            this.dTPkEnd.Size = new System.Drawing.Size(111, 21);
            this.dTPkEnd.TabIndex = 3;
            this.dTPkEnd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPatInfor_KeyUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(217, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 51;
            this.label11.Text = "到";
            // 
            // dTPkBegin
            // 
            this.dTPkBegin.Location = new System.Drawing.Point(100, 69);
            this.dTPkBegin.Name = "dTPkBegin";
            this.dTPkBegin.Size = new System.Drawing.Size(111, 21);
            this.dTPkBegin.TabIndex = 2;
            this.dTPkBegin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPatInfor_KeyUp);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cbBAgeType);
            this.groupBox2.Controls.Add(this.txtAge);
            this.groupBox2.Controls.Add(this.qTxtWorkUnit);
            this.groupBox2.Controls.Add(this.cboJob);
            this.groupBox2.Controls.Add(this.cboFeeType);
            this.groupBox2.Controls.Add(this.cboSex);
            this.groupBox2.Controls.Add(this.txtTel);
            this.groupBox2.Controls.Add(this.txtAddress);
            this.groupBox2.Controls.Add(this.txtIdentityCard);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(529, 208);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "病人信息";
            // 
            // cbBAgeType
            // 
            this.cbBAgeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBAgeType.FormattingEnabled = true;
            this.cbBAgeType.Items.AddRange(new object[] {
            "岁",
            "月",
            "天",
            "小时"});
            this.cbBAgeType.Location = new System.Drawing.Point(447, 22);
            this.cbBAgeType.Name = "cbBAgeType";
            this.cbBAgeType.Size = new System.Drawing.Size(61, 20);
            this.cbBAgeType.TabIndex = 3;
            this.cbBAgeType.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPatInfor_KeyUp);
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(385, 22);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(60, 21);
            this.txtAge.TabIndex = 2;
            this.txtAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAge.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPatInfor_KeyUp);
            // 
            // qTxtWorkUnit
            // 
            this.qTxtWorkUnit.AllowSelectedNullRow = true;
            this.qTxtWorkUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.qTxtWorkUnit.BackColor = System.Drawing.Color.White;
            this.qTxtWorkUnit.DisplayField = "NAME";
            this.qTxtWorkUnit.Location = new System.Drawing.Point(78, 173);
            this.qTxtWorkUnit.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.qTxtWorkUnit.MemberField = "CODE";
            this.qTxtWorkUnit.MemberValue = null;
            this.qTxtWorkUnit.Name = "qTxtWorkUnit";
            this.qTxtWorkUnit.NextControl = null;
            this.qTxtWorkUnit.NextControlByEnter = true;
            this.qTxtWorkUnit.OffsetX = 0;
            this.qTxtWorkUnit.OffsetY = 0;
            this.qTxtWorkUnit.QueryFields = new string[] {
        "NAME",
        "PY_CODE",
        "WB_CODE"};
            this.qTxtWorkUnit.SelectedValue = null;
            this.qTxtWorkUnit.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.qTxtWorkUnit.SelectionCardBackColor = System.Drawing.Color.White;
            this.qTxtWorkUnit.SelectionCardColumnHeaderHeight = 30;
            selectionCardColumn5.AutoFill = true;
            selectionCardColumn5.DataBindField = "NAME";
            selectionCardColumn5.HeaderText = "单位名称";
            selectionCardColumn5.IsNameField = false;
            selectionCardColumn5.IsSeachColumn = true;
            selectionCardColumn5.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn5.Visiable = true;
            selectionCardColumn5.Width = 75;
            selectionCardColumn6.AutoFill = false;
            selectionCardColumn6.DataBindField = "CODE";
            selectionCardColumn6.HeaderText = "国标码";
            selectionCardColumn6.IsNameField = false;
            selectionCardColumn6.IsSeachColumn = false;
            selectionCardColumn6.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn6.Visiable = false;
            selectionCardColumn6.Width = 75;
            selectionCardColumn7.AutoFill = false;
            selectionCardColumn7.DataBindField = "PY_CODE";
            selectionCardColumn7.HeaderText = null;
            selectionCardColumn7.IsNameField = false;
            selectionCardColumn7.IsSeachColumn = true;
            selectionCardColumn7.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn7.Visiable = false;
            selectionCardColumn7.Width = 75;
            selectionCardColumn8.AutoFill = false;
            selectionCardColumn8.DataBindField = "WB_CODE";
            selectionCardColumn8.HeaderText = null;
            selectionCardColumn8.IsNameField = false;
            selectionCardColumn8.IsSeachColumn = true;
            selectionCardColumn8.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn8.Visiable = false;
            selectionCardColumn8.Width = 75;
            this.qTxtWorkUnit.SelectionCardColumns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn5,
        selectionCardColumn6,
        selectionCardColumn7,
        selectionCardColumn8};
            this.qTxtWorkUnit.SelectionCardFont = null;
            this.qTxtWorkUnit.SelectionCardHeight = 250;
            this.qTxtWorkUnit.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.qTxtWorkUnit.SelectionCardRowHeaderWidth = 35;
            this.qTxtWorkUnit.SelectionCardRowHeight = 23;
            this.qTxtWorkUnit.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.qTxtWorkUnit.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.qTxtWorkUnit.SelectionCardWidth = 500;
            this.qTxtWorkUnit.ShowRowNumber = true;
            this.qTxtWorkUnit.ShowSelectionCardAfterEnter = false;
            this.qTxtWorkUnit.Size = new System.Drawing.Size(430, 21);
            this.qTxtWorkUnit.TabIndex = 9;
            this.qTxtWorkUnit.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.qTxtWorkUnit.AfterSelectedRow += new GWI.HIS.Windows.Controls.AfterSelectedRowHandler(this.qTxtWorkUnit_AfterSelectedRow);
            this.qTxtWorkUnit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.qTxtWorkUnit_KeyUp);
            // 
            // cboJob
            // 
            this.cboJob.BackColor = System.Drawing.Color.White;
            this.cboJob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboJob.Font = new System.Drawing.Font("宋体", 9F);
            this.cboJob.ForeColor = System.Drawing.Color.Black;
            this.cboJob.FormattingEnabled = true;
            this.cboJob.Items.AddRange(new object[] {
            "干部",
            "工人",
            "农民",
            "科技",
            "教师",
            "学生",
            "离退",
            "家务",
            "待业",
            "儿童",
            "其他"});
            this.cboJob.Location = new System.Drawing.Point(242, 53);
            this.cboJob.Name = "cboJob";
            this.cboJob.Size = new System.Drawing.Size(266, 20);
            this.cboJob.TabIndex = 5;
            this.cboJob.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPatInfor_KeyUp);
            // 
            // cboFeeType
            // 
            this.cboFeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFeeType.Font = new System.Drawing.Font("宋体", 9F);
            this.cboFeeType.FormattingEnabled = true;
            this.cboFeeType.Location = new System.Drawing.Point(78, 52);
            this.cboFeeType.Name = "cboFeeType";
            this.cboFeeType.Size = new System.Drawing.Size(82, 20);
            this.cboFeeType.TabIndex = 4;
            this.cboFeeType.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPatInfor_KeyUp);
            // 
            // cboSex
            // 
            this.cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSex.FormattingEnabled = true;
            this.cboSex.Items.AddRange(new object[] {
            "未知的性别",
            "男性",
            "女性"});
            this.cboSex.Location = new System.Drawing.Point(242, 22);
            this.cboSex.Name = "cboSex";
            this.cboSex.Size = new System.Drawing.Size(62, 20);
            this.cboSex.TabIndex = 1;
            this.cboSex.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPatInfor_KeyUp);
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(78, 142);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(430, 21);
            this.txtTel.TabIndex = 8;
            this.txtTel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPatInfor_KeyUp);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(78, 113);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(430, 21);
            this.txtAddress.TabIndex = 7;
            this.txtAddress.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPatInfor_KeyUp);
            // 
            // txtIdentityCard
            // 
            this.txtIdentityCard.Location = new System.Drawing.Point(78, 81);
            this.txtIdentityCard.Name = "txtIdentityCard";
            this.txtIdentityCard.Size = new System.Drawing.Size(430, 21);
            this.txtIdentityCard.TabIndex = 6;
            this.txtIdentityCard.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPatInfor_KeyUp);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(78, 22);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(82, 21);
            this.txtName.TabIndex = 0;
            this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPatInfor_KeyUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(179, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "职  业  ：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "工作单位：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "电    话：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "地    址：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "身份证号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "病人类型：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(321, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "年  龄  ：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "性  别  ：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓  名  ：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btSure);
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 504);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(556, 46);
            this.panel1.TabIndex = 2;
            // 
            // btSure
            // 
            this.btSure.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.OtherProcess;
            this.btSure.FixedWidth = true;
            this.btSure.Location = new System.Drawing.Point(332, 9);
            this.btSure.Name = "btSure";
            this.btSure.Size = new System.Drawing.Size(90, 25);
            this.btSure.TabIndex = 0;
            this.btSure.Text = "确定(&S)";
            this.btSure.UseVisualStyleBackColor = true;
            this.btSure.Click += new System.EventHandler(this.btSure_Click);
            // 
            // btCancel
            // 
            this.btCancel.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.OtherProcess;
            this.btCancel.FixedWidth = true;
            this.btCancel.Location = new System.Drawing.Point(442, 9);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(90, 25);
            this.btCancel.TabIndex = 4;
            this.btCancel.Text = "取消";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // FrmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(556, 550);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(564, 584);
            this.MinimumSize = new System.Drawing.Size(564, 584);
            this.Name = "FrmRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新号";
            this.Load += new System.EventHandler(this.FrmRegister_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRegister_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmRegister_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private GWI.HIS.Windows.Controls.Button btSure;
        private GWI.HIS.Windows.Controls.Button btCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtIdentityCard;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cboSex;
        private System.Windows.Forms.ComboBox cboFeeType;
        private System.Windows.Forms.ComboBox cboJob;
        private GWI.HIS.Windows.Controls.QueryTextBox qTxtName;
        private System.Windows.Forms.TextBox txtCardNo;
        private System.Windows.Forms.DateTimePicker dTPkBegin;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dTPkEnd;
        private GWI.HIS.Windows.Controls.Button btQuery;
        private System.Windows.Forms.ListView lVPatList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private GWI.HIS.Windows.Controls.QueryTextBox qTxtWorkUnit;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbBAgeType;
        private System.Windows.Forms.TextBox txtAge;
    }
}