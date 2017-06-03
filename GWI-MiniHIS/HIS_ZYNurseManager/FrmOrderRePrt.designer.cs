namespace HIS_ZYNurseManager
{
    partial class FrmOrderRePrt
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
            this.rbn_AllPages = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbx_Pages = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.lbl_ValidPageNO = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbn_PageRange = new System.Windows.Forms.RadioButton();
            this.btn_Print = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbn_AllPages
            // 
            this.rbn_AllPages.AutoSize = true;
            this.rbn_AllPages.Location = new System.Drawing.Point(6, 20);
            this.rbn_AllPages.Name = "rbn_AllPages";
            this.rbn_AllPages.Size = new System.Drawing.Size(71, 16);
            this.rbn_AllPages.TabIndex = 0;
            this.rbn_AllPages.TabStop = true;
            this.rbn_AllPages.Text = "所有页面";
            this.rbn_AllPages.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbx_Pages);
            this.groupBox1.Controls.Add(this.lbl_ValidPageNO);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rbn_PageRange);
            this.groupBox1.Controls.Add(this.rbn_AllPages);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 145);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "打印范围";
            // 
            // tbx_Pages
            // 
            this.tbx_Pages.AllowSelectedNullRow = false;
            this.tbx_Pages.DisplayField = "";
            this.tbx_Pages.Location = new System.Drawing.Point(82, 42);
            this.tbx_Pages.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.tbx_Pages.MemberField = "";
            this.tbx_Pages.MemberValue = null;
            this.tbx_Pages.Name = "tbx_Pages";
            this.tbx_Pages.NextControl = null;
            this.tbx_Pages.NextControlByEnter = false;
            this.tbx_Pages.OffsetX = 0;
            this.tbx_Pages.OffsetY = 0;
            this.tbx_Pages.QueryFields = null;
            this.tbx_Pages.SelectedValue = null;
            this.tbx_Pages.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.tbx_Pages.SelectionCardBackColor = System.Drawing.Color.White;
            this.tbx_Pages.SelectionCardColumnHeaderHeight = 30;
            this.tbx_Pages.SelectionCardColumns = null;
            this.tbx_Pages.SelectionCardFont = null;
            this.tbx_Pages.SelectionCardHeight = 250;
            this.tbx_Pages.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.tbx_Pages.SelectionCardRowHeaderWidth = 35;
            this.tbx_Pages.SelectionCardRowHeight = 23;
            this.tbx_Pages.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.tbx_Pages.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.tbx_Pages.SelectionCardWidth = 250;
            this.tbx_Pages.ShowRowNumber = true;
            this.tbx_Pages.ShowSelectionCardAfterEnter = false;
            this.tbx_Pages.Size = new System.Drawing.Size(88, 21);
            this.tbx_Pages.TabIndex = 6;
            this.tbx_Pages.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.UInteger;
            this.tbx_Pages.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbx_Pages_KeyDown);
            this.tbx_Pages.Enter += new System.EventHandler(this.tbx_Pages_Enter);
            // 
            // lbl_ValidPageNO
            // 
            this.lbl_ValidPageNO.AutoSize = true;
            this.lbl_ValidPageNO.ForeColor = System.Drawing.Color.Red;
            this.lbl_ValidPageNO.Location = new System.Drawing.Point(6, 95);
            this.lbl_ValidPageNO.Name = "lbl_ValidPageNO";
            this.lbl_ValidPageNO.Size = new System.Drawing.Size(119, 12);
            this.lbl_ValidPageNO.TabIndex = 5;
            this.lbl_ValidPageNO.Text = "当前可用页码范围：1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "请键入页码和/或用逗号分隔的页码范围(例如1,3,5-12)";
            // 
            // rbn_PageRange
            // 
            this.rbn_PageRange.AutoSize = true;
            this.rbn_PageRange.Location = new System.Drawing.Point(7, 43);
            this.rbn_PageRange.Name = "rbn_PageRange";
            this.rbn_PageRange.Size = new System.Drawing.Size(71, 16);
            this.rbn_PageRange.TabIndex = 1;
            this.rbn_PageRange.TabStop = true;
            this.rbn_PageRange.Text = "页面范围";
            this.rbn_PageRange.UseVisualStyleBackColor = true;
            // 
            // btn_Print
            // 
            this.btn_Print.Location = new System.Drawing.Point(25, 163);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(75, 23);
            this.btn_Print.TabIndex = 2;
            this.btn_Print.Text = "打印";
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(107, 163);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // FrmOrderRePrt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 198);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmOrderRePrt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmOrderRePrt";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbn_AllPages;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbn_PageRange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_ValidPageNO;
        private GWI.HIS.Windows.Controls.QueryTextBox tbx_Pages;

    }
}