using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.Model;
using HIS.YP_BLL;
using HIS.YP_BLL.PrintCenter;

namespace HIS_YPManager
{
    public class FrmStockControl
    {
        const int NORMAL = 0;
        const int UPDATE = 1;
        private int _currentState;
        private IFrmStockPlan _frmstockplan;
        private BillProcessor _billProcessor;
        private BillQuery _billQuery;
        public YP_PlanMaster _currentMaster = null;
        public YP_PlanOrder _currentOrder = null;
        public DataTable _orderDt;
        private DataTable _masterDt;
        private DataTable _drugInfo;

        public int CurrentState
        {
            set
            {
                _currentState = value;
                _frmstockplan.ChangeCurrentState(_currentState);
                
            }
            get
            {
                return _currentState;
            }
        }
        public FrmStockControl(IFrmStockPlan frmstockplan)
        {
            try
            {
                _frmstockplan = frmstockplan;
                _drugInfo = DrugBaseDataBll.YD_LoadDrugInfo(0, 0);
                _frmstockplan.RefreshDurgInfo(_drugInfo);
                _billProcessor = BillFactory.GetProcessor(ConfigManager.OP_YK_STOCKPLAN);
                _billQuery = BillFactory.GetQuery(ConfigManager.OP_YK_STOCKPLAN);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 构建查询条件列表
        /// </summary>
        private Hashtable BuildConditionParams(DateTime beginTime, DateTime endTime)
        {
            Hashtable parameters = new Hashtable();
            ConditionParam param = new ConditionParam(QueryConditionType.开始时间, beginTime, true);
            parameters.Add(QueryConditionType.开始时间, param);
            param = new ConditionParam(QueryConditionType.结束时间, endTime, true);
            parameters.Add(QueryConditionType.结束时间, param);
            return parameters;
        }
        public void LoadPlanMaster(DateTime beginTime, DateTime endTime)
        {
            try
            {
                if (_masterDt != null)
                {
                    _masterDt.Rows.Clear();
                }
                _masterDt = _billQuery.LoadMaster(BuildConditionParams(beginTime, endTime));
                
                _frmstockplan.RefreshMaster(_masterDt);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void BuildNewBill(long deptId, long userId, bool isBuildByLimit)
        {
            _currentMaster = (YP_PlanMaster)_billProcessor.BuildNewMaster(deptId, userId);
            if (!isBuildByLimit)
            {
                _orderDt = _billQuery.LoadOrder((BillMaster)_currentMaster);
                _frmstockplan.RefreshOrder(_orderDt);
                _currentOrder = (YP_PlanOrder)_billProcessor.BuildNewoder(deptId, _currentMaster);
                if (_orderDt != null)
                {
                    _orderDt.Rows.Clear();
                }
            }
            else
            {
                _currentMaster.PlanMasterId = -1;
                _orderDt = _billQuery.LoadOrder((BillMaster)_currentMaster);
                _currentMaster.PlanMasterId = 0;
                _frmstockplan.RefreshOrder(_orderDt);
                _currentOrder = (YP_PlanOrder)_billProcessor.BuildNewoder(deptId, _currentMaster);
                
            }
            _frmstockplan.ClearAll();
        }

        public void DelteBill(DateTime beginTime, DateTime endTime)
        {
            try
            {
                if (_currentMaster != null && _currentState == NORMAL)
                {
                    _billProcessor.DelBill(_currentMaster);
                    LoadPlanMaster(beginTime, endTime);
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void SaveBill()
        {
            try
            {
                if (_currentMaster != null && _orderDt != null)
                {
                    List<BillOrder> orderList = new List<BillOrder>();
                    for (int index = 0; index < _orderDt.Rows.Count; index++)
                    {
                        YP_PlanOrder order = ChangeDataRowToObj(_orderDt.Rows[index]);
                        orderList.Add(order);
                    }
                    if (_currentMaster.PlanMasterId == 0)
                    {
                        _billProcessor.SaveBill(_currentMaster, orderList, 0);
                    }
                    else
                    {
                        _billProcessor.UpdateBill(_currentMaster, orderList, 0);
                    }
                    _currentState = NORMAL;
                    _frmstockplan.ChangeCurrentState(_currentState);
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void CancelSaveBill()
        {
            _currentState = NORMAL;
            _orderDt.Rows.Clear();
            _frmstockplan.ClearAll();
            _frmstockplan.ChangeCurrentState(_currentState);
        }


        public void GetCurrentOrder(int selectIndex)
        {
            if (_orderDt != null)
            {
                if (_orderDt.Rows.Count > 0 && selectIndex < _orderDt.Rows.Count)
                {
                    DataRow selectRow = _orderDt.Rows[selectIndex];
                    _currentOrder = ChangeDataRowToObj(selectRow);
                    _frmstockplan.ShowCurrentOrder(_currentOrder);
                }
            }
        }

        public void AddOrder()
        {
            if (_currentOrder != null && _orderDt != null)
            {
                if (_currentOrder.MakerDicId == 0)
                {
                    throw new Exception("请选择药品");
                }
                if (_currentOrder.StockNum == 0)
                {
                    throw new Exception("请输入数量");
                }
                DataRow newRow = _orderDt.NewRow();
                ChangeObjToDataRow(newRow);
                _orderDt.Rows.Add(newRow);
                _frmstockplan.ClearAll();
                _currentOrder = (YP_PlanOrder)(_billProcessor.BuildNewoder(0, _currentMaster));
            }
        }

        public void UpdateOrder(int selectIndex)
        {
            if (_currentOrder != null)
            {
                if (_currentOrder.MakerDicId == 0)
                {
                    throw new Exception("请选择药品");
                }
                if (_currentOrder.StockNum == 0)
                {
                    throw new Exception("请输入数量");
                }
                DataRow newRow = _orderDt.Rows[selectIndex];
                ChangeObjToDataRow(newRow);
            }
        }

        public void DeleteOrder(int selectIndex)
        {
            if (_orderDt != null)
            {
                if (_orderDt.Rows.Count > 0 && selectIndex < _orderDt.Rows.Count)
                {
                    _orderDt.Rows.RemoveAt(selectIndex);
                }
            }
        }

        public void GetCurrentMaster(int masterId)
        {
            if (_currentState == NORMAL)
            {
                DataRow[] selectRows = _masterDt.Select("PLANMASTERID=" + masterId);
                if (selectRows.Length > 0)
                {
                    DataRow currentRow = selectRows[0];
                    if (_currentMaster == null)
                    {
                        _currentMaster = new YP_PlanMaster();
                    }
                    _currentMaster.PlanMasterId = masterId;
                    _currentMaster.RegPeople = Convert.ToInt32(currentRow["REGPEOPLE"]);
                    _currentMaster.RegTime = Convert.ToDateTime(currentRow["REGTIME"]);
                    _currentMaster.RetailFee = Convert.ToDecimal(currentRow["RETAILFEE"]);
                    _currentMaster.TradeFee = Convert.ToDecimal(currentRow["TRADEFEE"]);
                    _currentMaster.RegPeopleName = currentRow["REGPEOPLENAME"].ToString();
                    _currentMaster.LASTCHANGTIME = Convert.ToDateTime(currentRow["LASTCHANGTIME"]);           
                    _orderDt = _billQuery.LoadOrder(_currentMaster);
                    _frmstockplan.RefreshOrder(_orderDt);
                    _frmstockplan.RefreshFee(_currentMaster.RetailFee, _currentMaster.TradeFee);
                }
            }
        }

        private void ChangeObjToDataRow(DataRow newRow)
        {
            if (_currentOrder != null)
            {
                newRow["MAKERDICID"] = _currentOrder.MakerDicId;
                newRow["CHEMNAME"] = _currentOrder._orderRemark._chemName;
                newRow["SPEC"] = _currentOrder._orderRemark._drugSpe;
                newRow["PRODUCTNAME"] = _currentOrder._orderRemark._productName;
                newRow["PLANMASTERID"] = _currentOrder.PlanMasterId;
                newRow["PLANORDERID"] = _currentOrder.PlanOrderId;
                newRow["RETAILPRICE"] = _currentOrder.RetailPrice;
                newRow["TRADEPRICE"] = _currentOrder.TradePrice;
                newRow["UNIT"] = _currentOrder.Unit;
                newRow["UNITNAME"] = _currentOrder.UnitName;
                newRow["STOCKNUM"] = _currentOrder.StockNum;
                newRow["RETAILFEE"] = _currentOrder.StockNum * _currentOrder.RetailPrice;
                newRow["TRADEFEE"] = _currentOrder.StockNum * _currentOrder.TradePrice;
            }
        }

        private YP_PlanOrder ChangeDataRowToObj(DataRow newRow)
        {
            YP_PlanOrder planOrder = new YP_PlanOrder();
            planOrder.MakerDicId = Convert.ToInt32(newRow["MAKERDICID"]);
            planOrder._orderRemark._chemName = newRow["CHEMNAME"].ToString();
            planOrder._orderRemark._drugSpe = newRow["SPEC"].ToString();
            planOrder._orderRemark._productName = newRow["PRODUCTNAME"].ToString();
            planOrder.PlanMasterId = Convert.ToInt32(newRow["PLANMASTERID"]);
            planOrder.PlanOrderId = Convert.ToInt32(newRow["PLANORDERID"]);
            planOrder.RetailPrice = Convert.ToDecimal(newRow["RETAILPRICE"]);
            planOrder.TradePrice = Convert.ToDecimal(newRow["TRADEPRICE"]);
            planOrder.Unit = Convert.ToInt32(newRow["UNIT"]);
            planOrder.UnitName = newRow["UNITNAME"].ToString();
            planOrder.TradeFee = Convert.ToDecimal(newRow["TRADEFEE"]);
            planOrder.RetailFee = Convert.ToDecimal(newRow["RETAILFEE"]);
            planOrder.StockNum = Convert.ToDecimal(newRow["STOCKNUM"]);
            return planOrder;
        }

        public void PrintBill(int printer)
        {
            string startPath = System.Windows.Forms.Application.StartupPath + "\\report\\药品采购计划单.grf";
            if (_currentMaster != null)
            {
                YP_Printer billPrinter = PrintFactory.GetPrinter(ConfigManager.OP_YK_STOCKPLAN);
                billPrinter.PrintBill(_currentMaster, null, startPath, printer);
            }
        }

    }

    public interface IFrmStockPlan
    {
        void RefreshMaster(DataTable masterDt);
        void RefreshOrder(DataTable orderDt);
        void ChangeCurrentState(int currentState);
        void ClearAll();
        void ShowCurrentOrder(YP_PlanOrder order);
        void RefreshDurgInfo(DataTable drugInfo);
        void RefreshFee(decimal totalRetailFee, decimal totalTradeFee);
    }
}
