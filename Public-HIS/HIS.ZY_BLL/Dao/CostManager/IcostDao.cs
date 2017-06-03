using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.ZY_BLL.Dao.CostManager
{
    public interface IcostDao : IbaseDao
    {
        decimal[] GetMenoyAndPosFee(string ChargeCode);
        DataTable GetDetailCharge(string ChargeCode, int feeType);
        void UpdateAccount(string ChargeCode, int ID);
        DataTable GetTicketTotle(int AccountID);
        DataTable GetTicketTotle(int[] AccountIDs);
        decimal[] GetTotleType(int AccountID);
        decimal GetfaoverAll_Fee(int patlistid, string patientcode, decimal costFee);
        decimal GetvillageAll_Fee(int patlistid);
        decimal GetvillageAll_Fee(int patlistid, DateTime costdate);
        void UpdateRecord_Flag(int CostMasterID, int Record_Flag);
        string GetNewTicketNo(DateTime date);
        void UpdateCostMID(int oldCMID, int NewCMID);
        string GetDeptName(int patlistid);

        DataTable GetPatOrderFee(int PatListID);
        DataTable GetPatBigItemOrderFee(int PatListID);
        DataTable GetProject();
        DataTable GetItem();
    }
}
