namespace HIS_MZDocManager
{
    partial class UCOfenItem
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
            this._pnlItemLetter = new System.Windows.Forms.Panel();
            this._txtSearchItem = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this._cmbFilterFieldItem = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this._lvwOfenItem = new GWI.HIS.Windows.Controls.ListView(this.components);
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this._pnlItemLetter.SuspendLayout();
            this.SuspendLayout();
            // 
            // _pnlItemLetter
            // 
            this._pnlItemLetter.Controls.Add(this._txtSearchItem);
            this._pnlItemLetter.Controls.Add(this.lblSearch);
            this._pnlItemLetter.Controls.Add(this._cmbFilterFieldItem);
            this._pnlItemLetter.Controls.Add(this.lblFilter);
            this._pnlItemLetter.Dock = System.Windows.Forms.DockStyle.Top;
            this._pnlItemLetter.Location = new System.Drawing.Point(0, 0);
            this._pnlItemLetter.Name = "_pnlItemLetter";
            this._pnlItemLetter.Size = new System.Drawing.Size(160, 100);
            this._pnlItemLetter.TabIndex = 1;
            // 
            // _txtSearchItem
            // 
            this._txtSearchItem.Location = new System.Drawing.Point(70, 74);
            this._txtSearchItem.Name = "_txtSearchItem";
            this._txtSearchItem.Size = new System.Drawing.Size(85, 21);
            this._txtSearchItem.TabIndex = 7;
            this._txtSearchItem.TextChanged += new System.EventHandler(this._txtSearchItem_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.Location = new System.Drawing.Point(5, 74);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(70, 20);
            this.lblSearch.TabIndex = 6;
            this.lblSearch.Text = "查询代码：";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _cmbFilterFieldItem
            // 
            this._cmbFilterFieldItem.FormattingEnabled = true;
            this._cmbFilterFieldItem.Location = new System.Drawing.Point(70, 51);
            this._cmbFilterFieldItem.Name = "_cmbFilterFieldItem";
            this._cmbFilterFieldItem.Size = new System.Drawing.Size(85, 20);
            this._cmbFilterFieldItem.TabIndex = 5;
            this._cmbFilterFieldItem.SelectionChangeCommitted += new System.EventHandler(this._cmbFilterFieldItem_SelectionChangeCommitted);
            // 
            // lblFilter
            // 
            this.lblFilter.Location = new System.Drawing.Point(5, 52);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(70, 20);
            this.lblFilter.TabIndex = 4;
            this.lblFilter.Text = "过滤字段：";
            this.lblFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lvwOfenItem
            // 
            this._lvwOfenItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this._lvwOfenItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lvwOfenItem.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._lvwOfenItem.FullRowSelect = true;
            this._lvwOfenItem.GridLines = true;
            this._lvwOfenItem.Location = new System.Drawing.Point(0, 100);
            this._lvwOfenItem.MultiSelect = false;
            this._lvwOfenItem.Name = "_lvwOfenItem";
            this._lvwOfenItem.Size = new System.Drawing.Size(160, 100);
            this._lvwOfenItem.TabIndex = 0;
            this._lvwOfenItem.UseCompatibleStateImageBehavior = false;
            this._lvwOfenItem.UseGradientBackgroundColor = false;
            this._lvwOfenItem.View = System.Windows.Forms.View.Details;
            this._lvwOfenItem.DoubleClick += new System.EventHandler(this._lvwOfenItem_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "项目编码";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "项目名称";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "单位";
            this.columnHeader3.Width = 55;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "使用频度";
            this.columnHeader4.Width = 85;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "拼音码";
            this.columnHeader5.Width = 70;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "五笔码";
            this.columnHeader6.Width = 70;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "数字码";
            this.columnHeader7.Width = 0;
            // 
            // UCOfenItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.Controls.Add(this._lvwOfenItem);
            this.Controls.Add(this._pnlItemLetter);
            this.Name = "UCOfenItem";
            this.Size = new System.Drawing.Size(160, 200);
            this.Resize += new System.EventHandler(this.UCOfenItem_Resize);
            this._pnlItemLetter.ResumeLayout(false);
            this._pnlItemLetter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _pnlItemLetter;
        private GWI.HIS.Windows.Controls.ListView _lvwOfenItem;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox _txtSearchItem;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ComboBox _cmbFilterFieldItem;
        private System.Windows.Forms.Label lblFilter;
    }
}
