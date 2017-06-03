using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.SYSTEM.BussinessLogicLayer.Classes;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.ZYNurse_BLL;

namespace HIS_ZYNurseManager
{
    public partial class FrmFeeModel : GWI.HIS.Windows.Controls.BaseMainForm
    {
        User _currentUser;
        Deptment _currentDept;
        int level = 0;
        HIS.ZYNurse_BLL.FeeModelProcess _currentModel;
        DataTable dtItem;
        DataTable dtAllItems;
        public FrmFeeModel(long currentUserId, long currreentDeptId)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currreentDeptId);
        }
        //模板头操作
        #region 模板头操作
        private void tvlevel_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.tvtype.Nodes.Clear();
            this.dgvFeeModel.DataSource = null;
            if (this.tvlevel.SelectedNode.Index == 0)
            {
                level = 0;
            }
            else if (this.tvlevel.SelectedNode.Index == 1)
            {
                level = 1;
            }
            else
            {
                level = 2;
            }            
            InitNode();
            
        }
        private void InitNode()
        {
            tvtype.Nodes.Clear();
            dgvFeeModel.DataSource = null;
            TreeNode node = PublicFeeModel.LoadModeTree(level, Convert.ToInt32(_currentDept.DeptID), Convert.ToInt32(_currentUser.EmployeeID));
            tvtype.Nodes.Add(node);
            tvtype.SelectedNode = node;
            node.Expand();
            tvlevel.ExpandAll();
        }

        private void tsAddType_Click(object sender, EventArgs e)
        {
            if (tvtype.SelectedNode != null)
            {
               HIS.ZYNurse_BLL.FeeModelProcess model=  (HIS.ZYNurse_BLL.FeeModelProcess)tvtype.SelectedNode.Tag;
               if (model.MODEL_TYPE == 1)
               {
                   MessageBox.Show("模板下边不能添加类型");
                   return;
               }
                FrmAddModel frnAdd = new FrmAddModel();
                frnAdd.level = level;
                frnAdd.lbtext = "请输入类型的名称:";
                frnAdd.type = 0;
                frnAdd.ShowDialog();
                if (frnAdd.modelName != "")
                {
                    HIS.ZYNurse_BLL.FeeModelProcess newtype = new HIS.ZYNurse_BLL.FeeModelProcess();
                    newtype.MODEL_TYPE = 0;
                    newtype.MODEL_NAME = frnAdd.modelName;
                    newtype.MODEL_LEVEL = level;
                    newtype.P_ID = model.MODEL_ID;
                    newtype.CREATE_DATE = XcDate.ServerDateTime;
                    newtype.CREATE_DEPT = Convert.ToInt32(_currentDept.DeptID);
                    newtype.CREATE_NURSE = Convert.ToInt32(_currentUser.EmployeeID);
                    newtype.Add();
                    InitNode();
                }

            }

        }

        private void tsAddModel_Click(object sender, EventArgs e)
        {
            if (tvtype.SelectedNode != null)
            {
                HIS.ZYNurse_BLL.FeeModelProcess model = (HIS.ZYNurse_BLL.FeeModelProcess)tvtype.SelectedNode.Tag;
                if (model.MODEL_TYPE == 1)
                {
                    MessageBox.Show("模板下边不能添加模板");
                    return;
                }
                FrmAddModel frnAdd = new FrmAddModel();
                frnAdd.level = level;
                frnAdd.lbtext = "请输入模板的名称:";
                frnAdd.type = 1;
                frnAdd.ShowDialog();
                if (frnAdd.modelName != "")
                {
                    HIS.ZYNurse_BLL.FeeModelProcess newtype = new HIS.ZYNurse_BLL.FeeModelProcess();
                    newtype.MODEL_TYPE = 1;
                    newtype.MODEL_NAME = frnAdd.modelName;
                    newtype.MODEL_LEVEL = level;
                    newtype.P_ID = model.MODEL_ID;
                    newtype.CREATE_DATE = XcDate.ServerDateTime;
                    newtype.CREATE_DEPT = Convert.ToInt32(_currentDept.DeptID);
                    newtype.CREATE_NURSE = Convert.ToInt32(_currentUser.EmployeeID);
                    newtype.Add();
                    InitNode();
                }
            }
        }

        private void tsUpdate_Click(object sender, EventArgs e)
        {
            if (tvtype.SelectedNode != null)
            {
                HIS.ZYNurse_BLL.FeeModelProcess model = (HIS.ZYNurse_BLL.FeeModelProcess)tvtype.SelectedNode.Tag;              
                FrmAddModel frnAdd = new FrmAddModel();
                frnAdd.level = level;
                frnAdd.lbtext = "请输入修改后的名称:";            
                frnAdd.ShowDialog();
                if (frnAdd.modelName != "")
                {
                    model.MODEL_NAME = frnAdd.modelName;
                    model.Update();
                    InitNode();
                }
            }
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            if (_currentModel != null)
            {
                if (_currentModel.IsExsistChilds(_currentModel.MODEL_ID))
                {
                    MessageBox.Show("请先删除该结点的子结点");
                    return;
                }
                if (_currentModel.IsExsistFeeList(_currentModel.MODEL_ID))
                {
                    MessageBox.Show("该模板还有模板明细，请先删除明细再删除模板");
                    return;
                }
                _currentModel.Delete();
                InitNode();
            }          
        }

        private void FrmFeeModel_Load(object sender, EventArgs e)
        {
            _currentModel = new HIS.ZYNurse_BLL.FeeModelProcess();
            OP_Account op_account = new OP_Account();
            dtItem = op_account.getItems();
            dtItem.TableName = "Itemslist";
            dgvFeeModel.SetSelectionCardDataSource(dtItem, item_name.Index);

            dtAllItems = dtItem.Clone();
            for (int i = 0; i < dtItem.Rows.Count; i++)
            {
                dtAllItems.Rows.Add(dtItem.Rows[i].ItemArray);
            }

            Op_BaseData basedata = new Op_BaseData();

            DataTable yf = basedata.GetYfName();
            if (yf == null || yf.Rows.Count == 1)
            {
                this.cbYf.Text = "全部药房";
                this.cbYf.Visible = false;
                this.lbyf.Visible = false;
            }
            else
            {
                this.cbYf.Visible = true;
                this.lbyf.Visible = true;
                this.cbYf.DisplayMember = "Name";
                this.cbYf.ValueMember = "Value";
                cbYf.DataSource = basedata.Get_dept_yfName(Convert.ToInt32(_currentDept.DeptID));
                this.cbYf.SelectedIndex = 0;
            }
        }

       

        private void tvtype_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point ClickPoint = new Point(e.X, e.Y);
                TreeNode CurrentNode = tvtype.GetNodeAt(ClickPoint);
                if (CurrentNode != null)//判断你点的是不是一个节点...
                {
                    this.tvtype.SelectedNode = CurrentNode;
                }
            }
        }
        #endregion

        private void tvtype_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvtype.SelectedNode != null)
            {
                dgvFeeModel.DataSource = null;
                _currentModel = (HIS.ZYNurse_BLL.FeeModelProcess)tvtype.SelectedNode.Tag;
                txtModelName.Text = _currentModel.MODEL_NAME;
                BindFeeModel();
            }            
        }
        //选中选项卡赋值
        private void dgvFeeModel_SelectCardRowSelected(object SelectedValue, ref bool stop, ref int customNextColumnIndex)
        {
            int currentRowIndex = dgvFeeModel.CurrentCell.RowIndex;
            if (dgvFeeModel.CurrentCell.ColumnIndex == dgvFeeModel.Columns["item_name"].Index)
            {
                //取得选择卡的数据              
                int item_id = Convert.ToInt32(((DataRow)SelectedValue)["item_id"].ToString());
                string name = ((DataRow)SelectedValue)["order_type"].ToString();
                string item_name = ((DataRow)SelectedValue)["order_name"].ToString();
                string price = ((DataRow)SelectedValue)["price"].ToString();
                string item_unit = ((DataRow)SelectedValue)["order_unit"].ToString();
                string default_usage = ((DataRow)SelectedValue)["DEFAULT_USAGE"].ToString();
                string tc_flag = ((DataRow)SelectedValue)["TC_FLAG"].ToString();
                int execdept = Convert.ToInt32(XcConvert.IsNull(((DataRow)SelectedValue)["execdept_code"], _currentDept.DeptID.ToString()));
                int item_type = Convert.ToInt32(((DataRow)SelectedValue)["item_type"].ToString());
                string item_code = ((DataRow)SelectedValue)["statitem_code"].ToString();
                dgvFeeModel.EndEdit();
                dgvFeeModel["item_id", currentRowIndex].Value = item_id;
                dgvFeeModel["item_type", currentRowIndex].Value = item_type;
                dgvFeeModel["item_name", currentRowIndex].Value = item_name;
                dgvFeeModel["amount", currentRowIndex].Value = 1;
                dgvFeeModel["unit", currentRowIndex].Value = item_unit;
                dgvFeeModel["order_usage", currentRowIndex].Value = default_usage;
               // dgvFeeModel["tc_id", currentRowIndex].Value = tc_flag;
                dgvFeeModel["execdept_code", currentRowIndex].Value = execdept;
                dgvFeeModel["item_code", currentRowIndex].Value = item_code;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (_currentModel == null)
            {
                return;
            }
            if (_currentModel.MODEL_TYPE == 0)
            {
                MessageBox.Show(""+_currentModel.MODEL_NAME+"是类型，不能直接添加明细");
                return;
            }
            dgvFeeModel.Focus();
            DataTable dt = (DataTable)dgvFeeModel.DataSource;
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr.ItemArray);
            dgvFeeModel.DataSource = dt;
            dgvFeeModel.CurrentCell = this.dgvFeeModel["item_name", dgvFeeModel.Rows.Count - 1];
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvFeeModel.Rows.Count == 0)
            {
                return;
            }
            List<HIS.Model.ZY_NURSE_FEEMODELLIST> records = new List<HIS.Model.ZY_NURSE_FEEMODELLIST>();
            DataTable dt = (DataTable)dgvFeeModel.DataSource;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["item_name"] ==null ||  dt.Rows[i]["item_name"].ToString().Trim()=="")
                {
                    continue;
                }
                HIS.Model.ZY_NURSE_FEEMODELLIST recordson = new HIS.Model.ZY_NURSE_FEEMODELLIST();
                recordson = (HIS.Model.ZY_NURSE_FEEMODELLIST)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dt, i, recordson);
                recordson.MODEL_ID = _currentModel.MODEL_ID;
                records.Add(recordson);
            }
            FeeModelList list = new FeeModelList();
            if (list.Add(records))
            {
                MessageBox.Show("保存成功");
                BindFeeModel();
            }
            else
            {
                MessageBox.Show("保存失败");
            }
        }

        private void dgvFeeModel_DataGridViewCellPressEnterKey(object sender, int colIndex, int rowIndex, ref bool jumpStop)
        {
            if (dgvFeeModel.CurrentCell == null || dgvFeeModel.Rows.Count == 0)
            {
                return;
            }
            int currentrow = dgvFeeModel.CurrentRow.Index;
            if (currentrow == dgvFeeModel.Rows.Count - 1 && dgvFeeModel.CurrentCell.ColumnIndex == this.amount.Index)
            {
                if (dgvFeeModel["item_name", currentrow].Value.ToString().Trim() != "")
                {
                    DataTable dt = (DataTable)dgvFeeModel.DataSource;
                    DataRow dr = dt.NewRow();
                    dt.Rows.Add(dr.ItemArray);
                    dgvFeeModel.DataSource = dt;
                }

            }
        }

        private void tbnFresh_Click(object sender, EventArgs e)
        {

            BindFeeModel();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvFeeModel.CurrentCell == null || dgvFeeModel.Rows.Count == 0)
            {
                return;
            }
            int currentrow = dgvFeeModel.CurrentRow.Index;
            DataTable dt = (DataTable)dgvFeeModel.DataSource;
            HIS.Model.ZY_NURSE_FEEMODELLIST model = new HIS.Model.ZY_NURSE_FEEMODELLIST();
            model = (HIS.Model.ZY_NURSE_FEEMODELLIST)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dt, currentrow, model);
            FeeModelList list = new FeeModelList();
            list.Delete(model);
            MessageBox.Show("删除成功");
            BindFeeModel();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BindFeeModel()
        {
            if (_currentModel.MODEL_TYPE == 1)
            {
                dgvFeeModel.DataSource = null;
                dgvFeeModel.AutoGenerateColumns = false;
                DataTable dt = PublicFeeModel.GetFeeModelList(_currentModel.MODEL_ID);
                dgvFeeModel.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvFeeModel.Columns.Count; j++)
                    {
                        dgvFeeModel.Rows[i].Cells[j].Style.ForeColor = System.Drawing.Color.RoyalBlue;

                    }                 
                }
               
            }
        }

        private void dgvFeeModel_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void FrmFeeModel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnNew_Click(null, null);
            }
            else if (e.KeyCode == Keys.F3)
            {
                btnSave_Click(null, null);
            }
            else if (e.KeyCode == Keys.F4)
            {
                btnDel_Click(null, null);
            }
            else if (e.KeyCode == Keys.F5)
            {
                tbnFresh_Click(null, null);
            }
            else if (e.KeyCode == Keys.F6)
            {
                this.Close();
            }
        }

        private void cbYf_SelectedIndexChanged(object sender, EventArgs e)
        {
           string yfIds= (this.cbYf.SelectedValue == null ? -1 : this.cbYf.SelectedValue).ToString().Trim();
            dtItem.Clear();
            //新增判断药房科室
            if (yfIds != "-1")
            {
                DataRow[] dr = dtAllItems.Select("item_type >3 or execdept_code in ( " + yfIds + ")");              
                for (int i = 0; i < dr.Length; i++)
                {
                    dtItem.Rows.Add(dr[i].ItemArray);
                }               
            }
            else
            {
                for (int i = 0; i < dtAllItems.Rows.Count; i++)
                {
                    dtItem.Rows.Add(dtAllItems.Rows[i].ItemArray);
                }
            }
        }
    }
}
