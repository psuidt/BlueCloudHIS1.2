using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Xml;

namespace HIS_PublicManager.SystemTool.GenerateEntityXML
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            this.comboBox1.SelectedIndex = 0;
        }
        [STAThread]
        public static void Main()
        {
            try
            {
                Application.Run(new FrmMain());
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        Type[] types = null;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string fileStr = openFileDialog1.FileName;
                    this.textBox1.Text = fileStr;
                    Assembly assembly = Assembly.LoadFrom(fileStr);
                    types = assembly.GetTypes();

                    dataSet1.Table_field.Rows.Clear();
                    dataSet1.Tablees.Rows.Clear();

                    //this.checkedListBox1.Items.Clear();
                    this.listView1.Items.Clear();



                    for (int i = 0; i < types.Length; i++)
                    {
                        //this.checkedListBox1.Items.Add(types[i].Name);

                        ListViewItem lstViewItem = new ListViewItem();
                        lstViewItem.SubItems.Clear();
                        //lstViewItem.Tag = zypatlist[i];
                        lstViewItem.SubItems[0].Text = types[i].Name;
                        lstViewItem.SubItems.Add("Entity");
                        //lstViewItem.SubItems.Add(zypatlist[i].PatientInfo.PatSex);
                        //lstViewItem.SubItems.Add(zypatlist[i].PatientInfo.PatBriDate.ToString("yyyy-MM-dd"));
                        this.listView1.Items.Add(lstViewItem);


                        DataRow dr = dataSet1.Tablees.NewRow();
                        dr[0] = false;
                        dr[1] = types[i].Name;
                        dr[2] = "Entity";
                        dataSet1.Tablees.Rows.Add(dr);
                        for (int n = 0; n < types[i].GetProperties().Length; n++)
                        {
                            DataRow drr = dataSet1.Table_field.NewRow();
                            drr[0] = true;
                            drr[1] = n;
                            drr[2] = types[i].GetProperties()[n].Name;
                            drr[3] = types[i].GetProperties()[n].PropertyType.ToString();
                            drr[4] = false;
                            drr[5] = false;
                            drr[6] = types[i].Name;
                            dataSet1.Table_field.Rows.Add(drr);
                        }
                    }
                }
            }
            catch { }
        }

   
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //IEnumerator sf= this.checkedListBox1.CheckedIndices.GetEnumerator();
                if (this.checkBox1.Checked)
                {

                    for (int i = 0; i < dataSet1.Tablees.Rows.Count; i++)
                    {
                        dataSet1.Tablees.Rows[i][0] = true;
                        //  this.checkedListBox1.(i, CheckState.Checked);
                        this.listView1.Items[i].Checked = true;
                    }


                }
                else
                {
                    for (int i = 0; i < dataSet1.Tablees.Rows.Count; i++)
                    {
                        dataSet1.Tablees.Rows[i][0] = false;
                        //this.checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                        this.listView1.Items[i].Checked = false;
                    }
                }
            }
            catch { }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.checkBox2.Checked)
                {
                    DataRow[] drs = dataSet1.Table_field.Select("表名 ='" + this.listView1.SelectedItems[0].Text.ToString() + "'");
                    for (int i = 0; i < drs.Length; i++)
                    {
                        drs[i][0] = true;
                    }
                }
                else
                {
                    DataRow[] drs = dataSet1.Table_field.Select("表名 ='" + this.listView1.SelectedItems[0].Text.ToString() + "'");
                    for (int i = 0; i < drs.Length; i++)
                    {
                        drs[i][0] = false;
                    }
                }
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow[] drs = dataSet1.Table_field.Select("表名 ='" + this.listView1.SelectedItems[0].Text.ToString() + "'");
                for (int i = 0; i < drs.Length; i++)
                {
                    drs[i][7] = DBNull.Value;
                    drs[i][8] = DBNull.Value;
                }
            }
            catch { }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            createXML();
            createCS();
            createJavaScript();
            MessageBox.Show("ok");
        }

        /// <summary>
        /// 创建配置文件
        /// </summary>
        public void createXML()
        {
            StreamWriter sw = File.CreateText(Application.StartupPath+"\\HIS.EntityConfig.xml");
            sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            sw.WriteLine("<HIS>");
            for (int i = 0; i < dataSet1.Tablees.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataSet1.Tablees.Rows[i][0]))
                {
                    sw.WriteLine("<Entity code=\"" + dataSet1.Tablees.Rows[i][1].ToString() + "\"  name=\"" + dataSet1.Tablees.Rows[i][1].ToString() + "\" type=\"" + dataSet1.Tablees.Rows[i][2].ToString() + "\" IsGB=\"" + dataSet1.Tablees.Rows[i][3].ToString() + "\">");
                    DataRow[] drs = dataSet1.Table_field.Select("表名 ='" + dataSet1.Tablees.Rows[i][1].ToString() + "'");
                    for (int n = 0; n < drs.Length; n++)
                    {
                        if (Convert.ToBoolean(drs[n][0]))
                        {
                            string str = "";
                            str += "<Field ";
                            if (Convert.ToBoolean(drs[n][4]))
                            {
                                str += "DataKey=\"key\" ";
                            }
                            else if (Convert.ToBoolean(drs[n][5]) && drs[n][7] != DBNull.Value && drs[n][8]!=DBNull.Value)
                            {
                                str += "DataKey=\""+drs[n][7].ToString()+"."+drs[n][8].ToString()+"\" ";
                            }
                            else
                            {
                                str += "DataKey=\"none\" ";
                            }
                            str += "DataType=\"" + drs[n][3].ToString() + "\"  code=\"" + drs[n][2].ToString() + "\">" + drs[n][2].ToString() + "</Field>";
                            sw.WriteLine(str);
                        }
                    }
                    sw.WriteLine("</Entity>");
                }
            }
            sw.WriteLine("</HIS>");
            sw.Flush();
            sw.Close();
        }

        /// <summary>
        /// 创建CS文件
        /// </summary>
        public void createCS()
        {
            string str1 = "\t";
            string str2 = "\t\t";
            string str3 = "\t\t\t";
            StreamWriter sw = File.CreateText(Application.StartupPath + "\\HIS.BLL.Table&View.cs");
            //sw.WriteLine("using HIS.SYSTEM.Core;");
            sw.WriteLine("");
            sw.WriteLine("namespace HIS.BLL");
            sw.WriteLine("{");

            sw.WriteLine(str1+"public struct Tables");
            sw.WriteLine(str1+"{");
            for (int i = 0; i < dataSet1.Tablees.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataSet1.Tablees.Rows[i][0]) && dataSet1.Tablees.Rows[i][2].ToString()=="Table")
                {
                    sw.WriteLine(str2 + "public static string " + dataSet1.Tablees.Rows[i][1].ToString() + " =  \"" + dataSet1.Tablees.Rows[i][1].ToString() + "\";");
                    DataRow[] drs = dataSet1.Table_field.Select("表名 ='" + dataSet1.Tablees.Rows[i][1].ToString() + "'");
                    sw.WriteLine(str2+"public struct "+dataSet1.Tablees[i][1].ToString().ToLower());
                    sw.WriteLine(str2+"{");
                    for (int n = 0; n < drs.Length; n++)
                    {                   
                        if (Convert.ToBoolean(drs[n][0]))
                        {
                            sw.WriteLine(str3 + "public static string " + drs[n][2].ToString().ToUpper() + " = \"" + drs[n][2].ToString().ToUpper() + "\";");
                        }
                    }
                    sw.WriteLine(str2+"}");
                }
            }
            sw.WriteLine(str1+"}");

            sw.WriteLine(str1+"public struct Views");
            sw.WriteLine(str1+"{");
            for (int i = 0; i < dataSet1.Tablees.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataSet1.Tablees.Rows[i][0]) && dataSet1.Tablees.Rows[i][2].ToString() == "View")
                {
                    sw.WriteLine(str2 + "public static string " + dataSet1.Tablees.Rows[i][1].ToString() + " =  \"" + dataSet1.Tablees.Rows[i][1].ToString() + "\";");
                    DataRow[] drs = dataSet1.Table_field.Select("表名 ='" + dataSet1.Tablees.Rows[i][1].ToString() + "'");
                    sw.WriteLine(str2+"public struct " + dataSet1.Tablees[i][1].ToString().ToLower());
                    sw.WriteLine(str2+"{");
                    for (int n = 0; n < drs.Length; n++)
                    {
                        if (Convert.ToBoolean(drs[n][0]))
                        {
                            sw.WriteLine(str3 + "public static string " + drs[n][2].ToString().ToUpper() + " = \"" + drs[n][2].ToString().ToUpper() + "\";");
                        }
                    }
                    sw.WriteLine(str2+"}");
                }
            }
            sw.WriteLine(str1+"}");

            sw.WriteLine("}");
            sw.Flush();
            sw.Close();
        }

        public void createJavaScript()
        {
            string str1 = "\t";
            string str2 = "\t\t";
            string str3 = "\t\t\t";
            StreamWriter sw = File.CreateText(Application.StartupPath + "\\StoreData.js");
            //sw.WriteLine("using HIS.SYSTEM.Core;");
            sw.WriteLine("");
            sw.WriteLine("Ext.namespace('Model');");
            sw.WriteLine("");
            for (int i = 0; i < dataSet1.Tablees.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataSet1.Tablees.Rows[i][0]))
                {
                    sw.WriteLine("Model." + dataSet1.Tablees.Rows[i][1].ToString() + " = function(type){");
                    sw.WriteLine(str1 + "this.record = Ext.data.Record.create([");
                    DataRow[] drs = dataSet1.Table_field.Select("表名 ='" + dataSet1.Tablees.Rows[i][1].ToString() + "'");
                    for (int n = 0; n < drs.Length; n++)
                    {
                        if (Convert.ToBoolean(drs[n][0]))
                        {
                            sw.WriteLine(str2 + "{name : '" + drs[n][2].ToString() + "',mapping:'" + drs[n][2].ToString() + "',type : 'string'},");
                        }
                    }
                    sw.WriteLine(str1 + "]);");
                    sw.WriteLine("");
                    sw.WriteLine(str1 + "this.store = new Ext.data.Store({");
                    sw.WriteLine(str2 + "proxy: new Ext.data.HttpProxy({");
                    sw.WriteLine(str3 + "method: 'GET',");
                    sw.WriteLine(str3 + "url: 'Action/'");
                    sw.WriteLine(str2 + "}),");
                    sw.WriteLine(str2 + "reader: new Ext.data.JsonReader({");
                    sw.WriteLine(str3 + "root: 'rows',");
                    sw.WriteLine(str3 + "totalProperty: 'total',");
                    sw.WriteLine(str3 + "fields: [");

                    for (int n = 0; n < drs.Length; n++)
                    {
                        if (Convert.ToBoolean(drs[n][0]))
                        {
                            sw.WriteLine(str3 + str1 + "{name : '" + drs[n][2].ToString() + "',mapping:'" + drs[n][2].ToString() + "',type : 'string'},");
                        }
                    }
                    sw.WriteLine(str3 + "]");
                    sw.WriteLine(str2 + "})");
                    sw.WriteLine(str1 + "});");

                    sw.WriteLine("");

                    sw.WriteLine(str1 + "this.cm = new Ext.grid.ColumnModel([");
                    sw.WriteLine(str2 + "new Ext.grid.RowNumberer(),");
                    for (int n = 0; n < drs.Length; n++)
                    {
                        if (Convert.ToBoolean(drs[n][0]))
                        {
                            sw.WriteLine(str3 + "{header: '" + drs[n][2].ToString() + "', width: 80, sortable: true, dataIndex: '" + drs[n][2].ToString() + "'},");
                        }
                    }
                    sw.WriteLine(str1 + "]);");
                    sw.WriteLine("}");
                  
                }
            }
            sw.Flush();
            sw.Close();
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //ds1.Table_field.Select("表名 =" + this.checkedListBox1.SelectedItem.ToString());
            //this.tablefieldBindingSource.Filter = "表名 ='" + this.checkedListBox1.SelectedItem.ToString() + "'";
            
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (((DataGridView)sender).CurrentCell.ColumnIndex == 7)
                {
                    object obj = ((DataGridView)sender)[((DataGridView)sender).CurrentCell.ColumnIndex - 1, ((DataGridView)sender).CurrentCell.RowIndex].Value;
                    if (obj == DBNull.Value)
                    {
                        obj = "";

                    }
                    this.tablefieldBindingSource1.Filter = "表名 ='" + obj.ToString() + "'";
                }
            }
            catch { }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.tablefieldBindingSource.Filter = "表名 ='" + this.listView1.SelectedItems[0].Text.ToString() + "'";
                this.tableesBindingSource.Filter = "表名 <>'" + this.listView1.SelectedItems[0].Text.ToString() + "'";
                //this.checkBox2.Checked = false;

                DataRow[] dr = dataSet1.Tablees.Select("表名='" + this.listView1.SelectedItems[0].Text.ToString() + "'");
                if (dr.Length > 0)
                {
                  
                    this.checkBox3.Checked=Convert.ToBoolean(dr[0][3]);
                }
            }
            catch { }
        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                bool b = false;


                if (e.CurrentValue == CheckState.Checked)
                {
                    e.NewValue = CheckState.Unchecked;
                    b = false;
                }
                else
                {
                    e.NewValue = CheckState.Checked;
                    b = true;
                }

                for (int i = 0; i < dataSet1.Tablees.Rows.Count; i++)
                {
                    if (this.listView1.SelectedItems[0].Text.ToString() == dataSet1.Tablees.Rows[i][1].ToString())
                    {
                        dataSet1.Tablees.Rows[i][0] = b;
                        continue;
                    }
                }
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HIS.SYSTEM.Core.EntityConfig.ConnStr = this.textBox2.Text;
            HIS.SYSTEM.DatabaseAccessLayer.OleDB oleDb = new HIS.SYSTEM.DatabaseAccessLayer.OleDB();
            try
            {
                //oleDb.Initialize(this.textBox2.Text);

                dataSet1.Table_field.Rows.Clear();
                dataSet1.Tablees.Rows.Clear();

                //this.checkedListBox1.Items.Clear();
                this.listView1.Items.Clear();


                IDataReader datar = oleDb.GetDataReader("select tabname from syscat.tables where tabschema ='DB2INST2' and TYPE='T' order by tabname ");
                while (datar.Read())
                {
                    ListViewItem lstViewItem = new ListViewItem();
                    lstViewItem.SubItems.Clear();
                    //lstViewItem.Tag = zypatlist[i];
                    lstViewItem.SubItems[0].Text = datar[0].ToString();
                    lstViewItem.SubItems.Add("Table");
                    //lstViewItem.SubItems.Add(zypatlist[i].PatientInfo.PatSex);
                    //lstViewItem.SubItems.Add(zypatlist[i].PatientInfo.PatBriDate.ToString("yyyy-MM-dd"));
                    this.listView1.Items.Add(lstViewItem);


                    DataRow dr = dataSet1.Tablees.NewRow();
                    dr[0] = false;
                    dr[1] = datar[0].ToString();
                    dr[2] = "Table";
                    dr[3] = false;
                    dataSet1.Tablees.Rows.Add(dr);
                    int index = 0;
                    IDataReader datarr = oleDb.GetDataReader("select colname,typename,identity from SYScat.COLUMNS where tabschema='DB2INST2' and tabname = '"+datar[0].ToString()+"' order by colno");
                    while (datarr.Read())
                    {
                        DataRow drr = dataSet1.Table_field.NewRow();
                        if (datarr[0].ToString().Trim().ToUpper() == "WORKID")
                        {
                            drr[0] = false;
                        }
                        else
                        {
                            drr[0] = true;
                        }
                        drr[1] = index++;
                        drr[2] = datarr[0].ToString();
                        drr[3] = datarr[1].ToString();
                        drr[4] = datarr[2].ToString() == "Y" ? true : false;
                        drr[5] = false;
                        drr[6] = datar[0].ToString();
                        dataSet1.Table_field.Rows.Add(drr);
                    }
                    datarr.Close();
                }
                datar.Close();
                IDataReader _datar = oleDb.GetDataReader("select viewname from syscat.views where viewschema ='DB2INST2' order by viewname");
                while (_datar.Read())
                {
                    ListViewItem lstViewItem = new ListViewItem();
                    lstViewItem.SubItems.Clear();
                    //lstViewItem.Tag = zypatlist[i];
                    lstViewItem.SubItems[0].Text = _datar[0].ToString();
                    lstViewItem.SubItems.Add("View");
                    //lstViewItem.SubItems.Add(zypatlist[i].PatientInfo.PatSex);
                    //lstViewItem.SubItems.Add(zypatlist[i].PatientInfo.PatBriDate.ToString("yyyy-MM-dd"));
                    this.listView1.Items.Add(lstViewItem);


                    DataRow dr = dataSet1.Tablees.NewRow();
                    dr[0] = false;
                    dr[1] = _datar[0].ToString();
                    dr[2] = "View";
                    dr[3] = false;
                    dataSet1.Tablees.Rows.Add(dr);
                    int index = 0;
                    IDataReader datarr = oleDb.GetDataReader("select colname,typename,identity from SYScat.COLUMNS where tabschema='DB2INST2' and tabname = '" + _datar[0].ToString() + "' order by colno");
                    while (datarr.Read())
                    {
                        DataRow drr = dataSet1.Table_field.NewRow();
                        if (datarr[0].ToString().Trim().ToUpper() == "WORKID")
                        {
                            drr[0] = false;
                        }
                        else
                        {
                            drr[0] = true;
                        }
                        drr[1] = index++;
                        drr[2] = datarr[0].ToString();
                        drr[3] = datarr[1].ToString();
                        drr[4] = datarr[2].ToString() == "Y" ? true : false;
                        drr[5] = false;
                        drr[6] = _datar[0].ToString();
                        dataSet1.Table_field.Rows.Add(drr);
                    }
                }


            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                oleDb.Close();
                oleDb.Dispose();
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            DataRow[] dr = dataSet1.Tablees.Select("表名='" + this.listView1.SelectedItems[0].Text.ToString() + "'");
            if (dr.Length > 0)
            {
                dr[0][3] = this.checkBox3.Checked;
            }
        }

        private void btnCreatEntityFile_Click( object sender, EventArgs e )
        {
            if ( listView1.SelectedItems.Count == 0 )
                return;

            string tableName = listView1.SelectedItems[0].Text;

            FolderBrowserDialog folder = new FolderBrowserDialog();
            if ( folder.ShowDialog() == DialogResult.OK )
            {
                string path = folder.SelectedPath;
                CreateEntityFile( path, tableName );
                MessageBox.Show( "finish!!!" );
            }
        }


        private void CreateEntityFile(string path,string tableName)
        {
            StreamWriter sw = File.CreateText( path + "\\" + tableName + ".cs" );
            sw.WriteLine( "using System;" );
            sw.WriteLine( "namespace HIS.Model" );
            sw.WriteLine( "{" );
            sw.WriteLine( "\tpublic class " + tableName );
            sw.WriteLine( "\t{" );
            for ( int i = 0; i < dataGridView1.Rows.Count; i++ )
            {
                string fieldName = dataGridView1["列名DataGridViewTextBoxColumn", i].Value.ToString();
                string dataType = dataGridView1["数据类型DataGridViewTextBoxColumn", i].Value.ToString();
                string typeName = "";
                if ( dataType == "INTEGER" || dataType == "BIGINT" || dataType == "SMALLINT" )
                {
                    typeName = "int";
                }
                else if ( dataType == "DECIMAL" )
                {
                    typeName = "decimal";
                }
                else if ( dataType == "DATE" || dataType == "TIMESTAMP" )
                {
                    typeName = "DateTime";
                }
                else
                {
                    typeName = "string";
                }
                sw.WriteLine( "\t\tprivate " + typeName + " _" + fieldName.ToLower() + ";" );
                sw.WriteLine( "\t\t/// <summary>" );
                sw.WriteLine( "\t\t///" );
                sw.WriteLine( "\t\t/// </summary>" );
                sw.WriteLine( "\t\tpublic " + typeName + " " + fieldName.ToUpper() );
                sw.WriteLine( "\t\t{" );
                sw.WriteLine( "\t\t\tget{return _" + fieldName.ToLower() + ";}" );
                sw.WriteLine( "\t\t\tset{_"+ fieldName.ToLower() +" = value ;}" );
                sw.WriteLine( "" );
                sw.WriteLine( "\t\t}" );
            }
            sw.WriteLine( "\t}" );
            sw.WriteLine( "}" );
            sw.Flush();
            sw.Close();
        }

       

    }
}
