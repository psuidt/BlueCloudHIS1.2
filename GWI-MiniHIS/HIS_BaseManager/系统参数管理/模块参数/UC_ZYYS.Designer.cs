namespace HIS_BaseManager
{
    partial class UC_ZYYS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chk001 = new System.Windows.Forms.CheckBox();
            this.chk002 = new System.Windows.Forms.CheckBox();
            this.chk003 = new System.Windows.Forms.CheckBox();
            this.chk005 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgv004 = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.DEPT_ID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dtDeptOfZYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.baseDataSet = new HIS_BaseManager.BaseDataSet();
            this.DEPTDICID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dtDeptOfYPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRemoveMapping = new System.Windows.Forms.Button();
            this.btnAddMapping = new System.Windows.Forms.Button();
            this.chk006 = new System.Windows.Forms.CheckBox();
            this.chk007 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv004)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDeptOfZYBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDeptOfYPBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // chk001
            // 
            this.chk001.AutoSize = true;
            this.chk001.Location = new System.Drawing.Point(28, 11);
            this.chk001.Name = "chk001";
            this.chk001.Size = new System.Drawing.Size(168, 16);
            this.chk001.TabIndex = 0;
            this.chk001.Text = "开医嘱时不能开零库存药品";
            this.chk001.UseVisualStyleBackColor = true;
            // 
            // chk002
            // 
            this.chk002.AutoSize = true;
            this.chk002.Location = new System.Drawing.Point(28, 39);
            this.chk002.Name = "chk002";
            this.chk002.Size = new System.Drawing.Size(120, 16);
            this.chk002.TabIndex = 1;
            this.chk002.Text = "开启PASC接口功能";
            this.chk002.UseVisualStyleBackColor = true;
            // 
            // chk003
            // 
            this.chk003.AutoSize = true;
            this.chk003.Location = new System.Drawing.Point(28, 67);
            this.chk003.Name = "chk003";
            this.chk003.Size = new System.Drawing.Size(114, 16);
            this.chk003.TabIndex = 2;
            this.chk003.Text = "开启LIS接口功能";
            this.chk003.UseVisualStyleBackColor = true;
            // 
            // chk005
            // 
            this.chk005.AutoSize = true;
            this.chk005.Location = new System.Drawing.Point(28, 95);
            this.chk005.Name = "chk005";
            this.chk005.Size = new System.Drawing.Size(180, 16);
            this.chk005.TabIndex = 3;
            this.chk005.Text = "长期医嘱中允许开精神类药品";
            this.chk005.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "住院科室药房对应关系";
            // 
            // dgv004
            // 
            this.dgv004.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgv004.AllowSortWhenClickColumnHeader = false;
            this.dgv004.AllowUserToAddRows = false;
            this.dgv004.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv004.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv004.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv004.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DEPT_ID,
            this.DEPTDICID});
            this.dgv004.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgv004.EnableHeadersVisualStyles = false;
            this.dgv004.HideSelectionCardWhenCustomInput = false;
            this.dgv004.Location = new System.Drawing.Point(153, 126);
            this.dgv004.MultiSelect = false;
            this.dgv004.Name = "dgv004";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv004.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv004.RowTemplate.Height = 23;
            this.dgv004.SelectionCards = null;
            this.dgv004.Size = new System.Drawing.Size(408, 107);
            this.dgv004.TabIndex = 23;
            this.dgv004.UseGradientBackgroundColor = false;
            this.dgv004.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv004_DataError);
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
            // dtDeptOfZYBindingSource
            // 
            this.dtDeptOfZYBindingSource.DataMember = "dtDeptOfZY";
            this.dtDeptOfZYBindingSource.DataSource = this.baseDataSet;
            // 
            // baseDataSet
            // 
            this.baseDataSet.DataSetName = "BaseDataSet";
            this.baseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // dtDeptOfYPBindingSource
            // 
            this.dtDeptOfYPBindingSource.DataMember = "dtDeptOfYP";
            this.dtDeptOfYPBindingSource.DataSource = this.baseDataSet;
            // 
            // btnRemoveMapping
            // 
            this.btnRemoveMapping.Location = new System.Drawing.Point(567, 155);
            this.btnRemoveMapping.Name = "btnRemoveMapping";
            this.btnRemoveMapping.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveMapping.TabIndex = 26;
            this.btnRemoveMapping.Text = "-";
            this.btnRemoveMapping.UseVisualStyleBackColor = true;
            this.btnRemoveMapping.Click += new System.EventHandler(this.btnRemoveMapping_Click);
            // 
            // btnAddMapping
            // 
            this.btnAddMapping.Location = new System.Drawing.Point(567, 126);
            this.btnAddMapping.Name = "btnAddMapping";
            this.btnAddMapping.Size = new System.Drawing.Size(23, 23);
            this.btnAddMapping.TabIndex = 25;
            this.btnAddMapping.Text = "+";
            this.btnAddMapping.UseVisualStyleBackColor = true;
            this.btnAddMapping.Click += new System.EventHandler(this.btnAddMapping_Click);
            // 
            // chk006
            // 
            this.chk006.AutoSize = true;
            this.chk006.Location = new System.Drawing.Point(28, 244);
            this.chk006.Name = "chk006";
            this.chk006.Size = new System.Drawing.Size(132, 16);
            this.chk006.TabIndex = 27;
            this.chk006.Text = "医院上医技确费系统";
            this.chk006.UseVisualStyleBackColor = true;
            // 
            // chk007
            // 
            this.chk007.AutoSize = true;
            this.chk007.Location = new System.Drawing.Point(28, 274);
            this.chk007.Name = "chk007";
            this.chk007.Size = new System.Drawing.Size(192, 16);
            this.chk007.TabIndex = 28;
            this.chk007.Text = "医技确费是否按项目执行科室确";
            this.chk007.UseVisualStyleBackColor = true;
            // 
            // UC_ZYYS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chk007);
            this.Controls.Add(this.chk006);
            this.Controls.Add(this.btnRemoveMapping);
            this.Controls.Add(this.btnAddMapping);
            this.Controls.Add(this.dgv004);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chk005);
            this.Controls.Add(this.chk003);
            this.Controls.Add(this.chk002);
            this.Controls.Add(this.chk001);
            this.Name = "UC_ZYYS";
            this.Size = new System.Drawing.Size(648, 402);
            this.Load += new System.EventHandler(this.UC_ZYYS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv004)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDeptOfZYBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDeptOfYPBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk001;
        private System.Windows.Forms.CheckBox chk002;
        private System.Windows.Forms.CheckBox chk003;
        private System.Windows.Forms.CheckBox chk005;
        private System.Windows.Forms.Label label4;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgv004;
        private System.Windows.Forms.Button btnRemoveMapping;
        private System.Windows.Forms.Button btnAddMapping;
        private System.Windows.Forms.CheckBox chk006;
        private BaseDataSet baseDataSet;
        private System.Windows.Forms.BindingSource dtDeptOfZYBindingSource;
        private System.Windows.Forms.BindingSource dtDeptOfYPBindingSource;
        private System.Windows.Forms.DataGridViewComboBoxColumn DEPT_ID;
        private System.Windows.Forms.DataGridViewComboBoxColumn DEPTDICID;
        private System.Windows.Forms.CheckBox chk007;
    }
}
