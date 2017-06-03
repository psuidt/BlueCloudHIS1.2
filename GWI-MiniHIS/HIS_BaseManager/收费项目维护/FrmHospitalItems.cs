using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS_BaseManager.UIController;
using HIS.Base_BLL;
using HIS_BaseManager.收费项目维护.UIController;
using HIS.Base_BLL.收费项目及医嘱维护;

namespace HIS_BaseManager
{
    public partial class FrmHospitalItems : BaseMainForm ,IFrmHospitalItems,IFrmOrderItem,IFrmItemExecDept,IFrmComplexItem,IFrmUsageItem
    {
        private User currentUser;

        private FrmHospitalItemsController serviceItemController;
        private FrmOrderItemController orderController;
        private FrmItemExecDeptController execDeptController;
        private FrmComplexController complexController;
        private FrmUsageItemController usageController;

        public FrmHospitalItems(string FormText,User CurrentUser)
        {
            InitializeComponent( );

            currentUser = CurrentUser;
            this.FormTitle = FormText;
            this.Text = FormText;

            System.Drawing.Font font9  = new Font( "宋体" , 9F );

            dgvComplex.AutoGenerateColumns = false;
            dgvHsItem.AutoGenerateColumns = false;

            this.Load += new EventHandler( FrmHospitalItems_Load );

            this.Font = font9;
            this.plBaseWorkArea.Font = font9;
            this.panel2.Font = font9;
            this.panel3.Font = font9;
            this.panel7.Font = font9;
            this.panel11.Font = font9;
            this.panel12.Font = font9;
            this.panel13.Font = font9;
            this.tabControl1.Font = font9;
            this.tabPage1.Font = font9;
            this.tabPage2.Font = font9;
            this.tabPage3.Font = font9;
            this.tabPage4.Font = font9;
        }

        void FrmHospitalItems_Load( object sender , EventArgs e )
        {
            #region 医院收费项目部分
            serviceItemController = new FrmHospitalItemsController(this);
            serviceItemController.Initalize();
            dgvItem.DataSource = serviceItemController.HospitalBaseServiceItem.DefaultView;
            #endregion

            #region 医嘱部分
            //初始化医嘱管理器
            orderController = new FrmOrderItemController(this);
            orderController.Initiazle();
            //医嘱管理界面
            cboOrderType.DisplayMember = "NAME";
            cboOrderType.ValueMember = "ID";
            cboOrderType.DataSource = orderController.OrderType;

            cboFindOrderType.DisplayMember = "NAME";
            cboFindOrderType.ValueMember = "ID";
            cboFindOrderType.DataSource = orderController.OrderType.Copy();

            cboMediClass.DisplayMember = "NAME";
            cboMediClass.ValueMember = "ID";
            cboMediClass.DataSource = orderController.MedicalClass;

            txtUsage.SetSelectionCardDataSource(orderController.DefaultUsage);
            txtServiceItem.SetSelectionCardDataSource(orderController.ServiceItems);

            dgvOrderItem.AutoGenerateColumns = false;
            dgvOrderItem.DataSource = orderController.OrderList.DefaultView;
            #endregion

            #region 执行科室部分
            //初始化执行科室维护界面管理器
            execDeptController = new FrmItemExecDeptController(this);
            execDeptController.Initiazle();
            dgvHsItem.DataSource = execDeptController.HospitalServiceItems.DefaultView;
            dgvDept.AutoGenerateColumns = false;
            dgvDept.DataSource = BaseDataReader.Base_Dept_Property;
            #endregion

            #region 组合项目部分
            complexController = new FrmComplexController(this);
            complexController.Initialize();
            //绑定大项目下拉框
            cboStatItem.DisplayMember = "ITEM_NAME";
            cboStatItem.ValueMember = "CODE";
            DataTable tbStatitem = HIS.Base_BLL.BaseDataReader.Base_Stat_Item.Select("CODE not in ('00','01','02','03')").CopyToDataTable();
            cboStatItem.DataSource = tbStatitem;
            //cboStatItem.DataSource = HIS.Base_BLL.BaseDataReader.Base_Stat_Item;
            //设置组合明细网格选择卡
            dgvDetail.SetSelectionCardDataSource(serviceItemController.HospitalBaseServiceItem, 0);
            dgvComplex.DataSource = complexController.ComplexItems.DefaultView;
            #endregion

            #region 用法部分
            usageController = new FrmUsageItemController( this );
            usageController.Initialize( );
            dgvAssServiceItem.SetSelectionCardDataSource( usageController.ServiceItems , COL_USAGE_ITEM_KEYCODE.Name );
            dgvUsageItem.DataSource = usageController.UsageDiction.DefaultView;
            #endregion


            #region 医嘱维护界面事件
            dgvOrderItem.CurrentCellChanged += new EventHandler(dgvOrderItem_CurrentCellChanged);
            dgvOrderItem.DataError += new DataGridViewDataErrorEventHandler(dgvOrderItem_DataError);
            txtServiceItem.TextChanged += new EventHandler(txtServiceItem_TextChanged);
            cboOrderType.SelectedValueChanged += new EventHandler(cboOrderType_SelectedValueChanged);
            cboOrderType.KeyPress +=new KeyPressEventHandler(Order_EditController_KeyPress);
            txtOrderName.KeyPress +=new KeyPressEventHandler(Order_EditController_KeyPress);
            txtOrderPY.KeyPress +=new KeyPressEventHandler(Order_EditController_KeyPress);
            txtOrderWB.KeyPress +=new KeyPressEventHandler(Order_EditController_KeyPress);
            txtOrderCode.KeyPress +=new KeyPressEventHandler(Order_EditController_KeyPress);
            txtOrderUnit.KeyPress +=new KeyPressEventHandler(Order_EditController_KeyPress);
            cboMediClass.KeyPress +=new KeyPressEventHandler(Order_EditController_KeyPress);
            txtUsage.KeyPress +=new KeyPressEventHandler(Order_EditController_KeyPress);
            txtServiceItem.KeyPress +=new KeyPressEventHandler(Order_EditController_KeyPress);
            txtMemo.KeyPress += new KeyPressEventHandler(Order_EditController_KeyPress);
            #endregion

            #region 执行科室维护界面事件
            dgvHsItem.CurrentCellChanged += new EventHandler(dgvHsItem_CurrentCellChanged);
            dgvDept.CellContentClick += new DataGridViewCellEventHandler(dgvDept_CellContentClick);
            dgvDept.Paint += new PaintEventHandler(dgvDept_Paint);
            #endregion

            #region 组合项目界面控件事件
            dgvComplex.CurrentCellChanged+=new EventHandler(dgvComplex_CurrentCellChanged);
            #endregion

            #region 用法部分的控件事件
            txtUsageName.KeyPress += new KeyPressEventHandler( OnTextBoxPressEnterKey );
            txtUsagePyCode.KeyPress += new KeyPressEventHandler( OnTextBoxPressEnterKey );
            txtUsageWbCode.KeyPress += new KeyPressEventHandler( OnTextBoxPressEnterKey );
            txtUsageUnit.KeyPress += new KeyPressEventHandler( OnTextBoxPressEnterKey );
            txtKeyword4.KeyPress += new KeyPressEventHandler( OnTextBoxPressEnterKey );
            #endregion

            foreach ( Control ctrl in this.Controls )
                ctrl.Font = new Font( "宋体" , 9F );
        }


        private void tabControl1_SelectedIndexChanged( object sender , EventArgs e )
        {
            dgvAssServiceItem.CloseSelectionCard( );
            dgvDetail.CloseSelectionCard( );

            if ( tabControl1.SelectedIndex == 0 )
            {
                btnSelectItem.Visible = true;
                btnRemoveServiceITem.Visible = true;
                toolStripButton1.Visible = true;
            }
            else
            {
                btnSelectItem.Visible = false;
                btnRemoveServiceITem.Visible = false;
                toolStripButton1.Visible = false;
            }

            //dgvItem.CurrentCell = null;
            //dgvComplex.CurrentCell = null;
            //dgvHsItem.CurrentCell = null;
        }

        #region 工具栏事件
        private void btnRefresh_Click( object sender , EventArgs e )
        {
            try
            {
                Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor( );
                switch (tabControl1.SelectedIndex)
                {
                    case 0:
                        serviceItemController.Initalize();
                        dgvItem.DataSource = serviceItemController.HospitalBaseServiceItem.DefaultView;
                        break;
                    case 1:
                        complexController.Initialize();
                        dgvComplex.DataSource = complexController.ComplexItems.DefaultView;
                        break;
                    case 2://执行科室
                        execDeptController.Initiazle();
                        dgvHsItem.DataSource = execDeptController.HospitalServiceItems.DefaultView;
                        break;
                    case 3:
                        orderController.Initiazle();
                        dgvOrderItem.DataSource = orderController.OrderList.DefaultView;
                        txtServiceItem.SetSelectionCardDataSource(orderController.ServiceItems);
                        break;
                    case 4:
                        usageController.Initialize( );
                        dgvUsageItem.DataSource = usageController.UsageDiction.DefaultView;
                        break;
                }
            }
            catch
            {
                MessageBox.Show( "加载数据发生错误！" );
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.Close( );
        }
        #endregion

        #region IFrmHospitalItems 成员
        /// <summary>
        /// 医院的基本医疗服务项目
        /// </summary>
        public DataTable ServiceItems
        {
            get
            {
                if ( dgvItem.DataSource != null )
                    return ( (DataView)dgvItem.DataSource ).Table;
                else
                    return null;
            }
            set
            {
                dgvItem.DataSource = serviceItemController.HospitalBaseServiceItem.DefaultView;
            }
        }

        public DataTable Stat_Items
        {
            get
            {
                return null;   
            }
            set
            {
                comboBox1.DisplayMember = "ITEM_NAME";
                comboBox1.ValueMember = "CODE";
                comboBox1.DataSource = value;
                comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
            }
        }

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filterString = null;
            if (comboBox1.SelectedValue != null)
                filterString = " statitem_code='" + comboBox1.SelectedValue.ToString() + "'";
            ((DataView)dgvItem.DataSource).RowFilter = filterString;
        }

        /// <summary>
        /// 获取从基本医疗服务项目中选择要添加到本院服务项目中的项目
        /// </summary>
        /// <returns></returns>
        public DataTable GetSelectBaseServiceItemsForm()
        {
            FrmSelectServiceItem fSelected = new FrmSelectServiceItem( serviceItemController.BaseSeriveItems );
            if ( fSelected.ShowDialog( ) == DialogResult.OK )
            {
                return fSelected.SelectedItems;
            }
            else
            {
                return null;
            }
        }
        #endregion
        #region 医院收费项目界面相关事件
        private void btnSelectItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (serviceItemController.AddSelectedServiceItems())
                {
                    serviceItemController.Initalize();
                    dgvItem.DataSource = serviceItemController.HospitalBaseServiceItem.DefaultView;
                    btnRefreshServiceItem_Click( null , null );
                }
            }
            catch (CustomException ce)
            {
                MessageBox.Show(ce.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("增加项目发生异常错误！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveServiceITem_Click(object sender, EventArgs e)
        {
            if (dgvItem.SelectedRows.Count == 0)
                return;
            if (dgvItem.CurrentCell == null)
                return;
            string name = dgvItem["ITEM_NAME" , dgvItem.CurrentCell.RowIndex].Value.ToString( ).Trim( );

            if ( MessageBox.Show( "确定要移除服务项目【" + name + "】吗？" , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.No )
                return;
            try
            {
                int item_id = Convert.ToInt32(dgvItem["ITEM_ID", dgvItem.CurrentCell.RowIndex].Value);
                serviceItemController.RemoveServiceItems(item_id);
                serviceItemController.Initalize();
                dgvItem.DataSource = serviceItemController.HospitalBaseServiceItem.DefaultView;
                btnRefreshServiceItem_Click( null , null );
            }
            catch (CustomException ce)
            {
                MessageBox.Show(ce.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("移除项目发生异常错误！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtKeyword_TextChanged( object sender , EventArgs e )
        {
            string filterString = "";
            if ( txtKeyword.Text.Trim( ) != "" )
            {
                string keyWord = CommonFun.FormatKeyword( txtKeyword.Text );
                filterString = "ITEM_NAME LIKE '%" + keyWord + "%' OR PY_CODE LIKE '%" + keyWord + "%' OR WB_CODE LIKE '%" + keyWord + "%'";
            }
            ( (DataView)dgvItem.DataSource ).RowFilter = filterString;
        }
        #endregion

        #region IFrmOrderItem 成员

        public int SelectedOrderId
        {
            get
            {
                int orderId = 0;
                if (dgvOrderItem.Rows.Count == 0 || dgvOrderItem.CurrentCell == null)
                    orderId = -1;
                else
                    orderId = Convert.ToInt32( dgvOrderItem[OrderId.Name,dgvOrderItem.CurrentCell.RowIndex].Value );
                //MessageBox.Show(orderId.ToString());
                return orderId;
            }
        }

        public string ORDER_NAME
        {
            get
            {
                return txtOrderName.Text.Trim();
            }
            set
            {
                txtOrderName.Text = value;
            }
        }

        public string ORDER_UNIT
        {
            get
            {
                return txtOrderUnit.Text.Trim();
            }
            set
            {
                txtOrderUnit.Text = value.Trim();
            }
        }

        public int ORDER_TYPE
        {
            get
            {
                if (cboOrderType.SelectedIndex == -1)
                    return 0;
                else
                    return Convert.ToInt32(cboOrderType.SelectedValue);

            }
            set
            {
                cboOrderType.SelectedValue = value;
            }
        }

        public int MEDICAL_CLASS
        {
            get
            {
                if (cboMediClass.SelectedValue == null||cboMediClass.Enabled ==false)
                    return 0;
                else
                    return Convert.ToInt32(cboMediClass.SelectedValue);
            }
            set
            {
                cboMediClass.SelectedValue = value;
            }
        }

        public string DEFAULT_USAGE
        {
            get
            {
                return txtUsage.Text.Trim();
            }
            set
            {
                txtUsage.Text = value;
            }
        }

        string IFrmOrderItem.PY_CODE
        {
            get
            {
                return txtOrderPY.Text.Trim();
            }
            set
            {
                txtOrderPY.Text = value.Trim();
            }
        }

        string IFrmOrderItem.WB_CODE
        {
            get
            {
                return txtOrderWB.Text.Trim();
            }
            set
            {
                txtOrderWB.Text = value.Trim();
            }
        }

        public string D_CODE
        {
            get
            {
                return txtOrderCode.Text.Trim();
            }
            set
            {
                txtOrderCode.Text = value.Trim();
            }
        }

        int IFrmOrderItem.ITEM_ID
        {
            get
            {
                if (txtServiceItem.MemberValue == null)
                    return 0;
                else
                    return Convert.ToInt32(txtServiceItem.MemberValue);
            }
            set
            {
                txtServiceItem.MemberValue = value;
            }
        }

        public int TC_FLAG
        {
            get
            {
                return chkComplex.Checked ? 1 : 0;
            }
            set
            {
                chkComplex.Checked = value == 1 ? true : false;
            }
        }

        public int DELETE_BIT
        {
            get
            {
                return chkDelete.Checked ? 1 : 0;
            }
            set
            {
                chkDelete.Checked = value == 1 ? true : false;
            }
        }

        public string OrderBZ
        {
            get
            {
                return txtMemo.Text.Trim();
            }
            set
            {
                txtMemo.Text = value.Trim();
            } 
        }

        #endregion
        #region 医嘱项目维护相关事件
        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            orderController.ClearInfo();
            btnAddOrder.Enabled = false;
        }

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
                        
            string message="";
            try
            {
                if (btnAddOrder.Enabled == false)
                {
                    if (!orderController.CheckData(false, out message))
                        throw new Exception(message);

                    orderController.SaveOrderItem();
                    btnAddOrder.Enabled = true;
                }
                else
                {
                    if (!orderController.CheckData(true, out message))
                        throw new Exception(message);

                    orderController.UpdateOrderItem();
                }
                MessageBox.Show("保存成功！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAddOrder.Focus( );
            }
            catch(Exception err)
            {
                MessageBox.Show("保存失败！\r\n" + err.Message , "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void cboOrderType_SelectedValueChanged(object sender, EventArgs e)
        {
            //医嘱类型选择发生变化
            if (cboOrderType.SelectedValue != null && cboOrderType.SelectedValue.ToString() == "5")
            {
                cboMediClass.Enabled = true;
            }
            else
            {
                cboMediClass.Enabled = false;
                if ( cboOrderType.SelectedValue != null && cboOrderType.SelectedValue.ToString( ) == "7" )
                    txtServiceItem.Enabled = false;
                else
                    txtServiceItem.Enabled = true;
            }
        }

        void dgvOrderItem_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            //e.Cancel = true;
        }

        void dgvOrderItem_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvOrderItem.CurrentCell == null)
                return;
            orderController.ShowOrderDetail();
            btnAddOrder.Enabled = true;
        }

        void txtServiceItem_TextChanged(object sender, EventArgs e)
        {
            if (txtServiceItem.Text.Trim() == "")
            {
                chkComplex.Checked = false;
            }
        }

        private void txtServiceItem_AfterSelectedRow(object sender, object SelectedValue)
        {
            if (SelectedValue != null)
            {
                if (Convert.ToInt32(((DataRow)SelectedValue)["COMPLEX_ID"]) > 0)
                {
                    chkComplex.Checked = true;
                }
                else
                {
                    chkComplex.Checked = false;
                }
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string strFilter = "";
            string keyWord = GWI.HIS.Windows.Controls.CommonFun.FormatKeyword(txtKeyword3.Text);

            strFilter = "PY_CODE like '" + keyWord + "%' or WB_CODE like '" + keyWord + "%' or ORDER_NAME like '%" + keyWord + "%'";
            if (chkOrderType.Checked)
            {
                strFilter = "(" + strFilter + ") and ORDER_TYPE=" + cboFindOrderType.SelectedValue.ToString();
            }
            ((DataView)dgvOrderItem.DataSource).RowFilter = strFilter;
        }

        private void chkOrderType_CheckedChanged(object sender, EventArgs e)
        {
            cboFindOrderType.Enabled = chkOrderType.Enabled;
        }

        private void txtKeyword3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                btnFind_Click(null, null);
            }
        }

        private void btnAddToOrder1_Click(object sender, EventArgs e)
        {
            if (dgvItem.CurrentCell == null)
                return;

            int row = dgvItem.CurrentCell.RowIndex;
            AddInfoToOrderUI(dgvItem["ITEM_NAME", row].Value.ToString(),
                                dgvItem["PY_CODE", row].Value.ToString(),
                                dgvItem["WB_CODE", row].Value.ToString(),
                                "",
                                dgvItem["ITEM_UNIT", row].Value.ToString(),
                                Convert.ToInt32(dgvItem["ITEM_ID", row].Value),
                                false);
            
            
        }

        private void AddInfoToOrderUI(string name, string py, string wb, string code, string unit, int itemid, bool complex)
        {
            dgvOrderItem.CurrentCellChanged -= dgvOrderItem_CurrentCellChanged;
            txtOrderName.Text = name;
            txtOrderPY.Text = py;
            txtOrderWB.Text = wb;
            txtOrderCode.Text = code;
            txtOrderUnit.Text = unit;
            txtServiceItem.MemberValue = itemid;
            chkComplex.Checked = complex;

            cboOrderType.SelectedIndex = -1;
            btnAddOrder.Enabled = false;
            tabControl1.SelectedIndex = 3;
            DELETE_BIT = 0;
            dgvOrderItem.CurrentCellChanged +=new EventHandler(dgvOrderItem_CurrentCellChanged);
        }

        private void Order_EditController_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctrl = (Control)sender;
            if ((int)e.KeyChar == 13)
            {
                if (ctrl.Name == cboOrderType.Name)
                {
                    txtOrderName.Focus();
                }
                if (ctrl.Name == txtOrderName.Name)
                {
                    string[] pywb = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.GetPyWbCode(txtOrderName.Text);
                    txtOrderPY.Text = pywb[0];
                    txtOrderWB.Text = pywb[1];
                    txtOrderCode.Focus();
                }
                if (ctrl.Name == txtOrderPY.Name)
                {
                    txtOrderWB.Focus();
                }
                if (ctrl.Name == txtOrderWB.Name)
                {
                    txtOrderCode.Focus();
                }
                if (ctrl.Name == txtOrderCode.Name)
                {
                    txtOrderUnit.Focus();
                }
                if (ctrl.Name == txtOrderUnit.Name)
                {
                    if (!cboMediClass.Enabled)
                        txtUsage.Focus();
                    else
                        cboMediClass.Focus();
                }
                if (ctrl.Name == cboMediClass.Name)
                {
                    txtUsage.Focus();
                }
                if (ctrl.Name == txtUsage.Name)
                {
                    txtServiceItem.Focus();
                }
                if (ctrl.Name == txtServiceItem.Name)
                {
                    txtMemo.Focus();
                }
                if (ctrl.Name == txtMemo.Name)
                {
                    btnSaveOrder.Focus();
                }
            }
        }

        private void btnRefreshServiceItem_Click( object sender , EventArgs e )
        {
            orderController.RefreshServiceItems( );
            txtServiceItem.SetSelectionCardDataSource( orderController.ServiceItems );
        }
        #endregion


        #region IFrmItemExecDept 成员

        public List<BaseItem> SelectedItems
        {
            get
            {
                List<BaseItem> selectedItems = new List<BaseItem>( );
                if ( dgvHsItem.CurrentCell == null )
                {
                    return selectedItems;
                }

                for ( int i = 0 ; i < dgvHsItem.SelectedRows.Count ; i++ )
                {
                    int rowIndex = dgvHsItem.SelectedRows[i].Index;
                    BaseItem selectedItem = new BaseItem( );
                    selectedItem.ItemId = Convert.ToInt32( dgvHsItem[ITEM_ID_3.Name , rowIndex].Value );
                    selectedItem.ComplexId = Convert.ToInt32( dgvHsItem[COMPLEX_ID_3.Name , rowIndex].Value );
                    selectedItems.Add( selectedItem );
                }
                return selectedItems;
            }
        }

        

        public List<Department> SelectedDepts
        {
            get
            {
                List<Department> lstDept = new List<Department>();

                for (int i = 0; i < dgvDept.Rows.Count; i++)
                {
                    if (dgvDept[SELECTED.Name, i].Value != null && Convert.ToInt32(dgvDept[SELECTED.Name, i].Value) == 1)
                    {
                        Department dept = new Department();
                        dept.DeptID = Convert.ToInt32(dgvDept[DEPT_ID.Name, i].Value);
                        dept.DefaultFlag = Convert.ToInt32(dgvDept[DEFAULT_FLAG.Name, i].Value);
                        lstDept.Add(dept);
                    }
                }

                return lstDept;
            }
        }

        #endregion
        #region 执行科室维护界面事件
        void dgvHsItem_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvHsItem.CurrentCell == null)
                return;
            List<Department> lstDept = execDeptController.ExecDeptOfSelectedItem;
            for (int i = 0; i < dgvDept.Rows.Count; i++)
            {
                dgvDept[SELECTED.Name, i].Value = 0;
                dgvDept[DEFAULT_FLAG.Name, i].Value = 0;
                for (int j = 0; j < lstDept.Count; j++)
                {
                    if (lstDept[j].DeptID == Convert.ToInt32(dgvDept[DEPT_ID.Name, i].Value))
                    {
                        dgvDept[SELECTED.Name, i].Value = (short)1;
                        if (lstDept[j].DefaultFlag == 1)
                            dgvDept[DEFAULT_FLAG.Name, i].Value = 1;
                        
                        break;
                    }

                }
                
            }
        }

        private void txtKeyword1_TextChanged(object sender, EventArgs e)
        {
            string filterString = "";
            if (txtKeyword1.Text.Trim() != "")
            {
                string keyWord = CommonFun.FormatKeyword(txtKeyword1.Text);
                filterString = "ITEM_NAME LIKE '%" + keyWord + "%' OR PY_CODE LIKE '%" + keyWord + "%' OR WB_CODE LIKE '%" + keyWord + "%'";
            }
            ((DataView)dgvHsItem.DataSource).RowFilter = filterString;
        }

        private void btnSaveExecDept_Click(object sender, EventArgs e)
        {
            if (dgvHsItem.CurrentCell == null)
            {
                MessageBox.Show("请先选择具体的服务项目！","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            try
            {
                execDeptController.SaveItemExceDept( );
                MessageBox.Show( "执行科室保存成功！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                txtKeyword1.Focus( );
            }
            catch(Exception err)
            {
                MessageBox.Show( err.Message ,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        void dgvDept_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DEFAULT_FLAG.Index)
            {
                for (int i = 0; i < dgvDept.Rows.Count; i++)
                    dgvDept[DEFAULT_FLAG.Name, i].Value = (short)0;

                dgvDept[SELECTED.Name, e.RowIndex].Value = (short)1;
            }

        }

        void dgvDept_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < dgvDept.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgvDept[SELECTED.Name, i].Value) == 1)
                {
                    if (Convert.ToInt32(dgvDept[DEFAULT_FLAG.Name, i].Value) == 1)
                    {
                        dgvDept[DEPT_NAME.Name, i].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        dgvDept[DEPT_NAME.Name, i].Style.ForeColor = Color.Black;
                    }
                }
                else
                {
                    dgvDept[DEPT_NAME.Name, i].Style.ForeColor = Color.Gray;
                }
            }
        }

        private void btnSelectAllDept_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvDept.Rows.Count; i++)
                dgvDept[SELECTED.Name, i].Value = (short)1;
        }

        private void btnDisSelected_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvDept.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgvDept[SELECTED.Name, i].Value) == 1)
                {
                    dgvDept[SELECTED.Name, i].Value = (short)0;
                }
                else
                {
                    dgvDept[SELECTED.Name, i].Value = (short)1;

                }
            }
        }
        #endregion


        #region IFrmComplexItem 成员
        public int SelectedComplexId
        {
            get
            {
                if (dgvComplex.CurrentCell == null)
                    return 0;

                return Convert.ToInt32(dgvComplex[COMPLEX_ID.Name, dgvComplex.CurrentCell.RowIndex].Value);
            }
        }

        public string Complex_Code
        {
            get
            {
                return "";
            }
            set
            {
                
            }
        }

        public string Complex_Name
        {
            get
            {
                return txtComplexName.Text.Trim();
            }
            set
            {
                txtComplexName.Text = value.Trim();
            }
        }

        public string Complex_Item_Unit
        {
            get
            {
                return txtUnit.Text.Trim();
            }
            set
            {
                txtUnit.Text = value.Trim();
            }
        }

        public decimal Complex_Price
        {
            get
            {
                if (txtPrice.Text.Trim() == "")
                    return 0;
                else
                    return Convert.ToDecimal(txtPrice.Text);
            }
            set
            {
                txtPrice.Text = value.ToString();
            }
        }

        public string Complex_Statitem_Code
        {
            get
            {
                if (cboStatItem.SelectedValue == null)
                    return "";
                else
                    return cboStatItem.SelectedValue.ToString();
            }
            set
            {
                cboStatItem.SelectedValue = value.Trim();
            }
        }

        public string Complex_Py_Code
        {
            get
            {
                return txtPyCode.Text.Trim();
            }
            set
            {
                txtPyCode.Text = value.Trim();
            }
        }

        public string Complex_Wb_Code
        {
            get
            {
                return txtWbCode.Text.Trim();
            }
            set
            {
                txtWbCode.Text = value.Trim();
            }
        }

        public int Complex_Valid_Flag
        {
            get
            {
                return chkValid.Checked ? 1 : 0;
            }
            set
            {
                chkValid.Checked = value == 1 ? true : false;
            }
        }

        public List<ComplexDetailItem> ComplexDetail
        {
            get
            {
                List<ComplexDetailItem> lstDetail = new List<ComplexDetailItem>();
                for (int i = 0; i < dgvDetail.Rows.Count; i++)
                {
                    ComplexDetailItem detail = new ComplexDetailItem();
                    detail.ITEM_ID = Convert.ToInt32(dgvDetail[DETAIL_ITEM_ID.Name, i].Value);
                    if (detail.ITEM_ID == 0) //2010-06-03 组合项目增加明细时，名称为空时，数据库里会增加一条空的记录  heyan
                    {
                        continue;
                    }
                    detail.Num = Convert.ToInt32( dgvDetail[NUM.Name,i].Value );
                    detail.PRICE = Convert.ToDecimal(dgvDetail[DETAIL_PRICE.Name, i].Value);
                    lstDetail.Add(detail);
                }
                return lstDetail;
            }
        }

        #endregion
        #region 组合项目界面控件事件
        void dgvComplex_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvComplex.CurrentCell == null)
            {
                btnSave.Enabled = false;
                return;
            }

            if (dgvComplex.Rows.Count == 0)
                return;
            

            complexController.ShowComplexItem();
            DataTable tbDetail = complexController.SelectedComplexItemDetail;
            dgvDetail.Rows.Clear();
            for (int i = 0; i < tbDetail.Rows.Count; i++)
            {
                dgvDetail.Rows.Add();
                int row = dgvDetail.Rows.Count - 1;
                dgvDetail["DETAIL_ITEM_ID", row].Value = tbDetail.Rows[i]["ITEM_ID"];
                dgvDetail["DETAIL_ITEM_NAME", row].Value = tbDetail.Rows[i]["ITEM_NAME"];
                dgvDetail["NUM", row].Value = tbDetail.Rows[i]["NUM"];
                dgvDetail["DETAIL_PRICE", row].Value = tbDetail.Rows[i]["PRICE"];
            }
            btnSave.Enabled = true;
            btnAdd.Enabled = true;
        }

        private void txtComplexName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                string[] pywb = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.GetPyWbCode(txtComplexName.Text);
                txtPyCode.Text = pywb[0];
                txtWbCode.Text = pywb[1];
            }
        }

        private void cboStatItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                txtPrice.Focus();
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            dgvDetail.Rows.Add();
            dgvDetail.CurrentCell = dgvDetail["KEY_CODE", dgvDetail.Rows.Count - 1];
            dgvDetail.Focus();
        }

        private void btnRemoveDetail_Click(object sender, EventArgs e)
        {
            if (dgvDetail.Rows.Count == 0)
                return;
            if (dgvDetail.CurrentCell == null)
                return;
            if (dgvComplex.Rows.Count == 0)
                return;
            if ( dgvComplex.CurrentCell == null )
            {
                    return;
            }

            //int complexId = Convert.ToInt32(dgvComplex["COMPLEX_ID", dgvComplex.CurrentCell.RowIndex].Value);
            //int detailId = Convert.ToInt32(dgvDetail["DETAIL_ITEM_ID", dgvDetail.CurrentCell.RowIndex].Value);

            dgvDetail.Rows.RemoveAt(dgvDetail.CurrentCell.RowIndex);
        }

        private void txtKeyword2_TextChanged(object sender, EventArgs e)
        {
            string filterString = "";
            if (txtKeyword2.Text.Trim() != "")
            {
                string keyWord = CommonFun.FormatKeyword(txtKeyword2.Text);
                filterString = "ITEM_NAME LIKE '%" + keyWord + "%' OR PY_CODE LIKE '%" + keyWord + "%' OR WB_CODE LIKE '%" + keyWord + "%'";
            }
            ((DataView)dgvComplex.DataSource).RowFilter = filterString;
        }

        private void btnAddToOrder2_Click(object sender, EventArgs e)
        {
            if (dgvComplex.CurrentCell == null)
                return;
            int row = dgvComplex.CurrentCell.RowIndex;
            AddInfoToOrderUI(dgvComplex["COMPLEX_NAME", row].Value.ToString(),
                               dgvComplex["COMPLEX_PY_CODE", row].Value.ToString(),
                               dgvComplex["COMPLEX_WB_CODE", row].Value.ToString(),
                               "",
                               dgvComplex["COMPLEX_UNIT", row].Value.ToString(),
                               Convert.ToInt32(dgvComplex["COMPLEX_ID", row].Value),
                               true);
        }

        private void dgvDetail_SelectCardRowSelected(object SelectedValue, ref bool stop, ref int customNextColumnIndex)
        {
            if (SelectedValue != null)
            {
                int row = dgvDetail.CurrentCell.RowIndex;
                string selectedId = ((DataRow)SelectedValue)["ITEM_ID"].ToString().Trim();
                for (int i = 0; i < dgvDetail.Rows.Count; i++)
                {
                    string curId = dgvDetail["DETAIL_ITEM_ID", i].Value == null ? "" : dgvDetail["DETAIL_ITEM_ID", i].Value.ToString().Trim();
                    if (selectedId == curId)
                    {
                        MessageBox.Show("所选项目已经添加，如需要增加，请更改数量！", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        stop = true;
                        return;
                    }
                }

                dgvDetail["DETAIL_ITEM_ID", row].Value = ((DataRow)SelectedValue)["ITEM_ID"].ToString();
                dgvDetail["DETAIL_ITEM_NAME", row].Value = ((DataRow)SelectedValue)["ITEM_NAME"].ToString();
                dgvDetail["DETAIL_PRICE", row].Value = ((DataRow)SelectedValue)["PRICE"].ToString();
                dgvDetail["NUM", row].Value = 1;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            txtComplexName.Text = "";
            txtPyCode.Text = "";
            txtWbCode.Text = "";
            txtUnit.Text = "";
            txtPrice.Text = "0.00";
            cboStatItem.SelectedIndex = -1;
            chkValid.Checked = true;
            dgvDetail.Rows.Clear();
            txtComplexName.Focus();
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();

                if (btnAdd.Enabled == false)
                {
                    complexController.AddComplexItem();
                    MessageBox.Show("添加组合项目成功!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    complexController.UpdateComplexItem();
                    MessageBox.Show("保存成功！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnAdd.Focus( );
                }
               // 20100604.2.04 组合项目保存时，项目自动刷新
                orderController.RefreshServiceItems();
                txtServiceItem.SetSelectionCardDataSource(orderController.ServiceItems);
                btnAdd.Enabled = true;
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存组合项目发生错误！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;

            }
        }

        private void btnRefreshComplexSelectCard_Click( object sender , EventArgs e )
        {
            dgvDetail.SetSelectionCardDataSource( serviceItemController.HospitalBaseServiceItem , 0 );
        }
        #endregion


        #region IFrmUsageItem 成员

        public int CurrentSelectedUsageID
        {
            get
            {
                if ( dgvUsageItem.CurrentCell == null )
                    return 0;
                else
                    return Convert.ToInt32( dgvUsageItem[USAGE_ID.Name , dgvUsageItem.CurrentCell.RowIndex].Value );
            }
        }

        public string UsageName
        {
            get
            {
                return txtUsageName.Text.Trim( );
            }
            set
            {
                txtUsageName.Text = value;
            }
        }

        public string UsageUnit
        {
            get
            {
                return txtUsageUnit.Text.Trim( );
            }
            set
            {
                txtUsageUnit.Text = value;
            }
        }

        public string UsagePyCode
        {
            get
            {
                return txtUsagePyCode.Text.Trim( );
            }
            set
            {
                txtUsagePyCode.Text = value;
            }
        }

        public string UsageWbCode
        {
            get
            {
                return txtUsageWbCode.Text.Trim( );
            }
            set
            {
                txtUsageWbCode.Text = value;
            }
        }

        public bool PrintLong
        {
            get
            {
                return chkPrintLong.Checked;
            }
            set
            {
                chkPrintLong.Checked = value;
            }
        }

        public bool PrintTemp
        {
            get
            {
                return chkPrintTemp.Checked;
            }
            set
            {
                chkPrintTemp.Checked = value;
            }
        }

        public bool DeleteBit
        {
            get
            {
                return chkUsageDelete.Checked;
            }
            set
            {
                chkUsageDelete.Checked = value;
            }
        }

        public List<LinkageItem> AssociatedItems
        {
            get
            {
                List<LinkageItem> lstItems = new List<LinkageItem>( );
                for ( int i = 0 ; i < dgvAssServiceItem.Rows.Count ; i++ )
                {
                    if ( dgvAssServiceItem[COL_USAGE_ITEM_ID.Name , i].Value == null ||
                        dgvAssServiceItem[COL_USAGE_ITEM_ID.Name , i].Value.ToString( ) == "" )
                        continue;

                    LinkageItem item = new LinkageItem( );
                    item.ITEM_ID = ( Convert.ToInt32( dgvAssServiceItem[COL_USAGE_ITEM_ID.Name , i].Value ) );
                    item.ITEM_NAME = dgvAssServiceItem[COL_USAGE_ITEM_NAME.Name , i].Value.ToString( );
                    item.ITEM_UNIT = dgvAssServiceItem[COL_USAGE_ITEM_UNIT.Name , i].Value.ToString( );
                    item.PRICE = Convert.ToDecimal( dgvAssServiceItem[COL_USAGE_ITEM_PRICE.Name , i].Value );
                    try
                    {
                        if ( dgvAssServiceItem[COL_USAGE_ITEM_NUM.Name , i].Value == null )
                            item.Num = 1;
                        else
                            item.Num = Convert.ToInt32( dgvAssServiceItem[COL_USAGE_ITEM_NUM.Name , i].Value );
                    }
                    catch
                    {
                        item.Num = 1;
                    }

                    lstItems.Add( item );
                }
                return lstItems;
            }
            set
            {
                dgvAssServiceItem.Rows.Clear( );
                foreach ( LinkageItem item in value )
                {
                    int row = dgvAssServiceItem.Rows.Add( );
                    dgvAssServiceItem[COL_USAGE_ITEM_ID.Name , row].Value = item.ITEM_ID;
                    dgvAssServiceItem[COL_USAGE_ITEM_NAME.Name , row].Value = item.ITEM_NAME;
                    dgvAssServiceItem[COL_USAGE_ITEM_UNIT.Name , row].Value = item.ITEM_UNIT;
                    dgvAssServiceItem[COL_USAGE_ITEM_PRICE.Name , row].Value = item.PRICE;
                    dgvAssServiceItem[COL_USAGE_ITEM_NUM.Name , row].Value = item.Num;
                }
            }
        }

        #endregion
        #region 用法维护界面控件事件
        private void btnAddAssRow_Click( object sender , EventArgs e )
        {
            dgvAssServiceItem.Rows.Add( );
            dgvAssServiceItem.CurrentCell = dgvAssServiceItem[COL_USAGE_ITEM_KEYCODE.Name , dgvAssServiceItem.Rows.Count-1];
            dgvAssServiceItem.Focus( );
        }

        private void btnDeleteAssRow_Click( object sender , EventArgs e )
        {
            if ( dgvAssServiceItem.CurrentRow != null )
                dgvAssServiceItem.Rows.Remove( dgvAssServiceItem.CurrentRow );
        }

        private void dgvAssServiceItem_SelectCardRowSelected( object SelectedValue , ref bool stop , ref int customNextColumnIndex )
        {
            if ( SelectedValue != null )
            {
                DataRow dr = (DataRow)SelectedValue;
                int row = dgvAssServiceItem.CurrentCell.RowIndex;

                dgvAssServiceItem[COL_USAGE_ITEM_ID.Name , row].Value = Convert.ToInt32( dr["ITEM_ID"] );
                dgvAssServiceItem[COL_USAGE_ITEM_NAME.Name , row].Value =  dr["ITEM_NAME"].ToString().Trim();
                dgvAssServiceItem[COL_USAGE_ITEM_UNIT.Name , row].Value = dr["ITEM_UNIT"].ToString().Trim();
                dgvAssServiceItem[COL_USAGE_ITEM_PRICE.Name , row].Value = Convert.ToDecimal( dr["PRICE"] );
                dgvAssServiceItem[COL_USAGE_ITEM_PRICE.Name , row].Value = 1;
            }
        }

        private void dgvUsageItem_CurrentCellChanged( object sender , EventArgs e )
        {
            btnAddNewUsage.Enabled = true;
            if ( dgvUsageItem.CurrentCell == null )
                return;

            usageController.ShowUsageItem( );
        }

        private void btnAddNewUsage_Click( object sender , EventArgs e )
        {
            txtUsageName.Text = "";
            txtUsagePyCode.Text = "";
            txtUsageWbCode.Text = "";
            txtUsageUnit.Text = "";
            dgvAssServiceItem.Rows.Clear( );
            txtUsageName.Focus( );
            btnAddNewUsage.Enabled = false;
        }

        private void btnSaveUsage_Click( object sender , EventArgs e )
        {
            try
            {
                if ( btnAddNewUsage.Enabled == true )
                {
                    usageController.UpdateUsageItem( );
                }
                else
                {
                    usageController.SaveUsageItem( );
                    if ( dgvUsageItem.Rows.Count > 0 )
                    {
                        dgvUsageItem.DataSource = usageController.UsageDiction.DefaultView;
                        dgvUsageItem.CurrentCell = dgvUsageItem[COL_USAGE_NAME.Name , dgvUsageItem.Rows.Count - 1];
                    }
                }
                MessageBox.Show( "保存成功！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }

        private void btnRefreshAssSeviceItem_Click( object sender , EventArgs e )
        {
            dgvAssServiceItem.SetSelectionCardDataSource( usageController.ServiceItems , COL_USAGE_ITEM_KEYCODE.Name);
        }

        private void OnTextBoxPressEnterKey( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
            {
                if ( ( (Control)sender ).Name == txtUsageName.Name )
                {
                    string[] pywb = PublicStaticFun.GetPyWbCode( txtUsageName.Text );
                    txtUsagePyCode.Text = pywb[0];
                    txtUsageWbCode.Text = pywb[1];
                    txtUsagePyCode.Focus( );
                }
                if ( ( (Control)sender ).Name == txtUsagePyCode.Name )
                {
                    txtUsageWbCode.Focus( );
                }

                if ( ( (Control)sender ).Name == txtUsageWbCode.Name )
                {
                    txtUsageUnit.Focus( );
                }
                if ( ( (Control)sender ).Name == txtUsageUnit.Name )
                {
                    btnSaveUsage.Focus( );
                }
                if ( ( (Control)sender ).Name == txtKeyword4.Name )
                {
                    btnSearchUsage_Click( null , null );
                }
            }
        }

        private void btnSearchUsage_Click( object sender , EventArgs e )
        {
            try
            {
                string keyword = CommonFun.FormatKeyword( txtKeyword4.Text );
                string sFilter = "";
                if ( keyword != "" )
                {
                    sFilter = "NAME LIKE '%" + keyword + "%' OR PY_CODE LIKE '" + keyword + "%' OR WB_CODE LIKE '" + keyword + "%'";
                }
                ( (DataView)dgvUsageItem.DataSource ).RowFilter = sFilter;
            }
            catch
            {
            }
        }
        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.ReportToExcel(((DataView)this.dgvItem.DataSource).ToTable());
        }

        /// <summary>
        /// 输出Excel
        /// </summary>
        /// <param name="Report"></param>
        public void ReportToExcel(DataTable Report)
        {

            try
            {
                int totalColumn = Report.Columns.Count;

                Microsoft.Office.Interop.Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();

                excel.Application.Workbooks.Add(true);

                //e.TotalCount = Report.DataResult.Rows.Count;

                #region 填充数据
                excel.Cells[1, 1] = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName + "费用项目";
                Microsoft.Office.Interop.Excel.Range titleStartcell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[1, 1];
                Microsoft.Office.Interop.Excel.Range titleEndcell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[1, totalColumn];
                excel.get_Range(titleStartcell, titleEndcell).Merge(0);
                excel.get_Range(titleStartcell, titleEndcell).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                excel.get_Range(titleStartcell, titleEndcell).Font.Name = "宋体";
                excel.get_Range(titleStartcell, titleEndcell).Font.Size = 15;
                excel.get_Range(titleStartcell, titleEndcell).Font.Bold = true;

                //excel.Cells[2, 1] = "统计时间：";
                //excel.Cells[2, 2] = bdate.ToString("yyyy-MM-dd HH:mm:ss") + " -- " + edate.ToString("yyyy-MM-dd HH:mm:ss");
                excel.get_Range((Microsoft.Office.Interop.Excel.Range)excel.Cells[2, 2], (Microsoft.Office.Interop.Excel.Range)excel.Cells[2, 6]).Merge(0);

                excel.Cells[2, totalColumn - 2] = "制表人：";
                //excel.Cells[2, totalColumn - 1] = _user.Name;


                int row = 3;
                Microsoft.Office.Interop.Excel.Range startCell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[row, 1];
                Microsoft.Office.Interop.Excel.Range endCell = (Microsoft.Office.Interop.Excel.Range)excel.Cells[row + Report.Rows.Count, totalColumn];

                for (int i = 0; i < Report.Columns.Count; i++)
                    excel.Cells[row, i + 1] = Report.Columns[i].ColumnName.ToString();
                row = row + 1;
                for (int i = 0; i < Report.Rows.Count; i++)
                {

                    for (int j = 0; j < Report.Columns.Count; j++)
                    {
                        object objValue = Report.Rows[i][Report.Columns[j].ColumnName];
                        if (Convert.IsDBNull(objValue))
                            continue;
                        excel.Cells[row + i, j + 1] = objValue.ToString();
                    }
                    //e.CurrentCount = i;
                    //if (OnExporting != null)
                    //    OnExporting(e);
                }
                #endregion

                #region 画网格线
                object obj = excel.get_Range(startCell, endCell).Select();

                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;

                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                excel.get_Range(startCell, endCell).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

                row = row + Report.Rows.Count + 1;
                excel.Cells[row, 1] = "审核人";
                excel.Cells[row, totalColumn - 2] = "打印日期：";
                excel.Cells[row, totalColumn] = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.ToString("yyyy-MM-dd");
                #endregion

                //excel.get_Range(titleStartcell, titleEndcell).Select();
                excel.ActiveWindow.DisplayGridlines = false;
                excel.Visible = true;

            }
            catch (Exception err)
            {
                MessageBox.Show("输出到Excel发生错误！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ErrorWriter.WriteLog(err.Message);
            }
            finally
            {
                GC.Collect();
            }
        }

    }
}
