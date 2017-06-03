using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.ZY_BLL.Dao.PresManager
{
    public interface IpresDao : IbaseDao
    {
        DataTable GetSendGrugPres(int patlistid, string deptcode);
        DataTable GetSendGrugPres(int patlistid);
        decimal GetSendGrugPresTotalFee(int patlistid, string deptcode);
        DataTable GetSendGrugPres(string cureNO, string deptcode);
        decimal GetNoCostAll_Fee(int patlistid);
        decimal GetNoCostAll_Fee(int patlistid, DateTime costdate);
        void AlterCostID(int patlistID, int CostID, int CostType);
        void AlterCostID(int oldCostID, int newCostID);
        DataTable GetNotSendDurgPresDataTable(int PatListID);
        decimal GetPresAllFee(DateTime PresDate, int PresType,int PatListID);
    }
}
