namespace HIS_ZYManager.InvoiceManager
{
    partial class FrmAllotInvoice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAllotInvoice));
            this.label5 = new System.Windows.Forms.Label();
            this.txtJs = new System.Windows.Forms.TextBox();
            this.txtKs = new System.Windows.Forms.TextBox();
            this.cboInvoiceType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new GWI.HIS.Windows.Controls.Button();
            this.btnOk = new GWI.HIS.Windows.Controls.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkCommonUser = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboChargetor = new GWMHIS.PublicControls.ComboxTextBoxEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPerfChar = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(233, 149);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 14);
            this.label5.TabIndex = 17;
            this.label5.Text = "至";
            // 
            // txtJs
            // 
            this.txtJs.Location = new System.Drawing.Point(261, 146);
            this.txtJs.MaxLength = 8;
            this.txtJs.Name = "txtJs";
            this.txtJs.Size = new System.Drawing.Size(132, 23);
            this.txtJs.TabIndex = 16;
            // 
            // txtKs
            // 
            this.txtKs.Location = new System.Drawing.Point(92, 146);
            this.txtKs.MaxLength = 8;
            this.txtKs.Name = "txtKs";
            this.txtKs.Size = new System.Drawing.Size(129, 23);
            this.txtKs.TabIndex = 15;
            // 
            // cboInvoiceType
            // 
            this.cboInvoiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInvoiceType.FormattingEnabled = true;
            this.cboInvoiceType.Items.AddRange(new object[] {
            "收费发票",
            "挂号发票"});
            this.cboInvoiceType.Location = new System.Drawing.Point(92, 81);
            this.cboInvoiceType.Name = "cboInvoiceType";
            this.cboInvoiceType.Size = new System.Drawing.Size(132, 21);
            this.cboInvoiceType.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 149);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "起始号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "发票类型";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.Cancel;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FixedWidth = true;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(348, 233);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.Ok;
            this.btnOk.FixedWidth = true;
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(247, 233);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(90, 25);
            this.btnOk.TabIndex = 18;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 21;
            this.label1.Text = "领用人";
            // 
            // chkCommonUser
            // 
            this.chkCommonUser.AutoSize = true;
            this.chkCommonUser.Enabled = false;
            this.chkCommonUser.Location = new System.Drawing.Point(23, 586);
            this.chkCommonUser.Name = "chkCommonUser";
            this.chkCommonUser.Size = new System.Drawing.Size(138, 18);
            this.chkCommonUser.TabIndex = 22;
            this.chkCommonUser.Text = "所有人使用该卷票";
            this.chkCommonUser.UseVisualStyleBackColor = false;
            this.chkCommonUser.CheckedChanged += new System.EventHandler(this.chkCommonUser_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 181);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(371, 14);
            this.label3.TabIndex = 24;
            this.label3.Text = "(如果不使用电脑管理票号，则起始号不必与实体发票同号)";
            // 
            // cboChargetor
            // 
            this.cboChargetor.DataSource = null;
            this.cboChargetor.DisplayField = "NAME";
            this.cboChargetor.Location = new System.Drawing.Point(92, 38);
            this.cboChargetor.Name = "cboChargetor";
            this.cboChargetor.SearchKeyFiled = new string[] {
        "PY_CODE",
        "WB_CODE"};
            this.cboChargetor.SelectedValue = null;
            this.cboChargetor.Size = new System.Drawing.Size(132, 23);
            this.cboChargetor.TabIndex = 20;
            this.cboChargetor.ValueField = "EMPLOYEE_ID";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtPerfChar);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboInvoiceType);
            this.groupBox1.Controls.Add(this.txtKs);
            this.groupBox1.Controls.Add(this.cboChargetor);
            this.groupBox1.Controls.Add(this.txtJs);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(469, 215);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // txtPerfChar
            // 
            this.txtPerfChar.Location = new System.Drawing.Point(92, 113);
            this.txtPerfChar.MaxLength = 3;
            this.txtPerfChar.Name = "txtPerfChar";
            this.txtPerfChar.Size = new System.Drawing.Size(129, 23);
            this.txtPerfChar.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 116);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 25;
            this.label6.Text = "前缀字符";
            // 
            // FrmAllotInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(479, 274);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.chkCommonUser);
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAllotInvoice";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "分配票据";
            this.Load += new System.EventHandler(this.FrmAllotInvoice_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtJs;
        private System.Windows.Forms.TextBox txtKs;
        private System.Windows.Forms.ComboBox cboInvoiceType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private GWI.HIS.Windows.Controls.Button btnCancel;
        private GWI.HIS.Windows.Controls.Button btnOk;
        private GWMHIS.PublicControls.ComboxTextBoxEx cboChargetor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkCommonUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPerfChar;
        private System.Windows.Forms.Label label6;
    }
}