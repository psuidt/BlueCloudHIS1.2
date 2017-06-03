using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_MZDocManager
{
    public partial class UCPatientList : UserControl, IDockingcontrol
    {
        private long _employeeId;
        public event EventHandler SelectDataList;

        public UCPatientList(long employeeId)
        {
            InitializeComponent();
            _employeeId = employeeId;
            RefreshData();
        }

        public void RefreshData()
        {
            HIS.MZDoc_BLL.Public.PatCureStatus status = _rdbWaitPatient.Checked ? HIS.MZDoc_BLL.Public.PatCureStatus.候诊状态 : HIS.MZDoc_BLL.Public.PatCureStatus.结束状态;
            this._lvwPatientList.Items.Clear();
            List<HIS.Model.MZ_PatList> patlist = HIS.MZDoc_BLL.OP_Patient.SearchPatList(_rdbDocPatient.Checked, status, _dtpBegin.Value, _dtpEnd.Value);
            for (int i = 0; i < patlist.Count; i++)
            {
                ListViewItem lstViewItem = new ListViewItem();
                lstViewItem.SubItems.Clear();
                lstViewItem.Tag = patlist[i];
                lstViewItem.SubItems[0].Text = patlist[i].VisitNo;
                lstViewItem.SubItems.Add(patlist[i].PatName);
                lstViewItem.SubItems.Add(patlist[i].PatSex);
                lstViewItem.SubItems.Add(patlist[i].Age.ToString());
                lstViewItem.SubItems.Add(patlist[i].REG_DOC_NAME);
                lstViewItem.SubItems.Add(patlist[i].REG_DEPT_NAME);
                lstViewItem.SubItems.Add(patlist[i].CureDate.ToString());
                this._lvwPatientList.Items.Add(lstViewItem);
            }
            _btRefreshPatient.Text = "刷新病人(共" + patlist.Count + "人)";
        }

        #region 事件
        private void _btRefreshPatient_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void _lvwPatientList_DoubleClick(object sender, EventArgs e)
        {
            if (SelectDataList != null)
            {
                SelectDataList(_lvwPatientList.SelectedItems[0].Tag, e);
            }
        }
        #endregion

    }
}
