namespace HIS_YPManager
{
    partial class FrmValidityDate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmValidityDate));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgrdDrugInfo = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.label1 = new System.Windows.Forms.Label();
            this.cobDrugType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValidyDays = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdDrugInfo)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Controls.Add(this.label3);
            this.plBaseToolbar.Controls.Add(this.btnClose);
            this.plBaseToolbar.Controls.Add(this.btnQuery);
            this.plBaseToolbar.Controls.Add(this.txtValidyDays);
            this.plBaseToolbar.Controls.Add(this.label2);
            this.plBaseToolbar.Controls.Add(this.cobDrugType);
            this.plBaseToolbar.Controls.Add(this.label1);
            this.plBaseToolbar.Size = new System.Drawing.Size(792, 36);
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
            this.plBaseStatus.Location = new System.Drawing.Point(0, 540);
            this.plBaseStatus.Size = new System.Drawing.Size(792, 26);
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.panel2);
            this.plBaseWorkArea.Controls.Add(this.panel1);
            this.plBaseWorkArea.Location = new System.Drawing.Point(0, 70);
            this.plBaseWorkArea.Size = new System.Drawing.Size(792, 470);
            // 
            // dgrdDrugInfo
            // 
            this.dgrdDrugInfo.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgrdDrugInfo.AllowSortWhenClickColumnHeader = true;
            this.dgrdDrugInfo.AllowUserToAddRows = false;
            this.dgrdDrugInfo.AllowUserToDeleteRows = false;
            this.dgrdDrugInfo.AllowUserToResizeRows = false;
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
            this.Column8,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgrdDrugInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdDrugInfo.EnableHeadersVisualStyles = false;
            this.dgrdDrugInfo.HideSelectionCardWhenCustomInput = false;
            this.dgrdDrugInfo.Location = new System.Drawing.Point(0, 0);
            this.dgrdDrugInfo.MultiSelect = false;
            this.dgrdDrugInfo.Name = "dgrdDrugInfo";
            this.dgrdDrugInfo.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdDrugInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdDrugInfo.RowHeadersWidth = 35;
            this.dgrdDrugInfo.RowTemplate.Height = 23;
            this.dgrdDrugInfo.SelectionCards = null;
            this.dgrdDrugInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdDrugInfo.Size = new System.Drawing.Size(792, 447);
            this.dgrdDrugInfo.TabIndex = 0;
            this.dgrdDrugInfo.UseGradientBackgroundColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "药品类型";
            // 
            // cobDrugType
            // 
            this.cobDrugType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobDrugType.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cobDrugType.FormattingEnabled = true;
            this.cobDrugType.Items.AddRange(new object[] {
            "西药",
            "中成药",
            "中药",
            "医用物资",
            "全部药品"});
            this.cobDrugType.Location = new System.Drawing.Point(77, 8);
            this.cobDrugType.Name = "cobDrugType";
            this.cobDrugType.Size = new System.Drawing.Size(108, 21);
            this.cobDrugType.TabIndex = 1;
            this.cobDrugType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cobDrugType_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(208, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "报警天数";
            // 
            // txtValidyDays
            // 
            this.txtValidyDays.AllowSelectedNullRow = false;
            this.txtValidyDays.DisplayField = "";
            this.txtValidyDays.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtValidyDays.Location = new System.Drawing.Point(277, 7);
            this.txtValidyDays.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtValidyDays.MemberField = "";
            this.txtValidyDays.MemberValue = null;
            this.txtValidyDays.Name = "txtValidyDays";
            this.txtValidyDays.NextControl = this.btnQuery;
            this.txtValidyDays.NextControlByEnter = true;
            this.txtValidyDays.OffsetX = 0;
            this.txtValidyDays.OffsetY = 0;
            this.txtValidyDays.QueryFields = null;
            this.txtValidyDays.SelectedValue = null;
            this.txtValidyDays.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtValidyDays.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtValidyDays.SelectionCardColumnHeaderHeight = 30;
            this.txtValidyDays.SelectionCardColumns = null;
            this.txtValidyDays.SelectionCardFont = null;
            this.txtValidyDays.SelectionCardHeight = 250;
            this.txtValidyDays.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtValidyDays.SelectionCardRowHeaderWidth = 35;
            this.txtValidyDays.SelectionCardRowHeight = 23;
            this.txtValidyDays.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtValidyDays.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtValidyDays.SelectionCardWidth = 250;
            this.txtValidyDays.ShowRowNumber = true;
            this.txtValidyDays.ShowSelectionCardAfterEnter = false;
            this.txtValidyDays.Size = new System.Drawing.Size(64, 23);
            this.txtValidyDays.TabIndex = 4;
            this.txtValidyDays.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.Integer;
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(404, 5);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(90, 27);
            this.btnQuery.TabIndex = 5;
            this.btnQuery.Text = "查询(&F)";
            this.btnQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(500, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 27);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "退出(&C)";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(348, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "天";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 23);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(790, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "药品信息";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgrdDrugInfo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(792, 447);
            this.panel2.TabIndex = 1;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "MAKERDICID";
            this.Column8.HeaderText = "编码";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 40;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "NAME";
            this.Column1.HeaderText = "药品品名";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "BATCHNUM";
            this.Column2.HeaderText = "批次号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 75;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "SPEC";
            this.Column3.HeaderText = "药品规格";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.DataPropertyName = "PRODUCTNAME";
            this.Column4.HeaderText = "生产厂商";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "CURRENTNUM";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.NullValue = null;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column5.HeaderText = "数量";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 65;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "PACKUNITNAME";
            this.Column6.HeaderText = "单位";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 45;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column7.DataPropertyName = "VALIDITYDATE";
            this.Column7.HeaderText = "到效日期";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // FrmValidityDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.FormTitle = "药品效期报警";
            this.Name = "FrmValidityDate";
            this.Text = "药品效期报警";
            this.Load += new System.EventHandler(this.FrmValidityDate_Load);
            this.plBaseToolbar.ResumeLayout(false);
            this.plBaseToolbar.PerformLayout();
            this.plBaseWorkArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdDrugInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GWI.HIS.Windows.Controls.DataGridViewEx dgrdDrugInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cobDrugType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnQuery;
        private GWI.HIS.Windows.Controls.QueryTextBox txtValidyDays;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}