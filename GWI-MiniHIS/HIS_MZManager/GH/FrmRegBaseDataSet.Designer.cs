namespace HIS_MZManager.GH
{
    partial class FrmRegBaseDataSet
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
                components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmRegBaseDataSet ) );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle( );
            GWI.HIS.Windows.Controls.DataGridViewSelectionCard dataGridViewSelectionCard1 = new GWI.HIS.Windows.Controls.DataGridViewSelectionCard( );
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn1 = new GWI.HIS.Windows.Controls.SelectionCardColumn( );
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn2 = new GWI.HIS.Windows.Controls.SelectionCardColumn( );
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn3 = new GWI.HIS.Windows.Controls.SelectionCardColumn( );
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn4 = new GWI.HIS.Windows.Controls.SelectionCardColumn( );
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn5 = new GWI.HIS.Windows.Controls.SelectionCardColumn( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle( );
            this.lvwRegTypeDefine = new System.Windows.Forms.ListView( );
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader( );
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader( );
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader( );
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader( );
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader( );
            this.label1 = new System.Windows.Forms.Label( );
            this.txtTypeName = new GWI.HIS.Windows.Controls.QueryTextBox( );
            this.btnNewType = new GWI.HIS.Windows.Controls.Button( );
            this.button1 = new GWI.HIS.Windows.Controls.Button( );
            this.dgvItems = new GWI.HIS.Windows.Controls.DataGridViewEx( );
            this.ITEM_ID = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.CODE = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.ITEM_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.TYPE_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.tabControl1 = new System.Windows.Forms.TabControl( );
            this.tabPage1 = new System.Windows.Forms.TabPage( );
            this.btnEditType = new GWI.HIS.Windows.Controls.Button( );
            this.btnAddType = new GWI.HIS.Windows.Controls.Button( );
            this.label4 = new System.Windows.Forms.Label( );
            this.txtTypeCode = new GWI.HIS.Windows.Controls.QueryTextBox( );
            this.chkValid = new System.Windows.Forms.CheckBox( );
            this.label3 = new System.Windows.Forms.Label( );
            this.txtWB = new GWI.HIS.Windows.Controls.QueryTextBox( );
            this.label2 = new System.Windows.Forms.Label( );
            this.txtPY = new GWI.HIS.Windows.Controls.QueryTextBox( );
            this.btnRemoveItem = new GWI.HIS.Windows.Controls.Button( );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvItems ) ).BeginInit( );
            this.tabControl1.SuspendLayout( );
            this.tabPage1.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // lvwRegTypeDefine
            // 
            this.lvwRegTypeDefine.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4} );
            this.lvwRegTypeDefine.FullRowSelect = true;
            this.lvwRegTypeDefine.GridLines = true;
            this.lvwRegTypeDefine.HideSelection = false;
            this.lvwRegTypeDefine.Location = new System.Drawing.Point( 3 , 3 );
            this.lvwRegTypeDefine.Name = "lvwRegTypeDefine";
            this.lvwRegTypeDefine.Size = new System.Drawing.Size( 251 , 347 );
            this.lvwRegTypeDefine.TabIndex = 0;
            this.lvwRegTypeDefine.UseCompatibleStateImageBehavior = false;
            this.lvwRegTypeDefine.View = System.Windows.Forms.View.Details;
            this.lvwRegTypeDefine.SelectedIndexChanged += new System.EventHandler( this.lvwRegTypeDefine_SelectedIndexChanged );
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "有效";
            this.columnHeader5.Width = 44;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "类型代码";
            this.columnHeader1.Width = 67;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "类型名称";
            this.columnHeader2.Width = 151;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "拼音码";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "五笔码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label1.Location = new System.Drawing.Point( 447 , 9 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 67 , 15 );
            this.label1.TabIndex = 2;
            this.label1.Text = "类型名称";
            // 
            // txtTypeName
            // 
            this.txtTypeName.AllowSelectedNullRow = false;
            this.txtTypeName.DisplayField = "";
            this.txtTypeName.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtTypeName.Location = new System.Drawing.Point( 520 , 6 );
            this.txtTypeName.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtTypeName.MaxLength = 15;
            this.txtTypeName.MemberField = "";
            this.txtTypeName.MemberValue = null;
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.NextControl = this.btnNewType;
            this.txtTypeName.NextControlByEnter = true;
            this.txtTypeName.OffsetX = 0;
            this.txtTypeName.OffsetY = 0;
            this.txtTypeName.QueryFields = null;
            this.txtTypeName.SelectedValue = null;
            this.txtTypeName.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTypeName.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtTypeName.SelectionCardColumnHeaderHeight = 30;
            this.txtTypeName.SelectionCardColumns = null;
            this.txtTypeName.SelectionCardFont = null;
            this.txtTypeName.SelectionCardHeight = 250;
            this.txtTypeName.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtTypeName.SelectionCardRowHeaderWidth = 35;
            this.txtTypeName.SelectionCardRowHeight = 23;
            this.txtTypeName.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtTypeName.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtTypeName.SelectionCardWidth = 250;
            this.txtTypeName.ShowRowNumber = true;
            this.txtTypeName.ShowSelectionCardAfterEnter = false;
            this.txtTypeName.Size = new System.Drawing.Size( 348 , 24 );
            this.txtTypeName.TabIndex = 3;
            this.txtTypeName.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtTypeName.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtTypeName_KeyPress );
            // 
            // btnNewType
            // 
            this.btnNewType.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.OtherProcess;
            this.btnNewType.FixedWidth = false;
            this.btnNewType.Location = new System.Drawing.Point( 796 , 356 );
            this.btnNewType.Name = "btnNewType";
            this.btnNewType.Size = new System.Drawing.Size( 35 , 25 );
            this.btnNewType.TabIndex = 6;
            this.btnNewType.Text = "+";
            this.btnNewType.UseVisualStyleBackColor = true;
            this.btnNewType.Click += new System.EventHandler( this.btnNewType_Click );
            // 
            // button1
            // 
            this.button1.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.CloseWindow;
            this.button1.FixedWidth = true;
            this.button1.Image = ( (System.Drawing.Image)( resources.GetObject( "button1.Image" ) ) );
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point( 782 , 437 );
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size( 90 , 25 );
            this.button1.TabIndex = 4;
            this.button1.Text = "关闭(&X)";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler( this.button1_Click );
            // 
            // dgvItems
            // 
            this.dgvItems.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgvItems.AllowSortWhenClickColumnHeader = false;
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle1.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItems.ColumnHeadersHeight = 25;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvItems.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.ITEM_ID,
            this.CODE,
            this.ITEM_NAME,
            this.Price,
            this.TYPE_CODE} );
            this.dgvItems.EnableHeadersVisualStyles = false;
            this.dgvItems.Location = new System.Drawing.Point( 260 , 78 );
            this.dgvItems.Name = "dgvItems";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            dataGridViewCellStyle3.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvItems.RowTemplate.Height = 23;
            dataGridViewSelectionCard1.BindColumnIndex = 1;
            dataGridViewSelectionCard1.CardSize = new System.Drawing.Size( 450 , 250 );
            selectionCardColumn1.AutoFill = false;
            selectionCardColumn1.DataBindField = "ITEM_ID";
            selectionCardColumn1.HeaderText = "ITEM_ID";
            selectionCardColumn1.IsSeachColumn = false;
            selectionCardColumn1.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn1.Visiable = false;
            selectionCardColumn1.Width = 75;
            selectionCardColumn2.AutoFill = true;
            selectionCardColumn2.DataBindField = "ITEM_NAME";
            selectionCardColumn2.HeaderText = "项目名称";
            selectionCardColumn2.IsSeachColumn = true;
            selectionCardColumn2.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn2.Visiable = true;
            selectionCardColumn2.Width = 75;
            selectionCardColumn3.AutoFill = false;
            selectionCardColumn3.DataBindField = "PY_CODE";
            selectionCardColumn3.HeaderText = "PY_CODE";
            selectionCardColumn3.IsSeachColumn = true;
            selectionCardColumn3.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn3.Visiable = false;
            selectionCardColumn3.Width = 75;
            selectionCardColumn4.AutoFill = false;
            selectionCardColumn4.DataBindField = "WB_CODE";
            selectionCardColumn4.HeaderText = "WB_CODE";
            selectionCardColumn4.IsSeachColumn = false;
            selectionCardColumn4.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn4.Visiable = false;
            selectionCardColumn4.Width = 75;
            selectionCardColumn5.AutoFill = false;
            selectionCardColumn5.DataBindField = "PRICE";
            selectionCardColumn5.HeaderText = "价格";
            selectionCardColumn5.IsSeachColumn = false;
            selectionCardColumn5.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn5.Visiable = true;
            selectionCardColumn5.Width = 75;
            dataGridViewSelectionCard1.Columns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn1,
        selectionCardColumn2,
        selectionCardColumn3,
        selectionCardColumn4,
        selectionCardColumn5};
            dataGridViewSelectionCard1.CurrentPage = 0;
            dataGridViewSelectionCard1.DataObjectType = null;
            dataGridViewSelectionCard1.DataSource = null;
            dataGridViewSelectionCard1.DataSourceIsDataTable = false;
            dataGridViewSelectionCard1.FilterResult = null;
            dataGridViewSelectionCard1.OffsetX = 0;
            dataGridViewSelectionCard1.OffsetY = 0;
            dataGridViewSelectionCard1.SelectCardAlternatingRowsBackColor = System.Drawing.Color.Empty;
            dataGridViewSelectionCard1.SelectCardFilterType = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            dataGridViewSelectionCard1.SelectCardRowHeight = 23;
            dataGridViewSelectionCard1.SelectionCardBackGroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewSelectionCard1.SelectionCardFont = new System.Drawing.Font( "宋体" , 9F );
            dataGridViewSelectionCard1.SelectionCardLabelBackColor = System.Drawing.SystemColors.Control;
            dataGridViewSelectionCard1.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.Page;
            dataGridViewSelectionCard1.SelectionRowBackColor = System.Drawing.Color.Black;
            dataGridViewSelectionCard1.SpeciFilterString = null;
            dataGridViewSelectionCard1.TotalPage = 0;
            this.dgvItems.SelectionCards = new GWI.HIS.Windows.Controls.DataGridViewSelectionCard[] {
        dataGridViewSelectionCard1};
            this.dgvItems.Size = new System.Drawing.Size( 608 , 272 );
            this.dgvItems.TabIndex = 7;
            this.dgvItems.UseGradientBackgroundColor = true;
            this.dgvItems.SelectCardRowSelected += new GWI.HIS.Windows.Controls.OnSelectCardRowSelectedHandle( this.dgvItems_SelectCardRowSelected );
            // 
            // ITEM_ID
            // 
            this.ITEM_ID.DataPropertyName = "ITEM_ID";
            this.ITEM_ID.HeaderText = "项目ID";
            this.ITEM_ID.Name = "ITEM_ID";
            this.ITEM_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ITEM_ID.Visible = false;
            // 
            // CODE
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 192 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            this.CODE.DefaultCellStyle = dataGridViewCellStyle2;
            this.CODE.HeaderText = "检索码";
            this.CODE.Name = "CODE";
            this.CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CODE.Width = 50;
            // 
            // ITEM_NAME
            // 
            this.ITEM_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ITEM_NAME.DataPropertyName = "ITEM_NAME";
            this.ITEM_NAME.HeaderText = "项目名称";
            this.ITEM_NAME.Name = "ITEM_NAME";
            this.ITEM_NAME.ReadOnly = true;
            this.ITEM_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "价格";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TYPE_CODE
            // 
            this.TYPE_CODE.DataPropertyName = "TYPE_CODE";
            this.TYPE_CODE.HeaderText = "TYPE_CODE";
            this.TYPE_CODE.Name = "TYPE_CODE";
            this.TYPE_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TYPE_CODE.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Location = new System.Drawing.Point( 12 , 420 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 860 , 9 );
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add( this.tabPage1 );
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point( 0 , 0 );
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size( 883 , 419 );
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add( this.btnEditType );
            this.tabPage1.Controls.Add( this.btnAddType );
            this.tabPage1.Controls.Add( this.label4 );
            this.tabPage1.Controls.Add( this.txtTypeCode );
            this.tabPage1.Controls.Add( this.chkValid );
            this.tabPage1.Controls.Add( this.label3 );
            this.tabPage1.Controls.Add( this.txtWB );
            this.tabPage1.Controls.Add( this.label2 );
            this.tabPage1.Controls.Add( this.txtPY );
            this.tabPage1.Controls.Add( this.btnRemoveItem );
            this.tabPage1.Controls.Add( this.lvwRegTypeDefine );
            this.tabPage1.Controls.Add( this.label1 );
            this.tabPage1.Controls.Add( this.btnNewType );
            this.tabPage1.Controls.Add( this.dgvItems );
            this.tabPage1.Controls.Add( this.txtTypeName );
            this.tabPage1.Location = new System.Drawing.Point( 4 , 21 );
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage1.Size = new System.Drawing.Size( 875 , 394 );
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "挂号类型定义";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnEditType
            // 
            this.btnEditType.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.Edit;
            this.btnEditType.FixedWidth = true;
            this.btnEditType.Image = ( (System.Drawing.Image)( resources.GetObject( "btnEditType.Image" ) ) );
            this.btnEditType.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditType.Location = new System.Drawing.Point( 778 , 42 );
            this.btnEditType.Name = "btnEditType";
            this.btnEditType.Size = new System.Drawing.Size( 90 , 25 );
            this.btnEditType.TabIndex = 17;
            this.btnEditType.Text = "保存(&S)";
            this.btnEditType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditType.UseVisualStyleBackColor = true;
            this.btnEditType.Click += new System.EventHandler( this.btnEditType_Click );
            // 
            // btnAddType
            // 
            this.btnAddType.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.AddNew;
            this.btnAddType.FixedWidth = true;
            this.btnAddType.Image = ( (System.Drawing.Image)( resources.GetObject( "btnAddType.Image" ) ) );
            this.btnAddType.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddType.Location = new System.Drawing.Point( 685 , 42 );
            this.btnAddType.Name = "btnAddType";
            this.btnAddType.Size = new System.Drawing.Size( 90 , 25 );
            this.btnAddType.TabIndex = 16;
            this.btnAddType.Text = "新增(&N)";
            this.btnAddType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddType.UseVisualStyleBackColor = true;
            this.btnAddType.Click += new System.EventHandler( this.btnAddType_Click );
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label4.Location = new System.Drawing.Point( 259 , 9 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 53 , 15 );
            this.label4.TabIndex = 14;
            this.label4.Text = "代  码";
            // 
            // txtTypeCode
            // 
            this.txtTypeCode.AllowSelectedNullRow = false;
            this.txtTypeCode.DisplayField = "";
            this.txtTypeCode.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtTypeCode.Location = new System.Drawing.Point( 333 , 6 );
            this.txtTypeCode.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtTypeCode.MaxLength = 3;
            this.txtTypeCode.MemberField = "";
            this.txtTypeCode.MemberValue = null;
            this.txtTypeCode.Name = "txtTypeCode";
            this.txtTypeCode.NextControl = this.txtTypeName;
            this.txtTypeCode.NextControlByEnter = true;
            this.txtTypeCode.OffsetX = 0;
            this.txtTypeCode.OffsetY = 0;
            this.txtTypeCode.QueryFields = null;
            this.txtTypeCode.SelectedValue = null;
            this.txtTypeCode.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTypeCode.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtTypeCode.SelectionCardColumnHeaderHeight = 30;
            this.txtTypeCode.SelectionCardColumns = null;
            this.txtTypeCode.SelectionCardFont = null;
            this.txtTypeCode.SelectionCardHeight = 250;
            this.txtTypeCode.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtTypeCode.SelectionCardRowHeaderWidth = 35;
            this.txtTypeCode.SelectionCardRowHeight = 23;
            this.txtTypeCode.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtTypeCode.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtTypeCode.SelectionCardWidth = 250;
            this.txtTypeCode.ShowRowNumber = true;
            this.txtTypeCode.ShowSelectionCardAfterEnter = false;
            this.txtTypeCode.Size = new System.Drawing.Size( 108 , 24 );
            this.txtTypeCode.TabIndex = 15;
            this.txtTypeCode.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            // 
            // chkValid
            // 
            this.chkValid.AutoSize = true;
            this.chkValid.Location = new System.Drawing.Point( 634 , 46 );
            this.chkValid.Name = "chkValid";
            this.chkValid.Size = new System.Drawing.Size( 48 , 16 );
            this.chkValid.TabIndex = 13;
            this.chkValid.Text = "有效";
            this.chkValid.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label3.Location = new System.Drawing.Point( 447 , 46 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 52 , 15 );
            this.label3.TabIndex = 11;
            this.label3.Text = "五笔码";
            // 
            // txtWB
            // 
            this.txtWB.AllowSelectedNullRow = false;
            this.txtWB.DisplayField = "";
            this.txtWB.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtWB.Location = new System.Drawing.Point( 520 , 43 );
            this.txtWB.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtWB.MaxLength = 15;
            this.txtWB.MemberField = "";
            this.txtWB.MemberValue = null;
            this.txtWB.Name = "txtWB";
            this.txtWB.NextControl = null;
            this.txtWB.NextControlByEnter = false;
            this.txtWB.OffsetX = 0;
            this.txtWB.OffsetY = 0;
            this.txtWB.QueryFields = null;
            this.txtWB.SelectedValue = null;
            this.txtWB.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtWB.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtWB.SelectionCardColumnHeaderHeight = 30;
            this.txtWB.SelectionCardColumns = null;
            this.txtWB.SelectionCardFont = null;
            this.txtWB.SelectionCardHeight = 250;
            this.txtWB.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtWB.SelectionCardRowHeaderWidth = 35;
            this.txtWB.SelectionCardRowHeight = 23;
            this.txtWB.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtWB.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtWB.SelectionCardWidth = 250;
            this.txtWB.ShowRowNumber = true;
            this.txtWB.ShowSelectionCardAfterEnter = false;
            this.txtWB.Size = new System.Drawing.Size( 94 , 24 );
            this.txtWB.TabIndex = 12;
            this.txtWB.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label2.Location = new System.Drawing.Point( 260 , 46 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 52 , 15 );
            this.label2.TabIndex = 9;
            this.label2.Text = "拼音码";
            // 
            // txtPY
            // 
            this.txtPY.AllowSelectedNullRow = false;
            this.txtPY.DisplayField = "";
            this.txtPY.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtPY.Location = new System.Drawing.Point( 333 , 43 );
            this.txtPY.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtPY.MaxLength = 15;
            this.txtPY.MemberField = "";
            this.txtPY.MemberValue = null;
            this.txtPY.Name = "txtPY";
            this.txtPY.NextControl = null;
            this.txtPY.NextControlByEnter = false;
            this.txtPY.OffsetX = 0;
            this.txtPY.OffsetY = 0;
            this.txtPY.QueryFields = null;
            this.txtPY.SelectedValue = null;
            this.txtPY.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPY.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtPY.SelectionCardColumnHeaderHeight = 30;
            this.txtPY.SelectionCardColumns = null;
            this.txtPY.SelectionCardFont = null;
            this.txtPY.SelectionCardHeight = 250;
            this.txtPY.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtPY.SelectionCardRowHeaderWidth = 35;
            this.txtPY.SelectionCardRowHeight = 23;
            this.txtPY.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtPY.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtPY.SelectionCardWidth = 250;
            this.txtPY.ShowRowNumber = true;
            this.txtPY.ShowSelectionCardAfterEnter = false;
            this.txtPY.Size = new System.Drawing.Size( 108 , 24 );
            this.txtPY.TabIndex = 10;
            this.txtPY.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtPY.TextChanged += new System.EventHandler( this.queryTextBox2_TextChanged );
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.OtherProcess;
            this.btnRemoveItem.FixedWidth = false;
            this.btnRemoveItem.Location = new System.Drawing.Point( 837 , 356 );
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size( 31 , 25 );
            this.btnRemoveItem.TabIndex = 8;
            this.btnRemoveItem.Text = "-";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler( this.btnRemoveItem_Click );
            // 
            // FrmRegBaseDataSet
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size( 883 , 474 );
            this.Controls.Add( this.tabControl1 );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.button1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmRegBaseDataSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "挂号基础数据维护";
            this.Load += new System.EventHandler( this.FrmRegBaseDataSet_Load );
            ( (System.ComponentModel.ISupportInitialize)( this.dgvItems ) ).EndInit( );
            this.tabControl1.ResumeLayout( false );
            this.tabPage1.ResumeLayout( false );
            this.tabPage1.PerformLayout( );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.ListView lvwRegTypeDefine;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label1;
        private GWI.HIS.Windows.Controls.QueryTextBox txtTypeName;
        private GWI.HIS.Windows.Controls.Button button1;
        private GWI.HIS.Windows.Controls.Button btnNewType;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgvItems;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private GWI.HIS.Windows.Controls.Button btnRemoveItem;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label3;
        private GWI.HIS.Windows.Controls.QueryTextBox txtWB;
        private System.Windows.Forms.Label label2;
        private GWI.HIS.Windows.Controls.QueryTextBox txtPY;
        private System.Windows.Forms.CheckBox chkValid;
        private System.Windows.Forms.Label label4;
        private GWI.HIS.Windows.Controls.QueryTextBox txtTypeCode;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private GWI.HIS.Windows.Controls.Button btnAddType;
        private GWI.HIS.Windows.Controls.Button btnEditType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPE_CODE;

    }
}