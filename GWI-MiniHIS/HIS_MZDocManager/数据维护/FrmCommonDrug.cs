using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWMHIS.BussinessLogicLayer.Classes;

namespace HIS_MZDocManager
{
    public partial class FrmCommonDrug : GWI.HIS.Windows.Controls.BaseMainForm,Action.IDataInstall
    {
        private User _currentUser;
        private HIS.MZDoc_BLL.Public.CurrentStatus _currentStatus = HIS.MZDoc_BLL.Public.CurrentStatus.查询状态;
        Action.FrmDataInstallController Controller;
        private HIS.MZDoc_BLL.CommonDrug _commonDrug;

        private int _rowIndex = -1;
        private int _firstInputColumnIndex = 1;

        public FrmCommonDrug(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            this.Text = chineseName;
            this.FormTitle = chineseName;

            _commonDrug = new HIS.MZDoc_BLL.CommonDrug();
            dGVEMain.SetSelectionCardDataSource(_commonDrug.LoadShowCardData(), _firstInputColumnIndex);
            Controller = new HIS_MZDocManager.Action.FrmDataInstallController(this);
            Controller.LoadData();            
        }

        #region IDataInstall 成员
        public User currentUser
        {
            get 
            { 
                return _currentUser; 
            }
        }

        public DataTable BindMainData
        {
            get
            {
                return (DataTable)this.dGVEMain.DataSource;
            }
            set
            {
                this.dGVEMain.AutoGenerateColumns = false;
                this.dGVEMain.DataSource = value;
                _rowIndex = -1;
            }
        }

        public HIS.MZDoc_BLL.IBaseCommon CommonSub
        {
            get
            {
                if (this.dGVEMain.DataSource != null && _rowIndex >= 0)
                {
                    _commonDrug = (HIS.MZDoc_BLL.CommonDrug)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject((DataTable)this.dGVEMain.DataSource, _rowIndex, _commonDrug);
                    _commonDrug.Record_Doc = (int)_currentUser.EmployeeID;
                }
                return _commonDrug;
            }
            set
            {
                _commonDrug = (HIS.MZDoc_BLL.CommonDrug)value;
                _commonDrug.Record_Doc = (int)_currentUser.EmployeeID;
            }
        }

        public int RowIndex
        {
            get
            {
                return _rowIndex;
            }
            set
            {
                _rowIndex = value;
            }
        }

        public bool DataGridViewReadOnly
        {
            set
            {
                dGVEMain.Columns[_firstInputColumnIndex].ReadOnly = value;
                dGVEMain.SelectionMode = value ? DataGridViewSelectionMode.FullRowSelect : DataGridViewSelectionMode.CellSelect;
            }
        }

        public HIS.MZDoc_BLL.Public.CurrentStatus CurrentStatus
        {
            get
            {
                return _currentStatus;
            }
            set
            {
                _currentStatus = value;
                DataGridViewReadOnly = _currentStatus == HIS.MZDoc_BLL.Public.CurrentStatus.查询状态;
                this.lbStatus.Text = "        当前状态：" + _currentStatus.ToString();
            }
        }
        #endregion

        #region 工具栏事件
        //保存
        private void tSBtnSave_Click(object sender, EventArgs e)
        {
            if (Controller.Save())
            {
                MessageBox.Show("保存成功！","提示");
                Controller.LoadData();
            }
        }
        //新增
        private void tSBtnNew_Click(object sender, EventArgs e)
        {
            if (CurrentStatus != HIS.MZDoc_BLL.Public.CurrentStatus.查询状态)
            {
                if (MessageBox.Show("有未保存的数据，是否继续？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Controller.LoadData();
                }
                else
                {
                    return;
                }
            }
            CurrentStatus = HIS.MZDoc_BLL.Public.CurrentStatus.新建状态;
            dGVEMain.Focus();
            Controller.AddRow<HIS.MZDoc_BLL.CommonDrug>();
            dGVEMain.CurrentCell = this.dGVEMain[_firstInputColumnIndex, _rowIndex];
        }
        //修改
        private void tSBtnUpdate_Click(object sender, EventArgs e)
        {
            if (CurrentStatus != HIS.MZDoc_BLL.Public.CurrentStatus.查询状态)
            {
                if (MessageBox.Show("有未保存的数据，是否继续？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Controller.LoadData();
                }
                else
                {
                    return;
                }
            }
            if (dGVEMain.CurrentCell != null)
            {
                _rowIndex = dGVEMain.CurrentRow.Index;
                CurrentStatus = HIS.MZDoc_BLL.Public.CurrentStatus.修改状态;
            }
        }
        //取消
        private void tSBtnCancel_Click(object sender, EventArgs e)
        {
            CurrentStatus = HIS.MZDoc_BLL.Public.CurrentStatus.查询状态;
            Controller.LoadData();
        }
        //删除
        private void tSBtnDel_Click(object sender, EventArgs e)
        {
            if (CurrentStatus != HIS.MZDoc_BLL.Public.CurrentStatus.查询状态)
            {
                if (MessageBox.Show("有未保存的数据，是否继续？", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }
            _rowIndex = dGVEMain.CurrentRow.Index;
            Controller.Delete();
            Controller.LoadData();
        }
        #endregion

        #region 网格事件
        private void dGVEMain_SelectCardRowSelected(object SelectedValue, ref bool stop, ref int customNextColumnIndex)
        {
            DataRow row = (DataRow)SelectedValue;
            int rowid = this.dGVEMain.CurrentCell.RowIndex;
            Controller.SelectCardBindData(rowid, row);

            this.tSMain.Focus();
            this.tSBtnSave.Select();
        }

        private void dGVEMain_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dGVEMain.CurrentCell == null) return;
            if (dGVEMain.CurrentCell.ColumnIndex == _firstInputColumnIndex && dGVEMain.CurrentCell.RowIndex == _rowIndex)
            {
                dGVEMain.Columns[_firstInputColumnIndex].ReadOnly = false;
            }
            else
            {
                dGVEMain.Columns[_firstInputColumnIndex].ReadOnly = true;
            }
        }
        #endregion        

        private void FrmCommonDrug_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F2:	//保存
                    tSBtnSave_Click(null, null);
                    break;
                case Keys.F3:	//新增
                    tSBtnNew_Click(null, null);
                    break;
                case Keys.F5:	//取消
                    tSBtnCancel_Click(null, null);
                    break;
                case Keys.F6:	//删除
                    tSBtnDel_Click(null, null);
                    break;
                default:
                    break;
            }
        }
    }
}
