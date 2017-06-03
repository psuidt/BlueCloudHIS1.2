namespace HIS_MZDocManager
{
    partial class UCOfenDiagnosis
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
            this.btRefreshOfenDiagnosis = new System.Windows.Forms.Button();
            this._lvwOfenDiagnosis = new GWI.HIS.Windows.Controls.ListView(this.components);
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // btRefreshOfenDiagnosis
            // 
            this.btRefreshOfenDiagnosis.Dock = System.Windows.Forms.DockStyle.Top;
            this.btRefreshOfenDiagnosis.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btRefreshOfenDiagnosis.Location = new System.Drawing.Point(0, 0);
            this.btRefreshOfenDiagnosis.Name = "btRefreshOfenDiagnosis";
            this.btRefreshOfenDiagnosis.Size = new System.Drawing.Size(160, 25);
            this.btRefreshOfenDiagnosis.TabIndex = 1;
            this.btRefreshOfenDiagnosis.Text = "刷新常用诊断";
            this.btRefreshOfenDiagnosis.UseVisualStyleBackColor = true;
            this.btRefreshOfenDiagnosis.Click += new System.EventHandler(this.btRefreshOfenDiagnosis_Click);
            // 
            // _lvwOfenDiagnosis
            // 
            this._lvwOfenDiagnosis.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this._lvwOfenDiagnosis.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lvwOfenDiagnosis.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._lvwOfenDiagnosis.FullRowSelect = true;
            this._lvwOfenDiagnosis.GridLines = true;
            this._lvwOfenDiagnosis.Location = new System.Drawing.Point(0, 25);
            this._lvwOfenDiagnosis.MultiSelect = false;
            this._lvwOfenDiagnosis.Name = "_lvwOfenDiagnosis";
            this._lvwOfenDiagnosis.Size = new System.Drawing.Size(160, 175);
            this._lvwOfenDiagnosis.TabIndex = 0;
            this._lvwOfenDiagnosis.UseCompatibleStateImageBehavior = false;
            this._lvwOfenDiagnosis.UseGradientBackgroundColor = true;
            this._lvwOfenDiagnosis.View = System.Windows.Forms.View.Details;
            this._lvwOfenDiagnosis.DoubleClick += new System.EventHandler(this._lvwOfenDiagnosis_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "编码";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "名称";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "使用频率";
            this.columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "拼音码";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "五笔码";
            this.columnHeader5.Width = 80;
            // 
            // UCOfenDiagnosis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.Controls.Add(this._lvwOfenDiagnosis);
            this.Controls.Add(this.btRefreshOfenDiagnosis);
            this.Name = "UCOfenDiagnosis";
            this.Size = new System.Drawing.Size(160, 200);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btRefreshOfenDiagnosis;
        private GWI.HIS.Windows.Controls.ListView _lvwOfenDiagnosis;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}
