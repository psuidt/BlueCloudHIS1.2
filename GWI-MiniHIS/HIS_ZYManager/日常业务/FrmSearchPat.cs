using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GWMHIS.BussinessLogicLayer.Forms;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZY_BLL.DataModel;
using HIS.ZY_BLL.ObjectModel.NccmManager;
using HIS.Interface;
using HIS_ZYManager.Action;

namespace HIS_ZYManager
{
    //[20100511.2.01]
    public partial class FrmSearchPat : GWI.HIS.Windows.Controls.BaseForm, IFrmSearchPatView
    {
        public bool IsDiag = false;

        //控制器
        FrmRegisterController Controller;

        public FrmSearchPat(FrmRegisterController _controller)
        {
            InitializeComponent();
            Controller = _controller;
            Controller.ifrmSearchPatView = this;

            //按医疗卡号
            this.comboBox1.SelectedIndex = 0;
            this.dgv_patinfo.DataSource = null;
        }
        public FrmSearchPat(FrmRegisterController _controller,string values)
        {
            InitializeComponent();
            Controller = _controller;
            Controller.ifrmSearchPatView = this;

            this.tb_search.Text = values;
            //按患者姓名查
            this.comboBox1.SelectedIndex = 3;
            this.comboBox1.Text = "患者姓名";
            tb_search_KeyDown(null, new KeyEventArgs(Keys.Enter));        
        }

        //窗体加载事件
        private void FrmSearchPat_Load(object sender, EventArgs e)
        {
            
        }
        //查询
        private void tb_search_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    Controller.SearchPat();
                    if (comboBox1.SelectedIndex == 4)
                    {
                        IsDiag = true;
                        this.Close();
                    }
                    this.btSearch.Focus();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示");
            }
        }
        //选择
        private void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Controller.ChoosePat();
                IsDiag = true;
                this.Close();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        //ESC关闭
        private void FrmSearchPat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        #region IFrmSearchPatView 成员

        public string searchValue
        {
            get { return this.tb_search.Text.Trim(); }
        }

        public DataTable patListInfo
        {
            set
            {
                this.dgv_patinfo.AutoGenerateColumns = false;
                this.dgv_patinfo.DataSource = value;
            }
        }

        public int RowIndex
        {
            get
            {
                return this.dgv_patinfo.CurrentCell.RowIndex;
            }
        }

        public int SelectIndex
        {
            get
            {
                return this.comboBox1.SelectedIndex;
            }
        }

        #endregion
    }
}
