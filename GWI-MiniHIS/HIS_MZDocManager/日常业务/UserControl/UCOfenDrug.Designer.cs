namespace HIS_MZDocManager
{
    partial class UCOfenDrug
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._pnlDrugLetter = new System.Windows.Forms.Panel();
            this._txtSearchDrug = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this._cmbFilterFieldDrug = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this._lvwOfenDrug = new GWI.HIS.Windows.Controls.ListView(this.components);
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this._pnlDrugLetter.SuspendLayout();
            this.SuspendLayout();
            // 
            // _pnlDrugLetter
            // 
            this._pnlDrugLetter.Controls.Add(this._txtSearchDrug);
            this._pnlDrugLetter.Controls.Add(this.lblSearch);
            this._pnlDrugLetter.Controls.Add(this._cmbFilterFieldDrug);
            this._pnlDrugLetter.Controls.Add(this.lblFilter);
            this._pnlDrugLetter.Dock = System.Windows.Forms.DockStyle.Top;
            this._pnlDrugLetter.Location = new System.Drawing.Point(0, 0);
            this._pnlDrugLetter.Name = "_pnlDrugLetter";
            this._pnlDrugLetter.Size = new System.Drawing.Size(160, 107);
            this._pnlDrugLetter.TabIndex = 1;
            // 
            // _txtSearchDrug
            // 
            this._txtSearchDrug.Location = new System.Drawing.Point(69, 85);
            this._txtSearchDrug.Name = "_txtSearchDrug";
            this._txtSearchDrug.Size = new System.Drawing.Size(85, 21);
            this._txtSearchDrug.TabIndex = 3;
            this._txtSearchDrug.TextChanged += new System.EventHandler(this._txtSearchDrug_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.Location = new System.Drawing.Point(5, 85);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(70, 20);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "查询代码：";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _cmbFilterFieldDrug
            // 
            this._cmbFilterFieldDrug.FormattingEnabled = true;
            this._cmbFilterFieldDrug.Location = new System.Drawing.Point(69, 62);
            this._cmbFilterFieldDrug.Name = "_cmbFilterFieldDrug";
            this._cmbFilterFieldDrug.Size = new System.Drawing.Size(85, 20);
            this._cmbFilterFieldDrug.TabIndex = 1;
            this._cmbFilterFieldDrug.SelectionChangeCommitted += new System.EventHandler(this._cmbFilterFieldDrug_SelectionChangeCommitted);
            // 
            // lblFilter
            // 
            this.lblFilter.Location = new System.Drawing.Point(5, 63);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(70, 20);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "过滤字段：";
            this.lblFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lvwOfenDrug
            // 
            this._lvwOfenDrug.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader3,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this._lvwOfenDrug.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lvwOfenDrug.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._lvwOfenDrug.FullRowSelect = true;
            this._lvwOfenDrug.GridLines = true;
            this._lvwOfenDrug.Location = new System.Drawing.Point(0, 107);
            this._lvwOfenDrug.MultiSelect = false;
            this._lvwOfenDrug.Name = "_lvwOfenDrug";
            this._lvwOfenDrug.Size = new System.Drawing.Size(160, 93);
            this._lvwOfenDrug.TabIndex = 0;
            this._lvwOfenDrug.UseCompatibleStateImageBehavior = false;
            this._lvwOfenDrug.UseGradientBackgroundColor = false;
            this._lvwOfenDrug.View = System.Windows.Forms.View.Details;
            this._lvwOfenDrug.DoubleClick += new System.EventHandler(this._lvwOfenDrug_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "项目编码";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "药品名称";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "规格";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "单位";
            this.columnHeader5.Width = 55;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "使用频度";
            this.columnHeader3.Width = 85;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "生产厂家";
            this.columnHeader6.Width = 150;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "拼音码";
            this.columnHeader7.Width = 0;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "五笔码";
            this.columnHeader8.Width = 0;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "数字码";
            this.columnHeader9.Width = 0;
            // 
            // UCOfenDrug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.Controls.Add(this._lvwOfenDrug);
            this.Controls.Add(this._pnlDrugLetter);
            this.Name = "UCOfenDrug";
            this.Size = new System.Drawing.Size(160, 200);
            this.Resize += new System.EventHandler(this.UCOfenDrug_Resize);
            this._pnlDrugLetter.ResumeLayout(false);
            this._pnlDrugLetter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _pnlDrugLetter;
        private GWI.HIS.Windows.Controls.ListView _lvwOfenDrug;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox _cmbFilterFieldDrug;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox _txtSearchDrug;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}
