namespace HIS_MZManager.GH
{
    partial class FrmMzgh
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn9 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn10 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn11 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn12 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn5 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn6 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn7 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn8 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn1 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn2 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn3 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn4 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMzgh));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAllergic = new System.Windows.Forms.TextBox();
            this.txtLinkAddress = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboAgeUnit = new System.Windows.Forms.ComboBox();
            this.txtAge = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboFeeType = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cboSex = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPatName = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHisCard = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRegDept = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.txtRegType = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.txtRegDoc = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.txtDocLevel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbPatientInfo = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new GWI.HIS.Windows.Controls.ToolStrip();
            this.btnRegister = new System.Windows.Forms.ToolStripButton();
            this.btnCancelRegister = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.dgvRegList = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.PATNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VISITNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CARDNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REG_DEPT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REG_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REG_DOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REG_FEE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REG_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REG_INVOICENO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TICKETCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RECORD_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHARGECODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbPatientInfo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegList)).BeginInit();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.BackColor = System.Drawing.SystemColors.Control;
            this.plBaseToolbar.Controls.Add(this.toolStrip1);
            this.plBaseToolbar.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plBaseToolbar.Size = new System.Drawing.Size(997, 31);
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
            this.plBaseStatus.Location = new System.Drawing.Point(0, 515);
            this.plBaseStatus.Size = new System.Drawing.Size(997, 26);
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.dgvRegList);
            this.plBaseWorkArea.Controls.Add(this.gbPatientInfo);
            this.plBaseWorkArea.Controls.Add(this.groupBox1);
            this.plBaseWorkArea.Location = new System.Drawing.Point(0, 65);
            this.plBaseWorkArea.Size = new System.Drawing.Size(997, 450);
            // 
            // plTitle
            // 
            this.plTitle.Size = new System.Drawing.Size(997, 34);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtAllergic);
            this.groupBox1.Controls.Add(this.txtLinkAddress);
            this.groupBox1.Controls.Add(this.txtTel);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cboAgeUnit);
            this.groupBox1.Controls.Add(this.txtAge);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cboFeeType);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.cboSex);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtPatName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtHisCard);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(997, 107);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本信息";
            // 
            // txtAllergic
            // 
            this.txtAllergic.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAllergic.Location = new System.Drawing.Point(657, 67);
            this.txtAllergic.MaxLength = 50;
            this.txtAllergic.Name = "txtAllergic";
            this.txtAllergic.Size = new System.Drawing.Size(334, 24);
            this.txtAllergic.TabIndex = 70;
            this.txtAllergic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnPressEnterKey);
            // 
            // txtLinkAddress
            // 
            this.txtLinkAddress.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLinkAddress.Location = new System.Drawing.Point(328, 67);
            this.txtLinkAddress.MaxLength = 25;
            this.txtLinkAddress.Name = "txtLinkAddress";
            this.txtLinkAddress.Size = new System.Drawing.Size(254, 24);
            this.txtLinkAddress.TabIndex = 69;
            this.txtLinkAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnPressEnterKey);
            // 
            // txtTel
            // 
            this.txtTel.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTel.Location = new System.Drawing.Point(79, 67);
            this.txtTel.MaxLength = 20;
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(170, 24);
            this.txtTel.TabIndex = 68;
            this.txtTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnPressEnterKey);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(584, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 15);
            this.label11.TabIndex = 67;
            this.label11.Text = "过 敏 史";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(255, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 15);
            this.label10.TabIndex = 66;
            this.label10.Text = "地   址";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(9, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 15);
            this.label9.TabIndex = 65;
            this.label9.Text = "电   话";
            // 
            // cboAgeUnit
            // 
            this.cboAgeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgeUnit.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboAgeUnit.FormattingEnabled = true;
            this.cboAgeUnit.Items.AddRange(new object[] {
            "岁",
            "月",
            "天"});
            this.cboAgeUnit.Location = new System.Drawing.Point(539, 40);
            this.cboAgeUnit.Name = "cboAgeUnit";
            this.cboAgeUnit.Size = new System.Drawing.Size(43, 23);
            this.cboAgeUnit.TabIndex = 64;
            // 
            // txtAge
            // 
            this.txtAge.AllowSelectedNullRow = false;
            this.txtAge.DisplayField = "";
            this.txtAge.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAge.Location = new System.Drawing.Point(499, 40);
            this.txtAge.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtAge.MaxLength = 2;
            this.txtAge.MemberField = "";
            this.txtAge.MemberValue = null;
            this.txtAge.Name = "txtAge";
            this.txtAge.NextControl = this.cboAgeUnit;
            this.txtAge.NextControlByEnter = true;
            this.txtAge.OffsetX = 0;
            this.txtAge.OffsetY = 0;
            this.txtAge.QueryFields = null;
            this.txtAge.SelectedValue = null;
            this.txtAge.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAge.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtAge.SelectionCardColumnHeaderHeight = 30;
            this.txtAge.SelectionCardColumns = null;
            this.txtAge.SelectionCardFont = null;
            this.txtAge.SelectionCardHeight = 250;
            this.txtAge.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtAge.SelectionCardRowHeaderWidth = 35;
            this.txtAge.SelectionCardRowHeight = 23;
            this.txtAge.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtAge.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtAge.SelectionCardWidth = 250;
            this.txtAge.ShowRowNumber = true;
            this.txtAge.ShowSelectionCardAfterEnter = false;
            this.txtAge.Size = new System.Drawing.Size(39, 24);
            this.txtAge.TabIndex = 2;
            this.txtAge.Text = "20";
            this.txtAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAge.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.UInteger;
            this.txtAge.Leave += new System.EventHandler(this.txtAge_Leave);
            this.txtAge.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAge_KeyUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(431, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 15);
            this.label8.TabIndex = 63;
            this.label8.Text = "年   龄";
            // 
            // cboFeeType
            // 
            this.cboFeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFeeType.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboFeeType.FormattingEnabled = true;
            this.cboFeeType.Location = new System.Drawing.Point(657, 40);
            this.cboFeeType.Name = "cboFeeType";
            this.cboFeeType.Size = new System.Drawing.Size(163, 23);
            this.cboFeeType.TabIndex = 3;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(584, 42);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(75, 15);
            this.label22.TabIndex = 3;
            this.label22.Text = "病人类型*";
            // 
            // cboSex
            // 
            this.cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSex.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboSex.FormattingEnabled = true;
            this.cboSex.Items.AddRange(new object[] {
            "未知的性别",
            "男性",
            "女性"});
            this.cboSex.Location = new System.Drawing.Point(328, 40);
            this.cboSex.Name = "cboSex";
            this.cboSex.Size = new System.Drawing.Size(97, 23);
            this.cboSex.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(255, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "性   别*";
            // 
            // txtPatName
            // 
            this.txtPatName.AllowSelectedNullRow = false;
            this.txtPatName.DisplayField = "";
            this.txtPatName.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPatName.Location = new System.Drawing.Point(79, 40);
            this.txtPatName.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtPatName.MaxLength = 5;
            this.txtPatName.MemberField = "";
            this.txtPatName.MemberValue = null;
            this.txtPatName.Name = "txtPatName";
            this.txtPatName.NextControl = this.cboSex;
            this.txtPatName.NextControlByEnter = true;
            this.txtPatName.OffsetX = 0;
            this.txtPatName.OffsetY = 0;
            this.txtPatName.QueryFields = null;
            this.txtPatName.SelectedValue = null;
            this.txtPatName.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPatName.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtPatName.SelectionCardColumnHeaderHeight = 30;
            this.txtPatName.SelectionCardColumns = null;
            this.txtPatName.SelectionCardFont = null;
            this.txtPatName.SelectionCardHeight = 250;
            this.txtPatName.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtPatName.SelectionCardRowHeaderWidth = 35;
            this.txtPatName.SelectionCardRowHeight = 23;
            this.txtPatName.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtPatName.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtPatName.SelectionCardWidth = 250;
            this.txtPatName.ShowRowNumber = true;
            this.txtPatName.ShowSelectionCardAfterEnter = false;
            this.txtPatName.Size = new System.Drawing.Size(170, 24);
            this.txtPatName.TabIndex = 0;
            this.txtPatName.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtPatName.Enter += new System.EventHandler(this.OnTextBoxEnter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(9, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "姓   名*";
            // 
            // txtHisCard
            // 
            this.txtHisCard.AllowSelectedNullRow = false;
            this.txtHisCard.BackColor = System.Drawing.SystemColors.Window;
            this.txtHisCard.DisplayField = "";
            this.txtHisCard.Enabled = false;
            this.txtHisCard.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHisCard.Location = new System.Drawing.Point(79, 14);
            this.txtHisCard.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtHisCard.MaxLength = 20;
            this.txtHisCard.MemberField = "";
            this.txtHisCard.MemberValue = null;
            this.txtHisCard.Name = "txtHisCard";
            this.txtHisCard.NextControl = null;
            this.txtHisCard.NextControlByEnter = false;
            this.txtHisCard.OffsetX = 0;
            this.txtHisCard.OffsetY = 0;
            this.txtHisCard.QueryFields = null;
            this.txtHisCard.SelectedValue = null;
            this.txtHisCard.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtHisCard.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtHisCard.SelectionCardColumnHeaderHeight = 30;
            this.txtHisCard.SelectionCardColumns = null;
            this.txtHisCard.SelectionCardFont = null;
            this.txtHisCard.SelectionCardHeight = 250;
            this.txtHisCard.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtHisCard.SelectionCardRowHeaderWidth = 35;
            this.txtHisCard.SelectionCardRowHeight = 23;
            this.txtHisCard.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtHisCard.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtHisCard.SelectionCardWidth = 250;
            this.txtHisCard.ShowRowNumber = true;
            this.txtHisCard.ShowSelectionCardAfterEnter = false;
            this.txtHisCard.Size = new System.Drawing.Size(170, 24);
            this.txtHisCard.TabIndex = 8;
            this.txtHisCard.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.Integer;
            this.txtHisCard.Leave += new System.EventHandler(this.txtHisCard_Leave);
            this.txtHisCard.Enter += new System.EventHandler(this.OnTextBoxEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "诊疗卡号";
            // 
            // txtRegDept
            // 
            this.txtRegDept.AllowSelectedNullRow = false;
            this.txtRegDept.DisplayField = "NAME";
            this.txtRegDept.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRegDept.Location = new System.Drawing.Point(79, 14);
            this.txtRegDept.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtRegDept.MaxLength = 20;
            this.txtRegDept.MemberField = "DEPT_ID";
            this.txtRegDept.MemberValue = null;
            this.txtRegDept.Name = "txtRegDept";
            this.txtRegDept.NextControl = this.txtRegType;
            this.txtRegDept.NextControlByEnter = true;
            this.txtRegDept.OffsetX = 0;
            this.txtRegDept.OffsetY = 0;
            this.txtRegDept.QueryFields = new string[] {
        "PY_CODE",
        "WB_CODE",
        "NAME"};
            this.txtRegDept.SelectedValue = null;
            this.txtRegDept.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtRegDept.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtRegDept.SelectionCardColumnHeaderHeight = 30;
            selectionCardColumn9.AutoFill = true;
            selectionCardColumn9.DataBindField = "NAME";
            selectionCardColumn9.HeaderText = "科室名称";
            selectionCardColumn9.IsNameField = false;
            selectionCardColumn9.IsSeachColumn = false;
            selectionCardColumn9.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn9.Visiable = true;
            selectionCardColumn9.Width = 75;
            selectionCardColumn10.AutoFill = false;
            selectionCardColumn10.DataBindField = "PY_CODE";
            selectionCardColumn10.HeaderText = "拼音码";
            selectionCardColumn10.IsNameField = false;
            selectionCardColumn10.IsSeachColumn = true;
            selectionCardColumn10.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn10.Visiable = true;
            selectionCardColumn10.Width = 75;
            selectionCardColumn11.AutoFill = false;
            selectionCardColumn11.DataBindField = "WB_CODE";
            selectionCardColumn11.HeaderText = "五笔码";
            selectionCardColumn11.IsNameField = false;
            selectionCardColumn11.IsSeachColumn = true;
            selectionCardColumn11.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn11.Visiable = true;
            selectionCardColumn11.Width = 75;
            selectionCardColumn12.AutoFill = false;
            selectionCardColumn12.DataBindField = "APPEND_FEE";
            selectionCardColumn12.HeaderText = "附加费用";
            selectionCardColumn12.IsNameField = false;
            selectionCardColumn12.IsSeachColumn = false;
            selectionCardColumn12.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn12.Visiable = true;
            selectionCardColumn12.Width = 75;
            this.txtRegDept.SelectionCardColumns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn9,
        selectionCardColumn10,
        selectionCardColumn11,
        selectionCardColumn12};
            this.txtRegDept.SelectionCardFont = null;
            this.txtRegDept.SelectionCardHeight = 230;
            this.txtRegDept.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtRegDept.SelectionCardRowHeaderWidth = 35;
            this.txtRegDept.SelectionCardRowHeight = 23;
            this.txtRegDept.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtRegDept.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtRegDept.SelectionCardWidth = 400;
            this.txtRegDept.ShowRowNumber = true;
            this.txtRegDept.ShowSelectionCardAfterEnter = true;
            this.txtRegDept.Size = new System.Drawing.Size(170, 24);
            this.txtRegDept.TabIndex = 0;
            this.txtRegDept.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtRegDept.Enter += new System.EventHandler(this.OnTextBoxEnter);
            // 
            // txtRegType
            // 
            this.txtRegType.AllowSelectedNullRow = false;
            this.txtRegType.DisplayField = "TYPE_NAME";
            this.txtRegType.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRegType.Location = new System.Drawing.Point(325, 14);
            this.txtRegType.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtRegType.MaxLength = 20;
            this.txtRegType.MemberField = "TYPE_CODE";
            this.txtRegType.MemberValue = null;
            this.txtRegType.Name = "txtRegType";
            this.txtRegType.NextControl = this.txtRegDoc;
            this.txtRegType.NextControlByEnter = true;
            this.txtRegType.OffsetX = 0;
            this.txtRegType.OffsetY = 0;
            this.txtRegType.QueryFields = new string[] {
        "PY_CODE",
        "WB_CODE",
        "TYPE_NAME"};
            this.txtRegType.SelectedValue = null;
            this.txtRegType.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtRegType.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtRegType.SelectionCardColumnHeaderHeight = 30;
            selectionCardColumn5.AutoFill = true;
            selectionCardColumn5.DataBindField = "TYPE_NAME";
            selectionCardColumn5.HeaderText = "挂号类别";
            selectionCardColumn5.IsNameField = false;
            selectionCardColumn5.IsSeachColumn = false;
            selectionCardColumn5.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn5.Visiable = true;
            selectionCardColumn5.Width = 75;
            selectionCardColumn6.AutoFill = false;
            selectionCardColumn6.DataBindField = "PY_CODE";
            selectionCardColumn6.HeaderText = "拼音码";
            selectionCardColumn6.IsNameField = false;
            selectionCardColumn6.IsSeachColumn = true;
            selectionCardColumn6.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn6.Visiable = true;
            selectionCardColumn6.Width = 75;
            selectionCardColumn7.AutoFill = false;
            selectionCardColumn7.DataBindField = "WB_CODE";
            selectionCardColumn7.HeaderText = "五笔码";
            selectionCardColumn7.IsNameField = false;
            selectionCardColumn7.IsSeachColumn = true;
            selectionCardColumn7.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn7.Visiable = true;
            selectionCardColumn7.Width = 75;
            selectionCardColumn8.AutoFill = false;
            selectionCardColumn8.DataBindField = "PRICE";
            selectionCardColumn8.HeaderText = "价格";
            selectionCardColumn8.IsNameField = false;
            selectionCardColumn8.IsSeachColumn = false;
            selectionCardColumn8.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn8.Visiable = true;
            selectionCardColumn8.Width = 75;
            this.txtRegType.SelectionCardColumns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn5,
        selectionCardColumn6,
        selectionCardColumn7,
        selectionCardColumn8};
            this.txtRegType.SelectionCardFont = null;
            this.txtRegType.SelectionCardHeight = 230;
            this.txtRegType.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtRegType.SelectionCardRowHeaderWidth = 35;
            this.txtRegType.SelectionCardRowHeight = 23;
            this.txtRegType.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtRegType.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtRegType.SelectionCardWidth = 400;
            this.txtRegType.ShowRowNumber = true;
            this.txtRegType.ShowSelectionCardAfterEnter = true;
            this.txtRegType.Size = new System.Drawing.Size(134, 24);
            this.txtRegType.TabIndex = 1;
            this.txtRegType.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtRegType.Enter += new System.EventHandler(this.OnTextBoxEnter);
            // 
            // txtRegDoc
            // 
            this.txtRegDoc.AllowSelectedNullRow = false;
            this.txtRegDoc.DisplayField = "EMP_NAME";
            this.txtRegDoc.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRegDoc.Location = new System.Drawing.Point(545, 14);
            this.txtRegDoc.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByFirstChar;
            this.txtRegDoc.MaxLength = 10;
            this.txtRegDoc.MemberField = "EMPLOYEE_ID";
            this.txtRegDoc.MemberValue = null;
            this.txtRegDoc.Name = "txtRegDoc";
            this.txtRegDoc.NextControl = null;
            this.txtRegDoc.NextControlByEnter = false;
            this.txtRegDoc.OffsetX = 0;
            this.txtRegDoc.OffsetY = 0;
            this.txtRegDoc.QueryFields = new string[] {
        "PY_CODE",
        "WB_CODE",
        "EMP_NAME"};
            this.txtRegDoc.SelectedValue = null;
            this.txtRegDoc.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtRegDoc.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtRegDoc.SelectionCardColumnHeaderHeight = 30;
            selectionCardColumn1.AutoFill = true;
            selectionCardColumn1.DataBindField = "EMP_NAME";
            selectionCardColumn1.HeaderText = "医生姓名";
            selectionCardColumn1.IsNameField = false;
            selectionCardColumn1.IsSeachColumn = true;
            selectionCardColumn1.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn1.Visiable = true;
            selectionCardColumn1.Width = 75;
            selectionCardColumn2.AutoFill = false;
            selectionCardColumn2.DataBindField = "YS_TYPENAME";
            selectionCardColumn2.HeaderText = "医生级别";
            selectionCardColumn2.IsNameField = false;
            selectionCardColumn2.IsSeachColumn = false;
            selectionCardColumn2.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn2.Visiable = true;
            selectionCardColumn2.Width = 75;
            selectionCardColumn3.AutoFill = false;
            selectionCardColumn3.DataBindField = "PY_CODE";
            selectionCardColumn3.HeaderText = "五笔码";
            selectionCardColumn3.IsNameField = false;
            selectionCardColumn3.IsSeachColumn = true;
            selectionCardColumn3.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn3.Visiable = true;
            selectionCardColumn3.Width = 75;
            selectionCardColumn4.AutoFill = false;
            selectionCardColumn4.DataBindField = "WB_CODE";
            selectionCardColumn4.HeaderText = "拼音码";
            selectionCardColumn4.IsNameField = false;
            selectionCardColumn4.IsSeachColumn = true;
            selectionCardColumn4.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn4.Visiable = true;
            selectionCardColumn4.Width = 75;
            this.txtRegDoc.SelectionCardColumns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn1,
        selectionCardColumn2,
        selectionCardColumn3,
        selectionCardColumn4};
            this.txtRegDoc.SelectionCardFont = null;
            this.txtRegDoc.SelectionCardHeight = 230;
            this.txtRegDoc.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtRegDoc.SelectionCardRowHeaderWidth = 35;
            this.txtRegDoc.SelectionCardRowHeight = 23;
            this.txtRegDoc.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtRegDoc.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtRegDoc.SelectionCardWidth = 400;
            this.txtRegDoc.ShowRowNumber = true;
            this.txtRegDoc.ShowSelectionCardAfterEnter = false;
            this.txtRegDoc.Size = new System.Drawing.Size(123, 24);
            this.txtRegDoc.TabIndex = 2;
            this.txtRegDoc.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtRegDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRegDoc_KeyPress);
            this.txtRegDoc.Enter += new System.EventHandler(this.OnTextBoxEnter);
            // 
            // txtDocLevel
            // 
            this.txtDocLevel.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDocLevel.Location = new System.Drawing.Point(747, 14);
            this.txtDocLevel.Name = "txtDocLevel";
            this.txtDocLevel.ReadOnly = true;
            this.txtDocLevel.Size = new System.Drawing.Size(104, 24);
            this.txtDocLevel.TabIndex = 6;
            this.txtDocLevel.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(674, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "医生职称";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(470, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "医    生";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(255, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "挂号类别";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "挂号科室";
            // 
            // gbPatientInfo
            // 
            this.gbPatientInfo.Controls.Add(this.groupBox2);
            this.gbPatientInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbPatientInfo.Location = new System.Drawing.Point(0, 107);
            this.gbPatientInfo.Name = "gbPatientInfo";
            this.gbPatientInfo.Size = new System.Drawing.Size(997, 47);
            this.gbPatientInfo.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.txtRegDoc);
            this.groupBox2.Controls.Add(this.txtRegType);
            this.groupBox2.Controls.Add(this.txtRegDept);
            this.groupBox2.Controls.Add(this.txtDocLevel);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(997, 47);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "挂号信息";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStrip1.BackgroundImage")));
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 11F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRegister,
            this.btnCancelRegister,
            this.btnRefresh,
            this.btnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(997, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnRegister
            // 
            this.btnRegister.Image = ((System.Drawing.Image)(resources.GetObject("btnRegister.Image")));
            this.btnRegister.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(81, 28);
            this.btnRegister.Text = "挂号(&X)";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnCancelRegister
            // 
            this.btnCancelRegister.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelRegister.Image")));
            this.btnCancelRegister.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelRegister.Name = "btnCancelRegister";
            this.btnCancelRegister.Size = new System.Drawing.Size(81, 28);
            this.btnCancelRegister.Text = "退号(&T)";
            this.btnCancelRegister.Click += new System.EventHandler(this.btnCancelRegister_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(111, 28);
            this.btnRefresh.Text = "刷新列表(&S)";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(111, 28);
            this.btnClose.Text = "关闭窗口(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvRegList
            // 
            this.dgvRegList.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvRegList.AllowSortWhenClickColumnHeader = true;
            this.dgvRegList.AllowUserToAddRows = false;
            this.dgvRegList.AllowUserToDeleteRows = false;
            this.dgvRegList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRegList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRegList.ColumnHeadersHeight = 30;
            this.dgvRegList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRegList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PATNAME,
            this.VISITNO,
            this.CARDNO,
            this.REG_DEPT,
            this.REG_TYPE,
            this.REG_DOC,
            this.REG_FEE,
            this.REG_DATE,
            this.REG_INVOICENO,
            this.TICKETCODE,
            this.RECORD_FLAG,
            this.CHARGECODE});
            this.dgvRegList.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgvRegList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRegList.EnableHeadersVisualStyles = false;
            this.dgvRegList.HideSelectionCardWhenCustomInput = false;
            this.dgvRegList.Location = new System.Drawing.Point(0, 154);
            this.dgvRegList.MultiSelect = false;
            this.dgvRegList.Name = "dgvRegList";
            this.dgvRegList.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRegList.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRegList.RowTemplate.Height = 23;
            this.dgvRegList.SelectionCards = null;
            this.dgvRegList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvRegList.Size = new System.Drawing.Size(997, 296);
            this.dgvRegList.TabIndex = 2;
            this.dgvRegList.UseGradientBackgroundColor = false;
            this.dgvRegList.DoubleClick += new System.EventHandler(this.dgvRegList_DoubleClick);
            // 
            // PATNAME
            // 
            this.PATNAME.DataPropertyName = "PATNAME";
            this.PATNAME.HeaderText = "病人姓名";
            this.PATNAME.Name = "PATNAME";
            this.PATNAME.ReadOnly = true;
            // 
            // VISITNO
            // 
            this.VISITNO.DataPropertyName = "VISITNO";
            this.VISITNO.HeaderText = "门诊就诊号";
            this.VISITNO.Name = "VISITNO";
            this.VISITNO.ReadOnly = true;
            this.VISITNO.Width = 120;
            // 
            // CARDNO
            // 
            this.CARDNO.DataPropertyName = "CARDNO";
            this.CARDNO.HeaderText = "诊疗卡号";
            this.CARDNO.Name = "CARDNO";
            this.CARDNO.ReadOnly = true;
            this.CARDNO.Width = 120;
            // 
            // REG_DEPT
            // 
            this.REG_DEPT.DataPropertyName = "REG_DEPT";
            this.REG_DEPT.HeaderText = "挂号科室";
            this.REG_DEPT.Name = "REG_DEPT";
            this.REG_DEPT.ReadOnly = true;
            // 
            // REG_TYPE
            // 
            this.REG_TYPE.DataPropertyName = "REG_TYPE";
            this.REG_TYPE.HeaderText = "挂号类别";
            this.REG_TYPE.Name = "REG_TYPE";
            this.REG_TYPE.ReadOnly = true;
            // 
            // REG_DOC
            // 
            this.REG_DOC.DataPropertyName = "REG_DOC";
            this.REG_DOC.HeaderText = "挂号医生";
            this.REG_DOC.Name = "REG_DOC";
            this.REG_DOC.ReadOnly = true;
            // 
            // REG_FEE
            // 
            this.REG_FEE.DataPropertyName = "REG_FEE";
            this.REG_FEE.HeaderText = "费用";
            this.REG_FEE.Name = "REG_FEE";
            this.REG_FEE.ReadOnly = true;
            this.REG_FEE.Width = 80;
            // 
            // REG_DATE
            // 
            this.REG_DATE.DataPropertyName = "REG_DATE";
            this.REG_DATE.HeaderText = "挂号日期";
            this.REG_DATE.Name = "REG_DATE";
            this.REG_DATE.ReadOnly = true;
            this.REG_DATE.Width = 120;
            // 
            // REG_INVOICENO
            // 
            this.REG_INVOICENO.DataPropertyName = "REG_INVOICENO";
            this.REG_INVOICENO.HeaderText = "挂号凭据号";
            this.REG_INVOICENO.Name = "REG_INVOICENO";
            this.REG_INVOICENO.ReadOnly = true;
            // 
            // TICKETCODE
            // 
            this.TICKETCODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TICKETCODE.DataPropertyName = "TICKETCODE";
            this.TICKETCODE.HeaderText = "前缀";
            this.TICKETCODE.Name = "TICKETCODE";
            this.TICKETCODE.ReadOnly = true;
            // 
            // RECORD_FLAG
            // 
            this.RECORD_FLAG.DataPropertyName = "RECORD_FLAG";
            this.RECORD_FLAG.HeaderText = "状态";
            this.RECORD_FLAG.Name = "RECORD_FLAG";
            this.RECORD_FLAG.ReadOnly = true;
            this.RECORD_FLAG.Visible = false;
            // 
            // CHARGECODE
            // 
            this.CHARGECODE.DataPropertyName = "CHARGECODE";
            this.CHARGECODE.HeaderText = "CHARGECODE";
            this.CHARGECODE.Name = "CHARGECODE";
            this.CHARGECODE.ReadOnly = true;
            this.CHARGECODE.Visible = false;
            // 
            // FrmMzgh
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(997, 541);
            this.Name = "FrmMzgh";
            this.Text = "FrmMzgh";
            this.Load += new System.EventHandler(this.FrmMzgh_Load);
            this.plBaseToolbar.ResumeLayout(false);
            this.plBaseToolbar.PerformLayout();
            this.plBaseWorkArea.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbPatientInfo.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDocLevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private GWI.HIS.Windows.Controls.QueryTextBox txtPatName;
        private System.Windows.Forms.Label label6;
        //private System.Windows.Forms.ToolBarButton btnClear;
        //private System.Windows.Forms.ToolBarButton btnSave;
        private System.Windows.Forms.ComboBox cboSex;
        private System.Windows.Forms.ComboBox cboFeeType;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Panel gbPatientInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private GWI.HIS.Windows.Controls.QueryTextBox txtHisCard;
        private System.Windows.Forms.Label label1;
        private GWI.HIS.Windows.Controls.ToolStrip toolStrip1;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvRegList;
        private GWI.HIS.Windows.Controls.QueryTextBox txtRegDoc;
        private GWI.HIS.Windows.Controls.QueryTextBox txtRegType;
        private GWI.HIS.Windows.Controls.QueryTextBox txtRegDept;
        private System.Windows.Forms.ToolStripButton btnRegister;
        private System.Windows.Forms.ToolStripButton btnCancelRegister;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnClose;
        private GWI.HIS.Windows.Controls.QueryTextBox txtAge;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn VISITNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CARDNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn REG_DEPT;
        private System.Windows.Forms.DataGridViewTextBoxColumn REG_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn REG_DOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn REG_FEE;
        private System.Windows.Forms.DataGridViewTextBoxColumn REG_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn REG_INVOICENO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TICKETCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECORD_FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHARGECODE;
        private System.Windows.Forms.ComboBox cboAgeUnit;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAllergic;
        private System.Windows.Forms.TextBox txtLinkAddress;
        private System.Windows.Forms.TextBox txtTel;
    }
}