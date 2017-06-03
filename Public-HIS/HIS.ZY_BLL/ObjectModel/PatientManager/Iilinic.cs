using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.ZY_BLL.DataModel;

namespace HIS.ZY_BLL.ObjectModel.PatientManager
{
    /// <summary>
    /// 访问病人列表接口
    /// </summary>
    public interface Iilinic
    {
        void updateCureDoc(string EmpID);
        void updatePatType(string pattype);
        void updateCurrDept(string DeptID);
        void updateBedCode(string bedcode);
        void updatePatOut(int flag,string diagncode,string diagnname,DateTime outdate);
        string getPatType();
        ZY_PatList GetPatInfo(string CureNo);
        ZY_PatList GetPatInfo(int patlistid);
    }
}
