namespace HIS_BaseManager
{
    partial class UC_MZYS
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn125 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn126 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn127 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn128 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle121 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle122 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle123 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle124 = new System.Windows.Forms.DataGridViewCellStyle();
            GWI.HIS.Windows.Controls.DataGridViewSelectionCard dataGridViewSelectionCard31 = new GWI.HIS.Windows.Controls.DataGridViewSelectionCard();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn121 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn122 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn123 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn124 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txt001 = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.txt002 = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chk003 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chk008 = new System.Windows.Forms.CheckBox();
            this.txt004 = new System.Windows.Forms.TextBox();
            this.txt009 = new System.Windows.Forms.TextBox();
            this.chk006_1 = new System.Windows.Forms.RadioButton();
            this.chk006_0 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvw010 = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv005 = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.DEPT_ID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DEPTDICID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnAddMapping = new System.Windows.Forms.Button();
            this.btnRemoveMapping = new System.Windows.Forms.Button();
            this.dgv007 = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.ORDER_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRemoveOrder = new System.Windows.Forms.Button();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dtDeptOfMZBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.baseDataSet = new HIS_BaseManager.BaseDataSet();
            this.dtDeptOfYPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.baseDataSet1 = new HIS_BaseManager.BaseDataSet();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv005)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv007)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDeptOfMZBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDeptOfYPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "皮试医嘱";
            // 
            // txt001
            // 
            this.txt001.AllowSelectedNullRow = false;
            this.txt001.DisplayField = "";
            this.txt001.Location = new System.Drawing.Point(160, 8);
            this.txt001.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txt001.MemberField = "";
            this.txt001.MemberValue = null;
            this.txt001.Name = "txt001";
            this.txt001.NextControl = null;
            this.txt001.NextControlByEnter = false;
            this.txt001.OffsetX = 0;
            this.txt001.OffsetY = 0;
            this.txt001.QueryFields = new string[0];
            this.txt001.SelectedValue = null;
            this.txt001.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txt001.SelectionCardBackColor = System.Drawing.Color.White;
            this.txt001.SelectionCardColumnHeaderHeight = 30;
            this.txt001.SelectionCardColumns = new GWI.HIS.Windows.Controls.SelectionCardColumn[0];
            this.txt001.SelectionCardFont = null;
            this.txt001.SelectionCardHeight = 250;
            this.txt001.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txt001.SelectionCardRowHeaderWidth = 35;
            this.txt001.SelectionCardRowHeight = 23;
            this.txt001.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txt001.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txt001.SelectionCardWidth = 470;
            this.txt001.ShowRowNumber = true;
            this.txt001.ShowSelectionCardAfterEnter = false;
            this.txt001.Size = new System.Drawing.Size(334, 21);
            this.txt001.TabIndex = 1;
            this.txt001.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            // 
            // txt002
            // 
            this.txt002.AllowSelectedNullRow = false;
            this.txt002.DisplayField = "NAME";
            this.txt002.Location = new System.Drawing.Point(160, 35);
            this.txt002.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txt002.MemberField = "ID";
            this.txt002.MemberValue = null;
            this.txt002.Name = "txt002";
            this.txt002.NextControl = null;
            this.txt002.NextControlByEnter = false;
            this.txt002.OffsetX = 0;
            this.txt002.OffsetY = 0;
            this.txt002.QueryFields = new string[] {
        "NAME",
        "PY_CODE",
        "WB_CODE"};
            this.txt002.SelectedValue = null;
            this.txt002.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txt002.SelectionCardBackColor = System.Drawing.Color.White;
            this.txt002.SelectionCardColumnHeaderHeight = 30;
            selectionCardColumn125.AutoFill = false;
            selectionCardColumn125.DataBindField = "ID";
            selectionCardColumn125.HeaderText = "ID";
            selectionCardColumn125.IsNameField = false;
            selectionCardColumn125.IsSeachColumn = false;
            selectionCardColumn125.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn125.Visiable = false;
            selectionCardColumn125.Width = 75;
            selectionCardColumn126.AutoFill = true;
            selectionCardColumn126.DataBindField = "NAME";
            selectionCardColumn126.HeaderText = "用法名称";
            selectionCardColumn126.IsNameField = true;
            selectionCardColumn126.IsSeachColumn = true;
            selectionCardColumn126.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn126.Visiable = true;
            selectionCardColumn126.Width = 75;
            selectionCardColumn127.AutoFill = false;
            selectionCardColumn127.DataBindField = "PY_CODE";
            selectionCardColumn127.HeaderText = "拼音码";
            selectionCardColumn127.IsNameField = false;
            selectionCardColumn127.IsSeachColumn = true;
            selectionCardColumn127.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn127.Visiable = true;
            selectionCardColumn127.Width = 75;
            selectionCardColumn128.AutoFill = false;
            selectionCardColumn128.DataBindField = "WB_CODE";
            selectionCardColumn128.HeaderText = "五笔码";
            selectionCardColumn128.IsNameField = false;
            selectionCardColumn128.IsSeachColumn = true;
            selectionCardColumn128.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn128.Visiable = true;
            selectionCardColumn128.Width = 75;
            this.txt002.SelectionCardColumns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn125,
        selectionCardColumn126,
        selectionCardColumn127,
        selectionCardColumn128};
            this.txt002.SelectionCardFont = null;
            this.txt002.SelectionCardHeight = 250;
            this.txt002.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txt002.SelectionCardRowHeaderWidth = 35;
            this.txt002.SelectionCardRowHeight = 23;
            this.txt002.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txt002.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txt002.SelectionCardWidth = 470;
            this.txt002.ShowRowNumber = true;
            this.txt002.ShowSelectionCardAfterEnter = false;
            this.txt002.Size = new System.Drawing.Size(437, 21);
            this.txt002.TabIndex = 3;
            this.txt002.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txt002.AfterSelectedRow += new GWI.HIS.Windows.Controls.AfterSelectedRowHandler(this.txt002_AfterSelectedRow);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "皮试用法";
            // 
            // chk003
            // 
            this.chk003.AutoSize = true;
            this.chk003.Location = new System.Drawing.Point(31, 62);
            this.chk003.Name = "chk003";
            this.chk003.Size = new System.Drawing.Size(204, 16);
            this.chk003.TabIndex = 5;
            this.chk003.Text = "强制控制未皮试和皮试阳性的药品";
            this.chk003.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "急诊处方时间段";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "门诊科室药房对应关系";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 505);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "医技报告接口类型";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(29, 397);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 29);
            this.label9.TabIndex = 12;
            this.label9.Text = "打印费用清单时需要显示的医嘱项目分类";
            // 
            // chk008
            // 
            this.chk008.AutoSize = true;
            this.chk008.Location = new System.Drawing.Point(369, 62);
            this.chk008.Name = "chk008";
            this.chk008.Size = new System.Drawing.Size(204, 16);
            this.chk008.TabIndex = 14;
            this.chk008.Text = "门诊医生开处方时自动生成用法联";
            this.chk008.UseVisualStyleBackColor = true;
            // 
            // txt004
            // 
            this.txt004.Location = new System.Drawing.Point(160, 84);
            this.txt004.Name = "txt004";
            this.txt004.Size = new System.Drawing.Size(437, 21);
            this.txt004.TabIndex = 15;
            this.txt004.Validating += new System.ComponentModel.CancelEventHandler(this.txt004_Validating);
            // 
            // txt009
            // 
            this.txt009.Location = new System.Drawing.Point(160, 502);
            this.txt009.Name = "txt009";
            this.txt009.Size = new System.Drawing.Size(437, 21);
            this.txt009.TabIndex = 16;
            // 
            // chk006_1
            // 
            this.chk006_1.AutoSize = true;
            this.chk006_1.Location = new System.Drawing.Point(131, 11);
            this.chk006_1.Name = "chk006_1";
            this.chk006_1.Size = new System.Drawing.Size(71, 16);
            this.chk006_1.TabIndex = 17;
            this.chk006_1.TabStop = true;
            this.chk006_1.Text = "打印明细";
            this.chk006_1.UseVisualStyleBackColor = true;
            // 
            // chk006_0
            // 
            this.chk006_0.AutoSize = true;
            this.chk006_0.Location = new System.Drawing.Point(299, 11);
            this.chk006_0.Name = "chk006_0";
            this.chk006_0.Size = new System.Drawing.Size(71, 16);
            this.chk006_0.TabIndex = 18;
            this.chk006_0.TabStop = true;
            this.chk006_0.Text = "打印汇总";
            this.chk006_0.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk006_1);
            this.groupBox1.Controls.Add(this.chk006_0);
            this.groupBox1.Location = new System.Drawing.Point(31, 208);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(566, 30);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "打印非药品处方方式";
            // 
            // lvw010
            // 
            this.lvw010.CheckBoxes = true;
            this.lvw010.Location = new System.Drawing.Point(160, 397);
            this.lvw010.Name = "lvw010";
            this.lvw010.Size = new System.Drawing.Size(437, 99);
            this.lvw010.TabIndex = 20;
            this.lvw010.UseCompatibleStateImageBehavior = false;
            this.lvw010.View = System.Windows.Forms.View.List;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 526);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(599, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "【前面为PACS接口（可选项：华奕）,后面为LIS接口（可选项：华奕）,中间用逗号隔开，没有为空字符，如 ,】";
            // 
            // dgv005
            // 
            this.dgv005.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgv005.AllowSortWhenClickColumnHeader = false;
            this.dgv005.AllowUserToAddRows = false;
            this.dgv005.AllowUserToDeleteRows = false;
            dataGridViewCellStyle121.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle121.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle121.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle121.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle121.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle121.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle121.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv005.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle121;
            this.dgv005.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv005.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DEPT_ID,
            this.DEPTDICID});
            this.dgv005.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgv005.EnableHeadersVisualStyles = false;
            this.dgv005.HideSelectionCardWhenCustomInput = false;
            this.dgv005.Location = new System.Drawing.Point(160, 111);
            this.dgv005.MultiSelect = false;
            this.dgv005.Name = "dgv005";
            dataGridViewCellStyle122.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle122.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle122.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle122.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle122.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle122.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle122.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv005.RowHeadersDefaultCellStyle = dataGridViewCellStyle122;
            this.dgv005.RowTemplate.Height = 23;
            this.dgv005.SelectionCards = null;
            this.dgv005.Size = new System.Drawing.Size(408, 93);
            this.dgv005.TabIndex = 22;
            this.dgv005.UseGradientBackgroundColor = false;
            this.dgv005.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv005_DataError);
            // 
            // DEPT_ID
            // 
            this.DEPT_ID.DataPropertyName = "DEPT_ID";
            this.DEPT_ID.DataSource = this.dtDeptOfMZBindingSource;
            this.DEPT_ID.DisplayMember = "NAME";
            this.DEPT_ID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.DEPT_ID.HeaderText = "门诊科室";
            this.DEPT_ID.Name = "DEPT_ID";
            this.DEPT_ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DEPT_ID.ValueMember = "DEPT_ID";
            this.DEPT_ID.Width = 150;
            // 
            // DEPTDICID
            // 
            this.DEPTDICID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DEPTDICID.DataPropertyName = "DEPTDICID";
            this.DEPTDICID.DataSource = this.dtDeptOfYPBindingSource;
            this.DEPTDICID.DisplayMember = "DEPTNAME";
            this.DEPTDICID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.DEPTDICID.HeaderText = "药剂科室";
            this.DEPTDICID.Name = "DEPTDICID";
            this.DEPTDICID.ValueMember = "DEPTDICID";
            // 
            // btnAddMapping
            // 
            this.btnAddMapping.Location = new System.Drawing.Point(574, 120);
            this.btnAddMapping.Name = "btnAddMapping";
            this.btnAddMapping.Size = new System.Drawing.Size(23, 23);
            this.btnAddMapping.TabIndex = 23;
            this.btnAddMapping.Text = "+";
            this.btnAddMapping.UseVisualStyleBackColor = true;
            this.btnAddMapping.Click += new System.EventHandler(this.btnAddMapping_Click);
            // 
            // btnRemoveMapping
            // 
            this.btnRemoveMapping.Location = new System.Drawing.Point(574, 149);
            this.btnRemoveMapping.Name = "btnRemoveMapping";
            this.btnRemoveMapping.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveMapping.TabIndex = 24;
            this.btnRemoveMapping.Text = "-";
            this.btnRemoveMapping.UseVisualStyleBackColor = true;
            this.btnRemoveMapping.Click += new System.EventHandler(this.btnRemoveMapping_Click);
            // 
            // dgv007
            // 
            this.dgv007.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgv007.AllowSortWhenClickColumnHeader = false;
            this.dgv007.AllowUserToAddRows = false;
            this.dgv007.AllowUserToDeleteRows = false;
            dataGridViewCellStyle123.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle123.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle123.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle123.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle123.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle123.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle123.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv007.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle123;
            this.dgv007.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv007.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ORDER_ID,
            this.Column1,
            this.ORDER_NAME});
            this.dgv007.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgv007.EnableHeadersVisualStyles = false;
            this.dgv007.HideSelectionCardWhenCustomInput = false;
            this.dgv007.Location = new System.Drawing.Point(160, 244);
            this.dgv007.Name = "dgv007";
            dataGridViewCellStyle124.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle124.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle124.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle124.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle124.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle124.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle124.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv007.RowHeadersDefaultCellStyle = dataGridViewCellStyle124;
            this.dgv007.RowHeadersWidth = 20;
            this.dgv007.RowTemplate.Height = 23;
            dataGridViewSelectionCard31.BindColumnIndex = 1;
            dataGridViewSelectionCard31.CardSize = new System.Drawing.Size(440, 120);
            selectionCardColumn121.AutoFill = false;
            selectionCardColumn121.DataBindField = "ORDER_ID";
            selectionCardColumn121.HeaderText = "ORDER_ID";
            selectionCardColumn121.IsNameField = false;
            selectionCardColumn121.IsSeachColumn = false;
            selectionCardColumn121.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn121.Visiable = false;
            selectionCardColumn121.Width = 75;
            selectionCardColumn122.AutoFill = true;
            selectionCardColumn122.DataBindField = "ORDER_NAME";
            selectionCardColumn122.HeaderText = "医嘱名称";
            selectionCardColumn122.IsNameField = true;
            selectionCardColumn122.IsSeachColumn = true;
            selectionCardColumn122.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn122.Visiable = true;
            selectionCardColumn122.Width = 75;
            selectionCardColumn123.AutoFill = false;
            selectionCardColumn123.DataBindField = "PY_CODE";
            selectionCardColumn123.HeaderText = "拼音码";
            selectionCardColumn123.IsNameField = false;
            selectionCardColumn123.IsSeachColumn = true;
            selectionCardColumn123.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn123.Visiable = true;
            selectionCardColumn123.Width = 75;
            selectionCardColumn124.AutoFill = false;
            selectionCardColumn124.DataBindField = "WB_CODE";
            selectionCardColumn124.HeaderText = "五笔码";
            selectionCardColumn124.IsNameField = false;
            selectionCardColumn124.IsSeachColumn = true;
            selectionCardColumn124.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn124.Visiable = true;
            selectionCardColumn124.Width = 75;
            dataGridViewSelectionCard31.Columns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn121,
        selectionCardColumn122,
        selectionCardColumn123,
        selectionCardColumn124};
            dataGridViewSelectionCard31.CurrentPage = 0;
            dataGridViewSelectionCard31.DataObjectType = null;
            dataGridViewSelectionCard31.DataSource = null;
            dataGridViewSelectionCard31.DataSourceIsDataTable = false;
            dataGridViewSelectionCard31.FilterResult = null;
            dataGridViewSelectionCard31.OffsetX = 0;
            dataGridViewSelectionCard31.OffsetY = 0;
            dataGridViewSelectionCard31.SelectCardAlternatingRowsBackColor = System.Drawing.Color.Empty;
            dataGridViewSelectionCard31.SelectCardFilterType = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            dataGridViewSelectionCard31.SelectCardRowHeight = 25;
            dataGridViewSelectionCard31.SelectionCardBackGroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewSelectionCard31.SelectionCardFont = new System.Drawing.Font("宋体", 9F);
            dataGridViewSelectionCard31.SelectionCardLabelBackColor = System.Drawing.SystemColors.Control;
            dataGridViewSelectionCard31.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            dataGridViewSelectionCard31.SelectionRowBackColor = System.Drawing.Color.Black;
            dataGridViewSelectionCard31.SpeciFilterString = null;
            dataGridViewSelectionCard31.TotalPage = 0;
            this.dgv007.SelectionCards = new GWI.HIS.Windows.Controls.DataGridViewSelectionCard[] {
        dataGridViewSelectionCard31};
            this.dgv007.Size = new System.Drawing.Size(408, 147);
            this.dgv007.TabIndex = 26;
            this.dgv007.UseGradientBackgroundColor = false;
            this.dgv007.SelectCardRowSelected += new GWI.HIS.Windows.Controls.OnSelectCardRowSelectedHandle(this.dgv007_SelectCardRowSelected);
            // 
            // ORDER_ID
            // 
            this.ORDER_ID.DataPropertyName = "ORDER_ID";
            this.ORDER_ID.HeaderText = "ORDER_ID";
            this.ORDER_ID.Name = "ORDER_ID";
            this.ORDER_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ORDER_ID.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "检索";
            this.Column1.MaxInputLength = 10;
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 50;
            // 
            // ORDER_NAME
            // 
            this.ORDER_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ORDER_NAME.DataPropertyName = "ORDER_NAME";
            this.ORDER_NAME.HeaderText = "医嘱名称";
            this.ORDER_NAME.Name = "ORDER_NAME";
            this.ORDER_NAME.ReadOnly = true;
            this.ORDER_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 12);
            this.label6.TabIndex = 27;
            this.label6.Text = "无号时自动生成的费用";
            // 
            // btnRemoveOrder
            // 
            this.btnRemoveOrder.Location = new System.Drawing.Point(574, 274);
            this.btnRemoveOrder.Name = "btnRemoveOrder";
            this.btnRemoveOrder.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveOrder.TabIndex = 29;
            this.btnRemoveOrder.Text = "-";
            this.btnRemoveOrder.UseVisualStyleBackColor = true;
            this.btnRemoveOrder.Click += new System.EventHandler(this.btnRemoveOrder_Click);
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Location = new System.Drawing.Point(574, 245);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(23, 23);
            this.btnAddOrder.TabIndex = 28;
            this.btnAddOrder.Text = "+";
            this.btnAddOrder.UseVisualStyleBackColor = true;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(500, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(191, 12);
            this.label7.TabIndex = 30;
            this.label7.Text = "请输入医嘱项目编号，用“,”隔开";
            // 
            // dtDeptOfMZBindingSource
            // 
            this.dtDeptOfMZBindingSource.DataMember = "dtDeptOfMZ";
            this.dtDeptOfMZBindingSource.DataSource = this.baseDataSet;
            // 
            // baseDataSet
            // 
            this.baseDataSet.DataSetName = "BaseDataSet";
            this.baseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtDeptOfYPBindingSource
            // 
            this.dtDeptOfYPBindingSource.DataMember = "dtDeptOfYP";
            this.dtDeptOfYPBindingSource.DataSource = this.baseDataSet1;
            // 
            // baseDataSet1
            // 
            this.baseDataSet1.DataSetName = "BaseDataSet";
            this.baseDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // UC_MZYS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnRemoveOrder);
            this.Controls.Add(this.btnAddOrder);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgv007);
            this.Controls.Add(this.btnRemoveMapping);
            this.Controls.Add(this.btnAddMapping);
            this.Controls.Add(this.dgv005);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lvw010);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt009);
            this.Controls.Add(this.txt004);
            this.Controls.Add(this.chk008);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chk003);
            this.Controls.Add(this.txt002);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt001);
            this.Controls.Add(this.label1);
            this.Name = "UC_MZYS";
            this.Size = new System.Drawing.Size(798, 553);
            this.Load += new System.EventHandler(this.UC_MZYS_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv005)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv007)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDeptOfMZBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDeptOfYPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private GWI.HIS.Windows.Controls.QueryTextBox txt001;
        private GWI.HIS.Windows.Controls.QueryTextBox txt002;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chk003;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chk008;
        private System.Windows.Forms.TextBox txt004;
        private System.Windows.Forms.TextBox txt009;
        private System.Windows.Forms.RadioButton chk006_1;
        private System.Windows.Forms.RadioButton chk006_0;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvw010;
        private System.Windows.Forms.Label label5;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgv005;
        private System.Windows.Forms.Button btnAddMapping;
        private System.Windows.Forms.Button btnRemoveMapping;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgv007;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRemoveOrder;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.BindingSource dtDeptOfMZBindingSource;
        private BaseDataSet baseDataSet;
        private System.Windows.Forms.BindingSource dtDeptOfYPBindingSource;
        private BaseDataSet baseDataSet1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_NAME;
        private System.Windows.Forms.DataGridViewComboBoxColumn DEPT_ID;
        private System.Windows.Forms.DataGridViewComboBoxColumn DEPTDICID;
        private System.Windows.Forms.Label label7;
    }
}
