using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HIS.SYSTEM.Core;
using HIS.SYSTEM.DatabaseAccessLayer;

namespace HIS_PublicManager.SystemTool.GenerateWorkers
{
    public partial class FrmMain : Form
    {
        public enum OPTYPE
        {
            新增,修改
        }

        public RelationalDatabase _Oledb = null;
        private OPTYPE _optype = OPTYPE.新增;
        public OPTYPE optype
        {
            set
            {
                _optype = value;
                if (_optype == OPTYPE.新增)
                {
                    this.button1.Enabled = true;
                    this.button2.Enabled = true;
                    this.button3.Enabled = false;
                    this.button4.Enabled = false;
                    this.textBox1.Text = "";
                    this.textBox2.Text = "";
                    this.textBox3.Text = "";
                    this.textBox4.Text = "";
                    this.textBox5.Text = "";
                    this.textBox4.Enabled = true;
                    this.textBox1.Enabled = true;
                }
                else
                {
                    this.button1.Enabled = true;
                    this.button2.Enabled = true;
                    this.button3.Enabled = true;
                    this.button4.Enabled = true;
                    this.textBox1.Enabled = false;
                    this.textBox4.Enabled = false;
                }
            }
            get
            {
                return _optype;
            }
        }
        public FrmMain()
        {
            InitializeComponent();
            EntityConfig.FrameWorkType = false;
            EntityConfig.DbType = HIS.SYSTEM.PubicBaseClasses.DatabaseType.IbmDb2;
            EntityConfig.ConnStr = EntityConfig.GetDefaultCnnString();
            _Oledb = new OleDB();

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            

            this.listView1.Items.Clear();

            string strsql = "select WORKID, WORKNO, WORKNAME from HIS_WORKERS";

            IDataReader idr= _Oledb.GetDataReader(strsql);
            while (idr.Read())
            {
                ListViewItem lstViewItem = new ListViewItem();

                lstViewItem.SubItems[0].Text = idr["workid"].ToString();
                lstViewItem.SubItems.Add(idr["Workno"].ToString());
                lstViewItem.SubItems.Add(idr["workname"].ToString());

                this.listView1.Items.Add(lstViewItem);
            }
        }

        int WorkID = 0;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            optype = OPTYPE.修改;

            
            if (this.listView1.SelectedItems.Count > 0)
            {
                WorkID = Convert.ToInt32(this.listView1.SelectedItems[0].Text);

                string strsql = "select  WORKNO, WORKNAME,WORKMEMO from HIS_WORKERS where WORKID=" + WorkID;
                DataRow dr = _Oledb.GetDataRow(strsql);
                this.textBox1.Text = dr["Workno"].ToString();
                this.textBox2.Text = dr["workname"].ToString();
                this.textBox3.Text = dr["workmemo"].ToString();

                strsql = "select a.CODE,b.NAME from  BASE_USER a,BASE_EMPLOYEE_PROPERTY b where a.workid=" + WorkID + " and a.ISADMIN=1 and  a.EMPLOYEE_ID=b.EMPLOYEE_ID ";
                dr = _Oledb.GetDataRow(strsql);
                this.textBox4.Text = dr["code"].ToString();
                this.textBox5.Text = dr["name"].ToString();
            }
        }

        private void 普通ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                this.listView1.Items[i].Checked = true;
            }
        }

        private void 高级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                if (this.listView1.Items[i].Checked)
                {
                    this.listView1.Items[i].Checked = false;
                }
                else
                {
                    this.listView1.Items[i].Checked = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            optype = OPTYPE.新增;

           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim() == "" || this.textBox4.Text.Trim() == "")
            {
                MessageBox.Show("医疗机构编码和用户名不能为空！");
                return;
            }
            

            if (optype == OPTYPE.新增)
            {
                string Workno = this.textBox1.Text.Trim().ToUpper();
                string strsql = "select count(*) from HIS_WORKERS where Ucase(workno)='" + Workno + "'";
                if (Convert.ToInt32(_Oledb.GetDataResult(strsql)) > 0)
                {
                    MessageBox.Show("医疗机构编码已经存在，不能重复添加！");
                    this.textBox1.Focus();
                    return;
                }
                string Code = this.textBox4.Text.Trim().ToUpper();
                strsql = "select count(*) from base_user where ucase(code)='" + Code + "'";
                if (Convert.ToInt32(_Oledb.GetDataResult(strsql)) > 0)
                {
                    MessageBox.Show("此用户名已经存在，不能重复添加！");
                    this.textBox4.Focus();
                    return;
                }
                if (MessageBox.Show("医疗机构编码和用户名保存后就不允许修改，是否继续保存？", "询问", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                object WorkID, LayerID, GroupID, EmployeeID, UserID;
                string strsql_work = @"insert into his_workers(WORKNO, WORKNAME, WORKMEMO,CRYP_FLAG, PASSLENGTH, PASSBACK) 
                            values('" + Workno + "','" + this.textBox2.Text.Trim() + "','" + this.textBox3.Text.Trim() + "',0,4,0)";
                string strsql_layer = @"insert into base_dept_layer(P_LAYER_ID, NAME, WORKID) values(0,'全院',{0})";

                string strsql_dept = @"insert into base_dept_property(P_DEPT_ID, LAYER,  NAME,  MZ_FLAG, ZY_FLAG, YJ_FLAG, JZ_FLAG, DELETED, ISFACT,
                                 WORKID)
                                values({0},0,'信息科',0,0,0,0,0,1,
                                 {1})";
                string strsql_group = @"insert into base_group(NAME, DELETE_FLAG, ADMINISTRATORS, EVERYONE,WORKID)
                                values('超级用户组',0,1,0,{0})";
                string strsql_employee = @"insert into base_employee_property(NAME, SEX, STATUS, DELETE_BIT, 
                                 WORKID)
                                values('" + this.textBox5.Text.Trim() + "',0,0,0,{0})";
                string strsql_user = @"insert into base_user(EMPLOYEE_ID, CODE, PASSWORD, GROUP_ID, WORKID, ISADMIN)
                                values({0},'" + Code + "','1',{1},{2},1)";
                string strsql_GROUP_USER = @"insert into BASE_GROUP_USER(USER_ID, GROUP_ID, WORKID)
                                values({0},{1},{2})";
                try
                {
                    //_Oledb = new OleDB();
                    _Oledb.BeginTransaction();
                    _Oledb.InsertRecord(strsql_work, out WorkID);

                    strsql_layer = String.Format(strsql_layer, WorkID);
                    _Oledb.InsertRecord(strsql_layer, out LayerID);

                    strsql_dept = string.Format(strsql_dept, LayerID, WorkID);
                    _Oledb.DoCommand(strsql_dept);

                    strsql_group = string.Format(strsql_group, WorkID);
                    _Oledb.InsertRecord(strsql_group, out GroupID);

                    strsql_employee = string.Format(strsql_employee, WorkID);
                    _Oledb.InsertRecord(strsql_employee, out EmployeeID);

                    strsql_user = string.Format(strsql_user, EmployeeID, GroupID, WorkID);
                    _Oledb.InsertRecord(strsql_user, out UserID);

                    strsql_GROUP_USER = string.Format(strsql_GROUP_USER, UserID, GroupID, WorkID);
                    _Oledb.DoCommand(strsql_GROUP_USER);

                    _Oledb.CommitTransaction();
                    MessageBox.Show("添加成功！");
                    FrmMain_Load(null, null);

                }
                catch (Exception err)
                {
                    _Oledb.RollbackTransaction();
                    MessageBox.Show(err.Message);
                }
            }
            else
            {
                string strsql_worker = "update HIS_WORKERS set WORKNAME='" + this.textBox2.Text.Trim() + "' , WORKMEMO='" + this.textBox3.Text.Trim() + "' where workid=" + WorkID;
               // string strsql_employee="update base_employee_property set name='"+this.textBox5.Text.Trim()+"' where "
                _Oledb.DoCommand(strsql_worker);
                MessageBox.Show("修改成功!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string sql_worker = "delete from HIS_WORKERS where workid="+WorkID;
            string sql_layer = "delete from base_dept_layer where workid="+WorkID;
            string sql_dept = "delete from base_dept_property where workid=" + WorkID;
            string sql_group = "delete from base_group where workid=" + WorkID;
            string sql_employee = "delete from base_employee_property where workid=" + WorkID;
            string sql_user = "delete from base_user where workid=" + WorkID;
            string sql_GROUP_USER = "delete from BASE_GROUP_USER  where workid=" + WorkID;
            _Oledb.DoCommand(sql_dept);
            _Oledb.DoCommand(sql_employee);
            _Oledb.DoCommand(sql_group);
            _Oledb.DoCommand(sql_GROUP_USER);
            _Oledb.DoCommand(sql_layer);
            _Oledb.DoCommand(sql_user);
            _Oledb.DoCommand(sql_worker);
            MessageBox.Show("删除成功！");
            FrmMain_Load(null, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (WorkID > 0)
            {
                FrmWorkInfo fwi = new FrmWorkInfo(WorkID, _Oledb);
                fwi.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HIS.SYSTEM.PublicBaseClasses.DESEncryptor des = new HIS.SYSTEM.PublicBaseClasses.DESEncryptor();
            string DesStr = this.textBox2.Text.Trim() + WorkID + this.textBox1.Text.Trim();
            des.InputString = DesStr;
            des.DesEncrypt();
            //this.textBox8.Text = des.OutString;
        }

       
    }
}
