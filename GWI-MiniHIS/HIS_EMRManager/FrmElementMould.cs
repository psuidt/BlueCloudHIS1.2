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
    /// 病历元素模板
    /// </summary>
    internal partial class FrmElementMould : Form
    {
        private bool _isSure = false;
        private HIS.EMR_BLL.EmrElement _element;
        /// <summary>
        /// 病历元素模板
        /// </summary>
        /// <param name="mouldData">模板数据</param>
        public FrmElementMould(DataTable mouldData)
        {
            InitializeComponent();
            this.dGVMouldList.AutoGenerateColumns = false;
            this.dGVMouldList.DataSource = mouldData;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mouldData"></param>
        public FrmElementMould(HIS.EMR_BLL.EmrElement element)
        {
            InitializeComponent();
            _element = element;
            rdBLevel_CheckedChanged(null,null);
        }
        /// <summary>
        /// 是否确定选中
        /// </summary>
        public bool IsSure
        {
            get { return _isSure; }
            set { _isSure = value; }
        }
        /// <summary>
        /// 所选数据
        /// </summary>
        public string SelectedValue
        {
            get
            {
                string value = "";
                for (int index = 0; index < this.dGVMouldList.Rows.Count; index++)
                {
                    if (Convert.ToBoolean(this.dGVMouldList["Selected", index].Value))
                    {
                        value += this.dGVMouldList["MouldContent", index].Value.ToString()+"，";
                    }
                }
                if (value.Trim().Length > 0)
                {
                    value = value.Substring(0, value.Length - 1);
                }
                return value;
            }
        }
        //确定
        private void btSure_Click(object sender, EventArgs e)
        {
            bool hasChecked = false;
            for (int index = 0; index < this.dGVMouldList.Rows.Count; index++)
            {
                if (Convert.ToBoolean(this.dGVMouldList["Selected", index].Value))
                {
                    hasChecked = true;
                }
            }
            if (!hasChecked)
            {
                if (MessageBox.Show("您未选中任何模板，确定要退出吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }
            _isSure = true;
            this.Close();
        }
        //取消
        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdBLevel_CheckedChanged(object sender, EventArgs e)
        {
            if (_element == null)
            {
                return;
            }
            int level = 0;
            if (rdBHospital.Checked)
            {
                level = 1;
            }
            else if (rdBHospital.Checked)
            {
                level = 2;
            }
            else
            {
                level = 3;
            }
            this.dGVMouldList.AutoGenerateColumns = false;
            this.dGVMouldList.DataSource = _element.GetElementMould(
                level, Public.StaticVariable.CurrentRecordInfo.CreateEmpId, Public.StaticVariable.CurrentRecordInfo.CreateDeptId);
        }
    }
}
