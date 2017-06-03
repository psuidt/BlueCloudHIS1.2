namespace HIS_YPManager
{
    partial class FrmMonthAccount
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cobAccountDay = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnYFMonthAccount = new System.Windows.Forms.Button();
            this.btnYKMonthAccount = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cobBeginDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.cobEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnCancelAccount = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCheckAccount = new System.Windows.Forms.Button();
            this.lblState = new System.Windows.Forms.Label();
            this.dgrdWrongData = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitBalanceInfo = new System.Windows.Forms.SplitContainer();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBalacneAccount = new System.Windows.Forms.Button();
            this.dgrdAccountHis = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCurrentActMonth = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdWrongData)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.splitBalanceInfo.Panel1.SuspendLayout();
            this.splitBalanceInfo.Panel2.SuspendLayout();
            this.splitBalanceInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdAccountHis)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(36, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "每月月结时间";
            // 
            // cobAccountDay
            // 
            this.cobAccountDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobAccountDay.FormattingEnabled = true;
            this.cobAccountDay.Location = new System.Drawing.Point(139, 75);
            this.cobAccountDay.Name = "cobAccountDay";
            this.cobAccountDay.Size = new System.Drawing.Size(189, 21);
            this.cobAccountDay.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Location = new System.Drawing.Point(190, 102);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(66, 28);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "设置";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(262, 102);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 28);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "退出(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnYFMonthAccount
            // 
            this.btnYFMonthAccount.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnYFMonthAccount.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnYFMonthAccount.Location = new System.Drawing.Point(18, 50);
            this.btnYFMonthAccount.Name = "btnYFMonthAccount";
            this.btnYFMonthAccount.Size = new System.Drawing.Size(230, 27);
            this.btnYFMonthAccount.TabIndex = 4;
            this.btnYFMonthAccount.Text = "药房系统月结(&F)";
            this.btnYFMonthAccount.UseVisualStyleBackColor = true;
            this.btnYFMonthAccount.Click += new System.EventHandler(this.btnYFMonthAccount_Click);
            // 
            // btnYKMonthAccount
            // 
            this.btnYKMonthAccount.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnYKMonthAccount.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnYKMonthAccount.Location = new System.Drawing.Point(18, 82);
            this.btnYKMonthAccount.Name = "btnYKMonthAccount";
            this.btnYKMonthAccount.Size = new System.Drawing.Size(230, 27);
            this.btnYKMonthAccount.TabIndex = 5;
            this.btnYKMonthAccount.Text = "药库/物资系统月结(&F)";
            this.btnYKMonthAccount.UseVisualStyleBackColor = true;
            this.btnYKMonthAccount.Click += new System.EventHandler(this.btnYKMonthAccount_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "上次月结开始时间";
            // 
            // cobBeginDate
            // 
            this.cobBeginDate.Enabled = false;
            this.cobBeginDate.Location = new System.Drawing.Point(139, 17);
            this.cobBeginDate.Name = "cobBeginDate";
            this.cobBeginDate.Size = new System.Drawing.Size(189, 23);
            this.cobBeginDate.TabIndex = 7;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEndDate.Location = new System.Drawing.Point(6, 50);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(127, 14);
            this.lblEndDate.TabIndex = 8;
            this.lblEndDate.Text = "上次月结结束时间";
            this.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cobEndDate
            // 
            this.cobEndDate.Enabled = false;
            this.cobEndDate.Location = new System.Drawing.Point(139, 46);
            this.cobEndDate.Name = "cobEndDate";
            this.cobEndDate.Size = new System.Drawing.Size(189, 23);
            this.cobEndDate.TabIndex = 9;
            // 
            // btnCancelAccount
            // 
            this.btnCancelAccount.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancelAccount.ForeColor = System.Drawing.Color.Red;
            this.btnCancelAccount.Location = new System.Drawing.Point(18, 18);
            this.btnCancelAccount.Name = "btnCancelAccount";
            this.btnCancelAccount.Size = new System.Drawing.Size(230, 27);
            this.btnCancelAccount.TabIndex = 10;
            this.btnCancelAccount.Text = "取消本月月结(&R)";
            this.btnCancelAccount.UseVisualStyleBackColor = true;
            this.btnCancelAccount.Click += new System.EventHandler(this.btnCancelAccount_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblCurrentActMonth);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnCancelAccount);
            this.groupBox1.Controls.Add(this.btnYFMonthAccount);
            this.groupBox1.Controls.Add(this.btnYKMonthAccount);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 138);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "月结操作";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnBalacneAccount);
            this.groupBox2.Controls.Add(this.btnCheckAccount);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cobBeginDate);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.cobEndDate);
            this.groupBox2.Controls.Add(this.btnOK);
            this.groupBox2.Controls.Add(this.lblEndDate);
            this.groupBox2.Controls.Add(this.cobAccountDay);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(343, 138);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "设置月结时间";
            // 
            // btnCheckAccount
            // 
            this.btnCheckAccount.Location = new System.Drawing.Point(108, 102);
            this.btnCheckAccount.Name = "btnCheckAccount";
            this.btnCheckAccount.Size = new System.Drawing.Size(77, 28);
            this.btnCheckAccount.TabIndex = 10;
            this.btnCheckAccount.Text = "自动对账";
            this.btnCheckAccount.UseVisualStyleBackColor = true;
            this.btnCheckAccount.Click += new System.EventHandler(this.btnCheckAccount_Click);
            // 
            // lblState
            // 
            this.lblState.BackColor = System.Drawing.Color.Transparent;
            this.lblState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblState.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblState.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblState.Location = new System.Drawing.Point(0, 362);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(603, 28);
            this.lblState.TabIndex = 13;
            this.lblState.Text = "准备...";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgrdWrongData
            // 
            this.dgrdWrongData.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgrdWrongData.AllowSortWhenClickColumnHeader = true;
            this.dgrdWrongData.AllowUserToAddRows = false;
            this.dgrdWrongData.AllowUserToDeleteRows = false;
            this.dgrdWrongData.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdWrongData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgrdWrongData.ColumnHeadersHeight = 30;
            this.dgrdWrongData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgrdWrongData.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgrdWrongData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdWrongData.EnableHeadersVisualStyles = false;
            this.dgrdWrongData.HideSelectionCardWhenCustomInput = false;
            this.dgrdWrongData.Location = new System.Drawing.Point(0, 0);
            this.dgrdWrongData.Name = "dgrdWrongData";
            this.dgrdWrongData.ReadOnly = true;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdWrongData.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgrdWrongData.RowHeadersVisible = false;
            this.dgrdWrongData.RowTemplate.Height = 23;
            this.dgrdWrongData.SelectionCards = null;
            this.dgrdWrongData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdWrongData.Size = new System.Drawing.Size(324, 224);
            this.dgrdWrongData.TabIndex = 14;
            this.dgrdWrongData.UseGradientBackgroundColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.dgrdWrongData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 224);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(603, 138);
            this.panel2.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(343, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(260, 138);
            this.panel3.TabIndex = 13;
            // 
            // splitBalanceInfo
            // 
            this.splitBalanceInfo.BackColor = System.Drawing.Color.Transparent;
            this.splitBalanceInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitBalanceInfo.Location = new System.Drawing.Point(0, 138);
            this.splitBalanceInfo.Name = "splitBalanceInfo";
            // 
            // splitBalanceInfo.Panel1
            // 
            this.splitBalanceInfo.Panel1.Controls.Add(this.dgrdAccountHis);
            this.splitBalanceInfo.Panel1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // splitBalanceInfo.Panel2
            // 
            this.splitBalanceInfo.Panel2.Controls.Add(this.panel1);
            this.splitBalanceInfo.Size = new System.Drawing.Size(603, 224);
            this.splitBalanceInfo.SplitterDistance = 275;
            this.splitBalanceInfo.TabIndex = 17;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "CHEMNAME";
            this.Column1.HeaderText = "化学名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "MAKERDICID";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle10;
            this.Column2.HeaderText = "内部编码";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 40;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "STOREWRONGFEE";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            this.Column3.DefaultCellStyle = dataGridViewCellStyle11;
            this.Column3.HeaderText = "库存差额";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 50;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "WRONGFEE";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            this.Column4.DefaultCellStyle = dataGridViewCellStyle12;
            this.Column4.HeaderText = "账面差额";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 50;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "WRONGNUM";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N0";
            this.Column5.DefaultCellStyle = dataGridViewCellStyle13;
            this.Column5.HeaderText = "数量差额";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 50;
            // 
            // btnBalacneAccount
            // 
            this.btnBalacneAccount.Location = new System.Drawing.Point(25, 102);
            this.btnBalacneAccount.Name = "btnBalacneAccount";
            this.btnBalacneAccount.Size = new System.Drawing.Size(77, 28);
            this.btnBalacneAccount.TabIndex = 11;
            this.btnBalacneAccount.Text = "自动平账";
            this.btnBalacneAccount.UseVisualStyleBackColor = true;
            this.btnBalacneAccount.Click += new System.EventHandler(this.btnBalacneAccount_Click);
            // 
            // dgrdAccountHis
            // 
            this.dgrdAccountHis.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgrdAccountHis.AllowSortWhenClickColumnHeader = true;
            this.dgrdAccountHis.AllowUserToAddRows = false;
            this.dgrdAccountHis.AllowUserToDeleteRows = false;
            this.dgrdAccountHis.AllowUserToResizeRows = false;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdAccountHis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgrdAccountHis.ColumnHeadersHeight = 30;
            this.dgrdAccountHis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7,
            this.Column9,
            this.Column10});
            this.dgrdAccountHis.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgrdAccountHis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdAccountHis.EnableHeadersVisualStyles = false;
            this.dgrdAccountHis.HideSelectionCardWhenCustomInput = false;
            this.dgrdAccountHis.Location = new System.Drawing.Point(0, 0);
            this.dgrdAccountHis.Name = "dgrdAccountHis";
            this.dgrdAccountHis.ReadOnly = true;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle16.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdAccountHis.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgrdAccountHis.RowHeadersVisible = false;
            this.dgrdAccountHis.RowTemplate.Height = 23;
            this.dgrdAccountHis.SelectionCards = null;
            this.dgrdAccountHis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdAccountHis.Size = new System.Drawing.Size(275, 224);
            this.dgrdAccountHis.TabIndex = 15;
            this.dgrdAccountHis.UseGradientBackgroundColor = true;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.DataPropertyName = "BEGINTIME";
            this.Column6.HeaderText = "开始时间";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column7.DataPropertyName = "ENDTIME";
            this.Column7.HeaderText = "结束时间";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "ACCOUNTYEAR";
            this.Column9.HeaderText = "会计年份";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 35;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "ACCOUNTMONTH";
            this.Column10.HeaderText = "会计月份";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "当前未结会计月份：";
            // 
            // lblCurrentActMonth
            // 
            this.lblCurrentActMonth.AutoSize = true;
            this.lblCurrentActMonth.Location = new System.Drawing.Point(163, 116);
            this.lblCurrentActMonth.Name = "lblCurrentActMonth";
            this.lblCurrentActMonth.Size = new System.Drawing.Size(85, 14);
            this.lblCurrentActMonth.TabIndex = 12;
            this.lblCurrentActMonth.Text = "0000年01月";
            // 
            // FrmMonthAccount
            // 
            this.AcceptButton = this.btnCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(603, 390);
            this.Controls.Add(this.splitBalanceInfo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblState);
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.Name = "FrmMonthAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "库房月结";
            this.Load += new System.EventHandler(this.FrmMonthAccount_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdWrongData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.splitBalanceInfo.Panel1.ResumeLayout(false);
            this.splitBalanceInfo.Panel2.ResumeLayout(false);
            this.splitBalanceInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdAccountHis)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cobAccountDay;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnYFMonthAccount;
        private System.Windows.Forms.Button btnYKMonthAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker cobBeginDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker cobEndDate;
        private System.Windows.Forms.Button btnCancelAccount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblState;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgrdWrongData;
        private System.Windows.Forms.Button btnCheckAccount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitBalanceInfo;
        private System.Windows.Forms.Button btnBalacneAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgrdAccountHis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.Label lblCurrentActMonth;
        private System.Windows.Forms.Label label3;
    }
}

