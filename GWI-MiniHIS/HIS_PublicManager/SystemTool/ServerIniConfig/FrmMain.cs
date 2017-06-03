using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS_PublicManager.SystemTool.ServerIniConfig
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.Button btTest;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rbServerName;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblPwd;
		private System.Windows.Forms.Label lblUser;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtUserID;
		private System.Windows.Forms.TextBox txtDatabase;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.TextBox txtProtocol;
		private System.Windows.Forms.TextBox txtHostName;
		private System.Windows.Forms.Label lblDataName;
		private System.Windows.Forms.Label lblPort;
		private System.Windows.Forms.Label lblProtocol;
		private System.Windows.Forms.Label lblServerName;
		private System.Windows.Forms.RadioButton rbDataSource;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnSearchPath;
		private System.Windows.Forms.TextBox txtLocalDBPath;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rbServerNamezy;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtPasswordzy;
		private System.Windows.Forms.TextBox txtUserIDzy;
		private System.Windows.Forms.TextBox txtDatabasezy;
		private System.Windows.Forms.TextBox txtPortzy;
		private System.Windows.Forms.TextBox txtProtocolzy;
		private System.Windows.Forms.TextBox txtHostNamezy;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.RadioButton rbDataSourcezy;
		private System.Windows.Forms.Label lblDataNamezy;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label lblDataNameyb;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtPasswordyb;
		private System.Windows.Forms.TextBox txtUserIDyb;
		private System.Windows.Forms.TextBox txtDatabaseyb;
		private System.Windows.Forms.TextBox txtHostNameyb;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.RadioButton rbServerNameyp;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txtPasswordyp;
		private System.Windows.Forms.TextBox txtUserIDyp;
		private System.Windows.Forms.TextBox txtDatabaseyp;
		private System.Windows.Forms.TextBox txtPortyp;
		private System.Windows.Forms.TextBox txtProtocolyp;
		private System.Windows.Forms.TextBox txtHostNameyp;
		private System.Windows.Forms.Label lblDataNameyp;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.RadioButton rbDataSourceyp;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txtCustomDirectory;
		private System.Windows.Forms.TabPage tabPage0;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label lblDataNameLis;
		private System.Windows.Forms.RadioButton rbServerNameLis;
		private System.Windows.Forms.RadioButton rbDataSourceLis;
		private System.Windows.Forms.TextBox txtHostNameLis;
		private System.Windows.Forms.TextBox txtProtocolLis;
		private System.Windows.Forms.TextBox txtPortLis;
		private System.Windows.Forms.TextBox txtDatabaseLis;
		private System.Windows.Forms.TextBox txtUserIDLis;
		private System.Windows.Forms.TextBox txtPasswordLis;
		private System.Windows.Forms.TabPage tabPage7;
		private System.Windows.Forms.TabPage tabPage8;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.RadioButton rbServerNamePACS;
		private System.Windows.Forms.TextBox txtPasswordPACS;
		private System.Windows.Forms.TextBox txtUserIDPACS;
		private System.Windows.Forms.TextBox txtDatabasePACS;
		private System.Windows.Forms.TextBox txtPortPACS;
		private System.Windows.Forms.TextBox txtProtocolPACS;
		private System.Windows.Forms.TextBox txtHostNamePACS;
		private System.Windows.Forms.Label lblDataNamePACS;
		private System.Windows.Forms.RadioButton rbDataSourcePACS;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.TextBox txtPasswordRis;
		private System.Windows.Forms.TextBox txtUserIDRis;
		private System.Windows.Forms.TextBox txtDatabaseRis;
		private System.Windows.Forms.TextBox txtPortRis;
		private System.Windows.Forms.TextBox txtProtocolRis;
		private System.Windows.Forms.TextBox txtHostNameRis;
		private System.Windows.Forms.RadioButton rbDataSourceRis;
		private System.Windows.Forms.RadioButton rbServerNameRis;
		private System.Windows.Forms.Label lblDataNameRis;
		private System.Windows.Forms.TabPage tabPage9;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.RadioButton rbServerNameUpdate;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.TextBox txtPasswordUpdate;
		private System.Windows.Forms.TextBox txtDatabaseUpdate;
		private System.Windows.Forms.TextBox txtPortUpdate;
		private System.Windows.Forms.TextBox txtProtocolUpdate;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.RadioButton rbDataSourceUpdate;
		private System.Windows.Forms.Label lblDataNameUpdate;
		private System.Windows.Forms.TextBox txtHostNameUpdate;
		private System.Windows.Forms.TabControl tbctrlDataSource;
		private System.Windows.Forms.TextBox txtUserIDUpdate;
		private System.Windows.Forms.TabPage tabPage4;
        private TabPage tabPage10;
        private Button button1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMain()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btCancel = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.btTest = new System.Windows.Forms.Button();
            this.tbctrlDataSource = new System.Windows.Forms.TabControl();
            this.tabPage0 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbServerName = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPwd = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtProtocol = new System.Windows.Forms.TextBox();
            this.txtHostName = new System.Windows.Forms.TextBox();
            this.lblDataName = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblProtocol = new System.Windows.Forms.Label();
            this.lblServerName = new System.Windows.Forms.Label();
            this.rbDataSource = new System.Windows.Forms.RadioButton();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.rbServerNameUpdate = new System.Windows.Forms.RadioButton();
            this.label35 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.txtPasswordUpdate = new System.Windows.Forms.TextBox();
            this.txtUserIDUpdate = new System.Windows.Forms.TextBox();
            this.txtDatabaseUpdate = new System.Windows.Forms.TextBox();
            this.txtPortUpdate = new System.Windows.Forms.TextBox();
            this.txtProtocolUpdate = new System.Windows.Forms.TextBox();
            this.txtHostNameUpdate = new System.Windows.Forms.TextBox();
            this.lblDataNameUpdate = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.rbDataSourceUpdate = new System.Windows.Forms.RadioButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnSearchPath = new System.Windows.Forms.Button();
            this.txtLocalDBPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.txtCustomDirectory = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbServerNamezy = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPasswordzy = new System.Windows.Forms.TextBox();
            this.txtUserIDzy = new System.Windows.Forms.TextBox();
            this.txtDatabasezy = new System.Windows.Forms.TextBox();
            this.txtPortzy = new System.Windows.Forms.TextBox();
            this.txtProtocolzy = new System.Windows.Forms.TextBox();
            this.txtHostNamezy = new System.Windows.Forms.TextBox();
            this.lblDataNamezy = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.rbDataSourcezy = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbServerNameyp = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPasswordyp = new System.Windows.Forms.TextBox();
            this.txtUserIDyp = new System.Windows.Forms.TextBox();
            this.txtDatabaseyp = new System.Windows.Forms.TextBox();
            this.txtPortyp = new System.Windows.Forms.TextBox();
            this.txtProtocolyp = new System.Windows.Forms.TextBox();
            this.txtHostNameyp = new System.Windows.Forms.TextBox();
            this.lblDataNameyp = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.rbDataSourceyp = new System.Windows.Forms.RadioButton();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtPasswordRis = new System.Windows.Forms.TextBox();
            this.txtUserIDRis = new System.Windows.Forms.TextBox();
            this.txtDatabaseRis = new System.Windows.Forms.TextBox();
            this.txtPortRis = new System.Windows.Forms.TextBox();
            this.txtProtocolRis = new System.Windows.Forms.TextBox();
            this.txtHostNameRis = new System.Windows.Forms.TextBox();
            this.rbDataSourceRis = new System.Windows.Forms.RadioButton();
            this.rbServerNameRis = new System.Windows.Forms.RadioButton();
            this.label28 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.lblDataNameRis = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.rbServerNamePACS = new System.Windows.Forms.RadioButton();
            this.label23 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtPasswordPACS = new System.Windows.Forms.TextBox();
            this.txtUserIDPACS = new System.Windows.Forms.TextBox();
            this.txtDatabasePACS = new System.Windows.Forms.TextBox();
            this.txtPortPACS = new System.Windows.Forms.TextBox();
            this.txtProtocolPACS = new System.Windows.Forms.TextBox();
            this.txtHostNamePACS = new System.Windows.Forms.TextBox();
            this.lblDataNamePACS = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.rbDataSourcePACS = new System.Windows.Forms.RadioButton();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtPasswordLis = new System.Windows.Forms.TextBox();
            this.txtUserIDLis = new System.Windows.Forms.TextBox();
            this.txtDatabaseLis = new System.Windows.Forms.TextBox();
            this.txtPortLis = new System.Windows.Forms.TextBox();
            this.txtProtocolLis = new System.Windows.Forms.TextBox();
            this.txtHostNameLis = new System.Windows.Forms.TextBox();
            this.rbDataSourceLis = new System.Windows.Forms.RadioButton();
            this.rbServerNameLis = new System.Windows.Forms.RadioButton();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblDataNameLis = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPasswordyb = new System.Windows.Forms.TextBox();
            this.txtUserIDyb = new System.Windows.Forms.TextBox();
            this.txtDatabaseyb = new System.Windows.Forms.TextBox();
            this.txtHostNameyb = new System.Windows.Forms.TextBox();
            this.lblDataNameyb = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbctrlDataSource.SuspendLayout();
            this.tabPage0.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(348, 282);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 26);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "取消";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(228, 282);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 26);
            this.btOK.TabIndex = 0;
            this.btOK.Text = "确定";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btTest
            // 
            this.btTest.Location = new System.Drawing.Point(108, 282);
            this.btTest.Name = "btTest";
            this.btTest.Size = new System.Drawing.Size(75, 26);
            this.btTest.TabIndex = 16;
            this.btTest.Text = "测试连接";
            this.btTest.Click += new System.EventHandler(this.btTest_Click);
            // 
            // tbctrlDataSource
            // 
            this.tbctrlDataSource.Controls.Add(this.tabPage0);
            this.tbctrlDataSource.Controls.Add(this.tabPage9);
            this.tbctrlDataSource.Controls.Add(this.tabPage3);
            this.tbctrlDataSource.Controls.Add(this.tabPage10);
            this.tbctrlDataSource.Location = new System.Drawing.Point(0, 5);
            this.tbctrlDataSource.Name = "tbctrlDataSource";
            this.tbctrlDataSource.SelectedIndex = 0;
            this.tbctrlDataSource.Size = new System.Drawing.Size(532, 263);
            this.tbctrlDataSource.TabIndex = 17;
            // 
            // tabPage0
            // 
            this.tabPage0.Controls.Add(this.groupBox1);
            this.tabPage0.Location = new System.Drawing.Point(4, 21);
            this.tabPage0.Name = "tabPage0";
            this.tabPage0.Size = new System.Drawing.Size(524, 238);
            this.tabPage0.TabIndex = 0;
            this.tabPage0.Tag = "0";
            this.tabPage0.Text = "远程登录";
            this.tabPage0.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbServerName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblPwd);
            this.groupBox1.Controls.Add(this.lblUser);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtUserID);
            this.groupBox1.Controls.Add(this.txtDatabase);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtProtocol);
            this.groupBox1.Controls.Add(this.txtHostName);
            this.groupBox1.Controls.Add(this.lblDataName);
            this.groupBox1.Controls.Add(this.lblPort);
            this.groupBox1.Controls.Add(this.lblProtocol);
            this.groupBox1.Controls.Add(this.lblServerName);
            this.groupBox1.Controls.Add(this.rbDataSource);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(524, 238);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rbServerName
            // 
            this.rbServerName.Checked = true;
            this.rbServerName.Location = new System.Drawing.Point(144, 11);
            this.rbServerName.Name = "rbServerName";
            this.rbServerName.Size = new System.Drawing.Size(112, 24);
            this.rbServerName.TabIndex = 49;
            this.rbServerName.TabStop = true;
            this.rbServerName.Text = "直接服务器连接";
            this.rbServerName.CheckedChanged += new System.EventHandler(this.rbServerName_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 47;
            this.label7.Text = "连接类型：";
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(16, 204);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(65, 12);
            this.lblPwd.TabIndex = 46;
            this.lblPwd.Text = "登录密码：";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(16, 171);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(65, 12);
            this.lblUser.TabIndex = 45;
            this.lblUser.Text = "登录用户：";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(144, 201);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(240, 21);
            this.txtPassword.TabIndex = 44;
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(144, 168);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(240, 21);
            this.txtUserID.TabIndex = 43;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(144, 134);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(240, 21);
            this.txtDatabase.TabIndex = 42;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(144, 103);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(240, 21);
            this.txtPort.TabIndex = 41;
            // 
            // txtProtocol
            // 
            this.txtProtocol.Location = new System.Drawing.Point(144, 73);
            this.txtProtocol.Name = "txtProtocol";
            this.txtProtocol.Size = new System.Drawing.Size(240, 21);
            this.txtProtocol.TabIndex = 40;
            // 
            // txtHostName
            // 
            this.txtHostName.Location = new System.Drawing.Point(144, 41);
            this.txtHostName.Name = "txtHostName";
            this.txtHostName.Size = new System.Drawing.Size(240, 21);
            this.txtHostName.TabIndex = 39;
            // 
            // lblDataName
            // 
            this.lblDataName.AutoSize = true;
            this.lblDataName.Location = new System.Drawing.Point(16, 136);
            this.lblDataName.Name = "lblDataName";
            this.lblDataName.Size = new System.Drawing.Size(65, 12);
            this.lblDataName.TabIndex = 38;
            this.lblDataName.Text = "数据库名：";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(16, 105);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(41, 12);
            this.lblPort.TabIndex = 37;
            this.lblPort.Text = "端口：";
            // 
            // lblProtocol
            // 
            this.lblProtocol.AutoSize = true;
            this.lblProtocol.Location = new System.Drawing.Point(16, 75);
            this.lblProtocol.Name = "lblProtocol";
            this.lblProtocol.Size = new System.Drawing.Size(41, 12);
            this.lblProtocol.TabIndex = 36;
            this.lblProtocol.Text = "协议：";
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(16, 42);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(125, 12);
            this.lblServerName.TabIndex = 35;
            this.lblServerName.Text = "服务器名称（或IP）：";
            // 
            // rbDataSource
            // 
            this.rbDataSource.Location = new System.Drawing.Point(266, 11);
            this.rbDataSource.Name = "rbDataSource";
            this.rbDataSource.Size = new System.Drawing.Size(88, 24);
            this.rbDataSource.TabIndex = 48;
            this.rbDataSource.Text = "数据源连接";
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.groupBox8);
            this.tabPage9.Location = new System.Drawing.Point(4, 21);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(524, 238);
            this.tabPage9.TabIndex = 9;
            this.tabPage9.Tag = "9";
            this.tabPage9.Text = "升级服务器";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.rbServerNameUpdate);
            this.groupBox8.Controls.Add(this.label35);
            this.groupBox8.Controls.Add(this.label38);
            this.groupBox8.Controls.Add(this.label39);
            this.groupBox8.Controls.Add(this.txtPasswordUpdate);
            this.groupBox8.Controls.Add(this.txtUserIDUpdate);
            this.groupBox8.Controls.Add(this.txtDatabaseUpdate);
            this.groupBox8.Controls.Add(this.txtPortUpdate);
            this.groupBox8.Controls.Add(this.txtProtocolUpdate);
            this.groupBox8.Controls.Add(this.txtHostNameUpdate);
            this.groupBox8.Controls.Add(this.lblDataNameUpdate);
            this.groupBox8.Controls.Add(this.label41);
            this.groupBox8.Controls.Add(this.label42);
            this.groupBox8.Controls.Add(this.label43);
            this.groupBox8.Controls.Add(this.rbDataSourceUpdate);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(0, 0);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(524, 238);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            // 
            // rbServerNameUpdate
            // 
            this.rbServerNameUpdate.Checked = true;
            this.rbServerNameUpdate.Location = new System.Drawing.Point(144, 11);
            this.rbServerNameUpdate.Name = "rbServerNameUpdate";
            this.rbServerNameUpdate.Size = new System.Drawing.Size(112, 24);
            this.rbServerNameUpdate.TabIndex = 49;
            this.rbServerNameUpdate.TabStop = true;
            this.rbServerNameUpdate.Text = "直接服务器连接";
            this.rbServerNameUpdate.CheckedChanged += new System.EventHandler(this.rbServerNameUpdate_CheckedChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(16, 16);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(65, 12);
            this.label35.TabIndex = 47;
            this.label35.Text = "连接类型：";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(16, 204);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(65, 12);
            this.label38.TabIndex = 46;
            this.label38.Text = "登录密码：";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(16, 171);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(65, 12);
            this.label39.TabIndex = 45;
            this.label39.Text = "登录用户：";
            // 
            // txtPasswordUpdate
            // 
            this.txtPasswordUpdate.Location = new System.Drawing.Point(144, 201);
            this.txtPasswordUpdate.Name = "txtPasswordUpdate";
            this.txtPasswordUpdate.PasswordChar = '*';
            this.txtPasswordUpdate.Size = new System.Drawing.Size(240, 21);
            this.txtPasswordUpdate.TabIndex = 44;
            // 
            // txtUserIDUpdate
            // 
            this.txtUserIDUpdate.Location = new System.Drawing.Point(144, 168);
            this.txtUserIDUpdate.Name = "txtUserIDUpdate";
            this.txtUserIDUpdate.Size = new System.Drawing.Size(240, 21);
            this.txtUserIDUpdate.TabIndex = 43;
            // 
            // txtDatabaseUpdate
            // 
            this.txtDatabaseUpdate.Location = new System.Drawing.Point(144, 134);
            this.txtDatabaseUpdate.Name = "txtDatabaseUpdate";
            this.txtDatabaseUpdate.Size = new System.Drawing.Size(240, 21);
            this.txtDatabaseUpdate.TabIndex = 42;
            // 
            // txtPortUpdate
            // 
            this.txtPortUpdate.Location = new System.Drawing.Point(144, 103);
            this.txtPortUpdate.Name = "txtPortUpdate";
            this.txtPortUpdate.Size = new System.Drawing.Size(240, 21);
            this.txtPortUpdate.TabIndex = 41;
            // 
            // txtProtocolUpdate
            // 
            this.txtProtocolUpdate.Location = new System.Drawing.Point(144, 73);
            this.txtProtocolUpdate.Name = "txtProtocolUpdate";
            this.txtProtocolUpdate.Size = new System.Drawing.Size(240, 21);
            this.txtProtocolUpdate.TabIndex = 40;
            // 
            // txtHostNameUpdate
            // 
            this.txtHostNameUpdate.Location = new System.Drawing.Point(144, 41);
            this.txtHostNameUpdate.Name = "txtHostNameUpdate";
            this.txtHostNameUpdate.Size = new System.Drawing.Size(240, 21);
            this.txtHostNameUpdate.TabIndex = 39;
            // 
            // lblDataNameUpdate
            // 
            this.lblDataNameUpdate.AutoSize = true;
            this.lblDataNameUpdate.Location = new System.Drawing.Point(16, 136);
            this.lblDataNameUpdate.Name = "lblDataNameUpdate";
            this.lblDataNameUpdate.Size = new System.Drawing.Size(65, 12);
            this.lblDataNameUpdate.TabIndex = 38;
            this.lblDataNameUpdate.Text = "数据库名：";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(16, 105);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(41, 12);
            this.label41.TabIndex = 37;
            this.label41.Text = "端口：";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(16, 75);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(41, 12);
            this.label42.TabIndex = 36;
            this.label42.Text = "协议：";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(16, 42);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(125, 12);
            this.label43.TabIndex = 35;
            this.label43.Text = "服务器名称（或IP）：";
            // 
            // rbDataSourceUpdate
            // 
            this.rbDataSourceUpdate.Location = new System.Drawing.Point(266, 11);
            this.rbDataSourceUpdate.Name = "rbDataSourceUpdate";
            this.rbDataSourceUpdate.Size = new System.Drawing.Size(88, 24);
            this.rbDataSourceUpdate.TabIndex = 48;
            this.rbDataSourceUpdate.Text = "数据源连接";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnSearchPath);
            this.tabPage3.Controls.Add(this.txtLocalDBPath);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(524, 238);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Tag = "3";
            this.tabPage3.Text = "本机登录";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnSearchPath
            // 
            this.btnSearchPath.Location = new System.Drawing.Point(384, 36);
            this.btnSearchPath.Name = "btnSearchPath";
            this.btnSearchPath.Size = new System.Drawing.Size(22, 20);
            this.btnSearchPath.TabIndex = 2;
            this.btnSearchPath.Text = "…";
            this.btnSearchPath.Click += new System.EventHandler(this.btnSearchPath_Click);
            // 
            // txtLocalDBPath
            // 
            this.txtLocalDBPath.Location = new System.Drawing.Point(6, 36);
            this.txtLocalDBPath.Name = "txtLocalDBPath";
            this.txtLocalDBPath.Size = new System.Drawing.Size(402, 21);
            this.txtLocalDBPath.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "本机数据库路径：";
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.button1);
            this.tabPage10.Location = new System.Drawing.Point(4, 21);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(524, 238);
            this.tabPage10.TabIndex = 10;
            this.tabPage10.Text = "中间件服务器";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(137, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(226, 91);
            this.button1.TabIndex = 0;
            this.button1.Text = "配置参数";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.txtCustomDirectory);
            this.tabPage6.Controls.Add(this.label14);
            this.tabPage6.Location = new System.Drawing.Point(4, 21);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(524, 238);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Tag = "6";
            this.tabPage6.Text = "其他配置";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // txtCustomDirectory
            // 
            this.txtCustomDirectory.Location = new System.Drawing.Point(6, 36);
            this.txtCustomDirectory.Name = "txtCustomDirectory";
            this.txtCustomDirectory.Size = new System.Drawing.Size(402, 21);
            this.txtCustomDirectory.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(8, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(124, 18);
            this.label14.TabIndex = 2;
            this.label14.Text = "客户端自定义路径：";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(524, 238);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Tag = "1";
            this.tabPage1.Text = "远程登录(住院)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbServerNamezy);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtPasswordzy);
            this.groupBox2.Controls.Add(this.txtUserIDzy);
            this.groupBox2.Controls.Add(this.txtDatabasezy);
            this.groupBox2.Controls.Add(this.txtPortzy);
            this.groupBox2.Controls.Add(this.txtProtocolzy);
            this.groupBox2.Controls.Add(this.txtHostNamezy);
            this.groupBox2.Controls.Add(this.lblDataNamezy);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.rbDataSourcezy);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(524, 238);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // rbServerNamezy
            // 
            this.rbServerNamezy.Checked = true;
            this.rbServerNamezy.Location = new System.Drawing.Point(144, 11);
            this.rbServerNamezy.Name = "rbServerNamezy";
            this.rbServerNamezy.Size = new System.Drawing.Size(112, 24);
            this.rbServerNamezy.TabIndex = 49;
            this.rbServerNamezy.TabStop = true;
            this.rbServerNamezy.Text = "直接服务器连接";
            this.rbServerNamezy.CheckedChanged += new System.EventHandler(this.rbServerNamezy_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 47;
            this.label1.Text = "连接类型：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 46;
            this.label3.Text = "登录密码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 45;
            this.label4.Text = "登录用户：";
            // 
            // txtPasswordzy
            // 
            this.txtPasswordzy.Location = new System.Drawing.Point(144, 201);
            this.txtPasswordzy.Name = "txtPasswordzy";
            this.txtPasswordzy.PasswordChar = '*';
            this.txtPasswordzy.Size = new System.Drawing.Size(240, 21);
            this.txtPasswordzy.TabIndex = 44;
            // 
            // txtUserIDzy
            // 
            this.txtUserIDzy.Location = new System.Drawing.Point(144, 168);
            this.txtUserIDzy.Name = "txtUserIDzy";
            this.txtUserIDzy.Size = new System.Drawing.Size(240, 21);
            this.txtUserIDzy.TabIndex = 43;
            // 
            // txtDatabasezy
            // 
            this.txtDatabasezy.Location = new System.Drawing.Point(144, 134);
            this.txtDatabasezy.Name = "txtDatabasezy";
            this.txtDatabasezy.Size = new System.Drawing.Size(240, 21);
            this.txtDatabasezy.TabIndex = 42;
            // 
            // txtPortzy
            // 
            this.txtPortzy.Location = new System.Drawing.Point(144, 103);
            this.txtPortzy.Name = "txtPortzy";
            this.txtPortzy.Size = new System.Drawing.Size(240, 21);
            this.txtPortzy.TabIndex = 41;
            // 
            // txtProtocolzy
            // 
            this.txtProtocolzy.Location = new System.Drawing.Point(144, 73);
            this.txtProtocolzy.Name = "txtProtocolzy";
            this.txtProtocolzy.Size = new System.Drawing.Size(240, 21);
            this.txtProtocolzy.TabIndex = 40;
            // 
            // txtHostNamezy
            // 
            this.txtHostNamezy.Location = new System.Drawing.Point(144, 41);
            this.txtHostNamezy.Name = "txtHostNamezy";
            this.txtHostNamezy.Size = new System.Drawing.Size(240, 21);
            this.txtHostNamezy.TabIndex = 39;
            // 
            // lblDataNamezy
            // 
            this.lblDataNamezy.AutoSize = true;
            this.lblDataNamezy.Location = new System.Drawing.Point(16, 136);
            this.lblDataNamezy.Name = "lblDataNamezy";
            this.lblDataNamezy.Size = new System.Drawing.Size(65, 12);
            this.lblDataNamezy.TabIndex = 38;
            this.lblDataNamezy.Text = "数据库名：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 37;
            this.label6.Text = "端口：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 36;
            this.label8.Text = "协议：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 12);
            this.label9.TabIndex = 35;
            this.label9.Text = "服务器名称（或IP）：";
            // 
            // rbDataSourcezy
            // 
            this.rbDataSourcezy.Location = new System.Drawing.Point(266, 11);
            this.rbDataSourcezy.Name = "rbDataSourcezy";
            this.rbDataSourcezy.Size = new System.Drawing.Size(88, 24);
            this.rbDataSourcezy.TabIndex = 48;
            this.rbDataSourcezy.Text = "数据源连接";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(524, 238);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Tag = "2";
            this.tabPage2.Text = "远程登录(药品)";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbServerNameyp);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.txtPasswordyp);
            this.groupBox4.Controls.Add(this.txtUserIDyp);
            this.groupBox4.Controls.Add(this.txtDatabaseyp);
            this.groupBox4.Controls.Add(this.txtPortyp);
            this.groupBox4.Controls.Add(this.txtProtocolyp);
            this.groupBox4.Controls.Add(this.txtHostNameyp);
            this.groupBox4.Controls.Add(this.lblDataNameyp);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.rbDataSourceyp);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(524, 238);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // rbServerNameyp
            // 
            this.rbServerNameyp.Checked = true;
            this.rbServerNameyp.Location = new System.Drawing.Point(144, 11);
            this.rbServerNameyp.Name = "rbServerNameyp";
            this.rbServerNameyp.Size = new System.Drawing.Size(112, 24);
            this.rbServerNameyp.TabIndex = 64;
            this.rbServerNameyp.TabStop = true;
            this.rbServerNameyp.Text = "直接服务器连接";
            this.rbServerNameyp.CheckedChanged += new System.EventHandler(this.rbServerNameyp_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 62;
            this.label5.Text = "连接类型：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 204);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 61;
            this.label12.Text = "登录密码：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 171);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 60;
            this.label13.Text = "登录用户：";
            // 
            // txtPasswordyp
            // 
            this.txtPasswordyp.Location = new System.Drawing.Point(144, 201);
            this.txtPasswordyp.Name = "txtPasswordyp";
            this.txtPasswordyp.PasswordChar = '*';
            this.txtPasswordyp.Size = new System.Drawing.Size(240, 21);
            this.txtPasswordyp.TabIndex = 59;
            // 
            // txtUserIDyp
            // 
            this.txtUserIDyp.Location = new System.Drawing.Point(144, 168);
            this.txtUserIDyp.Name = "txtUserIDyp";
            this.txtUserIDyp.Size = new System.Drawing.Size(240, 21);
            this.txtUserIDyp.TabIndex = 58;
            // 
            // txtDatabaseyp
            // 
            this.txtDatabaseyp.Location = new System.Drawing.Point(144, 134);
            this.txtDatabaseyp.Name = "txtDatabaseyp";
            this.txtDatabaseyp.Size = new System.Drawing.Size(240, 21);
            this.txtDatabaseyp.TabIndex = 57;
            // 
            // txtPortyp
            // 
            this.txtPortyp.Location = new System.Drawing.Point(144, 103);
            this.txtPortyp.Name = "txtPortyp";
            this.txtPortyp.Size = new System.Drawing.Size(240, 21);
            this.txtPortyp.TabIndex = 56;
            // 
            // txtProtocolyp
            // 
            this.txtProtocolyp.Location = new System.Drawing.Point(144, 73);
            this.txtProtocolyp.Name = "txtProtocolyp";
            this.txtProtocolyp.Size = new System.Drawing.Size(240, 21);
            this.txtProtocolyp.TabIndex = 55;
            // 
            // txtHostNameyp
            // 
            this.txtHostNameyp.Location = new System.Drawing.Point(144, 41);
            this.txtHostNameyp.Name = "txtHostNameyp";
            this.txtHostNameyp.Size = new System.Drawing.Size(240, 21);
            this.txtHostNameyp.TabIndex = 54;
            // 
            // lblDataNameyp
            // 
            this.lblDataNameyp.AutoSize = true;
            this.lblDataNameyp.Location = new System.Drawing.Point(16, 136);
            this.lblDataNameyp.Name = "lblDataNameyp";
            this.lblDataNameyp.Size = new System.Drawing.Size(65, 12);
            this.lblDataNameyp.TabIndex = 53;
            this.lblDataNameyp.Text = "数据库名：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 105);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 52;
            this.label16.Text = "端口：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 75);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 12);
            this.label17.TabIndex = 51;
            this.label17.Text = "协议：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 42);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(125, 12);
            this.label18.TabIndex = 50;
            this.label18.Text = "服务器名称（或IP）：";
            // 
            // rbDataSourceyp
            // 
            this.rbDataSourceyp.Location = new System.Drawing.Point(266, 11);
            this.rbDataSourceyp.Name = "rbDataSourceyp";
            this.rbDataSourceyp.Size = new System.Drawing.Size(88, 24);
            this.rbDataSourceyp.TabIndex = 63;
            this.rbDataSourceyp.Text = "数据源连接";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.groupBox6);
            this.tabPage7.Location = new System.Drawing.Point(4, 21);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(524, 238);
            this.tabPage7.TabIndex = 7;
            this.tabPage7.Tag = "7";
            this.tabPage7.Text = "远程登录(RIS)";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtPasswordRis);
            this.groupBox6.Controls.Add(this.txtUserIDRis);
            this.groupBox6.Controls.Add(this.txtDatabaseRis);
            this.groupBox6.Controls.Add(this.txtPortRis);
            this.groupBox6.Controls.Add(this.txtProtocolRis);
            this.groupBox6.Controls.Add(this.txtHostNameRis);
            this.groupBox6.Controls.Add(this.rbDataSourceRis);
            this.groupBox6.Controls.Add(this.rbServerNameRis);
            this.groupBox6.Controls.Add(this.label28);
            this.groupBox6.Controls.Add(this.label32);
            this.groupBox6.Controls.Add(this.label33);
            this.groupBox6.Controls.Add(this.label34);
            this.groupBox6.Controls.Add(this.lblDataNameRis);
            this.groupBox6.Controls.Add(this.label36);
            this.groupBox6.Controls.Add(this.label37);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(524, 238);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            // 
            // txtPasswordRis
            // 
            this.txtPasswordRis.Location = new System.Drawing.Point(144, 201);
            this.txtPasswordRis.Name = "txtPasswordRis";
            this.txtPasswordRis.PasswordChar = '*';
            this.txtPasswordRis.Size = new System.Drawing.Size(240, 21);
            this.txtPasswordRis.TabIndex = 25;
            // 
            // txtUserIDRis
            // 
            this.txtUserIDRis.Location = new System.Drawing.Point(144, 168);
            this.txtUserIDRis.Name = "txtUserIDRis";
            this.txtUserIDRis.Size = new System.Drawing.Size(240, 21);
            this.txtUserIDRis.TabIndex = 24;
            // 
            // txtDatabaseRis
            // 
            this.txtDatabaseRis.Location = new System.Drawing.Point(144, 134);
            this.txtDatabaseRis.Name = "txtDatabaseRis";
            this.txtDatabaseRis.Size = new System.Drawing.Size(240, 21);
            this.txtDatabaseRis.TabIndex = 23;
            // 
            // txtPortRis
            // 
            this.txtPortRis.Location = new System.Drawing.Point(144, 103);
            this.txtPortRis.Name = "txtPortRis";
            this.txtPortRis.Size = new System.Drawing.Size(240, 21);
            this.txtPortRis.TabIndex = 22;
            // 
            // txtProtocolRis
            // 
            this.txtProtocolRis.Location = new System.Drawing.Point(144, 73);
            this.txtProtocolRis.Name = "txtProtocolRis";
            this.txtProtocolRis.Size = new System.Drawing.Size(240, 21);
            this.txtProtocolRis.TabIndex = 21;
            // 
            // txtHostNameRis
            // 
            this.txtHostNameRis.Location = new System.Drawing.Point(144, 41);
            this.txtHostNameRis.Name = "txtHostNameRis";
            this.txtHostNameRis.Size = new System.Drawing.Size(240, 21);
            this.txtHostNameRis.TabIndex = 20;
            // 
            // rbDataSourceRis
            // 
            this.rbDataSourceRis.Location = new System.Drawing.Point(266, 11);
            this.rbDataSourceRis.Name = "rbDataSourceRis";
            this.rbDataSourceRis.Size = new System.Drawing.Size(104, 24);
            this.rbDataSourceRis.TabIndex = 19;
            this.rbDataSourceRis.Text = "数据源连接";
            // 
            // rbServerNameRis
            // 
            this.rbServerNameRis.Checked = true;
            this.rbServerNameRis.Location = new System.Drawing.Point(144, 11);
            this.rbServerNameRis.Name = "rbServerNameRis";
            this.rbServerNameRis.Size = new System.Drawing.Size(112, 24);
            this.rbServerNameRis.TabIndex = 18;
            this.rbServerNameRis.TabStop = true;
            this.rbServerNameRis.Text = "直接服务器连接";
            this.rbServerNameRis.CheckedChanged += new System.EventHandler(this.rbServerNameRis_CheckedChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(16, 75);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(41, 12);
            this.label28.TabIndex = 13;
            this.label28.Text = "协议：";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(16, 42);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(125, 12);
            this.label32.TabIndex = 12;
            this.label32.Text = "服务器名称（或IP）：";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(16, 16);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(65, 12);
            this.label33.TabIndex = 11;
            this.label33.Text = "连接类型：";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(16, 105);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(41, 12);
            this.label34.TabIndex = 14;
            this.label34.Text = "端口：";
            // 
            // lblDataNameRis
            // 
            this.lblDataNameRis.AutoSize = true;
            this.lblDataNameRis.Location = new System.Drawing.Point(16, 136);
            this.lblDataNameRis.Name = "lblDataNameRis";
            this.lblDataNameRis.Size = new System.Drawing.Size(65, 12);
            this.lblDataNameRis.TabIndex = 17;
            this.lblDataNameRis.Text = "数据库名：";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(16, 171);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(65, 12);
            this.label36.TabIndex = 16;
            this.label36.Text = "登录用户：";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(16, 204);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(65, 12);
            this.label37.TabIndex = 15;
            this.label37.Text = "登录密码：";
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.groupBox7);
            this.tabPage8.Location = new System.Drawing.Point(4, 21);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(524, 238);
            this.tabPage8.TabIndex = 8;
            this.tabPage8.Tag = "8";
            this.tabPage8.Text = "远程登录(PACS)";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.rbServerNamePACS);
            this.groupBox7.Controls.Add(this.label23);
            this.groupBox7.Controls.Add(this.label26);
            this.groupBox7.Controls.Add(this.label27);
            this.groupBox7.Controls.Add(this.txtPasswordPACS);
            this.groupBox7.Controls.Add(this.txtUserIDPACS);
            this.groupBox7.Controls.Add(this.txtDatabasePACS);
            this.groupBox7.Controls.Add(this.txtPortPACS);
            this.groupBox7.Controls.Add(this.txtProtocolPACS);
            this.groupBox7.Controls.Add(this.txtHostNamePACS);
            this.groupBox7.Controls.Add(this.lblDataNamePACS);
            this.groupBox7.Controls.Add(this.label29);
            this.groupBox7.Controls.Add(this.label30);
            this.groupBox7.Controls.Add(this.label31);
            this.groupBox7.Controls.Add(this.rbDataSourcePACS);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(0, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(524, 238);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            // 
            // rbServerNamePACS
            // 
            this.rbServerNamePACS.Checked = true;
            this.rbServerNamePACS.Location = new System.Drawing.Point(144, 11);
            this.rbServerNamePACS.Name = "rbServerNamePACS";
            this.rbServerNamePACS.Size = new System.Drawing.Size(112, 24);
            this.rbServerNamePACS.TabIndex = 64;
            this.rbServerNamePACS.TabStop = true;
            this.rbServerNamePACS.Text = "直接服务器连接";
            this.rbServerNamePACS.CheckedChanged += new System.EventHandler(this.rbServerNamePACS_CheckedChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(16, 16);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(65, 12);
            this.label23.TabIndex = 62;
            this.label23.Text = "连接类型：";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(16, 204);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 12);
            this.label26.TabIndex = 61;
            this.label26.Text = "登录密码：";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(16, 171);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(65, 12);
            this.label27.TabIndex = 60;
            this.label27.Text = "登录用户：";
            // 
            // txtPasswordPACS
            // 
            this.txtPasswordPACS.Location = new System.Drawing.Point(144, 201);
            this.txtPasswordPACS.Name = "txtPasswordPACS";
            this.txtPasswordPACS.PasswordChar = '*';
            this.txtPasswordPACS.Size = new System.Drawing.Size(240, 21);
            this.txtPasswordPACS.TabIndex = 59;
            // 
            // txtUserIDPACS
            // 
            this.txtUserIDPACS.Location = new System.Drawing.Point(144, 168);
            this.txtUserIDPACS.Name = "txtUserIDPACS";
            this.txtUserIDPACS.Size = new System.Drawing.Size(240, 21);
            this.txtUserIDPACS.TabIndex = 58;
            // 
            // txtDatabasePACS
            // 
            this.txtDatabasePACS.Location = new System.Drawing.Point(144, 134);
            this.txtDatabasePACS.Name = "txtDatabasePACS";
            this.txtDatabasePACS.Size = new System.Drawing.Size(240, 21);
            this.txtDatabasePACS.TabIndex = 57;
            // 
            // txtPortPACS
            // 
            this.txtPortPACS.Location = new System.Drawing.Point(144, 103);
            this.txtPortPACS.Name = "txtPortPACS";
            this.txtPortPACS.Size = new System.Drawing.Size(240, 21);
            this.txtPortPACS.TabIndex = 56;
            // 
            // txtProtocolPACS
            // 
            this.txtProtocolPACS.Location = new System.Drawing.Point(144, 73);
            this.txtProtocolPACS.Name = "txtProtocolPACS";
            this.txtProtocolPACS.Size = new System.Drawing.Size(240, 21);
            this.txtProtocolPACS.TabIndex = 55;
            // 
            // txtHostNamePACS
            // 
            this.txtHostNamePACS.Location = new System.Drawing.Point(144, 41);
            this.txtHostNamePACS.Name = "txtHostNamePACS";
            this.txtHostNamePACS.Size = new System.Drawing.Size(240, 21);
            this.txtHostNamePACS.TabIndex = 54;
            // 
            // lblDataNamePACS
            // 
            this.lblDataNamePACS.AutoSize = true;
            this.lblDataNamePACS.Location = new System.Drawing.Point(16, 136);
            this.lblDataNamePACS.Name = "lblDataNamePACS";
            this.lblDataNamePACS.Size = new System.Drawing.Size(65, 12);
            this.lblDataNamePACS.TabIndex = 53;
            this.lblDataNamePACS.Text = "数据库名：";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(16, 105);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(41, 12);
            this.label29.TabIndex = 52;
            this.label29.Text = "端口：";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(16, 75);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(41, 12);
            this.label30.TabIndex = 51;
            this.label30.Text = "协议：";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(16, 42);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(125, 12);
            this.label31.TabIndex = 50;
            this.label31.Text = "服务器名称（或IP）：";
            // 
            // rbDataSourcePACS
            // 
            this.rbDataSourcePACS.Location = new System.Drawing.Point(266, 11);
            this.rbDataSourcePACS.Name = "rbDataSourcePACS";
            this.rbDataSourcePACS.Size = new System.Drawing.Size(88, 24);
            this.rbDataSourcePACS.TabIndex = 63;
            this.rbDataSourcePACS.Text = "数据源连接";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox5);
            this.tabPage5.Location = new System.Drawing.Point(4, 21);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(524, 238);
            this.tabPage5.TabIndex = 6;
            this.tabPage5.Tag = "5";
            this.tabPage5.Text = "远程登录(LIS)";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtPasswordLis);
            this.groupBox5.Controls.Add(this.txtUserIDLis);
            this.groupBox5.Controls.Add(this.txtDatabaseLis);
            this.groupBox5.Controls.Add(this.txtPortLis);
            this.groupBox5.Controls.Add(this.txtProtocolLis);
            this.groupBox5.Controls.Add(this.txtHostNameLis);
            this.groupBox5.Controls.Add(this.rbDataSourceLis);
            this.groupBox5.Controls.Add(this.rbServerNameLis);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.label22);
            this.groupBox5.Controls.Add(this.lblDataNameLis);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(524, 238);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            // 
            // txtPasswordLis
            // 
            this.txtPasswordLis.Location = new System.Drawing.Point(144, 201);
            this.txtPasswordLis.Name = "txtPasswordLis";
            this.txtPasswordLis.PasswordChar = '*';
            this.txtPasswordLis.Size = new System.Drawing.Size(240, 21);
            this.txtPasswordLis.TabIndex = 10;
            // 
            // txtUserIDLis
            // 
            this.txtUserIDLis.Location = new System.Drawing.Point(144, 168);
            this.txtUserIDLis.Name = "txtUserIDLis";
            this.txtUserIDLis.Size = new System.Drawing.Size(240, 21);
            this.txtUserIDLis.TabIndex = 9;
            // 
            // txtDatabaseLis
            // 
            this.txtDatabaseLis.Location = new System.Drawing.Point(144, 134);
            this.txtDatabaseLis.Name = "txtDatabaseLis";
            this.txtDatabaseLis.Size = new System.Drawing.Size(240, 21);
            this.txtDatabaseLis.TabIndex = 8;
            // 
            // txtPortLis
            // 
            this.txtPortLis.Location = new System.Drawing.Point(144, 103);
            this.txtPortLis.Name = "txtPortLis";
            this.txtPortLis.Size = new System.Drawing.Size(240, 21);
            this.txtPortLis.TabIndex = 7;
            // 
            // txtProtocolLis
            // 
            this.txtProtocolLis.Location = new System.Drawing.Point(144, 73);
            this.txtProtocolLis.Name = "txtProtocolLis";
            this.txtProtocolLis.Size = new System.Drawing.Size(240, 21);
            this.txtProtocolLis.TabIndex = 6;
            // 
            // txtHostNameLis
            // 
            this.txtHostNameLis.Location = new System.Drawing.Point(144, 41);
            this.txtHostNameLis.Name = "txtHostNameLis";
            this.txtHostNameLis.Size = new System.Drawing.Size(240, 21);
            this.txtHostNameLis.TabIndex = 5;
            // 
            // rbDataSourceLis
            // 
            this.rbDataSourceLis.Location = new System.Drawing.Point(266, 11);
            this.rbDataSourceLis.Name = "rbDataSourceLis";
            this.rbDataSourceLis.Size = new System.Drawing.Size(104, 24);
            this.rbDataSourceLis.TabIndex = 4;
            this.rbDataSourceLis.Text = "数据源连接";
            // 
            // rbServerNameLis
            // 
            this.rbServerNameLis.Checked = true;
            this.rbServerNameLis.Location = new System.Drawing.Point(144, 11);
            this.rbServerNameLis.Name = "rbServerNameLis";
            this.rbServerNameLis.Size = new System.Drawing.Size(112, 24);
            this.rbServerNameLis.TabIndex = 3;
            this.rbServerNameLis.TabStop = true;
            this.rbServerNameLis.Text = "直接服务器连接";
            this.rbServerNameLis.CheckedChanged += new System.EventHandler(this.rbServerNameLis_CheckedChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(16, 75);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 12);
            this.label21.TabIndex = 2;
            this.label21.Text = "协议：";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(16, 42);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(125, 12);
            this.label20.TabIndex = 1;
            this.label20.Text = "服务器名称（或IP）：";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(16, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 12);
            this.label19.TabIndex = 0;
            this.label19.Text = "连接类型：";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(16, 105);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 12);
            this.label22.TabIndex = 2;
            this.label22.Text = "端口：";
            // 
            // lblDataNameLis
            // 
            this.lblDataNameLis.AutoSize = true;
            this.lblDataNameLis.Location = new System.Drawing.Point(16, 136);
            this.lblDataNameLis.Name = "lblDataNameLis";
            this.lblDataNameLis.Size = new System.Drawing.Size(65, 12);
            this.lblDataNameLis.TabIndex = 2;
            this.lblDataNameLis.Text = "数据库名：";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(16, 171);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(65, 12);
            this.label24.TabIndex = 2;
            this.label24.Text = "登录用户：";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(16, 204);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(65, 12);
            this.label25.TabIndex = 2;
            this.label25.Text = "登录密码：";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Location = new System.Drawing.Point(4, 21);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(524, 238);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Tag = "4";
            this.tabPage4.Text = "医保服务器";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtPasswordyb);
            this.groupBox3.Controls.Add(this.txtUserIDyb);
            this.groupBox3.Controls.Add(this.txtDatabaseyb);
            this.groupBox3.Controls.Add(this.txtHostNameyb);
            this.groupBox3.Controls.Add(this.lblDataNameyb);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(524, 238);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 46;
            this.label10.Text = "登录密码：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 45;
            this.label11.Text = "登录用户：";
            // 
            // txtPasswordyb
            // 
            this.txtPasswordyb.Location = new System.Drawing.Point(144, 162);
            this.txtPasswordyb.Name = "txtPasswordyb";
            this.txtPasswordyb.PasswordChar = '*';
            this.txtPasswordyb.Size = new System.Drawing.Size(240, 21);
            this.txtPasswordyb.TabIndex = 44;
            // 
            // txtUserIDyb
            // 
            this.txtUserIDyb.Location = new System.Drawing.Point(144, 126);
            this.txtUserIDyb.Name = "txtUserIDyb";
            this.txtUserIDyb.Size = new System.Drawing.Size(240, 21);
            this.txtUserIDyb.TabIndex = 43;
            // 
            // txtDatabaseyb
            // 
            this.txtDatabaseyb.Location = new System.Drawing.Point(144, 90);
            this.txtDatabaseyb.Name = "txtDatabaseyb";
            this.txtDatabaseyb.Size = new System.Drawing.Size(240, 21);
            this.txtDatabaseyb.TabIndex = 42;
            // 
            // txtHostNameyb
            // 
            this.txtHostNameyb.Location = new System.Drawing.Point(144, 56);
            this.txtHostNameyb.Name = "txtHostNameyb";
            this.txtHostNameyb.Size = new System.Drawing.Size(240, 21);
            this.txtHostNameyb.TabIndex = 39;
            // 
            // lblDataNameyb
            // 
            this.lblDataNameyb.AutoSize = true;
            this.lblDataNameyb.Location = new System.Drawing.Point(16, 93);
            this.lblDataNameyb.Name = "lblDataNameyb";
            this.lblDataNameyb.Size = new System.Drawing.Size(65, 12);
            this.lblDataNameyb.TabIndex = 38;
            this.lblDataNameyb.Text = "数据库名：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 57);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(125, 12);
            this.label15.TabIndex = 35;
            this.label15.Text = "服务器名称（或IP）：";
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(532, 321);
            this.Controls.Add(this.tbctrlDataSource);
            this.Controls.Add(this.btTest);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "客户端配置";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tbctrlDataSource.ResumeLayout(false);
            this.tabPage0.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage10.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}
		#region 方法
		/// <summary>
		/// 获取INI信息
		/// </summary>
		/// <param name="type"></param>
		private void GetIniInformation(int type)
		{
			string strCnnType="";
			switch(type)
			{
				case 0:		//远程门诊
					txtHostName.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER","HOSTNAME",Constant.ApplicationDirectory+"\\Server.ini"));
					txtHostName.Tag=txtHostName.Text;
					txtProtocol.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER","PROTOCOL",Constant.ApplicationDirectory+"\\Server.ini"));
					txtProtocol.Tag=txtProtocol.Text;
					txtPort.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER","PORT",Constant.ApplicationDirectory+"\\Server.ini"));
					txtPort.Tag=txtPort.Text;
					txtDatabase.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER","DATASOURCE",Constant.ApplicationDirectory+"\\Server.ini"));
					txtUserID.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER","USER_ID",Constant.ApplicationDirectory+"\\Server.ini"));
					txtPassword.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER","PASSWORD",Constant.ApplicationDirectory+"\\Server.ini"));
					strCnnType=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER","CONNECTIONTYPE",Constant.ApplicationDirectory+"\\Server.ini"));
					if(strCnnType=="1")
					{
						rbDataSource.Checked=true;
					}
					break;
				case 1:		//远程住院
					txtHostNamezy.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_ZY","HOSTNAME",Constant.ApplicationDirectory+"\\Server.ini"));
					txtHostNamezy.Tag=txtHostNamezy.Text;
					txtProtocolzy.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_ZY","PROTOCOL",Constant.ApplicationDirectory+"\\Server.ini"));
					txtProtocolzy.Tag=txtProtocolzy.Text;
					txtPortzy.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_ZY","PORT",Constant.ApplicationDirectory+"\\Server.ini"));
					txtPortzy.Tag=txtPortzy.Text;
					txtDatabasezy.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_ZY","DATASOURCE",Constant.ApplicationDirectory+"\\Server.ini"));
					txtUserIDzy.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_ZY","USER_ID",Constant.ApplicationDirectory+"\\Server.ini"));
					txtPasswordzy.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_ZY","PASSWORD",Constant.ApplicationDirectory+"\\Server.ini"));
					strCnnType=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_ZY","CONNECTIONTYPE",Constant.ApplicationDirectory+"\\Server.ini"));
					if(strCnnType=="1")
					{
						rbDataSourcezy.Checked=true;
					}
					break;
				case 2:		//远程药品
					txtHostNameyp.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_YP","HOSTNAME",Constant.ApplicationDirectory+"\\Server.ini"));
					txtHostNameyp.Tag=txtHostNameyp.Text;
					txtProtocolyp.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_YP","PROTOCOL",Constant.ApplicationDirectory+"\\Server.ini"));
					txtProtocolyp.Tag=txtProtocolyp.Text;
					txtPortyp.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_YP","PORT",Constant.ApplicationDirectory+"\\Server.ini"));
					txtPortyp.Tag=txtPortyp.Text;
					txtDatabaseyp.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_YP","DATASOURCE",Constant.ApplicationDirectory+"\\Server.ini"));
					txtUserIDyp.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_YP","USER_ID",Constant.ApplicationDirectory+"\\Server.ini"));
					txtPasswordyp.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_YP","PASSWORD",Constant.ApplicationDirectory+"\\Server.ini"));
					strCnnType=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_YP","CONNECTIONTYPE",Constant.ApplicationDirectory+"\\Server.ini"));
					if(strCnnType=="1")
					{
						rbDataSourceyp.Checked=true;
					}
					break;
				case 3:		//本机Access
					txtLocalDBPath.Text =Crypto.Instance().UnCryp(ApiFunction.GetIniString("LOCALSERVER","DATASOURCE",Constant.ApplicationDirectory+"\\Server.ini"));
					break;
				case 4:		//医保
					txtHostNameyb.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_YB","HOSTNAME",Constant.ApplicationDirectory+"\\Server.ini"));
					txtHostNameyb.Tag=txtHostNameyb.Text;
					txtDatabaseyb.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_YB","DATASOURCE",Constant.ApplicationDirectory+"\\Server.ini"));
					txtUserIDyb.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_YB","USER_ID",Constant.ApplicationDirectory+"\\Server.ini"));
					txtPasswordyb.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_YB","PASSWORD",Constant.ApplicationDirectory+"\\Server.ini"));
					break;
				case 5:		//LIS
					txtHostNameLis.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_LIS","HOSTNAME",Constant.ApplicationDirectory+"\\Server.ini"));
					txtHostNameLis.Tag=txtHostNameLis.Text;
					txtProtocolLis.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_LIS","PROTOCOL",Constant.ApplicationDirectory+"\\Server.ini"));
					txtProtocolLis.Tag=txtProtocolLis.Text;
					txtPortLis.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_LIS","PORT",Constant.ApplicationDirectory+"\\Server.ini"));
					txtPortLis.Tag=txtPortLis.Text;
					txtDatabaseLis.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_LIS","DATASOURCE",Constant.ApplicationDirectory+"\\Server.ini"));
					txtUserIDLis.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_LIS","USER_ID",Constant.ApplicationDirectory+"\\Server.ini"));
					txtPasswordLis.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_LIS","PASSWORD",Constant.ApplicationDirectory+"\\Server.ini"));
					strCnnType=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_LIS","CONNECTIONTYPE",Constant.ApplicationDirectory+"\\Server.ini"));
					if(strCnnType=="1")
					{
						rbDataSourceLis.Checked=true;
					}
					break;
				case 6:		//其他设置
					txtCustomDirectory.Text =Crypto.Instance().UnCryp(ApiFunction.GetIniString("CUSTOMDIRRECTORY","DIRECTORY",Constant.ApplicationDirectory+"\\Server.ini"));
					break;
				case 7:		//RIS
					txtHostNameRis.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_RIS","HOSTNAME",Constant.ApplicationDirectory+"\\Server.ini"));
					txtHostNameRis.Tag=txtHostNameRis.Text;
					txtProtocolRis.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_RIS","PROTOCOL",Constant.ApplicationDirectory+"\\Server.ini"));
					txtProtocolRis.Tag=txtProtocolRis.Text;
					txtPortRis.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_RIS","PORT",Constant.ApplicationDirectory+"\\Server.ini"));
					txtPortRis.Tag=txtPortRis.Text;
					txtDatabaseRis.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_RIS","DATASOURCE",Constant.ApplicationDirectory+"\\Server.ini"));
					txtUserIDRis.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_RIS","USER_ID",Constant.ApplicationDirectory+"\\Server.ini"));
					txtPasswordRis.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_RIS","PASSWORD",Constant.ApplicationDirectory+"\\Server.ini"));
					strCnnType=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_RIS","CONNECTIONTYPE",Constant.ApplicationDirectory+"\\Server.ini"));
					if(strCnnType=="1")
					{
						rbDataSourceRis.Checked=true;
					}
					break;
				case 8:		//PACS
					txtHostNamePACS.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_PACS","HOSTNAME",Constant.ApplicationDirectory+"\\Server.ini"));
					txtHostNamePACS.Tag=txtHostNamePACS.Text;
					txtProtocolPACS.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_PACS","PROTOCOL",Constant.ApplicationDirectory+"\\Server.ini"));
					txtProtocolPACS.Tag=txtProtocolPACS.Text;
					txtPortPACS.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_PACS","PORT",Constant.ApplicationDirectory+"\\Server.ini"));
					txtPortPACS.Tag=txtPortPACS.Text;
					txtDatabasePACS.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_PACS","DATASOURCE",Constant.ApplicationDirectory+"\\Server.ini"));
					txtUserIDPACS.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_PACS","USER_ID",Constant.ApplicationDirectory+"\\Server.ini"));
					txtPasswordPACS.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_PACS","PASSWORD",Constant.ApplicationDirectory+"\\Server.ini"));
					strCnnType=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_PACS","CONNECTIONTYPE",Constant.ApplicationDirectory+"\\Server.ini"));
					if(strCnnType=="1")
					{
						rbDataSourcePACS.Checked=true;
					}
					break;
				case 9:		//Update
					txtHostNameUpdate.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_UPDATE","HOSTNAME",Constant.ApplicationDirectory+"\\Server.ini"));
					txtHostNameUpdate.Tag=txtHostNameUpdate.Text;
					txtProtocolUpdate.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_UPDATE","PROTOCOL",Constant.ApplicationDirectory+"\\Server.ini"));
					txtProtocolUpdate.Tag=txtProtocolUpdate.Text;
					txtPortUpdate.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_UPDATE","PORT",Constant.ApplicationDirectory+"\\Server.ini"));
					txtPortUpdate.Tag=txtPortUpdate.Text;
					txtDatabaseUpdate.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_UPDATE","DATASOURCE",Constant.ApplicationDirectory+"\\Server.ini"));
					txtUserIDUpdate.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_UPDATE","USER_ID",Constant.ApplicationDirectory+"\\Server.ini"));
					txtPasswordUpdate.Text=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_UPDATE","PASSWORD",Constant.ApplicationDirectory+"\\Server.ini"));
					strCnnType=Crypto.Instance().UnCryp(ApiFunction.GetIniString("SERVER_UPDATE","CONNECTIONTYPE",Constant.ApplicationDirectory+"\\Server.ini"));
					if(strCnnType=="1")
					{
						rbDataSourceUpdate.Checked=true;
					}
					break;
				default :
					break;
			}
		}
		#endregion

		#region 事件
		private void frmMain_Load(object sender, System.EventArgs e)
		{
			//登录信息
			GetIniInformation(0);
			GetIniInformation(1);
			GetIniInformation(2);
			GetIniInformation(3);
			GetIniInformation(4);
			GetIniInformation(5);
			GetIniInformation(6);
			GetIniInformation(7);
			GetIniInformation(8);
			GetIniInformation(9);
		}

		private void btCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btOK_Click(object sender, System.EventArgs e)
		{
			//设置数据库连接信息
			//门诊
			ApiFunction.WriteIniString("SERVER","HOSTNAME",Crypto.Instance().Cryp(txtHostName.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER","PROTOCOL",Crypto.Instance().Cryp(txtProtocol.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER","PORT",Crypto.Instance().Cryp(txtPort.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER","DATASOURCE",Crypto.Instance().Cryp(txtDatabase.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER","USER_ID",Crypto.Instance().Cryp(txtUserID.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER","PASSWORD",Crypto.Instance().Cryp(txtPassword.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER","CONNECTIONTYPE",Crypto.Instance().Cryp(rbServerName.Checked ?"0":"1"),Constant.ApplicationDirectory+"\\Server.ini");
			//住院
			ApiFunction.WriteIniString("SERVER_ZY","HOSTNAME",Crypto.Instance().Cryp(txtHostNamezy.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_ZY","PROTOCOL",Crypto.Instance().Cryp(txtProtocolzy.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_ZY","PORT",Crypto.Instance().Cryp(txtPortzy.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_ZY","DATASOURCE",Crypto.Instance().Cryp(txtDatabasezy.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_ZY","USER_ID",Crypto.Instance().Cryp(txtUserIDzy.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_ZY","PASSWORD",Crypto.Instance().Cryp(txtPasswordzy.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_ZY","CONNECTIONTYPE",Crypto.Instance().Cryp(rbServerNamezy.Checked ?"0":"1"),Constant.ApplicationDirectory+"\\Server.ini");
			//药品
			ApiFunction.WriteIniString("SERVER_YP","HOSTNAME",Crypto.Instance().Cryp(txtHostNameyp.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_YP","PROTOCOL",Crypto.Instance().Cryp(txtProtocolyp.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_YP","PORT",Crypto.Instance().Cryp(txtPortyp.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_YP","DATASOURCE",Crypto.Instance().Cryp(txtDatabaseyp.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_YP","USER_ID",Crypto.Instance().Cryp(txtUserIDyp.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_YP","PASSWORD",Crypto.Instance().Cryp(txtPasswordyp.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_YP","CONNECTIONTYPE",Crypto.Instance().Cryp(rbServerNameyp.Checked ?"0":"1"),Constant.ApplicationDirectory+"\\Server.ini");
			//本机
			ApiFunction.WriteIniString("LOCALSERVER","DATASOURCE",Crypto.Instance().Cryp(txtLocalDBPath.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			//医保
			ApiFunction.WriteIniString("SERVER_YB","HOSTNAME",Crypto.Instance().Cryp(txtHostNameyb.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_YB","DATASOURCE",Crypto.Instance().Cryp(txtDatabaseyb.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_YB","USER_ID",Crypto.Instance().Cryp(txtUserIDyb.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_YB","PASSWORD",Crypto.Instance().Cryp(txtPasswordyb.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			//LIS
			ApiFunction.WriteIniString("SERVER_LIS","HOSTNAME",Crypto.Instance().Cryp(txtHostNameLis.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_LIS","PROTOCOL",Crypto.Instance().Cryp(txtProtocolLis.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_LIS","PORT",Crypto.Instance().Cryp(txtPortLis.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_LIS","DATASOURCE",Crypto.Instance().Cryp(txtDatabaseLis.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_LIS","USER_ID",Crypto.Instance().Cryp(txtUserIDLis.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_LIS","PASSWORD",Crypto.Instance().Cryp(txtPasswordLis.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_LIS","CONNECTIONTYPE",Crypto.Instance().Cryp(rbServerNameLis.Checked ?"0":"1"),Constant.ApplicationDirectory+"\\Server.ini");
			//RIS
			ApiFunction.WriteIniString("SERVER_RIS","HOSTNAME",Crypto.Instance().Cryp(txtHostNameRis.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_RIS","PROTOCOL",Crypto.Instance().Cryp(txtProtocolRis.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_RIS","PORT",Crypto.Instance().Cryp(txtPortRis.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_RIS","DATASOURCE",Crypto.Instance().Cryp(txtDatabaseRis.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_RIS","USER_ID",Crypto.Instance().Cryp(txtUserIDRis.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_RIS","PASSWORD",Crypto.Instance().Cryp(txtPasswordRis.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_RIS","CONNECTIONTYPE",Crypto.Instance().Cryp(rbServerNameRis.Checked ?"0":"1"),Constant.ApplicationDirectory+"\\Server.ini");
			//PACS
			ApiFunction.WriteIniString("SERVER_PACS","HOSTNAME",Crypto.Instance().Cryp(txtHostNamePACS.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_PACS","PROTOCOL",Crypto.Instance().Cryp(txtProtocolPACS.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_PACS","PORT",Crypto.Instance().Cryp(txtPortPACS.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_PACS","DATASOURCE",Crypto.Instance().Cryp(txtDatabasePACS.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_PACS","USER_ID",Crypto.Instance().Cryp(txtUserIDPACS.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_PACS","PASSWORD",Crypto.Instance().Cryp(txtPasswordPACS.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_PACS","CONNECTIONTYPE",Crypto.Instance().Cryp(rbServerNamePACS.Checked ?"0":"1"),Constant.ApplicationDirectory+"\\Server.ini");
			//升级
			ApiFunction.WriteIniString("SERVER_UPDATE","HOSTNAME",Crypto.Instance().Cryp(txtHostNameUpdate.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_UPDATE","PROTOCOL",Crypto.Instance().Cryp(txtProtocolUpdate.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_UPDATE","PORT",Crypto.Instance().Cryp(txtPortUpdate.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_UPDATE","DATASOURCE",Crypto.Instance().Cryp(txtDatabaseUpdate.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_UPDATE","USER_ID",Crypto.Instance().Cryp(txtUserIDUpdate.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_UPDATE","PASSWORD",Crypto.Instance().Cryp(txtPasswordUpdate.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			ApiFunction.WriteIniString("SERVER_UPDATE","CONNECTIONTYPE",Crypto.Instance().Cryp(rbServerNameUpdate.Checked ?"0":"1"),Constant.ApplicationDirectory+"\\Server.ini");
			//自定义路径
			ApiFunction.WriteIniString("CUSTOMDIRRECTORY","DIRECTORY",Crypto.Instance().Cryp(txtCustomDirectory.Text.Trim()),Constant.ApplicationDirectory+"\\Server.ini");
			this.Close();
		}

		private void btTest_Click(object sender, System.EventArgs e)
		{
			this.Cursor =Cursors.WaitCursor;
			string cnnString="";
			switch(Convert.ToInt32(tbctrlDataSource.SelectedTab.Tag))
			{
				case 0://门诊
					if(rbServerName.Checked)
						cnnString=@"Provider=IBMDADB2;Database="+txtDatabase.Text.Trim()+";HostName="+txtHostName.Text.Trim()+";Protocol="+txtProtocol.Text.Trim()+";Port="+txtPort.Text.Trim()+";User ID="+txtUserID.Text.Trim()+";Password="+txtPassword.Text.Trim();
					else
						cnnString=@"Provider=IBMDADB2.1;User ID="+txtUserID.Text.Trim()+";Password="+txtPassword.Text.Trim()+";Data Source="+txtDatabase.Text.Trim()+";Mode=ReadWrite;Extended Properties=";
					break;
				case 1://住院
					if(rbServerNamezy.Checked)
						cnnString=@"Provider=IBMDADB2;Database="+txtDatabasezy.Text.Trim()+";HostName="+txtHostNamezy.Text.Trim()+";Protocol="+txtProtocolzy.Text.Trim()+";Port="+txtPortzy.Text.Trim()+";User ID="+txtUserIDzy.Text.Trim()+";Password="+txtPasswordzy.Text.Trim();
					else
						cnnString=@"Provider=IBMDADB2.1;User ID="+txtUserIDzy.Text.Trim()+";Password="+txtPasswordzy.Text.Trim()+";Data Source="+txtDatabasezy.Text.Trim()+";Mode=ReadWrite;Extended Properties=";
					break;
				case 2://药品
					if(rbServerNameyp.Checked)
						cnnString=@"Provider=IBMDADB2;Database="+txtDatabaseyp.Text.Trim()+";HostName="+txtHostNameyp.Text.Trim()+";Protocol="+txtProtocolyp.Text.Trim()+";Port="+txtPortyp.Text.Trim()+";User ID="+txtUserIDyp.Text.Trim()+";Password="+txtPasswordyp.Text.Trim();
					else
						cnnString=@"Provider=IBMDADB2.1;User ID="+txtUserIDyp.Text.Trim()+";Password="+txtPasswordyp.Text.Trim()+";Data Source="+txtDatabaseyp.Text.Trim()+";Mode=ReadWrite;Extended Properties=";
					break;
				case 3://本机登录
					cnnString=@"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Data Source="+txtLocalDBPath.Text.Trim()+";Mode=Share Deny None;Jet OLEDB:Engine Type=5;Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:System database=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1";
					break;
				case 4://医保数据库
					cnnString=@"packet size=4096;user id="+txtUserIDyb.Text.Trim()+";password="+txtPasswordyb.Text.Trim()+";data source="+txtHostNameyb.Text.Trim()+";persist security info=True;initial catalog="+txtDatabaseyb.Text.Trim();
					break;
				case 5://LIS数据库
					if(rbServerNameLis.Checked)
						cnnString=@"Provider=IBMDADB2;Database="+txtDatabaseLis.Text.Trim()+";HostName="+txtHostNameLis.Text.Trim()+";Protocol="+txtProtocolLis.Text.Trim()+";Port="+txtPortLis.Text.Trim()+";User ID="+txtUserIDLis.Text.Trim()+";Password="+txtPasswordLis.Text.Trim();
					else
						cnnString=@"Provider=IBMDADB2.1;User ID="+txtUserIDLis.Text.Trim()+";Password="+txtPasswordLis.Text.Trim()+";Data Source="+txtDatabaseLis.Text.Trim()+";Mode=ReadWrite;Extended Properties=";
					break;
				case 7://RIS数据库
					if(rbServerNameRis.Checked)
						cnnString=@"Provider=IBMDADB2;Database="+txtDatabaseRis.Text.Trim()+";HostName="+txtHostNameRis.Text.Trim()+";Protocol="+txtProtocolRis.Text.Trim()+";Port="+txtPortRis.Text.Trim()+";User ID="+txtUserIDRis.Text.Trim()+";Password="+txtPasswordRis.Text.Trim();
					else
						cnnString=@"Provider=IBMDADB2.1;User ID="+txtUserIDRis.Text.Trim()+";Password="+txtPasswordRis.Text.Trim()+";Data Source="+txtDatabaseRis.Text.Trim()+";Mode=ReadWrite;Extended Properties=";
					break;
				case 8://PACS数据库
					if(rbServerNamePACS.Checked)
						cnnString=@"Provider=IBMDADB2;Database="+txtDatabasePACS.Text.Trim()+";HostName="+txtHostNamePACS.Text.Trim()+";Protocol="+txtProtocolPACS.Text.Trim()+";Port="+txtPortPACS.Text.Trim()+";User ID="+txtUserIDPACS.Text.Trim()+";Password="+txtPasswordPACS.Text.Trim();
					else
						cnnString=@"Provider=IBMDADB2.1;User ID="+txtUserIDPACS.Text.Trim()+";Password="+txtPasswordPACS.Text.Trim()+";Data Source="+txtDatabasePACS.Text.Trim()+";Mode=ReadWrite;Extended Properties=";
					break;
				case 9://升级数据库
					if(rbServerNameUpdate.Checked)
						cnnString=@"Provider=IBMDADB2;Database="+txtDatabaseUpdate.Text.Trim()+";HostName="+txtHostNameUpdate.Text.Trim()+";Protocol="+txtProtocolUpdate.Text.Trim()+";Port="+txtPortUpdate.Text.Trim()+";User ID="+txtUserIDUpdate.Text.Trim()+";Password="+txtPasswordUpdate.Text.Trim();
					else
						cnnString=@"Provider=IBMDADB2.1;User ID="+txtUserIDUpdate.Text.Trim()+";Password="+txtPasswordUpdate.Text.Trim()+";Data Source="+txtDatabaseUpdate.Text.Trim()+";Mode=ReadWrite;Extended Properties=";
					break;
				default :
					break;

			}
			if(cnnString=="") 
			{
				this.Cursor =Cursors.Default;
				return;
			}
			if(Convert.ToInt32(tbctrlDataSource.SelectedTab.Tag)==4)
			{
				try
				{
					//获得连接
					SqlConnection sqlcnn=new SqlConnection(cnnString);
					sqlcnn.Open();
					sqlcnn.Close();
					this.Cursor =Cursors.Default;
					MessageBox.Show("数据库连接成功！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
				catch(SqlException err)
				{
					this.Cursor =Cursors.Default;
					MessageBox.Show("数据库连接失败：\n"+err.Message,"错误",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				}
			}
			else
			{
				try
				{
					//获得连接
					OleDbConnection cnn=new OleDbConnection(cnnString);
					cnn.Open();
					cnn.Close();
					this.Cursor =Cursors.Default;
					MessageBox.Show("数据库连接成功！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
				catch(OleDbException err)
				{
					this.Cursor =Cursors.Default;
					MessageBox.Show("数据库连接失败：\n"+err.Message,"错误",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				}
			}
		}

		private void rbServerName_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rbServerName.Checked)
			{
				txtHostName.Enabled=true;
				txtHostName.Text=Convert.ToString(txtHostName.Tag);
				txtProtocol.Enabled =true;
				txtProtocol.Text=Convert.ToString(txtProtocol.Tag);
				txtPort.Enabled =true;
				txtPort.Text=Convert.ToString(txtPort.Tag);
				lblDataName.Text="数据库名：";
			}
			else
			{
				txtHostName.Enabled=false;
				txtHostName.Text="";
				txtProtocol.Enabled =false;
				txtProtocol.Text="";
				txtPort.Enabled =false;
				txtPort.Text="";
				lblDataName.Text="数据源名：";
			}
		}

		private void rbServerNamezy_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rbServerNamezy.Checked)
			{
				txtHostNamezy.Enabled=true;
				txtHostNamezy.Text=Convert.ToString(txtHostNamezy.Tag);
				txtProtocolzy.Enabled =true;
				txtProtocolzy.Text=Convert.ToString(txtProtocolzy.Tag);
				txtPortzy.Enabled =true;
				txtPortzy.Text=Convert.ToString(txtPortzy.Tag);
				lblDataNamezy.Text="数据库名：";
			}
			else
			{
				txtHostNamezy.Enabled=false;
				txtHostNamezy.Text="";
				txtProtocolzy.Enabled =false;
				txtProtocolzy.Text="";
				txtPortzy.Enabled =false;
				txtPortzy.Text="";
				lblDataNamezy.Text="数据源名：";
			}
		}
		private void rbServerNameyp_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rbServerNameyp.Checked)
			{
				txtHostNameyp.Enabled=true;
				txtHostNameyp.Text=Convert.ToString(txtHostNameyp.Tag);
				txtProtocolyp.Enabled =true;
				txtProtocolyp.Text=Convert.ToString(txtProtocolyp.Tag);
				txtPortyp.Enabled =true;
				txtPortyp.Text=Convert.ToString(txtPortyp.Tag);
				lblDataNameyp.Text="数据库名：";
			}
			else
			{
				txtHostNameyp.Enabled=false;
				txtHostNameyp.Text="";
				txtProtocolyp.Enabled =false;
				txtProtocolyp.Text="";
				txtPortyp.Enabled =false;
				txtPortyp.Text="";
				lblDataNameyp.Text="数据源名：";
			}
		}
		private void rbServerNameLis_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rbServerNameLis.Checked)
			{
				txtHostNameLis.Enabled=true;
				txtHostNameLis.Text=Convert.ToString(txtHostNameLis.Tag);
				txtProtocolLis.Enabled =true;
				txtProtocolLis.Text=Convert.ToString(txtProtocolLis.Tag);
				txtPortLis.Enabled =true;
				txtPortLis.Text=Convert.ToString(txtPortLis.Tag);
				lblDataNameLis.Text="数据库名：";
			}
			else
			{
				txtHostNameLis.Enabled=false;
				txtHostNameLis.Text="";
				txtProtocolLis.Enabled =false;
				txtProtocolLis.Text="";
				txtPortLis.Enabled =false;
				txtPortLis.Text="";
				lblDataNameLis.Text="数据源名：";
			}
		}
		private void rbServerNameRis_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rbServerNameRis.Checked)
			{
				txtHostNameRis.Enabled=true;
				txtHostNameRis.Text=Convert.ToString(txtHostNameRis.Tag);
				txtProtocolRis.Enabled =true;
				txtProtocolRis.Text=Convert.ToString(txtProtocolRis.Tag);
				txtPortRis.Enabled =true;
				txtPortRis.Text=Convert.ToString(txtPortRis.Tag);
				lblDataNameRis.Text="数据库名：";
			}
			else
			{
				txtHostNameRis.Enabled=false;
				txtHostNameRis.Text="";
				txtProtocolRis.Enabled =false;
				txtProtocolRis.Text="";
				txtPortRis.Enabled =false;
				txtPortRis.Text="";
				lblDataNameRis.Text="数据源名：";
			}
		}
		private void rbServerNamePACS_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rbServerNamePACS.Checked)
			{
				txtHostNamePACS.Enabled=true;
				txtHostNamePACS.Text=Convert.ToString(txtHostNamePACS.Tag);
				txtProtocolPACS.Enabled =true;
				txtProtocolPACS.Text=Convert.ToString(txtProtocolPACS.Tag);
				txtPortPACS.Enabled =true;
				txtPortPACS.Text=Convert.ToString(txtPortPACS.Tag);
				lblDataNamePACS.Text="数据库名：";
			}
			else
			{
				txtHostNamePACS.Enabled=false;
				txtHostNamePACS.Text="";
				txtProtocolPACS.Enabled =false;
				txtProtocolPACS.Text="";
				txtPortPACS.Enabled =false;
				txtPortPACS.Text="";
				lblDataNamePACS.Text="数据源名：";
			}
		}
		private void rbServerNameUpdate_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rbServerNameUpdate.Checked)
			{
				txtHostNameUpdate.Enabled=true;
				txtHostNameUpdate.Text=Convert.ToString(txtHostNameUpdate.Tag);
				txtProtocolUpdate.Enabled =true;
				txtProtocolUpdate.Text=Convert.ToString(txtProtocolUpdate.Tag);
				txtPortUpdate.Enabled =true;
				txtPortUpdate.Text=Convert.ToString(txtPortUpdate.Tag);
				lblDataNameUpdate.Text="数据库名：";
			}
			else
			{
				txtHostNameUpdate.Enabled=false;
				txtHostNameUpdate.Text="";
				txtProtocolUpdate.Enabled =false;
				txtProtocolUpdate.Text="";
				txtPortUpdate.Enabled =false;
				txtPortUpdate.Text="";
				lblDataNameUpdate.Text="数据源名：";
			}
		}

		private void btnSearchPath_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog f=new OpenFileDialog();
			f.Filter ="Access数据库(*.mdb)|*.mdb";
			f.Title ="请选择数据库文件";
			f.Multiselect =false;
			if(f.ShowDialog()==DialogResult.OK)
			{
				txtLocalDBPath.Text =f.FileName;
			}
		}
		#endregion

        private void button1_Click(object sender, EventArgs e)
        {

        }




	}
}