namespace HIS_BaseManager
{
    partial class FrmLayerAttr
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLayerName = new System.Windows.Forms.TextBox();
            this.txtParentLayer = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSelectLayer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point( 41, 89 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 53, 12 );
            this.label1.TabIndex = 0;
            this.label1.Text = "上级层次";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point( 41, 38 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 53, 12 );
            this.label2.TabIndex = 1;
            this.label2.Text = "层次名称";
            // 
            // txtLayerName
            // 
            this.txtLayerName.Location = new System.Drawing.Point( 100, 35 );
            this.txtLayerName.Name = "txtLayerName";
            this.txtLayerName.Size = new System.Drawing.Size( 175, 21 );
            this.txtLayerName.TabIndex = 2;
            this.txtLayerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtLayerName_KeyPress );
            // 
            // txtParentLayer
            // 
            this.txtParentLayer.Location = new System.Drawing.Point( 100, 86 );
            this.txtParentLayer.Name = "txtParentLayer";
            this.txtParentLayer.Size = new System.Drawing.Size( 138, 21 );
            this.txtParentLayer.TabIndex = 3;
            this.txtParentLayer.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtParentLayer_KeyPress );
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point( 100, 130 );
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size( 75, 23 );
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "确定(&S)";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler( this.btnOk_Click );
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point( 200, 130 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 75, 23 );
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "关闭(&X)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler( this.btnCancel_Click );
            // 
            // btnSelectLayer
            // 
            this.btnSelectLayer.Location = new System.Drawing.Point( 240, 85 );
            this.btnSelectLayer.Name = "btnSelectLayer";
            this.btnSelectLayer.Size = new System.Drawing.Size( 40, 23 );
            this.btnSelectLayer.TabIndex = 6;
            this.btnSelectLayer.Text = "..";
            this.btnSelectLayer.UseVisualStyleBackColor = true;
            this.btnSelectLayer.Click += new System.EventHandler( this.btnSelectLayer_Click );
            // 
            // FrmLayerAttr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 333, 178 );
            this.Controls.Add( this.btnSelectLayer );
            this.Controls.Add( this.btnCancel );
            this.Controls.Add( this.btnOk );
            this.Controls.Add( this.txtParentLayer );
            this.Controls.Add( this.txtLayerName );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLayerAttr";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "增加层次";
            this.Load += new System.EventHandler( this.FrmLayerAttr_Load );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLayerName;
        private System.Windows.Forms.TextBox txtParentLayer;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSelectLayer;
    }
}