using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_EMRManager
{
    /// <summary>
    /// 病历模板名称信息
    /// </summary>
    internal partial class FrmEmrMouldInfo : Form
    {
        private bool _isSure = false;

        /// <summary>
        /// 病历模板名称信息
        /// </summary>
        public FrmEmrMouldInfo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 模板名称
        /// </summary>
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
        /// <summary>
        /// 是否确定
        /// </summary>
        public bool IsSure
        {
            get
            {
                return _isSure;
            }
        }

        //确定
        private void btSure_Click(object sender, EventArgs e)
        {
            _isSure = true;
            this.Close();
        }
        //取消
        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //回车跳转
        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{Tab}");
        }
    }
}
