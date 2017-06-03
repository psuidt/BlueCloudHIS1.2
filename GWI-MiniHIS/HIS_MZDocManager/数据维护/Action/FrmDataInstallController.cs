using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS_MZDocManager.Action
{
    class FrmDataInstallController
    {
        IDataInstall _view;

        public FrmDataInstallController(IDataInstall view)
        {
            _view = view;
        }
       
        public void LoadData()
        {
            _view.BindMainData = _view.CommonSub.LoadCommonData(_view.currentUser.EmployeeID);
            _view.CurrentStatus = HIS.MZDoc_BLL.Public.CurrentStatus.查询状态;
        }

        public void AddRow<T>()
        {
            DataTable dt = _view.BindMainData;
            int rowid;
            if (dt.Rows.Count > 0)
            {
                rowid = dt.Rows.Count - 1;
                foreach (object value in dt.Rows[rowid].ItemArray)
                {
                    if (XcConvert.IsNull(value,"") != "")
                    {
                        List<T> _commonSubs = new List<T>();
                        T _commonSub = (T)System.Activator.CreateInstance(typeof(T));
                        _commonSubs.Add(_commonSub);
                        DataTable ddt = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(_commonSubs);
                        dt.Rows.Add(ddt.Rows[0].ItemArray);
                        _view.RowIndex = dt.Rows.Count - 1;
                        return;
                    }
                }
            }
            else
            {
                List<T> _commonSubs = new List<T>();
                T _commonSub = (T)System.Activator.CreateInstance(typeof(T));
                _commonSubs.Add(_commonSub);

                _view.BindMainData = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(_commonSubs);
                dt = _view.BindMainData;
            }

            _view.RowIndex = dt.Rows.Count - 1;
        }

        public void SelectCardBindData(int rowid, DataRow row)
        {
            DataTable dt = _view.BindMainData;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                for (int j = 0; j < row.Table.Columns.Count; j++)
                {
                    if (dt.Columns[i].ColumnName.ToLower().Trim() == row.Table.Columns[j].ColumnName.ToLower().Trim())
                    {
                        dt.Rows[rowid][i] = XcConvert.IsNull(row[j], "");
                        continue;
                    }
                }
            }
        }

        public bool Save()
        {
            if (_view.CurrentStatus == HIS.MZDoc_BLL.Public.CurrentStatus.新建状态)
            {
                return _view.CommonSub.Add();
            }
            else if (_view.CurrentStatus == HIS.MZDoc_BLL.Public.CurrentStatus.修改状态)
            {
                return _view.CommonSub.Update();
            }
            return false;
        }

        public bool Delete()
        {
            return _view.CommonSub.Delete();
        }
    }
}
