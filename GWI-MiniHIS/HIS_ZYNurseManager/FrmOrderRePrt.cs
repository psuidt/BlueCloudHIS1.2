/*
 * 2010-3-29    添加输入页码范围异常处理
 *              添加页面范围输入框获取焦点事件和回车事件
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_ZYNurseManager
{
    public partial class FrmOrderRePrt : Form
    {
        int[] _pages;
        bool _exitflag;//退出标识，true取消，false打印
        /// <summary>
        /// 获取需要重打的页码
        /// </summary>
        public int[] Pages
        {
            get
            {
                return _pages;
            }
        }
        /// <summary>
        /// 获取退出标识，true取消，false打印
        /// </summary>
        public bool ExitFlag
        {
            get
            {
                return _exitflag;
            }
        }       
        public FrmOrderRePrt(int[] validpages)
        {
            InitializeComponent();
            _pages = validpages;
            //如果超过两页，当前可用页码范围加" - 最后一页页数"
            if (_pages.Length > 1)
                lbl_ValidPageNO.Text += " - " + _pages.Length;
        }        

        private void btn_Print_Click(object sender, EventArgs e)
        {
            //打印范围选定为所有页面
            if (rbn_AllPages.Checked)
            {
                for (int i = 0; i < _pages.Length; i++)
                    _pages[i] = 1;
            }
            //打印范围选定为页面范围
            if (rbn_PageRange.Checked)
            {
                //处理页面范围后的页码
                string[] str = tbx_Pages.Text.Split(',');
                for (int i = 0; i < str.Length; i++)
                {
                    try
                    {
                        if (str[i].Contains('-'))
                        {
                            string[] substr = str[i].Split('-');
                            for (int pageno = Convert.ToInt32(substr[0]) - 1; pageno < Convert.ToInt32(substr[1]); pageno++)
                            {
                                _pages[pageno] = 1;
                            }
                        }
                        else
                        {
                            int pageno = Convert.ToInt32(str[i]) - 1;
                            _pages[pageno] = 1;
                        }
                    }
                    catch (IndexOutOfRangeException indxEx)
                    {
                        MessageBox.Show("输入页码超出界限，请输入可用页码范围内的页码值\n\t"+indxEx.Message, "提示", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("出现未知异常，请联系管理员\n\t"+ex.Message, "提示", MessageBoxButtons.OK);
                    }
                }
            }
            _exitflag = false;
            this.Close();
        }

        private void tbx_Pages_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_Print.PerformClick();
        }

        private void tbx_Pages_Enter(object sender, EventArgs e)
        {
            rbn_PageRange.Checked = true;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            _exitflag = true;
            this.Close();
        }
    }
}
