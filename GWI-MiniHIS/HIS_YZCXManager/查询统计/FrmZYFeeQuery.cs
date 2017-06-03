using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.YZCX_BLL;

namespace HIS_YZCXManager
{
    public partial class FrmZYFeeQuery : GWI.HIS.Windows.Controls.BaseMainForm, IFrmZYFeeQuery
    {
        private FrmZYFeeQueryControl _control;
        private string _currentPresDept;
        private string _currentPresDoc;
        public FrmZYFeeQuery(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            this.Text = chineseName;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btRpt_Click(object sender, EventArgs e)
        {
            try
            {
                _control.LoadZYFeeDept(dtpBdate.Value, dtpEdate.Value);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public void RefreshDeptFee(DataTable refreshDt)
        {
            if (refreshDt != null)
            {
                this.dgvData.DataSource = refreshDt;
                dgvData.Columns["presdeptcode"].Visible = false;
            }
        }

        public void RefreshDocFee(DataTable refreshDt)
        {
            if (refreshDt != null)
            {
                this.dgrdPresDocFee.DataSource = refreshDt;
                dgrdPresDocFee.Columns["presdoccode"].Visible = false;
            }
        }

        public void RefreshPatFee(DataTable refreshDt)
        {
            if (refreshDt != null)
            {
                this.dgrdPatFee.AutoGenerateColumns = false;
                this.dgrdPatFee.DataSource = refreshDt;
            }
        }

        private void FrmZYFeeQuery_Load(object sender, EventArgs e)
        {
            _control = new FrmZYFeeQueryControl(this);
            foreach (object obj in Enum.GetValues(typeof(Item_Type)))
                cobQueryType.Items.Add(obj.ToString());
            cobQueryType.Text = Item_Type.发票项目.ToString();
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                if (dgvData.CurrentCell != null)
                {
                    int rowIndex = dgvData.CurrentCell.RowIndex;
                    if (rowIndex > -1)
                    {
                        _currentPresDept = dgvData["presdeptcode", rowIndex].Value.ToString();
                        _control.LoadZYFeeDoc(dtpBdate.Value, dtpEdate.Value, _currentPresDept);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                this.Cursor = DefaultCursor;
            }
        }

        private void btnClosePatCard_Click(object sender, EventArgs e)
        {
            pnlPatFee.Visible = false;
        }

        private void dgrdPresDocFee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgrdPresDocFee.CurrentCell != null)
                {
                    int rowIndex = dgrdPresDocFee.CurrentCell.RowIndex;
                    if (rowIndex > -1)
                    {
                        _currentPresDoc = dgrdPresDocFee["presdoccode", rowIndex].Value.ToString();
                        _control.LoadZYFeePat(dtpBdate.Value, dtpEdate.Value, _currentPresDoc, _currentPresDept);
                    }
                }
                pnlPatFee.Visible = true;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }


        private void lblPicDept_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvData.DataSource != null)
                {
                    DataTable pictureDt = ((DataTable)(this.dgvData.DataSource)).Copy();
                    pictureDt.Rows.RemoveAt(pictureDt.Rows.Count - 1);
                    TableColumn[] columns = new TableColumn[1];
                    columns[0].ColumnName = "科室金额";
                    columns[0].ColumnField = "总收入";
                    FrmShowGraphic showGraphic = new FrmShowGraphic(pictureDt, "科室名称", columns, DataTableStruct.Rows,
                        "住院收入图示");
                    showGraphic.ShowDialog();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void lblPicDoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgrdPresDocFee.DataSource != null)
                {
                    DataTable pictureDt = ((DataTable)(this.dgrdPresDocFee.DataSource)).Copy();
                    pictureDt.Rows.RemoveAt(pictureDt.Rows.Count - 1);
                    TableColumn[] columns = new TableColumn[1];
                    columns[0].ColumnName = "医生金额";
                    columns[0].ColumnField = "总收入";
                    FrmShowGraphic showGraphic = new FrmShowGraphic(pictureDt, "医生名称", columns, DataTableStruct.Rows,
                        "住院收入图示");
                    showGraphic.ShowDialog();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
