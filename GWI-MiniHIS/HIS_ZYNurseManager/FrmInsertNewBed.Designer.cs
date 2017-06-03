namespace HIS_ZYNurseManager
{
    partial class FrmInsertNewBed
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInsertNewBed));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btninsertbed = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_BedNumUnused = new System.Windows.Forms.Label();
            this.lbl_BedNumUsed = new System.Windows.Forms.Label();
            this.lbl_BedNumAll = new System.Windows.Forms.Label();
            this.lbl_CurrDeptName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbDeptName = new System.Windows.Forms.ComboBox();
            this.queryTextBox1 = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.btncancelbed = new System.Windows.Forms.Button();
            this.chkaddbed = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.dataGridViewEx1 = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Used = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Controls.Add(this.toolStrip1);
            this.plBaseToolbar.Size = new System.Drawing.Size(847, 29);
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
            this.plBaseStatus.Location = new System.Drawing.Point(0, 390);
            this.plBaseStatus.Size = new System.Drawing.Size(847, 26);
            this.plBaseStatus.Visible = false;
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.panel2);
            this.plBaseWorkArea.Controls.Add(this.panel1);
            this.plBaseWorkArea.Size = new System.Drawing.Size(847, 327);
            // 
            // plTitle
            // 
            this.plTitle.Size = new System.Drawing.Size(847, 34);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "科室名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "床  位  号：";
            // 
            // btninsertbed
            // 
            this.btninsertbed.Location = new System.Drawing.Point(277, 18);
            this.btninsertbed.Name = "btninsertbed";
            this.btninsertbed.Size = new System.Drawing.Size(75, 23);
            this.btninsertbed.TabIndex = 4;
            this.btninsertbed.Text = "插入床位";
            this.btninsertbed.UseVisualStyleBackColor = true;
            this.btninsertbed.Visible = false;
            this.btninsertbed.Click += new System.EventHandler(this.btninsertbed_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "房  间  号：";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(98, 76);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(144, 21);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 203);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(847, 124);
            this.panel1.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lbl_BedNumUnused);
            this.groupBox2.Controls.Add(this.lbl_BedNumUsed);
            this.groupBox2.Controls.Add(this.lbl_BedNumAll);
            this.groupBox2.Controls.Add(this.lbl_CurrDeptName);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(376, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(459, 106);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "床位情况";
            // 
            // lbl_BedNumUnused
            // 
            this.lbl_BedNumUnused.AutoSize = true;
            this.lbl_BedNumUnused.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_BedNumUnused.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbl_BedNumUnused.Location = new System.Drawing.Point(160, 75);
            this.lbl_BedNumUnused.Name = "lbl_BedNumUnused";
            this.lbl_BedNumUnused.Size = new System.Drawing.Size(0, 15);
            this.lbl_BedNumUnused.TabIndex = 7;
            // 
            // lbl_BedNumUsed
            // 
            this.lbl_BedNumUsed.AutoSize = true;
            this.lbl_BedNumUsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_BedNumUsed.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbl_BedNumUsed.Location = new System.Drawing.Point(160, 55);
            this.lbl_BedNumUsed.Name = "lbl_BedNumUsed";
            this.lbl_BedNumUsed.Size = new System.Drawing.Size(0, 15);
            this.lbl_BedNumUsed.TabIndex = 6;
            // 
            // lbl_BedNumAll
            // 
            this.lbl_BedNumAll.AutoSize = true;
            this.lbl_BedNumAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_BedNumAll.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbl_BedNumAll.Location = new System.Drawing.Point(124, 36);
            this.lbl_BedNumAll.Name = "lbl_BedNumAll";
            this.lbl_BedNumAll.Size = new System.Drawing.Size(0, 15);
            this.lbl_BedNumAll.TabIndex = 5;
            // 
            // lbl_CurrDeptName
            // 
            this.lbl_CurrDeptName.AutoSize = true;
            this.lbl_CurrDeptName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CurrDeptName.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbl_CurrDeptName.Location = new System.Drawing.Point(112, 17);
            this.lbl_CurrDeptName.Name = "lbl_CurrDeptName";
            this.lbl_CurrDeptName.Size = new System.Drawing.Size(0, 15);
            this.lbl_CurrDeptName.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label7.Location = new System.Drawing.Point(51, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "当前未使用床位数：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label6.Location = new System.Drawing.Point(51, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "当前已使用床位数：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(51, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "当前床位数：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(51, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "当前科室：";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.cmbDeptName);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.queryTextBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btncancelbed);
            this.groupBox1.Controls.Add(this.chkaddbed);
            this.groupBox1.Controls.Add(this.btninsertbed);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 108);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "床位信息";
            // 
            // cmbDeptName
            // 
            this.cmbDeptName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeptName.FormattingEnabled = true;
            this.cmbDeptName.Location = new System.Drawing.Point(99, 14);
            this.cmbDeptName.Name = "cmbDeptName";
            this.cmbDeptName.Size = new System.Drawing.Size(144, 20);
            this.cmbDeptName.TabIndex = 8;
            this.cmbDeptName.SelectedIndexChanged += new System.EventHandler(this.cmbDeptName_SelectedIndexChanged);
            // 
            // queryTextBox1
            // 
            this.queryTextBox1.AllowSelectedNullRow = false;
            this.queryTextBox1.DisplayField = "";
            this.queryTextBox1.Location = new System.Drawing.Point(98, 43);
            this.queryTextBox1.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.queryTextBox1.MaxLength = 3;
            this.queryTextBox1.MemberField = "";
            this.queryTextBox1.MemberValue = null;
            this.queryTextBox1.Name = "queryTextBox1";
            this.queryTextBox1.NextControl = null;
            this.queryTextBox1.NextControlByEnter = false;
            this.queryTextBox1.OffsetX = 0;
            this.queryTextBox1.OffsetY = 0;
            this.queryTextBox1.QueryFields = null;
            this.queryTextBox1.SelectedValue = null;
            this.queryTextBox1.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.queryTextBox1.SelectionCardBackColor = System.Drawing.Color.White;
            this.queryTextBox1.SelectionCardColumnHeaderHeight = 30;
            this.queryTextBox1.SelectionCardColumns = null;
            this.queryTextBox1.SelectionCardFont = null;
            this.queryTextBox1.SelectionCardHeight = 250;
            this.queryTextBox1.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.queryTextBox1.SelectionCardRowHeaderWidth = 35;
            this.queryTextBox1.SelectionCardRowHeight = 23;
            this.queryTextBox1.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.queryTextBox1.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.queryTextBox1.SelectionCardWidth = 250;
            this.queryTextBox1.ShowRowNumber = true;
            this.queryTextBox1.ShowSelectionCardAfterEnter = false;
            this.queryTextBox1.Size = new System.Drawing.Size(75, 21);
            this.queryTextBox1.TabIndex = 9;
            this.queryTextBox1.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.Integer;
            // 
            // btncancelbed
            // 
            this.btncancelbed.Location = new System.Drawing.Point(277, 45);
            this.btncancelbed.Name = "btncancelbed";
            this.btncancelbed.Size = new System.Drawing.Size(75, 23);
            this.btncancelbed.TabIndex = 10;
            this.btncancelbed.Text = "删除床位";
            this.btncancelbed.UseVisualStyleBackColor = true;
            this.btncancelbed.Visible = false;
            this.btncancelbed.Click += new System.EventHandler(this.btncancelbed_Click);
            // 
            // chkaddbed
            // 
            this.chkaddbed.AutoSize = true;
            this.chkaddbed.Location = new System.Drawing.Point(189, 45);
            this.chkaddbed.Name = "chkaddbed";
            this.chkaddbed.Size = new System.Drawing.Size(48, 16);
            this.chkaddbed.TabIndex = 12;
            this.chkaddbed.Text = "加床";
            this.chkaddbed.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Controls.Add(this.dataGridViewEx1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(847, 203);
            this.panel2.TabIndex = 9;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(847, 203);
            this.listView1.TabIndex = 13;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // dataGridViewEx1
            // 
            this.dataGridViewEx1.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dataGridViewEx1.AllowSortWhenClickColumnHeader = false;
            this.dataGridViewEx1.AllowUserToAddRows = false;
            this.dataGridViewEx1.AllowUserToDeleteRows = false;
            this.dataGridViewEx1.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewEx1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewEx1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEx1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column2,
            this.Used});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewEx1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewEx1.DisplayAllItemWhenSelectionCardShowing = false;
            this.dataGridViewEx1.EnableHeadersVisualStyles = false;
            this.dataGridViewEx1.HideSelectionCardWhenCustomInput = false;
            this.dataGridViewEx1.Location = new System.Drawing.Point(0, 204);
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewEx1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewEx1.RowTemplate.Height = 23;
            this.dataGridViewEx1.SelectionCards = null;
            this.dataGridViewEx1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEx1.Size = new System.Drawing.Size(516, 126);
            this.dataGridViewEx1.TabIndex = 0;
            this.dataGridViewEx1.UseGradientBackgroundColor = true;
            this.dataGridViewEx1.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridViewEx1_Paint);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "name";
            this.Column1.HeaderText = "科室名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "dept_id";
            this.Column3.HeaderText = "科室ID";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "bed_no";
            this.Column2.HeaderText = "现存床位";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Used
            // 
            this.Used.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Used.DataPropertyName = "Used";
            this.Used.HeaderText = "是否已分配";
            this.Used.Name = "Used";
            this.Used.ReadOnly = true;
            this.Used.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "0.bmp");
            this.imageList1.Images.SetKeyName(1, "1.bmp");
            this.imageList1.Images.SetKeyName(2, "2.bmp");
            this.imageList1.Images.SetKeyName(3, "3.bmp");
            this.imageList1.Images.SetKeyName(4, "18.bmp");
            this.imageList1.Images.SetKeyName(5, "4.bmp");
            this.imageList1.Images.SetKeyName(6, "5.bmp");
            this.imageList1.Images.SetKeyName(7, "6.bmp");
            this.imageList1.Images.SetKeyName(8, "7.bmp");
            this.imageList1.Images.SetKeyName(9, "8.bmp");
            this.imageList1.Images.SetKeyName(10, "9.bmp");
            this.imageList1.Images.SetKeyName(11, "10.bmp");
            this.imageList1.Images.SetKeyName(12, "11.bmp");
            this.imageList1.Images.SetKeyName(13, "12.bmp");
            this.imageList1.Images.SetKeyName(14, "13.bmp");
            this.imageList1.Images.SetKeyName(15, "14.bmp");
            this.imageList1.Images.SetKeyName(16, "15.bmp");
            this.imageList1.Images.SetKeyName(17, "16.bmp");
            this.imageList1.Images.SetKeyName(18, "17.bmp");
            this.imageList1.Images.SetKeyName(19, "99.bmp");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(847, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(73, 22);
            this.toolStripButton1.Text = "添加床位";
            this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton1.Click += new System.EventHandler(this.btninsertbed_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(73, 22);
            this.toolStripButton2.Text = "删除床位";
            this.toolStripButton2.Click += new System.EventHandler(this.btncancelbed_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(49, 22);
            this.toolStripButton3.Text = "刷新";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(49, 22);
            this.toolStripButton4.Text = "退出";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // FrmInsertNewBed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 416);
            this.FormTitle = "床位维护";
            this.Name = "FrmInsertNewBed";
            this.Text = "床位维护";
            this.plBaseToolbar.ResumeLayout(false);
            this.plBaseToolbar.PerformLayout();
            this.plBaseWorkArea.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btninsertbed;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        public GWI.HIS.Windows.Controls.DataGridViewEx dataGridViewEx1;
        private System.Windows.Forms.ComboBox cmbDeptName;
        private GWI.HIS.Windows.Controls.QueryTextBox queryTextBox1;
        private System.Windows.Forms.Button btncancelbed;
        private System.Windows.Forms.CheckBox chkaddbed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Used;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_CurrDeptName;
        private System.Windows.Forms.Label lbl_BedNumAll;
        private System.Windows.Forms.Label lbl_BedNumUnused;
        private System.Windows.Forms.Label lbl_BedNumUsed;

    }
}