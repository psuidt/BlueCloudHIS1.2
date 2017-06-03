namespace HIS_YPManager
{
    partial class ZYFrmDrugRefund
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZYFrmDrugRefund));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.txtPatDept = new System.Windows.Forms.TextBox();
            this.lblPatDept = new System.Windows.Forms.Label();
            this.txtBedNo = new System.Windows.Forms.TextBox();
            this.lblPatBedCode = new System.Windows.Forms.Label();
            this.txtPatAge = new System.Windows.Forms.TextBox();
            this.txtPatName = new System.Windows.Forms.TextBox();
            this.lblPatName = new System.Windows.Forms.Label();
            this.txtPatSex = new System.Windows.Forms.TextBox();
            this.lblPatSex = new System.Windows.Forms.Label();
            this.lblPatAge = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnRefund = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.chkIsRefundAll = new System.Windows.Forms.CheckBox();
            this.cobEndDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cobBeginDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRefunder = new System.Windows.Forms.TextBox();
            this.lblDispenser = new System.Windows.Forms.Label();
            this.txtQueryNum = new GWMHIS.PublicControls.InpatientNOTextBox(this.components);
            this.lblQueryNum = new System.Windows.Forms.Label();
            this.dgrdDispOrder = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.OrderRecipeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpecName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retailPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retailFeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalDispenseNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalRefundNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefundNum = new GWI.HIS.Windows.Controls.DataGridViewTextBoxColumnEx();
            this.UnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderDrugOCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDispOrder = new System.Windows.Forms.Label();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.plBaseWorkArea.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdDispOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDrugOCBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
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
            this.plBaseWorkArea.Controls.Add(this.panel7);
            this.plBaseWorkArea.Controls.Add(this.panel1);
            this.plBaseWorkArea.Location = new System.Drawing.Point(0, 34);
            this.plBaseWorkArea.Size = new System.Drawing.Size(1016, 674);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 69);
            this.panel1.TabIndex = 18;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel9);
            this.panel5.Controls.Add(this.panel10);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1016, 69);
            this.panel5.TabIndex = 21;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Transparent;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel9.Controls.Add(this.txtPatDept);
            this.panel9.Controls.Add(this.lblPatDept);
            this.panel9.Controls.Add(this.txtBedNo);
            this.panel9.Controls.Add(this.lblPatBedCode);
            this.panel9.Controls.Add(this.txtPatAge);
            this.panel9.Controls.Add(this.txtPatName);
            this.panel9.Controls.Add(this.lblPatName);
            this.panel9.Controls.Add(this.txtPatSex);
            this.panel9.Controls.Add(this.lblPatSex);
            this.panel9.Controls.Add(this.lblPatAge);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(586, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(430, 69);
            this.panel9.TabIndex = 1;
            // 
            // txtPatDept
            // 
            this.txtPatDept.Location = new System.Drawing.Point(328, 35);
            this.txtPatDept.Name = "txtPatDept";
            this.txtPatDept.Size = new System.Drawing.Size(88, 23);
            this.txtPatDept.TabIndex = 9;
            this.txtPatDept.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPatDept
            // 
            this.lblPatDept.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPatDept.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPatDept.Location = new System.Drawing.Point(272, 36);
            this.lblPatDept.Name = "lblPatDept";
            this.lblPatDept.Size = new System.Drawing.Size(52, 21);
            this.lblPatDept.TabIndex = 8;
            this.lblPatDept.Text = "科室";
            this.lblPatDept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBedNo
            // 
            this.txtBedNo.Location = new System.Drawing.Point(349, 7);
            this.txtBedNo.Name = "txtBedNo";
            this.txtBedNo.Size = new System.Drawing.Size(67, 23);
            this.txtBedNo.TabIndex = 7;
            this.txtBedNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPatBedCode
            // 
            this.lblPatBedCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPatBedCode.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPatBedCode.Location = new System.Drawing.Point(271, 8);
            this.lblPatBedCode.Name = "lblPatBedCode";
            this.lblPatBedCode.Size = new System.Drawing.Size(72, 21);
            this.lblPatBedCode.TabIndex = 6;
            this.lblPatBedCode.Text = "病人床位";
            this.lblPatBedCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPatAge
            // 
            this.txtPatAge.BackColor = System.Drawing.SystemColors.Window;
            this.txtPatAge.Location = new System.Drawing.Point(201, 35);
            this.txtPatAge.Name = "txtPatAge";
            this.txtPatAge.Size = new System.Drawing.Size(64, 23);
            this.txtPatAge.TabIndex = 5;
            this.txtPatAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPatName
            // 
            this.txtPatName.BackColor = System.Drawing.SystemColors.Window;
            this.txtPatName.Location = new System.Drawing.Point(86, 6);
            this.txtPatName.Name = "txtPatName";
            this.txtPatName.Size = new System.Drawing.Size(179, 23);
            this.txtPatName.TabIndex = 1;
            this.txtPatName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPatName
            // 
            this.lblPatName.BackColor = System.Drawing.Color.Transparent;
            this.lblPatName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPatName.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPatName.Location = new System.Drawing.Point(8, 7);
            this.lblPatName.Name = "lblPatName";
            this.lblPatName.Size = new System.Drawing.Size(72, 21);
            this.lblPatName.TabIndex = 0;
            this.lblPatName.Text = "病人姓名";
            this.lblPatName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPatSex
            // 
            this.txtPatSex.BackColor = System.Drawing.SystemColors.Window;
            this.txtPatSex.Location = new System.Drawing.Point(86, 35);
            this.txtPatSex.Name = "txtPatSex";
            this.txtPatSex.ReadOnly = true;
            this.txtPatSex.Size = new System.Drawing.Size(53, 23);
            this.txtPatSex.TabIndex = 3;
            this.txtPatSex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPatSex
            // 
            this.lblPatSex.BackColor = System.Drawing.Color.Transparent;
            this.lblPatSex.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPatSex.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPatSex.Location = new System.Drawing.Point(8, 36);
            this.lblPatSex.Name = "lblPatSex";
            this.lblPatSex.Size = new System.Drawing.Size(72, 21);
            this.lblPatSex.TabIndex = 2;
            this.lblPatSex.Text = "病人性别";
            this.lblPatSex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPatAge
            // 
            this.lblPatAge.BackColor = System.Drawing.Color.Transparent;
            this.lblPatAge.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPatAge.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPatAge.Location = new System.Drawing.Point(145, 36);
            this.lblPatAge.Name = "lblPatAge";
            this.lblPatAge.Size = new System.Drawing.Size(52, 21);
            this.lblPatAge.TabIndex = 4;
            this.lblPatAge.Text = "年龄";
            this.lblPatAge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel10
            // 
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel10.Controls.Add(this.btnQuery);
            this.panel10.Controls.Add(this.btnRefund);
            this.panel10.Controls.Add(this.chkIsRefundAll);
            this.panel10.Controls.Add(this.btnQuit);
            this.panel10.Controls.Add(this.cobEndDate);
            this.panel10.Controls.Add(this.label2);
            this.panel10.Controls.Add(this.cobBeginDate);
            this.panel10.Controls.Add(this.label1);
            this.panel10.Controls.Add(this.txtRefunder);
            this.panel10.Controls.Add(this.lblDispenser);
            this.panel10.Controls.Add(this.txtQueryNum);
            this.panel10.Controls.Add(this.lblQueryNum);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(586, 69);
            this.panel10.TabIndex = 0;
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(498, 1);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(78, 29);
            this.btnQuery.TabIndex = 13;
            this.btnQuery.Text = "查询(&F)";
            this.btnQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnRefund
            // 
            this.btnRefund.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefund.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRefund.Image = ((System.Drawing.Image)(resources.GetObject("btnRefund.Image")));
            this.btnRefund.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefund.Location = new System.Drawing.Point(414, 31);
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(78, 29);
            this.btnRefund.TabIndex = 4;
            this.btnRefund.Text = "退药 F2";
            this.btnRefund.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefund.UseVisualStyleBackColor = true;
            this.btnRefund.Click += new System.EventHandler(this.btnRefund_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.Location = new System.Drawing.Point(498, 31);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(78, 29);
            this.btnQuit.TabIndex = 5;
            this.btnQuit.Text = "关闭(&C)";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // chkIsRefundAll
            // 
            this.chkIsRefundAll.AutoSize = true;
            this.chkIsRefundAll.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkIsRefundAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkIsRefundAll.Location = new System.Drawing.Point(406, 7);
            this.chkIsRefundAll.Name = "chkIsRefundAll";
            this.chkIsRefundAll.Size = new System.Drawing.Size(86, 18);
            this.chkIsRefundAll.TabIndex = 12;
            this.chkIsRefundAll.Text = "默认全退";
            this.chkIsRefundAll.UseVisualStyleBackColor = true;
            this.chkIsRefundAll.CheckedChanged += new System.EventHandler(this.chkIsRefundAll_CheckedChanged);
            // 
            // cobEndDate
            // 
            this.cobEndDate.Location = new System.Drawing.Point(236, 4);
            this.cobEndDate.Name = "cobEndDate";
            this.cobEndDate.Size = new System.Drawing.Size(135, 23);
            this.cobEndDate.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "到";
            // 
            // cobBeginDate
            // 
            this.cobBeginDate.Location = new System.Drawing.Point(71, 4);
            this.cobBeginDate.Name = "cobBeginDate";
            this.cobBeginDate.Size = new System.Drawing.Size(135, 23);
            this.cobBeginDate.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(1, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "发药时间";
            // 
            // txtRefunder
            // 
            this.txtRefunder.BackColor = System.Drawing.SystemColors.Window;
            this.txtRefunder.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRefunder.Location = new System.Drawing.Point(236, 33);
            this.txtRefunder.Name = "txtRefunder";
            this.txtRefunder.ReadOnly = true;
            this.txtRefunder.Size = new System.Drawing.Size(158, 23);
            this.txtRefunder.TabIndex = 1;
            this.txtRefunder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDispenser
            // 
            this.lblDispenser.AutoSize = true;
            this.lblDispenser.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDispenser.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblDispenser.Location = new System.Drawing.Point(181, 37);
            this.lblDispenser.Name = "lblDispenser";
            this.lblDispenser.Size = new System.Drawing.Size(52, 14);
            this.lblDispenser.TabIndex = 6;
            this.lblDispenser.Text = "退药人";
            // 
            // txtQueryNum
            // 
            this.txtQueryNum.EnabledFalseBackColor = System.Drawing.SystemColors.Control;
            this.txtQueryNum.EnabledTrueBackColor = System.Drawing.SystemColors.Window;
            this.txtQueryNum.EnterBackColor = System.Drawing.SystemColors.Window;
            this.txtQueryNum.EnterForeColor = System.Drawing.SystemColors.WindowText;
            this.txtQueryNum.Location = new System.Drawing.Point(71, 33);
            this.txtQueryNum.Name = "txtQueryNum";
            this.txtQueryNum.NextControl = null;
            this.txtQueryNum.PreviousControl = null;
            this.txtQueryNum.Size = new System.Drawing.Size(102, 23);
            this.txtQueryNum.TabIndex = 0;
            this.txtQueryNum.Text = "00000000";
            // 
            // lblQueryNum
            // 
            this.lblQueryNum.AutoSize = true;
            this.lblQueryNum.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblQueryNum.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblQueryNum.Location = new System.Drawing.Point(16, 37);
            this.lblQueryNum.Name = "lblQueryNum";
            this.lblQueryNum.Size = new System.Drawing.Size(52, 14);
            this.lblQueryNum.TabIndex = 7;
            this.lblQueryNum.Text = "住院号";
            this.lblQueryNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgrdDispOrder
            // 
            this.dgrdDispOrder.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgrdDispOrder.AllowSortWhenClickColumnHeader = false;
            this.dgrdDispOrder.AllowUserToAddRows = false;
            this.dgrdDispOrder.AutoGenerateColumns = false;
            this.dgrdDispOrder.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgrdDispOrder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdDispOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgrdDispOrder.ColumnHeadersHeight = 30;
            this.dgrdDispOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderRecipeID,
            this.chemNameDataGridViewTextBoxColumn,
            this.SpecName,
            this.retailPriceDataGridViewTextBoxColumn,
            this.retailFeeDataGridViewTextBoxColumn,
            this.TotalDispenseNum,
            this.TotalRefundNum,
            this.RefundNum,
            this.UnitName,
            this.Column1});
            this.dgrdDispOrder.DataSource = this.orderDrugOCBindingSource;
            this.dgrdDispOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdDispOrder.EnableHeadersVisualStyles = false;
            this.dgrdDispOrder.Location = new System.Drawing.Point(0, 24);
            this.dgrdDispOrder.Name = "dgrdDispOrder";
            this.dgrdDispOrder.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdDispOrder.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dgrdDispOrder.RowHeadersVisible = false;
            this.dgrdDispOrder.RowTemplate.Height = 23;
            this.dgrdDispOrder.SelectionCards = null;
            this.dgrdDispOrder.Size = new System.Drawing.Size(1016, 581);
            this.dgrdDispOrder.TabIndex = 0;
            this.dgrdDispOrder.UseGradientBackgroundColor = true;
            this.dgrdDispOrder.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrdDispOrder_CellEndEdit);
            // 
            // OrderRecipeID
            // 
            this.OrderRecipeID.DataPropertyName = "OrderRecipeID";
            this.OrderRecipeID.HeaderText = "记账编号";
            this.OrderRecipeID.Name = "OrderRecipeID";
            this.OrderRecipeID.ReadOnly = true;
            this.OrderRecipeID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OrderRecipeID.Width = 70;
            // 
            // chemNameDataGridViewTextBoxColumn
            // 
            this.chemNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chemNameDataGridViewTextBoxColumn.DataPropertyName = "ChemName";
            dataGridViewCellStyle18.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chemNameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle18;
            this.chemNameDataGridViewTextBoxColumn.HeaderText = "药品名称";
            this.chemNameDataGridViewTextBoxColumn.Name = "chemNameDataGridViewTextBoxColumn";
            this.chemNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.chemNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SpecName
            // 
            this.SpecName.DataPropertyName = "SPEC";
            this.SpecName.HeaderText = "规格";
            this.SpecName.Name = "SpecName";
            this.SpecName.ReadOnly = true;
            this.SpecName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SpecName.Width = 130;
            // 
            // retailPriceDataGridViewTextBoxColumn
            // 
            this.retailPriceDataGridViewTextBoxColumn.DataPropertyName = "RetailPrice";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.Format = "N3";
            dataGridViewCellStyle19.NullValue = null;
            this.retailPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle19;
            this.retailPriceDataGridViewTextBoxColumn.FillWeight = 80F;
            this.retailPriceDataGridViewTextBoxColumn.HeaderText = "零售价";
            this.retailPriceDataGridViewTextBoxColumn.Name = "retailPriceDataGridViewTextBoxColumn";
            this.retailPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.retailPriceDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.retailPriceDataGridViewTextBoxColumn.Width = 55;
            // 
            // retailFeeDataGridViewTextBoxColumn
            // 
            this.retailFeeDataGridViewTextBoxColumn.DataPropertyName = "RetailFee";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle20.Format = "N2";
            dataGridViewCellStyle20.NullValue = null;
            this.retailFeeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle20;
            this.retailFeeDataGridViewTextBoxColumn.HeaderText = "零售金额";
            this.retailFeeDataGridViewTextBoxColumn.Name = "retailFeeDataGridViewTextBoxColumn";
            this.retailFeeDataGridViewTextBoxColumn.ReadOnly = true;
            this.retailFeeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.retailFeeDataGridViewTextBoxColumn.Width = 60;
            // 
            // TotalDispenseNum
            // 
            this.TotalDispenseNum.DataPropertyName = "TOTALDISPENSENUM";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle21.Format = "N0";
            dataGridViewCellStyle21.NullValue = "N0";
            this.TotalDispenseNum.DefaultCellStyle = dataGridViewCellStyle21;
            this.TotalDispenseNum.FillWeight = 80F;
            this.TotalDispenseNum.HeaderText = "发药量";
            this.TotalDispenseNum.Name = "TotalDispenseNum";
            this.TotalDispenseNum.ReadOnly = true;
            this.TotalDispenseNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TotalDispenseNum.Width = 50;
            // 
            // TotalRefundNum
            // 
            this.TotalRefundNum.DataPropertyName = "TOTALREFUNDNUM";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle22.Format = "N0";
            dataGridViewCellStyle22.NullValue = null;
            this.TotalRefundNum.DefaultCellStyle = dataGridViewCellStyle22;
            this.TotalRefundNum.HeaderText = "退药量";
            this.TotalRefundNum.Name = "TotalRefundNum";
            this.TotalRefundNum.ReadOnly = true;
            this.TotalRefundNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TotalRefundNum.Width = 50;
            // 
            // RefundNum
            // 
            this.RefundNum.DataPropertyName = "RefundNum";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.Blue;
            this.RefundNum.DefaultCellStyle = dataGridViewCellStyle23;
            this.RefundNum.FillWeight = 80F;
            this.RefundNum.HeaderText = "本次退药";
            this.RefundNum.JumpInType = GWI.HIS.Windows.Controls.JumpInType.AwaysJumpIn;
            this.RefundNum.Name = "RefundNum";
            this.RefundNum.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RefundNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RefundNum.TextFormatStyle = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.RefundNum.Width = 60;
            // 
            // UnitName
            // 
            this.UnitName.DataPropertyName = "UNITNAME";
            this.UnitName.HeaderText = "单位";
            this.UnitName.Name = "UnitName";
            this.UnitName.ReadOnly = true;
            this.UnitName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UnitName.Width = 35;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "OPTIME";
            this.Column1.HeaderText = "发药时间";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // orderDrugOCBindingSource
            // 
            this.orderDrugOCBindingSource.DataSource = typeof(HIS.Model.YP_DROrder);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblDispOrder);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1016, 24);
            this.panel2.TabIndex = 0;
            // 
            // lblDispOrder
            // 
            this.lblDispOrder.AutoSize = true;
            this.lblDispOrder.BackColor = System.Drawing.Color.Transparent;
            this.lblDispOrder.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDispOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblDispOrder.Location = new System.Drawing.Point(3, 3);
            this.lblDispOrder.Name = "lblDispOrder";
            this.lblDispOrder.Size = new System.Drawing.Size(67, 14);
            this.lblDispOrder.TabIndex = 0;
            this.lblDispOrder.Text = "发药明细";
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "退药数量";
            this.dataGridTextBoxColumn6.Width = 75;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "零售金额";
            this.dataGridTextBoxColumn5.Width = 75;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "零售价";
            this.dataGridTextBoxColumn4.Width = 75;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "发药数量";
            this.dataGridTextBoxColumn3.Width = 75;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "规格";
            this.dataGridTextBoxColumn2.Width = 75;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "药品名称";
            this.dataGridTextBoxColumn1.Width = 75;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel6);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel7.Location = new System.Drawing.Point(0, 69);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1016, 605);
            this.panel7.TabIndex = 23;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgrdDispOrder);
            this.panel6.Controls.Add(this.panel2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1016, 605);
            this.panel6.TabIndex = 22;
            // 
            // ZYFrmDrugRefund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormTitle = "药房住院退药";
            this.KeyPreview = true;
            this.Name = "ZYFrmDrugRefund";
            this.Text = "药房住院退药";
            this.Load += new System.EventHandler(this.ZYFrmDrugRefund_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ZYFrmDrugRefund_KeyDown);
            this.plBaseWorkArea.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdDispOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDrugOCBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPatSex;
        private System.Windows.Forms.Label lblQueryNum;
        private System.Windows.Forms.Label lblPatAge;
        private System.Windows.Forms.Label lblPatSex;
        private System.Windows.Forms.Label lblPatName;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnRefund;
        private System.Windows.Forms.TextBox txtRefunder;
        private System.Windows.Forms.Label lblDispenser;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgrdDispOrder;
        private System.Windows.Forms.BindingSource orderDrugOCBindingSource;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblDispOrder;
        private GWMHIS.PublicControls.InpatientNOTextBox txtQueryNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn drugOCNumDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TextBox txtPatAge;
        private System.Windows.Forms.TextBox txtPatName;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DateTimePicker cobEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker cobBeginDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderRecipeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn chemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpecName;
        private System.Windows.Forms.DataGridViewTextBoxColumn retailPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn retailFeeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalDispenseNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalRefundNum;
        private GWI.HIS.Windows.Controls.DataGridViewTextBoxColumnEx RefundNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.CheckBox chkIsRefundAll;
        private System.Windows.Forms.Label lblPatBedCode;
        private System.Windows.Forms.Label lblPatDept;
        private System.Windows.Forms.TextBox txtBedNo;
        private System.Windows.Forms.TextBox txtPatDept;
        private System.Windows.Forms.Button btnQuery;

    }
}