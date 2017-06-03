
namespace HIS_MZManager.ILControl
{
    partial class ILSelectDialog
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( ILSelectDialog ) );
            this.lblName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboChineseIL = new System.Windows.Forms.ComboBox();
            this.cboEnglishIL = new System.Windows.Forms.ComboBox();
            this.btnSave = new GWI.HIS.Windows.Controls.Button();
            this.btnClose = new GWI.HIS.Windows.Controls.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font( "宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            this.lblName.Location = new System.Drawing.Point( 12, 14 );
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size( 64, 16 );
            this.lblName.TabIndex = 0;
            this.lblName.Text = "lblName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point( 12, 42 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 149, 12 );
            this.label1.TabIndex = 1;
            this.label1.Text = "你在本机设置的输入法为：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point( 12, 70 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 29, 12 );
            this.label2.TabIndex = 2;
            this.label2.Text = "中文";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point( 12, 107 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 29, 12 );
            this.label3.TabIndex = 3;
            this.label3.Text = "英文";
            // 
            // cboChineseIL
            // 
            this.cboChineseIL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChineseIL.FormattingEnabled = true;
            this.cboChineseIL.Location = new System.Drawing.Point( 47, 67 );
            this.cboChineseIL.Name = "cboChineseIL";
            this.cboChineseIL.Size = new System.Drawing.Size( 258, 20 );
            this.cboChineseIL.TabIndex = 4;
            // 
            // cboEnglishIL
            // 
            this.cboEnglishIL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEnglishIL.FormattingEnabled = true;
            this.cboEnglishIL.Location = new System.Drawing.Point( 47, 104 );
            this.cboEnglishIL.Name = "cboEnglishIL";
            this.cboEnglishIL.Size = new System.Drawing.Size( 258, 20 );
            this.cboEnglishIL.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.Save;
            this.btnSave.FixedWidth = true;
            this.btnSave.Image = ( (System.Drawing.Image)( resources.GetObject( "btnSave.Image" ) ) );
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point( 75, 138 );
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size( 90, 30 );
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler( this.btnSave_Click );
            // 
            // btnClose
            // 
            this.btnClose.ButtomImageStyle = GWI.HIS.Windows.Controls.ButtomImageStyle.CloseWindow;
            this.btnClose.FixedWidth = true;
            this.btnClose.Image = ( (System.Drawing.Image)( resources.GetObject( "btnClose.Image" ) ) );
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point( 173, 138 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 90, 30 );
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "关闭窗口(&X)";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // ILSelectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 331, 177 );
            this.Controls.Add( this.btnClose );
            this.Controls.Add( this.btnSave );
            this.Controls.Add( this.cboEnglishIL );
            this.Controls.Add( this.cboChineseIL );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.lblName );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ILSelectDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "个人输入法";
            this.Load += new System.EventHandler( this.ILSelectDialog_Load );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboChineseIL;
        private System.Windows.Forms.ComboBox cboEnglishIL;
        private GWI.HIS.Windows.Controls.Button btnSave;
        private GWI.HIS.Windows.Controls.Button btnClose;
    }
}

