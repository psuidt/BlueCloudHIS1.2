namespace HIS_ZYDocManager.日常业务
{
    partial class FrmStop
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
            this.NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.radAlter = new System.Windows.Forms.RadioButton();
            this.radDefault = new System.Windows.Forms.RadioButton();
            this.btnYes = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // NumUpDown
            // 
            this.NumUpDown.Enabled = false;
            this.NumUpDown.Location = new System.Drawing.Point(162, 48);
            this.NumUpDown.Name = "NumUpDown";
            this.NumUpDown.Size = new System.Drawing.Size(34, 21);
            this.NumUpDown.TabIndex = 21;
            // 
            // radAlter
            // 
            this.radAlter.AutoSize = true;
            this.radAlter.BackColor = System.Drawing.Color.Transparent;
            this.radAlter.Location = new System.Drawing.Point(97, 48);
            this.radAlter.Name = "radAlter";
            this.radAlter.Size = new System.Drawing.Size(59, 16);
            this.radAlter.TabIndex = 18;
            this.radAlter.Text = "修改值";
            this.radAlter.UseVisualStyleBackColor = false;
            // 
            // radDefault
            // 
            this.radDefault.AutoSize = true;
            this.radDefault.BackColor = System.Drawing.Color.Transparent;
            this.radDefault.Checked = true;
            this.radDefault.Location = new System.Drawing.Point(21, 48);
            this.radDefault.Name = "radDefault";
            this.radDefault.Size = new System.Drawing.Size(59, 16);
            this.radDefault.TabIndex = 17;
            this.radDefault.TabStop = true;
            this.radDefault.Text = "默认值";
            this.radDefault.UseVisualStyleBackColor = false;
            this.radDefault.CheckedChanged += new System.EventHandler(this.radDefault_CheckedChanged);
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(58, 70);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(63, 21);
            this.btnYes.TabIndex = 14;
            this.btnYes.Text = "确 定";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(19, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "末日执行次数：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(19, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "确定停医嘱";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Window;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(97, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "√";
            // 
            // FrmStop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(206, 100);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NumUpDown);
            this.Controls.Add(this.radAlter);
            this.Controls.Add(this.radDefault);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmStop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "停嘱";
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown NumUpDown;
        private System.Windows.Forms.RadioButton radAlter;
        private System.Windows.Forms.RadioButton radDefault;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}