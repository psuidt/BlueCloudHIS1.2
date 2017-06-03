namespace HIS_ZYNurseManager
{
    partial class FrmModifyDoc
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnalter = new System.Windows.Forms.Button();
            this.queryTextBox2 = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnalter);
            this.groupBox2.Controls.Add(this.queryTextBox2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 193);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "修改主管医生";
            // 
            // btnalter
            // 
            this.btnalter.Location = new System.Drawing.Point(178, 24);
            this.btnalter.Name = "btnalter";
            this.btnalter.Size = new System.Drawing.Size(55, 25);
            this.btnalter.TabIndex = 7;
            this.btnalter.Text = "确定";
            this.btnalter.UseVisualStyleBackColor = true;
            this.btnalter.Click += new System.EventHandler(this.btnalter_Click);
            // 
            // queryTextBox2
            // 
            this.queryTextBox2.AllowSelectedNullRow = false;
            this.queryTextBox2.DisplayField = "NAME";
            this.queryTextBox2.Location = new System.Drawing.Point(27, 24);
            this.queryTextBox2.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.queryTextBox2.MemberField = "EMPLOYEE_ID";
            this.queryTextBox2.MemberValue = null;
            this.queryTextBox2.Name = "queryTextBox2";
            this.queryTextBox2.NextControl = this.btnalter;
            this.queryTextBox2.NextControlByEnter = true;
            this.queryTextBox2.OffsetX = 0;
            this.queryTextBox2.OffsetY = 0;
            this.queryTextBox2.QueryFields = new string[] {
        "PY_CODE",
        "WB_CODE"};
            this.queryTextBox2.SelectedValue = null;
            this.queryTextBox2.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.queryTextBox2.SelectionCardBackColor = System.Drawing.Color.White;
            this.queryTextBox2.SelectionCardColumnHeaderHeight = 30;
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
            this.queryTextBox2.SelectionCardColumns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn1,
        selectionCardColumn2};
            this.queryTextBox2.SelectionCardFont = null;
            this.queryTextBox2.SelectionCardHeight = 250;
            this.queryTextBox2.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.queryTextBox2.SelectionCardRowHeaderWidth = 35;
            this.queryTextBox2.SelectionCardRowHeight = 23;
            this.queryTextBox2.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.queryTextBox2.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.queryTextBox2.SelectionCardWidth = 250;
            this.queryTextBox2.ShowRowNumber = true;
            this.queryTextBox2.ShowSelectionCardAfterEnter = false;
            this.queryTextBox2.Size = new System.Drawing.Size(131, 21);
            this.queryTextBox2.TabIndex = 5;
            this.queryTextBox2.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            // 
            // FrmModifyDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 193);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmModifyDoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改主管医生";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private GWI.HIS.Windows.Controls.QueryTextBox queryTextBox2;
        private System.Windows.Forms.Button btnalter;
    }
}