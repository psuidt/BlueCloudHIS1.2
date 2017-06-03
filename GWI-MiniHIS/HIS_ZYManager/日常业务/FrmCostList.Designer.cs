namespace HIS_ZYManager
{
    partial class FrmCostList
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn1 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn2 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn3 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCostList));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.dgFee = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.XD = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbPresType = new System.Windows.Forms.ComboBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.tb_drugname = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbpatName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbInpatNo = new GWMHIS.PublicControls.InpatientNOTextBox(this.components);
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.lbExtFee = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lbCoseTolFee = new System.Windows.Forms.Label();
            this.lbChargeTolFee = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpEdate = new System.Windows.Forms.DateTimePicker();
            this.dtpBdate = new System.Windows.Forms.DateTimePicker();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolbrush = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolclose = new System.Windows.Forms.ToolStripButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFee)).BeginInit();
            this.panel2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvPatList
            // 
            this.lvPatList.BackColor = System.Drawing.Color.White;
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.toolStripContainer1);
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
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dgFee);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel2);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(787, 611);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(787, 636);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip2);
            // 
            // dgFee
            // 
            this.dgFee.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgFee.AllowSortWhenClickColumnHeader = false;
            this.dgFee.AllowUserToAddRows = false;
            this.dgFee.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgFee.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgFee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.XD,
            this.Column9,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgFee.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgFee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgFee.EnableHeadersVisualStyles = false;
            this.dgFee.HideSelectionCardWhenCustomInput = false;
            this.dgFee.Location = new System.Drawing.Point(0, 91);
            this.dgFee.Name = "dgFee";
            this.dgFee.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgFee.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgFee.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgFee.RowTemplate.Height = 23;
            this.dgFee.SelectionCards = null;
            this.dgFee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFee.Size = new System.Drawing.Size(787, 520);
            this.dgFee.TabIndex = 2;
            this.dgFee.UseGradientBackgroundColor = true;
            this.dgFee.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFee_CellClick);
            // 
            // XD
            // 
            this.XD.DataPropertyName = "XD";
            this.XD.HeaderText = "选择";
            this.XD.Name = "XD";
            this.XD.ReadOnly = true;
            this.XD.Width = 50;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "PRESORDERID";
            this.Column9.HeaderText = "处方号";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column9.Width = 60;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CostDate";
            this.Column1.HeaderText = "费用发生时间";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 140;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ItemName";
            this.Column2.HeaderText = "项目名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 220;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Standard";
            this.Column3.HeaderText = "规格";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Sell_Price";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N3";
            dataGridViewCellStyle2.NullValue = "0";
            this.Column4.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column4.HeaderText = "销售价";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 75;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Amount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = "0";
            this.Column5.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column5.HeaderText = "数量";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 75;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Unit";
            this.Column6.HeaderText = "单位";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 60;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Tolal_Fee";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.Column7.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column7.HeaderText = "金额";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "CostName";
            this.Column8.HeaderText = "记账员";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbPresType);
            this.panel2.Controls.Add(this.checkBox5);
            this.panel2.Controls.Add(this.checkBox4);
            this.panel2.Controls.Add(this.tb_drugname);
            this.panel2.Controls.Add(this.checkBox3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.tbpatName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tbInpatNo);
            this.panel2.Controls.Add(this.checkBox2);
            this.panel2.Controls.Add(this.lbExtFee);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.lbCoseTolFee);
            this.panel2.Controls.Add(this.lbChargeTolFee);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dtpEdate);
            this.panel2.Controls.Add(this.dtpBdate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(787, 91);
            this.panel2.TabIndex = 0;
            this.panel2.Controls.SetChildIndex(this.dtpBdate, 0);
            this.panel2.Controls.SetChildIndex(this.dtpEdate, 0);
            this.panel2.Controls.SetChildIndex(this.label3, 0);
            this.panel2.Controls.SetChildIndex(this.label4, 0);
            this.panel2.Controls.SetChildIndex(this.label7, 0);
            this.panel2.Controls.SetChildIndex(this.label8, 0);
            this.panel2.Controls.SetChildIndex(this.lbChargeTolFee, 0);
            this.panel2.Controls.SetChildIndex(this.lbCoseTolFee, 0);
            this.panel2.Controls.SetChildIndex(this.label16, 0);
            this.panel2.Controls.SetChildIndex(this.lbExtFee, 0);
            this.panel2.Controls.SetChildIndex(this.checkBox2, 0);
            this.panel2.Controls.SetChildIndex(this.tbInpatNo, 0);
            this.panel2.Controls.SetChildIndex(this.label2, 0);
            this.panel2.Controls.SetChildIndex(this.tbpatName, 0);
            this.panel2.Controls.SetChildIndex(this.label5, 0);
            this.panel2.Controls.SetChildIndex(this.checkBox3, 0);
            this.panel2.Controls.SetChildIndex(this.tb_drugname, 0);
            this.panel2.Controls.SetChildIndex(this.checkBox4, 0);
            this.panel2.Controls.SetChildIndex(this.checkBox5, 0);
            this.panel2.Controls.SetChildIndex(this.cbPresType, 0);
            // 
            // cbPresType
            // 
            this.cbPresType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPresType.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbPresType.FormattingEnabled = true;
            this.cbPresType.Items.AddRange(new object[] {
            "长期账单",
            "临时账单"});
            this.cbPresType.Location = new System.Drawing.Point(363, 51);
            this.cbPresType.Name = "cbPresType";
            this.cbPresType.Size = new System.Drawing.Size(121, 21);
            this.cbPresType.TabIndex = 50;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(341, 55);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(15, 14);
            this.checkBox5.TabIndex = 49;
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.BackColor = System.Drawing.Color.Transparent;
            this.checkBox4.Location = new System.Drawing.Point(65, 76);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(48, 16);
            this.checkBox4.TabIndex = 48;
            this.checkBox4.Text = "反选";
            this.checkBox4.UseVisualStyleBackColor = false;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // tb_drugname
            // 
            this.tb_drugname.AllowSelectedNullRow = false;
            this.tb_drugname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_drugname.DisplayField = "ITEMNAME";
            this.tb_drugname.Enabled = false;
            this.tb_drugname.Location = new System.Drawing.Point(577, 51);
            this.tb_drugname.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByFirstChar;
            this.tb_drugname.MemberField = "ITEMID";
            this.tb_drugname.MemberValue = null;
            this.tb_drugname.Name = "tb_drugname";
            this.tb_drugname.NextControl = null;
            this.tb_drugname.NextControlByEnter = false;
            this.tb_drugname.OffsetX = 0;
            this.tb_drugname.OffsetY = 0;
            this.tb_drugname.QueryFields = new string[] {
        "PY_CODE",
        "WB_CODE",
        "ITEMNAME"};
            this.tb_drugname.SelectedValue = null;
            this.tb_drugname.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.tb_drugname.SelectionCardBackColor = System.Drawing.Color.White;
            this.tb_drugname.SelectionCardColumnHeaderHeight = 30;
            selectionCardColumn1.AutoFill = false;
            selectionCardColumn1.DataBindField = "ITEMID";
            selectionCardColumn1.HeaderText = "代码";
            selectionCardColumn1.IsNameField = false;
            selectionCardColumn1.IsSeachColumn = false;
            selectionCardColumn1.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn1.Visiable = true;
            selectionCardColumn1.Width = 75;
            selectionCardColumn2.AutoFill = true;
            selectionCardColumn2.DataBindField = "ITEMNAME";
            selectionCardColumn2.HeaderText = "名称";
            selectionCardColumn2.IsNameField = false;
            selectionCardColumn2.IsSeachColumn = true;
            selectionCardColumn2.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn2.Visiable = true;
            selectionCardColumn2.Width = 75;
            selectionCardColumn3.AutoFill = false;
            selectionCardColumn3.DataBindField = "address";
            selectionCardColumn3.HeaderText = "厂家";
            selectionCardColumn3.IsNameField = false;
            selectionCardColumn3.IsSeachColumn = false;
            selectionCardColumn3.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn3.Visiable = true;
            selectionCardColumn3.Width = 120;
            this.tb_drugname.SelectionCardColumns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn1,
        selectionCardColumn2,
        selectionCardColumn3};
            this.tb_drugname.SelectionCardFont = null;
            this.tb_drugname.SelectionCardHeight = 250;
            this.tb_drugname.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.tb_drugname.SelectionCardRowHeaderWidth = 35;
            this.tb_drugname.SelectionCardRowHeight = 23;
            this.tb_drugname.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.tb_drugname.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.Page;
            this.tb_drugname.SelectionCardWidth = 250;
            this.tb_drugname.ShowRowNumber = true;
            this.tb_drugname.ShowSelectionCardAfterEnter = false;
            this.tb_drugname.Size = new System.Drawing.Size(208, 21);
            this.tb_drugname.TabIndex = 46;
            this.tb_drugname.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.BackColor = System.Drawing.Color.Transparent;
            this.checkBox3.Location = new System.Drawing.Point(18, 76);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(48, 16);
            this.checkBox3.TabIndex = 47;
            this.checkBox3.Text = "全选";
            this.checkBox3.UseVisualStyleBackColor = false;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(190, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 45;
            this.label5.Text = "姓名";
            // 
            // tbpatName
            // 
            this.tbpatName.BackColor = System.Drawing.Color.Transparent;
            this.tbpatName.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbpatName.ForeColor = System.Drawing.Color.Blue;
            this.tbpatName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbpatName.Location = new System.Drawing.Point(233, 13);
            this.tbpatName.Name = "tbpatName";
            this.tbpatName.Size = new System.Drawing.Size(100, 23);
            this.tbpatName.TabIndex = 44;
            this.tbpatName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(22, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 41;
            this.label2.Text = "住院号";
            // 
            // tbInpatNo
            // 
            this.tbInpatNo.BackColor = System.Drawing.Color.White;
            this.tbInpatNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInpatNo.EnabledFalseBackColor = System.Drawing.SystemColors.Control;
            this.tbInpatNo.EnabledTrueBackColor = System.Drawing.SystemColors.Window;
            this.tbInpatNo.EnterBackColor = System.Drawing.SystemColors.Window;
            this.tbInpatNo.EnterForeColor = System.Drawing.SystemColors.WindowText;
            this.tbInpatNo.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbInpatNo.Location = new System.Drawing.Point(69, 12);
            this.tbInpatNo.Name = "tbInpatNo";
            this.tbInpatNo.NextControl = null;
            this.tbInpatNo.PreviousControl = null;
            this.tbInpatNo.Size = new System.Drawing.Size(100, 23);
            this.tbInpatNo.TabIndex = 42;
            this.tbInpatNo.Text = "00000000";
            this.tbInpatNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInpatNo_KeyDown);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox2.Location = new System.Drawing.Point(496, 53);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(82, 18);
            this.checkBox2.TabIndex = 39;
            this.checkBox2.Text = "费用明细";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // lbExtFee
            // 
            this.lbExtFee.AutoSize = true;
            this.lbExtFee.ForeColor = System.Drawing.Color.Blue;
            this.lbExtFee.Location = new System.Drawing.Point(693, 19);
            this.lbExtFee.Name = "lbExtFee";
            this.lbExtFee.Size = new System.Drawing.Size(11, 12);
            this.lbExtFee.TabIndex = 37;
            this.lbExtFee.Text = "1";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(646, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 36;
            this.label16.Text = "余额：";
            // 
            // lbCoseTolFee
            // 
            this.lbCoseTolFee.AutoSize = true;
            this.lbCoseTolFee.ForeColor = System.Drawing.Color.Blue;
            this.lbCoseTolFee.Location = new System.Drawing.Point(562, 19);
            this.lbCoseTolFee.Name = "lbCoseTolFee";
            this.lbCoseTolFee.Size = new System.Drawing.Size(11, 12);
            this.lbCoseTolFee.TabIndex = 35;
            this.lbCoseTolFee.Text = "0";
            // 
            // lbChargeTolFee
            // 
            this.lbChargeTolFee.AutoSize = true;
            this.lbChargeTolFee.ForeColor = System.Drawing.Color.Blue;
            this.lbChargeTolFee.Location = new System.Drawing.Point(413, 19);
            this.lbChargeTolFee.Name = "lbChargeTolFee";
            this.lbChargeTolFee.Size = new System.Drawing.Size(11, 12);
            this.lbChargeTolFee.TabIndex = 34;
            this.lbChargeTolFee.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(496, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 33;
            this.label8.Text = "累计记账：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(349, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 32;
            this.label7.Text = "累计交费：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(223, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "至";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(102, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "从";
            // 
            // dtpEdate
            // 
            this.dtpEdate.CustomFormat = "yyyy-MM-dd";
            this.dtpEdate.Enabled = false;
            this.dtpEdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEdate.Location = new System.Drawing.Point(250, 51);
            this.dtpEdate.Name = "dtpEdate";
            this.dtpEdate.Size = new System.Drawing.Size(83, 21);
            this.dtpEdate.TabIndex = 1;
            // 
            // dtpBdate
            // 
            this.dtpBdate.CustomFormat = "yyyy-MM-dd";
            this.dtpBdate.Enabled = false;
            this.dtpBdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBdate.Location = new System.Drawing.Point(129, 51);
            this.dtpBdate.Name = "dtpBdate";
            this.dtpBdate.Size = new System.Drawing.Size(90, 21);
            this.dtpBdate.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Font = new System.Drawing.Font("宋体", 10F);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbrush,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolclose});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(462, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // toolbrush
            // 
            this.toolbrush.Image = ((System.Drawing.Image)(resources.GetObject("toolbrush.Image")));
            this.toolbrush.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbrush.Name = "toolbrush";
            this.toolbrush.Size = new System.Drawing.Size(83, 22);
            this.toolbrush.Text = "查询(F2)";
            this.toolbrush.Click += new System.EventHandler(this.toolbrush_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(139, 22);
            this.toolStripButton1.Text = "显示未发药的处方";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(146, 22);
            this.toolStripButton2.Text = "冲账/取消冲账(F4)";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolclose
            // 
            this.toolclose.Image = ((System.Drawing.Image)(resources.GetObject("toolclose.Image")));
            this.toolclose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolclose.Name = "toolclose";
            this.toolclose.Size = new System.Drawing.Size(76, 22);
            this.toolclose.Text = "关闭(&C)";
            this.toolclose.Click += new System.EventHandler(this.toolclose_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox1.Location = new System.Drawing.Point(18, 52);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(82, 18);
            this.checkBox1.TabIndex = 38;
            this.checkBox1.Text = "选择时间";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(206, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 43;
            this.label1.Text = "姓名";
            // 
            // FrmCostList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.FormTitle = "费用冲账";
            this.KeyPreview = true;
            this.Name = "FrmCostList";
            this.Text = "费用冲账";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCostList_KeyDown);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.plBaseWorkArea.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFee)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolclose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtpEdate;
        private System.Windows.Forms.DateTimePicker dtpBdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton toolbrush;
        private System.Windows.Forms.Label lbExtFee;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lbCoseTolFee;
        private System.Windows.Forms.Label lbChargeTolFee;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label tbpatName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private GWMHIS.PublicControls.InpatientNOTextBox tbInpatNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private GWI.HIS.Windows.Controls.QueryTextBox tb_drugname;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgFee;
        private System.Windows.Forms.ComboBox cbPresType;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn XD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}