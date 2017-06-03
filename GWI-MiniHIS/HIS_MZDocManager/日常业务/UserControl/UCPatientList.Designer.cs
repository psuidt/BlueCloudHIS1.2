namespace HIS_MZDocManager
{
    partial class UCPatientList
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
            this._dtpBegin = new System.Windows.Forms.DateTimePicker();
            this._dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this._rdbFinishPatient = new System.Windows.Forms.RadioButton();
            this._rdbWaitPatient = new System.Windows.Forms.RadioButton();
            this.pnlPatient = new System.Windows.Forms.Panel();
            this._rdbAllPatient = new System.Windows.Forms.RadioButton();
            this._rdbDocPatient = new System.Windows.Forms.RadioButton();
            this._btRefreshPatient = new System.Windows.Forms.Button();
            this._lvwPatientList = new GWI.HIS.Windows.Controls.ListView(this.components);
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.pnlStatus.SuspendLayout();
            this.pnlPatient.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dtpBegin
            // 
            this._dtpBegin.Dock = System.Windows.Forms.DockStyle.Top;
            this._dtpBegin.Location = new System.Drawing.Point(0, 0);
            this._dtpBegin.Name = "_dtpBegin";
            this._dtpBegin.Size = new System.Drawing.Size(160, 21);
            this._dtpBegin.TabIndex = 1;
            // 
            // _dtpEnd
            // 
            this._dtpEnd.Dock = System.Windows.Forms.DockStyle.Top;
            this._dtpEnd.Location = new System.Drawing.Point(0, 21);
            this._dtpEnd.Name = "_dtpEnd";
            this._dtpEnd.Size = new System.Drawing.Size(160, 21);
            this._dtpEnd.TabIndex = 2;
            // 
            // pnlStatus
            // 
            this.pnlStatus.Controls.Add(this._rdbFinishPatient);
            this.pnlStatus.Controls.Add(this._rdbWaitPatient);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatus.Location = new System.Drawing.Point(0, 42);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(160, 23);
            this.pnlStatus.TabIndex = 2;
            // 
            // _rdbFinishPatient
            // 
            this._rdbFinishPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rdbFinishPatient.Location = new System.Drawing.Point(79, 0);
            this._rdbFinishPatient.Name = "_rdbFinishPatient";
            this._rdbFinishPatient.Size = new System.Drawing.Size(81, 23);
            this._rdbFinishPatient.TabIndex = 1;
            this._rdbFinishPatient.Text = "已诊状态";
            this._rdbFinishPatient.UseVisualStyleBackColor = true;
            // 
            // _rdbWaitPatient
            // 
            this._rdbWaitPatient.Checked = true;
            this._rdbWaitPatient.Dock = System.Windows.Forms.DockStyle.Left;
            this._rdbWaitPatient.Location = new System.Drawing.Point(0, 0);
            this._rdbWaitPatient.Name = "_rdbWaitPatient";
            this._rdbWaitPatient.Size = new System.Drawing.Size(79, 23);
            this._rdbWaitPatient.TabIndex = 0;
            this._rdbWaitPatient.TabStop = true;
            this._rdbWaitPatient.Text = "候诊状态";
            this._rdbWaitPatient.UseVisualStyleBackColor = true;
            this._rdbWaitPatient.CheckedChanged += new System.EventHandler(this._btRefreshPatient_Click);
            // 
            // pnlPatient
            // 
            this.pnlPatient.Controls.Add(this._rdbAllPatient);
            this.pnlPatient.Controls.Add(this._rdbDocPatient);
            this.pnlPatient.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPatient.Location = new System.Drawing.Point(0, 65);
            this.pnlPatient.Name = "pnlPatient";
            this.pnlPatient.Size = new System.Drawing.Size(160, 24);
            this.pnlPatient.TabIndex = 3;
            // 
            // _rdbAllPatient
            // 
            this._rdbAllPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rdbAllPatient.Location = new System.Drawing.Point(79, 0);
            this._rdbAllPatient.Name = "_rdbAllPatient";
            this._rdbAllPatient.Size = new System.Drawing.Size(81, 24);
            this._rdbAllPatient.TabIndex = 1;
            this._rdbAllPatient.Text = "所有病人";
            this._rdbAllPatient.UseVisualStyleBackColor = true;
            // 
            // _rdbDocPatient
            // 
            this._rdbDocPatient.Checked = true;
            this._rdbDocPatient.Dock = System.Windows.Forms.DockStyle.Left;
            this._rdbDocPatient.Location = new System.Drawing.Point(0, 0);
            this._rdbDocPatient.Name = "_rdbDocPatient";
            this._rdbDocPatient.Size = new System.Drawing.Size(79, 24);
            this._rdbDocPatient.TabIndex = 0;
            this._rdbDocPatient.TabStop = true;
            this._rdbDocPatient.Text = "我的病人";
            this._rdbDocPatient.UseVisualStyleBackColor = true;
            this._rdbDocPatient.CheckedChanged += new System.EventHandler(this._btRefreshPatient_Click);
            // 
            // _btRefreshPatient
            // 
            this._btRefreshPatient.Dock = System.Windows.Forms.DockStyle.Top;
            this._btRefreshPatient.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._btRefreshPatient.Location = new System.Drawing.Point(0, 89);
            this._btRefreshPatient.Name = "_btRefreshPatient";
            this._btRefreshPatient.Size = new System.Drawing.Size(160, 23);
            this._btRefreshPatient.TabIndex = 3;
            this._btRefreshPatient.Text = "刷新病人(共0人)";
            this._btRefreshPatient.UseVisualStyleBackColor = true;
            this._btRefreshPatient.Click += new System.EventHandler(this._btRefreshPatient_Click);
            // 
            // _lvwPatientList
            // 
            this._lvwPatientList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this._lvwPatientList.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lvwPatientList.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._lvwPatientList.FullRowSelect = true;
            this._lvwPatientList.GridLines = true;
            this._lvwPatientList.Location = new System.Drawing.Point(0, 112);
            this._lvwPatientList.MultiSelect = false;
            this._lvwPatientList.Name = "_lvwPatientList";
            this._lvwPatientList.Size = new System.Drawing.Size(160, 172);
            this._lvwPatientList.TabIndex = 0;
            this._lvwPatientList.UseCompatibleStateImageBehavior = false;
            this._lvwPatientList.UseGradientBackgroundColor = false;
            this._lvwPatientList.View = System.Windows.Forms.View.Details;
            this._lvwPatientList.DoubleClick += new System.EventHandler(this._lvwPatientList_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "门诊号";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "病人姓名";
            this.columnHeader2.Width = 85;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "性别";
            this.columnHeader3.Width = 55;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "年龄";
            this.columnHeader4.Width = 85;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "挂号医师";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "挂号科室";
            this.columnHeader6.Width = 80;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "挂号时间";
            this.columnHeader7.Width = 150;
            // 
            // UCPatientList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.Controls.Add(this._lvwPatientList);
            this.Controls.Add(this._btRefreshPatient);
            this.Controls.Add(this.pnlPatient);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this._dtpEnd);
            this.Controls.Add(this._dtpBegin);
            this.Name = "UCPatientList";
            this.Size = new System.Drawing.Size(160, 284);
            this.pnlStatus.ResumeLayout(false);
            this.pnlPatient.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker _dtpBegin;
        private System.Windows.Forms.DateTimePicker _dtpEnd;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.RadioButton _rdbWaitPatient;
        private System.Windows.Forms.RadioButton _rdbFinishPatient;
        private System.Windows.Forms.Panel pnlPatient;
        private System.Windows.Forms.RadioButton _rdbDocPatient;
        private System.Windows.Forms.RadioButton _rdbAllPatient;
        private System.Windows.Forms.Button _btRefreshPatient;
        private GWI.HIS.Windows.Controls.ListView _lvwPatientList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
    }
}
