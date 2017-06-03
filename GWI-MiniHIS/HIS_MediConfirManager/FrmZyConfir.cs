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
    public partial class FrmZyConfir : GWI.HIS.Windows.Controls.BaseMainForm,Action.IFrmConfirView
    {
        private Action.FrmConfirController Controller;
        private User _currentUser;
        private Deptment _currentDept;
        private List<HIS.Model.ZY_PatList> _zyPatlist;
        private List<HIS.Model.ZY_PatList> _selectPatlist;
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
        public  bool IsConfird
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
        public   List<HIS.Model.MZ_PatList> selectMzPatlist { get; set; } //选中的门诊病人列表
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
         public  List<HIS.Model.MZ_PatList> mzPatlist { get; set; }
         public  List<HIS.Model.ZY_PatList> zyPatlist
        {
            get
            {
                return _zyPatlist;
            }
            set
            {
                _zyPatlist = value;
            }
        }
         public List<HIS.Model.ZY_PatList> selectPatlist { get { return _selectPatlist; } set { _selectPatlist = value; } } 
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
        public FrmZyConfir(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            IsConfird = false;
            _listView = LvNotConfir;
            ConfirType = HIS.MedicalConfir_BLL.ConfirType.住院;
            Controller = new HIS_MediConfirManager.Action.FrmConfirController(this);
            btnCancel.Enabled = false;
            BtnOK.Enabled = true;
        }
        #endregion

        #region 病人列表事件

        #region  Tab索引改变事件 
        private void TabPlist_SelectedIndexChanged(object sender, EventArgs e)
        {           
            BindItems = null;
            if (TabPlist.SelectedIndex == 0)
            {
                _listView = LvNotConfir;
                IsConfird = false;
                btnCancel.Enabled= false;
                BtnOK.Enabled = true;

            }
            else
            {
                _listView = LvConfir;
                IsConfird = true;
                btnCancel.Enabled = true;
                BtnOK.Enabled = false;
            }
            if (selectPatlist == null)
            {
                selectPatlist = new List<HIS.Model.ZY_PatList>();
                return;
            }
            selectPatlist.Clear();
        }
        #endregion

        #region 加载病人列表
        public void BindPatlist()
        {
            _listView.Items.Clear();
            if (zyPatlist == null)
            {              
                return;
            }
            else
            {
                for (int i = 0; i < zyPatlist.Count; i++)
                {
                    ListViewItem lstViewItem = new ListViewItem();
                    lstViewItem.SubItems.Clear();
                    lstViewItem.Tag = zyPatlist[i];
                    lstViewItem.SubItems[0].Text = zyPatlist[i].PatientInfo.PatName;
                    lstViewItem.SubItems.Add(zyPatlist[i].CureNo);
                    lstViewItem.SubItems.Add(HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(zyPatlist[i].CurrDeptCode));
                    lstViewItem.SubItems.Add(zyPatlist[i].PatientInfo.PatSex);
                    lstViewItem.SubItems.Add(zyPatlist[i].BedCode);
                    lstViewItem.SubItems.Add(zyPatlist[i].PatientInfo.PatBriDate.ToString("yyyy-MM-dd"));
                    _listView.Items.Add(lstViewItem);
                }
            }
        }
        #endregion

        #region 未确费病人列表刷新
        /// <summary>
         /// 未确费病人列表刷新
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void LinkFreshNotConfir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          DataTable dt = BindItems;
            Controller.GetPatlist();
           BindItems = dt;
        }
        #endregion

        #region 已确费病人列表刷新
        /// <summary>
        /// 已确费病人列表刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkFreshConfir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          DataTable dt = BindItems;
            Controller.GetPatlist();
           BindItems = dt;
        }
        #endregion

        //单击列表姓名一列时全选
        private void LvConfir_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
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
        }

        #region 选择事件
        private void LvNotConfir_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem item = e.Item;
            HIS.Model.ZY_PatList pat =(HIS.Model.ZY_PatList) item.Tag;
            if (item.Checked)
            {
                Controller.AddItems(pat);
                int i=0;
                if (selectPatlist == null)
                {
                    selectPatlist = new List<HIS.Model.ZY_PatList>();
                    selectPatlist.Add(pat);
                }
                else
                {
                    for (i = 0; i < selectPatlist.Count; i++)
                    {
                        if (selectPatlist[i].PatListID == pat.PatListID)
                        {
                            break;
                        }
                    }
                    if (i == selectPatlist.Count)
                    {
                        selectPatlist.Add(pat);
                    }
                }
            }
            else
            {
                Controller.PlusItems(pat);
                if (selectPatlist == null) return;
                for ( int i = 0; i < selectPatlist.Count; i++)
                {
                    if (selectPatlist[i].PatListID == pat.PatListID)
                    {
                        selectPatlist.Remove(pat);
                    }
                }
            }
        }
        #endregion

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
               Controller.CellXD(rowid,true);
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
        //关闭
        private void BtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion       

        private void DgvFeeDetail_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                for (int i = 0; i < this.DgvFeeDetail.Rows.Count; i++)
                {
                    Controller.CellXD(i, true );
                }
            }
        }

        private void LvNotConfir_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (_listView == null || _listView.SelectedItems.Count==0)
            {
                PatInfoPanel.Clear();               
                return;
            }
            else
            {
                _listView.SelectedItems[0].Checked = !_listView.SelectedItems[0].Checked;
                PatInfoControl patinfo = new PatInfoControl();
                HIS.Model.ZY_PatList pat = (HIS.Model.ZY_PatList)_listView.SelectedItems[0].Tag;                
                PatInfoPanel.InPaitent = patinfo.SetData(pat);
            }
        }
        #region 全选所有病人
        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _listView.Items.Count; i++)
            {
                _listView.Items[i].Checked = true;
            }
        }
        #endregion

        #region 反选病人
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

        #region 按住院号查询
      
        private void txtCurenoFind_KeyDown(object sender, KeyEventArgs e)
        {                  
            if (e.KeyCode == Keys.Enter)
            {
                    
               // Controller.FindFee(cureno);
                string cureno;
                if (IsConfird)
                {
                    cureno = txtCurNo1.Text.Trim();
                }
                else
                {
                    cureno = txtCurenoFind.Text.Trim();
                }
                if (zyPatlist == null || zyPatlist.Count == 0)
                {
                    return;
                }
                List<HIS.Model.ZY_PatList> plist = new List<HIS.Model.ZY_PatList>();
                for (int i = 0; i < zyPatlist.Count; i++)
                {
                    if (cureno == zyPatlist[i].CureNo)
                    {
                        plist.Add(zyPatlist[i]);
                    }
                }               
                BindPatlist(plist);
            }
        }
        #endregion
        private void txtPatName_TextChanged(object sender, EventArgs e)
        {
            string pywb ;
            if(IsConfird)
            {
                pywb = txtPatName1.Text.Trim();
            }
            else
            {
                pywb=txtPatName.Text.Trim();
            }
            if (zyPatlist == null || zyPatlist.Count == 0)
            {
                return;
            }
            List<HIS.Model.ZY_PatList> plist = new List<HIS.Model.ZY_PatList>();
            for (int i = 0; i < zyPatlist.Count; i++)
            {
                if (zyPatlist[i].PatientInfo.PYM.IndexOf(pywb, 0) >= 0 || zyPatlist[i].PatientInfo.WBM.IndexOf(pywb, 0) >= 0 || zyPatlist[i].PatientInfo.PatName.IndexOf(pywb) >= 0)
                {
                    plist.Add(zyPatlist[i]);
                }
            }          
            BindPatlist(plist);
        }

        #region 加载病人列表
        public void BindPatlist(List<HIS.Model.ZY_PatList> plist)
        {
            _listView.Items.Clear();
            if (plist == null)
            {
                return;
            }
            else
            {
                for (int i = 0; i < plist.Count; i++)
                {
                    ListViewItem lstViewItem = new ListViewItem();
                    lstViewItem.SubItems.Clear();
                    lstViewItem.Tag = plist[i];
                    lstViewItem.SubItems[0].Text = plist[i].PatientInfo.PatName;
                    lstViewItem.SubItems.Add(plist[i].CureNo);
                    lstViewItem.SubItems.Add(HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(plist[i].CurrDeptCode));
                    lstViewItem.SubItems.Add(plist[i].PatientInfo.PatSex);
                    lstViewItem.SubItems.Add(plist[i].BedCode);
                    lstViewItem.SubItems.Add(plist[i].PatientInfo.PatBriDate.ToString("yyyy-MM-dd"));
                    _listView.Items.Add(lstViewItem);
                }
            }
        }
        #endregion

     
    }
}
