namespace HIS_PublicManager.SystemTool.GenerateEntityXML
{
    partial class FrmMain
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.选择DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.序号DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.列名DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数据类型DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.主键DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.外键DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.关联外键 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tableesBindingSource = new System.Windows.Forms.BindingSource( this.components );
            this.dataSet1 = new GenerateEntityXML.DataSet1();
            this.列名ssss = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tablefieldBindingSource1 = new System.Windows.Forms.BindingSource( this.components );
            this.tablefieldBindingSource = new System.Windows.Forms.BindingSource( this.components );
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnCreatEntityFile = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.dataGridView1 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tableesBindingSource ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.dataSet1 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tablefieldBindingSource1 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tablefieldBindingSource ) ).BeginInit();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point( 0, 0 );
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add( this.panel4 );
            this.splitContainer1.Panel1.Controls.Add( this.panel3 );
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add( this.panel2 );
            this.splitContainer1.Panel2.Controls.Add( this.panel1 );
            this.splitContainer1.Size = new System.Drawing.Size( 1016, 734 );
            this.splitContainer1.SplitterDistance = 193;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add( this.listView1 );
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point( 0, 10 );
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size( 193, 724 );
            this.panel4.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2} );
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point( 0, 0 );
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size( 193, 724 );
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler( this.listView1_SelectedIndexChanged );
            this.listView1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler( this.listView1_ItemCheck );
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "表名";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "类型";
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point( 0, 0 );
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size( 193, 10 );
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add( this.dataGridView1 );
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point( 0, 96 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 819, 638 );
            this.panel2.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.选择DataGridViewTextBoxColumn,
            this.序号DataGridViewTextBoxColumn,
            this.列名DataGridViewTextBoxColumn,
            this.数据类型DataGridViewTextBoxColumn,
            this.主键DataGridViewTextBoxColumn,
            this.外键DataGridViewTextBoxColumn,
            this.关联外键,
            this.列名ssss} );
            this.dataGridView1.DataSource = this.tablefieldBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point( 0, 0 );
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size( 819, 638 );
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler( this.dataGridView1_EditingControlShowing );
            this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler( this.dataGridView1_CurrentCellDirtyStateChanged );
            // 
            // 选择DataGridViewTextBoxColumn
            // 
            this.选择DataGridViewTextBoxColumn.DataPropertyName = "选择";
            this.选择DataGridViewTextBoxColumn.HeaderText = "选择";
            this.选择DataGridViewTextBoxColumn.Name = "选择DataGridViewTextBoxColumn";
            this.选择DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.选择DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.选择DataGridViewTextBoxColumn.Width = 70;
            // 
            // 序号DataGridViewTextBoxColumn
            // 
            this.序号DataGridViewTextBoxColumn.DataPropertyName = "序号";
            this.序号DataGridViewTextBoxColumn.HeaderText = "序号";
            this.序号DataGridViewTextBoxColumn.Name = "序号DataGridViewTextBoxColumn";
            this.序号DataGridViewTextBoxColumn.ReadOnly = true;
            this.序号DataGridViewTextBoxColumn.Width = 60;
            // 
            // 列名DataGridViewTextBoxColumn
            // 
            this.列名DataGridViewTextBoxColumn.DataPropertyName = "列名";
            this.列名DataGridViewTextBoxColumn.HeaderText = "列名";
            this.列名DataGridViewTextBoxColumn.Name = "列名DataGridViewTextBoxColumn";
            this.列名DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 数据类型DataGridViewTextBoxColumn
            // 
            this.数据类型DataGridViewTextBoxColumn.DataPropertyName = "数据类型";
            this.数据类型DataGridViewTextBoxColumn.HeaderText = "数据类型";
            this.数据类型DataGridViewTextBoxColumn.Name = "数据类型DataGridViewTextBoxColumn";
            this.数据类型DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 主键DataGridViewTextBoxColumn
            // 
            this.主键DataGridViewTextBoxColumn.DataPropertyName = "主键";
            this.主键DataGridViewTextBoxColumn.HeaderText = "主键";
            this.主键DataGridViewTextBoxColumn.Name = "主键DataGridViewTextBoxColumn";
            this.主键DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.主键DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.主键DataGridViewTextBoxColumn.Width = 70;
            // 
            // 外键DataGridViewTextBoxColumn
            // 
            this.外键DataGridViewTextBoxColumn.DataPropertyName = "外键";
            this.外键DataGridViewTextBoxColumn.HeaderText = "外键";
            this.外键DataGridViewTextBoxColumn.Name = "外键DataGridViewTextBoxColumn";
            this.外键DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.外键DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.外键DataGridViewTextBoxColumn.Width = 70;
            // 
            // 关联外键
            // 
            this.关联外键.DataPropertyName = "关联外键(表)";
            this.关联外键.DataSource = this.tableesBindingSource;
            this.关联外键.DisplayMember = "表名";
            this.关联外键.HeaderText = "关联外键(表)";
            this.关联外键.Name = "关联外键";
            this.关联外键.ValueMember = "表名";
            this.关联外键.Width = 150;
            // 
            // tableesBindingSource
            // 
            this.tableesBindingSource.DataMember = "Tablees";
            this.tableesBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // 列名ssss
            // 
            this.列名ssss.DataPropertyName = "关联外键(字段)";
            this.列名ssss.DataSource = this.tablefieldBindingSource1;
            this.列名ssss.DisplayMember = "列名";
            this.列名ssss.HeaderText = "关联外键(字段)";
            this.列名ssss.Name = "列名ssss";
            this.列名ssss.ValueMember = "列名";
            this.列名ssss.Width = 150;
            // 
            // tablefieldBindingSource1
            // 
            this.tablefieldBindingSource1.DataMember = "Table_field";
            this.tablefieldBindingSource1.DataSource = this.dataSet1;
            // 
            // tablefieldBindingSource
            // 
            this.tablefieldBindingSource.DataMember = "Table_field";
            this.tablefieldBindingSource.DataSource = this.dataSet1;
            this.tablefieldBindingSource.Filter = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.panel6 );
            this.panel1.Controls.Add( this.panel5 );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point( 0, 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 819, 96 );
            this.panel1.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add( this.tabControl1 );
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point( 0, 0 );
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size( 819, 70 );
            this.panel6.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add( this.tabPage1 );
            this.tabControl1.Controls.Add( this.tabPage2 );
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point( 0, 0 );
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size( 819, 70 );
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add( this.textBox1 );
            this.tabPage1.Controls.Add( this.button1 );
            this.tabPage1.Location = new System.Drawing.Point( 4, 21 );
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage1.Size = new System.Drawing.Size( 811, 45 );
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "实体";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point( 16, 8 );
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size( 375, 21 );
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point( 397, 6 );
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size( 90, 23 );
            this.button1.TabIndex = 1;
            this.button1.Text = "选择程序集";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler( this.button1_Click );
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add( this.button4 );
            this.tabPage2.Controls.Add( this.textBox2 );
            this.tabPage2.Controls.Add( this.comboBox1 );
            this.tabPage2.Location = new System.Drawing.Point( 4, 21 );
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage2.Size = new System.Drawing.Size( 811, 45 );
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "数据库";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point( 656, 9 );
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size( 75, 23 );
            this.button4.TabIndex = 2;
            this.button4.Text = "连接数据库";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler( this.button4_Click );
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point( 145, 9 );
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size( 495, 21 );
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "Provider=IBMDADB2;Database=WEBHIS;HostName=192.168.10.60;Protocol=tcpip;Port=5000" +
                "0;User ID=DB2inst2;Password=db2inst2";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange( new object[] {
            "DB2",
            "SQLServer2000",
            "SQLServer2005",
            "Oracle",
            "MySQL",
            "MSAccess"} );
            this.comboBox1.Location = new System.Drawing.Point( 18, 9 );
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size( 121, 20 );
            this.comboBox1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add( this.btnCreatEntityFile );
            this.panel5.Controls.Add( this.checkBox3 );
            this.panel5.Controls.Add( this.button2 );
            this.panel5.Controls.Add( this.checkBox1 );
            this.panel5.Controls.Add( this.checkBox2 );
            this.panel5.Controls.Add( this.button3 );
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point( 0, 70 );
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size( 819, 26 );
            this.panel5.TabIndex = 6;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point( 222, 8 );
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size( 84, 16 );
            this.checkBox3.TabIndex = 6;
            this.checkBox3.Text = "是否为国标";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler( this.checkBox3_CheckedChanged );
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point( 569, 0 );
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size( 75, 23 );
            this.button2.TabIndex = 2;
            this.button2.Text = "生成";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler( this.button2_Click );
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point( 3, 8 );
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size( 60, 16 );
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "全选表";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler( this.checkBox1_CheckedChanged );
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point( 125, 8 );
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size( 60, 16 );
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "全选列";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler( this.checkBox2_CheckedChanged );
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point( 660, 0 );
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size( 75, 23 );
            this.button3.TabIndex = 5;
            this.button3.Text = "全置空";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler( this.button3_Click );
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnCreatEntityFile
            // 
            this.btnCreatEntityFile.Location = new System.Drawing.Point( 437, 0 );
            this.btnCreatEntityFile.Name = "btnCreatEntityFile";
            this.btnCreatEntityFile.Size = new System.Drawing.Size( 115, 23 );
            this.btnCreatEntityFile.TabIndex = 7;
            this.btnCreatEntityFile.Text = "生成表实体文件";
            this.btnCreatEntityFile.UseVisualStyleBackColor = true;
            this.btnCreatEntityFile.Click += new System.EventHandler( this.btnCreatEntityFile_Click );
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 1016, 734 );
            this.Controls.Add( this.splitContainer1 );
            this.Name = "FrmMain";
            this.Text = "生成配置文件";
            this.splitContainer1.Panel1.ResumeLayout( false );
            this.splitContainer1.Panel2.ResumeLayout( false );
            this.splitContainer1.ResumeLayout( false );
            this.panel4.ResumeLayout( false );
            this.panel2.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.dataGridView1 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tableesBindingSource ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.dataSet1 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tablefieldBindingSource1 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tablefieldBindingSource ) ).EndInit();
            this.panel1.ResumeLayout( false );
            this.panel6.ResumeLayout( false );
            this.tabControl1.ResumeLayout( false );
            this.tabPage1.ResumeLayout( false );
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout( false );
            this.tabPage2.PerformLayout();
            this.panel5.ResumeLayout( false );
            this.panel5.PerformLayout();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.BindingSource tablefieldBindingSource;
        private DataSet1 dataSet1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.BindingSource tablefieldBindingSource1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.BindingSource tableesBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 选择DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 列名DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数据类型DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 主键DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 外键DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn 关联外键;
        private System.Windows.Forms.DataGridViewComboBoxColumn 列名ssss;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Button btnCreatEntityFile;
    }
}