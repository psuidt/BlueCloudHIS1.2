namespace HIS_BaseManager
{
    partial class FrmParameterSet
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmParameterSet ) );
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tvwModels = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList( this.components );
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.plUI = new System.Windows.Forms.Panel();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.plBaseToolbar.SuspendLayout();
            this.plBaseWorkArea.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.Controls.Add( this.chkAll );
            this.plBaseToolbar.Controls.Add( this.btnClose );
            this.plBaseToolbar.Controls.Add( this.btnRefresh );
            this.plBaseToolbar.Controls.Add( this.btnSave );
            this.plBaseToolbar.Controls.Add( this.btnCheck );
            this.plBaseToolbar.Size = new System.Drawing.Size( 900, 30 );
            // 
            // baseImageList
            // 
            this.baseImageList.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "baseImageList.ImageStream" ) ) );
            this.baseImageList.Images.SetKeyName( 0, "table_delete.gif" );
            this.baseImageList.Images.SetKeyName( 1, "search_big.GIF" );
            this.baseImageList.Images.SetKeyName( 2, "Save.GIF" );
            this.baseImageList.Images.SetKeyName( 3, "Print.GIF" );
            this.baseImageList.Images.SetKeyName( 4, "page_user_dark.gif" );
            this.baseImageList.Images.SetKeyName( 5, "page_refresh.gif" );
            this.baseImageList.Images.SetKeyName( 6, "page_key.gif" );
            this.baseImageList.Images.SetKeyName( 7, "page_edit.gif" );
            this.baseImageList.Images.SetKeyName( 8, "page_cross.gif" );
            this.baseImageList.Images.SetKeyName( 9, "list_users.gif" );
            this.baseImageList.Images.SetKeyName( 10, "icon_package_get.gif" );
            this.baseImageList.Images.SetKeyName( 11, "icon_network.gif" );
            this.baseImageList.Images.SetKeyName( 12, "icon_history.gif" );
            this.baseImageList.Images.SetKeyName( 13, "icon_accept.gif" );
            this.baseImageList.Images.SetKeyName( 14, "folder_page.gif" );
            this.baseImageList.Images.SetKeyName( 15, "folder_new.gif" );
            this.baseImageList.Images.SetKeyName( 16, "Exit.GIF" );
            this.baseImageList.Images.SetKeyName( 17, "Delete.GIF" );
            this.baseImageList.Images.SetKeyName( 18, "copy.gif" );
            this.baseImageList.Images.SetKeyName( 19, "action_stop.gif" );
            this.baseImageList.Images.SetKeyName( 20, "action_refresh.gif" );
            // 
            // plBaseStatus
            // 
            this.plBaseStatus.Location = new System.Drawing.Point( 0, 528 );
            this.plBaseStatus.Size = new System.Drawing.Size( 900, 0 );
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add( this.groupBox2 );
            this.plBaseWorkArea.Controls.Add( this.groupBox1 );
            this.plBaseWorkArea.Location = new System.Drawing.Point( 0, 64 );
            this.plBaseWorkArea.Size = new System.Drawing.Size( 900, 464 );
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.tvwModels );
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point( 0, 0 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 244, 464 );
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "分类";
            // 
            // tvwModels
            // 
            this.tvwModels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwModels.HideSelection = false;
            this.tvwModels.ImageIndex = 0;
            this.tvwModels.ImageList = this.imageList1;
            this.tvwModels.Indent = 40;
            this.tvwModels.Location = new System.Drawing.Point( 3, 17 );
            this.tvwModels.Name = "tvwModels";
            this.tvwModels.SelectedImageIndex = 0;
            this.tvwModels.Size = new System.Drawing.Size( 238, 444 );
            this.tvwModels.TabIndex = 0;
            this.tvwModels.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.tvwModels_AfterSelect );
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "imageList1.ImageStream" ) ) );
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName( 0, "FLD302.ICO" );
            this.imageList1.Images.SetKeyName( 1, "Blueberry.ico" );
            this.imageList1.Images.SetKeyName( 2, "Pencil.ico" );
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add( this.plUI );
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point( 244, 0 );
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size( 656, 464 );
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "详细参数设置";
            // 
            // plUI
            // 
            this.plUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plUI.Location = new System.Drawing.Point( 3, 17 );
            this.plUI.Name = "plUI";
            this.plUI.Size = new System.Drawing.Size( 650, 444 );
            this.plUI.TabIndex = 0;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point( 3, 2 );
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size( 79, 25 );
            this.btnCheck.TabIndex = 0;
            this.btnCheck.Text = "参数校验";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler( this.btnCheck_Click );
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point( 88, 2 );
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size( 79, 25 );
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler( this.btnSave_Click );
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point( 431, 2 );
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size( 79, 25 );
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler( this.btnRefresh_Click );
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point( 516, 2 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 79, 25 );
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point( 173, 7 );
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size( 252, 16 );
            this.chkAll.TabIndex = 4;
            this.chkAll.Text = "全部(不选则只保存对当前分类做所的修改)";
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // FrmParameterSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 900, 528 );
            this.Name = "FrmParameterSet";
            this.Text = "FrmParameterSet";
            this.Load += new System.EventHandler( this.FrmParameterSet_Load );
            this.plBaseToolbar.ResumeLayout( false );
            this.plBaseToolbar.PerformLayout();
            this.plBaseWorkArea.ResumeLayout( false );
            this.groupBox1.ResumeLayout( false );
            this.groupBox2.ResumeLayout( false );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView tvwModels;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel plUI;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkAll;
    }
}