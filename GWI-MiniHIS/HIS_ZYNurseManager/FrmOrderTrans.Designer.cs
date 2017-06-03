namespace HIS_ZYNurseManager
{
    partial class FrmOrderTrans
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOrderTrans));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtgrdOrderTrans = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupLines = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btRefresh = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btOrderTrans = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.inPatientPanel1 = new GWI.HIS.Windows.Controls.Controls.InPatientPanel();
            this.btnAllSelect = new System.Windows.Forms.Button();
            this.btnReverSelect = new System.Windows.Forms.Button();
            this.chkpat = new System.Windows.Forms.CheckBox();
            this.chklong = new System.Windows.Forms.CheckBox();
            this.chktemp = new System.Windows.Forms.CheckBox();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdOrderTrans)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Controls.Add(this.button2);
            this.plBaseToolbar.Controls.Add(this.btRefresh);
            this.plBaseToolbar.Controls.Add(this.chktemp);
            this.plBaseToolbar.Controls.Add(this.chklong);
            this.plBaseToolbar.Controls.Add(this.btOrderTrans);
            this.plBaseToolbar.Controls.Add(this.chkpat);
            this.plBaseToolbar.Controls.Add(this.btnReverSelect);
            this.plBaseToolbar.Controls.Add(this.btnAllSelect);
            this.plBaseToolbar.Size = new System.Drawing.Size(1008, 29);
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
            this.plBaseStatus.Location = new System.Drawing.Point(0, 410);
            this.plBaseStatus.Size = new System.Drawing.Size(1008, 26);
            this.plBaseStatus.Visible = false;
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.panel3);
            this.plBaseWorkArea.Controls.Add(this.panel1);
            this.plBaseWorkArea.Size = new System.Drawing.Size(1008, 347);
            // 
            // plTitle
            // 
            this.plTitle.Size = new System.Drawing.Size(1008, 34);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(701, 191);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(304, 21);
            this.textBox7.TabIndex = 70;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(642, 194);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 69;
            this.label8.Text = "历史诊断";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtgrdOrderTrans);
            this.panel3.Controls.Add(this.textBox7);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Font = new System.Drawing.Font("宋体", 9F);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1008, 232);
            this.panel3.TabIndex = 3;
            // 
            // dtgrdOrderTrans
            // 
            this.dtgrdOrderTrans.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dtgrdOrderTrans.AllowSortWhenClickColumnHeader = false;
            this.dtgrdOrderTrans.AllowUserToAddRows = false;
            this.dtgrdOrderTrans.AllowUserToDeleteRows = false;
            this.dtgrdOrderTrans.AllowUserToResizeColumns = false;
            this.dtgrdOrderTrans.AllowUserToResizeRows = false;
            this.dtgrdOrderTrans.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgrdOrderTrans.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgrdOrderTrans.ColumnHeadersHeight = 30;
            this.dtgrdOrderTrans.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column10,
            this.Column11,
            this.Column1,
            this.Column2,
            this.Column14,
            this.Column4,
            this.Column5,
            this.Column6,
            this.GroupLines,
            this.Column7,
            this.Column22,
            this.Column23,
            this.Column9,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18,
            this.Column8,
            this.Column12,
            this.Column13,
            this.GroupFlag});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgrdOrderTrans.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgrdOrderTrans.DisplayAllItemWhenSelectionCardShowing = false;
            this.dtgrdOrderTrans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgrdOrderTrans.EnableHeadersVisualStyles = false;
            this.dtgrdOrderTrans.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dtgrdOrderTrans.HideSelectionCardWhenCustomInput = false;
            this.dtgrdOrderTrans.Location = new System.Drawing.Point(0, 0);
            this.dtgrdOrderTrans.Name = "dtgrdOrderTrans";
            this.dtgrdOrderTrans.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgrdOrderTrans.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgrdOrderTrans.RowHeadersVisible = false;
            this.dtgrdOrderTrans.RowTemplate.Height = 23;
            this.dtgrdOrderTrans.SelectionCards = null;
            this.dtgrdOrderTrans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgrdOrderTrans.Size = new System.Drawing.Size(1008, 232);
            this.dtgrdOrderTrans.TabIndex = 4;
            this.dtgrdOrderTrans.UseGradientBackgroundColor = true;
            this.dtgrdOrderTrans.Paint += new System.Windows.Forms.PaintEventHandler(this.dtgrdOrderTrans_Paint);
            this.dtgrdOrderTrans.Click += new System.EventHandler(this.dtgrdOrderTrans_Click);
            this.dtgrdOrderTrans.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrdOrderTrans_CellContentClick);
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "order_id";
            this.Column3.HeaderText = "ID";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Visible = false;
            this.Column3.Width = 30;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "选";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column10.Width = 25;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "patid";
            this.Column11.HeaderText = "ID";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column11.Visible = false;
            this.Column11.Width = 30;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "bed_no";
            this.Column1.HeaderText = "床号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "cureno";
            this.Column2.HeaderText = "住院号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "patname";
            this.Column14.HeaderText = "姓名";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column14.Width = 80;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "order_bdate";
            this.Column4.HeaderText = "开嘱时间";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 120;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "name";
            this.Column5.HeaderText = "开嘱医生";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 80;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "order_type";
            this.Column6.HeaderText = "类型";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 60;
            // 
            // GroupLines
            // 
            this.GroupLines.HeaderText = "";
            this.GroupLines.Name = "GroupLines";
            this.GroupLines.ReadOnly = true;
            this.GroupLines.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GroupLines.Width = 10;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "order_content";
            this.Column7.HeaderText = "医嘱内容";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column7.Width = 200;
            // 
            // Column22
            // 
            this.Column22.DataPropertyName = "amount";
            this.Column22.HeaderText = "剂量";
            this.Column22.Name = "Column22";
            this.Column22.ReadOnly = true;
            this.Column22.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column22.Width = 60;
            // 
            // Column23
            // 
            this.Column23.DataPropertyName = "unit";
            this.Column23.HeaderText = "单位";
            this.Column23.Name = "Column23";
            this.Column23.ReadOnly = true;
            this.Column23.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column23.Width = 45;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "order_usage";
            this.Column9.HeaderText = "用法";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column9.Width = 95;
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "frequency";
            this.Column15.HeaderText = "频次";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column15.Width = 50;
            // 
            // Column16
            // 
            this.Column16.DataPropertyName = "firset_times";
            this.Column16.HeaderText = "首次";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            this.Column16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column16.Width = 50;
            // 
            // Column17
            // 
            this.Column17.DataPropertyName = "teminal_times";
            this.Column17.HeaderText = "末次";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            this.Column17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column17.Width = 50;
            // 
            // Column18
            // 
            this.Column18.DataPropertyName = "order_struc";
            this.Column18.HeaderText = "嘱托";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            this.Column18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column18.Width = 160;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "status_flag";
            this.Column8.HeaderText = "状态";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column8.Width = 45;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "group_id";
            this.Column12.HeaderText = "组号";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column12.Visible = false;
            this.Column12.Width = 45;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "serial_id";
            this.Column13.HeaderText = "顺序";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column13.Visible = false;
            this.Column13.Width = 45;
            // 
            // GroupFlag
            // 
            this.GroupFlag.DataPropertyName = "GroupFlag";
            this.GroupFlag.HeaderText = "组标记";
            this.GroupFlag.Name = "GroupFlag";
            this.GroupFlag.ReadOnly = true;
            this.GroupFlag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GroupFlag.Visible = false;
            // 
            // btRefresh
            // 
            this.btRefresh.Location = new System.Drawing.Point(840, 3);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(75, 23);
            this.btRefresh.TabIndex = 22;
            this.btRefresh.Text = "刷新(&R)";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // button2
            // 
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(921, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 21;
            this.button2.Text = "退出(&E)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btOrderTrans
            // 
            this.btOrderTrans.Location = new System.Drawing.Point(759, 3);
            this.btOrderTrans.Name = "btOrderTrans";
            this.btOrderTrans.Size = new System.Drawing.Size(75, 23);
            this.btOrderTrans.TabIndex = 20;
            this.btOrderTrans.Text = "转抄(&C)";
            this.btOrderTrans.UseVisualStyleBackColor = true;
            this.btOrderTrans.Click += new System.EventHandler(this.btOrderTrans_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.inPatientPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 232);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 115);
            this.panel1.TabIndex = 2;
            // 
            // inPatientPanel1
            // 
            this.inPatientPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.inPatientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.inPatientPanel1.Font = new System.Drawing.Font("宋体", 9F);
            this.inPatientPanel1.InPaitent = null;
            this.inPatientPanel1.Location = new System.Drawing.Point(0, 0);
            this.inPatientPanel1.Name = "inPatientPanel1";
            this.inPatientPanel1.Size = new System.Drawing.Size(665, 115);
            this.inPatientPanel1.TabIndex = 82;
            // 
            // btnAllSelect
            // 
            this.btnAllSelect.Location = new System.Drawing.Point(12, 3);
            this.btnAllSelect.Name = "btnAllSelect";
            this.btnAllSelect.Size = new System.Drawing.Size(38, 23);
            this.btnAllSelect.TabIndex = 0;
            this.btnAllSelect.Text = "全选";
            this.btnAllSelect.UseVisualStyleBackColor = true;
            this.btnAllSelect.Click += new System.EventHandler(this.btnAllSelect_Click);
            // 
            // btnReverSelect
            // 
            this.btnReverSelect.Location = new System.Drawing.Point(56, 3);
            this.btnReverSelect.Name = "btnReverSelect";
            this.btnReverSelect.Size = new System.Drawing.Size(37, 23);
            this.btnReverSelect.TabIndex = 1;
            this.btnReverSelect.Text = "反选";
            this.btnReverSelect.UseVisualStyleBackColor = true;
            this.btnReverSelect.Click += new System.EventHandler(this.btnReverSelect_Click);
            // 
            // chkpat
            // 
            this.chkpat.AutoSize = true;
            this.chkpat.Location = new System.Drawing.Point(226, 7);
            this.chkpat.Name = "chkpat";
            this.chkpat.Size = new System.Drawing.Size(72, 16);
            this.chkpat.TabIndex = 5;
            this.chkpat.Text = "选定病人";
            this.chkpat.UseVisualStyleBackColor = true;
            this.chkpat.CheckedChanged += new System.EventHandler(this.chkpat_CheckedChanged);
            // 
            // chklong
            // 
            this.chklong.AutoSize = true;
            this.chklong.Location = new System.Drawing.Point(116, 7);
            this.chklong.Name = "chklong";
            this.chklong.Size = new System.Drawing.Size(48, 16);
            this.chklong.TabIndex = 6;
            this.chklong.Text = "长嘱";
            this.chklong.UseVisualStyleBackColor = true;
            // 
            // chktemp
            // 
            this.chktemp.AutoSize = true;
            this.chktemp.Location = new System.Drawing.Point(170, 7);
            this.chktemp.Name = "chktemp";
            this.chktemp.Size = new System.Drawing.Size(48, 16);
            this.chktemp.TabIndex = 7;
            this.chktemp.Text = "临嘱";
            this.chktemp.UseVisualStyleBackColor = true;
            // 
            // FrmOrderTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 436);
            this.FormTitle = "医嘱转抄";
            this.Name = "FrmOrderTrans";
            this.Text = "医嘱转抄";
            this.plBaseToolbar.ResumeLayout(false);
            this.plBaseToolbar.PerformLayout();
            this.plBaseWorkArea.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdOrderTrans)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private GWI.HIS.Windows.Controls.DataGridViewEx dtgrdOrderTrans;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btOrderTrans;
        private System.Windows.Forms.Button btnReverSelect;
        private System.Windows.Forms.Button btnAllSelect;
        private GWI.HIS.Windows.Controls.Controls.InPatientPanel inPatientPanel1;
        private System.Windows.Forms.CheckBox chkpat;
        private System.Windows.Forms.CheckBox chktemp;
        private System.Windows.Forms.CheckBox chklong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupLines;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column23;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupFlag;
    }
}