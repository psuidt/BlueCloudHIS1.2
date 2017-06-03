using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using GWMHIS.BussinessLogicLayer.Classes;
using HIS.ZY_BLL.DataModel;

namespace HIS_ZYManager.Action
{

    //[20100511.2.01]
    /// <summary>
    /// 入院登记界面接口
    /// </summary>
    public interface IFrmRegisterView
    {
        User currentUser { get; }
        Deptment currentDept { get; }
        void Initialize(DataSet _dataSet);
        SearchPatList searchPatList { get; }
        DataTable cbDept_set { set; }
        List<ZY_PatList> zyPatLists { set; }
        ZY_PatList zyPatList { get; set; }
        string InpatNo { get; set; }
    }
    //[20100511.2.01]
    public interface IFrmSearchPatView
    {
        string searchValue { get; }
        DataTable patListInfo { set; }
        int SelectIndex { get; }
        int RowIndex { get; }
    }

}
