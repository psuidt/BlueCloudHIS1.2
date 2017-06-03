namespace HIS_BaseManager
{
    partial class UC_ZYHS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chk001 = new System.Windows.Forms.CheckBox();
            this.chk002 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt005 = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.txt004 = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.txt003 = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt006 = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.chk007 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rd008_1 = new System.Windows.Forms.RadioButton();
            this.rd008_0 = new System.Windows.Forms.RadioButton();
            this.btnRemoveMapping = new System.Windows.Forms.Button();
            this.btnAddMapping = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.baseDataSet = new HIS_BaseManager.BaseDataSet();
            this.dtDeptOfZYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtDeptOfYPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgv009 = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.DEPT_ID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DEPTDICID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDeptOfZYBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDeptOfYPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv009)).BeginInit();
            this.SuspendLayout();
            // 
            // chk001
            // 
            this.chk001.AutoSize = true;
            this.chk001.Location = new System.Drawing.Point(28, 11);
            this.chk001.Name = "chk001";
            this.chk001.Size = new System.Drawing.Size(144, 16);
            this.chk001.TabIndex = 0;
            this.chk001.Text = "未发药不能够定义出院";
            this.chk001.UseVisualStyleBackColor = true;
            // 
            // chk002
            // 
            this.chk002.AutoSize = true;
            this.chk002.Location = new System.Drawing.Point(28, 43);
            this.chk002.Name = "chk002";
            this.chk002.Size = new System.Drawing.Size(144, 16);
            this.chk002.TabIndex = 1;
            this.chk002.Text = "未退药不能够定义出院";
            this.chk002.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "长嘱内容每行宽度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "临嘱内容每行宽度";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "每页显示的行数";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt005);
            this.groupBox1.Controls.Add(this.txt004);
            this.groupBox1.Controls.Add(this.txt003);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(28, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 128);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "医嘱打印(注:宽度字符为汉字个数)";
            // 
            // txt005
            // 
            this.txt005.AllowSelectedNullRow = false;
            this.txt005.DisplayField = "";
            this.txt005.Location = new System.Drawing.Point(125, 89);
            this.txt005.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txt005.MaxLength = 3;
            this.txt005.MemberField = "";
            this.txt005.MemberValue = null;
            this.txt005.Name = "txt005";
            this.txt005.NextControl = null;
            this.txt005.NextControlByEnter = false;
            this.txt005.OffsetX = 0;
            this.txt005.OffsetY = 0;
            this.txt005.QueryFields = null;
            this.txt005.SelectedValue = null;
            this.txt005.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txt005.SelectionCardBackColor = System.Drawing.Color.White;
            this.txt005.SelectionCardColumnHeaderHeight = 30;
            this.txt005.SelectionCardColumns = null;
            this.txt005.SelectionCardFont = null;
            this.txt005.SelectionCardHeight = 250;
            this.txt005.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txt005.SelectionCardRowHeaderWidth = 35;
            this.txt005.SelectionCardRowHeight = 23;
            this.txt005.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txt005.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txt005.SelectionCardWidth = 250;
            this.txt005.ShowRowNumber = true;
            this.txt005.ShowSelectionCardAfterEnter = false;
            this.txt005.Size = new System.Drawing.Size(108, 21);
            this.txt005.TabIndex = 14;
            this.txt005.Text = "30";
            this.txt005.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt005.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.UInteger;
            // 
            // txt004
            // 
            this.txt004.AllowSelectedNullRow = false;
            this.txt004.DisplayField = "";
            this.txt004.Location = new System.Drawing.Point(125, 60);
            this.txt004.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txt004.MaxLength = 3;
            this.txt004.MemberField = "";
            this.txt004.MemberValue = null;
            this.txt004.Name = "txt004";
            this.txt004.NextControl = null;
            this.txt004.NextControlByEnter = false;
            this.txt004.OffsetX = 0;
            this.txt004.OffsetY = 0;
            this.txt004.QueryFields = null;
            this.txt004.SelectedValue = null;
            this.txt004.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txt004.SelectionCardBackColor = System.Drawing.Color.White;
            this.txt004.SelectionCardColumnHeaderHeight = 30;
            this.txt004.SelectionCardColumns = null;
            this.txt004.SelectionCardFont = null;
            this.txt004.SelectionCardHeight = 250;
            this.txt004.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txt004.SelectionCardRowHeaderWidth = 35;
            this.txt004.SelectionCardRowHeight = 23;
            this.txt004.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txt004.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txt004.SelectionCardWidth = 250;
            this.txt004.ShowRowNumber = true;
            this.txt004.ShowSelectionCardAfterEnter = false;
            this.txt004.Size = new System.Drawing.Size(108, 21);
            this.txt004.TabIndex = 13;
            this.txt004.Text = "20";
            this.txt004.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt004.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.UInteger;
            // 
            // txt003
            // 
            this.txt003.AllowSelectedNullRow = false;
            this.txt003.DisplayField = "";
            this.txt003.Location = new System.Drawing.Point(125, 28);
            this.txt003.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txt003.MaxLength = 3;
            this.txt003.MemberField = "";
            this.txt003.MemberValue = null;
            this.txt003.Name = "txt003";
            this.txt003.NextControl = null;
            this.txt003.NextControlByEnter = false;
            this.txt003.OffsetX = 0;
            this.txt003.OffsetY = 0;
            this.txt003.QueryFields = null;
            this.txt003.SelectedValue = null;
            this.txt003.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txt003.SelectionCardBackColor = System.Drawing.Color.White;
            this.txt003.SelectionCardColumnHeaderHeight = 30;
            this.txt003.SelectionCardColumns = null;
            this.txt003.SelectionCardFont = null;
            this.txt003.SelectionCardHeight = 250;
            this.txt003.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txt003.SelectionCardRowHeaderWidth = 35;
            this.txt003.SelectionCardRowHeight = 23;
            this.txt003.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txt003.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txt003.SelectionCardWidth = 250;
            this.txt003.ShowRowNumber = true;
            this.txt003.ShowSelectionCardAfterEnter = false;
            this.txt003.Size = new System.Drawing.Size(108, 21);
            this.txt003.TabIndex = 12;
            this.txt003.Text = "16";
            this.txt003.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt003.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.UInteger;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "允许查询最近";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(149, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "月出院的患者";
            // 
            // txt006
            // 
            this.txt006.AllowSelectedNullRow = false;
            this.txt006.DisplayField = "";
            this.txt006.Location = new System.Drawing.Point(109, 223);
            this.txt006.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txt006.MaxLength = 3;
            this.txt006.MemberField = "";
            this.txt006.MemberValue = null;
            this.txt006.Name = "txt006";
            this.txt006.NextControl = null;
            this.txt006.NextControlByEnter = false;
            this.txt006.OffsetX = 0;
            this.txt006.OffsetY = 0;
            this.txt006.QueryFields = null;
            this.txt006.SelectedValue = null;
            this.txt006.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txt006.SelectionCardBackColor = System.Drawing.Color.White;
            this.txt006.SelectionCardColumnHeaderHeight = 30;
            this.txt006.SelectionCardColumns = null;
            this.txt006.SelectionCardFont = null;
            this.txt006.SelectionCardHeight = 250;
            this.txt006.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txt006.SelectionCardRowHeaderWidth = 35;
            this.txt006.SelectionCardRowHeight = 23;
            this.txt006.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txt006.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txt006.SelectionCardWidth = 250;
            this.txt006.ShowRowNumber = true;
            this.txt006.ShowSelectionCardAfterEnter = false;
            this.txt006.Size = new System.Drawing.Size(34, 21);
            this.txt006.TabIndex = 15;
            this.txt006.Text = "30";
            this.txt006.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt006.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.UInteger;
            // 
            // chk007
            // 
            this.chk007.AutoSize = true;
            this.chk007.Location = new System.Drawing.Point(28, 261);
            this.chk007.Name = "chk007";
            this.chk007.Size = new System.Drawing.Size(84, 16);
            this.chk007.TabIndex = 16;
            this.chk007.Text = "不打印瓶签";
            this.chk007.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rd008_1);
            this.groupBox2.Controls.Add(this.rd008_0);
            this.groupBox2.Location = new System.Drawing.Point(28, 295);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(321, 43);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "明日发送药品模式";
            // 
            // rd008_1
            // 
            this.rd008_1.AutoSize = true;
            this.rd008_1.Location = new System.Drawing.Point(175, 20);
            this.rd008_1.Name = "rd008_1";
            this.rd008_1.Size = new System.Drawing.Size(119, 16);
            this.rd008_1.TabIndex = 1;
            this.rd008_1.TabStop = true;
            this.rd008_1.Text = "发送明日所有药品";
            this.rd008_1.UseVisualStyleBackColor = true;
            // 
            // rd008_0
            // 
            this.rd008_0.AutoSize = true;
            this.rd008_0.Location = new System.Drawing.Point(20, 20);
            this.rd008_0.Name = "rd008_0";
            this.rd008_0.Size = new System.Drawing.Size(119, 16);
            this.rd008_0.TabIndex = 0;
            this.rd008_0.TabStop = true;
            this.rd008_0.Text = "发送明日非口服药";
            this.rd008_0.UseVisualStyleBackColor = true;
            // 
            // btnRemoveMapping
            // 
            this.btnRemoveMapping.Location = new System.Drawing.Point(635, 394);
            this.btnRemoveMapping.Name = "btnRemoveMapping";
            this.btnRemoveMapping.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveMapping.TabIndex = 30;
            this.btnRemoveMapping.Text = "-";
            this.btnRemoveMapping.UseVisualStyleBackColor = true;
            this.btnRemoveMapping.Click += new System.EventHandler(this.btnRemoveMapping_Click);
            // 
            // btnAddMapping
            // 
            this.btnAddMapping.Location = new System.Drawing.Point(635, 365);
            this.btnAddMapping.Name = "btnAddMapping";
            this.btnAddMapping.Size = new System.Drawing.Size(23, 23);
            this.btnAddMapping.TabIndex = 29;
            this.btnAddMapping.Text = "+";
            this.btnAddMapping.UseVisualStyleBackColor = true;
            this.btnAddMapping.Click += new System.EventHandler(this.btnAddMapping_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 365);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 12);
            this.label6.TabIndex = 27;
            this.label6.Text = "护士账单录入科室药房对应关系";
            // 
            // baseDataSet
            // 
            this.baseDataSet.DataSetName = "BaseDataSet";
            this.baseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtDeptOfZYBindingSource
            // 
            this.dtDeptOfZYBindingSource.DataMember = "dtDeptOfZY";
            this.dtDeptOfZYBindingSource.DataSource = this.baseDataSet;
            // 
            // dtDeptOfYPBindingSource
            // 
            this.dtDeptOfYPBindingSource.DataMember = "dtDeptOfYP";
            this.dtDeptOfYPBindingSource.DataSource = this.baseDataSet;
            // 
            // dgv009
            // 
            this.dgv009.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgv009.AllowSortWhenClickColumnHeader = false;
            this.dgv009.AllowUserToAddRows = false;
            this.dgv009.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv009.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv009.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv009.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DEPT_ID,
            this.DEPTDICID});
            this.dgv009.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgv009.EnableHeadersVisualStyles = false;
            this.dgv009.HideSelectionCardWhenCustomInput = false;
            this.dgv009.Location = new System.Drawing.Point(205, 356);
            this.dgv009.MultiSelect = false;
            this.dgv009.Name = "dgv009";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv009.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv009.RowTemplate.Height = 23;
            this.dgv009.SelectionCards = null;
            this.dgv009.Size = new System.Drawing.Size(408, 107);
            this.dgv009.TabIndex = 31;
            this.dgv009.UseGradientBackgroundColor = false;
            // 
            // DEPT_ID
            // 
            this.DEPT_ID.DataPropertyName = "DEPT_ID";
            this.DEPT_ID.DataSource = this.dtDeptOfZYBindingSource;
            this.DEPT_ID.DisplayMember = "NAME";
            this.DEPT_ID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.DEPT_ID.HeaderText = "住院科室";
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
            // UC_ZYHS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv009);
            this.Controls.Add(this.btnRemoveMapping);
            this.Controls.Add(this.btnAddMapping);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chk007);
            this.Controls.Add(this.txt006);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chk002);
            this.Controls.Add(this.chk001);
            this.Name = "UC_ZYHS";
            this.Size = new System.Drawing.Size(716, 536);
            this.Load += new System.EventHandler(this.UC_ZYHS_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDeptOfZYBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDeptOfYPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv009)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk001;
        private System.Windows.Forms.CheckBox chk002;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private GWI.HIS.Windows.Controls.QueryTextBox txt005;
        private GWI.HIS.Windows.Controls.QueryTextBox txt004;
        private GWI.HIS.Windows.Controls.QueryTextBox txt003;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private GWI.HIS.Windows.Controls.QueryTextBox txt006;
        private System.Windows.Forms.CheckBox chk007;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rd008_1;
        private System.Windows.Forms.RadioButton rd008_0;
        private System.Windows.Forms.Button btnRemoveMapping;
        private System.Windows.Forms.Button btnAddMapping;
        private System.Windows.Forms.Label label6;
        private BaseDataSet baseDataSet;
        private System.Windows.Forms.BindingSource dtDeptOfZYBindingSource;
        private System.Windows.Forms.BindingSource dtDeptOfYPBindingSource;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgv009;
        private System.Windows.Forms.DataGridViewComboBoxColumn DEPT_ID;
        private System.Windows.Forms.DataGridViewComboBoxColumn DEPTDICID;
    }
}
