namespace HIS_MZDocManager
{
    partial class UCMedicalApply
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn5 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn6 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn7 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn8 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkLBMedicalItem = new System.Windows.Forms.CheckedListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gpBSearchItem = new System.Windows.Forms.GroupBox();
            this.qTxtMecicalItemQuery = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.cbBMedicalDept = new System.Windows.Forms.ComboBox();
            this.cbBMedicalClass = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gpBApplyInfo = new System.Windows.Forms.GroupBox();
            this.txtAssayTime = new System.Windows.Forms.TextBox();
            this.txtAssayItemName = new System.Windows.Forms.TextBox();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.cbBSample = new System.Windows.Forms.ComboBox();
            this.cbBParam = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.btAssayPrint = new GWI.HIS.Windows.Controls.Button();
            this.btAssayOK = new GWI.HIS.Windows.Controls.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dGVEAssay = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.gpBSearchItem.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gpBApplyInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVEAssay)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkLBMedicalItem);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 500);
            this.panel1.TabIndex = 0;
            // 
            // chkLBMedicalItem
            // 
            this.chkLBMedicalItem.CheckOnClick = true;
            this.chkLBMedicalItem.ColumnWidth = 280;
            this.chkLBMedicalItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLBMedicalItem.Font = new System.Drawing.Font("宋体", 10F);
            this.chkLBMedicalItem.FormattingEnabled = true;
            this.chkLBMedicalItem.HorizontalScrollbar = true;
            this.chkLBMedicalItem.Location = new System.Drawing.Point(0, 89);
            this.chkLBMedicalItem.MultiColumn = true;
            this.chkLBMedicalItem.Name = "chkLBMedicalItem";
            this.chkLBMedicalItem.Size = new System.Drawing.Size(390, 400);
            this.chkLBMedicalItem.TabIndex = 52;
            this.chkLBMedicalItem.UseCompatibleTextRendering = true;
            this.chkLBMedicalItem.SelectedIndexChanged += new System.EventHandler(this.chkLBMedicalItem_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gpBSearchItem);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(390, 89);
            this.panel3.TabIndex = 0;
            // 
            // gpBSearchItem
            // 
            this.gpBSearchItem.BackColor = System.Drawing.Color.Transparent;
            this.gpBSearchItem.Controls.Add(this.qTxtMecicalItemQuery);
            this.gpBSearchItem.Controls.Add(this.cbBMedicalDept);
            this.gpBSearchItem.Controls.Add(this.cbBMedicalClass);
            this.gpBSearchItem.Controls.Add(this.label27);
            this.gpBSearchItem.Controls.Add(this.label26);
            this.gpBSearchItem.Controls.Add(this.label18);
            this.gpBSearchItem.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpBSearchItem.ForeColor = System.Drawing.Color.Blue;
            this.gpBSearchItem.Location = new System.Drawing.Point(3, 3);
            this.gpBSearchItem.Name = "gpBSearchItem";
            this.gpBSearchItem.Size = new System.Drawing.Size(381, 76);
            this.gpBSearchItem.TabIndex = 46;
            this.gpBSearchItem.TabStop = false;
            this.gpBSearchItem.Text = "查找项目";
            // 
            // qTxtMecicalItemQuery
            // 
            this.qTxtMecicalItemQuery.AllowSelectedNullRow = false;
            this.qTxtMecicalItemQuery.DisplayField = "";
            this.qTxtMecicalItemQuery.Font = new System.Drawing.Font("宋体", 9F);
            this.qTxtMecicalItemQuery.ForeColor = System.Drawing.SystemColors.ControlText;
            this.qTxtMecicalItemQuery.Location = new System.Drawing.Point(71, 46);
            this.qTxtMecicalItemQuery.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.qTxtMecicalItemQuery.MemberField = "";
            this.qTxtMecicalItemQuery.MemberValue = null;
            this.qTxtMecicalItemQuery.Name = "qTxtMecicalItemQuery";
            this.qTxtMecicalItemQuery.NextControl = null;
            this.qTxtMecicalItemQuery.NextControlByEnter = false;
            this.qTxtMecicalItemQuery.OffsetX = 0;
            this.qTxtMecicalItemQuery.OffsetY = 0;
            this.qTxtMecicalItemQuery.QueryFields = new string[] {
        "Py_Code",
        "Wb_Code"};
            this.qTxtMecicalItemQuery.SelectedValue = null;
            this.qTxtMecicalItemQuery.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.qTxtMecicalItemQuery.SelectionCardBackColor = System.Drawing.Color.White;
            this.qTxtMecicalItemQuery.SelectionCardColumnHeaderHeight = 30;
            selectionCardColumn5.AutoFill = false;
            selectionCardColumn5.DataBindField = "Order_Id";
            selectionCardColumn5.HeaderText = "项目编码";
            selectionCardColumn5.IsSeachColumn = false;
            selectionCardColumn5.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn5.Visiable = true;
            selectionCardColumn5.Width = 75;
            selectionCardColumn6.AutoFill = false;
            selectionCardColumn6.DataBindField = "Order_Name";
            selectionCardColumn6.HeaderText = "项目名称";
            selectionCardColumn6.IsSeachColumn = false;
            selectionCardColumn6.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn6.Visiable = true;
            selectionCardColumn6.Width = 75;
            selectionCardColumn7.AutoFill = false;
            selectionCardColumn7.DataBindField = "Py_Code";
            selectionCardColumn7.HeaderText = "拼音码";
            selectionCardColumn7.IsSeachColumn = true;
            selectionCardColumn7.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn7.Visiable = true;
            selectionCardColumn7.Width = 75;
            selectionCardColumn8.AutoFill = false;
            selectionCardColumn8.DataBindField = "Wb_Code";
            selectionCardColumn8.HeaderText = "五笔码";
            selectionCardColumn8.IsSeachColumn = true;
            selectionCardColumn8.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn8.Visiable = true;
            selectionCardColumn8.Width = 75;
            this.qTxtMecicalItemQuery.SelectionCardColumns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn5,
        selectionCardColumn6,
        selectionCardColumn7,
        selectionCardColumn8};
            this.qTxtMecicalItemQuery.SelectionCardFont = null;
            this.qTxtMecicalItemQuery.SelectionCardHeight = 250;
            this.qTxtMecicalItemQuery.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.qTxtMecicalItemQuery.SelectionCardRowHeaderWidth = 35;
            this.qTxtMecicalItemQuery.SelectionCardRowHeight = 23;
            this.qTxtMecicalItemQuery.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.qTxtMecicalItemQuery.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.qTxtMecicalItemQuery.SelectionCardWidth = 250;
            this.qTxtMecicalItemQuery.ShowRowNumber = true;
            this.qTxtMecicalItemQuery.ShowSelectionCardAfterEnter = false;
            this.qTxtMecicalItemQuery.Size = new System.Drawing.Size(126, 21);
            this.qTxtMecicalItemQuery.TabIndex = 30;
            this.qTxtMecicalItemQuery.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            // 
            // cbBMedicalDept
            // 
            this.cbBMedicalDept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBMedicalDept.Font = new System.Drawing.Font("宋体", 9F);
            this.cbBMedicalDept.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbBMedicalDept.FormattingEnabled = true;
            this.cbBMedicalDept.Location = new System.Drawing.Point(71, 23);
            this.cbBMedicalDept.Name = "cbBMedicalDept";
            this.cbBMedicalDept.Size = new System.Drawing.Size(126, 20);
            this.cbBMedicalDept.TabIndex = 21;
            this.cbBMedicalDept.SelectedIndexChanged += new System.EventHandler(this.cbBMedicalDept_SelectedIndexChanged);
            // 
            // cbBMedicalClass
            // 
            this.cbBMedicalClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBMedicalClass.Font = new System.Drawing.Font("宋体", 9F);
            this.cbBMedicalClass.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbBMedicalClass.FormattingEnabled = true;
            this.cbBMedicalClass.Location = new System.Drawing.Point(272, 23);
            this.cbBMedicalClass.Name = "cbBMedicalClass";
            this.cbBMedicalClass.Size = new System.Drawing.Size(103, 20);
            this.cbBMedicalClass.TabIndex = 23;
            this.cbBMedicalClass.SelectedIndexChanged += new System.EventHandler(this.cbBMedicalClass_SelectedIndexChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("宋体", 9F);
            this.label27.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label27.Location = new System.Drawing.Point(2, 26);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(65, 12);
            this.label27.TabIndex = 20;
            this.label27.Text = "科室名称：";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("宋体", 9F);
            this.label26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label26.Location = new System.Drawing.Point(210, 26);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 12);
            this.label26.TabIndex = 22;
            this.label26.Text = "项目分类：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 9F);
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(2, 50);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 12);
            this.label18.TabIndex = 26;
            this.label18.Text = "检索项目：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Controls.Add(this.dGVEAssay);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(390, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(487, 500);
            this.panel2.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 193);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(487, 304);
            this.tabControl1.TabIndex = 53;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gpBApplyInfo);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(479, 279);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gpBApplyInfo
            // 
            this.gpBApplyInfo.BackColor = System.Drawing.Color.Transparent;
            this.gpBApplyInfo.Controls.Add(this.txtAssayTime);
            this.gpBApplyInfo.Controls.Add(this.txtAssayItemName);
            this.gpBApplyInfo.Controls.Add(this.txtMemo);
            this.gpBApplyInfo.Controls.Add(this.cbBSample);
            this.gpBApplyInfo.Controls.Add(this.cbBParam);
            this.gpBApplyInfo.Controls.Add(this.label16);
            this.gpBApplyInfo.Controls.Add(this.label35);
            this.gpBApplyInfo.Controls.Add(this.label36);
            this.gpBApplyInfo.Controls.Add(this.label38);
            this.gpBApplyInfo.Controls.Add(this.label37);
            this.gpBApplyInfo.Controls.Add(this.btAssayPrint);
            this.gpBApplyInfo.Controls.Add(this.btAssayOK);
            this.gpBApplyInfo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpBApplyInfo.ForeColor = System.Drawing.Color.Blue;
            this.gpBApplyInfo.Location = new System.Drawing.Point(6, 6);
            this.gpBApplyInfo.Name = "gpBApplyInfo";
            this.gpBApplyInfo.Size = new System.Drawing.Size(467, 269);
            this.gpBApplyInfo.TabIndex = 52;
            this.gpBApplyInfo.TabStop = false;
            this.gpBApplyInfo.Text = "申请信息";
            // 
            // txtAssayTime
            // 
            this.txtAssayTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssayTime.BackColor = System.Drawing.Color.White;
            this.txtAssayTime.Font = new System.Drawing.Font("宋体", 9F);
            this.txtAssayTime.ForeColor = System.Drawing.Color.Blue;
            this.txtAssayTime.Location = new System.Drawing.Point(71, 45);
            this.txtAssayTime.Name = "txtAssayTime";
            this.txtAssayTime.ReadOnly = true;
            this.txtAssayTime.Size = new System.Drawing.Size(390, 21);
            this.txtAssayTime.TabIndex = 46;
            this.txtAssayTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAssayItemName
            // 
            this.txtAssayItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssayItemName.BackColor = System.Drawing.SystemColors.Window;
            this.txtAssayItemName.Font = new System.Drawing.Font("宋体", 9F);
            this.txtAssayItemName.ForeColor = System.Drawing.Color.Blue;
            this.txtAssayItemName.Location = new System.Drawing.Point(71, 19);
            this.txtAssayItemName.Name = "txtAssayItemName";
            this.txtAssayItemName.ReadOnly = true;
            this.txtAssayItemName.Size = new System.Drawing.Size(390, 21);
            this.txtAssayItemName.TabIndex = 45;
            this.txtAssayItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMemo
            // 
            this.txtMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMemo.BackColor = System.Drawing.Color.White;
            this.txtMemo.Font = new System.Drawing.Font("宋体", 9F);
            this.txtMemo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtMemo.Location = new System.Drawing.Point(2, 137);
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(459, 95);
            this.txtMemo.TabIndex = 43;
            // 
            // cbBSample
            // 
            this.cbBSample.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBSample.BackColor = System.Drawing.Color.White;
            this.cbBSample.Font = new System.Drawing.Font("宋体", 9F);
            this.cbBSample.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbBSample.FormattingEnabled = true;
            this.cbBSample.Location = new System.Drawing.Point(71, 71);
            this.cbBSample.Name = "cbBSample";
            this.cbBSample.Size = new System.Drawing.Size(390, 20);
            this.cbBSample.TabIndex = 37;
            // 
            // cbBParam
            // 
            this.cbBParam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBParam.BackColor = System.Drawing.Color.White;
            this.cbBParam.Font = new System.Drawing.Font("宋体", 9F);
            this.cbBParam.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbBParam.FormattingEnabled = true;
            this.cbBParam.Location = new System.Drawing.Point(71, 95);
            this.cbBParam.Name = "cbBParam";
            this.cbBParam.Size = new System.Drawing.Size(390, 20);
            this.cbBParam.TabIndex = 41;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 9F);
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(2, 49);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 31;
            this.label16.Text = "申请时间：";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.Font = new System.Drawing.Font("宋体", 9F);
            this.label35.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label35.Location = new System.Drawing.Point(2, 23);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(65, 12);
            this.label35.TabIndex = 38;
            this.label35.Text = "当前项目：";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.Font = new System.Drawing.Font("宋体", 9F);
            this.label36.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label36.Location = new System.Drawing.Point(2, 74);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(65, 12);
            this.label36.TabIndex = 36;
            this.label36.Text = "化验样本：";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.Transparent;
            this.label38.Font = new System.Drawing.Font("宋体", 9F);
            this.label38.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label38.Location = new System.Drawing.Point(2, 122);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(65, 12);
            this.label38.TabIndex = 42;
            this.label38.Text = "备  注  ：";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.Color.Transparent;
            this.label37.Font = new System.Drawing.Font("宋体", 9F);
            this.label37.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label37.Location = new System.Drawing.Point(2, 98);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(65, 12);
            this.label37.TabIndex = 40;
            this.label37.Text = "附加说明：";
            // 
            // btAssayPrint
            // 
            this.btAssayPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAssayPrint.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.OtherProcess;
            this.btAssayPrint.FixedWidth = true;
            this.btAssayPrint.Font = new System.Drawing.Font("宋体", 9F);
            this.btAssayPrint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btAssayPrint.Location = new System.Drawing.Point(243, 238);
            this.btAssayPrint.Name = "btAssayPrint";
            this.btAssayPrint.Size = new System.Drawing.Size(90, 25);
            this.btAssayPrint.TabIndex = 34;
            this.btAssayPrint.Text = "打印";
            this.btAssayPrint.UseVisualStyleBackColor = true;
            // 
            // btAssayOK
            // 
            this.btAssayOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAssayOK.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.OtherProcess;
            this.btAssayOK.FixedWidth = true;
            this.btAssayOK.Font = new System.Drawing.Font("宋体", 9F);
            this.btAssayOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btAssayOK.Location = new System.Drawing.Point(340, 238);
            this.btAssayOK.Name = "btAssayOK";
            this.btAssayOK.Size = new System.Drawing.Size(90, 25);
            this.btAssayOK.TabIndex = 33;
            this.btAssayOK.Text = "提交";
            this.btAssayOK.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(479, 282);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dGVEAssay
            // 
            this.dGVEAssay.AllowUserToAddRows = false;
            this.dGVEAssay.AllowUserToDeleteRows = false;
            this.dGVEAssay.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVEAssay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dGVEAssay.ColumnHeadersHeight = 25;
            this.dGVEAssay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dGVEAssay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVEAssay.DefaultCellStyle = dataGridViewCellStyle5;
            this.dGVEAssay.Dock = System.Windows.Forms.DockStyle.Top;
            this.dGVEAssay.EnableHeadersVisualStyles = false;
            this.dGVEAssay.Location = new System.Drawing.Point(0, 0);
            this.dGVEAssay.MultiSelect = false;
            this.dGVEAssay.Name = "dGVEAssay";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVEAssay.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dGVEAssay.RowHeadersWidth = 25;
            this.dGVEAssay.RowTemplate.Height = 23;
            this.dGVEAssay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVEAssay.Size = new System.Drawing.Size(487, 193);
            this.dGVEAssay.TabIndex = 51;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Item_Id";
            this.dataGridViewTextBoxColumn3.HeaderText = "项目编码";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 75;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Item_Name";
            this.dataGridViewTextBoxColumn4.HeaderText = "项目名称";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Dept_Name";
            this.dataGridViewTextBoxColumn5.HeaderText = "执行科室";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Apply_Date";
            this.dataGridViewTextBoxColumn6.HeaderText = "申请时间";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 110;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Price";
            this.dataGridViewTextBoxColumn7.HeaderText = "价格";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Width = 60;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Sample";
            this.dataGridViewTextBoxColumn8.HeaderText = "化验样本";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn8.Width = 90;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Param";
            this.dataGridViewTextBoxColumn9.HeaderText = "附加说明";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn9.Width = 90;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Memo";
            this.dataGridViewTextBoxColumn10.HeaderText = "备注";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn10.Width = 200;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn11.HeaderText = "状态";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn11.Width = 70;
            // 
            // UCMedicalApply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UCMedicalApply";
            this.Size = new System.Drawing.Size(877, 500);
            this.Load += new System.EventHandler(this.UCMedicalApply_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.gpBSearchItem.ResumeLayout(false);
            this.gpBSearchItem.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gpBApplyInfo.ResumeLayout(false);
            this.gpBApplyInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVEAssay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox gpBSearchItem;
        private GWI.HIS.Windows.Controls.QueryTextBox qTxtMecicalItemQuery;
        private System.Windows.Forms.ComboBox cbBMedicalDept;
        private System.Windows.Forms.ComboBox cbBMedicalClass;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckedListBox chkLBMedicalItem;
        private System.Windows.Forms.DataGridView dGVEAssay;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.GroupBox gpBApplyInfo;
        private System.Windows.Forms.TextBox txtAssayTime;
        private System.Windows.Forms.TextBox txtAssayItemName;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.ComboBox cbBSample;
        private System.Windows.Forms.ComboBox cbBParam;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label37;
        private GWI.HIS.Windows.Controls.Button btAssayPrint;
        private GWI.HIS.Windows.Controls.Button btAssayOK;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}
