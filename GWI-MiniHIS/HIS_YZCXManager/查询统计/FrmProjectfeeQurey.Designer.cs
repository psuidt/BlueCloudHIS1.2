namespace HIS_YZCXManager
{
    partial class FrmProjectfeeQurey
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProjectfeeQurey));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.treePorject = new System.Windows.Forms.TreeView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtQueryItem = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgrdDeptInfo = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgrdDocInfo = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPicture = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cobBeginDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cobEndDate = new System.Windows.Forms.DateTimePicker();
            this.radMZ = new System.Windows.Forms.RadioButton();
            this.radZY = new System.Windows.Forms.RadioButton();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdDeptInfo)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdDocInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plBaseToolbar.Controls.Add(this.btnQuit);
            this.plBaseToolbar.Controls.Add(this.btnQuery);
            this.plBaseToolbar.Controls.Add(this.radAll);
            this.plBaseToolbar.Controls.Add(this.radZY);
            this.plBaseToolbar.Controls.Add(this.radMZ);
            this.plBaseToolbar.Controls.Add(this.cobEndDate);
            this.plBaseToolbar.Controls.Add(this.label2);
            this.plBaseToolbar.Controls.Add(this.cobBeginDate);
            this.plBaseToolbar.Controls.Add(this.label1);
            this.plBaseToolbar.Size = new System.Drawing.Size(1016, 37);
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
            this.plBaseStatus.Location = new System.Drawing.Point(0, 706);
            this.plBaseStatus.Size = new System.Drawing.Size(1016, 28);
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.panel2);
            this.plBaseWorkArea.Controls.Add(this.panel1);
            this.plBaseWorkArea.Location = new System.Drawing.Point(0, 71);
            this.plBaseWorkArea.Size = new System.Drawing.Size(1016, 635);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 635);
            this.panel1.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.treePorject);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 62);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(230, 573);
            this.panel7.TabIndex = 2;
            // 
            // treePorject
            // 
            this.treePorject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treePorject.Location = new System.Drawing.Point(0, 0);
            this.treePorject.Name = "treePorject";
            this.treePorject.Size = new System.Drawing.Size(230, 573);
            this.treePorject.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtQueryItem);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(230, 62);
            this.panel3.TabIndex = 1;
            // 
            // txtQueryItem
            // 
            this.txtQueryItem.AllowSelectedNullRow = false;
            this.txtQueryItem.DisplayField = "";
            this.txtQueryItem.Location = new System.Drawing.Point(9, 32);
            this.txtQueryItem.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtQueryItem.MemberField = "";
            this.txtQueryItem.MemberValue = null;
            this.txtQueryItem.Name = "txtQueryItem";
            this.txtQueryItem.NextControl = null;
            this.txtQueryItem.NextControlByEnter = false;
            this.txtQueryItem.OffsetX = 0;
            this.txtQueryItem.OffsetY = 0;
            this.txtQueryItem.QueryFields = null;
            this.txtQueryItem.SelectedValue = null;
            this.txtQueryItem.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtQueryItem.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtQueryItem.SelectionCardColumnHeaderHeight = 30;
            this.txtQueryItem.SelectionCardColumns = null;
            this.txtQueryItem.SelectionCardFont = null;
            this.txtQueryItem.SelectionCardHeight = 250;
            this.txtQueryItem.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtQueryItem.SelectionCardRowHeaderWidth = 35;
            this.txtQueryItem.SelectionCardRowHeight = 23;
            this.txtQueryItem.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtQueryItem.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtQueryItem.SelectionCardWidth = 250;
            this.txtQueryItem.ShowRowNumber = true;
            this.txtQueryItem.ShowSelectionCardAfterEnter = false;
            this.txtQueryItem.Size = new System.Drawing.Size(215, 23);
            this.txtQueryItem.TabIndex = 1;
            this.txtQueryItem.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(7, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "查询大项目代码";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.pnlPicture);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(230, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(786, 635);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel4.Location = new System.Drawing.Point(0, 261);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(786, 374);
            this.panel4.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgrdDeptInfo);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(378, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(408, 374);
            this.panel6.TabIndex = 1;
            // 
            // dgrdDeptInfo
            // 
            this.dgrdDeptInfo.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgrdDeptInfo.AllowSortWhenClickColumnHeader = false;
            this.dgrdDeptInfo.AllowUserToAddRows = false;
            this.dgrdDeptInfo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdDeptInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdDeptInfo.ColumnHeadersHeight = 30;
            this.dgrdDeptInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgrdDeptInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdDeptInfo.EnableHeadersVisualStyles = false;
            this.dgrdDeptInfo.Location = new System.Drawing.Point(0, 0);
            this.dgrdDeptInfo.MultiSelect = false;
            this.dgrdDeptInfo.Name = "dgrdDeptInfo";
            this.dgrdDeptInfo.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdDeptInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgrdDeptInfo.RowTemplate.Height = 23;
            this.dgrdDeptInfo.SelectionCards = null;
            this.dgrdDeptInfo.Size = new System.Drawing.Size(408, 374);
            this.dgrdDeptInfo.TabIndex = 0;
            this.dgrdDeptInfo.UseGradientBackgroundColor = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PRESDEPTNAME";
            this.dataGridViewTextBoxColumn1.HeaderText = "科室名称";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PRESNUM";
            this.dataGridViewTextBoxColumn2.HeaderText = "开方次数";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TOTALFEE";
            this.dataGridViewTextBoxColumn3.HeaderText = "开方金额";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgrdDocInfo);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(378, 374);
            this.panel5.TabIndex = 0;
            // 
            // dgrdDocInfo
            // 
            this.dgrdDocInfo.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgrdDocInfo.AllowSortWhenClickColumnHeader = true;
            this.dgrdDocInfo.AllowUserToAddRows = false;
            this.dgrdDocInfo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdDocInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdDocInfo.ColumnHeadersHeight = 30;
            this.dgrdDocInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgrdDocInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdDocInfo.EnableHeadersVisualStyles = false;
            this.dgrdDocInfo.Location = new System.Drawing.Point(0, 0);
            this.dgrdDocInfo.MultiSelect = false;
            this.dgrdDocInfo.Name = "dgrdDocInfo";
            this.dgrdDocInfo.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdDocInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdDocInfo.RowTemplate.Height = 23;
            this.dgrdDocInfo.SelectionCards = null;
            this.dgrdDocInfo.Size = new System.Drawing.Size(378, 374);
            this.dgrdDocInfo.TabIndex = 0;
            this.dgrdDocInfo.UseGradientBackgroundColor = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "PRESDOCNAME";
            this.Column1.HeaderText = "医生名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "PRESNUM";
            this.Column2.HeaderText = "开方次数";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "TOTALFEE";
            this.Column3.HeaderText = "开方金额";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // pnlPicture
            // 
            this.pnlPicture.BackColor = System.Drawing.Color.White;
            this.pnlPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPicture.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPicture.Location = new System.Drawing.Point(0, 0);
            this.pnlPicture.Name = "pnlPicture";
            this.pnlPicture.Size = new System.Drawing.Size(786, 261);
            this.pnlPicture.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "开始时间";
            // 
            // cobBeginDate
            // 
            this.cobBeginDate.Location = new System.Drawing.Point(81, 5);
            this.cobBeginDate.Name = "cobBeginDate";
            this.cobBeginDate.Size = new System.Drawing.Size(134, 23);
            this.cobBeginDate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(233, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "结束时间";
            // 
            // cobEndDate
            // 
            this.cobEndDate.Location = new System.Drawing.Point(302, 5);
            this.cobEndDate.Name = "cobEndDate";
            this.cobEndDate.Size = new System.Drawing.Size(128, 23);
            this.cobEndDate.TabIndex = 3;
            // 
            // radMZ
            // 
            this.radMZ.AutoSize = true;
            this.radMZ.Checked = true;
            this.radMZ.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radMZ.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.radMZ.Location = new System.Drawing.Point(459, 7);
            this.radMZ.Name = "radMZ";
            this.radMZ.Size = new System.Drawing.Size(55, 18);
            this.radMZ.TabIndex = 4;
            this.radMZ.TabStop = true;
            this.radMZ.Text = "门诊";
            this.radMZ.UseVisualStyleBackColor = true;
            // 
            // radZY
            // 
            this.radZY.AutoSize = true;
            this.radZY.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radZY.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.radZY.Location = new System.Drawing.Point(518, 7);
            this.radZY.Name = "radZY";
            this.radZY.Size = new System.Drawing.Size(55, 18);
            this.radZY.TabIndex = 5;
            this.radZY.Text = "住院";
            this.radZY.UseVisualStyleBackColor = true;
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.radAll.Location = new System.Drawing.Point(577, 7);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(55, 18);
            this.radAll.TabIndex = 6;
            this.radAll.Text = "全部";
            this.radAll.UseVisualStyleBackColor = true;
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(849, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(77, 27);
            this.btnQuery.TabIndex = 7;
            this.btnQuery.Text = "统计(&F)";
            this.btnQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.Location = new System.Drawing.Point(932, 3);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(77, 27);
            this.btnQuit.TabIndex = 8;
            this.btnQuit.Text = "关闭(&C)";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // FrmProjectfeeQurey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormTitle = "项目金额分析";
            this.Name = "FrmProjectfeeQurey";
            this.Text = "项目金额分析";
            this.Load += new System.EventHandler(this.FrmProjectfeeQurey_Load);
            this.plBaseToolbar.ResumeLayout(false);
            this.plBaseToolbar.PerformLayout();
            this.plBaseWorkArea.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdDeptInfo)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdDocInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel pnlPicture;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treePorject;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.RadioButton radZY;
        private System.Windows.Forms.RadioButton radMZ;
        private System.Windows.Forms.DateTimePicker cobEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker cobBeginDate;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgrdDeptInfo;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgrdDocInfo;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel3;
        private GWI.HIS.Windows.Controls.QueryTextBox txtQueryItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}