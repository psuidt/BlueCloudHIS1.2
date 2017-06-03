using HIS.ZY_BLL.DataModel;
namespace HIS_ZYManager
{
    partial class FrmSearchPat
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
            this.tb_search = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_patinfo = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.patIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cureNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patSexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pYMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wBMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.familyCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mediCardDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cureNumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patBriDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patGroupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patTELDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patCaseNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pATJOBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCCOUNTTYPEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_patinfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_search
            // 
            this.tb_search.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_search.Location = new System.Drawing.Point(190, 10);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(262, 23);
            this.tb_search.TabIndex = 0;
            this.tb_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_search_KeyDown);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "医疗卡号",
            "身份证号",
            "家庭编码",
            "患者姓名",
            "住院编号"});
            this.comboBox1.Location = new System.Drawing.Point(44, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "选择";
            // 
            // btSearch
            // 
            this.btSearch.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSearch.Location = new System.Drawing.Point(478, 9);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(75, 24);
            this.btSearch.TabIndex = 3;
            this.btSearch.Text = "选择(&X)";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btSearch);
            this.panel1.Controls.Add(this.tb_search);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 43);
            this.panel1.TabIndex = 4;
            // 
            // dgv_patinfo
            // 
            this.dgv_patinfo.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dgv_patinfo.AllowSortWhenClickColumnHeader = false;
            this.dgv_patinfo.AllowUserToAddRows = false;
            this.dgv_patinfo.AllowUserToDeleteRows = false;
            this.dgv_patinfo.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_patinfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_patinfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_patinfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patIDDataGridViewTextBoxColumn,
            this.patCodeDataGridViewTextBoxColumn,
            this.cureNoDataGridViewTextBoxColumn,
            this.patNameDataGridViewTextBoxColumn,
            this.patSexDataGridViewTextBoxColumn,
            this.pYMDataGridViewTextBoxColumn,
            this.wBMDataGridViewTextBoxColumn,
            this.familyCodeDataGridViewTextBoxColumn,
            this.mediCardDataGridViewTextBoxColumn,
            this.cureNumDataGridViewTextBoxColumn,
            this.patNumberDataGridViewTextBoxColumn,
            this.patBriDateDataGridViewTextBoxColumn,
            this.patGroupDataGridViewTextBoxColumn,
            this.patTELDataGridViewTextBoxColumn,
            this.patAddressDataGridViewTextBoxColumn,
            this.patCaseNoDataGridViewTextBoxColumn,
            this.pATJOBDataGridViewTextBoxColumn,
            this.aCCOUNTTYPEDataGridViewTextBoxColumn});
            this.dgv_patinfo.DisplayAllItemWhenSelectionCardShowing = false;
            this.dgv_patinfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_patinfo.EnableHeadersVisualStyles = false;
            this.dgv_patinfo.HideSelectionCardWhenCustomInput = false;
            this.dgv_patinfo.Location = new System.Drawing.Point(0, 43);
            this.dgv_patinfo.MultiSelect = false;
            this.dgv_patinfo.Name = "dgv_patinfo";
            this.dgv_patinfo.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_patinfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_patinfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_patinfo.RowTemplate.Height = 23;
            this.dgv_patinfo.SelectionCards = null;
            this.dgv_patinfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_patinfo.Size = new System.Drawing.Size(602, 301);
            this.dgv_patinfo.TabIndex = 5;
            this.dgv_patinfo.UseGradientBackgroundColor = true;
            // 
            // patIDDataGridViewTextBoxColumn
            // 
            this.patIDDataGridViewTextBoxColumn.DataPropertyName = "PatID";
            this.patIDDataGridViewTextBoxColumn.HeaderText = "PatID";
            this.patIDDataGridViewTextBoxColumn.Name = "patIDDataGridViewTextBoxColumn";
            this.patIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.patIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.patIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // patCodeDataGridViewTextBoxColumn
            // 
            this.patCodeDataGridViewTextBoxColumn.DataPropertyName = "PatCode";
            this.patCodeDataGridViewTextBoxColumn.HeaderText = "PatCode";
            this.patCodeDataGridViewTextBoxColumn.Name = "patCodeDataGridViewTextBoxColumn";
            this.patCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.patCodeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.patCodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // cureNoDataGridViewTextBoxColumn
            // 
            this.cureNoDataGridViewTextBoxColumn.DataPropertyName = "CureNo";
            this.cureNoDataGridViewTextBoxColumn.HeaderText = "住院号";
            this.cureNoDataGridViewTextBoxColumn.Name = "cureNoDataGridViewTextBoxColumn";
            this.cureNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cureNoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // patNameDataGridViewTextBoxColumn
            // 
            this.patNameDataGridViewTextBoxColumn.DataPropertyName = "PatName";
            this.patNameDataGridViewTextBoxColumn.HeaderText = "病人姓名";
            this.patNameDataGridViewTextBoxColumn.Name = "patNameDataGridViewTextBoxColumn";
            this.patNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.patNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // patSexDataGridViewTextBoxColumn
            // 
            this.patSexDataGridViewTextBoxColumn.DataPropertyName = "PatSex";
            this.patSexDataGridViewTextBoxColumn.HeaderText = "性别";
            this.patSexDataGridViewTextBoxColumn.Name = "patSexDataGridViewTextBoxColumn";
            this.patSexDataGridViewTextBoxColumn.ReadOnly = true;
            this.patSexDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.patSexDataGridViewTextBoxColumn.Width = 60;
            // 
            // pYMDataGridViewTextBoxColumn
            // 
            this.pYMDataGridViewTextBoxColumn.DataPropertyName = "PYM";
            this.pYMDataGridViewTextBoxColumn.HeaderText = "PYM";
            this.pYMDataGridViewTextBoxColumn.Name = "pYMDataGridViewTextBoxColumn";
            this.pYMDataGridViewTextBoxColumn.ReadOnly = true;
            this.pYMDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pYMDataGridViewTextBoxColumn.Visible = false;
            // 
            // wBMDataGridViewTextBoxColumn
            // 
            this.wBMDataGridViewTextBoxColumn.DataPropertyName = "WBM";
            this.wBMDataGridViewTextBoxColumn.HeaderText = "WBM";
            this.wBMDataGridViewTextBoxColumn.Name = "wBMDataGridViewTextBoxColumn";
            this.wBMDataGridViewTextBoxColumn.ReadOnly = true;
            this.wBMDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.wBMDataGridViewTextBoxColumn.Visible = false;
            // 
            // familyCodeDataGridViewTextBoxColumn
            // 
            this.familyCodeDataGridViewTextBoxColumn.DataPropertyName = "FamilyCode";
            this.familyCodeDataGridViewTextBoxColumn.HeaderText = "家庭编码";
            this.familyCodeDataGridViewTextBoxColumn.Name = "familyCodeDataGridViewTextBoxColumn";
            this.familyCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.familyCodeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // mediCardDataGridViewTextBoxColumn
            // 
            this.mediCardDataGridViewTextBoxColumn.DataPropertyName = "MediCard";
            this.mediCardDataGridViewTextBoxColumn.HeaderText = "医疗卡号";
            this.mediCardDataGridViewTextBoxColumn.Name = "mediCardDataGridViewTextBoxColumn";
            this.mediCardDataGridViewTextBoxColumn.ReadOnly = true;
            this.mediCardDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cureNumDataGridViewTextBoxColumn
            // 
            this.cureNumDataGridViewTextBoxColumn.DataPropertyName = "CureNum";
            this.cureNumDataGridViewTextBoxColumn.HeaderText = "CureNum";
            this.cureNumDataGridViewTextBoxColumn.Name = "cureNumDataGridViewTextBoxColumn";
            this.cureNumDataGridViewTextBoxColumn.ReadOnly = true;
            this.cureNumDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cureNumDataGridViewTextBoxColumn.Visible = false;
            // 
            // patNumberDataGridViewTextBoxColumn
            // 
            this.patNumberDataGridViewTextBoxColumn.DataPropertyName = "PatNumber";
            this.patNumberDataGridViewTextBoxColumn.HeaderText = "身份证号";
            this.patNumberDataGridViewTextBoxColumn.Name = "patNumberDataGridViewTextBoxColumn";
            this.patNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.patNumberDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // patBriDateDataGridViewTextBoxColumn
            // 
            this.patBriDateDataGridViewTextBoxColumn.DataPropertyName = "PatBriDate";
            this.patBriDateDataGridViewTextBoxColumn.HeaderText = "出生日期";
            this.patBriDateDataGridViewTextBoxColumn.Name = "patBriDateDataGridViewTextBoxColumn";
            this.patBriDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.patBriDateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // patGroupDataGridViewTextBoxColumn
            // 
            this.patGroupDataGridViewTextBoxColumn.DataPropertyName = "PatGroup";
            this.patGroupDataGridViewTextBoxColumn.HeaderText = "PatGroup";
            this.patGroupDataGridViewTextBoxColumn.Name = "patGroupDataGridViewTextBoxColumn";
            this.patGroupDataGridViewTextBoxColumn.ReadOnly = true;
            this.patGroupDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.patGroupDataGridViewTextBoxColumn.Visible = false;
            // 
            // patTELDataGridViewTextBoxColumn
            // 
            this.patTELDataGridViewTextBoxColumn.DataPropertyName = "PatTEL";
            this.patTELDataGridViewTextBoxColumn.HeaderText = "PatTEL";
            this.patTELDataGridViewTextBoxColumn.Name = "patTELDataGridViewTextBoxColumn";
            this.patTELDataGridViewTextBoxColumn.ReadOnly = true;
            this.patTELDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.patTELDataGridViewTextBoxColumn.Visible = false;
            // 
            // patAddressDataGridViewTextBoxColumn
            // 
            this.patAddressDataGridViewTextBoxColumn.DataPropertyName = "PatAddress";
            this.patAddressDataGridViewTextBoxColumn.HeaderText = "PatAddress";
            this.patAddressDataGridViewTextBoxColumn.Name = "patAddressDataGridViewTextBoxColumn";
            this.patAddressDataGridViewTextBoxColumn.ReadOnly = true;
            this.patAddressDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.patAddressDataGridViewTextBoxColumn.Visible = false;
            // 
            // patCaseNoDataGridViewTextBoxColumn
            // 
            this.patCaseNoDataGridViewTextBoxColumn.DataPropertyName = "PatCaseNo";
            this.patCaseNoDataGridViewTextBoxColumn.HeaderText = "PatCaseNo";
            this.patCaseNoDataGridViewTextBoxColumn.Name = "patCaseNoDataGridViewTextBoxColumn";
            this.patCaseNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.patCaseNoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.patCaseNoDataGridViewTextBoxColumn.Visible = false;
            // 
            // pATJOBDataGridViewTextBoxColumn
            // 
            this.pATJOBDataGridViewTextBoxColumn.DataPropertyName = "PATJOB";
            this.pATJOBDataGridViewTextBoxColumn.HeaderText = "PATJOB";
            this.pATJOBDataGridViewTextBoxColumn.Name = "pATJOBDataGridViewTextBoxColumn";
            this.pATJOBDataGridViewTextBoxColumn.ReadOnly = true;
            this.pATJOBDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pATJOBDataGridViewTextBoxColumn.Visible = false;
            // 
            // aCCOUNTTYPEDataGridViewTextBoxColumn
            // 
            this.aCCOUNTTYPEDataGridViewTextBoxColumn.DataPropertyName = "ACCOUNTTYPE";
            this.aCCOUNTTYPEDataGridViewTextBoxColumn.HeaderText = "ACCOUNTTYPE";
            this.aCCOUNTTYPEDataGridViewTextBoxColumn.Name = "aCCOUNTTYPEDataGridViewTextBoxColumn";
            this.aCCOUNTTYPEDataGridViewTextBoxColumn.ReadOnly = true;
            this.aCCOUNTTYPEDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.aCCOUNTTYPEDataGridViewTextBoxColumn.Visible = false;
            // 
            // patientInfoBindingSource
            // 
            this.patientInfoBindingSource.DataSource = typeof(HIS.ZY_BLL.DataModel.PatientInfo);
            // 
            // FrmSearchPat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 344);
            this.Controls.Add(this.dgv_patinfo);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmSearchPat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关联新农合病人";
            this.Load += new System.EventHandler(this.FrmSearchPat_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_patinfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.Panel panel1;
        private GWI.HIS.Windows.Controls.DataGridViewEx dgv_patinfo;
        private System.Windows.Forms.BindingSource patientInfoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn patIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cureNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patSexDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pYMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wBMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn familyCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mediCardDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cureNumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patBriDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patGroupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patTELDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patCaseNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pATJOBDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aCCOUNTTYPEDataGridViewTextBoxColumn;


    }
}