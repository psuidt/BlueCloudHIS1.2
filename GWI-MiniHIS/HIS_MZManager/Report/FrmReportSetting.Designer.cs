namespace HIS_MZManager.Report
{
    partial class FrmReportSetting
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
            this.lblReportName = new System.Windows.Forms.Label();
            this.tvwCol = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            this.lvwField = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelCol = new System.Windows.Forms.Button();
            this.btnAddCol = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDesign = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 3, 11 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 53, 12 );
            this.label1.TabIndex = 0;
            this.label1.Text = "报表名：";
            // 
            // lblReportName
            // 
            this.lblReportName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblReportName.Location = new System.Drawing.Point( 62, 7 );
            this.lblReportName.Name = "lblReportName";
            this.lblReportName.Size = new System.Drawing.Size( 396, 20 );
            this.lblReportName.TabIndex = 1;
            this.lblReportName.Text = "label2";
            this.lblReportName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tvwCol
            // 
            this.tvwCol.Font = new System.Drawing.Font( "宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            this.tvwCol.HideSelection = false;
            this.tvwCol.Location = new System.Drawing.Point( 5, 60 );
            this.tvwCol.Name = "tvwCol";
            this.tvwCol.Size = new System.Drawing.Size( 208, 376 );
            this.tvwCol.TabIndex = 2;
            this.tvwCol.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler( this.tvwCol_AfterLabelEdit );
            this.tvwCol.DoubleClick += new System.EventHandler( this.tvwCol_DoubleClick );
            this.tvwCol.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.tvwCol_AfterSelect );
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point( 3, 38 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 65, 12 );
            this.label3.TabIndex = 3;
            this.label3.Text = "报表打印列";
            // 
            // lvwField
            // 
            this.lvwField.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1} );
            this.lvwField.Font = new System.Drawing.Font( "宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
            this.lvwField.HideSelection = false;
            this.lvwField.Location = new System.Drawing.Point( 267, 60 );
            this.lvwField.Name = "lvwField";
            this.lvwField.Size = new System.Drawing.Size( 191, 376 );
            this.lvwField.TabIndex = 4;
            this.lvwField.UseCompatibleStateImageBehavior = false;
            this.lvwField.View = System.Windows.Forms.View.Details;
            this.lvwField.DoubleClick += new System.EventHandler( this.lvwField_DoubleClick );
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "列名称";
            this.columnHeader1.Width = 144;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point( 265, 38 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 41, 12 );
            this.label4.TabIndex = 5;
            this.label4.Text = "字段列";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add( this.label1 );
            this.panel1.Controls.Add( this.lblReportName );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point( 0, 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 470, 32 );
            this.panel1.TabIndex = 6;
            // 
            // btnDelCol
            // 
            this.btnDelCol.Location = new System.Drawing.Point( 219, 413 );
            this.btnDelCol.Name = "btnDelCol";
            this.btnDelCol.Size = new System.Drawing.Size( 38, 23 );
            this.btnDelCol.TabIndex = 1;
            this.btnDelCol.Text = "删除列";
            this.btnDelCol.UseVisualStyleBackColor = true;
            this.btnDelCol.Click += new System.EventHandler( this.btnDelCol_Click );
            // 
            // btnAddCol
            // 
            this.btnAddCol.Location = new System.Drawing.Point( 219, 353 );
            this.btnAddCol.Name = "btnAddCol";
            this.btnAddCol.Size = new System.Drawing.Size( 38, 23 );
            this.btnAddCol.TabIndex = 0;
            this.btnAddCol.Text = "新增列";
            this.btnAddCol.UseVisualStyleBackColor = true;
            this.btnAddCol.Click += new System.EventHandler( this.btnAddCol_Click );
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point( 219, 69 );
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size( 38, 23 );
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "<<";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler( this.btnAdd_Click );
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point( 219, 108 );
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size( 38, 23 );
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = ">>";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler( this.btnRemove_Click );
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point( 300, 462 );
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size( 76, 23 );
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler( this.btnSave_Click );
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point( 382, 462 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 76, 23 );
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // btnDesign
            // 
            this.btnDesign.Enabled = false;
            this.btnDesign.Location = new System.Drawing.Point( 341, 503 );
            this.btnDesign.Name = "btnDesign";
            this.btnDesign.Size = new System.Drawing.Size( 76, 23 );
            this.btnDesign.TabIndex = 12;
            this.btnDesign.Text = "设计器";
            this.btnDesign.UseVisualStyleBackColor = true;
            this.btnDesign.Visible = false;
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point( 219, 204 );
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size( 38, 23 );
            this.btnDown.TabIndex = 14;
            this.btnDown.Text = "▼";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler( this.btnDown_Click );
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point( 219, 165 );
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size( 38, 23 );
            this.btnUp.TabIndex = 13;
            this.btnUp.Text = "▲";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler( this.btnUp_Click );
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point( 219, 382 );
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size( 38, 23 );
            this.btnEdit.TabIndex = 15;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler( this.btnEdit_Click );
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Location = new System.Drawing.Point( 8, 445 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 452, 8 );
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point( 12, 462 );
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size( 27, 22 );
            this.button1.TabIndex = 17;
            this.button1.Text = "？";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler( this.button1_Click );
            // 
            // FrmReportSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size( 470, 497 );
            this.Controls.Add( this.button1 );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.btnEdit );
            this.Controls.Add( this.btnDown );
            this.Controls.Add( this.btnUp );
            this.Controls.Add( this.btnDelCol );
            this.Controls.Add( this.btnDesign );
            this.Controls.Add( this.btnAddCol );
            this.Controls.Add( this.btnClose );
            this.Controls.Add( this.btnSave );
            this.Controls.Add( this.btnRemove );
            this.Controls.Add( this.btnAdd );
            this.Controls.Add( this.panel1 );
            this.Controls.Add( this.label4 );
            this.Controls.Add( this.lvwField );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.tvwCol );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReportSetting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "报表打印列设置";
            this.Load += new System.EventHandler( this.FrmReportSetting_Load );
            this.panel1.ResumeLayout( false );
            this.panel1.PerformLayout();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblReportName;
        private System.Windows.Forms.TreeView tvwCol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvwField;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDelCol;
        private System.Windows.Forms.Button btnAddCol;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDesign;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
    }
}