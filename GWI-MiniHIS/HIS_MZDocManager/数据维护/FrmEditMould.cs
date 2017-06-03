using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_MZDocManager
{
    public partial class FrmEditMould : Form
    {
        private bool _isSure = false;
        public FrmEditMould()
        {
            InitializeComponent();
        }

        #region 属性
        public HIS.MZDoc_BLL.Public.CurrentStatus OperateType
        {
            set 
            {
                switch (value)
                {
                    case HIS.MZDoc_BLL.Public.CurrentStatus.新建状态:
                        this.Text = "新建节点";
                        break;
                    case HIS.MZDoc_BLL.Public.CurrentStatus.修改状态:
                        this.plType.Visible = false;
                        this.Text = "修改节点";
                        break;
                }
            }
        }

        public int MouldType
        {
            get
            {
                return rdBMould.Checked?1:0;
            }
        }

        public string MouldName
        {
            get
            {
                return txtName.Text;
            }
            set
            {
                txtName.Text = value;
            }
        }

        public bool IsSure
        {
            get
            {
                return _isSure;
            }
        }
        #endregion

        private void btSure_Click(object sender, EventArgs e)
        {
            _isSure = true;
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{Tab}");
        }
    }
}
