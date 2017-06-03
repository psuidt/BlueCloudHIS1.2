namespace HIS_DJSFManager.窗口
{
    partial class FrmAccount
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle( );
            this.label1 = new System.Windows.Forms.Label( );
            this.label2 = new System.Windows.Forms.Label( );
            this.cboUser = new System.Windows.Forms.ComboBox( );
            this.cboAccountDate = new System.Windows.Forms.ComboBox( );
            this.dgvInvoiceItem = new GWI.HIS.Windows.Controls.DataGridViewEx( );
            this.ITEM_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.MONEY = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.dgvInvoiceList = new GWI.HIS.Windows.Controls.DataGridViewEx( );
            this.InvoiceType = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.NumberStartAndEnd = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.TotalNum = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.RefundNum = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.RefundMoney = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.ViewDetail = new System.Windows.Forms.DataGridViewLinkColumn( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.groupBox2 = new System.Windows.Forms.GroupBox( );
            this.groupBox3 = new System.Windows.Forms.GroupBox( );
            this.txtFavor = new System.Windows.Forms.TextBox( );
            this.txtChargeFee = new System.Windows.Forms.TextBox( );
            this.txtExiamFee = new System.Windows.Forms.TextBox( );
            this.txtRegFee = new System.Windows.Forms.TextBox( );
            this.txtFactCash = new System.Windows.Forms.TextBox( );
            this.label4 = new System.Windows.Forms.Label( );
            this.label3 = new System.Windows.Forms.Label( );
            this.groupBox4 = new System.Windows.Forms.GroupBox( );
            this.dgvTallyPart = new GWI.HIS.Windows.Controls.DataGridViewEx( );
            this.TallyType = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.TallyNumber = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.TallyMoney = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.label5 = new System.Windows.Forms.Label( );
            this.txtTotal = new System.Windows.Forms.TextBox( );
            this.txtTotalCN = new System.Windows.Forms.TextBox( );
            this.btnHandIn = new System.Windows.Forms.Button( );
            this.btnPrint = new System.Windows.Forms.Button( );
            this.btnClose = new System.Windows.Forms.Button( );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvInvoiceItem ) ).BeginInit( );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvInvoiceList ) ).BeginInit( );
            this.groupBox1.SuspendLayout( );
            this.groupBox2.SuspendLayout( );
            this.groupBox3.SuspendLayout( );
            this.groupBox4.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvTallyPart ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label1.Location = new System.Drawing.Point( 6 , 9 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 72 , 16 );
            this.label1.TabIndex = 0;
            this.label1.Text = "交款人：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label2.Location = new System.Drawing.Point( 239 , 9 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 104 , 16 );
            this.label2.TabIndex = 1;
            this.label2.Text = "交款单时间：";
            // 
            // cboUser
            // 
            this.cboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUser.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.cboUser.FormattingEnabled = true;
            this.cboUser.Location = new System.Drawing.Point( 71 , 6 );
            this.cboUser.Name = "cboUser";
            this.cboUser.Size = new System.Drawing.Size( 162 , 24 );
            this.cboUser.TabIndex = 2;
            // 
            // cboAccountDate
            // 
            this.cboAccountDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccountDate.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.cboAccountDate.FormattingEnabled = true;
            this.cboAccountDate.Location = new System.Drawing.Point( 327 , 6 );
            this.cboAccountDate.Name = "cboAccountDate";
            this.cboAccountDate.Size = new System.Drawing.Size( 269 , 24 );
            this.cboAccountDate.TabIndex = 3;
            // 
            // dgvInvoiceItem
            // 
            this.dgvInvoiceItem.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvInvoiceItem.AllowSortWhenClickColumnHeader = false;
            this.dgvInvoiceItem.AllowUserToAddRows = false;
            this.dgvInvoiceItem.AllowUserToDeleteRows = false;
            this.dgvInvoiceItem.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle1.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoiceItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInvoiceItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInvoiceItem.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.ITEM_NAME,
            this.MONEY} );
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInvoiceItem.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInvoiceItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInvoiceItem.EnableHeadersVisualStyles = false;
            this.dgvInvoiceItem.Location = new System.Drawing.Point( 3 , 17 );
            this.dgvInvoiceItem.Name = "dgvInvoiceItem";
            this.dgvInvoiceItem.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle4.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoiceItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInvoiceItem.RowTemplate.Height = 23;
            this.dgvInvoiceItem.SelectionCards = null;
            this.dgvInvoiceItem.Size = new System.Drawing.Size( 418 , 275 );
            this.dgvInvoiceItem.TabIndex = 0;
            this.dgvInvoiceItem.UseGradientBackgroundColor = false;
            // 
            // ITEM_NAME
            // 
            this.ITEM_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ITEM_NAME.HeaderText = "项目";
            this.ITEM_NAME.Name = "ITEM_NAME";
            this.ITEM_NAME.ReadOnly = true;
            this.ITEM_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MONEY
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.MONEY.DefaultCellStyle = dataGridViewCellStyle2;
            this.MONEY.HeaderText = "金额";
            this.MONEY.Name = "MONEY";
            this.MONEY.ReadOnly = true;
            this.MONEY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MONEY.Width = 200;
            // 
            // dgvInvoiceList
            // 
            this.dgvInvoiceList.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvInvoiceList.AllowSortWhenClickColumnHeader = false;
            this.dgvInvoiceList.AllowUserToAddRows = false;
            this.dgvInvoiceList.AllowUserToDeleteRows = false;
            this.dgvInvoiceList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle5.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoiceList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvInvoiceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInvoiceList.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.InvoiceType,
            this.NumberStartAndEnd,
            this.TotalNum,
            this.RefundNum,
            this.RefundMoney,
            this.ViewDetail} );
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInvoiceList.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvInvoiceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInvoiceList.EnableHeadersVisualStyles = false;
            this.dgvInvoiceList.Location = new System.Drawing.Point( 3 , 17 );
            this.dgvInvoiceList.Name = "dgvInvoiceList";
            this.dgvInvoiceList.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle12.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoiceList.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvInvoiceList.RowTemplate.Height = 23;
            this.dgvInvoiceList.SelectionCards = null;
            this.dgvInvoiceList.Size = new System.Drawing.Size( 845 , 76 );
            this.dgvInvoiceList.TabIndex = 0;
            this.dgvInvoiceList.UseGradientBackgroundColor = false;
            this.dgvInvoiceList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler( this.dgvInvoiceList_CellContentClick );
            // 
            // InvoiceType
            // 
            this.InvoiceType.HeaderText = "票类";
            this.InvoiceType.Name = "InvoiceType";
            this.InvoiceType.ReadOnly = true;
            this.InvoiceType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NumberStartAndEnd
            // 
            this.NumberStartAndEnd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NumberStartAndEnd.DefaultCellStyle = dataGridViewCellStyle6;
            this.NumberStartAndEnd.HeaderText = "起止号码";
            this.NumberStartAndEnd.Name = "NumberStartAndEnd";
            this.NumberStartAndEnd.ReadOnly = true;
            this.NumberStartAndEnd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TotalNum
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TotalNum.DefaultCellStyle = dataGridViewCellStyle7;
            this.TotalNum.HeaderText = "张数";
            this.TotalNum.Name = "TotalNum";
            this.TotalNum.ReadOnly = true;
            this.TotalNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RefundNum
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.RefundNum.DefaultCellStyle = dataGridViewCellStyle8;
            this.RefundNum.HeaderText = "退费张数";
            this.RefundNum.Name = "RefundNum";
            this.RefundNum.ReadOnly = true;
            this.RefundNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RefundMoney
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.RefundMoney.DefaultCellStyle = dataGridViewCellStyle9;
            this.RefundMoney.HeaderText = "退费金额";
            this.RefundMoney.Name = "RefundMoney";
            this.RefundMoney.ReadOnly = true;
            this.RefundMoney.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ViewDetail
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            this.ViewDetail.DefaultCellStyle = dataGridViewCellStyle10;
            this.ViewDetail.HeaderText = "";
            this.ViewDetail.Name = "ViewDetail";
            this.ViewDetail.ReadOnly = true;
            this.ViewDetail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ViewDetail.Width = 75;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add( this.dgvInvoiceItem );
            this.groupBox1.Location = new System.Drawing.Point( 1 , 131 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 424 , 295 );
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "收费科目";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add( this.dgvInvoiceList );
            this.groupBox2.Location = new System.Drawing.Point( 1 , 32 );
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size( 851 , 96 );
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "收费票据";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add( this.txtFavor );
            this.groupBox3.Controls.Add( this.txtChargeFee );
            this.groupBox3.Controls.Add( this.txtExiamFee );
            this.groupBox3.Controls.Add( this.txtRegFee );
            this.groupBox3.Controls.Add( this.txtFactCash );
            this.groupBox3.Controls.Add( this.label4 );
            this.groupBox3.Controls.Add( this.label3 );
            this.groupBox3.Location = new System.Drawing.Point( 1 , 427 );
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size( 851 , 71 );
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "收现金";
            // 
            // txtFavor
            // 
            this.txtFavor.BackColor = System.Drawing.Color.White;
            this.txtFavor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFavor.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtFavor.Location = new System.Drawing.Point( 91 , 13 );
            this.txtFavor.Multiline = true;
            this.txtFavor.Name = "txtFavor";
            this.txtFavor.ReadOnly = true;
            this.txtFavor.Size = new System.Drawing.Size( 94 , 23 );
            this.txtFavor.TabIndex = 6;
            this.txtFavor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtChargeFee
            // 
            this.txtChargeFee.BackColor = System.Drawing.Color.White;
            this.txtChargeFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChargeFee.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtChargeFee.Location = new System.Drawing.Point( 728 , 41 );
            this.txtChargeFee.Multiline = true;
            this.txtChargeFee.Name = "txtChargeFee";
            this.txtChargeFee.ReadOnly = true;
            this.txtChargeFee.Size = new System.Drawing.Size( 94 , 23 );
            this.txtChargeFee.TabIndex = 5;
            this.txtChargeFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtExiamFee
            // 
            this.txtExiamFee.BackColor = System.Drawing.Color.White;
            this.txtExiamFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExiamFee.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtExiamFee.Location = new System.Drawing.Point( 533 , 41 );
            this.txtExiamFee.Multiline = true;
            this.txtExiamFee.Name = "txtExiamFee";
            this.txtExiamFee.ReadOnly = true;
            this.txtExiamFee.Size = new System.Drawing.Size( 94 , 23 );
            this.txtExiamFee.TabIndex = 4;
            this.txtExiamFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtRegFee
            // 
            this.txtRegFee.BackColor = System.Drawing.Color.White;
            this.txtRegFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRegFee.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtRegFee.Location = new System.Drawing.Point( 332 , 41 );
            this.txtRegFee.Multiline = true;
            this.txtRegFee.Name = "txtRegFee";
            this.txtRegFee.ReadOnly = true;
            this.txtRegFee.Size = new System.Drawing.Size( 94 , 23 );
            this.txtRegFee.TabIndex = 3;
            this.txtRegFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFactCash
            // 
            this.txtFactCash.BackColor = System.Drawing.Color.White;
            this.txtFactCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFactCash.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtFactCash.Location = new System.Drawing.Point( 91 , 41 );
            this.txtFactCash.Multiline = true;
            this.txtFactCash.Name = "txtFactCash";
            this.txtFactCash.ReadOnly = true;
            this.txtFactCash.Size = new System.Drawing.Size( 94 , 23 );
            this.txtFactCash.TabIndex = 2;
            this.txtFactCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label4.Location = new System.Drawing.Point( 11 , 43 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 840 , 16 );
            this.label4.TabIndex = 1;
            this.label4.Text = "实收现金：            元,(其中:定额挂号             元、定额诊金             元、处方收费            元)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label3.Location = new System.Drawing.Point( 11 , 16 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 72 , 16 );
            this.label3.TabIndex = 0;
            this.label3.Text = "优惠金额";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add( this.dgvTallyPart );
            this.groupBox4.Location = new System.Drawing.Point( 431 , 131 );
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size( 421 , 295 );
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "记账部分";
            // 
            // dgvTallyPart
            // 
            this.dgvTallyPart.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvTallyPart.AllowSortWhenClickColumnHeader = false;
            this.dgvTallyPart.AllowUserToAddRows = false;
            this.dgvTallyPart.AllowUserToDeleteRows = false;
            this.dgvTallyPart.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle13.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTallyPart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvTallyPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTallyPart.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.TallyType,
            this.TallyNumber,
            this.TallyMoney} );
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTallyPart.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgvTallyPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTallyPart.EnableHeadersVisualStyles = false;
            this.dgvTallyPart.Location = new System.Drawing.Point( 3 , 17 );
            this.dgvTallyPart.Name = "dgvTallyPart";
            this.dgvTallyPart.ReadOnly = true;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle17.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTallyPart.RowHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvTallyPart.RowTemplate.Height = 23;
            this.dgvTallyPart.SelectionCards = null;
            this.dgvTallyPart.Size = new System.Drawing.Size( 415 , 275 );
            this.dgvTallyPart.TabIndex = 0;
            this.dgvTallyPart.UseGradientBackgroundColor = false;
            // 
            // TallyType
            // 
            this.TallyType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TallyType.HeaderText = "记账类型";
            this.TallyType.Name = "TallyType";
            this.TallyType.ReadOnly = true;
            this.TallyType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TallyNumber
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TallyNumber.DefaultCellStyle = dataGridViewCellStyle14;
            this.TallyNumber.HeaderText = "张数";
            this.TallyNumber.Name = "TallyNumber";
            this.TallyNumber.ReadOnly = true;
            this.TallyNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TallyMoney
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TallyMoney.DefaultCellStyle = dataGridViewCellStyle15;
            this.TallyMoney.HeaderText = "金额";
            this.TallyMoney.Name = "TallyMoney";
            this.TallyMoney.ReadOnly = true;
            this.TallyMoney.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label5.Location = new System.Drawing.Point( 6 , 503 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 787 , 23 );
            this.label5.TabIndex = 8;
            this.label5.Text = "合计(小写): ￥                    元 、合计（大写）: ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtTotal.Location = new System.Drawing.Point( 125 , 502 );
            this.txtTotal.Multiline = true;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size( 143 , 23 );
            this.txtTotal.TabIndex = 9;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalCN
            // 
            this.txtTotalCN.BackColor = System.Drawing.Color.White;
            this.txtTotalCN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalCN.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtTotalCN.Location = new System.Drawing.Point( 431 , 503 );
            this.txtTotalCN.Multiline = true;
            this.txtTotalCN.Name = "txtTotalCN";
            this.txtTotalCN.ReadOnly = true;
            this.txtTotalCN.Size = new System.Drawing.Size( 418 , 23 );
            this.txtTotalCN.TabIndex = 10;
            // 
            // btnHandIn
            // 
            this.btnHandIn.Location = new System.Drawing.Point( 602 , 6 );
            this.btnHandIn.Name = "btnHandIn";
            this.btnHandIn.Size = new System.Drawing.Size( 75 , 23 );
            this.btnHandIn.TabIndex = 11;
            this.btnHandIn.Text = "交款";
            this.btnHandIn.UseVisualStyleBackColor = true;
            this.btnHandIn.Click += new System.EventHandler( this.btnHandIn_Click );
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point( 683 , 6 );
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size( 75 , 23 );
            this.btnPrint.TabIndex = 12;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler( this.btnPrint_Click );
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point( 764 , 6 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 75 , 23 );
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // FrmAccount
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size( 859 , 535 );
            this.Controls.Add( this.btnClose );
            this.Controls.Add( this.btnPrint );
            this.Controls.Add( this.btnHandIn );
            this.Controls.Add( this.txtTotalCN );
            this.Controls.Add( this.txtTotal );
            this.Controls.Add( this.label5 );
            this.Controls.Add( this.groupBox3 );
            this.Controls.Add( this.groupBox4 );
            this.Controls.Add( this.groupBox2 );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.cboAccountDate );
            this.Controls.Add( this.cboUser );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAccount";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "个人交款表";
            this.Load += new System.EventHandler( this.FrmAccount_Load );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvInvoiceItem ) ).EndInit( );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvInvoiceList ) ).EndInit( );
            this.groupBox1.ResumeLayout( false );
            this.groupBox2.ResumeLayout( false );
            this.groupBox3.ResumeLayout( false );
            this.groupBox3.PerformLayout( );
            this.groupBox4.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvTallyPart ) ).EndInit( );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboUser;
        private System.Windows.Forms.ComboBox cboAccountDate;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvInvoiceItem;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvInvoiceList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvTallyPart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtChargeFee;
        private System.Windows.Forms.TextBox txtExiamFee;
        private System.Windows.Forms.TextBox txtRegFee;
        private System.Windows.Forms.TextBox txtFactCash;
        private System.Windows.Forms.TextBox txtFavor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtTotalCN;
        private System.Windows.Forms.Button btnHandIn;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn MONEY;
        private System.Windows.Forms.DataGridViewTextBoxColumn TallyType;
        private System.Windows.Forms.DataGridViewTextBoxColumn TallyNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn TallyMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberStartAndEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefundNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefundMoney;
        private System.Windows.Forms.DataGridViewLinkColumn ViewDetail;


    }
}