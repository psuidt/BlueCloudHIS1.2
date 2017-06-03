using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.YZCX_BLL;
using System.Collections;
using HIS.Model;

namespace HIS_YZCXManager
{
    public class FrmCheckQueryControl
    {
        public FrmCheckQueryControl(IFrmCheckQuery frmCheckQuery)
        {
            _frmCheckQuery = frmCheckQuery;
            _drugInfo = YP_Loader.LoadUseDrug();
            _drugDeptList = YP_Loader.GetAllDrugDept();
            _frmCheckQuery.RefreshDrugInfo(_drugInfo);
        }

        private DataTable _drugInfo;
        private DataTable _checkInfoDt;
        private DataTable _checkAuditInfo;
        private List<YP_DeptDic> _drugDeptList;
        private string _drugType;
        private IFrmCheckQuery _frmCheckQuery;
        private int _queryMakerId = 0;
        public void SetMakerDicId(int makerDicId)
        {
            _queryMakerId = makerDicId;
        }


        public void LoadCheckOrder(int auditNo, YP_DeptDic drugDept)
        {
            try
            {
                _checkInfoDt = YP_Loader.LoadCheckInfo(auditNo, drugDept.DeptID, drugDept.DeptType1, _drugType, _queryMakerId);
                _frmCheckQuery.RefreshCheckOrder(_checkInfoDt);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void LoadData(string drugType, DateTime beginDate, DateTime endDate, string rptPath)
        {
            try
            {
                _checkAuditInfo = YP_Loader.LoadCheckBillFee(beginDate, endDate, drugType, _queryMakerId);
                _drugType = drugType;
                _frmCheckQuery.ShowCheckMaster(_checkAuditInfo, _drugDeptList);
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    public interface IFrmCheckQuery
    {
        void ShowCheckMaster(DataTable checkAuditInfo, List<YP_DeptDic> drugDeptList);
        void RefreshCheckOrder(DataTable checkOrderDt);
        void RefreshDrugInfo(DataTable drugInfo);
    }
}
