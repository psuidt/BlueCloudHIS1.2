namespace HIS_PublicManager.SystemTool.GenerateWorkers
{
    partial class FrmWorkInfo
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
            this.tbHISPOS = new System.Windows.Forms.TextBox();
            this.tbHISADDRESS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbHISYZBM = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbHISBEDNUM = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbHISPRESON = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbHISTEL = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbHISPATNUM = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbHISWORKNUM = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbHISBEDCOUNT = new GWI.HIS.Windows.Controls.QueryTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "地理位置";
            // 
            // tbHISPOS
            // 
            this.tbHISPOS.Location = new System.Drawing.Point(109, 23);
            this.tbHISPOS.Name = "tbHISPOS";
            this.tbHISPOS.Size = new System.Drawing.Size(298, 21);
            this.tbHISPOS.TabIndex = 1;
            // 
            // tbHISADDRESS
            // 
            this.tbHISADDRESS.Location = new System.Drawing.Point(109, 60);
            this.tbHISADDRESS.Name = "tbHISADDRESS";
            this.tbHISADDRESS.Size = new System.Drawing.Size(298, 21);
            this.tbHISADDRESS.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "通信地址";
            // 
            // tbHISYZBM
            // 
            this.tbHISYZBM.Location = new System.Drawing.Point(109, 97);
            this.tbHISYZBM.Name = "tbHISYZBM";
            this.tbHISYZBM.Size = new System.Drawing.Size(298, 21);
            this.tbHISYZBM.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "邮政编码";
            // 
            // tbHISBEDNUM
            // 
            this.tbHISBEDNUM.AllowSelectedNullRow = false;
            this.tbHISBEDNUM.DisplayField = "";
            this.tbHISBEDNUM.Location = new System.Drawing.Point(109, 136);
            this.tbHISBEDNUM.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.tbHISBEDNUM.MemberField = "";
            this.tbHISBEDNUM.MemberValue = null;
            this.tbHISBEDNUM.Name = "tbHISBEDNUM";
            this.tbHISBEDNUM.NextControl = null;
            this.tbHISBEDNUM.NextControlByEnter = false;
            this.tbHISBEDNUM.OffsetX = 0;
            this.tbHISBEDNUM.OffsetY = 0;
            this.tbHISBEDNUM.QueryFields = null;
            this.tbHISBEDNUM.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbHISBEDNUM.SelectedValue = null;
            this.tbHISBEDNUM.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHISBEDNUM.SelectionCardBackColor = System.Drawing.Color.White;
            this.tbHISBEDNUM.SelectionCardColumnHeaderHeight = 30;
            this.tbHISBEDNUM.SelectionCardColumns = null;
            this.tbHISBEDNUM.SelectionCardFont = null;
            this.tbHISBEDNUM.SelectionCardHeight = 250;
            this.tbHISBEDNUM.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.tbHISBEDNUM.SelectionCardRowHeaderWidth = 35;
            this.tbHISBEDNUM.SelectionCardRowHeight = 23;
            this.tbHISBEDNUM.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.tbHISBEDNUM.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.tbHISBEDNUM.SelectionCardWidth = 250;
            this.tbHISBEDNUM.ShowRowNumber = true;
            this.tbHISBEDNUM.ShowSelectionCardAfterEnter = false;
            this.tbHISBEDNUM.Size = new System.Drawing.Size(298, 21);
            this.tbHISBEDNUM.TabIndex = 7;
            this.tbHISBEDNUM.Text = "0";
            this.tbHISBEDNUM.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.Integer;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "编制床位数";
            // 
            // tbHISPRESON
            // 
            this.tbHISPRESON.Location = new System.Drawing.Point(109, 176);
            this.tbHISPRESON.Name = "tbHISPRESON";
            this.tbHISPRESON.Size = new System.Drawing.Size(298, 21);
            this.tbHISPRESON.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "联系人";
            // 
            // tbHISTEL
            // 
            this.tbHISTEL.Location = new System.Drawing.Point(109, 217);
            this.tbHISTEL.Name = "tbHISTEL";
            this.tbHISTEL.Size = new System.Drawing.Size(298, 21);
            this.tbHISTEL.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "联系电话";
            // 
            // tbHISPATNUM
            // 
            this.tbHISPATNUM.AllowSelectedNullRow = false;
            this.tbHISPATNUM.DisplayField = "";
            this.tbHISPATNUM.Location = new System.Drawing.Point(109, 258);
            this.tbHISPATNUM.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.tbHISPATNUM.MemberField = "";
            this.tbHISPATNUM.MemberValue = null;
            this.tbHISPATNUM.Name = "tbHISPATNUM";
            this.tbHISPATNUM.NextControl = null;
            this.tbHISPATNUM.NextControlByEnter = false;
            this.tbHISPATNUM.OffsetX = 0;
            this.tbHISPATNUM.OffsetY = 0;
            this.tbHISPATNUM.QueryFields = null;
            this.tbHISPATNUM.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbHISPATNUM.SelectedValue = null;
            this.tbHISPATNUM.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHISPATNUM.SelectionCardBackColor = System.Drawing.Color.White;
            this.tbHISPATNUM.SelectionCardColumnHeaderHeight = 30;
            this.tbHISPATNUM.SelectionCardColumns = null;
            this.tbHISPATNUM.SelectionCardFont = null;
            this.tbHISPATNUM.SelectionCardHeight = 250;
            this.tbHISPATNUM.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.tbHISPATNUM.SelectionCardRowHeaderWidth = 35;
            this.tbHISPATNUM.SelectionCardRowHeight = 23;
            this.tbHISPATNUM.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.tbHISPATNUM.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.tbHISPATNUM.SelectionCardWidth = 250;
            this.tbHISPATNUM.ShowRowNumber = true;
            this.tbHISPATNUM.ShowSelectionCardAfterEnter = false;
            this.tbHISPATNUM.Size = new System.Drawing.Size(298, 21);
            this.tbHISPATNUM.TabIndex = 13;
            this.tbHISPATNUM.Text = "0";
            this.tbHISPATNUM.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.Integer;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 261);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "当地服务人口";
            // 
            // tbHISWORKNUM
            // 
            this.tbHISWORKNUM.AllowSelectedNullRow = false;
            this.tbHISWORKNUM.DisplayField = "";
            this.tbHISWORKNUM.Location = new System.Drawing.Point(109, 295);
            this.tbHISWORKNUM.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.tbHISWORKNUM.MemberField = "";
            this.tbHISWORKNUM.MemberValue = null;
            this.tbHISWORKNUM.Name = "tbHISWORKNUM";
            this.tbHISWORKNUM.NextControl = null;
            this.tbHISWORKNUM.NextControlByEnter = false;
            this.tbHISWORKNUM.OffsetX = 0;
            this.tbHISWORKNUM.OffsetY = 0;
            this.tbHISWORKNUM.QueryFields = null;
            this.tbHISWORKNUM.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbHISWORKNUM.SelectedValue = null;
            this.tbHISWORKNUM.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHISWORKNUM.SelectionCardBackColor = System.Drawing.Color.White;
            this.tbHISWORKNUM.SelectionCardColumnHeaderHeight = 30;
            this.tbHISWORKNUM.SelectionCardColumns = null;
            this.tbHISWORKNUM.SelectionCardFont = null;
            this.tbHISWORKNUM.SelectionCardHeight = 250;
            this.tbHISWORKNUM.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.tbHISWORKNUM.SelectionCardRowHeaderWidth = 35;
            this.tbHISWORKNUM.SelectionCardRowHeight = 23;
            this.tbHISWORKNUM.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.tbHISWORKNUM.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.tbHISWORKNUM.SelectionCardWidth = 250;
            this.tbHISWORKNUM.ShowRowNumber = true;
            this.tbHISWORKNUM.ShowSelectionCardAfterEnter = false;
            this.tbHISWORKNUM.Size = new System.Drawing.Size(298, 21);
            this.tbHISWORKNUM.TabIndex = 15;
            this.tbHISWORKNUM.Text = "0";
            this.tbHISWORKNUM.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.Integer;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 298);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "职工人数";
            // 
            // tbHISBEDCOUNT
            // 
            this.tbHISBEDCOUNT.AllowSelectedNullRow = false;
            this.tbHISBEDCOUNT.DisplayField = "";
            this.tbHISBEDCOUNT.Location = new System.Drawing.Point(109, 333);
            this.tbHISBEDCOUNT.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
            this.tbHISBEDCOUNT.MemberField = "";
            this.tbHISBEDCOUNT.MemberValue = null;
            this.tbHISBEDCOUNT.Name = "tbHISBEDCOUNT";
            this.tbHISBEDCOUNT.NextControl = null;
            this.tbHISBEDCOUNT.NextControlByEnter = false;
            this.tbHISBEDCOUNT.OffsetX = 0;
            this.tbHISBEDCOUNT.OffsetY = 0;
            this.tbHISBEDCOUNT.QueryFields = null;
            this.tbHISBEDCOUNT.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbHISBEDCOUNT.SelectedValue = null;
            this.tbHISBEDCOUNT.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHISBEDCOUNT.SelectionCardBackColor = System.Drawing.Color.White;
            this.tbHISBEDCOUNT.SelectionCardColumnHeaderHeight = 30;
            this.tbHISBEDCOUNT.SelectionCardColumns = null;
            this.tbHISBEDCOUNT.SelectionCardFont = null;
            this.tbHISBEDCOUNT.SelectionCardHeight = 250;
            this.tbHISBEDCOUNT.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
            this.tbHISBEDCOUNT.SelectionCardRowHeaderWidth = 35;
            this.tbHISBEDCOUNT.SelectionCardRowHeight = 23;
            this.tbHISBEDCOUNT.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
            this.tbHISBEDCOUNT.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            this.tbHISBEDCOUNT.SelectionCardWidth = 250;
            this.tbHISBEDCOUNT.ShowRowNumber = true;
            this.tbHISBEDCOUNT.ShowSelectionCardAfterEnter = false;
            this.tbHISBEDCOUNT.Size = new System.Drawing.Size(298, 21);
            this.tbHISBEDCOUNT.TabIndex = 17;
            this.tbHISBEDCOUNT.Text = "0";
            this.tbHISBEDCOUNT.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.Integer;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 336);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "实际床位数";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(141, 391);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(274, 391);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "关闭";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmWorkInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 454);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbHISBEDCOUNT);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbHISWORKNUM);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbHISPATNUM);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbHISTEL);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbHISPRESON);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbHISBEDNUM);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbHISYZBM);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbHISADDRESS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbHISPOS);
            this.Controls.Add(this.label1);
            this.Name = "FrmWorkInfo";
            this.Text = "医院详细信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbHISPOS;
        private System.Windows.Forms.TextBox tbHISADDRESS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbHISYZBM;
        private System.Windows.Forms.Label label3;
        private GWI.HIS.Windows.Controls.QueryTextBox tbHISBEDNUM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbHISPRESON;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbHISTEL;
        private System.Windows.Forms.Label label6;
        private GWI.HIS.Windows.Controls.QueryTextBox tbHISPATNUM;
        private System.Windows.Forms.Label label7;
        private GWI.HIS.Windows.Controls.QueryTextBox tbHISWORKNUM;
        private System.Windows.Forms.Label label8;
        private GWI.HIS.Windows.Controls.QueryTextBox tbHISBEDCOUNT;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}