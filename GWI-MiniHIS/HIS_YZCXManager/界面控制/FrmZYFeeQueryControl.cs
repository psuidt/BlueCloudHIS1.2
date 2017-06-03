using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.YZCX_BLL;

namespace HIS_YZCXManager
{
    public class FrmZYFeeQueryControl
    {
        private DataTable _queryItemDt;
        private DataTable _deptFeeDt;
        private DataTable _docFeeDt;
        private DataTable _patFeeDt;
        private IFrmZYFeeQuery _frmzyfeequery; 
        public FrmZYFeeQueryControl(IFrmZYFeeQuery frmzyfeequery)
        {
            _frmzyfeequery = frmzyfeequery;
            _queryItemDt = PublicDataReader.LoadZYFPCode();
            _deptFeeDt = new DataTable();
            _deptFeeDt.Columns.Add("科室名称", System.Type.GetType("System.String"));
            _deptFeeDt.Columns.Add("presdeptcode", System.Type.GetType("System.String"));
            _deptFeeDt.Columns.Add("总收入", System.Type.GetType("System.Decimal"));
            for (int index = 0; index < _queryItemDt.Rows.Count; index++)
            {
                DataRow fpRow = _queryItemDt.Rows[index];
                _deptFeeDt.Columns.Add(fpRow["item_name"].ToString(), Type.GetType("System.Decimal"));             
            }
            _deptFeeDt.PrimaryKey = new DataColumn[] { _deptFeeDt.Columns["presdeptcode"] };
            _docFeeDt = new DataTable();
            _docFeeDt.Columns.Add("医生名称", System.Type.GetType("System.String"));
            _docFeeDt.Columns.Add("presdoccode", System.Type.GetType("System.String"));
            _docFeeDt.Columns.Add("总收入", System.Type.GetType("System.Decimal"));
            for (int index = 0; index < _queryItemDt.Rows.Count; index++)
            {
                DataRow fpRow = _queryItemDt.Rows[index];
                _docFeeDt.Columns.Add(fpRow["item_name"].ToString(), Type.GetType("System.Decimal"));
            }
            _docFeeDt.PrimaryKey = new DataColumn[] { _docFeeDt.Columns["presdoccode"] };
        }
        public void LoadZYFeeDept(DateTime beginDate, DateTime endDate)
        {
            try
            {
                _deptFeeDt.Rows.Clear();
                DataTable orderDeptDt = ZY_Loader.LoadZYDeptFee(beginDate, endDate);
                if (orderDeptDt.Rows.Count > 0)
                {
                    for (int index = 0; index < orderDeptDt.Rows.Count; index++)
                    {
                        DataRow currentRow = orderDeptDt.Rows[index];
                        DataRow findRow = _deptFeeDt.Rows.Find(currentRow["presdeptcode"]);
                        string codeName = currentRow["codename"].ToString();
                        if (findRow == null)
                        {
                            DataRow newRow = _deptFeeDt.NewRow();
                            for (int temp = 0; temp < _queryItemDt.Rows.Count; temp++)
                            {
                                DataRow queryTypeRow = _queryItemDt.Rows[temp];
                                newRow[queryTypeRow["item_name"].ToString()] = 0;
                            }
                            string deptName = currentRow["deptname"].ToString().Trim();
                            newRow["科室名称"] = (deptName == "" ? "未指定" : deptName);
                            newRow["presdeptcode"] = currentRow["presdeptcode"].ToString();
                            newRow["总收入"] = Convert.ToDecimal(currentRow["totalfee"]);
                            newRow[codeName] = Convert.ToDecimal(currentRow["totalfee"]);
                            _deptFeeDt.Rows.Add(newRow);
                        }
                        else
                        {
                            findRow["总收入"] = Convert.ToDecimal(findRow["总收入"]) +
                                Convert.ToDecimal(currentRow["totalfee"]);
                            findRow[codeName] = Convert.ToDecimal(findRow[codeName]) +
                                Convert.ToDecimal(currentRow["totalfee"]);
                        }
                    }
                    DataRow totalRow = _deptFeeDt.NewRow();
                    totalRow["科室名称"] = "合计";
                    totalRow["presdeptcode"] = "";
                    for (int temp = 2; temp < _deptFeeDt.Columns.Count; temp++)
                    {
                        string columnName = _deptFeeDt.Columns[temp].ColumnName;
                        totalRow[columnName] = 0;
                        for (int index = 0; index < _deptFeeDt.Rows.Count; index++)
                        {
                            totalRow[columnName] = Convert.ToDecimal(totalRow[columnName])
                                + Convert.ToDecimal(_deptFeeDt.Rows[index][columnName]);
                        }
                    }                   
                    _deptFeeDt.Rows.Add(totalRow);

                }
                _frmzyfeequery.RefreshDeptFee(_deptFeeDt);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void LoadZYFeeDoc(DateTime beginDate, DateTime endDate, string deptCode)
        {
            try
            {
                _docFeeDt.Rows.Clear();
                DataTable orderDocDt = ZY_Loader.LoadZYDocFee(beginDate, endDate, deptCode);
                if (orderDocDt.Rows.Count > 0)
                {
                    for (int index = 0; index < orderDocDt.Rows.Count; index++)
                    {
                        DataRow currentRow = orderDocDt.Rows[index];
                        string codeName = currentRow["codename"].ToString();
                        DataRow findRow = _docFeeDt.Rows.Find(currentRow["presdoccode"]);
                        if (findRow == null)
                        {
                            DataRow newRow = _docFeeDt.NewRow();
                            for (int temp = 0; temp < _queryItemDt.Rows.Count; temp++)
                            {
                                DataRow queryTypeRow = _queryItemDt.Rows[temp];
                                newRow[queryTypeRow["item_name"].ToString()] = 0;
                            }
                            string docName = currentRow["docname"].ToString().Trim();
                            newRow["医生名称"] = (docName == "" ? "未指定" : docName);
                            newRow["总收入"] = Convert.ToDecimal(currentRow["totalfee"]);
                            newRow["presdoccode"] = currentRow["presdoccode"].ToString();
                            newRow[codeName] = Convert.ToDecimal(currentRow["totalfee"]);
                            _docFeeDt.Rows.Add(newRow);
                        }
                        else
                        {
                            findRow["总收入"] = Convert.ToDecimal(findRow["总收入"]) +
                                Convert.ToDecimal(currentRow["totalfee"]);
                            findRow[codeName] = Convert.ToDecimal(findRow[codeName]) +
                                Convert.ToDecimal(currentRow["totalfee"]);
                        }
                    }
                    DataRow totalRow = _docFeeDt.NewRow();
                   
                    totalRow["医生名称"] = "合计";
                    for (int temp = 1; temp < _docFeeDt.Columns.Count; temp++)
                    {
                        string columnName = _docFeeDt.Columns[temp].ColumnName;
                        totalRow[columnName] = 0;
                        for (int index = 0; index < _docFeeDt.Rows.Count; index++)
                        {
                            totalRow[columnName] = Convert.ToDecimal(totalRow[columnName])
                                + Convert.ToDecimal(_docFeeDt.Rows[index][columnName]);
                        }
                        
                    }
                    totalRow["presdoccode"] = "-1";
                    _docFeeDt.Rows.Add(totalRow);
                }
                _frmzyfeequery.RefreshDocFee(_docFeeDt);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void LoadZYFeePat(DateTime beginDate, DateTime endDate, string docCode, string deptCode)
        {
            try
            {
                _patFeeDt = ZY_Loader.LoadZYPatFee(beginDate, endDate, docCode, deptCode);
                _frmzyfeequery.RefreshPatFee(_patFeeDt);

            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    public interface IFrmZYFeeQuery
    {
        void RefreshDeptFee(DataTable refreshDt);
        void RefreshDocFee(DataTable refreshDt);
        void RefreshPatFee(DataTable refreshDt);
    }
}
