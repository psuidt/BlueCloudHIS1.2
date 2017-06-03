using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.ZY_BLL;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.ZYDoc_BLL;
using GWMHIS.BussinessLogicLayer.Classes;
using GWI.HIS.Windows.Controls;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS_ZYDocManager.日常业务
{
    public partial class FrmOrderManager : GWI.HIS.Windows.Controls.BaseForm, Action.IFrmOrderManagerView
    {
        private User _currentUser;
        private Deptment _currentDept;
        private int _rowIndex;
        HIS.Model.ZY_PatList _zypatlist;
        private Action.Order_Status order_Status;
        public Action.FrmOrderManagerController Controller;
        private string note;
        private bool show = false;
        private static Deptment dept;
        private bool first = true;
        private bool firsetss = true;
        private int[] curSelectedRow = new int[100];
        public  bool notSaveLong = false;
        public  bool notSaveTemp = false;
        public  bool notSend = false;
        /// <summary>
        /// 长期账单和临时账单的数据网格控件
        /// </summary>
        private GWI.HIS.Windows.Controls.DataGridViewEx _DataGridViewEx;
        /// <summary>
        /// 0,长期，1，临时
        /// </summary>
        private int OrderKind = 0;       
        public FrmOrderManager()
        {
            InitializeComponent();
            //_zypatlist = patlist;
            //IsExistNotSaveLong();
            //IsExistNotSaveTemp();
            //IsExistNotSend();
        }
        public FrmOrderManager(long currentUserId, long currentDeptId, HIS.Model.ZY_PatList patlist)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            dept = _currentDept;
            _zypatlist = patlist;
            Controller = new HIS_ZYDocManager.Action.FrmOrderManagerController(this);
            OrderKind = 0;
            _DataGridViewEx = this.dtgrdLong;
            Controller.GetPatlist();
            Controller.getOrderData(OrderKind);
        }
        public FrmOrderManager(HIS.Model.ZY_PatList patlist)
        {
            InitializeComponent();
            _zypatlist = patlist;
            Controller = new HIS_ZYDocManager.Action.FrmOrderManagerController(this);
            OrderKind = 0;
            _DataGridViewEx = this.dtgrdLong;
            Controller.GetPatlist();
            this.tabPageControl1.SelectedIndex = 0;
            Controller.getOrderData(OrderKind);
        }
        private void FrmOrderManager_Load(object sender, EventArgs e)
        {
            this.pres_amount.TextFormatStyle = GWI.HIS.Windows.Controls.TextFormatStyle.Numberic;
            this.pres_amount1.TextFormatStyle = GWI.HIS.Windows.Controls.TextFormatStyle.Numberic;
            this.amount.TextFormatStyle = GWI.HIS.Windows.Controls.TextFormatStyle.Numberic;
            this.amount1.TextFormatStyle = GWI.HIS.Windows.Controls.TextFormatStyle.Numberic;
            this.amount2.TextFormatStyle = GWI.HIS.Windows.Controls.TextFormatStyle.Numberic;
            this.firset_times.TextFormatStyle = GWI.HIS.Windows.Controls.TextFormatStyle.Numberic;
            if (_DataGridViewEx != null)
            {
                Controller.ColorPaint((DataTable)_DataGridViewEx.DataSource);
                this.SetPlace();
            }
        }
        public void Brush()
        {
            this.tabPageControl1.SelectedIndex = 0;
            OrderKind = 0;
            Controller.getOrderData(0);
            this.SetPlace();
        }
        public void BrushTemp()
        {
            
            this.tabPageControl1.SelectedIndex = 1;
            OrderKind = 1;
            Controller.getOrderData(1);
            this.SetPlace();
            // Controller.ColorPaint((DataTable)dtgrdTemp.DataSource);
        }
        private void tabPageControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._DataGridViewEx.CloseSelectionCard();
            this.chkEdit.Checked = false;
            if (tabPageControl1.SelectedIndex == 0)
            {
                OrderKind = 0;
                _DataGridViewEx = this.dtgrdLong;
                this.btnjz.Visible = false;
                this.btnGave.Visible = false;
                this.btnStop.Visible = true;
                this.btnSelf.Visible = true;
                this.btnModel.Visible = true;  
                
                show = true;
            }
            if (tabPageControl1.SelectedIndex == 1)
            {
                OrderKind = 1;
                _DataGridViewEx = this.dtgrdTemp;
                this.btnjz.Visible = true;
                this.btnGave.Visible = true;
                this.btnStop.Visible = false;
                this.btnSelf.Visible = true;
                this.btnModel.Visible = true;  
                show = false;
                if (first)
                {
                    if (dtgrdTemp.DataSource != null)
                    {
                        first = false;
                    }
                    else
                    {
                        Controller.getOrderData(OrderKind);
                        first = false;
                        this.SetPlace();
                    }
                }
            }
            if (tabPageControl1.SelectedIndex == 2)
            {
                OrderKind = 6;
                _DataGridViewEx = this.dtgrdOpration;
                this.btnjz.Visible = false;
                this.btnGave.Visible = false;
                this.btnStop.Visible = false;
                this.btnSelf.Visible = false;
                this.btnModel.Visible = false;               
                show = false;
                if (firsetss)
                {
                    if (dtgrdOpration.DataSource != null)
                    {
                        firsetss = false;

                    }
                    else
                    {
                        Controller.getOperation();
                        firsetss = false;
                        this.SetPlace();
                    }
                }
            }
        }

        #region IView成员
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
        public void Initialize(DataSet _dataSet)
        {
            this.dtgrdLong.SetSelectionCardDataSource(_dataSet.Tables["ITEM_DICTIONARYLONG"], itemname.Index);
            this.dtgrdLong.SetSelectionCardDataSource(_dataSet.Tables["Usage"], order_usage.Index);
            this.dtgrdLong.SetSelectionCardDataSource(_dataSet.Tables["Frequency"], frequency.Index);
            this.dtgrdLong.SetSelectionCardDataSource(_dataSet.Tables["Entrust"], order_struc.Index);

            this.dtgrdTemp.SetSelectionCardDataSource(_dataSet.Tables["ITEM_DICTIONARY"], itemname1.Index);
            this.dtgrdTemp.SetSelectionCardDataSource(_dataSet.Tables["Usage"], order_usage1.Index);
            this.dtgrdTemp.SetSelectionCardDataSource(_dataSet.Tables["Frequency"], frequency1.Index);
            this.dtgrdTemp.SetSelectionCardDataSource(_dataSet.Tables["Entrust"], order_struc1.Index);
            this.dtgrdTemp.SetSelectionCardDataSource(_dataSet.Tables["DwType"], unit1.Index);
          

            this.dtgrdOpration.SetSelectionCardDataSource(_dataSet.Tables["ITEM_DICTIONARYOP"], itemname2.Index);
            this.dtgrdOpration.SetSelectionCardDataSource(_dataSet.Tables["Usage"], order_usage2.Index);
            this.dtgrdOpration.SetSelectionCardDataSource(_dataSet.Tables["Frequency"], frequency2.Index);
            this.dtgrdOpration.SetSelectionCardDataSource(_dataSet.Tables["Entrust"], order_struc2.Index);
        }
        #endregion

        #region IFrmOrderManagerView 病人信息处方数据

        public void SetUnit(DataTable dw)
        {
            //this._DataGridViewEx.SetSelectionCardDataSource(dw, unit1.Index);
            //this._DataGridViewEx.SetSelectionCardDataSource(dw, unit2.Index);
        }

        public void SetItem(int sign, int kind)
        {
            //if (kind == 0) //长期
            //{
            //    if (sign == 0)
            //    {
            //        this.dtgrdLong.SetSelectionCardDataSource(Controller.getData(4), itemname.Index);
            //    }
            //    //西药和中成药
            //    if (sign == 1)
            //    {
            //        this.dtgrdLong.SetSelectionCardDataSource(Controller.getData(0), itemname.Index);
            //    }

            //    //项目
            //    if (sign == 2)
            //    {
            //        this.dtgrdLong.SetSelectionCardDataSource(Controller.getData(5), itemname.Index);
            //    }
            //}
            //if (kind == 1) //临时
            //{
            //    if (sign == 0)
            //    {
            //        this.dtgrdTemp.SetSelectionCardDataSource(Controller.getData(3), itemname1.Index);
            //    }
            //    //西药和中成药
            //    if (sign == 1)
            //    {
            //        this.dtgrdTemp.SetSelectionCardDataSource(Controller.getData(0), itemname1.Index);
            //    }
            //    //中草药
            //    if (sign == 2)
            //    {
            //        this.dtgrdTemp.SetSelectionCardDataSource(Controller.getData(1), itemname1.Index);
            //    }
            //    //治疗项目和手术项目
            //    if (sign == 3)
            //    {
            //        this.dtgrdTemp.SetSelectionCardDataSource(Controller.getData(2), itemname1.Index);
            //    }
            //}
            //if (kind == 6)
            //{
            //    if (sign == 0)
            //    {
            //        this.dtgrdTemp.SetSelectionCardDataSource(Controller.getData(3), itemname2.Index);
            //    }
            //    //西药和中成药
            //    if (sign == 1)
            //    {
            //        this.dtgrdTemp.SetSelectionCardDataSource(Controller.getData(0), itemname2.Index);
            //    }
            //    //中草药
            //    if (sign == 2)
            //    {
            //        this.dtgrdTemp.SetSelectionCardDataSource(Controller.getData(1), itemname2.Index);
            //    }
            //    //治疗项目和手术项目
            //    if (sign == 3)
            //    {
            //        this.dtgrdTemp.SetSelectionCardDataSource(Controller.getData(2), itemname2.Index);
            //    }
            //}
        }

        public int GetType()
        {
            return OrderKind;
        }

        public int GetRowIndex()
        {
            return _rowIndex;
        }
        public HIS_ZYDocManager.Action.Order_Status Order_Status
        {
            get
            {
                return order_Status;
            }
        }

        public void Plus(int i)
        {
            if (i == 0)
            {
                this.dtgrdLong.CurrentCellChanged -= new System.EventHandler(this.dtgrdLong_CurrentCellChanged);
            }
            if (i == 1)
            {
                this.dtgrdLong.CurrentCellChanged += new System.EventHandler(this.dtgrdLong_CurrentCellChanged);
            }
        }

        public string InpatNo
        {
            get
            {
                return this.inPatientPanel1.InPaitent.InpitentNo;
            }
            set
            {
                this.inPatientPanel1.InPaitent.InpitentNo = value;
            }
        }

        public HIS.Model.ZY_PatList zy_patlist_get
        {
            get
            {
                return _zypatlist;
            }
        }

        public HIS.Model.ZY_PatList BindPatControlData
        {
            set
            {
                HIS_ZYDocManager.PublicClass patient = new PublicClass();
                string[] doc = new string[3];
                doc = HIS.ZYDoc_BLL.OP_OrderManager.GetDoc(value.PatListID);
                patient.BalanceFee = HIS.ZY_BLL.OP_CostManage.GetPatFee(value.PatListID).surplusFee;
                patient.BedNo = value.BedCode;
                patient.BordDay = value.PatientInfo.PatBriDate;
                patient.CureDoctor = new GWI.HIS.Windows.Controls.BindValue(null,doc[1] );
                patient.CurrentDepartment = new GWI.HIS.Windows.Controls.BindValue(null, this._currentDept.Name);
                patient.EconomyDoctor = new GWI.HIS.Windows.Controls.BindValue(null, doc[0]);
                patient.InDepartment = new GWI.HIS.Windows.Controls.BindValue(null, HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(value.CureDeptCode));
                string[] strdiag = value.DiseaseName.Split(new char[] { '|' });
                patient.InDisease = new GWI.HIS.Windows.Controls.BindValue(null, strdiag[0]);
                patient.InpitentNo = value.CureNo;
                patient.Nurse = new GWI.HIS.Windows.Controls.BindValue(null, doc[2]);
                patient.PatientName = value.PatientInfo.PatName;
                patient.PatientType = new GWI.HIS.Windows.Controls.BindValue(null, value.PatientInfo.ACCOUNTTYPE);
                patient.PrePayFee = HIS.ZY_BLL.OP_CostManage.GetPatFee(value.PatListID).chargeFee;
                patient.Sex = value.PatientInfo.PatSex;
                patient.InDate = value.CureDate;
                patient.TendInfo = "";
                this.inPatientPanel1.InPaitent = patient;               
            }
        }

        public PatFee BindPatFeeControlData
        {
            set
            {
                //this.lbChargeFee.Text = value.chargeFee.ToString();
                //this.lbCostFee.Text = value.costFee.ToString();
                //this.lbExtFee.Text = value.surplusFee.ToString();
                //if (value.surplusFee < 0)
                //{
                //    this.lbExtFee.ForeColor = Color.Red;
                //}
                //else
                //{
                //    this.lbExtFee.ForeColor = Color.Black;
                //}
            }
        }

        public DataTable BindLongOrderData
        {
            get
            {
                // ((DataTable)this.dtgrdLong.DataSource).Columns["status_falg"].DefaultValue = -1;
                return (DataTable)this.dtgrdLong.DataSource;
            }
            set
            {
                this.dtgrdLong.AutoGenerateColumns = false;
                this.dtgrdLong.DataSource = value;
            }
        }

        public DataTable BindTempOrderData
        {
            get
            {
                return (DataTable)this.dtgrdTemp.DataSource;
            }
            set
            {
                this.dtgrdTemp.AutoGenerateColumns = false;
                this.dtgrdTemp.DataSource = value;
            }
        }

        public DataTable BindOprationOrderData
        {
            get
            {
                return (DataTable)this.dtgrdOpration.DataSource;
            }
            set
            {
                this.dtgrdOpration.AutoGenerateColumns = false;
                this.dtgrdOpration.DataSource = value;
            }
        }
        #endregion

        #region IFrmOrderManagerView 成员颜色
        public HIS_ZYDocManager.Action.OrderColor OrderColor
        {
            set
            {
                if (value.colIndex == -1)
                {
                    //颜色
                    for (int r = 0; r < _DataGridViewEx.Columns.Count; r++)
                    {
                        _DataGridViewEx.Rows[value.rowIndex].Cells[r].Style.ForeColor = value.ForeColor;
                        _DataGridViewEx.Rows[value.rowIndex].Cells[r].Style.BackColor = value.BackColor;
                    }
                }
                else
                {
                    _DataGridViewEx.Rows[value.rowIndex].Cells[value.colIndex].Style.ForeColor = value.ForeColor;
                    _DataGridViewEx.Rows[value.rowIndex].Cells[value.colIndex].Style.BackColor = value.BackColor;
                }
            }
        }
        #endregion

        #region 成员只读
        public bool ItemNameReadOnly
        {
            set
            {
                itemname.ReadOnly = value;
                itemname1.ReadOnly = value;
                itemname2.ReadOnly = value;
            }
        }

        public bool AmountReadOnly
        {
            set
            {
                amount.ReadOnly = value;
                amount1.ReadOnly = value;
                amount2.ReadOnly = value;
            }
        }

        public bool PresAmountReadOnly
        {
            set
            {
                pres_amount.ReadOnly = value;
                pres_amount1.ReadOnly = value;
            }
        }
        public bool UnitReadOnly
        {
            set
            {
                unit.ReadOnly = value;
                unit1.ReadOnly = value;
                unit2.ReadOnly = value;
            }
        }

        public bool FrenQuencyReadOnly
        {
            set
            {
                frequency.ReadOnly = value;
                frequency1.ReadOnly = value;
                frequency2.ReadOnly = value;
            }
        }

        public bool UsageReadOnly
        {
            set
            {
                order_usage.ReadOnly = value;
                order_usage1.ReadOnly = value;
                order_usage2.ReadOnly = value;
            }
        }
        public bool FirstTimeReadOnly
        {
            set
            {
                firset_times.ReadOnly = value;

            }
        }

        public bool DropSperReadOnly
        {
            set
            {
                dropspec.ReadOnly = value;
                dropspec1.ReadOnly = value;
                dropspec2.ReadOnly = value;
            }
        }

        public bool StrucReadOnly
        {
            set
            {
                order_struc.ReadOnly = value;
                order_struc1.ReadOnly = value;
                order_struc2.ReadOnly = value;
            }
        }

        #endregion 
        
        #region 显示范围
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0)
            {
                return;
            }
            DataTable dt = (DataTable)_DataGridViewEx.DataSource;
            for (int i = dt.Rows.Count-1; i >=0; i--)
            {
                if (dt.Rows[i]["status_falg"].ToString() == "-1")
                {

                    if (MessageBox.Show("还有未保存的医嘱，需要先保存吗？", "保存提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.chkEdit.Checked = false;
                        int colid, rowid;
                       
                        if (IsNotCanUse())
                        {
                            return;
                        }
                        if (Controller.CheckOrderData(out colid, out rowid, OrderKind))
                        {
                            try
                            {
                                this.Cursor = PublicStaticFun.WaitCursor();
                                _DataGridViewEx.EndEdit();
                                Controller.SaveOrder(OrderKind);
                                Controller.getOrderData(OrderKind);
                                this.Cursor = Cursors.Default;
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }
                            finally
                            {
                                this.Cursor = Cursors.Default;
                            }

                            this.SetPlace();
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            _DataGridViewEx.CurrentCell = _DataGridViewEx[colid, rowid];
                        }
                        break;
                        
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (radioButton1.Checked)
            {
                
                Controller.getOrderData(OrderKind);
                this.SetPlace();
            }
            else
            {
                        
                if (dt == null || dt.Rows.Count == 0)
                {
                    return;
                }
                DataTable dtcopy = dt.Clone();
                dtcopy.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[i]["status_falg"].ToString()) < 3)
                    {
                        dtcopy.Rows.Add(dt.Rows[i].ItemArray);
                    }
                } 
                this._DataGridViewEx.DataSource = dtcopy;
                Controller.ColorPaint((DataTable)_DataGridViewEx.DataSource);
                this.SetPlace();
            }
        }
        #endregion

        #region 快捷键
        private void FrmOrderManager_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F3:	//新开
                    btnNew_Click(null, null);
                    break;
                case Keys.F4:	//取消
                    btnCancel_Click(null, null);
                    break;
                case Keys.F5:	//保存
                    btnSave_Click(null, null);
                    break;
                case Keys.F6:	//模板
                    btnModel_Click(null, null);
                    break;
                case Keys.F7:	//发送
                    btnSend_Click(null, null);
                    break;
                case Keys.F8:	//停嘱
                    btnStop_Click(null, null);
                    break;
                case Keys.F9:	//交病人
                    btnGave_Click(null, null);
                    break;
                //case Keys.F10:  //医嘱复制
                //    btnExplain_Click(null, null);
                //    break;
                case Keys.F11:	//中药脚注
                    btnjz_Click(null, null);
                    break;
                case Keys.F12:	//刷新
                    btnbrush_Click(null, null);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 按钮事件（对医嘱的操作）
        //新开
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (IsNotCanUse())
            {
                return;
            }
            this.chkEdit.Checked = false;
            AddRow(this._DataGridViewEx, 0);
            _DataGridViewEx.CurrentCell = this._DataGridViewEx[2, _rowIndex];            
        }
        //保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.chkEdit.Checked = false;
            int colid, rowid;
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0)
            {
                return;
            }
            if (IsNotCanUse())
            {
                return;
            }
            if (Controller.CheckOrderData(out colid, out rowid, OrderKind))
            {
                try
                {
                    this.Cursor = PublicStaticFun.WaitCursor();
                    _DataGridViewEx.EndEdit();
                  
                    Controller.SaveOrder(OrderKind);                  
                    Controller.getOrderData(OrderKind);
                    this.Cursor = Cursors.Default;
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }

                this.SetPlace();
            }
            else
            {
                this.Cursor = Cursors.Default;
                _DataGridViewEx.CurrentCell = _DataGridViewEx[colid, rowid];
            }
        }
        //取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.chkEdit.Checked = false; 
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || _DataGridViewEx.CurrentCell==null)
            {
                return;
            }
            if (_DataGridViewEx.CurrentCell != null)
            {
               
                int _rowindex = _DataGridViewEx.CurrentCell.RowIndex;
                if (_rowindex >= _DataGridViewEx.Rows.Count)
                {
                    return;
                }
                DataTable dt = (DataTable)_DataGridViewEx.DataSource;
                string flag = dt.Rows[_rowindex]["status_falg"].ToString();
                Controller.DelOrder(_rowindex, OrderKind, 0);   
            }
            this.SetPlace();
        }
        // 中药脚注
        private void btnjz_Click(object sender, EventArgs e)
        {
            this.chkEdit.Checked = false;
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || _DataGridViewEx.CurrentCell == null)
            {
                return;
            }
            int nrow = _DataGridViewEx.CurrentCell.RowIndex;
            int ncol = _DataGridViewEx.CurrentCell.ColumnIndex;
            DataTable tb = new DataTable();
            if (OrderKind == 0)
            {
                return;
              
            }
            if (OrderKind == 1)
            {
                tb = this.BindTempOrderData;
            }
            if (OrderKind == 6)
            {
                tb = this.BindOprationOrderData;
            }
            if (tb.Rows.Count == 0)
            {
                return;
            }
            if (tb.Rows[nrow]["order_content"] == System.DBNull.Value)
            {
                return;
            }
            if (Convert.ToInt32(tb.Rows[nrow]["item_type"].ToString()) != 3)
            {
                MessageBox.Show("该医嘱不属于中草药");
                return;
            }
            if (Convert.ToInt32(tb.Rows[nrow]["status_falg"].ToString()) > 1 )
            {
                return;
            }
            FrmJZ jz = new FrmJZ();
            jz.ShowDialog();
            note = jz.note;
            if (note.Trim() != "")
            {
                string str = tb.Rows[nrow]["order_content"].ToString().Trim() + " ";
                if (str.IndexOf("【") > 0)
                {
                    str = str + str.Substring(0, str.IndexOf("【"));
                }
                tb.Rows[nrow]["order_content"] = str + " 【" + note + "】";
                List<HIS.Model.ZY_DOC_ORDERRECORD> order_record = new List<HIS.Model.ZY_DOC_ORDERRECORD>();
                HIS.Model.ZY_DOC_ORDERRECORD record = new HIS.Model.ZY_DOC_ORDERRECORD();

                record = (HIS.Model.ZY_DOC_ORDERRECORD)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(tb, nrow, record);
                record.ORDER_CONTENT = tb.Rows[nrow]["order_content"].ToString().Trim();
                order_record.Add(record);
                if (record.STATUS_FALG >= 0)
                {
                    HIS.ZYDoc_BLL.OP_OrderManager.UpdateOrderType(order_record);
                }
            }
            this.SetPlace();
        }
        //交病人
        private void btnGave_Click(object sender, EventArgs e)
        {
            this.chkEdit.Checked = false;
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || _DataGridViewEx.CurrentCell == null)
            {
                return;
            }
            if (OrderKind !=1)
            {
                MessageBox.Show("只能是临时医嘱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataTable dt = (DataTable)_DataGridViewEx.DataSource;
            
            int nrow = _DataGridViewEx.CurrentCell.RowIndex;
            int ncol = _DataGridViewEx.CurrentCell.ColumnIndex;
            if (dt.Rows[nrow]["order_content"].ToString().Trim() == "")
            {
                MessageBox.Show("请选择医嘱内容");
                return;
            }
            if (Convert.ToInt32(dt.Rows[nrow]["item_type"].ToString()) > 3)
            {
                MessageBox.Show("交病人的只能是药品！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.SetPlace();
                return;
            }
            if (Controller.OrderToPat(nrow, ncol, OrderKind))
            {
                Controller.getOrderData(OrderKind);
            }
            this.SetPlace();
        }
        //自由录入
        private void chkEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || _DataGridViewEx.CurrentCell == null)
            {
                this.ItemNameReadOnly = true;
                _DataGridViewEx.HideSelectionCardWhenCustomInput = false;
                return;
            }
            if (chkEdit.Checked == true)
            {
                int rowindex = _DataGridViewEx.CurrentCell.RowIndex;
                int colindex = _DataGridViewEx.CurrentCell.ColumnIndex;
                DataTable dt = (DataTable)_DataGridViewEx.DataSource;
                if (Convert.ToInt32(dt.Rows[rowindex]["status_falg"].ToString()) > 1)
                {
                    MessageBox.Show("该医嘱已转抄，不能自录入");
                    return;
                }
                MessageBox.Show("修改医嘱内容状态，不产生新的医嘱费用");
                this.ItemNameReadOnly = false;                
                _DataGridViewEx.HideSelectionCardWhenCustomInput = true;                
                if (dt.Rows[rowindex]["order_content"].ToString().Trim() == "")
                {
                    dt.Rows[rowindex]["order_content"] = _DataGridViewEx[2, rowindex].Value.ToString();
                    dt.Rows[rowindex]["status_falg"] = -1;
                    dt.Rows[rowindex]["item_type"] = 7;
                    dt.Rows[rowindex]["orecord_a2"] = 0;
                }
                else
                {
                    if (dt.Rows[rowindex]["orecord_a2"].ToString().Trim() == "1")
                    {
                        dt.Rows[rowindex]["orecord_a2"] = 2;
                        dt.Rows[rowindex]["status_falg"] = -1;
                    }
                    dt.Rows[rowindex]["order_content"] = _DataGridViewEx[2, rowindex].Value.ToString();
                    Controller.ColorPaint(dt);
                }
            }
            else
            {
                this.ItemNameReadOnly = true;
                _DataGridViewEx.HideSelectionCardWhenCustomInput = false;
            }
            this.SetPlace();
        }
        //刷新
        private void btnbrush_Click(object sender, EventArgs e)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0)
            {
                return;
            }
            this.chkEdit.Checked = false;
            DataTable dt = (DataTable)_DataGridViewEx.DataSource;
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (dt.Rows[i]["status_falg"].ToString() == "-1")
                {

                    if (MessageBox.Show("还有未保存的医嘱，需要先保存吗？", "保存提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int colid, rowid;
                        if (IsNotCanUse())
                        {
                            return;
                        }
                        if (Controller.CheckOrderData(out colid, out rowid, OrderKind))
                        {
                            
                                //this.Cursor = PublicStaticFun.WaitCursor();
                                //_DataGridViewEx.EndEdit();
                                Controller.SaveOrder(OrderKind);
                                //Controller.getOrderData(OrderKind);
                                //this.Cursor = Cursors.Default;
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            _DataGridViewEx.CurrentCell = _DataGridViewEx[colid, rowid];
                        }
                        break;

                    }
                    else
                    {
                        break;
                    }
                }
            }
            this.Cursor = PublicStaticFun.WaitCursor();
            _DataGridViewEx.DataSource = null;
            Controller.getOrderData(OrderKind);
            this.Cursor = Cursors.Default;
            this.SetPlace();
        }

        //医嘱发送
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || _DataGridViewEx.CurrentCell == null)
            {
                return;
            }
            this.chkEdit.Checked = false;
            if (IsNotCanUse())
            {
                return;
            } 
            DataTable dt = new DataTable();
            dt = Controller.GetOrderTable(OrderKind);
            bool hasNotSend = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["status_falg"].ToString() == "-1")
                {
                    MessageBox.Show("还有未保存的医嘱，请先保存再发送");
                    return;
                    break;
                }
                if (Convert.ToInt32(dt.Rows[i]["status_falg"].ToString()) < 1)
                {
                    hasNotSend = true;
                }
            }
            if (hasNotSend)
            {
                this.Cursor = PublicStaticFun.WaitCursor();
                Controller.SendOrder(OrderKind);
                Controller.getOrderData(OrderKind);
                this.Cursor = Cursors.Default;
                this.SetPlace();
            }
        }
        //停嘱
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || _DataGridViewEx.CurrentCell == null)
            {
                return;
            }
            if (IsNotCanUse())
            {
                return;
            }
            this.chkEdit.Checked = false;
            if (OrderKind == 0)
            {
                int nrow = _DataGridViewEx.CurrentCell.RowIndex;
                int ncol = _DataGridViewEx.CurrentCell.ColumnIndex;
                DataTable dt = this.BindLongOrderData;
                if (Convert.ToInt32(dt.Rows[nrow]["status_falg"].ToString().Trim()) == 2) // 已经转抄，没有停止
                {
                    bool b = Controller.StopCheck(nrow, ncol);
                    string frenqucy = _DataGridViewEx["frequency", nrow].Value.ToString();
                    if (b)
                    {
                        FrmStopOrder frmstop = new FrmStopOrder();
                        frmstop.frnquecy = frenqucy;
                        frmstop.beginDateTime =Convert.ToDateTime(dt.Rows[nrow]["order_bdate"]);
                        frmstop.ShowDialog();
                        if (frmstop.IsStop)
                        {
                            int num = frmstop.num;
                            DateTime edate = frmstop.endtime;
                            //if (edate < Convert.ToDateTime(dt.Rows[nrow]["order_bdate"].ToString()))
                            //{
                            //    MessageBox.Show("停嘱时间不能小于开医嘱时间,停医嘱失败");
                            //    return;
                            //}
                            bool a = Controller.StopOrders(nrow, num, edate, _currentUser.EmployeeID, Convert.ToInt32(dt.Rows[nrow]["group_id"].ToString().Trim()), 0);
                            if (a)
                            {
                                MessageBox.Show("停医嘱成功！");
                            }
                            else
                            {
                                MessageBox.Show("停医嘱失败！\n");
                            }
                        }
                    }
                }
                if (Convert.ToInt32(dt.Rows[nrow]["status_falg"].ToString().Trim()) == 3)//已经停止的医嘱可以取消停
                {
                    
                    if (Controller.StopForSH(Convert.ToInt32(dt.Rows[nrow]["patid"].ToString().Trim()), Convert.ToInt32(dt.Rows[nrow]["babyid"].ToString().Trim()), Convert.ToInt32(dt.Rows[nrow]["group_id"].ToString().Trim())))
                    {
                        MessageBox.Show("该组医嘱是术后、产后或转科自动停止的，不允许取消停！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    Controller.StopOrders(nrow, 0, HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime, _currentUser.EmployeeID, Convert.ToInt32(dt.Rows[nrow]["group_id"].ToString().Trim()), 1);
                }
               
                Controller.getOrderData(0);
                
            }
            this.SetPlace();
        }
        //模板
        private void btnModel_Click(object sender, EventArgs e)
        {
            if (_DataGridViewEx == null)
            {
                return;
            }
            if (zy_patlist_get == null)
            {
                MessageBox.Show("请先指定病人");
                return;
            }
            if (IsNotCanUse())
            {
                return;
            }
            this.chkEdit.Checked = false;
            HIS_ZYDocManager.基础数据.FrmDocModel model = new HIS_ZYDocManager.基础数据.FrmDocModel(_currentUser.UserID,_currentDept.DeptID);
            //model.MdiParent = this.MdiParent;
            //model.WindowState = FormWindowState.Maximized;
            //((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(model);
            //model.Show();

            model.ShowDialog();
            if (model.lists == null || model.lists.Count == 0)
            {
                this.SetPlace();
                return;
            }
            Controller.AddModelData(model.lists);
            this.SetPlace();
            
        }
        //// 说明性医嘱
        //private void btnExplain_Click(object sender, EventArgs e)
        //{

        //}

        // 自备　
        private void btnSelf_Click(object sender, EventArgs e)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || _DataGridViewEx.CurrentCell == null)
            {
                return;
            }
            if (IsNotCanUse())
            {
                return;
            }
            this.chkEdit.Checked = false;
            int rowid = _DataGridViewEx.CurrentCell.RowIndex;
            int colid = _DataGridViewEx.CurrentCell.ColumnIndex;
            Controller.InsertSelfMed((DataTable)_DataGridViewEx.DataSource, rowid, colid);
            this.SetPlace();
        }    
        #endregion

        #region 网格事件
        //赋值
        private void dtgrdLong_SelectCardRowSelected(object SelectedValue, ref bool stop, ref int customNextColumnIndex)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.CurrentCell == null)
            {
                return;
            }
            _DataGridViewEx.EndEdit();
            DataRow dr = (DataRow)SelectedValue;
            int rowid = this._DataGridViewEx.CurrentCell.RowIndex;
            int columnid = this._DataGridViewEx.CurrentCell.ColumnIndex;
            DataTable dt = new DataTable();
            if (OrderKind == 0)
            {
                dt = this.BindLongOrderData;
            }
            if (OrderKind == 1)
            {
                dt = this.BindTempOrderData;
            }
            if (OrderKind == 6)
            {
                dt = this.BindOprationOrderData;
            }
            int id = Controller.SelectCardBindData(OrderKind, rowid, dr, columnid);
            if (id != -1)
            {
                if (id == 3)
                {
                    if (!Controller.IsGroupFirstRow(dt, rowid))
                    {
                        _DataGridViewEx.CurrentCell = _DataGridViewEx[5, rowid];
                        _DataGridViewEx.CurrentCell = _DataGridViewEx[6, rowid];
                        _DataGridViewEx.CurrentCell = _DataGridViewEx[7, rowid];
                    }
                    _DataGridViewEx.CurrentCell = _DataGridViewEx[4, rowid];
                } 
                customNextColumnIndex = id;            
            }            
        }
        //回车新开
        private void dtgrdLong_DataGridViewCellPressEnterKey(object sender, int colIndex, int rowIndex, ref bool jumpStop)
        {
           
            this.chkEdit.Checked = false;
            DataTable dtt = (DataTable)_DataGridViewEx.DataSource;
            if (dtt.Rows[rowIndex]["status_falg"].ToString() != "-1")
            {
                return;
            }
            if (colIndex == 10 && rowIndex == (this._DataGridViewEx.RowCount - 1))
            {
                
                AddRow(this._DataGridViewEx, 1);
               
                for (int i = 0; i < _DataGridViewEx.Controls.Count; i++)
                {
                    if (_DataGridViewEx.Controls[i].GetType().ToString() == "System.Windows.Forms.HScrollBar")
                    {
                        HScrollBar scrollbar = (System.Windows.Forms.HScrollBar)this._DataGridViewEx.Controls[i];
                        scrollbar.Value = 0;
                        break;
                    }
                }

                _DataGridViewEx.CurrentCell = this._DataGridViewEx[0, _rowIndex];
                _DataGridViewEx.CurrentCell = this._DataGridViewEx[1, _rowIndex];
                //dtgrdLong_CellContentClick(null, null);
            }
            DataTable dt = new DataTable();
            if (OrderKind == 0)
            {
                dt = this.BindLongOrderData;
            }
            if (OrderKind == 1)
            {
                dt = this.BindTempOrderData;
            }
            if (OrderKind == 6)
            {
                dt = this.BindOprationOrderData;
            }
        
            if (colIndex >= 3 && !Controller.IsGroupFirstRow(dt, rowIndex))
            {
                //dt.Rows[rowIndex]["FREQUENCY"] = dt.Rows[rowIndex - 1]["FREQUENCY"].ToString();
                //dt.Rows[rowIndex]["order_usage"] = dt.Rows[rowIndex - 1]["order_usage"].ToString();
                //dt.Rows[rowIndex]["firset_times"] = dt.Rows[rowIndex - 1]["firset_times"].ToString();
                //dt.Rows[rowIndex]["pres_amount"] = dt.Rows[rowIndex - 1]["pres_amount"].ToString();
                AddRow(this._DataGridViewEx, 1);
                _DataGridViewEx.CurrentCell = this._DataGridViewEx[1, _rowIndex];
                
            }
        }

    
        //单元格值改变的时候
        private void dtgrdLong_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_DataGridViewEx != null && _DataGridViewEx.CurrentCell != null)
            {
                int rowid = _DataGridViewEx.CurrentCell.RowIndex;
                int colid = _DataGridViewEx.CurrentCell.ColumnIndex;
                DataTable dt = (DataTable)_DataGridViewEx.DataSource;                
                if (OrderKind > 0 && colid == 7 && Controller.IsGroupFirstRow(dt,rowid))
                {
                    string name = _DataGridViewEx.Columns[colid].DataPropertyName;
                    dt.Rows[rowid]["pres_amount"] = dt.Rows[rowid]["presnum"];
                    Controller.ChangeValue(dt, rowid, name);
                }
                if (OrderKind == 0 && colid == 7 && Controller.IsGroupFirstRow(dt, rowid))
                {
                    string name = _DataGridViewEx.Columns[colid].DataPropertyName;
                    dt.Rows[rowid]["firset_times"] = dt.Rows[rowid]["First"];
                    Controller.ChangeValue(dt, rowid, name);     
                }
                if (dt.Rows[rowid]["orecord_a2"].ToString().Trim() == "1")
                {
                    dt.Rows[rowid]["orecord_a2"] = 2;
                    dt.Rows[rowid]["status_falg"] = -1;
                    Controller.ColorPaint(dt);
                }
             
            }
        }
        #region 控制只读
        private void dtgrdLong_CurrentCellChanged(object sender, EventArgs e)
        {
            if (_DataGridViewEx != null && _DataGridViewEx.CurrentCell != null)
            {
                int rowid = _DataGridViewEx.CurrentCell.RowIndex;
                int colid = _DataGridViewEx.CurrentCell.ColumnIndex;
                DataTable table = (DataTable)_DataGridViewEx.DataSource;
                string flag = table.Rows[rowid]["status_falg"].ToString().Trim();
                Controller.SettingReadOnly(colid, rowid, OrderKind);
                if (OrderKind == 0)
                {
                    this.UnitReadOnly = true;                   
                    if (table.Rows.Count == 0 || table == null || rowid >= table.Rows.Count)
                    {
                        return;
                    }
                    if (flag == "2")
                    {
                        this.btnStop.Text = "停嘱(F8)";
                        this.btnStop.Enabled = true;
                    }

                    else if (flag == "3")
                    {
                        this.btnStop.Text = "取消停医嘱(F8)";
                        this.btnStop.Enabled = true;
                    }
                    else
                    {
                        this.btnStop.Text = "停医嘱(F8)";
                        this.btnStop.Enabled = false;
                    }
                }
                if (OrderKind == 1)
                {
                    if (Convert.ToInt32(table.Rows[rowid]["item_type"].ToString()) <= 2)
                    {
                        Controller.GetDwType(Convert.ToInt32(table.Rows[rowid]["makedicid"].ToString()), Convert.ToInt32(table.Rows[rowid]["item_type"].ToString()));
                    }
                }
                DataRow drug = Controller.GetDrugInfo(rowid, OrderKind);
                if (drug == null)
                {
                    this.lbdrugname.Text = "";
                    this.lbdrugunit.Text = "";
                    this.lbdrugtype.Text = "";
                    this.lbdrugrage.Text = "";
                    this.lbdrugprice.Text = "";
                    this.lbdrugdept.Text = "";
                    this.lbaddress.Text = "";
                    this.lbspec.Text = "";
                    this.cbdu.Checked = false;
                    this.cbma.Checked = false;
                    this.cbgu.Checked = false;
                    this.cbjs.Checked = false;
                }
                else
                {
                    this.lbdrugname.Text = drug["itemname"].ToString();
                    this.lbdrugunit.Text = drug["packunit"].ToString();
                    this.lbdrugtype.Text = drug["insur_type"].ToString();
                    this.lbdrugrage.Text = drug["ncms_comp_rate"].ToString();
                    this.lbdrugprice.Text = drug["sell_price"].ToString();
                    this.lbdrugdept.Text = drug["execdeptname"].ToString();
                    this.lbaddress.Text = drug["address"].ToString();
                    this.lbspec.Text = drug["standard"].ToString();
                    if (drug["virulent_flag"].ToString() == "1")
                    {
                        this.cbdu.Checked = true;
                    }
                    else
                    {
                        this.cbdu.Checked = false;
                    }
                    if (drug["narcotic_flag"].ToString() == "1")
                    {
                        this.cbma.Checked = true;
                    }
                    else
                    {
                        this.cbma.Checked = false;
                    }
                    if (drug["costly_flag"].ToString() == "1")
                    {
                        this.cbgu.Checked = true;
                    }
                    else
                    {
                        this.cbgu.Checked = false;
                    }
                    if (drug["lunacy_flag"].ToString() == "1")
                    {
                        this.cbjs.Checked = true;
                    }
                    else
                    {
                        this.cbjs.Checked = false;
                    }

                }
            }
            else
            {
                return;
            }

        }
        #endregion

        private void dtgrdLong_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
       
        //修改录入时间
        private void dtgrdLong_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_DataGridViewEx != null && _DataGridViewEx.CurrentCell != null)
            {
                int rowindex = _DataGridViewEx.CurrentCell.RowIndex;
                int colindex = _DataGridViewEx.CurrentCell.ColumnIndex;
                if (colindex != 0)
                {
                    return;
                }
                if (IsNotCanUse())
                {
                    return;
                }
                DataTable dt = (DataTable)_DataGridViewEx.DataSource;
                if (Convert.ToInt32(dt.Rows[rowindex]["status_falg"].ToString().Trim()) > 1)
                {
                    MessageBox.Show("该医嘱已执行，不能修改录入时间");
                    return;
                }
                if (dt.Rows[rowindex]["begintime"].ToString() == "0001-1-1 0:00:00")
                {
                    return;
                }

                if (dt.Rows[rowindex]["order_content"].ToString() == "")
                {
                    return;
                }
                Frmtime ftime = new Frmtime();
                ftime.ShowDialog();
                DateTime btime = ftime.dtime;
                if (btime.ToString() != "0001-1-1 0:00:00")
                {
                    dt.Rows[rowindex]["begintime"] = ftime.dtime;
                    int end = Controller.GetGroupBeginRow(dt, rowindex);
                    for (int i = rowindex; i < end; i++)
                    {
                        dt.Rows[i]["begintime"] = ftime.dtime;
                        //dt.Rows[i]["order_bdate"] = ftime.dtime;
                        if (dt.Rows[i]["orecord_a2"].ToString().Trim() == "1")
                        {
                            dt.Rows[i]["orecord_a2"] = 2;
                            dt.Rows[i]["status_falg"] = -1;
                        }
                    }
                    Controller.ColorPaint(dt);
                }
            }
        }
        #endregion

        #region 方法
        public  void AddRow(GWI.HIS.Windows.Controls.DataGridViewEx dgv, int sign)
        {
            dgv.Focus();
            int rowid = Controller.AddRow(OrderKind, sign);
            _rowIndex = rowid;
        }

        #region 是否存在未保存的长嘱
        public bool IsExistNotSaveLong()
        {
            if (this.dtgrdLong == null || this.dtgrdLong.DataSource == null)
            {
                return false;
            }
            DataTable dt = (DataTable)this.dtgrdLong.DataSource;
            if (dt == null || dt.Rows.Count == 0)
            {
               
                return false;
            }
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (Convert.ToInt32(dt.Rows[i]["status_falg"].ToString().Trim()) == -1)
                {
                    
                    return true;
                }
            }
           
            return false;
        }
        #endregion

        #region 是否存在未保存的临嘱
        public bool IsExistNotSaveTemp()
        {
            if (this.dtgrdTemp == null || this.dtgrdTemp.Rows.Count == 0)
            {
                return false;
            }
            DataTable dt = (DataTable)this.dtgrdTemp.DataSource;
            if (dt == null || dt.Rows.Count == 0)
            {
                return false;

            }
            else
            {
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Convert.ToInt32(dt.Rows[i]["status_falg"].ToString().Trim()) == -1)
                    {
                        return true;
                        break;
                    }
                }
            }

            return false;

        }
        #endregion

        #region 是否存在未发送的医嘱
        public bool IsExistNotSend()
        {
            //DataTable dt = (DataTable)this._DataGridViewEx.DataSource;
            //if (dt == null || dt.Rows.Count == 0)
            //{
            //    notSend= false;
            //    return false;
            //} 

            notSend = HIS.ZYDoc_BLL.OP_OrderManager.IsNotSend(_zypatlist.PatListID, 0);
            return notSend;
        }
        #endregion

        private void SetPlace()
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0)
            {
                return;
            }
            else
            {
                _DataGridViewEx.CurrentCell=_DataGridViewEx[2,_DataGridViewEx.Rows.Count-1];
            }
        }
        private bool IsNotCanUse()
        {
            if (HIS.ZYDoc_BLL.OP_OrderManager.pattype(_zypatlist.PatListID) || HIS.ZYDoc_BLL.OP_OrderManager.IsTrans(_zypatlist.PatListID))
            {
                MessageBox.Show("已对该病人定义出院，不能修改医嘱");
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 右键事件
        //刷新选项卡
        private void 刷新选项卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = PublicStaticFun.WaitCursor();
            Controller.LoadINFO();
            this.Cursor = Cursors.Default;
            this.SetPlace();
        }  
        //右键插入一行
        private void 插入一行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_DataGridViewEx==null || _DataGridViewEx.Rows.Count == 0)
            {
                return;
            }
            if (IsNotCanUse())
            {
                return;
            }
            int currentRow = _DataGridViewEx.CurrentCell.RowIndex;
            DataTable tb = new DataTable();
            if (OrderKind == 0)
            {
                tb = this.BindLongOrderData;
            }
            if (OrderKind == 1)
            {
                tb = this.BindTempOrderData;
            }
            if (OrderKind == 6)
            {
                tb = this.BindOprationOrderData;
            }
            if (Convert.ToInt32(tb.Rows[currentRow]["status_falg"].ToString().Trim()) > 0 )
            {
                MessageBox.Show("该医嘱已发送，不能插入一行");
                return;
            }
            if (Convert.ToInt32(tb.Rows[currentRow]["item_type"].ToString().Trim()) > 3)
            {
                return;
            }
             int order_type;
             if (Convert.ToInt32(tb.Rows[currentRow]["status_falg"].ToString().Trim()) == -1 && Controller.IsGroupFirstRow(tb, currentRow))
             {
                 AddRow(this._DataGridViewEx, 1);

                 for (int i = 0; i < _DataGridViewEx.Controls.Count; i++)
                 {
                     if (_DataGridViewEx.Controls[i].GetType().ToString() == "System.Windows.Forms.HScrollBar")
                     {
                         HScrollBar scrollbar = (System.Windows.Forms.HScrollBar)this._DataGridViewEx.Controls[i];
                         scrollbar.Value = 0;
                         break;
                     }
                 }

                 _DataGridViewEx.CurrentCell = this._DataGridViewEx[0, _rowIndex];
                 _DataGridViewEx.CurrentCell = this._DataGridViewEx[2, _rowIndex];
                 return;
             }

             else
             {

                 if (tb.Rows[currentRow]["order_content"].ToString().Trim() != "")
                 {
                     // int groupid =Convert.ToInt32( tb.Rows[currentRow]["group_id"].ToString().Trim());
                     order_type = Convert.ToInt32(tb.Rows[currentRow]["item_type"].ToString().Trim());
                     DataTable tb1 = tb.Copy();
                     tb1.Rows.Clear();
                     for (int i = 0; i <= currentRow; i++)
                     {
                         tb1.Rows.Add(tb.Rows[i].ItemArray);
                     }
                     DataRow dr = tb1.NewRow();
                     dr["status_falg"] = -1;
                     dr["begintime"] = Convert.ToDateTime("0001-1-1 0:00:00");
                     dr["orecord_a1"] = 1;//标志。表示是右键新插入的行   
                     dr["orecord_a2"] = 0;
                     dr["makedicid"] = 0;
                     tb1.Rows.Add(dr);
                     for (int i = currentRow + 1; i < tb.Rows.Count; i++)
                     {
                         tb1.Rows.Add(tb.Rows[i].ItemArray);
                     }
                     if (OrderKind == 0)
                     {
                         this.BindLongOrderData = null;
                         this.BindLongOrderData = tb1;
                     }
                     if (OrderKind == 1)
                     {
                         this.BindTempOrderData = null;
                         this.BindTempOrderData = tb1;
                     }
                     if (OrderKind == 0) //长期
                     {
                         if (order_type == 1 || order_type == 2)
                         {
                             //this.SetItem(1, 0);
                             Controller.getData(0);
                         }
                         if (order_type == 4 || order_type == 6)
                         {
                            // this.SetItem(2, 0);
                             Controller.getData(5);
                         }
                     }
                     else
                     {
                         if (order_type == 1 || order_type == 2)
                         {
                            // this.SetItem(1, OrderKind);
                             Controller.getData(0);
                         }
                         if (order_type == 3)
                         {
                             //this.SetItem(2, OrderKind);
                             Controller.getData(1);
                         }
                         if (order_type > 3)
                         {
                             Controller.getData(2);
                             //this.SetItem(3, OrderKind);
                         }
                     }
                     _DataGridViewEx.CurrentCell = _DataGridViewEx[2, currentRow + 1];

                     Controller.ColorPaint(tb1);
                 }
             }
        

        }
        //删除一行
        private void 删除当前行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || _DataGridViewEx.CurrentCell == null)
            {
                return;
            }
           
            if (_DataGridViewEx.CurrentCell != null)
            {
               
                int _rowindex = _DataGridViewEx.CurrentCell.RowIndex;
                if (_rowindex >= _DataGridViewEx.Rows.Count)
                {
                    return;
                }
                DataTable dt = (DataTable)_DataGridViewEx.DataSource;
              
                Controller.DelOrder(_rowindex, OrderKind, 0);
                this.SetPlace();
            }
        }
        //删除一组
        private void 删除一组ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || _DataGridViewEx.CurrentCell == null)
            {
                return;
            }
           
            if (_DataGridViewEx.CurrentCell != null && _DataGridViewEx.Rows.Count>0)
            {
               
                int _rowindex = _DataGridViewEx.CurrentCell.RowIndex;
                if (_rowindex >= _DataGridViewEx.Rows.Count)
                {
                    return;
                }
                DataTable dt = (DataTable)_DataGridViewEx.DataSource;
                string flag = dt.Rows[_rowindex]["status_falg"].ToString(); 
               Controller.DelOrder(_rowindex, OrderKind, 1);
               this.SetPlace();
            }
        }
        //增加皮试　
        private void 增加皮试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || _DataGridViewEx.CurrentCell == null)
            {
                return;
            }
            if (IsNotCanUse())
            {
                return;
            }
            DataTable myTb = (DataTable)_DataGridViewEx.DataSource;
            int nrow, ncol;
            nrow = _DataGridViewEx.CurrentCell.RowIndex;
            ncol = _DataGridViewEx.CurrentCell.ColumnIndex;
            Controller.OnInsertPS(myTb, nrow, OrderKind);
        }
        //医嘱复制
        private void 医嘱复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (_DataGridViewEx.MultiSelect == false)
            //{
            //    MessageBox.Show("复制医嘱前请按shift键选择需要复制的医嘱!");
            //    return;

            //}
            //if (_DataGridViewEx != null && _DataGridViewEx.SelectedRows != null)
            //{

            //    for (int i = 0; i < _DataGridViewEx.Rows.Count; i++)
            //    {
            //        int beginNum = 0;
            //        int endNum = 0;

            //        if (_DataGridViewEx.Rows[i].Selected)
            //        {
            //            Controller.Copy((DataTable)_DataGridViewEx.DataSource, i);
            //        }
            //    }

            //}
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || _DataGridViewEx.CurrentCell == null)
            {
                
                return;
            }
            if (IsNotCanUse())
            {
                this.SetPlace();
                return;
            }
            Controller.Copy((DataTable)_DataGridViewEx.DataSource, _DataGridViewEx.CurrentCell.RowIndex);
            this.SetPlace(); 

        }
        //作废医嘱
        private void 作废医嘱ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0 || _DataGridViewEx.CurrentCell == null)
            {
                return;
            }
            if (IsNotCanUse())
            {
                return;
            }
            if (OrderKind != 1)
            {
                MessageBox.Show("只有临时医嘱可以作废");
                return;
            }
            int nrow, ncol;
            //首先得到当前网格的信息
            DataTable myTb = ((DataTable)_DataGridViewEx.DataSource);
            nrow =_DataGridViewEx.CurrentCell.RowIndex;
            ncol = _DataGridViewEx.CurrentCell.ColumnIndex;
            if (myTb.Rows[nrow]["order_content"].ToString() == "")
            {
                return;
            }
            if (myTb.Rows[nrow]["status_falg"].ToString() != "5")
            {
                if (Convert.ToInt32(myTb.Rows[nrow]["status_falg"].ToString()) > 1)
                {
                    MessageBox.Show("该医嘱已执行，不能删除");
                    return;
                }
                if (myTb.Rows[nrow]["status_falg"].ToString() == "-1"|| myTb.Rows[nrow]["status_falg"].ToString() == "0" || myTb.Rows[nrow]["status_falg"].ToString() == "1")
                {
                   
                    Controller.DelOrder(nrow, OrderKind, 0);
                }
                return;
            }
            try
            {
                if (myTb.Rows[nrow]["order_content"].ToString().IndexOf("【作废】") == 0)
                {
                    MessageBox.Show("该医嘱已经作废！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("是否作废“" + myTb.Rows[nrow]["order_content"].ToString().Trim() + "”？", "作废提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                } 
              
                if (Controller.Abolish(nrow, myTb))
                {
      
                    MessageBox.Show("医嘱作废成功！\n已记帐的费用请护士冲正。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Controller.getOrderData(OrderKind);
                }
                
            }
            catch (System.Exception err)
            {
                MessageBox.Show("医嘱作废失败！\n" + err.ToString(), "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        #endregion    

        #region 颜色表示状态提示
        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            this.PlExplain.Top = this.panel3.Top;
            this.PlExplain.Visible = true;
        }
        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            this.PlExplain.Visible = false;
        }
        #endregion

        private void dtgrdLong_Paint(object sender, PaintEventArgs e)
        {
            if (_DataGridViewEx == null || _DataGridViewEx.Rows.Count == 0)
            {
                return;
            }
            Pen pen = new Pen(Color.Black, 1);//组线画笔
            int x1, y1, x2, y2, y3, y4;//y1为组头横线位置，y2为组线底位置，y3为组线顶位置，y4为组尾横线位置
            x1 = y1 = x2 = y2 = 0;
            DataTable dt = (DataTable)_DataGridViewEx.DataSource;
            for (int i = 0; i < _DataGridViewEx.Rows.Count; i++)
            {
                int beginNum = 0;
                int endNum = 0;
                Controller.findz(i, dt, ref beginNum, ref endNum);
                if (beginNum != endNum)
                {
                    for (int j = beginNum; j < endNum + 1; j++)
                    {
                        x1 = _DataGridViewEx.GetCellDisplayRectangle(1, j, false).Left + _DataGridViewEx.GetCellDisplayRectangle(1, j, false).Width * 2 / 3;
                        x2 = _DataGridViewEx.GetCellDisplayRectangle(1, j, false).Right;
                        y1 = _DataGridViewEx.GetCellDisplayRectangle(1, j, false).Top + _DataGridViewEx.GetCellDisplayRectangle(1, j, false).Height * 1 / 5;
                        y2 = _DataGridViewEx.GetCellDisplayRectangle(1, j, false).Bottom;
                        y3 = _DataGridViewEx.GetCellDisplayRectangle(1, j, false).Top;
                        y4 = _DataGridViewEx.GetCellDisplayRectangle(1, j, false).Bottom - _DataGridViewEx.GetCellDisplayRectangle(1, j, false).Height * 1 / 5;
                        if (j == beginNum)
                        {
                            e.Graphics.DrawLine(pen, x1, y1, x2, y1);
                            e.Graphics.DrawLine(pen, x1, y1, x1, y2);
                        }
                        else if (j == endNum)
                        {
                            e.Graphics.DrawLine(pen, x1, y3, x1, y4);
                            e.Graphics.DrawLine(pen, x1, y4, x2, y4);
                        }
                        else
                        {
                            e.Graphics.DrawLine(pen, x1, y3, x1, y2);
                        }
                    }
                }
                i = endNum;
            }
        }
      
    }
}
