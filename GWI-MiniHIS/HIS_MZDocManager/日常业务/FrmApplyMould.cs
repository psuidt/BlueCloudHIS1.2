using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_MZDocManager
{
    public partial class FrmApplyMould : Form
    {
        private bool _isSure = false;
        DataSet _dataSet = null;
        HIS.MZDoc_BLL.MedicalApplyMould _currentMould = new HIS.MZDoc_BLL.MedicalApplyMould();

        public FrmApplyMould(int medicalClass, string elementName, long empId, long deptId)
        {
            InitializeComponent();
            _currentMould.Element_Name = elementName;
            _currentMould.Medical_Class = medicalClass;
            _currentMould.Create_Emp = (int)empId;
            _currentMould.Create_Dept = (int)deptId;

            this._dataSet = this._currentMould.GetMouldData();
            _rdbLevel_CheckedChanged(_rdbLevelH, null);
        }

        public bool IsSure
        {
            get { return _isSure; }
            set { _isSure = value; }
        }

        public string MouldContent
        {
            get { return txtMouldText.Text.Trim(); }
            set { txtMouldText.Text = value; }
        }

        private void _rdbLevel_CheckedChanged(object sender, EventArgs e)
        {
            GVEApplyMould.AutoGenerateColumns = false;
            if (sender.Equals(_rdbLevelH) && _rdbLevelH.Checked)
            {
                GVEApplyMould.DataSource = this._dataSet.Tables["LevelHMould"];
            }
            if (sender.Equals(_rdbLevelD) && _rdbLevelD.Checked)
            {
                GVEApplyMould.DataSource = this._dataSet.Tables["LevelDMould"];
            }
            if (sender.Equals(_rdbLevelP) && _rdbLevelP.Checked)
            {
                GVEApplyMould.DataSource = this._dataSet.Tables["LevelPMould"];
            }
        }

        private void GVEApplyMould_CurrentCellChanged(object sender, EventArgs e)
        {
            
        }

        private void btSure_Click(object sender, EventArgs e)
        {
            _isSure = true;
            this.Close();
        }

        private void btQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            this.contextMenuStrip.Show(this.Location.X + this.btSave.Location.X + this.btSave.Width + 8, this.Location.Y + this.btSave.Location.Y + this.btSave.Height + 24);
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HIS.MZDoc_BLL.MedicalApplyMould mould = new HIS.MZDoc_BLL.MedicalApplyMould();
            mould.Level = Convert.ToInt32(((System.Windows.Forms.ToolStripMenuItem)sender).Tag);
            mould.Content = this.txtMouldText.Text.Trim();
            mould.Medical_Class = _currentMould.Medical_Class;
            mould.Element_Name = _currentMould.Element_Name;
            mould.Create_Emp = _currentMould.Create_Emp;
            mould.Create_Dept = _currentMould.Create_Dept;
            mould.Save();
            this._dataSet = this._currentMould.GetMouldData();
            MessageBox.Show("保存成功！","提示");
        }

        private void GVEApplyMould_DoubleClick(object sender, EventArgs e)
        {
            if (GVEApplyMould.DataSource != null && GVEApplyMould.CurrentCell.RowIndex > -1)
            {
                if (txtMouldText.Text.Trim() == "")
                {
                    txtMouldText.Text = GVEApplyMould[0, GVEApplyMould.CurrentCell.RowIndex].Value.ToString();
                }
                else
                {
                    txtMouldText.Text = txtMouldText.Text.Trim() + "," + GVEApplyMould[0, GVEApplyMould.CurrentCell.RowIndex].Value.ToString();
                }
            }
        }
    }
}
