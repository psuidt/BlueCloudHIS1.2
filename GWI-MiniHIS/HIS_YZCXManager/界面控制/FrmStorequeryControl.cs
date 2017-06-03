using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.Model;
using HIS.YZCX_BLL;


namespace HIS_YZCXManager
{
    public class FrmStorequeryControl
    {
        private List<QueryStoreDept> _listDeptStore = new List<QueryStoreDept>();
        private DataTable _totalStore;
        private DataTable _deptSplit;
        private IFrmStoreQuery _formInterface;

        public FrmStorequeryControl(IFrmStoreQuery formInterface)
        {
            _totalStore = new DataTable();
            _totalStore.Columns.Add("MAKERDICID");
            _totalStore.Columns.Add("CHEMNAME");
            _totalStore.Columns.Add("SPEC");
            _totalStore.Columns.Add("PRODUCTNAME");
            _totalStore.Columns.Add("RETAILPRICE", new Decimal().GetType());
            _totalStore.Columns.Add("TRADEPRICE", new Decimal().GetType());
            _totalStore.Columns.Add("RETAILFEE", new Decimal().GetType());
            _totalStore.Columns.Add("TRADEFEE", new Decimal().GetType());
            _totalStore.Columns.Add("PACKUNIT");
            _totalStore.Columns.Add("PACKNUM", new Decimal().GetType());
            _totalStore.Columns.Add("BASENUM", new Int32().GetType());
            _totalStore.PrimaryKey = new DataColumn[]{_totalStore.Columns["MAKERDICID"]};
            _deptSplit = new DataTable();
            _deptSplit.Columns.Add("MAKERDICID");
            _deptSplit.Columns.Add("DEPTNAME");
            _deptSplit.Columns.Add("PACKNUM", new Decimal().GetType());
            _deptSplit.Columns.Add("BASENUM", new Int32().GetType());
            _deptSplit.Columns.Add("DEPTID");
            _deptSplit.Columns.Add("DEPTTYPE");
            _formInterface = formInterface;
        }

        private void GetAllDrugDept()
        {
            try
            {
                List<YP_DeptDic> listDept = YP_Loader.GetAllDrugDept();
                foreach (YP_DeptDic dept in listDept)
                {
                    QueryStoreDept queryDept = new QueryStoreDept();
                    queryDept.DeptDic = dept;
                    _listDeptStore.Add(queryDept);
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void LoadAllDeptStore(string drugType, string queryCode)
        {
            try
            {
                if (_listDeptStore.Count > 0)
                {
                    foreach (QueryStoreDept storeDept in _listDeptStore)
                    {
                        storeDept.StoreDt = YP_Loader.LoadDrugStore(storeDept.DeptDic,
                            drugType,
                            queryCode);
                        if (storeDept.StoreDt != null)
                        {
                            storeDept.StoreDt.PrimaryKey = new DataColumn[]{storeDept.StoreDt.Columns["MAKERDICID"]};
                        }
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void GetDeptSplit(int makerDicID)
        {
            _deptSplit.Rows.Clear();
            if (_listDeptStore != null)
            {
                foreach (QueryStoreDept storeDept in _listDeptStore)
                {
                    DataRow findRow = storeDept.StoreDt.Rows.Find(makerDicID);
                    if (findRow != null)
                    {
                        DataRow newRow = _deptSplit.NewRow();
                        newRow["MAKERDICID"] = findRow["MAKERDICID"];
                        newRow["DEPTNAME"] = storeDept.DeptDic.DeptName;
                        newRow["PACKNUM"] = findRow["PACKNUM"];
                        newRow["BASENUM"] = findRow["BASENUM"];
                        newRow["DEPTTYPE"] = storeDept.DeptDic.DeptType1;
                        newRow["DEPTID"] = storeDept.DeptDic.DeptID;
                        _deptSplit.Rows.Add(newRow);
                    }
                }
            }
            _formInterface.RefreshDeptSplit(_deptSplit);
        }

        private void CombineTotalStore()
        {
            _totalStore.Rows.Clear();
            foreach (QueryStoreDept storeDept in _listDeptStore)
            {
                DataTable storeDt = storeDept.StoreDt;
                DataRow currentRow;
                for (int index = 0; index < storeDt.Rows.Count; index++)
                {
                    currentRow = storeDt.Rows[index];
                    DataRow FindRow = _totalStore.Rows.Find(currentRow["MAKERDICID"]);
                    if (FindRow == null)
                    {
                        DataRow newRow = _totalStore.NewRow();
                        newRow["MAKERDICID"] = currentRow["MAKERDICID"];
                        newRow["CHEMNAME"] = currentRow["CHEMNAME"];
                        newRow["SPEC"] = currentRow["SPEC"];
                        newRow["PRODUCTNAME"] = currentRow["PRODUCTNAME"];
                        newRow["RETAILPRICE"] = currentRow["RETAILPRICE"];
                        newRow["TRADEPRICE"] = currentRow["TRADEPRICE"];
                        newRow["RETAILFEE"] = currentRow["TOTALFEE"];
                        newRow["TRADEFEE"] = currentRow["TRADEFEE"];
                        newRow["PACKUNIT"] = currentRow["PACKUNITNAME"];
                        newRow["PACKNUM"] = currentRow["PACKNUM"];
                        newRow["BASENUM"] = currentRow["BASENUM"];
                        _totalStore.Rows.Add(newRow);
                    }
                    else
                    {
                        FindRow["BASENUM"] = Convert.ToDecimal(FindRow["BASENUM"])
                            + Convert.ToDecimal(currentRow["BASENUM"]);
                        FindRow["PACKNUM"] = Convert.ToDecimal(FindRow["PACKNUM"])
                            + Convert.ToDecimal(currentRow["PACKNUM"]);
                        FindRow["RETAILFEE"] = Convert.ToDecimal(FindRow["RETAILFEE"])
                            + Convert.ToDecimal(currentRow["TOTALFEE"]);
                        FindRow["TRADEFEE"] = Convert.ToDecimal(FindRow["TRADEFEE"])
                            + Convert.ToDecimal(currentRow["TRADEFEE"]);
                    }
                }
            }
        }

        private decimal GetTotalRetailFee()
        {
            decimal totalRetailFee = 0;
            if (_listDeptStore.Count > 0)
            {
                foreach (QueryStoreDept storeDept in _listDeptStore)
                {
                    totalRetailFee += YP_Loader.LoadRetailFee(storeDept.DeptDic);
                }
            }
            return totalRetailFee;
        }

        private decimal GetTotalTradeFee()
        {
            decimal totalTradeFee = 0;
            if (_listDeptStore.Count > 0)
            {
                foreach (QueryStoreDept storeDept in _listDeptStore)
                {
                    totalTradeFee += YP_Loader.LoadTradelFee(storeDept.DeptDic);
                }
            }
            return totalTradeFee;
        }

        public void LoadData(string drugType, string queryCode)
        {
            try
            {
                _listDeptStore.Clear();
                //获取所有药剂科室
                GetAllDrugDept();
                //加载各科室库存信息
                LoadAllDeptStore(drugType, queryCode);
                //合并库存量以及金额
                CombineTotalStore();
                _formInterface.RefreshStoreInfo(_totalStore);
                _formInterface.RefreshFee(GetTotalRetailFee(), GetTotalTradeFee());
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    public interface IFrmStoreQuery
    {
         void RefreshStoreInfo(DataTable totalStoreDt);
         void RefreshDeptSplit(DataTable deptSplit);
         void RefreshFee(decimal retailFee, decimal tradeFee);
    }
}
