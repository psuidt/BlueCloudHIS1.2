namespace HIS_ZYNurseManager
{
    partial class Frmcanaccount
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.queryTextBox1 = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.btnassure = new GWI.HIS.Windows.Controls.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(75, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "(注意：只能输入正整数)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(57, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "请输入您需要冲正的数量";
            // 
            // queryTextBox1
            // 
            this.queryTextBox1.AllowSelectedNullRow = false;
            this.queryTextBox1.DisplayField = "";
            this.queryTextBox1.Location = new System.Drawing.Point(60, 71);
            this.queryTextBox1.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.queryTextBox1.MemberField = "";
            this.queryTextBox1.MemberValue = null;
            this.queryTextBox1.Name = "queryTextBox1";
            this.queryTextBox1.NextControl = null;
            this.queryTextBox1.NextControlByEnter = false;
            this.queryTextBox1.OffsetX = 0;
            this.queryTextBox1.OffsetY = 0;
            this.queryTextBox1.QueryFields = null;
            this.queryTextBox1.SelectedValue = null;
            this.queryTextBox1.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.queryTextBox1.SelectionCardBackColor = System.Drawing.Color.White;
            this.queryTextBox1.SelectionCardColumnHeaderHeight = 30;
            this.queryTextBox1.SelectionCardColumns = null;
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
            this.queryTextBox1.Size = new System.Drawing.Size(165, 21);
            this.queryTextBox1.TabIndex = 5;
            this.queryTextBox1.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.Integer;
            // 
            // btnassure
            // 
            this.btnassure.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.OtherProcess;
            this.btnassure.FixedWidth = true;
            this.btnassure.Location = new System.Drawing.Point(88, 114);
            this.btnassure.Name = "btnassure";
            this.btnassure.Size = new System.Drawing.Size(90, 25);
            this.btnassure.TabIndex = 6;
            this.btnassure.Text = "确定";
            this.btnassure.UseVisualStyleBackColor = true;
            this.btnassure.Click += new System.EventHandler(this.btnassure_Click);
            // 
            // Frmcanaccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(280, 151);
            this.Controls.Add(this.btnassure);
            this.Controls.Add(this.queryTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Frmcanaccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "冲正数量";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private GWI.HIS.Windows.Controls.QueryTextBox queryTextBox1;
        private GWI.HIS.Windows.Controls.Button btnassure;

    }
}