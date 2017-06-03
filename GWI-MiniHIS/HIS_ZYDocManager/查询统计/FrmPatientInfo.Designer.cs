namespace HIS_ZYDocManager.查询统计
{
    partial class FrmPatientInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPatientInfo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dtPEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpBdate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgResult = new GWI.HIS.Windows.Controls.DataGridViewEx();
            this.BtnResult = new System.Windows.Forms.Button();
            this.radIn = new System.Windows.Forms.RadioButton();
            this.radOut = new System.Windows.Forms.RadioButton();
            this.cbDocName = new System.Windows.Forms.ComboBox();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResult)).BeginInit();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Controls.Add(this.cbDocName);
            this.plBaseToolbar.Controls.Add(this.radOut);
            this.plBaseToolbar.Controls.Add(this.radIn);
            this.plBaseToolbar.Controls.Add(this.BtnResult);
            this.plBaseToolbar.Controls.Add(this.cbType);
            this.plBaseToolbar.Controls.Add(this.label5);
            this.plBaseToolbar.Controls.Add(this.label4);
            this.plBaseToolbar.Controls.Add(this.label3);
            this.plBaseToolbar.Controls.Add(this.dtPEnd);
            this.plBaseToolbar.Controls.Add(this.label2);
            this.plBaseToolbar.Controls.Add(this.dtpBdate);
            this.plBaseToolbar.Controls.Add(this.label1);
            this.plBaseToolbar.Size = new System.Drawing.Size(1106, 42);
            // 
            // baseImageList
            // 
            this.baseImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("baseImageList.ImageStream")));
            this.baseImageList.Images.SetKeyName(0, "table_delete.gif");
            this.baseImageList.Images.SetKeyName(1, "search_big.GIF");
            this.baseImageList.Images.SetKeyName(2, "Save.GIF");
            this.baseImageList.Images.SetKeyName(3, "Print.GIF");
            this.baseImageList.Images.SetKeyName(4, "page_user_dark.gif");
            this.baseImageList.Images.SetKeyName(5, "page_refresh.gif");
            this.baseImageList.Images.SetKeyName(6, "page_key.gif");
            this.baseImageList.Images.SetKeyName(7, "page_edit.gif");
            this.baseImageList.Images.SetKeyName(8, "page_cross.gif");
            this.baseImageList.Images.SetKeyName(9, "list_users.gif");
            this.baseImageList.Images.SetKeyName(10, "icon_package_get.gif");
            this.baseImageList.Images.SetKeyName(11, "icon_network.gif");
            this.baseImageList.Images.SetKeyName(12, "icon_history.gif");
            this.baseImageList.Images.SetKeyName(13, "icon_accept.gif");
            this.baseImageList.Images.SetKeyName(14, "folder_page.gif");
            this.baseImageList.Images.SetKeyName(15, "folder_new.gif");
            this.baseImageList.Images.SetKeyName(16, "Exit.GIF");
            this.baseImageList.Images.SetKeyName(17, "Delete.GIF");
            this.baseImageList.Images.SetKeyName(18, "copy.gif");
            this.baseImageList.Images.SetKeyName(19, "action_stop.gif");
            this.baseImageList.Images.SetKeyName(20, "action_refresh.gif");
            // 
            // plBaseStatus
            // 
            this.plBaseStatus.Location = new System.Drawing.Point(0, 534);
            this.plBaseStatus.Size = new System.Drawing.Size(1106, 26);
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add(this.panel1);
            this.plBaseWorkArea.Location = new System.Drawing.Point(0, 76);
            this.plBaseWorkArea.Size = new System.Drawing.Size(1106, 458);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "出院日期从：";
            // 
            // dtPEnd
            // 
            this.dtPEnd.Location = new System.Drawing.Point(419, 12);
            this.dtPEnd.Name = "dtPEnd";
            this.dtPEnd.Size = new System.Drawing.Size(118, 21);
            this.dtPEnd.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(393, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "到";
            // 
            // dtpBdate
            // 
            this.dtpBdate.Location = new System.Drawing.Point(261, 12);
            this.dtpBdate.Name = "dtpBdate";
            this.dtpBdate.Size = new System.Drawing.Size(118, 21);
            this.dtpBdate.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(558, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "医生姓名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(756, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "按";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(919, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "统计";
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "发票项目",
            "会计项目",
            "核算项目",
            "大项目"});
            this.cbType.Location = new System.Drawing.Point(779, 12);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(134, 20);
            this.cbType.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgResult);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1106, 458);
            this.panel1.TabIndex = 0;
            // 
            // dtgResult
            // 
            this.dtgResult.AddNewRowAfterPressEnterKeyAtLastRowAndColumn = false;
            this.dtgResult.AllowSortWhenClickColumnHeader = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgResult.DisplayAllItemWhenSelectionCardShowing = false;
            this.dtgResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgResult.EnableHeadersVisualStyles = false;
            this.dtgResult.HideSelectionCardWhenCustomInput = false;
            this.dtgResult.Location = new System.Drawing.Point(0, 0);
            this.dtgResult.Name = "dtgResult";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgResult.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgResult.RowTemplate.Height = 23;
            this.dtgResult.SelectionCards = null;
            this.dtgResult.Size = new System.Drawing.Size(1106, 458);
            this.dtgResult.TabIndex = 0;
            this.dtgResult.UseGradientBackgroundColor = true;
            // 
            // BtnResult
            // 
            this.BtnResult.Location = new System.Drawing.Point(973, 11);
            this.BtnResult.Name = "BtnResult";
            this.BtnResult.Size = new System.Drawing.Size(66, 21);
            this.BtnResult.TabIndex = 13;
            this.BtnResult.Text = "查询";
            this.BtnResult.UseVisualStyleBackColor = true;
            this.BtnResult.Click += new System.EventHandler(this.BtnResult_Click);
            // 
            // radIn
            // 
            this.radIn.AutoSize = true;
            this.radIn.Checked = true;
            this.radIn.Location = new System.Drawing.Point(16, 14);
            this.radIn.Name = "radIn";
            this.radIn.Size = new System.Drawing.Size(71, 16);
            this.radIn.TabIndex = 14;
            this.radIn.TabStop = true;
            this.radIn.Text = "在院病人";
            this.radIn.UseVisualStyleBackColor = true;
            this.radIn.CheckedChanged += new System.EventHandler(this.radIn_CheckedChanged);
            // 
            // radOut
            // 
            this.radOut.AutoSize = true;
            this.radOut.Location = new System.Drawing.Point(98, 15);
            this.radOut.Name = "radOut";
            this.radOut.Size = new System.Drawing.Size(71, 16);
            this.radOut.TabIndex = 15;
            this.radOut.Text = "出院病人";
            this.radOut.UseVisualStyleBackColor = true;
            // 
            // cbDocName
            // 
            this.cbDocName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDocName.FormattingEnabled = true;
            this.cbDocName.Location = new System.Drawing.Point(619, 12);
            this.cbDocName.Name = "cbDocName";
            this.cbDocName.Size = new System.Drawing.Size(121, 20);
            this.cbDocName.TabIndex = 16;
            // 
            // FrmPatientInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 560);
            this.FormTitle = "医院医生病人相关信息统计";
            this.Name = "FrmPatientInfo";
            this.Text = "医生病人信息统计";
            this.plBaseToolbar.ResumeLayout(false);
            this.plBaseToolbar.PerformLayout();
            this.plBaseWorkArea.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtPEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpBdate;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private GWI.HIS.Windows.Controls.DataGridViewEx dtgResult;
        private System.Windows.Forms.Button BtnResult;
        private System.Windows.Forms.RadioButton radOut;
        private System.Windows.Forms.RadioButton radIn;
        private System.Windows.Forms.ComboBox cbDocName;
    }
}