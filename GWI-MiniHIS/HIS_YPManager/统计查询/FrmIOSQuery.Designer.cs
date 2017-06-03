namespace HIS_YPManager
{
    partial class FrmIOSQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIOSQuery));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgrdDrugIOS = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.cobQueryType = new System.Windows.Forms.ComboBox();
            this.lblQueryType = new System.Windows.Forms.Label();
            this.lblQueryMonth = new System.Windows.Forms.Label();
            this.lblQueryYear = new System.Windows.Forms.Label();
            this.cobQueryMonth = new System.Windows.Forms.ComboBox();
            this.cobQueryYear = new System.Windows.Forms.ComboBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plBaseWorkArea.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdDrugIOS)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Size = new System.Drawing.Size(1016, 0);
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
            this.plBaseStatus.Location = new System.Drawing.Point(0, 708);
            this.plBaseStatus.Size = new System.Drawing.Size(1016, 26);
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.panel2);
            this.plBaseWorkArea.Location = new System.Drawing.Point(0, 34);
            this.plBaseWorkArea.Size = new System.Drawing.Size(1016, 674);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1016, 674);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel4.Location = new System.Drawing.Point(0, 34);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1016, 640);
            this.panel4.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgrdDrugIOS);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 22);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1016, 618);
            this.panel6.TabIndex = 3;
            // 
            // dgrdDrugIOS
            // 
            this.dgrdDrugIOS.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgrdDrugIOS.AllowSortWhenClickColumnHeader = false;
            this.dgrdDrugIOS.AllowUserToAddRows = false;
            this.dgrdDrugIOS.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdDrugIOS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdDrugIOS.ColumnHeadersHeight = 35;
            this.dgrdDrugIOS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgrdDrugIOS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdDrugIOS.EnableHeadersVisualStyles = false;
            this.dgrdDrugIOS.Location = new System.Drawing.Point(0, 0);
            this.dgrdDrugIOS.MultiSelect = false;
            this.dgrdDrugIOS.Name = "dgrdDrugIOS";
            this.dgrdDrugIOS.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdDrugIOS.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdDrugIOS.RowHeadersVisible = false;
            this.dgrdDrugIOS.RowTemplate.Height = 23;
            this.dgrdDrugIOS.SelectionCards = null;
            this.dgrdDrugIOS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdDrugIOS.Size = new System.Drawing.Size(1016, 618);
            this.dgrdDrugIOS.TabIndex = 1;
            this.dgrdDrugIOS.UseGradientBackgroundColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1016, 22);
            this.panel5.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1016, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "药品进销存账务";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btnQuit);
            this.panel3.Controls.Add(this.btnPrint);
            this.panel3.Controls.Add(this.btnQuery);
            this.panel3.Controls.Add(this.cobQueryType);
            this.panel3.Controls.Add(this.lblQueryType);
            this.panel3.Controls.Add(this.lblQueryMonth);
            this.panel3.Controls.Add(this.lblQueryYear);
            this.panel3.Controls.Add(this.cobQueryMonth);
            this.panel3.Controls.Add(this.cobQueryYear);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1016, 34);
            this.panel3.TabIndex = 0;
            // 
            // btnQuit
            // 
            this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.Location = new System.Drawing.Point(725, 2);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(86, 26);
            this.btnQuit.TabIndex = 8;
            this.btnQuit.Text = "关闭(&C)";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(633, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(86, 26);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(541, 2);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(86, 26);
            this.btnQuery.TabIndex = 6;
            this.btnQuery.Text = "查询(&F)";
            this.btnQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // cobQueryType
            // 
            this.cobQueryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobQueryType.FormattingEnabled = true;
            this.cobQueryType.Items.AddRange(new object[] {
            "西药",
            "中药",
            "中成药",
            "医用物资",
            "全部药品"});
            this.cobQueryType.Location = new System.Drawing.Point(405, 6);
            this.cobQueryType.Name = "cobQueryType";
            this.cobQueryType.Size = new System.Drawing.Size(120, 21);
            this.cobQueryType.TabIndex = 5;
            this.cobQueryType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cobQueryType_KeyDown);
            // 
            // lblQueryType
            // 
            this.lblQueryType.AutoSize = true;
            this.lblQueryType.Location = new System.Drawing.Point(336, 9);
            this.lblQueryType.Name = "lblQueryType";
            this.lblQueryType.Size = new System.Drawing.Size(63, 14);
            this.lblQueryType.TabIndex = 4;
            this.lblQueryType.Text = "药品类型";
            // 
            // lblQueryMonth
            // 
            this.lblQueryMonth.AutoSize = true;
            this.lblQueryMonth.Location = new System.Drawing.Point(209, 9);
            this.lblQueryMonth.Name = "lblQueryMonth";
            this.lblQueryMonth.Size = new System.Drawing.Size(63, 14);
            this.lblQueryMonth.TabIndex = 3;
            this.lblQueryMonth.Text = "查询月份";
            // 
            // lblQueryYear
            // 
            this.lblQueryYear.AutoSize = true;
            this.lblQueryYear.Location = new System.Drawing.Point(13, 8);
            this.lblQueryYear.Name = "lblQueryYear";
            this.lblQueryYear.Size = new System.Drawing.Size(63, 14);
            this.lblQueryYear.TabIndex = 2;
            this.lblQueryYear.Text = "查询年份";
            // 
            // cobQueryMonth
            // 
            this.cobQueryMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobQueryMonth.FormattingEnabled = true;
            this.cobQueryMonth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cobQueryMonth.Location = new System.Drawing.Point(278, 6);
            this.cobQueryMonth.Name = "cobQueryMonth";
            this.cobQueryMonth.Size = new System.Drawing.Size(52, 21);
            this.cobQueryMonth.TabIndex = 1;
            this.cobQueryMonth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cobQueryMonth_KeyDown);
            // 
            // cobQueryYear
            // 
            this.cobQueryYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobQueryYear.FormattingEnabled = true;
            this.cobQueryYear.Items.AddRange(new object[] {
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015"});
            this.cobQueryYear.Location = new System.Drawing.Point(82, 5);
            this.cobQueryYear.Name = "cobQueryYear";
            this.cobQueryYear.Size = new System.Drawing.Size(121, 21);
            this.cobQueryYear.TabIndex = 0;
            this.cobQueryYear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cobQueryYear_KeyDown);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "INPROJECT";
            this.Column1.HeaderText = "项目";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "INFEE";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "金额";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "OUTPROJECT";
            this.Column3.HeaderText = "项目";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.DataPropertyName = "OUTFEE";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column4.HeaderText = "金额";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FrmIOSQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormTitle = "进销存查询";
            this.Name = "FrmIOSQuery";
            this.Text = "进销存查询";
            this.Load += new System.EventHandler(this.FrmIOSQuery_Load);
            this.plBaseWorkArea.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdDrugIOS)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblQueryMonth;
        private System.Windows.Forms.Label lblQueryYear;
        private System.Windows.Forms.ComboBox cobQueryMonth;
        private System.Windows.Forms.ComboBox cobQueryYear;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ComboBox cobQueryType;
        private System.Windows.Forms.Label lblQueryType;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgrdDrugIOS;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}