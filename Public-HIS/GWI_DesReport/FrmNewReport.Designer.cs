namespace GWI_DesReport
{
    partial class FrmNewReport
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
            this.tb_RptName = new System.Windows.Forms.TextBox();
            this.tb_rptPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_ConnStr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Sql = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bt_Test = new System.Windows.Forms.Button();
            this.bt_Next = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(67, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入报表名称";
            // 
            // tb_RptName
            // 
            this.tb_RptName.Location = new System.Drawing.Point(174, 56);
            this.tb_RptName.Name = "tb_RptName";
            this.tb_RptName.Size = new System.Drawing.Size(342, 21);
            this.tb_RptName.TabIndex = 1;
            // 
            // tb_rptPath
            // 
            this.tb_rptPath.Location = new System.Drawing.Point(174, 94);
            this.tb_rptPath.Name = "tb_rptPath";
            this.tb_rptPath.Size = new System.Drawing.Size(342, 21);
            this.tb_rptPath.TabIndex = 3;
            this.tb_rptPath.Text = "Report/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(67, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "报表默认路径";
            // 
            // tb_ConnStr
            // 
            this.tb_ConnStr.Location = new System.Drawing.Point(174, 134);
            this.tb_ConnStr.Name = "tb_ConnStr";
            this.tb_ConnStr.Size = new System.Drawing.Size(342, 21);
            this.tb_ConnStr.TabIndex = 5;
            this.tb_ConnStr.Text = "Provider=IBMDADB2.1;Password=db2inst2;Persist Security Info=True;User ID=db2inst2" +
                ";Data Source=HIS;Location=192.168.10.60:50000;Mode=ReadWrite";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(67, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "连接数据库路径";
            // 
            // tb_Sql
            // 
            this.tb_Sql.Location = new System.Drawing.Point(174, 176);
            this.tb_Sql.Multiline = true;
            this.tb_Sql.Name = "tb_Sql";
            this.tb_Sql.Size = new System.Drawing.Size(342, 173);
            this.tb_Sql.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(67, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "输入SQL语句";
            // 
            // bt_Test
            // 
            this.bt_Test.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Test.Location = new System.Drawing.Point(70, 370);
            this.bt_Test.Name = "bt_Test";
            this.bt_Test.Size = new System.Drawing.Size(88, 27);
            this.bt_Test.TabIndex = 8;
            this.bt_Test.Text = "测试";
            this.bt_Test.UseVisualStyleBackColor = true;
            // 
            // bt_Next
            // 
            this.bt_Next.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Next.Location = new System.Drawing.Point(299, 370);
            this.bt_Next.Name = "bt_Next";
            this.bt_Next.Size = new System.Drawing.Size(88, 27);
            this.bt_Next.TabIndex = 9;
            this.bt_Next.Text = "下一步";
            this.bt_Next.UseVisualStyleBackColor = true;
            this.bt_Next.Click += new System.EventHandler(this.bt_Next_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(428, 370);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 27);
            this.button3.TabIndex = 10;
            this.button3.Text = "关闭(&C)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(523, 93);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(42, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(523, 174);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(42, 23);
            this.button5.TabIndex = 12;
            this.button5.Text = "高级";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // FrmNewReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 419);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.bt_Next);
            this.Controls.Add(this.bt_Test);
            this.Controls.Add(this.tb_Sql);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_ConnStr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_rptPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_RptName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNewReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建报表";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_RptName;
        private System.Windows.Forms.TextBox tb_rptPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_ConnStr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Sql;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bt_Test;
        private System.Windows.Forms.Button bt_Next;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}