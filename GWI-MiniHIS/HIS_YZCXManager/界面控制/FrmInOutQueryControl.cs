using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using HIS.YZCX_BLL;
using HIS.Model;

namespace HIS_YZCXManager
{
    struct TypeFee
    {
        public string TradeFeeName;
        public string RetailFeeName;
    }
    public class FrmInOutQueryControl
    {
        private DataTable _inStoreInfo;
        private DataTable _outStoreInfo;
        private DataTable _totalInStoreInfo;
        private DataTable _totalOutStoreInfo;
        private decimal _totalInRetailFee;
        private decimal _totalInStockFee;
        private decimal _totalOutRetailFee;
        private decimal _totalOutTradeFee;
        private IFrmInOutQuery _frmInOutQuery;
        private Hashtable _typeName = new Hashtable();
        private DataTable _deptDt;
        private string _queryType;
        private PrintCondition _printCondition = new PrintCondition();

        public PrintCondition PrintCondition
        {
            get 
            { 
                return _printCondition; 
            }
            set
            { 
                _printCondition = value; 
            }
        }

        public FrmInOutQueryControl(IFrmInOutQuery frmInOutQuery)
        {
            
            _frmInOutQuery = frmInOutQuery;
            _totalInStoreInfo = new DataTable();
            _totalInStoreInfo.Columns.Add("PRJNAME");
            _totalInStoreInfo.Columns.Add("PRJID", new Int32().GetType());
            _totalInStoreInfo.Columns.Add("RETAILFEE", new Decimal().GetType());
            _totalInStoreInfo.Columns.Add("XYRETAILFEE", new Decimal().GetType());
            _totalInStoreInfo.Columns.Add("ZYRETAILFEE", new Decimal().GetType());
            _totalInStoreInfo.Columns.Add("ZCYRETAILFEE", new Decimal().GetType());
            _totalInStoreInfo.Columns.Add("WZRETAILFEE", new Decimal().GetType());
            _totalInStoreInfo.Columns.Add("TRADEFEE", new Decimal().GetType());
            _totalInStoreInfo.Columns.Add("XYTRADEFEE", new Decimal().GetType());
            _totalInStoreInfo.Columns.Add("ZYTRADEFEE", new Decimal().GetType());
            _totalInStoreInfo.Columns.Add("ZCYTRADEFEE", new Decimal().GetType());
            _totalInStoreInfo.Columns.Add("WZTRADEFEE", new Decimal().GetType());
            _totalOutStoreInfo = _totalInStoreInfo.Clone();
            TypeFee typeFee = new TypeFee();
            typeFee.RetailFeeName = "XYRETAILFEE";
            typeFee.TradeFeeName = "XYTRADEFEE";
            _typeName.Add(1, typeFee);
            typeFee = new TypeFee();
            typeFee.RetailFeeName = "ZCYRETAILFEE";
            typeFee.TradeFeeName = "ZCYTRADEFEE";
            _typeName.Add(2, typeFee);
            typeFee = new TypeFee();
            typeFee.RetailFeeName = "ZYRETAILFEE";
            typeFee.TradeFeeName = "ZYTRADEFEE";
            _typeName.Add(3, typeFee);
            typeFee = new TypeFee();
            typeFee.RetailFeeName = "WZRETAILFEE";
            typeFee.TradeFeeName = "WZTRADEFEE";
            _typeName.Add(4, typeFee);
            _totalInStoreInfo.PrimaryKey = new DataColumn[] { _totalInStoreInfo.Columns["PRJID"] };
            _totalOutStoreInfo.PrimaryKey = new DataColumn[] { _totalOutStoreInfo.Columns["PRJID"] };
            _deptDt = YP_Loader.GetYKDept();
            _frmInOutQuery.AddDrugDept(_deptDt);
        }

        public void LoadInMasterData(DateTime beginDate, DateTime endDate, int deptId, string getType, string opType)
        {
            try
            {
                _queryType = getType;
                _totalInRetailFee = 0;
                _totalInStockFee = 0;
                _totalInStoreInfo.Rows.Clear();
                _inStoreInfo = YP_Loader.LoadInStoreInfo(beginDate, endDate, deptId, opType);
                GetTotalInStoreInfo(_queryType);
                _frmInOutQuery.RefreshInMaster(_totalInStoreInfo);
                _frmInOutQuery.SetTotalFee(_totalInRetailFee, _totalInStockFee);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void LoadOutMasterData(DateTime beginDate, DateTime endDate, int deptId, string opType)
        {
            try
            {
                _totalOutRetailFee = 0;
                _totalOutTradeFee = 0;
                _totalOutStoreInfo.Rows.Clear();
                _outStoreInfo = YP_Loader.LoadOutStoreInfo(beginDate, endDate, deptId, opType);
                GetTotalOutStoreInfo(opType);
                _frmInOutQuery.RefreshOutMaster(_totalOutStoreInfo);
                _frmInOutQuery.SetTotalFee(_totalOutRetailFee, _totalOutTradeFee);

            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private DataTable CollectOrdersByID(DataTable orderDt)
        {
            try
            {
                if (orderDt != null)
                {
                    DataTable totalDt = orderDt.Clone();
                    totalDt.PrimaryKey = new DataColumn[] { totalDt.Columns["MAKERDICID"] };
                    for (int index = 0; index < orderDt.Rows.Count; index++)
                    {
                        DataRow currentRow = orderDt.Rows[index];
                        DataRow findRow = totalDt.Rows.Find(Convert.ToInt32(currentRow["MAKERDICID"]));
                        if (findRow == null)
                        {
                            totalDt.Rows.Add(currentRow.ItemArray);
                        }
                        else
                        {
                            findRow["NUM"] = Convert.ToDecimal(findRow["NUM"]) + Convert.ToDecimal(currentRow["NUM"]);
                            findRow["RETAILFEE"] = Convert.ToDecimal(findRow["RETAILFEE"]) + Convert.ToDecimal(currentRow["RETAILFEE"]);
                            findRow["TRADEFEE"] = Convert.ToDecimal(findRow["TRADEFEE"]) + Convert.ToDecimal(currentRow["TRADEFEE"]);
                            findRow["STOCKFEE"] = Convert.ToDecimal(findRow["STOCKFEE"]) + Convert.ToDecimal(currentRow["STOCKFEE"]);
                        }
                    }
                    totalDt.Columns.Remove("REGTIME");
                    return totalDt;
                }
                else
                    return null;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void LoadOutOrderData(int prjId, bool isCollect)
        {
            try
            {
                DataTable orderDt = _outStoreInfo.Clone();
                if (prjId <= 0)
                {
                    orderDt = _outStoreInfo;
                    if (isCollect)
                        orderDt = CollectOrdersByID(orderDt);
                    _frmInOutQuery.RefreshOutOrder(orderDt);
                    return;
                }
                DataRow[] selectRows = this._outStoreInfo.Select("OUTDEPTID=" + prjId);
                foreach (DataRow dr in selectRows)
                {
                    orderDt.Rows.Add(dr.ItemArray);
                }
                if (isCollect)
                    orderDt = CollectOrdersByID(orderDt);
                _frmInOutQuery.RefreshOutOrder(orderDt);
            }
            catch (Exception error)
            {
                throw error;
            }
        }


        public void LoadInOrderData(int prjId, bool isCollect)
        {
            try
            {
                DataTable orderDt = _inStoreInfo.Clone();
                DataRow[] selectRows;
                if (prjId <= 0)
                {
                    orderDt = _inStoreInfo;
                    if (isCollect)
                        orderDt = CollectOrdersByID(orderDt);
                    _frmInOutQuery.RefreshInOrder(orderDt);
                    return;
                }
                switch (_queryType)
                {
                    case "生产厂家":
                        selectRows = this._inStoreInfo.Select("PRODUCTID=" + prjId);
                        foreach (DataRow dr in selectRows)
                        {
                            orderDt.Rows.Add(dr.ItemArray);
                        }
                        if (isCollect)
                            orderDt = CollectOrdersByID(orderDt);
                        _frmInOutQuery.RefreshInOrder(orderDt);
                        break;
                    case "供应商":
                        selectRows = this._inStoreInfo.Select("SUPPORTDICID=" + prjId);
                        foreach (DataRow dr in selectRows)
                        {
                            orderDt.Rows.Add(dr.ItemArray);
                        }
                        if (isCollect)
                            orderDt = CollectOrdersByID(orderDt);
                        _frmInOutQuery.RefreshInOrder(orderDt);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 汇总明细金额生成汇总表
        /// </summary>
        public void GetTotalOutStoreInfo(string opType)
        {
            try
            {
                if (_outStoreInfo == null)
                {
                    return;
                }
                DataRow eachRow;
                //构建汇总表结构，插入统计项目名称和ID
                if (opType == "报损出库")
                {
                    DataRow newRow = _totalOutStoreInfo.NewRow();
                    newRow["PRJID"] = 0;
                    newRow["PRJNAME"] = "药库报损出库";
                    newRow["XYRETAILFEE"] = 0;
                    newRow["ZCYRETAILFEE"] = 0;
                    newRow["ZYRETAILFEE"] = 0;
                    newRow["WZRETAILFEE"] = 0;
                    newRow["XYTRADEFEE"] = 0;
                    newRow["ZCYTRADEFEE"] = 0;
                    newRow["ZYTRADEFEE"] = 0;
                    newRow["WZTRADEFEE"] = 0;
                    for (int index = 0; index < _outStoreInfo.Rows.Count; index++)
                    {
                        eachRow = _outStoreInfo.Rows[index];
                        _totalOutTradeFee += Convert.ToDecimal(eachRow["TRADEFEE"]);
                        string columnName = ((TypeFee)(_typeName[Convert.ToInt32(eachRow["TYPEDICID"])])).RetailFeeName;
                        newRow[columnName] = Convert.ToDecimal(newRow[columnName])
                            + Convert.ToDecimal(eachRow["RETAILFEE"]);
                        columnName = ((TypeFee)(_typeName[Convert.ToInt32(eachRow["TYPEDICID"])])).TradeFeeName;
                        newRow[columnName] = Convert.ToDecimal(newRow[columnName])
                            + Convert.ToDecimal(eachRow["TRADEFEE"]);
                    }
                    _totalOutStoreInfo.Rows.Add(newRow);
                }
                else
                {
                    for (int index = 0; index < _outStoreInfo.Rows.Count; index++)
                    {
                        eachRow = _outStoreInfo.Rows[index];
                        _totalOutTradeFee += Convert.ToDecimal(eachRow["TRADEFEE"]);
                        DataRow findRow = _totalOutStoreInfo.Rows.Find(eachRow["OUTDEPTID"]);
                        if (findRow == null)
                        {
                            DataRow newRow = _totalOutStoreInfo.NewRow();
                            newRow["PRJID"] = Convert.ToInt32(eachRow["OUTDEPTID"]);
                            newRow["PRJNAME"] = eachRow["DEPTNAME"].ToString();
                            newRow["XYRETAILFEE"] = 0;
                            newRow["ZCYRETAILFEE"] = 0;
                            newRow["ZYRETAILFEE"] = 0;
                            newRow["WZRETAILFEE"] = 0;
                            newRow["XYTRADEFEE"] = 0;
                            newRow["ZCYTRADEFEE"] = 0;
                            newRow["ZYTRADEFEE"] = 0;
                            newRow["WZTRADEFEE"] = 0;
                            string columnName = ((TypeFee)(_typeName[Convert.ToInt32(eachRow["TYPEDICID"])])).RetailFeeName;
                            newRow[columnName] = Convert.ToDecimal(eachRow["RETAILFEE"]);
                            columnName = ((TypeFee)(_typeName[Convert.ToInt32(eachRow["TYPEDICID"])])).TradeFeeName;
                            newRow[columnName] = Convert.ToDecimal(eachRow["TRADEFEE"]);
                            _totalOutStoreInfo.Rows.Add(newRow);
                        }
                        else
                        {
                            string columnName = ((TypeFee)(_typeName[Convert.ToInt32(eachRow["TYPEDICID"])])).RetailFeeName;
                            findRow[columnName] = Convert.ToDecimal(findRow[columnName]) + Convert.ToDecimal(eachRow["RETAILFEE"]);
                            columnName = ((TypeFee)(_typeName[Convert.ToInt32(eachRow["TYPEDICID"])])).TradeFeeName;
                            findRow[columnName] = Convert.ToDecimal(findRow[columnName]) + Convert.ToDecimal(eachRow["TRADEFEE"]);

                        }
                    }
                }
                //合计汇总表金额
                DataRow endRow = _totalOutStoreInfo.NewRow();
                endRow["PRJNAME"] = "合计";
                endRow["PRJID"] = -1;
                endRow["XYRETAILFEE"] = 0;
                endRow["ZCYRETAILFEE"] = 0;
                endRow["ZYRETAILFEE"] = 0;
                endRow["WZRETAILFEE"] = 0;
                endRow["RETAILFEE"] = 0;
                endRow["XYTRADEFEE"] = 0;
                endRow["ZCYTRADEFEE"] = 0;
                endRow["ZYTRADEFEE"] = 0;
                endRow["WZTRADEFEE"] = 0;
                endRow["TRADEFEE"] = 0;
                for (int index = 0; index < _totalOutStoreInfo.Rows.Count; index++)
                {
                    _totalOutStoreInfo.Rows[index]["RETAILFEE"] = Convert.ToDecimal(_totalOutStoreInfo.Rows[index]["XYRETAILFEE"])
                        + Convert.ToDecimal(_totalOutStoreInfo.Rows[index]["ZCYRETAILFEE"])
                        + Convert.ToDecimal(_totalOutStoreInfo.Rows[index]["ZYRETAILFEE"])
                        + Convert.ToDecimal(_totalOutStoreInfo.Rows[index]["WZRETAILFEE"]);
                    _totalOutStoreInfo.Rows[index]["TRADEFEE"] = Convert.ToDecimal(_totalOutStoreInfo.Rows[index]["XYTRADEFEE"])
                        + Convert.ToDecimal(_totalOutStoreInfo.Rows[index]["ZCYTRADEFEE"])
                        + Convert.ToDecimal(_totalOutStoreInfo.Rows[index]["ZYTRADEFEE"])
                        + Convert.ToDecimal(_totalOutStoreInfo.Rows[index]["WZTRADEFEE"]);
                    endRow["XYRETAILFEE"] = Convert.ToDecimal(_totalOutStoreInfo.Rows[index]["XYRETAILFEE"])
                        + Convert.ToDecimal(endRow["XYRETAILFEE"]);
                    endRow["ZCYRETAILFEE"] = Convert.ToDecimal(_totalOutStoreInfo.Rows[index]["ZCYRETAILFEE"])
                        + Convert.ToDecimal(endRow["ZCYRETAILFEE"]);
                    endRow["ZYRETAILFEE"] = Convert.ToDecimal(_totalOutStoreInfo.Rows[index]["ZYRETAILFEE"])
                        + Convert.ToDecimal(endRow["ZYRETAILFEE"]);
                    endRow["WZRETAILFEE"] = Convert.ToDecimal(_totalOutStoreInfo.Rows[index]["WZRETAILFEE"])
                        + Convert.ToDecimal(endRow["WZRETAILFEE"]);
                    endRow["RETAILFEE"] = Convert.ToDecimal(_totalOutStoreInfo.Rows[index]["RETAILFEE"])
                        + Convert.ToDecimal(endRow["RETAILFEE"]);
                    endRow["XYTRADEFEE"] = Convert.ToDecimal(_totalOutStoreInfo.Rows[index]["XYTRADEFEE"])
                        + Convert.ToDecimal(endRow["XYTRADEFEE"]);
                    endRow["ZCYTRADEFEE"] = Convert.ToDecimal(_totalOutStoreInfo.Rows[index]["ZCYTRADEFEE"])
                        + Convert.ToDecimal(endRow["ZCYTRADEFEE"]);
                    endRow["ZYTRADEFEE"] = Convert.ToDecimal(_totalOutStoreInfo.Rows[index]["ZYTRADEFEE"])
                        + Convert.ToDecimal(endRow["ZYTRADEFEE"]);
                    endRow["WZTRADEFEE"] = Convert.ToDecimal(_totalOutStoreInfo.Rows[index]["WZTRADEFEE"])
                        + Convert.ToDecimal(endRow["WZTRADEFEE"]);
                    endRow["TRADEFEE"] = Convert.ToDecimal(_totalOutStoreInfo.Rows[index]["TRADEFEE"])
                        + Convert.ToDecimal(endRow["TRADEFEE"]);
                    
                }
                _totalOutRetailFee += (Convert.ToDecimal(endRow["XYRETAILFEE"]) +
                    Convert.ToDecimal(endRow["ZCYRETAILFEE"]) +
                    Convert.ToDecimal(endRow["ZYRETAILFEE"]) +
                    Convert.ToDecimal(endRow["WZRETAILFEE"]));
                _totalOutStoreInfo.Rows.Add(endRow);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 汇总入库金额生成汇总表
        /// </summary>
        /// <param name="getType">统计类型</param>
        public void GetTotalInStoreInfo(string getType)
        {
            try
            {
                if (_inStoreInfo == null)
                {
                    return;
                }
                DataRow eachRow;
                string columnName = "";
                switch (getType)
                {
                    case "生产厂家":
                        //构建汇总表结构，插入统计项目名称和ID
                        for (int index = 0; index < _inStoreInfo.Rows.Count; index++)
                        {
                            eachRow = _inStoreInfo.Rows[index];
                            _totalInStockFee += Convert.ToDecimal(eachRow["TRADEFEE"]);
                            DataRow findRow = _totalInStoreInfo.Rows.Find(eachRow["PRODUCTID"]);
                            if (findRow == null)
                            {
                                DataRow newRow = _totalInStoreInfo.NewRow();
                                newRow["PRJID"] = Convert.ToInt32(eachRow["PRODUCTID"]);
                                newRow["PRJNAME"] = eachRow["PRODUCTNAME"].ToString();                              
                                newRow["XYRETAILFEE"] = 0;
                                newRow["ZCYRETAILFEE"] = 0;
                                newRow["ZYRETAILFEE"] = 0;
                                newRow["WZRETAILFEE"] = 0;
                                newRow["XYTRADEFEE"] = 0;
                                newRow["ZCYTRADEFEE"] = 0;
                                newRow["ZYTRADEFEE"] = 0;
                                newRow["WZTRADEFEE"] = 0;
                                columnName = ((TypeFee)(_typeName[Convert.ToInt32(eachRow["TYPEDICID"])])).RetailFeeName;
                                newRow[columnName] = Convert.ToDecimal(eachRow["RETAILFEE"]);
                                columnName = ((TypeFee)(_typeName[Convert.ToInt32(eachRow["TYPEDICID"])])).TradeFeeName;
                                newRow[columnName] = Convert.ToDecimal(eachRow["TRADEFEE"]);
                                _totalInStoreInfo.Rows.Add(newRow);
                            }
                            else
                            {
                                columnName = ((TypeFee)(_typeName[Convert.ToInt32(eachRow["TYPEDICID"])])).RetailFeeName;
                                findRow[columnName] = Convert.ToDecimal(findRow[columnName]) 
                                    + Convert.ToDecimal(eachRow["RETAILFEE"]);
                                columnName = ((TypeFee)(_typeName[Convert.ToInt32(eachRow["TYPEDICID"])])).TradeFeeName;
                                findRow[columnName] = Convert.ToDecimal(findRow[columnName])
                                    + Convert.ToDecimal(eachRow["TRADEFEE"]);
                            }
                        }
                        break;
                    case "供应商":
                        for (int index = 0; index < _inStoreInfo.Rows.Count; index++)
                        {
                            eachRow = _inStoreInfo.Rows[index];
                            _totalInStockFee += Convert.ToDecimal(eachRow["TRADEFEE"]);
                            DataRow findRow = _totalInStoreInfo.Rows.Find(eachRow["SUPPORTDICID"]);
                            if (findRow == null)
                            {
                                DataRow newRow = _totalInStoreInfo.NewRow();
                                newRow["PRJID"] = Convert.ToInt32(eachRow["SUPPORTDICID"]);
                                newRow["PRJNAME"] = eachRow["NAME"].ToString();
                                newRow["XYRETAILFEE"] = 0;
                                newRow["ZCYRETAILFEE"] = 0;
                                newRow["ZYRETAILFEE"] = 0;
                                newRow["WZRETAILFEE"] = 0;
                                newRow["XYTRADEFEE"] = 0;
                                newRow["ZCYTRADEFEE"] = 0;
                                newRow["ZYTRADEFEE"] = 0;
                                newRow["WZTRADEFEE"] = 0;
                                columnName = ((TypeFee)(_typeName[Convert.ToInt32(eachRow["TYPEDICID"])])).RetailFeeName;
                                newRow[columnName] = Convert.ToDecimal(eachRow["RETAILFEE"]);
                                columnName = ((TypeFee)(_typeName[Convert.ToInt32(eachRow["TYPEDICID"])])).TradeFeeName;
                                newRow[columnName] = Convert.ToDecimal(eachRow["TRADEFEE"]);
                                _totalInStoreInfo.Rows.Add(newRow);
                            }
                            else
                            {
                                columnName = ((TypeFee)(_typeName[Convert.ToInt32(eachRow["TYPEDICID"])])).RetailFeeName;
                                findRow[columnName] = Convert.ToDecimal(findRow[columnName])
                                + Convert.ToDecimal(eachRow["RETAILFEE"]);
                                columnName = ((TypeFee)(_typeName[Convert.ToInt32(eachRow["TYPEDICID"])])).TradeFeeName;
                                findRow[columnName] = Convert.ToDecimal(findRow[columnName])
                                + Convert.ToDecimal(eachRow["TRADEFEE"]);
                            }
                        }
                        break;
                    default:
                        break;
                }
                //合计汇总表金额
                DataRow endRow = _totalInStoreInfo.NewRow();
                endRow["PRJNAME"] = "合计";
                endRow["PRJID"] = 0;
                endRow["XYRETAILFEE"] = 0;
                endRow["ZCYRETAILFEE"] = 0;
                endRow["ZYRETAILFEE"] = 0;
                endRow["WZRETAILFEE"] = 0;
                endRow["RETAILFEE"] = 0;
                endRow["XYTRADEFEE"] = 0;
                endRow["ZCYTRADEFEE"] = 0;
                endRow["ZYTRADEFEE"] = 0;
                endRow["WZTRADEFEE"] = 0;
                endRow["TRADEFEE"] = 0;
                for (int index = 0; index < _totalInStoreInfo.Rows.Count; index++)
                {
                    _totalInStoreInfo.Rows[index]["RETAILFEE"] = Convert.ToDecimal(_totalInStoreInfo.Rows[index]["XYRETAILFEE"])
                        + Convert.ToDecimal(_totalInStoreInfo.Rows[index]["ZCYRETAILFEE"])
                        + Convert.ToDecimal(_totalInStoreInfo.Rows[index]["ZYRETAILFEE"])
                        + Convert.ToDecimal(_totalInStoreInfo.Rows[index]["WZRETAILFEE"]);
                    _totalInStoreInfo.Rows[index]["TRADEFEE"] = Convert.ToDecimal(_totalInStoreInfo.Rows[index]["XYTRADEFEE"])
                        + Convert.ToDecimal(_totalInStoreInfo.Rows[index]["ZCYTRADEFEE"])
                        + Convert.ToDecimal(_totalInStoreInfo.Rows[index]["ZYTRADEFEE"])
                        + Convert.ToDecimal(_totalInStoreInfo.Rows[index]["WZTRADEFEE"]);
                    endRow["XYRETAILFEE"] = Convert.ToDecimal(_totalInStoreInfo.Rows[index]["XYRETAILFEE"])
                        + Convert.ToDecimal(endRow["XYRETAILFEE"]);
                    endRow["ZCYRETAILFEE"] = Convert.ToDecimal(_totalInStoreInfo.Rows[index]["ZCYRETAILFEE"])
                        + Convert.ToDecimal(endRow["ZCYRETAILFEE"]);
                    endRow["ZYRETAILFEE"] = Convert.ToDecimal(_totalInStoreInfo.Rows[index]["ZYRETAILFEE"])
                        + Convert.ToDecimal(endRow["ZYRETAILFEE"]);
                    endRow["WZRETAILFEE"] = Convert.ToDecimal(_totalInStoreInfo.Rows[index]["WZRETAILFEE"])
                        + Convert.ToDecimal(endRow["WZRETAILFEE"]);
                    endRow["RETAILFEE"] = Convert.ToDecimal(_totalInStoreInfo.Rows[index]["RETAILFEE"])
                        + Convert.ToDecimal(endRow["RETAILFEE"]);
                    endRow["XYTRADEFEE"] = Convert.ToDecimal(_totalInStoreInfo.Rows[index]["XYTRADEFEE"])
                        + Convert.ToDecimal(endRow["XYTRADEFEE"]);
                    endRow["ZCYTRADEFEE"] = Convert.ToDecimal(_totalInStoreInfo.Rows[index]["ZCYTRADEFEE"])
                        + Convert.ToDecimal(endRow["ZCYTRADEFEE"]);
                    endRow["ZYTRADEFEE"] = Convert.ToDecimal(_totalInStoreInfo.Rows[index]["ZYTRADEFEE"])
                        + Convert.ToDecimal(endRow["ZYTRADEFEE"]);
                    endRow["WZTRADEFEE"] = Convert.ToDecimal(_totalInStoreInfo.Rows[index]["WZTRADEFEE"])
                        + Convert.ToDecimal(endRow["WZTRADEFEE"]);
                    endRow["TRADEFEE"] = Convert.ToDecimal(_totalInStoreInfo.Rows[index]["TRADEFEE"])
                        + Convert.ToDecimal(endRow["TRADEFEE"]);
                }
                _totalInRetailFee += (Convert.ToDecimal(endRow["XYRETAILFEE"]) + 
                    Convert.ToDecimal(endRow["ZCYRETAILFEE"])+
                    Convert.ToDecimal(endRow["ZYRETAILFEE"]) + 
                    Convert.ToDecimal(endRow["WZRETAILFEE"]));
                _totalInStoreInfo.Rows.Add(endRow);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void PrintReport(string path)
        {
            try
            {
                if (_printCondition.billNo == "0")
                {
                    if (_totalInStoreInfo != null)
                    {
                        if (_totalInStoreInfo.Rows.Count > 0)
                            YP_Printer.PrintTotalInOutStore(path, _printCondition, _totalInStoreInfo);
                    }
                }
                else
                {
                    if (_totalOutStoreInfo != null)
                    {
                        if (_totalOutStoreInfo.Rows.Count > 0)
                            YP_Printer.PrintTotalInOutStore(path, _printCondition, _totalOutStoreInfo);
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    public interface IFrmInOutQuery
    {
        void SetTotalFee(decimal _totalRetailFee, decimal _totalStockFee);
        void RefreshInMaster(DataTable totalInMaster);
        void RefreshOutMaster(DataTable totalOutMaster);
        void RefreshInOrder(DataTable inOrder);
        void RefreshOutOrder(DataTable outOrder);
        void AddDrugDept(DataTable deptDt);
    }

}
