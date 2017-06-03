namespace HIS_ZYManager
{
    partial class FrmClearPatData
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClearPatData));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btQuest = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.lbCoseTolFee = new System.Windows.Forms.TextBox();
            this.lbChargeTolFee = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbpatName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbInpatNo = new GWMHIS.PublicControls.InpatientNOTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btQuest);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lbCoseTolFee);
            this.groupBox1.Controls.Add(this.lbChargeTolFee);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbpatName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbInpatNo);
            this.groupBox1.Location = new System.Drawing.Point(243, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 336);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btQuest
            // 
            this.btQuest.Location = new System.Drawing.Point(69, 272);
            this.btQuest.Name = "btQuest";
            this.btQuest.Size = new System.Drawing.Size(92, 23);
            this.btQuest.TabIndex = 44;
            this.btQuest.Text = "一键清零";
            this.btQuest.UseVisualStyleBackColor = true;
            this.btQuest.Click += new System.EventHandler(this.btQuest_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(66, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 14);
            this.label10.TabIndex = 43;
            this.label10.Text = "姓名";
            // 
            // lbCoseTolFee
            // 
            this.lbCoseTolFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCoseTolFee.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCoseTolFee.ForeColor = System.Drawing.Color.Blue;
            this.lbCoseTolFee.Location = new System.Drawing.Point(109, 196);
            this.lbCoseTolFee.Name = "lbCoseTolFee";
            this.lbCoseTolFee.ReadOnly = true;
            this.lbCoseTolFee.Size = new System.Drawing.Size(151, 23);
            this.lbCoseTolFee.TabIndex = 42;
            this.lbCoseTolFee.Text = "0";
            // 
            // lbChargeTolFee
            // 
            this.lbChargeTolFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbChargeTolFee.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbChargeTolFee.ForeColor = System.Drawing.Color.Blue;
            this.lbChargeTolFee.Location = new System.Drawing.Point(109, 157);
            this.lbChargeTolFee.Name = "lbChargeTolFee";
            this.lbChargeTolFee.ReadOnly = true;
            this.lbChargeTolFee.Size = new System.Drawing.Size(151, 23);
            this.lbChargeTolFee.TabIndex = 41;
            this.lbChargeTolFee.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(38, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 40;
            this.label8.Text = "累计记账";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(38, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 39;
            this.label7.Text = "累计交费";
            // 
            // tbpatName
            // 
            this.tbpatName.BackColor = System.Drawing.Color.White;
            this.tbpatName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbpatName.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbpatName.Location = new System.Drawing.Point(109, 113);
            this.tbpatName.Name = "tbpatName";
            this.tbpatName.ReadOnly = true;
            this.tbpatName.Size = new System.Drawing.Size(151, 23);
            this.tbpatName.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(52, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 36;
            this.label3.Text = "住院号";
            // 
            // tbInpatNo
            // 
            this.tbInpatNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInpatNo.EnabledFalseBackColor = System.Drawing.SystemColors.Control;
            this.tbInpatNo.EnabledTrueBackColor = System.Drawing.SystemColors.Window;
            this.tbInpatNo.EnterBackColor = System.Drawing.SystemColors.Window;
            this.tbInpatNo.EnterForeColor = System.Drawing.SystemColors.WindowText;
            this.tbInpatNo.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbInpatNo.Location = new System.Drawing.Point(109, 74);
            this.tbInpatNo.Name = "tbInpatNo";
            this.tbInpatNo.NextControl = null;
            this.tbInpatNo.PreviousControl = null;
            this.tbInpatNo.Size = new System.Drawing.Size(151, 23);
            this.tbInpatNo.TabIndex = 37;
            this.tbInpatNo.Text = "00000000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(221, 410);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(377, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "注意：清零只是清零病人的费用信息，预交金请到预交金管理界面操作\r\n";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(185, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 45;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmClearPatData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.FormTitle = "病人费用一键清零";
            this.Name = "FrmClearPatData";
            this.RightToLeftLayout = true;
            this.Text = "病人费用一键清零";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.plBaseWorkArea.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox lbCoseTolFee;
        private System.Windows.Forms.TextBox lbChargeTolFee;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbpatName;
        private System.Windows.Forms.Label label3;
        private GWMHIS.PublicControls.InpatientNOTextBox tbInpatNo;
        private System.Windows.Forms.Button btQuest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}