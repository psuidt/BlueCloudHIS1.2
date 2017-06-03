using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.Model;
using HIS.YZCX_BLL;

namespace HIS_YZCXManager
{
    class FrmZYPatfeeQueryControl
    {
        private DataTable _clincDepts;
        private QueryZYPatInfo _currentPat;
        private DataTable _currentPatItemFee;
        private DataTable _currentPatBigItemFee;
        private DataTable _currentPatHSItemFee;
        private DataTable _currentPatPrePayFee;
        private IFrmZYPatfeeQuery _formInterface;

        public FrmZYPatfeeQueryControl(IFrmZYPatfeeQuery frmZYPatfeeQuery)
        {
            _formInterface = frmZYPatfeeQuery;
            _currentPatBigItemFee = new DataTable();
            _currentPatBigItemFee.Columns.Add("PRJCODE");
            _currentPatBigItemFee.Columns.Add("PRJNAME");
            _currentPatBigItemFee.Columns.Add("PRJFEE", new Decimal().GetType());
            _currentPatBigItemFee.PrimaryKey = new DataColumn[] { _currentPatBigItemFee.Columns["PRJCODE"]};
            _currentPatHSItemFee = _currentPatBigItemFee.Clone();

        }

        public void LoadAllClincDept()
        {
            try
            {
                _clincDepts = PublicDataReader.LoadClincDept();
                _formInterface.RefreshClincDept(_clincDepts);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<ZY_PatList> LoadPatBy(bool isInHospital, int deptId)
        {
            try
            {
                return ZY_Loader.LoadZYPat(deptId, isInHospital);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public QueryZYPatInfo CurrentPat
        {
            set
            {
                _currentPat = value;
            }
            get
            {
                return _currentPat;
            }
        }

        public void LoadZYPatFee()
        {
            try
            {
                decimal patTotalFee = 0;
                decimal patPrePayFee = 0;
                if (_currentPat != null)
                {
                    _currentPatHSItemFee.Rows.Clear();
                    _currentPatBigItemFee.Rows.Clear();
                    _currentPatItemFee = ZY_Loader.LoadZYPatFee(_currentPat._zyPatient);
                    _currentPatPrePayFee = ZY_Loader.LoadZYPrePayFee(_currentPat._zyPatient);
                    for (int index = 0; index < _currentPatPrePayFee.Rows.Count; index++)
                    {
                        DataRow prePayFeeRow = _currentPatPrePayFee.Rows[index];
                        patPrePayFee += Convert.ToDecimal(prePayFeeRow["TOTAL_FEE"]);
                    }
                    for (int index = 0; index < _currentPatItemFee.Rows.Count; index++)
                    {

                        DataRow currentRow = _currentPatItemFee.Rows[index];
                        string bigItemCode = currentRow["BIGITEMTYPE"].ToString();
                        string hsCode = currentRow["HSCODE"].ToString();
                        patTotalFee += Convert.ToDecimal(currentRow["TOTAL_FEE"]);
                        DataRow findBigItemRow = _currentPatBigItemFee.Rows.Find(bigItemCode);
                        if (findBigItemRow != null)
                        {
                            findBigItemRow["PRJFEE"] = Convert.ToDecimal(findBigItemRow["PRJFEE"])
                                + Convert.ToDecimal(currentRow["TOTAL_FEE"]);
                        }
                        else
                        {
                            DataRow newRow = _currentPatBigItemFee.NewRow();
                            newRow["PRJCODE"] = currentRow["BIGITEMTYPE"].ToString();
                            newRow["PRJNAME"] = currentRow["BIGITEMNAME"].ToString();
                            newRow["PRJFEE"] = Convert.ToDecimal(currentRow["TOTAL_FEE"]);
                            _currentPatBigItemFee.Rows.Add(newRow);
                        }
                        DataRow findHSItemRow = _currentPatHSItemFee.Rows.Find(hsCode);
                        if (findHSItemRow != null)
                        {
                            findHSItemRow["PRJFEE"] = Convert.ToDecimal(findHSItemRow["PRJFEE"])
                                + Convert.ToDecimal(currentRow["TOTAL_FEE"]);
                        }
                        else
                        {
                            DataRow newRow = _currentPatHSItemFee.NewRow();
                            newRow["PRJCODE"] = currentRow["HSCODE"].ToString();
                            newRow["PRJNAME"] = currentRow["HSNAME"].ToString();
                            newRow["PRJFEE"] = Convert.ToDecimal(currentRow["TOTAL_FEE"]);
                            _currentPatHSItemFee.Rows.Add(newRow);
                        }
                    }
                    _currentPat.TotalFee = patTotalFee;
                    _currentPat.PrePayFee = patPrePayFee;
                    _formInterface.RefreshPatInfo(_currentPat);
                }
                _formInterface.RefreshPatFee(_currentPatItemFee,
                    _currentPatBigItemFee, _currentPatHSItemFee);
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    public interface IFrmZYPatfeeQuery
    {
        void RefreshPatInfo(QueryZYPatInfo pat);
        void RefreshPatFee(DataTable itemFee, DataTable bigitemFee, DataTable hsitemFee);
        void RefreshClincDept(DataTable clincDepts);
    }
}
