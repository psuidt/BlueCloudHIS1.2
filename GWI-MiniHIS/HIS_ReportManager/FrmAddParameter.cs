using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_ReportManager
{
    public partial class FrmAddParameter : GWI.HIS.Windows.Controls.BaseForm
    {
        DataTable _procedureparams;
        HIS.Report_BLL.Paramater _currParameter;
        public bool isAdd;
        DataTable _enum;
        public FrmAddParameter(DataTable procedureparams)
        {
            InitializeComponent();
            _procedureparams = procedureparams;
            cbParaNames.DataSource = _procedureparams;
            cbParaNames.DisplayMember = "parmname";
            ShowParadata();
            
        }
        public FrmAddParameter(HIS.Report_BLL.Paramater currParameter)
        {
            InitializeComponent();
            _currParameter = currParameter;
            cbParaNames.Items.Add(_currParameter.PARAMETER);
            cbParaNames.SelectedIndex = 0;
            txtInOut.Text = _currParameter.PARAMETER_TYPE;
            txtParamLength.Text = _currParameter.DATALENGTH.ToString();
            txtParamter_cn.Text = _currParameter.PARAMETER_CN;
            txtParaType.Text = _currParameter.PARAMDATATYPE.ToString();         
        }
        private void cbParaNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isAdd)
            {
                ShowParadata();
            }
        }
        private void ShowParadata()
        {
            txtInOut.Text = "";
            txtParamLength.Text = "";
            txtParaType.Text = "";            
            string parmnname = cbParaNames.Text.Trim();
            DataRow[] rows = _procedureparams.Select("parmname='" + parmnname + "'");
            if (rows == null || rows.Length == 0)
            {
                return;
            }
            txtInOut.Text = rows[0]["rowtype"].ToString().Trim() == "P" ? "IN" : "OUT";
            txtParamLength.Text = rows[0]["length"].ToString();
            txtParaType.Text = rows[0]["typename"].ToString();
        }

        private void FrmAddParameter_Load(object sender, EventArgs e)
        {
            if (isAdd)
            {
                ShowParadata();
            }        
            foreach (object obj in Enum.GetValues(typeof(HIS.Report_BLL.ReControlTyp)))
                cbParaControl.Items.Add(obj.ToString());
            if (_currParameter != null)
            {
                cbParaControl.SelectedIndex = _currParameter.UIC_TYPE;
            }
            else
            {
                cbParaControl.SelectedIndex = 0;
            }
            HIS.Report_BLL.ParamProcess _paramProcess = new HIS.Report_BLL.ParamProcess();
            _enum = _paramProcess.getEnum();
            DataRow dr = _enum.NewRow();
          dr["ENUMNAME"] = "无";
          _enum.Rows.Add(dr);
          this.cbSource.DataSource = _enum;
          this.cbSource.DisplayMember = "ENUMNAME";
          this.cbSource.ValueMember = "ID";
          if (isAdd)
          {
              this.cbSource.SelectedIndex = -1;
          }
          else
          {
              DataRow[] row = _enum.Select("id=" + _currParameter.ENUMEID + "");
              if (row != null && row.Length != 0)
              {
                  this.cbSource.Text = row[0]["ENUMNAME"].ToString();
              }
              else
              {
                  this.cbSource.SelectedIndex = -1;
              }
          }
        }

        private void GetParamter()
        {
            if (isAdd)
            {
                if (_currParameter == null)
                {
                    _currParameter = new HIS.Report_BLL.Paramater();
                }
                if (txtParaType.Text.IndexOf("INT", 0) >= 0)
                {
                    _currParameter.PARAMDATATYPE = 1;
                }
                else if (txtParaType.Text.IndexOf("DATE", 0) >= 0 || txtParaType.Text.IndexOf("TIME", 0) >= 0)
                {
                    _currParameter.PARAMDATATYPE = 2;
                }
                else
                {
                    _currParameter.PARAMDATATYPE = 0;
                }
            }
            else
            {
                _currParameter.PARAMDATATYPE = Convert.ToInt32(txtParaType.Text);
            }
            _currParameter.PARAMETER = cbParaNames.Text.Trim();
            _currParameter.PARAMETER_CN = txtParamter_cn.Text.Trim();
          
            _currParameter.DATALENGTH = txtParamLength.Text.Trim() == "" ? 0 : Convert.ToInt32(txtParamLength.Text);
            _currParameter.UIC_TYPE = cbParaControl.SelectedIndex;
            _currParameter.PARAMETER_TYPE = txtInOut.Text.Trim();

            if (cbSource.SelectedIndex!=-1)
            {
                DataRow[] dr = _enum.Select("enumname='" + cbSource.Text.Trim() + "'");
                if (dr == null || dr.Length == 0)
                {
                    return;
                }
                //_currParameter.FOREIGNER_FILTER_SQL = dr[0]["remark"].ToString().Trim();
                //_currParameter.FOREIGNER_FIELD_CN_NAME = "name";
                //_currParameter.FOREIGNER_FIELD_DB_NAM = "id";
                if (cbSource.Text.Trim() != "无")
                {
                    _currParameter.ENUMEID = Convert.ToInt32(cbSource.SelectedValue.ToString());
                }
                else
                {
                    _currParameter.ENUMEID = 0;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            GetParamter();
            if (isAdd)
            {
                _currParameter.addParamter();
            }
            else
            {
                _currParameter.UpateParamter();

            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbParaControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbParaControl.SelectedIndex == 1 || cbParaControl.SelectedIndex == 4)
            {
                grpSelectSource.Enabled = true;
            }
            else
            {
                grpSelectSource.Enabled = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmEditSource edit = new FrmEditSource();           
            if (!isAdd)
            {
                edit.sourceSql = _currParameter.FOREIGNER_FILTER_SQL;
            }
            edit.ShowDialog();
            if (edit.isRight)
            {
                if (_currParameter == null)
                {
                    _currParameter = new HIS.Report_BLL.Paramater();
                }
                _currParameter.FOREIGNER_FILTER_SQL = edit.sourceSql;
                _currParameter.FOREIGNER_FIELD_CN_NAME = "name";
                _currParameter.FOREIGNER_FIELD_DB_NAME = "id";
                _currParameter.ENUMEID = -1;
            }
        }

        private void cbSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSource.Text.Trim() != "无")
            {
                linkLabel1.Enabled = false;
            }
            else
            {
                linkLabel1.Enabled = true;
            }
        }

      
    }
}
