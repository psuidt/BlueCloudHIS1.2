namespace HIS_YPManager
{
    partial class FrmSelectOutDept
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectOutDept));
            GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn1 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtSelectDept = new GWI.HIS.Windows.Controls.QueryTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(40, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择申领库房:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 33);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(18, 87);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(62, 32);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(86, 87);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 32);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtSelectDept
            // 
            this.txtSelectDept.AllowSelectedNullRow = false;
            this.txtSelectDept.DisplayField = "";
            this.txtSelectDept.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSelectDept.Location = new System.Drawing.Point(4, 42);
            this.txtSelectDept.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.txtSelectDept.MemberField = "";
            this.txtSelectDept.MemberValue = null;
            this.txtSelectDept.Name = "txtSelectDept";
            this.txtSelectDept.NextControl = null;
            this.txtSelectDept.NextControlByEnter = false;
            this.txtSelectDept.OffsetX = 0;
            this.txtSelectDept.OffsetY = 0;
            this.txtSelectDept.QueryFields = new string[] {
        "PY_CODE\t",
        "WB_CODE"};
            this.txtSelectDept.SelectedValue = null;
            this.txtSelectDept.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSelectDept.SelectionCardBackColor = System.Drawing.Color.White;
            this.txtSelectDept.SelectionCardColumnHeaderHeight = 25;
            selectionCardColumn1.AutoFill = true;
            selectionCardColumn1.DataBindField = "NAME";
            selectionCardColumn1.HeaderText = "科室名称";
            selectionCardColumn1.IsSeachColumn = false;
            selectionCardColumn1.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
            selectionCardColumn1.Visiable = true;
            selectionCardColumn1.Width = 75;
            this.txtSelectDept.SelectionCardColumns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn1};
            this.txtSelectDept.SelectionCardFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSelectDept.SelectionCardHeight = 100;
            this.txtSelectDept.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.txtSelectDept.SelectionCardRowHeaderWidth = 25;
            this.txtSelectDept.SelectionCardRowHeight = 18;
            this.txtSelectDept.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.txtSelectDept.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.txtSelectDept.SelectionCardWidth = 140;
            this.txtSelectDept.ShowRowNumber = true;
            this.txtSelectDept.ShowSelectionCardAfterEnter = false;
            this.txtSelectDept.Size = new System.Drawing.Size(144, 21);
            this.txtSelectDept.TabIndex = 1;
            this.txtSelectDept.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
            this.txtSelectDept.AfterSelectedRow += new GWI.HIS.Windows.Controls.AfterSelectedRowHandler(this.txtSelectDept_AfterSelectedRow);
            this.txtSelectDept.Leave += new System.EventHandler(this.txtSelectDept_Leave);
            // 
            // FrmSelectOutDept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(156, 187);
            this.Controls.Add(this.txtSelectDept);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(164, 221);
            this.MinimumSize = new System.Drawing.Size(164, 221);
            this.Name = "FrmSelectOutDept";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择申领库房";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmSelectOutDept_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private GWI.HIS.Windows.Controls.QueryTextBox txtSelectDept;
    }
}