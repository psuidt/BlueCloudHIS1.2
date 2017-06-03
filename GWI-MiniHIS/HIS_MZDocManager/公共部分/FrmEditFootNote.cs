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
    /// <summary>
    /// 中药脚注编辑界面
    /// </summary>
    public partial class FrmEditFootNote : Form
    {
        private bool _isSure = false;
        /// <summary>
        /// 中药脚注
        /// </summary>
        public FrmEditFootNote(string footNode)
        {
            InitializeComponent();
            txtFootNote.Text = footNode;
        } 
        #region 属性
       
        /// <summary>
        /// 中药脚注内容
        /// </summary>
        public string FootNote
        {
            get
            {
                return txtFootNote.Text;
            }
            set
            {
                txtFootNote.Text = value;
            }
        }

        /// <summary>
        /// 是否已确定
        /// </summary>
        public bool IsSure
        {
            get
            {
                return _isSure;
            }
        }
        #endregion

        private void cbBFootNote_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFootNote.Text = txtFootNote.Text + (txtFootNote.Text.Trim() == "" ? "" : "，") + cbBFootNote.Text;
        }

        private void btSure_Click(object sender, EventArgs e)
        {
            _isSure = true;
            this.Close();
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            txtFootNote.Text = "";
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
