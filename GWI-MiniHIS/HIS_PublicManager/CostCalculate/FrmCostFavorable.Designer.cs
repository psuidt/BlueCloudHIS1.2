namespace HIS_PublicManager
{
    partial class FrmCostFavorable
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbResultFee = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btCal = new System.Windows.Forms.Button();
            this.btok = new System.Windows.Forms.Button();
            this.btclose = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(567, 32);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btCal);
            this.panel2.Controls.Add(this.btok);
            this.panel2.Controls.Add(this.btclose);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(567, 154);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(567, 1);
            this.panel3.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(33, 10);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(84, 16);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "按明细优惠";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbResultFee);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(98, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 81);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "优惠结果";
            // 
            // tbResultFee
            // 
            this.tbResultFee.AllowSelectedNullRow = false;
            this.tbResultFee.DisplayField = "";
            this.tbResultFee.Location = new System.Drawing.Point(114, 40);
            this.tbResultFee.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.tbResultFee.MemberField = "";
            this.tbResultFee.MemberValue = null;
            this.tbResultFee.Name = "tbResultFee";
            this.tbResultFee.NextControl = null;
            this.tbResultFee.NextControlByEnter = false;
            this.tbResultFee.OffsetX = 0;
            this.tbResultFee.OffsetY = 0;
            this.tbResultFee.QueryFields = null;
            this.tbResultFee.SelectedValue = null;
            this.tbResultFee.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.tbResultFee.SelectionCardBackColor = System.Drawing.Color.White;
            this.tbResultFee.SelectionCardColumnHeaderHeight = 30;
            this.tbResultFee.SelectionCardColumns = null;
            this.tbResultFee.SelectionCardFont = null;
            this.tbResultFee.SelectionCardHeight = 250;
            this.tbResultFee.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.tbResultFee.SelectionCardRowHeaderWidth = 35;
            this.tbResultFee.SelectionCardRowHeight = 23;
            this.tbResultFee.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.tbResultFee.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.tbResultFee.SelectionCardWidth = 250;
            this.tbResultFee.ShowRowNumber = true;
            this.tbResultFee.ShowSelectionCardAfterEnter = false;
            this.tbResultFee.Size = new System.Drawing.Size(231, 21);
            this.tbResultFee.TabIndex = 20;
            this.tbResultFee.Text = "0";
            this.tbResultFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbResultFee.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.Numberic;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(35, 45);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 21;
            this.label13.Text = "优惠  金额";
            // 
            // btCal
            // 
            this.btCal.Location = new System.Drawing.Point(198, 109);
            this.btCal.Name = "btCal";
            this.btCal.Size = new System.Drawing.Size(75, 23);
            this.btCal.TabIndex = 4;
            this.btCal.Text = "计算";
            this.btCal.UseVisualStyleBackColor = true;
            // 
            // btok
            // 
            this.btok.Location = new System.Drawing.Point(298, 109);
            this.btok.Name = "btok";
            this.btok.Size = new System.Drawing.Size(75, 23);
            this.btok.TabIndex = 5;
            this.btok.Text = "确定";
            this.btok.UseVisualStyleBackColor = true;
            this.btok.Click += new System.EventHandler(this.btok_Click);
            // 
            // btclose
            // 
            this.btclose.Location = new System.Drawing.Point(400, 109);
            this.btclose.Name = "btclose";
            this.btclose.Size = new System.Drawing.Size(75, 23);
            this.btclose.TabIndex = 6;
            this.btclose.Text = "退出";
            this.btclose.UseVisualStyleBackColor = true;
            this.btclose.Click += new System.EventHandler(this.btclose_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(486, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "单位（元）";
            // 
            // FrmCostFavorable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 187);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmCostFavorable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "结算优惠";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private GWI.HIS.Windows.Controls.QueryTextBox tbResultFee;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btCal;
        private System.Windows.Forms.Button btok;
        private System.Windows.Forms.Button btclose;
        private System.Windows.Forms.Label label8;
    }
}