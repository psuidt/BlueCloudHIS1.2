namespace HIS_ZYNurseManager
{
    partial class FrmPatOut
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPatOut));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabPageControl1 = new GWI.HIS.Windows.Controls.Controls.TabPageControl();
            this.tab_Leave = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv_Leave = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.病人科室 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出院日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出院时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.床号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.住院号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.病人ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.姓名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.性别 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出院方式 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tab_Transfer = new System.Windows.Forms.TabPage();
            this.dgv_Transfer = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.TranDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TranTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TranBedNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TranCureNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TranName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TranSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TranOrigeDept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TranGetDept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TranDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TranBookDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tab_Left = new System.Windows.Forms.TabPage();
            this.dgv_Left = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnl_PatInfo = new GWI.HIS.Windows.Controls.Controls.InPatientPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_Out = new System.Windows.Forms.ToolStripButton();
            this.btn_CancelOut = new System.Windows.Forms.ToolStripButton();
            this.btn_Refresh = new System.Windows.Forms.ToolStripButton();
            this.messageTimer1 = new MessagePromptManager.MessageTimer();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPageControl1.SuspendLayout();
            this.tab_Leave.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Leave)).BeginInit();
            this.tab_Transfer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Transfer)).BeginInit();
            this.tab_Left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Left)).BeginInit();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Controls.Add(this.toolStrip1);
            this.plBaseToolbar.Margin = new System.Windows.Forms.Padding(2);
            this.plBaseToolbar.Size = new System.Drawing.Size(988, 29);
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
            this.plBaseStatus.Location = new System.Drawing.Point(0, 389);
            this.plBaseStatus.Margin = new System.Windows.Forms.Padding(2);
            this.plBaseStatus.Size = new System.Drawing.Size(988, 26);
            this.plBaseStatus.Visible = false;
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.panel1);
            this.plBaseWorkArea.Margin = new System.Windows.Forms.Padding(2);
            this.plBaseWorkArea.Size = new System.Drawing.Size(988, 326);
            // 
            // plTitle
            // 
            this.plTitle.Size = new System.Drawing.Size(988, 34);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabPageControl1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(988, 326);
            this.panel1.TabIndex = 0;
            // 
            // tabPageControl1
            // 
            this.tabPageControl1.Controls.Add(this.tab_Leave);
            this.tabPageControl1.Controls.Add(this.tab_Transfer);
            this.tabPageControl1.Controls.Add(this.tab_Left);
            this.tabPageControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPageControl1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPageControl1.Location = new System.Drawing.Point(0, 0);
            this.tabPageControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageControl1.Name = "tabPageControl1";
            this.tabPageControl1.SelectedIndex = 0;
            this.tabPageControl1.Size = new System.Drawing.Size(988, 209);
            this.tabPageControl1.TabIndex = 0;
            this.tabPageControl1.SelectedIndexChanged += new System.EventHandler(this.tabPageControl1_SelectedIndexChanged);
            // 
            // tab_Leave
            // 
            this.tab_Leave.BackColor = System.Drawing.Color.Transparent;
            this.tab_Leave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tab_Leave.BackgroundImage")));
            this.tab_Leave.Controls.Add(this.panel3);
            this.tab_Leave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tab_Leave.Location = new System.Drawing.Point(4, 23);
            this.tab_Leave.Margin = new System.Windows.Forms.Padding(2);
            this.tab_Leave.Name = "tab_Leave";
            this.tab_Leave.Padding = new System.Windows.Forms.Padding(2);
            this.tab_Leave.Size = new System.Drawing.Size(980, 182);
            this.tab_Leave.TabIndex = 0;
            this.tab_Leave.Text = "定义出院";
            this.tab_Leave.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv_Leave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(2, 2);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(976, 178);
            this.panel3.TabIndex = 0;
            // 
            // dgv_Leave
            // 
            this.dgv_Leave.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgv_Leave.AllowSortWhenClickColumnHeader = false;
            this.dgv_Leave.AllowUserToAddRows = false;
            this.dgv_Leave.AllowUserToDeleteRows = false;
            this.dgv_Leave.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Leave.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Leave.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.病人科室,
            this.出院日期,
            this.出院时间,
            this.床号,
            this.住院号,
            this.病人ID,
            this.姓名,
            this.性别,
            this.出院方式,
            this.Column1});
            this.dgv_Leave.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgv_Leave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Leave.EnableHeadersVisualStyles = false;
            this.dgv_Leave.HideSelectionCardWhenCustomInput = false;
            this.dgv_Leave.Location = new System.Drawing.Point(0, 0);
            this.dgv_Leave.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_Leave.Name = "dgv_Leave";
            this.dgv_Leave.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Leave.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Leave.RowTemplate.Height = 23;
            this.dgv_Leave.SelectionCards = null;
            this.dgv_Leave.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Leave.Size = new System.Drawing.Size(976, 178);
            this.dgv_Leave.TabIndex = 0;
            this.dgv_Leave.UseGradientBackgroundColor = true;
            this.dgv_Leave.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Leave_CellClick);
            // 
            // 病人科室
            // 
            this.病人科室.DataPropertyName = "病人科室";
            this.病人科室.HeaderText = "病人科室";
            this.病人科室.Name = "病人科室";
            this.病人科室.ReadOnly = true;
            this.病人科室.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.病人科室.Visible = false;
            // 
            // 出院日期
            // 
            this.出院日期.DataPropertyName = "出院日期";
            this.出院日期.HeaderText = "出院日期";
            this.出院日期.Name = "出院日期";
            this.出院日期.ReadOnly = true;
            this.出院日期.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 出院时间
            // 
            this.出院时间.DataPropertyName = "出院时间";
            this.出院时间.HeaderText = "出院时间";
            this.出院时间.Name = "出院时间";
            this.出院时间.ReadOnly = true;
            this.出院时间.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.出院时间.Visible = false;
            // 
            // 床号
            // 
            this.床号.DataPropertyName = "床号";
            this.床号.HeaderText = "床号";
            this.床号.Name = "床号";
            this.床号.ReadOnly = true;
            this.床号.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.床号.Width = 60;
            // 
            // 住院号
            // 
            this.住院号.DataPropertyName = "住院号";
            this.住院号.HeaderText = "住院号";
            this.住院号.Name = "住院号";
            this.住院号.ReadOnly = true;
            this.住院号.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.住院号.Width = 120;
            // 
            // 病人ID
            // 
            this.病人ID.DataPropertyName = "病人ID";
            this.病人ID.HeaderText = "病人ID";
            this.病人ID.Name = "病人ID";
            this.病人ID.ReadOnly = true;
            this.病人ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.病人ID.Visible = false;
            // 
            // 姓名
            // 
            this.姓名.DataPropertyName = "姓名";
            this.姓名.HeaderText = "姓名";
            this.姓名.Name = "姓名";
            this.姓名.ReadOnly = true;
            this.姓名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.姓名.Width = 80;
            // 
            // 性别
            // 
            this.性别.DataPropertyName = "性别";
            this.性别.HeaderText = "性别";
            this.性别.Name = "性别";
            this.性别.ReadOnly = true;
            this.性别.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.性别.Width = 60;
            // 
            // 出院方式
            // 
            this.出院方式.DataPropertyName = "出院方式";
            this.出院方式.HeaderText = "出院方式";
            this.出院方式.Name = "出院方式";
            this.出院方式.ReadOnly = true;
            this.出院方式.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tab_Transfer
            // 
            this.tab_Transfer.BackColor = System.Drawing.Color.Transparent;
            this.tab_Transfer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tab_Transfer.BackgroundImage")));
            this.tab_Transfer.Controls.Add(this.dgv_Transfer);
            this.tab_Transfer.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tab_Transfer.Location = new System.Drawing.Point(4, 23);
            this.tab_Transfer.Margin = new System.Windows.Forms.Padding(2);
            this.tab_Transfer.Name = "tab_Transfer";
            this.tab_Transfer.Padding = new System.Windows.Forms.Padding(2);
            this.tab_Transfer.Size = new System.Drawing.Size(980, 182);
            this.tab_Transfer.TabIndex = 1;
            this.tab_Transfer.Text = "病人转科";
            this.tab_Transfer.UseVisualStyleBackColor = true;
            // 
            // dgv_Transfer
            // 
            this.dgv_Transfer.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgv_Transfer.AllowSortWhenClickColumnHeader = false;
            this.dgv_Transfer.AllowUserToAddRows = false;
            this.dgv_Transfer.AllowUserToDeleteRows = false;
            this.dgv_Transfer.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Transfer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Transfer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TranDate,
            this.TranTime,
            this.TranBedNo,
            this.TranCureNo,
            this.TranName,
            this.TranSex,
            this.TranOrigeDept,
            this.TranGetDept,
            this.TranDoc,
            this.TranBookDate,
            this.Column2});
            this.dgv_Transfer.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgv_Transfer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Transfer.EnableHeadersVisualStyles = false;
            this.dgv_Transfer.HideSelectionCardWhenCustomInput = false;
            this.dgv_Transfer.Location = new System.Drawing.Point(2, 2);
            this.dgv_Transfer.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_Transfer.Name = "dgv_Transfer";
            this.dgv_Transfer.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Transfer.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Transfer.RowTemplate.Height = 23;
            this.dgv_Transfer.SelectionCards = null;
            this.dgv_Transfer.Size = new System.Drawing.Size(976, 178);
            this.dgv_Transfer.TabIndex = 0;
            this.dgv_Transfer.UseGradientBackgroundColor = true;
            this.dgv_Transfer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Transfer_CellClick);
            // 
            // TranDate
            // 
            this.TranDate.DataPropertyName = "TranDate";
            this.TranDate.HeaderText = "转科日期";
            this.TranDate.Name = "TranDate";
            this.TranDate.ReadOnly = true;
            this.TranDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TranDate.Width = 80;
            // 
            // TranTime
            // 
            this.TranTime.DataPropertyName = "TranTime";
            this.TranTime.HeaderText = "转科时间";
            this.TranTime.Name = "TranTime";
            this.TranTime.ReadOnly = true;
            this.TranTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TranTime.Width = 80;
            // 
            // TranBedNo
            // 
            this.TranBedNo.DataPropertyName = "TranBedNo";
            this.TranBedNo.HeaderText = "床号";
            this.TranBedNo.Name = "TranBedNo";
            this.TranBedNo.ReadOnly = true;
            this.TranBedNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TranBedNo.Width = 50;
            // 
            // TranCureNo
            // 
            this.TranCureNo.DataPropertyName = "TranCureNo";
            this.TranCureNo.HeaderText = "住院号";
            this.TranCureNo.Name = "TranCureNo";
            this.TranCureNo.ReadOnly = true;
            this.TranCureNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TranCureNo.Width = 80;
            // 
            // TranName
            // 
            this.TranName.DataPropertyName = "TranName";
            this.TranName.HeaderText = "姓名";
            this.TranName.Name = "TranName";
            this.TranName.ReadOnly = true;
            this.TranName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TranName.Width = 80;
            // 
            // TranSex
            // 
            this.TranSex.DataPropertyName = "TranSex";
            this.TranSex.HeaderText = "性别";
            this.TranSex.Name = "TranSex";
            this.TranSex.ReadOnly = true;
            this.TranSex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TranSex.Width = 50;
            // 
            // TranOrigeDept
            // 
            this.TranOrigeDept.DataPropertyName = "TranOrigeDeptName";
            this.TranOrigeDept.HeaderText = "源科室";
            this.TranOrigeDept.Name = "TranOrigeDept";
            this.TranOrigeDept.ReadOnly = true;
            this.TranOrigeDept.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TranOrigeDept.Width = 80;
            // 
            // TranGetDept
            // 
            this.TranGetDept.DataPropertyName = "TranGetDeptName";
            this.TranGetDept.HeaderText = "目标科室";
            this.TranGetDept.Name = "TranGetDept";
            this.TranGetDept.ReadOnly = true;
            this.TranGetDept.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TranGetDept.Width = 80;
            // 
            // TranDoc
            // 
            this.TranDoc.DataPropertyName = "TranDocName";
            this.TranDoc.HeaderText = "医生";
            this.TranDoc.Name = "TranDoc";
            this.TranDoc.ReadOnly = true;
            this.TranDoc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TranDoc.Width = 80;
            // 
            // TranBookDate
            // 
            this.TranBookDate.DataPropertyName = "TranBookDate";
            this.TranBookDate.HeaderText = "登记日期";
            this.TranBookDate.Name = "TranBookDate";
            this.TranBookDate.ReadOnly = true;
            this.TranBookDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TranBookDate.Width = 80;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tab_Left
            // 
            this.tab_Left.Controls.Add(this.dgv_Left);
            this.tab_Left.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tab_Left.Location = new System.Drawing.Point(4, 23);
            this.tab_Left.Margin = new System.Windows.Forms.Padding(2);
            this.tab_Left.Name = "tab_Left";
            this.tab_Left.Padding = new System.Windows.Forms.Padding(2);
            this.tab_Left.Size = new System.Drawing.Size(555, 186);
            this.tab_Left.TabIndex = 2;
            this.tab_Left.Text = "已出院患者";
            this.tab_Left.UseVisualStyleBackColor = true;
            // 
            // dgv_Left
            // 
            this.dgv_Left.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgv_Left.AllowSortWhenClickColumnHeader = false;
            this.dgv_Left.AllowUserToAddRows = false;
            this.dgv_Left.AllowUserToDeleteRows = false;
            this.dgv_Left.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Left.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_Left.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.Column3});
            this.dgv_Left.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgv_Left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Left.EnableHeadersVisualStyles = false;
            this.dgv_Left.HideSelectionCardWhenCustomInput = false;
            this.dgv_Left.Location = new System.Drawing.Point(2, 2);
            this.dgv_Left.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_Left.Name = "dgv_Left";
            this.dgv_Left.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Left.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_Left.RowTemplate.Height = 23;
            this.dgv_Left.SelectionCards = null;
            this.dgv_Left.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Left.Size = new System.Drawing.Size(551, 182);
            this.dgv_Left.TabIndex = 1;
            this.dgv_Left.UseGradientBackgroundColor = true;
            this.dgv_Left.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Left_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "病人科室";
            this.dataGridViewTextBoxColumn1.HeaderText = "病人科室";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "出院日期";
            this.dataGridViewTextBoxColumn2.HeaderText = "出院日期";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "出院时间";
            this.dataGridViewTextBoxColumn3.HeaderText = "出院时间";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "目前状态";
            this.dataGridViewTextBoxColumn4.HeaderText = "目前状态";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "住院号";
            this.dataGridViewTextBoxColumn5.HeaderText = "住院号";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 120;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "病人ID";
            this.dataGridViewTextBoxColumn6.HeaderText = "病人ID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "姓名";
            this.dataGridViewTextBoxColumn7.HeaderText = "姓名";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "性别";
            this.dataGridViewTextBoxColumn8.HeaderText = "性别";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn8.Width = 60;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "出院方式";
            this.dataGridViewTextBoxColumn9.HeaderText = "出院方式";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.pnl_PatInfo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 209);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(988, 117);
            this.panel2.TabIndex = 1;
            // 
            // pnl_PatInfo
            // 
            this.pnl_PatInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.pnl_PatInfo.Font = new System.Drawing.Font("宋体", 9F);
            this.pnl_PatInfo.InPaitent = null;
            this.pnl_PatInfo.Location = new System.Drawing.Point(0, 0);
            this.pnl_PatInfo.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_PatInfo.Name = "pnl_PatInfo";
            this.pnl_PatInfo.Size = new System.Drawing.Size(665, 115);
            this.pnl_PatInfo.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Out,
            this.btn_CancelOut,
            this.btn_Refresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(988, 29);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_Out
            // 
            this.btn_Out.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btn_Out.Image = ((System.Drawing.Image)(resources.GetObject("btn_Out.Image")));
            this.btn_Out.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Out.Name = "btn_Out";
            this.btn_Out.Size = new System.Drawing.Size(23, 26);
            this.btn_Out.Click += new System.EventHandler(this.btn_Out_Click);
            // 
            // btn_CancelOut
            // 
            this.btn_CancelOut.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btn_CancelOut.Image = ((System.Drawing.Image)(resources.GetObject("btn_CancelOut.Image")));
            this.btn_CancelOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_CancelOut.Name = "btn_CancelOut";
            this.btn_CancelOut.Size = new System.Drawing.Size(23, 26);
            this.btn_CancelOut.Click += new System.EventHandler(this.btn_CancelOut_Click);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btn_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("btn_Refresh.Image")));
            this.btn_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(56, 26);
            this.btn_Refresh.Text = "刷新";
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // messageTimer1
            // 
            this.messageTimer1.Enabled = true;
            this.messageTimer1.Interval = 2000;
            this.messageTimer1.MessageReceiver = null;
            // 
            // FrmPatOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 415);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormTitle = "病人出区";
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmPatOut";
            this.Text = "病人出区";
            this.plBaseToolbar.ResumeLayout(false);
            this.plBaseWorkArea.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPageControl1.ResumeLayout(false);
            this.tab_Leave.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Leave)).EndInit();
            this.tab_Transfer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Transfer)).EndInit();
            this.tab_Left.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Left)).EndInit();
            this.panel2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private GWI.HIS.Windows.Controls.Controls.TabPageControl tabPageControl1;
        private System.Windows.Forms.TabPage tab_Leave;
        private System.Windows.Forms.Panel panel3;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgv_Leave;
        private System.Windows.Forms.TabPage tab_Transfer;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgv_Transfer;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_Out;
        private System.Windows.Forms.ToolStripButton btn_CancelOut;
        private System.Windows.Forms.ToolStripButton btn_Refresh;
        private System.Windows.Forms.Panel panel2;
        private GWI.HIS.Windows.Controls.Controls.InPatientPanel pnl_PatInfo;
        private System.Windows.Forms.TabPage tab_Left;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgv_Left;
        private System.Windows.Forms.DataGridViewTextBoxColumn 病人科室;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出院日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出院时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 床号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 住院号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 病人ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 姓名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 性别;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出院方式;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TranDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TranTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TranBedNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TranCureNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TranName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TranSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn TranOrigeDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn TranGetDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn TranDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TranBookDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private MessagePromptManager.MessageTimer messageTimer1;
    }
}