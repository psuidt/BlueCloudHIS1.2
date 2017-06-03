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
using HIS.ZY_BLL.ObjectModel.BaseData;

namespace HIS_MediInsInterface
{
    public partial class ZYBaseFrom : GWI.HIS.Windows.Controls.BaseMainForm
    {
        public delegate void lvPatList_DoubleClickEvent(object sender, EventArgs e);
        /// <summary>
        /// 病人列表双击事件
        /// </summary>
        public event lvPatList_DoubleClickEvent HIS_DoubleClick;

        public ZY_PatList zy_PatList = null;
        private ZY_PatList[] _zy_PatLists =null;

        private User _currentUser;
        private Deptment _currentDept;
        private FilterType _filterType;			//选项卡条件过滤类别
        private SearchType _searchType;

        protected bool IsCost = false;
        public long currentUserId
        {
            set
            {
                _currentUser = new User(value);
            }
        }
        public long currentDeptId
        {
            set
            {
                _currentDept = new Deptment(value); ;
            }
        }

        public string chineseName
        {
            set
            {
                this.Text = value;
            }
        }
        public ZY_PatList[] zy_PatLists
        {
            get
            {
                List<ZY_PatList> zylist = new List<ZY_PatList>();

                for (int i = 0; i < this.lvPatList.Items.Count; i++)
                {
                    if (this.lvPatList.Items[i].Checked)
                    {
                        zylist.Add((ZY_PatList)this.lvPatList.Items[i].Tag);
                    }
                }
                _zy_PatLists = zylist.ToArray();
                return _zy_PatLists;
            }
        }
        public User currentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;

            }
        }
        public Deptment currentDept
        {
            get { return _currentDept; }
            set { _currentDept = value; }
        }
        public FilterType filterType
        {
            get { return _filterType; }
            set { _filterType = value; }
        }
        public SearchType searchType
        {
            get { return _searchType; }
            set { _searchType = value; }
        }

        List<ZY_PatList> zypatlist = null;

        public ZYBaseFrom()
        {

            InitializeComponent();
            DataTable dt = BaseDataFactory.GetData(baseDataType.住院临床科室);
            this.cbDept.DataSource = dt;
            this.cbDept.DisplayMember = "name";
            zy_PatList = new ZY_PatList();
        }
        // 绑定病人列表
        private void BindLvPatList1(bool b)
        {
            this.lvPatList.Items.Clear();

            //List<ZY_PatList> zypatlist = null;
            if (b == true)
            {
                zypatlist = zy_PatList.BindPatList();
            }

            for (int i = 0; i < zypatlist.Count; i++)
            {
                ListViewItem lstViewItem = new ListViewItem();
                lstViewItem.SubItems.Clear();
                lstViewItem.Tag = zypatlist[i];
                lstViewItem.SubItems[0].Text = zypatlist[i].CureNo;
                lstViewItem.SubItems.Add(zypatlist[i].patientInfo.PatName);
                lstViewItem.SubItems.Add(zypatlist[i].patientInfo.PatSex);
                lstViewItem.SubItems.Add(zypatlist[i].patientInfo.PatBriDate.ToString("yyyy-MM-dd"));
                this.lvPatList.Items.Add(lstViewItem);
            }
        }
        // 绑定病人列表
        private void BindLvPatList(bool IsOper)
        {
            string DeptCode = null;
            if (this.chbDept.Checked)
            {
                DeptCode = ((DataRowView)this.cbDept.SelectedValue).Row["code"].ToString().Trim();
            }
            DateTime? Bdate = null;
            DateTime? Edate = null;
            if (this.cbdate.Checked)
            {
                Bdate = this.dtpBegin.Value;
                Edate = this.dtpEnd.Value;
            }

            this.lvPatList.Items.Clear();

            

            BindPatListVal bplv = new BindPatListVal();
            bplv.IsIn=this.rbin.Checked;
            bplv.DeptCode=DeptCode;
            bplv.Bdate=Bdate;
            bplv.Edate=Edate;
            bplv.IsOperation = IsOper;
            zy_PatList.bindPatListVal = bplv;
            zypatlist = zy_PatList.BindPatList();

            for (int i = 0; i < zypatlist.Count; i++)
            {
                ListViewItem lstViewItem = new ListViewItem();
                lstViewItem.SubItems.Clear();
                lstViewItem.Tag = zypatlist[i];
                lstViewItem.SubItems[0].Text = zypatlist[i].CureNo;
                lstViewItem.SubItems.Add(zypatlist[i].patientInfo.PatName);
                lstViewItem.SubItems.Add(zypatlist[i].patientInfo.PatSex);
                lstViewItem.SubItems.Add(zypatlist[i].patientInfo.PatBriDate.ToString("yyyy-MM-dd"));
                this.lvPatList.Items.Add(lstViewItem);
            }
            this.label1.Text = zypatlist.Count + " 人";
        }
        //刷新
        public void llabrush_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.BindLvPatList(this.checkBox1.Checked);
        }
        //双击病人列表
        private void lvPatList_DoubleClick(object sender, EventArgs e)
        {
            if (this.lvPatList.SelectedItems.Count > 0)
            {
                zy_PatList = (ZY_PatList)this.lvPatList.SelectedItems[0].Tag;
                this.HIS_DoubleClick(sender, e);
            }
        }
        //显示科室
        private void chbDept_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chbDept.Checked)
            {
                this.cbDept.Enabled = true;
            }
            else
            {
                this.cbDept.Enabled = false;
            }
        }
        //出院
        private void rbOut_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbOut.Checked)
            {
                this.cbdate.Checked = true;
                this.chbDept.Checked = true;
            }
        }
        //显示日期
        private void cbdate_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbdate.Checked)
            {

                this.dtpBegin.Enabled = true;
                this.dtpEnd.Enabled = true;

                this.dtpBegin.Value = DateTime.Now.AddMonths(-1);
                this.dtpEnd.Value = DateTime.Now;
            }
            else
            {
                this.dtpBegin.Enabled = false;
                this.dtpEnd.Enabled = false;
            }
        }
        //在院
        private void rbin_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbin.Checked)
            {
                this.cbdate.Checked = false;
                this.chbDept.Checked = false;
            }
        }
        //根据住院号检索
        private void tbInpatNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (zypatlist != null)
                {
                    List<ZY_PatList> patlist = zypatlist.FindAll(x => x.CureNo == this.tbInpatNo.Text);

                    this.lvPatList.Items.Clear();

                    for (int i = 0; i < patlist.Count; i++)
                    {
                        ListViewItem lstViewItem = new ListViewItem();
                        lstViewItem.SubItems.Clear();
                        lstViewItem.Tag = patlist[i];
                        lstViewItem.SubItems[0].Text = patlist[i].CureNo;
                        lstViewItem.SubItems.Add(patlist[i].patientInfo.PatName);
                        lstViewItem.SubItems.Add(patlist[i].patientInfo.PatSex);
                        lstViewItem.SubItems.Add(patlist[i].patientInfo.PatBriDate.ToString("yyyy-MM-dd"));
                        this.lvPatList.Items.Add(lstViewItem);
                    }

                    if (patlist.Count > 0)
                    {
                        zy_PatList = patlist[0];
                        this.HIS_DoubleClick(sender, e);
                    }
                }

            }
        }
        //根据病人名称拼音码检索
        private void tbPatName_TextChanged(object sender, EventArgs e)
        {
            if (zypatlist != null)
            {
                List<ZY_PatList> patlist = zypatlist.FindAll(x => (x.patientInfo.PYM.ToLower().Contains(this.tbPatName.Text.Trim()) || x.patientInfo.PatName.Contains(this.tbPatName.Text.Trim())));

                this.lvPatList.Items.Clear();

                for (int i = 0; i < patlist.Count; i++)
                {
                    ListViewItem lstViewItem = new ListViewItem();
                    lstViewItem.SubItems.Clear();
                    lstViewItem.Tag = patlist[i];
                    lstViewItem.SubItems[0].Text = patlist[i].CureNo;
                    lstViewItem.SubItems.Add(patlist[i].patientInfo.PatName);
                    lstViewItem.SubItems.Add(patlist[i].patientInfo.PatSex);
                    lstViewItem.SubItems.Add(patlist[i].patientInfo.PatBriDate.ToString("yyyy-MM-dd"));
                    this.lvPatList.Items.Add(lstViewItem);
                }
            }
        }

        private void ZYBaseFrom_Load(object sender, EventArgs e)
        {
            //DataTable dt = BaseDataFactory.GetData(baseDataType.住院临床科室);
            //this.cbDept.DataSource = dt;
            //this.cbDept.DisplayMember = "name";

            //zy_PatList = new ZY_PatList();
        }
    }
}
