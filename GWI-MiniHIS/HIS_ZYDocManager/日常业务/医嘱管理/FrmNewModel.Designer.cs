namespace HIS_ZYDocManager.日常业务
{
    partial class FrmNewModel
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
            this.rbHospital = new System.Windows.Forms.RadioButton();
            this.rbDept = new System.Windows.Forms.RadioButton();
            this.rbSelf = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtModelName = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbHospital
            // 
            this.rbHospital.AutoSize = true;
            this.rbHospital.BackColor = System.Drawing.Color.Transparent;
            this.rbHospital.Location = new System.Drawing.Point(12, 12);
            this.rbHospital.Name = "rbHospital";
            this.rbHospital.Size = new System.Drawing.Size(47, 16);
            this.rbHospital.TabIndex = 0;
            this.rbHospital.Text = "全院";
            this.rbHospital.UseVisualStyleBackColor = false;
            this.rbHospital.CheckedChanged += new System.EventHandler(this.rbHospital_CheckedChanged);
            // 
            // rbDept
            // 
            this.rbDept.AutoSize = true;
            this.rbDept.BackColor = System.Drawing.Color.Transparent;
            this.rbDept.Location = new System.Drawing.Point(82, 12);
            this.rbDept.Name = "rbDept";
            this.rbDept.Size = new System.Drawing.Size(47, 16);
            this.rbDept.TabIndex = 1;
            this.rbDept.Text = "科室";
            this.rbDept.UseVisualStyleBackColor = false;
            this.rbDept.CheckedChanged += new System.EventHandler(this.rbDept_CheckedChanged);
            // 
            // rbSelf
            // 
            this.rbSelf.AutoSize = true;
            this.rbSelf.BackColor = System.Drawing.Color.Transparent;
            this.rbSelf.Checked = true;
            this.rbSelf.Location = new System.Drawing.Point(146, 12);
            this.rbSelf.Name = "rbSelf";
            this.rbSelf.Size = new System.Drawing.Size(47, 16);
            this.rbSelf.TabIndex = 2;
            this.rbSelf.TabStop = true;
            this.rbSelf.Text = "个人";
            this.rbSelf.UseVisualStyleBackColor = false;
            this.rbSelf.CheckedChanged += new System.EventHandler(this.rbSelf_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "请输入模板名称：";
            // 
            // txtModelName
            // 
            this.txtModelName.Location = new System.Drawing.Point(12, 46);
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.Size = new System.Drawing.Size(181, 21);
            this.txtModelName.TabIndex = 4;
            this.txtModelName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtModelName_KeyUp);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(26, 73);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(60, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(125, 73);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(57, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmNewModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(205, 103);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtModelName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbSelf);
            this.Controls.Add(this.rbDept);
            this.Controls.Add(this.rbHospital);
            this.Name = "FrmNewModel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增模板";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbHospital;
        private System.Windows.Forms.RadioButton rbDept;
        private System.Windows.Forms.RadioButton rbSelf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtModelName;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}