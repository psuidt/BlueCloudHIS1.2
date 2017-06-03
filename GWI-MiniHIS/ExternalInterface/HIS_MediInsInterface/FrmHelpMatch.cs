using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace HIS_MediInsInterface
{
    public partial class FrmHelpMatch : GWI.HIS.Windows.Controls.BaseForm
    {
        //线程外访问控件,更改控件值
        delegate void SetCallback(Control control,params object[] obj);
        private void SetValue(Control control, params object[] obj)
        {
            if (control.InvokeRequired)
            {
                SetCallback d = new SetCallback(SetValue);
                this.Invoke(d,control, obj);
            }
            else
            {
                string name=control.Name;
                switch (name)
                {
                    case "progressBar1":
                        ((ProgressBar)control).Value = Convert.ToInt32(obj[0]);
                        break;
                    case "lbjd":
                        ((Label)control).Text = obj[0].ToString();
                        ((Label)control).Refresh();
                        break;
                    case "dataGridViewEx1":
                        ((GWI.HIS.Windows.Controls.DataGridViewEx)dataGridViewEx1).DataSource = (DataTable)obj[0];
                        ((GWI.HIS.Windows.Controls.DataGridViewEx)dataGridViewEx1).Refresh();
                        break;
                    case "btSearch":
                        ((Button)control).Enabled = Convert.ToBoolean(obj[0]);
                        break;
                    case "btStop":
                        ((Button)control).Enabled = Convert.ToBoolean(obj[0]);
                        break;
                    case "FrmHelpMatch":
                        ((Form)control).Refresh();
                        ((Form)control).Activate();
                        break;
                }
            }
        }

        DataTable centerdt = null;
        DataTable hisdt = null;

        public bool IsOk = false;
        public DataTable matchDt=null;
        HIS.Base_BLL.Enums.MatchClass matchclass;

        public FrmHelpMatch()
        {
            InitializeComponent();
        }

        public FrmHelpMatch(DataTable _centerdt, DataTable _hisdt,HIS.Base_BLL.Enums.MatchClass _matchclass)
        {
            InitializeComponent();
            centerdt = _centerdt;
            hisdt = _hisdt;
            matchclass = _matchclass;

            matchDt = new DataTable();
            DataColumn dc = new DataColumn("center_code",typeof(string));
            matchDt.Columns.Add(dc);
            dc = new DataColumn("center_name", typeof(string));
            matchDt.Columns.Add(dc);
            dc = new DataColumn("his_code", typeof(string));
            matchDt.Columns.Add(dc);
            dc = new DataColumn("his_name", typeof(string));
            matchDt.Columns.Add(dc);

            this.btSearch.Enabled = true;
            this.btStop.Enabled = false;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            switch (cb.Name)
            {
                case "checkBox1":
                    if (cb.Checked == true)
                    {
                        this.checkBox2.Checked = false;
                        this.checkBox3.Checked = false;
                    }
                    break;
                case "checkBox2":
                    if (cb.Checked == true)
                    {
                        this.checkBox1.Checked = false;
                        this.checkBox3.Checked = false;
                    }
                    break;
                case "checkBox3":
                    if (cb.Checked == true)
                    {
                        this.checkBox1.Checked = false;
                        this.checkBox2.Checked = false;
                    }
                    break;
            }
        }


        Thread thread = null; 
        private void btSearch_Click(object sender, EventArgs e)
        {


            if (centerdt == null || hisdt == null)
                MessageBox.Show("没有需要匹配的数据！");

            matchDt.Rows.Clear();
            //this.dataGridViewEx1.DataSource = matchDt;
            this.dataGridViewEx1.Refresh();
            this.progressBar1.Maximum = hisdt.Rows.Count;
            this.progressBar1.Minimum = 0;      

            thread = new Thread(new ThreadStart(Search));
            thread.Start();

            this.btSearch.Enabled = false;
            this.btStop.Enabled = true;
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            if (thread != null)
            {
                thread.Abort();
                this.btSearch.Enabled = true;
                this.btStop.Enabled = false;
            }
        }

        private void Search()
        {
            
            int value = 4;
            if (checkBox1.Checked == true)//完全匹配
            {
                #region
                for (int i = 0; i < hisdt.Rows.Count; i++)
                {
                    for (int j = 0; j < centerdt.Rows.Count; j++)
                    {
                        if (matchclass == HIS.Base_BLL.Enums.MatchClass.药品匹配)
                        {
                            if (hisdt.Rows[i]["NAME"].ToString().Trim() == centerdt.Rows[j]["Medi_name"].ToString().Trim())
                            {
                                DataRow dr = matchDt.NewRow();

                                dr["center_code"] = centerdt.Rows[j]["Medi_code"];
                                dr["center_name"] = centerdt.Rows[j]["Medi_name"];
                                dr["his_code"] = hisdt.Rows[i]["code"];
                                dr["his_name"] = hisdt.Rows[i]["NAME"];

                                matchDt.Rows.Add(dr);
                                break;
                            }
                        }
                        else if (matchclass == HIS.Base_BLL.Enums.MatchClass.项目匹配)
                        {
                            if (hisdt.Rows[i]["ITEM_NAME"].ToString().Trim() == centerdt.Rows[j]["item_name"].ToString().Trim())
                            {
                                DataRow dr = matchDt.NewRow();

                                dr["center_code"] = centerdt.Rows[j]["item_code"];
                                dr["center_name"] = centerdt.Rows[j]["item_name"];
                                dr["his_code"] = hisdt.Rows[i]["ITEM_ID"];
                                dr["his_name"] = hisdt.Rows[i]["ITEM_NAME"];

                                matchDt.Rows.Add(dr);
                                break;
                            }
                        }
                    }

                    SetValue(this.lbjd, (i + 1).ToString() + "/" + hisdt.Rows.Count.ToString());
                    SetValue(this.progressBar1, i + 1);
                }
                #endregion
            }
            else if (checkBox2.Checked == true)
            {
                #region
                for (int i = 0; i < hisdt.Rows.Count; i++)
                {
                    for (int j = 0; j < centerdt.Rows.Count; j++)
                    {
                        if (matchclass == HIS.Base_BLL.Enums.MatchClass.药品匹配)
                        {
                            if (hisdt.Rows[i]["NAME"].ToString().Trim().IndexOf(centerdt.Rows[j]["Medi_name"].ToString().Trim()) > 0)
                            {
                                DataRow dr = matchDt.NewRow();

                                dr["center_code"] = centerdt.Rows[j]["Medi_code"];
                                dr["center_name"] = centerdt.Rows[j]["Medi_name"];
                                dr["his_code"] = hisdt.Rows[i]["code"];
                                dr["his_name"] = hisdt.Rows[i]["NAME"];

                                matchDt.Rows.Add(dr);
                                break;
                            }
                        }
                        else if (matchclass == HIS.Base_BLL.Enums.MatchClass.项目匹配)
                        {
                            if (hisdt.Rows[i]["ITEM_NAME"].ToString().Trim().IndexOf(centerdt.Rows[j]["item_name"].ToString().Trim()) > 0)
                            {
                                DataRow dr = matchDt.NewRow();

                                dr["center_code"] = centerdt.Rows[j]["item_code"];
                                dr["center_name"] = centerdt.Rows[j]["item_name"];
                                dr["his_code"] = hisdt.Rows[i]["ITEM_ID"];
                                dr["his_name"] = hisdt.Rows[i]["ITEM_NAME"];

                                matchDt.Rows.Add(dr);
                                break;
                            }
                        }

                    }
                    SetValue(this.lbjd, (i + 1).ToString() + "/" + hisdt.Rows.Count.ToString());
                    SetValue(this.progressBar1, i + 1);
                }
                #endregion
            }
            else if (checkBox3.Checked == true)
            {
                try
                {
                    value = Convert.ToInt32(this.textBox3.Text.Trim());//this.textBox3.Text.Trim().Split(new char[] { '-' })[1].ToString());
                }
                catch
                {
                    MessageBox.Show("请正确填写！");
                }
                #region

                for (int i = 0; i < hisdt.Rows.Count; i++)
                {
                    for (int j = 0; j < centerdt.Rows.Count; j++)
                    {
                        if (matchclass == HIS.Base_BLL.Enums.MatchClass.药品匹配)
                        {
                            #region
                            char[] hisch = hisdt.Rows[i]["NAME"].ToString().Trim().ToCharArray();
                            char[] centerch = centerdt.Rows[j]["Medi_name"].ToString().Trim().ToCharArray();

                            bool b = false;//是否已找到制定匹配

                            for (int ci = 0; ci < hisch.Length; ci++)
                            {
                                for (int cj = 0; cj < centerch.Length; cj++)
                                {
                                    //循环his字符和center字符
                                    //如果his的字符与center的字符相同并且his和center的字符剩余长度大于等于自定value长度，就找剩余value长度的字符是否匹配
                                    if (hisch[ci] == centerch[cj] && hisch.Length - ci > value && centerch.Length - cj > value)
                                    {
                                        //循环制定value后面几个是否相同
                                        for (int k = 1; k <= value; k++)
                                        {
                                            if (hisch[ci + k] != centerch[cj + k])
                                            {
                                                //如果比匹配继续循环
                                                b = false;
                                                break;
                                            }
                                            if (k == value)
                                            {
                                                //如果已经匹配找到了匹配值
                                                b = true;
                                            }
                                        }
                                    }
                                    if (b == true)
                                    {
                                        break;
                                    }
                                }
                                if (b == true)
                                {
                                    break;
                                }
                            }


                            if (b == true)
                            {
                                DataRow dr = matchDt.NewRow();

                                dr["center_code"] = centerdt.Rows[j]["Medi_code"];
                                dr["center_name"] = centerdt.Rows[j]["Medi_name"];
                                dr["his_code"] = hisdt.Rows[i]["code"];
                                dr["his_name"] = hisdt.Rows[i]["NAME"];

                                matchDt.Rows.Add(dr);
                                break;
                            }
                            #endregion
                        }
                        else if (matchclass == HIS.Base_BLL.Enums.MatchClass.项目匹配)
                        {
                            #region
                            char[] hisch = hisdt.Rows[i]["ITEM_NAME"].ToString().Trim().ToCharArray();
                            char[] centerch = centerdt.Rows[j]["item_name"].ToString().Trim().ToCharArray();

                            bool b = false;//是否已找到制定匹配
                            for (int ci = 0; ci < hisch.Length; ci++)
                            {
                                for (int cj = 0; cj < centerch.Length; cj++)
                                {
                                    if (hisch[ci] == centerch[cj] && hisch.Length - ci > value && centerch.Length - cj > value)
                                    {
                                        for (int k = 1; k <= value; k++)
                                        {
                                            if (hisch[ci + k] != centerch[cj + k])
                                            {
                                                b = false;
                                                break;
                                            }
                                            if (k == value)
                                            {
                                                b = true;
                                            }
                                        }
                                    }
                                    if (b == true)
                                    {
                                        break;
                                    }
                                }
                                if (b == true)
                                {
                                    break;
                                }
                            }


                            if (b == true)
                            {
                                DataRow dr = matchDt.NewRow();

                                dr["center_code"] = centerdt.Rows[j]["item_code"];
                                dr["center_name"] = centerdt.Rows[j]["item_name"];
                                dr["his_code"] = hisdt.Rows[i]["ITEM_ID"];
                                dr["his_name"] = hisdt.Rows[i]["ITEM_NAME"];

                                matchDt.Rows.Add(dr);
                                break;
                            }
                            #endregion
                        }
                    }
                    SetValue(this.lbjd, (i + 1).ToString() + "/" + hisdt.Rows.Count.ToString());
                    SetValue(this.progressBar1, i + 1);
                }

                #endregion
            }

            
            //this.dataGridViewEx1.DataSource = matchDt;
            //this.dataGridViewEx1.Refresh();
            SetValue(this.dataGridViewEx1, matchDt);
            SetValue(btSearch, true);
            SetValue(btStop, false);
            SetValue(this);
        }

        

        private void btMatch_Click(object sender, EventArgs e)
        {
            matchDt = (DataTable)this.dataGridViewEx1.DataSource;
            if (matchDt != null)
            {
                IsOk = true;
                this.Close();
            }
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewEx1.CurrentCell != null)
                matchDt.Rows.RemoveAt(this.dataGridViewEx1.CurrentCell.RowIndex);
        }

        private void FrmHelpMatch_FormClosed(object sender, FormClosedEventArgs e)
        {
            btStop_Click(null, null);
        }

       
    }
}
