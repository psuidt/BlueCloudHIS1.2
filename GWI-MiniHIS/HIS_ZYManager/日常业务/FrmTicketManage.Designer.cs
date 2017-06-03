using HIS.ZY_BLL.DataModel;
namespace HIS_ZYManager
{
    partial class FrmTicketManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTicketManage));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.dgCost = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.txtFP = new System.Windows.Forms.TextBox();
            this.txtZyh = new GWMHIS.PublicControls.InpatientNOTextBox(this.components);
            this.btSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpEdate = new System.Windows.Forms.DateTimePicker();
            this.dtpBdate = new System.Windows.Forms.DateTimePicker();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolCanel = new System.Windows.Forms.ToolStripButton();
            this.toolAgain = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.zYCostMasterSonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCost)).BeginInit();
            this.panel2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zYCostMasterSonBindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dgCost);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel2);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(799, 611);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(799, 636);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip2);
            // 
            // dgCost
            // 
            this.dgCost.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgCost.AllowSortWhenClickColumnHeader = false;
            this.dgCost.AllowUserToAddRows = false;
            this.dgCost.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCost.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgCost.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column15,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14});
            this.dgCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCost.EnableHeadersVisualStyles = false;
            this.dgCost.Location = new System.Drawing.Point(0, 55);
            this.dgCost.MultiSelect = false;
            this.dgCost.Name = "dgCost";
            this.dgCost.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCost.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgCost.RowTemplate.Height = 23;
            this.dgCost.SelectionCards = null;
            this.dgCost.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCost.Size = new System.Drawing.Size(799, 556);
            this.dgCost.TabIndex = 2;
            this.dgCost.UseGradientBackgroundColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButton3);
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Controls.Add(this.txtFP);
            this.panel2.Controls.Add(this.txtZyh);
            this.panel2.Controls.Add(this.btSearch);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dtpEdate);
            this.panel2.Controls.Add(this.dtpBdate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(799, 55);
            this.panel2.TabIndex = 0;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton3.Location = new System.Drawing.Point(523, 18);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(67, 18);
            this.radioButton3.TabIndex = 15;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "发票号";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton2.Location = new System.Drawing.Point(330, 18);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(67, 18);
            this.radioButton2.TabIndex = 14;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "住院号";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.chkBZyh_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton1.Location = new System.Drawing.Point(19, 18);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(53, 18);
            this.radioButton1.TabIndex = 13;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "时间";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txtFP
            // 
            this.txtFP.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFP.Location = new System.Drawing.Point(591, 16);
            this.txtFP.Name = "txtFP";
            this.txtFP.Size = new System.Drawing.Size(107, 23);
            this.txtFP.TabIndex = 12;
            // 
            // txtZyh
            // 
            this.txtZyh.Enabled = false;
            this.txtZyh.EnabledFalseBackColor = System.Drawing.SystemColors.Control;
            this.txtZyh.EnabledTrueBackColor = System.Drawing.SystemColors.Window;
            this.txtZyh.EnterBackColor = System.Drawing.SystemColors.Window;
            this.txtZyh.EnterForeColor = System.Drawing.SystemColors.WindowText;
            this.txtZyh.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtZyh.ForeColor = System.Drawing.Color.Black;
            this.txtZyh.Location = new System.Drawing.Point(399, 16);
            this.txtZyh.Name = "txtZyh";
            this.txtZyh.NextControl = null;
            this.txtZyh.PreviousControl = null;
            this.txtZyh.Size = new System.Drawing.Size(107, 23);
            this.txtZyh.TabIndex = 10;
            this.txtZyh.Text = "00000000";
            // 
            // btSearch
            // 
            this.btSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btSearch.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSearch.Image = ((System.Drawing.Image)(resources.GetObject("btSearch.Image")));
            this.btSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSearch.Location = new System.Drawing.Point(709, 16);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(81, 22);
            this.btSearch.TabIndex = 5;
            this.btSearch.Text = "查询";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(190, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "至";
            // 
            // dtpEdate
            // 
            this.dtpEdate.CustomFormat = "yyyy-MM-dd";
            this.dtpEdate.Enabled = false;
            this.dtpEdate.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEdate.Location = new System.Drawing.Point(217, 16);
            this.dtpEdate.Name = "dtpEdate";
            this.dtpEdate.Size = new System.Drawing.Size(95, 23);
            this.dtpEdate.TabIndex = 2;
            // 
            // dtpBdate
            // 
            this.dtpBdate.CustomFormat = "yyyy-MM-dd";
            this.dtpBdate.Enabled = false;
            this.dtpBdate.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpBdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBdate.Location = new System.Drawing.Point(88, 16);
            this.dtpBdate.Name = "dtpBdate";
            this.dtpBdate.Size = new System.Drawing.Size(98, 23);
            this.dtpBdate.TabIndex = 1;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Font = new System.Drawing.Font("宋体", 10F);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolCanel,
            this.toolAgain,
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton3});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(427, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // toolCanel
            // 
            this.toolCanel.Image = ((System.Drawing.Image)(resources.GetObject("toolCanel.Image")));
            this.toolCanel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCanel.Name = "toolCanel";
            this.toolCanel.Size = new System.Drawing.Size(111, 22);
            this.toolCanel.Text = "取消结算(F2)";
            this.toolCanel.Click += new System.EventHandler(this.toolCanel_Click);
            // 
            // toolAgain
            // 
            this.toolAgain.Image = global::HIS_ZYManager.Properties.Resources.打印;
            this.toolAgain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAgain.Name = "toolAgain";
            this.toolAgain.Size = new System.Drawing.Size(111, 22);
            this.toolAgain.Text = "补打发票(F3)";
            this.toolAgain.Click += new System.EventHandler(this.toolAgain_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(111, 22);
            this.toolStripButton1.Text = "废票补录(F4)";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton3.Text = "关闭(&C)";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // zYCostMasterSonBindingSource
            // 
            this.zYCostMasterSonBindingSource.DataSource = typeof(ZY_CostMaster);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(181, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "从";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "TicketNum";
            this.Column1.HeaderText = "发票流水号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "TicketCode";
            this.Column15.HeaderText = "发票号";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "UserName";
            this.Column2.HeaderText = "结算人";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "CureNo";
            this.Column3.HeaderText = "住院号";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 70;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "PatName";
            this.Column4.HeaderText = "姓名";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "DeptName";
            this.Column5.HeaderText = "科室";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "CostDate";
            this.Column6.HeaderText = "结算时间";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Total_Fee";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            this.Column7.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column7.HeaderText = "总金额";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Deptosit_Fee";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.Column8.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column8.HeaderText = "预交金";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Self_Fee";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.Column9.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column9.HeaderText = "自付金额";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "Village_Fee";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.Column10.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column10.HeaderText = "记账金额";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "Favor_Fee";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0";
            this.Column11.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column11.HeaderText = "优惠金额";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "Money_Fee";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0";
            this.Column12.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column12.HeaderText = "现金金额";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "Pos_Fee";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = "0";
            this.Column13.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column13.HeaderText = "POS金额";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "CostType";
            this.Column14.HeaderText = "结算类型";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FrmTicketManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.FormTitle = "结算记录";
            this.KeyPreview = true;
            this.Name = "FrmTicketManage";
            this.Text = "结算记录";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmTicketManage_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.plBaseWorkArea.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCost)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zYCostMasterSonBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtpEdate;
        private System.Windows.Forms.DateTimePicker dtpBdate;
        private System.Windows.Forms.ToolStripButton toolCanel;
        private System.Windows.Forms.ToolStripButton toolAgain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.BindingSource zYCostMasterSonBindingSource;
        private GWMHIS.PublicControls.InpatientNOTextBox txtZyh;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgCost;
        private System.Windows.Forms.TextBox txtFP;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
    }
}