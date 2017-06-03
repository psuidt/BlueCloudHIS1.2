using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using GWMHIS.BussinessLogicLayer.Classes;

namespace HIS_ZYNurseManager.Action
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

        //HIS.Model.ZY_PatList zy_patlist_get { get; }
        //SearchPatList searchPatList { get; }
        //DataTable cbDept_set { set; }
        //List<HIS.Model.ZY_PatList> lvPatList_set { set; }
    }
}
