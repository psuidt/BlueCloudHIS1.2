namespace HIS_ReportManager
{
    partial class FrmVindicatorConfig
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
                components.Dispose();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVindicatorConfig));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.btnSetting = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTabIndex = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.cboUC = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkAllowEdit = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtColWidth = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.txtHeight = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.txtWidth = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLocationY = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.txtLocationX = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.grpForignerInfo = new System.Windows.Forms.GroupBox();
            this.btnTestSQL = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtFilterSql = new System.Windows.Forms.TextBox();
            this.cboForignerName_Field = new System.Windows.Forms.ComboBox();
            this.cboForignerID_Field = new System.Windows.Forms.ComboBox();
            this.cboForignerTable = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtParamter_cn = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cboEnume = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboParam = new System.Windows.Forms.ComboBox();
            this.txtParaName = new System.Windows.Forms.TextBox();
            this.txtMaxLength = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tvwField = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.chkForignerKey = new System.Windows.Forms.CheckBox();
            this.btnConfirmField = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.btnFixedField = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpForignerInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(742, 489);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "关闭(&X)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(661, 489);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "刷新(&F)";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(580, 489);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.grpForignerInfo);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.tvwField);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(858, 463);
            this.panel1.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.btnSetting);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtTabIndex);
            this.groupBox3.Controls.Add(this.cboUC);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.chkAllowEdit);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtColWidth);
            this.groupBox3.Controls.Add(this.txtHeight);
            this.groupBox3.Controls.Add(this.txtWidth);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtLocationY);
            this.groupBox3.Controls.Add(this.txtLocationX);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(197, 317);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(661, 146);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "用户界面设置";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(182, 102);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(173, 12);
            this.label23.TabIndex = 22;
            this.label23.Text = "该字段在网格中显示时的列宽度";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(343, 17);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(174, 73);
            this.label22.TabIndex = 21;
            this.label22.Text = "字段在用户界面的控件展现设置，可通过控件布局设置多个字段在用户界面的布局方式";
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(343, 122);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(156, 24);
            this.btnSetting.TabIndex = 8;
            this.btnSetting.Text = "控件布局(&L)>>>";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(203, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 19;
            this.label12.Text = "TabIndex";
            // 
            // txtTabIndex
            // 
            this.txtTabIndex.AllowSelectedNullRow = false;
            this.txtTabIndex.DisplayField = "";
            this.txtTabIndex.Location = new System.Drawing.Point(262, 14);
            this.txtTabIndex.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtTabIndex.MaxLength = 4;
            this.txtTabIndex.MemberField = "";
            this.txtTabIndex.MemberValue = null;
            this.txtTabIndex.Name = "txtTabIndex";
            this.txtTabIndex.NextControl = null;
            this.txtTabIndex.NextControlByEnter = false;
            this.txtTabIndex.OffsetX = 0;
            this.txtTabIndex.OffsetY = 0;
            this.txtTabIndex.QueryFields = null;
            this.txtTabIndex.SelectedValue = null;
            this.txtTabIndex.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTabIndex.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtTabIndex.SelectionCardColumnHeaderHeight = 30;
            this.txtTabIndex.SelectionCardColumns = null;
            this.txtTabIndex.SelectionCardFont = null;
            this.txtTabIndex.SelectionCardHeight = 250;
            this.txtTabIndex.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtTabIndex.SelectionCardRowHeaderWidth = 35;
            this.txtTabIndex.SelectionCardRowHeight = 23;
            this.txtTabIndex.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtTabIndex.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtTabIndex.SelectionCardWidth = 250;
            this.txtTabIndex.ShowRowNumber = true;
            this.txtTabIndex.ShowSelectionCardAfterEnter = false;
            this.txtTabIndex.Size = new System.Drawing.Size(63, 21);
            this.txtTabIndex.TabIndex = 1;
            this.txtTabIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTabIndex.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.UInteger;
            // 
            // cboUC
            // 
            this.cboUC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUC.FormattingEnabled = true;
            this.cboUC.Location = new System.Drawing.Point(113, 14);
            this.cboUC.Name = "cboUC";
            this.cboUC.Size = new System.Drawing.Size(79, 20);
            this.cboUC.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 9;
            this.label11.Text = "显示控件类型";
            // 
            // chkAllowEdit
            // 
            this.chkAllowEdit.AutoSize = true;
            this.chkAllowEdit.Location = new System.Drawing.Point(29, 130);
            this.chkAllowEdit.Name = "chkAllowEdit";
            this.chkAllowEdit.Size = new System.Drawing.Size(132, 16);
            this.chkAllowEdit.TabIndex = 7;
            this.chkAllowEdit.Text = "在编辑状态允许修改";
            this.chkAllowEdit.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 7;
            this.label10.Text = "网格的列宽度";
            // 
            // txtColWidth
            // 
            this.txtColWidth.AllowSelectedNullRow = false;
            this.txtColWidth.DisplayField = "";
            this.txtColWidth.Location = new System.Drawing.Point(113, 99);
            this.txtColWidth.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtColWidth.MaxLength = 4;
            this.txtColWidth.MemberField = "";
            this.txtColWidth.MemberValue = null;
            this.txtColWidth.Name = "txtColWidth";
            this.txtColWidth.NextControl = null;
            this.txtColWidth.NextControlByEnter = false;
            this.txtColWidth.OffsetX = 0;
            this.txtColWidth.OffsetY = 0;
            this.txtColWidth.QueryFields = null;
            this.txtColWidth.SelectedValue = null;
            this.txtColWidth.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtColWidth.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtColWidth.SelectionCardColumnHeaderHeight = 30;
            this.txtColWidth.SelectionCardColumns = null;
            this.txtColWidth.SelectionCardFont = null;
            this.txtColWidth.SelectionCardHeight = 250;
            this.txtColWidth.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtColWidth.SelectionCardRowHeaderWidth = 35;
            this.txtColWidth.SelectionCardRowHeight = 23;
            this.txtColWidth.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtColWidth.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtColWidth.SelectionCardWidth = 250;
            this.txtColWidth.ShowRowNumber = true;
            this.txtColWidth.ShowSelectionCardAfterEnter = false;
            this.txtColWidth.Size = new System.Drawing.Size(63, 21);
            this.txtColWidth.TabIndex = 6;
            this.txtColWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtColWidth.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.UInteger;
            // 
            // txtHeight
            // 
            this.txtHeight.AllowSelectedNullRow = false;
            this.txtHeight.DisplayField = "";
            this.txtHeight.Location = new System.Drawing.Point(262, 70);
            this.txtHeight.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtHeight.MaxLength = 4;
            this.txtHeight.MemberField = "";
            this.txtHeight.MemberValue = null;
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.NextControl = null;
            this.txtHeight.NextControlByEnter = false;
            this.txtHeight.OffsetX = 0;
            this.txtHeight.OffsetY = 0;
            this.txtHeight.QueryFields = null;
            this.txtHeight.SelectedValue = null;
            this.txtHeight.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtHeight.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtHeight.SelectionCardColumnHeaderHeight = 30;
            this.txtHeight.SelectionCardColumns = null;
            this.txtHeight.SelectionCardFont = null;
            this.txtHeight.SelectionCardHeight = 250;
            this.txtHeight.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtHeight.SelectionCardRowHeaderWidth = 35;
            this.txtHeight.SelectionCardRowHeight = 23;
            this.txtHeight.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtHeight.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtHeight.SelectionCardWidth = 250;
            this.txtHeight.ShowRowNumber = true;
            this.txtHeight.ShowSelectionCardAfterEnter = false;
            this.txtHeight.Size = new System.Drawing.Size(63, 21);
            this.txtHeight.TabIndex = 5;
            this.txtHeight.Text = "30";
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHeight.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.UInteger;
            // 
            // txtWidth
            // 
            this.txtWidth.AllowSelectedNullRow = false;
            this.txtWidth.DisplayField = "";
            this.txtWidth.Location = new System.Drawing.Point(113, 71);
            this.txtWidth.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtWidth.MaxLength = 4;
            this.txtWidth.MemberField = "";
            this.txtWidth.MemberValue = null;
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.NextControl = null;
            this.txtWidth.NextControlByEnter = false;
            this.txtWidth.OffsetX = 0;
            this.txtWidth.OffsetY = 0;
            this.txtWidth.QueryFields = null;
            this.txtWidth.SelectedValue = null;
            this.txtWidth.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtWidth.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtWidth.SelectionCardColumnHeaderHeight = 30;
            this.txtWidth.SelectionCardColumns = null;
            this.txtWidth.SelectionCardFont = null;
            this.txtWidth.SelectionCardHeight = 250;
            this.txtWidth.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtWidth.SelectionCardRowHeaderWidth = 35;
            this.txtWidth.SelectionCardRowHeight = 23;
            this.txtWidth.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtWidth.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtWidth.SelectionCardWidth = 250;
            this.txtWidth.ShowRowNumber = true;
            this.txtWidth.ShowSelectionCardAfterEnter = false;
            this.txtWidth.Size = new System.Drawing.Size(63, 21);
            this.txtWidth.TabIndex = 4;
            this.txtWidth.Text = "75";
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWidth.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.UInteger;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(233, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "大小       宽:                     高:";
            // 
            // txtLocationY
            // 
            this.txtLocationY.AllowSelectedNullRow = false;
            this.txtLocationY.DisplayField = "";
            this.txtLocationY.Location = new System.Drawing.Point(262, 42);
            this.txtLocationY.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtLocationY.MaxLength = 4;
            this.txtLocationY.MemberField = "";
            this.txtLocationY.MemberValue = null;
            this.txtLocationY.Name = "txtLocationY";
            this.txtLocationY.NextControl = null;
            this.txtLocationY.NextControlByEnter = false;
            this.txtLocationY.OffsetX = 0;
            this.txtLocationY.OffsetY = 0;
            this.txtLocationY.QueryFields = null;
            this.txtLocationY.SelectedValue = null;
            this.txtLocationY.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLocationY.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtLocationY.SelectionCardColumnHeaderHeight = 30;
            this.txtLocationY.SelectionCardColumns = null;
            this.txtLocationY.SelectionCardFont = null;
            this.txtLocationY.SelectionCardHeight = 250;
            this.txtLocationY.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtLocationY.SelectionCardRowHeaderWidth = 35;
            this.txtLocationY.SelectionCardRowHeight = 23;
            this.txtLocationY.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtLocationY.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtLocationY.SelectionCardWidth = 250;
            this.txtLocationY.ShowRowNumber = true;
            this.txtLocationY.ShowSelectionCardAfterEnter = false;
            this.txtLocationY.Size = new System.Drawing.Size(63, 21);
            this.txtLocationY.TabIndex = 3;
            this.txtLocationY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLocationY.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.UInteger;
            // 
            // txtLocationX
            // 
            this.txtLocationX.AllowSelectedNullRow = false;
            this.txtLocationX.DisplayField = "";
            this.txtLocationX.Location = new System.Drawing.Point(113, 42);
            this.txtLocationX.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtLocationX.MaxLength = 4;
            this.txtLocationX.MemberField = "";
            this.txtLocationX.MemberValue = null;
            this.txtLocationX.Name = "txtLocationX";
            this.txtLocationX.NextControl = null;
            this.txtLocationX.NextControlByEnter = false;
            this.txtLocationX.OffsetX = 0;
            this.txtLocationX.OffsetY = 0;
            this.txtLocationX.QueryFields = null;
            this.txtLocationX.SelectedValue = null;
            this.txtLocationX.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLocationX.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtLocationX.SelectionCardColumnHeaderHeight = 30;
            this.txtLocationX.SelectionCardColumns = null;
            this.txtLocationX.SelectionCardFont = null;
            this.txtLocationX.SelectionCardHeight = 250;
            this.txtLocationX.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtLocationX.SelectionCardRowHeaderWidth = 35;
            this.txtLocationX.SelectionCardRowHeight = 23;
            this.txtLocationX.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtLocationX.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtLocationX.SelectionCardWidth = 250;
            this.txtLocationX.ShowRowNumber = true;
            this.txtLocationX.ShowSelectionCardAfterEnter = false;
            this.txtLocationX.Size = new System.Drawing.Size(63, 21);
            this.txtLocationX.TabIndex = 2;
            this.txtLocationX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLocationX.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.UInteger;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(233, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "位置        X:                      Y:";
            // 
            // grpForignerInfo
            // 
            this.grpForignerInfo.Controls.Add(this.btnTestSQL);
            this.grpForignerInfo.Controls.Add(this.label21);
            this.grpForignerInfo.Controls.Add(this.label20);
            this.grpForignerInfo.Controls.Add(this.label19);
            this.grpForignerInfo.Controls.Add(this.label18);
            this.grpForignerInfo.Controls.Add(this.txtFilterSql);
            this.grpForignerInfo.Controls.Add(this.cboForignerName_Field);
            this.grpForignerInfo.Controls.Add(this.cboForignerID_Field);
            this.grpForignerInfo.Controls.Add(this.cboForignerTable);
            this.grpForignerInfo.Controls.Add(this.label4);
            this.grpForignerInfo.Controls.Add(this.label7);
            this.grpForignerInfo.Controls.Add(this.label6);
            this.grpForignerInfo.Controls.Add(this.label5);
            this.grpForignerInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpForignerInfo.Enabled = false;
            this.grpForignerInfo.Location = new System.Drawing.Point(197, 150);
            this.grpForignerInfo.Name = "grpForignerInfo";
            this.grpForignerInfo.Size = new System.Drawing.Size(661, 167);
            this.grpForignerInfo.TabIndex = 13;
            this.grpForignerInfo.TabStop = false;
            this.grpForignerInfo.Text = "       ";
            // 
            // btnTestSQL
            // 
            this.btnTestSQL.Location = new System.Drawing.Point(343, 130);
            this.btnTestSQL.Name = "btnTestSQL";
            this.btnTestSQL.Size = new System.Drawing.Size(156, 23);
            this.btnTestSQL.TabIndex = 21;
            this.btnTestSQL.Text = "SQL测试(&T)";
            this.btnTestSQL.UseVisualStyleBackColor = true;
            this.btnTestSQL.Click += new System.EventHandler(this.btnTestSQL_Click);
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(343, 98);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(156, 48);
            this.label21.TabIndex = 20;
            this.label21.Text = "外键表数据的过滤条件(不带where关键字)";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(343, 72);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(101, 12);
            this.label20.TabIndex = 19;
            this.label20.Text = "外键表中实际字段";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(343, 47);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(173, 12);
            this.label19.TabIndex = 18;
            this.label19.Text = "该标识展现给用户的中文名字段";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(343, 20);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(125, 12);
            this.label18.TabIndex = 16;
            this.label18.Text = "外键数据来源的表名称";
            // 
            // txtFilterSql
            // 
            this.txtFilterSql.Location = new System.Drawing.Point(113, 95);
            this.txtFilterSql.Multiline = true;
            this.txtFilterSql.Name = "txtFilterSql";
            this.txtFilterSql.Size = new System.Drawing.Size(212, 60);
            this.txtFilterSql.TabIndex = 3;
            // 
            // cboForignerName_Field
            // 
            this.cboForignerName_Field.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboForignerName_Field.FormattingEnabled = true;
            this.cboForignerName_Field.Location = new System.Drawing.Point(113, 69);
            this.cboForignerName_Field.Name = "cboForignerName_Field";
            this.cboForignerName_Field.Size = new System.Drawing.Size(212, 20);
            this.cboForignerName_Field.TabIndex = 2;
            // 
            // cboForignerID_Field
            // 
            this.cboForignerID_Field.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboForignerID_Field.FormattingEnabled = true;
            this.cboForignerID_Field.Location = new System.Drawing.Point(113, 43);
            this.cboForignerID_Field.Name = "cboForignerID_Field";
            this.cboForignerID_Field.Size = new System.Drawing.Size(212, 20);
            this.cboForignerID_Field.TabIndex = 1;
            // 
            // cboForignerTable
            // 
            this.cboForignerTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboForignerTable.FormattingEnabled = true;
            this.cboForignerTable.Location = new System.Drawing.Point(113, 17);
            this.cboForignerTable.Name = "cboForignerTable";
            this.cboForignerTable.Size = new System.Drawing.Size(212, 20);
            this.cboForignerTable.TabIndex = 0;
            this.cboForignerTable.SelectedIndexChanged += new System.EventHandler(this.Combox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "外键对应表";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "过滤条件(SQL)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "字段物理名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "名称的字段";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtParamter_cn);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cboEnume);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cboParam);
            this.groupBox1.Controls.Add(this.txtParaName);
            this.groupBox1.Controls.Add(this.txtMaxLength);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(197, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(661, 150);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本属性";
            // 
            // txtParamter_cn
            // 
            this.txtParamter_cn.Enabled = false;
            this.txtParamter_cn.Location = new System.Drawing.Point(113, 43);
            this.txtParamter_cn.MaxLength = 10;
            this.txtParamter_cn.Name = "txtParamter_cn";
            this.txtParamter_cn.Size = new System.Drawing.Size(212, 21);
            this.txtParamter_cn.TabIndex = 17;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(27, 46);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 16;
            this.label15.Text = "参数别名";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(343, 122);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(197, 26);
            this.label17.TabIndex = 15;
            this.label17.Text = "提供枚举类型";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(343, 96);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 12);
            this.label16.TabIndex = 14;
            this.label16.Text = "字段的数据类型";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(343, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(149, 12);
            this.label14.TabIndex = 12;
            this.label14.Text = "字段在数据库中的实际名称";
            // 
            // cboEnume
            // 
            this.cboEnume.DisplayMember = "ENUMNAME";
            this.cboEnume.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEnume.FormattingEnabled = true;
            this.cboEnume.Location = new System.Drawing.Point(113, 119);
            this.cboEnume.Name = "cboEnume";
            this.cboEnume.Size = new System.Drawing.Size(212, 20);
            this.cboEnume.TabIndex = 3;
            this.cboEnume.ValueMember = "ID";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(27, 122);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 10;
            this.label13.Text = "枚举类名";
            // 
            // cboParam
            // 
            this.cboParam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParam.FormattingEnabled = true;
            this.cboParam.Location = new System.Drawing.Point(113, 67);
            this.cboParam.Name = "cboParam";
            this.cboParam.Size = new System.Drawing.Size(212, 20);
            this.cboParam.TabIndex = 2;
            this.cboParam.SelectedIndexChanged += new System.EventHandler(this.Combox_SelectedIndexChanged);
            // 
            // txtParaName
            // 
            this.txtParaName.Enabled = false;
            this.txtParaName.Location = new System.Drawing.Point(113, 17);
            this.txtParaName.MaxLength = 10;
            this.txtParaName.Name = "txtParaName";
            this.txtParaName.Size = new System.Drawing.Size(212, 21);
            this.txtParaName.TabIndex = 0;
            // 
            // txtMaxLength
            // 
            this.txtMaxLength.Location = new System.Drawing.Point(113, 93);
            this.txtMaxLength.MaxLength = 10;
            this.txtMaxLength.Name = "txtMaxLength";
            this.txtMaxLength.Size = new System.Drawing.Size(212, 21);
            this.txtMaxLength.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "参数类型";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "参数长度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "入参名称";
            // 
            // tvwField
            // 
            this.tvwField.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvwField.HideSelection = false;
            this.tvwField.Location = new System.Drawing.Point(0, 0);
            this.tvwField.Name = "tvwField";
            this.tvwField.Size = new System.Drawing.Size(197, 463);
            this.tvwField.TabIndex = 0;
            this.tvwField.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwField_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Devish Xls File.ico");
            this.imageList1.Images.SetKeyName(1, "Dervish Closed Folder.ico");
            // 
            // chkForignerKey
            // 
            this.chkForignerKey.AutoSize = true;
            this.chkForignerKey.BackColor = System.Drawing.Color.Transparent;
            this.chkForignerKey.Location = new System.Drawing.Point(332, 149);
            this.chkForignerKey.Name = "chkForignerKey";
            this.chkForignerKey.Size = new System.Drawing.Size(48, 16);
            this.chkForignerKey.TabIndex = 0;
            this.chkForignerKey.Text = "外键";
            this.chkForignerKey.UseVisualStyleBackColor = false;
            this.chkForignerKey.CheckedChanged += new System.EventHandler(this.chkForignerKey_CheckedChanged);
            // 
            // btnConfirmField
            // 
            this.btnConfirmField.Location = new System.Drawing.Point(0, 469);
            this.btnConfirmField.Name = "btnConfirmField";
            this.btnConfirmField.Size = new System.Drawing.Size(85, 23);
            this.btnConfirmField.TabIndex = 12;
            this.btnConfirmField.Text = "字段验证(&C)";
            this.btnConfirmField.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Location = new System.Drawing.Point(0, 495);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(306, 27);
            this.label24.TabIndex = 13;
            this.label24.Text = "检测数据库字段与实体字段是否一致,并以当前数据库字段为参照修正配置表中的字段配置";
            // 
            // btnFixedField
            // 
            this.btnFixedField.Location = new System.Drawing.Point(91, 469);
            this.btnFixedField.Name = "btnFixedField";
            this.btnFixedField.Size = new System.Drawing.Size(85, 23);
            this.btnFixedField.TabIndex = 14;
            this.btnFixedField.Text = "字段修复(&R)";
            this.btnFixedField.UseVisualStyleBackColor = true;
            // 
            // FrmVindicatorConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 546);
            this.Controls.Add(this.btnFixedField);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.btnConfirmField);
            this.Controls.Add(this.chkForignerKey);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVindicatorConfig";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "字段维护设置";
            this.Load += new System.EventHandler(this.FrmVindicatorConfig_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grpForignerInfo.ResumeLayout(false);
            this.grpForignerInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView tvwField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkForignerKey;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox grpForignerInfo;
        private GWI.HIS.Windows.Controls.QueryTextBox txtHeight;
        private GWI.HIS.Windows.Controls.QueryTextBox txtWidth;
        private System.Windows.Forms.Label label9;
        private GWI.HIS.Windows.Controls.QueryTextBox txtLocationY;
        private GWI.HIS.Windows.Controls.QueryTextBox txtLocationX;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboParam;
        private System.Windows.Forms.TextBox txtParaName;
        private System.Windows.Forms.TextBox txtMaxLength;
        private System.Windows.Forms.TextBox txtFilterSql;
        private System.Windows.Forms.ComboBox cboForignerName_Field;
        private System.Windows.Forms.ComboBox cboForignerID_Field;
        private System.Windows.Forms.ComboBox cboForignerTable;
        private System.Windows.Forms.CheckBox chkAllowEdit;
        private System.Windows.Forms.Label label10;
        private GWI.HIS.Windows.Controls.QueryTextBox txtColWidth;
        private System.Windows.Forms.ComboBox cboUC;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private GWI.HIS.Windows.Controls.QueryTextBox txtTabIndex;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox cboEnume;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnConfirmField;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnFixedField;
        private System.Windows.Forms.Button btnTestSQL;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtParamter_cn;
    }
}