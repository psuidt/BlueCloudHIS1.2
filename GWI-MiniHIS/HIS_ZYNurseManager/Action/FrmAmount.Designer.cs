namespace HIS_ZYNurseManager
{
    partial class FrmCanAmount
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
            this.label1 = new System.Windows.Forms.Label();
            this.queryTextBox1 = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(32, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入需要冲正的数量";
            // 
            // queryTextBox1
            // 
            this.queryTextBox1.AllowSelectedNullRow = false;
            this.queryTextBox1.DisplayField = "";
            this.queryTextBox1.Location = new System.Drawing.Point(35, 67);
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
            this.queryTextBox1.Size = new System.Drawing.Size(164, 21);
            this.queryTextBox1.TabIndex = 1;
            this.queryTextBox1.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.Numberic;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(71, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmAmount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 159);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.queryTextBox1);
            this.Controls.Add(this.label1);
            this.Name = "FrmAmount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private GWI.HIS.Windows.Controls.QueryTextBox queryTextBox1;
        private System.Windows.Forms.Button button1;
    }
}