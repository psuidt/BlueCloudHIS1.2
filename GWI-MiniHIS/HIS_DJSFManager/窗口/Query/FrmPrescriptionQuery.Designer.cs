namespace HIS_DJSFManager.窗口
{
    partial class FrmPrescriptionQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmPrescriptionQuery ) );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle( );
            this.label1 = new System.Windows.Forms.Label( );
            this.label2 = new System.Windows.Forms.Label( );
            this.txtPatient = new System.Windows.Forms.TextBox( );
            this.dtpFrom = new System.Windows.Forms.DateTimePicker( );
            this.dtpTo = new System.Windows.Forms.DateTimePicker( );
            this.label3 = new System.Windows.Forms.Label( );
            this.btnQuery = new GWI.HIS.Windows.Controls.Button( );
            this.btnClose = new GWI.HIS.Windows.Controls.Button( );
            this.btnPatient = new GWI.HIS.Windows.Controls.Button( );
            this.dgvPresc = new GWI.HIS.Windows.Controls.DataGridViewEx( );
            this.txtInvoiceNo = new System.Windows.Forms.TextBox( );
            this.label4 = new System.Windows.Forms.Label( );
            this.label5 = new System.Windows.Forms.Label( );
            this.label6 = new System.Windows.Forms.Label( );
            this.NO = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.PresID = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.VisitNo = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.PatName = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.InvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.Item_Name = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.Standard = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.Pack_Unit = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.Pack_Num = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.Base_Num = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.PresAmount = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.TotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.RECORD_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.DRUG_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.plBaseToolbar.SuspendLayout( );
            this.plBaseStatus.SuspendLayout( );
            this.plBaseWorkArea.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvPresc ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Controls.Add( this.txtInvoiceNo );
            this.plBaseToolbar.Controls.Add( this.label4 );
            this.plBaseToolbar.Controls.Add( this.btnPatient );
            this.plBaseToolbar.Controls.Add( this.btnClose );
            this.plBaseToolbar.Controls.Add( this.btnQuery );
            this.plBaseToolbar.Controls.Add( this.label3 );
            this.plBaseToolbar.Controls.Add( this.dtpTo );
            this.plBaseToolbar.Controls.Add( this.dtpFrom );
            this.plBaseToolbar.Controls.Add( this.txtPatient );
            this.plBaseToolbar.Controls.Add( this.label2 );
            this.plBaseToolbar.Controls.Add( this.label1 );
            this.plBaseToolbar.Size = new System.Drawing.Size( 955 , 40 );
            // 
            // baseImageList
            // 
            this.baseImageList.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "baseImageList.ImageStream" ) ) );
            this.baseImageList.Images.SetKeyName( 0 , "table_delete.gif" );
            this.baseImageList.Images.SetKeyName( 1 , "search_big.GIF" );
            this.baseImageList.Images.SetKeyName( 2 , "Save.GIF" );
            this.baseImageList.Images.SetKeyName( 3 , "Print.GIF" );
            this.baseImageList.Images.SetKeyName( 4 , "page_user_dark.gif" );
            this.baseImageList.Images.SetKeyName( 5 , "page_refresh.gif" );
            this.baseImageList.Images.SetKeyName( 6 , "page_key.gif" );
            this.baseImageList.Images.SetKeyName( 7 , "page_edit.gif" );
            this.baseImageList.Images.SetKeyName( 8 , "page_cross.gif" );
            this.baseImageList.Images.SetKeyName( 9 , "list_users.gif" );
            this.baseImageList.Images.SetKeyName( 10 , "icon_package_get.gif" );
            this.baseImageList.Images.SetKeyName( 11 , "icon_network.gif" );
            this.baseImageList.Images.SetKeyName( 12 , "icon_history.gif" );
            this.baseImageList.Images.SetKeyName( 13 , "icon_accept.gif" );
            this.baseImageList.Images.SetKeyName( 14 , "folder_page.gif" );
            this.baseImageList.Images.SetKeyName( 15 , "folder_new.gif" );
            this.baseImageList.Images.SetKeyName( 16 , "Exit.GIF" );
            this.baseImageList.Images.SetKeyName( 17 , "Delete.GIF" );
            this.baseImageList.Images.SetKeyName( 18 , "copy.gif" );
            this.baseImageList.Images.SetKeyName( 19 , "action_stop.gif" );
            this.baseImageList.Images.SetKeyName( 20 , "action_refresh.gif" );
            // 
            // plBaseStatus
            // 
            this.plBaseStatus.Controls.Add( this.label6 );
            this.plBaseStatus.Controls.Add( this.label5 );
            this.plBaseStatus.Location = new System.Drawing.Point( 0 , 436 );
            this.plBaseStatus.Size = new System.Drawing.Size( 955 , 30 );
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add( this.dgvPresc );
            this.plBaseWorkArea.Location = new System.Drawing.Point( 0 , 74 );
            this.plBaseWorkArea.Size = new System.Drawing.Size( 955 , 362 );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 12 , 12 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 53 , 12 );
            this.label1.TabIndex = 0;
            this.label1.Text = "病人姓名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 374 , 15 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 53 , 12 );
            this.label2.TabIndex = 1;
            this.label2.Text = "处方日期";
            // 
            // txtPatient
            // 
            this.txtPatient.Location = new System.Drawing.Point( 70 , 9 );
            this.txtPatient.Name = "txtPatient";
            this.txtPatient.Size = new System.Drawing.Size( 100 , 21 );
            this.txtPatient.TabIndex = 2;
            this.txtPatient.TextChanged += new System.EventHandler( this.txtPatient_TextChanged );
            this.txtPatient.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtPatient_KeyPress );
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point( 433 , 10 );
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size( 116 , 21 );
            this.dtpFrom.TabIndex = 3;
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point( 578 , 10 );
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size( 116 , 21 );
            this.dtpTo.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 555 , 15 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 17 , 12 );
            this.label3.TabIndex = 5;
            this.label3.Text = "到";
            // 
            // btnQuery
            // 
            this.btnQuery.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.OtherProcess;
            this.btnQuery.FixedWidth = false;
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point( 719 , 8 );
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size( 83 , 25 );
            this.btnQuery.TabIndex = 6;
            this.btnQuery.Text = "查询(&Q)";
            this.btnQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler( this.btnQuery_Click );
            // 
            // btnClose
            // 
            this.btnClose.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.OtherProcess;
            this.btnClose.FixedWidth = false;
            this.btnClose.Location = new System.Drawing.Point( 815 , 8 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 83 , 25 );
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // btnPatient
            // 
            this.btnPatient.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.OtherProcess;
            this.btnPatient.FixedWidth = false;
            this.btnPatient.Location = new System.Drawing.Point( 170 , 7 );
            this.btnPatient.Name = "btnPatient";
            this.btnPatient.Size = new System.Drawing.Size( 34 , 25 );
            this.btnPatient.TabIndex = 8;
            this.btnPatient.UseVisualStyleBackColor = true;
            this.btnPatient.Click += new System.EventHandler( this.btnPatient_Click );
            // 
            // dgvPresc
            // 
            this.dgvPresc.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvPresc.AllowSortWhenClickColumnHeader = false;
            this.dgvPresc.AllowUserToAddRows = false;
            this.dgvPresc.AllowUserToDeleteRows = false;
            this.dgvPresc.AllowUserToResizeRows = false;
            this.dgvPresc.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle1.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPresc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPresc.ColumnHeadersHeight = 38;
            this.dgvPresc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPresc.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.NO,
            this.PresID,
            this.VisitNo,
            this.PatName,
            this.InvoiceNo,
            this.Item_Name,
            this.Standard,
            this.Price,
            this.Pack_Unit,
            this.Pack_Num,
            this.Base_Num,
            this.PresAmount,
            this.TotalCost,
            this.RECORD_FLAG,
            this.DRUG_FLAG} );
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle8.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPresc.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPresc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPresc.EnableHeadersVisualStyles = false;
            this.dgvPresc.Location = new System.Drawing.Point( 0 , 0 );
            this.dgvPresc.MultiSelect = false;
            this.dgvPresc.Name = "dgvPresc";
            this.dgvPresc.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle9.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPresc.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvPresc.RowHeadersWidth = 40;
            this.dgvPresc.RowTemplate.Height = 20;
            this.dgvPresc.SelectionCards = null;
            this.dgvPresc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPresc.Size = new System.Drawing.Size( 955 , 362 );
            this.dgvPresc.TabIndex = 0;
            this.dgvPresc.UseGradientBackgroundColor = true;
            this.dgvPresc.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler( this.dgvPresc_DataError );
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point( 268 , 10 );
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size( 100 , 21 );
            this.txtInvoiceNo.TabIndex = 10;
            this.txtInvoiceNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtInvoiceNo_KeyPress );
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 210 , 13 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 41 , 12 );
            this.label4.TabIndex = 9;
            this.label4.Text = "发票号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point( 19 , 7 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 245 , 12 );
            this.label5.TabIndex = 0;
            this.label5.Text = "蓝色：正常处方，（√）代表已经收费或发药";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point( 288 , 7 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 197 , 12 );
            this.label6.TabIndex = 1;
            this.label6.Text = "红色：表示处方在收费后进行了退费";
            // 
            // NO
            // 
            this.NO.DataPropertyName = "NO";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NO.DefaultCellStyle = dataGridViewCellStyle2;
            this.NO.HeaderText = "序";
            this.NO.Name = "NO";
            this.NO.ReadOnly = true;
            this.NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NO.Width = 30;
            // 
            // PresID
            // 
            this.PresID.HeaderText = "处方号";
            this.PresID.Name = "PresID";
            this.PresID.ReadOnly = true;
            this.PresID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PresID.Visible = false;
            this.PresID.Width = 50;
            // 
            // VisitNo
            // 
            this.VisitNo.DataPropertyName = "VisitNo";
            this.VisitNo.HeaderText = "就诊号";
            this.VisitNo.Name = "VisitNo";
            this.VisitNo.ReadOnly = true;
            this.VisitNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PatName
            // 
            this.PatName.DataPropertyName = "PatName";
            this.PatName.HeaderText = "病人姓名";
            this.PatName.Name = "PatName";
            this.PatName.ReadOnly = true;
            this.PatName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PatName.Width = 75;
            // 
            // InvoiceNo
            // 
            this.InvoiceNo.DataPropertyName = "InvoiceNo";
            this.InvoiceNo.HeaderText = "发票号";
            this.InvoiceNo.Name = "InvoiceNo";
            this.InvoiceNo.ReadOnly = true;
            this.InvoiceNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.InvoiceNo.Width = 75;
            // 
            // Item_Name
            // 
            this.Item_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Item_Name.DataPropertyName = "Item_Name";
            this.Item_Name.HeaderText = "药品、项目名称";
            this.Item_Name.Name = "Item_Name";
            this.Item_Name.ReadOnly = true;
            this.Item_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Standard
            // 
            this.Standard.DataPropertyName = "Standard";
            this.Standard.HeaderText = "规格";
            this.Standard.Name = "Standard";
            this.Standard.ReadOnly = true;
            this.Standard.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Standard.Width = 120;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "#0.##0";
            this.Price.DefaultCellStyle = dataGridViewCellStyle3;
            this.Price.HeaderText = "单价";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Price.Width = 75;
            // 
            // Pack_Unit
            // 
            this.Pack_Unit.DataPropertyName = "Pack_Unit";
            this.Pack_Unit.HeaderText = "包装单位";
            this.Pack_Unit.Name = "Pack_Unit";
            this.Pack_Unit.ReadOnly = true;
            this.Pack_Unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Pack_Unit.Width = 45;
            // 
            // Pack_Num
            // 
            this.Pack_Num.DataPropertyName = "Pack_Num";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "#0";
            this.Pack_Num.DefaultCellStyle = dataGridViewCellStyle4;
            this.Pack_Num.HeaderText = "包装数";
            this.Pack_Num.Name = "Pack_Num";
            this.Pack_Num.ReadOnly = true;
            this.Pack_Num.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Pack_Num.Width = 42;
            // 
            // Base_Num
            // 
            this.Base_Num.DataPropertyName = "Base_Num";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "#0";
            this.Base_Num.DefaultCellStyle = dataGridViewCellStyle5;
            this.Base_Num.HeaderText = "基本数";
            this.Base_Num.Name = "Base_Num";
            this.Base_Num.ReadOnly = true;
            this.Base_Num.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Base_Num.Width = 42;
            // 
            // PresAmount
            // 
            this.PresAmount.DataPropertyName = "PresAmount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "#0";
            this.PresAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.PresAmount.HeaderText = "付数";
            this.PresAmount.Name = "PresAmount";
            this.PresAmount.ReadOnly = true;
            this.PresAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PresAmount.Width = 30;
            // 
            // TotalCost
            // 
            this.TotalCost.DataPropertyName = "TotalCost";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "#0.#0";
            this.TotalCost.DefaultCellStyle = dataGridViewCellStyle7;
            this.TotalCost.HeaderText = "金额";
            this.TotalCost.Name = "TotalCost";
            this.TotalCost.ReadOnly = true;
            this.TotalCost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TotalCost.Width = 80;
            // 
            // RECORD_FLAG
            // 
            this.RECORD_FLAG.DataPropertyName = "RECORD_FLAG";
            this.RECORD_FLAG.HeaderText = "收费";
            this.RECORD_FLAG.Name = "RECORD_FLAG";
            this.RECORD_FLAG.ReadOnly = true;
            this.RECORD_FLAG.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RECORD_FLAG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RECORD_FLAG.Width = 30;
            // 
            // DRUG_FLAG
            // 
            this.DRUG_FLAG.DataPropertyName = "DRUG_FLAG";
            this.DRUG_FLAG.HeaderText = "发药";
            this.DRUG_FLAG.Name = "DRUG_FLAG";
            this.DRUG_FLAG.ReadOnly = true;
            this.DRUG_FLAG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DRUG_FLAG.Width = 30;
            // 
            // FrmPrescriptionQuery
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size( 955 , 466 );
            this.Name = "FrmPrescriptionQuery";
            this.Text = "FrmPrescriptionQuery";
            this.plBaseToolbar.ResumeLayout( false );
            this.plBaseToolbar.PerformLayout( );
            this.plBaseStatus.ResumeLayout( false );
            this.plBaseStatus.PerformLayout( );
            this.plBaseWorkArea.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvPresc ) ).EndInit( );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.TextBox txtPatient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private GWI.HIS.Windows.Controls.Button btnClose;
        private GWI.HIS.Windows.Controls.Button btnQuery;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private GWI.HIS.Windows.Controls.Button btnPatient;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvPresc;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PresID;
        private System.Windows.Forms.DataGridViewTextBoxColumn VisitNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Standard;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pack_Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pack_Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Base_Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn PresAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECORD_FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn DRUG_FLAG;
    }
}