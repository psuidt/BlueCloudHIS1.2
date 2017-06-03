using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.MZDoc_BLL.Public;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS_MZDocManager
{
    public partial class UCOfenItem : UserControl, IDockingcontrol
    {
        private long _employeeId;
        private DataSet _dataSet = new DataSet();
        public event EventHandler SelectDataList;
        public UCOfenItem(long employeeId)
        {
            InitializeComponent();
            _employeeId = employeeId;
            _cmbFilterFieldItem.Items.Add("智能");
            _cmbFilterFieldItem.Items.Add("拼音");
            _cmbFilterFieldItem.Items.Add("五笔");
            _cmbFilterFieldItem.SelectedIndex = 0;
            RefreshData();
        }

        public void RefreshData()
        {
            if (_dataSet.Tables.IndexOf("CommonData") > -1)
            {
                _dataSet.Tables.Remove("CommonData");
            }
            DataTable table = new HIS.MZDoc_BLL.CommonItem().LoadCommonData(_employeeId);
            table.TableName = "CommonData";
            _dataSet.Tables.Add(table);
            ViewData(_dataSet.Tables["CommonData"].Select(""));
        }

        public void SearchData()
        {
            string strsearch = "";
            switch (_cmbFilterFieldItem.SelectedIndex)
            {
                case 0:
                    strsearch = "Py_Code like '" + _txtSearchItem.Text.Trim() + "%' or Wb_Code like '" + _txtSearchItem.Text.Trim() + "%'";
                    break;
                case 1:
                    strsearch = "Py_Code like '" + _txtSearchItem.Text.Trim() + "%'";
                    break;
                case 2:
                    strsearch = "Wb_Code like '" + _txtSearchItem.Text.Trim() + "%'";
                    break;
                default:
                    break;
            }
            ViewData(_dataSet.Tables["CommonData"].Select(strsearch));
        }

        private void ViewData(DataRow[] rows)
        {
            this._lvwOfenItem.Items.Clear();
            for (int index = 0; index < rows.Length; index++)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = rows[index]["Item_Id"].ToString();
                listViewItem.SubItems.Add(rows[index]["Order_Name"].ToString());
                listViewItem.SubItems.Add(rows[index]["Order_Unit"].ToString());
                listViewItem.SubItems.Add(rows[index]["Frequency"].ToString());
                listViewItem.SubItems.Add(rows[index]["PY_CODE"].ToString());
                listViewItem.SubItems.Add(rows[index]["WB_CODE"].ToString());
                listViewItem.SubItems.Add(rows[index]["D_CODE"].ToString());
                this._lvwOfenItem.Items.Add(listViewItem);
            }
        }

        #region 事件
        /// <summary>
        /// 当字母面板大小发生改变时自动调整其工具栏位置及大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCOfenItem_Resize(object sender, EventArgs e)
        {
            //正常情况下第一排26个字母与一[全部]，宽度和为26*20+42=562
            //第二排内容与第一排对齐，如果宽度不够则分成两行（不管宽度多小）
            const int LETTERMAXWIDTH = 562;
            _pnlItemLetter.Controls.Clear();
            _pnlItemLetter.Height = 45;
            Label lbl = null;
            int yCount = 0;

            #region 字母标签
            for (int i = 65, xCount = 0; i <= 91; i++, xCount++)
            {
                lbl = new Label();
                if (i < 91)
                {
                    lbl.Text = ((char)i).ToString();
                    lbl.Size = new Size(20, 20);
                }
                else
                {
                    lbl.Text = "全部";
                    lbl.Size = new Size(42, 20);
                }
                lbl.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, ((Byte)(134)));
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.MouseHover += new EventHandler(lbl_MouseHover);
                lbl.MouseLeave += new EventHandler(lbl_MouseLeave);
                lbl.Click += new EventHandler(lblItem_Click);
                lbl.Location = new Point(xCount * 20, yCount * 20);
                if (lbl.Left + lbl.Width > _pnlItemLetter.Width)	//如果超出
                {
                    xCount = 0;
                    yCount++;
                    _pnlItemLetter.Height += 20;
                    lbl.Location = new Point(xCount * 20, yCount * 20);
                }
                _pnlItemLetter.Controls.Add(lbl);
            }
            #endregion

            #region	过滤字段与查询代码
            //lblFilter
            yCount++;
            lblFilter.Location = new Point(5, yCount * 20);
            _pnlItemLetter.Controls.Add(lblFilter);

            //_cmbFilterFieldItem
            _cmbFilterFieldItem.Location = new Point(75, yCount * 20);
            _cmbFilterFieldItem.DropDownStyle = ComboBoxStyle.DropDownList;
            _cmbFilterFieldItem.BringToFront();
            _pnlItemLetter.Controls.Add(_cmbFilterFieldItem);

            //lblSearch
            lblSearch.Location = new Point(135, yCount * 20);
            if (lblSearch.Left + lblSearch.Width >= _pnlItemLetter.Width)	//如果超出
            {
                yCount++;
                _pnlItemLetter.Height += 20;
                lblSearch.Location = new Point(5, yCount * 20);
            }
            _pnlItemLetter.Controls.Add(lblSearch);

            //_txtSearchItem
            if (_pnlItemLetter.Width >= LETTERMAXWIDTH)
            {
                _txtSearchItem.Size = new Size(LETTERMAXWIDTH - (lblSearch.Left + lblSearch.Width), 20);
            }
            else
            {
                int lblCount = _pnlItemLetter.Width / 20;	//根据_pnlItemLetter的宽度计算一行最多显示多少字母
                _txtSearchItem.Size = new Size(lblCount * 20 - (lblSearch.Left + lblSearch.Width), 20);
            }
            _txtSearchItem.Location = new Point(lblSearch.Left + lblSearch.Width, yCount * 20);
            _txtSearchItem.BringToFront();
            _pnlItemLetter.Controls.Add(_txtSearchItem);
            #endregion
        }

        /// <summary>
        /// 鼠标在字母上悬停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_MouseHover(object sender, System.EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.BorderStyle = BorderStyle.FixedSingle;
            lbl.ForeColor = Color.Blue;
            lbl.Cursor = Cursors.Hand;
        }
        /// <summary>
        /// 鼠标在字母上离开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_MouseLeave(object sender, System.EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.BorderStyle = BorderStyle.None;
            lbl.ForeColor = Color.Black;
            lbl.Cursor = Cursors.Default;
        }
        
        /// <summary>
        /// 鼠标单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblItem_Click(object sender, System.EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.Red;
            if (lbl.Text == "全部")
            {
                if (_txtSearchItem.Text == "")
                    _cmbFilterFieldItem_SelectionChangeCommitted(null, null);
                else
                    _txtSearchItem.Text = "";
            }
            else
                _txtSearchItem.Text += lbl.Text.ToLower();
            _txtSearchItem.Focus();
            _txtSearchItem.SelectionStart = _txtSearchItem.Text.Length;
        }

        private void _cmbFilterFieldItem_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SearchData();
        }

        private void _txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            _cmbFilterFieldItem_SelectionChangeCommitted(null, null);
        }

        private void _lvwOfenItem_DoubleClick(object sender, EventArgs e)
        {
            if (SelectDataList != null)
            {
                SelectDataList(_lvwOfenItem.SelectedItems[0].Text, e);
            }
        }
        #endregion
    }
}
