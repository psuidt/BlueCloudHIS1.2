namespace HIS_YPManager
{
    partial class FrmStoreLimitQuery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStoreLimitQuery));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cobQueryType = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgrdDrugInfo = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuildPlan = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtQueryCode = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cobDrugType = new System.Windows.Forms.ComboBox();
            this.MAKERDICID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISSELECT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USEUNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRADEPRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdDrugInfo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plBaseToolbar.Controls.Add(this.cobDrugType);
            this.plBaseToolbar.Controls.Add(this.label4);
            this.plBaseToolbar.Controls.Add(this.txtQueryCode);
            this.plBaseToolbar.Controls.Add(this.btnQuery);
            this.plBaseToolbar.Controls.Add(this.btnBuildPlan);
            this.plBaseToolbar.Controls.Add(this.label3);
            this.plBaseToolbar.Controls.Add(this.btnCancel);
            this.plBaseToolbar.Controls.Add(this.cobQueryType);
            this.plBaseToolbar.Controls.Add(this.btnPrint);
            this.plBaseToolbar.Controls.Add(this.label1);
            this.plBaseToolbar.Size = new System.Drawing.Size(1016, 35);
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
            this.plBaseStatus.Location = new System.Drawing.Point(0, 734);
            this.plBaseStatus.Size = new System.Drawing.Size(1016, 0);
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.panel2);
            this.plBaseWorkArea.Controls.Add(this.panel1);
            this.plBaseWorkArea.Location = new System.Drawing.Point(0, 69);
            this.plBaseWorkArea.Size = new System.Drawing.Size(1016, 665);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(927, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "退出(&C)";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(765, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 24);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(439, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "定位查询";
            // 
            // cobQueryType
            // 
            this.cobQueryType.AllowDrop = true;
            this.cobQueryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobQueryType.FormattingEnabled = true;
            this.cobQueryType.Items.AddRange(new object[] {
            "列出高于库存上限药品",
            "列出低于库存下限药品"});
            this.cobQueryType.Location = new System.Drawing.Point(72, 5);
            this.cobQueryType.Name = "cobQueryType";
            this.cobQueryType.Size = new System.Drawing.Size(155, 21);
            this.cobQueryType.TabIndex = 0;
            this.cobQueryType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cobQueryType_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgrdDrugInfo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel2.Location = new System.Drawing.Point(0, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1016, 639);
            this.panel2.TabIndex = 1;
            // 
            // dgrdDrugInfo
            // 
            this.dgrdDrugInfo.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgrdDrugInfo.AllowSortWhenClickColumnHeader = false;
            this.dgrdDrugInfo.AllowUserToAddRows = false;
            this.dgrdDrugInfo.AllowUserToDeleteRows = false;
            this.dgrdDrugInfo.AllowUserToResizeRows = false;
            this.dgrdDrugInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgrdDrugInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdDrugInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdDrugInfo.ColumnHeadersHeight = 30;
            this.dgrdDrugInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MAKERDICID,
            this.ISSELECT,
            this.Column1,
            this.Column2,
            this.Column6,
            this.Column4,
            this.Column3,
            this.Column9,
            this.USEUNIT,
            this.Column7,
            this.TRADEPRICE,
            this.Column5});
            this.dgrdDrugInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdDrugInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgrdDrugInfo.EnableHeadersVisualStyles = false;
            this.dgrdDrugInfo.HideSelectionCardWhenCustomInput = false;
            this.dgrdDrugInfo.Location = new System.Drawing.Point(0, 0);
            this.dgrdDrugInfo.MultiSelect = false;
            this.dgrdDrugInfo.Name = "dgrdDrugInfo";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdDrugInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgrdDrugInfo.RowTemplate.Height = 23;
            this.dgrdDrugInfo.SelectionCards = null;
            this.dgrdDrugInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdDrugInfo.ShowCellToolTips = false;
            this.dgrdDrugInfo.Size = new System.Drawing.Size(1016, 639);
            this.dgrdDrugInfo.TabIndex = 0;
            this.dgrdDrugInfo.UseGradientBackgroundColor = true;
            this.dgrdDrugInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrdDrugInfo_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 26);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1016, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "库存信息";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "查询条件";
            // 
            // btnBuildPlan
            // 
            this.btnBuildPlan.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBuildPlan.Image = ((System.Drawing.Image)(resources.GetObject("btnBuildPlan.Image")));
            this.btnBuildPlan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuildPlan.Location = new System.Drawing.Point(846, 3);
            this.btnBuildPlan.Name = "btnBuildPlan";
            this.btnBuildPlan.Size = new System.Drawing.Size(75, 24);
            this.btnBuildPlan.TabIndex = 8;
            this.btnBuildPlan.Text = "生成(&B)";
            this.btnBuildPlan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuildPlan.UseVisualStyleBackColor = true;
            this.btnBuildPlan.Click += new System.EventHandler(this.btnBuildPlan_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(684, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 24);
            this.btnQuery.TabIndex = 9;
            this.btnQuery.Text = "查询(&F)";
            this.btnQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtQueryCode
            // 
            this.txtQueryCode.AllowSelectedNullRow = false;
            this.txtQueryCode.DisplayField = "";
            this.txtQueryCode.Location = new System.Drawing.Point(508, 3);
            this.txtQueryCode.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtQueryCode.MemberField = "";
            this.txtQueryCode.MemberValue = null;
            this.txtQueryCode.Name = "txtQueryCode";
            this.txtQueryCode.NextControl = null;
            this.txtQueryCode.NextControlByEnter = false;
            this.txtQueryCode.OffsetX = 0;
            this.txtQueryCode.OffsetY = 0;
            this.txtQueryCode.QueryFields = null;
            this.txtQueryCode.SelectedValue = null;
            this.txtQueryCode.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtQueryCode.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtQueryCode.SelectionCardColumnHeaderHeight = 30;
            this.txtQueryCode.SelectionCardColumns = null;
            this.txtQueryCode.SelectionCardFont = null;
            this.txtQueryCode.SelectionCardHeight = 250;
            this.txtQueryCode.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtQueryCode.SelectionCardRowHeaderWidth = 35;
            this.txtQueryCode.SelectionCardRowHeight = 23;
            this.txtQueryCode.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtQueryCode.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtQueryCode.SelectionCardWidth = 250;
            this.txtQueryCode.ShowRowNumber = true;
            this.txtQueryCode.ShowSelectionCardAfterEnter = false;
            this.txtQueryCode.Size = new System.Drawing.Size(170, 23);
            this.txtQueryCode.TabIndex = 10;
            this.txtQueryCode.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "商品类型";
            // 
            // cobDrugType
            // 
            this.cobDrugType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobDrugType.FormattingEnabled = true;
            this.cobDrugType.Items.AddRange(new object[] {
            "全部药品",
            "西药",
            "中成药",
            "中药",
            "医用物资"});
            this.cobDrugType.Location = new System.Drawing.Point(304, 4);
            this.cobDrugType.Name = "cobDrugType";
            this.cobDrugType.Size = new System.Drawing.Size(129, 21);
            this.cobDrugType.TabIndex = 12;
            // 
            // MAKERDICID
            // 
            this.MAKERDICID.DataPropertyName = "MAKERDICID";
            this.MAKERDICID.HeaderText = "编码";
            this.MAKERDICID.Name = "MAKERDICID";
            this.MAKERDICID.ReadOnly = true;
            this.MAKERDICID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MAKERDICID.Width = 40;
            // 
            // ISSELECT
            // 
            this.ISSELECT.HeaderText = "生成选择";
            this.ISSELECT.Name = "ISSELECT";
            this.ISSELECT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ISSELECT.Width = 35;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "CHEMNAME";
            this.Column1.HeaderText = "化学名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "SPEC";
            this.Column2.HeaderText = "规格";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.DataPropertyName = "PRODUCTNAME";
            this.Column6.HeaderText = "生产厂家";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "UPPERLIMIT";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Format = "N0";
            this.Column4.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column4.HeaderText = "库存上限";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 70;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "CURRENTNUM";
            dataGridViewCellStyle3.Format = "N0";
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.HeaderText = "库存数量";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 65;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "LOWERLIMIT";
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.Format = "N0";
            this.Column9.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column9.HeaderText = "库存下限";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column9.Width = 70;
            // 
            // USEUNIT
            // 
            this.USEUNIT.DataPropertyName = "PACKUNITNAME";
            this.USEUNIT.HeaderText = "单位";
            this.USEUNIT.Name = "USEUNIT";
            this.USEUNIT.ReadOnly = true;
            this.USEUNIT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.USEUNIT.Width = 35;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "RETAILPRICE";
            dataGridViewCellStyle5.Format = "N3";
            this.Column7.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column7.HeaderText = "零售价";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column7.Width = 65;
            // 
            // TRADEPRICE
            // 
            this.TRADEPRICE.DataPropertyName = "TRADEPRICE";
            dataGridViewCellStyle6.Format = "N3";
            this.TRADEPRICE.DefaultCellStyle = dataGridViewCellStyle6;
            this.TRADEPRICE.HeaderText = "批发价";
            this.TRADEPRICE.Name = "TRADEPRICE";
            this.TRADEPRICE.ReadOnly = true;
            this.TRADEPRICE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TRADEPRICE.Width = 65;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "STOPUSE";
            this.Column5.HeaderText = "停用";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.Width = 35;
            // 
            // FrmStoreLimitQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormTitle = "库位高低储报警";
            this.Name = "FrmStoreLimitQuery";
            this.Text = "库位高低储报警";
            this.Load += new System.EventHandler(this.FrmStoreLimitQuery_Load);
            this.plBaseToolbar.ResumeLayout(false);
            this.plBaseToolbar.PerformLayout();
            this.plBaseWorkArea.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdDrugInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgrdDrugInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cobQueryType;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBuildPlan;
        private System.Windows.Forms.Button btnQuery;
        private GWI.HIS.Windows.Controls.QueryTextBox txtQueryCode;
        private System.Windows.Forms.ComboBox cobDrugType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAKERDICID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ISSELECT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn USEUNIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRADEPRICE;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
    }
}