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

namespace HIS_MediConfirManager
{
    public partial class FrmMzConfir : GWI.HIS.Windows.Controls.BaseMainForm, Action.IFrmConfirView
    {
        private Action.FrmConfirController Controller;
        private User _currentUser;
        private Deptment _currentDept;
        private List<HIS.Model.MZ_PatList> _mzPatlist;
        private List<HIS.Model.MZ_PatList> _selectMzPatlist;
        private GWI.HIS.Windows.Controls.ListView _listView;
        private bool _isConfird;
        private HIS.MedicalConfir_BLL.ConfirType _ConfirType;
        #region 接口成员
        public User currentUser
        {
            get
            {
                return _currentUser;
            }
        }
        public Deptment currentDept
        {
            get
            {
                return _currentDept;
            }
        }
        public bool IsConfird
        {
            get
            {
                return _isConfird;
            }
            set
            {
                _isConfird = value;
            }
        }
        public HIS.MedicalConfir_BLL.ConfirType ConfirType
        {
            get
            {
                return _ConfirType;
            }
            set
            {
                _ConfirType = value;
            }
        }
        public DateTime? GetBdate
        {
            get
            {
                if (TabPlist.SelectedIndex == 0)
                {
                    return dtpBeginTime.Value; 
                }
                else
                {
                    return dtpBegin.Value;
                }
            }
        }
        public DateTime? GetEdate
        {
            get
            {
                if (TabPlist.SelectedIndex == 0)
                {
                    return dtpEndTime.Value;
                }
                else
                {
                    return dtpEnd.Value;
                }
            }
        }
        public List<HIS.Model.MZ_PatList> mzPatlist { get { return _mzPatlist; } set { _mzPatlist = value; } }
        public List<HIS.Model.ZY_PatList> zyPatlist
        {
            get;
            set;
        }
        public List<HIS.Model.ZY_PatList> selectPatlist { get; set; }
       public  List<HIS.Model.MZ_PatList> selectMzPatlist { get { return _selectMzPatlist; } set { _selectMzPatlist = value; } } //选中的门诊病人列表
        public DataTable BindItems
        {
            get
            {
                return (DataTable)DgvFeeDetail.DataSource;
            }
            set
            {
                DgvFeeDetail.AutoGenerateColumns = false;
                DgvFeeDetail.DataSource = value;
            }
        }
        #endregion      

        #region 构造函数
        public FrmMzConfir(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            IsConfird = false;
            _listView = LvNotConfir;
            ConfirType = HIS.MedicalConfir_BLL.ConfirType.门诊;
            Controller = new HIS_MediConfirManager.Action.FrmConfirController(this);
            btnCancel.Enabled = false;
            BtnOK.Enabled = true;
        }
        #endregion

        #region Tab页面转换
        private void TabPlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindItems = null;
            if (TabPlist.SelectedIndex == 0)
            {
                _listView = LvNotConfir;
                IsConfird = false;
                btnCancel.Enabled = false;
                BtnOK.Enabled = true;

            }
            else
            {
                _listView = LvConfir;
                IsConfird = true;
                btnCancel.Enabled = true;
                BtnOK.Enabled = false;
            }
            if (selectMzPatlist == null)
            {
                selectMzPatlist = new List<HIS.Model.MZ_PatList>();
                return;
            }
            selectMzPatlist.Clear();
        }
        #endregion

        #region 加载病人列表
        public void BindPatlist()
        {
            _listView.Items.Clear();
            if (mzPatlist == null)
            {
                return;
            }
            else
            {
                for (int i = 0; i < mzPatlist.Count; i++)
                {
                    ListViewItem lstViewItem = new ListViewItem();
                    lstViewItem.SubItems.Clear();
                    lstViewItem.Tag = mzPatlist[i];
                    lstViewItem.SubItems[0].Text = mzPatlist[i].PatName;
                    lstViewItem.SubItems.Add(mzPatlist[i].VisitNo);
                    lstViewItem.SubItems.Add(mzPatlist[i].PatSex);
                    lstViewItem.SubItems.Add(mzPatlist[i].Age.ToString());
                    lstViewItem.SubItems.Add(mzPatlist[i].CureDate.ToString("yyyy-MM-dd"));
                    _listView.Items.Add(lstViewItem);
                }
            }
        }
        #endregion

        #region 未确费病人刷新
        private void LinkFreshNotConfir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataTable dt = BindItems;
            Controller.GetPatlist();
            BindItems = dt;
        }
        #endregion

        #region 已确费病人刷新 
        private void LinkFreshConfir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataTable dt = BindItems;
            Controller.GetPatlist();
            BindItems = dt;
        }
        #endregion

        #region 病人列表列标题单击事件
        private void LvNotConfir_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                for (int i = 0; i < _listView.Items.Count; i++)
                {
                    _listView.Items[i].Checked = true;                   
                }
            }
        }
        #endregion

        #region 选中病人事件
        private void  LvNotConfir_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem item = e.Item;
            HIS.Model.MZ_PatList pat = (HIS.Model.MZ_PatList)item.Tag;
            if (item.Checked)
            {
                Controller.MzAddItems(pat);
                int i = 0;
                if (selectMzPatlist == null)
                {
                    selectMzPatlist = new List<HIS.Model.MZ_PatList>();
                    selectMzPatlist.Add(pat);
                }
                else
                {
                    for (i = 0; i < selectMzPatlist.Count; i++)
                    {
                        if (selectMzPatlist[i].PatListID == pat.PatListID)
                        {
                            break;
                        }
                    }
                    if (i == selectMzPatlist.Count)
                    {
                        selectMzPatlist.Add(pat);
                    }
                }
            }
            else
            {
                Controller.MzPlusItems(pat);
                if (selectMzPatlist == null) return;
                for (int i = 0; i < selectMzPatlist.Count; i++)
                {
                    if (selectMzPatlist[i].PatListID == pat.PatListID)
                    {
                        selectMzPatlist.Remove(pat);
                    }
                }
            }
        }
        #endregion

        #region 费用明细选中事件
        private void DgvFeeDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvFeeDetail == null || DgvFeeDetail.Rows.Count == 0)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {
                int rowid = e.RowIndex;
                if (rowid < 0)
                {
                    return;
                }
                Controller.CellXD(rowid, true);
            }
        }
        #endregion

        #region 费用明细列标题单击选中事件
        private void DgvFeeDetail_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                for (int i = 0; i < this.DgvFeeDetail.Rows.Count; i++)
                {
                    Controller.CellXD(i, false);
                }
            }
        }
        #endregion

        #region 按钮事件
        //确费
        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (Controller.FeeConfir())
            {
               // Controller.GetItems();
                MessageBox.Show("确费成功");
            }
        }
        //取消确费
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Controller.ConcelFee())
            {
                Controller.GetItems();
                MessageBox.Show("取消确费成功");
            }
        }
        //全选
        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.DgvFeeDetail.Rows.Count; i++)
            {
                Controller.CellXD(i, false);
            }
        }
        //反选
        private void BtnSelectNot_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.DgvFeeDetail.Rows.Count; i++)
            {
                Controller.CellXD(i, true);
            }
        }
        //刷新 
        private void BtnFresh_Click(object sender, EventArgs e)
        {
            Controller.GetItems();
        }
        // 退出
        private void BtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 显示病人信息
        private void LvNotConfir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_listView == null || _listView.SelectedItems.Count == 0)
            {              
                return;
            }
            else
            {               
                HIS.Model.MZ_PatList pat = (HIS.Model.MZ_PatList)_listView.SelectedItems[0].Tag;
                txtVistno.Text = pat.VisitNo.ToString();
                txtPatname .Text= pat.PatName.ToString();
                txtPatAge.Text = pat.Age.ToString();
                txtPatSex.Text = pat.PatSex.ToString();
                txtPatType.Text = pat.MediType;
                
                txtRegDept.Text = pat.REG_DEPT_NAME;
                txtCureDoc.Text =HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName( pat.CureEmpCode.ToString());
                txtCureDept.Text = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(pat.CureDeptCode.ToString());
                txtDisease.Text = pat.DiseaseName;               
            }
        }
        #endregion

        #region 全选所有病人
        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _listView.Items.Count; i++)
            {
                _listView.Items[i].Checked = true;
            }
        }
        #endregion

        #region 反选病人列表
        private void 反选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _listView.Items.Count; i++)
            {
                if (_listView.Items[i].Checked == true)
                {
                    _listView.Items[i].Checked = false;
                }
                else
                {
                    _listView.Items[i].Checked = true;
                }
            }
        }
        #endregion

        #region 通过门诊就诊号查询
        #region 通过门诊就诊号查询
        private void btnFind_Click(object sender, EventArgs e)
        {
            string visitno = txtFind.Text.Trim();
            if (visitno == "")
            {
                return;
            }
            Controller.FindFee(visitno);
        }
        #endregion
        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            string visitno = txtFind.Text.Trim();
            if (visitno == "")
            {
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                Controller.FindFee(visitno);
            }
        }
        #endregion
    }
}
