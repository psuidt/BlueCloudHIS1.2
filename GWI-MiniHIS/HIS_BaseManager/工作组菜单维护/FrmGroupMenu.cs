using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using HIS.SYSTEM.PubicBaseClasses;
using GWMHIS.BussinessLogicLayer.Classes;
using GWMHIS.BussinessLogicLayer.Forms;

namespace HIS_BaseManager
{
	public struct Module
	{
		public long ID;
		public string Name;
	}
	public struct MenuInfo
	{
		public bool IsModule;
		public long ModuleID;
		public long ParentMenuID;
		public long MenuID;
		public string MenuName;
		public string FunctionName;
		public string DllName;
		public bool IsSystemMenu;
		public string Memo;
	}
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
    public class FrmGroupMenu : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ImageList imageList2;
		private System.Windows.Forms.ContextMenu mnuSelect;
		private System.Windows.Forms.MenuItem mnuSelectAll;
        private System.Windows.Forms.MenuItem mnuUnSelectAll;
        private GWI.HIS.Windows.Controls.ToolStrip toolStrip1;
        private Panel panel1;
        private TreeView tvwMenu;
        private Splitter splitter1;
        private ListView lstGroup;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ToolStripButton btnAddGroup;
        private ToolStripButton btnSave;
        private ToolStripButton btnDeleteGroup;
        private ToolStripButton btnRefresh;
        private ToolStripButton btnExit;
        private ToolStripButton btnEditGroup;
		private System.ComponentModel.IContainer components;

        public FrmGroupMenu( long currentUserId , long currentDeptId , string formText )
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			InitMenuTree();
			InitGroups();
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container( );
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmGroupMenu ) );
            this.imageList2 = new System.Windows.Forms.ImageList( this.components );
            this.imageList1 = new System.Windows.Forms.ImageList( this.components );
            this.panel2 = new System.Windows.Forms.Panel( );
            this.mnuSelect = new System.Windows.Forms.ContextMenu( );
            this.mnuSelectAll = new System.Windows.Forms.MenuItem( );
            this.mnuUnSelectAll = new System.Windows.Forms.MenuItem( );
            this.tvwMenu = new System.Windows.Forms.TreeView( );
            this.lstGroup = new System.Windows.Forms.ListView( );
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader( );
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader( );
            this.splitter1 = new System.Windows.Forms.Splitter( );
            this.panel1 = new System.Windows.Forms.Panel( );
            this.toolStrip1 = new GWI.HIS.Windows.Controls.ToolStrip( );
            this.btnAddGroup = new System.Windows.Forms.ToolStripButton( );
            this.btnSave = new System.Windows.Forms.ToolStripButton( );
            this.btnEditGroup = new System.Windows.Forms.ToolStripButton( );
            this.btnDeleteGroup = new System.Windows.Forms.ToolStripButton( );
            this.btnRefresh = new System.Windows.Forms.ToolStripButton( );
            this.btnExit = new System.Windows.Forms.ToolStripButton( );
            this.plBaseToolbar.SuspendLayout( );
            this.plBaseWorkArea.SuspendLayout( );
            this.panel1.SuspendLayout( );
            this.toolStrip1.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // plBaseToolbar
            // 
            this.plBaseToolbar.BackColor = System.Drawing.SystemColors.Control;
            this.plBaseToolbar.Controls.Add( this.toolStrip1 );
            this.plBaseToolbar.Size = new System.Drawing.Size( 864 , 29 );
            // 
            // baseImageList
            // 
            this.baseImageList.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "baseImageList.ImageStream" ) ) );
            this.baseImageList.Images.SetKeyName( 0 , "table_delete.gif" );
            this.baseImageList.Images.SetKeyName( 1 , "search_big.GIF" );
            this.baseImageList.Images.SetKeyName( 2 , "Save.GIF" );
            this.baseImageList.Images.SetKeyName( 3 , "Print.GIF" );
            this.baseImageList.Images.SetKeyName( 4 , "page_user_dark.gif" );
            this.baseImageList.Images.SetKeyName( 5 , "page_refresh.gif" );
            this.baseImageList.Images.SetKeyName( 6 , "page_key.gif" );
            this.baseImageList.Images.SetKeyName( 7 , "page_edit.gif" );
            this.baseImageList.Images.SetKeyName( 8 , "page_cross.gif" );
            this.baseImageList.Images.SetKeyName( 9 , "list_users.gif" );
            this.baseImageList.Images.SetKeyName( 10 , "icon_package_get.gif" );
            this.baseImageList.Images.SetKeyName( 11 , "icon_network.gif" );
            this.baseImageList.Images.SetKeyName( 12 , "icon_history.gif" );
            this.baseImageList.Images.SetKeyName( 13 , "icon_accept.gif" );
            this.baseImageList.Images.SetKeyName( 14 , "folder_page.gif" );
            this.baseImageList.Images.SetKeyName( 15 , "folder_new.gif" );
            this.baseImageList.Images.SetKeyName( 16 , "Exit.GIF" );
            this.baseImageList.Images.SetKeyName( 17 , "Delete.GIF" );
            this.baseImageList.Images.SetKeyName( 18 , "copy.gif" );
            this.baseImageList.Images.SetKeyName( 19 , "action_stop.gif" );
            this.baseImageList.Images.SetKeyName( 20 , "action_refresh.gif" );
            // 
            // plBaseStatus
            // 
            this.plBaseStatus.Location = new System.Drawing.Point( 0 , 431 );
            this.plBaseStatus.Size = new System.Drawing.Size( 864 , 26 );
            // 
            // plBaseWorkArea
            // 
            this.plBaseWorkArea.Controls.Add( this.panel1 );
            this.plBaseWorkArea.Controls.Add( this.splitter1 );
            this.plBaseWorkArea.Controls.Add( this.lstGroup );
            this.plBaseWorkArea.Size = new System.Drawing.Size( 864 , 368 );
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "imageList2.ImageStream" ) ) );
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName( 0 , "" );
            this.imageList2.Images.SetKeyName( 1 , "" );
            this.imageList2.Images.SetKeyName( 2 , "" );
            this.imageList2.Images.SetKeyName( 3 , "删除.ico" );
            this.imageList2.Images.SetKeyName( 4 , "新增.ico" );
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "imageList1.ImageStream" ) ) );
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName( 0 , "" );
            this.imageList1.Images.SetKeyName( 1 , "" );
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point( 0 , 34 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 864 , 423 );
            this.panel2.TabIndex = 5;
            // 
            // mnuSelect
            // 
            this.mnuSelect.MenuItems.AddRange( new System.Windows.Forms.MenuItem[] {
            this.mnuSelectAll,
            this.mnuUnSelectAll} );
            // 
            // mnuSelectAll
            // 
            this.mnuSelectAll.Index = 0;
            this.mnuSelectAll.Text = "全选";
            this.mnuSelectAll.Click += new System.EventHandler( this.mnuSelectAll_Click );
            // 
            // mnuUnSelectAll
            // 
            this.mnuUnSelectAll.Index = 1;
            this.mnuUnSelectAll.Text = "取消全选";
            this.mnuUnSelectAll.Click += new System.EventHandler( this.mnuUnSelectAll_Click );
            // 
            // tvwMenu
            // 
            this.tvwMenu.CheckBoxes = true;
            this.tvwMenu.ContextMenu = this.mnuSelect;
            this.tvwMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwMenu.Font = new System.Drawing.Font( "宋体" , 11F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.tvwMenu.FullRowSelect = true;
            this.tvwMenu.ImageIndex = 0;
            this.tvwMenu.ImageList = this.imageList1;
            this.tvwMenu.Location = new System.Drawing.Point( 0 , 0 );
            this.tvwMenu.Name = "tvwMenu";
            this.tvwMenu.SelectedImageIndex = 0;
            this.tvwMenu.Size = new System.Drawing.Size( 478 , 368 );
            this.tvwMenu.TabIndex = 1;
            // 
            // lstGroup
            // 
            this.lstGroup.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2} );
            this.lstGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstGroup.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lstGroup.FullRowSelect = true;
            this.lstGroup.HideSelection = false;
            this.lstGroup.LargeImageList = this.imageList1;
            this.lstGroup.Location = new System.Drawing.Point( 0 , 0 );
            this.lstGroup.MultiSelect = false;
            this.lstGroup.Name = "lstGroup";
            this.lstGroup.Size = new System.Drawing.Size( 383 , 368 );
            this.lstGroup.SmallImageList = this.imageList1;
            this.lstGroup.TabIndex = 2;
            this.lstGroup.UseCompatibleStateImageBehavior = false;
            this.lstGroup.View = System.Windows.Forms.View.Details;
            this.lstGroup.SelectedIndexChanged += new System.EventHandler( this.lstGroup_SelectedIndexChanged );
            this.lstGroup.DoubleClick += new System.EventHandler( this.lstGroup_DoubleClick );
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "工作组名称";
            this.columnHeader1.Width = 199;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "描述";
            this.columnHeader2.Width = 172;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point( 383 , 0 );
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size( 3 , 368 );
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.tvwMenu );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point( 386 , 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 478 , 368 );
            this.panel1.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.BackgroundImage = ( (System.Drawing.Image)( resources.GetObject( "toolStrip1.BackgroundImage" ) ) );
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Font = new System.Drawing.Font( "宋体" , 10F );
            this.toolStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.btnAddGroup,
            this.btnSave,
            this.btnEditGroup,
            this.btnDeleteGroup,
            this.btnRefresh,
            this.btnExit} );
            this.toolStrip1.Location = new System.Drawing.Point( 0 , 0 );
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size( 864 , 29 );
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Image = global::HIS_BaseManager.Properties.Resources.新建;
            this.btnAddGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size( 55 , 26 );
            this.btnAddGroup.Text = "新增";
            this.btnAddGroup.Click += new System.EventHandler( this.btnAddGroup_Click );
            // 
            // btnSave
            // 
            this.btnSave.Image = global::HIS_BaseManager.Properties.Resources.保存;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size( 55 , 26 );
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler( this.btnSave_Click );
            // 
            // btnEditGroup
            // 
            this.btnEditGroup.Image = ( (System.Drawing.Image)( resources.GetObject( "btnEditGroup.Image" ) ) );
            this.btnEditGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditGroup.Name = "btnEditGroup";
            this.btnEditGroup.Size = new System.Drawing.Size( 55 , 26 );
            this.btnEditGroup.Text = "修改";
            this.btnEditGroup.Click += new System.EventHandler( this.btnEditGroup_Click );
            // 
            // btnDeleteGroup
            // 
            this.btnDeleteGroup.Image = global::HIS_BaseManager.Properties.Resources.删除报表;
            this.btnDeleteGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Size = new System.Drawing.Size( 55 , 26 );
            this.btnDeleteGroup.Text = "删除";
            this.btnDeleteGroup.Click += new System.EventHandler( this.btnDeleteGroup_Click );
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::HIS_BaseManager.Properties.Resources.刷新;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size( 55 , 26 );
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler( this.btnRefresh_Click );
            // 
            // btnExit
            // 
            this.btnExit.Image = global::HIS_BaseManager.Properties.Resources.退出;
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size( 83 , 26 );
            this.btnExit.Text = "关闭窗口";
            this.btnExit.Click += new System.EventHandler( this.btnExit_Click );
            // 
            // FrmGroupMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.ClientSize = new System.Drawing.Size( 864 , 457 );
            this.Controls.Add( this.panel2 );
            this.Name = "FrmGroupMenu";
            this.Text = "工作组菜单管理";
           
            this.Controls.SetChildIndex( this.panel2 , 0 );
            this.Controls.SetChildIndex( this.plBaseToolbar , 0 );
            this.Controls.SetChildIndex( this.plBaseStatus , 0 );
            this.Controls.SetChildIndex( this.plBaseWorkArea , 0 );
            this.plBaseToolbar.ResumeLayout( false );
            this.plBaseToolbar.PerformLayout( );
            this.plBaseWorkArea.ResumeLayout( false );
            this.panel1.ResumeLayout( false );
            this.toolStrip1.ResumeLayout( false );
            this.toolStrip1.PerformLayout( );
            this.ResumeLayout( false );

		}
		#endregion

		#region 初始化菜单与组
		private void InitMenuTree()
		{
			
			TreeNode ndMod=null;
			MenuInfo mInfo;

            DataTable tbModule = HIS.Base_BLL.BaseDataReader.Base_Module;

			this.tvwMenu.Nodes.Clear();
			for(int i=0;i<=tbModule.Rows.Count-1;i++)
			{
				mInfo=new MenuInfo();
				mInfo.ModuleID=Convert.ToInt64(tbModule.Rows[i]["module_id"]);
				mInfo.MenuName=tbModule.Rows[i]["name"].ToString().Trim();
				mInfo.MenuID=0;
				mInfo.ParentMenuID=0;
				mInfo.IsModule=true;

				ndMod=new TreeNode();
				ndMod.Text=mInfo.MenuName;
				ndMod.ImageIndex=0;
				ndMod.Tag=mInfo;
				tvwMenu.Nodes.Add(ndMod);
				AddNode(ndMod);

			}
		}

		private void AddNode(TreeNode TopNode)
		{
			MenuInfo mInfo=(MenuInfo)TopNode.Tag;
			//顶级菜单为模块名，menuid=module;
			long moduleId=mInfo.ModuleID;
			//取得所有菜单
            DataTable tbMenu = HIS.Base_BLL.BaseDataReader.Base_Menu;
			//获取顶级菜单
			DataTable tbTopmenu=tbMenu.Clone();
			DataRow[] rows=tbMenu.Select("p_menu_id=-1 and module_id="+moduleId);
			for(int i=0;i<=rows.Length-1;i++)
			{
				tbTopmenu.Rows.Add(rows[i].ItemArray);
			}
			//循环加载顶级菜单
			for(int i=0;i<=tbTopmenu.Rows.Count-1;i++)
			{
				mInfo=new MenuInfo();
				mInfo.IsModule=false;
				mInfo.ModuleID=moduleId;
				mInfo.MenuID=Convert.ToInt64(tbTopmenu.Rows[i]["menu_id"]);
				mInfo.MenuName=tbTopmenu.Rows[i]["name"].ToString().Trim();
				mInfo.ParentMenuID=Convert.ToInt64(tbTopmenu.Rows[i]["p_menu_id"]);
				TreeNode node=new TreeNode();
				node.Text=mInfo.MenuName;
				node.ImageIndex=0;
				node.Tag=mInfo;
				TopNode.Nodes.Add(node);
				AddSubNode(node,tbMenu);
			}
		}

		private void AddSubNode(TreeNode ParentNode,DataTable tbMenus)
		{
			MenuInfo mInfo=(MenuInfo)ParentNode.Tag;
			long moduleId=mInfo.ModuleID;
			DataTable tbSubMenu=tbMenus.Clone();
			DataRow[] rows=tbMenus.Select("p_menu_id="+mInfo.MenuID+" and module_id="+moduleId);
			for(int i=0;i<=rows.Length-1;i++)
			{
				tbSubMenu.Rows.Add(rows[i].ItemArray);
			}

			for(int i=0;i<=tbSubMenu.Rows.Count-1;i++)
			{
				mInfo=new MenuInfo();
				mInfo.MenuID=Convert.ToInt64(tbSubMenu.Rows[i]["menu_id"]);
				mInfo.ModuleID=moduleId;
				mInfo.MenuName=tbSubMenu.Rows[i]["name"].ToString().Trim();
				mInfo.ParentMenuID=Convert.ToInt64(tbSubMenu.Rows[i]["p_menu_id"]);
				TreeNode ndSub=new TreeNode();
				ndSub.Text=mInfo.MenuName;
				ndSub.ImageIndex=0;
				ndSub.Tag=mInfo;
				ParentNode.Nodes.Add(ndSub);
				AddSubNode(ndSub,tbMenus);
			}
		}

		private void InitGroups()
		{

            DataTable tbGroup = HIS.Base_BLL.BaseDataReader.Base_Group;
			this.lstGroup.Items.Clear();
			for(int i=0;i<=tbGroup.Rows.Count-1;i++)
			{
				ListViewItem item=new ListViewItem();
				item.Text=tbGroup.Rows[i]["name"].ToString().Trim();
				item.SubItems.Add(tbGroup.Rows[i]["memo"].ToString().Trim());
				item.ImageIndex=1;
				item.Tag=Convert.ToInt64(tbGroup.Rows[i]["group_id"]);
                if ( Convert.ToInt32( tbGroup.Rows[i]["ADMINISTRATORS"] ) == 1 )
                    item.Text = item.Text + "【管理员】";
                if ( Convert.ToInt32( tbGroup.Rows[i]["DELETE_FLAG"] ) == 1 )
                    item.Text = item.Text + "(停用)";
				this.lstGroup.Items.Add(item);
			}
		}

		private void SearchTreeNode(ref ArrayList Sql)
		{
			long groupId=Convert.ToInt64(this.lstGroup.SelectedItems[0].Tag);
            HIS.Base_BLL.GroupMenuManager gmm = new HIS.Base_BLL.GroupMenuManager( );
            gmm.BeginEdit( );
            try
            {
                foreach ( TreeNode node in this.tvwMenu.Nodes )
                {
                    MenuInfo mInfo = (MenuInfo)node.Tag;
                    if ( mInfo.IsModule )
                    {
                        gmm.DeleteGroupMenu( Convert.ToInt32( groupId ) , Convert.ToInt32(mInfo.ModuleID) );
                    }
                    SearchSubNode( node , mInfo.ModuleID , groupId ,gmm );

                }
                gmm.EndEdit( );
            }
            catch
            {
                gmm.AbortEdit( );
            }
		}
		private void SearchSubNode(TreeNode node,long ModuleID,long GroupID,HIS.Base_BLL.GroupMenuManager gmm)
		{
			foreach(TreeNode nd in node.Nodes)
			{
				if(nd.Checked)
				{
					MenuInfo mInfo=(MenuInfo)nd.Tag;
					if(mInfo.IsModule==false)
					{
						if(nd.Checked)
						{
                            gmm.AddGroupMenu( Convert.ToInt32(GroupID) ,Convert.ToInt32( ModuleID ),Convert.ToInt32( mInfo.MenuID) );
						}
					}
				}
				SearchSubNode(nd,ModuleID,GroupID,gmm);
			}
		}
		private void ClearNodeCheck()
		{
			foreach(TreeNode node in this.tvwMenu.Nodes)
			{
				node.Checked=false;
				ClearSubNodeCheck(node);
			}
		}
		private void ClearSubNodeCheck(TreeNode node)
		{
			foreach(TreeNode nd in node.Nodes)
			{
				nd.Checked=false;
				ClearSubNodeCheck(nd);
			}
		}
		#endregion

 		
		private void SetCheckStatus(TreeNode node)
		{
            HIS.Base_BLL.GroupMenuManager g = new HIS.Base_BLL.GroupMenuManager( );
			foreach(TreeNode nd in node.Nodes)
			{
				nd.Checked=node.Checked;
				SetCheckStatus(nd);
			}
		}

		private void lstGroup_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.lstGroup.SelectedItems.Count==0) return;
			this.ClearNodeCheck();
			long groupId=Convert.ToInt64(this.lstGroup.SelectedItems[0].Tag);
			foreach(TreeNode node in this.tvwMenu.Nodes)
			{
				long moduleId=((MenuInfo)node.Tag).ModuleID;
                
                DataRow[] drs = HIS.Base_BLL.BaseDataReader.Base_Group_Menu.Select( "module_id=" + moduleId + " and group_id=" + groupId );
				if(drs.Length!=0) node.Checked=true;
				for(int i=0;i<=drs.Length-1;i++)
				{
					long menuId=Convert.ToInt64(drs[i]["menu_id"]);
					SetNodeCheck(node,menuId);
				}
			}
		}
		
		private void SetNodeCheck(TreeNode node,long MenuID)
		{
			foreach(TreeNode nd in node.Nodes)
			{
				MenuInfo mInfo=(MenuInfo)nd.Tag;
				if(mInfo.MenuID==MenuID)
				{
					nd.Checked=true;
					return;
				}
				else
				{
					SetNodeCheck(nd,MenuID);
				}
			}
		}

		private void mnuSelectAll_Click(object sender, System.EventArgs e)
		{
			if(tvwMenu.SelectedNode!=null)
			{
				TreeNode node=tvwMenu.SelectedNode;
				node.Checked=true;
				SetCheckStatus(node);
			}
		}

		private void tvwMenu_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(e.Node.Checked)
			{
				if(e.Node.Parent!=null)
				{
					e.Node.Parent.Checked=true;
				}
			}
		}

		private void mnuUnSelectAll_Click(object sender, System.EventArgs e)
		{
			if(tvwMenu.SelectedNode!=null)
			{
				TreeNode node=tvwMenu.SelectedNode;
				node.Checked=false;
				SetCheckStatus(node);
			}
		}

        private void btnAddGroup_Click( object sender, EventArgs e )
        {
            FrmEditGroup fEdit = new FrmEditGroup( );
            if ( fEdit.ShowDialog( ) == DialogResult.OK )
            {
                ListViewItem item = new ListViewItem( );
                item.Text = fEdit.ReturnName;
                item.SubItems.Add( "" );
                item.ImageIndex = 1;
                item.Tag = fEdit.ReturnID;
                this.lstGroup.Items.Add( item );
            }
            
        }

        private void btnSave_Click( object sender, EventArgs e )
        {
            ArrayList Sqls = new ArrayList();
            this.SearchTreeNode( ref Sqls );
        }

        private void btnDeleteGroup_Click( object sender, EventArgs e )
        {
            if ( lstGroup.SelectedItems.Count == 0 )
                return;

            if ( MessageBox.Show( "是否删除该组？删除后该组所属的用户有可能不能在进入系统", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes )
            {
                HIS.Base_BLL.GroupMenuManager gmm = new HIS.Base_BLL.GroupMenuManager();
                try
                {
                    int groupId = Convert.ToInt32( lstGroup.SelectedItems[0].Tag );
                    gmm.BeginEdit();
                    gmm.DeleteGroup( groupId );
                    gmm.EndEdit();

                    lstGroup.Items.Remove( lstGroup.SelectedItems[0] );

                }
                catch ( Exception err )
                {
                    gmm.AbortEdit();
                    MessageBox.Show( err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
        }

        private void btnRefresh_Click( object sender, EventArgs e )
        {
            this.InitGroups();
            this.InitMenuTree();
        }

        private void btnExit_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void btnEditGroup_Click( object sender , EventArgs e )
        {
            if ( lstGroup.SelectedItems.Count == 0 )
            {
                MessageBox.Show( "请指定要修改的目标组" , "" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                return;
            }
            else
            {
                int groupId = Convert.ToInt32( lstGroup.SelectedItems[0].Tag );
                FrmEditGroup fEdit = new FrmEditGroup( groupId );
                if ( fEdit.ShowDialog( ) == DialogResult.OK )
                {
                    lstGroup.SelectedItems[0].Text = fEdit.ReturnName;
                }
            }
        }

        private void lstGroup_DoubleClick( object sender , EventArgs e )
        {
            if ( lstGroup.SelectedItems.Count == 0 )
                return;
            btnEditGroup_Click( null , null );
        }
	}
}
