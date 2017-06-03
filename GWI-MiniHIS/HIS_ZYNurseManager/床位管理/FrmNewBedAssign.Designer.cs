namespace HIS_ZYNurseManager
{
    partial class FrmNewBedAssign
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
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn1 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn2 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ExitAssign = new GWI.HIS.Windows.Controls.Button();
            this.ConfirmAssign = new GWI.HIS.Windows.Controls.Button();
            this.queryTextBox1 = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewEx1 = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.peopleid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cureno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 28);
            this.panel1.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(118, 8);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "出院召回";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "未分配床位列表";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.ExitAssign);
            this.panel2.Controls.Add(this.ConfirmAssign);
            this.panel2.Controls.Add(this.queryTextBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 274);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(491, 77);
            this.panel2.TabIndex = 1;
            // 
            // ExitAssign
            // 
            this.ExitAssign.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.OtherProcess;
            this.ExitAssign.FixedWidth = true;
            this.ExitAssign.Location = new System.Drawing.Point(372, 40);
            this.ExitAssign.Name = "ExitAssign";
            this.ExitAssign.Size = new System.Drawing.Size(90, 25);
            this.ExitAssign.TabIndex = 9;
            this.ExitAssign.Text = "退出(&E)";
            this.ExitAssign.UseVisualStyleBackColor = true;
            this.ExitAssign.Click += new System.EventHandler(this.ExitAssign_Click);
            // 
            // ConfirmAssign
            // 
            this.ConfirmAssign.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.OtherProcess;
            this.ConfirmAssign.FixedWidth = true;
            this.ConfirmAssign.Location = new System.Drawing.Point(266, 40);
            this.ConfirmAssign.Name = "ConfirmAssign";
            this.ConfirmAssign.Size = new System.Drawing.Size(90, 25);
            this.ConfirmAssign.TabIndex = 8;
            this.ConfirmAssign.Text = "确定(&S)";
            this.ConfirmAssign.UseVisualStyleBackColor = true;
            this.ConfirmAssign.Click += new System.EventHandler(this.ConfirmAssign_Click);
            // 
            // queryTextBox1
            // 
            this.queryTextBox1.AllowSelectedNullRow = false;
            this.queryTextBox1.DisplayField = "NAME";
            this.queryTextBox1.Location = new System.Drawing.Point(12, 44);
            this.queryTextBox1.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.queryTextBox1.MemberField = "EMPLOYEE_ID";
            this.queryTextBox1.MemberValue = null;
            this.queryTextBox1.Name = "queryTextBox1";
            this.queryTextBox1.NextControl = null;
            this.queryTextBox1.NextControlByEnter = false;
            this.queryTextBox1.OffsetX = 0;
            this.queryTextBox1.OffsetY = 0;
            this.queryTextBox1.QueryFields = new string[] {
        "PY_CODE",
        "WB_CODE"};
            this.queryTextBox1.SelectedValue = null;
            this.queryTextBox1.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.queryTextBox1.SelectionCardBackColor = System.Drawing.Color.White;
            this.queryTextBox1.SelectionCardColumnHeaderHeight = 30;
            selectionCardColumn1.AutoFill = true;
            selectionCardColumn1.DataBindField = "EMPLOYEE_ID";
            selectionCardColumn1.HeaderText = "代码";
            selectionCardColumn1.IsNameField = false;
            selectionCardColumn1.IsSeachColumn = false;
            selectionCardColumn1.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn1.Visiable = true;
            selectionCardColumn1.Width = 75;
            selectionCardColumn2.AutoFill = true;
            selectionCardColumn2.DataBindField = "NAME";
            selectionCardColumn2.HeaderText = "名称";
            selectionCardColumn2.IsNameField = false;
            selectionCardColumn2.IsSeachColumn = false;
            selectionCardColumn2.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn2.Visiable = true;
            selectionCardColumn2.Width = 75;
            this.queryTextBox1.SelectionCardColumns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn1,
        selectionCardColumn2};
            this.queryTextBox1.SelectionCardFont = null;
            this.queryTextBox1.SelectionCardHeight = 250;
            this.queryTextBox1.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.queryTextBox1.SelectionCardRowHeaderWidth = 35;
            this.queryTextBox1.SelectionCardRowHeight = 23;
            this.queryTextBox1.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.queryTextBox1.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.queryTextBox1.SelectionCardWidth = 250;
            this.queryTextBox1.ShowRowNumber = true;
            this.queryTextBox1.ShowSelectionCardAfterEnter = false;
            this.queryTextBox1.Size = new System.Drawing.Size(196, 21);
            this.queryTextBox1.TabIndex = 5;
            this.queryTextBox1.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "选择主管医生：";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.dataGridViewEx1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 28);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(491, 256);
            this.panel3.TabIndex = 2;
            // 
            // dataGridViewEx1
            // 
            this.dataGridViewEx1.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dataGridViewEx1.AllowSortWhenClickColumnHeader = false;
            this.dataGridViewEx1.AllowUserToAddRows = false;
            this.dataGridViewEx1.AllowUserToDeleteRows = false;
            this.dataGridViewEx1.AllowUserToResizeColumns = false;
            this.dataGridViewEx1.AllowUserToResizeRows = false;
            this.dataGridViewEx1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewEx1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewEx1.ColumnHeadersHeight = 30;
            this.dataGridViewEx1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.peopleid,
            this.Column1,
            this.cureno,
            this.name,
            this.sex,
            this.Column6,
            this.Column22,
            this.Column2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewEx1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewEx1.DisplayAllItemWhenSelectionCardShowing = false;
            this.dataGridViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEx1.EnableHeadersVisualStyles = false;
            this.dataGridViewEx1.HideSelectionCardWhenCustomInput = false;
            this.dataGridViewEx1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewEx1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewEx1.RowHeadersVisible = false;
            this.dataGridViewEx1.RowTemplate.Height = 23;
            this.dataGridViewEx1.SelectionCards = null;
            this.dataGridViewEx1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEx1.Size = new System.Drawing.Size(491, 256);
            this.dataGridViewEx1.TabIndex = 2;
            this.dataGridViewEx1.UseGradientBackgroundColor = true;
            this.dataGridViewEx1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEx1_CellClick);
            // 
            // peopleid
            // 
            this.peopleid.DataPropertyName = "patlistid";
            this.peopleid.HeaderText = "病人ID";
            this.peopleid.Name = "peopleid";
            this.peopleid.ReadOnly = true;
            this.peopleid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.peopleid.Visible = false;
            this.peopleid.Width = 5;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "curedate";
            this.Column1.HeaderText = "入院日期";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cureno
            // 
            this.cureno.DataPropertyName = "cureno";
            this.cureno.HeaderText = "住院号";
            this.cureno.Name = "cureno";
            this.cureno.ReadOnly = true;
            this.cureno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // name
            // 
            this.name.DataPropertyName = "patname";
            this.name.HeaderText = "姓名";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.name.Width = 80;
            // 
            // sex
            // 
            this.sex.DataPropertyName = "patsex";
            this.sex.HeaderText = "性别";
            this.sex.Name = "sex";
            this.sex.ReadOnly = true;
            this.sex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sex.Width = 50;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "name";
            this.Column6.HeaderText = "所属科室";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 80;
            // 
            // Column22
            // 
            this.Column22.DataPropertyName = "pattype";
            this.Column22.HeaderText = "入院状态";
            this.Column22.Name = "Column22";
            this.Column22.ReadOnly = true;
            this.Column22.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column22.Width = 60;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "deptid";
            this.Column2.HeaderText = "deptid";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Visible = false;
            // 
            // FrmNewBedAssign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(491, 351);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmNewBedAssign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "床位分配";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private GWI.HIS.Windows.Controls.DataGridViewEx dataGridViewEx1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private GWI.HIS.Windows.Controls.QueryTextBox queryTextBox1;
        private GWI.HIS.Windows.Controls.Button ConfirmAssign;
        private GWI.HIS.Windows.Controls.Button ExitAssign;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn peopleid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cureno;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;

    }
}