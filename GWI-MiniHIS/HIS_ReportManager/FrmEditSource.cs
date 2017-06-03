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
    public partial class FrmEditSource : GWI.HIS.Windows.Controls.BaseForm
    {
         public   bool isRight = false;
        #region 属性
        public string sourceSql
        {
            get
            {
                return richTxtSql.Text.Trim();
            }
            set
            {
                richTxtSql.Text = value;
            }
        }      
        #endregion
        public FrmEditSource()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isRight)
            {
                MessageBox.Show("请先正确通过SQL测试");
                return;
            }
            this.Close();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            HIS.Report_BLL.Paramater _parameter = new HIS.Report_BLL.Paramater();
            if (sourceSql == "")
            {
                MessageBox.Show("数据源SQL不能为空");                
                return;
            }
            try
            {
                if (_parameter.TestSQL(sourceSql))
                {
                    isRight = true;
                    MessageBox.Show("SQL语句正确！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FrmEditSource_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            isRight = false;
            this.Close();
        }
    }
}
