using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.Public_BLL;
using ICSharpCode.TextEditor.Document;
using System.Threading;

namespace HIS_PublicManager.SystemTool.DBClient
{
    public partial class FrmClient : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private DataSet ds;
        private Thread t;

        public FrmClient()
        {
            InitializeComponent();

            db2sqlstr.ShowEOLMarkers = false;
            db2sqlstr.ShowHRuler = false;
            db2sqlstr.ShowInvalidLines = false;
            db2sqlstr.ShowMatchingBracket = true;
            db2sqlstr.ShowSpaces = false;
            db2sqlstr.ShowTabs = false;
            db2sqlstr.ShowVRuler = false;
            db2sqlstr.AllowCaretBeyondEOL = false;
            db2sqlstr.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("TSQL");
            db2sqlstr.Encoding = Encoding.GetEncoding("GB2312");

            ressqlstr.ShowEOLMarkers = false;
            ressqlstr.ShowHRuler = false;
            ressqlstr.ShowInvalidLines = false;
            ressqlstr.ShowMatchingBracket = true;
            ressqlstr.ShowSpaces = false;
            ressqlstr.ShowTabs = false;
            ressqlstr.ShowVRuler = false;
            ressqlstr.AllowCaretBeyondEOL = false;
            ressqlstr.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("TSQL");
            ressqlstr.Encoding = Encoding.GetEncoding("GB2312");


            Datashow.Runing += new Datashow.RuningEventHandler(this.Datashow_Runing);

            
        }

        private ICSharpCode.TextEditor.TextEditorControl rtb
        {
            get
            {
                if (this.HISDB2tabControl.SelectedIndex == 0)
                {
                    return this.db2sqlstr;
                }
                return this.ressqlstr;
            }
            set
            {
                if (this.HISDB2tabControl.SelectedIndex == 0)
                {
                    this.db2sqlstr = value;
                }
                else
                {
                    this.ressqlstr = value;
                }
            }
        }

        private string strtext
        {
            get
            {
                return this.rtb.Text;
            }
            set
            {
                this.rtb.Text = value;
            }
        }

        private void Datashow_Runing(string sql, int allcount, int nowcount)
        {
            //this.progressBar1.Maximum = allcount;
            //this.progressBar1.Value = nowcount + 1;
        }
   
        private void bind_nodes()
        {
            try
            {
                TreeNode node = new TreeNode();               
                node.Text = "门诊";
                node.Tag = "DB2ConnMZ";
                node.ForeColor = Color.Blue;
                node.ImageIndex = 21;                
                this.HISDB2treeView.Nodes.Add(node);
                TreeNode[] nodes = new TreeNode[] { new TreeNode("表"), new TreeNode("视图"), new TreeNode("存储过程"), new TreeNode("索引"), new TreeNode("函数"), new TreeNode("触发器") };
                node.Nodes.AddRange(nodes);
                this.bind_dbnames(nodes);
                //node.Expand();
                TreeNode _node = new TreeNode();
                _node.Text = "通用维护";
                _node.Tag = "DB2sql";
                _node.ForeColor = Color.Blue;
                _node.ImageIndex = 21;
                this.HISDB2treeView.Nodes.Add(_node);
                TreeNode[] _nodes = new TreeNode[] { new TreeNode("升级脚本"), new TreeNode("功能脚本") };
                _node.Nodes.AddRange(_nodes);
                HISDB2treeView.ExpandAll();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void bind_dbnames(TreeNode[] hismz)
        {
            DataTable[] tableArray = new DataTable[6];

            try
            {
                tableArray[0] = OP_DBClient.GetDbData(DataTypeName.表);
                tableArray[1] = OP_DBClient.GetDbData(DataTypeName.视图);
                tableArray[2] = OP_DBClient.GetDbData(DataTypeName.存储过程);
                tableArray[3] = OP_DBClient.GetDbData(DataTypeName.索引);
                tableArray[4] = OP_DBClient.GetDbData(DataTypeName.函数);
                tableArray[5] = OP_DBClient.GetDbData(DataTypeName.触发器);
                
                TreeNode[] nodes = new TreeNode[tableArray[0].Rows.Count];
                for (int i = 0; i < nodes.Length; i++)
                {
                    nodes[i] = new TreeNode(tableArray[0].Rows[i][1].ToString());
                    nodes[i].Tag = 4;
                    nodes[i].ImageIndex = 22;
                    bind_colmnames(nodes[i]);
                }
                hismz[0].ImageIndex = 23;
                hismz[0].Nodes.AddRange(nodes);
                TreeNode[] nodeArray2 = new TreeNode[tableArray[1].Rows.Count];
                for (int j = 0; j < nodeArray2.Length; j++)
                {
                    nodeArray2[j] = new TreeNode(tableArray[1].Rows[j][1].ToString());
                    nodeArray2[j].Tag = 1;
                    nodeArray2[j].ImageIndex = 22;
                    bind_colmnames(nodeArray2[j]);
                }
                hismz[1].ImageIndex = 23;
                hismz[1].Nodes.AddRange(nodeArray2);
                TreeNode[] nodeArray3 = new TreeNode[tableArray[2].Rows.Count];
                for (int k = 0; k < nodeArray3.Length; k++)
                {
                    nodeArray3[k] = new TreeNode(tableArray[2].Rows[k][1].ToString());
                    nodeArray3[k].Tag = 2;
                    nodeArray3[k].ImageIndex = 22;
                }
                hismz[2].ImageIndex = 23;
                hismz[2].Nodes.AddRange(nodeArray3);
                TreeNode[] nodeArray4 = new TreeNode[tableArray[3].Rows.Count];
                for (int m = 0; m < nodeArray4.Length; m++)
                {
                    nodeArray4[m] = new TreeNode(tableArray[3].Rows[m][1].ToString());
                    nodeArray4[m].ImageIndex = 22;
                }
                hismz[3].ImageIndex = 23;
                hismz[3].Nodes.AddRange(nodeArray4);
                TreeNode[] nodeArray5 = new TreeNode[tableArray[4].Rows.Count];
                for (int n = 0; n < nodeArray5.Length; n++)
                {
                    nodeArray5[n] = new TreeNode(tableArray[4].Rows[n][1].ToString());
                    nodeArray5[n].Tag = 3;
                    nodeArray5[n].ImageIndex = 22;
                }
                hismz[4].ImageIndex = 23;
                hismz[4].Nodes.AddRange(nodeArray5);
                TreeNode[] nodeArray6 = new TreeNode[tableArray[5].Rows.Count];
                for (int num6 = 0; num6 < nodeArray6.Length; num6++)
                {
                    nodeArray6[num6] = new TreeNode(tableArray[5].Rows[num6][0].ToString());
                    nodeArray6[num6].ImageIndex = 22;
                }
                hismz[5].ImageIndex = 23;
                hismz[5].Nodes.AddRange(nodeArray6);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "连接数据库配置不正确", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void bind_colmnames(TreeNode node)
        {
            string tablename = getTableName(node.Text);
            DataTable dt = OP_DBClient.GetDbColmData(tablename);
            TreeNode[] nodes = new TreeNode[dt.Rows.Count];
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = new TreeNode(dt.Rows[i][0].ToString() + "     （" + dt.Rows[i][1].ToString() + "|" + dt.Rows[i][2].ToString() + "）");
                nodes[i].ImageIndex = 24;
            }

            node.Nodes.AddRange(nodes);
        }

        private string getTableName(string text)
        {
            //int index = text.IndexOf(" ");
            //return text.Substring(0, index).Trim();
            return text.Trim();
        }

        private string getColMName(string text)
        {
            int index = text.IndexOf(" ");
            return text.Substring(0, index).Trim();
        }

        private void startRun()
        {
            this.ds = new DataSet();
            this.ds = Datashow.OutData(this.ressqlstr.Text);
        }

        private void stopRun()
        {
            this.t.Abort();
            this.timer1.Enabled = false;
            Datashow.ErrStr = "已停止运行";
            Datashow.ErrBool = true;
            this.ShowError();
            this.toolStripButton5.Enabled = true;
            this.toolStripButton6.Enabled = false;
        }

        private void ShowData()
        {
            //this.dg1.DataSource = null;
            this.tabControl2.Controls.Clear();
            for (int i = 0; i < this.ds.Tables.Count; i++)
            {
                TabPage page = new TabPage();
                page.Dock = DockStyle.Fill;
                page.Text = "结果" + Convert.ToString((int)(i + 1));
                this.tabControl2.Controls.Add(page);
                int index = this.ds.Tables[i].TableName.IndexOf("[");
                string name = this.ds.Tables[i].TableName.Substring(0, index).Trim();
                if (name == "SELECT" || name == "Procedure")
                {
                    GWI.HIS.Windows.Controls.DataGridViewEx grid = new GWI.HIS.Windows.Controls.DataGridViewEx();
                    grid.UseGradientBackgroundColor = true;
                    grid.Dock = DockStyle.Fill;
                    grid.ReadOnly = true;
                    page.Controls.Add(grid);
                    grid.DataSource = this.ds.Tables[i];
                }
                else
                {
                    RichTextBox rich = new RichTextBox();
                    rich.Dock = DockStyle.Fill;
                    rich.ReadOnly = true;
                    page.Controls.Add(rich);
                    rich.Text = this.ds.Tables[i].TableName + "执行成功！";
                }

            }
            this.ShowError();
            this.toolStripButton5.Enabled = true;
            this.toolStripButton6.Enabled = false;
        }

        private void ShowError()
        {
            if (!Datashow.ErrBool)
            {
                this.HISDB2tabControl.SelectedIndex = 1;
            }
            else
            {
                this.HISDB2tabControl.SelectedIndex = 0;               
            }
            this.richTextBox1.Text = this.richTextBox1.Text + "\n" + Datashow.ErrStr;
            Datashow.ErrStr = "";
            Datashow.ErrBool = false;
        }

        private void HISDB2treeView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int num = Convert.ToInt32(this.HISDB2treeView.SelectedNode.Tag);
                switch (num)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        {
                            if (this.HISDB2tabControl.SelectedIndex == 1)
                            {
                                this.HISDB2tabControl.SelectedIndex = 0;
                            }
                            string tablename = getTableName(this.HISDB2treeView.SelectedNode.Text);

                            switch (num)
                            {
                                case 4:
                                case 1:
                                    string str = null;
                                    for (int i = 0; i<this.HISDB2treeView.SelectedNode.Nodes.Count; i++)
                                    {
                                        if (i != this.HISDB2treeView.SelectedNode.Nodes.Count - 1)
                                            str = str + getColMName(this.HISDB2treeView.SelectedNode.Nodes[i].Text) + ",";
                                        else
                                            str = str + getColMName(this.HISDB2treeView.SelectedNode.Nodes[i].Text);
                                    }
                                    this.strtext = this.strtext + "select "+str+" from " + tablename + " ;\n";
                                    return;
                            }
                            if ((num == 3) || (num == 2))
                            {
                                this.strtext = this.strtext + "call " + tablename + "();\n";
                            }
                            break;
                        }
                }
            }
            catch
            {
            }
        }
        //刷新
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.HISDB2treeView.Nodes.Clear();
            this.bind_nodes();
        }
        //运行
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.progressBar1.Value = 0;
            this.timer1.Enabled = true;
            this.toolStripButton5.Enabled = false;
            this.toolStripButton6.Enabled = true;
            if (this.HISDB2tabControl.SelectedIndex == 0)
            {
                this.ressqlstr.Text = this.db2sqlstr.Text;
            }
            this.t = new Thread(new ThreadStart(this.startRun));
            this.t.Start();
        }
        //时间
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.t.ThreadState == System.Threading.ThreadState.Stopped)
            {
                this.ShowData();
                this.timer1.Enabled = false;
            }
        }
        //停止
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            this.stopRun();
        }

        private void FrmClient_Load(object sender, EventArgs e)
        {
            this.toolStripButton4_Click(null, null);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
