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
    public partial class UCOfenDiagnosis : UserControl, IDockingcontrol
    {
        private long _employeeId;
        public event EventHandler SelectDataList;
        public UCOfenDiagnosis(long employeeId)
        {
            InitializeComponent();
            _employeeId = employeeId;
            RefreshData();
        }
        public void RefreshData()
        {
            this._lvwOfenDiagnosis.Items.Clear();
            DataTable dataSource = new HIS.MZDoc_BLL.CommonDiagnosis().LoadCommonData(_employeeId);
            for (int index = 0; index < dataSource.Rows.Count; index++)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = dataSource.Rows[index]["Diagnosis_Code"].ToString();
                listViewItem.SubItems.Add(dataSource.Rows[index]["Diagnosis_Name"].ToString());
                listViewItem.SubItems.Add(dataSource.Rows[index]["Frequency"].ToString());
                listViewItem.SubItems.Add(dataSource.Rows[index]["Py_code"].ToString());
                listViewItem.SubItems.Add(dataSource.Rows[index]["Wb_code"].ToString());
                this._lvwOfenDiagnosis.Items.Add(listViewItem);
            }
        }

        #region 事件
        private void btRefreshOfenDiagnosis_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void _lvwOfenDiagnosis_DoubleClick(object sender, EventArgs e)
        {
            if (SelectDataList != null)
            {
                SelectDataList(_lvwOfenDiagnosis.SelectedItems[0].SubItems[1].Text, e);
            }
        } 
        #endregion
    }
}
