namespace HIS_MZDocManager
{
    partial class FrmTransfusionCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTransfusionCard));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dTPkEnd = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dTPkBegin = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this._lvwPatientList = new GWI.HIS.Windows.Controls.ListView(this.components);
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this._btRefreshPatient = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtFeeType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.tBVisitNo = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSex = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tBDiagnosis = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tBCardno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btRefresh = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.btPrint = new System.Windows.Forms.Button();
            this.dGVEMain = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PresNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dept_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Standard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usage_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usage_Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dosage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usage_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frequency_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Days = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_Money = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Entrust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plBaseWorkArea.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVEMain)).BeginInit();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Size = new System.Drawing.Size(937, 10);
            this.plBaseToolbar.Visible = false;
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
            this.plBaseStatus.Location = new System.Drawing.Point(0, 447);
            this.plBaseStatus.Size = new System.Drawing.Size(937, 26);
            this.plBaseStatus.Visible = false;
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.dGVEMain);
            this.plBaseWorkArea.Controls.Add(this.panel4);
            this.plBaseWorkArea.Controls.Add(this.panel3);
            this.plBaseWorkArea.Controls.Add(this.panel1);
            this.plBaseWorkArea.Font = new System.Drawing.Font("宋体", 9F);
            this.plBaseWorkArea.Location = new System.Drawing.Point(0, 44);
            this.plBaseWorkArea.Size = new System.Drawing.Size(937, 403);
            // 
            // dTPkEnd
            // 
            this.dTPkEnd.Location = new System.Drawing.Point(34, 29);
            this.dTPkEnd.Name = "dTPkEnd";
            this.dTPkEnd.Size = new System.Drawing.Size(116, 21);
            this.dTPkEnd.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "至";
            // 
            // dTPkBegin
            // 
            this.dTPkBegin.Location = new System.Drawing.Point(34, 5);
            this.dTPkBegin.Name = "dTPkBegin";
            this.dTPkBegin.Size = new System.Drawing.Size(116, 21);
            this.dTPkBegin.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "从";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this._lvwPatientList);
            this.panel1.Controls.Add(this._btRefreshPatient);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(162, 403);
            this.panel1.TabIndex = 0;
            // 
            // _lvwPatientList
            // 
            this._lvwPatientList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this._lvwPatientList.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lvwPatientList.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._lvwPatientList.FullRowSelect = true;
            this._lvwPatientList.GridLines = true;
            this._lvwPatientList.Location = new System.Drawing.Point(0, 84);
            this._lvwPatientList.MultiSelect = false;
            this._lvwPatientList.Name = "_lvwPatientList";
            this._lvwPatientList.Size = new System.Drawing.Size(160, 317);
            this._lvwPatientList.TabIndex = 5;
            this._lvwPatientList.UseCompatibleStateImageBehavior = false;
            this._lvwPatientList.UseGradientBackgroundColor = false;
            this._lvwPatientList.View = System.Windows.Forms.View.Details;
            this._lvwPatientList.DoubleClick += new System.EventHandler(this._lvwPatientList_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "门诊号";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "病人姓名";
            this.columnHeader2.Width = 85;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "性别";
            this.columnHeader3.Width = 55;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "年龄";
            this.columnHeader4.Width = 85;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "挂号医师";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "挂号科室";
            this.columnHeader6.Width = 80;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "挂号时间";
            this.columnHeader7.Width = 150;
            // 
            // _btRefreshPatient
            // 
            this._btRefreshPatient.Dock = System.Windows.Forms.DockStyle.Top;
            this._btRefreshPatient.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._btRefreshPatient.Location = new System.Drawing.Point(0, 61);
            this._btRefreshPatient.Name = "_btRefreshPatient";
            this._btRefreshPatient.Size = new System.Drawing.Size(160, 23);
            this._btRefreshPatient.TabIndex = 4;
            this._btRefreshPatient.Text = "刷新病人(共0人)";
            this._btRefreshPatient.UseVisualStyleBackColor = true;
            this._btRefreshPatient.Click += new System.EventHandler(this._btRefreshPatient_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.dTPkEnd);
            this.panel2.Controls.Add(this.dTPkBegin);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(160, 61);
            this.panel2.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(256, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(105, 21);
            this.txtName.TabIndex = 39;
            // 
            // txtFeeType
            // 
            this.txtFeeType.Location = new System.Drawing.Point(256, 34);
            this.txtFeeType.Name = "txtFeeType";
            this.txtFeeType.Size = new System.Drawing.Size(105, 21);
            this.txtFeeType.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "门 诊 号：";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(570, 7);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(145, 21);
            this.txtTel.TabIndex = 42;
            // 
            // tBVisitNo
            // 
            this.tBVisitNo.Location = new System.Drawing.Point(78, 35);
            this.tBVisitNo.Name = "tBVisitNo";
            this.tBVisitNo.Size = new System.Drawing.Size(107, 21);
            this.tBVisitNo.TabIndex = 29;
            this.tBVisitNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBVisitNo_KeyPress);
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(482, 10);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(33, 21);
            this.txtAge.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 30;
            this.label3.Text = "病人姓名：";
            // 
            // txtSex
            // 
            this.txtSex.Location = new System.Drawing.Point(405, 10);
            this.txtSex.Name = "txtSex";
            this.txtSex.Size = new System.Drawing.Size(35, 21);
            this.txtSex.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(367, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 31;
            this.label4.Text = "性别：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(446, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 32;
            this.label7.Text = "年龄：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(521, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 34;
            this.label10.Text = "电话：";
            // 
            // tBDiagnosis
            // 
            this.tBDiagnosis.Location = new System.Drawing.Point(405, 34);
            this.tBDiagnosis.Name = "tBDiagnosis";
            this.tBDiagnosis.Size = new System.Drawing.Size(310, 21);
            this.tBDiagnosis.TabIndex = 36;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(191, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 35;
            this.label12.Text = "病人类型：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(367, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 33;
            this.label14.Text = "诊断：";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tBCardno);
            this.panel3.Controls.Add(this.tBVisitNo);
            this.panel3.Controls.Add(this.txtAge);
            this.panel3.Controls.Add(this.tBDiagnosis);
            this.panel3.Controls.Add(this.txtSex);
            this.panel3.Controls.Add(this.txtName);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.txtFeeType);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.txtTel);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(162, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(775, 61);
            this.panel3.TabIndex = 1;
            // 
            // tBCardno
            // 
            this.tBCardno.Location = new System.Drawing.Point(78, 9);
            this.tBCardno.Name = "tBCardno";
            this.tBCardno.Size = new System.Drawing.Size(107, 21);
            this.tBCardno.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "诊疗卡号：";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btRefresh);
            this.panel4.Controls.Add(this.btClose);
            this.panel4.Controls.Add(this.btPrint);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(162, 61);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(775, 37);
            this.panel4.TabIndex = 2;
            // 
            // btRefresh
            // 
            this.btRefresh.BackColor = System.Drawing.Color.White;
            this.btRefresh.Location = new System.Drawing.Point(417, 6);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(75, 23);
            this.btRefresh.TabIndex = 34;
            this.btRefresh.Text = "刷新";
            this.btRefresh.UseVisualStyleBackColor = false;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(579, 6);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 33;
            this.btClose.Text = "退出";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btPrint
            // 
            this.btPrint.Location = new System.Drawing.Point(498, 6);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(75, 23);
            this.btPrint.TabIndex = 32;
            this.btPrint.Text = "打印";
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // dGVEMain
            // 
            this.dGVEMain.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dGVEMain.AllowSortWhenClickColumnHeader = false;
            this.dGVEMain.AllowUserToAddRows = false;
            this.dGVEMain.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVEMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVEMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVEMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.PresNo,
            this.OrderNo,
            this.Item_Id,
            this.Item_Name,
            this.Dept_Name,
            this.Standard,
            this.Price,
            this.Usage_Amount,
            this.Usage_Unit,
            this.Dosage,
            this.Usage_Name,
            this.Frequency_Name,
            this.Days,
            this.Item_Amount,
            this.Item_Unit,
            this.Item_Money,
            this.Entrust});
            this.dGVEMain.DisplayAllItemWhenSelectionCardShowing = false;
            this.dGVEMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVEMain.EnableHeadersVisualStyles = false;
            this.dGVEMain.HideSelectionCardWhenCustomInput = false;
            this.dGVEMain.Location = new System.Drawing.Point(162, 98);
            this.dGVEMain.MultiSelect = false;
            this.dGVEMain.Name = "dGVEMain";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVEMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dGVEMain.RowHeadersWidth = 35;
            this.dGVEMain.RowTemplate.Height = 23;
            this.dGVEMain.SelectionCards = new GWI.HIS.Windows.Controls.DataGridViewSelectionCard[0];
            this.dGVEMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVEMain.Size = new System.Drawing.Size(775, 305);
            this.dGVEMain.TabIndex = 7;
            this.dGVEMain.UseGradientBackgroundColor = true;
            this.dGVEMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVEMain_CellClick);
            this.dGVEMain.Paint += new System.Windows.Forms.PaintEventHandler(this.dGVEMain_Paint);
            // 
            // Selected
            // 
            this.Selected.DataPropertyName = "Selected";
            this.Selected.HeaderText = "选";
            this.Selected.Name = "Selected";
            this.Selected.ReadOnly = true;
            this.Selected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Selected.Width = 25;
            // 
            // PresNo
            // 
            this.PresNo.DataPropertyName = "TmpNos";
            this.PresNo.HeaderText = "*";
            this.PresNo.Name = "PresNo";
            this.PresNo.ReadOnly = true;
            this.PresNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PresNo.Width = 30;
            // 
            // OrderNo
            // 
            this.OrderNo.DataPropertyName = "OrderNo";
            this.OrderNo.HeaderText = "行号";
            this.OrderNo.Name = "OrderNo";
            this.OrderNo.ReadOnly = true;
            this.OrderNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OrderNo.Visible = false;
            this.OrderNo.Width = 5;
            // 
            // Item_Id
            // 
            this.Item_Id.DataPropertyName = "Item_Id_S";
            this.Item_Id.HeaderText = "项目编码";
            this.Item_Id.Name = "Item_Id";
            this.Item_Id.ReadOnly = true;
            this.Item_Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Item_Id.Width = 70;
            // 
            // Item_Name
            // 
            this.Item_Name.DataPropertyName = "Item_Name_S";
            this.Item_Name.HeaderText = "项目名称";
            this.Item_Name.Name = "Item_Name";
            this.Item_Name.ReadOnly = true;
            this.Item_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Item_Name.Width = 205;
            // 
            // Dept_Name
            // 
            this.Dept_Name.DataPropertyName = "Dept_Name";
            this.Dept_Name.HeaderText = "执行科室";
            this.Dept_Name.Name = "Dept_Name";
            this.Dept_Name.ReadOnly = true;
            this.Dept_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Standard
            // 
            this.Standard.DataPropertyName = "Standard";
            this.Standard.HeaderText = "规格";
            this.Standard.Name = "Standard";
            this.Standard.ReadOnly = true;
            this.Standard.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Standard.Width = 110;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Item_Price_S";
            this.Price.HeaderText = "价格";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Price.Width = 60;
            // 
            // Usage_Amount
            // 
            this.Usage_Amount.DataPropertyName = "Usage_Amount_S";
            this.Usage_Amount.HeaderText = "用量/次";
            this.Usage_Amount.Name = "Usage_Amount";
            this.Usage_Amount.ReadOnly = true;
            this.Usage_Amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Usage_Amount.Width = 60;
            // 
            // Usage_Unit
            // 
            this.Usage_Unit.DataPropertyName = "Usage_Unit";
            this.Usage_Unit.HeaderText = "单位";
            this.Usage_Unit.Name = "Usage_Unit";
            this.Usage_Unit.ReadOnly = true;
            this.Usage_Unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Usage_Unit.Width = 50;
            // 
            // Dosage
            // 
            this.Dosage.DataPropertyName = "Dosage_S";
            this.Dosage.HeaderText = "剂数";
            this.Dosage.Name = "Dosage";
            this.Dosage.ReadOnly = true;
            this.Dosage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Dosage.Width = 40;
            // 
            // Usage_Name
            // 
            this.Usage_Name.DataPropertyName = "Usage_Name";
            this.Usage_Name.HeaderText = "用法";
            this.Usage_Name.Name = "Usage_Name";
            this.Usage_Name.ReadOnly = true;
            this.Usage_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Usage_Name.Width = 70;
            // 
            // Frequency_Name
            // 
            this.Frequency_Name.DataPropertyName = "Frequency_Name";
            this.Frequency_Name.HeaderText = "频次";
            this.Frequency_Name.Name = "Frequency_Name";
            this.Frequency_Name.ReadOnly = true;
            this.Frequency_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Frequency_Name.Width = 50;
            // 
            // Days
            // 
            this.Days.DataPropertyName = "Days_S";
            this.Days.HeaderText = "天数";
            this.Days.Name = "Days";
            this.Days.ReadOnly = true;
            this.Days.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Days.Width = 40;
            // 
            // Item_Amount
            // 
            this.Item_Amount.DataPropertyName = "Item_Amount_S";
            this.Item_Amount.HeaderText = "开药数量";
            this.Item_Amount.Name = "Item_Amount";
            this.Item_Amount.ReadOnly = true;
            this.Item_Amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Item_Amount.Width = 50;
            // 
            // Item_Unit
            // 
            this.Item_Unit.DataPropertyName = "Item_Unit";
            this.Item_Unit.HeaderText = "开药单位";
            this.Item_Unit.Name = "Item_Unit";
            this.Item_Unit.ReadOnly = true;
            this.Item_Unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Item_Unit.Width = 50;
            // 
            // Item_Money
            // 
            this.Item_Money.DataPropertyName = "Item_Money";
            this.Item_Money.HeaderText = "金额";
            this.Item_Money.Name = "Item_Money";
            this.Item_Money.ReadOnly = true;
            this.Item_Money.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Item_Money.Width = 60;
            // 
            // Entrust
            // 
            this.Entrust.DataPropertyName = "Entrust";
            this.Entrust.HeaderText = "嘱托";
            this.Entrust.Name = "Entrust";
            this.Entrust.ReadOnly = true;
            this.Entrust.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Entrust.Width = 150;
            // 
            // FrmTransfusionCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 473);
            this.Name = "FrmTransfusionCard";
            this.Text = "FrmSkinTestProcess";
            this.Load += new System.EventHandler(this.FrmTransfusionCard_Load);
            this.plBaseWorkArea.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVEMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dTPkEnd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dTPkBegin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button _btRefreshPatient;
        private GWI.HIS.Windows.Controls.ListView _lvwPatientList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtFeeType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox tBVisitNo;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSex;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tBDiagnosis;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBCardno;
        private GWI.HIS.Windows.Controls.DataGridViewEx dGVEMain;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn PresNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dept_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Standard;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usage_Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usage_Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dosage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usage_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequency_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Days;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Money;
        private System.Windows.Forms.DataGridViewTextBoxColumn Entrust;
        private System.Windows.Forms.Button btRefresh;
    }
}