using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using GWMHIS.BussinessLogicLayer.Classes;
using HIS.ZY_BLL.DataModel;

namespace HIS_ZYManager.Action
{
    /// <summary>
    /// 查询病人条件的结构
    /// </summary>
    public struct SearchPatList
    {
        public bool rbIn;
        public string DeptCode;

        public DateTime? Bdate;
        public DateTime? Edate;
    }

    public interface IView
    {
        User currentUser { get; }
        Deptment currentDept { get; }
        void Initialize(DataSet _dataSet);

        ZY_PatList zy_patlist_get { get; }
        SearchPatList searchPatList { get; }
        DataTable cbDept_set { set; }
        List<ZY_PatList> lvPatList_set { set; }
    }
}
