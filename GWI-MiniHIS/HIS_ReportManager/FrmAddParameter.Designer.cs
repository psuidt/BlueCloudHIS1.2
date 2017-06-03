namespace HIS_ReportManager
{
    partial class FrmAddParameter
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
            this.txtParamter_cn = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtParamLength = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtParaType = new System.Windows.Forms.TextBox();
            this.txtInOut = new System.Windows.Forms.TextBox();
            this.cbParaNames = new System.Windows.Forms.ComboBox();
            this.cbParaControl = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpSelectSource = new System.Windows.Forms.GroupBox();
            this.cbSource = new System.Windows.Forms.ComboBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.grpSelectSource.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtParamter_cn
            // 
            this.txtParamter_cn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtParamter_cn.Location = new System.Drawing.Point(83, 36);
            this.txtParamter_cn.MaxLength = 50;
            this.txtParamter_cn.Name = "txtParamter_cn";
            this.txtParamter_cn.Size = new System.Drawing.Size(173, 21);
            this.txtParamter_cn.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(12, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "参数别名：";
            // 
            // txtParamLength
            // 
            this.txtParamLength.BackColor = System.Drawing.SystemColors.Control;
            this.txtParamLength.Location = new System.Drawing.Point(82, 115);
            this.txtParamLength.MaxLength = 50;
            this.txtParamLength.Name = "txtParamLength";
            this.txtParamLength.ReadOnly = true;
            this.txtParamLength.Size = new System.Drawing.Size(173, 21);
            this.txtParamLength.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(11, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 27;
            this.label6.Text = "输入输出：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(12, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 26;
            this.label5.Text = "参数大小：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(11, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 24;
            this.label4.Text = "参数类型：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(13, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "参数名  ：";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.grpSelectSource);
            this.groupBox1.Controls.Add(this.txtParaType);
            this.groupBox1.Controls.Add(this.txtInOut);
            this.groupBox1.Controls.Add(this.cbParaNames);
            this.groupBox1.Controls.Add(this.cbParaControl);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtParamter_cn);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtParamLength);
            this.groupBox1.Location = new System.Drawing.Point(1, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 249);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参数信息";
            // 
            // txtParaType
            // 
            this.txtParaType.Location = new System.Drawing.Point(82, 88);
            this.txtParaType.Name = "txtParaType";
            this.txtParaType.ReadOnly = true;
            this.txtParaType.Size = new System.Drawing.Size(173, 21);
            this.txtParaType.TabIndex = 35;
            // 
            // txtInOut
            // 
            this.txtInOut.Location = new System.Drawing.Point(82, 62);
            this.txtInOut.Name = "txtInOut";
            this.txtInOut.ReadOnly = true;
            this.txtInOut.Size = new System.Drawing.Size(174, 21);
            this.txtInOut.TabIndex = 34;
            // 
            // cbParaNames
            // 
            this.cbParaNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParaNames.FormattingEnabled = true;
            this.cbParaNames.Location = new System.Drawing.Point(83, 12);
            this.cbParaNames.Name = "cbParaNames";
            this.cbParaNames.Size = new System.Drawing.Size(173, 20);
            this.cbParaNames.TabIndex = 33;
            this.cbParaNames.SelectedIndexChanged += new System.EventHandler(this.cbParaNames_SelectedIndexChanged);
            // 
            // cbParaControl
            // 
            this.cbParaControl.FormattingEnabled = true;
            this.cbParaControl.Location = new System.Drawing.Point(82, 142);
            this.cbParaControl.Name = "cbParaControl";
            this.cbParaControl.Size = new System.Drawing.Size(173, 20);
            this.cbParaControl.TabIndex = 30;
            this.cbParaControl.SelectedIndexChanged += new System.EventHandler(this.cbParaControl_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 29;
            this.label1.Text = "入参控件：";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(42, 256);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 31;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(152, 256);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grpSelectSource
            // 
            this.grpSelectSource.Controls.Add(this.linkLabel1);
            this.grpSelectSource.Controls.Add(this.cbSource);
            this.grpSelectSource.Location = new System.Drawing.Point(15, 168);
            this.grpSelectSource.Name = "grpSelectSource";
            this.grpSelectSource.Size = new System.Drawing.Size(240, 70);
            this.grpSelectSource.TabIndex = 41;
            this.grpSelectSource.TabStop = false;
            this.grpSelectSource.Text = "选择数据源";
            // 
            // cbSource
            // 
            this.cbSource.FormattingEnabled = true;
            this.cbSource.Location = new System.Drawing.Point(26, 17);
            this.cbSource.Name = "cbSource";
            this.cbSource.Size = new System.Drawing.Size(198, 20);
            this.cbSource.TabIndex = 0;
            this.cbSource.SelectedIndexChanged += new System.EventHandler(this.cbSource_SelectedIndexChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Enabled = false;
            this.linkLabel1.Location = new System.Drawing.Point(24, 44);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(29, 12);
            this.linkLabel1.TabIndex = 42;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "高级";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // FrmAddParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 286);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmAddParameter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑";
            this.Load += new System.EventHandler(this.FrmAddParameter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpSelectSource.ResumeLayout(false);
            this.grpSelectSource.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtParamter_cn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtParamLength;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbParaControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtParaType;
        private System.Windows.Forms.TextBox txtInOut;
        private System.Windows.Forms.ComboBox cbParaNames;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpSelectSource;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ComboBox cbSource;
    }
}