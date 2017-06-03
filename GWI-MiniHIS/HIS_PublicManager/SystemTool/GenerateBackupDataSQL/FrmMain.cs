using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace HIS_PublicManager.SystemTool.GenerateBackupDataSQL
{
    public partial class FrmMain : Form
    {
        HIS.SYSTEM.DatabaseAccessLayer.OleDB oleDb;
        int WorkID;
        string baseTableName;
        public FrmMain()
        {
            InitializeComponent();
            this.textBox1.Text = "Provider=IBMDADB2;Database=CSDB;HostName=192.168.10.253;Protocol=tcpip;Port=5000" +
                "0;User ID=DB2inst2;Password=db2inst2";
            this.button6.Enabled = false;
            this.button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HIS.SYSTEM.Core.EntityConfig.ConnStr = this.textBox1.Text;
            oleDb = new HIS.SYSTEM.DatabaseAccessLayer.OleDB();
            try
            {

                string strsql = "select WORKID, WORKNAME from HIS_WORKERS ";
                DataTable dt = oleDb.GetDataTable(strsql);
                this.comboBox1.DisplayMember = "WORKNAME";
                this.comboBox1.ValueMember = "WORKID";
                this.comboBox1.DataSource = dt;
                this.button6.Enabled = true;
                this.button2.Enabled = true;
                MessageBox.Show("连接成功！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            WorkID = Convert.ToInt32(this.comboBox1.SelectedValue);
            this.treeView1.Nodes.Clear();
            this.comboBox2.Items.Clear();
            backUpDataSet.data.Rows.Clear();
            TreeNode node0 = new TreeNode("数据库表");

            IDataReader datar = oleDb.GetDataReader("select tabname from syscat.tables where tabschema ='DB2INST2' and TYPE='T' order by tabname ");
            TreeNode node = null;
            while (datar.Read())
            {
                node = new TreeNode(datar[0].ToString());
                TreeNode node1;
                IDataReader datarr = oleDb.GetDataReader("select colname,identity,typename from SYScat.COLUMNS where tabschema='DB2INST2' and tabname = '" + datar[0].ToString() + "' order by colno");
                while (datarr.Read())
                {
                    node1 = new TreeNode(datarr[0].ToString());
                    node1.Tag = datarr[2].ToString();
                    node.Nodes.Add(node1);

                    if (datarr[1].ToString() == "Y")
                    {
                        DataRow dr = backUpDataSet.data.NewRow();
                        dr["TableName"] = datar[0].ToString();
                        dr["FieldName"] = datarr[0].ToString();
                        dr["BaseTableName"] = datar[0].ToString();
                        backUpDataSet.data.Rows.Add(dr);
                    }
                }
                datarr.Close();
                node0.Nodes.Add(node);
                this.comboBox2.Items.Add(datar[0].ToString());
            }
            datar.Close();
            this.treeView1.Nodes.Add(node0);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox3.Items.Clear();
            IDataReader datarr = oleDb.GetDataReader("select colname from SYScat.COLUMNS where tabschema='DB2INST2' and tabname = '" + this.comboBox2.Text + "' order by colno");
            while (datarr.Read())
            {
                this.comboBox3.Items.Add(datarr[0].ToString());
            }
            datarr.Close();
           
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = oleDb.GetDataRow("select min(" + this.comboBox3.Text + "),max(" + this.comboBox3.Text + ") from " + this.comboBox2.Text + " where workid=" + WorkID);
                this.textBox3.Text = dr[0].ToString();
                this.textBox4.Text = dr[1].ToString();
            }
            catch
            {
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.groupBox1.Enabled = true;
            if (this.treeView1.SelectedNode.Level == 0)
            {
                this.dataBindingSource.Filter = "";
                this.groupBox1.Enabled = false;
            }
            else if (this.treeView1.SelectedNode.Level == 1)
            {
                this.dataBindingSource.Filter = "BaseTableName='" + this.treeView1.SelectedNode.Text + "'";
                baseTableName = this.treeView1.SelectedNode.Text;
            }
            else if (this.treeView1.SelectedNode.Level == 2)
            {
                this.dataBindingSource.Filter = "BaseTableName='" + this.treeView1.SelectedNode.Parent.Text + "'";
                baseTableName = this.treeView1.SelectedNode.Parent.Text;
            }
        }
        //新增
        private void button3_Click(object sender, EventArgs e)
        {
            this.comboBox2.SelectedIndex = 0;
            this.comboBox3.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.comboBox4.Text = "";
            //this.textBox2.Text = "";
        }
        //保存
        private void button4_Click(object sender, EventArgs e)
        {
            DataRow[] drs = backUpDataSet.data.Select("TableName='" + this.comboBox2.Text + "' and FieldName='" + this.comboBox3.Text + "' and BaseTableName='"+baseTableName+"'");
            if (drs.Length != 0)
            {
                DataRow dr = drs[0];
                dr["TableName"] = this.comboBox2.Text;
                dr["FieldName"] = this.comboBox3.Text;
                dr["MinNum"] = this.textBox3.Text;
                dr["MaxNum"] = this.textBox4.Text;
                dr["AddName"] = this.comboBox4.Text;
                dr["AddNum"] = this.textBox2.Text;
                dr["BaseTableName"] = baseTableName;
            }
            else
            {
                DataRow dr = backUpDataSet.data.NewRow();
                dr["TableName"] = this.comboBox2.Text;
                dr["FieldName"] = this.comboBox3.Text;
                dr["MinNum"] = this.textBox3.Text;
                dr["MaxNum"] = this.textBox4.Text;
                dr["AddName"] = this.comboBox4.Text;
                dr["AddNum"] = this.textBox2.Text;
                dr["BaseTableName"] = baseTableName;
                backUpDataSet.data.Rows.Add(dr);
            }
        }
        //删除
        private void button5_Click(object sender, EventArgs e)
        {
            DataRow[] drs = backUpDataSet.data.Select("TableName='" + this.comboBox2.Text + "' and FieldName='" + this.comboBox3.Text + "' and BaseTableName='" + baseTableName + "'");
            if (drs.Length != 0)
            {
                backUpDataSet.data.Rows.Remove(drs[0]);
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentCell != null)
            {
                int rowid = this.dataGridView1.CurrentCell.RowIndex;
                this.comboBox2.Text = this.dataGridView1[0, rowid].Value.ToString();
                this.comboBox3.Text = this.dataGridView1[1, rowid].Value.ToString();
                //this.textBox3.Text = this.dataGridView1[2, rowid].Value.ToString();
                //this.textBox4.Text = this.dataGridView1[3, rowid].Value.ToString();
                this.comboBox4.Text = this.dataGridView1[4, rowid].Value.ToString();
                this.textBox2.Text = this.dataGridView1[5, rowid].Value.ToString();
            }
        }
        //生成
        private void button2_Click(object sender, EventArgs e)
        {
            backUpDataSet.data.WriteXml("BackUpConfig" + WorkID + ".xml");
            CreateDEL();
            CreateImportSql();
            CreateRestartWith();
            MessageBox.Show("生成成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //导入
        private void button6_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                backUpDataSet.data.Rows.Clear();
                backUpDataSet.data.ReadXml(openFileDialog1.FileName);
            }
        }

        private void CreateDEL()
        {
            StreamWriter sw = File.CreateText(Application.StartupPath + "\\BackUpData" + WorkID + ".sql");
            sw.WriteLine("--" + this.textBox1.Text);
            sw.WriteLine("--DateTime:" + DateTime.Now.ToString());
            sw.WriteLine("");
            DataTable dt = backUpDataSet.data;
            TreeNode tn = this.treeView1.TopNode;
            for (int n = 0; n < tn.Nodes.Count; n++)
            {
                sw.WriteLine(@"EXPORT TO 'C:\BackUpData\" + tn.Nodes[n].Text + ".del' OF DEL");

                //DataRow[] drs = dt.Select("TableName='" + tn.Nodes[n].Text + "'");
                //if (drs.Length != 0)
                //{
                //    string selectSql = null;
                //    //表的列
                //    for (int m = 0; m < tn.Nodes[n].Nodes.Count; m++)
                //    {
                //        //配置的列
                //        for (int i = 0; i < drs.Length; i++)
                //        {
                //            if (tn.Nodes[n].Nodes[m].Text == drs[i]["FieldName"].ToString())
                //            {
                //                if (drs[i]["AddName"].ToString() == "加法增长")
                //                {
                //                    if (tn.Nodes[n].Nodes[m].Tag.ToString() == "VARCHAR")
                //                    {
                //                        selectSql += "(case  " + drs[i]["FieldName"].ToString() + "   when '' then '' else trim(cast(cast(" + drs[i]["FieldName"].ToString() + " as int)+" + drs[i]["AddNum"].ToString() + " as char(20) )) end),";
                //                    }
                //                    else
                //                    {
                //                        selectSql += drs[i]["FieldName"].ToString() + "+" + drs[i]["AddNum"].ToString() + ",";
                //                    }
                //                }
                //                else
                //                {
                //                    if (tn.Nodes[n].Nodes[m].Tag.ToString() == "VARCHAR")
                //                    {
                //                        selectSql += "(case  " + drs[i]["FieldName"].ToString() + "   when '' then '' else trim(cast(cast(" + drs[i]["FieldName"].ToString() + " as int)*" + drs[i]["AddNum"].ToString() + " as char(20) )) end),";
                //                    }
                //                    else
                //                    {
                //                        selectSql += drs[i]["FieldName"].ToString() + "*" + drs[i]["AddNum"].ToString() + ",";
                //                    }
                //                }
                //                break;
                //            }
                //            if (i == drs.Length - 1)
                //            {
                //                selectSql += tn.Nodes[n].Nodes[m].Text + ",";
                //            }
                //        }
                //    }
                //    selectSql = selectSql.Substring(0, selectSql.Length - 1);
                //    sw.WriteLine(@"  SELECT " + selectSql + " FROM " + tn.Nodes[n].Text + " where workid=" + WorkID + ";");
                //}
                //else
                //{
                    sw.WriteLine(@"  SELECT * FROM " + tn.Nodes[n].Text + " where workid=" + WorkID + ";");
                //}
                sw.WriteLine("");
            }

            sw.WriteLine("");
            sw.Flush();
            sw.Close();
        }

        private void CreateImportSql()
        {
            StreamWriter sw = File.CreateText(Application.StartupPath + "\\ImportData" + WorkID + ".sql");
            sw.WriteLine("--" + this.textBox1.Text);
            sw.WriteLine("--DateTime:" + DateTime.Now.ToString());
            sw.WriteLine("");
            TreeNode tn = this.treeView1.TopNode;
            for (int n = 0; n < tn.Nodes.Count; n++)
            {

                sw.WriteLine(@"IMPORT FROM 'C:\BackUpData\" + tn.Nodes[n].Text + ".del' OF DEL");
                sw.WriteLine(@"  INSERT INTO " + tn.Nodes[n].Text + ";");
                sw.WriteLine("");
            }

            sw.WriteLine("");
            sw.Flush();
            sw.Close();
        }

        private void CreateRestartWith()
        {
            StreamWriter sw = File.CreateText(Application.StartupPath + "\\RestartWith.sql");
            sw.WriteLine("--" + this.textBox1.Text);
            sw.WriteLine("--DateTime:" + DateTime.Now.ToString());
            sw.WriteLine("");
            TreeNode tn = this.treeView1.TopNode;
            for (int n = 0; n < tn.Nodes.Count; n++)
            {
                try
                {
                    string generated = oleDb.GetDataResult("select  name   from SYSIBM.SYSCOLUMNS where  generated='D' and tbname='" + tn.Nodes[n].Text + "' order by tbname").ToString();
                    string maxid = oleDb.GetDataResult("select max(" + generated + ")+1 from " + tn.Nodes[n].Text).ToString();
                    if (maxid != "" && maxid != null)
                    {
                        sw.WriteLine(@"ALTER TABLE " + tn.Nodes[n].Text + "  LOCKSIZE ROW  APPEND OFF  NOT VOLATILE  ALTER COLUMN " + generated + "    RESTART WITH " + maxid + ";");
                        sw.WriteLine("");
                    }
                }
                catch { }
            }

            sw.WriteLine("");
            sw.Flush();
            sw.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                IList ilist = dataBindingSource.List;
                for (int i = 0; i < ilist.Count; i++)
                {
                    DataRowView drv = (DataRowView)ilist[i];
                    DataRow dr = drv.Row;
                    dr["AddName"] = this.comboBox4.Text;
                    dr["AddNum"] = this.textBox2.Text;
                }
            }
        }

       
    }
}
