using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.EMR_BLL;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS_EMRManager
{
    public partial class FrmEMRInfoUpdate : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private User _currentUser;  //当前用户
        private Deptment _currentDept;  //当前科室
        private List<HIS.EMR_BLL.EmrRecord> records;

        public FrmEMRInfoUpdate(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            this.Text = chineseName;
            this.FormTitle = chineseName;

            ViewPatData();
        }

        private void ViewPatData()
        {
            this.dGVDataList.DataSource = null;
            this.dGVPatList.AutoGenerateColumns = false;
            this.dGVPatList.DataSource = HIS.EMR_BLL.OP_EmrDataUpdate.GetEmrPatList(this.rdBHadUp.Checked);
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            ViewPatData();
        }

        private void dGVDataList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    if (this.dGVDataList["Checked", e.RowIndex].Value == null)
            //    {
            //        this.dGVDataList["Checked", e.RowIndex].Value = false;
            //    }
            //    this.dGVDataList["Checked", e.RowIndex].Value = !(bool)this.dGVDataList["Checked", e.RowIndex].Value;
            //}
        }

        private void dGVPatList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    _rowIndex = e.RowIndex;
            //    if (this.dGVPatList["Selected", e.RowIndex].Value == null)
            //    {
            //        this.dGVPatList["Selected", e.RowIndex].Value = false;
            //    }
            //    this.dGVPatList["Selected", e.RowIndex].Value = !(bool)this.dGVPatList["Selected", e.RowIndex].Value;
            //}
            //string patIdList = "";
            //for (int index = 0; index < this.dGVPatList.Rows.Count; index++)
            //{
            //    if (Convert.ToBoolean(this.dGVPatList["Selected", index].Value))
            //    {
            //        patIdList += this.dGVPatList["PatId", index].Value.ToString() + ",";
            //    }
            //}
            //if (patIdList != "")
            //{
            //    patIdList = patIdList.Substring(0, patIdList.Length - 1);
            //    this.dGVDataList.AutoGenerateColumns = false;
            //    this.dGVDataList.DataSource = HIS.EMR_BLL.OP_EmrDataUpdate.GetEmrRecord(patIdList, this.rdBHadUp.Checked);
            //}
            if (e.RowIndex < 0)
            {
                return;
            }
            string patIdList = this.dGVPatList["PatId", e.RowIndex].Value.ToString(); 
            this.dGVDataList.AutoGenerateColumns = false;
            this.dGVDataList.DataSource = HIS.EMR_BLL.OP_EmrDataUpdate.GetEmrRecord(patIdList, this.rdBHadUp.Checked);
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable table = (DataTable)this.dGVDataList.DataSource;
                if (table == null)
                {
                    return;
                }
                records = new List<EmrRecord>();
                for (int index = 0; index < table.Rows.Count; index++)
                {
                    HIS.EMR_BLL.EmrRecord record = new EmrRecord();
                    record = (HIS.EMR_BLL.EmrRecord)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(table, index, record);
                    records.Add(record);
                }
                string dahid = "";
                if (this.dGVPatList["MediCard", this.dGVPatList.CurrentCell.RowIndex].Value.ToString().Trim() != "")
                {
                    dahid = HIS.EMR_BLL.OP_EmrDataUpdate.GetPatFileId(
                        this.dGVPatList["MediCard", this.dGVPatList.CurrentCell.RowIndex].Value.ToString().Trim(),
                        this.dGVPatList["PatName", this.dGVPatList.CurrentCell.RowIndex].Value.ToString().Trim());
                }
                else
                {
                    FrmPatList form = new FrmPatList(HIS.EMR_BLL.OP_EmrDataUpdate.GetPatFileId(this.dGVPatList["PatName", this.dGVPatList.CurrentCell.RowIndex].Value.ToString().Trim()));
                    form.ShowDialog();
                    if (form.IsSure)
                    {
                        dahid = form.SelectedFileId;
                    }
                }
                if (dahid.Trim() != "")
                {
                    HIS.EMR_BLL.OP_EmrDataUpdate.UploaEmrRecord(dahid, records);
                    MessageBox.Show("上传成功！");
                    ViewPatData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void rdBNoUp_CheckedChanged(object sender, EventArgs e)
        {
            ViewPatData();
            this.btUpdate.Enabled = this.rdBNoUp.Checked;
        }
    }
}
