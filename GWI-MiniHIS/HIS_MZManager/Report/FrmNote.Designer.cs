namespace HIS_MZManager.Report
{
    partial class FrmNote
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
                components.Dispose();
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point( 12, 9 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 65, 12 );
            this.label1.TabIndex = 0;
            this.label1.Text = "报表打印列";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point( 36, 31 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 293, 12 );
            this.label2.TabIndex = 1;
            this.label2.Text = "打印或设计报表时，报表的列由定义的报表打印列决定";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point( 12, 58 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 41, 12 );
            this.label3.TabIndex = 2;
            this.label3.Text = "你可以";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point( 44, 89 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 269, 12 );
            this.label4.TabIndex = 3;
            this.label4.Text = "通过新增、删除、修改按钮对报表打印列进行修改";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point( 44, 117 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 149, 12 );
            this.label5.TabIndex = 4;
            this.label5.Text = "通过【▲】【▼】进行排序";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point( 44, 145 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 257, 12 );
            this.label6.TabIndex = 5;
            this.label6.Text = "通过【<<】【>>】增加或移除该列所包含的项目";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Location = new System.Drawing.Point( 319, 165 );
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size( 29, 12 );
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "关闭";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.linkLabel1_LinkClicked );
            // 
            // FrmNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 365, 186 );
            this.Controls.Add( this.linkLabel1 );
            this.Controls.Add( this.label6 );
            this.Controls.Add( this.label5 );
            this.Controls.Add( this.label4 );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNote";
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}